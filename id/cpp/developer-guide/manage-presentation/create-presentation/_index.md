---
title: Membuat Presentasi dalam C++
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
description: "Buat presentasi dalam C++ dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, serta simpan secara programatik untuk hasil yang andal."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan kotak teks ke slide pertamanya, dan menyimpan hasilnya sebagai file. FAQ singkat di akhir mencakup pertanyaan umum tentang format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

Sebelum memulai, tambahkan Aspose.Slides ke proyek Anda: dari NuGet dalam proyek Visual Studio di Windows, atau dari paket ZIP dengan CMake di Linux. Lihat [Instalasi](/slides/id/cpp/installation/).

## **Buat Presentasi PowerPoint**

Untuk membuat presentasi dan menempatkan kotak teks pada slide pertamanya, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) . Presentasi baru sudah berisi satu slide kosong.
1. Dapatkan slide tersebut dengan metode [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) dan indeksnya, 0.
1. Tambahkan persegi panjang dengan metode [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) , dan atur teksnya dengan metode [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) .
1. Simpan presentasi sebagai file PPTX dengan metode [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) .

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Sudut kiri‑atas persegi panjang berada 50 point dari tepi kiri dan 50 point dari tepi atas slide, dan persegi panjang memiliki lebar 400 point serta tinggi 100 point. Program menyimpan *hello.pptx* di direktori kerja, dengan satu slide yang berisi persegi panjang dan teksnya. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Lisensi](/slides/id/cpp/licensing/) .

## **FAQ**

### Format apa yang dapat saya simpan untuk presentasi baru?

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/cpp/save-presentation/), dan mengekspor ke [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/id/cpp/convert-powerpoint-to-xps/), [HTML](/slides/id/cpp/convert-powerpoint-to-html/), [SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/), serta [gambar](/slides/id/cpp/convert-powerpoint-to-png/) , di antaranya.

### Bisakah saya memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX reguler?

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan serupa [didukung](/slides/id/cpp/supported-file-formats/) .

### Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?

Atur [ukuran slide](/slides/id/cpp/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih cara konten harus diskalakan.

### Dalam satuan apa ukuran dan koordinat diukur?

Dalam point: 1 inci sama dengan 72 unit.

### Bagaimana cara menangani presentasi yang sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?

Gunakan [strategi manajemen BLOB](/slides/id/cpp/manage-blob/) , batasi penyimpanan dalam memori dengan memanfaatkan file temporer, dan lebih pilih alur kerja berbasis file dibanding aliran yang sepenuhnya berada di memori.

### Bisakah saya membuat/menyimpan presentasi secara paralel?

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/cpp/multithreading/) . Jalankan instance terpisah yang terisolasi per thread atau proses.

### Bagaimana cara menghilangkan watermark percobaan dan batasan?

[Terapkan lisensi](/slides/id/cpp/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika ada beberapa thread yang terlibat.

### Bisakah saya menandatangani secara digital PPTX yang saya buat?

Ya. [Tanda tangan digital](/slides/id/cpp/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

### Apakah macro (VBA) didukung dalam presentasi yang dibuat?

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/cpp/presentation-via-vba/) dan menyimpan file yang mendukung macro seperti PPTM/PPSM.