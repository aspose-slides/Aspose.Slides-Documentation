---
title: Cara Menambahkan Header & Footer ke Presentasi di .NET
linktitle: Tambahkan Header & Footer
type: docs
weight: 20
url: /id/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migrasi
- tambahkan header
- tambahkan footer
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
description: "Pelajari cara menambahkan header dan footer pada presentasi PowerPoint PPT, PPTX, dan ODP di .NET menggunakan API Aspose.Slides legacy dan modern."
---
{{% alert color="primary" %}} 

Sebuah [Aspose.Slides for .NET API](/slides/id/net/) baru telah dirilis dan kini produk tunggal ini mendukung kemampuan untuk membuat dokumen PowerPoint dari awal serta mengedit dokumen yang sudah ada.

{{% /alert %}} 
## **Dukungan untuk Kode Warisan**
Untuk menggunakan kode warisan yang dikembangkan dengan Aspose.Slides untuk .NET versi sebelum 13.x, Anda perlu melakukan beberapa perubahan kecil pada kode Anda dan kode tersebut akan berfungsi seperti sebelumnya. Semua kelas yang sebelumnya berada di Aspose.Slides untuk .NET lama di bawah namespace Aspose.Slide dan Aspose.Slides.Pptx kini digabungkan dalam satu namespace Aspose.Slides. Silakan lihat cuplikan kode sederhana berikut untuk menambahkan header footer dalam presentasi pada API Aspose.Slides legacy dan ikuti langkah-langkah yang menjelaskan cara bermigrasi ke API yang baru digabung.
## **Pendekatan Legacy Aspose.Slides untuk .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Mengatur properti visibilitas Header Footer
//Memperbarui bidang Tanggal Waktu
//Menampilkan placeholder tanggal waktu
//Menampilkan placeholder footer
//Menampilkan Nomor Slide
//Mengatur visibilitas header footer pada Slide Judul
//Menulis presentasi ke disk
sourcePres.Write("NewSource.pptx");
```

```c#
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
    
    //Set visibilitas header footer pada Slide Judul
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Tulis presentasi ke disk
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```