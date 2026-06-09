---
title: Aspose.Slides'ın SSRS 2012 SharePoint Entegrasyon Modunda Manuel Entegrasyonu
type: docs
weight: 100
url: /tr/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Bu makale, Aspose.Slides for Reporting Services'ı SSRS 2012 SharePoint entegrasyon konseptinde manuel olarak nasıl entegre edeceğinizi öğretir. 

{{% /alert %}} 
## **Aspose.Slides'ı SSRS 2012'de SharePoint Entegrasyon Modu ile Entegre Etme**
Buradaki manuel kurulum, MSI yükleyicisi yerine DLL kullanır. 

Ürünü MSI yükleyicisiyle kurmanızı öneririz; çünkü gerekli tüm kurulum işlemlerini ve yapılandırma görevlerini otomatik olarak gerçekleştirir. Ancak MSI yükleyicisiyle otomatik kurulum başarısız olursa, aşağıdaki adımları izlemelisiniz:

1. **Aspose.Slides.ReportingServices.dll** dosyasını **Universal** dizininden **SharePonit RS** bin dizinine kopyalayın.  
   Bizim örneğimizde, bu *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* dizinidir.  
2. Sharepoint'in **rssrvpolicy.config** dosyasını ( *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* dizininden) aynı şekilde [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/tr/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) makalesinde açıklanan gibi güncelleyin.  
3. Bu komut dosyasını Powershell'de çalıştırın, ancak **rs_test** ifadesini Reporting Services uygulamanızın adıyla değiştirin.  

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

SharePoint için Reporting Service cmdlet'leri hakkında daha fazla bilgi için [bu Microsoft makalesi](http://technet.microsoft.com/en-us/library/gg492249?ppud=4) makalesini okuyun.