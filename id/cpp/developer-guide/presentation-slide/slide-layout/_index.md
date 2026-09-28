---
title: Terapkan atau Ubah Tata Letak Slide dalam C++
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/cpp/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header bagian
- dua konten
- perbandingan
- hanya judul
- tata letak kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi tata letak slide dalam Aspose.Slides untuk C++, tambahkan placeholder, hapus tata letak yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Tata letak slide mendefinisikan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sambil memungkinkan setiap slide berisi kontennya masing‑masing.

Tata letak yang paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subjudul.
- **Title and Content**: Berisi placeholder judul dan placeholder konten umum.
- **Blank**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkat terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/) merupakan bagian dari master dan mendefinisikan susunan placeholder tertentu.
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari master‑nya. Nilai yang ditetapkan langsung pada normal slide akan menggantikan nilai yang diwarisi pada tingkat tersebut. Ketika normal slide dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak nanti tidak secara otomatis menambahkan bentuk placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah digunakan, periksa slide‑slide yang bergantung padanya dan tinjau presentasi yang dihasilkan.
- Tata letak yang masih digunakan oleh slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung padanya ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak digunakan.

Untuk informasi lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/cpp/slide-master/).

Untuk menyembunyikan logo yang diwarisi atau bentuk master dekoratif pada satu slide atau melalui tata letak bersama, lihat [Control the Visibility of Master Graphics](/slides/id/cpp/slide-master/). Contoh membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berbasis nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika tata letak tersebut tidak tersedia, secara sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan kesesuaian antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa output saat beralih antara tata letak yang sangat berbeda.

## **Tambah Tata Letak Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterlayoutslidecollection/add/) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Title and Content** baru dengan nama `Report Title and Content`, kemudian menambahkan slide normal berdasarkan tata letak tersebut. Nama tata letak harus unik dalam koleksi.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Tambahkan tata letak hanya ketika templat memang membutuhkan struktur yang dapat digunakan kembali. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali alih‑alih membuat duplikat.

## **Tambah Placeholder ke Tata Letak Slide**

Metode [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) menyediakan sebuah [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke tata letak.

| Placeholder PowerPoint               | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Konten](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Konten (Vertikal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Teks](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Teks (Vertikal)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Gambar](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabel](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Gambar Daring](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Contoh berikut memverifikasi bahwa tata letak **Blank** ada, menambahkan empat placeholder ke dalamnya, dan kemudian membuat slide normal yang menggunakan tata letak yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasil:

![Placeholder pada tata letak slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder tata letak yang ada dapat memengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Tata Letak Slide yang Tidak Digunakan**

Gunakan metode [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus tata letak yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih digunakan tetap utuh.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [get_HasDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) atau [GetDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/getdependingslides/). Alihkan slide yang bergantung sebelum memanggil [ILayoutSlide::Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/remove/). Mencoba menghapus tata letak yang masih digunakan akan menimbulkan [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Tata Letak Slide**

Sebuah tata letak memiliki footer, nomor slide, dan placeholder tanggal‑waktu sendiri. Gunakan metode [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) untuk mengontrol placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak dengan aman dan membuat elemen footernya terlihat:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kontrol Visibilitas Footer pada Master dan Tata Letak Anak‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Metode propagasi dari [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslideheaderfootermanager/) beroperasi pada master serta tata letak slide dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apa Perbedaan antara Master Slide dan Layout Slide?**

Sebuah master slide mendefinisikan tema presentasi dan pemformatan bersama. Sebuah layout slide merupakan bagian dari master dan mendefinisikan satu susunan placeholder yang dapat digunakan kembali. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Apakah Saya Dapat Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Saat menyalin antar presentasi, juga verifikasi font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Jika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan styling yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [GetDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/getdependingslides/) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus hanya layout yang tidak direferensikan.