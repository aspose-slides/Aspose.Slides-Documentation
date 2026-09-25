---
title: Kelola Aksesibilitas Presentasi dalam C++
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/cpp/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- teks alternatif
- judul teks alternatif
- deskripsi teks alternatif
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Otomatisasi pemeriksaan aksesibilitas presentasi pada file PPT, PPTX, dan ODP dengan Aspose.Slides untuk C++—tingkatkan pengalaman pembaca layar dan tingkatkan kepatuhan."
---
## **Pendahuluan**

Teks alternatif membantu orang yang menggunakan teknologi bantu memahami makna gambar, diagram, dan bentuk informatif lainnya. Artikel ini menjelaskan cara membaca dan memperbarui judul serta deskripsi teks alternatif dengan Aspose.Slides for C++, membedakan deskripsi aksesibilitas dari nama bentuk yang digunakan dalam kode, dan memeriksa apakah sebuah bentuk ditandai sebagai dekoratif.

Fitur-fitur ini mendukung aksesibilitas presentasi, namun tidak menjamin hal tersebut. Urutan pembacaan, kontras warna, keterbacaan teks, dan persyaratan aksesibilitas lainnya juga perlu ditinjau.

## **Kelola Judul Teks Alternatif dan Deskripsi**

Gunakan teks alternatif untuk menjelaskan makna gambar, diagram, dan bentuk informatif lainnya kepada orang yang tidak dapat melihatnya. Properti berikut melayani tujuan yang berbeda:

| Properti atau konten | Tujuan |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Judul singkat untuk deskripsi alternatif. |
| [AlternativeText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_alternativetext/) | Deskripsi yang bermakna tentang konten atau tujuan bentuk dalam konteks slide. |
| [Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_name/) | Nama bentuk, yang dapat digunakan kode untuk menemukan bentuk tertentu dalam presentasi. |
| Teks yang terlihat | Konten yang ditampilkan pada slide, seperti teks bentuk atau judul dan label diagram. Memperbarui teks alternatif tidak mengubah konten ini. |

Ketika sebuah presentasi digunakan kembali sebagai templat, kode dapat menemukan bentuk berdasarkan [Name]‑nya sebelum memperbaruinya. Nama ini memiliki tujuan yang berbeda dari teks alternatif, yang menjelaskan apa yang disampaikan visual kepada pembaca. Pencarian berdasarkan nama memungkinkan penulis memperbaiki atau menerjemahkan deskripsi tanpa mengubah cara kode menemukan bentuk. Nama dapat diedit dan tidak dijamin unik, sehingga pastikan nama tersebut cocok dengan bentuk yang dimaksud; lihat [Identifikasi dan Temukan Bentuk](/slides/id/cpp/shape-manipulations/#identify-and-find-shapes).

Contoh berikut memerlukan `input.pptx` dengan gambar pintu masuk kantor sebagai bentuk pertama pada slide pertama. Gambar tersebut tidak boleh ditandai sebagai dekoratif. Contoh ini membaca dan mencetak judul serta deskripsi teks alternatif saat ini, memperbarui kedua nilai, dan menyimpan presentasi sebagai `output.pptx`. Sesuaikan kata‑kata dengan gambar sebenarnya dan informasi yang disampaikannya.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Menambahkan teks alternatif saja tidak menjamin aksesibilitas presentasi atau kepatuhan terhadap standar aksesibilitas. Tinjau deskripsi untuk akurasi dan relevansi, serta periksa urutan pembacaan, kontras warna, keterbacaan teks, dan persyaratan aksesibilitas lainnya. Visual informatif tidak boleh ditandai sebagai dekoratif; bagian berikutnya menunjukkan cara membaca [IsDecorative](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_isdecorative/).

## **Tandai sebagai Dekoratif**

Tanda “tandai sebagai dekoratif” menandai visual yang semata‑mata ornamental sehingga pembaca layar melewatinya, mengurangi kebisingan dan mempertahankan fokus pada konten yang bermakna. Terapkan pada latar belakang, hiasan, dan pemisah—tidak pernah pada diagram, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides mengekspos flag ini untuk deteksi dan validasi, memungkinkan pemeriksaan otomatis aksesibilitas dan pembersihan.

![Tandai sebagai Dekoratif](mark_as_decorative.png)

Contoh kode berikut menunjukkan cara menentukan apakah sebuah bentuk ditandai sebagai dekoratif.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **Tanya Jawab**

**Apa yang harus saya masukkan dalam judul dan deskripsi teks alternatif?**

Gunakan judul singkat untuk mengidentifikasi subjek dan deskripsi untuk menjelaskan informasi yang disampaikan visual dalam konteks slide. Untuk diagram, jelaskan tren atau perbandingan yang relevan daripada hanya menyebut “diagram”.

**Haruskah saya menggunakan teks alternatif untuk menemukan bentuk dalam templat?**

Lebih baik menemukan bentuk berdasarkan [Name] dan memastikan itu adalah bentuk yang diharapkan. Teks alternatif dapat diedit atau diterjemahkan, yang dapat memutus kode yang mencari deskripsi tepat; lihat [Identifikasi dan Temukan Bentuk](/slides/id/cpp/shape-manipulations/).

**Kapan sebuah bentuk harus ditandai sebagai dekoratif?**

Gunakan flag dekoratif untuk visual yang tidak menambah informasi, seperti hiasan ornamental. Gambar dan diagram yang menyampaikan makna memerlukan deskripsi yang sesuai.

**Apakah menambahkan teks alternatif membuat presentasi sepenuhnya dapat diakses?**

Tidak. Teks alternatif hanya menangani sebagian aspek aksesibilitas. Tinjau juga urutan pembacaan, kontras warna, keterbacaan teks, dan persyaratan lain yang berlaku; mengatur properti ini saja tidak menjamin kepatuhan.