---
title: Mengonversi Presentasi PowerPoint dalam Mode Handout di .NET
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
description: "Konversi presentasi menjadi handout di .NET. Atur slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides, dengan contoh kode C#. Coba secara gratis."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi ke format output yang mendukung mode Handout. Dalam mode ini, beberapa slide diatur pada satu halaman, yang berguna untuk mencetak materi presentasi untuk konferensi, seminar, dan acara serupa.

Mode Handout dikonfigurasi melalui properti `SlidesLayoutOptions`, yang tersedia di [IPdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/ihtmloptions/), dan [ITiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/itiffoptions/). Untuk menentukan tata letak handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/handoutlayoutingoptions/) .

## **Ekspor Mode Handout**

Untuk mengekspor presentasi dalam mode Handout, atur properti `SlidesLayoutOptions` pada opsi ekspor target dan berikan instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/handoutlayoutingoptions/) yang menentukan jumlah slide per halaman serta parameter tampilan terkait.

Berikut adalah contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```c#
// Muat presentasi.
using var presentation = new Presentation("sample.pptx");

// Atur opsi ekspor.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slide pada satu halaman secara horizontal
        PrintSlideNumbers = true,                   // cetak nomor slide
        PrintFrameSlide = true,                     // cetak bingkai di sekitar slide
        PrintComments = false                       // tanpa komentar
    }
};

// Ekspor presentasi ke PDF dengan tata letak yang dipilih.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Perlu diingat bahwa properti `SlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar. 
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [presets](https://reference.aspose.com/slides/id/net/aspose.slides.export/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat menentukan kisi khusus, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh enumerasi [HandoutType](https://reference.aspose.com/slides/id/net/aspose.slides.export/handouttype/); tata letak arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Aktifkan opsi `ShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/).