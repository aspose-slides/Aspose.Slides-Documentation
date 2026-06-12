---
title: Konversi Presentasi OpenDocument di C++
linktitle: Konversi OpenDocument
type: docs
weight: 10
url: /id/cpp/convert-openoffice-odp/
keywords:
- konversi ODP
- ODP ke gambar
- ODP ke GIF
- ODP ke HTML
- ODP ke JPG
- ODP ke MD
- ODP ke PDF
- ODP ke PNG
- ODP ke PPT
- ODP ke PPTX
- ODP ke TIFF
- ODP ke video
- ODP ke Word
- ODP ke XPS
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Aspose.Slides untuk C++ memungkinkan Anda mengonversi ODP ke PDF, HTML, dan format gambar dengan mudah. Tingkatkan aplikasi C++ Anda dengan konversi presentasi yang cepat dan akurat."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/id/cpp/) memungkinkan Anda mengonversi presentasi OpenDocument (ODP) ke berbagai format (HTML, PDF, TIFF, SWF, XPS, dll). API yang digunakan untuk mengonversi file ODP ke format dokumen lain sama dengan yang digunakan untuk operasi konversi PowerPoint (PPT dan PPTX).

Sebagai contoh, jika Anda perlu mengonversi presentasi ODP ke PDF, Anda dapat melakukannya sebagai berikut:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```