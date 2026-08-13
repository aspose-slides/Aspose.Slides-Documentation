---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk .NET 14.9.0
linktitle: Aspose.Slides untuk .NET 14.9.0
type: docs
weight: 110
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini menampilkan semua [added](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) atau [removed](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) kelas, metode, properti, dan lain-lain, serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 14.9.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Penambahan Pewarisan dari Antarmuka ICollection dan IEnumerable Generik ke ISmartArtNodeCollection**
Kelas Aspose.Slides.SmartArt.SmartArtNodeCollection (dan antarmuka terkait Aspose.Slides.SmartArt.ISmartArtNodeCollection) mewarisi antarmuka generik IEnumerable<ISmartArtNode> dan antarmuka ICollection.
#### **Nilai Enum SmartArtLayoutType.Custom Ditambahkan**
Jenis tata letak SmartArt Custom mewakili diagram dengan templat khusus. Diagram khusus hanya dapat dimuat dari file presentasi dan tidak dapat dibuat melalui metode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Kelas SmartArtShape dan Antarmuka ISmartArtShape Ditambahkan**
Kelas Aspose.Slides.SmartArt.SmartArtShape (dan antarmukanya Aspose.Slides.SmartArt.ISmartArtShape) memberikan akses ke bentuk individual dalam diagram SmartArt. SmartArtShape dapat digunakan untuk mengubah FillFormat, LineFormat, menambahkan Hyperlink, dan tugas lainnya.

{{% alert color="info" %}} 

**Note**: SmartArtShape tidak mendukung properti IShape RawFrame, Frame, Rotation, X, Y, Width, Height dan melempar System.NotSupportedException ketika mencoba mengaksesnya.

Contoh penggunaan:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Kelas SmartArtShapeCollection, Antarmuka ISmartArtShapeCollection, dan Properti ISmartArtNode.Shapes Ditambahkan**
Kelas Aspose.Slides.SmartArt.SmartArtShapeCollection (dan antarmukanya Aspose.Slides.SmartArt.ISmartArtShapeCollection) menambahkan akses ke bentuk individual dalam diagram SmartArt. Koleksi ini berisi bentuk yang terkait dengan SmartArtNode. Properti SmartArtNode.Shapes mengembalikan koleksi semua bentuk yang terkait dengan node tersebut.

{{% alert color="info" %}} 

**Note**: tergantung pada SmartArtLayoutType, satu SmartArtShape dapat dibagikan antara beberapa node.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Metode untuk Menyimpan Slide dengan Menyertakan Nomor Halaman Ditambahkan**
Metode-metode berikut telah ditambahkan:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Metode ini memungkinkan pengembang menyimpan slide presentasi tertentu ke format PDF, XPS, TIFF, HTML. Array 'slides' digunakan untuk menentukan nomor halaman, dimulai dari 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Array posisi slide

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Metode untuk Mengganti Gambar Ditambahkan ke PPImage, IPPImage**
Metode baru yang ditambahkan:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Metode pertama

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Metode kedua

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Metode ketiga

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```