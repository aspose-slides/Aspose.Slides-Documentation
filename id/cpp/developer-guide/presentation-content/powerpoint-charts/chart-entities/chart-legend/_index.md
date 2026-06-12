---
title: "Sesuaikan Legenda Diagram dalam Presentasi Menggunakan С++"
linktitle: "Legenda Diagram"
type: docs
url: /id/cpp/chart-legend/
keywords:
- "legenda diagram"
- "posisi legenda"
- "ukuran font"
- "PowerPoint"
- "presentasi"
- "С++"
- "Aspose.Slides"
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk С++ guna mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individual.

Artikel ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda yang panjang membungkus atau menggunakan pemisah baris, dan membiarkan pemformatan legenda mewarisi dari tema presentasi ketika pengaturan teks dan isi eksplisit tidak diterapkan.

## **Penempatan Legenda**
Untuk mengatur properti legenda, ikuti langkah-langkah berikut:

- Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
- Ambil referensi slide.
- Tambahkan diagram pada slide.
- Atur properti legenda.
- Tulis presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengatur posisi dan ukuran legenda diagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Atur Ukuran Font Legenda**
Aspose.Slides for C++ memungkinkan pengembang mengatur ukuran font legenda. Ikuti langkah-langkah berikut:

- Buat instance kelas Presentation .
- Buat diagram default.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Tulis presentasi ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Atur Ukuran Font Legenda Individual**
Aspose.Slides for C++ memungkinkan pengembang mengatur ukuran font pada entri legenda individual. Ikuti langkah-langkah berikut:

- Buat instance kelas Presentation .
- Buat diagram default.
- Akses entri legenda.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Tulis presentasi ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Apakah saya dapat mengaktifkan legenda sehingga diagram secara otomatis menyediakan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([set_Overlay(false)](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/legend/set_overlay/)); dalam hal ini, area plot akan menyusut untuk menampung legenda.

**Apakah saya dapat membuat label legenda berdiri pada beberapa baris?**

Ya. Label yang panjang secara otomatis akan membungkus ketika ruang tidak cukup; pemisah baris paksa didukung melalui karakter newline dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan mengatur warna/isi/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan akan memperbarui dengan benar ketika desain berubah.