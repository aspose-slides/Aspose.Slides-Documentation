---
title: Konversi PPT ke PPTX di PHP
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/php-java/convert-ppt-to-pptx/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- PPT ke PPTX
- simpan PPT sebagai PPTX
- ekspor PPT ke PPTX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Konversi presentasi PPT lama ke PPTX modern dengan cepat menggunakan Aspose.Slides untuk PHP via Java — tutorial yang jelas, contoh kode gratis, tanpa ketergantungan Microsoft Office."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPT menjadi format PPTX menggunakan PHP dan aplikasi konversi PPT ke PPTX secara daring. Topik berikut dibahas.

- Mengonversi PPT ke PPTX

## **Mengonversi PPT ke PPTX dengan PHP**

Untuk contoh kode Java yang mengonversi PPT ke PPTX, lihat bagian di bawah ini yaitu [Convert PPT to PPTX](#convert-ppt-to-pptx). Kode tersebut hanya memuat file PPT dan menyimpannya dalam format PPTX. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPT ke banyak format lain seperti PDF, XPS, ODP, HTML, dll., sebagaimana dibahas dalam artikel-artikel berikut.

- [Mengonversi PPT ke PDF dengan PHP](/slides/id/php-java/convert-powerpoint-to-pdf/)
- [Mengonversi PPT ke XPS dengan PHP](/slides/id/php-java/convert-powerpoint-to-xps/)
- [Mengonversi PPT ke HTML dengan PHP](/slides/id/php-java/convert-powerpoint-to-html/)
- [Mengonversi PPT ke ODP dengan PHP](/slides/id/php-java/save-presentation/)
- [Mengonversi PPT ke PNG dengan PHP](/slides/id/php-java/convert-powerpoint-to-png/)

## **Tentang Konversi PPT ke PPTX**
Konversi format PPT lama ke PPTX dengan Aspose.Slides API. Jika Anda perlu mengonversi ribuan presentasi PPT ke format PPTX, solusi terbaik adalah melakukannya secara programatis. Dengan Aspose.Slides API, hal ini dapat dilakukan hanya dalam beberapa baris kode. API mendukung kompatibilitas penuh untuk mengonversi presentasi PPT ke PPTX dan memungkinkan:

- Mengonversi struktur rumit master, tata letak, dan slide.
- Mengonversi presentasi dengan diagram.
- Mengonversi presentasi dengan grup bentuk, auto-shape (seperti persegi panjang dan elips), bentuk dengan geometri khusus.
- Mengonversi presentasi yang memiliki tekstur dan gaya isian gambar untuk auto-shape.
- Mengonversi presentasi dengan placeholder, bingkai teks, dan penampung teks.

{{% alert color="primary" %}} 

Lihat aplikasi **Aspose.Slides PPT to PPTX Conversion**:

[](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

Aplikasi ini dibangun berdasarkan **Aspose.Slides API**, sehingga Anda dapat melihat contoh nyata kemampuan konversi dasar PPT ke PPTX. Aspose.Slides Conversion adalah aplikasi web, yang memungkinkan Anda menyeret file presentasi dalam format PPT dan mengunduhnya setelah dikonversi ke PPTX.

Temukan contoh lain dari **Aspose.Slides Conversion** yang dapat dijalankan.
{{% /alert %}} 

## **Mengonversi PPT ke PPTX**
Aspose.Slides for PHP via Java kini memudahkan pengembang mengakses PPT menggunakan instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan mengonversinya ke format [PPTX](https://docs.fileformat.com/presentation/pptx/). Saat ini, API mendukung konversi parsial dari [PPT](https://docs.fileformat.com/presentation/ppt/) ke PPTX. Untuk detail lebih lanjut mengenai fitur yang didukung dan tidak didukung dalam konversi PPT ke PPTX, silakan lihat dokumentasi ini [link](/slides/id/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java menawarkan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) yang merepresentasikan file presentasi **PPTX**. Kelas Presentation kini juga dapat mengakses **PPT** melalui objek Presentation saat diinstansiasi. Contoh berikut menunjukkan cara mengonversi presentasi PPT menjadi Presentasi PPTX.

```php
  # Buat objek Presentation yang mewakili file PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Menyimpan presentasi PPTX ke format PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Gambar : Presentasi PPT Sumber**|

Potongan kode di atas menghasilkan presentasi PPTX berikut setelah konversi:

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Gambar: Presentasi PPTX yang dihasilkan setelah konversi**|

## **FAQ**

**Apa perbedaan antara format PPT dan PPTX?**

PPT adalah format file biner lama yang digunakan Microsoft PowerPoint, sedangkan PPTX adalah format berbasis XML yang lebih baru diperkenalkan sejak Microsoft Office 2007. File PPTX menawarkan kinerja lebih baik, ukuran file yang lebih kecil, dan pemulihan data yang lebih baik.

**Apakah Aspose.Slides mendukung konversi batch banyak file PPT ke PPTX?**

Ya, Anda dapat menggunakan Aspose.Slides dalam sebuah loop untuk mengonversi banyak file PPT ke PPTX secara programatis, sehingga cocok untuk skenario konversi batch.

**Apakah konten dan pemformatan akan tetap terjaga setelah konversi?**

Aspose.Slides menjaga fidelitas tinggi dalam mengonversi presentasi. Tata letak slide, animasi, bentuk, diagram, dan elemen desain lainnya tetap terjaga selama konversi PPT ke PPTX.

**Apakah saya dapat mengonversi format lain seperti PDF atau HTML dari file PPT?**

Ya, Aspose.Slides mendukung konversi file PPT ke [multiple formats](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/), termasuk PDF, XPS, HTML, ODP, serta format gambar seperti PNG dan JPEG.

**Apakah memungkinkan mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya, Aspose.Slides adalah API mandiri dan tidak memerlukan Microsoft PowerPoint atau perangkat lunak pihak ketiga lainnya untuk melakukan konversi.

**Apakah ada alat daring yang tersedia untuk konversi PPT ke PPTX?**

Ya, Anda dapat menggunakan aplikasi web gratis [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) untuk melakukan konversi langsung di browser tanpa menulis kode.