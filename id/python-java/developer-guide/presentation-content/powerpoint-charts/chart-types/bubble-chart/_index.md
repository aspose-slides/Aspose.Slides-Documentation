---
title: Sesuaikan Diagram Gelembung dalam Presentasi Menggunakan Python
linktitle: Diagram Gelembung
type: docs
url: /id/python-java/bubble-chart/
keywords:
- diagram gelembung
- ukuran gelembung
- skala ukuran
- representasi ukuran
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan sesuaikan diagram gelembung yang kuat di PowerPoint dengan Aspose.Slides untuk Python via Java untuk meningkatkan visualisasi data Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram gelembung di Aspose.Slides. Artikel ini mencakup dua opsi penyesuaian khusus: menskalakan ukuran gelembung melalui metode [setBubbleSizeScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) dan mengontrol cara nilai ukuran gelembung direpresentasikan melalui metode [setBubbleSizeRepresentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Contoh-contoh memperlihatkan cara membuat diagram gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung menjadi lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3-D”, mencatat bahwa batas praktis diagram bergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa proses ekspor mempertahankan tampilan diagram melalui mesin render Aspose.Slides.

## **Skala Ukuran Diagram Gelembung**
Aspose.Slides for Python via Java mendukung skala ukuran diagram gelembung melalui metode [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale), dan [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Contoh berikut menunjukkan cara menskalakan ukuran gelembung.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Representasikan Data sebagai Ukuran Diagram Gelembung**
Metode [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) dan [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) tersedia dalam kelas [ChartSeriesGroup](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/). Representasi ukuran gelembung menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam diagram gelembung. Nilai yang dapat dipilih adalah [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/id/python-java/aspose.slides/bubblesizerepresentationtype/#Area) dan [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/id/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Enumerasi [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/id/python-java/aspose.slides/bubblesizerepresentationtype/) menjelaskan cara-cara yang mungkin untuk merepresentasikan data sebagai ukuran diagram gelembung. Contoh berikut menunjukkan cara merepresentasikan ukuran gelembung menggunakan lebar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah “bubble chart with 3-D effect” didukung, dan bagaimana perbedaannya dengan diagram biasa?**

Ya. Terdapat tipe diagram terpisah, “Bubble with 3-D.” Tipe ini menerapkan gaya 3‑D pada gelembung tetapi tidak menambahkan sumbu tambahan; data tetap X‑Y‑S (ukuran). Tipe ini tersedia dalam kelas [chart type](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/).

**Apakah ada batasan jumlah seri dan titik pada diagram gelembung?**

Tidak ada batas keras pada tingkat API; batasan ditentukan oleh kinerja dan versi PowerPoint target. Disarankan agar jumlah titik tetap wajar untuk memastikan keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan diagram gelembung (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; proses rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vektor, aturan umum rendering grafik diagram berlaku (resolusi, anti‑aliasing), jadi pilih DPI yang cukup untuk pencetakan.