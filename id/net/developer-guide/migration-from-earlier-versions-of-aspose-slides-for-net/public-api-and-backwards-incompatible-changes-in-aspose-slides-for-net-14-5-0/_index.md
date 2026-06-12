---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.5.0
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
description: "Tinjau pembaruan API publik dan perubahan yang tidak kompatibel mundur di Aspose.Slides untuk .NET guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 
Halaman ini mencantumkan semua kelas, metode, properti, dll yang [added](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ditambahkan, setiap [restrictions](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) pembatasan baru, dan [changes](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 14.5.0.
{{% /alert %}} 
## **API Publik dan Perubahan yang Tidak Kompatibel Mundur**
### **Antarmuka, Kelas, Properti, dan Metode yang Ditambahkan**
#### **Menambahkan Antarmuka Aspose.Slides.IPresentationInfo dan Kelas PresentationInfo**
Mewakili informasi tentang presentasi.

- Properti Boolean IsEncrypted mengembalikan True jika presentasi terenkripsi, jika tidak mengembalikan False.
- Properti LoadFormat mengembalikan tipe presentasi.
#### **Menambahkan Properti Aspose.Slides.IShape.IsGrouped**
Properti Aspose.Slides.IShape.IsGrouped menentukan apakah suatu bentuk dikelompokkan.
#### **Menambahkan Properti Aspose.Slides.IShape.ParentGroup**
Properti Aspose.Slides.IShape.ParentGroup mengembalikan objek GroupShape induk jika bentuk dikelompokkan. Jika tidak, mengembalikan null.
#### **Menambahkan Metode Aspose.Slides.IShapeCollection.AddGroupShape()**
Metode Aspose.Slides.IShapeCollection.AddGroupShape() membuat GroupShape baru dan menambahkannya ke akhir koleksi.
Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten saat bentuk baru ditambahkan.
#### **Menambahkan Metode Aspose.Slides.IShapeCollection.Clear()**
Metode Aspose.Slides.IShapeCollection.Clear() menghapus semua bentuk dari koleksi.
#### **Menambahkan Metode Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metode Aspose.Slides.IShapeCollection.InsertGroupShape(int) membuat GroupShape baru dan menyisipkannya ke dalam koleksi pada posisi indeks yang ditentukan.
Ukuran bingkai dan posisi GroupShape akan disesuaikan dengan konten ketika bentuk baru ditambahkan.
#### **Menambahkan Metode IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Metode ini memungkinkan mendapatkan informasi tentang file atau aliran presentasi tanpa memuat seluruh presentasi.
#### **Menambahkan Properti IPresentationFactory PresentationFactory.Instance**
Properti ini memungkinkan pengembang menggunakan fungsionalitas pabrik tanpa menginstansiasi.
### **Pembatasan**
#### **Pembatasan pada IShape.Frame**
Pembatasan telah ditambahkan untuk penggunaan nilai yang tidak terdefinisi pada IShape.Frame. Kode yang mencoba menetapkan bingkai yang tidak terdefinisi ke IShape.Frame tidak masuk akal dalam kebanyakan kasus (khususnya ketika GroupShape induk berulang kali bersarang dalam {{GroupShape}} lain). Misalnya:
``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 
atau
``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 
Kode semacam itu dapat menyebabkan situasi yang tidak jelas. Oleh karena itu, pembatasan telah ditambahkan untuk penggunaan nilai yang tidak terdefinisi pada IShape.Frame. Nilai x, y, width, height, flipH, flipV, dan rotationAngle harus terdefinisi (dan tidak diatur ke float.NaN atau NullableBool.NotDefined). Contoh kode di atas kini melemparkan pengecualian ArgumentException.
Ini berlaku untuk kasus penggunaan berikut:
``` csharp

 IShape shape = ...;

shape.Frame = ...; // Tidak boleh tidak terdefinisi

IShapeCollection shapes = ...;

// Parameter x, y, width, height tidak boleh berupa float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 
Namun properti bingkai IShape.RawFrame dapat tidak terdefinisi. Hal ini masuk akal ketika sebuah bentuk terhubung ke placeholder. Maka nilai bingkai bentuk yang tidak terdefinisi akan ditimpa oleh nilai placeholder induk. Jika tidak ada placeholder induk, bentuk tersebut akan menggunakan nilai default saat mengevaluasi bingkai efektif berdasarkan IShape.RawFrame-nya. Nilai default adalah 0 dan NullableBool.False untuk x, y, width, height, flipH, flipV, dan rotationAngle. Misalnya:
``` csharp

 IShape shape = ...; // shape terhubung ke placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// sekarang shape mewarisi nilai x, y, height, flipH, flipV dari placeholder dan menimpa width=100 serta rotationAngle=0.

``` 
### **Properti yang Diubah**
#### **Mengubah Nama dan Tipe Properti Aspose.Slides.IShapeCollection.Parent**
- Tipe properti Aspose.Slides.IShapeCollection.Parent telah diubah dari ISlideComponent menjadi antarmuka IGroupShape yang baru. Antarmuka IGroupShape adalah turunan dari ISlideComponent sehingga kode yang ada tidak memerlukan penyesuaian.
- Nama properti Aspose.Slides.IShapeCollection.Parent telah diubah dari Parent menjadi ParentGroup.
#### **Mengubah Tipe Properti Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Tipe properti Aspose.Slides.IShapeFrame.FlipH telah diubah dari bool menjadi NullableBool.
- Properti IShape.Frame mengembalikan instance IShapeFrame yang efektif (semua propertinya memiliki nilai efektif yang terdefinisi).
- Properti IShape.RawFrame mengembalikan sebuah instance IShapeFrame yang setiap propertinya dapat memiliki nilai tidak terdefinisi (khususnya FlipH atau FlipV dapat memiliki nilai NullableBool.NotDefined).