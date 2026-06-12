---
title: Kelola Aksesibilitas Presentasi di .NET
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/net/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Otomatisasi pemeriksaan aksesibilitas presentasi pada file PPT, PPTX, dan ODP dengan Aspose.Slides untuk .NET—tingkatkan pengalaman pembaca layar dan tingkatkan kepatuhan."
---
## **Pendahuluan**

Aksesibilitas presentasi memastikan bahwa orang yang menggunakan teknologi bantu—seperti pembaca layar, tampilan braille, atau navigasi hanya dengan keyboard—dapat memahami dan menavigasi slide Anda seefektif penonton yang melihat dan menggunakan mouse. Praktik yang baik berfokus pada urutan baca yang jelas, teks alternatif yang bermakna untuk visual informatif, kontras warna yang cukup, tipografi yang mudah dibaca, teks tautan yang deskriptif, serta menghindari penyampaian makna hanya melalui warna atau posisi. Ketika aksesibilitas direncanakan sejak awal, hasilnya adalah struktur yang lebih bersih, visual yang lebih konsisten, dan konten yang menjangkau setiap pemirsa tanpa solusi tambahan.

## **Tandai sebagai Dekoratif**

Tanda “Mark as decorative” menandai visual murni ornamental sehingga pembaca layar melewatinya, mengurangi kebisingan dan menjaga fokus pada konten yang bermakna. Terapkan pada latar belakang, hiasan, dan spacer—tidak pernah pada diagram, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides menyediakan tanda ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis serta pembersihan.

![Tandai sebagai Dekoratif](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah bentuk ditandai sebagai dekoratif.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```