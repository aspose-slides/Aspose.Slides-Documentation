---
title: Sesuaikan Diagram Donat dalam Presentasi Menggunakan C++
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
- C++
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk C++, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokus dibahas pada metode `set_DoughnutHoleSize` serta langkah‑langkah dasar yang diperlukan untuk menyesuaikan jenis diagram ini melalui kode.

## **Menentukan Celah Tengah pada Diagram Donat**
Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
- Tambahkan diagram donat ke slide.
- Tentukan ukuran lubang pada diagram donat.
- Tulis presentasi ke disk.

Dalam contoh di bawah, kami telah mengatur ukuran lubang pada diagram donat.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Apakah saya dapat membuat donat berlapis‑multilevel dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi satu cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat “meledak” (irisan terpisah) didukung?**

Ya. Ada tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan‑irisan secara individual.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah bentuk; Anda dapat merendernya menjadi [raster image](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) atau mengekspor diagram ke gambar [SVG](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/).