---
title: Kelola Sel Tabel dalam Presentasi dengan Python
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/python-net/manage-cells/
keywords:
- sel tabel
- gabungkan sel
- hapus batas
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola sel tabel PowerPoint di Python: identifikasi sel yang digabung, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda untuk mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, menangani penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh‑contoh menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui pemformatan sel melalui properti sel, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol. Koordinat dalam artikel ini ditulis sebagai `(kolom, baris)`.

## **Mengidentifikasi Sel Tabel yang Digabung**

Contoh ini membuka presentasi yang sudah ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Contoh ini mengasumsikan bahwa slide dan bentuk tersebut ada serta bentuknya merupakan tabel. Kemudian contoh ini mengiterasi semua baris dan kolom serta menggunakan [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) untuk mengidentifikasi sel dalam wilayah yang digabung. Untuk setiap kecocokan, contoh ini mencetak koordinat sel dalam urutan `baris;kolom`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), dan koordinat awal wilayah, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) serta [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Menghapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan tambahkan tabel ke slide pertama dengan [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini mengatur semua empat batas sel ke [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), sehingga tidak terlihat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Menggabungkan Sel Tabel**

Gunakan [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) untuk menggabungkan rentang sel tabel berbentuk persegi panjang menjadi satu sel. Tentukan sel pada sudut kiri‑atas dan kanan‑bawah rentang tersebut. Argumen terakhir mengendalikan apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `False` menjaga penggabungan tetap berada di dalam rentang itu.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris berukuran 70 poin, lalu menggabungkan empat sel pusat dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan mencakup dua kolom dan dua baris, sementara kisi‑kisi dasar tabel tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau pemformatan sel yang digabung, gunakan posisi kiri‑atasnya: `table.rows[1][1]` dalam contoh ini. Posisi lain dalam rentang yang digabung tetap menjadi bagian dari kisi‑kisi tabel, sehingga indeks sel di luar rentang tidak berubah.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Membagi Sel Tabel**

Menggabungkan sel pada contoh sebelumnya mempertahankan kisi‑kisi tabel. Membagi sebuah sel dapat memperkenalkan kolom kisi baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model kisi tabel PowerPoint.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris berukuran 70 poin dan memanggil [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar yang sama.

Setelah pembagian ini, dua bagian dapat diakses sebagai `table.rows[1][1]` dan `table.rows[1][2]`. Kisi‑kisi tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4, masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang telah diperbarui saat mengakses sel setelah pembagian.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Membagi Sel Tabel yang Digabung Berdasarkan Baris atau Kolom**

Untuk menyiapkan sel template yang digabung agar dapat diisi data, gunakan [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) untuk memisahkan berdasarkan batas baris yang ada, atau [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) untuk memisahkan berdasarkan batas kolom.

Argumen `index` menghitung baris pada bagian atas atau kolom pada bagian kiri dari pembagian; argumen ini relatif terhadap wilayah yang digabung:

- Pembagian baris: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Pembagian kolom: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Contoh ini mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabung secara vertikal. Dimulai dari posisi bawah, contoh ini menggunakan [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) dan [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) untuk menemukan asal dan memeriksa kedua rentang. `split_by_row_span` dengan indeks 1 kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom secara horizontal, gunakan `split_by_col_span` dengan indeks 1 sebagai gantinya.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Dapatkan sel hasil dari tabel setelah pemisahan.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Kisi‑kisi tabel dan indeks sel di sekitarnya tetap tidak berubah. Dapatkan sel‑sel yang dihasilkan dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) mencetak `False`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pembagian.

Teks asli dan pemformatannya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi pemformatan sel seperti isi, batas, dan margin. Isi sel‑sel tersebut setelah pemisahan dan tetapkan semua pemformatan teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel “Product A” dan “Product B” terpisah dengan pemformatan sel dari template tetap terjaga. Lihat [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) untuk detail.

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom berukuran 150 poin dan baris berukuran 50 poin. Contoh ini mengatur [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) menjadi padat dan [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) menjadi merah untuk sel `(2, 3)`, yaitu kolom ketiga dan baris keempat.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Menambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Contoh ini memuat gambar dengan [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) dan menambahkannya ke koleksi gambar presentasi dengan [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Selanjutnya contoh ini menetapkan gambar ke isian gambar sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat secara otomatis dibebaskan ketika blok `with` selesai.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk masing‑masing sisi sel?**

Ya. Batas [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku bergantung pada [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan dengan sel yang baru; dengan tile, ubin‑ubin dihitung ulang.

**Bisakah saya menetapkan hyperlink ke seluruh konten sebuah sel?**

[Hyperlinks](/slides/id/python-net/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke sebuah bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (run) dengan pemformatan independen—familik font, gaya, ukuran, dan warna.