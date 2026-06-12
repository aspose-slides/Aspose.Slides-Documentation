---
title: Kelola Aksesibilitas Presentasi di Python
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/python-net/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Python membantu mengotomatisasi pemeriksaan aksesibilitas presentasi dalam file PPT, PPTX, dan ODP—meningkatkan pengalaman pembaca layar dan meningkatkan kepatuhan."
---
## **Pengantar**

Presentasi yang dapat diakses memastikan bahwa orang yang menggunakan teknologi bantu—seperti pembaca layar, tampilan braille, atau navigasi hanya dengan keyboard—dapat memahami dan menavigasi slide Anda seefektif penonton yang dapat melihat dan menggunakan mouse. Praktik yang baik berfokus pada urutan baca yang jelas, teks alternatif yang bermakna untuk visual informatif, kontras warna yang cukup, tipografi yang dapat dibaca, teks tautan yang deskriptif, dan menghindari penyampaian makna hanya melalui warna atau posisi. Ketika aksesibilitas direncanakan sejak awal, hasilnya adalah struktur yang lebih bersih, visual yang lebih konsisten, dan konten yang menjangkau setiap pemirsa tanpa solusi alternatif.

## **Tandai sebagai Dekoratif**

Tanda sebagai dekoratif menandai visual yang semata-mata ornamental sehingga pembaca layar melewatinya, mengurangi kebisingan dan menjaga fokus pada konten yang bermakna. Terapkan pada latar belakang, hiasan, dan spacer—tidak pernah pada grafik, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides mengekspos tanda ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis dan pembersihan.

![Mark as Decorative](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah shape ditandai sebagai dekoratif.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```