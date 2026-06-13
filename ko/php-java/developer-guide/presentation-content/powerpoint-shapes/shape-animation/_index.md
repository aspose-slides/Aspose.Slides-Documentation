---
title: PHP를 사용한 프레젠테이션에서 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/php-java/shape-animation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 도형 애니메이션을 만들고 맞춤 설정하는 방법을 알아보세요. 돋보이세요!"
---
## **소개**

애니메이션은 텍스트, 이미지, 도형 또는 [차트](https://docs.aspose.com/slides/ko/php-java/animated-charts/)에 적용할 수 있는 시각 효과입니다. 프레젠테이션이나 그 구성 요소에 생동감을 부여합니다.

## **프레젠테이션에서 애니메이션을 사용하는 이유**

* 정보 흐름을 제어합니다
* 중요한 포인트를 강조합니다
* 청중의 관심이나 참여를 높입니다
* 내용을 더 쉽게 읽고 이해하거나 처리할 수 있도록 합니다
* 프레젠테이션에서 중요한 부분에 독자나 시청자의 주의를 끕니다

PowerPoint는 **입장**, **퇴장**, **강조**, 및 **움직임 경로** 범주에 걸쳐 애니메이션 및 애니메이션 효과를 위한 다양한 옵션과 도구를 제공합니다.

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 `Aspose.Slides.Animation` 네임스페이스 아래에서 애니메이션 작업에 필요한 클래스와 유형을 제공합니다,
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttype) 열거형에 정의된 **150개 이상의 애니메이션 효과**를 제공합니다. 이러한 효과는 본질적으로 PowerPoint에서 사용되는 효과와 동일하거나 동등합니다.

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for PHP via Java를 사용하면 도형의 텍스트에 애니메이션을 적용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 얻습니다.
3. 사각형 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
4. `AutoShape`의 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/#getTextFrame)에 텍스트를 추가합니다.
5. 주요 효과 시퀀스를 가져옵니다.
6. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)에 애니메이션 효과를 추가합니다.
7. `TextAnimation.setBuildType` 메서드와 `BuildType` 열거형의 값을 사용합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 PHP 코드는 `Fade` 효과를 AutoShape에 적용하고 텍스트 애니메이션을 *By 1st Level Paragraphs* 값으로 설정하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 텍스트가 포함된 새로운 AutoShape를 추가합니다
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # 슬라이드의 주요 시퀀스를 가져옵니다.
    $sequence = $sld->getTimeline()->getMainSequence();
    # 도형에 Fade 애니메이션 효과를 추가합니다
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # 도형 텍스트를 1단계 단락별로 애니메이션합니다
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)에 애니메이션을 적용할 수 있습니다. [**Animated Text**](/slides/ko/php-java/animated-text/)를 확인하십시오.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 얻습니다.
3. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe)를 추가하거나 가져옵니다.
4. 주요 효과 시퀀스를 가져옵니다.
5. [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe)에 애니메이션 효과를 추가합니다.
6. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 PHP 코드는 `Fly` 효과를 PictureFrame에 적용하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
  $pres = new Presentation();
  try {
    # 프레젠테이션 이미지 컬렉션에 추가할 이미지를 로드합니다
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 슬라이드에 그림 프레임을 추가합니다
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # 슬라이드의 주요 시퀀스를 가져옵니다.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 그림 프레임에 왼쪽에서 날아오는 애니메이션 효과를 추가합니다
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 얻습니다.
3. 사각형 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
4. 베벨 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)를 추가합니다 (이 객체를 클릭하면 애니메이션이 재생됩니다).
5. 베벨 도형에 대한 효과 시퀀스를 생성합니다.
6. 사용자 정의 `UserPath`를 생성합니다.
7. `UserPath`로 이동하는 명령을 추가합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

다음 PHP 코드는 `PathFootball` (path football) 효과를 도형에 적용하는 방법을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 기존 도형에 대해 처음부터 PathFootball 효과를 생성합니다.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # PathFootBall 애니메이션 효과를 추가합니다
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 일종의 "버튼"을 생성합니다.
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # 이 버튼에 대한 효과 시퀀스를 생성합니다.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # 사용자 지정 경로를 생성합니다. 객체는 버튼을 클릭한 후에만 이동합니다.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 생성된 경로가 비어 있으므로 이동 명령을 추가합니다.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # PPTX 파일을 디스크에 씁니다
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **도형에 적용된 애니메이션 효과 가져오기**

다음 예제에서는 [Sequence](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/) 클래스의 `getEffectsByShape` 메서드를 사용하여 도형에 적용된 모든 애니메이션 효과를 가져오는 방법을 보여줍니다.

**예제 1: 일반 슬라이드의 도형에 적용된 애니메이션 효과 가져오기**

이전에 PowerPoint 프레젠테이션에 도형에 애니메이션 효과를 추가하는 방법을 배웠습니다. 다음 샘플 코드는 `AnimExample_out.pptx` 프레젠테이션의 첫 번째 일반 슬라이드에 있는 첫 번째 도형에 적용된 효과를 가져오는 방법을 보여줍니다.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # 슬라이드의 주요 애니메이션 시퀀스를 가져옵니다.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # 도형에 적용된 애니메이션 효과를 가져옵니다.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**예제 2: 자리 표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

일반 슬라이드의 도형에 레이아웃 슬라이드 및/또는 마스터 슬라이드에 있는 자리 표시자가 있으며, 이러한 자리 표시자에 애니메이션 효과가 추가된 경우, 슬라이드 쇼 중에 도형의 모든 효과가 재생됩니다. 여기에는 자리 표시자에서 상속된 효과도 포함됩니다.

예를 들어 `sample.pptx` 프레젠테이션 파일에 하나의 슬라이드가 있고, 해당 슬라이드에는 텍스트가 "Made with Aspose.Slides"인 푸터 도형만 있으며 **Random Bars** 효과가 적용되어 있다고 가정해 보겠습니다.

![슬라이드 도형 애니메이션 효과](slide-shape-animation.png)

또한 **layout** 슬라이드의 푸터 자리 표시자에 **Split** 효과가 적용되어 있다고 가정합니다.

![레이아웃 도형 애니메이션 효과](layout-shape-animation.png)

마지막으로 **master** 슬라이드의 푸터 자리 표시자에 **Fly In** 효과가 적용되어 있습니다.

![마스터 도형 애니메이션 효과](master-shape-animation.png)

다음 샘플 코드는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스의 `getBasePlaceholder` 메서드를 사용하여 도형 자리 표시자에 접근하고 레이아웃 및 마스터 슬라이드에 있는 자리 표시자로부터 상속된 효과를 포함한 푸터 도형에 적용된 애니메이션 효과를 가져오는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// 정상 슬라이드에 있는 도형의 애니메이션 효과를 가져옵니다.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Get animation effects of the placeholder on the layout slide.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Get animation effects of the placeholder on the master slide.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // 플라이, 하단
Type: 134, subtype: 45            // 스플릿, 수직내부
Type: 126, subtype: 22            // 랜덤바, 가로
```

## **애니메이션 효과 타이밍 변경 방법**

Aspose.Slides for PHP via Java를 사용하면 애니메이션 효과의 Timing 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 타이밍 창입니다:

![애니메이션 타이밍 창](shape-animation.png)

PowerPoint 타이밍 **Start** 드롭다운 목록은 [Timing::getTriggerType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/#getTriggerType) 메서드와 일치합니다.
PowerPoint 타이밍 **Duration**은 [Timing::getDuration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/#getDuration) 메서드와 일치합니다. 애니메이션 지속 시간(초)은 애니메이션이 한 사이클을 완료하는 데 걸리는 총 시간입니다.
PowerPoint 타이밍 **Delay**는 [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/#getTriggerDelayTime) 메서드와 일치합니다.

다음은 Effect Timing 속성을 변경하는 방법입니다:

1. [Apply](#apply-animation-to-shape)하거나 애니메이션 효과를 가져옵니다.
2. [Effect::getTiming](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#getTiming) 메서드를 사용하여 필요한 새 값을 설정합니다.
3. 수정된 PPTX 파일을 저장합니다.

```php
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 슬라이드의 주요 시퀀스를 가져옵니다.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 주요 시퀀스의 첫 번째 효과를 가져옵니다.
    $effect = $sequence->get_Item(0);
    # 효과 TriggerType을 클릭 시 시작하도록 변경합니다
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # 효과 Duration을 변경합니다
    $effect->getTiming()->setDuration(3.0);
    # 효과 TriggerDelayTime을 변경합니다
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **애니메이션 효과 사운드**

Aspose.Slides는 애니메이션 효과에 사운드를 적용하기 위한 다음 메서드를 제공합니다:

- [setSound(IAudio value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 메서드
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-) 메서드

### **애니메이션 효과 사운드 추가**

다음 PHP 코드는 애니메이션 효과 사운드를 추가하고 다음 효과가 시작될 때 사운드를 중지하는 방법을 보여줍니다:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # 슬라이드의 주요 시퀀스를 가져옵니다.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # 주요 시퀀스의 첫 번째 효과를 가져옵니다.
    $firstEffect = $sequence->get_Item(0);
    # 효과에 "소리 없음"이 있는지 확인합니다
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # 첫 번째 효과에 소리를 추가합니다
      $firstEffect->setSound($effectSound);
    }
    # 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # 효과의 "이전 소리 중지" 플래그를 설정합니다
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **애니메이션 효과 사운드 추출**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 얻습니다.
3. 주요 효과 시퀀스를 가져옵니다.
4. 각 애니메이션 효과에 포함된 [setSound(IAudio value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 메서드를 추출합니다.

다음 PHP 코드는 애니메이션 효과에 포함된 사운드를 추출하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 슬라이드의 주요 시퀀스를 가져옵니다.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # 효과 사운드를 바이트 배열로 추출합니다
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **애니메이션 이후**

Aspose.Slides for PHP via Java를 사용하면 애니메이션 효과의 After animation 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 효과 창 및 확장 메뉴입니다:

![애니메이션 효과 창 및 확장 메뉴](shape-after-animation.png)

PowerPoint Effect **After animation** 드롭다운 목록은 다음 메서드와 일치합니다:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setAfterAnimationType) 메서드는 After animation 유형을 정의합니다:
  * PowerPoint **More Colors**는 [AfterAnimationType::Color](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/#Color) 유형과 일치합니다;
  * PowerPoint **Don't Dim** 항목은 [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/#DoNotDim) 유형과 일치합니다 (기본 애니메이션 이후 유형);
  * PowerPoint **Hide After Animation** 항목은 [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 유형과 일치합니다;
  * PowerPoint **Hide on Next Mouse Click** 항목은 [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 유형과 일치합니다;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setAfterAnimationColor) 메서드는 After animation 색상 형식을 정의합니다. 이 메서드는 [AfterAnimationType::Color](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/#Color) 유형과 함께 사용됩니다. 유형을 다른 것으로 변경하면 After animation 색상이 지워집니다.

다음 PHP 코드는 After animation 효과를 변경하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 주요 시퀀스의 첫 번째 효과를 가져옵니다
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # After animation 유형을 Color로 변경합니다
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # After animation 색상을 설정합니다
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **텍스트 애니메이션**

Aspose.Slides는 애니메이션 효과의 *Animate text* 블록을 다루기 위해 다음 메서드를 제공합니다:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setAnimateTextType) 메서드는 효과의 텍스트 애니메이션 유형을 정의합니다. 도형 텍스트는 다음과 같이 애니메이션될 수 있습니다:
  - 한 번에 모두 ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/ko/php-java/aspose.slides/animatetexttype/#AllAtOnce) 유형)
  - 단어별 ([AnimateTextType::ByWord](https://reference.aspose.com/slides/ko/php-java/aspose.slides/animatetexttype/#ByWord) 유형)
  - 문자별 ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/animatetexttype/#ByLetter) 유형)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setDelayBetweenTextParts) 메서드는 애니메이션된 텍스트 부분(단어 또는 문자) 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율을 의미하고, 음수 값은 초 단위 지연을 의미합니다.

다음은 Effect Animate text 속성을 변경하는 방법입니다:

1. [Apply](#apply-animation-to-shape)하거나 애니메이션 효과를 가져옵니다.
2. [setBuildType(int value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textanimation/#setBuildType) 메서드와 [BuildType::AsOneObject](https://reference.aspose.com/slides/ko/php-java/aspose.slides/buildtype/#AsOneObject) 값을 사용하여 *By Paragraphs* 애니메이션 모드를 끕니다.
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setAnimateTextType) 및 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/#setDelayBetweenTextParts) 메서드를 사용하여 새 값을 설정합니다.
4. 수정된 PPTX 파일을 저장합니다.

```php
  # 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 주요 시퀀스의 첫 번째 효과를 가져옵니다
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 효과 텍스트 애니메이션 유형을 "As One Object" 로 변경합니다
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # 효과 애니메이트 텍스트 유형을 "By word" 로 변경합니다
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 단어 사이의 지연을 효과 지속 시간의 20% 로 설정합니다
    $firstEffect->setDelayBetweenTextParts(20.0);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**프레젠테이션을 웹에 게시할 때 애니메이션이 유지되도록 하려면 어떻게 해야 하나요?**

[Export to HTML5](/slides/ko/php-java/export-to-html5/)를 사용하고 [shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/html5options/setanimateshapes/) 및 [transition](https://reference.aspose.com/slides/ko/php-java/aspose.slides/html5options/setanimatetransitions/) 애니메이션을 담당하는 옵션을 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않지만 HTML5는 재생합니다.

**도형의 z-순서(레이어 순서)를 변경하면 애니메이션에 어떤 영향을 줍니까?**

애니메이션 순서와 그리기 순서는 독립적입니다. 효과는 나타나고 사라지는 타이밍과 유형을 제어하고, [z-order](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getzorderposition/)는 무엇이 무엇을 가리는지를 결정합니다. 시각적 결과는 두 요소의 조합에 따라 정의됩니다. (이는 일반적인 PowerPoint 동작이며, Aspose.Slides의 효과와 도형 모델도 동일한 논리를 따릅니다.)

**특정 효과를 비디오로 변환할 때 제한 사항이 있나요?**

일반적으로 [애니메이션이 지원됩니다](/slides/ko/php-java/convert-powerpoint-to-video/), 그러나 드물게 특정 효과가 다르게 렌더링될 수 있습니다. 사용하려는 효과와 라이브러리 버전으로 테스트하는 것이 권장됩니다.