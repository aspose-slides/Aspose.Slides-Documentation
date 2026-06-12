---
title: Tingkatkan Presentasi Anda dengan AutoFit di JavaScript
linktitle: Pengaturan Autofit
type: docs
weight: 30
url: /id/nodejs-java/manage-autofit-settings/
keywords:
- kotak teks
- autofit
- jangan autofit
- sesuaikan teks
- perkecil teks
- bungkus teks
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola pengaturan AutoFit di Aspose.Slides untuk Node.js guna mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument Anda serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, ketika Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fix text** untuk kotak teks—secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu muat di dalamnya. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—meningkatkan tinggi—untuk memungkinkan menampung lebih banyak teks. 
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis memperkecil kotak teks—mengurangi tinggi—untuk menghilangkan ruang yang tidak terpakai. 

Di PowerPoint, terdapat 4 parameter atau opsi penting yang mengontrol perilaku autofit untuk sebuah kotak teks: 

* **Jangan Autofit**
* **Perkecil teks pada kelebihan**
* **Ubah ukuran bentuk agar sesuai teks**
* **Bungkus teks dalam bentuk.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java menyediakan opsi serupa—beberapa properti di bawah kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat)—yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi.

## **Ubah Ukuran Bentuk agar Sesuai Teks**

Jika Anda menginginkan teks dalam kotak selalu muat setelah perubahan teks, gunakan opsi **Resize shape to fix text**. Untuk menentukan pengaturan ini, panggil metode [setAutofitType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) dengan nilai `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Contoh kode JavaScript berikut menunjukkan cara menentukan bahwa teks harus selalu muat dalam kotaknya pada presentasi PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan otomatis diubah ukurannya (tinggi bertambah) supaya semua teks muat. Jika teks menjadi lebih pendek, sebaliknya.

## **Jangan Autofit**

Jika Anda ingin sebuah kotak teks atau bentuk mempertahankan dimensinya terlepas dari perubahan teks di dalamnya, gunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, panggil metode [setAutofitType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) dengan nilai `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Contoh kode JavaScript berikut menunjukkan cara menentukan bahwa kotak teks harus selalu mempertahankan dimensinya pada presentasi PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluber keluar.

## **Perkecil Teks pada Kelebihan**

Jika teks menjadi terlalu panjang untuk kotaknya, dengan opsi **Shrink text on overflow** Anda dapat menentukan bahwa ukuran dan spasi teks harus diperkecil agar muat dalam kotaknya. Untuk menentukan pengaturan ini, panggil metode [setAutofitType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) dengan nilai `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Contoh kode JavaScript berikut menunjukkan cara menentukan bahwa teks harus diperkecil saat kelebihan pada presentasi PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Saat opsi **Shrink text on overflow** digunakan, pengaturan hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya. 
{{% /alert %}}

## **Bungkus Teks**

Jika Anda menginginkan teks dalam sebuah bentuk dibungkus di dalam bentuk tersebut ketika teks melampaui batas lebar bentuk, gunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, panggil metode [setWrapText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) dengan nilai `true`.

Contoh kode JavaScript berikut menunjukkan cara menggunakan pengaturan Wrap Text pada presentasi PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Jika Anda memanggil metode `setWrapText` dengan nilai `False` untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang daripada lebar bentuk, teks akan meluas di luar batas bentuk dalam satu baris tunggal. 
{{% /alert %}}

## **FAQ**

**Apakah margin internal frame teks memengaruhi AutoFit?**  
Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan diterapkan lebih awal—mengecilkan font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum menyetel AutoFit.

**Bagaimana AutoFit berinteraksi dengan jeda baris manual dan soft line break?**  
Jeda paksa tetap dipertahankan, dan AutoFit menyesuaikan ukuran font serta spasi di sekitarnya. Menghapus jeda yang tidak diperlukan sering mengurangi agresivitas AutoFit dalam memangkas teks.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**  
Ya. Mengganti ke font dengan metrik glif yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran akhir font dan pembungkus baris. Setelah melakukan perubahan atau substitusi font, periksa kembali slide.