﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeviewBD
{
	public partial class home : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                TreeNode node = new TreeNode();
                node.ImageUrl = "~/imagens/GRUPO.png";
                node.Text = "CONTOSO";
                node.Value = "DC=CONTOSO,DC=LOCAL";
                arvore.Nodes.Add(node);
            }
        }

        public string[] GetOUs(string path)

        {
            List<string> obj = new List<string>(); //nao precisa de tamanho fixo
                                                   // List<string> users = new List<string>();


            DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.92.200/" + path, "contoso\\administrator", "Br@sil01");

            foreach (DirectoryEntry child in entry.Children)//cria uma var que vai navegar pelos filhos do AD
            {
                if (child.SchemaClassName == "organizationalUnit") //seleciona apenas o tipo OU
                {
                    obj.Add(child.Path.Split('/')[3]); //seleciona um separador, passando o index do que vc quer retornar


                }

                else if (child.SchemaClassName == "user")
                {

                    obj.Add(child.Path.Split('/')[3]);
                }
            }

            entry.Dispose();
            return obj.ToArray(); // converter um list para tipo array
        }



        public void ExpandArvore(TreeNode node)
        {
            try
            {
                //string[] directories = Directory.GetDirectories(node.Value);
                string[] directories = GetOUs(node.Value);


                foreach (string directory in directories)//cria uma var que vai percorrer o array listado acima
                {
                    TreeNode childNote = new TreeNode();

                    //childNote.Text = directory.Split('\\')[directory.Split('\\').Length -1];
                    childNote.Text = directory.Split(',')[0].Split('=')[1];

                    if (directory.StartsWith("OU"))
                    {
                        childNote.ImageUrl = "~/imagens/GRUPO.png";

                    }
                    else if (directory.StartsWith("CN"))
                    {
                        childNote.ImageUrl = "~/imagens/USUARIO.png";

                    }

                    childNote.Value = directory;
                    node.ChildNodes.Add(childNote);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected void arvore_SelectedNodeChanged(object sender, EventArgs e)
        {
            ExpandArvore((sender as TreeView).SelectedNode); //chamada generica
        }
    }
}