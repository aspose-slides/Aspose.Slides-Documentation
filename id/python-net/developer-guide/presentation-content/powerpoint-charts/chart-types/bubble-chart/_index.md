---
title: Sesuaikan Diagram Gelembung dalam Presentasi dengan Python
linktitle: Diagram Gelembung
type: docs
url: /id/python-net/bubble-chart/
keywords:
  - diagram gelembung
  - ukuran gelembung
  - skala ukuran
  - representasi ukuran
  - PowerPoint
  - OpenDocument
  - presentasi
  - Python
  - Aspose.Slides
description: "Buat dan sesuaikan diagram gelembung yang kuat di PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET untuk meningkatkan visualisasi data Anda dengan mudah."
---
## **Ikhtisar**

Artikel ini memperlihatkan cara bekerja dengan diagram gelembung di Aspose.Slides. Artikel ini mencakup dua opsi kustomisasi khusus: mengubah skala ukuran gelembung melalui properti `bubble_size_scale` dan mengontrol cara nilai ukuran gelembung direpresentasikan melalui properti `bubble_size_representation`.

Contoh-contoh menunjukkan cara membuat diagram gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung menjadi lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3-D”, mencatat bahwa batas praktis diagram tergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan diagram melalui mesin render Aspose.Slides.

## **Skala Ukuran Diagram Gelembung**
Aspose.Slides for Python via .NET menyediakan dukungan untuk skala ukuran diagram gelembung. Pada Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale** dan **ChartSeriesGroup.bubble_size_scale** telah ditambahkan. Contoh kode berikut diberikan.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Representasikan Data sebagai Ukuran Diagram Gelembung**
Properti **bubble_size_representation** telah ditambahkan ke kelas ChartSeries, ChartSeriesGroup. **bubble_size_representation** menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam diagram gelembung. Nilai yang mungkin adalah: **BubbleSizeRepresentationType.AREA** dan **BubbleSizeRepresentationType.WIDTH**. Oleh karena itu, enum **BubbleSizeRepresentationType** telah ditambahkan untuk menentukan cara-cara yang mungkin merepresentasikan data sebagai ukuran diagram gelembung. Contoh kode diberikan di bawah.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah “bubble chart with 3-D effect” didukung, dan bagaimana perbedaannya dengan yang reguler?**

Ya. Ada tipe diagram terpisah, “Bubble with 3-D.” Tipe ini menerapkan gaya 3-D pada gelembung tetapi tidak menambah sumbu tambahan; data tetap X‑Y‑S (ukuran). Tipe ini tersedia dalam enumerasi [chart type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/).

**Apakah ada batasan jumlah seri dan poin dalam diagram gelembung?**

Tidak ada batas keras pada tingkat API; batasan ditentukan oleh kinerja dan versi PowerPoint target. Disarankan untuk menjaga jumlah poin tetap wajar demi keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan diagram gelembung (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vektor, aturan rendering grafik diagram umum berlaku (resolusi, anti‑aliasing), jadi pilih DPI yang cukup untuk pencetakan.