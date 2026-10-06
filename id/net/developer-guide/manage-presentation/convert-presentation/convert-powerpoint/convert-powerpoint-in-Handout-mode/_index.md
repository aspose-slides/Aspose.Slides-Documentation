---
title: Konversi Presentasi PowerPoint dalam Mode Handout di .NET
linktitle: Mode Handout
type: docs
weight: 150
url: /id/net/convert-powerpoint-in-handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PowerPoint
- presentasi
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi menjadi handout di .NET. Atur jumlah slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides, beserta contoh kode C#. Coba gratis."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi ke format output yang mendukung mode Handout. Dalam mode ini, beberapa slide diatur pada satu halaman, yang berguna untuk mencetak materi presentasi untuk konferensi, seminar, dan acara serupa.

Mode Handout dikonfigurasi melalui properti `SlidesLayoutOptions`, yang tersedia di [IPdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/ihtmloptions/), dan [ITiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/itiffoptions/). Untuk menentukan tata letak handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/handoutlayoutingoptions/).

Untuk mengatur dimensi dan orientasi halaman handout sebelum ekspor, lihat [Notes Page Size](/slides/id/net/notes-size/).

## **Ekspor Mode Handout**

Untuk mengekspor presentasi dalam mode Handout, atur properti `SlidesLayoutOptions` pada opsi ekspor target dan beri instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/handoutlayoutingoptions/) yang mendefinisikan jumlah slide per halaman serta parameter tampilan terkait.

Berikut contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Muat sebuah presentasi.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slide pada satu halaman secara horizontal
        PrintSlideNumbers = true,                   // cetak nomor slide
        PrintFrameSlide = true,                     // cetak bingkai di sekitar slide
        PrintComments = false                       // tidak ada komentar
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Perlu diingat bahwa properti `SlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar. 
{{% /alert %}} 

## **FAQ**

### Apa jumlah maksimum thumbnail slide per halaman dalam mode Handout?

Aspose.Slides mendukung [presets](https://reference.aspose.com/slides/id/net/aspose.slides.export/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

### Dapatkah saya mendefinisikan grid khusus, seperti 5 atau 8 slide per halaman?

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh enumerasi [HandoutType](https://reference.aspose.com/slides/id/net/aspose.slides.export/handouttype/); tata letak arbitrer tidak didukung.

### Dapatkah saya menyertakan slide tersembunyi dalam output Handout?

Ya. Aktifkan opsi `ShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/).