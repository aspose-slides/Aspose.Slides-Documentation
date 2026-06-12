---
title: Mengonversi PPTX ke PPT di Java
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Mengonversi PPTX ke PPT dengan mudah menggunakan Aspose.Slides untuk Java—pastikan kompatibilitas yang mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPTX ke format PPT menggunakan Java. Topik berikut dibahas.

- Konversi PPTX ke PPT di Java

## **Konversi PPTX ke PPT di Java**

Untuk contoh kode Java yang mengonversi PPTX ke PPT, lihat bagian di bawah ini yaitu [Convert PPTX to PPT](#convert-pptx-to-ppt). Kode tersebut hanya memuat file PPTX dan menyimpannya dalam format PPT. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPTX ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti yang dibahas dalam artikel-artikel ini.

- [Konversi PPTX ke PDF di Java](/slides/id/java/convert-powerpoint-to-pdf/)
- [Konversi PPTX ke XPS di Java](/slides/id/java/convert-powerpoint-to-xps/)
- [Konversi PPTX ke HTML di Java](/slides/id/java/convert-powerpoint-to-html/)
- [Konversi PPTX ke ODP di Java](/slides/id/java/save-presentation/)
- [Konversi PPTX ke PNG di Java](/slides/id/java/convert-powerpoint-to-png/)

## **Konversi PPTX ke PPT**
Untuk mengonversi PPTX ke PPT, cukup berikan nama file dan format penyimpanan ke metode **Save** dari kelas [**Presentation**](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation). Contoh kode Java di bawah ini mengonversi sebuah Presentation dari PPTX ke PPT dengan opsi default.

```java
// buat objek Presentation yang mewakili file PPTX
Presentation presentation = new Presentation("template.pptx");

// simpan presentasi sebagai PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada saat disimpan ke format PPT warisan (97–2003)?**

Tidak selalu. Format PPT tidak memiliki beberapa kemampuan baru (mis., efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau dirasterisasi selama konversi.

**Apakah saya dapat mengonversi hanya slide tertentu ke PPT alih-alih seluruh presentasi?**

Penyimpanan langsung menargetkan seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru dengan hanya slide tersebut dan simpan sebagai PPT; atau gunakan layanan/API yang mendukung parameter konversi per slide.

**Apakah presentasi yang dilindungi kata sandi didukung?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan kata sandi, dan juga [konfigurasi pengaturan perlindungan/enkripsi](/slides/id/java/password-protected-presentation/) untuk PPT yang disimpan.