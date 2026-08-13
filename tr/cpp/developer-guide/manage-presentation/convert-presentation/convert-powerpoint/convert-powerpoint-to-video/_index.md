---
title: PowerPoint Sunumlarını C++'ta Videoya Dönüştürme
linktitle: PowerPoint'ten Videoya
type: docs
weight: 130
url: /tr/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten videoya
- sunumdan videoya
- PPT'den videoya
- PPTX'den videoya
- PowerPoint'ten MP4'e
- sunumdan MP4'e
- PPT'den MP4'e
- PPTX'den MP4'e
- PPT'yi MP4 olarak kaydet
- PPTX'i MP4 olarak kaydet
- PPT'yi MP4'e dışa aktar
- PPTX'i MP4'e dışa aktar
- video dönüştürme
- PowerPoint
- C++
- Aspose.Slides
description: "C++'ta PowerPoint sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. Çalışma akışınızı hızlandırmak için örnek kod ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint sunumunuzu videoya dönüştürerek şunları elde edersiniz

* **Erişilebilirlik artışı:** Tüm cihazlar (platformdan bağımsız) varsayılan olarak video oynatıcılarıyla donatılmıştır, bu yüzden kullanıcılar videoları açmayı veya oynatmayı daha kolay bulur.
* **Daha fazla erişim:** Videolar sayesinde geniş bir izleyici kitlesine ulaşabilir ve sunumda sıkıcı olabilecek bilgileri onlara hedefleyebilirsiniz. Çoğu anket ve istatistik, insanların videoları diğer içerik türlerine göre daha fazla izlediğini ve tükettiğini, ve genellikle bu tür içerikleri tercih ettiklerini göstermektedir.

[Aspose.Slides 22.11](https://docs.aspose.com/slides/tr/cpp/aspose-slides-for-cpp-22-11-release-notes/) sürümünde, sunumu videoya dönüştürme desteği ekledik.

* Aspose.Slides kullanarak sunum slaytlarından belirli bir FPS (saniyedeki kare sayısı) ile eşleşen bir dizi kare üretin
* `ffmpeg` gibi üçüncü taraf bir yardımcı programı kullanarak karelerden bir video oluşturun

## **PowerPoint Sunumunu Videoya Dönüştürme**

1. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.
2. `ffmpeg.exe` yolunu ortam değişkeni `PATH` içine ekleyin.
3. PowerPoint‑ten videoya kodunu çalıştırın.

Bu C++ kodu, bir şekil ve iki animasyon efekti içeren bir sunumu videoya nasıl dönüştüreceğinizi gösterir:

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
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Video Efektleri**

Slaytlardaki nesnelere animasyonlar uygulayabilir ve slaytlar arasında geçişler kullanabilirsiniz.

{{% alert color="info" %}} 

Aşağıdaki makalelere göz atmak isteyebilirsiniz: [PowerPoint Animation](https://docs.aspose.com/slides/tr/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/tr/cpp/shape-animation/), ve [Shape Effect](https://docs.aspose.com/slides/tr/cpp/shape-effect/).

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici ve eğlenceli hâle getirir—videolar için de aynı şey geçerlidir. Önceki sunum koduna bir slayt ve geçiş daha ekleyelim:

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

// Yukarıda gösterildiği gibi bir gülümseme şekli ekler ve animasyon uygular
auto presentation = System::MakeObject<Presentation>();

// Yeni bir slayt ve animasyonlu geçiş ekler

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides ayrıca metinler için animasyon desteği sunar. Bu nedenle nesneler üzerindeki paragrafları birbiri ardına (bir saniyelik gecikme ile) görünecek şekilde animasyonlu hâle getiriyoruz:

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

    // Kareleri videoya dönüştürür
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

## **Video Dönüştürme Sınıfları**

PowerPoint‑ten video dönüşüm görevlerini gerçekleştirmenize olanak tanımak için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_animations_generator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_player/) sınıflarını sağlar.

PresentationAnimationsGenerator, video (daha sonra oluşturulacak) için çerçeve boyutunu kurucu aracılığıyla ayarlamanıza izin verir. Sunum örneği verirseniz, `Presentation.SlideSize` kullanılacak ve [PresentationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_player/) tarafından kullanılan animasyonlar üretilir.

Animasyonlar üretildiğinde, her sonraki animasyon için bir `NewAnimation` olayı tetiklenir; bu olayda [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player/) parametresi bulunur. Bu sınıf, ayrı bir animasyon için oynatıcıyı temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player/) ile çalışmak için [get_Duration](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (animasyonun tam süresi) özelliği ve [SetTimePosition](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) yöntemi kullanılır. Her animasyon konumu *0‑den sürese* arasına ayarlanır ve ardından `GetFrame` yöntemi, o andaki animasyon durumuna karşılık gelen bir Bitmap döndürür.

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
    // ilk animasyon durumu
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // ilk animasyon durumu bitmap'i

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // animasyonun son durumu
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // animasyonun son karesi
    lastImage->Save(u"last.png");
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

Bir sunumdaki tüm animasyonların aynı anda oynatılması için [PresentationPlayer](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_player/) sınıfı kullanılır. Bu sınıf, kurucusunda bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.presentation_animations_generator/) örneği ve FPS alır, ardından tüm animasyonlar için `FrameTick` olayını tetikleyerek oynatılmalarını sağlar:

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

Daha sonra oluşturulan çerçeveler birleştirilerek video üretilir. Bkz. [Convert PowerPoint to Video](https://docs.aspose.com/slides/tr/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümü.

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

### Şifre korumalı sunumları dönüştürmek mümkün mü?

Evet, Aspose.Slides, [şifre korumalı sunumlarla](/slides/tr/cpp/password-protected-presentation/) çalışmayı destekler. Bu dosyaları işlerken doğru şifreyi sağlamanız gerekir; böylece kütüphane sunumun içeriğine erişebilir.

### Aspose.Slides bulut çözümlerinde kullanılabilir mi?

Evet, Aspose.Slides bulut uygulamaları ve hizmetlerine entegre edilebilir. Kütüphane, sunucu ortamlarında çalışacak şekilde tasarlanmıştır; dosya toplu işleme için yüksek performans ve ölçeklenebilirlik sağlar.

### Dönüştürme sırasında sunumların boyutlarıyla ilgili sınırlamalar var mı?

Aspose.Slides, neredeyse her boyutta sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmeniz önerilir.