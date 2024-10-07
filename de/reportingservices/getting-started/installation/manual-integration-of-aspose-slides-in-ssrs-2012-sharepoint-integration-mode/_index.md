---
title: Manuelle Integration von Aspose.Slides in SSRS 2012 SharePoint Integrationsmodus
type: docs
weight: 100
url: /reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---

{{% alert color="primary" %}} 

Dieser Artikel zeigt Ihnen, wie Sie Aspose.Slides für Reporting Services manuell im Konzept der SharePoint-Integration in SSRS 2012 integrieren. 

{{% /alert %}} 
## **Integration von Aspose.Slides mit SSRS 2012 im SharePoint Integrationsmodus**
Die manuelle Installation hier verwendet die DLL anstelle des MSI-Installers. 

Wir empfehlen, das Produkt mit dem MSI-Installer zu installieren, da es alle erforderlichen Installationsprozesse und Konfigurationsaufgaben automatisch durchführt. Wenn die automatische Installation mit dem MSI-Installer jedoch fehlschlägt, sind dies die Schritte, die Sie befolgen müssen:

1. Kopieren Sie die **Aspose.Slides.ReportingServices.dll** aus dem **Universal**-Verzeichnis in das Bin-Verzeichnis von **SharePoint RS**.
   In unserem Fall ist es *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Aktualisieren Sie die **rssrvpolicy.config**-Datei von Sharepoint (aus dem *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*-Verzeichnis) auf die gleiche Weise, wie sie im Artikel [Manuelle Installation von Aspose.Slides für Reporting Services](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) beschrieben wird.
1. Führen Sie dieses Skript in PowerShell aus, ersetzen Sie dabei rs_test durch den Namen Ihrer Reporting Services-App.

**rs_test**

``` xml



Write-Host "Füge Aspose.Slides Rendering-Erweiterungen hinzu"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Get ReportingService-Anwendungsdienst"

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

Für weitere Informationen zu Reporting-Service-Cmdlets für SharePoint lesen Sie [diesen Microsoft-Artikel](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).