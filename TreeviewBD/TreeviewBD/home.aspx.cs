using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                using (DataTable datatable = DataLayer.GetTreeviewCandidate())
                {
                    foreach (DataRow dataRow in datatable.Rows)
                    {
                         TreeNode parentNode = new TreeNode();
                         parentNode.Text = dataRow["DepartmentLevel1"].ToString();
                         parentNode.Value = dataRow["DepartmentLevel1"].ToString();
                         arvore.Nodes.Add(parentNode);

                    }

                }

            }
        }

        public void ExpandArvore(TreeNode parentNode)
        {
            try { 
            
                TreeNode childnode;

                using (DataTable dataTable1 = DataLayer.GetTreeviewCandidateDP1())
                {

                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        TreeNode t = new TreeNode();
                        t.Text = dataRow1["DepartmentLevel2"].ToString();
                        parentNode.ChildNodes.Add(t);
                       // childnode = t;

                        using (DataTable dataTable2 = DataLayer.GetTreeviewCandidateDP2())
                        {

                            foreach(DataRow dataRow2 in dataTable2.Rows)
                            {
                                TreeNode t2= new TreeNode();
                                t2.Text = dataRow2["DepartmentLevel3"].ToString();
                                t.ChildNodes.Add(t2);
                               // childnode = t2;



                            }
                        }
                    }
                }


                //using (DataTable dataTable2 = DataLayer.GetTreeviewCandidateDP2())
                //{
                //    foreach (DataRow dataRow2 in dataTable2.Rows)
                //    {
                //        TreeNode childnode = new TreeNode();
                //        childnode.Text = dataRow2["DepartmentLevel3"].ToString();
                //        parentNode.ChildNodes.Add(childnode);
                //    }
                //}

                //using (DataTable dataTable3 = DataLayer.GetTreeviewCandidateDP3())
                //{
                //    foreach (DataRow dataRow3 in dataTable3.Rows)
                //    {
                //      TreeNode childnode3 = new TreeNode();
                //        childnode3.Text = dataRow3["DepartmentLevel4"].ToString();
                //        parentNode.ChildNodes.Add(childnode3);
                //    }
                //}

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        protected void arvore_SelectedNodeChanged(object sender, EventArgs e)
        {
            ExpandArvore((sender as TreeView).SelectedNode); //chamada generica
        }

     

    }
}