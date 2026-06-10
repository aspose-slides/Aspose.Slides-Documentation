---
title: Aspose.Slides manuális integrálása az SSRS 2012 SharePoint integrációs módban
type: docs
weight: 100
url: /hu/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Ez a cikk bemutatja, hogyan integrálhatja az Aspose.Slides for Reporting Services terméket manuálisan az SSRS 2012 SharePoint integrációs koncepcióban. 

{{% /alert %}} 
## **Az Aspose.Slides integrálása az SSRS 2012-be SharePoint integrációs módban**
A manuális telepítés itt az MSI telepítő helyett a DLL-t használja. 

Javasoljuk, hogy a terméket az MSI telepítő segítségével telepítse, mivel ez automatikusan elvégzi a szükséges telepítési folyamatokat és konfigurációs feladatokat. Ha azonban az automatikus MSI telepítés nem sikerül, az alábbi lépéseket kell követnie:

1. Másolja a **Aspose.Slides.ReportingServices.dll** fájlt a **Universal** könyvtárból a **SharePonit RS** bin könyvtárba.
   Ebben az esetben ez a *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Frissítse a Sharepoint **rssrvpolicy.config** fájlját (a *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* könyvtárból) ugyanúgy, ahogyan az [Aspose.Slides for Reporting Services manuális telepítése](https://docs.aspose.com/slides/hu/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) cikkben le van írva. 
1. Futtassa ezt a szkriptet a PowerShellben, de cserélje le az rs_test-et a Reporting Services alkalmazás nevére. 

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

További információk a Reporting Service cmdletekről a SharePointhoz, olvassa el [ezt a Microsoft cikket](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).