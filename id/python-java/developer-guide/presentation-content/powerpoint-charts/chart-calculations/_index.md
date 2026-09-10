---
title: Optimalkan Perhitungan Diagram untuk Presentasi di Python via Java
linktitle: Perhitungan Diagram
type: docs
weight: 50
url: /id/python-java/chart-calculations/
keywords:
- perhitungan diagram
- elemen diagram
- posisi elemen
- posisi aktual
- elemen anak
- elemen induk
- nilai diagram
- nilai aktual
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pahami perhitungan diagram, pembaruan data, dan kontrol presisi di Aspose.Slides untuk Python via Java untuk PPT dan PPTX, dengan contoh kode Python yang praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan diagram dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai sebenarnya dari elemen diagram, termasuk posisi dan ukuran sebenarnya dari elemen diagram serta nilai sebenarnya dari sumbu diagram. Artikel ini juga menjelaskan bahwa nilai-nilai tersebut diisi setelah validasi tata letak diagram.

Selain itu, artikel ini menunjukkan cara mendapatkan posisi sebenarnya dari elemen diagram induk dan cara menyembunyikan komponen diagram seperti judul, sumbu, legenda, dan garis kisi. Bersama-sama, contoh-contoh ini membantu Anda memeriksa informasi tata letak diagram dan mengontrol visibilitas elemen diagram dalam presentasi PowerPoint secara programatik.

## **Hitung Nilai Aktual Elemen Diagram**
Aspose.Slides for Python via Java menyediakan API sederhana untuk mendapatkan properti ini. Metode dari kelas [Axis](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/) memberikan informasi tentang nilai aktual sumbu diagram ([getActualMaxValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/#getActualMaxValue),[getActualMinValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/#getActualMinValue),[getActualMajorUnit](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/#getActualMajorUnit),[getActualMinorUnit](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/#getActualMinorUnit),[getActualMajorUnitScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/#getActualMajorUnitScale),[getActualMinorUnitScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Panggil metode [Chart.validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) terlebih dahulu untuk mengisi properti ini dengan nilai aktual.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Hitung Posisi Aktual Elemen Diagram Induk**
Aspose.Slides for Python via Java menyediakan API sederhana untuk mendapatkan properti ini. Metode dari kelas [ChartPlotArea](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/) memberikan informasi tentang posisi dan ukuran aktual area plot diagram ([getActualX](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/#getActualX),[getActualY](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/#getActualY),[getActualWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/#getActualWidth),[getActualHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/#getActualHeight)). Panggil metode [Chart.validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) terlebih dahulu untuk mengisi properti ini dengan nilai aktual.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Sembunyikan Elemen Diagram**
Bagian ini menjelaskan cara menyembunyikan informasi dari diagram. Menggunakan Aspose.Slides for Python via Java, Anda dapat menyembunyikan **Title, Vertical Axis, Horizontal Axis**, dan **Grid Lines**. Contoh kode berikut menunjukkan cara menggunakan properti ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpate.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Sembunyikan judul diagram.
    chart.setTitle(False)

    # Sembunyikan sumbu nilai.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Sembunyikan sumbu kategori.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Sembunyikan legenda.
    chart.setLegend(False)

    # Sembunyikan garis kisi utama.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Pertahankan hanya seri pertama. Menghapus dari akhir menjaga indeks yang tersisa tetap valid.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Atur warna garis seri.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah buku kerja Excel eksternal dapat digunakan sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Diagram dapat merujuk ke buku kerja eksternal: ketika Anda menghubungkan atau menyegarkan sumber eksternal, rumus dan nilai diambil dari buku kerja tersebut, dan diagram mencerminkan pembaruan selama operasi buka/edit. API memungkinkan Anda [tentukan buku kerja eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook) path dan mengelola data yang ditautkan.

**Bisakah saya menghitung dan menampilkan garis tren tanpa harus mengimplementasikan regresi sendiri?**

Ya. [Trendlines](/slides/id/python-java/trend-line/) (linear, eksponensial, dan lainnya) ditambahkan dan diperbarui oleh Aspose.Slides; parameternya dihitung ulang dari data seri secara otomatis, sehingga Anda tidak perlu mengimplementasikan perhitungan Anda sendiri.

**Jika presentasi memiliki beberapa diagram dengan tautan eksternal, dapatkah saya mengontrol buku kerja mana yang digunakan setiap diagram untuk nilai yang dihitung?**

Ya. Setiap diagram dapat menunjuk ke [buku kerja eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook) miliknya sendiri, atau Anda dapat membuat/mengganti buku kerja eksternal per diagram secara terpisah dari yang lain.