---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ekstrak latar belakang slide lengkap sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java, mempermudah alur kerja visual."
---
## **Ikhtisar**

Dalam presentasi PowerPoint, latar belakang slide dapat dibentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan pada slide master atau slide tata letak.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan mengkloning slide yang dipilih ke dalam presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Dapatkan Latar Belakang Seluruh Slide**

Aspose.Slides for Node.js via Java tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, tetapi Anda dapat mengikuti langkah-langkah di bawah ini:
1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Dapatkan ukuran slide dari presentasi.
1. Pilih sebuah slide.
1. Buat presentasi sementara.
1. Tetapkan ukuran slide yang sama pada presentasi sementara.
1. Kloning slide yang dipilih ke dalam presentasi sementara.
1. Hapus bentuk-bentuk dari slide yang dikloning.
1. Konversi slide yang dikloning menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Apakah gradien kompleks, tekstur, atau isian gambar dari slide master akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isian gradien, gambar, dan tekstur yang didefinisikan pada slide, tata letak, atau master. Jika Anda perlu memisahkan tampilan dari master yang diwarisi, [atur latar belakang sendiri](/slides/id/nodejs-java/presentation-background/) pada slide saat ini sebelum mengekspor.

**Bisakah saya menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat [tambahkan watermark](/slides/id/nodejs-java/watermark/) berupa bentuk atau gambar pada [salinan slide](/slides/id/nodejs-java/clone-slides/) yang sedang dikerjakan (ditempatkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda menghasilkan gambar latar belakang dengan watermark yang sudah terintegrasi.

**Bisakah saya mendapatkan latar belakang untuk tata letak atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau tata letak yang diinginkan, terapkan pada [slide sementara](/slides/id/nodejs-java/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk memperoleh latar belakang yang berasal dari tata letak atau master tersebut.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur rendering sepenuhnya tersedia dengan [lisensi yang valid](/slides/id/nodejs-java/licensing/). Dalam mode evaluasi, output mungkin menyertakan batasan seperti watermark. Aktifkan lisensi sekali per proses sebelum menjalankan ekspor batch.