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
description: "C++에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배우세요. 샘플 코드와 자동화 기술을 확인하여 작업 흐름을 효율화할 수 있습니다."
---
## **소개**

PowerPoint 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다.

* **접근성 향상:** 모든 장치(플랫폼에 관계없이)는 기본적으로 비디오 플레이어를 갖추고 있어 프레젠테이션 열기 애플리케이션보다 사용자가 비디오를 열거나 재생하기가 더 쉽습니다.
* **더 넓은 도달 범위:** 비디오를 통해 대규모 청중에게 도달하고 프레젠테이션에서 지루하게 느껴질 수 있는 정보를 전달할 수 있습니다. 대부분의 설문 조사와 통계에 따르면 사람들은 다른 형태의 콘텐츠보다 비디오를 더 많이 시청하고 소비하며 전반적으로 이런 콘텐츠를 선호합니다.

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/ko/cpp/aspose-slides-for-cpp-22-11-release-notes/), we implemented support for presentation to video conversion.

* Use Aspose.Slides to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)
* Use a third‑party utility like `ffmpeg` to create a video based on the frames.

## **PowerPoint 프레젠테이션을 비디오로 변환**

1. ffmpeg을 [여기](https://ffmpeg.org/download.html)에서 다운로드합니다.
2. `ffmpeg.exe` 경로를 환경 변수 `PATH`에 추가합니다.
3. PowerPoint를 비디오로 변환하는 코드를 실행합니다.

This C++ code shows you how to convert a presentation (containing a figure and two animation effects) to a video:

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

    // 스마일 도형을 추가하고 그에 애니메이션을 적용합니다
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

## **비디오 효과**

슬라이드의 개체에 애니메이션을 적용하고 슬라이드 간 전환을 사용할 수 있습니다.

{{% alert color="primary" %}} 

다음 문서를 참조하십시오: [PowerPoint 애니메이션](https://docs.aspose.com/slides/ko/cpp/powerpoint-animation/), [도형 애니메이션](https://docs.aspose.com/slides/ko/cpp/shape-animation/), 그리고 [도형 효과](https://docs.aspose.com/slides/ko/cpp/shape-effect/).

{{% /alert %}} 

애니메이션과 전환은 슬라이드쇼를 더 매력적이고 흥미롭게 만들며, 비디오에서도 동일한 효과를 제공합니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:

```c++
// 스마일 도형을 추가하고 애니메이션을 적용합니다

// ...

// 새 슬라이드를 추가하고 애니메이션 전환을 설정합니다

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides는 텍스트 애니메이션도 지원합니다. 따라서 개체에 있는 단락을 순차적으로 표시하도록 애니메이션을 적용합니다(지연 시간은 1초로 설정).

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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행할 수 있도록 Aspose.Slides는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_animations_generator/)와 [PresentationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_player/) 클래스를 제공합니다.

PresentationAnimationsGenerator는 생성자를 통해 나중에 생성될 비디오의 프레임 크기를 설정할 수 있게 합니다. 프레젠테이션 인스턴스를 전달하면 `Presentation.SlideSize`가 사용되며, 이 클래스는 [PresentationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_player/)가 사용할 애니메이션을 생성합니다.

애니메이션이 생성될 때마다 각 후속 애니메이션에 대해 `NewAnimation` 이벤트가 발생하고, 여기에는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player/) 파라미터가 전달됩니다. 후자는 개별 애니메이션의 플레이어를 나타내는 클래스입니다.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player/)를 사용하려면 [get_Duration](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (애니메이션 전체 지속 시간) 속성과 [SetTimePosition](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) 메서드를 사용합니다. 각 애니메이션 위치는 *0에서 duration* 범위 내에 설정되며, 그 후 `GetFrame` 메서드는 해당 시점의 애니메이션 상태에 해당하는 Bitmap을 반환합니다.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // 초기 애니메이션 상태
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // 초기 애니메이션 상태 비트맵

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // 애니메이션의 최종 상태
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // 애니메이션의 마지막 프레임
    lastBitmap->Save(u"last.png");
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

프레젠테이션의 모든 애니메이션을 한 번에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_player/) 클래스를 사용합니다. 이 클래스는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.presentation_animations_generator/) 인스턴스와 FPS 값을 생성자에 전달받은 뒤, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:

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

그 후 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. 자세한 내용은 [Convert PowerPoint to Video](https://docs.aspose.com/slides/ko/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참조하십시오.

## **지원되는 애니메이션 및 효과**

**입장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
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

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
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

**종료**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
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

**동작 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **자주 묻는 질문**

**비밀번호로 보호된 프레젠테이션을 변환할 수 있나요?**

예, Aspose.Slides는 [비밀번호로 보호된 프레젠테이션](/slides/ko/cpp/password-protected-presentation/)을 처리할 수 있습니다. 이러한 파일을 처리할 때는 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 내용을 액세스할 수 있도록 해야 합니다.

**Aspose.Slides를 클라우드 솔루션에서 사용할 수 있나요?**

예, Aspose.Slides는 클라우드 애플리케이션 및 서비스에 통합될 수 있습니다. 이 라이브러리는 서버 환경에서 동작하도록 설계되어 대량 파일 처리 시 높은 성능과 확장성을 제공합니다.

**변환 과정에서 프레젠테이션 크기 제한이 있나요?**

Aspose.Slides는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 그러나 매우 큰 파일을 다룰 경우 추가 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장될 때도 있습니다.