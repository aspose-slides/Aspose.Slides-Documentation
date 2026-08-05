---
title: Sesuaikan legenda diagram dalam presentasi menggunakan C++
linktitle: Legenda Diagram
type: docs
url: /id/cpp/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk C++ guna mengoptimalkan presentasi PowerPoint dengan format legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan format pada entri legenda individu.

Ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda panjang terbungkus atau menggunakan pemisah baris, dan membiarkan format legenda mewarisi dari tema presentasi ketika pengaturan teks dan isian eksplisit tidak diterapkan.

## **Penempatan Legenda**
Untuk mengatur properti legenda, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
- Dapatkan referensi slide.
- Menambahkan diagram pada slide.
- Mengatur properti legenda.
- Simpan presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengatur posisi dan ukuran legenda Diagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Atur Ukuran Font Legenda**
Aspose.Slides untuk C++ memungkinkan pengembang mengatur ukuran font legenda. Ikuti langkah-langkah berikut:

- Instansiasi kelas Presentation.
- Membuat diagram default.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Simpan presentasi ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Atur Ukuran Font Legenda Individual**
Aspose.Slides untuk C++ memungkinkan pengembang mengatur ukuran font entri legenda individu. Ikuti langkah-langkah berikut:

- Instansiasi kelas Presentation.
- Membuat diagram default.
- Akses entri legenda.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Simpan presentasi ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Apakah saya dapat mengaktifkan legenda sehingga diagram secara otomatis menyediakan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([set_Overlay(false)](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/legend/set_overlay/)); dalam kasus ini, area plot akan menyusut untuk menampung legenda.

**Apakah saya dapat membuat label legenda multi-baris?**

Ya. Label panjang secara otomatis terbungkus ketika ruang tidak cukup; pemisah baris paksa didukung melalui karakter baris baru dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan atur warna/isian/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan akan terbarui dengan benar ketika desain berubah.