---
title: Dapatkan Batas Bagian Teks dari Presentasi dalam PHP
linktitle: Batas Bagian
type: docs
weight: 47
url: /id/php-java/portion-bounds/
keywords:
- batas bagian teks
- bagian teks
- bagian teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Bagian teks mewakili fragmen khusus teks di dalam paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil batas fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih detail. Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [Portion::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/getrect/). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [Portion::getCoordinates](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/getcoordinates/). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami bagaimana pemformatan diselesaikan melalui bagian, paragraf, bingkai teks, dan pewarisan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Bagian Teks**

Gunakan [Portion::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/getrect/) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Koordinat Bagian Teks**

Gunakan [Portion::getCoordinates](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/getcoordinates/) untuk mengambil koordinat awal sebuah bagian teks:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/php-java/manage-hyperlinks/) ke sebuah bagian individual; hanya fragmen itu yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti tingkat Bagian memiliki prioritas tertinggi. Jika sebuah properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/), Aspose.Slides mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/). Jika juga tidak diatur di sana, Aspose.Slides menggunakan gaya [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) atau [theme](https://reference.aspose.com/slides/id/php-java/aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak ada di mesin atau server target?**

[Aturan substitusi font](/slides/id/php-java/font-selection-sequence/) berlaku. Teks mungkin akan mengalir kembali: metrik, hyphenasi, dan lebar dapat berubah, yang penting untuk penempatan yang presisi.

**Apakah saya dapat mengatur transparansi isian teks khusus bagian atau gradien secara independen dari sisa paragraf?**

Ya, warna teks, isian, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.