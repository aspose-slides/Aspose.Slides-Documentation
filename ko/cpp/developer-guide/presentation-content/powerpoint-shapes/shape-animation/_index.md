---
title: C++을 사용한 프레젠테이션에서 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/cpp/shape-animation/
keywords:
- 도형
- 애니메이션
- 효과
- 애니메이션 도형
- 애니메이션 텍스트
- 애니메이션 추가
- 애니메이션 가져오기
- 애니메이션 추출
- 효과 추가
- 효과 가져오기
- 효과 추출
- 효과 사운드
- 애니메이션 적용
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 도형 애니메이션을 만들고 사용자 지정하는 방법을 알아보세요. 돋보이게 만들 수 있습니다!"
---
## **소개**

애니메이션은 텍스트, 이미지, 도형 또는 [차트](/slides/ko/cpp/animated-charts/)에 적용할 수 있는 시각 효과입니다. 프레젠테이션이나 그 구성 요소에 생동감을 부여합니다. 

## **프레젠테이션에서 애니메이션을 사용하는 이유**

애니메이션을 사용하면 

* 정보 흐름을 제어합니다
* 중요한 포인트를 강조합니다
* 청중의 관심이나 참여를 높입니다
* 콘텐츠를 더 쉽게 읽고 이해하거나 처리할 수 있게 합니다
* 독자나 시청자의 시선을 프레젠테이션의 중요한 부분으로 이끕니다

PowerPoint는 **입장**, **퇴장**, **강조**, **경로** 카테고리 전반에 걸쳐 다양한 애니메이션 옵션과 도구를 제공합니다. 

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 [Aspose.Slides.Animation](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation) 네임스페이스 아래에서 애니메이션 작업에 필요한 클래스와 타입을 제공합니다,
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 열거형 아래에서 **150개 이상의 애니메이션 효과**를 제공합니다. 이러한 효과는 기본적으로 PowerPoint에서 사용되는 효과와 동일하거나 동등합니다.

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for C++를 사용하면 도형의 텍스트에 애니메이션을 적용할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_auto_shape)를 추가합니다. 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3)에 텍스트를 추가합니다.
5. 메인 효과 시퀀스를 가져옵니다.
6. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_auto_shape)에 애니메이션 효과를 추가합니다. 
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) 속성을 [BuildType 열거형](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) 중 해당 값으로 설정합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 C++ 코드는 `Fade` 효과를 AutoShape에 적용하고 텍스트 애니메이션을 *By 1st Level Paragraphs* 값으로 설정하는 방법을 보여줍니다:

```c++
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 텍스트가 포함된 새 AutoShape를 추가합니다
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// 슬라이드의 메인 시퀀스를 가져옵니다.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// 도형에 Fade 애니메이션 효과를 추가합니다
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 도형 텍스트를 1단계 단락별로 애니메이션합니다
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// PPTX 파일을 디스크에 저장합니다
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [Paragraph](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_paragraph)에 애니메이션을 적용할 수 있습니다. [**Animated Text**](/slides/ko/cpp/animated-text/)를 참고하십시오.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_picture_frame)을 추가하거나 가져옵니다. 
4. 메인 효과 시퀀스를 가져옵니다.
5. [PictureFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_picture_frame)에 애니메이션 효과를 추가합니다.
6. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 C++ 코드는 `Fly` 효과를 picture frame에 적용하는 방법을 보여줍니다:

```c++
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// 슬라이드에 그림 프레임을 추가합니다
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// 슬라이드의 메인 시퀀스를 가져옵니다.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 그림 프레임에 왼쪽에서 날아오는 애니메이션 효과를 추가합니다
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX 파일을 디스크에 저장합니다
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **도형에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_auto_shape)를 추가합니다. 
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_auto_shape)를 추가합니다(이 객체를 클릭하면 애니메이션이 재생됩니다).
5. `Bevel` 도형에 대한 효과 시퀀스를 생성합니다.
6. 사용자 정의 `UserPath`를 생성합니다.
7. `UserPath`로 이동하기 위한 명령을 추가합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 C++ 코드는 `PathFootball`(경로 풋볼) 효과를 도형에 적용하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 프레젠테이션을 로드합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 선택된 슬라이드의 도형 컬렉션에 접근합니다
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 기존 도형에 대해 처음부터 PathFootball 효과를 만듭니다.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall 애니메이션 효과를 추가합니다
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// 일종의 "버튼"을 생성합니다.
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// 이 버튼에 대한 효과 시퀀스를 생성합니다.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // 사용자 정의 경로를 생성합니다. 버튼을 클릭한 후에만 객체가 이동합니다.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// 만든 경로가 비어 있으므로 이동 명령을 추가합니다.
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
	 
	 // PPTX 파일을 디스크에 저장합니다
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **도형에 적용된 애니메이션 효과 가져오기**

다음 예제들은 [ISequence](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/) 인터페이스의 `GetEffectsByShape` 메서드를 사용하여 도형에 적용된 모든 애니메이션 효과를 가져오는 방법을 보여줍니다.

**예제 1: 일반 슬라이드의 도형에 적용된 애니메이션 효과 가져오기**

이전에 PowerPoint 프레젠테이션에서 도형에 애니메이션 효과를 추가하는 방법을 배웠습니다. 다음 샘플 코드는 프레젠테이션 `AnimExample_out.pptx`의 첫 번째 일반 슬라이드에 있는 첫 번째 도형에 적용된 효과를 가져오는 방법을 보여줍니다.

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**예제 2: 자리표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

일반 슬라이드의 도형에 레이아웃 슬라이드 및/또는 마스터 슬라이드에 있는 자리표시자가 있고, 이러한 자리표시자에 애니메이션 효과가 추가된 경우, 해당 도형의 모든 효과는 슬라이드 쇼 중에 재생되며, 자리표시자에서 상속된 효과도 포함됩니다.

`sample.pptx`라는 PowerPoint 파일에 하나의 슬라이드가 있는데, 그 슬라이드에는 텍스트 "Made with Aspose.Slides"가 있는 푸터 도형만 존재하고, 해당 도형에 **Random Bars** 효과가 적용되어 있다고 가정해 보겠습니다.

![슬라이드 도형 애니메이션 효과](slide-shape-animation.png)

또한 **layout** 슬라이드의 푸터 자리표시자에 **Split** 효과가 적용되어 있다고 가정합니다.

![레이아웃 도형 애니메이션 효과](layout-shape-animation.png)

마지막으로 **master** 슬라이드의 푸터 자리표시자에 **Fly In** 효과가 적용되어 있습니다.

![마스터 도형 애니메이션 효과](master-shape-animation.png)

다음 샘플 코드는 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스의 `GetBasePlaceholder` 메서드를 사용하여 도형 자리표시자에 접근하고, 레이아웃 및 마스터 슬라이드에 위치한 자리표시자에서 상속된 효과를 포함하여 푸터 도형에 적용된 애니메이션 효과를 가져오는 방법을 보여줍니다.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 일반 슬라이드에서 도형에 적용된 애니메이션 효과를 가져옵니다.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// 레이아웃 슬라이드에서 자리표시자에 적용된 애니메이션 효과를 가져옵니다.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// 마스터 슬라이드에서 자리표시자에 적용된 애니메이션 효과를 가져옵니다.
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
Type: 47, subtype: 2              // 플라이, 하단
Type: 134, subtype: 45            // 스플릿, 수직진입
Type: 126, subtype: 22            // 랜덤바, 가로
```

## **애니메이션 효과 타이밍 속성 변경**

Aspose.Slides for C++를 사용하면 애니메이션 효과의 타이밍 속성을 변경할 수 있습니다.

Microsoft PowerPoint의 애니메이션 타이밍 창은 다음과 같습니다:

![예시1_이미지](shape-animation.png)

이것은 PowerPoint 타이밍과 [Effect.Timing](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) 속성 간의 대응 관계입니다:

- PowerPoint 타이밍 **Start** 드롭다운 목록은 [Effect.Timing.TriggerType] 속성과 일치합니다. 
- PowerPoint 타이밍 **Duration**은 [Effect.Timing.Duration] 속성과 일치합니다. 애니메이션의 지속시간(초)은 애니메이션이 한 사이클을 완료하는 데 걸리는 전체 시간입니다. 
- PowerPoint 타이밍 **Delay**는 [Effect.Timing.TriggerDelayTime] 속성과 일치합니다. 

Effect 타이밍 속성을 변경하는 방법은 다음과 같습니다:

1. [Apply](#apply-animation-to-shape) 또는 애니메이션 효과를 가져옵니다.
2. 필요한 [Effect.Timing] 속성에 새로운 값을 설정합니다. 
3. 수정된 PPTX 파일을 저장합니다.

다음 C++ 코드는 해당 작업을 시연합니다:

```c++
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 슬라이드의 메인 시퀀스를 가져옵니다.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// 메인 시퀀스의 첫 번째 효과를 가져옵니다.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// 효과 TriggerType을 클릭 시 시작하도록 변경합니다
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// 효과 Duration을 변경합니다
effect->get_Timing()->set_Duration(3.f);

// 효과 TriggerDelayTime을 변경합니다
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX 파일을 디스크에 저장합니다
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **애니메이션 효과 사운드**

Aspose.Slides는 애니메이션 효과에 사운드를 사용할 수 있도록 다음 속성을 제공합니다: 

- [set_Sound()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **애니메이션 효과 사운드 추가**

다음 C++ 코드는 애니메이션 효과 사운드를 추가하고 다음 효과가 시작될 때 사운드를 중지하는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 슬라이드의 메인 시퀀스를 가져옵니다.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// 메인 시퀀스의 첫 번째 효과를 가져옵니다
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// 효과에 "No Sound"가 설정되어 있는지 확인합니다
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // 첫 번째 효과에 사운드를 추가합니다
    firstEffect->set_Sound(effectSound);
}

// 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// 효과의 "Stop previous sound" 플래그를 설정합니다
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX 파일을 디스크에 저장합니다
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **애니메이션 효과 사운드 추출**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 메인 효과 시퀀스를 가져옵니다.
4. [set_Sound()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effect/set_sound/) 를 각 애니메이션 효과에 내장된 것을 추출합니다. 

다음 C++ 코드는 애니메이션 효과에 내장된 사운드를 추출하는 방법을 보여줍니다:

```c++
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 슬라이드의 메인 시퀀스를 가져옵니다.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **애니메이션 이후**

Aspose.Slides for C++를 사용하면 애니메이션 효과의 After animation 속성을 변경할 수 있습니다.

Microsoft PowerPoint의 애니메이션 효과 창 및 확장 메뉴는 다음과 같습니다:

![예시1_이미지](shape-after-animation.png)

PowerPoint 효과 **After animation** 드롭다운 목록은 다음 속성과 일치합니다: 

- `set_AfterAnimationType()` 속성은 After animation 유형을 설명합니다:
  * PowerPoint **More Colors**는 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다;
  * PowerPoint **Don't Dim** 항목은 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 유형(기본 After animation 유형)과 일치합니다;
  * PowerPoint **Hide After Animation** 항목은 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다;
  * PowerPoint **Hide on Next Mouse Click** 항목은 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다;
- `set_AfterAnimationColor()` 속성은 After animation 색상 형식을 정의합니다. 이 속성은 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 유형과 함께 작동합니다. 유형을 다른 것으로 변경하면 After animation 색상이 초기화됩니다.

다음 C++ 코드는 After animation 효과를 변경하는 방법을 보여줍니다:

```c++
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 메인 시퀀스의 첫 번째 효과를 가져옵니다
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// After animation 타입을 Color로 변경합니다
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// After animation 어두워지는 색상을 설정합니다
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX 파일을 디스크에 저장합니다
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **텍스트 애니메이션**

Aspose.Slides는 애니메이션 효과의 *Animate text* 블록을 다루기 위해 다음 속성을 제공합니다: 

- [set_AnimateTextType()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 은 효과의 애니메이션 텍스트 유형을 설명합니다. 도형 텍스트는 다음과 같이 애니메이션될 수 있습니다:
  - 전체 한 번에 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/animatetexttype/) 유형)
  - 단어별 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/animatetexttype/) 유형)
  - 문자별 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/animatetexttype/) 유형)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 는 애니메이션 텍스트 부분(단어나 문자) 사이의 지연을 설정합니다. 양수 값은 효과 지속시간의 백분율을 지정하고, 음수 값은 초 단위 지연을 지정합니다.

Effect Animate text 속성을 변경하는 방법은 다음과 같습니다:

1. [Apply](#apply-animation-to-shape) 또는 애니메이션 효과를 가져옵니다.
2. [set_BuildType()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 속성을 [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/buildtype/) 값으로 설정하여 *By Paragraphs* 애니메이션 모드를 해제합니다.
3. 새 값을 [set_AnimateTextType()] 및 [set_DelayBetweenTextParts()] 속성에 설정합니다.
4. 수정된 PPTX 파일을 저장합니다.

다음 C++ 코드는 해당 작업을 시연합니다:

```c++
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// 메인 시퀀스의 첫 번째 효과를 가져옵니다
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// 효과 Text animation 유형을 "As One Object"로 변경합니다
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// 효과 Animate text 유형을 "By word"로 변경합니다
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// 단어 사이 지연을 효과 지속시간의 20%로 설정합니다
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX 파일을 디스크에 저장합니다
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**프레젠테이션을 웹에 게시할 때 애니메이션이 보존되도록 하려면 어떻게 해야 하나요?**

[Export to HTML5](/slides/ko/cpp/export-to-html5/)를 사용하고, [shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/set_animateshapes/) 및 [transition](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/set_animatetransitions/) 애니메이션을 담당하는 [options](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/)를 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않지만, HTML5는 재생합니다.

**도형의 z-순서(레이어 순서)를 변경하면 애니메이션에 어떤 영향을 미칩니까?**

애니메이션 순서와 그리기 순서는 독립적입니다. 효과는 나타나거나 사라지는 타이밍과 유형을 제어하고, [z-order](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/get_zorderposition/)는 어떤 도형이 다른 도형을 가리는지를 결정합니다. 최종적인 시각 결과는 이들의 조합에 의해 정의됩니다. (이는 일반적인 PowerPoint 동작이며, Aspose.Slides의 효과와 도형 모델도 동일한 논리를 따릅니다.)

**특정 효과를 비디오로 변환할 때 애니메이션에 제한이 있나요?**

일반적으로 [애니메이션은 지원됩니다](/slides/ko/cpp/convert-powerpoint-to-video/), 하지만 드물게 일부 경우나 특정 효과는 다르게 렌더링될 수 있습니다. 사용 중인 효과와 라이브러리 버전으로 테스트하는 것이 권장됩니다.