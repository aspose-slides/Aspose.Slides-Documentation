---
title: Konversi PPTX ke PPT di .NET
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Dengan mudah mengonversi PPTX ke PPT menggunakan Aspose.Slides untuk .NET—pastikan kompatibilitas mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPTX ke format PPT menggunakan C#. Topik berikut dibahas.

- Mengonversi PPTX ke PPT dengan C#

## **Konversi PPTX ke PPT di .NET**

Untuk contoh kode C# yang mengonversi PPTX ke PPT, lihat bagian di bawah yaitu [Konversi PPTX ke PPT](#convert-pptx-to-ppt). Kode hanya memuat file PPTX dan menyimpannya dalam format PPT. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPTX ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti yang dibahas dalam artikel-artikel berikut.

- [Konversi PPTX ke PDF di .NET](/slides/id/net/convert-powerpoint-to-pdf/)
- [Konversi PPTX ke XPS di .NET](/slides/id/net/convert-powerpoint-to-xps/)
- [Konversi PPTX ke HTML di .NET](/slides/id/net/convert-powerpoint-to-html/)
- [Konversi PPTX ke ODP di .NET](/slides/id/net/save-presentation/)
- [Konversi PPTX ke PNG di .NET](/slides/id/net/convert-powerpoint-to-png/)

## **Konversi PPTX ke PPT**
Untuk mengonversi PPTX ke PPT cukup kirimkan nama file dan format penyimpanan ke metode [**Save**](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) dari kelas [**Presentation**](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Contoh kode C# di bawah mengonversi sebuah Presentation dari PPTX ke PPT menggunakan opsi default.

```c#
// Membuat objek Presentation yang merepresentasikan file PPTX
Presentation pres = new Presentation("presentation.pptx");

// Menyimpan presentasi PPTX ke format PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada saat disimpan ke format PPT (97–2003) legacy?**

Tidak selalu. Format PPT tidak memiliki beberapa kemampuan baru (mis., efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau dirasterisasi selama konversi.

**Bisakah saya mengonversi hanya slide yang dipilih ke PPT alih-alih seluruh presentasi?**

Penyimpanan langsung menargetkan seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru yang hanya berisi slide tersebut dan simpan sebagai PPT; alternatifnya, gunakan layanan/API yang mendukung parameter konversi per slide.

**Apakah presentasi yang dilindungi kata sandi didukung?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan kata sandi, dan juga [mengonfigurasi pengaturan perlindungan/enkripsi](/slides/id/net/password-protected-presentation/) untuk PPT yang disimpan.