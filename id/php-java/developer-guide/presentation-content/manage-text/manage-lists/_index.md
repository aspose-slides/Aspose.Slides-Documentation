---
title: Kelola Daftar Bullet dan Bernomor dalam Presentasi Menggunakan PHP
linktitle: Kelola Daftar
type: docs
weight: 60
url: /id/php-java/manage-lists/
keywords:
- bullet
- daftar bullet
- daftar bernomor
- bullet simbol
- bullet gambar
- bullet khusus
- daftar berjenjang
- buat bullet
- tambahkan bullet
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar bullet, gambar, berjenjang, dan bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java memungkinkan Anda membuat dan memformat daftar bullet dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan bullet‑nya dikontrol melalui format paragrafnya.

Gunakan metode [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getParagraphFormat--) untuk mengakses pengaturan daftar pada level paragraf. Titik masuk utama adalah [ParagraphFormat.getBullet](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#getBullet--) yang mengembalikan objek [BulletFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/). Dengan objek ini, Anda dapat mengatur jenis bullet, simbol, gambar, warna, ukuran, gaya penomoran, dan nomor awal.

Artikel ini menunjukkan cara:

- membuat daftar bullet dengan simbol khusus
- membuat bullet gambar
- membuat daftar berjenjang dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah pemformatan daftar dalam presentasi yang sudah ada

## **Buat Daftar Bullet**

Untuk membuat daftar bullet, tambahkan objek [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) ke dalam [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) dan atur [BulletFormat.setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setType-int-) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/#Symbol). Anda kemudian dapat mengatur [BulletFormat.setChar](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#getColor--) , dan [BulletFormat.setHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setHeight-float-) untuk mengontrol tampilan bullet.

Kode PHP berikut mendemonstrasikan cara membuat daftar bullet dalam sebuah slide:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Bullet simbol](symbol_bullets.png)

## **Buat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Atur [BulletFormat.setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setType-int-) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/#Numbered). Anda juga dapat memilih format penomoran dengan [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) atau mengatur [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) ketika daftar harus dimulai dari nilai selain 1.

Kode PHP berikut menunjukkan cara membuat daftar bernomor dalam sebuah slide:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Bullet bernomor](numbered_bullets.png)

## **Buat Bullet Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol bullet standar dengan gambar. Bullet gambar paling baik digunakan dengan gambar sederhana yang tetap dapat terbaca pada ukuran kecil, seperti ikon atau file PNG transparan kecil.

{{% alert color="primary" %}}
Idealnya, jika Anda berencana mengganti simbol bullet standar dengan gambar, sebaiknya pilih grafik sederhana dengan latar belakang transparan. Gambar semacam itu cocok sebagai simbol bullet khusus.
{{% /alert %}}

Untuk membuat bullet gambar, tambahkan gambar ke [Presentation.getImages](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getImages--) dan tetapkan objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) yang dikembalikan ke [BulletFormat.getPicture](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#getPicture--). Atur [BulletFormat.setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setType-int-) ke [BulletType.Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/#Picture) sebelum menetapkan gambar.

Misalkan kita memiliki “image.png”:

![Gambar untuk bullet](picture_for_bullets.png)

Kode PHP berikut menunjukkan cara membuat bullet gambar dalam sebuah slide:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Bullet gambar](picture_bullets.png)

## **Buat Daftar Multilevel**

Gunakan [ParagraphFormat.setDepth](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setDepth-short-) untuk menempatkan item daftar pada tingkat yang berbeda. Tingkat 0 adalah tingkat teratas, tingkat 1 berada di dalamnya, dan seterusnya.

Kode PHP berikut menunjukkan cara membuat daftar bullet berjenjang:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Daftar multilevel](multilevel_list.png)

## **Ubah Daftar yang Ada**

Untuk mengubah pemformatan daftar dalam presentasi yang sudah ada, akses paragraf target dan perbarui pengaturan [ParagraphFormat.getBullet](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#getBullet--)‑nya. Properti yang sama yang digunakan untuk membuat daftar dapat dipakai untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

Kode PHP berikut mengubah paragraf pertama dalam sebuah frame teks agar menggunakan gaya daftar bernomor:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Apakah daftar bullet dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan daftar ketika format target mendukung tata letak teks dan fitur bullet yang bersangkutan.

**Apakah saya dapat mengedit daftar dalam presentasi yang sudah ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan [ParagraphFormat.getBullet](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#getBullet--), dan simpan presentasi.

**Apakah daftar dapat berisi teks non‑Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang dipakai dalam presentasi mendukung karakter yang Anda perlukan.