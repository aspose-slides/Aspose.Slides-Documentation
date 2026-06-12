---
title: Sesuaikan Grafik 3D dalam Presentasi Menggunakan С++
linktitle: Grafik 3D
type: docs
url: /id/cpp/3d-chart/
keywords:
- grafik 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan grafik 3-D di Aspose.Slides untuk С++, dengan dukungan untuk file PPT dan PPTX—tingkatkan presentasi Anda hari ini."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan grafik 3D di Aspose.Slides dengan mengonfigurasi pengaturan `Rotation3D` seperti `RotationX`, `RotationY`, `DepthPercents`, dan `RightAngleAxes`. Panduan ini meliputi pembuatan presentasi, menambahkan grafik 3D dengan data default, menerapkan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Atur Properti RotationX, RotationY, dan DepthPercents pada Grafik 3D**
Aspose.Slides untuk C++ menyediakan API sederhana untuk mengatur properti ini. Artikel berikut akan membantu Anda mengatur berbagai properti seperti Rotasi X, Y, **DepthPercents**, dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
1. Akses slide pertama.
1. Tambahkan grafik dengan data default.
1. Atur properti Rotation3D.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Tipe grafik apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari grafik kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui enumerasi [ChartType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/) di referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster dari grafik 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor grafik ke gambar melalui [chart API](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) atau [render seluruh slide](/slides/id/cpp/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda membutuhkan pratinjau pixel-perfect atau ingin menyematkan grafik ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan rendering grafik 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran yang sesuai (resolusi dan dimensi) untuk memenuhi kebutuhan tampilan atau cetak target.