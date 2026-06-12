---
title: Sesuaikan Diagram Donat dalam Presentasi di .NET
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/net/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk .NET, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Ringkasan**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya pada pengaturan `DoughnutHoleSize` dan mendemonstrasikan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga menyertakan FAQ singkat yang mencakup skenario diagram donat terkait, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang meledak, dan mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**
Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
- Tambahkan diagram donat pada slide.
- Tentukan ukuran lubang pada diagram donat.
- Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur ukuran lubang pada diagram donat.

```c#
 // Buat instance dari kelas Presentation
 Presentation presentation = new Presentation();

 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
 chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // Tulis presentasi ke disk
 presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah saya dapat membuat donat multi‑level dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat "meledak" (irisan terpisah) didukung?**

Ya. Ada tipe diagram Donat Meledak [chart type](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individual.

**Bagaimana saya dapat memperoleh gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah shape; Anda dapat merendernya ke [raster image](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/) atau mengekspor diagram ke [SVG image](https://reference.aspose.com/slides/id/net/aspose.slides/shape/writeassvg/).