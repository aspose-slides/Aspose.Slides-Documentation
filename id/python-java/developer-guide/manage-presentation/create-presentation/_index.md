---
title: Buat Presentasi dengan Python via Java
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
description: "Buat presentasi dengan Python via Java menggunakan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatis untuk hasil yang handal."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi dengan Aspose.Slides untuk Python via Java, menambahkan bentuk dengan teks ke slide pertama, dan menyimpan hasilnya sebagai file PPTX. FAQ mencakup format output, templat, ukuran slide, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

## **Buat Presentasi**

Membuat file PowerPoint dari awal dengan Aspose.Slides untuk Python via Java sesederhana menginstansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) . Konstruktor secara otomatis menyediakan dek kosong dengan satu slide, memberikan kanvas langsung untuk bentuk, teks, diagram, atau konten lain yang dibutuhkan aplikasi Anda. Setelah Anda memodifikasi slide tersebut—atau menambahkan yang baru—Anda dapat menyimpan hasilnya ke format PPTX, PPT lama, atau bahkan format OpenDocument. Contoh kode singkat di bawah ini mengilustrasikan alur kerja ini dengan menambahkan bentuk sederhana ke slide pertama.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan slide pertama berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) bertipe [ShapeType.Cloud](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#Cloud) menggunakan [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) .
4. Atur teks bentuk menggunakan [TextFrame.setText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#setText) .
5. Simpan presentasi menggunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Pptx) .

Contoh berikut memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Ia memulai JVM jika belum berjalan, menambahkan bentuk awan ke slide pertama, dan menyimpan presentasi:

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

Hasil:

![Presentasi baru](new_presentation.png)

## **FAQ**

**Format apa yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/python-java/save-presentation/), dan mengekspor ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/python-java/convert-powerpoint-to-xps/), [HTML](/slides/id/python-java/convert-powerpoint-to-html/), [SVG](/slides/id/python-java/render-slide-as-svg/), dan [images](/slides/id/python-java/convert-powerpoint-to-png/), antara lain.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX biasa?**

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan serupa [didukung](/slides/id/python-java/supported-file-formats/) .

**Bagaimana saya mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [slide size](/slides/id/python-java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana cara menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [BLOB management strategies](/slides/id/python-java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file dibandingkan alur berbasis memori saja.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang sama dari [multiple threads](/slides/id/python-java/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Apply a license](/slides/id/python-java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika banyak thread terlibat.

**Apakah saya dapat menandatangani digital PPTX yang saya buat?**

Ya. [Digital signatures](/slides/id/python-java/digital-signature-in-powerpoint/) (menambah dan memverifikasi) didukung untuk presentasi.

**Apakah macro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [create/edit VBA projects](/slides/id/python-java/presentation-via-vba/) dan menyimpan file yang mendukung macro seperti PPTM/PPSM.