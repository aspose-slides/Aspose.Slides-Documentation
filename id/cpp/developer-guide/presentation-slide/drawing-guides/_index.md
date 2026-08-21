---
title: Kelola Panduan Gambar dalam Presentasi di C++
linktitle: Panduan Gambar
type: docs
weight: 85
url: /id/cpp/drawing-guides/
keywords:
- panduan gambar
- panduan horizontal
- panduan vertikal
- panduan penyelarasan
- tampilan slide
- slide master
- slide tata letak
- master catatan
- master handout
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Menambahkan, mengakses, dan menghapus panduan gambar horizontal serta vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Panduan gambar adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Mereka sangat berguna ketika suatu aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama yang harus diikuti penulis saat menambahkan atau memindahkan konten.

Panduan gambar adalah bantuan penyuntingan, bukan konten slide. Mereka tidak muncul dalam tayangan slide atau output yang dirender. Aspose.Slides for C++ menampilkannya melalui antarmuka [IDrawingGuidesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguidescollection/) . Sebuah panduan direpresentasikan oleh [IDrawingGuide](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguide/) dan memiliki orientasi, posisi, serta warna.

Posisi diukur dalam poin dari sudut kiri atas slide atau master yang bersangkutan. Panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Menambahkan Panduan ke Tampilan Slide**

Gunakan [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/id/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) untuk mengelola panduan yang ditampilkan saat menyunting slide normal. Panggil [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguidescollection/add/) dengan nilai [Orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/orientation/) dan posisi dalam poin.

Contoh berikut menambahkan satu panduan vertikal di sebelah kanan tengah slide dan satu panduan horizontal di bawahnya:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengakses Panduan Gambar**

Metode [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguidescollection/get_count/) dan metode [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguidescollection/idx_get/) memberikan akses ke panduan yang ada. Metode [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguide/get_position/), dan [IDrawingGuide::get_Color](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguide/get_color/) mengembalikan properti saat ini dari sebuah panduan. Metode setter yang bersesuaian dapat mengubah properti tersebut.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Menambahkan Panduan ke Master dan Slide Tata Letak**

Master slide dan masing-masing slide tata letaknya dapat memiliki koleksi panduan gambar masing-masing. Gunakan [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/get_drawingguides/) untuk master slide dan [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_drawingguides/) untuk slide tata letak.

Contoh berikut menambahkan satu panduan vertikal ke master slide pertama dan satu panduan horizontal ke slide tata letak pertama:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Menambahkan Panduan ke Master Catatan dan Handout**

Master catatan dan master handout juga mendukung panduan gambar. Gunakan [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslide/get_drawingguides/) dan [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) untuk mengakses koleksi mereka. Jika sebuah presentasi tidak berisi salah satu master ini, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) atau [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) membuat master default dan mengembalikannya.

Contoh berikut menambahkan satu panduan horizontal ke master catatan dan satu panduan vertikal ke master handout:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Menghapus Panduan Gambar**

Panggil [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides/idrawingguidescollection/clear/) untuk menghapus semua panduan dari koleksi tertentu. Menghapus satu koleksi tidak memengaruhi panduan yang disimpan dalam ruang lingkup lain.

Contoh berikut menghapus panduan tampilan slide dan semua panduan pada master slide, slide tata letak, master catatan, dan master handout tanpa membuat master yang hilang:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apakah panduan gambar muncul dalam slide show atau gambar yang diekspor?**

Tidak. Panduan gambar adalah bantuan penyelarasan untuk penyuntingan dan tidak dirender sebagai konten presentasi.

**Apakah panduan gambar dapat ditambahkan langsung ke slide normal individu?**

Panduan penyuntingan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk master slide, slide tata letak, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi panduan?**

Posisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah menghapus panduan gambar menghilangkan bentuk atau mengubah konten slide?**

Tidak. Metode `Clear` hanya menghapus panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.