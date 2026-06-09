---
title: Kolay ve Hafif Dağıtım
type: docs
weight: 50
url: /tr/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services, Microsoft SQL Server Reporting Services için bir [rendering extension](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) 'dir.
Aspose.Slides for Reporting Services, aşağıdakilerden birini çalıştıran bilgisayarlara kurulum yapabilen tek bir MSI kurucusu olarak sunulur:

- Microsoft SQL Server 2005 Reporting Services (32-bit ve 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit ve 64-bit)

Ayrıca Aspose.Slides for Reporting Services tek bir .NET derlemesinden (*Aspose.Slides*.ReportingServices.dll) oluştuğu için manuel olarak dağıtmak ve yönetmek de kolaydır; tamamen C# ile yazılmış, CLS uyumlu ve yalnızca güvenli yönetilen kod içerir.

{{% /alert %}} 

MSI kurucusu ve ZIP indirme paketi Aspose.Slides for ReportingServices içerir:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 ve .NET Framework 2.0 için derlenmiştir (x86 ve x64 için kullanılabilir)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 ve .NET Framework 2.0 için derlenmiştir (x86 ve x64 için kullanılabilir)

Kurulum sırasında Aspose.Slides.ReportingServices.dll, ReportServer\bin dizinine kopyalanır ve yapılandırma dosyası güncellenerek Reporting Services yeni render uzantısını tanır. Bu adımlar Aspose.Slides for Reporting Services kurucusu tarafından otomatik olarak gerçekleştirilir, ancak bu belgede daha sonra açıklanan şekilde manuel olarak da yapılabilir.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Aspose.Slides.ReportingServices.dll, **ReportServer\bin** dizinine kopyalanmıştır.