---
title: Kelola Sel Tabel dalam Presentasi Menggunakan Python
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/python-java/manage-cells/
keywords:
- sel tabel
- gabungkan sel
- hapus border
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dengan mudah menggunakan Aspose.Slides untuk Python via Java. Kuasai cara mengakses, memodifikasi, dan menata sel secara cepat untuk otomatisasi slide yang mulus."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus garis tepi sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mengambil tabel dari slide, memperbarui pemformatan sel melalui properti sel, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

## **Mengidentifikasi Sel Tabel yang Digabungkan**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan tabel dari slide pertama.
3. Iterasi melalui baris dan kolom tabel untuk menemukan sel yang digabungkan.
4. Cetak pesan saat sel yang digabungkan ditemukan.

Kode Python ini menunjukkan cara mengidentifikasi sel tabel yang digabungkan dalam presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Asumsikan bahwa shape pertama pada slide pertama adalah sebuah tabel.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Menghapus Garis Tepi Sel Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan daftar lebar kolom.
4. Tentukan daftar tinggi baris.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addTable) .
6. Iterasi melalui setiap sel untuk menghapus garis tepi atas, bawah, kanan, dan kiri.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python ini menunjukkan cara menghapus garis tepi dari sel tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Tambahkan tabel ke slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Atur format batas untuk setiap sel.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Penomoran pada Sel yang Digabungkan**

Jika kita menggabungkan dua pasangan sel, (1, 1) dan (2, 1), serta (1, 2) dan (2, 2), tabel yang dihasilkan mempertahankan penomoran selnya. Kode Python ini mendemonstrasikan prosesnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Tambahkan tabel ke slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Atur format batas untuk setiap sel.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Gabungkan sel (1, 1) dan (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Gabungkan sel (1, 2) dan (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kemudian kami menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi satu sel besar yang digabungkan di tengahnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Tambahkan tabel ke slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Atur format batas untuk setiap sel.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Gabungkan sel (1, 1) dan (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Gabungkan sel (1, 2) dan (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Gabungkan sel (1, 1) dan (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Penomoran pada Sel yang Dipisah**

Pada contoh sebelumnya, menggabungkan sel tabel tidak mengubah penomoran sel lainnya.

Kali ini, kami mengambil tabel biasa (tabel tanpa sel yang digabungkan) dan kemudian mencoba memisahkan sel (1, 1) untuk mendapatkan tabel khusus. Perhatikan penomoran tabel ini, yang mungkin tampak aneh. Namun, itulah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama.

Kode Python ini mendemonstrasikan proses yang kami jelaskan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Tambahkan tabel ke slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Atur format batas untuk setiap sel.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Pisah sel (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ubah Warna Latar Belakang Sel Tabel**

Kode Python ini menunjukkan cara mengubah warna latar belakang sel tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Tambahkan tabel ke slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Atur warna latar belakang untuk sebuah sel.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Gambar di Dalam Sel Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan daftar lebar kolom.
4. Tentukan daftar tinggi baris.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addTable) .
6. Muat file gambar menggunakan [Images.fromFile](https://reference.aspose.com/slides/id/python-java/aspose.slides/images/#fromFile) .
7. Tambahkan gambar ke presentasi untuk membuat objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) .
8. Atur tipe isian [FillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/fillformat/) sel tabel menjadi [FillType.Picture](https://reference.aspose.com/slides/id/python-java/aspose.slides/filltype/#Picture) .
9. Tambahkan gambar ke sel pertama tabel.
10. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python ini menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tentukan lebar kolom dan tinggi baris.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Tambahkan tabel ke slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Buat gambar presentasi dari file gambar.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Tambahkan gambar ke sel tabel pertama.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan garis dan gaya yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Garis [top](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/id/python-java/aspose.slides/cellformat/#getBorderRight) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda. Ini secara logis mengikuti kontrol garis per sisi untuk sebuah sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku bergantung pada [fill mode](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan dengan sel baru; dengan tile, ubin dihitung ulang. Artikel menyebutkan mode tampilan gambar dalam sel.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sebuah sel?**

[Hyperlinks](/slides/id/python-java/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke sebuah portion atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda di dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) (run) dengan pemformatan independen—familia font, gaya, ukuran, dan warna.