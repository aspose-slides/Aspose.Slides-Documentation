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
- kloning baris
- kloning kolom
- menyalin baris
- menyalin kolom
- menghapus baris
- menghapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola baris dan kolom tabel di PowerPoint dengan Aspose.Slides untuk Python via .NET dan percepat pengeditan presentasi serta pembaruan data."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET memungkinkan Anda mengelola struktur dan pemformatan tabel dalam presentasi PowerPoint melalui kelas [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Anda dapat menentukan baris header, menggandakan atau menghapus baris dan kolom, serta menerapkan pemformatan teks ke seluruh baris atau kolom.

Artikel ini menjelaskan operasi tersebut dengan contoh Python. Artikel ini juga menunjukkan cara mengambil preset gaya tabel sehingga Anda dapat menggunakannya kembali. Indeks baris dan kolom tabel berawal dari nol.

## **Mengontrol Tinggi Baris**

Gunakan [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) untuk mengatur tinggi minimum baris dalam poin. Itu adalah batas bawah, bukan tinggi tetap. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) mengembalikan tinggi aktual dan bersifat read‑only. Akses baris melalui [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Contoh ini memuat [row-height-input.pptx](row-height-input.pptx), yang memiliki tabel sebagai bentuk pertama pada slide pertama. Baris pertamanya dimulai pada 70 poin. Sel-selnya menggunakan teks Arial 18 poin, dengan pembungkusan, dan margin atas serta bawah 6 poin; teks yang lebih panjang di kolom kedua terbungkus menjadi beberapa baris. Contoh ini meningkatkan minimum menjadi 100 poin, kemudian menurunkannya menjadi 20 poin, mencetak tinggi aktual setelah setiap perubahan, dan menyimpan kedua hasil.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Dengan presentasi yang disertakan, meningkatkan minimum menambahkan ruang pada baris. Menurunkannya menghapus ruang ekstra tersebut, tetapi tinggi aktual tetap lebih besar dari 20 poin karena teks dan margin sel membutuhkan lebih banyak ruang. Mengurangi minimum saja tidak dapat memaksa baris berada di bawah ruang yang diperlukan oleh isinya.

Beberapa faktor memengaruhi tinggi aktual:

- **Teks dan ukuran font:** teks yang lebih panjang, jeda baris eksplisit, atau font yang lebih besar dapat memerlukan lebih banyak ruang vertikal.
- **Pembungkusan dan lebar kolom:** dengan pembungkusan diaktifkan, [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) yang lebih sempit dapat menghasilkan lebih banyak baris. Kolom yang lebih lebar dapat mengurangi ruang yang dibutuhkan secara vertikal.
- **Margin sel:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) dan [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) menambah ruang vertikal. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) dan [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) mengurangi lebar yang tersedia untuk teks dan dapat menyebabkan pembungkusan tambahan.

Untuk tabel ini tanpa sel yang digabung, sel yang membutuhkan ruang vertikal paling banyak menentukan batas bawah yang dipengaruhi konten untuk seluruh baris. Untuk membuat baris lebih pendek, Anda mungkin juga perlu memendekkan teks, mengurangi ukuran font atau margin, atau memperlebar kolom.

Gambar di bawah menunjukkan tabel yang sama pada skala yang sama. Pada percobaan ini, tinggi aktual adalah 70, 100, dan 55.2 poin: baris terakhir tetap lebih tinggi daripada minimum 20 poin. Pengukuran teks yang tepat dapat bervariasi tergantung pada font yang tersedia di lingkungan Anda. Unduh hasil yang disimpan: [minimum meningkat](row-height-increased.pptx) dan [minimum menurun](row-height-decreased.pptx).

| Asli: minimum 70 pt, aktual 70 pt | Ditambah: minimum 100 pt, aktual 100 pt | Dikurangi: minimum 20 pt, aktual 55.2 pt |
| --- | --- | --- |
| ![Tabel asli dengan baris pertama 70 poin.](row-height-before.png) | ![Tabel setelah meningkatkan minimum baris pertama menjadi 100 poin.](row-height-increased.png) | ![Tabel setelah menurunkan minimum baris pertama menjadi 20 poin; teks yang terbungkus membuat baris lebih tinggi daripada minimum.](row-height-decreased.png) |

## **Menetapkan Baris Pertama sebagai Header**

Gunakan properti [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) untuk menandai baris pertama sebagai format header. Penampilannya tergantung pada gaya tabel yang diterapkan pada tabel.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Akses slide pertama.
3. Akses tabel yang disimpan sebagai bentuk pertama pada slide.
4. Aktifkan format header untuk baris pertamanya.
5. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama. Ia mengaktifkan format header untuk baris pertama dan menyimpan `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Menggandakan Baris atau Kolom Tabel**

Gandakan baris atau kolom untuk menggunakan kembali konten dan pemformatannya. Anda dapat menambahkan salinan ke akhir tabel atau menyisipkannya pada posisi tertentu.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
5. Gandakan baris yang diperlukan.
6. Gandakan kolom yang diperlukan.
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `Test.pptx` dengan setidaknya satu slide. Ia membuat tabel dengan tiga kolom dan lima baris, dengan dimensi yang ditentukan dalam poin. Ia menambahkan salinan baris pertama dan kolom pertama, kemudian menyisipkan salinan baris kedua dan kolom kedua pada indeks 3 (posisi keempat). Tabel yang dihasilkan memiliki tujuh baris dan lima kolom. Argumen `False` menonaktifkan penggandaan ke dalam baris atau kolom yang digabung bersebelahan; tabel ini tidak memiliki sel yang digabung.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menghapus Baris atau Kolom dari Tabel**

Hapus baris atau kolom yang tidak lagi diperlukan dalam sebuah tabel. Menghapus sebuah item menggeser indeks baris atau kolom yang mengikutinya.

1. Buat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
5. Hapus baris kedua dan kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel tiga‑by‑tiga dan menghapus baris serta kolom pada indeks 1, menyisakan tabel dua‑by‑dua di `TestTable_out.pptx`. Dimensi dalam poin. Argumen `False` menonaktifkan penghapusan baris atau kolom yang digabung bersebelahan; tabel ini tidak memiliki sel yang digabung.

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

## **Mengatur Pemformatan Teks pada Tingkat Baris Tabel**

Terapkan pemformatan teks ke seluruh baris untuk menjaga konsistensi sel-selnya. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Akses tabel pada slide pertama.
3. Atur [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) untuk baris pertama.
4. Atur [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) dan [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) untuk baris pertama.
5. Atur [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) untuk baris kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua baris. Ia menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada baris pertama, kemudian mengatur teks vertikal pada baris kedua.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Pemformatan Teks pada Tingkat Kolom Tabel**

Terapkan pemformatan teks ke seluruh kolom untuk menjaga konsistensi sel-selnya. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Akses tabel pada slide pertama.
3. Atur [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) untuk kolom pertama.
4. Atur [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) dan [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) untuk kolom pertama.
5. Atur [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) untuk kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua kolom. Ia menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada kolom pertama, kemudian mengatur teks vertikal pada kolom kedua.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan properti [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) untuk mengambil preset yang diterapkan pada sebuah tabel dan menggunakannya kembali pada tabel lain. Ini mengidentifikasi preset alih-alih penimpaan pemformatan sel individual.

Contoh ini membuat sebuah tabel, menerapkan [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), dan membaca kembali preset tersebut. Ia mencetak `True` ketika preset yang diambil cocok dengan preset yang diterapkan dan menyimpan tabel dalam `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bisakah saya menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda tetap dapat menimpa isi, tepi, dan warna teks di atas tema tersebut.

**Bisakah saya mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, kemudian isi kembali baris tabel sesuai urutan tersebut.

**Bisakah saya memiliki kolom berpita (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom berpita, kemudian timpa sel tertentu dengan pemformatan lokal; pemformatan tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.