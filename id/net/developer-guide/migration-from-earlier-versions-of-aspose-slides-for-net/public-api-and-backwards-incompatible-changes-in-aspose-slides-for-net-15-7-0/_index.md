---
title: API Publik dan Perubahan Tidak Kompatibel Mundur pada Aspose.Slides untuk .NET 15.7.0
linktitle: Aspose.Slides untuk .NET 15.7.0
type: docs
weight: 180
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
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

Halaman ini mencantumkan semua kelas, metode, properti, dan lain‑lain yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 15.7.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Enum ImagePixelFormat Telah Ditambahkan**
Enum Aspose.Slides.Export.ImagePixelFormat telah ditambahkan untuk menentukan format piksel gambar yang dihasilkan.
#### **Metode IChartDataPoint.GetAutomaticDataPointColor() Telah Ditambahkan**
Mengembalikan warna otomatis untuk titik data berdasarkan indeks seri, indeks titik data, ParentSeriesGroup, properti IsColorVaried, dan gaya diagram.
Warna ini digunakan secara default jika FillType bernilai NotDefined.
#### **Metode RenderToGraphics Telah Ditambahkan ke Slide**
Metode RenderToGraphics (dan overloadnya) telah ditambahkan ke Aspose.Slides.Slide untuk merender slide ke objek Graphics.
#### **Properti PixelFormat Telah Ditambahkan ke ITiffOptions dan TiffOptions**
Properti PixelFormat telah ditambahkan ke Aspose.Slides.Export.ITiffOptions dan Aspose.Slides.Export.TiffOptions untuk menentukan format piksel pada gambar TIFF yang dihasilkan.