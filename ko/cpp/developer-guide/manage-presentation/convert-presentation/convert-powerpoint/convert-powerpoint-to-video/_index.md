---
title: C++에서 PowerPoint 프레젠테이션을 비디오로 변환하기
linktitle: PowerPoint를 비디오로
type: docs
weight: 130
url: /ko/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 비디오로
- 프레젠테이션을 비디오로
- PPT를 비디오로
- PPTX를 비디오로
- PowerPoint를 MP4로
- 프레젠테이션을 MP4로
- PPT를 MP4로
- PPTX를 MP4로
- PPT를 MP4로 저장
- PPTX를 MP4로 저장
- PPT를 MP4로 내보내기
- PPTX를 MP4로 내보내기
- 비디오 변환
- PowerPoint
- C++
- Aspose.Slides
description: "C++에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배웁니다. 워크플로를 간소화하기 위한 샘플 코드와 자동화 기술을 확인하세요."
---
## **소개**

PowerPoint 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻습니다.

* **접근성 향상:** 모든 장치(플랫폼에 관계없이)는 기본적으로 비디오 플레이어가 탑재되어 있어 프레젠테이션 열기 애플리케이션보다 사용자가 비디오를 열거나 재생하기가 더 쉽습니다.
* **도달 범위 확대:** 비디오를 통해 대규모 청중에게 도달하고 프레젠테이션에서는 지루하게 느껴질 수 있는 정보를 전달할 수 있습니다. 대부분의 설문 조사와 통계에 따르면 사람들은 다른 형태의 콘텐츠보다 비디오를 더 많이 시청하고 소비하며, 일반적으로 이러한 콘텐츠를 선호합니다.

[Aspose.Slides 22.11](https://docs.aspose.com/slides/ko/cpp/aspose-slides-for-cpp-22-11-release-notes/)에서 프레젠테이션을 비디오로 변환하는 기능을 구현했습니다.

* Aspose.Slides를 사용하여 특정 FPS(초당 프레임 수)에 해당하는 프레젠테이션 슬라이드의 프레임 집합을 생성합니다.
* `ffmpeg`와 같은 타사 유틸리티를 사용하여 프레임을 기반으로 비디오를 생성합니다.

## **PowerPoint 프레젠테이션을 비디오로 변환하기**

1. ffmpeg을 [여기](https://ffmpeg.org/download.html)에서 다운로드합니다.
2. `ffmpeg.exe` 경로를 환경 변수 `PATH`에 추가합니다.
3. PowerPoint를 비디오로 변환하는 코드를 실행합니다.

다음 C++ 코드는 그림과 두 개의 애니메이션 효과가 포함된 프레젠테이션을 비디오로 변환하는 방법을 보여줍니다:

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

    // 스마일 도형을 추가하고 애니메이션을 적용합니다
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

## **비디오 효과**

슬라이드의 객체에 애니메이션을 적용하고 슬라이드 간 전환을 사용할 수 있습니다.

{{% alert color="info" %}} 

다음 문서를 확인해 보세요: [PowerPoint 애니메이션](https://docs.aspose.com/slides/ko/cpp/powerpoint-animation/), [도형 애니메이션](https://docs.aspose.com/slides/ko/cpp/shape-animation/), 및 [도형 효과](https://docs.aspose.com/slides/ko/cpp/shape-effect/).

{{% /alert %}} 

애니메이션과 전환은 슬라이드쇼를 더욱 흥미롭고 매력적으로 만들며, 비디오에서도 동일한 효과를 줍니다. 이전 프레젠테이션 코드에 슬라이드와 전환을 하나 더 추가해 보겠습니다:

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

// 위에 표시된 대로 스마일 도형을 추가하고 애니메이션을 적용합니다
auto presentation = System::MakeObject<Presentation>();

// 새 슬라이드를 추가하고 애니메이션 전환을 적용합니다

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides는 텍스트 애니메이션도 지원합니다. 따라서 객체에 있는 단락을 순차적으로(지연 시간을 1초로 설정하여) 애니메이션합니다:

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

    // 텍스트와 애니메이션을 추가합니다
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

    // 프레임을 비디오로 변환합니다
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

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행할 수 있도록 Aspose.Slides는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_animations_generator/)와 [PresentationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_player/) 클래스를 제공합니다.

PresentationAnimationsGenerator는 생성자를 통해 나중에 생성될 비디오의 프레임 크기를 설정할 수 있게 합니다. 프레젠테이션 인스턴스를 전달하면 `Presentation.SlideSize`가 사용되며, 이는 [PresentationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_player/)가 사용하는 애니메이션을 생성합니다.

애니메이션이 생성될 때마다 각 후속 애니메이션에 대해 `NewAnimation` 이벤트가 발생하며, 여기에는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player/) 매개변수가 포함됩니다. 후자는 별도 애니메이션의 플레이어를 나타내는 클래스입니다.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player/)와 작업하려면 [get_Duration](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (애니메이션의 전체 지속 시간) 속성과 [SetTimePosition](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) 메서드를 사용합니다. 각 애니메이션 위치는 *0부터 지속 시간* 범위 내에서 설정되며, 이후 `GetFrame` 메서드는 해당 순간의 애니메이션 상태에 해당하는 비트맵을 반환합니다.

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
    // 초기 애니메이션 상태
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // 초기 애니메이션 상태 비트맵

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // 애니메이션의 최종 상태
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // 애니메이션의 마지막 프레임
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 스마일 도형을 추가하고 애니메이션을 적용합니다
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

프레젠테이션의 모든 애니메이션을 한 번에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_player/) 클래스를 사용합니다. 이 클래스는 생성자에서 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_animations_generator/) 인스턴스와 효과에 대한 FPS를 받아들인 뒤, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:

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

그런 다음 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. 자세한 내용은 [PowerPoint를 비디오로 변환](https://docs.aspose.com/slides/ko/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참조하십시오.

## **지원되는 애니메이션 및 효과**

**입장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Fade** | ![지원](v.png) | ![지원](v.png) |
| **Fly In** | ![지원](v.png) | ![지원](v.png) |
| **Float In** | ![지원](v.png) | ![지원](v.png) |
| **Split** | ![지원](v.png) | ![지원](v.png) |
| **Wipe** | ![지원](v.png) | ![지원](v.png) |
| **Shape** | ![지원](v.png) | ![지원](v.png) |
| **Wheel** | ![지원](v.png) | ![지원](v.png) |
| **Random Bars** | ![지원](v.png) | ![지원](v.png) |
| **Grow & Turn** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Zoom** | ![지원](v.png) | ![지원](v.png) |
| **Swivel** | ![지원](v.png) | ![지원](v.png) |
| **Bounce** | ![지원](v.png) | ![지원](v.png) |

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Color Pulse** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Teeter** | ![지원](v.png) | ![지원](v.png) |
| **Spin** | ![지원](v.png) | ![지원](v.png) |
| **Grow/Shrink** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Desaturate** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Darken** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Lighten** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Transparency** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Object Color** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Complementary Color** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Line Color** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Fill Color** | ![지원되지 않음](x.png) | ![지원](v.png) |

**퇴장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Fade** | ![지원](v.png) | ![지원](v.png) |
| **Fly Out** | ![지원](v.png) | ![지원](v.png) |
| **Float Out** | ![지원](v.png) | ![지원](v.png) |
| **Split** | ![지원](v.png) | ![지원](v.png) |
| **Wipe** | ![지원](v.png) | ![지원](v.png) |
| **Shape** | ![지원](v.png) | ![지원](v.png) |
| **Random Bars** | ![지원](v.png) | ![지원](v.png) |
| **Shrink & Turn** | ![지원되지 않음](x.png) | ![지원](v.png) |
| **Zoom** | ![지원](v.png) | ![지원](v.png) |
| **Swivel** | ![지원](v.png) | ![지원](v.png) |
| **Bounce** | ![지원](v.png) | ![지원](v.png) |

**모션 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![지원](v.png) | ![지원](v.png) |
| **Arcs** | ![지원](v.png) | ![지원](v.png) |
| **Turns** | ![지원](v.png) | ![지원](v.png) |
| **Shapes** | ![지원](v.png) | ![지원](v.png) |
| **Loops** | ![지원](v.png) | ![지원](v.png) |
| **Custom Path** | ![지원](v.png) | ![지원](v.png) |

## **FAQ**

### 암호로 보호된 프레젠테이션을 변환할 수 있나요?

예, Aspose.Slides는 [암호로 보호된 프레젠테이션](/slides/ko/cpp/password-protected-presentation/) 작업을 지원합니다. 이러한 파일을 처리할 때는 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 내용에 접근할 수 있도록 해야 합니다.

### Aspose.Slides가 클라우드 솔루션에서 사용을 지원하나요?

예, Aspose.Slides는 클라우드 애플리케이션 및 서비스에 통합될 수 있습니다. 이 라이브러리는 서버 환경에서 작동하도록 설계되어 파일 일괄 처리 시 높은 성능과 확장성을 제공합니다.

### 변환 중 프레젠테이션에 대한 크기 제한이 있나요?

Aspose.Slides는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 그러나 매우 큰 파일을 다룰 경우 추가 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장되기도 합니다.