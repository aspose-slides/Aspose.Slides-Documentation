---
title: Menambahkan Watermark ke Presentasi di Android
linktitle: Watermark
type: docs
weight: 40
url: /id/androidjava/watermark/
keywords:
- tanda air
- watermark teks
- watermark gambar
- menambahkan watermark
- mengubah watermark
- menghapus watermark
- menghapus watermark
- menambahkan watermark ke PPT
- menambahkan watermark ke PPTX
- menambahkan watermark ke ODP
- menghapus watermark dari PPT
- menghapus watermark dari PPTX
- menghapus watermark dari ODP
- menghapus watermark dari PPT
- menghapus watermark dari PPTX
- menghapus watermark dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola watermark teks dan gambar dalam presentasi PowerPoint dan OpenDocument di Android dengan Java untuk menandakan draft, informasi rahasia, dan lainnya."
---
## **Pendahuluan**

**Sebuah watermark** dalam presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau di seluruh slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut masih draf (mis., watermark "Draft"), bahwa berisi informasi rahasia (mis., watermark "Confidential"), untuk menentukan perusahaan mana yang memiliki (mis., watermark "Company Name"), untuk mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan dalam format presentasi PowerPoint dan OpenOffice. Di Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/android-java/), ada berbagai cara untuk membuat watermark dalam dokumen PowerPoint atau OpenOffice dan memodifikasi desain serta perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan sebuah shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) .

Ada dua cara penerapan watermark: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide — watermark ditambahkan ke Slide Master, dirancang sepenuhnya di sana, dan diterapkan ke semua slide tanpa memengaruhi izin untuk mengubah watermark pada slide individu.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa depan, jika ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa pun; namun biasanya ada fitur umum pada watermark, seperti perataan tengah, rotasi, posisi depan, dll. Kami akan membahas cara menggunakan ini dalam contoh di bawah.

## **Watermark Teks**

### **Tambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks dalam PPT, PPTX, atau ODP, Anda dapat terlebih dahulu menambahkan shape ke slide, lalu menambahkan text frame ke shape tersebut. Text frame direpresentasikan oleh antarmuka [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/). Tipe ini tidak mewarisi dari [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dibungkus dalam objek [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [addTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) seperti ditunjukkan di bawah.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/androidjava/text-formatting/)
{{% /alert %}}

### **Tambahkan Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/masterslide/). Sisa logika sama seperti saat menambahkan watermark ke satu slide — buat objek [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) , lalu tambahkan watermark ke dalamnya menggunakan metode [addTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) .

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Slide Master](/slides/id/androidjava/slide-master/)
{{% /alert %}}

### **Set Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isi dan garis. Baris kode berikut membuat shape menjadi transparan.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Set Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti di bawah ini.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Set Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Pusatkan Watermark Teks**

Dimungkinkan untuk memusatkan watermark pada slide, dan untuk itu, Anda dapat melakukan hal berikut:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Tambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, Anda dapat melakukan hal berikut:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Kunci Watermark dari Penyuntingan**

Jika perlu mencegah watermark agar tidak dapat diedit, gunakan metode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, pengubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teksnya dari penyuntingan, dan banyak lagi:

```java
// Kunci shape watermark agar tidak dapat dimodifikasi
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Bawa Watermark ke Depan**

Di Aspose.Slides, urutan Z (Z-order) shape dapat diatur melalui metode [IShapeCollection.reorder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Untuk melakukannya, Anda harus memanggil metode ini dari daftar slide presentasi dan melewatkan referensi shape serta nomor urutnya ke metode tersebut. Dengan cara ini, memungkinkan untuk membawa shape ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna jika Anda perlu menempatkan watermark di depan presentasi:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Set Rotasi Watermark**

Berikut contoh kode cara menyesuaikan rotasi watermark sehingga ditempatkan secara diagonal melintasi slide:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Set Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama untuk sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama shape watermark, beri nilai pada metode [IAutoShape.setName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) :

```java
watermarkShape.setName("watermark");
```

### **Hapus Watermark**

Untuk menghapus shape watermark, gunakan metode [IAutoShape.getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) untuk menemukannya di shape slide. Kemudian, beri shape watermark ke metode [IShapeCollection.remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

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

**Apa itu watermark dan mengapa saya harus menggunakannya?**

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide yang membantu melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah atas presentasi.

**Apakah saya dapat menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatis ke setiap slide dalam sebuah presentasi. Anda dapat mengiterasi semua slide dan menerapkan pengaturan watermark satu per satu.

**Bagaimana saya dapat mengatur transparansi watermark?**

Anda dapat mengatur transparansi watermark dengan memodifikasi pengaturan isi ([getFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getFillFormat--)) pada shape. Ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

**Format gambar apa yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Apakah saya dapat menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk menyesuaikan desain presentasi Anda dan mempertahankan konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat mengubah posisi dan orientasi watermark secara programatis dengan memodifikasi koordinat, ukuran, dan properti rotasi shape.