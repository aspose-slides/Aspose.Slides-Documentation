---
title: Dapatkan Batas Paragraf dari Presentasi dalam PHP
linktitle: Paragraf
type: docs
weight: 60
url: /id/php-java/paragraph/
keywords:
- batas paragraf
- batas bagian teks
- koordinat paragraf
- koordinat bagian
- ukuran paragraf
- ukuran bagian teks
- kerangka teks
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf dan bagian teks di Aspose.Slides untuk PHP via Java guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf serta bagian teks di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dalam sebuah `TextFrame` dengan menggunakan `getRect()`, cara mendapatkan koordinat paragraf dan bagian di dalam teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, efek pembungkus teks terhadap batas, konversi piksel, dan nilai pemformatan paragraf yang efektif.

## **Dapatkan Koordinat Paragraf dan Bagian dalam TextFrame**
Menggunakan Aspose.Slides untuk PHP melalui Java, pengembang kini dapat memperoleh koordinat persegi panjang untuk Paragraph di dalam koleksi paragraf TextFrame. Ini juga memungkinkan Anda untuk mendapatkan [the coordinates of portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getCoordinates) di dalam koleksi bagian sebuah paragraf. Pada topik ini, kami akan mendemonstrasikan dengan contoh cara mendapatkan koordinat persegi panjang untuk paragraf beserta posisi bagian di dalam paragraf.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Dapatkan Koordinat Persegi Panjang Sebuah Paragraf**
Dengan menggunakan metode [**getRect()**](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getRect) pengembang dapat memperoleh persegi panjang batas paragraf.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dapatkan Ukuran Paragraf dan Bagian di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/Portion) atau [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/Paragraph) di dalam teks sel tabel, Anda dapat menggunakan metode [Portion::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getRect) dan [Paragraph::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getRect).

Kode contoh ini memperlihatkan operasi yang dijelaskan:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tanya Jawab**

**Dalam satuan apa koordinat yang dikembalikan untuk paragraf dan bagian teks diukur?**

Dalam poin, di mana 1 inci = 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [wrapping](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/setwraptext/) diaktifkan dalam [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/), teks akan dipisah agar sesuai dengan lebar area, yang mengubah batas sebenarnya dari paragraf.

**Dapatkah koordinat paragraf dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel menggunakan: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering/ekspor.

**Bagaimana cara mendapatkan parameter pemformatan paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/php-java/shape-effective-properties/); ini mengembalikan nilai akhir yang terkonsolidasi untuk indentasi, spasi, pembungkus, RTL, dan lainnya.