---
title: Buat Presentasi di .NET
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Buat presentasi di .NET dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatis untuk hasil yang dapat diandalkan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan kotak teks ke slide pertamanya, dan menyimpan hasilnya sebagai file. Artikel ini juga menunjukkan cara membuat dan menyimpan presentasi kosong, serta cara membuka presentasi yang ada dalam format yang didukung dan menyimpannya dalam format lain. FAQ singkat di bagian akhir mencakup pertanyaan umum tentang format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

Sebelum memulai, tambahkan Aspose.Slides ke proyek Anda dari NuGet. Lihat [Installation](/slides/id/net/installation/) untuk paket yang digunakan pada Windows, Linux, dan macOS.

## **Membuat Presentasi PowerPoint**

Untuk membuat presentasi dan menempatkan kotak teks pada slide pertama, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Presentasi baru sudah berisi satu slide kosong.  
2. Dapatkan slide tersebut dari koleksi [Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/) dengan indeksnya, 0.  
3. Tambahkan persegi panjang dengan metode [AddAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addautoshape/) dan atur [teks](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/text/).  
4. Simpan presentasi sebagai file PPTX dengan metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Sudut kiri atas persegi panjang berada 50 poin dari tepi kiri dan 50 poin dari tepi atas slide, dan persegi panjang tersebut memiliki lebar 400 poin dan tinggi 100 poin. File yang disimpan berisi satu slide dengan persegi panjang itu dan teksnya. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Licensing](/slides/id/net/licensing/).

## **Membuat dan Menyimpan Presentasi**

<a name="csharp-create-save-presentation"></a>

Untuk membuat presentasi kosong dan menyimpannya, buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan simpan dalam format apa pun dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/). Hasilnya adalah presentasi dengan satu slide kosong.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Membuka dan Menyimpan Presentasi**

<a name="csharp-open-save-presentation"></a>

Untuk mengonversi presentasi dari satu format ke format lain, buka dengan memberikan jalurnya ke konstruktor [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/presentation/), lalu simpan dalam format target. Aspose.Slides mendeteksi format input, seperti PPT, PPTX, atau ODP, dari file itu sendiri.

Contoh di bawah mengharapkan sebuah presentasi OpenDocument bernama *Sample.odp* di direktori kerja dan menyimpannya sebagai PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Format apa yang dapat saya simpan untuk presentasi baru?

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/net/save-presentation/), dan mengekspor ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/), [XPS](/slides/id/net/convert-powerpoint-to-xps/), [HTML](/slides/id/net/convert-powerpoint-to-html/), [SVG](/slides/id/net/render-a-slide-as-an-svg-image/), serta [gambar](/slides/id/net/convert-powerpoint-to-png/), antara lain.

### Bisakah saya memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX biasa?

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/net/supported-file-formats/).

### Bagaimana cara mengontrol ukuran slide/rasio aspek saat membuat presentasi?

Atur [slide size](/slides/id/net/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus di‑skala.

### Dalam satuan apa ukuran dan koordinat diukur?

Dalam poin: 1 inci sama dengan 72 satuan.

### Bagaimana cara menangani presentasi yang sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?

Gunakan [BLOB management strategies](/slides/id/net/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file dibandingkan aliran murni dalam memori.

### Bisakah saya membuat/menyimpan presentasi secara paralel?

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/net/multithreading/). Jalankan instance terpisah dan terisolasi per thread atau proses.

### Bagaimana cara menghilangkan watermark percobaan dan batasan?

[Terapkan lisensi](/slides/id/net/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika beberapa thread terlibat.

### Bisakah saya menandatangani secara digital PPTX yang saya buat?

Ya. [Digital signatures](/slides/id/net/digital-signature-in-powerpoint/) (menambah dan memverifikasi) didukung untuk presentasi.

### Apakah makro (VBA) didukung dalam presentasi yang dibuat?

Ya. Anda dapat [buat/ubah proyek VBA](/slides/id/net/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.