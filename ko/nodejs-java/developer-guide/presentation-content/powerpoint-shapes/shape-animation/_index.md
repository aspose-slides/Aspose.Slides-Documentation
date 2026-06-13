---
title: JavaScript를 사용하여 프레젠테이션에 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 도형 애니메이션을 생성하고 사용자 정의하는 방법을 알아보세요. 돋보이게 하세요!"
---
## **소개**

애니메이션은 텍스트, 이미지, 도형 또는 [차트](/slides/ko/nodejs-java/animated-charts/)에 적용할 수 있는 시각 효과입니다. 프레젠테이션이나 그 구성 요소에 생동감을 부여합니다.

## **프레젠테이션에서 애니메이션을 사용하는 이유**

* 정보 흐름을 제어합니다  
* 중요한 포인트를 강조합니다  
* 청중의 관심이나 참여를 높입니다  
* 콘텐츠를 더 쉽게 읽고 이해하거나 처리할 수 있도록 합니다  
* 청중이 프레젠테이션의 중요한 부분에 주목하도록 유도합니다  

PowerPoint는 **입장**, **퇴장**, **강조**, **동작 경로** 범주에 걸친 애니메이션 및 애니메이션 효과에 대한 다양한 옵션과 도구를 제공합니다.

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 애니메이션 작업에 필요한 클래스와 유형을 `Aspose.Slides.Animation` 네임스페이스 아래에 제공합니다,  
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effecttype) 열거형 아래에 **150개 이상의 애니메이션 효과**를 제공합니다. 이 효과들은 기본적으로 PowerPoint에서 사용되는 효과와 동일하거나 동등합니다.

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for Node.js via Java를 사용하면 도형의 텍스트에 애니메이션을 적용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 얻습니다.  
3. `rectangle` [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape)를 추가합니다.  
4. [AutoShape.addTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-)을 사용하여 텍스트를 추가합니다.  
5. 메인 효과 시퀀스를 가져옵니다.  
6. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape)에 애니메이션 효과를 추가합니다.  
7. `BuildType` 열거형에서 값을 사용하여 `TextAnimation.setBuildType` 메서드를 호출합니다.  
8. 프레젠테이션을 PPTX 파일로 저장합니다.

이 JavaScript 코드는 `Fade` 효과를 AutoShape에 적용하고 텍스트 애니메이션을 *By 1st Level Paragraphs* 값으로 설정하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 텍스트가 포함된 새 AutoShape를 추가합니다
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    var sequence = sld.getTimeline().getMainSequence();
    // 도형에 Fade 애니메이션 효과를 추가합니다
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 도형 텍스트를 1단계 단락별로 애니메이션합니다
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // PPTX 파일을 디스크에 저장합니다
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary"%}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [단락](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph)에 애니메이션을 적용할 수 있습니다. [**애니메이션 텍스트**](/slides/ko/nodejs-java/animated-text/)를 참조하십시오.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 얻습니다.  
3. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe)를 추가하거나 가져옵니다.  
4. 메인 효과 시퀀스를 가져옵니다.  
5. [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe)에 애니메이션 효과를 추가합니다.  
6. 프레젠테이션을 PPTX 파일로 저장합니다.  

이 JavaScript 코드는 `Fly` 효과를 사진 프레임에 적용하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션 이미지 컬렉션에 추가할 이미지를 로드합니다
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 슬라이드에 그림 프레임을 추가합니다
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 그림 프레임에 왼쪽에서 날아오는 애니메이션 효과를 추가합니다
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // PPTX 파일을 디스크에 저장합니다
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 얻습니다.  
3. `rectangle` [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape)를 추가합니다.  
4. `Bevel` [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape)를 추가합니다(이 개체를 클릭하면 애니메이션이 재생됩니다).  
5. 베벨 도형에 대한 효과 시퀀스를 생성합니다.  
6. 사용자 정의 `UserPath`를 생성합니다.  
7. `UserPath`로 이동하기 위한 명령을 추가합니다.  
8. 프레젠테이션을 PPTX 파일로 저장합니다.  

이 JavaScript 코드는 `PathFootball` (패스 풋볼) 효과를 도형에 적용하는 방법을 보여줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 기존 도형에 대해 처음부터 PathFootball 효과를 생성합니다.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // PathFootball 애니메이션 효과를 추가합니다
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // 일종의 "버튼"을 생성합니다.
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // 이 버튼을 위한 효과 시퀀스를 생성합니다.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // 사용자 정의 경로를 생성합니다. 버튼을 클릭한 후에만 객체가 움직입니다.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 생성된 경로가 비어 있으므로 이동 명령을 추가합니다.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형에 적용된 애니메이션 효과 가져오기**

다음 예제는 [Sequence](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/) 클래스의 `getEffectsByShape` 메서드를 사용하여 도형에 적용된 모든 애니메이션 효과를 가져오는 방법을 보여줍니다.

**예제 1: 일반 슬라이드의 도형에 적용된 애니메이션 효과 가져오기**

이전에 PowerPoint 프레젠테이션의 도형에 애니메이션 효과를 추가하는 방법을 배웠습니다. 다음 샘플 코드는 프레젠테이션 `AnimExample_out.pptx`의 첫 번째 일반 슬라이드에 있는 첫 번째 도형에 적용된 효과를 가져오는 방법을 보여줍니다.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // 슬라이드의 메인 애니메이션 시퀀스를 가져옵니다.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다.
    var shape = firstSlide.getShapes().get_Item(0);

    // 도형에 적용된 애니메이션 효과를 가져옵니다.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**예제 2: 자리표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

일반 슬라이드의 도형에 레이아웃 슬라이드 및/또는 마스터 슬라이드에 있는 자리표시자가 있고, 해당 자리표시자에 애니메이션 효과가 추가된 경우, 도형의 모든 효과가 슬라이드 쇼 중에 재생되며, 여기에는 자리표시자에서 상속된 효과도 포함됩니다.

예를 들어, `sample.pptx`라는 PowerPoint 프레젠테이션 파일에 하나의 슬라이드가 있고, 해당 슬라이드에는 "Made with Aspose.Slides" 텍스트가 있는 바닥글 도형만 있으며, 그 도형에 **Random Bars** 효과가 적용되어 있다고 가정해 보겠습니다.

![Slide shape animation effect](slide-shape-animation.png)

또한 **layout** 슬라이드의 바닥글 자리표시자에 **Split** 효과가 적용되어 있다고 가정합니다.

![Layout shape animation effect](layout-shape-animation.png)

마지막으로, **master** 슬라이드의 바닥글 자리표시자에 **Fly In** 효과가 적용되어 있습니다.

![Master shape animation effect](master-shape-animation.png)

다음 샘플 코드는 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 클래스의 `getBasePlaceholder` 메서드를 사용하여 도형 자리표시자에 접근하고, 레이아웃 및 마스터 슬라이드에 위치한 자리표시자에서 상속된 효과를 포함하여 바닥글 도형에 적용된 애니메이션 효과를 가져오는 방법을 보여줍니다.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // 플라이, 하단
Type: 134, subtype: 45            // 스플릿, 수직진입
Type: 126, subtype: 22            // RandomBars, 가로
```

## **애니메이션 효과 타이밍 속성 변경**

Aspose.Slides for Node.js via Java를 사용하면 애니메이션 효과의 타이밍 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 타이밍 창입니다:

![example1_image](shape-animation.png)

다음은 PowerPoint 타이밍과 [Effect.Timing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Effect#getTiming--) 속성 간의 대응 관계입니다:

- PowerPoint 타이밍 **Start** 드롭다운 목록은 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Timing#getTriggerType--) 속성과 일치합니다.  
- PowerPoint 타이밍 **Duration**은 [Effect.Timing.Duration](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Timing#getDuration--) 속성과 일치합니다. 애니메이션의 지속 시간(초)은 애니메이션이 한 사이클을 완료하는 총 시간입니다.  
- PowerPoint 타이밍 **Delay**는 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) 속성과 일치합니다.  

Effect 타이밍 속성을 변경하는 방법은 다음과 같습니다:

1. [Apply](#apply-animation-to-shape)하거나 애니메이션 효과를 가져옵니다.  
2. 필요한 [Effect.Timing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Effect#getTiming--) 속성에 새 값을 설정합니다.  
3. 수정된 PPTX 파일을 저장합니다.  

```javascript
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    var effect = sequence.get_Item(0);
    // 효과 TriggerType을 클릭 시 시작하도록 변경합니다
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // 효과 Duration을 변경합니다
    effect.getTiming().setDuration(3.0);
    // 효과 TriggerDelayTime을 변경합니다
    effect.getTiming().setTriggerDelayTime(0.5);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **애니메이션 효과 사운드**

Aspose.Slides는 애니메이션 효과의 사운드와 작업할 수 있도록 다음 속성을 제공합니다:

- [setSound(IAudio value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **애니메이션 효과 사운드 추가**

이 JavaScript 코드는 애니메이션 효과 사운드를 추가하고 다음 효과가 시작될 때 사운드를 중지하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    var firstEffect = sequence.get_Item(0);
    // 효과에 "소리 없음"이 설정되어 있는지 확인합니다
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // 첫 번째 효과에 사운드를 추가합니다
        firstEffect.setSound(effectSound);
    }
    // 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // 효과의 "이전 사운드 중지" 플래그를 설정합니다
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **애니메이션 효과 사운드 추출**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 얻습니다.  
3. 메인 효과 시퀀스를 가져옵니다.  
4. 각 애니메이션 효과에 포함된 [setSound(IAudio value)](...)를 추출합니다.  

이 JavaScript 코드는 애니메이션 효과에 포함된 사운드를 추출하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // 효과 사운드를 바이트 배열로 추출합니다
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **애니메이션 이후**

Aspose.Slides for Node.js via Java를 사용하면 애니메이션 효과의 After animation 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 효과 창 및 확장 메뉴입니다:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** 드롭다운 목록은 다음 속성과 일치합니다:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) 메서드는 After animation 유형을 설명합니다;  
  * PowerPoint **More Colors**는 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#Color) 유형과 일치합니다;  
  * PowerPoint **Don't Dim** 항목은 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) 유형과 일치합니다(기본 After animation 유형);  
  * PowerPoint **Hide After Animation** 항목은 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 유형과 일치합니다;  
  * PowerPoint **Hide on Next Mouse Click** 항목은 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 유형과 일치합니다;  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) 메서드는 After animation 색상 형식을 정의합니다. 이 메서드는 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#Color) 유형과 함께 작동합니다. 유형을 다른 것으로 변경하면 After animation 색상이 초기화됩니다.  

이 JavaScript 코드는 After animation 효과를 변경하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // After animation 유형을 Color로 변경합니다
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // After animation 색상을 설정합니다
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **텍스트 애니메이션**

Aspose.Slides는 애니메이션 효과의 *Animate text* 블록과 작업할 수 있도록 다음 속성을 제공합니다:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) 메서드는 효과의 Animate text 유형을 설명합니다. 도형 텍스트는 다음과 같이 애니메이션될 수 있습니다:  
  - 한 번에 전체 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) 유형)  
  - 단어 단위 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/animatetexttype/#ByWord) 유형)  
  - 글자 단위 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/animatetexttype/#ByLetter) 유형)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) 메서드는 애니메이션 텍스트 파트(단어 또는 글자) 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율을 나타내고, 음수 값은 초 단위 지연을 나타냅니다.  

Effect Animate text 속성을 변경하는 방법은 다음과 같습니다:

1. [Apply](#apply-animation-to-shape)하거나 애니메이션 효과를 가져옵니다.  
2. [setBuildType(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) 메서드를 [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/buildtype/#AsOneObject) 값으로 설정하여 *By Paragraphs* 애니메이션 모드를 끕니다.  
3. [setAnimateTextType(int value)](...) 및 [setDelayBetweenTextParts(float value)](...) 속성에 새 값을 설정합니다.  
4. 수정된 PPTX 파일을 저장합니다.  

```javascript
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // 메인 시퀀스의 첫 번째 효과를 가져옵니다
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // 효과 텍스트 애니메이션 유형을 "As One Object"로 변경합니다
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // 효과 Animate text 유형을 "By word"로 변경합니다
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // 단어 사이 지연을 효과 지속 시간의 20%로 설정합니다
    firstEffect.setDelayBetweenTextParts(20.0);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**프레젠테이션을 웹에 게시할 때 애니메이션이 유지되도록 하려면 어떻게 해야 하나요?**

[Export to HTML5](/slides/ko/nodejs-java/export-to-html5/)를 사용하고 [options](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/)에서 [shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/setanimateshapes/) 및 [transition](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/setanimatetransitions/) 애니메이션을 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않지만 HTML5는 재생합니다.

**도형의 z-순서(레이어 순서)를 변경하면 애니메이션에 어떤 영향을 줍니까?**

애니메이션 순서와 그리기 순서는 독립적입니다. 효과는 나타나거나 사라지는 타이밍과 유형을 제어하고, [z-order](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getzorderposition/)는 어떤 것이 다른 것을 가리는지를 결정합니다. 가시적인 결과는 이들의 조합에 의해 정의됩니다. (이는 일반적인 PowerPoint 동작이며, Aspose.Slides의 효과와 도형 모델도 동일한 논리를 따릅니다.)

**특정 효과를 비디오로 변환할 때 애니메이션에 제한이 있나요?**

일반적으로 [애니메이션이 지원됩니다](/slides/ko/nodejs-java/convert-powerpoint-to-video/)이지만, 드물거나 특정 효과는 다르게 렌더링될 수 있습니다. 사용 중인 효과와 라이브러리 버전으로 테스트하는 것이 권장됩니다.