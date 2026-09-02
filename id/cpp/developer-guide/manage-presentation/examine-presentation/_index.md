---
title: Mengambil dan Memperbarui Informasi Presentasi dalam C++
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/cpp/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- ambil properti
- baca properti
- ubah properti
- modifikasi properti
- perbarui properti
- periksa PPTX
- periksa PPT
- periksa ODP
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan C++ untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/documentproperties/) serta mendemonstrasikan operasi tipikal untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format apa (PPT, PPTX, ODP, dan lainnya) yang sedang digunakan oleh presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode C++ berikut:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Dapatkan Properti Presentasi**

Kode C++ ini menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki presentasi PowerPoint dengan properti dokumen seperti yang ditunjukkan di bawah.

![Properti dokumen asli presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Presentasi dengan Proteksi Kata Sandi](/slides/id/cpp/password-protected-presentation/)
- [Presentasi dengan Proteksi Penulisan](/slides/id/cpp/write-protected-presentation/)

## **FAQ**

**Bagaimana cara memeriksa apakah font tersemat dan yang mana?**

Cari informasi [embedded-font](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getembeddedfonts/) pada level presentasi, lalu bandingkan entri tersebut dengan kumpulan [font yang sebenarnya digunakan dalam konten](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getfonts/) untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasi melalui [slide collection](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidecollection/) dan periksa [visibility flag](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/get_hidden/) setiap slide.

**Bisakah saya mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [slide size and orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slidesize/) saat ini dengan preset standar; hal ini membantu memperkirakan perilaku saat mencetak dan mengekspor.

**Apakah ada cara cepat untuk melihat apakah chart merujuk ke sumber data eksternal?**

Ya. Jelajahi semua [charts](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/), periksa [data source](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana cara menilai slide 'berat' yang mungkin memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai area berpotensi menurunkan kinerja.