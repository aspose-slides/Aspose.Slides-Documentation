---
title: Manuell integration av Aspose.Slides i SSRS 2012 SharePoint-integrationsläge
type: docs
weight: 100
url: /sv/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 
Den här artikeln visar hur du integrerar Aspose.Slides för Reporting Services manuellt i SSRS 2012 SharePoint‑integrationskonceptet. 
{{% /alert %}} 
## **Integrera Aspose.Slides med SSRS 2012 i SharePoint‑integrationsläge**
Den manuella installationen här använder DLL‑filen i stället för MSI‑installationsprogrammet. 

Vi rekommenderar att du installerar produkten med MSI‑installationsprogrammet eftersom det utför alla nödvändiga installationsprocesser och konfigurationsuppgifter automatiskt. Om den automatiska installationen med MSI‑installationsprogrammet misslyckas, är detta stegen du måste följa:

1. Kopiera **Aspose.Slides.ReportingServices.dll** från **Universal**‑katalogen till **SharePonit RS**‑bin‑katalogen.
   I vårt fall är det *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin*
1. Uppdatera Sharepoints **rssrvpolicy.config**‑fil (från *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*‑katalogen) på samma sätt som beskrivs i artikeln [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/sv/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/).
1. Kör detta skript i PowerShell men ersätt rs_test med namnet på din Reporting Services‑applikation. 

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

För mer information om Reporting Service‑cmdlets för SharePoint, läs [den här Microsoft‑artikeln](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).