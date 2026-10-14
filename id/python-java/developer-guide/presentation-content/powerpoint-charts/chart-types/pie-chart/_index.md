---
title: Sesuaikan Diagram Pai dalam Presentasi Menggunakan Python via Java
linktitle: Diagram Pai
type: docs
url: /id/python-java/pie-chart/
keywords:
- diagram pai
- mengelola diagram
- menyesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan sesuaikan diagram pai dalam Python via Java dengan Aspose.Slides. Konfigurasikan plot sekunder, tampilkan label data, dan terapkan warna irisan otomatis di PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram pai di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram pai standar.

Contoh-contoh berfokus pada tugas-tugas penyesuaian diagram seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Sekunder untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides for Python via Java mendukung opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie. Opsi-opsi ini mengontrol ukuran plot sekunder dan bagaimana titik data dibagi antara kedua plot.

Contoh berikut membuat diagram Pie of Pie dalam presentasi baru dan menampilkan nilai titik data sebagai label. Metode [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) mengatur ukuran plot sekunder menjadi 149% dari plot utama. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) memilih pemisahan berbasis persentase, dan [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) mengatur ambang batas menjadi 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Tampilkan nilai dan konfigurasikan plot sekunder.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pilih Kategori untuk Plot Sekunder**

Gunakan pemisahan khusus ketika Anda ingin mengelompokkan kategori tertentu dalam plot sekunder terlepas dari nilai persentasenya. Misalnya, laporan penjualan mungkin menampilkan Online dan Events bersama sehingga pembaca dapat membandingkan kedua saluran ini, meskipun mereka menyumbang 35% dan 10% dari total penjualan.

Panggil [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) dengan [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) dan pilih titik melalui [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metode [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) pada koleksi menerima indeks berbasis nol dalam seri; gunakan [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) untuk menambahkan objek titik data. Pada contoh ini, indeks 1 memilih Online, dan titik pada indeks 3 memilih Events. Partners juga ditambahkan sementara, kemudian dikecualikan menggunakan [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Ganti data default dengan penjualan per saluran.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Pilih Online berdasarkan indeks berbasis nol dan Events berdasarkan objek titik data.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Kecualikan Partners dari seleksi tanpa menghapus data sumbernya.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) dan Events (10) muncul sebagai irisan terpisah di plot sekunder. Di plot utama, mereka direpresentasikan oleh satu irisan gabungan dengan nilai 45, bersama Retail (40) dan Partners (15). Menghapus Partners dari seleksi khusus mempertahankannya di plot utama; ini tidak menghapus kategori atau nilainya dari data sumber diagram.

Berikut gambar menunjukkan presentasi yang disimpan di PowerPoint:

![Diagram Pie of Pie dengan Online dan Events di plot sekunder dan nilai gabungan 45 di plot utama](pie_of_pie_custom.png)

## **Atur Pewarnaan Irisan Diagram Pai Otomatis**

Aspose.Slides for Python via Java dapat secara otomatis menetapkan warna yang berbeda ke irisan diagram pai. Contoh berikut membuat diagram pai dengan judul terpusat dan mengganti data default dengan tiga kategori kuartalan serta nilai-nilainya. Metode [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) menampilkan nilai 20, 50, dan 30 sebagai label, sementara [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) mengaktifkan warna yang berbeda untuk setiap irisan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Tambah judul diagram terpusat.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ganti data default menggunakan lembar kerja pertama.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Tampilkan nilai dan beri warna berbeda pada irisan.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah variasi Pie of Pie dan Bar of Pie didukung?**

Ya, pustaka [mendukung](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) plot sekunder untuk diagram pai, termasuk tipe Pie of Pie dan Bar of Pie.

**Apakah saya dapat mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (seperti PNG) tanpa mengekspor seluruh presentasi.