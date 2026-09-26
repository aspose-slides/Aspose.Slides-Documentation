---
title: Cara Membuat Presentasi Hello World di .NET
linktitle: Presentasi Hello World
type: docs
weight: 10
url: /id/net/how-to-create-hello-world-presentation-document/
keywords:
- migrasi
- halo dunia
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
description: "Buat presentasi PowerPoint PPT, PPTX, dan ODP Hello World di .NET dengan Aspose.Slides menggunakan API warisan dan modern dalam satu panduan sederhana."
---
{{% alert color="info" %}} 
Sebuah [Aspose.Slides for .NET API](/slides/id/net/) baru telah dirilis dan sekarang produk tunggal ini mendukung kemampuan untuk menghasilkan dokumen PowerPoint dari awal serta mengedit dokumen yang sudah ada.
{{% /alert %}} 
## **Dukungan untuk Kode Warisan**
Untuk menggunakan kode warisan yang dikembangkan dengan Aspose.Slides for .NET versi sebelum 13.x, Anda perlu melakukan beberapa perubahan kecil pada kode Anda dan kode tersebut akan berfungsi seperti sebelumnya. Semua kelas yang ada di Aspose.Slides for .NET lama di dalam namespace Aspose.Slide dan Aspose.Slides.Pptx kini telah digabungkan ke dalam satu namespace Aspose.Slides. Silakan lihat cuplikan kode sederhana berikut untuk membuat dokumen Presentasi Hello World dengan API Aspose.Slides lama dan ikuti langkah-langkah yang menjelaskan cara bermigrasi ke API yang baru digabungkan.
## **Pendekatan Legacy Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Membuat objek Presentation yang mewakili file PPT
Presentation pres = new Presentation();

//Membuat objek License
License license = new License();

//Set lisensi Aspose.Slides untuk .NET untuk menghindari batasan evaluasi
license.SetLicense("Aspose.Slides.lic");

//Menambahkan slide kosong ke presentasi dan mendapatkan referensi
//dari slide kosong tersebut
Slide slide = pres.AddEmptySlide();

//Menambahkan persegi panjang (X=2400, Y=1800, Lebar=1000 & Tinggi=500) ke slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Menyembunyikan garis persegi panjang
rect.LineFormat.ShowLines = false;

//Menambahkan bingkai teks ke persegi panjang dengan "Hello World" sebagai teks default
rect.AddTextFrame("Hello World");

//Menghapus slide pertama dari presentasi yang selalu ditambahkan oleh
//Aspose.Slides untuk .NET secara default saat membuat presentasi
pres.Slides.RemoveAt(0);

//Menulis presentasi sebagai file PPT
pres.Write("C:\\hello.ppt");
```


## **Pendekatan Baru Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```