---
title: PHP에서 사용자 정의 애니메이션 동작 만들기 및 수정
linktitle: 사용자 지정 애니메이션
type: docs
weight: 151
url: /ko/php-java/custom-animation/
keywords:
- 사용자 지정 애니메이션
- 애니메이션 동작
- 움직임 경로
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 사용자 지정 애니메이션 동작 및 편집 가능한 움직임 경로를 만들고, 검사하고, 수정합니다."
---
## **개요**

맞춤 애니메이션 동작을 사용하면 색상 변경, 도형 회전 또는 편집 가능한 움직임 경로 따르기와 같은 애니메이션 효과 내 개별 작업을 제어할 수 있습니다. 이 가이드에서는 동작을 생성하고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사하고 수정하는 방법, 그리고 프레젠테이션을 저장하고 다시 열어도 속성이 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과 및 클릭 트리거에 대해서는 [도형 애니메이션](/slides/ko/php-java/shape-animation/)을 참조하십시오.

## **애니메이션 모델 이해하기**

애니메이션은 **Timeline → Sequence → Effect → Behaviors** 순서로 구성됩니다:

- 각 슬라이드에는 기본 시퀀스와 인터랙티브 시퀀스를 포함하는 타임라인이 있습니다.
- A [Sequence](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/)는 효과를 포함하며, 잠재적으로 서로 다른 도형을 대상으로 할 수 있습니다.
- An [Effect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/)는 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- The collection returned by [Effect::getBehaviors](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getbehaviors/)에는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업이 포함됩니다.

## **개별 동작 만들기**

Call [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/) to create an effect and access the [getBehaviors](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getbehaviors/) collection. A preset can populate this collection automatically. Keep its operations when extending the preset, or use [clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/clear/) when deliberately replacing them.

[BehaviorFactory](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/) creates the eight behavior types illustrated below. Motion is covered in [Build a Motion Path](#build-a-motion-path). Each snippet includes its imports and assumes that the PHP/Java Bridge and the Aspose.Slides PHP library have been loaded. Later editing examples state which output file they use.

### **회전**

Use [createRotationEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createrotationeffect/) to create a rotation. [getBy](https://reference.aspose.com/slides/ko/php-java/aspose.slides/rotationeffect/getby/) specifies a relative angle in degrees; [getFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/rotationeffect/getfrom/) and [getTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/rotationeffect/getto/) specify endpoints.

The example starts with a Spin effect, replaces its preset operations with one rotation behavior, and gives that operation a two-second duration. A relative angle of 90 degrees expresses a quarter-turn from the shape's starting orientation, so no explicit starting angle is needed.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` 파일에는 하나의 도형과 하나의 회전 동작이 포함되어 있습니다. 아래 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조정**

Use [createScaleEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createscaleeffect/) with X/Y percentages: [getFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/scaleeffect/getfrom/) and [getTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/scaleeffect/getto/) describe the starting and ending size, while [getBy](https://reference.aspose.com/slides/ko/php-java/aspose.slides/scaleeffect/getby/) describes a relative change. Here, 100 means the original size.

The example grows both dimensions from 100% to 125% over two seconds. Using equal horizontal and vertical percentages keeps the shape's proportions; different percentages would stretch one dimension more than the other.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **색상**

Use [createColorEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createcoloreffect/) to change the fill from blue to orange. [getFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/coloreffect/getfrom/) and [getTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/coloreffect/getto/) are colors; [getBy](https://reference.aspose.com/slides/ko/php-java/aspose.slides/coloreffect/getby/) is a color offset. The behavior's [BehaviorPropertyCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorpropertycollection/) identifies the attribute being animated.

The shape's solid fill is initialized to blue, matching the animation's starting color. Selecting the fill-color attribute tells the behavior which part of the shape to change; the color endpoints alone do not identify that attribute. The saved effect describes a two-second transition to orange.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **필터**

Use [createFilterEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createfiltereffect/) to select a wipe. [getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filtereffect/getsubtype/), and [getReveal](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filtereffect/getreveal/) specify the filter, direction, and whether to reveal or hide the shape.

This example configures a two-second wipe that reveals the shape using the right-direction subtype. The filter settings belong to the behavior inside the effect, so they are configured after the preset's original operations have been removed.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **속성**

Use [createPropertyEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) to animate opacity. [getFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/propertyeffect/getto/), and [getBy](https://reference.aspose.com/slides/ko/php-java/aspose.slides/propertyeffect/getby/) are strings interpreted using [getValueType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/propertyeffect/getvaluetype/) and [getCalcMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/propertyeffect/getcalcmode/). Choose endpoints or a relative offset rather than setting all three indiscriminately.

Here, the selected attribute is opacity, and the numeric strings represent a change from 25% opacity to full opacity. Linear interpolation describes a gradual change between those values. When adapting this example to another attribute, choose a value type and endpoint values appropriate to that attribute.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **설정**

Use [createSetEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createseteffect/) to assign visibility through [getTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/seteffect/getto/). A set behavior does not interpolate between endpoints.

The example selects the visibility attribute and assigns the string `visible` when the behavior runs. The rectangle is already visible in this minimal presentation, so the assignment may not produce an obvious visual change on its own. Such an operation is useful as part of a larger effect that also controls when the shape becomes hidden or visible.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **명령**

Use [createCommandEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createcommandeffect/) and configure [getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commandeffect/getcommandstring/), and [getShapeTarget](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commandeffect/getshapetarget/). Place a WAV recording named `sample.wav` in the working directory. This example embeds it with [addAudioFrameEmbedded](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addaudioframeembedded/) and attaches a play command to the audio frame.

The audio frame is both the effect's target and the command's target. This connects the play request to the embedded recording; a command string by itself does not identify which media object to control. The effect is configured to start on a click during the slideshow.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Saving stores the command in `command.pptx`; it does not play the recording. Playback requires a slideshow player that supports the command and its media target.

## **동작 컬렉션 관리**

[BehaviorCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/) supports [add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/remove/), and [removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/removeat/). This example opens `rotation.pptx`, adds scaling, moves it before rotation, and removes the rotation. Removing and reinserting the same object changes its stored position without making a copy.

The sequence of edits changes the collection from rotation–scale to scale–rotation, then to scale only. Indices refer to the current collection, so the removal uses the rotation's new index after reordering. The final enumeration confirms which behavior will be saved.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The output is `ScaleEffect`: only scaling remains. Collection order does not, by itself, schedule behaviors one after another. Clear the collection only when replacing all its operations.

## **동작 타이밍 구성**

A behavior has its own [Timing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/), independent of the timing returned by [Effect::getTiming](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/gettiming/). Effect timing schedules the enclosing effect; behavior timing describes an operation inside it.

### **지속 시간, 지연, 반복 및 가속 설정**

Open `rotation.pptx` and set the duration ([getDuration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getduration/)) and trigger delay ([getTriggerDelayTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/gettriggerdelaytime/)) in seconds, then configure the repeat count through [setRepeatCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getaccelerate/) and [getDecelerate](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getdecelerate/) are fractions of the duration; keep their sum at most 1.

The input file is the one created in the rotation example, where the first behavior is known to be a rotation. This example changes only that behavior's timing; its 90-degree angle remains intact. Keeping the angle and timing separate makes it easier to adjust the pace without rebuilding the animation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The behavior uses a two-second duration, a half-second delay, and a repeat count of 3. The first and last 20% of its duration are used for acceleration and deceleration.

Other repeat policies include [getRepeatDuration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrepeatuntilendslide/), and [getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrepeatuntilnextclick/); choose a policy rather than enabling them all together. [getAutoReverse](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getautoreverse/) plays the animation backwards after the forward pass. Acceleration and deceleration apply to continuous changes, not discrete assignments or commands.

## **움직임 경로 만들기**

Use [createMotionEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorfactory/createmotioneffect/) to create motion. Its [getFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioneffect/getto/), and [getBy](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioneffect/getby/) describe percentage-based coordinates or offsets. For an editable route, create a [MotionPath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motionpath/) and assign it with [MotionEffect::setPath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motionpath/) stores the path commands.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioncommandpathtype/) selects the operation:

| 명령 | 포인트 수 | 설명 |
| --- | --- | --- |
| MoveTo | One | 시작 위치를 설정합니다. |
| LineTo | One | 직선 구간을 따라 끝점까지 이동합니다. |
| CurveTo | Three | 두 개의 제어점과 끝점으로 정의된 3차 곡선을 따라 이동합니다. |
| CloseLoop | None | 시작 위치로 돌아갑니다. |
| End | None | 경로를 종료합니다. |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motionpathpointstype/) describes point-editing characteristics, such as corner or smooth points. It does not replace the command type. Use a curve point type for the curve example below, and a corner point type for the straight segments.

Path coordinates are normalized to slide dimensions: an X displacement of 0.25 represents one quarter of the slide width, not 0.25 points. Positive Y runs downward. Absolute commands specify positions in the path coordinate system; relative commands specify offsets from the current position. This is separate from [getOrigin](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioneffect/getorigin/), which selects the path's reference frame, and [getPathEditMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioneffect/getpatheditmode/), which controls how the path moves when the shape is moved.

### **직선 경로 만들기**

Create a motion behavior with a starting point, one straight segment, and an end command. [MotionPath::add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motionpath/add/) takes the command type, its points, the point type, and a relative-coordinate flag.

The starting command establishes (0, 0), and the line ends at (0.25, 0), giving the route a horizontal displacement of one quarter of the slide width. The ending command has no coordinate points. Once the path is assigned, adding the motion behavior to the effect connects that route to the rectangle.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` 파일에는 세 개의 경로 명령을 가진 하나의 움직임 동작이 포함되어 있습니다. 아래 파일 편집 예제는 이 알려진 구조를 사용합니다.

### **절대 좌표와 상대 좌표 비교**

These two path objects describe the same route. The absolute command ends at (0.3, 0.1); the relative command adds (0.1, 0.1) to the current position, (0.2, 0).

Both paths start at the same position. For the relative line, add its X and Y offsets to the current position to obtain the endpoint; for the absolute line, read the endpoint directly. Switching the flag without converting the coordinates would describe a different route.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Assign either path to a motion behavior to use it in a presentation. The final Boolean argument selects relative coordinates for that command.

### **선 대신 곡선으로 교체**

Open `motion.pptx` and replace its line command with a cubic curve. Supply the two control points first, followed by the endpoint.

The starting position is supplied by the preceding command. The first two points shape the curve, while the third is its destination; they are not three successive destinations. Updating the command type, point-editing type, and point array together keeps the segment consistent with its new geometry.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The path in `curve.pptx` still has three commands; its middle command now defines a curve.

## **저장된 경로 검사 및 편집**

Each [MotionCmdPath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioncmdpath/) exposes [getPoints](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioncmdpath/getpointstype/), and [isRelative](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motioncmdpath/isrelative/). The following examples use the known three-command path in `motion.pptx`. For arbitrary input, locate the intended effect and check command types and point counts before editing by index.

### **명령 및 좌표 읽기**

Read the path without changing it. End and close-loop commands need no points, so allow for a null point array.

The output pairs each numeric command type with its relative-coordinate flag before listing its points. This lets you distinguish an endpoint from an offset before modifying the path. A curve would list three points, whereas the straight line in this file lists only one.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

The listing contains a starting point, an absolute line ending at (0.25, 0), and an end command.

### **끝점 변경**

Open `motion.pptx` and replace the line's point array to move its endpoint.

In the input file, index 0 is the starting command and index 1 is the line. Replacing the line's single point changes its destination without changing its command type, timing, or position in the collection. Because the command uses absolute coordinates, the new pair specifies a position rather than an added offset.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The line in `motion-endpoint.pptx` ends at (0.4, 0.1); the original file is unchanged.

### **세그먼트 교체**

Use [insert](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motionpath/insert/) and [removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/motionpath/removeat/) to replace the line in `motion.pptx`. Inserting shifts the old line to index 2.

This demonstrates replacing a command object rather than editing its existing coordinates. After insertion, the collection temporarily contains the starting command, the new line, the old line, and the end command. Removing index 2 discards the old line and leaves the new route in place.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The saved path still has three commands, with the new line ending at (0.2, 0.1) and the end command last.

## **기존 동작 수정 및 검증**

When the behavior's index is unknown, select it by type. This example opens `rotation.pptx`, finds its [RotationEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/rotationeffect/), changes the angle, and checks the saved value after reopening.

The type check allows the loop to skip behaviors that are not rotations. The second load reads the saved file into a separate presentation object, so the comparison checks persisted data rather than the value still held in memory. This example still assumes the known effect is first in the main sequence; selecting a behavior by type does not locate the correct effect in an arbitrary presentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

The output is `Rotation preserved: true`. Apply the same type-checking pattern to other behaviors. For a complete preservation check, compare the target shape, effect, behavior types and order, timing, and path commands. Use a numeric tolerance for floating-point values. For a presentation with an unknown animation layout, see [Read Shape Animations](/slides/ko/php-java/shape-animation/#read-shape-animations) for traversal of main and interactive sequences.

## **동작 순서, 프리셋 및 재생**

The order in [BehaviorCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behaviorcollection/) is the stored order of an effect's operations. It is not a playlist in which every behavior automatically waits for the preceding one. Timing and the enclosing effect determine scheduling. Behaviors can overlap, and operations on the same property may interact through [additive](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behavioradditivetype/) and [accumulation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behavioraccumulatetype/) settings. Do not use collection reordering alone to schedule “move, then rotate”; use explicit timing or separate effects as described in [Shape Animation](/slides/ko/php-java/shape-animation/).

The effect's [getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/gettype/) and [getSubtype](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getsubtype/) describe its preset. They are not a complete description of an edited behavior tree. Choose the preset and subtype before customizing behaviors: changing the preset can rebuild the collection and discard your custom operations. For example, changing a customized Spin effect to Fade can replace its rotation behavior with set and filter behaviors. Inspect the collection again after changing a preset or subtype. Clearing preset behaviors can also remove visibility or initialization operations that the preset needs. The examples deliberately use visible shapes and replace the behaviors; they do not reconstruct every preset's implementation.

## **포맷 호환성**

A preserved behavior tree does not guarantee identical playback in every viewer or export renderer. Check the saved data and the rendered output separately.

| 포맷 또는 출력 | 확인 사항 |
| --- | --- |
| PPTX | 예제에서 기본 포맷으로 사용합니다. 파일을 다시 열어 편집 가능한 동작 트리를 확인한 뒤, 목표 PowerPoint 버전에서 재생을 검증하십시오. |
| PPT | 레거시 바이너리 형식은 PPTX와 다를 수 있습니다. 별도의 저장‑재열 사이클 및 재생을 테스트하고, PPTX 출력 성공만으로 모든 사용자 지정 조합을 지원한다고 추정하지 마십시오. |
| PDF, PNG, JPEG 및 기타 정적 슬라이드 이미지 | 정적인 슬라이드 표현을 포함하며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/php-java/export-to-html5/) | 내보내기 옵션에서 도형 애니메이션을 활성화하면 지원되는 애니메이션을 브라우저에서 재생할 수 있습니다. 사용자 지정 조합을 브라우저에서 테스트하십시오. |
| [Animated GIF](/slides/ko/php-java/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하므로 편집 가능한 동작이나 클릭 트리거 인터랙션은 포함되지 않습니다. 실제 렌더링된 움직임을 확인하십시오. |
| [Video](/slides/ko/php-java/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링하고 비디오로 인코딩합니다. 지원은 렌더러의 [지원되는 애니메이션 및 효과](/slides/ko/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)에 제한되며, 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 됩니다. |

## **FAQ**

**내가 아무 동작도 추가하기 전에 왜 효과에 동작이 포함되어 있나요?**

미리 정의된 효과를 만들면 그 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장할지 동작을 교체할지 결정하기 전에 이를 검사하십시오.

**동작을 처음으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대신할 수 없습니다. 지연 시간, 지속 시간 및 동일 속성에 대한 작업 간 상호 작용을 확인하십시오.

**끝 명령에 포인트가 없는 이유는 무엇인가요?**

경로의 종료를 표시하며 좌표가 필요하지 않습니다. 파일에서 경로를 읽을 때 null 포인트 배열을 확인하십시오.

**라운드 트립이 성공했다고 하면 재생이 보장되나요?**

아니요. 다시 열면 속성 보존을 확인할 수 있지만, 슬라이드쇼 플레이어나 애니메이션 내보내기를 별도로 테스트하여 실제 시각적 동작을 확인해야 합니다.