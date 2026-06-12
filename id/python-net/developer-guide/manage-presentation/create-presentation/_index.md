---
title: Buat Presentasi dalam Python
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
description: "Buat presentasi PowerPoint dalam Python dengan Aspose.Slides - hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, serta simpan secara terprogram untuk hasil yang andal."
---
## **Gambaran Umum**

Aspose.Slides for Python memungkinkan Anda membuat file presentasi baru sepenuhnya dengan kode. Artikel ini menunjukkan alur kerja inti—membuat objek [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) , mengambil slide pertama, menyisipkan bentuk sederhana, dan menyimpan hasilnya—sehingga Anda dapat melihat betapa sedikitnya pengaturan yang diperlukan untuk menghasilkan presentasi tanpa Microsoft Office. Karena API yang sama dapat menulis file PPT, PPTX, dan ODP, Anda dapat menargetkan format PowerPoint tradisional maupun OpenDocument dari satu basis kode. Aspose.Slides cocok untuk lingkungan desktop, web, atau server, memberikan aplikasi Python Anda titik awal yang efisien untuk menambahkan konten yang lebih kaya seperti teks, gambar, atau diagram setelah dek slide awal tersedia.

## **Buat Presentasi**

Membuat file PowerPoint dari awal di Aspose.Slides for Python sesederhana menginstansiasi kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) . Konstruktor secara otomatis menyediakan dek kosong dengan satu slide, memberi Anda kanvas langsung untuk bentuk, teks, diagram, atau konten lain yang dibutuhkan aplikasi Anda. Setelah Anda memodifikasi slide tersebut—atau menambahkan yang baru—Anda dapat menyimpan hasilnya ke PPTX, PPT lama, atau bahkan format OpenDocument. Contoh kode singkat di bawah ini menggambarkan alur kerja ini dengan menambahkan bentuk sederhana pada slide pertama.

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) bertipe `CLOUD` menggunakan metode `add_auto_shape` yang disediakan oleh koleksi `shapes` .
1. Tambahkan teks ke auto‑shape.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, bentuk awan ditambahkan ke slide pertama presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto-shape bertipe CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Simpan presentasi sebagai file PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Presentasi baru](new_presentation.png)

## **FAQ**

**Format apa yang dapat saya gunakan untuk menyimpan presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/python-net/save-presentation/), dan mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/id/python-net/convert-powerpoint-to-xps/), [HTML](/slides/id/python-net/convert-powerpoint-to-html/), [SVG](/slides/id/python-net/convert-powerpoint-to-png/), dan [gambar](/slides/id/python-net/convert-powerpoint-to-png/), serta format lainnya.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpannya sebagai PPTX biasa?**

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan sejenisnya [didukung](/slides/id/python-net/supported-file-formats/).

**Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [ukuran slide](/slides/id/python-net/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih cara konten skalanya.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana cara menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/python-net/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan pilih alur kerja berbasis file daripada alur berbasis stream murni.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/python-net/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/python-net/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika ada banyak thread yang terlibat.

**Apakah saya dapat menandatangani digital PPTX yang saya buat?**

Ya. [Tanda tangan digital](/slides/id/python-net/digital-signature-in-powerpoint/) (menambah dan memverifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/python-net/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.