<#
	Get Daily number of items sold by product
#>
function Get-DailyProductSalesTotals {
	 [cmdletbinding()]
    param (
	[Parameter(
            Mandatory = $false,
            HelpMessage = 'Enter a date to start from e.g.:(Get-Date("MM/DD/YYYY"))'
        )]
        [Alias('StartDate','Date')]
        [DateTime]$dateFilter = ([System.Data.SqlTypes.SqlDateTime]::MinValue.Value)
	)
	
	Write-Debug "$($dateFilter)";

	$sql = Get-DailyProductSalesQuery;
	$sqlParams = "FILTERDATE=$($dateFilter.ToString('yyyy-MM-dd'))"
	
	Write-Debug "$($sqlParams)";

	Invoke-Sqlcmd -Query $sql -ServerInstance "Sql17\tests" -Variable $sqlParams
}

function Get-DailyProductSalesQuery{
	$module = Get-Module SalesDashboardModule;

	$filePath = $module.FileList | Where { $_ -like '*DailyProductSalesQuery*'}
	
	$sql = [System.IO.File]::ReadAllText($filePath).Trim();

	Write-Debug "Sql: $($sql)";

	return $sql;
}