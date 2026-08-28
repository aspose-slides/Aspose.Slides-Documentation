---
title: Kelola Paragraf Teks PowerPoint dalam JavaScript
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, portion, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk Node.js via Java."
---
## **Ikhtisar**

Aspose.Slides for Node.js via Java merepresentasikan teks sebagai hierarki bingkai teks, paragraf, dan portion:

* [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) mewakili wadah teks dalam sebuah shape dan menyediakan akses ke koleksi paragrafnya.
* [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) mewakili satu paragraf dalam sebuah bingkai teks dan menyediakan akses ke bagiannya serta pemformatan tingkat paragraf.
* [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) mewakili jalur teks dalam sebuah paragraf. Setiap portion dapat memiliki teks dan pemformatan tingkat karakter sendiri.

Dengan demikian, sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan pemformatan lainnya yang berbeda dengan menggunakan beberapa portion.

## **Buat dan Format Paragraf**

### **Buat Paragraf dengan Beberapa Portion**

Langkah-langkah berikut membuat bingkai teks dengan tiga paragraf, masing-masing berisi tiga portion:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik shape.
5. Gunakan paragraf default dan tambahkan dua objek [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) lagi ke bingkai teks.
6. Tambahkan cukup objek [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) untuk setiap paragraf sehingga masing-masing memiliki tiga portion. Paragraf default sudah berisi satu portion kosong.
7. Setel teks setiap portion.
8. Terapkan pemformatan tingkat karakter melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/getportionformat/).
9. Simpan presentasi yang telah dimodifikasi.

Contoh JavaScript berikut mengimplementasikan langkah-langkah tersebut:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Buat Daftar Bullet dan Bernomor**

### **Buat Daftar Bullet atau Bernomor**

Bullet dan penomoran memudahkan pemindaian item terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [BulletFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/).

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik shape.
5. Hapus paragraf default dari bingkai teks.
6. Buat [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) untuk bullet simbol.
7. Setel [BulletFormat.setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/settype/) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bullettype/) dan tentukan karakter bullet.
8. Setel teks paragraf, indent, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke bingkai teks.
10. Buat paragraf kedua dan setel [BulletFormat.setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/settype/) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bullettype/).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke bingkai teks.
12. Simpan presentasi.

Contoh JavaScript berikut membuat bullet simbol dan bullet bernomor:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gunakan Bullet Gambar**

Bullet gambar memungkinkan Anda menggunakan gambar khusus alih-alih simbol atau angka.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dan akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).
4. Hapus paragraf default dari bingkai teks.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/).
6. Buat [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dan setel teksnya.
7. Setel [BulletFormat.setType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/settype/) ke [BulletType.Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bullettype/).
8. Tetapkan gambar melalui [BulletFormat.getPicture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/getpicture/) dan setel tinggi bullet.
9. Tambahkan paragraf ke bingkai teks.
10. Simpan presentasi yang telah dimodifikasi.

Contoh JavaScript berikut membuat bullet gambar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Buat Daftar Multilevel**

Setel [ParagraphFormat.setDepth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setdepth/) untuk menempatkan paragraf pada level yang berbeda dalam sebuah daftar. Level teratas memiliki kedalaman `0`.

1. Buat [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dan bersihkan paragraf default dari bingkai teksnya.
3. Buat empat paragraf dan konfigurasikan simbol bullet mereka.
4. Setel nilai [ParagraphFormat.setDepth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setdepth/) mereka menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf ke bingkai teks dan simpan presentasi.

Contoh JavaScript berikut membuat daftar bullet empat level:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Mulai Item Daftar Bernomor dengan Nilai Kustom**

Gunakan [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) untuk mengatur nomor awal yang ditampilkan pada paragraf bernomor.

1. Buat [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke sebuah slide.
2. Bersihkan paragraf default dari bingkai teks shape.
3. Buat tiga paragraf bernomor.
4. Setel [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) ke `2`, `3`, dan `7` untuk masing-masing paragraf.
5. Tambahkan paragraf ke bingkai teks dan simpan presentasi.

Contoh JavaScript berikut menetapkan nomor awal kustom untuk setiap paragraf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrol Tata Letak Paragraf dan Properti Akhir**

### **Set Indent Baris Pertama**

Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) untuk mengontrol indent baris pertama sebuah paragraf. Metode ini memindahkan hanya baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris lainnya tetap sejajar dengan tubuh paragraf.

Gunakan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) ketika Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) ketika Anda hanya ingin memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) yang berbeda untuk memperlihatkan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) shape dan hapus paragraf default.
5. Buat beberapa paragraf dan setel nilai [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) yang berbeda untuk masing-masing.
6. Tambahkan paragraf ke bingkai teks.
7. Simpan presentasi yang telah dimodifikasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Indent baris pertama dari paragraf](first_line_indent.png)

### **Set Indent Menggantung**

Indent menggantung adalah tata letak paragraf di mana baris pertama dimulai di sebelah kiri baris-baris berikutnya. Di Aspose.Slides, Anda membuat efek ini dengan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/). Berikan nilai negatif untuk menggeser baris pertama ke kiri relatif terhadap tubuh paragraf.

Dalam praktiknya, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) menentukan posisi kiri tubuh paragraf, dan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent menggantung, berikan nilai positif ke `setMarginLeft` dan nilai negatif ke `setIndent`.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lainnya di mana baris yang dibungkus harus disejajarkan di bawah tubuh paragraf bukan di bawah karakter pertama baris pertama.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) shape dan hapus paragraf default.
5. Buat paragraf dan berikan nilai positif ke [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) untuk setiap paragraf.
6. Berikan nilai negatif ke [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) untuk menciptakan efek indent menggantung.
7. Tambahkan paragraf ke bingkai teks.
8. Simpan presentasi yang telah dimodifikasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Indent menggantung dari paragraf](hanging_indent.png)

### **Set Properti Jalur Akhir Paragraf**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) mengontrol pemformatan tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin ke tanda akhir paragraf kedua:

1. Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dan bersihkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan bagian teks ke masing-masing.
4. Buat [PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Setel [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) dan [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Tetapkan format dengan [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) dan simpan presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke Paragraf**

Gunakan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) untuk mengonversi markup HTML menjadi paragraf dan portion dalam sebuah bingkai teks.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses sebuah slide dan tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
3. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) shape dan bersihkan paragraf default.
4. Definisikan atau baca string HTML sumber.
5. Berikan string HTML ke [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Simpan presentasi yang telah dimodifikasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ekspor Teks Paragraf ke HTML**

Gunakan [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) untuk mengekspor rentang paragraf terpilih sebagai HTML.

1. Buat atau muat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide dan temukan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) yang berisi teks.
3. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) shape.
4. Panggil [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Render Paragraf sebagai Gambar**

[Paragraph.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/#getImage) merender paragraf individual secara langsung dan mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/). Simpan hasilnya ke file dengan [IImage.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/#save). Anda tidak perlu merender shape yang berisi atau memotong bitmap secara manual.

[Paragraph.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/#getImage) dapat mengembalikan `null` jika paragraf tidak dapat ditemukan dalam koleksi induknya, tidak memiliki batasan rendering yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpannya dan bebaskan gambar yang dikembalikan setelah digunakan.

#### **Render Paragraf pada Skala Default**

Kotak teks berikut berisi tiga paragraf:

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam shape teks reguler pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Blok `finally` memastikan gambar dibebaskan dengan benar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Hasil:

![Gambar paragraf](paragraph_to_image_output.png)

#### **Render Paragraf dalam Sel Tabel dengan Skala**

Gunakan overload [Paragraph.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/#getImage) yang menerima parameter `scaleX` dan `scaleY` untuk mengatur faktor skala horizontal dan vertikal. Contoh berikut membuat sebuah tabel, merender paragraf dalam sel pertama dengan lebar dan tinggi dua kali lipat ukuran default, dan menyimpan hasilnya sebagai gambar PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Faktor skala `1` mempertahankan ukuran piksel default pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar dengan lebar dan tinggi kira-kira dua kali dimensi default, sehingga menghasilkan empat kali lebih banyak piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output resolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran berkas. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara terpisah.

Merender seluruh shape dengan [Shape.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage) tetap berguna ketika output harus menyertakan isi, border, atau konteks visual lain dari shape. Untuk gambar hanya paragraf, gunakan [Paragraph.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkusan baris dalam bingkai teks?**

Ya. Setel [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/setwraptext/) untuk menonaktifkan pembungkusan sehingga baris tidak terputus di tepi bingkai teks.

**Bagaimana cara mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Gunakan [Paragraph.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/getrect/) untuk mengambil persegi batas paragraf. [Portion.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#getRect) memberikan batas sebuah portion individual.

**Di mana kontrol perataan paragraf (kiri, kanan, tengah, atau justify) diatur?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setalignment/) adalah pengaturan tingkat paragraf dan berlaku untuk seluruh paragraf terlepas dari pemformatan portion individual.

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan untuk bagian paragraf?**

Ya. Setel [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) untuk portion individual, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.