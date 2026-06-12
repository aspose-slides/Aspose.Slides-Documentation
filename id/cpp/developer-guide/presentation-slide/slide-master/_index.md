---
title: Kelola Slide Master Presentasi di C++
linktitle: Master Slide
type: docs
weight: 80
url: /id/cpp/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- banyak slide master
- bandingkan slide master
- latar belakang
- placeholder
- klon slide master
- salin slide master
- duplikat slide master
- slide master tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk C++: akses, edit, klon, bandingkan, dan hapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** menentukan pengaturan desain bersama untuk sekelompok slide. Itu dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasanya untuk menjaga konsistensi presentasi tanpa mengulangi pemformatan yang sama pada setiap slide.

Aspose.Slides untuk C++ mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih master slide, dan setiap master slide dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke master slide. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut merupakan bagian dari master slide.

Hierarki adalah:

1. **Slide master** - menentukan desain dan tema bersama.
1. **Layout slide** - menentukan susunan spesifik placeholder dan pemformatan tingkat layout.
1. **Normal slide** - berisi konten presentasi sebenarnya dan menggunakan satu layout slide.

![Hierarki master slide, layout slide, dan normal slide](slide-master_2.jpg)

Di Aspose.Slides, slide master diwakili oleh antarmuka [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/). Semua master slide dalam sebuah presentasi tersedia melalui koleksi [Presentation::get_Masters](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_masters/) , yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Sebagai contoh, jika master slide dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/slides/id/cpp/slide-layout/).
{{% /alert %}}

## **Akses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `get_Masters()` untuk mengakses master slide:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Anda juga dapat mendapatkan master slide yang digunakan oleh slide normal melalui layout-nya:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Apa yang Dimiliki Slide Master**

Master slide adalah objek yang mirip slide. Ia mengimplementasikan [IBaseSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/), sehingga mengekspos banyak properti slide yang sama digunakan oleh slide normal dan layout. Anggota khusus master tercantum pada halaman API [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/).

Anggota master slide yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `get_Background()` | Menetapkan latar belakang slide tingkat master. |
| `get_Shapes()` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `get_LayoutSlides()` | Menyimpan layout slide yang termasuk dalam master. |
| `get_ThemeManager()` | Menyediakan akses ke API tema master. |
| `get_HeaderFooterManager()` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout turunannya. |
| `GetDependingSlides()` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke master slide, gambar tersebut muncul pada slide yang menggunakan layout dari master tersebut. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

```cpp
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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/cpp/picture-frame/).

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Master slide menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout memutuskan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder dalam tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, bekerja dengan layout slide yang termasuk dalam master:

```cpp
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

Anda juga dapat memformat bentuk placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```cpp
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

![Placeholder judul yang diformat diwarisi oleh slide normal](slide-master_8.png)

Untuk lebih banyak opsi placeholder dan pemformatan teks, lihat [Set Prompt Text in Placeholder](/slides/id/cpp/manage-placeholder/) dan [Text Formatting](/slides/id/cpp/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwarisi oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang solid untuk master slide pertama:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/cpp/presentation-background/) dan [Presentation Theme](/slides/id/cpp/presentation-theme/).

## **Menduplikasi Slide Master ke Presentasi Lain**

Gunakan [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/addclone/) untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Jika Anda perlu menduplikasi slide normal bersama master-nya, lihat [Clone Slides](/slides/id/cpp/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa master slide. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola master slide](slide-master_9.jpg)

Contoh berikut menduplikasi master default, memberi klon latar belakang yang berbeda, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout tersebut:

```cpp
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

Master slide dapat dibandingkan dengan metode `Equals` yang diwarisi dari [IBaseSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ini tidak membandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```cpp
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

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/cpp/compare-slides/).

## **Mengatur Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `set_LastView` pada [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) untuk mengontrol tampilan yang dibuka pertama kali oleh PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk pengaturan tampilan lebih lanjut, lihat [Save Presentation](/slides/id/cpp/save-presentation/).

## **Menghapus Master Slide yang Tidak Digunakan**

Presentasi terkadang berisi master slide yang tidak lagi digunakan oleh slide normal mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan mempermudah pemeliharaan templat.

Gunakan [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/id/cpp/aspose.slides/masterslidecollection/removeunused/) untuk menghapus master yang tidak terpakai dari koleksi `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Anda juga dapat menggunakan metode low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master menentukan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide merupakan bagian dari master slide dan menentukan susunan spesifik placeholder. Slide normal menggunakan layout slide, sehingga ia mewarisi dari layout maupun master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan beberapa master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke master slide atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada master slide, kemudian letakkan placeholder konten pada layout yang akan digunakan slide normal.

**Apakah saya dapat menghapus master slide yang masih digunakan?**

Tidak. Master slide yang memiliki slide bergantung tidak dapat dihapus secara langsung dengan aman. Pertama pindahkan slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.