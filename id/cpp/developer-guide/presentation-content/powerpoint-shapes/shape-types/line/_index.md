---
title: Menambahkan Bentuk Garis ke Presentasi di C++
linktitle: Garis
type: docs
weight: 50
url: /id/cpp/line/
keywords:
- garis
- membuat garis
- menambahkan garis
- garis biasa
- mengonfigurasi garis
- menyesuaikan garis
- gaya dash
- kepala panah
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dengan Aspose.Slides untuk C++. Temukan properti, metode, dan contoh."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatik. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis agar muncul sebagai panah.

Anda akan belajar cara menambahkan bentuk garis ke slide, mengatur tampilan visualnya, dan menyimpan presentasi yang diperbarui. Contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola dash, opsi kepala panah, dan warna isi.

## **Buat Garis Biasa**
Untuk menambahkan garis biasa sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance dari [kelas Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Line menggunakan metode [AddAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addautoshape/) yang disediakan oleh objek Shapes.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Buat Garis Berbentuk Panah**
Aspose.Slides untuk C++ juga memungkinkan pengembang mengkonfigurasi beberapa properti garis agar tampak lebih menarik. Mari coba konfigurasi beberapa properti garis agar tampak seperti panah. Ikuti langkah‑langkah berikut:

- Buat instance dari [kelas Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes.
- Atur Line Style ke salah satu gaya yang disediakan oleh Aspose.Slides untuk C++.
- Atur Width garis.
- Atur [Dash Style](https://reference.aspose.com/slides/id/cpp/aspose.slides/linedashstyle/) garis ke salah satu gaya yang disediakan oleh Aspose.Slides untuk C++.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/cpp/aspose.slides/lineformat/) dan Length titik awal garis.
- Atur Arrow Head Style dan Length titik akhir garis.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Apakah saya dapat mengubah garis biasa menjadi connector sehingga ia "menempel" ke bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/autoshape/) tipe [Line](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapetype/)) tidak otomatis menjadi connector. Untuk membuatnya menempel ke bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/cpp/aspose.slides/connector/) khusus dan [API terkait](/slides/id/cpp/connector/) untuk koneksi.

**Bagaimana saya harus melakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhir?**

[Baca properti efektif](/slides/id/cpp/shape-effective-properties/) melalui antarmuka [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilinefillformateffectivedata/) — antarmuka ini sudah memperhitungkan pewarisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukurannya)?**

Ya. Shapes menyediakan [objek lock](https://reference.aspose.com/slides/id/cpp/aspose.slides/autoshape/get_autoshapelock/) yang memungkinkan Anda [menolak operasi pengeditan](/slides/id/cpp/applying-protection-to-presentation/).