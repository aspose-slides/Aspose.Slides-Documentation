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

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan konten sederhana ke slide, dan menyimpan hasilnya sebagai file. Artikel ini juga memperlihatkan cara membuat dan menyimpan presentasi baru, membuka presentasi yang sudah ada dalam format yang didukung, dan menyimpannya ke format lain. Selain itu, artikel ini mencakup FAQ singkat yang membahas pertanyaan umum terkait format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

## **Buat Presentasi PowerPoint**
Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas Presentation.
2. Dapatkan referensi slide dengan menggunakan Index-nya.
3. Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes.
4. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```c#
// Membuat objek Presentation yang mewakili file presentasi
using (Presentation presentation = new Presentation())
{
    // Mengambil slide pertama
    ISlide slide = presentation.Slides[0];

    // Menambahkan autoshape tipe garis
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Buat dan Simpan Presentasi**

<a name="csharp-create-save-presentation"><strong>Langkah: Buat dan Simpan Presentasi dalam C#</strong></a>

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Simpan _Presentation_ ke format apa pun yang didukung oleh [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Buka dan Simpan Presentasi**

<a name="csharp-open-save-presentation"><strong>Langkah: Buka dan Simpan Presentasi dalam C#</strong></a>

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dengan format apa pun, misalnya PPT, PPTX, ODP, dll.
2. Simpan _Presentation_ ke format apa pun yang didukung oleh [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/)

```c#
// Muat file yang didukung apa pun di Presentation misalnya ppt, pptx, odp dll.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Format apa yang dapat saya gunakan untuk menyimpan presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/net/save-presentation/), dan mengekspor ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/), [XPS](/slides/id/net/convert-powerpoint-to-xps/), [HTML](/slides/id/net/convert-powerpoint-to-html/), [SVG](/slides/id/net/convert-powerpoint-to-png/), dan [gambar](/slides/id/net/convert-powerpoint-to-png/), serta lainnya.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX reguler?**

Ya. Muat templat tersebut dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/net/supported-file-formats/).

**Bagaimana saya mengontrol ukuran slide/rasio aspek saat membuat presentasi?**

Atur [ukuran slide](/slides/id/net/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi kustom) dan pilih cara konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana saya menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/net/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan pilih alur kerja berbasis file daripada alur kerja murni dalam memori.

**Bisakah saya membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) yang sama dari [banyak thread](/slides/id/net/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/net/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika banyak thread terlibat.

**Bisakah saya menandatangani digital PPTX yang saya buat?**

Ya. [Tanda tangan digital](/slides/id/net/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/net/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.