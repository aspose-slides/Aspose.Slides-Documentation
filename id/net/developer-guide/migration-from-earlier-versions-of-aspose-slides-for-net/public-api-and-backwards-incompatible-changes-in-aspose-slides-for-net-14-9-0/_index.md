---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.9.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini menampilkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for .NET 14.9.0. 

{{% /alert %}} 
## **Perubahan API Publik**
#### **Penambahan Pewarisan dari Antarmuka ICollection dan Generic IEnumerable ke ISmartArtNodeCollection**
Kelas Aspose.Slides.SmartArt.SmartArtNodeCollection (dan antarmuka terkait Aspose.Slides.SmartArt.ISmartArtNodeCollection) mewarisi antarmuka generic IEnumerable<ISmartArtNode> dan antarmuka ICollection. 
#### **Nilai Enum SmartArtLayoutType.Custom Ditambahkan**
Tipe tata letak SmartArt Custom mewakili diagram dengan templat khusus. Diagram khusus hanya dapat dimuat dari file presentasi dan tidak dapat dibuat melalui metode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom). 
#### **Kelas SmartArtShape dan Antarmuka ISmartArtShape Ditambahkan**
Kelas Aspose.Slides.SmartArt.SmartArtShape (dan antarmukanya Aspose.Slides.SmartArt.ISmartArtShape) memberikan akses ke bentuk individu dalam diagram SmartArt. SmartArtShape dapat digunakan untuk mengubah FillFormat, LineFormat, menambahkan Hyperlink, dan tugas lainnya. 

{{% alert color="primary" %}} 

**Catatan**: SmartArtShape tidak mendukung properti IShape RawFrame, Frame, Rotation, X, Y, Width, Height dan akan melempar System.NotSupportedException ketika mencoba mengaksesnya. 

Contoh penggunaan: 

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Kelas SmartArtShapeCollection, Antarmuka ISmartArtShapeCollection, dan Properti ISmartArtNode.Shapes Ditambahkan**
Kelas Aspose.Slides.SmartArt.SmartArtShapeCollection (dan antarmukanya Aspose.Slides.SmartArt.ISmartArtShapeCollection) menambahkan akses ke bentuk individu dalam diagram SmartArt. Koleksi ini berisi bentuk-bentuk yang terkait dengan SmartArtNode. Properti SmartArtNode.Shapes mengembalikan koleksi semua bentuk yang terkait dengan node tersebut. 

{{% alert color="primary" %}} 

**Catatan**: tergantung pada SmartArtLayoutType, satu SmartArtShape dapat dibagikan antara beberapa node. 

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Metode untuk Menyimpan Slide dengan Menjaga Nomor Halaman Ditambahkan**
Metode berikut telah ditambahkan: 

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Metode‑metode ini memungkinkan pengembang menyimpan slide presentasi tertentu ke format PDF, XPS, TIFF, HTML. Array 'slides' digunakan untuk menentukan nomor halaman, dimulai dari 1. 
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Array posisi slide
presentation.Save(outFileName, slides, SaveFormat.Pdf);
``` 
#### **Metode untuk Mengganti Gambar Ditambahkan ke PPImage, IPPImage**
Metode baru yang ditambahkan: 

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//Metode pertama
byte[] data = File.ReadAllBytes(image0.jpeg);
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);
//Metode kedua
Image newImage = Image.FromFile(image1.png);
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);
//Metode ketiga
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);
presentation.Save(presentation_out.pptx, SaveFormat.Pptx);
```