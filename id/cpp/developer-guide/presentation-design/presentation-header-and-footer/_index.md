---
title: Kelola Header dan Footer Presentasi di C++
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/cpp/presentation-header-and-footer/
keywords:
- header
- teks header
- footer
- teks footer
- atur header
- atur footer
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, serta handout dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides untuk C++ memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui antarmuka manajer header/footer.

Placeholder yang tersedia tergantung pada ruang lingkup:

| Ruang Lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Slide reguler | Tidak | Ya | Ya | Ya |
| Master catatan | Ya | Ya | Ya | Ya |
| Slide catatan | Ya | Ya | Ya | Ya |
| Master handout | Ya | Ya | Ya | Ya |

Slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan handout. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Ruang lingkup perubahan tergantung pada manajer yang Anda gunakan. Antarmuka [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideheaderfootermanager/) mengontrol satu slide reguler. Antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotesslideheaderfootermanager/) mengontrol satu slide catatan. Manajer master dan tata letak juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara antarmuka [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) mengontrol master handout.

## **Atur Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manajer header/footer tiap slide, mengatur teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, jadi Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`SetFooterText`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) dan [`SetDateTimeText`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) untuk mengatur teks, serta [`SetFooterVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), dan [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) untuk menampilkan placeholder yang bersangkutan.

Contoh end-to-end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama pada semua slide reguler:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Jika Anda hanya perlu memperbarui satu slide, akses slide tersebut langsung melalui [`Presentation::get_Slide`](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slide/) alih-alih menelusuri seluruh koleksi slide.

## **Atur Header dan Footer pada Master Catatan**

Master catatan mendefinisikan pemformatan umum dan perilaku placeholder untuk halaman catatan. Gunakan antarmuka [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya master catatan itu sendiri.

Contoh berikut mengatur header, footer, dan teks tanggal/waktu pada master catatan serta membuat semua placeholder yang didukung terlihat pada master tersebut:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Metode [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) mengembalikan `nullptr` ketika presentasi tidak berisi master catatan.

## **Terapkan Pengaturan Master Catatan ke Slide Catatan Anak**

Master catatan dapat menerapkan pengaturan header dan footer pada dirinya sendiri serta semua slide catatan yang bergantung. Gunakan metode propagasi khusus pada [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hirarki catatan.

Sebagai contoh, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) dan [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) memperbarui header master catatan dan semua header anak. Metode setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Metode propagasi yang digunakan di atas adalah [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), dan [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Atur Header dan Footer pada Slide Catatan Individual**

Slide catatan terkait dengan slide reguler tertentu. Gunakan antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotesslidemanager/addnotesslide/) mengembalikan slide catatan untuk slide saat ini dan membuatnya jika belum ada. Contoh berikut mengonfigurasi halaman catatan yang terkait dengan slide presentasi pertama:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Jika Anda pertama-tama menyebarkan pengaturan dari master catatan lalu mengubah slide catatan individual, pengaturan per‑slide berikutnya memungkinkan Anda menyesuaikan halaman catatan tersebut secara terpisah.

## **Atur Header dan Footer pada Master Handout**

Halaman handout menggunakan master handout untuk placeholder header, footer, tanggal/waktu, dan nomor halaman mereka. Tidak seperti halaman catatan, pengaturan handout dikelola melalui master handout, bukan melalui slide handout individual.

Gunakan [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) untuk mengakses master handout. Jika tidak ada, panggil [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) untuk membuat master handout default.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Pahami Ruang Lingkup dan Pewarisan**

Pilih manajer header/footer yang sesuai dengan ruang lingkup yang ingin Anda ubah:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslideheaderfootermanager/) mengontrol slide tata letak dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslideheaderfootermanager/) mengontrol master catatan dan dapat menyebarkan pengaturan ke semua slide catatan yang bergantung.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotesslideheaderfootermanager/) mengubah satu slide catatan dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) mengubah master handout dan mendukung keempat tipe placeholder.

Gunakan propagasi dari master atau tata letak ketika pengaturan yang sama harus diterapkan di seluruh hirarki. Gunakan manajer slide individual atau slide‑catatan ketika Anda membutuhkan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header pada slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan handout.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manajer header/footer yang bersangkutan untuk memeriksa visibilitasnya dan aktifkan bila diperlukan. Misalnya, [`get_IsFooterVisible`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) melaporkan apakah placeholder footer ada, dan [`SetFooterVisibility`](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Gunakan [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/set_firstslidenumber/) untuk mengatur nomor slide pertama. Placeholder nomor slide kemudian akan menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama dengan konten presentasi lainnya dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.