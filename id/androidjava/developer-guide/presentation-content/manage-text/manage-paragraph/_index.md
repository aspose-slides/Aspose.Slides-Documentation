---
title: "Mengelola Paragraf Teks PowerPoint di Android"
linktitle: "Kelola Paragraf"
type: docs
weight: 40
url: /id/androidjava/manage-paragraph/
keywords:
- "tambahkan teks"
- "tambahkan paragraf"
- "kelola teks"
- "kelola paragraf"
- "kelola bullet"
- "indentasi paragraf"
- "indentasi menggantung"
- "bullet paragraf"
- "daftar bernomor"
- "daftar berpoin"
- "properti paragraf"
- "impor HTML"
- "teks ke HTML"
- "paragraf ke HTML"
- "paragraf ke gambar"
- "teks ke gambar"
- "ekspor paragraf"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Kuasa format paragraf dengan Aspose.Slides untuk Android - optimalkan perataan, spasi, dan gaya dalam presentasi PPT, PPTX, serta ODP menggunakan Java."
---
## **Pendahuluan**

Aspose.Slides menyediakan semua antarmuka dan kelas yang Anda perlukan untuk bekerja dengan teks, paragraf, dan bagian PowerPoint dalam Java.

* Aspose.Slides menyediakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) untuk memungkinkan Anda menambahkan objek yang mewakili sebuah paragraf. Sebuah objek `ITextFame` dapat memiliki satu atau beberapa paragraf (setiap paragraf dibuat melalui karakter kembali baris).
* Aspose.Slides menyediakan antarmuka [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) untuk memungkinkan Anda menambahkan objek yang mewakili bagian-bagian. Sebuah objek `IParagraph` dapat memiliki satu atau beberapa bagian (koleksi objek iPortions).
* Aspose.Slides menyediakan antarmuka [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) untuk memungkinkan Anda menambahkan objek yang mewakili teks dan properti formatnya.

Sebuah objek `IParagraph` mampu menangani teks dengan properti format yang berbeda melalui objek `IPortion` yang mendasarinya.

## **Menambahkan Beberapa Paragraf yang Memuat Beberapa Bagian Teks**

Langkah‑langkah ini menunjukkan cara menambahkan bingkai teks yang berisi 3 paragraf dan setiap paragraf berisi 3 bagian:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah Rectangle [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
4. Dapatkan ITextFrame yang terkait dengan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).
5. Buat dua objek [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) dan tambahkan ke koleksi `IParagraphs` dari [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/).
6. Buat tiga objek [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) untuk setiap `IParagraph` baru (dua objek Portion untuk Paragraf default) dan tambahkan masing‑masing objek `IPortion` ke koleksi IPortion setiap `IParagraph`.
7. Tetapkan teks untuk setiap bagian.
8. Terapkan fitur format pilihan Anda ke setiap bagian menggunakan properti format yang diekspos oleh objek `IPortion`.
9. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut merupakan implementasi langkah‑langkah menambahkan paragraf yang memuat bagian-bagian:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape bertipe Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Akses TextFrame dari AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Buat Paragraph dan Portion dengan format teks yang berbeda
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Tulis PPTX ke Disk
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mengelola Bullet Paragraf**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf berpoin selalu lebih mudah dibaca dan dipahami.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/).
7. Atur `Type` bullet untuk paragraf menjadi `Symbol` dan tetapkan karakter bullet.
8. Atur `Text` paragraf.
9. Atur `Indent` paragraf untuk bullet.
10. Atur warna bullet.
11. Atur tinggi bullet.
12. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
13. Tambahkan paragraf kedua dan ulangi proses pada langkah 7 sampai 13.
14. Simpan presentasi.

Kode Java berikut menunjukkan cara menambahkan bullet paragraf:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menambahkan dan mengakses Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Mengakses text frame autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Menghapus paragraf default
    txtFrm.getParagraphs().removeAt(0);

    // Membuat paragraf
    Paragraph para = new Paragraph();

    // Mengatur gaya bullet paragraf dan simbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Mengatur teks paragraf
    para.setText("Welcome to Aspose.Slides");

    // Mengatur indent bullet
    para.getParagraphFormat().setIndent(25);

    // Mengatur warna bullet
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // set IsBulletHardColor ke true untuk menggunakan warna bullet sendiri

    // Mengatur Tinggi Bullet
    para.getParagraphFormat().getBullet().setHeight(100);

    // Menambahkan Paragraf ke text frame
    txtFrm.getParagraphs().add(para);

    // Membuat paragraf kedua
    Paragraph para2 = new Paragraph();

    // Mengatur tipe dan gaya bullet paragraf
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Menambahkan teks paragraf
    para2.setText("This is numbered bullet");

    // Mengatur indent bullet
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // set IsBulletHardColor ke true untuk menggunakan warna bullet sendiri

    // Mengatur Tinggi Bullet
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Menambahkan Paragraf ke text frame
    txtFrm.getParagraphs().add(para2);
    
    // Menyimpan presentasi yang telah dimodifikasi
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mengelola Bullet Gambar**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf gambar mudah dibaca dan dipahami.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/).
7. Muat gambar ke dalam [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/).
8. Atur tipe bullet menjadi [Picture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) dan tetapkan gambar.
9. Atur `Text` Paragraph.
10. Atur `Indent` Paragraph untuk bullet.
11. Atur warna bullet.
12. Atur tinggi bullet.
13. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
14. Tambahkan paragraf kedua dan ulangi proses berdasarkan langkah‑langkah sebelumnya.
15. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara menambahkan dan mengelola bullet gambar:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation presentation = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = presentation.getSlides().get_Item(0);

    // Membuat instance gambar untuk bullet
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Menambahkan dan mengakses Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Mengakses textframe autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Menghapus paragraf default
    textFrame.getParagraphs().removeAt(0);

    // Membuat paragraf baru
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Mengatur gaya bullet paragraf dan gambar
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Mengatur Tinggi Bullet
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Menambahkan paragraf ke text frame
    textFrame.getParagraphs().add(paragraph);

    // Menulis presentasi sebagai file PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Menulis presentasi sebagai file PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Mengelola Bullet Multi‑level**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet multi‑level mudah dibaca dan dipahami.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) pada slide baru.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) dan atur depth ke 0.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur depth ke 1.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur depth ke 2.
9. Buat instance paragraf keempat melalui kelas `Paragraph` dan atur depth ke 3.
10. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame`.
11. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara menambahkan dan mengelola bullet multi‑level:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan dan mengakses Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Mengakses text frame autoshape yang dibuat
    ITextFrame text = aShp.addTextFrame("");

    // Menghapus paragraf default
    text.getParagraphs().clear();

    // Menambahkan paragraf pertama
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Mengatur tingkat bullet
    para1.getParagraphFormat().setDepth((short)0);

    // Menambahkan paragraf kedua
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Mengatur tingkat bullet
    para2.getParagraphFormat().setDepth((short)1);

    // Menambahkan paragraf ketiga
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Mengatur tingkat bullet
    para3.getParagraphFormat().setDepth((short)2);

    // Menambahkan paragraf keempat
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Mengatur tingkat bullet
    para4.getParagraphFormat().setDepth((short)3);

    // Menambahkan paragraf ke koleksi
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Menulis presentasi sebagai file PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mengelola Paragraf dengan Daftar Bernomor Kustom**

Antarmuka [IBulletFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/) menyediakan properti [NumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) dan lainnya yang memungkinkan Anda mengelola paragraf dengan penomoran atau format kustom.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang berisi paragraf.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari autoshape.
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) dan atur [NumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) menjadi 2.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` menjadi 3.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` menjadi 7.
9. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame`.
10. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara menambahkan dan mengelola paragraf dengan penomoran atau format kustom:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Mengakses text frame autoshape yang dibuat
    ITextFrame textFrame = shape.getTextFrame();

    // Menghapus paragraf default yang ada
    textFrame.getParagraphs().removeAt(0);

    // Daftar pertama
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menetapkan Indent Baris Pertama untuk Paragraf**

Gunakan metode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) untuk mengontrol indent baris pertama suatu paragraf. Metode ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris lainnya tetap sejajar dengan badan paragraf.

Gunakan [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) bila Anda perlu memindahkan seluruh paragraf. Gunakan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah membuat beberapa paragraf dan menerapkan nilai indent yang berbeda untuk memperlihatkan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [Indent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf‑paragraf ke text frame.
7. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara menetapkan indent paragraf:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Hasilnya:

![Indent baris pertama paragraf](first_line_indent.png)

## **Menetapkan Indent Menggantung untuk Paragraf**

Indent menggantung adalah tata letak paragraf di mana baris pertama dimulai lebih ke kiri dibandingkan baris‑baris berikutnya. Di Aspose.Slides, Anda menciptakan efek ini dengan metode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Tetapkan indent ke nilai negatif untuk menggeser baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktik, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) menentukan posisi kiri badan paragraf, dan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent menggantung, atur nilai `MarginLeft` positif dan nilai `Indent` negatif.

Format ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus sejajar di bawah badan paragraf, bukan di bawah karakter pertama baris pertama.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat paragraf‑paragraf dan atur nilai [MarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) positif untuk masing‑masing.
6. Atur nilai [Indent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) negatif untuk menciptakan efek indent menggantung.
7. Tambahkan paragraf‑paragraf ke text frame.
8. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara menetapkan indent menggantung untuk paragraf:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Hasilnya:

![Indent menggantung paragraf](hanging_indent.png)

## **Mengelola Properti Jalur Akhir Paragraf**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi slide yang berisi paragraf melalui posisinya.
1. Tambahkan sebuah rectangle [autoshape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dengan dua paragraf ke Rectangle.
1. Tetapkan `FontHeight` dan jenis Font untuk paragraf‑paragraf.
1. Tetapkan properti End untuk paragraf‑paragraf.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan cara menetapkan properti End untuk paragraf dalam PowerPoint:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mengimpor Teks HTML ke dalam Paragraf**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengimpor teks HTML ke dalam paragraf.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
4. Tambahkan dan akses `autoshape` [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/).
5. Hapus paragraf default di dalam `ITextFrame`.
6. Baca file HTML sumber menggunakan TextReader.
7. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/).
8. Tambahkan konten file HTML yang dibaca dari TextReader ke [ParagraphCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/) pada TextFrame.
9. Simpan presentasi yang telah dimodifikasi.

Kode Java ini merupakan implementasi langkah‑langkah mengimpor teks HTML ke dalam paragraf:

```java
// Buat instance presentasi kosong
Presentation pres = new Presentation();
try {
    // Akses slide pertama default dari presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan AutoShape untuk menampung konten HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Menambahkan text frame ke shape
    ashape.addTextFrame("");

    // Membersihkan semua paragraf di text frame yang ditambahkan
    ashape.getTextFrame().getParagraphs().clear();

    // Memuat file HTML menggunakan stream reader
    TextReader tr = new StreamReader("file.html");

    // Menambahkan teks dari stream reader HTML ke text frame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Menyimpan Presentasi
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Mengekspor Teks Paragraf ke HTML**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengekspor teks (yang terdapat dalam paragraf) ke HTML.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses referensi slide yang relevan melalui indeksnya.
3. Akses shape yang berisi teks yang akan diekspor ke HTML.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) pada shape tersebut.
5. Buat instance `StreamWriter` dan tambahkan file HTML baru.
6. Berikan indeks awal ke StreamWriter dan ekspor paragraf‑paragraf pilihan Anda.

Kode Java berikut menunjukkan cara mengekspor teks paragraf PowerPoint ke HTML:

```java
// Muat file presentasi
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Akses slide pertama default dari presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Indeks yang diinginkan
    int index = 0;

    // Mengakses shape yang ditambahkan
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Membuat file HTML output
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Mengekstrak paragraf pertama sebagai HTML
    // Menulis data Paragraf ke HTML dengan memberikan indeks awal paragraf, total paragraf yang akan disalin
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menyimpan Paragraf sebagai Gambar**

Pada bagian ini, kami akan mengeksplorasi dua contoh yang menunjukkan cara menyimpan paragraf teks, yang diwakili oleh antarmuka [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/), sebagai gambar. Kedua contoh mencakup memperoleh gambar shape yang berisi paragraf menggunakan metode `getImage` dari antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), menghitung batas paragraf di dalam shape, dan mengekspornya sebagai gambar bitmap. Pendekatan ini memungkinkan Anda mengekstrak bagian‑bagian tertentu dari teks dalam presentasi PowerPoint dan menyimpannya sebagai gambar terpisah, yang dapat berguna untuk penggunaan lebih lanjut dalam berbagai skenario.

Misalkan kita memiliki file presentasi bernama **sample.pptx** dengan satu slide, di mana shape pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

**Contoh 1**

Dalam contoh ini, kami memperoleh paragraf kedua sebagai gambar. Untuk melakukannya, kami mengekstrak gambar shape dari slide pertama presentasi, kemudian menghitung batas paragraf kedua dalam text frame shape tersebut. Paragraf kemudian digambar ulang pada gambar bitmap baru, yang disimpan dalam format PNG. Metode ini sangat berguna ketika Anda perlu menyimpan paragraf tertentu sebagai gambar terpisah sambil mempertahankan dimensi dan format teks yang tepat.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Simpan shape dalam memori sebagai bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Buat bitmap shape dari memori.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Hitung batas paragraf kedua.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Potong bitmap shape untuk mendapatkan bitmap paragraf saja.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

**Contoh 2**

Dalam contoh ini, kami memperluas pendekatan sebelumnya dengan menambahkan faktor skala pada gambar paragraf. Shape diekstrak dari presentasi dan disimpan sebagai gambar dengan faktor skala `2`. Hal ini memungkinkan keluaran dengan resolusi lebih tinggi saat mengekspor paragraf. Batas paragraf kemudian dihitung dengan mempertimbangkan skala. Skala dapat sangat berguna ketika dibutuhkan gambar yang lebih detail, misalnya untuk penggunaan dalam materi cetak berkualitas tinggi.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Simpan shape dalam memori sebagai bitmap dengan skala.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Buat bitmap shape dari memori.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Hitung batas paragraf kedua.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Potong bitmap shape untuk mendapatkan bitmap paragraf saja.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat menonaktifkan sepenuhnya pembungkus baris di dalam text frame?**

Ya. Gunakan pengaturan pembungkus text frame ([setWrapText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) untuk mematikan pembungkus sehingga baris tidak terpotong di tepi frame.

**Bagaimana cara mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Anda dapat memperoleh persegi panjang pembatas paragraf (bahkan untuk satu bagian) untuk mengetahui posisi dan ukuran tepatnya pada slide.

**Di mana pengaturan perataan paragraf (kiri/kanan/tengah/justify) dikendalikan?**

[Alignment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) adalah pengaturan tingkat paragraf di [ParagraphFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphformat/); ia berlaku untuk seluruh paragraf terlepas dari format bagian individual.

**Apakah saya dapat menetapkan bahasa pemeriksaan ejaan hanya untuk bagian tertentu dari paragraf (misalnya satu kata)?**

Ya. Bahasa diatur pada tingkat bagian ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), sehingga beberapa bahasa dapat hidup berdampingan dalam satu paragraf.