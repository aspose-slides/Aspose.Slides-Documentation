---
title: Mengelola Bagian Teks dalam Presentasi dengan PHP
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/php-java/portion/
keywords:
- bagian teks
- potongan teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java, meningkatkan kinerja dan penyesuaian."
---
## **Pendahuluan**

Bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih detail.

## **Dapatkan Koordinat Bagian Teks**
Metode **getCoordinates()**[method](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/getcoordinates/) telah ditambahkan ke kelas [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) yang memungkinkan mengambil koordinat awal bagian.

```php
  # Instansiasi kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Membentuk ulang konteks presentasi
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/php-java/manage-hyperlinks/) ke bagian individu; hanya fragmen itu yang akan dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti pada tingkat Portion memiliki prioritas tertinggi. Jika suatu properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/), mesin mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/); jika tidak diatur di sana juga, maka diambil dari [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) atau gaya [theme](https://reference.aspose.com/slides/id/php-java/aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk Portion tidak ada di mesin/server target?**

[Aturan substitusi font](/slides/id/php-java/font-selection-sequence/) diterapkan. Teks dapat mengalami reflow: metrik, hyphenation, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi atau gradien isi teks khusus untuk Portion secara independen dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.