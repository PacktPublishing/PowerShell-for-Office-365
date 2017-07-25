using Microsoft.SharePoint.Client;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace MySpoCmdlets
{
[Cmdlet(VerbsCommon.Get, "DashboardList")]
public class GetListCommand : Cmdlet
{
    /// <summary>
    /// SharePoint Online Client Context 
    /// </summary>
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    [ValidateNotNullOrEmpty]
    public ClientContext ClientContext { get; set; }
    /// <summary>
    /// The ProcessRecord method creates or retrieves the list
    /// and sends it to the PowerShell pipeline
    /// </summary>
    protected override void ProcessRecord()
    {

        var list = EnsureList(ClientContext);

        WriteObject(list);
    }

    List EnsureList(ClientContext ctx)
    {

        var lists = ctx.Web.Lists;

        var listTitle = "ProductSales";

        ctx.Load(lists, ls => ls.Where(i => i.Title == listTitle));
        ctx.ExecuteQuery();

        List list = lists.FirstOrDefault();

        if (lists.Count == 0)
        {
            var listInfo = new ListCreationInformation()
            {
                TemplateType = (int)ListTemplateType.GenericList,
                Title = listTitle
            };

            list = ctx.Web.Lists.Add(listInfo);

            var fields = new List<string>()
            {
                "<Field Type='Text' Name='ProductName' DisplayName='Product Name' />",
                "<Field Type='DateTime' Name='SalesDate' DisplayName='Sales Date' Format='DateOnly' />",
                "<Field Type='Number' Name='SalesTotal' DisplayName='Sales Total'/>"
            };

            foreach (var field in fields)
            {
                list.Fields.AddFieldAsXml(field, true, AddFieldOptions.AddFieldInternalNameHint);
            }

        }

        ctx.Load(list);
        ctx.ExecuteQuery();

        return list;
    }

}

}
