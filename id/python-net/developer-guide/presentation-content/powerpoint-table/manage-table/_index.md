---
title: Kelola Tabel Presentasi dengan Python
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/python-net/manage-table/
keywords:
- tambah tabel
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
description: "Buat & edit tabel dalam slide PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Temukan contoh kode sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint mengatur informasi menjadi baris dan kolom, sehingga lebih mudah dibaca dan membandingkan nilai.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) dan [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) serta tipe lain untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Membuat Tabel dari Awal**

Buat tabel dengan menentukan posisi, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat batas sel, menggabungkan sel, dan memasukkan teks.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Definisikan daftar lebar kolom dalam poin.
4. Definisikan daftar tinggi baris dalam poin.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ke slide melalui metode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Iterasi melalui setiap [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses sel yang digabungkan melalui properti [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Atur teks dalam sel yang digabungkan.
10. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada titik (100, 50). Tabel tersebut memiliki batas merah dengan lebar 5 poin, menggabungkan dua sel pertama pada baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel berbasis nol dan menggunakan urutan (kolom, baris). Sel pertama diindeks sebagai (0, 0). Dalam Python, akses sel dengan `table.rows[row_index][column_index]`; indeks baris berada di posisi pertama dalam ekspresi ini.

Sebagai contoh, sel‑sel dalam tabel dengan 4 kolom dan 4 baris dinomori sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang diilustrasikan di atas, dengan lebar kolom dan tinggi baris masing‑masing 70 poin serta batas sel merah dengan lebar 5 poin. Koordinat menggambarkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Tabel yang Sudah Ada**

Tabel disimpan dalam koleksi shape slide. Iterasi melalui shape untuk menemukan tabel, lalu gunakan kelas [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) untuk membaca atau memperbarui sel‑nya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi melalui objek [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) dan hentikan ketika tabel ditemukan. Jika slide berisi beberapa tabel, gunakan [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) untuk mengidentifikasi tabel yang dibutuhkan.
4. Perbarui teks pada sel target.
5. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia mengatur sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom serta dua baris.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Untuk mengubah ukuran baris dalam tabel yang sudah ada dan memahami mengapa tinggi sebenarnya dapat melebihi minimum yang diminta, lihat [Control Row Height](/slides/id/python-net/manage-rows-and-columns/#control-row-height).

## **Menemukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) dari tabel, gunakan properti [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) untuk memperoleh [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) pemiliknya. Untuk text frame sel tabel, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) diatur dan [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) bernilai `None`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui properti hanya‑baca [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) dan [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) juga hanya‑baca: ia memberikan navigasi ke pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan bernilai `None` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-net/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

Anda dapat mengontrol penempatan vertikal dan arah teks sel tabel secara individual. Contoh pada bagian ini menengahkan teks dalam sel pertama dan memutarnya sebesar 270 derajat.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) pertama dan atur teks serta warnanya.
6. Atur [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) dan [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) sel.
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks di sel (0, 0), menambahkan nilai ke sel‑sel lainnya pada baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menerapkan Pemformatan Teks pada Tingkat Tabel**

Gunakan [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) untuk menerapkan pemformatan teks ke semua sel dalam sebuah tabel. Overload‑nya menerima pemformatan bagian, paragraf, dan text frame, sehingga Anda dapat mengatur properti tersebut tanpa harus iterasi satu per satu.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) dari slide.
4. Atur [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) untuk teks.
5. Atur [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) dan [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Atur [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mengatur ukuran font menjadi 25 poin, meratakan paragraf ke kanan dengan margin kanan 20 poin, dan membuat teks menjadi vertikal. Presentasi yang telah diformat disimpan sebagai `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) untuk membaca atau menetapkan gaya preset tabel. Contoh ini menerapkan [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) pada satu tabel, mencetak nama preset, dan menetapkan preset yang sama ke tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek tabel adalah perbandingan antara lebar dan tinggi tabel. Gunakan [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) untuk mengunci rasio ini pada tabel.

Contoh di bawah ini membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mencetak status kunci saat ini, mengaktifkan penguncian rasio aspek, mencetak status yang diperbarui (`True`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan‑ke‑kiri (RTL) untuk seluruh tabel dan teks di dalam sel‑nya?**

Ya. Tabel memiliki properti [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), dan paragraf memiliki [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Menggunakan keduanya memastikan urutan RTL yang benar serta rendering di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/python-net/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah memasukkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).