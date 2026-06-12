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
description: "Pelajari cara mengonversi presentasi PowerPoint ke video dalam C++. Temukan contoh kode dan teknik otomatisasi untuk mempermudah alur kerja Anda."
---
## **Pendahuluan**

Dengan mengonversi presentasi PowerPoint Anda ke video, Anda mendapatkan 

* **Peningkatan aksesibilitas:** Semua perangkat (tanpa memandang platform) dilengkapi pemutar video secara default dibandingkan aplikasi pembuka presentasi, sehingga pengguna lebih mudah membuka atau memutar video.
* **Jangkauan lebih luas:** Melalui video, Anda dapat menjangkau audiens yang besar dan menargetkan mereka dengan informasi yang mungkin terasa membosankan dalam presentasi. Sebagian besar survei dan statistik menunjukkan bahwa orang menonton dan mengonsumsi video lebih banyak dibandingkan bentuk konten lain, dan mereka umumnya lebih menyukai konten tersebut.

Pada [Aspose.Slides 22.11](https://docs.aspose.com/slides/id/cpp/aspose-slides-for-cpp-22-11-release-notes/), kami menambahkan dukungan untuk konversi presentasi ke video. 

* Gunakan Aspose.Slides untuk menghasilkan sekumpulan frame (dari slide presentasi) yang sesuai dengan FPS tertentu (frame per detik)
* Gunakan utilitas pihak ketiga seperti `ffmpeg` untuk membuat video berdasarkan frame-frame tersebut.

## **Mengonversi Presentasi PowerPoint ke Video**

1. Unduh ffmpeg [di sini](https://ffmpeg.org/download.html).
2. Tambahkan path ke `ffmpeg.exe` ke variabel lingkungan `PATH`.
3. Jalankan kode konversi PowerPoint ke video.

Kode C++ ini menunjukkan cara mengonversi sebuah presentasi (yang berisi gambar dan dua efek animasi) ke video:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Menambahkan bentuk smile dan kemudian memberi animasi padanya
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Efek Video**

Anda dapat menerapkan animasi pada objek di slide dan menggunakan transisi antar slide.

{{% alert color="primary" %}} 
Anda mungkin ingin melihat artikel berikut: [PowerPoint Animation](https://docs.aspose.com/slides/id/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/id/cpp/shape-animation/), dan [Shape Effect](https://docs.aspose.com/slides/id/cpp/shape-effect/).
{{% /alert %}} 

Animasi dan transisi membuat tayangan slide lebih menarik dan menarik—dan hal yang sama berlaku untuk video. Mari tambahkan slide lain dan transisi ke kode untuk presentasi sebelumnya:

```c++
// Menambahkan bentuk smile dan memberi animasi padanya

// ...

// Menambahkan slide baru dan transisi animasi

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides juga mendukung animasi untuk teks. Jadi kami memberi animasi pada paragraf di objek, yang akan muncul satu demi satu (dengan jeda satu detik):

```c++
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Kelas Konversi Video**

Untuk memungkinkan Anda melakukan tugas konversi PowerPoint ke video, Aspose.Slides menyediakan kelas [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_animations_generator/) dan [PresentationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat nanti) melalui konstruktornya. Jika Anda memberikan instance presentasi, `Presentation.SlideSize` akan digunakan dan ia menghasilkan animasi yang digunakan oleh [PresentationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_player/).

Saat animasi dihasilkan, sebuah event `NewAnimation` dibuat untuk setiap animasi berikutnya, yang memiliki parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player/). Parameter tersebut adalah kelas yang mewakili pemutar untuk animasi terpisah.

Untuk bekerja dengan [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player/), properti [get_Duration](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (durasi penuh animasi) dan metode [SetTimePosition](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) digunakan. Setiap posisi animasi diatur dalam rentang *0 hingga duration*, dan kemudian metode `GetFrame` akan mengembalikan Bitmap yang sesuai dengan keadaan animasi pada saat itu.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // keadaan animasi awal
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap keadaan animasi awal

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // keadaan akhir animasi
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // frame terakhir animasi
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Menambahkan bentuk smile dan memberi animasi padanya
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

Untuk membuat semua animasi dalam sebuah presentasi diputar bersamaan, kelas [PresentationPlayer](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_player/) digunakan. Kelas ini mengambil instance [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.presentation_animations_generator/) dan FPS untuk efek dalam konstruktornya, lalu memanggil event `FrameTick` untuk semua animasi agar diputar:

```c++
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

Kemudian frame yang dihasilkan dapat dikompilasi menjadi video. Lihat bagian [Convert PowerPoint to Video](https://docs.aspose.com/slides/id/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

**Masuk**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Penekanan**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Keluar**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Jalur Gerakan**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Apakah memungkinkan mengonversi presentasi yang dilindungi kata sandi?**

Ya, Aspose.Slides memungkinkan bekerja dengan [presentasi yang dilindungi kata sandi](/slides/id/cpp/password-protected-presentation/). Saat memproses file tersebut, Anda harus menyediakan kata sandi yang benar agar perpustakaan dapat mengakses konten presentasi.

**Apakah Aspose.Slides mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch berkas.

**Apakah ada batasan ukuran untuk presentasi selama konversi?**

Aspose.Slides mampu menangani presentasi dengan ukuran apa pun secara praktis. Namun, ketika bekerja dengan berkas yang sangat besar, sumber daya sistem tambahan mungkin diperlukan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.