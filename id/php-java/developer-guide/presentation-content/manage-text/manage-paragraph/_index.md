---
title: Kelola Paragraf Teks PowerPoint di PHP
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/php-java/manage-paragraph/
aliases:
  - /php-java/paragraf/
  - /php-java/bagian/
keywords:
- tambahkan teks
- tambahkan paragraf
- kelola teks
- kelola paragraf
- kelola bullet
- indentasi paragraf
- indentasi menggantung
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
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, bagian, bullet, daftar bernomor, indentasi, konten HTML, serta gambar paragraf dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java merepresentasikan teks sebagai hierarki kerangka teks, paragraf, dan bagian:

* [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) merepresentasikan kontainer teks dalam sebuah shape dan menyediakan akses ke koleksi paragrafnya.
* [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) merepresentasikan satu paragraf dalam sebuah kerangka teks dan menyediakan akses ke bagian‑bagian serta pemformatan level paragraf.
* [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) merepresentasikan rentang teks dalam sebuah paragraf. Setiap bagian dapat memiliki teks dan pemformatan karakter yang berbeda.

Dengan demikian, sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan pemformatan lain yang berbeda dengan menggunakan beberapa bagian.

## **Buat dan Format Paragraf**

### **Buat Paragraf dengan Beberapa Bagian**

Langkah‑langkah berikut membuat sebuah kerangka teks dengan tiga paragraf, masing‑masing berisi tiga bagian:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) shape tersebut.
5. Gunakan paragraf default dan tambahkan dua objek [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) lagi ke dalam kerangka teks.
6. Tambahkan cukup objek [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) sehingga setiap paragraf memiliki tiga bagian. Paragraf default sudah berisi satu bagian kosong.
7. Atur teks pada setiap bagian.
8. Terapkan pemformatan level karakter melalui [Portion::getPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getPortionFormat--).
9. Simpan presentasi yang telah dimodifikasi.

Contoh PHP ini mengimplementasikan langkah‑langkah tersebut:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Buat Daftar Bullet dan Bernomor**

### **Buat Daftar Bullet atau Bernomor**

Bullet dan penomoran memudahkan pemindaian item terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [BulletFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/).

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) shape tersebut.
5. Hapus paragraf default dari kerangka teks.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) untuk bullet simbol.
7. Atur [BulletFormat::setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setType-int-) menjadi [BulletType::Symbol](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/) dan tentukan karakter bullet.
8. Atur teks paragraf, indent, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke dalam kerangka teks.
10. Buat paragraf kedua dan atur [BulletFormat::setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setType-int-) menjadi [BulletType::Numbered](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke dalam kerangka teks.
12. Simpan presentasi.

Contoh PHP ini membuat bullet simbol dan bullet bernomor:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Gunakan Bullet Gambar**

Bullet gambar memungkinkan Anda menggunakan gambar khusus alih‑alih simbol atau angka.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dan akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/)‑nya.
4. Hapus paragraf default dari kerangka teks.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/).
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) dan atur teksnya.
7. Atur [BulletFormat::setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setType-int-) menjadi [BulletType::Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/bullettype/).
8. Tetapkan gambar melalui [BulletFormat::getPicture](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#getPicture--) dan atur tinggi bullet.
9. Tambahkan paragraf ke dalam kerangka teks.
10. Simpan presentasi yang telah dimodifikasi.

Contoh PHP ini membuat bullet gambar:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Buat Daftar Multilevel**

Atur [ParagraphFormat::setDepth](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setDepth-short-) untuk menempatkan paragraf pada level daftar yang berbeda. Level teratas memiliki depth `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) serta kosongkan paragraf default dari kerangka teksnya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Atur nilai [ParagraphFormat::setDepth](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setDepth-short-) mereka menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf‑paragraf ke dalam kerangka teks dan simpan presentasi.

Contoh PHP ini membuat daftar bullet empat level:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Mulai Item Daftar Bernomor dengan Nilai Kustom**

Gunakan [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) untuk menentukan nomor awal yang ditampilkan pada paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
2. Kosongkan paragraf default dari kerangka teks shape.
3. Buat tiga paragraf bernomor.
4. Atur [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/id/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) menjadi `2`, `3`, dan `7` untuk masing‑masing paragraf.
5. Tambahkan paragraf‑paragraf ke dalam kerangka teks dan simpan presentasi.

Contoh PHP ini menetapkan nomor mulai kustom untuk setiap paragraf:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrol Tata Letak Paragraf dan Properti Akhir**

### **Atur Indent Baris Pertama**

Gunakan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-) untuk mengontrol indent baris pertama pada sebuah paragraf. Metode ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris lainnya tetap rata dengan badan paragraf.

Gunakan [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) bila Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-) bila hanya baris pertama yang ingin dipindahkan.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-) yang berbeda untuk menunjukkan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) shape tersebut dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf‑paragraf ke dalam kerangka teks.
7. Simpan presentasi yang telah dimodifikasi.

Kode PHP ini menunjukkan cara mengatur indent paragraf:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

Hasilnya:

![Indent baris pertama dari paragraf](first_line_indent.png)

### **Atur Indent Menggantung**

Indent menggantung adalah tata letak paragraf di mana baris pertama dimulai ke kiri dibandingkan dengan baris‑baris berikutnya. Di Aspose.Slides, efek ini dibuat dengan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-). Berikan nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Dalam praktiknya, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) menentukan posisi kiri badan paragraf, dan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent menggantung, berikan nilai positif ke `setMarginLeft` dan nilai negatif ke `setIndent`.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris‑baris yang dibungkus harus rata di bawah badan paragraf, bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) shape tersebut dan hapus paragraf default.
5. Buat paragraf‑paragraf dan berikan nilai positif ke [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) untuk masing‑masing paragraf.
6. Berikan nilai negatif ke [ParagraphFormat::setIndent](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setIndent-float-) untuk menciptakan efek indent menggantung.
7. Tambahkan paragraf‑paragraf ke dalam kerangka teks.
8. Simpan presentasi yang telah dimodifikasi.

Kode PHP ini menunjukkan cara mengatur indent menggantung untuk sebuah paragraf:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Indent menggantung dari paragraf](hanging_indent.png)

### **Atur Properti Run Paragraf Akhir**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) mengontrol pemformatan tanda akhir paragraf. Contoh PHP berikut menetapkan ukuran font dan font Latin pada tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) serta kosongkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan bagian teks ke dalamnya.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Atur [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) dan [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Tetapkan format tersebut dengan [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) dan simpan presentasi.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke dalam Paragraf**

Gunakan [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) untuk mengubah markup HTML menjadi paragraf dan bagian dalam sebuah kerangka teks.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Akses sebuah slide dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
3. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) shape tersebut dan kosongkan paragraf default.
4. Baca berkas HTML sumber.
5. Berikan string HTML ke [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Simpan presentasi yang telah dimodifikasi.

Contoh PHP ini mengimpor HTML ke dalam sebuah kerangka teks:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Ekspor Teks Paragraf ke HTML**

Gunakan [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) untuk mengekspor rentang paragraf yang dipilih sebagai HTML.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) yang berisi teks.
3. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) shape tersebut.
4. Panggil [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah berkas.

Contoh PHP ini mengekspor semua paragraf dari shape teks pertama:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Render Paragraf sebagai Gambar**

[Paragraph::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getImage--) merender sebuah paragraf individu secara langsung dan mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/). Simpan hasilnya ke berkas atau stream dengan [IImage::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Anda tidak perlu merender shape yang berisi atau memotong bitmap secara manual.

[Paragraph::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getImage--) dapat mengembalikan `null` jika paragraf tidak ditemukan dalam koleksi induknya, tidak memiliki batas render yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpan dan buang gambar yang dikembalikan setelah selesai digunakan.

#### **Render Paragraf dengan Skala Default**

Misalkan kami memiliki sebuah berkas presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh PHP berikut merender paragraf kedua dalam sebuah shape teks biasa pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Blok `finally` memastikan gambar dibuang dengan benar.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

#### **Render Paragraf dalam Sel Tabel dengan Skalasi**

Gunakan overload [Paragraph::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getImage-float-float-) yang menerima parameter `$scaleX` dan `$scaleY` untuk mengatur faktor skala horizontal dan vertikal. Contoh PHP berikut membuat sebuah tabel, merender paragraf dalam sel pertamanya dengan lebar dan tinggi dua kali lipat skala default, dan menyimpan hasilnya sebagai gambar PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Faktor skala `1` mempertahankan ukuran piksel default pada sumbu tersebut. Misalnya, `2` pada kedua faktor menghasilkan gambar yang lebar dan tingginya kira‑kira dua kali dimensi default, menghasilkan empat kali jumlah piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output resolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran berkas. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara terpisah.

Merender keseluruhan shape dengan [Shape::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage--) tetap berguna ketika output harus menyertakan isian, border, atau konteks visual lain dari shape. Untuk gambar yang hanya berisi paragraf, gunakan [Paragraph::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Apakah saya dapat menonaktifkan pembungkusan baris sepenuhnya di dalam sebuah kerangka teks?**

Ya. Atur [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setWrapText-byte-) untuk menonaktifkan pembungkusan sehingga baris tidak terpotong di tepi kerangka teks.

**Bagaimana cara mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Gunakan [Paragraph::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getRect--) untuk mengambil persegi panjang pembatas paragraf. [Portion::getRect](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getRect--) memberikan batas untuk sebuah bagian individu.

**Di mana pengaturan perataan paragraf (kiri, kanan, tengah, atau justify) dikontrol?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setAlignment-int-) adalah pengaturan level paragraf dan berlaku untuk seluruh paragraf terlepas dari pemformatan bagian individu.

**Apakah saya dapat menetapkan bahasa proofing untuk bagian tertentu dari paragraf?**

Ya. Atur [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) untuk bagian‑bagian individu, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.