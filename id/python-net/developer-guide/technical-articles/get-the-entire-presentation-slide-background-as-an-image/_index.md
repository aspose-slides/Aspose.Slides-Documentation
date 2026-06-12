---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slide
- latar belakang
- latar belakang slide
- latar belakang akhir
- latar belakang ke gambar
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Ekstrak latar belakang slide lengkap sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET, menyederhanakan alur kerja visual."
---
## **Gambaran Umum**

Dalam presentasi PowerPoint, latar belakang slide dapat terbentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan pada slide master atau slide tata letak.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan mengkloning slide yang dipilih ke dalam presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Dapatkan Seluruh Latar Belakang Slide**

Aspose.Slides for Python tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, tetapi Anda dapat mengikuti langkah-langkah di bawah ini untuk melakukannya:
1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan ukuran slide dari presentasi.
3. Pilih sebuah slide.
4. Buat presentasi sementara.
5. Atur ukuran slide yang sama pada presentasi sementara.
6. Kloning slide yang dipilih ke dalam presentasi sementara.
7. Hapus bentuk-bentuk dari slide yang dikloning.
8. Konversi slide yang dikloning menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **Tanya Jawab**

**Apakah gradien kompleks, tekstur, atau isian gambar dari slide master akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isian gradien, gambar, dan tekstur yang didefinisikan pada slide, tata letak, atau master. Jika Anda perlu memisahkan tampilan dari master yang diwariskan, [setel latar belakang sendiri](/slides/id/python-net/presentation-background/) pada slide saat ini sebelum mengekspor.

**Bisakah saya menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat [menambahkan watermark](/slides/id/python-net/watermark/) bentuk atau gambar pada [salinan slide](/slides/id/python-net/clone-slides/) yang sedang dikerjakan (diletakkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda menghasilkan gambar latar belakang dengan watermark yang sudah tertanam.

**Bisakah saya mendapatkan latar belakang untuk tata letak atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau tata letak yang diinginkan, terapkan pada [slide sementara](/slides/id/python-net/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk mendapatkan latar belakang yang dihasilkan dari tata letak atau master tersebut.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur rendering sepenuhnya tersedia dengan [lisensi yang valid](/slides/id/python-net/licensing/). Dalam mode evaluasi, output mungkin memiliki batasan seperti watermark. Aktifkan lisensi satu kali per proses sebelum menjalankan ekspor batch.