---
title: Menambahkan Watermark ke Presentasi dalam Java
linktitle: Tanda Air
type: docs
weight: 40
url: /id/java/watermark/
keywords:
- tanda air
- tanda air teks
- tanda air gambar
- menambahkan tanda air
- mengubah tanda air
- menghapus tanda air
- menghapus tanda air
- menambahkan tanda air ke PPT
- menambahkan tanda air ke PPTX
- menambahkan tanda air ke ODP
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
description: "Kelola watermark teks dan gambar pada presentasi PowerPoint dan OpenDocument di Java untuk menunjukkan draft, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau pada seluruh slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut masih draft (misalnya watermark “Draft”), mengandung informasi rahasia (misalnya watermark “Confidential”), menyatakan perusahaan mana yang memilikinya (misalnya watermark “Nama Perusahaan”), mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan baik dalam format presentasi PowerPoint maupun OpenOffice. Di Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/java/), ada berbagai cara untuk membuat watermark dalam dokumen PowerPoint atau OpenOffice dan memodifikasi desain serta perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/), memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/).

Ada dua cara watermark dapat diterapkan: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide — watermark ditambahkan ke Slide Master, sepenuhnya dirancang di sana, dan diterapkan ke semua slide tanpa memengaruhi izin untuk mengubah watermark pada slide individual.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide normal atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa mendatang, jika ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa pun; namun biasanya terdapat fitur umum pada watermark, seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan fitur-fitur tersebut dalam contoh di bawah.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks pada PPT, PPTX, atau ODP, Anda dapat terlebih dahulu menambahkan shape ke slide, lalu menambahkan text frame ke shape tersebut. Text frame diwakili oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/). Tipe ini tidak diwarisi dari [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [addTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) seperti di bawah ini.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/id/java/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/). Logika selanjutnya sama seperti saat menambahkan watermark ke satu slide — buat objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) lalu tambahkan watermark ke dalamnya menggunakan metode [addTextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/id/java/slide-master/)
{{% /alert %}}

### **Menetapkan Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isi dan garis. Baris kode berikut membuat shape menjadi transparan.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Menetapkan Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti di bawah ini.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Menetapkan Warna Teks Watermark**

Untuk menetapkan warna teks watermark, gunakan kode berikut:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Menengahkan Watermark Teks**

Anda dapat menengahkan watermark pada slide dengan cara berikut:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Gambar di bawah menunjukkan hasil akhir.

![The text watermark](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, Anda dapat melakukan hal berikut:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Mengunci Watermark agar Tidak Diedit**

Jika perlu mencegah watermark diedit, gunakan metode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, perubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teks dari pengeditan, dan banyak lagi:

```java
// Kunci shape watermark agar tidak dapat diubah
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z shape dapat diatur melalui metode [IShapeCollection.reorder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutannya. Dengan cara ini, shape dapat dibawa ke depan atau dikirim ke belakang slide. Fitur ini sangat berguna bila Anda perlu menempatkan watermark di depan presentasi:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Menetapkan Rotasi Watermark**

Berikut contoh kode untuk menyesuaikan rotasi watermark sehingga posisinya miring melintasi slide:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Menetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama shape watermark, panggil metode [IAutoShape.setName](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan metode [IAutoShape.getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getName--) untuk menemukannya di shape slide. Kemudian, berikan shape watermark ke metode [IShapeCollection.remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Apa itu watermark dan mengapa harus menggunakannya?**

Watermark adalah overlay teks atau gambar yang diterapkan pada slide untuk melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah dari presentasi.

**Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatik ke setiap slide dalam sebuah presentasi. Anda dapat melakukan iterasi pada semua slide dan menerapkan pengaturan watermark secara individual.

**Bagaimana cara mengatur transparansi watermark?**

Anda dapat mengatur transparansi watermark dengan memodifikasi pengaturan isi ([getFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getFillFormat--)) pada shape. Hal ini memastikan watermark terasa halus dan tidak mengganggu konten slide.

**Format gambar apa yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Bisakah saya menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk menyesuaikan desain presentasi Anda dan menjaga konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan memodifikasi koordinat, ukuran, dan properti rotasi pada shape.