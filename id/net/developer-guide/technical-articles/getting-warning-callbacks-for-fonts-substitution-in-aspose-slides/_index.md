---
title: Dapatkan Panggilan Balik Peringatan untuk Substitusi Font di .NET
type: docs
weight: 120
url: /id/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- panggilan balik peringatan
- substitusi font
- proses rendering
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mendapatkan panggilan balik peringatan untuk substitusi font di Aspose.Slides untuk .NET dan menampilkan presentasi PowerPoint serta OpenDocument secara akurat."
---
## **Pendahuluan**

Aspose.Slides for .NET memungkinkan Anda menerima panggilan balik peringatan untuk substitusi font ketika font yang diperlukan tidak tersedia di mesin selama proses rendering. Panggilan balik ini membantu mendiagnosis masalah dengan font yang hilang atau tidak dapat diakses.

## **Mengaktifkan Panggilan Peringatan**

Aspose.Slides for .NET menyediakan API yang sederhana untuk menerima panggilan balik peringatan saat merender slide presentasi. Ikuti langkah-langkah berikut untuk mengonfigurasi panggilan balik peringatan:

1. Buat kelas callback khusus yang mengimplementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/net/aspose.slides.warnings/iwarningcallback/) untuk menangani peringatan.
1. Atur panggilan balik peringatan menggunakan kelas opsi seperti [RenderingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/), dan lainnya.
1. Muat presentasi yang menggunakan font yang tidak tersedia di mesin target.
1. Hasilkan thumbnail slide atau ekspor presentasi untuk melihat efeknya.

**Kelas Callback Peringatan Kustom:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Contoh output:
//
// Font akan disubstitusi dari XYZ ke {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Hasilkan Thumbnail Slide:**

```c#
// Menyiapkan callback peringatan untuk menangani peringatan terkait font selama render slide.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Memuat presentasi dari jalur file yang ditentukan.
using var presentation = new Presentation("sample.pptx");

// Menghasilkan gambar thumbnail untuk setiap slide dalam presentasi.
foreach (var slide in presentation.Slides)
{
    // Dapatkan gambar thumbnail slide menggunakan opsi rendering yang ditentukan.
    using var image = slide.GetImage(options);
    // ...
}
```

**Ekspor ke Format PDF:**

```c#
// Menyiapkan callback peringatan untuk menangani peringatan terkait font selama ekspor PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Memuat presentasi dari jalur file yang ditentukan.
using var presentation = new Presentation("sample.pptx");

// Mengekspor presentasi sebagai PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Ekspor ke Format HTML:**

```c#
// Menyiapkan callback peringatan untuk menangani peringatan terkait font selama ekspor HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Memuat presentasi dari jalur file yang ditentukan.
using var presentation = new Presentation("sample.pptx");

// Mengekspor presentasi dalam format HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```