---
title: Kelola Aksesibilitas Presentasi dalam JavaScript
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/nodejs-java/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Otomatisasi pemeriksaan aksesibilitas presentasi pada file PPT, PPTX, dan ODP dengan Aspose.Slides untuk Node.js—tingkatkan pengalaman pembaca layar dan tingkatkan kepatuhan."
---
## **Gambaran Umum**

Aksesibilitas presentasi memastikan bahwa orang yang menggunakan teknologi bantu—seperti pembaca layar, tampilan braille, atau navigasi hanya dengan keyboard—dapat memahami dan menavigasi slide Anda secara efektif seperti penonton yang melihat dan menggunakan mouse. Praktik yang baik berfokus pada urutan baca yang jelas, teks alternatif yang bermakna untuk visual informatif, kontras warna yang cukup, tipografi yang mudah dibaca, teks tautan yang deskriptif, dan menghindari penyampaian makna hanya melalui warna atau posisi. Ketika aksesibilitas direncanakan sejak awal, hasilnya adalah struktur yang lebih bersih, visual yang lebih konsisten, dan konten yang menjangkau setiap penonton tanpa solusi darurat.

## **Tandai sebagai Dekoratif**

Mark as decorative menandai visual yang semata-mata dekoratif sehingga pembaca layar melewatinya, mengurangi kebisingan dan menjaga fokus pada konten yang bermakna. Terapkan pada latar belakang, hiasan, dan pemisah—jangan pernah pada grafik, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides menyediakan tanda ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis serta pembersihan.

![Tandai sebagai Dekoratif](mark_as_decorative.png)

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```