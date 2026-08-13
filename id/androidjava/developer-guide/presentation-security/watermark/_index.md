---
title: Tambahkan Watermark ke Presentasi di Android
linktitle: Watermark
type: docs
weight: 40
url: /id/androidjava/watermark/
keywords:
- watermark
- watermark teks
- watermark gambar
- tambahkan watermark
- ubah watermark
- hapus watermark
- hapus watermark
- tambahkan watermark ke PPT
- tambahkan watermark ke PPTX
- tambahkan watermark ke ODP
- hapus watermark dari PPT
- hapus watermark dari PPTX
- hapus watermark dari ODP
- hapus watermark dari PPT
- hapus watermark dari PPTX
- hapus watermark dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola watermark teks dan gambar dalam presentasi PowerPoint dan OpenDocument di Android dengan Java untuk menunjukkan draf, informasi rahasia, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam sebuah presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau pada semua slide presentasi. Biasanya watermark digunakan untuk menunjukkan bahwa presentasi masih berupa draf (misalnya watermark “Draft”), berisi informasi rahasia (misalnya watermark “Confidential”), menandakan perusahaan pemiliknya (misalnya watermark “Nama Perusahaan”), mengidentifikasi penulis presentasi, dan sebagainya. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark dapat digunakan pada format presentasi PowerPoint maupun OpenOffice. Pada Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/android-java/), terdapat berbagai cara untuk membuat watermark di dokumen PowerPoint atau OpenOffice serta memodifikasi desain dan perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/) atau mengisi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), sehingga Anda dapat menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/).

Ada dua cara watermark dapat diterapkan: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide presentasi — watermark ditambahkan ke Slide Master, didesain sepenuhnya di sana, dan diterapkan ke semua slide tanpa memengaruhi izin mengubah watermark pada slide individual.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide normal atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat memberi nama pada watermark sehingga di masa mendatang, bila ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat mendesain watermark dengan cara apa saja; namun biasanya ada fitur umum pada watermark, seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan fitur-fitur tersebut dalam contoh di bawah.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks pada PPT, PPTX, atau ODP, Anda dapat terlebih dahulu menambahkan shape ke slide, lalu menambahkan text frame ke shape tersebut. Text frame direpresentasikan oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/). Tipe ini tidak diturunkan dari [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [addTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) seperti contoh di bawah.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/androidjava/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/masterslide/). Logika selanjutnya sama seperti saat menambahkan watermark ke satu slide — buat objek [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) lalu tambahkan watermark ke dalamnya menggunakan metode [addTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [Cara Menggunakan Slide Master](/slides/id/androidjava/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isi dan garis. Baris kode berikut membuat shape menjadi transparan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Mengatur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti contoh di bawah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Mengatur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Menengahkan Watermark Teks**

Anda dapat menengahkan watermark pada slide dengan melakukan hal berikut:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Gambar di bawah memperlihatkan hasil akhir.

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, lakukan hal berikut:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Mengunci Watermark agar Tidak Diedit**

Jika perlu mencegah watermark diedit, gunakan metode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, pengubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teksnya dari pengeditan, dan banyak lagi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Kunci shape watermark agar tidak dapat dimodifikasi
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z shape dapat diatur melalui metode [IShapeCollection.reorder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutannya. Dengan cara ini, Anda dapat membawa shape ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna bila Anda perlu menempatkan watermark di depan presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Mengatur Rotasi Watermark**

Berikut contoh kode untuk menyesuaikan rotasi watermark sehingga posisinya diagonal melintasi slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Menetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada shape watermark, beri nilai pada metode [IAutoShape.setName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan metode [IAutoShape.getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) untuk menemukannya di shape slide. Kemudian, berikan shape watermark ke metode [IShapeCollection.remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Apa itu watermark dan mengapa saya harus menggunakannya?

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide untuk melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah atas presentasi.

### Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatik ke setiap slide dalam sebuah presentasi. Anda dapat melakukan iterasi pada semua slide dan menerapkan pengaturan watermark satu per satu.

### Bagaimana cara menyesuaikan transparansi watermark?

Anda dapat menyesuaikan transparansi watermark dengan memodifikasi pengaturan isi ([getFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getFillFormat--)) pada shape. Hal ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

### Format gambar apa yang didukung untuk watermark?

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

### Bisakah saya menyesuaikan font dan gaya watermark teks?

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk mencocokkan desain presentasi Anda serta menjaga konsistensi merek.

### Bagaimana cara mengubah posisi atau orientasi watermark?

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan memodifikasi koordinat, ukuran, dan properti rotasi pada shape.