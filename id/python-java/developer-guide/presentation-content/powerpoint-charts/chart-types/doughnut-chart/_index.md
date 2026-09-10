---
title: Sesuaikan Diagram Donat dalam Presentasi Menggunakan Python via Java
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/python-java/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk Python via Java, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang di tengahnya, dan menyimpan presentasi. Fokusnya pada metode [setDoughnutHoleSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) dan memperlihatkan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga menyertakan FAQ singkat yang mencakup skenario terkait diagram donat, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang “meletus”, serta mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**

{{% alert color="info" title="Catatan" %}}
Aspose.Slides untuk Python via Java mendukung penentuan ukuran lubang pada diagram donat. Bagian ini menunjukkan cara menentukan ukuran lubang dengan contoh.
{{% /alert %}}

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

1. Buat objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Tambahkan diagram donat ke slide.
3. Tentukan ukuran lubang pada diagram donat.
4. Simpan presentasi ke disk.

Contoh berikut mengatur ukuran lubang pada diagram donat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Buat instance kelas Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Simpan presentasi ke disk.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat membuat donat multi‑tingkat dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat — setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat “meletus” (irisan terpisah) didukung?**

Ya. Ada tipe diagram [Exploded Doughnut](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan‑irisan individual.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram merupakan [shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) ; Anda dapat merendernya menjadi [raster image](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) atau mengekspor diagram ke gambar SVG.