---
title: Sesuaikan Diagram Pai dalam Presentasi Menggunakan С++
linktitle: Diagram Pai
type: docs
url: /id/cpp/pie-chart/
keywords:
- diagram pai
- mengelola diagram
- menyesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram pai dalam С++ dengan Aspose.Slides, dapat diekspor ke PowerPoint, meningkatkan penceritaan data Anda dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram pai di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram pai standar.

Contoh-contoh berfokus pada langkah-langkah penyesuaian diagram secara praktis seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Kedua untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides untuk C++ kini mendukung opsi plot kedua untuk diagram Pie of Pie atau Bar of Pie. Pada topik ini, kita akan melihat contoh cara menentukan opsi tersebut menggunakan Aspose.Slides. Untuk menentukan properti-properti tersebut, ikuti langkah-langkah di bawah ini:

1. Instansiasikan objek kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Tambahkan diagram pada slide.
1. Tentukan opsi plot kedua dari diagram.
1. Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur properti yang berbeda untuk diagram Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Atur Warna Irisan Diagram Pai Otomatis**

Aspose.Slides untuk C++ menyediakan API sederhana untuk mengatur warna irisan diagram pai secara otomatis. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instansi kelas Presentation.
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Atur Judul diagram.
1. Atur seri pertama untuk Menampilkan Nilai.
1. Atur indeks lembar data diagram.
1. Dapatkan lembar kerja data diagram.
1. Hapus seri dan kategori yang dihasilkan secara default.
1. Tambahkan kategori baru.
1. Tambahkan seri baru.

Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, pustaka tersebut [mendukung](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/charttype/) plot sekunder untuk diagram pai, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Apakah saya dapat mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) (seperti PNG) tanpa seluruh presentasi.