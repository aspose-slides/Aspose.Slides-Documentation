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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, bagian, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk Android via Java."
---
## **Ikhtisar**

Aspose.Slides untuk Android via Java merepresentasikan teks sebagai hierarki bingkai teks, paragraf, dan bagian:

* [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) mewakili kontainer teks dalam sebuah bentuk dan menyediakan akses ke koleksi paragrafnya.
* [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) mewakili satu paragraf dalam sebuah bingkai teks dan menyediakan akses ke bagian‑bagian serta pemformatan tingkat paragraf.
* [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) mewakili sebuah run teks di dalam paragraf. Setiap bagian dapat memiliki teks dan pemformatan tingkat karakter masing‑masing.

Sehingga sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan pemformatan lain yang berbeda dengan menggunakan beberapa bagian.

## **Buat dan Format Paragraf**

### **Buat Paragraf dengan Beberapa Bagian**

Langkah‑langkah berikut membuat sebuah bingkai teks dengan tiga paragraf, masing‑masing berisi tiga bagian:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) berbentuk persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) milik shape.
5. Gunakan paragraf default dan tambahkan dua objek [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) lagi ke dalam text frame.
6. Tambahkan cukup objek [IPortion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/) untuk setiap paragraf agar masing‑masing berisi tiga bagian. Paragraf default sudah berisi satu bagian kosong.
7. Atur teks setiap bagian.
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

## **Buat Daftar Bullet dan Bernomor**

### **Buat Daftar Bullet atau Bernomor**

Bullet dan penomoran memudahkan pemindaian item terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [IBulletFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/).

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide yang dipilih.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) milik shape.
5. Hapus paragraf default dari text frame.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) untuk bullet simbol.
7. Setel [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-int-) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/) dan tentukan karakter bullet.
8. Atur teks paragraf, indent, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke text frame.
10. Buat paragraf kedua dan setel [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-int-) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke text frame.
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

Bullet gambar memungkinkan Anda menggunakan gambar khusus alih‑alih simbol atau angka.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dan akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) miliknya.
4. Hapus paragraf default dari text frame.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/).
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) dan atur teksnya.
7. Setel [IBulletFormat.setType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setType-int-) ke [BulletType.Picture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/bullettype/).
8. Tetapkan gambar melalui [IBulletFormat.getPicture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#getPicture--) dan atur tinggi bullet.
9. Tambahkan paragraf ke text frame.
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

### **Buat Daftar Multilevel**

Setel [IParagraphFormat.setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) untuk menempatkan paragraf pada level daftar yang berbeda. Level teratas memiliki kedalaman `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dan bersihkan paragraf default dari bingkai teksnya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Setel nilai [IParagraphFormat.setDepth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) mereka menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf ke text frame dan simpan presentasi.

Contoh Android via Java ini membuat daftar bullet empat level:

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

Gunakan [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) untuk mengatur nomor awal yang ditampilkan pada paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) ke slide.
2. Bersihkan paragraf default dari bingkai teks shape.
3. Buat tiga paragraf bernomor.
4. Setel [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) ke `2`, `3`, dan `7` untuk paragraf masing‑masing.
5. Tambahkan paragraf ke text frame dan simpan presentasi.

Contoh Android via Java ini menetapkan nomor awal kustom untuk setiap paragraf:

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

## **Kontrol Tata Letak Paragraf dan Properti Akhir**

### **Atur Indent Baris Pertama**

Gunakan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) untuk mengontrol indent baris pertama sebuah paragraf. Metode ini memindahkan hanya baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris lainnya tetap rata dengan badan paragraf.

Gunakan [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ketika Anda perlu memindahkan seluruh paragraf. Gunakan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ketika Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai‑nilai [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yang berbeda untuk menunjukkan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) milik shape dan hapus paragraf default.
5. Buat beberapa paragraf dan setel nilai‑nilai [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf ke text frame.
7. Simpan presentasi yang telah dimodifikasi.

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

Hasil:

![Indent baris pertama dari paragraf](first_line_indent.png)

### **Atur Indent Menggantung**

Indent menggantung adalah tata letak paragraf di mana baris pertama mulai di sebelah kiri baris‑baris berikutnya. Di Aspose.Slides, Anda menciptakan efek ini dengan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Berikan nilai negatif untuk menggerakkan baris pertama ke kiri relatif terhadap badan paragraf.

Dalam praktiknya, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) menentukan posisi kiri badan paragraf, dan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent menggantung, berikan nilai positif pada `setMarginLeft` dan nilai negatif pada `setIndent`.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris‑baris yang dibungkus harus rata di bawah badan paragraf bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) milik shape dan hapus paragraf default.
5. Buat paragraf‑paragraf dan berikan nilai positif pada [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) untuk masing‑masing.
6. Berikan nilai negatif pada [IParagraphFormat.setIndent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) untuk menciptakan efek indent menggantung.
7. Tambahkan paragraf ke text frame.
8. Simpan presentasi yang telah dimodifikasi.

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

Hasil:

![Indent menggantung dari paragraf](hanging_indent.png)

### **Setel Properti Run Akhir Paragraf**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) mengontrol pemformatan tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin pada tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dan bersihkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan bagian‑bagian teks ke dalamnya.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Setel [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) dan [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Tetapkan format tersebut dengan [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) dan simpan presentasi.

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

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke dalam Paragraf**

Gunakan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) untuk mengonversi markup HTML menjadi paragraf dan bagian dalam sebuah bingkai teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
2. Akses sebuah slide dan tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).
3. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) shape dan bersihkan paragraf defaultnya.
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

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) yang berisi teks.
3. Akses [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) shape.
4. Panggil [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

Contoh Android via Java ini mengekspor semua paragraf dari shape teks pertama:

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

[IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage--) merender sebuah paragraf individu secara langsung dan mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/). Simpan hasilnya ke file atau stream dengan [IImage.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Anda tidak perlu merender shape yang memuatnya atau memotong bitmap secara manual.

[IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage--) dapat mengembalikan `null` jika paragraf tidak ditemukan dalam koleksi induknya, tidak memiliki batas render yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpannya dan buang gambar yang dikembalikan setelah penggunaan.

#### **Render Paragraf pada Skala Default**

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam shape teks biasa pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Blok `finally` memastikan gambar dibuang dengan benar.

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

Hasil:

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

Faktor skala `1` mempertahankan ukuran pixel default pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar yang lebar dan tingginya kira‑kira dua kali dimensi default, sehingga memiliki empat kali lebih banyak pixel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output resolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran file. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara independen.

Merender seluruh shape dengan [IShape.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getImage--) tetap berguna ketika output harus mencakup isi, batas, atau konteks visual lain dari shape. Untuk gambar hanya paragraf, gunakan [IParagraph.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkusan baris di dalam text frame?**

Ya. Setel [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) untuk menonaktifkan pembungkusan sehingga baris tidak terputus di tepi text frame.

**Bagaimana saya dapat memperoleh batas tepat pada slide dari paragraf tertentu?**

Gunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/#getRect--) untuk mengambil persegi panjang pembatas paragraf. [IPortion.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/#getRect--) menyediakan batas bagian individu.

**Di mana pengaturan perataan paragraf (kiri, kanan, tengah, atau justify) dikontrol?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) adalah pengaturan tingkat paragraf dan berlaku untuk seluruh paragraf terlepas dari pemformatan bagian individu.

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan untuk sebagian paragraf?**

Ya. Setel [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) untuk bagian‑bagian individu, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.