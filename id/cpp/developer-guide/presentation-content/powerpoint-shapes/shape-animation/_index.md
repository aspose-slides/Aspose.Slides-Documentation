---
title: Menerapkan Animasi Bentuk dalam Presentasi Menggunakan C++
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/cpp/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk animasi
- teks animasi
- menambahkan animasi
- mengambil animasi
- mengekstrak animasi
- menambahkan efek
- mengambil efek
- mengekstrak efek
- suara efek
- menerapkan animasi
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, penjadwalan, suara, perilaku setelah animasi, dan teks animasi dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Aspose.Slides for C++ merepresentasikan animasi slide sebagai efek dalam timeline slide. Sebuah efek memiliki shape target, tipe animasi dan subtipe, pemicu, pengaturan waktu, serta properti opsional seperti suara atau perilaku setelah animasi.

Timeline berisi dua jenis urutan:

- **Urutan utama** diputar saat slide maju.
- **Urutan interaktif** dimulai ketika shape pemicunya diklik.

Karena kotak teks, gambar, diagram, tabel, dan objek slide lainnya mengimplementasikan [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), Anda menggunakan metode [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/) yang sama untuk sebagian besar konten slide. Efek yang tersedia terdaftar dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effecttype/).

## **Menambahkan Animasi Shape**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/) dengan shape target, tipe efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika shape lain diklik, buat urutan interaktif dengan pemicu berupa shape tersebut.

Contoh berikut membuat kedua jenis animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pemicu mengatur kapan sebuah efek dimulai:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effecttriggertype/) menunggu klik di urutan utama, atau klik pada shape pemicu di urutan interaktif.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effecttriggertype/) dimulai bersamaan dengan efek sebelumnya.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effecttriggertype/) dimulai ketika efek sebelumnya selesai.

Untuk menganimasikan gambar, diagram, atau tipe shape lain, berikan objek tersebut ke [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/) alih-alih `targetShape`. Untuk opsi pengelompokan khusus diagram, lihat [Animated Charts](/slides/id/cpp/animated-charts/).

## **Membaca Animasi Shape**

Gunakan [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) ketika Anda mengetahui shape target. Untuk memeriksa setiap efek, enumerasi urutan utama dan setiap urutan interaktif. Enumerasi menghindari asumsi bahwa sebuah urutan berisi efek pada indeks `0`.

Contoh berikut membuat sebuah shape dengan efek urutan utama dan interaktif, mendapatkan efek yang menargetkan shape tersebut, kemudian enumerasi setiap urutan pada slide.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

Jika Anda hanya memerlukan efek untuk satu shape, pertama identifikasi shape tersebut berdasarkan nama, tipe placeholder, atau properti stabil lainnya; kemudian panggil [IShapeCollection::idx_get](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/idx_get/). Jangan mengasumsikan bahwa [IShapeCollection::idx_get](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/idx_get/) pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Diwariskan**

Placeholder pada slide normal dapat mewarisi perilaku animasi dari placeholder yang bersesuaian pada slide tata letak dan slide master. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/getbaseplaceholder/) mengembalikan placeholder induk tersebut, atau `nullptr` bila tidak ada induk.

Pada presentasi contoh berikut, footer memiliki **Random Bars** pada slide normal, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Efek animasi footer pada slide normal](slide-shape-animation.png)

![Efek animasi placeholder footer pada slide tata letak](layout-shape-animation.png)

![Efek animasi placeholder footer pada slide master](master-shape-animation.png)

Contoh berikut membangun hirarki placeholder sendiri. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang bersesuaian pada slide normal. Setiap pemanggilan [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/getbaseplaceholder/) diperiksa sebelum shape yang dikembalikan digunakan.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengubah Penjadwalan Animasi**

Dialog **Timing** PowerPoint dipetakan ke metode-metode [ITiming](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/).

![Dialog Timing PowerPoint untuk efek animasi](shape-animation.png)

- **Start** dipetakan ke [ITiming::set_TriggerType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** dipetakan ke [ITiming::set_Duration](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_duration/), dalam detik.
- **Delay** dipetakan ke [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), dalam detik.
- **Repeat** dipetakan ke [ITiming::set_RepeatCount](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), atau [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** dipetakan ke [ITiming::set_Rewind](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_rewind/).

Contoh terpisah ini menambahkan sebuah efek, mengubah penjadwalannya melalui objek yang dikembalikan oleh [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/), dan menyimpan hasilnya. Menjaga referensi [IEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/) yang dikembalikan menghindari penggunaan indeks koleksi yang tidak diperlukan.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gunakan satu mode pengulangan secara sengaja. Menggabungkan jumlah pengulangan dengan flag "until" dapat menghasilkan hasil yang membingungkan pada berbagai pemutar. Saat mengubah mode pengulangan, panggil [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) dan [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) sebelum [ITiming::set_RepeatCount](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/set_repeatcount/), karena mengatur salah satu flag juga mengubah mode pengulangan yang aktif.

## **Menambahkan dan Mengekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk audio tersemat melalui [IEffect::set_Sound](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) memberi tahu sebuah efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Menambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menyematkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua untuk menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/), sehingga tidak diperlukan indeks urutan.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Mengekstrak Suara Efek Tersemat**

Contoh berikut mengharapkan presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai kedua urutan utama dan interaktif serta menulis setiap suara efek tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih dari tipe MIME audio yang diberikan oleh [IAudio::get_ContentType](https://reference.aspose.com/slides/id/cpp/aspose.slides/iaudio/get_contenttype/).

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

Untuk objek audio berukuran besar, gunakan [IAudio::GetStream](https://reference.aspose.com/slides/id/cpp/aspose.slides/iaudio/getstream/) dan salin stream ke file alih-alih memuat seluruh objek ke dalam array byte.

## **Mengatur Perilaku Setelah Animasi**

Opsi **After animation** mengontrol apa yang terjadi pada sebuah shape setelah efeknya selesai.

![Dialog Opsi Efek PowerPoint menunjukkan pengaturan After animation](shape-after-animation.png)

Enumerasi [AfterAnimationType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/) mendukung membiarkan shape tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipe adalah [AfterAnimationType::Color](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/), panggil [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) untuk juga mengatur warna.

Contoh terpisah ini membuat sebuah efek, mengatur perilaku setelah animasinya melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Mengubah tipe dari [AfterAnimationType::Color](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/) menghapus pengaturan warna after-animation.

## **Menganimasikan Teks**

Animasi teks memiliki dua kontrol terkait:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itextanimation/set_buildtype/) mengontrol apakah paragraf muncul bersamaan atau per level paragraf.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) mengatur jeda antara kata atau huruf. Nilai positif adalah persentase dari durasi efek; nilai negatif adalah jeda dalam detik.

Contoh terpisah berikut menganimasikan kata-kata dalam sebuah kotak teks. [BuildType::AsOneObject](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/buildtype/) menonaktifkan pembuatan paragraf-per-paragraf sehingga pengaturan kata berlaku pada seluruh bingkai teks.

```cpp
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Untuk membangun kotak teks per paragraf, gunakan [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itextanimation/set_buildtype/) dengan [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/buildtype/) atau level paragraf lainnya. Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/) yang menerima sebuah [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/). Lihat [Animated Text](/slides/id/cpp/animated-text/) untuk contoh level paragraf.

## **Catatan Ekspor dan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, namun pemutaran akhir dikontrol oleh penampil presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [HTML5 export](/slides/id/cpp/export-to-html5/), GIF animasi, atau [video conversion](/slides/id/cpp/convert-powerpoint-to-video/) ketika output harus menampilkan gerakan.
- Untuk HTML5, aktifkan [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/html5options/set_animateshapes/) dan, bila diperlukan, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Render video mendukung banyak efek masuk, penekanan, keluar, dan jalur‑gerak yang umum, tetapi tidak semua efek PowerPoint didukung. Periksa [supported animations and effects](/slides/id/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) saat ini dan uji presentasi penting dengan versi Aspose.Slides target Anda.
- Efek kustom lanjutan dan efek yang diimpor dari format presentasi lain mungkin dipertahankan dalam berkas tetapi dirender berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **FAQ**

**Mengapa animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video ketika gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda dalam video?**

Ekspor video merender animasi alih-alih menyimpan perilaku PowerPoint asli. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi sebenarnya sebelum penggunaan produksi.

**Apakah memindahkan shape ke depan atau ke belakang mengubah urutan animasinya?**

Tidak. Z‑order shape mengontrol tumpang tindih, sedangkan urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah timeline jika Anda memerlukan urutan pemutaran yang berbeda.