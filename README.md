# PowerShell for Office 365
This is the code repository for [PowerShell for Office 365](https://www.packtpub.com/networking-and-servers/powershell-office-365?utm_source=github&utm_medium=repository&utm_campaign=9781787127999), published by [Packt](https://www.packtpub.com/?utm_source=github). It contains all the supporting project files necessary to work through the book from start to finish.
## About the Book
While most common administrative tasks are available via the Office 365 admin center, many IT professionals are unaware of the real power that is available to them below the surface. This book aims to educate readers on how learning PowerShell for Office 365 can simplify repetitive or complex administrative tasks and enable greater control than is available on the surface.

The book starts by teaching readers how to access Office 365 through PowerShell and then explains the PowerShell fundamentals required for automating Office 365 tasks. You will then walk through common administrative cmdlets to manage accounts, licensing, and other scenarios such as automating the importing of multiple users, assigning licenses in Office 365, distribution groups, passwords, and so on. Using practical examples, you will learn to enhance your current functionality by working with Skype Online, Exchange Online, and SharePoint Online using PowerShell. Finally, the book will help you effectively manage complex and repetitive tasks (such as license and account management) and build productive reports.

By the end of the book, you will have automated major repetitive tasks in Office 365 using PowerShell.
## Instructions and Navigation
All of the code is organized into folders. For example, Chapter06.



The code will look like the following:
```
function Get-DailyProductSalesQuery{
 $module = Get-Module SalesDashboardModule;

 $filePath = $module.FileList | Where { $_ -like '*DailyProductSalesQuery*'}
 
 $sql = [System.IO.File]::ReadAllText($filePath).Trim();

 Write-Debug "Sql: $($sql)";
 return $sql;
}
```



## Related Products
* [PowerShell 3.0 Advanced Administration Handbook](https://www.packtpub.com/networking-and-servers/powershell-30-advanced-administration-handbook?utm_source=github&utm_medium=repository&utm_campaign=9781849686426)

* [Installing SharePoint 2013 Using PowerShell](https://www.packtpub.com/big-data-and-business-intelligence/installing-sharepoint-2013-using-powershell?utm_source=github&utm_medium=repository&utm_campaign=9781787122321)

* [Mastering Windows PowerShell 5 Administration [Video]](https://www.packtpub.com/networking-and-servers/mastering-windows-powershell-5-administration-video?utm_source=github&utm_medium=repository&utm_campaign=9781786467980)
