---
title: Manuální integrace Aspose.Slides v režimu integrace SSRS 2012 se službou SharePoint
type: docs
weight: 100
url: /cs/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Tento článek vás naučí, jak ručně integrovat Aspose.Slides pro Reporting Services v konceptu integrace SSRS 2012 se službou SharePoint. 

{{% /alert %}} 
## **Integrace Aspose.Slides s SSRS 2012 v režimu integrace se službou SharePoint**
Manuální instalace zde používá DLL místo instalátoru MSI. 

Doporučujeme nainstalovat produkt pomocí instalátoru MSI, protože provádí všechny potřebné instalační procesy a konfigurační úkoly automaticky. Pokud však automatická instalace pomocí instalátoru MSI selže, postupujte podle následujících kroků:

1. Zkopírujte **Aspose.Slides.ReportingServices.dll** ze složky **Universal** do bin adresáře **SharePoint RS**.  
   V našem případě se jedná o *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Aktualizujte soubor **rssrvpolicy.config** služby SharePoint (ze složky *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) stejným způsobem, jak je popsáno v článku [Manuální instalace Aspose.Slides pro Reporting Services](https://docs.aspose.com/slides/cs/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/). 
1. Spusťte tento skript v PowerShellu, ale nahraďte rs_test názvem vaší aplikace Reporting Services. 

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

Pro více informací o cmdletech Reporting Service pro SharePoint si přečtěte [tento článek společnosti Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).