---
title: Dapatkan Batas Paragraf dari Presentasi di PHP
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/php-java/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- bingkai teks
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk PHP via Java untuk mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf dalam Aspose.Slides. Ini memperlihatkan cara mengambil persegi panjang paragraf dari sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) dengan menggunakan [Paragraph::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/getrect/), cara mendapatkan koordinat paragraf di dalam bingkai teks sel tabel, dan menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks pada batas, konversi piksel, serta nilai pemformatan paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang Sebuah Paragraf**

Gunakan [Paragraph::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/getrect/) untuk mendapatkan persegi panjang pembatas dari sebuah paragraf.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Ukuran Paragraf di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) dalam bingkai teks sel tabel, gunakan [Paragraph::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/getrect/). Persegi panjang yang dikembalikan relatif terhadap bingkai teks sel tabel, jadi tambahkan posisi tabel dan offset sel ketika Anda memerlukan koordinat tingkat slide.

Contoh berikut mendapatkan batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Dalam satuan apa koordinat paragraf diukur?**

Mereka diukur dalam poin, di mana 1 inci sama dengan 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/setwraptext/) diaktifkan untuk [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas sebenarnya dari paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel menggunakan rumus berikut: piksel = poin × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk render atau ekspor.

**Bagaimana cara mendapatkan parameter pemformatan paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [struktur data pemformatan paragraf efektif](/slides/id/php-java/shape-effective-properties/); ia mengembalikan nilai akhir yang terkonsolidasi untuk indents, spacing, wrapping, RTL, dan lainnya.