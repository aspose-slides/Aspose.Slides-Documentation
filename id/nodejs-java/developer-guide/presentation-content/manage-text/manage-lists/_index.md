---
title: Kelola Daftar Bertanda Titik dan Bernomor dalam Presentasi Menggunakan JavaScript
linktitle: Kelola Daftar
type: docs
weight: 60
url: /id/nodejs-java/manage-lists/
keywords:
- bullet
- daftar bertanda titik
- daftar bernomor
- bullet simbol
- bullet gambar
- bullet khusus
- daftar multilevel
- buat bullet
- tambahkan bullet
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar bertanda titik, gambar, bertingkat, dan bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java memungkinkan Anda membuat dan memformat daftar bertanda titik dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan bullet‑nya dikontrol melalui format paragrafnya.

Gunakan kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) untuk mengakses pengaturan daftar pada tingkat paragraf. Titik masuk utama adalah `Paragraph.getParagraphFormat().getBullet()`, yang mengembalikan objek [BulletFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/). Dengan objek ini, Anda dapat mengatur jenis bullet, simbol, gambar, warna, ukuran, gaya penomoran, dan nomor awal.

Artikel ini menunjukkan cara:

- membuat daftar bertanda titik dengan simbol khusus
- membuat bullet gambar
- membuat daftar multilevel dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah format daftar dalam presentasi yang ada

## **Buat Daftar Bertanda Titik**

Untuk membuat daftar bertanda titik, tambahkan objek [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) ke sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dan setel `BulletFormat.setType` ke [BulletType.Symbol](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bullettype/). Anda kemudian dapat menyetel `BulletFormat.setChar`, `BulletFormat.getColor`, dan `BulletFormat.setHeight` untuk mengontrol tampilan bullet.

Kode JavaScript berikut menunjukkan cara membuat daftar bertanda titik dalam sebuah slide:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bullet simbol](symbol_bullets.png)

## **Buat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Setel `BulletFormat.setType` ke [BulletType.Numbered](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bullettype/). Anda juga dapat memilih format penomoran dengan `BulletFormat.setNumberedBulletStyle` atau setel `BulletFormat.setNumberedBulletStartWith` ketika daftar harus dimulai dari nilai selain 1.

Kode JavaScript berikut menunjukkan cara membuat daftar bernomor dalam sebuah slide:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bullet bernomor](numbered_bullets.png)

## **Buat Bullet Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol bullet reguler dengan sebuah gambar. Bullet gambar paling cocok dengan gambar sederhana yang tetap dapat terbaca pada ukuran kecil, seperti ikon atau file PNG transparan berukuran kecil.

{{% alert color="primary" %}}
Idealnya, jika Anda berencana mengganti simbol bullet reguler dengan gambar, sebaiknya pilih grafik sederhana dengan latar belakang transparan. Gambar semacam itu bekerja baik sebagai simbol bullet khusus.

Perlu diingat bahwa gambar akan diperkecil menjadi ukuran yang sangat kecil. Untuk itu, kami sangat menyarankan memilih gambar yang tetap jelas dan secara visual efektif ketika digunakan sebagai bullet dalam daftar.
{{% /alert %}}

Untuk membuat bullet gambar, tambahkan gambar ke [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dengan `Presentation.getImages().addImage` dan tetapkan objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang dikembalikan ke `BulletFormat.getPicture().setImage`. Setel `BulletFormat.setType` ke [BulletType.Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bullettype/) sebelum menugaskan gambar.

Misalkan kita memiliki "image.png":

![Gambar untuk bullet](picture_for_bullets.png)

Kode JavaScript berikut menunjukkan cara membuat bullet gambar dalam sebuah slide:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Hasilnya:

![Bullet gambar](picture_bullets.png)

## **Buat Daftar Multilevel**

Gunakan `ParagraphFormat.setDepth` untuk menempatkan item daftar pada tingkat yang berbeda. Tingkat 0 adalah tingkat teratas, tingkat 1 berada di bawahnya, dan seterusnya.

Kode JavaScript berikut menunjukkan cara membuat daftar bertanda titik multilevel:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Daftar multilevel](multilevel_list.png)

## **Ubah Daftar yang Ada**

Untuk mengubah format daftar dalam presentasi yang ada, akses paragraf target dan perbarui pengaturan `ParagraphFormat.getBullet`‑nya. Properti yang sama digunakan untuk membuat daftar dapat juga dipakai untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah daftar bertanda titik dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan format daftar ketika format target mendukung tata letak teks dan fitur bullet yang bersangkutan.

**Apakah saya dapat mengedit daftar dalam presentasi yang ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan `ParagraphFormat.getBullet`, dan simpan presentasi.

**Apakah daftar dapat berisi teks non-Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang digunakan dalam presentasi mendukung karakter yang Anda perlukan.