---
title: Mengonversi Presentasi PowerPoint dalam Mode Handout Menggunakan PHP
linktitle: Mode Handout
type: docs
weight: 150
url: /id/php-java/convert-powerpoint-in-handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Konversi presentasi menjadi handout dengan PHP. Atur slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides untuk PHP, dengan contoh kode. Coba gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk pencetakan dalam mode Handout. Mode ini memungkinkan Anda mengatur bagaimana beberapa slide ditampilkan pada satu halaman, menjadikannya berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan mengatur metode `setSlidesLayoutOptions` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/), dan [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/).

## **Ekspor Mode Handout**

Untuk mengonfigurasi mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/handoutlayoutingoptions/), yang menentukan berapa banyak slide yang ditempatkan pada satu halaman serta parameter tampilan lainnya.

Berikut adalah contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```php
// Load a presentation.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // cetak nomor slide
$slidesLayoutOptions->setPrintFrameSlide(true);                      // cetak bingkai di sekitar slide
$slidesLayoutOptions->setPrintComments(false);                       // tanpa komentar

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Perlu diingat bahwa metode `setSlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar.
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimal thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [presets](https://reference.aspose.com/slides/id/php-java/aspose.slides/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat mendefinisikan grid kustom, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikendalikan secara ketat oleh kelas [HandoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/handouttype/), sehingga tata letak arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Aktifkan slide tersembunyi dengan menggunakan metode `setShowHiddenSlides` pada pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/).