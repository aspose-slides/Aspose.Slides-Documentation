---
title: Menambahkan Watermark ke Presentasi dengan JavaScript
linktitle: Watermark
type: docs
weight: 40
url: /id/nodejs-java/watermark/
keywords:
- watermark
- tanda air teks
- tanda air gambar
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola tanda air teks dan gambar dalam presentasi PowerPoint dan OpenDocument di Node.js untuk menunjukkan draf, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam sebuah presentasi adalah cap teks atau gambar yang digunakan pada satu slide atau pada seluruh slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut merupakan draf (misalnya watermark "Draft"), berisi informasi rahasia (misalnya watermark "Confidential"), menunjukkan perusahaan mana yang memilikinya (misalnya watermark "Company Name"), mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menandakan bahwa presentasi tidak boleh disalin. Watermark digunakan pada format presentasi PowerPoint dan OpenOffice. Di Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/nodejs-java/), terdapat berbagai cara untuk membuat watermark dalam dokumen PowerPoint atau OpenOffice serta memodifikasi desain dan perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan tipe [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) atau isi shape watermark dengan gambar. `PictureFrame` mengimplementasikan tipe [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/), memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek shape. Karena `TextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/).

Ada dua cara penerapan watermark: pada satu slide atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark pada semua slide — watermark ditambahkan ke Slide Master, didesain sepenuhnya di sana, dan diterapkan ke semua slide tanpa memengaruhi izin mengubah watermark pada slide individu.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide normal atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa mendatang, bila ingin menghapusnya, Anda dapat menemukannya di shape slide dengan nama tersebut.

Anda dapat mendesain watermark dengan cara apa pun; namun biasanya ada fitur umum pada watermark, seperti perataan tengah, rotasi, posisi depan, dll. Kami akan menunjukkan cara menggunakan fitur-fitur tersebut pada contoh di bawah.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**
Untuk menambahkan watermark teks pada PPT, PPTX, atau ODP, Anda dapat pertama‑tama menambahkan shape ke slide, lalu menambahkan text frame ke shape tersebut. Text frame direpresentasikan oleh tipe [**TextFrame**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame). Tipe ini tidak diturunkan dari [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape), yang memiliki serangkaian properti luas untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame) dibungkus dalam objek [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape). Untuk menambahkan teks watermark ke shape, gunakan metode [**addTextFrame**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) dengan teks watermark sebagai argumen:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- Cara menggunakan [TextFrame](/slides/id/nodejs-java/text-formatting/).
{{% /alert %}}

### **Menambahkan Watermark Teks ke Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [**MasterSlide**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterSlide). Logika selanjutnya sama seperti saat menambahkan watermark ke satu slide — buat objek [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) lalu tambahkan watermark menggunakan metode [**addTextFrame**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [Cara menggunakan ](/slides/id/nodejs-java/slide-master/)[Slide Master](/slides/id/nodejs-java/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Shape Watermark**

Secara default, shape persegi panjang memiliki warna isi dan garis. Baris kode berikut membuat shape menjadi transparan.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Mengatur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti pada contoh di bawah.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Mengatur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Watermark Teks Berpusat**
Anda dapat memusatkan watermark pada slide dengan melakukan hal berikut:



```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Gambar di bawah ini menunjukkan hasil akhir.

![Tanda air teks](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke semua slide presentasi, Anda dapat melakukan hal berikut:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Mengunci Watermark agar Tidak Diedit**

Jika perlu mencegah watermark diedit, gunakan metode [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape#getShapeLock--) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, pengubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teks dari pengeditan, dan lain‑lain:

```javascript
// Kunci shape watermark dari modifikasi
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z‑shape dapat diatur melalui metode [**SlideCollection.reorder**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutannya. Dengan cara ini, Anda dapat membawa shape ke depan atau mengirimnya ke belakang slide. Fitur ini berguna bila Anda perlu menempatkan watermark di depan presentasi:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Mengatur Rotasi Watermark**

Berikut contoh kode untuk mengatur rotasi watermark sehingga terletak diagonal di seluruh slide:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Menetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda memberi nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama shape watermark, panggil metode [**AutoShape.getName**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan metode [AutoShape.getName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getName--) untuk menemukannya di shape slide. Kemudian, berikan shape watermark ke metode [**ShapeCollection.remove**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Apa itu watermark dan mengapa saya harus menggunakannya?**

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide untuk melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah pada presentasi.

**Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark ke setiap slide dalam sebuah presentasi. Anda dapat mengulangi semua slide dan menerapkan pengaturan watermark secara individu.

**Bagaimana cara mengatur transparansi watermark?**

Anda dapat mengatur transparansi watermark dengan memodifikasi [pengaturan isi](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getfillformat/) shape. Hal ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

**Format gambar apa yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Bisakah saya menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa saja untuk menyesuaikan desain presentasi Anda dan menjaga konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark dengan memodifikasi koordinat, ukuran, dan properti rotasi shape.