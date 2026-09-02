---
title: Kelola Tabel Presentasi dengan Python
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/python-net/manage-table/
keywords:
- tambahkan tabel
- buat tabel
- akses tabel
- rasio aspek
- menyelaraskan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Buat & edit tabel di slide PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Temukan contoh kode sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint adalah cara yang efisien untuk menyajikan informasi. Informasi yang disusun dalam kisi sel (baris dan kolom) bersifat langsung dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/), kelas [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/) , dan tipe terkait lainnya untuk membantu Anda membuat, memperbarui, dan mengelola tabel dalam presentasi apa pun.

## **Membuat Tabel dari Awal**

Bagian ini menunjukkan cara membuat tabel dari awal di Aspose.Slides dengan menambahkan bentuk tabel ke slide, menentukan baris dan kolomnya, serta mengatur ukuran yang tepat. Anda juga akan melihat cara mengisi sel dengan teks, menyesuaikan perataan dan batas, serta menyesuaikan tampilan tabel.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Definisikan array lebar kolom.
4. Definisikan array tinggi baris.
5. Tambahkan [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) ke slide.
6. Iterasi setiap [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/) dan format batas atas, bawah, kanan, dan kiri.
7. Gabungkan sel pada dua baris pertama dan dua kolom pertama menjadi satu sel.
8. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) sebuah [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/).
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara membuat tabel dalam presentasi:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instansiasi kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Definisikan lebar kolom dan tinggi baris.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Tambahkan bentuk tabel ke slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Atur format batas untuk setiap sel.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Gabungkan sel dari (baris 0, kolom 0) hingga (baris 1, kolom 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Tambahkan teks ke sel yang digabungkan.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Simpan presentasi ke disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Penomoran dalam Tabel Standar**

Pada tabel standar, penomoran sel bersifat langsung dan berbasis nol. Sel pertama dalam tabel diindeks sebagai (0, 0) (kolom 0, baris 0).

Sebagai contoh, pada tabel dengan 4 kolom dan 4 baris, sel-selnya diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh Python berikut menunjukkan cara merujuk sel menggunakan penomoran berbasis nol ini:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tambahkan tabel dengan 4 kolom dan 4 baris.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Tabel yang Sudah Ada**

Bagian ini menjelaskan cara menemukan dan bekerja dengan tabel yang sudah ada dalam presentasi menggunakan Aspose.Slides. Anda akan belajar cara menemukan tabel pada slide, mengakses baris, kolom, dan selnya, serta memperbarui konten atau pemformatan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi semua objek [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) hingga menemukan tabel.
4. Gunakan objek [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) untuk bekerja dengan tabel.
5. Simpan presentasi yang telah dimodifikasi.

{{% alert color="info" title="Catatan" %}}
Jika slide berisi beberapa tabel, sebaiknya cari tabel yang dibutuhkan berdasarkan properti `alternative_text`‑nya.
{{% /alert %}}

Contoh Python berikut menunjukkan cara mengakses dan bekerja dengan tabel yang sudah ada:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instansiasi kelas Presentation untuk memuat file PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    table = None

    # Iterasi melalui shape dan referensikan tabel pertama yang ditemukan.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Atur teks sel pertama pada baris pertama.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Simpan presentasi yang dimodifikasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menemukan Sel yang Memiliki Bingkai Teks**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) dari tabel, gunakan properti [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) untuk mendapatkan [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/) pemiliknya. Untuk bingkai teks sel tabel, [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) diatur dan [TextFrame.parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/) bernilai `None`, meskipun tabel itu sendiri merupakan sebuah shape.

Koordinat sel tersedia melalui properti hanya-baca [Cell.first_column_index](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/first_column_index/) dan [Cell.first_row_index](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) juga hanya-baca: memberikan navigasi ke pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan bernilai `None` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-net/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

Bagian ini menunjukkan cara mengontrol penempatan teks di dalam sel tabel menggunakan Aspose.Slides. Anda akan belajar cara menambatkan teks secara vertikal dalam sel dan mengubah arah penulisan teks.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) ke slide.
4. Akses objek [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/) dari tabel.
5. Pusatkan teks secara vertikal dalam sel dan atur arah teks.
6. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara menyelaraskan teks dalam tabel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Buat instance kelas Presentation.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Definisikan lebar kolom dan tinggi baris.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Tambahkan bentuk tabel ke slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Pusatkan teks dan atur orientasi vertikal.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Simpan presentasi ke disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Pemformatan Teks pada Tingkat Tabel**

Bagian ini menunjukkan cara menerapkan pemformatan teks pada tingkat tabel di Aspose.Slides sehingga setiap sel mewarisi gaya yang konsisten dan seragam. Anda akan belajar cara mengatur ukuran font, perataan, dan margin secara global.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) ke slide.
4. Atur ukuran font (tinggi font) untuk teks.
5. Atur perataan paragraf dan margin.
6. Atur orientasi teks vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Membuat instance kelas Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Atur ukuran font untuk semua sel tabel.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Atur teks rata kanan dan margin kanan untuk semua sel tabel.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Atur orientasi teks vertikal untuk semua sel tabel.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menerapkan Gaya Tabel Bawaan**

Aspose.Slides memungkinkan Anda memformat tabel menggunakan gaya bawaan yang sudah ditentukan langsung dalam kode. Contoh ini memperlihatkan pembuatan tabel, penerapan gaya bawaan, dan penyimpanan hasilnya—cara efisien untuk memastikan pemformatan yang konsisten dan profesional.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek sebuah shape adalah perbandingan dimensinya. Aspose.Slides menyediakan properti `aspect_ratio_locked`, yang memungkinkan Anda mengunci rasio aspek untuk tabel dan shape lainnya.

Contoh Python berikut menunjukkan cara mengunci rasio aspek untuk tabel:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan‑ke‑kiri (RTL) untuk seluruh tabel dan teks dalam selnya?**

Ya. Tabel memiliki properti [right_to_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/right_to_left/), dan paragraf memiliki [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/right_to_left/). Menggunakan keduanya memastikan urutan RTL yang benar dan render yang tepat di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/python-net/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah dukungan menyisipkan gambar di dalam sel sebagai latar belakang?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).