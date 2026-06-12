---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan Python
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/python-net/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- gandakan baris
- gandakan kolom
- salin baris
- salin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola baris dan kolom tabel dalam PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET dan percepat penyuntingan presentasi serta pembaruan data."
---
## **Ikhtisar**

Artikel ini menunjukkan cara mengelola baris dan kolom tabel dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python. Anda akan belajar cara menambah, menyisipkan, menggandakan, dan menghapus baris atau kolom, menandai baris pertama sebagai header, menyesuaikan ukuran dan tata letak, serta menerapkan pemformatan teks dan gaya pada tingkat baris atau kolom. Setiap tugas ditunjukkan dengan cuplikan kode yang ringkas dan mandiri berdasarkan API [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/), sehingga Anda dapat dengan cepat menemukan tabel pada slide dan mengubah strukturnya agar sesuai dengan desain Anda.

## **Set the First Row as a Header**

Tandai baris pertama tabel sebagai header untuk membedakan judul kolom dari data dengan jelas. Pada Aspose.Slides untuk Python, cukup aktifkan opsi *First Row* tabel untuk menerapkan pemformatan header yang ditentukan oleh gaya tabel yang dipilih.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi.
1. Akses slide berdasarkan indeksnya.
1. Iterasi semua objek [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) untuk menemukan tabel yang relevan.
1. Setel baris pertama tabel sebagai header.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Iterasi melalui shapes dan dapatkan referensi ke tabel.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Atur baris pertama tabel sebagai header.
    table.first_row = True
    
    # Simpan presentasi ke disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone a Table Row or Column**

Gandakan setiap baris atau kolom tabel dan sisipkan salinannya pada posisi yang diinginkan di dalam tabel. Duplikat tersebut mempertahankan konten sel, pemformatan, dan ukuran, sehingga Anda dapat memperluas tata letak dengan cepat dan konsisten.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi.
1. Akses slide berdasarkan indeksnya.
1. Definisikan array lebar kolom.
1. Definisikan array tinggi baris.
1. Tambahkan sebuah [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) ke slide menggunakan `add_table(x, y, column_widths, row_heights)`.
1. Gandakan sebuah baris tabel.
1. Gandakan sebuah kolom tabel.
1. Simpan presentasi yang telah dimodifikasi.

```python
 import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Definisikan lebar kolom dan tinggi baris.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Tambahkan tabel ke slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Tambahkan teks ke baris 1, kolom 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Tambahkan teks ke baris 2, kolom 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Gandakan baris 1 di akhir tabel.
    table.rows.add_clone(table.rows[0], False)

    # Tambahkan teks ke baris 1, kolom 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Tambahkan teks ke baris 2, kolom 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Gandakan baris 2 sebagai baris ke-4 tabel.
    table.rows.insert_clone(3,table.rows[1], False)

    # Gandakan kolom pertama di akhir.
    table.columns.add_clone(table.columns[0], False)

    # Gandakan kolom kedua pada indeks 3 (posisi ke-4).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Simpan presentasi ke disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Row or Column from a Table**

Permudah tabel dengan menghapus baris atau kolom apa pun berdasarkan indeks menggunakan Aspose.Slides untuk Python—tata letak secara otomatis menyesuaikan kembali sambil mempertahankan pemformatan sel yang tersisa. Ini berguna untuk menyederhanakan grid data atau menghapus placeholder tanpa harus membangun ulang tabel.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi.
1. Akses slide berdasarkan indeksnya.
1. Definisikan array lebar kolom.
1. Definisikan array tinggi baris.
1. Tambahkan sebuah ITable ke slide menggunakan `add_table(x, y, column_widths, row_heights)`.
1. Hapus baris tabel.
1. Hapus kolom tabel.
1. Simpan presentasi yang telah dimodifikasi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Row Level**

Terapkan gaya teks yang konsisten pada seluruh baris tabel dalam satu langkah. Dengan Aspose.Slides untuk Python, Anda dapat mengatur keluarga font, ukuran, ketebalan, warna, dan perataan untuk semua sel dalam baris sekaligus agar judul atau pita data tetap seragam.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi.
1. Akses slide berdasarkan indeksnya.
1. Akses objek [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) yang relevan pada slide.
1. Setel tinggi font untuk sel baris pertama.
1. Setel perataan dan margin kanan untuk sel baris pertama.
1. Setel tipe vertikal teks untuk sel baris kedua.
1. Simpan presentasi yang telah dimodifikasi.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Atur tinggi font untuk sel baris pertama.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Atur perataan teks dan margin kanan untuk sel baris pertama.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Atur tipe vertikal teks untuk sel baris kedua.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Simpan presentasi ke disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Column Level**

Terapkan gaya teks yang konsisten pada seluruh kolom tabel sekaligus. Dengan Aspose.Slides untuk Python, Anda dapat mengatur keluarga font, ukuran, ketebalan, warna, dan perataan untuk semua sel dalam kolom guna menciptakan pita vertikal yang seragam untuk judul atau data.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi.
1. Akses slide berdasarkan indeksnya.
1. Akses objek [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) yang relevan pada slide.
1. Setel tinggi font untuk sel kolom pertama.
1. Setel perataan dan margin kanan untuk sel kolom pertama.
1. Setel tipe vertikal teks untuk sel kolom kedua.
1. Simpan presentasi yang telah dimodifikasi.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Atur tinggi font untuk sel kolom pertama.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Atur perataan teks dan margin kanan untuk sel kolom pertama.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Atur tipe vertikal teks untuk sel kolom kedua.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Simpan presentasi ke disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Table Style Properties**

Aspose.Slides memungkinkan Anda mengambil properti gaya sebuah tabel sehingga dapat digunakan kembali pada tabel lain atau di tempat lain. Kode Python berikut menunjukkan cara mendapatkan properti gaya dari gaya tabel yang sudah ditetapkan:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

Ya. Tabel mewarisi tema slide/tata letak/master, dan Anda tetap dapat menimpa isi, batas, dan warna teks di atas tema tersebut.

**Can I sort table rows like in Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data di memori terlebih dahulu, lalu isi ulang baris tabel sesuai urutan tersebut.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Ya. Aktifkan kolom berjalan bergaris, lalu timpa sel‑sel tertentu dengan pemformatan lokal; pemformatan pada tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.