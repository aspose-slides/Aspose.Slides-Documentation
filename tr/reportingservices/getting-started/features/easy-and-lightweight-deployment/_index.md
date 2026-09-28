---
title: Kolay ve Hafif Dağıtım
type: docs
weight: 50
url: /tr/reportingservices/easy-and-lightweight-deployment/
description: "Aspose.Slides for Reporting Services'in nasıl dağıtıldığını öğrenin: rapor sunucusunun bin klasöründe bir derleme, rapor sunucusu yapılandırmasına kaydedilir."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services, Microsoft SQL Server Reporting Services ve Power BI Report Server için bir [görselleştirme uzantısı](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) uzantısıdır.
Aspose.Slides for Reporting Services, desteklenen bir rapor sunucusunu, 32-bit veya 64-bit çalıştıran bilgisayarlara kurulabilen tek bir MSI yükleyicisi olarak sunulur; [Sistem Gereksinimleri](/slides/tr/reportingservices/system-requirements/) bölümüne bakın.

Aspose.Slides for Reporting Services, yalnızca bir .NET derlemesi *Aspose.Slides* *.ReportingServices.dll* içermesi, tamamen C# ile yazılmış olması, CLS uyumlu olması ve yalnızca güvenli yönetilen kod içermesi nedeniyle manuel olarak dağıtması ve yönetmesi de kolaydır.

{{% /alert %}}

ZIP indirmesi, rapor sunucuları için Aspose.Slides.ReportingServices.dll dosyasının iki derlemesini içerir:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 ve .NET Framework 2.0 için derlenmiştir (x86 ve x64 için kullanın)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 ve sonrası, Power BI Report Server ve .NET Framework 2.0 için derlenmiştir (x86 ve x64 için kullanın)

MSI yükleyicisi aynı iki derlemeyi kurar ve her rapor sunucusu örneği için doğru olanı seçer. [Manuel Yükleme](/slides/tr/reportingservices/install-manually/) ZIP indirmesindeki tüm dosyaları listeler.

Kurulum sırasında, Aspose.Slides.ReportingServices.dll, ReportServer\bin dizinine kopyalanır ve yapılandırma dosyası, Reporting Services'in yeni görselleştirme uzantısını tanıması için güncellenir. Bu adımlar Aspose.Slides for Reporting Services yükleyicisi tarafından gerçekleştirilir, ancak bu belgelerde daha sonra açıklanan şekilde manuel olarak da yapılabilir.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Şekil**: Aspose.Slides.ReportingServices.dll, **ReportServer\bin** dizinine kopyalanır.