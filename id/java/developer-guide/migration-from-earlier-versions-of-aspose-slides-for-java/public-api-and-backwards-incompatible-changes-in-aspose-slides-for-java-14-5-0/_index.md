---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk Java 14.5.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memudahkan migrasi solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang **ditambahkan**, semua **pembatasan** baru, serta **perubahan** lain yang diperkenalkan pada API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Classes and Methods**
#### **Added the Aspose.Slides.IPresentationInfo interface and PresentationInfo Classes**
Mewakili informasi tentang presentasi.

Method Boolean isEncrypted() mengembalikan True jika presentasi dienkripsi, jika tidak mengembalikan False.

Method LoadFormat getLoadFormat() mengembalikan tipe presentasi.
#### **Added the Aspose.Slides.IShape.isGrouped() Method**
Metode Aspose.Slides.IShape.isGrouped() menentukan apakah shape dikelompokkan.
#### **Added the Aspose.Slides.IShape.getParentGroup() Method**
Metode Aspose.Slides.IShape.getParentGroup() mengembalikan objek GroupShape induk jika shape dikelompokkan. Jika tidak, mengembalikan null.
#### **Added the Aspose.Slides.IShapeCollection.addGroupShape() Method**
Metode Aspose.Slides.IShapeCollection.addGroupShape() membuat GroupShape baru dan menambahkannya ke akhir koleksi.

Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten saat shape baru ditambahkan ke dalam GroupShape.
#### **Added the Aspose.Slides.IShapeCollection.clear() Method**
Metode Aspose.Slides.IShapeCollection.clear() menghapus semua shape dari koleksi.
#### **Added Aspose.Slides.IShapeCollection.insertGroupShape(int) Method**
Metode Aspose.Slides.IShapeCollection.insertGroupShape(int) membuat GroupShape baru dan menyisipkannya ke dalam koleksi pada indeks yang ditentukan.
Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten saat shape baru ditambahkan ke dalam GroupShape.
#### **Added the IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) Methods**
Metode‑metode ini memungkinkan pengembang memperoleh informasi tentang file/stream presentasi tanpa memuat seluruh presentasi.
#### **Added the IPresentationFactory PresentationFactory.getInstance() Method**
Memungkinkan penggunaan fungsi pabrik tanpa harus menginstansiasi.
### **Restrictions**
#### **Restrictions had been added for using undefined values for IShape.getFrame()**
Kode yang mencoba menetapkan bingkai tak terdefinisi ke IShape.setFrame(IShapeFrame) tidak masuk akal dalam kasus umum (khususnya ketika GroupShape induk berlapis‑lapis di dalam {{GroupShape}} lain). Contoh:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

atau

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Kode semacam itu dapat menyebabkan situasi yang tidak jelas. Oleh karena itu, pembatasan telah ditambahkan untuk penggunaan nilai tak terdefinisi pada IShape.Frame. Nilai x, y, width, height, flipH, flipV, dan rotationAngle harus didefinisikan (bukan Float.NaN atau NullableBool.NotDefined). Kode contoh di atas kini melempar pengecualian ArgumentException.
Hal ini berlaku untuk kasus penggunaan berikut:

``` java

 IShape shape = ...;

shape.setFrame(...); // tidak boleh tidak terdefinisi

IShapeCollection shapes = ...;

// parameter x, y, lebar, tinggi tidak boleh Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Namun bingkai IShape.getRawFrame() dapat tak terdefinisi. Hal ini masuk akal ketika sebuah shape terhubung ke placeholder. Nilai bingkai shape yang tidak terdefinisi akan ditimpa oleh nilai dari placeholder induk. Jika tidak ada placeholder induk, nilai default akan digunakan saat frame efektif dievaluasi berdasarkan IShape.getRawFrame(). Nilai default adalah 0 dan NullableBool.False untuk x, y, width, height, flipH, flipV, dan rotationAngle. Contoh:

``` java

 IShape shape = ...; // shape terhubung ke placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// sekarang shape mewarisi nilai x, y, height, flipH, flipV dari placeholder dan mengganti width=100 serta rotationAngle=0.

```
### **Changed Properties**
#### **Changed the Type and Name of the Aspose.Slides.IShapeCollection.getParent() Method**
Tipe properti Aspose.Slides.IShapeCollection.Parent telah diubah dari ISlideComponent menjadi antarmuka IGroupShape yang baru. Antarmuka IGroupShape merupakan turunan dari ISlideComponent sehingga kode yang ada tidak memerlukan penyesuaian.

Nama metode Aspose.Slides.IShapeCollection.getParent() telah diubah dari getParent menjadi getParentGroup().
#### **Change the Type of the Aspose.Slides.IShapeFrame.getFlipH() and .getFlipV() Methods**
Tipe metode Aspose.Slides.IShapeFrame.getFlipH() telah diubah dari bool menjadi NullableBool.

Metode IShape.getFrame() mengembalikan instance efektif IShapeFrame (semua propertinya memiliki nilai efektif yang terdefinisi).

Metode IShape.getRawFrame() mengembalikan instance IShapeFrame di mana setiap properti dapat memiliki nilai yang tidak terdefinisi (khususnya FlipH atau FlipV dapat bernilai NullableBool.NotDefined).