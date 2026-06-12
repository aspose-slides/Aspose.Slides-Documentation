---
title: Mengonversi PPTX ke PPT dalam PHP
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/php-java/convert-pptx-to-ppt/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPTX
- PPTX ke PPT
- menyimpan PPTX sebagai PPT
- mengekspor PPTX ke PPT
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Dengan mudah mengonversi PPTX ke PPT menggunakan Aspose.Slides — pastikan kompatibilitas yang mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPTX menjadi format PPT menggunakan PHP. Topik berikut dibahas.

- Mengonversi PPTX ke PPT

## **Mengonversi PPTX ke PPT dalam PHP**

Untuk contoh kode Java yang mengonversi PPTX ke PPT, silakan lihat bagian di bawah ini yaitu [Convert PPTX to PPT](#convert-pptx-to-ppt). Kode tersebut hanya memuat file PPTX dan menyimpannya dalam format PPT. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPTX ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti yang dibahas dalam artikel-artikel ini. 

- [Mengonversi PPTX ke PDF dalam PHP](/slides/id/php-java/convert-powerpoint-to-pdf/)
- [Mengonversi PPTX ke XPS dalam PHP](/slides/id/php-java/convert-powerpoint-to-xps/)
- [Mengonversi PPTX ke HTML dalam PHP](/slides/id/php-java/convert-powerpoint-to-html/)
- [Mengonversi PPTX ke ODP dalam PHP](/slides/id/php-java/save-presentation/)
- [Mengonversi PPTX ke PNG dalam PHP](/slides/id/php-java/convert-powerpoint-to-png/)

## **Mengonversi PPTX ke PPT**
Untuk mengonversi PPTX ke PPT, cukup berikan nama file dan format penyimpanan ke metode **Save** dari kelas [**Presentation**](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation). Contoh kode PHP di bawah ini mengonversi sebuah Presentation dari PPTX ke PPT menggunakan opsi default.

```php
  # menginstansiasi objek Presentation yang mewakili file PPTX
  $presentation = new Presentation("template.pptx");
  # simpan presentasi sebagai PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada saat disimpan ke format PPT lama (97–2003)?**

Tidak selalu. Format PPT tidak memiliki beberapa kemampuan terbaru (misalnya, efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau diubah menjadi raster selama konversi.

**Apakah saya dapat mengonversi hanya slide tertentu ke PPT daripada seluruh presentasi?**

Penyimpanan langsung menyasar seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru yang hanya berisi slide‑slide tersebut dan simpan sebagai PPT; alternatifnya, gunakan layanan/API yang mendukung parameter konversi per slide.

**Apakah presentasi yang dilindungi kata sandi didukung?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan kata sandi, dan juga [mengonfigurasi pengaturan perlindungan/enkripsi](/slides/id/php-java/password-protected-presentation/) untuk PPT yang disimpan.