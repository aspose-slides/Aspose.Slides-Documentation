---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang pada Aspose.Slides untuk .NET 15.7.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah pada Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda secara mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) kelas, metode, properti, dan sebagainya, serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 15.7.0.

{{% /alert %}} 
## **Public API Changes**
#### **Enum ImagePixelFormat Telah Ditambahkan**
Enum Aspose.Slides.Export.ImagePixelFormat telah ditambahkan untuk menentukan format piksel bagi gambar yang dihasilkan.
#### **Metode IChartDataPoint.GetAutomaticDataPointColor() Telah Ditambahkan**
Mengembalikan warna otomatis untuk data point berdasarkan indeks seri, indeks data point, ParentSeriesGroup, properti IsColorVaried, dan gaya diagram.
Warna ini digunakan secara default jika FillType bernilai NotDefined.
#### **Metode RenderToGraphics Telah Ditambahkan ke Slide**
Metode RenderToGraphics (dan overload-nya) telah ditambahkan ke Aspose.Slides.Slide untuk merender slide ke objek Graphics.
#### **Properti PixelFormat Telah Ditambahkan ke ITiffOptions dan TiffOptions**
Properti PixelFormat telah ditambahkan ke Aspose.Slides.Export.ITiffOptions dan Aspose.Slides.Export.TiffOptions untuk menentukan format piksel bagi gambar TIFF yang dihasilkan.