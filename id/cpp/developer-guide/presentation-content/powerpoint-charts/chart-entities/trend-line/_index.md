---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam C++
linktitle: Garis Tren
type: docs
url: /id/cpp/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linier
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren kustom
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Dengan cepat menambahkan dan menyesuaikan garis tren pada diagram PowerPoint menggunakan Aspose.Slides untuk C++ — panduan praktis untuk melibatkan audiens Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linier, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren ke depan dan ke belakang serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Aspose.Slides for C++ menyediakan API sederhana untuk mengelola berbagai Garis Tren pada diagram:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (contoh ini menggunakan ChartType.ClusteredColumn).
4. Menambahkan garis tren eksponensial untuk seri diagram 1.
5. Menambahkan garis tren linier untuk seri diagram 1.
6. Menambahkan garis tren logaritmik untuk seri diagram 2.
7. Menambahkan garis tren rata‑rata bergerak untuk seri diagram 2.
8. Menambahkan garis tren polinomial untuk seri diagram 3.
9. Menambahkan garis tren pangkat untuk seri diagram 3.
10. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Kode berikut digunakan untuk membuat diagram dengan Garis Tren.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Menambahkan Garis Kustom**

Aspose.Slides for C++ menyediakan API sederhana untuk menambahkan garis kustom ke dalam diagram. Untuk menambahkan garis polos sederhana ke slide yang dipilih dalam presentasi, silakan ikuti langkah‑langkah berikut:

- Buat instance dari kelas Presentation
- Dapatkan referensi slide dengan menggunakan Indeksnya
- Buat diagram baru menggunakan metode AddChart yang disediakan oleh objek Shapes
- Tambahkan AutoShape tipe Garis menggunakan metode AddAutoShape yang disediakan oleh objek Shapes
- Atur Warna garis bentuk.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX

Kode berikut digunakan untuk membuat diagram dengan Garis Kustom.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Apa arti 'forward' dan 'backward' pada garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide ke gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/cpp/create-shape-thumbnails/) itu sendiri.