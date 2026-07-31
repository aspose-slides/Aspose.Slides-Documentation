---
title: Kustomisasi Diagram 3D dalam Presentasi Menggunakan C++
linktitle: Diagram 3D
type: docs
url: /id/cpp/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram 3-D di Aspose.Slides untuk C++, dengan dukungan file PPT dan PPTX—tingkatkan presentasi Anda hari ini."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan diagram 3D di Aspose.Slides dengan mengonfigurasi pengaturan `Rotation3D` seperti `RotationX`, `RotationY`, `DepthPercents`, dan `RightAngleAxes`. Panduan ini meliputi pembuatan presentasi, penambahan diagram 3D dengan data default, penerapan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Setel Properti RotationX, RotationY, dan DepthPercents pada Diagram 3D**
Aspose.Slides untuk C++ menyediakan API sederhana untuk mengatur properti‑propersi ini. Artikel berikut akan membantu Anda cara menyetel properti berbeda seperti Rotasi X, Y, **DepthPercents**, dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Setel properti Rotation3D.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Jenis diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang dapat diakses melalui enumerasi [ChartType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar melalui [chart API](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) atau [render seluruh slide](/slides/id/cpp/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau pixel-perfect atau ingin menyematkan diagram ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa cepat proses membangun dan merender diagram 3D yang besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render dengan ukuran output yang sesuai (resolusi dan dimensi) untuk mencocokkan target tampilan atau kebutuhan cetak.