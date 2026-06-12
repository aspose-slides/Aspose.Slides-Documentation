---
title: Sesuaikan Diagram Donat dalam Presentasi Menggunakan С++
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/cpp/doughnut-chart/
keywords:
  - diagram donat
  - celah tengah
  - ukuran lubang
  - PowerPoint
  - presentasi
  - С++
  - Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk С++, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya pada metode `set_DoughnutHoleSize` dan memperlihatkan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

## **Tentukan Celah Tengah pada Diagram Donat**
Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
- Tambahkan diagram donat ke slide.
- Tentukan ukuran lubang pada diagram donat.
- Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur ukuran lubang pada diagram donat.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Apakah saya dapat membuat donat multi‑tingkat dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat “meledak” (irisan terpisah) didukung?**

Ya. Ada tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/) dan properti ledakan pada poin data; Anda dapat memisahkan irisan‑irisan secara individual.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah bentuk; Anda dapat merendernya ke [gambar raster](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) atau mengekspor diagram ke [gambar SVG](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/).