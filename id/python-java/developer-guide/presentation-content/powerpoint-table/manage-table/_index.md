---
title: Kelola Tabel Presentasi di Python
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/python-java/manage-table/
keywords:
- tambahkan tabel
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
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk Python melalui Java. Temukan contoh kode sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint adalah cara yang efisien untuk menampilkan informasi. Informasi dalam susunan sel (diatur dalam baris dan kolom) bersifat langsung dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) kelas [Cell](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/) dan tipe lainnya yang memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam semua jenis presentasi.

## **Membuat Tabel dari Awal**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan daftar lebar kolom.
4. Tentukan daftar tinggi baris.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addTable) .
6. Iterasi setiap [Cell](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/) untuk menerapkan format pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) dari sebuah [Cell](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/) .
9. Tambahkan beberapa teks ke [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) .
10. Simpan presentasi yang telah dimodifikasi.

Kode Python ini menunjukkan cara membuat tabel dalam sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Membuat instance kelas Presentation yang mewakili file PPTX
presentation = Presentation()
try:

    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Menambahkan shape tabel ke slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Mengatur format batas untuk setiap sel
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

    # Menggabungkan sel 1 & 2 pada baris 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Menambahkan teks ke sel yang digabungkan
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Menyimpan presentasi ke Disk
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat langsung dan berbasis nol. Sel pertama dalam tabel memiliki indeks 0,0 (kolom 0, baris 0).

Sebagai contoh, sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode Python ini menunjukkan cara membuat tabel dengan penomoran sel standar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Membuat instance kelas Presentation yang mewakili file PPTX
presentation = Presentation()
try:

    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Menambahkan shape tabel ke slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Mengatur format batas untuk setiap sel
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

    # Menyimpan presentasi ke disk
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengakses Tabel yang Ada**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya.
3. Inisialisasi variabel untuk objek [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) dan setel ke `None` .
4. Iterasi semua objek [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) hingga tabel ditemukan.

   Jika Anda menduga slide yang sedang Anda kerjakan berisi satu tabel, Anda dapat memeriksa semua shape yang ada. Ketika sebuah shape diidentifikasi sebagai tabel, Anda dapat menggunakannya sebagai objek [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) . Tetapi jika slide yang Anda kerjakan berisi beberapa tabel, maka lebih baik mencari tabel yang Anda butuhkan melalui [getAlternativeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText) .

5. Gunakan objek [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) untuk bekerja dengan tabel. Dalam contoh di bawah, kami memperbarui teks di kolom pertama baris kedua.
6. Simpan presentasi yang telah dimodifikasi.

Kode Python ini menunjukkan cara mengakses dan bekerja dengan tabel yang ada:

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Membuat instance kelas Presentation yang mewakili file PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Menginisialisasi referensi tabel.
    table = None

    # Mengiterasi shape dan mengatur referensi ke tabel yang ditemukan
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Mengatur teks untuk kolom pertama baris kedua
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Menyimpan presentasi yang dimodifikasi ke disk
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) dari sebuah tabel, gunakan metode [TextFrame.getParentCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentCell) untuk mendapatkan [Cell](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/) pemiliknya. Untuk text frame sel tabel, [TextFrame.getParentCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentCell) mengembalikan pemilik dan [TextFrame.getParentShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentShape) mengembalikan `None`, meskipun tabel itu sendiri merupakan sebuah shape.

Koordinat sel tersedia melalui metode read‑only [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/#getFirstColumnIndex) dan [Cell.getFirstRowIndex](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/#getFirstRowIndex) . [TextFrame.getParentCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentCell) juga memberikan navigasi read‑only: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan bernilai `None` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-java/search-and-replace-text/) .

## **Menyelaraskan Teks dalam Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) dari objek [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) .
6. Selaraskan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Kode Python ini menunjukkan cara menyelaraskan teks dalam tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Membuat instance kelas Presentation
presentation = Presentation()
try:

    # Mendapatkan slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Menambahkan shape tabel ke slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Mengakses text frame
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Mengakses paragraf pertama dalam text frame.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Mengakses bagian pertama dalam paragraf.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Menyelaraskan teks secara vertikal
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Menyimpan presentasi ke disk
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Pemformatan Teks pada Tingkat Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) dari slide.
4. Setel tinggi font teks dengan [setFontHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setFontHeight) .
5. Setel perataan dan margin kanan dengan [setAlignment](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setAlignment) dan [setMarginRight](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. Setel tipe teks vertikal dengan [setTextVerticalType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. Simpan presentasi yang telah dimodifikasi.

Kode Python ini menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Membuat instance kelas Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Mari asumsikan bahwa shape pertama pada slide pertama adalah tabel
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Mengatur tinggi font sel tabel
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Mengatur perataan teks sel tabel dan margin kanan dalam satu pemanggilan
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Mengatur tipe teks vertikal sel tabel
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Mendapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode Python ini menunjukkan cara mendapatkan properti gaya dari gaya tabel preset:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # ubah tema preset gaya default

    # Mendapatkan preset gaya tabel
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Menerapkan preset gaya yang diambil ke tabel lain
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek dari sebuah bentuk geometris adalah perbandingan ukurannya dalam dimensi yang berbeda. Aspose.Slides menyediakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) untuk memungkinkan Anda mengunci pengaturan rasio aspek untuk tabel dan bentuk lainnya.

Kode Python ini menunjukkan cara mengunci rasio aspek untuk tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # balik
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan‑ke‑kiri (RTL) untuk seluruh tabel dan teks di dalam selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/#setRightToLeft) , dan paragraf memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setRightToLeft) . Menggunakan keduanya memastikan urutan RTL yang benar serta rendering yang tepat di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/python-java/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku pada tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).