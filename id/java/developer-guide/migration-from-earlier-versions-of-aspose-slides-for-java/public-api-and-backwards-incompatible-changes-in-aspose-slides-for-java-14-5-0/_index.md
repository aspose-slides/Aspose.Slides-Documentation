---
title: API Publik dan Perubahan Tidak Kompatibel Mundur pada Aspose.Slides untuk Java 14.5.0
linktitle: Aspose.Slides untuk Java 14.5.0
type: docs
weight: 40
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah kompatibilitas di Aspose.Slides untuk Java guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) kelas, metode, properti, dan sebagainya, setiap [pembatasan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) baru, serta [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) lain yang diperkenalkan dengan API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **API Publik dan Perubahan Tidak Kompatibel Mundur**
### **Kelas dan Metode yang Ditambahkan**
#### **Menambahkan antarmuka Aspose.Slides.IPresentationInfo dan Kelas PresentationInfo**
Mewakili informasi tentang presentasi.

Metode Boolean isEncrypted() mengembalikan True jika presentasi dienkripsi, jika tidak mengembalikan False.

Metode LoadFormat getLoadFormat() mengembalikan jenis presentasi.
#### **Menambahkan Metode Aspose.Slides.IShape.isGrouped()**
Metode Aspose.Slides.IShape.isGrouped() menentukan apakah shape dikelompokkan.
#### **Menambahkan Metode Aspose.Slides.IShape.getParentGroup()**
Metode Aspose.Slides.IShape.getParentGroup() mengembalikan objek GroupShape induk jika shape dikelompokkan. Jika tidak, mengembalikan null.
#### **Menambahkan Metode Aspose.Slides.IShapeCollection.addGroupShape()**
Metode Aspose.Slides.IShapeCollection.addGroupShape() membuat GroupShape baru dan menambahkannya ke akhir koleksi.

Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten ketika shape baru ditambahkan ke dalam GroupShape.
#### **Menambahkan Metode Aspose.Slides.IShapeCollection.clear()**
Metode Aspose.Slides.IShapeCollection.clear() menghapus semua shape dari koleksi.
#### **Menambahkan Metode Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metode Aspose.Slides.IShapeCollection.insertGroupShape(int) membuat GroupShape baru dan menyisipkannya ke dalam koleksi pada indeks yang ditentukan.
Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten ketika shape baru ditambahkan ke dalam GroupShape.
#### **Menambahkan Metode IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Metode ini memungkinkan pengembang memperoleh informasi tentang file/stream presentasi tanpa memuat seluruh presentasi.
#### **Menambahkan Metode IPresentationFactory PresentationFactory.getInstance()**
Memungkinkan penggunaan fungsionalitas pabrik tanpa menginstansiasi.
### **Pembatasan**
#### **Pembatasan telah ditambahkan untuk penggunaan nilai tidak terdefinisi pada IShape.getFrame()**
Kode yang mencoba menetapkan bingkai yang tidak terdefinisi ke IShape.setFrame(IShapeFrame) tidak masuk akal dalam kasus umum (khususnya ketika GroupShape induk berlapis berulang kali ke dalam {{GroupShape}} lain). Contoh:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Melempar ArgumentException: nilai frame harus didefinisikan.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

atau

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Melempar ArgumentException: nilai x, y, lebar, dan tinggi harus didefinisikan.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Kode semacam itu dapat menyebabkan situasi yang tidak jelas. Jadi pembatasan telah ditambahkan untuk penggunaan nilai tidak terdefinisi pada IShape.Frame. Nilai x, y, lebar, tinggi, flipH, flipV, dan rotationAngle harus didefinisikan (bukan Float.NaN atau NullableBool.NotDefined). Kode contoh di atas kini melempar pengecualian ArgumentException.
Ini berlaku untuk kasus penggunaan berikut:

``` java
// Bingkai yang diteruskan ke IShape.setFrame(IShapeFrame) tidak boleh berisi nilai yang tidak terdefinisi.

// Parameter x, y, lebar, dan tinggi dari metode IShapeCollection berikut
// tidak boleh Float.NaN juga:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Namun bingkai yang dikembalikan oleh IShape.getRawFrame() dapat tidak terdefinisi. Hal ini masuk akal ketika sebuah shape terhubung ke placeholder. Nilai bingkai shape yang tidak terdefinisi kemudian digantikan oleh nilai placeholder induk. Jika tidak ada placeholder induk untuk shape tersebut, maka nilai default digunakan ketika mengevaluasi bingkai efektif berdasarkan IShape.getRawFrame(). Nilai default adalah 0 dan NullableBool.False untuk x, y, lebar, tinggi, flipH, flipV, dan rotationAngle. Contoh:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Shape terhubung ke placeholder.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Sekarang shape mewarisi nilai x, y, height, flipH dan flipV dari placeholder
    // dan mengganti lebar = 100 serta rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Properti yang Diubah**
#### **Mengubah Tipe dan Nama Metode Aspose.Slides.IShapeCollection.getParent()**
Tipe properti Aspose.Slides.IShapeCollection.Parent telah diubah dari ISlideComponent menjadi antarmuka IGroupShape yang baru. Antarmuka IGroupShape merupakan turunan dari ISlideComponent sehingga kode yang ada tidak memerlukan adaptasi.

Nama metode Aspose.Slides.IShapeCollection.getParent() telah diubah dari getParent menjadi getParentGroup().
#### **Mengubah Tipe Metode Aspose.Slides.IShapeFrame.getFlipH() dan .getFlipV()**
Tipe metode Aspose.Slides.IShapeFrame.getFlipH() telah diubah dari bool menjadi NullableBool.

Metode IShape.getFrame() mengembalikan instance IShapeFrame yang efektif (semua propertinya memiliki nilai efektif yang terdefinisi).

Metode IShape.getRawFrame() mengembalikan instance IShapeFrame yang masing‑masing propertinya dapat memiliki nilai tidak terdefinisi (khususnya FlipH atau FlipV dapat memiliki nilai NullableBool.NotDefined).