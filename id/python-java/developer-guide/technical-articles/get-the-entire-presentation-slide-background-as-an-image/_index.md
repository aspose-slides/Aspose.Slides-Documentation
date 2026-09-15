---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/python-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Python
- Java
- Aspose.Slides
description: "Ekstrak latar belakang slide lengkap sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java, menyederhanakan alur kerja visual."
---
## **Overview**

Dalam presentasi PowerPoint, latar belakang slide dapat dibentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan pada slide master atau slide tata letak.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides for Python via Java. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan mengkloning slide yang dipilih ke presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Get the Entire Slide Background**

Aspose.Slides for Python via Java tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, tetapi Anda dapat mengikuti langkah‑langkah di bawah ini untuk melakukannya:

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Dapatkan ukuran slide dari presentasi.
3. Pilih sebuah slide.
4. Buat presentasi sementara.
5. Atur ukuran slide yang sama pada presentasi sementara.
6. Klona slide yang dipilih ke presentasi sementara.
7. Hapus bentuk-bentuk dari slide yang dikloning.
8. Konversi slide yang dikloning menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah gradien kompleks, tekstur, atau isi gambar dari slide master akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isi gradien, gambar, dan tekstur yang didefinisikan pada slide, tata letak, atau master. Jika Anda perlu memisahkan tampilan dari master yang diwariskan, [atur latar belakang khusus](/slides/id/python-java/presentation-background/) pada slide saat ini sebelum mengekspor.

**Apakah saya dapat menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat menambahkan bentuk atau gambar [tambahkan watermark](/slides/id/python-java/watermark/) pada [salinan slide](/slides/id/python-java/clone-slides/) yang sedang dikerjakan (ditempatkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda menghasilkan gambar latar belakang dengan watermark yang sudah terintegrasi.

**Apakah saya dapat mendapatkan latar belakang untuk tata letak atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau tata letak yang diinginkan, terapkan pada [slide sementara](/slides/id/python-java/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk memperoleh latar belakang yang dihasilkan dari tata letak atau master tersebut.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur rendering sepenuhnya tersedia dengan [lisensi valid](/slides/id/python-java/licensing/). Dalam mode evaluasi, output mungkin mencakup batasan seperti watermark. Aktifkan lisensi sekali per proses sebelum menjalankan ekspor batch.