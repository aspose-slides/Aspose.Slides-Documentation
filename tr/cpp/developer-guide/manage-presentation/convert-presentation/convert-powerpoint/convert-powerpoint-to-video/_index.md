---
title: C++ ile PowerPoint Sunumlarını Videoya Dönüştürme
linktitle: PowerPoint'ten Videoya
type: docs
weight: 130
url: /tr/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint dönüştürme
- sunum dönüştürme
- PPT dönüştürme
- PPTX dönüştürme
- PowerPoint'ten video
- sunumdan video
- PPT'den video
- PPTX'den video
- PowerPoint'ten MP4
- sunumdan MP4
- PPT'den MP4
- PPTX'den MP4
- PPT'yi MP4 olarak kaydet
- PPTX'i MP4 olarak kaydet
- PPT'yi MP4'e aktar
- PPTX'i MP4'e aktar
- video dönüştürme
- PowerPoint
- C++
- Aspose.Slides
description: "C++'ta PowerPoint sunumlarını videoya dönüştürmeyi öğrenin. İş akışınızı kolaylaştırmak için örnek kod ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint sunumunuzu videoya dönüştürerek şunları elde edersiniz

* **Erişilebilirlik artışı:** Tüm cihazlar (platformdan bağımsız) varsayılan olarak video oynatıcılarıyla donatılmıştır; bu, sunum açma uygulamalarına kıyasla kullanıcıların videoları açmasını veya oynatmasını daha kolay hâle getirir.
* **Daha geniş erişim:** Videolar sayesinde geniş bir kitleye ulaşabilir ve onları bir sunumda sıkıcı olabilecek bilgilerle hedefleyebilirsiniz. Çoğu anket ve istatistik, insanların videoları diğer içerik biçimlerine göre daha çok izlediğini ve tükettiklerini, genellikle bu tür içeriği tercih ettiklerini göstermektedir.

[Aspose.Slides 22.11](https://docs.aspose.com/slides/tr/cpp/aspose-slides-for-cpp-22-11-release-notes/) sürümünde sunumu videoya dönüştürme desteği ekledik. 

* Aspose.Slides'ı belirli bir FPS (saniyedeki kare sayısı) ile eşleşen bir dizi çerçeve (sunum slaytlarından) oluşturmak için kullanın
* `ffmpeg` gibi bir üçüncü taraf yardımcı programı kullanarak çerçevelerden bir video oluşturun.

## **PowerPoint Sunumunu Videoya Dönüştürme**

1. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.
2. `ffmpeg.exe` dosyasının yolunu `PATH` ortam değişkenine ekleyin.
3. PowerPoint'ten video kodunu çalıştırın.

Bu C++ kodu, bir sunumu (içinde bir şekil ve iki animasyon efekti bulunan) videoya nasıl dönüştüreceğinizi gösterir:

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

    // Bir gülümseme şekli ekler ve ardından animasyon uygular
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

## **Video Efektleri**

Slaytlardaki nesnelere animasyonlar uygulayabilir ve slaytlar arasında geçişler kullanabilirsiniz.

{{% alert color="primary" %}} 

Bu makaleleri incelemek isteyebilirsiniz: [PowerPoint Animation](https://docs.aspose.com/slides/tr/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/tr/cpp/shape-animation/), ve [Shape Effect](https://docs.aspose.com/slides/tr/cpp/shape-effect/).

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici ve etkileyici kılar—ve videolar için de aynı şeyi yapar. Önceki sunumun koduna bir slayt ve geçiş daha ekleyelim:

```c++
// Bir gülümseme şekli ekler ve animasyon uygular

// ...

// Yeni bir slayt ekler ve animasyonlu geçiş ekler

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides ayrıca metin animasyonunu da destekler. Bu yüzden nesneler üzerindeki paragrafları animasyonluyoruz; bunlar birbiri ardına (gecikme bir saniye olarak ayarlanmış) görünecek:

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

    // Metin ve animasyonlar ekler
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

    // Çerçeveleri videoya dönüştürür
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

## **Video Dönüştürme Sınıfları**

PowerPoint'ten video dönüştürme görevlerini gerçekleştirmenizi sağlamak için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_animations_generator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_player/) sınıflarını sunar.

PresentationAnimationsGenerator, video için (daha sonra oluşturulacak) çerçeve boyutunu yapıcı aracılığıyla ayarlamanızı sağlar. Sunumun bir örneğini geçirirseniz, `Presentation.SlideSize` kullanılacak ve [PresentationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_player/) tarafından kullanılan animasyonları oluşturur.

Animasyonlar oluşturulduğunda, her bir sonraki animasyon için bir `NewAnimation` olayı üretilir; bu olayın [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player/) parametresi vardır. Bu sınıf, ayrı bir animasyon için oynatıcıyı temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player/) ile çalışmak için, [get_Duration](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (animasyonun toplam süresi) özelliği ve [SetTimePosition](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) yöntemi kullanılır. Her animasyon konumu *0 ile süre* aralığında ayarlanır ve ardından `GetFrame` yöntemi, o anki animasyon durumuna karşılık gelen bir Bitmap döndürür.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // başlangıç animasyon durumu
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // başlangıç animasyon durumu bitmap

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // animasyonun son durumu
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // animasyonun son karesi
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Bir gülümseme şekli ekler ve animasyon uygular
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

Bir sunumdaki tüm animasyonların aynı anda oynatılmasını sağlamak için [PresentationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_player/) sınıfı kullanılır. Bu sınıf, yapıcısında bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_animations_generator/) örneği ve efektler için FPS alır ve ardından tüm animasyonları oynatmak için `FrameTick` olayını tetikler:

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

Ardından üretilen çerçeveler birleştirilerek video oluşturulabilir. [Convert PowerPoint to Video](https://docs.aspose.com/slides/tr/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümüne bakın.

## **Desteklenen Animasyonlar ve Efektler**


**Giriş**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
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


**Vurgu**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
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

**Çıkış**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
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

**Hareket Yolları**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **SSS**

**Şifre korumalı sunumları dönüştürmek mümkün müdür?**

Evet, Aspose.Slides [şifre korumalı sunumlarla](/slides/tr/cpp/password-protected-presentation/) çalışmanıza izin verir. Bu tür dosyaları işlerken, kütüphanenin sunum içeriğine erişebilmesi için doğru şifreyi sağlamanız gerekir.

**Aspose.Slides bulut çözümlerinde kullanılmayı destekliyor mu?**

Evet, Aspose.Slides bulut uygulamalarına ve servislerine entegre edilebilir. Kütüphane, sunucu ortamlarında çalışacak şekilde tasarlanmıştır; dosyaların toplu işlenmesi için yüksek performans ve ölçeklenebilirlik sağlar.

**Dönüştürme sırasında sunumlar için herhangi bir boyut sınırlaması var mı?**

Aspose.Slides, neredeyse her boyuttaki sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmeniz önerilebilir.