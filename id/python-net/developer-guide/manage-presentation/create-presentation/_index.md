---
title: Membuat Presentasi di Python
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Buat presentasi PowerPoint dalam Python dengan Aspose.Slides - hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatik untuk hasil yang dapat diandalkan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi dengan Aspose.Slides untuk Python melalui .NET, menambahkan bentuk dengan teks ke slide pertama, dan menyimpan hasilnya sebagai file PPTX. API yang sama juga dapat menyimpan presentasi sebagai PPT dan ODP, sehingga Anda dapat menargetkan format PowerPoint dan OpenDocument dari satu basis kode, tanpa Microsoft Office. FAQ singkat di akhir mencakup pertanyaan umum tentang format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

Sebelum memulai, instal paket dari PyPI dengan `pip install aspose.slides`. Lihat [Instalasi](/slides/id/python-net/installation/) untuk pustaka yang juga diperlukan oleh Linux dan macOS, serta untuk lingkungan virtual yang diperlukan oleh Python sistem Debian dan Ubuntu.

## **Buat Presentasi**

Untuk membuat presentasi dan menempatkan bentuk dengan teks pada slide pertama, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Presentasi baru sudah berisi satu slide kosong.  
2. Dapatkan slide tersebut dari koleksi [slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/) dengan indeks 0.  
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) berbentuk awan menggunakan metode [add_auto_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_auto_shape/) pada koleksi [shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/shapes/) slide, dan atur [text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/text/)-nya.  
4. Simpan presentasi sebagai file PPTX menggunakan metode [save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Buat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto-shape tipe CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Simpan presentasi sebagai file PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Sudut kiri‑atas awan berada 20 poin dari tepi kiri dan 20 poin dari tepi atas slide, serta awan berukuran 200 poin lebar dan 80 poin tinggi. Pernyataan `with` melepaskan sumber daya presentasi saat blok selesai. Skrip menyimpan *new_presentation.pptx* di folder saat ini, dengan satu slide yang berisi awan dan teksnya. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Lisensi](/slides/id/python-net/licensing/).

Hasilnya:

![Presentasi baru](new_presentation.png)

## **FAQ**

### Format apa yang dapat saya simpan untuk presentasi baru?

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/python-net/save-presentation/), dan mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/id/python-net/convert-powerpoint-to-xps/), [HTML](/slides/id/python-net/convert-powerpoint-to-html/), [SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/), serta [gambar](/slides/id/python-net/convert-powerpoint-to-png/), antara lain.

### Bisakah saya memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX biasa?

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/python-net/supported-file-formats/).

### Bagaimana saya mengontrol ukuran/rasio aspek slide saat membuat presentasi?

Atur [ukuran slide](/slides/id/python-net/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

### Dalam satuan apa ukuran dan koordinat diukur?

Dalam poin: 1 inci sama dengan 72 satuan.

### Bagaimana saya menangani presentasi yang sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?

Gunakan [strategi manajemen BLOB](/slides/id/python-net/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file daripada aliran murni dalam memori.

### Bisakah saya membuat/menyimpan presentasi secara paralel?

Anda tidak dapat beroperasi pada instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/python-net/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

### Bagaimana cara menghapus watermark percobaan dan pembatasan?

[Terapkan lisensi](/slides/id/python-net/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika beberapa thread terlibat.

### Bisakah saya menandatangani secara digital PPTX yang saya buat?

Ya. [Tanda tangan digital](/slides/id/python-net/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

### Apakah makro (VBA) didukung dalam presentasi yang dibuat?

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/python-net/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.