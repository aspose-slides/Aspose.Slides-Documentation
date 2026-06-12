---
title: Dukungan .NET 6
type: docs
weight: 235
url: /id/net/net6/
keywords:
- Dukungan .NET 6
- Solusi cloud
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Konfigurasikan Aspose.Slides untuk .NET 6 untuk membuat, mengedit, dan mengonversi presentasi PowerPoint PPT, PPTX, dan ODP dalam aplikasi C# modern yang lintas platform."
---
## **Pendahuluan**

Mulai dari [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), dukungan untuk .NET6 telah diimplementasikan. Keistimewaan dukungan ini adalah .NET6 tidak lagi mendukung System.Drawing.Common untuk Linux ([perubahan yang memutuskan kompatibilitas](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) dan Slides mengimplementasikan subsistem grafis ini sendiri sebagai komponen C++.

Aspose.Slides untuk .NET kini berfungsi tanpa ketergantungan pada GDI/libgdiplus di:
* Windows
* Linux

Dukungan _MacOS_ sedang dalam proses.

## **Menggunakan Slides untuk .NET 6 di AWS dan Azure**

.NET6 adalah versi yang disarankan untuk Aspose.Slides yang digunakan di cloud (AWS, Azure, atau solusi cloud lainnya).

Sebelumnya, ketika Aspose.Slides digunakan di host Linux, ketergantungan tambahan (libgdiplus) harus diinstal dan hal ini sering tidak praktis (misalnya, saat menggunakan [AWS Lambda](https://aws.amazon.com/lambda)). Dengan Slides untuk .NET6, ketergantungan tersebut tidak lagi diperlukan, sehingga proses penyebaran jauh lebih mudah.

Pertimbangan lain adalah masalah yang muncul ketika Aspose.Slides digunakan pada solusi cloud dengan host Windows. Misalnya, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) memiliki batasan proses dan menyebabkan masalah saat melakukan ekspor PDF (lihat [ini](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Penggunaan Aspose.Slides untuk .NET6 menyelesaikan masalah ini.

## **Menggunakan Paket System.Drawing.Common dan Kelas Slides untuk .NET 6 (CS0433: Kesalahan Tipe Ada di Slides dan System.Drawing.Common)**

Kadang-kadang, baik ketergantungan System.Drawing maupun Slides untuk .NET6 harus digunakan dalam satu proyek (misalnya, ketika proyek .NET6 bergantung pada paket lain yang pada gilirannya bergantung pada System.Drawing). Hal ini dapat menyebabkan kesalahan komplikasi seperti berikut:

* CS0433: Tipe 'Image' ada di both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' dan 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: Tipe 'Graphics' ada di both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' dan 'System.Drawing.Common, Version=6.0.0.0'

Dalam kasus ini, Anda dapat menggunakan [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) untuk Aspose.Slides (versi kurang dari 24.8):
1) Pilih assembly Aspose.Slides dari ketergantungan proyek, lalu klik **Properties**.
  ![Properti paket Aspose Slides](package_properties.png)
2) Atur alias (misalnya, "Slides").
  ![Alias Aspose Slides](set_alias.png)

Sekarang, tipe dari System.Drawing.Common akan digunakan secara default. Alias assembly eksternal harus ditentukan di mana tipe Aspose.Slides diperlukan.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Contoh lengkap:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

Mulai versi 24.8, API publik yang sudah usang dengan ketergantungan pada System.Drawing telah dihapus. Mengenai contoh kode di atas, Anda dapat memperoleh gambar slide seperti berikut.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
API baru dijelaskan secara lebih detail di [Modern API](/slides/id/net/modern-api/).