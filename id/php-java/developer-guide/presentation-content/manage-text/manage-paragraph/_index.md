---
title: Kelola Paragraf Teks PowerPoint di PHP
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/php-java/manage-paragraph/
keywords:
- tambahkan teks
- tambahkan paragraf
- kelola teks
- kelola paragraf
- kelola bullet
- indentasi paragraf
- indentasi gantung
- bullet paragraf
- daftar bernomor
- daftar bullet
- properti paragraf
- impor HTML
- teks ke HTML
- paragraf ke HTML
- paragraf ke gambar
- teks ke gambar
- ekspor paragraf
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kuasi pemformatan paragraf dengan Aspose.Slides untuk PHP via Java — optimalkan perataan, spasi & gaya dalam presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Aspose.Slides menyediakan semua kelas yang Anda perlukan untuk bekerja dengan teks, paragraf, dan bagian PowerPoint.

* Aspose.Slides menyediakan kelas [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) yang memungkinkan Anda menambahkan objek yang mewakili sebuah paragraf. Sebuah objek `TextFame` dapat memiliki satu atau beberapa paragraf (setiap paragraf dibuat melalui karakter kembali).
* Aspose.Slides menyediakan kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) yang memungkinkan Anda menambahkan objek yang mewakili bagian. Sebuah objek `Paragraph` dapat memiliki satu atau beberapa bagian (koleksi objek bagian).
* Aspose.Slides menyediakan kelas [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) yang memungkinkan Anda menambahkan objek yang mewakili teks dan properti formatnya.

Objek `Paragraph` dapat menangani teks dengan properti format yang berbeda melalui objek `Portion` yang mendasarinya.

## **Menambahkan Beberapa Paragraf yang Berisi Beberapa Bagian**

Langkah-langkah berikut menunjukkan cara menambahkan sebuah TextFrame yang berisi 3 paragraf dan setiap paragraf berisi 3 bagian:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Dapatkan ITextFrame yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) .
5. Buat dua objek [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) dan tambahkan ke koleksi paragraf dari [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) .
6. Buat tiga objek [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) untuk setiap `Paragraph` baru (dua objek Portion untuk Paragraph default) dan tambahkan setiap objek `Portion` ke koleksi bagian dari masing-masing `Paragraph` .
7. Tetapkan beberapa teks untuk setiap bagian.
8. Terapkan fitur format pilihan Anda pada setiap bagian menggunakan properti format yang disediakan oleh objek `Portion` .
9. Simpan presentasi yang telah dimodifikasi.

```php
# Membuat instance kelas Presentation yang mewakili file PPTX
$pres = new Presentation();
try {
    # Mengakses slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan AutoShape tipe Persegi panjang
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Mengakses TextFrame dari AutoShape
    $tf = $ashp->getTextFrame();
    # Membuat Paragraf dan Bagian dengan format teks yang berbeda
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Menulis PPTX ke Disk
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Mengelola Bullet Paragraf**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf dengan bullet selalu lebih mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) pada autoshape.
5. Hapus paragraf default di dalam `TextFrame` .
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) .
7. Atur `Type` bullet untuk paragraf menjadi `Symbol` dan tetapkan karakter bullet.
8. Atur `Text` paragraf.
9. Atur `Indent` paragraf untuk bullet.
10. Tetapkan warna untuk bullet.
11. Tetapkan tinggi bullet.
12. Tambahkan paragraf baru ke koleksi paragraf `TextFrame` .
13. Tambahkan paragraf kedua dan ulangi proses pada langkah 7 sampai 13.
14. Simpan presentasi.

```php
# Membuat instance kelas Presentation yang mewakili file PPTX
$pres = new Presentation();
try {
    # Mengakses slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan dan mengakses Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Mengakses text frame autoshape
    $txtFrm = $aShp->getTextFrame();
    # Menghapus paragraf default
    $txtFrm->getParagraphs()->removeAt(0);
    # Membuat sebuah paragraf
    $para = new Paragraph();
    # Mengatur gaya bullet paragraf dan simbol
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Mengatur teks paragraf
    $para->setText("Welcome to Aspose.Slides");
    # Mengatur indentasi bullet
    $para->getParagraphFormat()->setIndent(25);
    # Mengatur warna bullet
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// set IsBulletHardColor menjadi true untuk menggunakan warna bullet sendiri

    # Mengatur Tinggi Bullet
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Menambahkan Paragraf ke text frame
    $txtFrm->getParagraphs()->add($para);
    # Membuat paragraf kedua
    $para2 = new Paragraph();
    # Mengatur tipe dan gaya bullet paragraf
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Menambahkan teks paragraf
    $para2->setText("This is numbered bullet");
    # Mengatur indentasi bullet
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// set IsBulletHardColor menjadi true untuk menggunakan warna bullet sendiri

    # Mengatur Tinggi Bullet
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Menambahkan Paragraf ke text frame
    $txtFrm->getParagraphs()->add($para2);
    # Menyimpan presentasi yang dimodifikasi
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Mengelola Bullet Gambar**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf gambar mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) pada autoshape.
5. Hapus paragraf default di dalam `TextFrame` .
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) .
7. Muat gambar di [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) .
8. Atur tipe bullet menjadi [Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/#Picture) dan tetapkan gambar.
9. Atur `Text` Paragraph.
10. Atur `Indent` Paragraph untuk bullet.
11. Tetapkan warna untuk bullet.
12. Tetapkan tinggi bullet.
13. Tambahkan paragraf baru ke koleksi paragraf `TextFrame` .
14. Tambahkan paragraf kedua dan ulangi proses berdasarkan langkah‑langkah sebelumnya.
15. Simpan presentasi yang telah dimodifikasi.

```php
# Membuat instance kelas Presentation yang mewakili file PPTX
$presentation = new Presentation();
try {
    # Mengakses slide pertama
    $slide = $presentation->getSlides()->get_Item(0);
    # Membuat instance gambar untuk bullet
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Menambahkan dan mengakses Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Mengakses textframe autoshape
    $textFrame = $autoShape->getTextFrame();
    # Menghapus paragraf default
    $textFrame->getParagraphs()->removeAt(0);
    # Membuat paragraf baru
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Mengatur style bullet paragraf dan gambar
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Mengatur Tinggi bullet
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Menambahkan paragraf ke text frame
    $textFrame->getParagraphs()->add($paragraph);
    # Menulis presentasi sebagai file PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Menulis presentasi sebagai file PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Mengelola Bullet Multilevel**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet multilevel mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) di slide baru.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) pada autoshape.
5. Hapus paragraf default di dalam `TextFrame` .
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) dan atur kedalaman menjadi 0.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur kedalaman menjadi 1.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur kedalaman menjadi 2.
9. Buat instance paragraf keempat melalui kelas `Paragraph` dan atur kedalaman menjadi 3.
10. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame` .
11. Simpan presentasi yang telah dimodifikasi.

```php
# Membuat instance kelas Presentation yang mewakili file PPTX
$pres = new Presentation();
try {
    # Mengakses slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan dan mengakses Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Mengakses text frame dari autoshape yang dibuat
    $text = $aShp->addTextFrame("");
    # Menghapus paragraf default
    $text->getParagraphs()->clear();
    # Menambahkan paragraf pertama
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mengatur level bullet
    $para1->getParagraphFormat()->setDepth(0);
    # Menambahkan paragraf kedua
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mengatur level bullet
    $para2->getParagraphFormat()->setDepth(1);
    # Menambahkan paragraf ketiga
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mengatur level bullet
    $para3->getParagraphFormat()->setDepth(2);
    # Menambahkan paragraf keempat
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Mengatur level bullet
    $para4->getParagraphFormat()->setDepth(3);
    # Menambahkan paragraf ke koleksi
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Menulis presentasi sebagai file PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Mengelola Paragraf dengan Daftar Bernomor Kustom**

Kelas [BulletFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/) menyediakan metode [setNumberedBulletStartWith](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) dan lainnya yang memungkinkan Anda mengelola paragraf dengan penomoran atau format kustom.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses slide yang berisi paragraf.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) pada autoshape.
5. Hapus paragraf default di dalam `TextFrame` .
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) dan atur [NumberedBulletStartWith](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) menjadi 2.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` menjadi 3.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` menjadi 7.
9. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame` .
10. Simpan presentasi yang telah dimodifikasi.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Mengakses text frame dari autoshape yang dibuat
    $textFrame = $shape->getTextFrame();
    # Menghapus paragraf default yang ada
    $textFrame->getParagraphs()->removeAt(0);
    # Daftar pertama
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Mengatur Indent Baris Pertama untuk Paragraf**

Gunakan metode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setindent/) untuk mengontrol indent baris pertama pada sebuah paragraf. Metode ini memindahkan hanya baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris lainnya tetap selaras dengan badan paragraf.

Gunakan [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setmarginleft/) ketika Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setindent/) ketika Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai indent yang berbeda untuk mendemonstrasikan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [Indent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setindent/) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf‑paragraf ke dalam text frame.
7. Simpan presentasi yang telah dimodifikasi.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Indent baris pertama dari paragraf](first_line_indent.png)

## **Mengatur Indent Gantung untuk Paragraf**

Indent gantung adalah tata letak paragraf di mana baris pertama mulai di sebelah kiri baris‑bari lainnya. Di Aspose.Slides, Anda dapat membuat efek ini dengan metode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setindent). Atur indent ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Dalam praktiknya, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setmarginleft) menentukan posisi kiri badan paragraf, dan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setindent) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent gantung, atur nilai `MarginLeft` positif dan nilai `Indent` negatif.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus sejajar di bawah badan paragraf bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat paragraf‑paragraf dan atur nilai [MarginLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setmarginleft) positif untuk masing‑masing.
6. Atur nilai [Indent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setindent) negatif untuk menciptakan efek indent gantung.
7. Tambahkan paragraf‑paragraf ke dalam text frame.
8. Simpan presentasi yang telah dimodifikasi.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Indent gantung dari paragraf](hanging_indent.png)

## **Mengelola Properti Run Akhir Paragraf**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide yang berisi paragraf melalui posisinya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
1. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) dengan dua paragraf ke Rectangle.
1. Atur tinggi font dan jenis Font untuk paragraf‑paragraf.
1. Atur properti End untuk paragraf‑paragraf.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Mengimpor Teks HTML ke dalam Paragraf**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengimpor teks HTML ke dalam paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
4. Tambahkan dan akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) milik `AutoShape` .
5. Hapus paragraf default di dalam `TextFrame` .
6. Baca file HTML sumber menggunakan TextReader.
7. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) .
8. Tambahkan konten file HTML yang dibaca dari TextReader ke [ParagraphCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphcollection/) milik TextFrame.
9. Simpan presentasi yang telah dimodifikasi.

```php
# Membuat instance presentasi kosong
$pres = new Presentation();
try {
    # Mengakses slide pertama default dari presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan AutoShape untuk menampung konten HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Menambahkan text frame ke shape
    $ashape->addTextFrame("");
    # Menghapus semua paragraf dalam text frame yang ditambahkan
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Memuat file HTML menggunakan stream reader
    $tr = new StreamReader("file.html");
    # Menambahkan teks dari stream reader HTML ke text frame
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Menyimpan Presentasi
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Mengekspor Teks Paragraf ke HTML**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengekspor teks (yang terdapat dalam paragraf) ke HTML.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses referensi slide yang relevan melalui indeksnya.
3. Akses shape yang berisi teks yang akan diekspor ke HTML.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) pada shape.
5. Buat instance `StreamWriter` dan tambahkan file HTML baru.
6. Berikan indeks awal ke `StreamWriter` dan ekspor paragraf pilihan Anda.

```php
# Muat file presentasi
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Akses slide pertama default dari presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # Indeks yang diinginkan
    $index = 0;
    # Mengakses shape yang ditambahkan
    $ashape = $slide->getShapes()->get_Item($index);
    # Membuat file HTML output
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Mengekstrak paragraf pertama sebagai HTML
    # Menulis data Paragraf ke HTML dengan menyediakan indeks mulai paragraf, total paragraf yang akan disalin
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Menyimpan Paragraf sebagai Gambar**

Pada bagian ini, kita akan mengeksplorasi dua contoh yang menunjukkan cara menyimpan sebuah paragraf teks, yang direpresentasikan oleh kelas [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) , sebagai gambar. Kedua contoh mencakup memperoleh gambar dari sebuah shape yang berisi paragraf menggunakan metode `getImage` dari kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) , menghitung batas paragraf di dalam shape, dan mengekspornya sebagai gambar bitmap. Pendekatan ini memungkinkan Anda mengekstrak bagian tertentu dari teks dalam presentasi PowerPoint dan menyimpannya sebagai gambar terpisah, yang dapat berguna untuk penggunaan lebih lanjut dalam berbagai skenario.

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah sebuah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

**Contoh 1**

Dalam contoh ini, kami memperoleh paragraf kedua sebagai gambar. Untuk melakukannya, kami mengekstrak gambar shape dari slide pertama presentasi dan kemudian menghitung batas paragraf kedua dalam text frame shape. Paragraf tersebut kemudian digambar ulang ke sebuah gambar bitmap baru, yang disimpan dalam format PNG. Metode ini sangat berguna ketika Anda perlu menyimpan paragraf tertentu sebagai gambar terpisah sambil mempertahankan dimensi dan format teks yang tepat.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Simpan shape dalam memori sebagai bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Buat bitmap shape dari memori.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Hitung batas paragraf kedua.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Potong bitmap shape untuk mendapatkan hanya bitmap paragraf.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasil:

![Gambar paragraf](paragraph_to_image_output.png)

**Contoh 2**

Dalam contoh ini, kami memperluas pendekatan sebelumnya dengan menambahkan faktor skala pada gambar paragraf. Shape diekstrak dari presentasi dan disimpan sebagai gambar dengan faktor skala `2`. Ini memungkinkan hasil dengan resolusi lebih tinggi saat mengekspor paragraf. Batas paragraf kemudian dihitung dengan mempertimbangkan skala. Skalasi dapat sangat berguna ketika gambar yang lebih detail dibutuhkan, misalnya untuk penggunaan dalam materi cetak berkualitas tinggi.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Simpan shape dalam memori sebagai bitmap dengan skala.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Buat bitmap shape dari memori.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Hitung batas paragraf kedua.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Potong bitmap shape untuk mendapatkan hanya bitmap paragraf.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkus baris di dalam sebuah TextFrame?**

Ya. Gunakan pengaturan pembungkus TextFrame ([setWrapText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/setwraptext/)) untuk mematikan pembungkus sehingga baris tidak akan terpotong di tepi frame.

**Bagaimana saya dapat memperoleh batas tepat pada slide untuk paragraf tertentu?**

Anda dapat mengambil persegi panjang pembatas paragraf (bahkan untuk satu bagian) untuk mengetahui posisi dan ukuran tepatnya pada slide.

**Di mana pengaturan perataan paragraf (kiri/kanan/tengah/rata) dikontrol?**

[Alignment](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setalignment/) adalah pengaturan tingkat paragraf di [ParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/) ; ia berlaku untuk seluruh paragraf terlepas dari pemformatan bagian individual.

**Apakah saya dapat menetapkan bahasa pemeriksaan ejaan untuk hanya bagian dari paragraf (mis., satu kata)?**

Ya. Bahasa diatur pada tingkat bagian ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId)) , sehingga beberapa bahasa dapat berdampingan dalam satu paragraf.