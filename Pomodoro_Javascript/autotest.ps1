
# Install pswatch
<#
$m = Get-Module -List pswatch 
if(!$m) {
    Write-Host "You don't have the pswatch cmdlet installed. Let me handle that for you."
    iex ((new-object net.webclient).DownloadString("http://bit.ly/Install-PsWatch"))
}
#>

Import-Module pswatch
watch | %{
    $dateStamp = get-date -uformat "%Y-%m-%d@%H:%M:%S"
    write-host "RUNNING TESTS"
    write-host $dateStamp
    write-host "......"
    & "C:\Program Files (x86)\phantomjs\phantomjs.exe" phantomjs-qunit.js qunit-runner.html
}

