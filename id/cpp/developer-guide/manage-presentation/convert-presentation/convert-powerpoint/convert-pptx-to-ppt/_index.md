---
title: Konversi PPTX ke PPT dalam C++
linktitle: PPTX ke PPT
type: docs
weight: 21
url: /id/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Dengan mudah mengonversi PPTX ke PPT menggunakan Aspose.Slides untuk C++—pastikan kompatibilitas yang mulus dengan format PowerPoint sambil mempertahankan tata letak dan kualitas presentasi Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPTX menjadi format PPT menggunakan C++. Topik berikut dibahas.

- Mengonversi PPTX ke PPT dengan C++

## **Mengonversi PPTX ke PPT dengan C++**

Untuk contoh kode C++ yang mengonversi PPTX ke PPT, silakan lihat bagian di bawah ini yaitu [Convert PPTX to PPT](#convert-pptx-to-ppt). Kode tersebut hanya memuat file PPTX dan menyimpannya dalam format PPT. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPTX ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti yang dibahas dalam artikel-artikel ini. 

- [Mengonversi PPTX ke PDF dengan C++](/slides/id/cpp/convert-powerpoint-to-pdf/)
- [Mengonversi PPTX ke XPS dengan C++](/slides/id/cpp/convert-powerpoint-to-xps/)
- [Mengonversi PPTX ke HTML dengan C++](/slides/id/cpp/convert-powerpoint-to-html/)
- [Mengonversi PPTX ke ODP dengan C++](/slides/id/cpp/save-presentation/)
- [Mengonversi PPTX ke PNG dengan C++](/slides/id/cpp/convert-powerpoint-to-png/)

## **Mengonversi PPTX ke PPT**
Untuk mengonversi PPTX ke PPT, cukup berikan nama file dan format penyimpanan ke metode **Save** pada kelas [**Presentation**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/). Contoh kode C++ di bawah ini mengonversi sebuah Presentation dari PPTX ke PPT menggunakan opsi default.

```cpp
// Muat PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Simpan dalam format PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **FAQ**

**Apakah semua efek dan fitur PPTX tetap ada saat disimpan ke format PPT (97–2003) yang lama?**

Tidak selalu. Format PPT tidak memiliki beberapa kemampuan yang lebih baru (misalnya, efek tertentu, objek, dan perilaku), sehingga fitur dapat disederhanakan atau diubah menjadi raster selama konversi.

**Bisakah saya mengonversi hanya slide tertentu ke PPT, bukan seluruh presentasi?**

Penyimpanan langsung menargetkan seluruh presentasi. Untuk mengonversi slide tertentu, buat presentasi baru dengan hanya slide tersebut dan simpan sebagai PPT; alternatifnya, gunakan layanan/API yang mendukung parameter konversi per slide.

**Apakah presentasi yang dilindungi kata sandi didukung?**

Ya. Anda dapat mendeteksi apakah file dilindungi, membukanya dengan kata sandi, dan juga [configure protection/encryption settings](/slides/id/cpp/password-protected-presentation/) untuk PPT yang disimpan.