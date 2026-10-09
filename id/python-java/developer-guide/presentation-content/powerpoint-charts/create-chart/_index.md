---
title: Buat atau Perbarui Grafik Presentasi PowerPoint di Python
linktitle: Buat atau Perbarui Grafik
type: docs
weight: 10
url: /id/python-java/create-chart/
keywords:
- menambahkan grafik
- membuat grafik
- mengedit grafik
- mengubah grafik
- memperbarui grafik
- grafik sebar
- grafik pai
- grafik garis
- grafik peta pohon
- grafik saham
- grafik box and whisker
- grafik corong
- grafik sunburst
- grafik histogram
- grafik radar
- grafik multi‑kategori
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan sesuaikan grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java. Tambahkan, format, dan edit grafik dengan contoh kode praktis dalam Python."
---
## **Gambaran Umum**

Artikel ini menyediakan panduan komprehensif tentang cara membuat dan menyesuaikan grafik menggunakan Aspose.Slides. Anda akan belajar cara menambahkan grafik secara programatik ke slide, mengisi data, dan menerapkan berbagai opsi pemformatan untuk menyesuaikan dengan kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode terperinci menggambarkan setiap langkah, mulai dari menginisialisasi presentasi dan objek grafik hingga mengkonfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan memperoleh pemahaman yang kuat tentang cara mengintegrasikan pembuatan grafik dinamis ke dalam aplikasi Anda, menyederhanakan proses pembuatan presentasi berbasis data.

## **Buat Grafik**

Grafik membantu orang dengan cepat memvisualisasikan data dan memperoleh wawasan yang mungkin tidak langsung terlihat dari tabel atau lembar kerja.

**Mengapa Membuat Grafik?**

* mengagregasi, merangkum, atau menyederhanakan sejumlah besar data pada satu slide dalam presentasi
* menampilkan pola dan tren dalam data
* menyimpulkan arah dan momentum data seiring waktu atau terhadap unit pengukuran tertentu
* mengidentifikasi outlier, penyimpangan, deviasi, kesalahan, data yang tidak masuk akal, dll.
* mengkomunikasikan atau menyajikan data yang kompleks

Di PowerPoint, Anda dapat membuat grafik melalui fungsi *Insert*, yang menyediakan templat untuk merancang berbagai jenis grafik. Dengan menggunakan Aspose.Slides, Anda dapat membuat grafik reguler (berdasarkan jenis grafik populer) dan grafik kustom.

{{% alert color="info" title="Note" %}}
Untuk membuat grafik, gunakan kelas [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) . Field dalam kelas ini sesuai dengan berbagai jenis grafik.
{{% /alert %}}

### **Buat Grafik Kolom Berkelompok**

Bagian ini menjelaskan cara membuat grafik kolom berkelompok menggunakan Aspose.Slides. Anda akan belajar menginisialisasi presentasi, menambahkan grafik, dan menyesuaikan elemen‑elemen seperti judul, data, seri, kategori, dan gaya. Ikuti langkah‑langkah di bawah ini untuk melihat bagaimana grafik kolom berkelompok standar dihasilkan:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan beberapa data dan tentukan tipe `ChartType.ClusteredColumn` .
4. Tambahkan judul ke grafik.
5. Akses lembar kerja data grafik.
6. Bersihkan semua seri dan kategori default.
7. Tambahkan seri dan kategori baru.
8. Tambahkan data grafik baru untuk seri grafik.
9. Terapkan warna isi ke seri grafik.
10. Tambahkan label ke seri grafik.
11. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Membuat instance kelas presentasi yang mewakili file PPTX.
presentation = Presentation()
try:
    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Menambahkan grafik dengan data defaultnya
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Menetapkan Judul grafik
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Menetapkan indeks untuk lembar data grafik
    default_worksheet_index = 0

    # Mendapatkan WorkSheet data grafik
    workbook = chart.getChartData().getChartDataWorkbook()

    # Menghapus seri dan kategori default yang dihasilkan
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Menambahkan seri baru
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Menambahkan kategori baru
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Mengambil seri grafik pertama
    series = chart.getChartData().getSeries().get_Item(0)

    # Sekarang mengisi data seri
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Menetapkan warna isi untuk seri
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Mengambil seri grafik kedua
    series = chart.getChartData().getSeries().get_Item(1)

    # Mengisi data seri
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Menetapkan warna isi untuk seri
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Membuat label khusus untuk setiap kategori pada seri baru
    # Menetapkan label pertama untuk menampilkan nama Kategori
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Menampilkan nilai untuk label ketiga
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Menyimpan presentasi dengan grafik
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Sebar**

Grafik sebar (juga dikenal sebagai plot sebar atau grafik x‑y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel.

Gunakan grafik sebar ketika:

* Anda memiliki data numerik berpasangan
* Anda memiliki dua variabel yang cocok bersama
* Anda ingin menentukan apakah dua variabel berhubungan
* Anda memiliki variabel independen yang memiliki banyak nilai untuk variabel dependen

1. Ikuti langkah‑langkah dalam [Buat Grafik Kolom Berkelompok](#buat-grafik-kolom-berkelompok) .
2. Pada langkah ketiga, tambahkan grafik dengan beberapa data dan pilih tipe grafik Anda sebagai salah satu berikut:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Mewakili grafik sebar._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Mewakili grafik sebar yang dihubungkan oleh kurva, dengan penanda data._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Mewakili grafik sebar yang dihubungkan oleh kurva, tanpa penanda data._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Mewakili grafik sebar yang dihubungkan oleh garis, dengan penanda data._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Mewakili grafik sebar yang dihubungkan oleh garis, tanpa penanda data._

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Membuat instance kelas presentasi yang mewakili file PPTX.
presentation = Presentation()
try:
    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Membuat grafik default
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Mendapatkan indeks lembar kerja data grafik default
    default_worksheet_index = 0

    # Mendapatkan lembar kerja data grafik
    workbook = chart.getChartData().getChartDataWorkbook()

    # Menghapus seri demo
    chart.getChartData().getSeries().clear()

    # Menambahkan seri baru
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Mengambil seri grafik pertama
    series = chart.getChartData().getSeries().get_Item(0)

    # Menambahkan titik baru (1:3) ke seri
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Menambahkan titik baru (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Mengubah tipe seri
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Mengubah penanda seri grafik
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Mengambil seri grafik kedua
    series = chart.getChartData().getSeries().get_Item(1)

    # Menambahkan titik baru (5:2) di sana
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Menambahkan titik baru (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Menambahkan titik baru (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Menambahkan titik baru (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Mengubah penanda seri grafik
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Pai**

Grafik pai paling baik digunakan untuk menunjukkan hubungan bagian‑dengan‑keseluruhan dalam data, terutama ketika data berisi label kategori dengan nilai numerik. Namun, jika data Anda memiliki banyak bagian atau label, Anda mungkin ingin mempertimbangkan menggunakan grafik batang sebagai gantinya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie) .
4. Akses workbook data grafik [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) .
5. Bersihkan seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Tambahkan poin baru untuk grafik dan terapkan warna kustom untuk sektor grafik pai.
9. Atur label untuk seri.
10. Aktifkan garis penunjuk untuk label seri.
11. Atur sudut rotasi untuk sektor grafik pai.
12. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Membuat instance kelas presentasi yang mewakili file PPTX.
presentation = Presentation()
try:
    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Menambahkan grafik dengan data default
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Menetapkan Judul grafik
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Menetapkan indeks untuk lembar data grafik
    default_worksheet_index = 0

    # Mendapatkan lembar kerja data grafik
    workbook = chart.getChartData().getChartDataWorkbook()

    # Menghapus seri dan kategori default yang dihasilkan
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Menambahkan kategori baru
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Menambahkan seri baru
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Mengisi data seri
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Menambahkan titik baru dan mengatur warna sektor
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Menetapkan tepi sektor
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Menetapkan tepi sektor
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Menetapkan tepi sektor
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Membuat label khusus untuk setiap kategori pada seri baru
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Menampilkan Leader Lines untuk Grafik
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Menetapkan Sudut Rotasi untuk Sektor Grafik Pai
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Menyimpan presentasi dengan grafik
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Garis**

Grafik garis (juga dikenal sebagai grafik linier) paling baik digunakan dalam situasi di mana Anda ingin menunjukkan perubahan nilai seiring waktu. Dengan grafik garis, Anda dapat membandingkan sejumlah besar data sekaligus, melacak perubahan dan tren dari waktu ke waktu, menyoroti anomali dalam seri data, dan lainnya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide menggunakan indeknya.
1. Tambahkan grafik dengan data default dan pilih tipe [ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line) .
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Secara default, titik‑titik pada grafik garis dihubungkan oleh garis lurus berkelanjutan. Jika Anda ingin titik‑titik dihubungkan oleh garis putus‑putus, Anda dapat menentukan jenis dash yang diinginkan sebagai berikut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Peta Pohon**

Grafik peta pohon paling baik digunakan untuk data penjualan ketika Anda ingin menunjukkan ukuran relatif kategori data dan dengan cepat menarik perhatian ke item yang menjadi kontributor besar dalam tiap kategori.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap) .
4. Akses workbook data grafik [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) .
5. Bersihkan seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #cabang 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #cabang 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Saham**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Akses workbook data grafik [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) .
5. Bersihkan seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Tentukan format garis high‑low.
9. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik BoxAndWhisker**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Akses workbook data grafik [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) .
5. Bersihkan seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Corong**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Sunburst**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #cabang 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #cabang 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Histogram**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram) .
4. Akses workbook data grafik [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) .
5. Bersihkan seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Radar**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan beberapa data dan pilih tipe grafik yang diinginkan ([ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar) dalam kasus ini) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Multi‑Kategori**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Tambahkan grafik dengan data default dan pilih tipe [ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn) .
4. Akses workbook data grafik [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) .
5. Bersihkan seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Menambahkan Seri
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Simpan presentasi dengan grafik
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Peta**

Grafik peta memvisualisasikan data geografis dan membantu membandingkan nilai antar wilayah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Grafik Kombinasi**

Grafik kombinasi (atau combo chart) menggabungkan dua atau lebih tipe grafik dalam satu grafik. Grafik ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antara dua atau lebih set data, membantu mengidentifikasi hubungan di antaranya.

![Grafik kombinasi](combination_chart.png)

Kode Python berikut memperlihatkan cara membuat grafik kombinasi yang ditampilkan di atas dalam sebuah presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Atur judul grafik.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Atur legenda grafik.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Hapus seri dan kategori default yang dihasilkan.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Tambahkan kategori baru.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Tambahkan seri pertama.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Atur sumbu horizontal.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Atur sumbu vertikal.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Atur warna garis kisi utama vertikal.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Atur sumbu horizontal sekunder.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Atur sumbu vertikal sekunder.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Perbarui Grafik**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) yang mewakili presentasi berisi grafik yang ingin Anda perbarui.
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Telusuri semua shape untuk menemukan grafik yang diinginkan.
4. Akses worksheet data grafik.
5. Modifikasi seri data grafik dengan mengubah nilai seri.
6. Tambahkan seri baru dan isi datanya.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Membuka presentasi yang berisi grafik yang akan diperbarui
presentation = Presentation("ExistingChart.pptx")
try:
    # Mengakses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Mengambil grafik dari slide
    chart = slide.getShapes().get_Item(0)

    # Menetapkan indeks lembar data grafik
    default_worksheet_index = 0

    # Mendapatkan lembar kerja data grafik
    workbook = chart.getChartData().getChartDataWorkbook()

    # Mengubah Nama Kategori grafik
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Mengambil seri grafik pertama
    series = chart.getChartData().getSeries().get_Item(0)

    # Sekarang memperbarui data seri
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Memodifikasi nama seri
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Mengambil seri grafik kedua
    series = chart.getChartData().getSeries().get_Item(1)

    # Sekarang memperbarui data seri
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Memodifikasi nama seri
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Sekarang, Menambahkan seri baru
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Mengambil seri grafik ketiga
    series = chart.getChartData().getSeries().get_Item(2)

    # Sekarang mengisi data seri
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Simpan presentasi dengan grafik
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Rentang Data untuk Grafik**

Untuk memeriksa rentang yang sudah digunakan oleh grafik yang ada, lihat [Mengambil Rentang Data Grafik](/slides/id/python-java/chart-workbook/#retrieve-a-charts-data-range) .

Untuk mengatur rentang data bagi sebuah grafik, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) yang mewakili presentasi berisi grafik.
2. Dapatkan referensi ke slide menggunakan indeknya.
3. Telusuri semua shape untuk menemukan grafik yang diinginkan.
4. Akses data grafik dan atur rentangnya.
5. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuka presentasi yang berisi grafik
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gunakan Penanda Default dalam Grafik**

Saat Anda menggunakan penanda default dalam grafik, setiap seri grafik secara otomatis mendapatkan simbol penanda yang berbeda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #Ambil seri grafik kedua
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Sekarang mengisi data seri
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jenis grafik apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung beragam [jenis grafik](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) , termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih jenis grafik yang paling tepat untuk kebutuhan visualisasi data Anda.

**Bagaimana cara menambahkan grafik baru ke slide?**

Untuk menambahkan grafik, pertama buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , ambil slide yang diinginkan menggunakan indeknya, lalu panggil metode untuk menambahkan grafik, menentukan tipe grafik dan data awal. Proses ini mengintegrasikan grafik langsung ke dalam presentasi Anda.

**Bagaimana saya dapat memperbarui data yang ditampilkan dalam grafik?**

Anda dapat memperbarui data grafik dengan mengakses workbook datanya ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) ), membersihkan semua seri dan kategori default, lalu menambahkan data khusus Anda. Hal ini memungkinkan Anda menyegarkan grafik agar mencerminkan data terbaru.

**Apakah memungkinkan untuk menyesuaikan tampilan grafik?**

Ya, Aspose.Slides menyediakan opsi penyesuaian yang luas. Anda dapat mengubah warna, font, label, legenda, dan elemen [formatting](/slides/id/python-java/chart-entities/) lainnya untuk menyesuaikan tampilan grafik dengan kebutuhan desain spesifik Anda.