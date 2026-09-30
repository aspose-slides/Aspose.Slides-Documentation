---
title: Kelola Tabel Presentasi dalam Python
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/python-java/manage-table/
keywords:
- menambah tabel
- buat tabel
- akses tabel
- rasio aspek
- menyelaraskan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk Python via Java. Temukan contoh kode sederhana untuk menyederhanakan alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint mengatur informasi ke dalam baris dan kolom, sehingga lebih mudah dibaca dan membandingkan nilai.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) dan [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) serta tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Membuat Tabel dari Awal**

Buat tabel dengan menentukan posisinya, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat batas sel, menggabungkan sel, dan menyisipkan teks.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan daftar lebar kolom dalam poin.
4. Tentukan daftar tinggi baris dalam poin.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ke slide melalui metode [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Iterasi melalui setiap [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses sel yang digabung melalui metode [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Atur teks dalam sel yang digabung.
10. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada posisi (100, 50) poin. Ia menerapkan batas merah dengan lebar 5 poin, menggabungkan dua sel pertama pada baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel dimulai dari nol dan menggunakan urutan (kolom, baris). Sel pertama memiliki indeks (0, 0).

Sebagai contoh, sel-sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang ditampilkan di atas, dengan lebar kolom dan tinggi baris masing-masing 70 poin serta batas sel merah dengan lebar 5 poin. Koordinat menunjukkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengakses Tabel yang Sudah Ada**

Tabel disimpan dalam koleksi bentuk (shape) slide. Iterasi melalui bentuk-bentuk untuk menemukan tabel, kemudian gunakan kelas [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) untuk membaca atau memperbarui sel-selnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi melalui objek [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) dan berhenti saat menemukan tabel. Jika slide berisi beberapa tabel, gunakan [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) untuk mengidentifikasi yang Anda perlukan.
4. Perbarui teks dalam sel target.
5. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia mengatur sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom dan dua baris.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk mengubah ukuran baris dalam tabel yang ada dan memahami mengapa tinggi aktualnya dapat melebihi minimum yang diminta, lihat [Control Row Height](/slides/id/python-java/manage-rows-and-columns/#control-row-height).

## **Menemukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) dari tabel, gunakan metode [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) untuk mengambil [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) pemiliknya. Untuk text frame sel tabel, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) mengembalikan pemilik dan [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) mengembalikan `None`, meskipun tabel itu sendiri merupakan sebuah shape.

Koordinat sel tersedia melalui metode baca-saja [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) dan [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) juga menyediakan navigasi baca-saja: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan bernilai `None` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-java/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

Anda dapat mengontrol penambatan vertikal dan arah teks sel tabel secara individual. Contoh pada bagian ini menengahkan teks dalam sel pertama dan memutarnya sebesar 270 derajat.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) pertama dan atur teks serta warnanya.
6. Atur penambatan vertikal sel dan arah teks menggunakan [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) dan [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks dalam sel (0, 0), menambahkan nilai ke sel-sel lain pada baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menetapkan Pemformatan Teks pada Tingkat Tabel**

Gunakan [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) untuk menerapkan pemformatan teks ke semua sel dalam tabel. Overload‑nya menerima pemformatan bagian, paragraf, dan text frame, sehingga Anda dapat mengatur properti tersebut tanpa iterasi melalui tiap sel.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) dari slide.
4. Atur ukuran font menggunakan [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) untuk teks.
5. Atur perataan paragraf dan margin kanan menggunakan [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) dan [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Atur arah teks menggunakan [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mengatur ukuran font menjadi 25 poin, meratakan kanan paragraf dengan margin kanan 20 poin, dan membuat teks menjadi vertikal. Presentasi yang telah diformat disimpan sebagai `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) untuk membaca gaya preset tabel dan [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) untuk menentukannya. Contoh ini menerapkan [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) ke satu tabel, mencetak nilai preset, dan menetapkan preset yang sama ke tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek tabel adalah perbandingan lebar dengan tinggi. Gunakan [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) untuk mengunci rasio ini pada tabel.

Contoh di bawah ini membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mencetak status kunci saat ini, mengaktifkan kunci rasio aspek, mencetak status yang diperbarui (`True`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks dalam selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), dan paragraf memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Menggunakan keduanya memastikan urutan RTL yang benar serta rendering di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/python-java/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) untuk sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).