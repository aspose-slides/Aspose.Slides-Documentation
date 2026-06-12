---
title: Kelola Aksesibilitas Presentasi di C++
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/cpp/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk C++ membantu mengotomatiskan pemeriksaan aksesibilitas presentasi dalam file PPT, PPTX, dan ODP—tingkatkan pengalaman pembaca layar dan tingkatkan kepatuhan."
---
## **Gambaran Umum**

Aksesibilitas presentasi memastikan bahwa orang yang menggunakan teknologi bantu—seperti pembaca layar, tampilan braille, atau navigasi hanya dengan keyboard—dapat memahami dan menavigasi slide Anda seefektif audiens yang melihat dan menggunakan mouse. Praktik yang baik berfokus pada urutan baca yang jelas, teks alternatif yang bermakna untuk visual informatif, kontras warna yang cukup, tipografi yang dapat dibaca, teks tautan yang deskriptif, dan menghindari penyampaian makna hanya dengan warna atau posisi. Ketika aksesibilitas direncanakan sejak awal, hasilnya adalah struktur yang lebih bersih, visual yang lebih konsisten, dan konten yang menjangkau setiap penonton tanpa solusi alternatif.

## **Tandai sebagai Dekoratif**

Tandai sebagai dekoratif menandai visual yang semata-mata ornamental sehingga pembaca layar melewatkannya, mengurangi kebisingan dan menjaga fokus pada konten yang bermakna. Terapkan pada latar belakang, hiasan, dan spacer—tidak pernah pada grafik, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides menyediakan flag ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis dan pembersihan.

![Tandai sebagai Dekoratif](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah bentuk ditandai sebagai dekoratif.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```