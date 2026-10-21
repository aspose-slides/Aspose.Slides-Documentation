---
title: Kelola Label Data Diagram dalam Presentasi Menggunakan Python
linktitle: Label Data
type: docs
url: /id/python-java/chart-data-label/
keywords:
- diagram
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python melalui Java untuk slide yang lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri diagram dan titik data individu, membantu pembaca mengidentifikasi nilai dan memahami diagram. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, mengendalikan label di luar maksimum sumbu, menyesuaikan jarak label sumbu kategori, dan memposisikan label diagram pai.

## **Mengatur Presisi Data pada Label Data Diagram**

Gunakan [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) untuk memformat nilai seri. Contoh ini membuat diagram garis dengan data default, menampilkan tabel datanya, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai dasar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk memformat sel numerik dalam workbook yang tertanam pada diagram, lihat [Atur Format Angka Kustom untuk Sel Workbook](/slides/id/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Contoh itu juga memperlihatkan label nilai yang mengikuti format sel sumbernya sambil mempertahankan nilai numerik yang disimpan.

## **Menampilkan Persentase sebagai Label**

Untuk diagram kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori dan tetapkan teks ke kerangka teks yang dikembalikan oleh [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Contoh ini menggunakan data diagram default dan menampilkan persentase dengan dua tempat desimal dalam font 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label kustom jika data diagram berubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Tanda Persentase dengan Label Data Diagram**

Ketika nilai disimpan sebagai pecahan, gunakan [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) untuk menampilkan persentase. Berikan `False` ke [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) untuk menerapkan format label secara terpisah dari sel sumber.

Contoh ini membuat diagram kolom 100% bertumpuk dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai berjumlah 1. Format label `0.0%` menampilkan 0.30 sebagai 30.0%, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label putih 10 poin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membaca Teks Aktual dari Label Data**

Gunakan [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi diagram yang dihasilkan. Pada contoh di bawah, format [label data default](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) menggabungkan setiap nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan titik lain menggunakan teks kustom dari [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Angka yang disimpan dalam titik data tetap `0.75`, meskipun labelnya menampilkan `75%` bersama nama kategori dan seri. Teks kustom menggantikan teks label yang dihasilkan. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) mengembalikan string label yang dihasilkan dalam kedua kasus. Periksa [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda ingin mengekstrak hanya label yang terlihat.

## **Mengendalikan Label Data di Luar Maksimum Sumbu**

Ketika Anda membatasi rentang sumbu secara manual, beberapa titik data mungkin melebihi maksimalnya. Gunakan [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) untuk mengendalikan apakah label datanya ditampilkan. Pengaturan ini mengubah visibilitas label; tidak mengubah rentang sumbu atau nilai data dasar.

Contoh di bawah membuat diagram kolom berkelompok 2D dengan nilai 60 dan 120. Ia memberikan `False` ke [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) dan menetapkan maksimum menjadi 100 dengan [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) pada sumbu vertikal. Slide pertama memungkinkan label di luar maksimum; salinan slide itu menonaktifkannya. Kedua slide disimpan dalam `DataLabelsOverMaximum.pptx`.

Aktifkan label nilai dengan [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Pengaturan tingkat diagram tidak secara otomatis menampilkan nilai atau menimpa penonaktifan tampilan nilai pada label individu. Contoh ini mengaktifkan nilai untuk seluruh seri dan menggunakan [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) untuk menempatkan label di ujung luar setiap kolom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gambar berikut menunjukkan slide yang disimpan yang dirender oleh Microsoft PowerPoint. Dengan `True`, label **120** terlihat di batas atas; dengan `False`, label tersebut disembunyikan. Label **60** tetap terlihat, maksimum sumbu tetap **100**, dan titik data kedua tetap **120** pada kedua kasus.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Diagram PowerPoint yang menampilkan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-true.png) | ![Diagram PowerPoint yang menyembunyikan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Tipe Diagram" %}}
Contoh ini menggunakan diagram kolom 2D dengan sumbu nilai. Diagram tanpa sumbu nilai, seperti diagram pai dan donat, tidak memiliki maksimum sumbu untuk dibatasi dengan cara ini.
{{% /alert %}}

## **Mengatur Jarak Label dari Sumbu**

Gunakan [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) untuk mengendalikan jarak antara label sumbu kategori dan sumbu. Nilainya berupa persentase dari ukuran font maksimum label sumbu. Contoh ini membuat diagram kolom berkelompok dan menetapkan offset label sumbu horizontal menjadi 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang terpasang pada titik data individu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menyesuaikan Lokasi Label**

Pada diagram pai, sesuaikan posisi label data untuk meningkatkan jarak dan memberi ruang bagi garis pemimpin.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan menyesuaikan offset horizontal serta vertikalnya menggunakan [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) dan [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Offset ini relatif terhadap lebar dan tinggi diagram, masing‑masing.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Diagram pai dengan posisi label data yang disesuaikan](pie-chart-adjusted-label.png)

## **Memformat Garis Pemimpin**

Ketika label diagram pai berada di luar irisan, garis pemimpin membantu pembaca mencocokkan setiap nilai dengan irisan yang tepat. Warna kontras dan garis yang sedikit lebih tebal dapat membuat koneksi ini lebih mudah diikuti, sementara transparansi dan gaya garis putus‑putus menjaga agar garis tidak terlalu mencolok.

Gunakan [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) untuk memformat garis pemimpin pada tingkat koleksi label data seri. Pengaturan dalam `series.getLabels().getLeaderLinesFormat().getLine()` berlaku untuk koleksi, bukan untuk label individu.

Contoh ini membuat diagram pai dengan data default, menampilkan nilai di luar irisan, dan mengaktifkan [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Ia memindahkan dua label lebih jauh dari irisan mereka menggunakan offset [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) dan [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY), yang diungkapkan sebagai pecahan lebar dan tinggi diagram. Tidak diperlukan presentasi input.

[getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) pada garis mengatur warna biru solid dengan nilai alpha 191 dari 255, memberi transparansi sekitar 25%. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) mengatur ketebalan menjadi 2 poin, dan [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) membuat garis menjadi putus‑putus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Pindahkan dua label lebih jauh dari irisan mereka.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mengaktifkan garis pemimpin tidak menjamin bahwa sebuah garis akan muncul untuk setiap label. Visibilitas bergantung pada penempatan label dan perilaku tata letak diagram. Pada contoh ini, dua label yang dipindahkan memiliki garis pemimpin yang terlihat; label yang tetap dekat dengan irisan tidak memerlukannya.

Gambar berikut menunjukkan `FormattedLeaderLines.pptx` yang disimpan dan dirender dengan Aspose.Slides:

![Diagram pai dengan garis pemimpin biru, semi‑transparan, putus‑putus yang menghubungkan dua label luar ke irisan masing‑masing](formatted-leader-lines.png)

## **Menambahkan Beberapa Baris Label Data di Atas Diagram Kolom**

Contoh ini membuat diagram kolom dengan dua baris label data di atas area plot. Seri A menampilkan kolom yang terlihat, sementara Seri B dan Seri C menyediakan label tambahan. Kolom mereka disembunyikan dengan menghapus isian dan outline. Metode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) menyelaraskan ketiga seri dengan pusat kategori yang sama.

Pengaturan [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) menyisakan ruang untuk baris label. Setelah [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) menghitung posisi default, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) dan [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) mempertahankan penjajaran horizontal dan menerapkan offset vertikal untuk menyusun label dalam dua baris. Angka tetap label data yang terhubung ke nilai seri; hanya judul baris yang menjadi bentuk teks terpisah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Sembunyikan kolom B dan C, tetapi tetap pertahankan label data mereka.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Ratakan ketiga seri dengan pusat kategori yang sama.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Gunakan lebih sedikit garis kisi untuk contoh yang ringkas ini.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Cadangkan ruang di atas area plot untuk dua baris label data.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Pertahankan posisi horizontal default. Y adalah offset dari
            # posisi label default, yang dinyatakan sebagai pecahan tinggi diagram.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Hanya judul baris yang merupakan bentuk teks terpisah.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Diagram kolom dengan dua baris label data di atas area plot](multiple-rows-of-labels.png)

## **FAQ**

**Bagaimana cara mencegah label data saling tumpang tindih pada diagram yang padat?**

Gabungkan penempatan label otomatis, garis pemimpin, dan ukuran font yang diperkecil; jika perlu, sembunyikan beberapa bidang (misalnya kategori) atau tampilkan label hanya untuk nilai ekstrem atau titik penting.

**Bagaimana cara menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Filter titik data sebelum mengaktifkan label dan nonaktifkan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai aturan yang ditentukan.

**Bagaimana memastikan gaya label konsisten saat mengekspor ke PDF/gambar?**

Tetapkan secara eksplisit keluarga font dan ukuran, serta verifikasi bahwa font tersedia di lingkungan rendering untuk menghindari fallback.