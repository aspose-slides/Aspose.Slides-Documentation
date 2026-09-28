---
title: "Kelola Slide Master Presentasi dalam C++"
linktitle: "Master Slide"
type: docs
weight: 80
url: /id/cpp/slide-master/
keywords:
- "master slide"
- "slide master"
- "slide master PPT"
- "beberapa slide master"
- "bandingkan slide master"
- "latar belakang"
- "placeholder"
- "kloning slide master"
- "salin slide master"
- "duplikasi slide master"
- "slide master yang tidak terpakai"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Kelola slide master dalam Aspose.Slides untuk C++: akses, edit, klon, bandingkan, dan hapus slide master pada presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Sebuah **slide master** menentukan pengaturan desain bersama untuk sekelompok slide. Itu dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, menyunting slide master adalah cara umum untuk menjaga konsistensi presentasi tanpa mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides for C++ mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide itu menjadi milik slide master.

Hierarki adalah:

1. **Slide master** - menentukan desain bersama dan tema.
1. **Layout slide** - menentukan susunan spesifik placeholder dan pemformatan tingkat layout.
1. **Normal slide** - berisi konten presentasi yang sebenarnya dan menggunakan satu layout slide.

![Hierarki slide master, layout slide, dan slide normal](slide-master_2.jpg)

Dalam Aspose.Slides, slide master direpresentasikan oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) . Semua slide master dalam sebuah presentasi tersedia melalui koleksi [Presentation::get_Masters](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_masters/) , yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Terapkan atau Ubah Tata Letak Slide](/slides/id/cpp/slide-layout/) .
{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Dalam Aspose.Slides, gunakan koleksi `get_Masters()` untuk mengakses slide master:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Anda juga dapat mendapatkan slide master yang digunakan oleh slide normal melalui layoutnya:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Apa yang Dimiliki Slide Master**

Slide master adalah objek yang mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/) , sehingga menampilkan banyak properti slide yang sama seperti yang digunakan oleh slide normal dan layout slide. Anggota khusus master terdaftar pada halaman API [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) .

Anggota slide master yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `get_Background()` | Menetapkan latar belakang slide tingkat master. |
| `get_Shapes()` | Menyimpan bentuk yang diletakkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `get_LayoutSlides()` | Menyimpan layout slide yang menjadi milik master. |
| `get_ThemeManager()` | Menyediakan akses ke API tema master. |
| `get_HeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout anaknya. |
| `GetDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan layout dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Bingkai Gambar](/slides/id/cpp/picture-frame/) .

## **Mengontrol Visibilitas Grafik Master**

Gunakan [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/set_showmastershapes/) untuk menyembunyikan grafik master yang diwariskan, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Berikan `false` ke [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/set_showmastershapes/) pada slide yang harus menghilangkan grafik tersebut dan `true` pada slide yang harus menampilkannya.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Contoh ini menggunakan layout **Blank** yang disertakan dengan presentasi baru dan menghapus placeholder slide awal.

### **Pilih Lingkup Pengaturan**

Slide normal menggunakan masternya melalui [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/get_layoutslide/) dan [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_masterslide/). Menetapkan properti pada slide individu hanya memengaruhi slide itu. Memberikan `false` ke [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/layoutslide/set_showmastershapes/) menyembunyikan grafik master untuk semua slide yang menggunakan layout bersama itu, meskipun pengaturan mereka sendiri `true`. Untuk menyembunyikan grafik hanya pada satu slide, ubah properti slide dan biarkan layout bersama tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada slide master itu sendiri. Pada master selalu mengembalikan `false`, dan menetapkan `true` memicu `System::NotSupportedException`. Terapkan pada slide normal atau layout saja.

### **Bedakan Grafik dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafik master | Mengontrol visibilitas shape master yang diwariskan tanpa menghapusnya atau mengubah shape slide itu sendiri. |
| Ubah isi latar belakang slide | Mengubah warna latar belakang, gradien, atau gambar. Grafik master adalah shape terpisah dan dapat tetap terlihat di atas latar belakang tersebut. Lihat [Latar Belakang Presentasi](/slides/id/cpp/presentation-background/) . |
| Hapus shape dari master | Menghapus shape sumber yang dibagikan, sehingga tidak lagi tersedia untuk slide mana pun yang menggunakan master tersebut. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout menentukan placeholder mana yang tersedia dan penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder dalam tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan layout slide yang menjadi milik master:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Anda juga dapat memformat shape placeholder yang sudah ada pada slide master. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Placeholder judul yang diformat diwariskan oleh slide normal](slide-master_8.png)

Untuk opsi placeholder dan pemformatan teks lebih lanjut, lihat [Setel Teks Prompt dalam Placeholder](/slides/id/cpp/manage-placeholder/) dan [Pemformatan Teks](/slides/id/cpp/text-formatting/) .

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang padat untuk slide master pertama:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk topik terkait, lihat [Latar Belakang Presentasi](/slides/id/cpp/presentation-background/) dan [Tema Presentasi](/slides/id/cpp/presentation-theme/) .

## **Mengkloning Slide Master ke Presentasi Lain**

Gunakan [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/addclone/) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Jika Anda perlu mengklon slide normal bersamaan dengan master-nya, lihat [Klon Slide](/slides/id/cpp/clone-slides/) .

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut mengklon master default, memberi klon latar belakang yang berbeda, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout itu:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Membandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `Equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/) . Perbandingan memeriksa struktur dan konten statis, seperti shape, teks, pemformatan, animasi, dan pengaturan slide lainnya. Itu tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Untuk informasi lebih lanjut, lihat [Bandingkan Slide Presentasi](/slides/id/cpp/compare-slides/) .

## **Atur Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `set_LastView` pada [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) untuk mengontrol tampilan yang dibuka PowerPoint pertama kali. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk pengaturan tampilan lebih lanjut, lihat [Simpan Presentasi](/slides/id/cpp/save-presentation/) .

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi digunakan oleh slide normal mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/id/cpp/aspose.slides/masterslidecollection/removeunused/) untuk menghapus master yang tidak terpakai dari koleksi `get_Masters()` :

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Anda juga dapat menggunakan metode low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master menentukan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide termasuk dalam slide master dan menentukan susunan spesifik placeholder. Slide normal menggunakan layout slide, sehingga mewarisi dari layout dan master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan beberapa master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, kemudian letakkan placeholder konten pada layout yang akan digunakan slide normal.

**Bisakah saya menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara aman secara langsung. Pindahkan terlebih dahulu slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.