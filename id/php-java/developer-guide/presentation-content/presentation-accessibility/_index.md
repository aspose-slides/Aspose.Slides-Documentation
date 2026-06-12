---
title: Kelola Aksesibilitas Presentasi di PHP
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/php-java/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides membantu mengotomatiskan pemeriksaan aksesibilitas presentasi pada file PPT, PPTX, dan ODP - meningkatkan pengalaman pembaca layar dan meningkatkan kepatuhan."
---
## **Gambaran Umum**

Presentasi yang dapat diakses memastikan bahwa orang yang menggunakan teknologi bantu—seperti pembaca layar, tampilan braille, atau navigasi hanya dengan keyboard—dapat memahami dan menavigasi slide Anda seefektif audiens yang melihat dan menggunakan mouse. Praktik yang baik berfokus pada urutan bacaan yang jelas, teks alternatif yang bermakna untuk visual informatif, kontras warna yang cukup, tipografi yang mudah dibaca, teks tautan yang deskriptif, serta menghindari penyampaian makna hanya melalui warna atau posisi. Ketika aksesibilitas direncanakan sejak awal, hasilnya adalah struktur yang lebih bersih, visual yang lebih konsisten, dan konten yang menjangkau setiap penonton tanpa cara kerja tambahan.

## **Tandai sebagai Dekoratif**

Tandai sebagai dekoratif menandai visual yang semata‑mata ornamental sehingga pembaca layar melewatkannya, mengurangi kebisingan dan menjaga fokus pada konten yang berarti. Terapkan pada latar belakang, hiasan, dan spacer—tidak pernah pada grafik, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides menyediakan flag ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis serta pembersihan.

![Tandai sebagai Dekoratif](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah bentuk ditandai sebagai dekoratif.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```