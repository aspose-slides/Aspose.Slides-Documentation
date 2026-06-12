---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam С++
linktitle: Garis Tren
type: docs
url: /id/cpp/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren kustom
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Dengan cepat menambahkan dan menyesuaikan garis tren dalam diagram PowerPoint menggunakan Aspose.Slides untuk С++ — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis kustom ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Tambahkan Garis Tren**
Aspose.Slides for C++ menyediakan API sederhana untuk mengelola Berbagai Garis Tren diagram:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (contoh ini menggunakan ChartType.ClusteredColumn).
4. Tambahkan garis tren eksponensial untuk seri diagram 1.
5. Tambahkan garis tren linear untuk seri diagram 1.
6. Tambahkan garis tren logaritmik untuk seri diagram 2.
7. Tambahkan garis tren rata‑rata bergerak untuk seri diagram 2.
8. Tambahkan garis tren polinomial untuk seri diagram 3.
9. Tambahkan garis tren pangkat untuk seri diagram 3.
10. Tulis presentasi yang telah dimodifikasi ke file PPTX.

The following code is used to create a chart with Trend Lines.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Tambahkan Garis Kustom**
Aspose.Slides for C++ menyediakan API sederhana untuk menambahkan garis kustom dalam diagram. Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas Presentation
- Dapatkan referensi slide dengan menggunakan Indeksnya
- Buat diagram baru menggunakan metode AddChart yang disediakan oleh objek Shapes
- Tambahkan AutoShape bertipe Garis menggunakan metode AddAutoShape yang disediakan oleh objek Shapes
- Atur Warna garis bentuk.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Apa arti 'forward' dan 'backward' pada garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan maju/mundur: untuk diagram scatter (XY) — dalam satuan sumbu; untuk diagram non‑scatter — dalam jumlah kategori. Hanya nilai tidak negatif yang diperbolehkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/cpp/create-shape-thumbnails/) itu sendiri.