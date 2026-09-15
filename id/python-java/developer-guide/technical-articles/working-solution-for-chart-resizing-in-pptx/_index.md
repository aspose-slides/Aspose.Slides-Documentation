---
title: Solusi Praktis untuk Pengubahan Ukuran Diagram di PPTX
type: docs
weight: 40
url: /id/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- pengubahan ukuran diagram
- diagram Excel
- objek OLE
- sematkan diagram
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Perbaiki pengubahan ukuran diagram yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk Python via Java. Pelajari dua metode dengan kode untuk menjaga ukuran tetap konsisten."
---
## **Latar Belakang**

Terjadi pengamatan bahwa diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose mengalami perubahan ukuran ke skala yang tidak ditentukan setelah aktivasi pertama. Perilaku ini menyebabkan perbedaan visual yang nyata dalam presentasi antara keadaan sebelum dan sesudah aktivasi diagram. Tim Aspose telah menyelidiki masalah ini secara mendetail dan menemukan solusinya. Artikel ini menjelaskan penyebab masalah dan perbaikan yang relevan.

Dalam [artikel sebelumnya](/slides/id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells for Python via Java dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides for Python via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/python-java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke bingkai objek OLE diagram tersebut. Dalam presentasi output, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada buku kerja Excel yang mendasarinya dan kemudian kembali ke slide yang bersangkutan dengan mengklik di luar buku kerja yang diaktifkan. Ukuran bingkai objek OLE berubah saat pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun buku kerja Excel yang disematkan.

## **Penyebab Pengubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Bingkai objek OLE, bagaimanapun, memiliki ukuran sendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran dan menjaga proporsi yang tepat sebagai bagian dari proses penyematan. Bergantung pada perbedaan antara ukuran jendela Excel dan ukuran atau posisi bingkai objek OLE, terjadi pengubahan ukuran.

## **Solusi yang Berfungsi**

Ada dua skenario yang mungkin untuk membuat presentasi PowerPoint menggunakan Aspose.Slides for Python via Java.

**Skenario 1:** Membuat presentasi berdasarkan templat yang sudah ada.

**Skenario 2:** Membuat presentasi dari awal.

Solusi yang kami berikan di sini berlaku untuk kedua skenario. Dasar semua pendekatan solusi adalah sama: **ukuran jendela objek OLE yang disematkan harus cocok dengan bingkai objek OLE di slide PowerPoint**. Kami akan membahas dua pendekatan untuk solusi ini.

## **Pendekatan Pertama**

Dalam pendekatan ini, kami akan mempelajari cara mengatur ukuran jendela buku kerja Excel yang disematkan sehingga cocok dengan ukuran bingkai objek OLE di slide PowerPoint.

**Scenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Asumsikan ada bentuk pada indeks 2 di templat tempat kami ingin menempatkan bingkai OLE yang berisi buku kerja Excel yang disematkan. Pada skenario ini, ukuran bingkai objek OLE telah ditentukan sebelumnya—ukuran ini cocok dengan ukuran bentuk pada indeks 2 di templat. Yang perlu kami lakukan hanyalah menetapkan ukuran jendela buku kerja sama dengan ukuran bentuk tersebut. Potongan kode berikut melayani tujuan ini:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Muat buku kerja Excel yang berisi diagram.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Atur ukuran jendela buku kerja dalam inci (PowerPoint menggunakan 72 titik per inci).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Simpan buku kerja ke aliran memori.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Buat bingkai objek OLE dengan data Excel yang disematkan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Katakanlah kami ingin membuat presentasi dari awal dan menyertakan bingkai objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat bingkai objek OLE setinggi 4 inci dan lebar 9,5 inci pada x = 0,5 inci dan y = 1 inci di slide. Kami kemudian menetapkan jendela buku kerja Excel ke ukuran yang sama—tinggi 4 inci dan lebar 9,5 inci.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Muat buku kerja Excel yang berisi diagram.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inci (4 * 72).
    desired_width = 684  # 9.5 inci (9.5 * 72).

    # Tentukan ukuran diagram dengan jendela.
    chart.setSizeWithWindow(True)

    # Atur ukuran jendela buku kerja dalam inci (PowerPoint menggunakan 72 titik per inci).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Simpan buku kerja ke aliran memori.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Buat bingkai objek OLE dengan data Excel yang disematkan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Pendekatan Kedua**

Dalam pendekatan ini, kami akan mempelajari cara mengatur ukuran diagram di dalam buku kerja Excel yang disematkan sehingga cocok dengan ukuran bingkai objek OLE di slide PowerPoint. Pendekatan ini berguna ketika ukuran diagram sudah diketahui sebelumnya dan tidak akan berubah.

**Scenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Asumsikan ada bentuk pada indeks 2 di templat tempat kami bermaksud menempatkan bingkai OLE yang berisi buku kerja Excel yang disematkan. Pada skenario ini, ukuran bingkai OLE telah ditentukan sebelumnya—cocok dengan ukuran bentuk pada indeks 2 di templat. Yang perlu kami lakukan hanyalah menetapkan ukuran diagram di buku kerja sama dengan ukuran bentuk tersebut. Potongan kode berikut melayani tujuan ini:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Muat buku kerja Excel yang berisi diagram.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Tentukan ukuran diagram tanpa jendela.
    chart.setSizeWithWindow(False)

    # Atur ukuran diagram dalam piksel (Excel menggunakan 96 piksel per inci).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Tentukan ukuran cetak diagram.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Simpan buku kerja ke aliran memori.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Buat bingkai objek OLE dengan data Excel yang disematkan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Misalkan kami ingin membuat presentasi dari awal dan menyertakan bingkai objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat bingkai objek OLE dengan tinggi 4 inci dan lebar 9,5 inci di slide pada x = 0,5 inci dan y = 1 inci. Kami juga menetapkan ukuran diagram yang bersesuaian ke dimensi yang sama: tinggi 4 inci dan lebar 9,5 inci.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Muat buku kerja Excel yang berisi diagram.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inci (4 * 72).
    desired_width = 684  # 9.5 inci (9.5 * 72).

    # Tentukan ukuran diagram tanpa jendela.
    chart.setSizeWithWindow(False)

    # Atur ukuran diagram dalam piksel (Excel menggunakan 96 piksel per inci).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Simpan buku kerja ke aliran memori.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Buat bingkai objek OLE dengan data Excel yang disematkan.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Kesimpulan**

Ada dua pendekatan untuk memperbaiki masalah pengubahan ukuran diagram. Pilihan pendekatan tergantung pada kebutuhan dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama baik ketika presentasi dibuat dari templat maupun dibuat dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.

## **FAQ**

**Mengapa diagram Excel yang disematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela aslinya saat pertama kali diaktifkan, sedangkan bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan pengubahan ukuran.

**Apakah mungkin mencegah masalah pengubahan ukuran ini sepenuhnya?**

Ya. Dengan menyamakan ukuran jendela buku kerja Excel atau ukuran diagram dengan ukuran bingkai objek OLE sebelum penyematan, Anda dapat menjaga konsistensi ukuran diagram.

**Pendekatan mana yang harus saya pilih, mengatur ukuran jendela buku kerja atau mengatur ukuran diagram?**

Gunakan **Pendekatan 1 (ukuran jendela)** jika Anda ingin mempertahankan rasio aspek buku kerja dan mungkin memungkinkan mengubah ukuran nanti.  
Gunakan **Pendekatan 2 (ukuran diagram)** jika dimensi diagram sudah tetap dan tidak akan berubah setelah penyematan.

**Apakah metode ini akan berfungsi pada presentasi berbasis templat maupun presentasi baru?**

Ya. Kedua pendekatan bekerja dengan cara yang sama untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai objek OLE?**

Tidak. Anda dapat menetapkan bingkai OLE ke ukuran berapa pun selama skala tersebut sesuai dengan ukuran buku kerja atau diagram.

**Dapatkah saya menggunakan metode ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh‑contoh dirancang untuk diagram Excel yang dibuat dengan Aspose.Cells, tetapi prinsipnya berlaku untuk program spreadsheet lain yang kompatibel dengan OLE asalkan mendukung opsi ukuran serupa.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan sebagai Objek OLE dalam Presentasi](/slides/id/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)