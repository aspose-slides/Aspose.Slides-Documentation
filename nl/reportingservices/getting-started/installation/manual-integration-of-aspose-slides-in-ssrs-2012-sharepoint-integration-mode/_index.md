---
title: Handmatige integratie van Aspose.Slides in de SSRS 2012 SharePoint integratiemodus
type: docs
weight: 100
url: /nl/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Dit artikel leert u hoe u Aspose.Slides for Reporting Services handmatig kunt integreren in het SSRS 2012 SharePoint‑integratieconcept. 

{{% /alert %}} 
## **Aspose.Slides integreren met SSRS 2012 in SharePoint‑integratiemodus**
De handmatige installatie hier maakt gebruik van de DLL in plaats van de MSI‑installatie. 

We raden aan het product te installeren met de MSI‑installatie, omdat deze alle benodigde installatieprocessen en configuratietaken automatisch uitvoert. Als de automatische installatie met de MSI‑installatie echter mislukt, volgt u de volgende stappen:

1. Kopieer de **Aspose.Slides.ReportingServices.dll** vanuit de **Universal**‑map naar de **SharePoint RS**‑bin‑map.
   In ons geval is dit *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Werk het **rssrvpolicy.config**‑bestand van SharePoint bij (vanuit de *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* map) op dezelfde manier zoals beschreven in het artikel [Aspose.Slides for Reporting Services handmatige installatie](https://docs.aspose.com/slides/nl/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/). 
1. Voer dit script uit in PowerShell, maar vervang rs_test door de naam van uw Reporting Services‑applicatie. 

**rs_test**

``` xml



Write-Host "Adding Aspose.Slides rendering extensions"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Get ReportinService Application Service"

$app = get-sprsserviceapplication



if ($app) {

                $app | ForEach-Object {



                $aspps = Get-SPRSExtension -Identity $_ -Name "ASPPS" -ExtensionType "Render"

                $aspptx = Get-SPRSExtension -Identity $_ -Name "ASPPTX" -ExtensionType "Render"

                $asppsx = Get-SPRSExtension -Identity $_ -Name "ASPPSX" -ExtensionType "Render"

                $asppt = Get-SPRSExtension -Identity $_ -Name "ASPPT" -ExtensionType "Render"



                if (-not $aspps ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPS" -TypeName "Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices" }

                if (-not $aspptx) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPTX" -TypeName "Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppsx ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPSX" -TypeName "Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppt ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPT" -TypeName "Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"}

                }

}



```

Voor meer informatie over Reporting Service‑cmdlets voor SharePoint, lees [dit Microsoft‑artikel](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).