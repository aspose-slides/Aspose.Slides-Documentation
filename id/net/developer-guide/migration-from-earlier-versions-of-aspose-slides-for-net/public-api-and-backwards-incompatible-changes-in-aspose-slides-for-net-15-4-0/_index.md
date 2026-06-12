---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk .NET 15.4.0
linktitle: Aspose.Slides untuk .NET 15.4.0
type: docs
weight: 150
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda secara mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan lain-lain yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 15.4.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Enum OrganizationChartLayoutType Telah Ditambahkan**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType mewakili jenis format node anak dalam diagram organisasi.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts Telah Ditambahkan**
Metode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts mengatur pergeseran default non-zero untuk Indent paragraf dan MarginLeft yang efektif ketika bullet diaktifkan (seperti yang dilakukan PowerPoint bila mengaktifkan bullet/penomoran paragraf). Jika bullet dinonaktifkan maka hanya mereset Indent paragraf dan MarginLeft (seperti yang dilakukan PowerPoint bila menonaktifkan bullet/penomoran paragraf).

Lihat contoh [di sini](/slides/id/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute Telah Ditambahkan**
Metode Aspose.Slides.IConnector.Reroute mengarahkan kembali konektor sehingga mengambil jalur terpendek antara bentuk-bentuk yang dihubungkannya. Untuk melakukan ini, metode Reroute() dapat mengubah StartShapeConnectionSiteIndex dan EndShapeConnectionSiteIndex.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Method IPresentation.GetSlideById Telah Ditambahkan**
Metode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) mengembalikan Slide, MasterSlide, atau LayoutSlide berdasarkan Id slide.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount Telah Ditambahkan**
Properti Aspose.Slides.IShape.ConnectionSiteCount mengembalikan jumlah situs koneksi pada bentuk.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.IsReversed Telah Ditambahkan**
Properti Aspose.Slides.SmartArt.ISmartArt.IsReversed memungkinkan mendapatkan atau mengatur keadaan diagram SmartArt terkait (kiri-ke-kanan) LTR atau (kanan-ke-kiri) RTL, jika diagram mendukung pembalikan.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes Telah Ditambahkan**
Properti Aspose.Slides.SmartArt.ISmartArt.Nodes mengembalikan koleksi node akar dalam objek SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // pilih node akar kedua

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden Telah Ditambahkan**
Properti Aspose.Slides.SmartArt.ISmartArtNode.IsHidden mengembalikan true jika node ini adalah node tersembunyi dalam model data.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //mengembalikan true

  if(hidden)

  {

    //lakukan beberapa aksi atau notifikasi

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout Telah Ditambahkan**
Properti Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout memungkinkan mendapatkan atau mengatur jenis diagram organisasi yang terkait dengan node saat ini.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Metode Set untuk Properti ISmartArt.Layout Telah Ditambahkan**
Metode set untuk properti Aspose.Slides.SmartArt.ISmartArt.Layout telah ditambahkan. Ini memungkinkan mengubah jenis layout diagram yang ada.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Perubahan API Minor**
**Berikut Daftar Perubahan API Minor:**

|Enum Aspose.Slides.BevelColorMode |dihapus, enum tidak terpakai |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |dihapus, properti tidak terpakai |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |ditambahkan |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |dihapus |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |dihapus karena usang |