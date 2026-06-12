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
- dapatkan properti
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
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan C++ untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/documentproperties/) serta menunjukkan operasi umum untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lainnya) yang sedang digunakan oleh presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi tersebut. Lihat kode C++ berikut:

``` cpp
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

Kode C++ berikut menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) yang memungkinkan Anda mengubah properti presentasi.

Misalkan kami memiliki presentasi PowerPoint dengan properti dokumen seperti yang ditunjukkan di bawah ini.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah ini.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Memeriksa apakah Presentasi terenkripsi](https://docs.aspose.com/slides/id/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Memeriksa apakah Presentasi dilindungi tulis (baca-saja)](https://docs.aspose.com/slides/id/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Memeriksa apakah Presentasi dilindungi kata sandi sebelum dimuat](https://docs.aspose.com/slides/id/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Mengonfirmasi Kata Sandi yang Digunakan untuk Melindungi Presentasi](https://docs.aspose.com/slides/id/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Bagaimana cara memeriksa apakah font tertanam dan font mana saja yang tertanam?**

Cari informasi [informasi font tertanam](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getembeddedfonts/) pada tingkat presentasi, lalu bandingkan entri tersebut dengan kumpulan [font yang sebenarnya digunakan dalam konten](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getfonts/) untuk mengidentifikasi font mana yang penting untuk proses rendering.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasi melalui [koleksi slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidecollection/) dan periksa [flag visibilitas](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/get_hidden/) setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide kustom digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [ukuran dan orientasi slide saat ini](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slidesize/) dengan preset standar; ini membantu memperkirakan perilaku saat mencetak dan mengekspor.

**Apakah ada cara cepat untuk melihat apakah diagram merujuk ke sumber data eksternal?**

Ya. Telusuri semua [diagram](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/), periksa [sumber data](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; beri skor kompleksitas kasar untuk menandai potensi titik panas kinerja.