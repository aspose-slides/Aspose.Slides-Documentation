---
title: Perubahan API Publik dan yang Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.3.0
linktitle: Aspose.Slides untuk .NET 14.3.0
type: docs
weight: 50
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "Tinjau pembaruan API publik serta perubahan yang tidak kompatibel di Aspose.Slides untuk .NET agar dapat memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
## **API Publik dan Perubahan yang Tidak Kompatibel Mundur**
### **Penambahan Enumerasi Aspose.Slides.ShapeThumbnailBounds dan Metode Aspose.Slides.IShape.GetThumbnail()**
Metode GetThumbnail() dan GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) digunakan untuk membuat thumbnail bentuk terpisah. Enumerasi ShapeThumbnailBounds mendefinisikan tipe batas thumbnail bentuk yang memungkinkan.
### **Properti UniqueId Telah Ditambahkan ke Aspose.Slides.IShape**
Properti Aspose.Slides.IShape.UniqueId memperoleh pengidentifikasi bentuk yang unik dalam lingkup presentasi. Pengidentifikasi unik ini disimpan dalam tag kustom bentuk.
### **Tanda Tangan Metode SetGroupingItem Diubah di IChartCategoryLevelsManager**
Tanda tangan metode IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

sudah usang dan digantikan dengan tanda tangan

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Sekarang pemanggilan seperti

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

harus diubah menjadi pemanggilan seperti

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Masukkan nilai seperti "Group 1" ke SetGroupingItem tetapi bukan nilai bertipe IChartDataCell. Membuat IChartDataCell dengan lembar kerja, baris, dan kolom yang telah ditentukan untuk level kategori harus memenuhi beberapa persyaratan dan telah dibungkus dalam metode SetGroupingItem(int, object).
### **Properti SlideId Ditambahkan ke Antarmuka Aspose.Slides.IBaseSlide**
Properti SlideId memperoleh pengidentifikasi slide yang unik.
### **Properti SoundName Ditambahkan ke ISlideShowTransition**
String yang dapat dibaca dan ditulis. Menentukan nama yang dapat dibaca manusia untuk suara transisi. Properti Sound harus ditetapkan untuk mendapatkan atau mengatur nama suara. Nama ini muncul di antarmuka pengguna PowerPoint saat mengonfigurasi suara transisi secara manual. Dapat melempar PptxException bila properti Sound tidak ditetapkan.
### **Tipe Properti ChartSeriesGroup.Type Diubah**
Properti ChartSeriesGroup.Type telah diubah dari enumerasi ChartType menjadi enumerasi baru CombinableSeriesTypesGroup. Enum CombinableSeriesTypesGroup mewakili grup tipe seri yang dapat digabungkan.
### **Dukungan untuk Menghasilkan Thumbnail Bentuk Individual Ditambahkan**
Aspose.Slides.ShapeThumbnailBounds

Anggota baru di Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)