---
title: Sesuaikan Tabel Data Diagram dalam Presentasi Menggunakan Python
linktitle: Tabel Data
type: docs
url: /id/python-java/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Sesuaikan font, batas, dan kunci legenda tabel data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java memungkinkan Anda menampilkan tabel data diagram dan menyesuaikan pemformatan teks, batas, serta kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol masing‑masing jenis batas, serta menampilkan atau menyembunyikan kunci legenda. Contoh‑contohnya menyimpan diagram yang telah dikonfigurasi dalam file PPTX.

## **Atur Properti Font**

Untuk menampilkan tabel data diagram, berikan `True` ke [setDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setDataTable). Gunakan [getChartDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#getChartDataTable) untuk mengakses tabel dan mengatur pemformatan teksnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Tambahkan diagram kolom berkelompok ke slide pertama.
1. Aktifkan tabel data diagram.
1. Aktifkan teks tebal dengan [setFontBold](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setFontBold) dan berikan `20` ke [setFontHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setFontHeight) untuk teks berukuran 20 poin.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut mengharuskan adanya `test.pptx` di direktori kerja dengan minimal satu slide. Ia menambahkan diagram dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. File `output.pptx` yang disimpan berisi diagram dengan tabel data yang diaktifkan serta pengaturan font yang ditentukan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sesuaikan Garis Tabel Data**

Aktifkan tabel dengan [Chart.setDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setDataTable) dan akses melalui [Chart.getChartDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#getChartDataTable). Anda dapat mengontrol tiga jenis batas secara independen:

- [setBorderHorizontal](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setBorderHorizontal) mengendalikan batas sel horizontal.
- [setBorderVertical](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setBorderVertical) mengendalikan batas sel vertikal.
- [setBorderOutline](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setBorderOutline) mengendalikan batas luar tabel.

Berikan `True` ke masing‑masing metode untuk menampilkan batasnya atau `False` untuk menyembunyikannya. Contoh berikut membuat diagram kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file masukan. Posisi dan ukuran diagram ditentukan dalam poin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Perbandingan di bawah ini menggunakan data diagram yang sama dan pengaturan kunci legenda yang sama pada keempat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan satu pengaturan batas saja. Varian kiri‑bawah cocok dengan pengaturan batas pada contoh.

![Tabel data diagram dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Tampilkan atau Sembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di sebelah nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri diagram. Berikan `True` ke [setShowLegendKey](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setShowLegendKey) untuk menampilkan penanda ini atau `False` untuk menyembunyikannya.

Legenda terpisah diagram dikendalikan oleh [Chart.setLegend](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setLegend). Pengaturan ini bersifat independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat diagram dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sambil menyembunyikan legenda terpisah. Semua batas tabel diaktifkan secara eksplisit. Tidak diperlukan presentasi masukan. Untuk menyembunyikan hanya kunci tabel, berikan `False` ke [setShowLegendKey](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Perbandingan di bawah ini menunjukkan tabel yang sama dengan kunci legenda diaktifkan dan dinonaktifkan. Semua batas tetap diaktifkan, dan legenda terpisah diagram disembunyikan pada kedua kasus.

![Tabel data diagram dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda di tabel data diagram?**

Ya. Berikan `True` ke [setShowLegendKey](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setShowLegendKey) untuk menampilkan kunci legenda atau `False` untuk menyembunyikannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram dan tabel data yang ditampilkan sebagai bagian dari slide ketika mengekspor ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/id/python-java/convert-powerpoint-to-html/), atau [gambar](/slides/id/python-java/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data dalam diagram yang dimuat dari templat?**

Ya. Untuk diagram yang dimuat dari presentasi atau templat yang ada, gunakan [hasDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#hasDataTable) dan [setDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setDataTable) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana cara menemukan diagram yang memiliki tabel data diaktifkan?**

Iterasikan semua shape pada setiap slide, identifikasi diagram, dan panggil metode [hasDataTable](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#hasDataTable) mereka. Nilai `True` menunjukkan bahwa tabel data diaktifkan.