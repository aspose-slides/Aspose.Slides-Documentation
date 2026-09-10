---
title: Kelola Penanda Data Grafik dalam Presentasi Menggunakan Python
linktitle: Penanda Data
type: docs
url: /id/python-java/chart-data-marker/
keywords:
- grafik
- titik data
- penanda
- opsi penanda
- ukuran penanda
- tipe isian
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara menyesuaikan penanda data grafik di Aspose.Slides untuk Python melalui Java, meningkatkan dampak presentasi pada format PPT dan PPTX dengan contoh kode Python yang jelas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan penanda data grafik di Aspose.Slides. Artikel ini menunjukkan cara membuat grafik, mengakses seri dan titik datanya, menerapkan isian gambar pada penanda di tingkat titik data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga mencatat bahwa bentuk penanda standar tersedia melalui enumerasi [MarkerStyleType](https://reference.aspose.com/slides/id/python-java/aspose.slides/markerstyletype/) dan bahwa tampilan penanda dipertahankan saat mengekspor grafik ke format raster atau SVG.

## **Atur Opsi Penanda Grafik**
Penanda dapat diatur pada titik data grafik dalam serangkaian tertentu. Untuk mengatur opsi penanda grafik, ikuti langkah‑langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Buat grafik default.
- Atur gambar.
- Akses seri grafik pertama.
- Tambahkan titik data baru.
- Tulis presentasi ke disk.

Contoh berikut mengatur opsi penanda grafik pada tingkat titik data.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Buat presentasi kosong.
presentation = Presentation()
try:
    # Akses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Membuat grafik default
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Dapatkan indeks worksheet data grafik default.
    default_worksheet_index = 0

    # Dapatkan workbook data grafik.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Hapus seri demo
    chart.getChartData().getSeries().clear()

    # Tambahkan seri baru
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Muat gambar pertama.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Muat gambar kedua.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Akses seri grafik pertama.
    series = chart.getChartData().getSeries().get_Item(0)

    # Tambahkan titik data.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Ubah ukuran penanda seri grafik.
    series.getMarker().setSize(15)

    # Simpan presentasi dengan grafik
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Bentuk penanda apa yang tersedia secara default?**

Bentuk standar tersedia (lingkaran, persegi, wajik, segitiga, dll.); daftarnya didefinisikan oleh kelas [MarkerStyleType](https://reference.aspose.com/slides/id/python-java/aspose.slides/markerstyletype/). Jika Anda membutuhkan bentuk non‑standar, gunakan penanda dengan isian gambar untuk meniru visual khusus.

**Apakah penanda dipertahankan saat mengekspor grafik ke gambar atau SVG?**

Ya. Saat merender grafik ke [raster formats](/slides/id/python-java/convert-powerpoint-to-png/) atau menyimpan [shapes as SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/), penanda mempertahankan tampilan dan pengaturannya, termasuk ukuran, isian, dan garis luar.