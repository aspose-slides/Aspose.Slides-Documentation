---
title: Menambahkan Watermark ke Presentasi dalam Java
linktitle: Watermark
type: docs
weight: 40
url: /id/java/watermark/
keywords:
- tanda air
- tanda air teks
- tanda air gambar
- menambah tanda air
- mengubah tanda air
- menghapus tanda air
- menghapus tanda air
- menambah tanda air ke PPT
- menambah tanda air ke PPTX
- menambah tanda air ke ODP
- menghapus tanda air dari PPT
- menghapus tanda air dari PPTX
- menghapus tanda air dari ODP
- menghapus tanda air dari PPT
- menghapus tanda air dari PPTX
- menghapus tanda air dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kelola tanda air teks dan gambar dalam presentasi PowerPoint dan OpenDocument menggunakan Java untuk menunjukkan draf, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam sebuah presentasi adalah cap teks atau gambar yang digunakan pada satu slide atau di seluruh slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut adalah draf (misalnya watermark “Draft”), berisi informasi rahasia (misalnya watermark “Confidential”), untuk menyebutkan perusahaan mana yang memilikinya (misalnya watermark “Nama Perusahaan”), untuk mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menandakan bahwa presentasi tidak boleh disalin. Watermark digunakan dalam format presentasi PowerPoint dan OpenOffice. Dalam Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/java/), ada berbagai cara untuk membuat watermark di dokumen PowerPoint atau OpenOffice dan memodifikasi desain serta perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/), memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/).

Ada dua cara watermark dapat diterapkan: pada satu slide atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide — watermark ditambahkan ke Slide Master, sepenuhnya didesain di sana, dan diterapkan ke semua slide tanpa memengaruhi izin mengedit watermark pada slide individual.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsionalitas penguncian shape. Sebuah shape tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat memberi nama pada watermark sehingga di masa mendatang, bila ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat mendesain watermark dengan cara apa pun; namun biasanya terdapat fitur umum pada watermark, seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan fitur-fitur tersebut dalam contoh di bawah.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks dalam PPT, PPTX, atau ODP, pertama‑tama tambahkan sebuah shape ke slide, kemudian tambahkan sebuah text frame ke shape tersebut. Text frame diwakili oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/). Tipe ini tidak diwarisi dari [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [addTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) seperti ditunjukkan di bawah.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Lihat Juga" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/java/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Seluruh Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/). Logika selanjutnya sama seperti saat menambahkan watermark ke satu slide — buat objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) dan kemudian tambahkan watermark ke dalamnya menggunakan metode [addTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Lihat Juga" %}} 
- [Cara Menggunakan Slide Master](/slides/id/java/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isian dan garis. Baris kode berikut membuat shape menjadi transparan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Mengatur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti ditunjukkan di bawah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Mengatur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Menengahkan Watermark Teks**

Watermark dapat ditempatkan di tengah slide, dan untuk itu Anda dapat melakukan hal berikut:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Gambar di bawah menunjukkan hasil akhir.

![The text watermark](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, Anda dapat melakukan hal berikut:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Mengunci Watermark agar Tidak Diedit**

Jika perlu mencegah watermark diedit, gunakan metode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, perubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teksnya dari pengeditan, dan banyak lagi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Kunci shape watermark agar tidak dapat diubah
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z shape dapat diatur melalui metode [IShapeCollection.reorder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutnya ke metode tersebut. Dengan cara ini, shape dapat dibawa ke depan atau dikirim ke belakang slide. Fitur ini sangat berguna bila Anda perlu menempatkan watermark di depan presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Mengatur Rotasi Watermark**

Berikut contoh kode cara mengatur rotasi watermark sehingga posisinya miring menyeberangi slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Memberi Nama pada Watermark**

Aspose.Slides memungkinkan Anda memberi nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk memberi nama pada shape watermark, tetapkan ke metode [IAutoShape.setName](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan metode [IAutoShape.getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getName--) untuk menemukannya di shape slide. Kemudian, berikan shape watermark ke metode [IShapeCollection.remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Apa itu watermark dan mengapa saya harus menggunakannya?

Watermark adalah overlay teks atau gambar yang diterapkan pada slide untuk melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah atas presentasi.

### Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatis ke setiap slide dalam sebuah presentasi. Anda dapat melakukan iterasi melalui semua slide dan menerapkan pengaturan watermark masing‑masing.

### Bagaimana cara menyesuaikan transparansi watermark?

Anda dapat menyesuaikan transparansi watermark dengan mengubah pengaturan isian ([getFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getFillFormat--)) pada shape. Hal ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

### Format gambar apa yang didukung untuk watermark?

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

### Bisakah saya menyesuaikan font dan gaya watermark teks?

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun agar sesuai dengan desain presentasi Anda dan menjaga konsistensi merek.

### Bagaimana cara mengubah posisi atau orientasi watermark?

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatis dengan mengubah koordinat, ukuran, dan properti rotasi shape.