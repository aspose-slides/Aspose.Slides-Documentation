---
title: Integração manual do Aspose.Slides no modo de integração do SharePoint no SSRS 2012
type: docs
weight: 100
url: /pt/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Este artigo ensina como integrar o Aspose.Slides for Reporting Services manualmente no conceito de integração do SharePoint no SSRS 2012. 

{{% /alert %}} 
## **Integrando o Aspose.Slides com o SSRS 2012 no modo de integração do SharePoint**
A instalação manual aqui usa o DLL em vez do instalador MSI. 

Recomendamos que você instale o produto usando o instalador MSI, pois ele realiza todas as etapas necessárias de instalação e tarefas de configuração automaticamente. No entanto, se a instalação automática com o instalador MSI falhar, estes são os passos que você deve seguir:

1. Copie o **Aspose.Slides.ReportingServices.dll** do diretório **Universal** para o diretório **SharePoint RS** bin.  
   No nosso caso, ele está em *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
2. Atualize o arquivo **rssrvpolicy.config** do SharePoint (do diretório *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) da mesma forma descrita no artigo [Instalação manual do Aspose.Slides para Reporting Services](https://docs.aspose.com/slides/pt/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/). 
3. Execute este script no PowerShell, mas substitua rs_test pelo nome da sua aplicação Reporting Services. 

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

Para mais informações sobre cmdlets do Reporting Service para SharePoint, leia [este artigo da Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).