---
title: Meningkatkan Presentasi Anda dengan AutoFit di Android
linktitle: Pengaturan Autofit
type: docs
weight: 30
url: /id/androidjava/manage-autofit-settings/
keywords:
- kotak teks
- autofit
- jangan autofit
- cocokkan teks
- perkecil teks
- bungkus teks
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola pengaturan AutoFit di Aspose.Slides untuk Android via Java untuk mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument Anda serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, saat Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fix text** untuk kotak teks—secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu muat di dalamnya.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—menambah tinggi—untuk memungkinkan menampung lebih banyak teks. 
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis memperkecil kotak teks—mengurangi tinggi—untuk menghilangkan ruang berlebih. 

Di PowerPoint, terdapat 4 parameter atau opsi penting yang mengontrol perilaku autofit untuk kotak teks:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java menyediakan opsi serupa—beberapa properti di kelas [TextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat) —yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi.

## **Ubah Ukuran Bentuk Agar Sesuai Teks**

Jika Anda ingin teks dalam sebuah kotak selalu cocok dalam kotak tersebut setelah perubahan teks dilakukan, Anda harus menggunakan opsi **Resize shape to fix text**. Untuk menentukan pengaturan ini, atur properti [AutofitType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat)) menjadi `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Kode Java berikut menunjukkan cara menentukan bahwa teks harus selalu cocok dalam kotaknya pada presentasi PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan secara otomatis diubah ukurannya (menambah tinggi) untuk memastikan semua teks muat di dalamnya. Jika teks menjadi lebih pendek, hal sebaliknya terjadi.

## **Jangan Autofit**

Jika Anda ingin kotak teks atau bentuk mempertahankan dimensinya terlepas dari perubahan teks yang dikandungnya, Anda harus menggunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, atur properti [AutofitType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat)) menjadi `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Kode Java berikut menunjukkan cara menentukan bahwa kotak teks harus selalu mempertahankan dimensinya dalam presentasi PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluap keluar.

## **Kecilkan Teks Pada Overflow**

Jika teks menjadi terlalu panjang untuk kotaknya, melalui opsi **Shrink text on overflow**, Anda dapat menentukan bahwa ukuran dan spasi teks harus dikurangi agar muat dalam kotak tersebut. Untuk menentukan pengaturan ini, atur properti [AutofitType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat)) menjadi `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Kode Java berikut menunjukkan cara menentukan bahwa teks harus diperkecil saat overflow dalam presentasi PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Ketika opsi **Shrink text on overflow** digunakan, pengaturan hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya.
{{% /alert %}}

## **Bungkus Teks**

Jika Anda ingin teks dalam sebuah bentuk dibungkus di dalam bentuk tersebut ketika teks melampaui batas bentuk (hanya lebar), Anda harus menggunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, Anda harus mengatur properti [WrapText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextFrameFormat)) menjadi `true`.

Kode Java berikut menunjukkan cara menggunakan pengaturan Wrap Text dalam presentasi PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}}
Jika Anda mengatur properti `WrapText` menjadi `False` untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang dari lebar bentuk, teks akan meluas di luar batas bentuk dalam satu baris.
{{% /alert %}}

## **FAQ**

**Apakah margin internal pada text frame memengaruhi AutoFit?**

Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan aktif lebih awal—mengecilkan font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum mengatur AutoFit.

**Bagaimana AutoFit berinteraksi dengan jeda baris manual dan soft?**

Break paksa tetap ada, dan AutoFit menyesuaikan ukuran font serta spasi di sekitarnya. Menghapus break yang tidak diperlukan sering mengurangi tingkat penekanan AutoFit pada teks.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**

Ya. Mengganti ke font dengan metrik glif yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran font akhir dan pembungkus baris. Setelah perubahan atau substitusi font apa pun, periksa kembali slide.