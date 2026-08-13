---
title: Mengonversi Presentasi PowerPoint ke Video dalam C++
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/cpp/convert-powerpoint-to-video/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi PPT
- konversi PPTX
- PowerPoint ke video
- presentasi ke video
- PPT ke video
- PPTX ke video
- PowerPoint ke MP4
- presentasi ke MP4
- PPT ke MP4
- PPTX ke MP4
- simpan PPT sebagai MP4
- simpan PPTX sebagai MP4
- ekspor PPT ke MP4
- ekspor PPTX ke MP4
- konversi video
- PowerPoint
- C++
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint ke video dalam C++. Temukan contoh kode dan teknik otomatisasi untuk menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Dengan mengonversi presentasi PowerPoint Anda ke video, Anda mendapatkan 

* **Peningkatan aksesibilitas:** Semua perangkat (tanpa memandang platform) secara default dilengkapi pemutar video dibandingkan aplikasi pembuka presentasi, sehingga pengguna lebih mudah membuka atau memutar video.
* **Jangkauan lebih luas:** Dengan video, Anda dapat menjangkau audiens yang besar dan menargetkan mereka dengan informasi yang mungkin terasa membosankan dalam presentasi. Sebagian besar survei dan statistik menunjukkan bahwa orang menonton dan mengonsumsi video lebih banyak daripada bentuk konten lain, dan mereka umumnya lebih menyukai konten tersebut.

Dalam [Aspose.Slides 22.11](https://docs.aspose.com/slides/id/cpp/aspose-slides-for-cpp-22-11-release-notes/), kami menambahkan dukungan untuk konversi presentasi ke video. 

* Gunakan Aspose.Slides untuk menghasilkan sekumpulan frame (dari slide presentasi) yang sesuai dengan FPS tertentu (frame per detik)
* Gunakan utilitas pihak ketiga seperti `ffmpeg` untuk membuat video berdasarkan frame-frame tersebut.

## **Konversi Presentasi PowerPoint ke Video**

1. Unduh ffmpeg [di sini](https://ffmpeg.org/download.html).
2. Tambahkan path ke `ffmpeg.exe` ke variabel lingkungan `PATH`.
3. Jalankan kode konversi PowerPoint ke video.

Kode C++ ini memperlihatkan cara mengonversi presentasi (yang berisi gambar dan dua efek animasi) menjadi video:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
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
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Menambahkan bentuk senyum dan kemudian memberi animasi padanya
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Efek Video**

Anda dapat menerapkan animasi pada objek di slide dan menggunakan transisi antar slide.

{{% alert color="info" %}} 

Anda mungkin ingin melihat artikel-artikel ini: [Animasi PowerPoint](https://docs.aspose.com/slides/id/cpp/powerpoint-animation/), [Animasi Bentuk](https://docs.aspose.com/slides/id/cpp/shape-animation/), dan [Efek Bentuk](https://docs.aspose.com/slides/id/cpp/shape-effect/).

{{% /alert %}} 

Animasi dan transisi membuat slideshow lebih menarik dan menarik—dan hal yang sama berlaku untuk video. Mari tambahkan slide dan transisi lain ke kode untuk presentasi sebelumnya:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// Menambahkan bentuk senyum dan memberi animasi seperti yang ditunjukkan di atas
auto presentation = System::MakeObject<Presentation>();

// Menambahkan slide baru dan transisi animasi

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides juga mendukung animasi untuk teks. Jadi kami menganimasi paragraf pada objek, yang akan muncul satu per satu (dengan jeda satu detik):

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Menambahkan teks dan animasi
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Mengonversi frame menjadi video
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Kelas Konversi Video**

Untuk memungkinkan Anda melakukan tugas konversi PowerPoint ke video, Aspose.Slides menyediakan kelas [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_animations_generator/) dan [PresentationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_player/) .

PresentationAnimationsGenerator memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat kemudian) melalui konstruktornya. Jika Anda memberikan instance presentasi, `Presentation.SlideSize` akan digunakan dan ia menghasilkan animasi yang digunakan oleh [PresentationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_player/) .

Ketika animasi dihasilkan, sebuah event `NewAnimation` dibuat untuk setiap animasi berikutnya, yang memiliki parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player/). Kelas tersebut mewakili pemutar untuk animasi terpisah.

Untuk bekerja dengan [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player/), properti [get_Duration](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (durasi penuh animasi) dan metode [SetTimePosition](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) digunakan. Setiap posisi animasi diatur dalam rentang *0 hingga durasi*, dan kemudian metode `GetFrame` akan mengembalikan Bitmap yang sesuai dengan keadaan animasi pada saat itu.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
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
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // keadaan animasi awal
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // bitmap keadaan animasi awal

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // keadaan akhir animasi
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // frame terakhir animasi
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Menambahkan bentuk senyum dan memberi animasi padanya
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

Untuk membuat semua animasi dalam satu presentasi diputar sekaligus, kelas [PresentationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_player/) digunakan. Kelas ini menerima instance [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_animations_generator/) dan FPS untuk efek dalam konstruktornya, lalu memanggil event `FrameTick` untuk semua animasi agar diputar:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

Kemudian frame yang dihasilkan dapat dikompilasi menjadi video. Lihat bagian [Konversi PowerPoint ke Video](https://docs.aspose.com/slides/id/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

**Masuk**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Muncul** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Memudar** | ![didukung](v.png) | ![didukung](v.png) |
| **Terbang Masuk** | ![didukung](v.png) | ![didukung](v.png) |
| **Mengapung Masuk** | ![didukung](v.png) | ![didukung](v.png) |
| **Terpisah** | ![didukung](v.png) | ![didukung](v.png) |
| **Usap** | ![didukung](v.png) | ![didukung](v.png) |
| **Bentuk** | ![didukung](v.png) | ![didukung](v.png) |
| **Roda** | ![didukung](v.png) | ![didukung](v.png) |
| **Bar Acak** | ![didukung](v.png) | ![didukung](v.png) |
| **Tumbuh & Berputar** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Zum** | ![didukung](v.png) | ![didukung](v.png) |
| **Putar** | ![didukung](v.png) | ![didukung](v.png) |
| **Melompat** | ![didukung](v.png) | ![didukung](v.png) |

**Penekanan**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Denyar** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Denyar Warna** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Goyang** | ![didukung](v.png) | ![didukung](v.png) |
| **Berputar** | ![didukung](v.png) | ![didukung](v.png) |
| **Tumbuh/Menciut** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Desaturasi** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Gelap** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Terang** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Transparansi** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Warna Objek** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Warna Komplemen** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Warna Garis** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Warna Isi** | ![tidak didukung](x.png) | ![didukung](v.png) |

**Keluar**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Menghilang** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Memudar** | ![didukung](v.png) | ![didukung](v.png) |
| **Terbang Keluar** | ![didukung](v.png) | ![didukung](v.png) |
| **Mengapung Keluar** | ![didukung](v.png) | ![didukung](v.png) |
| **Terpisah** | ![didukung](v.png) | ![didukung](v.png) |
| **Usap** | ![didukung](v.png) | ![didukung](v.png) |
| **Bentuk** | ![didukung](v.png) | ![didukung](v.png) |
| **Bar Acak** | ![didukung](v.png) | ![didukung](v.png) |
| **Menciut & Berputar** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Zum** | ![didukung](v.png) | ![didukung](v.png) |
| **Putar** | ![didukung](v.png) | ![didukung](v.png) |
| **Melompat** | ![didukung](v.png) | ![didukung](v.png) |

**Jalur Gerak**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Garis** | ![didukung](v.png) | ![didukung](v.png) |
| **Busur** | ![didukung](v.png) | ![didukung](v.png) |
| **Putaran** | ![didukung](v.png) | ![didukung](v.png) |
| **Bentuk** | ![didukung](v.png) | ![didukung](v.png) |
| **Loop** | ![didukung](v.png) | ![didukung](v.png) |
| **Jalur Kustom** | ![didukung](v.png) | ![didukung](v.png) |

## **FAQ**

### Apakah memungkinkan mengonversi presentasi yang dilindungi kata sandi?

Ya, Aspose.Slides memungkinkan bekerja dengan [presentasi yang dilindungi kata sandi](/slides/id/cpp/password-protected-presentation/). Saat memproses file tersebut, Anda harus menyediakan kata sandi yang benar agar perpustakaan dapat mengakses konten presentasi.

### Apakah Aspose.Slides mendukung penggunaan dalam solusi cloud?

Ya, Aspose.Slides dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja pada lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch file.

### Apakah ada batasan ukuran untuk presentasi selama konversi?

Aspose.Slides mampu menangani presentasi dengan ukuran apa pun secara praktis. Namun, saat bekerja dengan file yang sangat besar, mungkin diperlukan sumber daya sistem tambahan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.