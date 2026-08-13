---
title: Cara Menambahkan Header & Footer ke Presentasi di .NET
linktitle: Tambah Header & Footer
type: docs
weight: 20
url: /id/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migrasi
- tambahkan header
- tambahkan footer
- kode legacy
- kode modern
- pendekatan legacy
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan header dan footer pada presentasi PowerPoint PPT, PPTX, dan ODP di .NET menggunakan API Aspose.Slides legacy dan modern."
---
{{% alert color="info" %}} 
Sebuah [Aspose.Slides for .NET API](/slides/id/net/) baru telah dirilis dan sekarang produk tunggal ini mendukung kemampuan untuk membuat dokumen PowerPoint dari awal serta mengedit yang sudah ada.
{{% /alert %}} 
## **Dukungan untuk Kode Legacy**
Untuk menggunakan kode legacy yang dikembangkan dengan Aspose.Slides for .NET versi sebelum 13.x, Anda perlu melakukan beberapa perubahan kecil pada kode Anda dan kode tersebut akan berfungsi seperti sebelumnya. Semua kelas yang sebelumnya berada di Aspose.Slides for .NET di bawah namespace Aspose.Slide dan Aspose.Slides.Pptx kini digabungkan dalam satu namespace Aspose.Slides. Silakan lihat cuplikan kode sederhana berikut untuk menambahkan header footer pada presentasi dalam API Aspose.Slides legacy dan ikuti langkah-langkah yang menjelaskan cara migrasi ke API yang baru digabungkan.
## **Pendekatan Legacy Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Mengatur properti visibilitas Header Footer
sourcePres.UpdateSlideNumberFields = true;

//Perbarui bidang Tanggal Waktu
sourcePres.UpdateDateTimeFields = true;

//Tampilkan placeholder tanggal waktu
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Tampilkan placeholder footer
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Tampilkan Nomor Slide
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Atur visibilitas header footer pada Slide Judul
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Tulis presentasi ke disk
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Buat presentasi
Presentation pres = new Presentation();

//Dapatkan slide pertama
Slide sld = pres.GetSlideByPosition(1);

//Akses Header / Footer slide
HeaderFooter hf = sld.HeaderFooter;

//Atur Visibilitas Nomor Halaman
hf.PageNumberVisible = true;

//Atur Visibilitas Footer
hf.FooterVisible = true;

//Atur Visibilitas Header
hf.HeaderVisible = true;

//Atur Visibilitas Tanggal Waktu
hf.DateTimeVisible = true;

//Atur format Tanggal Waktu
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Atur Teks Header
hf.HeaderText = "Header Text";

//Atur Teks Footer
hf.FooterText = "Footer Text";

//Tulis presentasi ke disk
pres.Write("HeadFoot.ppt");
```



## **Pendekatan Baru Aspose.Slides untuk .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Mengatur properti visibilitas Header Footer
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Perbarui bidang Tanggal Waktu
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Tampilkan placeholder tanggal waktu
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Tampilkan placeholder footer
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Atur visibilitas header footer pada Slide Judul
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Tulis presentasi ke disk
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```