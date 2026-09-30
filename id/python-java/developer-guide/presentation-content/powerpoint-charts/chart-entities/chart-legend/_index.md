---
title: Kustomisasi Legenda Diagram dalam Presentasi Menggunakan Python
linktitle: Legenda Diagram
type: docs
url: /id/python-java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kustomisasi legenda diagram dengan Aspose.Slides untuk Python via Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda individu, serta menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multiline, dan mewarisi pemformatan dari tema presentasi.

## **Posisi Legenda**

Gunakan metode [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), dan [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) pada legenda untuk menentukan posisi dan ukuran sebagai pecahan dari dimensi diagram.

Contoh ini membuat presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar dan tinggi diagram mengubahnya menjadi nilai relatif: legenda diposisikan dengan offset 50 poin dari sudut kiri-atas diagram dan berukuran 100 x 100 poin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Nyatakan posisi dan ukuran legenda relatif terhadap diagram.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Ukuran Font Legenda**

Gunakan [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) pada legenda untuk mengakses pemformatan teksnya dan gunakan [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) untuk mengatur ukuran font dalam poin.

Contoh ini membuat diagram dengan data default dan mengatur teks legenda menjadi 20 poin. Ini juga menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur rentangnya dari -5 hingga 10.

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

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Ukuran Font Entri Legenda Individu**

Gunakan koleksi yang dikembalikan oleh metode [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) pada legenda untuk mengakses pemformatan entri tertentu. Indeks entri mulai dari nol, jadi indeks `1` merujuk pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ini memformat entri legenda kedua dengan teks tebal, miring, dan berwarna biru ukuran 20 poin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sembunyikan Entri Legenda Individu**

Untuk mengecualikan seri tambahan dari legenda sambil tetap menampilkan datanya, panggil [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) dengan `True` melalui [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Ini hanya menyembunyikan entri legenda yang dipilih; tidak menghapus seri atau titik datanya. Memanggil [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) dengan `False` sebaliknya, menyembunyikan seluruh legenda.

Contoh di bawah ini membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Ini menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri tersebut dipulihkan dengan memanggil [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) dengan `False` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

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
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Pulihkan entri yang sama tanpa mengubah data diagram.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Perbandingan di bawah menunjukkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua disembunyikan. Kolom seri kedua tetap tidak berubah.

![Perbandingan diagram dengan semua entri legenda terlihat dan dengan Seri 2 disembunyikan dari legenda; semua kolom tetap terlihat.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Untuk diagram pai, mereka mengidentifikasi titik data individu (iris), jadi gunakan [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) pada iris yang dipilih sebagai gantinya. API mendokumentasikan metode titik data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan mengasumsikan bahwa ini berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Bisakah saya membuat diagram menyediakan ruang untuk legenda alih-alih menimpanya?**  
Ya. Panggil [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) dengan `False` untuk memesan ruang bagi legenda alih-alih membiarkannya menimpa area plot.

**Bisakah saya membuat label legenda multiline?**  
Ya. Label yang panjang dapat dibungkus bila lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**  
Biarkan warna, isi, dan font legenda tidak diatur sehingga dapat mewarisi pemformatan tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersangkutan.