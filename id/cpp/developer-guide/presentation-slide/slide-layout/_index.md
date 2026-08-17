---
title: Terapkan atau Ubah Layout Slide di C++
linktitle: Layout Slide
type: docs
weight: 60
url: /id/cpp/slide-layout/
keywords:
- layout slide
- layout konten
- placeholder
- desain presentasi
- desain slide
- layout tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header bagian
- dua konten
- perbandingan
- hanya judul
- layout kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi layout slide dalam Aspose.Slides untuk C++, tambahkan placeholder, hapus layout yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Layout slide mendefinisikan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan layout memberikan slide struktur yang konsisten sekaligus memungkinkan setiap slide berisi kontennya sendiri.

Layout yang paling umum meliputi:

- **Slide Judul**: Berisi placeholder judul dan subjudul.
- **Judul dan Konten**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Kosong**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Layout**

Sebuah presentasi memiliki tiga tingkat terkait:

1. A [slide master](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
1. A [layout slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/) termasuk dalam sebuah master dan mendefinisikan susunan placeholder tertentu.
1. A [normal slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) menggunakan satu layout dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari layoutnya, dan layout mewarisi dari masternya. Nilai yang ditetapkan langsung pada slide normal akan menggantikan nilai yang diwariskan pada tingkat tersebut. Ketika sebuah normal slide dibuat, bentuk placeholder‑nya dihasilkan dari layout yang dipilih, sedangkan konten yang dimasukkan ke dalam placeholder tersebut menjadi milik slide normal.

Tambahkan placeholder yang diperlukan ke layout sebelum membuat slide darinya. Menambahkan placeholder lain ke layout kemudian tidak secara otomatis menambahkan bentuk placeholder yang bersesuaian ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwariskan atau geometri placeholder yang ada pada layout dapat memperbarui setiap slide yang bergantung padanya. Sebelum menyunting layout yang sudah digunakan, periksa slide‑slide yang bergantung dan tinjau presentasi yang dihasilkan.
- Layout yang masih digunakan oleh sebuah slide tidak dapat dihapus. Pindahkan slide‑slide yang bergantung ke layout lain terlebih dahulu, atau hapus hanya layout yang tidak digunakan.

Untuk info lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/cpp/slide-master/).

## **Pilih dan Terapkan Layout Slide**

Gunakan tipe layout ketika presentasi mengikuti definisi layout PowerPoint standar. Nama layout dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Judul dan Konten** pada master pertama. Jika layout tersebut tidak tersedia, secara sengaja beralih ke **Kosong**. Pemeriksaan null kedua diperlukan karena presentasi dapat berisi hanya layout khusus. Layout yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/set_layoutslide/).

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

Mengubah layout sebuah slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwariskan, dan korespondensi antara placeholder yang ada dengan layout baru dapat berubah, jadi periksa output ketika beralih antara layout yang sangat berbeda.

## **Tambahkan Layout Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih layout yang ada; ia tidak membuat yang baru. Untuk membuat layout, panggil metode [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterlayoutslidecollection/add/) pada koleksi layout master target.

Contoh berikut selalu menambahkan layout **Judul dan Konten** baru bernama `Report Title and Content`, lalu menambahkan slide normal berdasarkan layout tersebut. Nama layout harus unik dalam koleksi.

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

Tambahkan layout hanya ketika templat memang membutuhkan struktur dapat dipakai ulang lainnya. Jika layout yang cocok sudah ada, pilih dan gunakan kembali alih‑alih membuat duplikat.

## **Tambahkan Placeholder ke Layout Slide**

Metode [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) menyediakan sebuah [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke layout.

| Placeholder PowerPoint               | `ILayoutPlaceholderManager` Method |
| ------------------------------------ | ---------------------------------- |
| ![Konten](content.png)               | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Konten (Vertikal)](contentV.png)   | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Teks](text.png)                    | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Teks (Vertikal)](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Gambar](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png)                | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabel](table.png)                  | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                  | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Gambar Online](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Contoh berikut memverifikasi bahwa layout **Kosong** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang menggunakan layout yang dimodifikasi. Urutan dibuat sengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang bersesuaian pada slide tersebut.

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

![Placeholder pada layout slide](add_placeholders.png)

{{% alert color="warning" title="Peringatan" %}}
Mengubah pemformatan yang diwariskan atau geometri placeholder layout yang ada dapat memengaruhi slide‑slide yang bergantung. Placeholder layout yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan layout pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Layout Slide yang Tidak Digunakan**

Gunakan metode [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus layout yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan layout yang masih dipakai tetap utuh.

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

Untuk menghapus satu layout tertentu, pertama gunakan metode [get_HasDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) atau [GetDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/getdependingslides/). Pindahkan slide‑slide yang bergantung sebelum memanggil [ILayoutSlide::Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/remove/). Mencoba menghapus layout yang masih digunakan akan menghasilkan [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Layout Slide**

Sebuah layout memiliki footer, nomor slide, dan placeholder tanggal‑waktu miliknya sendiri. Gunakan metode [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) untuk mengontrol placeholder‑placeholder tersebut pada satu layout. Ini berguna ketika, misalnya, layout konten harus menampilkan footer tetapi layout judul tidak.

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

## **Kontrol Visibilitas Footer pada Master dan Layout Anak-nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Metode propagasi dari [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslideheaderfootermanager/) beroperasi pada master serta layout slide dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

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

**Apa Perbedaan antara Slide Master dan Layout Slide?**

Slide master mendefinisikan tema dan pemformatan bersama untuk seluruh presentasi. Layout slide termasuk dalam master dan mendefinisikan satu susunan placeholder yang dapat dipakai ulang. Slide normal menggunakan layout tersebut dan menyimpan konten khusus slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Saat menyalin antar presentasi, pastikan juga memeriksa font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Ketika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide‑slide yang bergantung mewarisi perubahan layout kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwariskan dapat berubah pada banyak slide sekaligus. Gunakan [GetDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/getdependingslides/) untuk mengidentifikasi slide yang terpengaruh sebelum menyunting layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxeditexception/). Pindahkan slide‑slide yang bergantung terlebih dahulu, atau gunakan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus hanya layout yang tidak direferensikan.