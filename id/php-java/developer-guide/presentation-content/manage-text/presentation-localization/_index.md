---
title: Otomatisasi Lokalisasi Presentasi dalam PHP
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/php-java/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- id bahasa
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Otomatisasi lokalisasi slide PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP melalui Java, menggunakan contoh kode praktis dan tip untuk peluncuran global yang lebih cepat."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyetel `LanguageId` untuk teks dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuka presentasi, menambahkan shape dengan teks, menetapkan pengidentifikasi bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Teks Presentasi dan Shape**
- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) tipe [Rectangle](https://reference.aspose.com/slides/id/php-java/aspose.slides/ShapeType#Rectangle) ke slide.
- Tambahkan beberapa teks ke TextFrame.
- Terapkan [Set Language Id](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) pada teks.
- Tulis presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas diperlihatkan di bawah dalam contoh.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah Language ID memicu terjemahan teks otomatis?**

Tidak. [Language ID](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) di Aspose.Slides menyimpan bahasa untuk pemeriksaan ejaan dan tata bahasa, tetapi tidak menerjemahkan atau mengubah konten teks. Itu adalah metadata yang dipahami PowerPoint untuk pemeriksaan.

**Apakah Language ID memengaruhi hyphenation dan pemutusan baris saat rendering?**

Di Aspose.Slides, [language ID](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) digunakan untuk proofing. Kualitas hyphenation dan pembungkus baris terutama tergantung pada ketersediaan [proper fonts](/slides/id/php-java/powerpoint-fonts/) serta pengaturan layout/pemutusan baris untuk sistem penulisan. Untuk memastikan rendering yang tepat, sediakan font yang diperlukan, konfigurasikan [font substitution rules](/slides/id/php-java/font-substitution/), dan/atau [embed fonts](/slides/id/php-java/embedded-font/) ke dalam presentasi.

**Apakah saya dapat menyetel bahasa yang berbeda dalam satu paragraf?**

Ya. [Language ID](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) diterapkan pada tingkat bagian teks, sehingga satu paragraf dapat mencampur banyak bahasa dengan pengaturan proofing yang berbeda.