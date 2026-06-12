---
title: Sesuaikan Diagram Gelembung dalam Presentasi Menggunakan С++
linktitle: Diagram Gelembung
type: docs
url: /id/cpp/bubble-chart/
keywords:
- diagram gelembung
- ukuran gelembung
- skala ukuran
- representasi ukuran
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Buat dan sesuaikan diagram gelembung yang kuat di PowerPoint dengan Aspose.Slides untuk С++ guna meningkatkan visualisasi data Anda dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan diagram gelembung di Aspose.Slides. Ini mencakup dua opsi penyesuaian khusus: mengubah skala ukuran gelembung melalui metode `set_BubbleSizeScale` dan mengontrol bagaimana nilai ukuran gelembung direpresentasikan melalui metode `set_BubbleSizeRepresentation`.

Contoh-contoh menunjukkan cara membuat diagram gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung menjadi lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3-D”, mencatat bahwa batas praktis diagram bergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan diagram melalui mesin perender Aspose.Slides.

## **Skala Ukuran Diagram Gelembung**
Aspose.Slides untuk C++ menyediakan dukungan untuk skala ukuran diagram gelembung. Di Aspose.Slides untuk **C++ IChartSeries.BubbleSizeScale** dan properti **IChartSeriesGroup.BubbleSizeScale** telah ditambahkan. Contoh sampel di bawah diberikan. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Representasikan Data sebagai Ukuran Diagram Gelembung**
Metode baru **get_BubbleSizeRepresentation()** telah ditambahkan ke kelas **IChartSeries** dan **ChartSeries**. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam diagram gelembung. Nilai yang memungkinkan adalah: **BubbleSizeRepresentationType.Area** dan **BubbleSizeRepresentationType.Width**. Oleh karena itu, enum **BubbleSizeRepresentationType** telah ditambahkan untuk menentukan cara-cara yang mungkin untuk merepresentasikan data sebagai ukuran diagram gelembung. Kode contoh diberikan di bawah.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Apakah diagram gelembung dengan efek 3-D didukung, dan bagaimana perbedaannya dengan diagram biasa?**

Ya. Ada tipe diagram terpisah, “Bubble with 3-D.” Ini menerapkan gaya 3-D pada gelembung tetapi tidak menambahkan sumbu tambahan; data tetap X-Y-S (ukuran). Tipe ini tersedia dalam enumerasi [chart type](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/).

**Apakah ada batas pada jumlah seri dan poin dalam diagram gelembung?**

Tidak ada batas keras pada tingkat API; kendala ditentukan oleh kinerja dan versi PowerPoint target. Disarankan untuk menjaga jumlah poin tetap wajar demi keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan diagram gelembung (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vektor, aturan rendering grafik diagram umum berlaku (resolusi, anti-aliasing), jadi pilih DPI yang cukup untuk pencetakan.