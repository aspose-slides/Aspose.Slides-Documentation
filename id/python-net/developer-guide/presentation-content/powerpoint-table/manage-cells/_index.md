---
title: Mengelola Sel Tabel dalam Presentasi dengan Python
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
description: "Kelola sel tabel PowerPoint dengan Python: identifikasi sel yang digabungkan, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk Python via .NET."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisah sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui pemformatan sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol. Koordinat dalam artikel ini dituliskan sebagai `(kolom, baris)`.

## **Identifikasi Sel Tabel yang Digabungkan**

Contoh membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Contoh mengasumsikan bahwa slide dan bentuk ada serta bentuk tersebut adalah tabel. Selanjutnya iterasi melalui semua baris dan kolom dan menggunakan [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) untuk mengidentifikasi sel dalam wilayah yang digabungkan. Untuk setiap kecocokan, contoh mencetak koordinat sel dalam urutan `baris;kolom`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), dan koordinat awal wilayah, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) serta [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

## **Hapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh mengatur keempat batas sel menjadi [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), sehingga tidak terlihat.

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

## **Tambahkan Batas Diagonal Sel**

Gunakan [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) untuk menggambar garis dari sudut kiri atas ke sudut kanan bawah, dan [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) untuk menggambar garis dari sudut kiri bawah ke sudut kanan atas. Diagonal dapat menandai header sudut; kedua diagonal dapat membentuk X untuk menandai sel tidak berlaku.

Setiap diagonal adalah sebuah [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). Pada [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/)-nya, atur [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) menjadi [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) dan pilih sebuah [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Atur [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) garis dalam poin.

Contoh membuat tiga sel dalam satu baris: diagonal turun berwarna merah, diagonal naik berwarna biru, dan kedua diagonal. Batas atas, bawah, kiri, dan kanan sel tetap tidak berubah.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Diagonal adalah properti pemformatan, bukan pemisahan sel. Setiap sel tetap memiliki satu [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); wilayah di kedua sisi diagonal tidak dapat diedit secara terpisah.

Tabel yang disimpan, ditampilkan di Microsoft PowerPoint:

![Tiga sel tabel menunjukkan diagonal merah dari kiri atas ke kanan bawah, diagonal biru dari kiri bawah ke kanan atas, dan kedua diagonal membentuk X.](diagonal-cell-borders.png)

*Dari kiri ke kanan: diagonal turun (merah, 3 pt), diagonal naik (biru, 5 pt), dan kedua diagonal.*

## **Gabungkan Sel Tabel**

Gunakan [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) untuk menggabungkan rentang sel tabel berbentuk persegi panjang menjadi satu sel. Tentukan sel pada sudut kiri atas dan kanan bawah rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `False` menjaga penggabungan tetap dalam rentang tersebut.

Contoh membuat tabel 4x4 dengan kolom dan baris berukuran 70 poin, kemudian menggabungkan empat sel pusat dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan mencakup dua kolom dan dua baris, sementara grid tabel yang mendasarinya tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau pemformatan sel yang digabungkan, gunakan posisi kiri atasnya: `table.rows[1][1]` dalam contoh ini. Posisi lain dalam rentang yang digabungkan tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

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

## **Pisahkan Sel Tabel**

Penggabungan sel pada contoh sebelumnya mempertahankan grid tabel. Memisahkan sel dapat memperkenalkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4x4 dengan kolom dan baris berukuran 70 poin dan memanggil [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar sama.

Setelah pemisahan ini, dua bagian diakses sebagai `table.rows[1][1]` dan `table.rows[1][2]`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4 masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang telah diperbarui saat mengakses sel setelah pemisahan.

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

<!-- visual-explanation:manage-cells:start -->
[![Sel 70‑poin yang belum digabungkan terpisah menjadi dua sel 35‑poin, menambahkan kolom grid kelima dan menggeser indeks ke kanan.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Pemecahan lebar memengaruhi sel (1, 1), menggunakan indeks berbasis nol (kolom, baris). Baris lain tetap memiliki sel yang membentang kedua posisi kolom baru.*
<!-- visual-explanation:manage-cells:end -->

### **Pisahkan Sel yang Digabungkan berdasarkan Rentang Baris atau Kolom**

Untuk menyiapkan sel templat yang digabungkan sebelum mengisi data, gunakan [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) untuk memisahkan sepanjang batas baris yang ada, atau [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) untuk memisahkan sepanjang batas kolom.

Argumen `index` menghitung baris pada bagian atas atau kolom pada bagian kiri dari pemisahan; relatif terhadap wilayah yang digabungkan:

- Pemisahan baris: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Pemisahan kolom: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Contoh mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabungkan secara vertikal. Mulai dari posisi bawah, contoh menggunakan [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) dan [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) untuk menemukan asal dan memeriksa kedua rentang. `split_by_row_span` dengan indeks 1 kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom secara horizontal, gunakan `split_by_col_span` dengan indeks 1 sebagai gantinya.

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

        # Dapatkan sel yang dihasilkan dari tabel setelah pemisahan.
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

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Dapatkan sel hasilnya melalui koordinatnya; di sini, keduanya memiliki rentang 1 dan [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) mencetak `False`. Wilayah yang lebih besar dapat tetap sebagian tergabung setelah satu pemisahan.

Teks asli dan pemformatannya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi pemformatan sel seperti isian, batas, dan margin. Isi sel setelah dipisah dan atur pemformatan teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel “Product A” dan “Product B” terpisah dengan pemformatan sel templat yang dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) untuk detail.

### **Pisahkan Sel pada Tinggi Tertentu**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) menerima tinggi bagian atas dalam poin. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) menerima jumlah baris grid yang ada di bagian atas. Untuk menempatkan sel 40 poin secara vertikal di tengah kolom kanan, kurangi 40 dari tinggi sel aktual dan bagi sisa ruang secara merata di atas dan di bawahnya.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Pemecahan pertama menambahkan baris grid, meninggalkan 90 poin di `table.rows[1][1]`. Pemecahan kedua membagi sel itu menjadi sel tengah 40 poin dan sel bawah 50 poin. Tiga sel di kolom kanan kini memiliki tinggi 50, 40, dan 50 poin dari atas ke bawah. Sel kiri membentang ketiga baris dengan tinggi aslinya 140 poin.

![Sel kiri membentang seluruh tinggi tabel di samping tiga sel dengan “Middle” di tengah.](split-by-height.png)

## **Ubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia mengatur [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) menjadi solid dan [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) menjadi merah untuk sel `(2, 3)`, pada kolom ketiga dan baris keempat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Contoh memuat gambar dengan [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) dan menambahkannya ke koleksi gambar presentasi dengan [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Kemudian gambar tersebut diberikan ke isian gambar sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) meregangkan gambar untuk mengisi sel, yang dapat mengubah rasio aspek. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat secara otomatis dibuang saat blok `with` berakhir.

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

**Apakah saya dapat mengatur ketebalan garis dan gaya yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) memiliki properti terpisah, sehingga ketebalan dan gaya masing‑masing sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Dengan peregangan, gambar menyesuaikan dengan sel baru; dengan ubin, ubin‑ubin dihitung ulang.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/python-net/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian atau ke semua teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (run) dengan pemformatan independen—jenis font, gaya, ukuran, dan warna.