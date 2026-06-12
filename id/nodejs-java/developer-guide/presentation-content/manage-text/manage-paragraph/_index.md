---
title: Kelola Paragraf Teks PowerPoint di JavaScript
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/nodejs-java/manage-paragraph/
keywords:
- menambahkan teks
- menambahkan paragraf
- mengelola teks
- mengelola paragraf
- mengelola bullet
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasa format paragraf dengan Aspose.Slides untuk Node.js melalui Java—optimalkan perataan, spasi & gaya dalam presentasi PPT, PPTX, dan ODP di JavaScript."
---
## **Pendahuluan**

Aspose.Slides menyediakan semua kelas yang Anda perlukan untuk bekerja dengan teks, paragraf, dan potongan PowerPoint dalam Java.

* Aspose.Slides menyediakan kelas [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) untuk memungkinkan Anda menambahkan objek yang mewakili sebuah paragraf. Objek `TextFame` dapat memiliki satu atau beberapa paragraf (setiap paragraf dibuat melalui karakter kembali).
* Aspose.Slides menyediakan kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) untuk memungkinkan Anda menambahkan objek yang mewakili potongan. Objek `Paragraph` dapat memiliki satu atau beberapa potongan (kumpulan objek potongan teks).
* Aspose.Slides menyediakan kelas [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) untuk memungkinkan Anda menambahkan objek yang mewakili teks dan properti formatnya.

Objek `Paragraph` mampu menangani teks dengan properti format yang berbeda melalui objek `Portion` yang mendasarinya.

## **Menambahkan Beberapa Paragraf yang Berisi Beberapa Potongan**

Langkah‑langkah berikut menunjukkan cara menambahkan bingkai teks yang berisi 3 paragraf dan setiap paragraf berisi 3 potongan:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Dapatkan `ITextFrame` yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
5. Buat dua objek [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dan tambahkan ke koleksi `IParagraphs` dari [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).
6. Buat tiga objek [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) untuk setiap `Paragraph` baru (dua objek Portion untuk Paragraph default) dan tambahkan setiap objek `Portion` ke koleksi IPortion masing‑masing `Paragraph`.
7. Tetapkan teks untuk setiap potongan.
8. Terapkan fitur format pilihan Anda ke setiap potongan menggunakan properti format yang diekspos oleh objek `Portion`.
9. Simpan presentasi yang telah dimodifikasi.

Kode Javascript berikut merupakan implementasi langkah‑langkah untuk menambahkan paragraf yang berisi potongan:

```javascript
// Instansiasi kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan AutoShape tipe Persegi Panjang
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Mengakses TextFrame dari AutoShape
    var tf = ashp.getTextFrame();
    // Membuat Paragraf dan Portion dengan format teks yang berbeda
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Menyimpan PPTX ke Disk
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengelola Bullet Paragraf**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf ber‑bullet selalu lebih mudah dibaca dan dipahami.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/).
7. Atur `Type` bullet untuk paragraf menjadi `Symbol` dan tetapkan karakter bullet.
8. Atur `Text` paragraf.
9. Atur `Indent` paragraf untuk bullet.
10. Tetapkan warna untuk bullet.
11. Tetapkan tinggi bullet.
12. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
13. Tambahkan paragraf kedua dan ulangi proses pada langkah 7 sampai 13.
14. Simpan presentasi.

Kode Javascript berikut menunjukkan cara menambahkan bullet paragraf:

```javascript
    // Membuat instance kelas Presentation yang mewakili file PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // Mengakses slide pertama
        var slide = pres.getSlides().get_Item(0);
        // Menambahkan dan mengakses Autoshape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Mengakses TextFrame autoshape
        var txtFrm = aShp.getTextFrame();
        // Menghapus paragraf default
        txtFrm.getParagraphs().removeAt(0);
        // Membuat paragraf
        var para = new aspose.slides.Paragraph();
        // Mengatur gaya bullet paragraf dan simbol
        para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar(8226);
        // Mengatur teks paragraf
        para.setText("Welcome to Aspose.Slides");
        // Mengatur indentasi bullet
        para.getParagraphFormat().setIndent(25);
        // Mengatur warna bullet
        para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // atur IsBulletHardColor ke true untuk menggunakan warna bullet sendiri
        // Mengatur tinggi bullet
        para.getParagraphFormat().getBullet().setHeight(100);
        // Menambahkan Paragraf ke TextFrame
        txtFrm.getParagraphs().add(para);
        // Membuat paragraf kedua
        var para2 = new aspose.slides.Paragraph();
        // Mengatur jenis dan gaya bullet paragraf
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
        // Menambahkan teks paragraf
        para2.setText("This is numbered bullet");
        // Mengatur indentasi bullet
        para2.getParagraphFormat().setIndent(25);
        para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // atur IsBulletHardColor ke true untuk menggunakan warna bullet sendiri
        // Mengatur tinggi bullet
        para2.getParagraphFormat().getBullet().setHeight(100);
        // Menambahkan Paragraf ke TextFrame
        txtFrm.getParagraphs().add(para2);
        // Menyimpan presentasi yang telah dimodifikasi
        pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Mengelola Bullet Gambar**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf gambar mudah dibaca dan dipahami.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/).
7. Muat gambar ke dalam [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/).
8. Atur jenis bullet menjadi [Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dan tetapkan gambar.
9. Atur `Text` paragraf.
10. Atur `Indent` paragraf untuk bullet.
11. Tetapkan warna untuk bullet.
12. Tetapkan tinggi bullet.
13. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
14. Tambahkan paragraf kedua dan ulangi proses berdasarkan langkah‑langkah sebelumnya.
15. Simpan presentasi yang telah dimodifikasi.

Kode Javascript berikut menunjukkan cara menambahkan dan mengelola bullet gambar:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = presentation.getSlides().get_Item(0);
    // Membuat instance gambar untuk bullet
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan dan mengakses Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Mengakses TextFrame autoshape
    var textFrame = autoShape.getTextFrame();
    // Menghapus paragraf default
    textFrame.getParagraphs().removeAt(0);
    // Membuat paragraf baru
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Mengatur gaya bullet paragraf dan gambar
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Mengatur tinggi bullet
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Menambahkan paragraf ke TextFrame
    textFrame.getParagraphs().add(paragraph);
    // Menulis presentasi sebagai file PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Menulis presentasi sebagai file PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mengelola Bullet Multilevel**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet multilevel mudah dibaca dan dipahami.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) pada slide baru.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dan atur kedalaman menjadi 0.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur kedalaman menjadi 1.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur kedalaman menjadi 2.
9. Buat instance paragraf keempat melalui kelas `Paragraph` dan atur kedalaman menjadi 3.
10. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame`.
11. Simpan presentasi yang telah dimodifikasi.

Kode Javascript berikut menunjukkan cara menambahkan dan mengelola bullet multilevel:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan dan mengakses Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Mengakses TextFrame dari autoshape yang dibuat
    var text = aShp.addTextFrame("");
    // Menghapus paragraf default
    text.getParagraphs().clear();
    // Menambahkan paragraf pertama
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Mengatur level bullet
    para1.getParagraphFormat().setDepth(0);
    // Menambahkan paragraf kedua
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Mengatur level bullet
    para2.getParagraphFormat().setDepth(1);
    // Menambahkan paragraf ketiga
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Mengatur level bullet
    para3.getParagraphFormat().setDepth(2);
    // Menambahkan paragraf keempat
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Mengatur level bullet
    para4.getParagraphFormat().setDepth(3);
    // Menambahkan paragraf ke koleksi
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Menulis presentasi sebagai file PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengelola Paragraf dengan Daftar Berangka Kustom**

Kelas [BulletFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/) menyediakan properti [NumberedBulletStartWith](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) dan lainnya yang memungkinkan Anda mengelola paragraf dengan penomoran atau format khusus.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide yang berisi paragraf.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dan atur [NumberedBulletStartWith](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) menjadi 2.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` menjadi 3.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` menjadi 7.
9. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame`.
10. Simpan presentasi yang telah dimodifikasi.

Kode Javascript berikut menunjukkan cara menambahkan dan mengelola paragraf dengan penomoran atau format khusus:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Mengakses text frame dari autoshape yang dibuat
    var textFrame = shape.getTextFrame();
    // Menghapus paragraf default yang ada
    textFrame.getParagraphs().removeAt(0);
    // Daftar pertama
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mengatur Indentasi Baris Pertama untuk Sebuah Paragraf**

Gunakan metode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) untuk mengontrol indentasi baris pertama sebuah paragraf. Metode ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris lain tetap sejajar dengan isi paragraf.

Gunakan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) bila Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai indentasi yang berbeda untuk mendemonstrasikan cara indentasi baris pertama memengaruhi tata letak paragraf.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) kosong ke bentuk dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [Indent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf‑paragraf ke bingkai teks.
7. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara mengatur indentasi paragraf:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Hasilnya:

![Indentasi baris pertama dari paragraf](first_line_indent.png)

## **Mengatur Indentasi Gantung untuk Sebuah Paragraf**

Indentasi gantung adalah tata letak paragraf dimana baris pertama dimulai lebih ke kiri dibandingkan baris‑baris berikutnya. Di Aspose.Slides, Anda membuat efek ini dengan metode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/). Atur indentasi ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap isi paragraf.

Secara praktis, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) menentukan posisi kiri isi paragraf, dan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk menciptakan indentasi gantung, tetapkan nilai `MarginLeft` positif dan nilai `Indent` negatif.

Format ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain dimana baris‑baris yang dibungkus harus sejajar di bawah isi paragraf bukan di bawah karakter pertama baris pertama.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) kosong ke bentuk dan hapus paragraf default.
5. Buat paragraf‑paragraf dan atur nilai [MarginLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) positif untuk masing‑masing.
6. Atur nilai [Indent](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setindent/) negatif untuk menciptakan efek indentasi gantung.
7. Tambahkan paragraf‑paragraf ke bingkai teks.
8. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara mengatur indentasi gantung untuk sebuah paragraf:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Hasilnya:

![Indentasi gantung dari paragraf](hanging_indent.png)

## **Mengelola Properti Jalur Akhir Paragraf**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Dapatkan referensi slide yang berisi paragraf melalui posisinya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
1. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dengan dua paragraf ke persegi panjang.
1. Atur `FontHeight` dan jenis Font untuk paragraf‑paragraf.
1. Atur properti End untuk paragraf‑paragraf.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Javascript berikut menunjukkan cara mengatur properti End untuk paragraf di PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengimpor Teks HTML ke dalam Paragraf**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengimpor teks HTML ke dalam paragraf.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Tambahkan dan akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) milik `AutoShape`.
5. Hapus paragraf default di dalam `TextFrame`.
6. Baca file HTML sumber dalam sebuah `TextReader`.
7. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/).
8. Tambahkan konten file HTML yang dibaca dari `TextReader` ke [ParagraphCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphcollection/) `TextFrame`.
9. Simpan presentasi yang telah dimodifikasi.

Kode Javascript berikut merupakan implementasi langkah‑langkah untuk mengimpor teks HTML ke dalam paragraf:

```javascript
// Buat instance presentasi kosong
var pres = new aspose.slides.Presentation();
try {
    // Akses slide pertama default presentasi
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan AutoShape untuk menampung konten HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Menambahkan text frame ke shape
    ashape.addTextFrame("");
    // Menghapus semua paragraf di text frame yang ditambahkan
    ashape.getTextFrame().getParagraphs().clear();
    // Memuat file HTML menggunakan stream reader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Menambahkan teks dari stream reader HTML ke text frame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Menyimpan presentasi
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengekspor Teks Paragraf ke HTML**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengekspor teks (yang terdapat dalam paragraf) ke HTML.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses referensi slide yang relevan melalui indeksnya.
3. Akses bentuk yang berisi teks yang akan diekspor ke HTML.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) bentuk tersebut.
5. Buat instance `StreamWriter` dan tambahkan file HTML baru.
6. Tentukan indeks awal untuk `StreamWriter` dan ekspor paragraf‑paragraf pilihan Anda.

Kode Javascript berikut menunjukkan cara mengekspor teks paragraf PowerPoint ke HTML:

```javascript
// Memuat file presentasi
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Mengakses slide pertama default presentasi
    var slide = pres.getSlides().get_Item(0);
    // Indeks yang diinginkan
    var index = 0;
    // Mengakses shape yang ditambahkan
    var ashape = slide.getShapes().get_Item(index);
    // Membuat file HTML output
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Mengekstrak paragraf pertama sebagai HTML
    // Menulis data paragraf ke HTML dengan memberikan indeks mulai paragraf, total paragraf yang akan disalin
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menyimpan Paragraf sebagai Gambar**

Pada bagian ini, kami akan mengeksplorasi dua contoh yang menunjukkan cara menyimpan sebuah paragraf teks, yang diwakili oleh kelas [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/), sebagai gambar. Kedua contoh melibatkan memperoleh gambar dari sebuah bentuk yang berisi paragraf menggunakan metode `getImage` dari kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/), menghitung batas paragraf di dalam bentuk, dan mengekspornya sebagai gambar bitmap. Pendekatan ini memungkinkan Anda mengekstrak bagian teks tertentu dari presentasi PowerPoint dan menyimpannya sebagai gambar terpisah, yang dapat berguna untuk penggunaan lebih lanjut dalam berbagai skenario.

Misalkan kita memiliki file presentasi bernama `sample.pptx` dengan satu slide, di mana bentuk pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

**Contoh 1**

Pada contoh ini, kami memperoleh paragraf kedua sebagai gambar. Untuk melakukannya, kami mengekstrak gambar bentuk dari slide pertama presentasi, kemudian menghitung batas paragraf kedua dalam bingkai teks bentuk tersebut. Paragraf kemudian digambar ulang ke dalam gambar bitmap baru, yang disimpan dalam format PNG. Metode ini sangat berguna ketika Anda perlu menyimpan paragraf tertentu sebagai gambar terpisah sambil mempertahankan dimensi dan format teks yang tepat.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Simpan shape di memori sebagai bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Buat bitmap shape dari memori.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Hitung batas paragraf kedua.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Potong bitmap shape untuk memperoleh bitmap paragraf saja.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

**Contoh 2**

Pada contoh ini, kami memperluas pendekatan sebelumnya dengan menambahkan faktor skala pada gambar paragraf. Bentuk diekstrak dari presentasi dan disimpan sebagai gambar dengan faktor skala `2`. Ini memungkinkan output beresolusi lebih tinggi saat mengekspor paragraf. Batas paragraf kemudian dihitung dengan mempertimbangkan skala. Skala dapat sangat berguna ketika diperlukan gambar yang lebih detail, misalnya untuk materi cetak berkualitas tinggi.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Simpan shape di memori sebagai bitmap dengan skala.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Buat bitmap shape dari memori.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Hitung batas paragraf kedua.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Potong bitmap shape untuk memperoleh bitmap paragraf saja.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menonaktifkan pembungkusan baris di dalam sebuah TextFrame secara total?**

Ya. Gunakan pengaturan pembungkusan TextFrame ([setWrapText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/setwraptext/)) untuk mematikan pembungkusan sehingga baris tidak terputus pada tepi bingkai.

**Bagaimana cara mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Anda dapat mengambil persegi batas paragraf (bahkan untuk satu potongan) untuk mengetahui posisi dan ukuran yang tepat pada slide.

**Di mana pengaturan perataan paragraf (kiri/kanan/tengah/justify) berada?**

[setAlignment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setalignment/) adalah metode pengaturan level paragraf di [ParagraphFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/); ia berlaku untuk seluruh paragraf terlepas dari format potongan individu.

**Apakah saya dapat menetapkan bahasa pemeriksaan ejaan hanya untuk sebagian paragraf (misalnya satu kata)?**

Ya. Bahasa diatur pada tingkat potongan ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), sehingga beberapa bahasa dapat hidup berdampingan dalam satu paragraf.