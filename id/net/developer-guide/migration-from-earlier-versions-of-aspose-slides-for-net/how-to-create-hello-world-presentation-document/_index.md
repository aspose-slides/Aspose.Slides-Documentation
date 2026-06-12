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
description: "Buat presentasi PowerPoint PPT, PPTX, dan ODP Hello World di .NET dengan Aspose.Slides menggunakan API legacy dan modern dalam satu panduan sederhana."
---
{{% alert color="primary" %}} 
Sebuah [Aspose.Slides for .NET API](/slides/id/net/) baru telah dirilis dan kini produk tunggal ini mendukung kemampuan untuk menghasilkan dokumen PowerPoint dari awal serta mengedit dokumen yang sudah ada.
{{% /alert %}} 
## **Dukungan Kode Legacy**
Untuk menggunakan kode warisan yang dikembangkan dengan Aspose.Slides untuk .NET versi sebelum 13.x, Anda perlu melakukan beberapa perubahan kecil pada kode Anda dan kode tersebut akan berfungsi seperti sebelumnya. Semua kelas yang ada di Aspose.Slides untuk .NET lama di namespace Aspose.Slide dan Aspose.Slides.Pptx kini digabungkan menjadi satu namespace Aspose.Slides. Silakan lihat potongan kode sederhana berikut untuk membuat dokumen Presentasi Hello World menggunakan API Aspose.Slides legacy dan ikuti langkah-langkah yang menjelaskan cara bermigrasi ke API yang baru digabungkan.
## **Pendekatan Legacy Aspose.Slides untuk .NET**
```c#
//Membuat objek Presentation yang mewakili file PPT
Presentation pres = new Presentation();

//Buat objek License
License license = new License();

//Set lisensi Aspose.Slides untuk .NET untuk menghindari batasan evaluasi
license.SetLicense("Aspose.Slides.lic");

//Menambahkan slide kosong ke presentasi dan mendapatkan referensi
//slide kosong tersebut
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

## **Pendekatan Baru Aspose.Slides untuk .NET 13.x**
```c#
// Membuat instance Presentation
Presentation pres = new Presentation();

// Ambil slide pertama
ISlide sld = (ISlide)pres.Slides[0];

// Tambahkan AutoShape tipe Persegi panjang
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Tambahkan ITextFrame ke Persegi panjang
ashp.AddTextFrame("Hello World");

// Ubah warna teks menjadi Hitam (yang defaultnya Putih)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Ubah warna garis persegi panjang menjadi Putih
ashp.ShapeStyle.LineColor.Color = Color.White;

// Hapus semua format isian pada bentuk
ashp.FillFormat.FillType = FillType.NoFill;

// Simpan presentasi ke disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```