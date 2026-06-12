---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "Ekstrak latar belakang slide lengkap sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++, menyederhanakan alur kerja visual."
---
## **Gambaran Umum**

Pada presentasi PowerPoint, latar belakang slide dapat dibentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan pada slide master atau slide tata letak.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan mengkloning slide yang dipilih ke dalam presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Dapatkan Seluruh Latar Belakang Slide**

Aspose.Slides untuk C++ tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, tetapi Anda dapat mengikuti langkah-langkah berikut untuk melakukannya:
1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan ukuran slide dari presentasi.
1. Pilih sebuah slide.
1. Buat presentasi sementara.
1. Atur ukuran slide yang sama di presentasi sementara.
1. Klon slide yang dipilih ke dalam presentasi sementara.
1. Hapus bentuk-bentuk dari slide yang diklon.
1. Konversi slide yang diklon menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **Tanya Jawab**

**Apakah gradien kompleks, tekstur, atau isian gambar dari slide master akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isian gradien, gambar, dan tekstur yang didefinisikan pada slide, tata letak, atau master. Jika Anda perlu memisahkan tampilan dari master yang diwarisi, [atur latar belakang sendiri](/slides/id/cpp/presentation-background/) pada slide saat ini sebelum mengekspor.

**Apakah saya dapat menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat menambahkan bentuk atau gambar [watermark](/slides/id/cpp/watermark/) pada [salinan slide yang sedang dikerjakan](/slides/id/cpp/clone-slides/) (ditempatkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda menghasilkan gambar latar belakang dengan watermark yang sudah terintegrasi.

**Apakah saya dapat memperoleh latar belakang untuk tata letak atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau tata letak yang diinginkan, terapkan ke [slide sementara](/slides/id/cpp/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk memperoleh latar belakang yang dihasilkan dari tata letak atau master tersebut.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur rendering tersedia sepenuhnya dengan [lisensi yang valid](/slides/id/cpp/licensing/). Dalam mode evaluasi, output mungkin memiliki batasan seperti watermark. Aktifkan lisensi sekali per proses sebelum menjalankan ekspor massal.