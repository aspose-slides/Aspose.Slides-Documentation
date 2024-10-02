---
title: Manual integration of Aspose.Slides in SSRS 2012 SharePoint Integration Mode
type: docs
weight: 100
url: /reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---

{{% alert color="primary" %}} 

This article teaches you how to integrate Aspose.Slides for Reporting Services manually in SSRS 2012 SharePoint integration concept. 

{{% /alert %}} 
## **Integrating Aspose.Slides with SSRS 2012 in SharePoint Integration Mode**
The manual installation here uses the DLL in place of the MSI installer. 

We recommend you install the product using the MSI installer because it performs all necessary installation processes and configuration tasks automatically. However, if the automatic installation with MSI installer fails, these are steps you must follow:

1. Copy the **Aspose.Slides.ReportingServices.dll** from the **Universal** directory to the **SharePonit RS** bin directory.
   In our case, it's *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Update Sharepoint's **rssrvpolicy.config** file (from the *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* directory) in the same way described in the [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) article.
1. Run this script in Powershell but replace rs_test with the name of your Reporting Services app name. 

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

For more information on Reporting Service cmdlets for SharePoint, read [this Microsoft article](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).
