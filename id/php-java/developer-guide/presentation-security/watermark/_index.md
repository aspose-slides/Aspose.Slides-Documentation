---
title: Menambahkan Watermark ke Presentasi dalam PHP
linktitle: Watermark
type: docs
weight: 40
url: /id/php-java/watermark/
keywords:
- tanda air
- tanda air teks
- tanda air gambar
- tambahkan tanda air
- ubah tanda air
- hapus tanda air
- hapus tanda air
- tambahkan tanda air ke PPT
- tambahkan tanda air ke PPTX
- tambahkan tanda air ke ODP
- hapus tanda air dari PPT
- hapus tanda air dari PPTX
- hapus tanda air dari ODP
- hapus tanda air dari PPT
- hapus tanda air dari PPTX
- hapus tanda air dari ODP
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola tanda air teks dan gambar pada presentasi PowerPoint dan OpenDocument dengan PHP untuk menunjukkan draf, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam sebuah presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau pada semua slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut merupakan draf (misalnya watermark "Draft"), berisi informasi rahasia (misalnya watermark "Confidential"), menyatakan perusahaan mana yang memiliki presentasi (misalnya watermark "Company Name"), mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan pada format presentasi PowerPoint maupun OpenOffice. Pada Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/php-java/), terdapat berbagai cara untuk membuat watermark pada dokumen PowerPoint atau OpenOffice serta mengubah desain dan perilakunya. Kesamaan utama adalah untuk menambahkan watermark teks, gunakan kelas [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/), sehingga Anda dapat menggunakan semua pengaturan fleksibel dari objek shape. Karena `ITextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/).

Ada dua cara watermark dapat diterapkan: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide — watermark ditambahkan ke Slide Master, sepenuhnya dirancang di sana, dan diterapkan ke semua slide tanpa memengaruhi izin mengubah watermark pada slide individu.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa mendatang, bila ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa pun; namun biasanya ada fitur umum pada watermark, seperti perataan tengah, rotasi, posisi di depan, dll. Kami akan menunjukkan cara menggunakan fitur tersebut dalam contoh di bawah ini.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks pada PPT, PPTX, atau ODP, pertama‑tama tambahkan sebuah shape ke slide, kemudian tambahkan teks frame ke shape tersebut. Teks frame direpresentasikan oleh kelas [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/). Tipe ini tidak mewarisi dari [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/), yang memiliki banyak properti untuk menempatkan watermark secara fleksibel. Oleh karena itu, objek [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) dibungkus dalam objek [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [addTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#addTextFrame) seperti contoh di bawah.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/php-java/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Seluruh Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/). Logika selanjutnya sama seperti menambahkan watermark ke slide tunggal — buat objek [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) kemudian tambahkan watermark ke dalamnya menggunakan metode [addTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Lihat juga" %}} 
- [Cara Menggunakan Slide Master](/slides/id/php-java/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Shape Watermark**

Secara bawaan, shape persegi panjang memiliki warna isi dan garis. Baris kode berikut membuat shape menjadi transparan.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Mengatur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti contoh di bawah.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Mengatur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Menempatkan Watermark Teks di Tengah**

Anda dapat menempatkan watermark di tengah slide dengan cara berikut:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Gambar di bawah menunjukkan hasil akhir.

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, lakukan hal berikut:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Mengunci Watermark agar Tidak Diedit**

Jika perlu mencegah watermark diedit, gunakan metode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#getAutoShapeLock) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, perubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teksnya dari pengeditan, dan lain‑lain:

```php
// Kunci shape watermark dari modifikasi
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z (Z‑order) shape dapat diatur melalui metode [ShapeCollection.reorder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#reorder). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutannya. Dengan cara ini, Anda dapat membawa sebuah shape ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna bila Anda ingin menempatkan watermark di depan presentasi:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Mengatur Rotasi Watermark**

Berikut contoh kode untuk mengatur rotasi watermark sehingga posisinya miring melintang slide:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Menetapkan Nama untuk Watermark**

Aspose.Slides memungkinkan Anda menetapkan nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada shape watermark, panggil metode [AutoShape.setName](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan metode [AutoShape.getName](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getName) untuk menemukan shape tersebut di dalam shape slide. Kemudian, berikan shape watermark tersebut ke metode [ShapeCollection.remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**Apa itu watermark dan mengapa harus menggunakannya?**

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide untuk membantu melindungi kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah atas presentasi.

**Bisakah saya menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatik ke setiap slide dalam sebuah presentasi. Anda dapat mengiterasi semua slide dan menerapkan pengaturan watermark secara terpisah.

**Bagaimana cara mengatur transparansi watermark?**

Anda dapat mengatur transparansi watermark dengan memodifikasi pengaturan isi ([getFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getfillformat/)) pada shape. Hal ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

**Format gambar apa saja yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Bisakah saya menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk menyesuaikan desain presentasi Anda dan menjaga konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan mengubah koordinat, ukuran, dan properti rotasi pada shape.