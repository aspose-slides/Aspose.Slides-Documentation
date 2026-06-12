---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- latar belakang slide
- latar belakang akhir
- ekstrak latar belakang
- seluruh latar belakang
- latar belakang ke gambar
- latar belakang PPT
- latar belakang PPTX
- latar belakang ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ekstrak latar belakang slide lengkap sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET, menyederhanakan alur kerja visual."
---
## **Ikhtisar**

Dalam presentasi PowerPoint, latar belakang slide dapat terbentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan pada slide master atau slide tata letak.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides untuk .NET. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan penggandaan slide yang dipilih ke dalam presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Dapatkan Seluruh Latar Belakang Slide**

Aspose.Slides untuk .NET tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, namun Anda dapat mengikuti langkah-langkah berikut untuk melakukannya:
1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan ukuran slide dari presentasi.
1. Pilih sebuah slide.
1. Buat presentasi sementara.
1. Atur ukuran slide yang sama pada presentasi sementara.
1. Klon slide yang dipilih ke dalam presentasi sementara.
1. Hapus bentuk-bentuk dari slide yang diklon.
1. Konversi slide yang diklon menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **FAQ**

**Apakah gradien kompleks, tekstur, atau isian gambar dari slide master akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isian gradien, gambar, dan tekstur yang didefinisikan pada slide, tata letak, atau master. Jika Anda perlu memisahkan tampilan dari master yang diwarisi, [atur latar belakang sendiri](/slides/id/net/presentation-background/) pada slide saat ini sebelum mengekspor.

**Apakah saya dapat menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat [menambahkan watermark](/slides/id/net/watermark/) berupa bentuk atau gambar pada [salinan slide yang sedang dikerjakan](/slides/id/net/clone-slides/) (ditempatkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda membuat gambar latar belakang dengan watermark yang sudah tertanam.

**Apakah saya dapat memperoleh latar belakang untuk tata letak atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau tata letak yang diinginkan, terapkan pada [slide sementara](/slides/id/net/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk memperoleh latar belakang yang berasal dari tata letak atau master tersebut.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur rendering sepenuhnya tersedia dengan [lisensi yang valid](/slides/id/net/licensing/). Dalam mode evaluasi, output mungkin memiliki batasan seperti watermark. Aktifkan lisensi sekali per proses sebelum menjalankan ekspor batch.