---
title: Sesuaikan Diagram Donat dalam Presentasi dengan Python
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/python-net/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk Python via .NET, mendukung format PowerPoint dan OpenDocument untuk presentasi dinamis."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya pada pengaturan `doughnut_hole_size` dan mendemonstrasikan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga mencakup FAQ singkat yang membahas skenario terkait diagram donat, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang “meledak”, serta mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**
Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
- Tambahkan diagram donat pada slide.
- Tentukan ukuran lubang pada diagram donat.
- Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur ukuran lubang pada diagram donat.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Buat instansi kelas Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Tulis presentasi ke disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat membuat donat bertingkat dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat “meledak” (irisan terpisah) didukung?**

Ya. Terdapat tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individu.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah bentuk; Anda dapat merendernya ke [raster image](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/) atau mengekspor diagram ke gambar [SVG](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/).