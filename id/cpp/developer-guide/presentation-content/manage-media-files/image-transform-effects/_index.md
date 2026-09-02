---
title: Kelola Efek Transformasi Gambar dalam Presentasi dengan C++
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/cpp/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- abu-abu
- duotone
- tint
- HSL
- penggantian warna
- blur
- transparansi
- efek alpha
- rantai efek
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Terapkan, rangkai, inspeksi, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Aspose.Slides mewakili penyesuaian gambar sebagai koleksi terurut dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulailah dengan [ISlidesPicture](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidespicture/) dan akses [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidespicture/get_imagetransform/). Koleksi [IImageTransformOperationCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini menunjukkan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar‑balik PPTX.

## **Memahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [ISlidesPicture](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidespicture/) termasuk dalam isian gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) adalah bentuk slide yang memiliki isian gambar terkait, geometri, pengaturan pangkas, dan pemformatan tingkat bingkai lainnya.

Oleh karena itu, operasi transformasi gambar tidak mengubah byte di [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/). Ketika `IPPImage` yang sama diteruskan ke [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addpictureframe/) lebih dari satu kali, setiap bingkai gambar baru menerima `ISlidesPicture` miliknya sendiri dan koleksi transformasinya sendiri. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lain menjadi grayscale, meskipun semuanya menggunakan sumber gambar tertanam yang sama.

Model `ISlidesPicture::get_ImageTransform` yang sama juga digunakan oleh isian gambar lainnya, seperti bentuk atau latar belakang slide. Contoh di bawah ini berfokus pada bingkai gambar.

## **Gunakan Rentang Parameter dan Satuan yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan satuan berikut. Simpan nilai dalam rentang ini meskipun versi perpustakaan tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target dapat menormalisasi, menghilangkan, atau menolak data tidak valid saat penyimpanan atau ketika PowerPoint membuka file.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` sampai `100`, persen; `0` membiarkan komponen tidak berubah. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Tidak ada parameter numerik. Alpha tidak berubah. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dua warna untuk piksel gelap dan terang. Saluran RGB dan alpha di `System::Drawing::Color` menggunakan `0` sampai `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue `0` inklusif sampai `360` eksklusif, dalam derajat; amount `-100` sampai `100`, persen. |
| [AddHSLEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue `0` inklusif sampai `360` eksklusif, dalam derajat; saturasi dan luminans `-100` sampai `100`, persen. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Warna pengganti menggunakan nilai saluran `0` sampai `255`. Nilai alpha yang ada tidak berubah. |
| [AddBlurEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius non‑negatif dan diukur dalam poin; `grow` mengontrol apakah konten yang blur dapat melampaui batas asli. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Persen non‑negatif. Gunakan `0` sampai `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` sampai `100`, persen opasitas. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` sampai `100`, persen ambang alpha. Nilai di bawah ambang menjadi transparan; nilai pada atau di atas ambang menjadi opak. |

Untuk modulasi alpha tetap, transparansi dan opasitas bersifat saling melengkapi. Misalnya, transparansi 35 % bersesuaian dengan nilai modulasi alpha 65 %.

## **Terapkan Kecerahan dan Kontras**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) mengembalikan operasi [IBrightnessContrast](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ibrightnesscontrast/). Pengaturan skalarnya disediakan saat operasi dibuat. Metode `IBrightnessContrast::GetEffective` mengembalikan nilai hanya‑baca yang dihitung dan dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15 % dan kontras sebesar 20 %, lalu menampilkan pratinjau tanpa mengubah gambar tertanam:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/brightnesscontrast/) adalah ekstensi efek gambar Office 2010 dan kurang portabel dibandingkan efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah putar‑balik PPTX, gunakan [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) dan verifikasi hasilnya setelah membuka kembali file. Bagian batasan format menjelaskan perbedaan ini secara lebih rinci.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada bingkai gambar berbeda yang menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, dan penggantian warna.

[IDuotone](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iduotone/) berisi dua parameter warna yang dapat diedit secara terpisah: `get_Color1` memetakan piksel gelap, sementara `get_Color2` memetakan piksel terang. Ini menjadikannya contoh berguna dari efek yang pengaturannya lebih kompleks daripada nilai skalar tunggal.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) menggantikan setiap warna piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [AddColorChangeEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), yang memetakan satu warna sumber ke warna lain dan menampilkan format warna sumber serta target.

## **Tambahkan Blur, Transparansi, dan Efek Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) memengaruhi semua saluran warna, termasuk alpha. Atur `grow` ke `true` ketika tepi yang blur dapat melampaui batas gambar asli.

Untuk transparansi seragam, gunakan [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Ia mengalikan setiap nilai alpha yang ada, sehingga piksel yang sebagian transparan tetap berbeda secara proporsional. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) malah menetapkan satu nilai alpha untuk semua piksel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) mengubah alpha menjadi dua tingkat berdasarkan ambang.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Operasi alpha tanpa parameter lainnya meliputi [AddAlphaCeilingEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), yang membuat setiap alpha bukan nol menjadi sepenuhnya opak; [AddAlphaFloorEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), yang membuat setiap alpha di bawah 100 % menjadi sepenuhnya transparan; dan [AddAlphaInverseEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), yang mengubah alpha menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `Add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai jalur pipa berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan berbeda dapat menghasilkan gambar yang berbeda.

Sebagai contoh, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai kembali hasil luminansi. Tint diikuti grayscale menghilangkan tint kembali. Demikian pula, penggantian alpha dapat menimpa nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa jenis operasi serta urutannya, dan menampilkan hasil yang dibuka kembali:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Koleksi tidak memberlakukan matriks kompatibilitas yang membatasi operasi warna, alpha, dan blur ke rantai terpisah. Mereka dapat digabungkan, tetapi kombinasi tidak selalu berguna. Penggantian warna tetap menghilangkan variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghapus dua warna yang dipilih; dan operasi alpha ceiling, floor, replacement, atau bi‑level dapat membuang detail alpha yang dibuat sebelumnya. Bangun rantai sesuai urutan pemrosesan piksel yang diinginkan, bukan memperlakukan item‑itemnya sebagai flag pemformatan tak berurutan.

## **Periksa Nilai yang Dapat Diedit dan Efektif**

Operasi yang dapat diedit adalah objek yang disimpan dalam `ISlidesPicture::get_ImageTransform`. Tergantung pada efeknya, objek tersebut dapat mengekspos anggota yang dapat ditulis secara langsung. Misalnya, [IBlur](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iblur/) mengekspos `set_Radius` dan `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ialphamodulatefixed/) mengekspos `set_Amount`, dan [IAlphaBiLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ialphabilevel/) mengekspos `set_Threshold`. Efek warna seperti [IDuotone](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iduotone/) mengekspos objek [IColorFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/icolorformat/) yang dapat diubah.

Beberapa antarmuka operasi, termasuk [IBrightnessContrast](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/itint/), dan [IAlphaReplace](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ialphareplace/), tidak mengekspos skalar pembuatannya sebagai properti yang dapat ditulis. Untuk mengubah pengaturan tersebut, hapus operasi tersebut dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `GetEffective()` dihitung dan hanya‑baca. Data ini berguna untuk menyelesaikan warna yang bergantung pada tema dan membaca nilai ternormalisasi yang dipakai renderer, tetapi bukan permukaan penyuntingan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif untuk beberapa operasi umum:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse tetap memiliki objek data‑efektif, namun tidak ada pengaturan skalar untuk dicetak. Keberadaan dan posisinya dalam koleksi adalah informasi penting.

## **Hapus atau Bersihkan Transformasi Gambar**

Gunakan [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan `Clear()` untuk menghapus seluruh rantai.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Menghapus atau membersihkan transformasi hanya mengubah pemformatan gambar. Itu tidak menghapus, mengompresi ulang, atau mengubah sumber [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang digunakan kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang disarankan untuk mengedit rantai efek. Bahkan dengan PPTX, tidak semua operasi memiliki portabilitas yang identik:

- Operasi DrawingML standar seperti luminansi, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan setelah putar‑balik PPTX. Selalu buka kembali file yang dihasilkan dan periksa koleksinya ketika preservasi menjadi keharusan.
- [BrightnessContrast](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/brightnesscontrast/) merupakan ekstensi Office 2010, bukan operasi luminansi DrawingML standar. Ia dapat dipakai untuk rendering dalam memori, namun tidak dijamin tetap menjadi [IBrightnessContrast](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/ibrightnesscontrast/) yang dapat diedit setelah menyimpan dan membuka kembali PPTX. Lebih pilih [AddLuminanceEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format biner PPT mendahului model efek DrawingML lengkap. Menyimpan ke PPT dapat menghilangkan operasi yang tidak didukung, mereduksi rantai menjadi subset yang didukung, atau memperkirakan tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang dapat diedit secara kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung pada tampilan yang dirender. Output tersebut tidak berisi `IImageTransformOperationCollection` yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen atau vektor menyimpan representasi rendering mereka sendiri.
- Efek tidak membuat gambar terhubung menjadi mandiri. Rendering gambar yang ditautkan tetap bergantung pada ketersediaan sumber yang ditautkan ketika presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output yang kritis, uji baik putar‑balik yang dapat diedit maupun format ekspor akhir dengan versi Aspose.Slides yang sama seperti yang digunakan di produksi.

## **FAQ**

**Apakah efek transformasi gambar mengubah data gambar yang tertanam?**

Tidak. Operasi tersebut milik `ISlidesPicture` yang digunakan oleh isian gambar. Byte `IPPImage` yang mendasarinya tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan gambar yang sama berbagi efeknya?**

Tidak. Menggunakan kembali `IPPImage` menghindari duplikasi data gambar, tetapi setiap bingkai gambar biasanya memiliki `ISlidesPicture` dan koleksi transformasi gambar yang terpisah.

**Bisakah efek warna, blur, dan alpha digabungkan?**

Ya. Koleksi menerima semuanya dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan setiap operasi terhadap output operasi sebelumnya karena operasi penggantian dan ambang dapat menghapus detail warna atau alpha yang lebih awal.

**Mengapa nilai efektif hanya‑baca?**

Data efektif mewakili nilai yang dihitung untuk rendering, termasuk warna yang telah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi bila anggota yang dapat ditulis tersedia; bila tidak, hapus operasi tersebut dan tambahkan pengganti dengan parameter pembuatan baru.

**Format apa yang sebaiknya saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi file dengan membukanya kembali. PPT lama tidak dapat mewakili model efek DrawingML lengkap, dan format ekspor yang dirender hanya mempertahankan tampilan, bukan operasi transformasi yang dapat diedit.