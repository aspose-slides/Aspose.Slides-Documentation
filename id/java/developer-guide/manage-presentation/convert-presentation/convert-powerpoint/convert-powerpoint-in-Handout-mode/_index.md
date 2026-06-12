---
title: Konversi Presentasi PowerPoint dalam Mode Handout Menggunakan Java
linktitle: Mode Handout
type: docs
weight: 150
url: /id/java/convert-powerpoint-in-Handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Konversi presentasi ke handout dalam Java. Atur slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides, dengan contoh kode Java. Coba gratis."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi ke format output yang mendukung mode Handout. Dalam mode ini, beberapa slide diatur pada satu halaman, yang berguna untuk mencetak materi presentasi untuk konferensi, seminar, dan acara serupa.

Mode Handout dikonfigurasi melalui metode `setSlidesLayoutOptions`, yang tersedia di [IPdfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihtmloptions/), dan [ITiffOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiffoptions/). Untuk menentukan tata letak handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/handoutlayoutingoptions/).

## **Ekspor Mode Handout**

Untuk mengekspor presentasi dalam mode Handout, atur metode `setSlidesLayoutOptions` pada opsi ekspor target dan lampirkan instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/handoutlayoutingoptions/) yang menentukan jumlah slide per halaman serta parameter tampilan terkait.

Di bawah ini contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```java
// Muat presentasi.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Atur opsi ekspor.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // cetak nomor slide
    slidesLayoutOptions.setPrintFrameSlide(true);                     // cetak bingkai di sekitar slide
    slidesLayoutOptions.setPrintComments(false);                      // tidak ada komentar

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Ekspor presentasi ke PDF dengan tata letak yang dipilih.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Perlu diingat bahwa metode `setSlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar.
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [presets](https://reference.aspose.com/slides/id/java/com.aspose.slides/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat menentukan grid khusus, misalnya 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh kelas [HandoutType](https://reference.aspose.com/slides/id/java/com.aspose.slides/handouttype/); tata letak arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Aktifkan slide tersembunyi menggunakan metode `setShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/tiffoptions/).