---
title: Kelola Bagian Slide dalam Presentasi dengan C++
linktitle: Bagian Slide
type: docs
weight: 100
url: /id/cpp/slide-section/
keywords:
- buat bagian
- tambahkan bagian
- edit bagian
- ubah bagian
- nama bagian
- ambil slide bagian
- proses slide bagian
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk C++: buat, ganti nama, susun ulang, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Bagian mengatur slide berurutan menjadi grup bernama tanpa mengubah konten slide. Dengan Aspose.Slides untuk C++, Anda dapat membuat, menyusun ulang, mengganti nama, memeriksa, dan menghapus bagian melalui metode [Presentation::get_Sections](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sections/).

Bagian sangat berguna ketika:

- sebuah presentasi besar perlu dibagi menjadi topik atau bab logis;
- grup slide yang berbeda ditugaskan kepada kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat dan menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih-alih menghitungnya dari posisi slide.

## **Membuat dan Mengelola Bagian**

Gunakan [ISectionCollection::AddSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/addsection/) untuk membuat sebuah bagian dengan menentukan namanya dan slide awal. Aspose.Slides menentukan slide mana yang termasuk dalam bagian tersebut dari struktur bagian presentasi saat ini.

[ISectionCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/) yang sama juga memungkinkan Anda:

- memindahkan sebuah bagian bersama dengan slide-nya dengan menggunakan [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- menghapus hanya definisi bagian dengan [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/removesection/), yang tetap mempertahankan slide-nya;
- menghapus sebuah bagian dan slide-nya dengan [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- menambahkan sebuah bagian kosong di akhir dengan [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/appendemptysection/).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama slide-nya, dan menambahkan sebuah bagian kosong:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Setelah operasi ini, presentasi berisi bagian `Introduction` dengan slide-nya dan sebuah bagian kosong `Appendix`. Bagian `Results` dan slide-nya telah dihapus.

## **Mengganti Nama Bagian**

Untuk mengganti nama sebuah bagian, panggil [ISection::set_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/set_name/). Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Mengambil Slide dari Bagian**

Metode [Presentation::get_Sections](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sections/) mengembalikan sebuah [ISectionCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectioncollection/) yang dapat Anda enumerasi. Untuk setiap [ISection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/), panggil [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/getslideslistofsection/) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode tersebut mengembalikan sebuah [ISectionSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectionslidecollection/), yang menyediakan jumlah, akses indeks, dan enumerasi.

Contoh berikut membuat dua bagian terisi dan satu bagian kosong, kemudian mencetak setiap bagian [name](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/get_name/), [identifier](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/get_sectionid/), [starting slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/get_startedfromslide/), jumlah slide, dan nomor slide. Ia menggunakan akses indeks untuk membaca slide pertama dan loop `for` berbasis rentang untuk memproses setiap slide. Untuk bagian kosong, koleksi yang dikembalikan memiliki hitungan nol, akses indeks tidak digunakan, dan enumerasi tidak melakukan iterasi.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang bagian secara manual dari [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/get_startedfromslide/), indeks slide, dan slide awal bagian berikutnya.

Penyuntingan struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk penyusunan ulang slide, mengkloning slide ke dalam sebuah bagian, memindahkan sebuah bagian bersama slide-nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/getslideslistofsection/) setelah setiap perubahan tersebut alih-alih mempertahankan asumsi tentang batas sebelumnya.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Panggil [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/getslideslistofsection/) lagi setiap kali slide atau bagian disusun ulang, dikloning, dipindahkan, atau dihapus. Ini menjaga pemrosesan selanjutnya selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak mempertahankan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk enumerasi selanjutnya.

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, panggil [ISlide::set_Hidden](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/set_hidden/) untuk setiap slide dalam bagian tersebut.

**Bagaimana saya dapat menemukan bagian yang berisi sebuah slide?**

Enumerasikan [Presentation::get_Sections](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sections/), panggil [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/getslideslistofsection/) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/get_startedfromslide/) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `nullptr`.