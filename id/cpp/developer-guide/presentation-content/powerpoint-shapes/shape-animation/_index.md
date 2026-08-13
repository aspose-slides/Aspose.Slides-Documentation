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
- tambahkan animasi
- dapatkan animasi
- ekstrak animasi
- tambahkan efek
- dapatkan efek
- ekstrak efek
- suara efek
- terapkan animasi
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan animasi bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk C++. Tampil menonjol!"
---
## **Pendahuluan**

Animasi adalah efek visual yang dapat diterapkan pada teks, gambar, bentuk, atau [grafik](/slides/id/cpp/animated-charts/). Animasi memberikan kehidupan pada presentasi atau komponennya. 

## **Mengapa Menggunakan Animasi dalam Presentasi?**

Dengan menggunakan animasi, Anda dapat 

* mengontrol alur informasi
* menekankan poin penting
* meningkatkan minat atau partisipasi audiens Anda
* membuat konten lebih mudah dibaca, dipahami, atau diproses
* menarik perhatian pembaca atau penonton ke bagian penting dalam presentasi

PowerPoint menyediakan banyak opsi dan alat untuk animasi serta efek animasi dalam kategori **entrance**, **exit**, **emphasis**, dan **motion paths**. 

## **Animasi dalam Aspose.Slides**

* Aspose.Slides menyediakan kelas dan tipe yang Anda perlukan untuk bekerja dengan animasi di namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.animation),
* Aspose.Slides menyediakan lebih dari **150 efek animasi** dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Efek-efek ini pada dasarnya sama (atau setara) dengan efek yang digunakan di PowerPoint.

## **Menerapkan Animasi ke TextBox**

Aspose.Slides untuk C++ memungkinkan Anda menerapkan animasi pada teks dalam sebuah bentuk. 

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape). 
4. Tambahkan teks ke [IAutoShape.TextFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape). 
7. Set properti [TextAnimation.BuildType](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) ke nilai dari [BuildType Enumeration](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Tulis presentasi ke disk sebagai file PPTX.

```c++
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
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Membuat instance kelas presentasi yang mewakili file presentasi.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Menambahkan AutoShape baru dengan teks
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Mendapatkan urutan utama slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Menambahkan efek animasi Fade ke shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Menganimasi teks shape berdasarkan paragraf tingkat pertama
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Menyimpan file PPTX ke disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Selain menerapkan animasi ke teks, Anda juga dapat menerapkan animasi ke satu [Paragraph](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_paragraph). Lihat [**Animated Text**](/slides/id/cpp/animated-text/).

{{% /alert %}} 

## **Menerapkan Animasi ke PictureFrame**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan atau dapatkan sebuah [PictureFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_picture_frame) pada slide. 
4. Dapatkan urutan utama efek.
5. Tambahkan efek animasi ke [PictureFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_picture_frame).
6. Tulis presentasi ke disk sebagai file PPTX.

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Membuat instance kelas presentasi yang mewakili file presentasi.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Muat gambar yang akan ditambahkan ke koleksi gambar presentasi
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Menambahkan picture frame ke slide
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Mendapatkan urutan utama slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Menambahkan efek animasi Fly dari Kiri ke picture frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Menyimpan file PPTX ke disk
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Menerapkan Animasi ke Shape**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape). 
4. Tambahkan sebuah `Bevel` [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape) (ketika objek ini diklik, animasi akan diputar).
5. Buat urutan efek pada bentuk bevel.
6. Buat `UserPath` khusus.
7. Tambahkan perintah untuk bergerak ke `UserPath`.
8. Tulis presentasi ke disk sebagai file PPTX.

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Jalur ke direktori dokumen.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Memuat presentasi
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Mengakses slide pertama
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Mengakses koleksi shape untuk slide yang dipilih
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Membuat efek PathFootball untuk shape yang ada dari awal.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Menambahkan efek animasi PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Membuat semacam "tombol".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Membuat urutan efek untuk tombol ini.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Membuat jalur pengguna khusus. Objek kami akan dipindahkan hanya setelah tombol diklik.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Menambahkan perintah untuk bergerak karena jalur yang dibuat kosong.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // Menulis file PPTX ke Disk
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Mendapatkan Efek Animasi yang Diterapkan pada Shape**

Contoh berikut menunjukkan cara menggunakan metode `GetEffectsByShape` dari antarmuka [ISequence](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/) untuk mendapatkan semua efek animasi yang diterapkan pada sebuah shape.

**Contoh 1: Mendapatkan efek animasi yang diterapkan pada shape di slide normal**

Sebelumnya, Anda telah mempelajari cara menambahkan efek animasi ke shape dalam presentasi PowerPoint. Kode contoh berikut menunjukkan cara mendapatkan efek yang diterapkan pada shape pertama di slide normal pertama dalam presentasi `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Mendapatkan urutan animasi utama slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Mendapatkan shape pertama pada slide pertama.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Mendapatkan efek animasi yang diterapkan pada shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Contoh 2: Mendapatkan semua efek animasi, termasuk yang diwarisi dari placeholder**

Jika sebuah shape pada slide normal memiliki placeholder yang berada pada layout slide dan/atau master slide, dan efek animasi telah ditambahkan ke placeholder tersebut, maka semua efek pada shape akan diputar selama pertunjukan slide, termasuk yang diwarisi dari placeholder.

Misalkan kita memiliki file presentasi PowerPoint `sample.pptx` dengan satu slide yang hanya berisi shape footer dengan teks "Made with Aspose.Slides" dan efek **Random Bars** diterapkan pada shape tersebut.

![Efek animasi shape slide](slide-shape-animation.png)

Misalkan juga efek **Split** diterapkan pada placeholder footer di slide **layout**.

![Efek animasi shape layout](layout-shape-animation.png)

Dan akhirnya, efek **Fly In** diterapkan pada placeholder footer di slide **master**.

![Efek animasi shape master](master-shape-animation.png)

Kode contoh berikut menunjukkan cara menggunakan metode `GetBasePlaceholder` dari antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) untuk mengakses placeholder shape dan mendapatkan efek animasi yang diterapkan pada shape footer, termasuk yang diwarisi dari placeholder pada layout dan master slide.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Dapatkan efek animasi dari shape pada slide normal.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Dapatkan efek animasi dari placeholder pada slide tata letak.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Dapatkan efek animasi dari placeholder pada slide master.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Terbang, Bawah
Type: 134, subtype: 45            // Pisah, VertikalMasuk
Type: 126, subtype: 22            // BilahAcak, Horizontal
```

## **Ubah Properti Waktu Efek Animasi**

Aspose.Slides untuk C++ memungkinkan Anda mengubah properti Timing dari sebuah efek animasi.

Ini adalah panel Animation Timing di Microsoft PowerPoint:

![example1_image](shape-animation.png)

Berikut adalah korespondensi antara PowerPoint Timing dan properti [Effect.Timing](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Daftar drop-down PowerPoint Timing **Start** cocok dengan properti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- PowerPoint Timing **Duration** cocok dengan properti [Effect.Timing.Duration](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Durasi sebuah animasi (dalam detik) adalah total waktu yang dibutuhkan animasi untuk menyelesaikan satu siklus. 
- PowerPoint Timing **Delay** cocok dengan properti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Berikut cara mengubah properti Timing efek:

1. [Apply](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Setel nilai baru untuk properti [Effect.Timing](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) yang Anda butuhkan. 
3. Simpan file PPTX yang telah dimodifikasi.

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Membuat instance kelas presentasi yang mewakili file presentasi.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Mendapatkan urutan utama slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Mendapatkan efek pertama dari urutan utama.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Mengubah TriggerType efek menjadi mulai saat diklik
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Mengubah Durasi efek
effect->get_Timing()->set_Duration(3.f);

// Mengubah TriggerDelayTime efek
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Menyimpan file PPTX ke disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Suara Efek Animasi**

Aspose.Slides menyediakan properti-properti berikut untuk memungkinkan Anda bekerja dengan suara dalam efek animasi: 

- [set_Sound()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Menambahkan Suara Efek Animasi**

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Menambahkan audio ke koleksi audio presentasi
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Mendapatkan urutan utama slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Mendapatkan efek pertama dari urutan utama
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Memeriksa efek untuk "No Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Menambahkan suara untuk efek pertama
    firstEffect->set_Sound(effectSound);
}

// Mendapatkan urutan interaktif pertama slide.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Mengatur flag efek "Stop previous sound"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Menulis file PPTX ke disk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Mengekstrak Suara Efek Animasi**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Dapatkan urutan utama efek. 
4. Mengekstrak [set_Sound()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/effect/set_sound/) yang tersemat pada masing-masing efek animasi. 

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Membuat instance kelas presentasi yang mewakili file presentasi.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Setelah Animasi**

Aspose.Slides untuk C++ memungkinkan Anda mengubah properti After animation dari sebuah efek animasi.

Ini adalah panel Effect dan menu ekstensi di Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Daftar drop-down PowerPoint Effect **After animation** cocok dengan properti berikut: 

- Properti [set_AfterAnimationType()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) yang mendeskripsikan tipe After animation :
  * Opsi PowerPoint **More Colors** cocok dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Opsi PowerPoint **Don't Dim** cocok dengan tipe [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/) (tipe after animation default);
  * Opsi PowerPoint **Hide After Animation** cocok dengan tipe [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Opsi PowerPoint **Hide on Next Mouse Click** cocok dengan tipe [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/) ;
- Properti [set_AfterAnimationColor()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) yang mendefinisikan format warna after animation. Properti ini bekerja bersamaan dengan tipe [AfterAnimationType.Color](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/afteranimationtype/). Jika Anda mengubah tipe ke yang lain, warna after animation akan dibersihkan.

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Membuat instance kelas presentasi yang mewakili file presentasi
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Mendapatkan efek pertama dari urutan utama
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Mengubah tipe after animation menjadi Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Mengatur warna after animation dim
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Menulis file PPTX ke disk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animasi Teks**

Aspose.Slides menyediakan properti-properti berikut untuk memungkinkan Anda bekerja dengan blok *Animate text* pada sebuah efek animasi:

- [set_AnimateTextType()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) yang mendeskripsikan tipe animate text dari efek. Teks shape dapat dianimasikan:
  - Semua sekaligus ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/animatetexttype/) tipe)
  - Per kata ([AnimateTextType.ByWord](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/animatetexttype/) tipe)
  - Per huruf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/animatetexttype/) tipe)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) menetapkan jeda antara bagian teks yang dianimasikan (kata atau huruf). Nilai positif menentukan persentase durasi efek. Nilai negatif menentukan jeda dalam detik.

Berikut cara mengubah properti Animate text pada Effect:

1. [Apply](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Set properti [set_BuildType()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation.itextanimation/set_buildtype/) ke nilai [BuildType.AsOneObject](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/buildtype/) untuk mematikan mode animasi *By Paragraphs*.
3. Setel nilai baru untuk properti [set_AnimateTextType()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) dan [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Simpan file PPTX yang telah dimodifikasi.

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Membuat instance kelas presentasi yang mewakili file presentasi.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Mendapatkan efek pertama dari urutan utama
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Mengubah tipe animasi teks efek menjadi "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Mengubah tipe Animate text efek menjadi "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Menetapkan jeda antar kata menjadi 20% dari durasi efek
firstEffect->set_DelayBetweenTextParts(20.0f);

// Menulis file PPTX ke disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Bagaimana saya dapat memastikan animasi tetap terjaga saat mempublikasikan presentasi ke web?

[Export to HTML5](/slides/id/cpp/export-to-html5/) dan aktifkan [options](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/html5options/) yang bertanggung jawab untuk animasi [shape](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/html5options/set_animateshapes/) dan [transition](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/html5options/set_animatetransitions/). HTML biasa tidak memutar animasi slide, sedangkan HTML5 melakukannya.

### Bagaimana perubahan urutan z (layer order) pada shape memengaruhi animasi?

Urutan animasi dan urutan gambar bersifat independen: sebuah efek mengontrol timing dan tipe muncul/hilang, sementara [z-order](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/get_zorderposition/) menentukan apa yang menutupi apa. Hasil yang terlihat ditentukan oleh kombinasi keduanya. (Ini adalah perilaku umum PowerPoint; model efek-dan-shape Aspose.Slides mengikuti logika yang sama.)

### Apakah ada keterbatasan saat mengkonversi animasi ke video untuk efek tertentu?

Secara umum, [animasi didukung](/slides/id/cpp/convert-powerpoint-to-video/), namun kasus langka atau efek spesifik mungkin dirender secara berbeda. Disarankan untuk menguji dengan efek yang Anda gunakan dan dengan versi perpustakaan yang bersangkutan.