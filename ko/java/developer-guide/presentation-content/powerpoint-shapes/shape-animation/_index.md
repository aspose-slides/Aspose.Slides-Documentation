---
title: "Java를 사용하여 프레젠테이션에 도형 애니메이션 적용"
linktitle: "도형 애니메이션"
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
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 도형 애니메이션을 만들고 맞춤 설정하는 방법을 알아보세요. 돋보이세요!"
---
## **소개**

Animations are visual effects that can be applied to texts, images, shapes, or [차트](https://docs.aspose.com/slides/ko/java/animated-charts/). They give life to presentations or its constituents. 

## **프레젠테이션에서 애니메이션을 사용하는 이유**

Using animations, you can 

* 정보 흐름 제어
* 중요한 포인트 강조
* 청중의 관심이나 참여 증가
* 내용을 더 쉽게 읽고 이해하거나 처리하도록
* 독자나 시청자의 주의를 프레젠테이션의 중요한 부분으로 끌기

PowerPoint provides many options and tools for animations and animation effects across the **entrance**, **exit**, **emphasis**, and **motion paths** categories. 

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 `Aspose.Slides.Animation` 네임스페이스 아래에서 애니메이션 작업에 필요한 클래스와 유형을 제공합니다,
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttype) 열거형에서 **150개 이상의 애니메이션 효과**를 제공합니다. 이 효과들은 본질적으로 PowerPoint에서 사용되는 동일하거나 동등한 효과입니다.

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for Java는 도형의 텍스트에 애니메이션을 적용할 수 있게 합니다. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) class.
2. Obtain a slide reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape). 
4. Add text to [IAutoShape.TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Get a main sequence of effects.
6. Add an animation effect to [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape). 
7. Set the `TextAnimation.BuildType` property to the value from `BuildType` Enumeration.
8. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `Fade` effect to AutoShape and set the text animation to *By 1st Level Paragraphs* value:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 텍스트가 포함된 새로운 AutoShape을 추가합니다.
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // 도형에 Fade 애니메이션 효과를 추가합니다.
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 도형 텍스트를 1단계 단락별로 애니메이션합니다.
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX 파일을 디스크에 저장합니다.
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph)에 애니메이션을 적용할 수 있습니다. [**Animated Text**](/slides/ko/java/animated-text/)를 보세요.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add or get a [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe) on the slide. 
4. Get the main sequence of effects.
5. Add an animation effect to [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe).
6. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `Fly` effect to a picture frame:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation();
try {
    // 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다.
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 슬라이드에 그림 프레임을 추가합니다.
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 그림 프레임에 왼쪽에서 날아오는 애니메이션 효과를 추가합니다.
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX 파일을 디스크에 저장합니다.
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape에 애니메이션 적용**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape). 
4. Add a `Bevel` [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape) (when this object is clicked, the animation gets played).
5. Create a sequence of effects on the bevel shape.
6. Create a custom `UserPath`.
7. Add commands for moving to the `UserPath`.
8. Write the presentation to disk as a PPTX file.

This Java code shows you how to apply the `PathFootball` (path football) effect to a shape:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 기존 도형에 대해 처음부터 PathFootball 효과를 생성합니다.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall 애니메이션 효과를 추가합니다.
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // "버튼"과 같은 것을 생성합니다.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 이 버튼에 대한 효과 시퀀스를 생성합니다.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // 사용자 정의 경로를 생성합니다. 객체는 버튼이 클릭된 후에만 이동합니다.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 생성된 경로가 비어 있으므로 이동 명령을 추가합니다.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX 파일을 디스크에 기록합니다.
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape에 적용된 애니메이션 효과 가져오기**

The following examples show you how to use the `getEffectsByShape` method from the [ISequence](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/) interface to get all animation effects applied to a shape.

**예제 1: 일반 슬라이드의 shape에 적용된 애니메이션 효과 가져오기**

Previously, you learned how to add animation effects to shapes in PowerPoint presentations. The following sample code shows you how to get the effects applied to the first shape on the first normal slide in the presentation `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 슬라이드의 메인 애니메이션 시퀀스를 가져옵니다.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 도형에 적용된 애니메이션 효과를 가져옵니다.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**예제 2: 자리 표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

If a shape on a normal slide has placeholders that are on the layout slide and/or master slide, and animation effects have been added to these placeholders, then all effects of the shape will be played during the slide show, including those inherited from the placeholders.

Let's say we have a PowerPoint presentation file `sample.pptx` with one slide containing only a footer shape with the text "Made with Aspose.Slides" and the **Random Bars** effect is applied to the shape.

![슬라이드 shape 애니메이션 효과](slide-shape-animation.png)

Let's also assume that the **Split** effect is applied to the footer placeholder on the **layout** slide.

![레이아웃 shape 애니메이션 효과](layout-shape-animation.png)

And finally, the **Fly In** effect is applied to the footer placeholder on the **master** slide.

![마스터 shape 애니메이션 효과](master-shape-animation.png)

The following sample code shows you how to use the `getBasePlaceholder` method from the [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) interface to access the shape placeholders and get the animation effects applied to the footer shape, including those inherited from placeholders located on the layout and master slides.

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **애니메이션 효과 타이밍 속성 변경**

Aspose.Slides for Java allows you to change the Timing properties of an animation effect.

This is the Animation Timing pane in Microsoft PowerPoint:

![예시1 이미지](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IEffect#getTiming--) properties:

- PowerPoint Timing **Start** drop-down list matches the [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITiming#getTriggerType--) property. 
- PowerPoint Timing **Duration** matches the [Effect.Timing.Duration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITiming#getDuration--) property. The duration of an animation (in seconds) is the total time it takes the animation to complete one cycle. 
- PowerPoint Timing **Delay** matches the [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITiming#getTriggerDelayTime--) property. 

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set new values for the [Effect.Timing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IEffect#getTiming--) properties you need. 
3. Save the modified PPTX file.

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    IEffect effect = sequence.get_Item(0);

    // 효과의 TriggerType을 클릭 시 시작하도록 변경합니다.
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 효과의 Duration을 변경합니다.
    effect.getTiming().setDuration(3f);

    // 효과의 TriggerDelayTime을 변경합니다.
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX 파일을 디스크에 저장합니다.
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **애니메이션 효과 사운드**

Aspose.Slides provides these properties to allow you to work with sounds in animation effects: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **애니메이션 효과 사운드 추가**

This Java code shows you how to add an animation effect sound and stop it when the next effect starts:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    IEffect firstEffect = sequence.get_Item(0);

    // 효과에 "No Sound"이 있는지 확인합니다
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 첫 번째 효과에 소리를 추가합니다
        firstEffect.setSound(effectSound);
    }

    // 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 효과의 "Stop previous sound" 플래그를 설정합니다
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **애니메이션 효과 사운드 추출**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) class.
2. Get a slide’s reference through its index. 
3. Get the main sequence of effects. 
4. Extract the [setSound(IAudio value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) embedded to each animation effect. 

This Java code shows you how to extract the sound embedded in an animation effect:

```java
import com.aspose.slides.*;

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

        // 효과 사운드를 바이트 배열로 추출합니다.
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **애니메이션 이후**

Aspose.Slides for Java allows you to change the After animation property of an animation effect.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![예시1 이미지](shape-after-animation.png)

PowerPoint Effect **After animation** drop-down list matches these properties: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) property which describes the After animation type :
  * PowerPoint **More Colors** matches the [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#Color) type;
  * PowerPoint **Don't Dim** list item matches the [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#DoNotDim) type (default after animation type);
  * PowerPoint **Hide After Animation** item matches the [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) type;
  * PowerPoint **Hide on Next Mouse Click** item matches the [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) type;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) property which defines an after animation color format. This property works in conjunction with the [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#Color) type. If you change the type to another, the after animation color will be cleared.

This Java code shows you how to change an after animation effect:

```java
import com.aspose.slides.*;
import java.awt.Color;

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // after animation 유형을 Color로 변경합니다
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // after animation 어두워지는 색을 설정합니다
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **텍스트 애니메이션**

Aspose.Slides provides these properties to allow you to work with an animation effect's *Animate text* block:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) which describes an animate text type of the effect. The shape text can be animated:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animatetexttype/#ByWord) type)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) sets a delay between the animated text parts (words or letters). A positive value specifies the percentage of effect duration. A negative value specifies the delay in seconds.

This is how you can change the Effect Animate text properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set the [setBuildType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextanimation/#setBuildType-int-) property to [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/buildtype/#AsOneObject) value to turn off the *By Paragraphs* animation mode.
3. Set new values for the [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) and [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) properties.
4. Save the modified PPTX file.

This Java code demonstrates the operation:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 효과의 텍스트 애니메이션 유형을 "As One Object"(하나의 객체)로 변경합니다
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 효과의 Animate text 유형을 "By word"(단어별)로 변경합니다
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 단어 사이의 지연을 효과 지속 시간의 20%로 설정합니다
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 프레젠테이션을 웹에 게시할 때 애니메이션이 보존되도록 하려면 어떻게 해야 하나요?

[HTML5로 내보내기](/slides/ko/java/export-to-html5/) 및 [옵션](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/)에서 [도형](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 및 [전환](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 애니메이션을 담당하는 항목을 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않으며, HTML5는 재생합니다.

### 도형의 z-순서(레이어 순서) 변경이 애니메이션에 어떤 영향을 줍니까?

Animation and drawing order are independent: an effect controls the timing and type of appearing/disappearing, while [z-order](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getZOrderPosition--) determines what covers what. The visible result is defined by their combination. (This is the general PowerPoint behavior; the Aspose.Slides effects-and-shapes model follows the same logic.)

### 특정 효과를 비디오로 변환할 때 제한 사항이 있나요?

일반적으로 [애니메이션은 지원됩니다](/slides/ko/java/convert-powerpoint-to-video/), 하지만 드문 경우나 특정 효과는 다르게 렌더링될 수 있습니다. 사용하는 효과와 라이브러리 버전으로 테스트하는 것이 권장됩니다.