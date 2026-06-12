---
title: Animasi Teks PowerPoint di PHP
linktitle: Teks Teranimasi
type: docs
weight: 60
url: /id/php-java/animated-text/
keywords:
- teks beranimasi
- animasi teks
- paragraf beranimasi
- animasi paragraf
- efek animasi
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat teks beranimasi yang dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java, dengan contoh kode yang mudah diikuti dan dioptimalkan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan teks beranimasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf individu dan mengambil efek yang sudah ditetapkan pada paragraf dalam bingkai teks. Fokusnya adalah pada metode API yang digunakan untuk menambahkan animasi tingkat paragraf dan memeriksa efek animasi paragraf yang ada dalam sebuah presentasi.

## **Menambahkan Efek Animasi ke Paragraf**

Kami menambahkan metode [**addEffect()**](https://reference.aspose.com/slides/id/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) ke kelas [**Sequence**](https://reference.aspose.com/slides/id/php-java/aspose.slides/Sequence). Metode ini memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh berikut menunjukkan cara menambahkan efek animasi ke satu paragraf:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # pilih paragraf untuk menambahkan efek
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # tambahkan efek animasi Fly ke paragraf yang dipilih
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Mendapatkan Efek Animasi Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan ke sebuah paragraf—misalnya, dalam satu skenario, Anda ingin mengambil efek animasi dalam sebuah paragraf karena berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk PHP via Java memungkinkan Anda mendapatkan semua efek animasi yang diterapkan pada paragraf yang terdapat dalam bingkai teks (shape). Kode contoh berikut menunjukkan cara mendapatkan efek animasi dalam sebuah paragraf:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Bagaimana perbedaan animasi teks dengan transisi slide, dan dapatkah keduanya digabungkan?**

Animasi teks mengontrol perilaku objek seiring waktu pada slide, sementara [transitions](/slides/id/php-java/slide-transition/) mengontrol cara pergantian slide. Kedua hal ini bersifat independen dan dapat digunakan bersama; urutan pemutaran diatur oleh garis waktu animasi dan pengaturan transisi.

**Apakah animasi teks tetap dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda hanya melihat satu kondisi slide tanpa gerakan. Untuk mempertahankan gerakan, gunakan ekspor [video](/slides/id/php-java/convert-powerpoint-to-video/) atau [HTML](/slides/id/php-java/export-to-html5/).

**Apakah animasi teks berfungsi di tata letak dan master slide?**

Efek yang diterapkan pada objek layout/master diwariskan ke slide, tetapi timing dan interaksinya dengan animasi tingkat slide bergantung pada urutan akhir pada slide.