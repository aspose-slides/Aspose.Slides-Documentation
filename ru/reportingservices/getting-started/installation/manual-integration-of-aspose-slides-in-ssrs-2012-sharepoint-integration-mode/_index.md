---  
title: Ручная интеграция Aspose.Slides в SSRS 2012 в режиме интеграции SharePoint  
type: docs  
weight: 100  
url: /ru/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/  
---  
  
{{% alert color="primary" %}}  
  
Эта статья научит вас, как вручную интегрировать Aspose.Slides для Reporting Services в концепции интеграции SharePoint в SSRS 2012.  
  
{{% /alert %}}  
## **Интеграция Aspose.Slides с SSRS 2012 в режиме интеграции SharePoint**  
Ручная установка здесь использует DLL вместо установщика MSI.  
  
Мы рекомендуем установить продукт с помощью установщика MSI, поскольку он автоматически выполняет все необходимые процессы установки и задачи конфигурации. Однако если автоматическая установка с помощью установщика MSI не удалась, следуйте этим шагам:  
  
1. Скопируйте **Aspose.Slides.ReportingServices.dll** из директории **Universal** в директорию бин **SharePoint RS**.  
   В нашем случае это *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin*  
1. Обновите файл **rssrvpolicy.config** SharePoint (из директории *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) так же, как описано в статье [Ручная установка Aspose.Slides для Reporting Services](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/).  
1. Запустите этот скрипт в Powershell, заменив rs_test на имя вашего приложения Reporting Services.  
  
**rs_test**  
  
``` xml  
  
  
Write-Host "Добавление расширений рендеринга Aspose.Slides"  
  
Add-PSSnapIn Microsoft.SharePoint.PowerShell  
  
  
Write-Host "Получение службы приложений ReportinService"  
  
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
  
Для получения дополнительной информации о командлетах Reporting Service для SharePoint прочитайте [эту статью Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).