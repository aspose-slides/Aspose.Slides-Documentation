---
title: Tambahkan Persegi Panjang ke Presentasi dalam C++
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/cpp/rectangle/
keywords:
- menambahkan persegi panjang
- membuat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang terformat
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk C++ — dengan mudah mendesain dan memodifikasi bentuk secara programatik."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX.

## **Buat Persegi Panjang Sederhana**
Seperti topik sebelumnya, topik ini juga membahas penambahan bentuk dan kali ini bentuk yang akan kita bahas adalah Rectangle. Pada topik ini, kami menjelaskan bagaimana pengembang dapat menambahkan persegi panjang sederhana atau yang diformat ke slide mereka menggunakan Aspose.Slides untuk C++. Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari [kelas Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan IAutoShape bertipe Rectangle menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan persegi panjang sederhana ke slide pertama presentasi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Buat Persegi Panjang yang Diformat**
Untuk menambahkan persegi panjang yang diformat ke slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari [kelas Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan IAutoShape bertipe Rectangle menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Atur Fill Type (jenis isi) persegi panjang menjadi Solid.
1. Atur Warna persegi panjang menggunakan properti SolidFillColor.Color yang disediakan oleh objek FillFormat yang terkait dengan objek IShape.
1. Atur Warna garis persegi panjang.
1. Atur Lebar garis persegi panjang.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Langkah-langkah di atas diimplementasikan dalam contoh di bawah ini.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [tipe bentuk](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapetype/) dengan sudut melengkung dan sesuaikan radius sudut di properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [tipe isi gambar](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/), berikan sumber gambar, dan konfigurasikan [mode peregangan/pengulangan](https://reference.aspose.com/slides/id/cpp/aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan cahaya?**

Ya. [Bayangan luar/dalam, cahaya, dan tepi lembut](/slides/id/cpp/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan hyperlink?**

Ya. [Tetapkan hyperlink](/slides/id/cpp/manage-hyperlinks/) pada klik bentuk (loncatan ke slide, file, alamat web, atau email).

**Bagaimana cara melindungi persegi panjang dari pergerakan dan perubahan?**

[Gunakan kunci bentuk](/slides/id/cpp/applying-protection-to-presentation/): Anda dapat melarang pergerakan, pengubahan ukuran, pemilihan, atau penyuntingan teks untuk mempertahankan tata letak.

**Bisakah saya mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [merender bentuk](http://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/) menjadi gambar dengan ukuran/skal yang ditentukan atau [mengekspornya sebagai SVG](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti aktual (efektif) dari persegi panjang dengan mempertimbangkan tema dan pewarisan?**

[Gunakan properti efektif bentuk](/slides/id/cpp/shape-effective-properties/): API mengembalikan nilai yang dihitung yang memperhitungkan gaya tema, tata letak, dan pengaturan lokal, mempermudah analisis format.