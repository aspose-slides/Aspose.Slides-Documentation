---
title: Penyebaran Mudah dan Ringan
type: docs
weight: 50
url: /id/reportingservices/easy-and-lightweight-deployment/
description: "Pelajari cara Aspose.Slides for Reporting Services di-deploy: satu assembly di folder bin server laporan, terdaftar dalam konfigurasi server laporan."
---
{{% alert color="info" title="Catatan" %}}

Aspose.Slides for Reporting Services adalah sebuah [rendering extension](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) untuk Microsoft SQL Server Reporting Services dan Power BI Report Server.  
Aspose.Slides for Reporting Services disediakan sebagai satu paket instalasi MSI tunggal yang dapat dipasang pada komputer yang menjalankan server laporan yang didukung, 32‑bit atau 64‑bit; lihat [System Requirements](/slides/id/reportingservices/system-requirements/).

Selain itu, mudah untuk menyebarkan dan mengelola Aspose.Slides for Reporting Services secara manual, karena hanya terdiri dari satu assembly .NET *Aspose.Slides* *.ReportingServices.dll* , sepenuhnya ditulis dalam C#, mematuhi CLS, dan hanya berisi kode terkelola yang aman.

{{% /alert %}}

Unduhan ZIP mencakup dua build Aspose.Slides.ReportingServices.dll untuk server laporan:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – dibangun untuk Microsoft SQL Server 2005 dan .NET Framework 2.0 (digunakan untuk x86 dan x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – dibangun untuk Microsoft SQL Server 2008 dan yang lebih baru, Power BI Report Server serta .NET Framework 2.0 (digunakan untuk x86 dan x64)

Instalasi MSI memasang dua build yang sama dan memilih yang tepat untuk setiap instance server laporan. [Install Manually](/slides/id/reportingservices/install-manually/) mencantumkan setiap file dalam unduhan ZIP.

Saat menginstal, Aspose.Slides.ReportingServices.dll disalin ke direktori ReportServer\bin dan file konfigurasi diperbarui sehingga Reporting Services menyadari ekstensi rendering baru. Langkah‑langkah ini dilakukan oleh installer Aspose.Slides for Reporting Services, tetapi Anda juga dapat melakukannya secara manual seperti yang dijelaskan lebih lanjut dalam dokumentasi ini.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Aspose.Slides.ReportingServices.dll disalin ke dalam direktori **ReportServer\bin**.