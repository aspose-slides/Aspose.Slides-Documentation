---
title: Kelola Sel Tabel dalam Presentasi Menggunakan Python
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/python-java/manage-cells/
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
description: "Kelola sel tabel PowerPoint dalam Python: identifikasi sel yang digabung, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk Python melalui Java."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui pemformatan sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(column, row)`.

## **Mengidentifikasi Sel Tabel yang Digabung**

Contoh ini membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Ia mengasumsikan bahwa slide dan bentuk tersebut ada serta bentuknya adalah tabel. Selanjutnya ia mengulangi semua baris dan kolom dan menggunakan [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) untuk mengidentifikasi sel dalam wilayah yang digabung. Untuk setiap kecocokan, ia mencetak koordinat sel dalam urutan `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), dan koordinat awal wilayah, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) serta [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Menghapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini mengatur semua empat batas sel ke [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), sehingga menjadi tidak terlihat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menggabungkan Sel Tabel**

Gunakan [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel pada sudut kiri-atas dan kanan-bawah dari rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `False` menjaga penggabungan tetap dalam rentang tersebut.

Contoh ini membuat tabel 4x4 dengan kolom dan baris 70 poin, lalu menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan membentang dua kolom dan dua baris, sementara grid tabel yang mendasarinya tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau pemformatan sel yang digabung, gunakan posisi kiri-atasnya: `table.get_Item(1, 1)` dalam contoh ini. Posisi lain dalam rentang yang digabung tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membagi Sel Tabel**

Menggabungkan sel pada contoh sebelumnya mempertahankan grid tabel. Membagi sebuah sel dapat menambahkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4x4 dengan kolom dan baris 70 poin dan memanggil [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar yang sama.

Setelah pembagian ini, dua bagian tersebut diakses sebagai `table.get_Item(1, 1)` dan `table.get_Item(2, 1)`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4, masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini saat mengakses sel setelah pembagian.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Membagi Sel yang Digabung berdasarkan Rentang Baris atau Kolom**

Untuk menyiapkan sel templat yang digabung untuk pengisian data, gunakan [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) untuk membagi sepanjang batas baris yang ada, atau [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) untuk membagi sepanjang batas kolom.

Argumen `index` menghitung baris pada bagian atas atau kolom pada bagian kiri dari pembagian; ia relatif terhadap wilayah yang digabung:

- Pembagian baris: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Pembagian kolom: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Contoh ini mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabung secara vertikal. Memulai dari posisi bawah, ia menggunakan [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) dan [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) untuk menemukan asal dan memeriksa kedua rentang. `splitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom secara horizontal, gunakan `splitByColSpan(1)` sebagai gantinya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Ambil sel yang dihasilkan dari tabel setelah pemisahan.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel yang dihasilkan dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) mencetak `False`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pembagian.

Teks asli dan pemformatannya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi pemformatan sel seperti isi, batas, dan margin. Isi sel setelah pembagian dan atur pemformatan teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel terpisah “Product A” dan “Product B” dengan pemformatan sel templat tetap dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) untuk detail.

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia menggunakan [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) untuk memilih isian solid dan mengatur warna yang dikembalikan oleh [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) menjadi merah untuk sel `(2, 3)`, yaitu kolom ketiga dan baris keempat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Gambar di Dalam Sel Tabel**

Tempatkan gambar input di direktori kerja sebelum menjalankan contoh ini. Ia memuat gambar dengan [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) dan menambahkannya ke koleksi gambar presentasi dengan [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Kemudian gambar tersebut diberikan ke isian gambar sel `(0, 0)`, sel pertama pada tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang dalam blok `finally` setelah ditambahkan ke presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) memiliki properti terpisah, sehingga ketebalan dan gaya tiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah mengatur gambar sebagai latar belakang sel?**

Perilakunya bergantung pada [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan diri dengan sel yang baru; dengan tile, ubin‑ubin dihitung ulang.

**Apakah saya dapat menugaskan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/python-java/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menugaskan tautan ke sebuah bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (jalur) dengan pemformatan independen—jenis font, gaya, ukuran, dan warna.