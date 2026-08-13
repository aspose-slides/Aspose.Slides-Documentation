---
title: Kelola Latar Belakang Presentasi dalam C++
linktitle: Latar Belakang Slide
type: docs
weight: 20
url: /id/cpp/presentation-background/
keywords:
- latar belakang presentasi
- latar belakang slide
- warna solid
- warna gradien
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengatur latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++, dengan tip kode untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Warna solid, gradien, dan gambar biasanya digunakan untuk latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (berlaku pada beberapa slide sekaligus).

![Latar belakang PowerPoint](powerpoint-background.png)

## **Mengatur Latar Belakang Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide tertentu dalam presentasi—bahkan jika presentasi menggunakan slide master. Perubahan hanya berlaku pada slide yang dipilih.

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Setel slide’s [BackgroundType](https://reference.aspose.com/slides/id/cpp/aspose.slides/backgroundtype/) ke `OwnBackground`.
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) ke `Solid`.
4. Gunakan metode [get_SolidFillColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/get_solidfillcolor/) pada [FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh C++ berikut menunjukkan cara mengatur warna solid biru sebagai latar belakang untuk slide normal:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Atur warna latar belakang slide menjadi biru.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Simpan presentasi ke disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengatur Latar Belakang Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide master dalam sebuah presentasi. Slide master berfungsi sebagai templat yang mengontrol format untuk semua slide, sehingga ketika Anda memilih warna solid untuk latar belakang slide master, itu berlaku pada setiap slide.

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Setel [BackgroundType] slide master (melalui `get_Masters`) ke `OwnBackground`.
3. Setel latar belakang slide master [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) ke `Solid`.
4. Gunakan metode [get_SolidFillColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/get_solidfillcolor/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh C++ berikut menunjukkan cara mengatur warna solid (hijau hutan) sebagai latar belakang untuk slide master:

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
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Atur warna latar belakang slide Master menjadi hijau hutan.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Simpan presentasi ke disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengatur Latar Belakang Gradien untuk Slide**

Gradien adalah efek grafis yang dibuat oleh perubahan warna secara bertahap. Ketika digunakan sebagai latar belakang slide, gradien dapat membuat presentasi terlihat lebih artistik dan profesional. Aspose.Slides memungkinkan Anda mengatur warna gradien sebagai latar belakang untuk slide.

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Setel slide’s [BackgroundType](https://reference.aspose.com/slides/id/cpp/aspose.slides/backgroundtype/) ke `OwnBackground`.
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) ke `Gradient`.
4. Gunakan metode [get_GradientFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/get_gradientformat/) pada [FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/) untuk mengonfigurasi pengaturan gradien yang diinginkan.
5. Simpan presentasi yang telah dimodifikasi.

Contoh C++ berikut menunjukkan cara mengatur warna gradien sebagai latar belakang untuk slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Terapkan efek gradien pada latar belakang.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Simpan presentasi ke disk.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengatur Gambar sebagai Latar Belakang Slide**

Selain pengisian solid dan gradien, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Setel slide’s [BackgroundType](https://reference.aspose.com/slides/id/cpp/aspose.slides/backgroundtype/) ke `OwnBackground`.
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) ke `Picture`.
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide.
5. Tambahkan gambar ke koleksi gambar presentasi.
6. Gunakan metode [get_PictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/get_picturefillformat/) pada [FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang.
7. Simpan presentasi yang telah dimodifikasi.

Contoh C++ berikut menunjukkan cara mengatur gambar sebagai latar belakang untuk slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Atur properti gambar latar belakang.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Muat gambar.
auto image = Images::FromFile(u"Tulips.jpg");
// Tambahkan gambar ke koleksi gambar presentasi.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Simpan presentasi ke disk.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Contoh kode berikut menunjukkan cara mengatur tipe isi latar belakang menjadi gambar ubin dan memodifikasi properti ubin:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
Baca selengkapnya: [**Gambar Ubin Sebagai Tekstur**](/slides/id/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar konten slide lebih menonjol. Kode C++ berikut menunjukkan cara mengubah transparansi untuk gambar latar belakang slide:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Sebagai contoh.

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Dapatkan koleksi operasi transformasi gambar.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Temukan efek transparansi persentase tetap yang ada.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Setel nilai transparansi baru.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Simpan presentasi ke disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mendapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan antarmuka [IBackgroundEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibackgroundeffectivedata/) untuk mengambil nilai latar belakang efektif slide. Antarmuka ini menampilkan [FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) dan [EffectFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) yang efektif.

Dengan menggunakan metode `get_Background` pada kelas [BaseSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh C++ berikut menunjukkan cara mendapatkan nilai latar belakang efektif slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Ambil latar belakang efektif, dengan memperhitungkan master, layout, dan tema.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### Apakah saya dapat mengatur ulang latar belakang khusus dan memulihkan latar belakang tema/layout?

Ya. Hapus isian khusus slide, dan latar belakang akan diwarisi kembali dari slide [layout](/slides/id/cpp/slide-layout/)/[master](/slides/id/cpp/slide-master/) yang bersesuaian (yaitu, [latar belakang tema](/slides/id/cpp/presentation-theme/)).

### Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?

Jika sebuah slide memiliki isian sendiri, isian tersebut akan tetap tidak berubah. Jika latar belakang diwarisi dari [layout](/slides/id/cpp/slide-layout/)/[master](/slides/id/cpp/slide-master/), maka akan diperbarui agar sesuai dengan [tema baru](/slides/id/cpp/presentation-theme/).