---
title: Sesuaikan Bagan Gelembung dalam Presentasi Menggunakan C++
linktitle: Bagan Gelembung
type: docs
url: /id/cpp/bubble-chart/
keywords:
- bagan gelembung
- ukuran gelembung
- skala ukuran
- representasi ukuran
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat dan sesuaikan bagan gelembung yang kuat di PowerPoint dengan Aspose.Slides untuk C++ guna meningkatkan visualisasi data Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan bagan gelembung di Aspose.Slides. Artikel ini mencakup dua opsi penyesuaian spesifik: mengubah skala ukuran gelembung melalui metode `set_BubbleSizeScale` dan mengendalikan bagaimana nilai ukuran gelembung direpresentasikan melalui metode `set_BubbleSizeRepresentation`.

Contoh-contoh menunjukkan cara membuat bagan gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung menjadi lebar. Artikel ini juga mencakup bagian FAQ singkat yang menjelaskan dukungan untuk tipe bagan “Bubble with 3-D”, mencatat bahwa batas praktis bagan bergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan bagan melalui mesin render Aspose.Slides.

## **Skala Ukuran Bagan Gelembung**
Aspose.Slides for C++ menyediakan dukungan untuk skala ukuran bagan gelembung. Di Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** dan **IChartSeriesGroup.BubbleSizeScale** properti telah ditambahkan. Contoh sampel diberikan di bawah. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representasikan Data sebagai Ukuran Bagan Gelembung**
Metode baru **get_BubbleSizeRepresentation()** telah ditambahkan ke kelas **IChartSeries** dan **ChartSeries**. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam bagan gelembung. Nilai yang mungkin adalah: **BubbleSizeRepresentationType.Area** dan **BubbleSizeRepresentationType.Width**. Sejalan dengan itu, enum **BubbleSizeRepresentationType** telah ditambahkan untuk menentukan cara-cara yang mungkin dalam merepresentasikan data sebagai ukuran bagan gelembung. Kode contoh diberikan di bawah.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Apakah "bagan gelembung dengan efek 3-D" didukung, dan bagaimana perbedaannya dengan yang biasa?**

Ya. Ada tipe bagan terpisah, "Bubble with 3-D." Tipe ini menerapkan gaya 3-D pada gelembung tetapi tidak menambahkan sumbu tambahan; data tetap X-Y-S (ukuran). Tipe ini tersedia dalam enumerasi [chart type](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/).

**Apakah ada batasan jumlah seri dan titik dalam bagan gelembung?**

Tidak ada batas keras pada tingkat API; batasan ditentukan oleh kinerja dan versi PowerPoint target. Disarankan untuk menjaga jumlah titik tetap wajar agar dapat dibaca dan proses render tidak terlalu lambat.

**Bagaimana proses ekspor memengaruhi tampilan bagan gelembung (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan bagan; proses render dilakukan oleh mesin Aspose.Slides. Untuk format raster atau vektor, aturan umum render grafik bagan berlaku (resolusi, anti‑aliasing), jadi pilih DPI yang cukup untuk pencetakan.