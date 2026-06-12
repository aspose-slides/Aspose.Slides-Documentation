---
title: Buat Presentasi dalam C++
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/cpp/create-presentation/
keywords:
- buat presentasi
- presentasi baru
- buat PPT
- PPT baru
- buat PPTX
- PPTX baru
- buat ODP
- ODP baru
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat presentasi dalam C++ dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, serta simpan secara terprogram untuk hasil yang dapat diandalkan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan konten sederhana ke slide, dan menyimpan hasilnya sebagai file.

## **Buat Presentasi PowerPoint**
Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
1. Dapatkan referensi slide dengan menggunakan Index‑nya.
1. Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**Format apa yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/cpp/save-presentation/), dan mengekspor ke [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/id/cpp/convert-powerpoint-to-xps/), [HTML](/slides/id/cpp/convert-powerpoint-to-html/), [SVG](/slides/id/cpp/convert-powerpoint-to-png/), serta [gambar](/slides/id/cpp/convert-powerpoint-to-png/), antara lain.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpannya sebagai PPTX biasa?**

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/cpp/supported-file-formats/).

**Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [ukuran slide](/slides/id/cpp/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih cara konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 satuan.

**Bagaimana cara menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/cpp/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan pilih alur kerja berbasis file daripada alur kerja yang sepenuhnya dalam memori.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/cpp/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/cpp/licensing/) satu kali per proses. XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika melibatkan banyak thread.

**Apakah saya dapat menandatangani secara digital PPTX yang saya buat?**

Ya. [Tanda tangan digital](/slides/id/cpp/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/cpp/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.