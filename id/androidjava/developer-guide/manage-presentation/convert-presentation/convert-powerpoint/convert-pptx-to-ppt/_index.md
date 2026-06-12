---
title: Ubah PPTX ke PPT di Android
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Dengan mudah mengonversi PPTX ke PPT menggunakan Aspose.Slides untuk Android via Java - pastikan kompatibilitas yang mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPTX menjadi format PPT menggunakan Java. Topik berikut dibahas.

- Mengonversi PPTX ke PPT di Java

## **Mengonversi PPTX ke PPT di Android**

Untuk contoh kode Java yang mengonversi PPTX ke PPT, lihat bagian di bawah yaitu [Ubah PPTX ke PPT](#convert-pptx-to-ppt). Kode tersebut hanya memuat file PPTX dan menyimpannya dalam format PPT. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPTX ke banyak format lain seperti PDF, XPS, ODP, HTML dll seperti yang dibahas dalam artikel-artikel ini.

- [Ubah PPTX ke PDF di Android](/slides/id/androidjava/convert-powerpoint-to-pdf/)
- [Ubah PPTX ke XPS di Android](/slides/id/androidjava/convert-powerpoint-to-xps/)
- [Ubah PPTX ke HTML di Android](/slides/id/androidjava/convert-powerpoint-to-html/)
- [Ubah PPTX ke ODP di Android](/slides/id/androidjava/save-presentation/)
- [Ubah PPTX ke PNG di Android](/slides/id/androidjava/convert-powerpoint-to-png/)

## **Ubah PPTX ke PPT**
Untuk mengonversi PPTX ke PPT cukup berikan nama file dan format penyimpanan ke metode **Save** milik kelas [**Presentation**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation). Contoh kode Java di bawah mengonversi Presentation dari PPTX ke PPT menggunakan opsi default.

```java
// instansiasi objek Presentation yang mewakili file PPTX
Presentation presentation = new Presentation("template.pptx");

// simpan presentasi sebagai PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada saat disimpan ke format PPT (97–2003) lama?**

Tidak selalu. Format PPT tidak memiliki beberapa kemampuan baru (misalnya, efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau dirasterisasi selama konversi.

**Bisakah saya mengonversi hanya slide tertentu ke PPT alih-alih seluruh presentasi?**

Penyimpanan langsung menargetkan seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru dengan slide tersebut dan simpan sebagai PPT; alternatifnya, gunakan layanan/API yang mendukung parameter konversi per slide.

**Apakah presentasi yang dilindungi kata sandi didukung?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan kata sandi, dan juga [konfigurasikan pengaturan perlindungan/enkripsi](/slides/id/androidjava/password-protected-presentation/) untuk PPT yang disimpan.