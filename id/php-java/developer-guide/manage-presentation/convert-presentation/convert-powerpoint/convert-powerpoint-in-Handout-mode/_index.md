---
title: Mengonversi Presentasi PowerPoint dalam Mode Handout Menggunakan PHP
linktitle: Mode Handout
type: docs
weight: 150
url: /id/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Konversi presentasi menjadi handout di PHP. Atur jumlah slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides untuk PHP, dengan contoh kode. Coba gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk dicetak dalam mode Handout. Mode ini memungkinkan Anda mengonfigurasi bagaimana beberapa slide muncul pada satu halaman, menjadikannya berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan menyetel metode `setSlidesLayoutOptions` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/), dan [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/) .

## **Ekspor Mode Handout**

Untuk mengkonfigurasi mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/handoutlayoutingoptions/), yang menentukan berapa banyak slide yang ditempatkan pada satu halaman dan parameter tampilan lainnya.

Berikut adalah contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```php
// Muat sebuah presentasi.
$presentation = new Presentation("sample.pptx");

// Atur opsi ekspor.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // cetak nomor slide
$slidesLayoutOptions->setPrintFrameSlide(true);                      // cetak bingkai di sekitar slide
$slidesLayoutOptions->setPrintComments(false);                       // tanpa komentar

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Ekspor presentasi ke PDF dengan tata letak yang dipilih.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Perlu diingat bahwa metode `setSlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar. 
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [presets](https://reference.aspose.com/slides/id/php-java/aspose.slides/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat menentukan grid kustom, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh kelas [HandoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/handouttype/); layout arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Aktifkan slide tersembunyi menggunakan metode `setShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/).