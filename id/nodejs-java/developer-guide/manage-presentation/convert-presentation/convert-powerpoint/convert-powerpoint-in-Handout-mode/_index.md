---
title: "Mengonversi Presentasi PowerPoint dalam Mode Handout Menggunakan JavaScript"
linktitle: "Mode Handout"
type: docs
weight: 150
url: /id/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- "konversi PowerPoint"
- "konversi presentasi"
- "mode handout"
- "handout"
- "PPT"
- "PPTX"
- "PowerPoint"
- "presentasi"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konversi presentasi menjadi handout. Atur slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides untuk Node.js, lengkap dengan contoh kode. Coba secara gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk pencetakan dalam mode Handout. Mode ini memungkinkan Anda mengatur bagaimana beberapa slide muncul pada satu halaman, membuatnya berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan mengatur metode `setSlidesLayoutOptions` dalam kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/), dan [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/).

## **Ekspor Mode Handout**

Untuk mengonfigurasi mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/handoutlayoutingoptions/), yang menentukan berapa banyak slide yang ditempatkan pada satu halaman dan parameter tampilan lainnya.

Berikut adalah contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```js
// Muat presentasi.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
slidesLayoutOptions.setPrintSlideNumbers(true);                                // cetak nomor slide
slidesLayoutOptions.setPrintFrameSlide(true);                                  // cetak bingkai di sekitar slide
slidesLayoutOptions.setPrintComments(false);                                   // tanpa komentar

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Perhatikan bahwa metode `setSlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar.
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [prasetelan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat menentukan grid khusus, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikendalikan secara ketat oleh enumerasi [HandoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/handouttype/); tata letak arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Gunakan metode `setShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/).