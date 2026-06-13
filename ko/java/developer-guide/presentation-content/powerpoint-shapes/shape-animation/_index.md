---
title: Java를 사용한 프레젠테이션에서 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 도형 애니메이션을 만들고 맞춤화하는 방법을 알아보세요. 돋보이게 하세요!"
---
## **소개**

애니메이션은 텍스트, 이미지, 도형 또는 [차트](https://docs.aspose.com/slides/ko/java/animated-charts/)에 적용될 수 있는 시각 효과입니다. 프레젠테이션이나 그 구성 요소에 생동감을 부여합니다. 

## **프레젠테이션에서 애니메이션을 사용하는 이유는?**

* 정보를 흐름을 제어한다
* 중요한 포인트를 강조한다
* 청중의 흥미나 참여도를 높인다
* 내용을 더 쉽게 읽거나 이해하거나 처리할 수 있게 만든다
* 프레젠테이션에서 중요한 부분에 독자나 시청자의 주의를 끈다

PowerPoint는 **입장**, **퇴장**, **강조**, **움직임 경로** 범주에 걸쳐 애니메이션 및 애니메이션 효과를 위한 다양한 옵션과 도구를 제공합니다. 

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 `Aspose.Slides.Animation` 네임스페이스 아래에서 애니메이션 작업에 필요한 클래스와 타입을 제공합니다.
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttype) 열거형에 **150개 이상의 애니메이션 효과**를 제공합니다. 이러한 효과는 본질적으로 PowerPoint에서 사용되는 효과와 동일(또는 동등)합니다.

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for Java를 사용하면 도형의 텍스트에 애니메이션을 적용할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape)을 추가합니다. 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)에 텍스트를 추가합니다.
5. 기본 효과 시퀀스를 가져옵니다.
6. [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape)에 애니메이션 효과를 추가합니다. 
7. `TextAnimation.BuildType` 속성을 `BuildType` 열거형의 값으로 설정합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 Java 코드는 AutoShape에 `Fade` 효과를 적용하고 텍스트 애니메이션을 *By 1st Level Paragraphs* 값으로 설정하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 텍스트가 있는 새 AutoShape을 추가합니다
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // 도형에 Fade 애니메이션 효과를 추가합니다
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 도형 텍스트를 1단계 단락별로 애니메이션합니다
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX 파일을 디스크에 저장합니다
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph)에 애니메이션을 적용할 수 있습니다. [**Animated Text**](/slides/ko/java/animated-text/)를 참조하세요.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe)을 추가하거나 가져옵니다. 
4. 기본 효과 시퀀스를 가져옵니다.
5. [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe)에 애니메이션 효과를 추가합니다.
6. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 Java 코드는 picture frame에 `Fly` 효과를 적용하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation();
try {
    // 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 슬라이드에 그림 프레임을 추가합니다
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 그림 프레임에 왼쪽에서 날아오는 애니메이션 효과를 추가합니다
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX 파일을 디스크에 저장합니다
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape)을 추가합니다. 
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape)를 추가합니다(이 개체를 클릭하면 애니메이션이 재생됩니다).
5. 베벨 도형에 대한 효과 시퀀스를 생성합니다.
6. 사용자 정의 `UserPath`를 생성합니다.
7. `UserPath`로 이동하기 위한 명령을 추가합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 Java 코드는 도형에 `PathFootball`(경로 축구) 효과를 적용하는 방법을 보여줍니다:

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 기존 도형에 대해 처음부터 PathFootball 효과를 생성합니다.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall 애니메이션 효과를 추가합니다
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 일종의 "버튼"을 생성합니다.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 이 버튼에 대한 효과 시퀀스를 생성합니다.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // 사용자 정의 경로를 생성합니다. 버튼을 클릭한 후에만 객체가 이동합니다.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 만든 경로가 비어 있으므로 이동 명령을 추가합니다.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형에 적용된 애니메이션 효과 가져오기**

다음 예제는 [ISequence](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/) 인터페이스의 `getEffectsByShape` 메서드를 사용하여 도형에 적용된 모든 애니메이션 효과를 가져오는 방법을 보여줍니다.

**예제 1: 일반 슬라이드의 도형에 적용된 애니메이션 효과 가져오기**

이전에 PowerPoint 프레젠테이션에서 도형에 애니메이션 효과를 추가하는 방법을 배웠습니다. 다음 샘플 코드는 프레젠테이션 `AnimExample_out.pptx`의 첫 번째 일반 슬라이드에서 첫 번째 도형에 적용된 효과를 가져오는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 슬라이드의 주요 애니메이션 시퀀스를 가져옵니다.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 도형에 적용된 애니메이션 효과를 가져옵니다.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**예제 2: 자리표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

일반 슬라이드의 도형에 레이아웃 슬라이드 및/또는 마스터 슬라이드에 있는 자리표시자가 있고, 이러한 자리표시자에 애니메이션 효과가 추가된 경우, 슬라이드 쇼 동안 해당 도형의 모든 효과가 재생되며, 여기에는 자리표시자에서 상속된 효과도 포함됩니다.

예를 들어 `sample.pptx`라는 PowerPoint 프레젠테이션 파일에 한 슬라이드가 있으며, 해당 슬라이드에는 푸터 도형에 'Made with Aspose.Slides' 텍스트가 포함되고 **Random Bars** 효과가 도형에 적용되어 있다고 가정해 보겠습니다.

![슬라이드 도형 애니메이션 효과](slide-shape-animation.png)

또한 레이아웃 슬라이드의 푸터 자리표시자에 **Split** 효과가 적용되어 있다고 가정합니다.

![레이아웃 도형 애니메이션 효과](layout-shape-animation.png)

마지막으로 마스터 슬라이드의 푸터 자리표시자에 **Fly In** 효과가 적용되어 있습니다.

![마스터 도형 애니메이션 효과](master-shape-animation.png)

다음 샘플 코드는 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인터페이스의 `getBasePlaceholder` 메서드를 사용하여 도형 자리표시자에 접근하고 레이아웃 및 마스터 슬라이드에 위치한 자리표시자에서 상속된 효과를 포함하여 푸터 도형에 적용된 애니메이션 효과를 가져오는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

출력:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **애니메이션 효과 타이밍 속성 변경**

Aspose.Slides for Java를 사용하면 애니메이션 효과의 타이밍 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint에서의 애니메이션 타이밍 창입니다:

![예시1_이미지](shape-animation.png)

다음은 PowerPoint 타이밍과 [Effect.Timing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IEffect#getTiming--) 속성 간의 대응 관계입니다:

- PowerPoint 타이밍 **Start** 드롭다운 목록은 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITiming#getTriggerType--) 속성과 일치합니다. 
- PowerPoint 타이밍 **Duration**은 [Effect.Timing.Duration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITiming#getDuration--) 속성과 일치합니다. 애니메이션의 지속 시간(초)은 애니메이션이 한 사이클을 완료하는 데 걸리는 총 시간입니다. 
- PowerPoint 타이밍 **Delay**는 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITiming#getTriggerDelayTime--) 속성과 일치합니다. 

다음은 Effect Timing 속성을 변경하는 방법입니다:

1. [Apply](#apply-animation-to-shape) 또는 애니메이션 효과를 가져옵니다.
2. 필요한 [Effect.Timing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IEffect#getTiming--) 속성에 새 값을 설정합니다. 
3. 수정된 PPTX 파일을 저장합니다.

다음 Java 코드는 해당 작업을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    IEffect effect = sequence.get_Item(0);

    // 효과 TriggerType을 클릭 시 시작하도록 변경합니다.
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 효과 Duration을 변경합니다.
    effect.getTiming().setDuration(3f);

    // 효과 TriggerDelayTime을 변경합니다.
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX 파일을 디스크에 저장합니다.
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **애니메이션 효과 사운드**

Aspose.Slides는 애니메이션 효과에서 사운드를 다룰 수 있도록 다음 속성을 제공합니다:

- [setSound(IAudio value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **애니메이션 효과 사운드 추가**

다음 Java 코드는 애니메이션 효과 사운드를 추가하고 다음 효과가 시작될 때 이를 중지하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    IEffect firstEffect = sequence.get_Item(0);

    // 효과에 "소리 없음"이 있는지 확인합니다
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 첫 번째 효과에 소리를 추가합니다
        firstEffect.setSound(effectSound);
    }

    // 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 효과 "이전 소리 중지" 플래그를 설정합니다
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **애니메이션 효과 사운드 추출**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 기본 효과 시퀀스를 가져옵니다. 
4. 각 애니메이션 효과에 내장된 [setSound(IAudio value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 를 추출합니다. 

다음 Java 코드는 애니메이션 효과에 내장된 사운드를 추출하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 효과 사운드를 바이트 배열로 추출합니다
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **애니메이션 후**

Aspose.Slides for Java를 사용하면 애니메이션 효과의 After animation 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 효과 창 및 확장 메뉴입니다:

![예시1_이미지](shape-after-animation.png)

PowerPoint 효과 **After animation** 드롭다운 목록은 다음 속성들과 일치합니다:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 속성은 After animation 유형을 설명합니다:
  * PowerPoint **More Colors**는 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#Color) 유형과 일치합니다;
  * PowerPoint **Don't Dim** 항목은 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#DoNotDim) 유형과 일치합니다(기본 after animation 유형);
  * PowerPoint **Hide After Animation** 항목은 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 유형과 일치합니다;
  * PowerPoint **Hide on Next Mouse Click** 항목은 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 유형과 일치합니다;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 속성은 after animation 색상 형식을 정의합니다. 이 속성은 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#Color) 유형과 함께 작동합니다. 유형을 다른 것으로 변경하면 after animation 색상이 초기화됩니다.

다음 Java 코드는 after animation 효과를 변경하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // after animation 유형을 Color로 변경합니다
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // after animation 색상을 설정합니다
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **텍스트 애니메이션**

Aspose.Slides는 애니메이션 효과의 *Animate text* 블록을 다룰 수 있도록 다음 속성을 제공합니다:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 은(는) 애니메이트 텍스트 유형을 설명합니다. 도형 텍스트는 다음과 같이 애니메이션될 수 있습니다:
  * 한 번에 전체 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animatetexttype/#AllAtOnce) 유형)
  * 단어별 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animatetexttype/#ByWord) 유형)
  * 글자별 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animatetexttype/#ByLetter) 유형)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 은(는) 애니메이트된 텍스트 부분(단어 또는 글자) 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율을 지정하고, 음수 값은 초 단위의 지연을 지정합니다.

다음은 Effect Animate text 속성을 변경하는 방법입니다:

1. [Apply](#apply-animation-to-shape) 또는 애니메이션 효과를 가져옵니다.
2. [setBuildType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextanimation/#setBuildType-int-) 속성을 [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/buildtype/#AsOneObject) 값으로 설정하여 *By Paragraphs* 애니메이션 모드를 끕니다.
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 및 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 속성에 새 값을 설정합니다.
4. 수정된 PPTX 파일을 저장합니다.

다음 Java 코드는 해당 작업을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 효과 Text animation type을 "As One Object"로 변경합니다
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 효과 Animate text type을 "By word"로 변경합니다
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 단어 사이 지연을 효과 지속시간의 20%로 설정합니다
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**프레젠테이션을 웹에 게시할 때 애니메이션이 보존되도록 하려면 어떻게 해야 하나요?**

[Export to HTML5](/slides/ko/java/export-to-html5/)를 사용하고 [옵션](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/) 중 [shape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 및 [transition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 애니메이션을 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않지만 HTML5는 재생합니다.

**도형의 z-순서(레이어 순서)를 변경하면 애니메이션에 어떤 영향을 줍니까?**

애니메이션 순서와 그리기 순서는 독립적입니다. 효과는 나타나거나 사라지는 타이밍과 유형을 제어하고, [z-order](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getZOrderPosition--)는 어떤 것이 무엇을 가리는지를 결정합니다. 가시적인 결과는 두 요소의 조합에 의해 정의됩니다. (이는 일반적인 PowerPoint 동작이며, Aspose.Slides의 효과와 도형 모델도 같은 논리를 따릅니다.)

**특정 효과를 비디오로 변환할 때 애니메이션에 제한이 있습니까?**

일반적으로 [애니메이션은 지원됩니다](/slides/ko/java/convert-powerpoint-to-video/), 하지만 드문 경우나 특정 효과는 다르게 렌더링될 수 있습니다. 사용하는 효과와 라이브러리 버전으로 테스트하는 것이 좋습니다.