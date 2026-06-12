---
title: Kelola Daftar Bertanda dan Bernomor dalam Presentasi di Android
linktitle: Kelola Daftar
type: docs
weight: 60
url: /id/androidjava/manage-lists/
keywords:
- tanda
- daftar berpoin
- daftar bernomor
- simbol bullet
- bullet gambar
- bullet khusus
- daftar bertingkat
- buat bullet
- tambahkan bullet
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar berpoin, bullet gambar, bertingkat, dan bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android melalui Java."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java memungkinkan Anda membuat dan memformat daftar berpoin dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan bullet‑nya dikendalikan melalui format paragrafnya.

Gunakan metode [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) untuk mengakses pengaturan daftar pada tingkat paragraf. Titik masuk utama adalah [IParagraphFormat.getBullet](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), yang mengembalikan objek [IBulletFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/). Dengan objek ini, Anda dapat mengatur jenis bullet, simbol, gambar, warna, ukuran, gaya penomoran, dan nomor mulai.

Artikel ini menunjukkan cara:

- membuat daftar berpoin dengan simbol khusus
- membuat bullet gambar
- membuat daftar bertingkat dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah pemformatan daftar dalam presentasi yang ada

## **Membuat Daftar Berpoin**

Untuk membuat daftar berpoin, tambahkan paragraf ke [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dan atur [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/). Anda kemudian dapat mengatur [IBulletFormat.setChar](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#getColor--), dan [IBulletFormat.setHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) untuk mengontrol tampilan bullet.

Kode Java berikut mendemonstrasikan cara membuat daftar berpoin dalam slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Bullet simbol](symbol_bullets.png)

## **Membuat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Atur [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/). Anda juga dapat memilih format penomoran dengan [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) atau mengatur [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) bila daftar harus dimulai dari nilai selain 1.

Kode Java berikut menunjukkan cara membuat daftar bernomor dalam slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Bullet bernomor](numbered_bullets.png)

## **Membuat Bullet Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol bullet reguler dengan gambar. Bullet gambar paling cocok untuk gambar sederhana yang tetap terbaca pada ukuran kecil, seperti ikon atau file PNG transparan berukuran kecil.

{{% alert color="primary" %}}
Idealnya, bila Anda berencana mengganti simbol bullet reguler dengan gambar, sebaiknya pilih grafik sederhana dengan latar belakang transparan. Gambar semacam itu berfungsi baik sebagai simbol bullet khusus.
{{% /alert %}}

Perlu diingat bahwa gambar akan diperkecil menjadi ukuran sangat kecil. Karena itu, kami sangat menyarankan memilih gambar yang tetap jelas dan efektif secara visual ketika digunakan sebagai bullet dalam daftar.

Untuk membuat bullet gambar, tambahkan gambar ke [Presentation.getImages](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getImages--) dan tetapkan objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) yang dikembalikan ke [IBulletFormat.getPicture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Atur [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) ke [BulletType.Picture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/) sebelum menetapkan gambar.

Misalkan kita memiliki "image.png":

![Gambar untuk bullet](picture_for_bullets.png)

Kode Java berikut menunjukkan cara membuat bullet gambar dalam slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Bullet gambar](picture_bullets.png)

## **Membuat Daftar Bertingkat**

Gunakan [IParagraphFormat.setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) untuk menempatkan item daftar pada tingkat yang berbeda. Tingkat 0 adalah tingkat atas, tingkat 1 berada di bawahnya, dan seterusnya.

Kode Java berikut menunjukkan cara membuat daftar berpoin bertingkat:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Daftar bertingkat](multilevel_list.png)

## **Mengubah Daftar yang Ada**

Untuk mengubah pemformatan daftar dalam presentasi yang ada, akses paragraf target dan perbarui pengaturan [IParagraphFormat.getBullet](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑nya. Metode yang sama digunakan untuk membuat daftar dapat dipakai untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

Kode Java berikut mengubah paragraf pertama dalam sebuah text frame agar menggunakan gaya daftar bernomor:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah daftar berpoin dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan daftar ketika format target mendukung tata letak teks dan fitur bullet yang bersesuaian.

**Apakah saya dapat mengedit daftar dalam presentasi yang ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan [IParagraphFormat.getBullet](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), dan simpan presentasi.

**Apakah daftar dapat berisi teks non‑Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang digunakan dalam presentasi mendukung karakter yang diperlukan.