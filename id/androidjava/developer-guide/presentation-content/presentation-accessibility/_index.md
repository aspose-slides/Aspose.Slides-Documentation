---
title: Kelola Aksesibilitas Presentasi di Android
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/androidjava/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Android via Java membantu mengotomatisasi pemeriksaan aksesibilitas presentasi dalam file PPT, PPTX, dan ODP—meningkatkan pengalaman pembaca layar dan meningkatkan kepatuhan."
---
## **Ikhtisar**

Aksesibilitas presentasi memastikan bahwa orang yang menggunakan teknologi bantuan—seperti pembaca layar, tampilan braille, atau navigasi hanya dengan keyboard—dapat memahami dan menavigasi slide Anda seefektif penonton yang melihat dan menggunakan mouse. Praktik yang baik berfokus pada urutan baca yang jelas, teks alternatif yang bermakna untuk visual informatif, kontras warna yang cukup, tipografi yang dapat dibaca, teks tautan yang deskriptif, dan menghindari penyampaian makna hanya melalui warna atau posisi. Ketika aksesibilitas direncanakan sejak awal, hasilnya adalah struktur yang lebih bersih, visual yang lebih konsisten, dan konten yang menjangkau setiap pemirsa tanpa solusi sementara.

## **Mark as Decorative**

Tanda “Mark as Decorative” menandai visual yang semata‑mata bersifat hiasan sehingga pembaca layar melewatinya, mengurangi kebisingan dan menjaga fokus pada konten yang berarti. Terapkan pada latar belakang, hiasan, dan spasi—tidak pernah pada grafik, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides mengekspose tanda ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis dan pembersihan.

![Mark as Decorative](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah shape ditandai sebagai dekoratif.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```