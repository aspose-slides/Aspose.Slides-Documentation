---
title: Buat Presentasi di Python via Java
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/python-java/create-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Buat presentasi di Python via Java dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatis untuk hasil yang andal."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi dengan Aspose.Slides untuk Python via Java, menambahkan bentuk dengan teks ke slide pertama, dan menyimpan hasilnya sebagai file PPTX. FAQ mencakup format output, templat, ukuran slide, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

Sebelum memulai, instal Python, JDK, JPype, dan Aspose.Slides untuk Python via Java. Lihat [Instalasi](/slides/id/python-java/installation/) untuk langkah-langkah pada Windows, Linux, dan macOS.

## **Buat Presentasi**

Membuat file PowerPoint dari awal di Aspose.Slides untuk Python via Java semudah menginstansiasi kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) . Konstruktor secara otomatis menyediakan dek kosong dengan satu slide, memberi Anda kanvas langsung untuk bentuk, teks, diagram, atau konten lain yang dibutuhkan aplikasi Anda. Setelah Anda memodifikasi slide tersebut—atau menambahkan yang baru—Anda dapat menyimpan hasilnya ke format PPTX, PPT lama, atau bahkan format OpenDocument. Contoh kode singkat di bawah ini menggambarkan alur kerja ini dengan menambahkan bentuk sederhana ke slide pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. Dapatkan slide pertama dengan indeksnya, 0.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) dengan tipe [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) menggunakan [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) .
1. Atur teks bentuk menggunakan [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText) .
1. Simpan presentasi menggunakan [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) .

Contoh berikut memulai Java Virtual Machine (JVM) jika belum berjalan, menambahkan bentuk awan dengan teks ke slide pertama, dan menyimpan presentasi. Simpan sebagai *create_presentation.py*:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Buat presentasi dengan satu slide kosong.
presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk awan dan atur teksnya.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Simpan presentasi sebagai file PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jalankan skrip di lingkungan tempat Anda menginstal paket-paket:

```sh
python create_presentation.py
```

Sudut kiri-atas awan berada 20 poin dari tepi kiri dan atas slide, dan awan memiliki lebar 200 poin serta tinggi 80 poin. Skrip menyimpan *new_presentation.pptx* di direktori kerja saat ini, dengan satu slide yang berisi awan dan teksnya. JVM tetap berjalan hingga proses Python berakhir; lihat [Batasan dan Perbedaan API](/slides/id/python-java/limitations-and-api-differences/#import-the-library). Tanpa lisensi, Aspose.Slides juga menambahkan kotak teks watermark evaluasi ke setiap slide yang disimpan; lihat [Lisensi](/slides/id/python-java/licensing/) .

Hasilnya:

![Presentasi baru](new_presentation.png)

## **FAQ**

**Format apa yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/python-java/save-presentation/), dan mengekspor ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/python-java/convert-powerpoint-to-xps/), [HTML](/slides/id/python-java/convert-powerpoint-to-html/), [SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/), serta [gambar](/slides/id/python-java/convert-powerpoint-to-png/), dan lain-lain.

**Bisakah saya memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX reguler?**

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan serupa [didukung](/slides/id/python-java/supported-file-formats/) .

**Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [ukuran slide](/slides/id/python-java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana cara menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/python-java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan pilih alur kerja berbasis file daripada alur murni dalam memori.

**Bisakah saya membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/python-java/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/python-java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika beberapa thread terlibat.

**Bisakah saya menandatangani secara digital PPTX yang saya buat?**

Ya. [Tanda tangan digital](/slides/id/python-java/digital-signature-in-powerpoint/) (menambahkan dan memverifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/python-java/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.