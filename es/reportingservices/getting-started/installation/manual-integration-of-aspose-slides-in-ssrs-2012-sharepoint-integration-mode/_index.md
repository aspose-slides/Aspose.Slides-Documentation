---
title: Integración manual de Aspose.Slides en el modo de integración de SharePoint de SSRS 2012
type: docs
weight: 100
url: /es/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---

{{% alert color="primary" %}} 

Este artículo te enseña cómo integrar Aspose.Slides para Reporting Services manualmente en el concepto de integración de SharePoint de SSRS 2012. 

{{% /alert %}} 
## **Integrando Aspose.Slides con SSRS 2012 en el modo de integración de SharePoint**
La instalación manual aquí utiliza el DLL en lugar del instalador MSI. 

Te recomendamos que instales el producto utilizando el instalador MSI porque realiza automáticamente todos los procesos de instalación y tareas de configuración necesarias. Sin embargo, si la instalación automática con el instalador MSI falla, estos son los pasos que debes seguir:

1. Copia el **Aspose.Slides.ReportingServices.dll** desde el directorio **Universal** al directorio bin de **SharePoint RS**. 
   En nuestro caso, es *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Actualiza el archivo **rssrvpolicy.config** de SharePoint (del directorio *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) de la misma manera descrita en el artículo sobre la [instalación manual de Aspose.Slides para Reporting Services](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/).
1. Ejecuta este script en Powershell, pero reemplaza rs_test con el nombre de tu aplicación de Reporting Services. 

**rs_test**

``` xml



Write-Host "Agregando extensiones de renderizado de Aspose.Slides"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Obteniendo el servicio de aplicación de ReportingService"

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

Para más información sobre los cmdlets de Reporting Service para SharePoint, lee [este artículo de Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).