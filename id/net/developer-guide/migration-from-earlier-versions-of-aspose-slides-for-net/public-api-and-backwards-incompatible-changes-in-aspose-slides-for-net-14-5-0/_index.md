---
title: API Publik dan Perubahan yang Tidak Kompatibel Mundur pada Aspose.Slides untuk .NET 14.5.0
linktitle: Aspose.Slides untuk .NET 14.5.0
type: docs
weight: 70
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang merusak pada Aspose.Slides untuk .NET guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) kelas, metode, properti, dan sebagainya, serta [pembatasan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) dan [perubahan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) lain yang diperkenalkan dengan Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **API Publik dan Perubahan yang Tidak Kompatibel Mundur**
### **Antarmuka, Kelas, Properti, dan Metode yang Ditambahkan**
#### **Ditambahkan Antarmuka Aspose.Slides.IPresentationInfo dan Kelas PresentationInfo**
Mewakili informasi tentang presentasi.

- Properti Boolean IsEncrypted mengembalikan True jika presentasi dienkripsi, selainnya mengembalikan False.
- Properti LoadFormat LoadFormat mengembalikan tipe presentasi.
#### **Ditambahkan Properti Aspose.Slides.IShape.IsGrouped**
Properti Aspose.Slides.IShape.IsGrouped menentukan apakah sebuah shape dikelompokkan.
#### **Ditambahkan Properti Aspose.Slides.IShape.ParentGroup**
Properti Aspose.Slides.IShape.ParentGroup mengembalikan objek GroupShape induk jika sebuah shape dikelompokkan. Jika tidak, mengembalikan null.
#### **Ditambahkan Metode Aspose.Slides.IShapeCollection.AddGroupShape()**
Metode Aspose.Slides.IShapeCollection.AddGroupShape() membuat GroupShape baru dan menambahkannya ke akhir koleksi.
Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten ketika shape baru ditambahkan.
#### **Ditambahkan Metode Aspose.Slides.IShapeCollection.Clear()**
Metode Aspose.Slides.IShapeCollection.Clear() menghapus semua shape dari koleksi.
#### **Ditambahkan Metode Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metode Aspose.Slides.IShapeCollection.InsertGroupShape(int) membuat GroupShape baru dan menyisipkannya ke dalam koleksi pada posisi indeks yang ditentukan.
Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten ketika shape baru ditambahkan.
#### **Ditambahkan Metode IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream)**
Metode ini memungkinkan memperoleh informasi tentang file atau aliran presentasi tanpa memuat seluruh presentasi.
#### **Ditambahkan Properti IPresentationFactory PresentationFactory.Instance**
Properti ini memungkinkan pengembang menggunakan fungsionalitas pabrik tanpa membuat instance.
### **Pembatasan**
#### **Pembatasan pada IShape.Frame**
Pembatasan telah ditambahkan untuk penggunaan nilai tak terdefinisi pada IShape.Frame. Kode yang berusaha menetapkan bingkai tak terdefinisi ke IShape.Frame biasanya tidak masuk akal (terutama ketika GroupShape induk berlapis beberapa kali ke dalam {{GroupShape}} lain). Misalnya:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Membuang ArgumentException: nilai frame harus didefinisikan.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

atau

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Membuang ArgumentException: x, y, lebar, dan tinggi harus didefinisikan.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Kode semacam itu dapat menyebabkan situasi yang tidak jelas. Jadi pembatasan telah ditambahkan untuk penggunaan nilai tak terdefinisi pada IShape.Frame. Nilai x, y, width, height, flipH, flipV, dan rotationAngle harus didefinisikan (dan tidak boleh diatur ke float.NaN atau NullableBool.NotDefined). Kode contoh di atas kini melemparkan pengecualian ArgumentException.
Ini berlaku untuk kasus penggunaan berikut:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Parameter x, y, lebar, dan tinggi tidak boleh float.NaN, dan flipH, flipV
// tidak boleh NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Pembatasan yang sama berlaku untuk setiap metode yang membuat shape:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Namun properti frame IShape.RawFrame dapat tak terdefinisi. Hal ini masuk akal ketika sebuah shape terhubung ke placeholder. Maka nilai bingkai shape yang tak terdefinisi akan diganti oleh nilai dari placeholder shape induk. Jika tidak ada placeholder induk, shape tersebut menggunakan nilai default saat mengevaluasi bingkai efektif berdasarkan IShape.RawFrame. Nilai default adalah 0 dan NullableBool.False untuk x, y, width, height, flipH, flipV, dan rotationAngle. Misalnya:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Shape terhubung ke placeholder
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // sekarang shape mewarisi nilai x, y, height, flipH, flipV dari placeholder dan menimpa width=100 serta rotationAngle=0.
}
``` 
### **Properti yang Diubah**
#### **Diubah Nama dan Tipe Properti Aspose.Slides.IShapeCollection.Parent**
- Tipe properti Aspose.Slides.IShapeCollection.Parent telah diubah dari ISlideComponent menjadi antarmuka IGroupShape yang baru. Antarmuka IGroupShape merupakan turunan dari ISlideComponent sehingga kode yang ada tidak memerlukan adaptasi.
- Nama properti Aspose.Slides.IShapeCollection.Parent telah diubah dari Parent menjadi ParentGroup.
#### **Diubah Tipe Properti Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Tipe properti Aspose.Slides.IShapeFrame.FlipH telah diubah dari bool menjadi NullableBool.
- Properti IShape.Frame mengembalikan instance efektif IShapeFrame (semua propertinya memiliki nilai efektif yang terdefinisi).
- Properti IShape.RawFrame mengembalikan instance IShapeFrame yang tiap propertinya dapat memiliki nilai tak terdefinisi (khususnya FlipH atau FlipV dapat bernilai NullableBool.NotDefined).