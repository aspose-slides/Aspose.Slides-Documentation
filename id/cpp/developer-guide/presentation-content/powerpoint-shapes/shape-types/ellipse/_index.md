---
title: Menambahkan Elips ke Presentasi di C++
linktitle: Elips
type: docs
weight: 30
url: /id/cpp/ellipse/
keywords:
- elips
- bentuk
- menambahkan elips
- membuat elips
- menggambar elips
- elips terformat
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides untuk C++ pada presentasi PPT dan PPTX — contoh kode C++ disertakan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint menggunakan Aspose.Slides. Artikel ini mencakup pembuatan elips sederhana, pembuatan elips dengan format, dan menyimpan presentasi yang telah diperbarui sebagai file PPTX. Artikel ini juga membahas pertanyaan terkait seperti bekerja dengan posisi dan ukuran elips, mengontrol urutan penumpukan, serta menerapkan efek animasi.

## **Buat Elips**
Dalam topik ini, kami akan memperkenalkan cara menambahkan bentuk elips ke slide mereka menggunakan Aspose.Slides untuk C++. Aspose.Slides untuk C++ menyediakan seperangkat API yang lebih mudah untuk menggambar berbagai jenis bentuk dengan hanya beberapa baris kode. Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah di bawah ini:

1. Buat instance dari [Presentation class](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)
1. Dapatkan referensi slide dengan menggunakan Index-nya
1. Tambahkan AutoShape tipe Ellipse menggunakan metode AddAutoShape yang disediakan oleh objek IShapes
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Buat Elips yang Diformat**
Untuk menambahkan elips yang diformat lebih baik ke slide, ikuti langkah-langkah di bawah ini:

1. Buat instance dari [Presentation class](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan AutoShape tipe Ellipse menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Setel Fill Type elips menjadi Solid.
1. Setel Color elips menggunakan properti SolidFillColor.Color yang disediakan oleh objek FillFormat yang terkait dengan objek IShape.
1. Setel Color garis elips.
1. Setel Width garis elips.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Bagaimana cara menetapkan posisi dan ukuran tepat elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, dasarkan perhitungan Anda pada ukuran slide dan konversikan milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilai.

**Bagaimana cara menempatkan elips di atas atau di bawah objek lain (mengontrol urutan penumpukan)?**

Sesuaikan urutan menggambar objek dengan membawa ke depan atau mengirim ke belakang. Ini memungkinkan elips menutupi objek lain atau memperlihatkan yang berada di bawahnya.

**Bagaimana cara menganimasi kemunculan atau penekanan elips?**

[Apply](/slides/id/cpp/shape-animation/) efek masuk, penekanan, atau keluar pada bentuk, dan konfigurasikan trigger serta timing untuk mengatur kapan dan bagaimana animasi diputar.