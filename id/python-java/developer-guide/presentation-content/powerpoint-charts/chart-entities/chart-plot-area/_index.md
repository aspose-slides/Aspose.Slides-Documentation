---
title: Kustomisasi Area Plot Chart Presentasi di Python
linktitle: Area Plot
type: docs
url: /id/python-java/chart-plot-area/
keywords:
- diagram
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan cara mengkustomisasi area plot chart dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java. Tingkatkan visual slide Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan area plot chart di Aspose.Slides. Artikel ini menjelaskan cara mendapatkan posisi dan ukuran aktual area plot dengan memvalidasi tata letak chart lalu membaca nilai X, Y, lebar, dan tinggi nya.

Artikel ini juga mendemonstrasikan cara mengonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan [LayoutTargetType](https://reference.aspose.com/slides/id/python-java/aspose.slides/layouttargettype/) untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau wilayah luarnya bersama dengan sumbu dan label sumbu.

## **Dapatkan Lebar dan Tinggi Area Plot Chart**

Aspose.Slides for Python via Java menyediakan API sederhana untuk membaca posisi dan ukuran aktual area plot chart.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan chart dengan data default.
1. Panggil metode [Chart.validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) sebelum memperoleh nilai aktual.
1. Dapatkan posisi X aktual (kiri) elemen chart relatif terhadap sudut kiri‑atas chart.
1. Dapatkan posisi Y aktual (atas) elemen chart relatif terhadap sudut kiri‑atas chart.
1. Dapatkan lebar aktual elemen chart.
1. Dapatkan tinggi aktual elemen chart.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Setel Mode Tata Letak Area Plot Chart**

Aspose.Slides for Python via Java menyediakan API sederhana untuk mengatur mode tata letak area plot chart. Metode [setLayoutTargetType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) dan [getLayoutTargetType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) tersedia di kelas [ChartPlotArea](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartplotarea/). Jika tata letak area plot didefinisikan secara manual, pengaturan ini menentukan apakah area plot diatur oleh bagian dalamnya (mengecualikan sumbu dan label sumbu) atau oleh bagian luarnya (menyertakan sumbu dan label sumbu). Ada dua nilai yang mungkin didefinisikan dalam enumerasi [LayoutTargetType](https://reference.aspose.com/slides/id/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/id/python-java/aspose.slides/layouttargettype/#Inner) menunjukkan bahwa ukuran area plot tidak termasuk tanda centang dan label sumbu.
- [Outer](https://reference.aspose.com/slides/id/python-java/aspose.slides/layouttargettype/#Outer) menunjukkan bahwa ukuran area plot termasuk tanda centang dan label sumbu.

Contoh kode diberikan di bawah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Dalam satuan apa X aktual, Y aktual, lebar aktual, dan tinggi aktual dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana perbedaan Area Plot dengan Area Chart dalam hal konten?**

Area Plot adalah wilayah gambar data (seri, garis kisi, garis tren, dll.); Area Chart mencakup elemen sekitarnya (judul, legenda, dll.). Pada chart 3D, Area Plot juga mencakup dinding/lantai dan sumbu‑sumbu.

**Bagaimana X, Y, lebar, dan tinggi Area Plot diinterpretasikan ketika tata letak manual?**

Mereka merupakan pecahan (0–1) dari ukuran keseluruhan chart; dalam mode ini, penempatan otomatis dinonaktifkan dan pecahan yang Anda setel akan digunakan.

**Mengapa posisi Area Plot berubah setelah menambahkan atau memindahkan legenda?**

Legenda berada di area chart di luar Area Plot tetapi memengaruhi tata letak dan ruang yang tersedia, sehingga Area Plot dapat bergeser ketika penempatan otomatis aktif. (Ini adalah perilaku standar untuk chart PowerPoint.)