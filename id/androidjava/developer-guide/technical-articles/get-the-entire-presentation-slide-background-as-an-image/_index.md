---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Android
- Java
- Aspose.Slides
description: "Ekstrak latar belakang slide lengkap sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java, menyederhanakan alur kerja visual."
---
## **Gambaran Umum**

Dalam presentasi PowerPoint, latar belakang slide dapat terbentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan pada slide master atau slide tata letak.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides untuk .NET. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan mengkloning slide yang dipilih ke dalam presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Dapatkan Seluruh Latar Belakang Slide**

Aspose.Slides for Android via Java tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, tetapi Anda dapat mengikuti langkah‑langkah di bawah ini untuk melakukannya:
1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan ukuran slide dari presentasi.
1. Pilih sebuah slide.
1. Buat presentasi sementara.
1. Tetapkan ukuran slide yang sama dalam presentasi sementara.
1. Kloning slide yang dipilih ke dalam presentasi sementara.
1. Hapus bentuk-bentuk dari slide yang dikloning.
1. Konversi slide yang dikloning menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Apakah gradien kompleks, tekstur, atau isian gambar dari slide master akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isian gradien, gambar, dan tekstur yang didefinisikan pada slide, tata letak, atau master. Jika Anda perlu mengisolasi tampilan dari master yang diwariskan, [menetapkan latar belakang sendiri](/slides/id/androidjava/presentation-background/) pada slide saat ini sebelum mengekspor.

**Apakah saya dapat menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat [menambahkan watermark](/slides/id/androidjava/watermark/) berupa bentuk atau gambar pada [salinan slide](/slides/id/androidjava/clone-slides/) yang sedang dikerjakan (ditempatkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda membuat gambar latar belakang dengan watermark yang sudah tersemat.

**Apakah saya dapat mendapatkan latar belakang untuk tata letak atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau tata letak yang diinginkan, terapkan pada [slide sementara](/slides/id/androidjava/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk memperoleh latar belakang yang berasal dari tata letak atau master tersebut.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur render sepenuhnya tersedia dengan [lisensi yang valid](/slides/id/androidjava/licensing/). Dalam mode evaluasi, keluaran mungkin memiliki batasan seperti watermark. Aktifkan lisensi satu kali per proses sebelum menjalankan ekspor batch.