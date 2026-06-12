---
title: "Mengonversi PPTX ke PPT dengan JavaScript"
linktitle: "PPTX ke PPT"
type: docs
weight: 21
url: /id/nodejs-java/convert-pptx-to-ppt/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPTX
- PPTX ke PPT
- simpan PPTX sebagai PPT
- ekspor PPTX ke PPT
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Dengan mudah mengonversi PPTX ke PPT menggunakan Aspose.Slides—memastikan kompatibilitas yang mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPTX menjadi format PPT menggunakan JavaScript. Topik berikut dibahas.

- Mengonversi PPTX ke PPT dengan JavaScript

## **JavaScript Mengonversi PPTX ke PPT**

Untuk contoh kode JavaScript yang mengonversi PPTX ke PPT, silakan lihat bagian di bawah ini yaitu [Convert PPTX to PPT](#convert-pptx-to-ppt). Itu hanya memuat file PPTX dan menyimpannya dalam format PPT. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPTX ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti yang dibahas dalam artikel-artikel ini. 

- [Mengonversi PPTX ke PDF dengan JavaScript](/slides/id/nodejs-java/convert-powerpoint-to-pdf/)
- [Mengonversi PPTX ke XPS dengan JavaScript](/slides/id/nodejs-java/convert-powerpoint-to-xps/)
- [Mengonversi PPTX ke HTML dengan JavaScript](/slides/id/nodejs-java/convert-powerpoint-to-html/)
- [Mengonversi PPTX ke ODP dengan JavaScript](/slides/id/nodejs-java/save-presentation/)
- [Mengonversi PPTX ke PNG dengan JavaScript](/slides/id/nodejs-java/convert-powerpoint-to-png/)

## **Mengonversi PPTX ke PPT**

Untuk mengonversi PPTX ke PPT, cukup berikan nama file dan format penyimpanan ke metode **Save** dari kelas [**Presentation**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation). Contoh kode JavaScript di bawah ini mengonversi sebuah Presentation dari PPTX ke PPT menggunakan opsi default.

```javascript
// buat objek Presentation yang mewakili file PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// simpan presentasi sebagai PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada saat disimpan ke format PPT lama (97–2003)?**

Tidak selalu. Format PPT tidak mendukung beberapa kemampuan baru (misalnya, efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau diubah menjadi raster selama konversi.

**Apakah saya dapat mengonversi hanya slide yang dipilih ke PPT alih-alih seluruh presentasi?**

Penyimpanan langsung menargetkan seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru yang hanya berisi slide tersebut dan simpan sebagai PPT; alternatifnya, gunakan layanan/API yang mendukung parameter konversi per slide.

**Apakah presentasi yang dilindungi kata sandi didukung?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan kata sandi, dan juga [mengonfigurasi pengaturan perlindungan/enkripsi](/slides/id/nodejs-java/password-protected-presentation/) untuk PPT yang disimpan.