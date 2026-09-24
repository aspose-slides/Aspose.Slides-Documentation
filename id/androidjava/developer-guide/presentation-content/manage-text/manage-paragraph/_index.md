---
title: Kelola Paragraf Teks PowerPoint di Android
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- menambah teks
- menambah paragraf
- mengelola teks
- mengelola paragraf
- mengelola bullet
- indentasi paragraf
- indentasi menggantung
- bullet paragraf
- daftar bernomor
- daftar bertanda
- properti paragraf
- impor HTML
- teks ke HTML
- paragraf ke HTML
- paragraf ke gambar
- teks ke gambar
- ekspor paragraf
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, bagian, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java merepresentasikan teks sebagai hirarki bingkai teks, paragraf, dan bagian:

* [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) mewakili wadah teks dalam sebuah bentuk dan menyediakan akses ke koleksi paragrafnya.
* [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) mewakili satu paragraf dalam bingkai teks dan menyediakan akses ke bagian-bagiannya serta pemformatan tingkat paragraf.
* [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) mewakili rentang teks dalam sebuah paragraf. Setiap bagian dapat memiliki teks dan pemformatan tingkat karakter tersendiri.

Dengan demikian, sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan pemformatan lain yang berbeda dengan menggunakan beberapa bagian.

## **Buat dan Format Paragraf**

### **Buat Paragraf dengan Beberapa Bagian**

Langkah-langkah berikut membuat bingkai teks dengan tiga paragraf, masing‑masing berisi tiga bagian:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) milik bentuk.
5. Gunakan paragraf default dan tambahkan dua objek [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) lagi ke bingkai teks.
6. Tambahkan cukup objek [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) untuk masing‑masing paragraf agar berisi tiga bagian. Paragraf default sudah berisi satu bagian kosong.
7. Atur teks masing‑masing bagian.
8. Terapkan pemformatan tingkat karakter melalui [IPortion.getPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Simpan presentasi yang telah dimodifikasi.

Contoh Android via Java ini mengimplementasikan langkah‑langkah tersebut:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Buat Daftar Bertanda dan Bernomor**

### **Buat Daftar Bertanda atau Bernomor**

Bullet dan penomoran memudahkan pemindaian item terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [IBulletFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/).

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide yang dipilih.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) milik bentuk.
5. Hapus paragraf default dari bingkai teks.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) untuk bullet simbol.
7. Atur [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-int-) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/) dan tentukan karakter bullet.
8. Atur teks paragraf, indentasi, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke bingkai teks.
10. Buat paragraf kedua dan atur [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-int-) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke bingkai teks.
12. Simpan presentasi.

Contoh Android via Java ini membuat bullet simbol dan bullet bernomor:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gunakan Bullet Gambar**

Bullet gambar memungkinkan Anda memakai gambar khusus alih‑alih simbol atau angka.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dan akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) miliknya.
4. Hapus paragraf default dari bingkai teks.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/).
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) dan atur teksnya.
7. Atur [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-int-) ke [BulletType.Picture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/).
8. Tetapkan gambar melalui [IBulletFormat.getPicture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#getPicture--) dan atur tinggi bullet.
9. Tambahkan paragraf ke bingkai teks.
10. Simpan presentasi yang telah dimodifikasi.

Contoh Android via Java ini membuat bullet gambar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Buat Daftar Bertingkat**

Atur [IParagraphFormat.setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) untuk menempatkan paragraf pada tingkatan yang berbeda dalam sebuah daftar. Tingkat teratas memiliki kedalaman `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) serta bersihkan paragraf default dari bingkai teksnya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Atur nilai [IParagraphFormat.setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) mereka menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf ke bingkai teks dan simpan presentasi.

Contoh Android via Java ini membuat daftar bertanda empat tingkat:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Mulai Item Daftar Bernomor dengan Nilai Kustom**

Gunakan [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) untuk menetapkan angka awal yang ditampilkan pada paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
2. Bersihkan paragraf default dari bingkai teks bentuk.
3. Buat tiga paragraf bernomor.
4. Atur [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) menjadi `2`, `3`, dan `7` untuk paragraf masing‑masing.
5. Tambahkan paragraf ke bingkai teks dan simpan presentasi.

Contoh Android via Java ini menetapkan angka mulai kustom untuk setiap paragraf:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kendalikan Tata Letak Paragraf dan Properti Akhir**

### **Atur Inden Baris Pertama**

Gunakan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) untuk mengontrol inden baris pertama sebuah paragraf. Metode ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris lainnya tetap sejajar dengan badan paragraf.

Gunakan [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) bila Anda perlu memindahkan seluruh paragraf. Gunakan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yang berbeda untuk mendemonstrasikan bagaimana inden baris pertama memengaruhi tata letak paragraf.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) bentuk dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf ke bingkai teks.
7. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur inden paragraf:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Indentasi baris pertama dari paragraf](first_line_indent.png)

### **Atur Inden Gantung**

Inden menggantung adalah tata letak paragraf di mana baris pertama mulai di sebelah kiri baris‑baris lainnya. Di Aspose.Slides, Anda membuat efek ini dengan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Berikan nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktis, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) menentukan posisi kiri badan paragraf, dan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat inden menggantung, berikan nilai positif pada `setMarginLeft` dan nilai negatif pada `setIndent`.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris‑baris yang dibungkus harus rata di bawah badan paragraf bukan di bawah karakter pertama baris pertama.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) bentuk dan hapus paragraf default.
5. Buat paragraf dan berikan nilai positif pada [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) untuk masing‑masing paragraf.
6. Berikan nilai negatif pada [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) untuk menciptakan efek inden menggantung.
7. Tambahkan paragraf ke bingkai teks.
8. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur inden menggantung untuk sebuah paragraf:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Indentasi menggantung dari paragraf](hanging_indent.png)

### **Atur Properti Jalankan Akhir Paragraf**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) mengontrol pemformatan tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin pada tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) serta bersihkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan bagian‑bagian teks ke masing‑masing.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Atur [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) dan [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Terapkan format dengan [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) dan simpan presentasi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hitung Baris yang Dihasilkan**

Gunakan [IParagraph.getLinesCount](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) untuk menghitung jumlah baris yang ditempati oleh sebuah paragraf setelah tata letak teks, termasuk pembungkusan otomatis. Ini berguna saat memeriksa panjang teks dan tata letak dalam templat presentasi.

Sebuah paragraf merupakan satu item dalam [ITextFrame.getParagraphs](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParagraphs--), dan dapat menempati beberapa baris yang dirender. Istirahat baris eksplisit dalam paragraf memaksa baris baru tanpa membuat paragraf tambahan. Pembungkusan otomatis menghasilkan baris berdasarkan lebar yang tersedia tanpa menyisipkan istirahat baris eksplisit ke dalam teks. Oleh karena itu, menghitung paragraf atau karakter istirahat baris tidak memberikan jumlah baris yang dirender.

Contoh berikut membuat sebuah bentuk teks, menghitung barisnya, mempersempit bentuk, lalu mengganti teks dengan string yang lebih pendek. Pembungkusan diaktifkan dan autofit dinonaktifkan sehingga lebar bentuk mengontrol pembungkusan tanpa memperkecil teks atau mengubah ukuran bentuk secara otomatis. Dimensi bentuk dalam poin. Akhirnya, contoh menambahkan paragraf lain dan menjumlahkan total baris di seluruh bingkai teks.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Dengan teks dan dimensi ini, mempersempit bentuk meningkatkan jumlah baris, sementara mengganti teks dengan string pendek menguranginya. Hitungan pasti dapat bervariasi tergantung pada ketersediaan dan substitusi font, ukuran font, margin, indentasi, pembungkusan, dan pengaturan autofit. Gunakan font dan pengaturan tata letak yang ditujukan untuk lingkungan target saat memeriksa sebuah templat.

Jumlah baris saja tidak menentukan apakah teks meluap dari kontainernya. Tinggi yang tersedia, tinggi baris, spasi paragraf dan baris, serta perilaku autofit juga berpengaruh; bahkan satu baris dapat melampaui lebar yang tersedia bila pembungkusan dinonaktifkan.

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke dalam Paragraf**

Gunakan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) untuk mengonversi markup HTML menjadi paragraf dan bagian dalam sebuah bingkai teks.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses sebuah slide dan tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).
3. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) bentuk dan bersihkan paragraf defaultnya.
4. Baca file HTML sumber.
5. Serahkan string HTML ke [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Simpan presentasi yang telah dimodifikasi.

Contoh Android via Java ini mengimpor HTML ke dalam bingkai teks:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ekspor Teks Paragraf ke HTML**

Gunakan [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) untuk mengekspor rentang paragraf yang dipilih sebagai HTML.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) yang berisi teks.
3. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) bentuk.
4. Panggil [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

Contoh Android via Java ini mengekspor semua paragraf dari bentuk teks pertama:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Render Paragraf sebagai Gambar**

[IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage--) merender sebuah paragraf secara langsung dan mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/). Simpan hasilnya ke file atau stream dengan [IImage.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Anda tidak perlu merender bentuk yang memuatnya atau memotong bitmap secara manual.

[IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage--) dapat mengembalikan `null` jika paragraf tidak dapat ditemukan dalam koleksi induknya, tidak memiliki batas rendering yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpannya dan buang gambar yang dikembalikan setelah penggunaan.

#### **Render Paragraf pada Skala Default**

Misalkan kami memiliki file presentasi bernama sample.pptx dengan satu slide, di mana bentuk pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam bentuk teks biasa pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Blok `finally` memastikan gambar dibuang dengan benar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

#### **Render Paragraf dalam Sel Tabel dengan Skala**

Gunakan overload [IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) yang menerima parameter `float scaleX` dan `float scaleY` untuk mengatur faktor skala horizontal dan vertikal. Contoh berikut membuat sebuah tabel, merender paragraf dalam sel pertama dengan lebar dan tinggi dua kali lipat skala default, dan menyimpan hasilnya sebagai gambar PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Faktor skala `1` mempertahankan sumbu tersebut pada ukuran piksel defaultnya. Misalnya, `2` untuk kedua faktor menghasilkan gambar yang lebar dan tingginya kira‑kira dua kali dimensi default, menghasilkan empat kali lebih banyak piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output resolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran berkas. Faktor di bawah `1` menghasilkan gambar yang lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara independen.

Merender seluruh bentuk dengan [IShape.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getImage--) tetap berguna ketika output harus mencakup isi, batas, atau konteks visual lain dari bentuk. Untuk gambar yang hanya berisi paragraf, gunakan [IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkusan baris di dalam bingkai teks?**

Ya. Atur [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) untuk menonaktifkan pembungkusan sehingga baris tidak terputus di tepi bingkai teks.

**Bagaimana saya dapat memperoleh batas tepat pada slide untuk paragraf tertentu?**

Gunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getRect--) untuk mengambil persegi batas paragraf. [IPortion.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/#getRect--) menyediakan batas untuk bagian individu.

**Di mana kontrol perataan paragraf (kiri, kanan, tengah, atau justify) berada?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) adalah pengaturan tingkat paragraf dan berlaku untuk seluruh paragraf terlepas dari pemformatan bagian individu.

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan untuk bagian tertentu dari paragraf?**

Ya. Atur [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) untuk bagian‑bagian individu, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.