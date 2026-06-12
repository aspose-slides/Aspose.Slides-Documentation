---
title: Kelola Grafik SmartArt dalam Presentasi Menggunakan Python
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/python-net/manage-smartart-shape/
keywords:
- objek SmartArt
- grafik SmartArt
- gaya SmartArt
- warna SmartArt
- buat SmartArt
- tambahkan SmartArt
- sunting SmartArt
- ubah SmartArt
- akses SmartArt
- jenis tata letak SmartArt
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint dalam Python melalui .NET menggunakan Aspose.Slides, dengan contoh kode yang singkat dan panduan yang berfokus pada kinerja."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatik. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang sudah ada, menemukan SmartArt berdasarkan jenis tata letak tertentu, dan memperbarui tampilan visualnya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk pada slide presentasi, memeriksa apakah sebuah bentuk adalah SmartArt, dan kemudian memodifikasi atau memeriksa propertinya.

## **Buat Bentuk SmartArt**

Aspose.Slides untuk Python melalui .NET memungkinkan Anda menambahkan bentuk SmartArt khusus ke slide dari awal. API mempermudah hal ini. Untuk menambahkan bentuk SmartArt ke slide:

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan slide target berdasarkan indeksnya.
1. Tambahkan bentuk SmartArt, dengan menentukan jenis tata letaknya.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instansiasi kelas Presentation.
with slides.Presentation() as presentation:
    # Akses slide presentasi.
    slide = presentation.slides[0]
    # Tambahkan bentuk SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Bentuk SmartArt pada Slide**

Kode berikut menunjukkan cara mengakses bentuk SmartArt pada sebuah slide. Contoh ini mengiterasi setiap bentuk pada slide dan memeriksa apakah itu sebuah objek [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/) .

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Muat file presentasi.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterasi setiap bentuk pada slide pertama.
    for shape in presentation.slides[0].shapes:
        # Periksa apakah bentuk tersebut adalah bentuk SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Cetak nama bentuk.
            print("Shape name:", shape.name)
```

## **Akses Bentuk SmartArt dengan Jenis Tata Letak Tertentu**

Contoh berikut menunjukkan cara mengakses bentuk SmartArt dengan jenis tata letak tertentu. Perhatikan bahwa Anda tidak dapat mengubah jenis tata letak SmartArt—jenis ini hanya terbaca dan ditetapkan saat bentuk dibuat.

1. Buat instance [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan referensi ke slide pertama berdasarkan indeks.
1. Iterasi setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut adalah objek [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/) .
1. Jika jenis tata letak bentuk SmartArt cocok dengan yang Anda butuhkan, lakukan tindakan yang diperlukan.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterasi setiap bentuk pada slide pertama.
    for shape in presentation.slides[0].shapes:
        # Periksa apakah bentuk tersebut adalah bentuk SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Periksa jenis tata letak SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Ubah Gaya Bentuk SmartArt**

Contoh berikut menunjukkan cara menemukan bentuk SmartArt dan mengubah gayanya:

1. Buat [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat file yang berisi bentuk SmartArt.
1. Dapatkan referensi ke slide pertama berdasarkan indeks.
1. Iterasi setiap bentuk pada slide pertama.
1. Temukan bentuk SmartArt dengan gaya yang ditentukan.
1. Tetapkan gaya baru ke bentuk SmartArt.
1. Simpan presentasi.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterasi setiap bentuk pada slide pertama.
    for shape in presentation.slides[0].shapes:
        # Periksa apakah bentuk tersebut adalah bentuk SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Periksa gaya SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Ubah gaya SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Simpan presentasi.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ubah Gaya Warna Bentuk SmartArt**

Contoh ini menunjukkan cara mengubah gaya warna sebuah bentuk SmartArt. Kode contoh menemukan bentuk SmartArt dengan gaya warna tertentu dan memperbaruinya.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang berisi bentuk SmartArt.
1. Dapatkan referensi ke slide pertama berdasarkan indeks.
1. Iterasi setiap bentuk pada slide pertama.
1. Periksa apakah bentuk tersebut adalah objek [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/) .
1. Temukan bentuk SmartArt dengan gaya warna yang ditentukan.
1. Tetapkan gaya warna baru untuk bentuk SmartArt tersebut.
1. Simpan presentasi.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterasi setiap bentuk pada slide pertama.
    for shape in presentation.slides[0].shapes:
        # Periksa apakah bentuk tersebut adalah bentuk SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Periksa jenis warna.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Ubah jenis warna.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Simpan presentasi.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat memberi animasi pada SmartArt sebagai satu objek?**

Ya. SmartArt adalah sebuah bentuk, jadi Anda dapat menerapkan [animasi standar](/slides/id/python-net/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) seperti pada bentuk lainnya.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Tetapkan dan gunakan Teks Alternatif (AltText) serta cari bentuk tersebut berdasarkan nilai itu—ini merupakan cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/python-net/group/) .

**Bagaimana cara mendapatkan gambar SmartArt tertentu (misalnya untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar bentuk; perpustakaan dapat [merender bentuk individual](/slides/id/python-net/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan kesetiaan tinggi untuk [ekspor PDF](/slides/id/python-net/convert-powerpoint-to-pdf/) , dengan beragam opsi kualitas dan kompatibilitas.