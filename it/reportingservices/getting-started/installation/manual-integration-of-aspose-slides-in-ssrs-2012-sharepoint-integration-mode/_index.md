---
title: Integrazione manuale di Aspose.Slides in modalità integrazione SharePoint di SSRS 2012
type: docs
weight: 100
url: /it/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Questo articolo spiega come integrare manualmente Aspose.Slides per Reporting Services in modalità di integrazione SharePoint di SSRS 2012. 

{{% /alert %}} 
## **Integrazione di Aspose.Slides con SSRS 2012 in modalità integrazione SharePoint**
L'installazione manuale qui utilizza il DLL al posto del programma di installazione MSI. 

Consigliamo di installare il prodotto utilizzando il pacchetto MSI perché esegue automaticamente tutti i processi di installazione e le attività di configurazione necessari. Tuttavia, se l'installazione automatica con MSI fallisce, questi sono i passaggi da seguire:

1. Copiare **Aspose.Slides.ReportingServices.dll** dalla directory **Universal** alla directory bin di **SharePonit RS**.  
   Nel nostro caso, è *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Aggiornare il file **rssrvpolicy.config** di Sharepoint (dalla directory *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) nello stesso modo descritto nell'articolo [installazione manuale di Aspose.Slides per Reporting Services](https://docs.aspose.com/slides/it/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/). 
1. Eseguire questo script in Powershell sostituendo rs_test con il nome della propria applicazione Reporting Services. 

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

Per ulteriori informazioni sui cmdlet di Reporting Service per SharePoint, leggere [questo articolo Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).