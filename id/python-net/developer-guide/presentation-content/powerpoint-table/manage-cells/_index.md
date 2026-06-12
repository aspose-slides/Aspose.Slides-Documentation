---
title: Kelola Sel Tabel dalam Presentasi dengan Python
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/python-net/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- menghapus batas
- memisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python melalui .NET dengan mudah. Kuasai cara mengakses, memodifikasi, dan menata sel secara cepat untuk otomatisasi slide yang mulus."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah penggabungan atau pemisahan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Mengidentifikasi Sel Tabel yang Digabung**

Tabel sering berisi sel yang digabung untuk header atau untuk mengelompokkan data terkait. Pada bagian ini, Anda akan melihat cara menentukan apakah sel tertentu termasuk dalam wilayah yang digabung dan cara merujuk ke sel induk (kiri‑atas) sehingga Anda dapat membaca atau memformat seluruh blok secara konsisten.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan tabel dari slide pertama.
1. Iterasi baris dan kolom tabel untuk menemukan sel yang digabung.
1. Cetak pesan ketika sel yang digabung ditemukan.

Kode Python berikut mengidentifikasi sel tabel yang digabung dalam sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Mengasumsikan bentuk pertama pada slide pertama adalah sebuah tabel.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Menghapus Batas Sel Tabel**

Kadang‑kadang batas tabel mengalihkan perhatian dari konten atau menyebabkan kekacauan visual. Bagian ini menunjukkan cara menghapus batas dari sel yang dipilih—atau sisi tertentu dari sebuah sel—sehingga Anda dapat menghasilkan tata letak yang lebih bersih dan lebih selaras dengan desain slide Anda.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan slide berdasarkan indeksnya.
1. Definisikan array lebar kolom.
1. Definisikan array tinggi baris.
1. Tambahkan tabel ke slide menggunakan metode [add_table](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_table/) .
1. Iterasi setiap sel untuk menghapus batas atas, bawah, kiri, dan kanan.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menghapus batas dari sel tabel:

```python
import aspose.slides as slides

# Buat instance dari kelas Presentation yang mewakili file PPTX.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tentukan kolom dengan lebar dan baris dengan tinggi.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Tambahkan shape tabel ke slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Hapus isian batas untuk setiap sel.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Simpan file PPTX ke disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Penomoran pada Sel yang Digabung**

Jika Anda menggabungkan dua pasang sel—misalnya, (1, 1) x (2, 1) dan (1, 2) x (2, 2)—tabel yang dihasilkan akan mempertahankan penomoran sel yang sama seperti tabel tanpa penggabungan. Kode Python berikut mendemonstrasikan perilaku ini:

```python
import aspose.slides as slides

# Buat instance dari kelas Presentation yang mewakili file PPTX.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tentukan kolom dengan lebar dan baris dengan tinggi.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Tambahkan shape tabel ke slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Gabungkan sel (1,1) dan (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Gabungkan sel (1, 2) dan (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Cetak indeks sel.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Simpan file PPTX ke disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Penomoran pada Sel yang Dipisah**

Pada contoh sebelumnya, ketika sel tabel digabung, penomoran pada sel lain tidak berubah. Kali ini, kami membuat tabel biasa (tanpa sel yang digabung) lalu memisah sel (1, 1) untuk menghasilkan tabel khusus. Perhatikan penomoran tabel ini—mungkin terlihat tidak biasa. Namun, itulah cara Microsoft PowerPoint memberi nomor pada sel tabel, dan Aspose.Slides mengikuti perilaku yang sama.

Kode Python berikut mendemonstrasikan perilaku ini:

```python
import aspose.slides as slides

# Buat instance dari kelas Presentation yang mewakili file PPTX.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Tambahkan shape tabel ke slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Pisah sel (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Cetak indeks sel.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Simpan file PPTX ke disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh Python berikut mendemonstrasikan cara mengubah warna latar belakang sel tabel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Buat tabel baru.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Atur warna latar belakang untuk sel.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyisipkan Gambar ke dalam Sel Tabel**

Bagian ini menunjukkan cara menyisipkan gambar ke dalam sel tabel di Aspose.Slides. Ini mencakup penerapan isian gambar pada sel target dan mengonfigurasi opsi tampilan seperti stretch atau tile.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Definisikan array lebar kolom.
1. Definisikan array tinggi baris.
1. Tambahkan tabel ke slide dengan metode [add_table](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_table/) .
1. Muat gambar dari file.
1. Tambahkan gambar ke koleksi gambar presentasi untuk memperoleh objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) .
1. Tetapkan [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) sel tabel menjadi `PICTURE`.
1. Terapkan gambar ke sel tabel dan pilih mode isian (misalnya, `STRETCH`).
1. Simpan presentasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```python
import aspose.slides as slides

# Membuat objek Presentation.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Tambahkan shape tabel ke slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Muat gambar dan tambahkan ke presentasi untuk memperoleh PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Terapkan gambar ke sel tabel pertama.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Simpan presentasi ke disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menetapkan ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [atas](https://reference.aspose.com/slides/id/python-net/aspose.slides/cellformat/border_top/)/[bawah](https://reference.aspose.com/slides/id/python-net/aspose.slides/cellformat/border_bottom/)/[kiri](https://reference.aspose.com/slides/id/python-net/aspose.slides/cellformat/border_left/)/[kanan](https://reference.aspose.com/slides/id/python-net/aspose.slides/cellformat/border_right/) memiliki properti terpisah, sehingga ketebalan dan gaya masing‑masing sisi dapat berbeda. Ini secara logis mengikuti kontrol batas per sisi untuk sebuah sel yang dijelaskan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [mode isian](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan diri dengan sel baru; dengan tile, ubin-ubin dihitung ulang. Artikel menyebutkan mode tampilan gambar dalam sel.

**Apakah saya dapat menambahkan hyperlink ke seluruh konten sebuah sel?**

[Hyperlinks](/slides/id/python-net/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat menetapkan font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) (run) dengan format independen—jenis font, gaya, ukuran, dan warna.