---
title: Ręczna integracja Aspose.Slides w trybie integracji SharePoint w SSRS 2012
type: docs
weight: 100
url: /pl/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Ten artykuł wyjaśnia, jak ręcznie zintegrować Aspose.Slides for Reporting Services w koncepcji integracji SharePoint w SSRS 2012. 

{{% /alert %}} 
## **Integracja Aspose.Slides z SSRS 2012 w trybie integracji SharePoint**
Ręczna instalacja tutaj wykorzystuje plik DLL zamiast instalatora MSI.

Zalecamy zainstalowanie produktu przy użyciu instalatora MSI, ponieważ automatycznie wykonuje wszystkie niezbędne procesy instalacyjne i zadania konfiguracyjne. Jeśli jednak automatyczna instalacja przy użyciu instalatora MSI nie powiedzie się, należy wykonać następujące kroki:

1. Skopiuj **Aspose.Slides.ReportingServices.dll** z katalogu **Universal** do katalogu bin **SharePonit RS**.
   W naszym przypadku jest to *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Zaktualizuj plik **rssrvpolicy.config** Sharepointu (z katalogu *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) w taki sam sposób, jak opisano w artykule [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/pl/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/).
1. Uruchom ten skrypt w PowerShell, zamieniając rs_test na nazwę Twojej aplikacji Reporting Services. 

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

Aby uzyskać więcej informacji o cmdletach Reporting Service dla SharePoint, przeczytaj [ten artykuł Microsoftu](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).