clear

$hasNext = $null
$aggrgtCnt = @()
$type = ''
$repo = Read-Host -Prompt 'Enter Target Repo'
$type = Read-Host -Prompt 'Enter Type'
$user = Read-Host -Prompt 'Enter User'
$pass = Read-Host -Prompt 'Enter Password' -AsSecureString

$pair = "$($user):$([Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($pass)))"


$APIRequest = "https://api.bitbucket.org/2.0/repositories/mpower-ondemand/$repo/$type/"

$encodedCreds = [System.Convert]::ToBase64String([System.Text.Encoding]::ASCII.GetBytes($pair))

$basicAuthValue = "Basic $encodedCreds"

$Headers = @{ Authorization = $basicAuthValue }

while($hasNext -ne "false")
{

    $webResult = Invoke-WebRequest -Uri $APIRequest -Headers $Headers

    $resultCotent = $webResult.Content | ConvertFrom-Json

    foreach($value in $resultCotent.values)
    {
        $aggrgtCnt += $value

        if($resultCotent.next -eq $null)
        {
            $hasNext = "false"
        }
    }

    $APIRequest = $resultCotent.next

}

write-host "Content Count: " $aggrgtCnt.Count

$aggrgtCnt | Out-GridView

