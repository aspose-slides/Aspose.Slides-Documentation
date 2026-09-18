---
title: 在 PHP 中创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/php-java/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PowerPoint 演示文稿中使用 Aspose.Slides for PHP via Java 创建、检查和修改自定义动画行为以及可编辑的运动路径。"
---
## **概述**

自定义动画行为让您能够在动画效果中控制各个操作，例如更改颜色、旋转形状或沿可编辑的运动路径移动。本指南展示了如何创建和组合行为、配置它们的时间、检查和修改现有动画，以及验证它们的属性在保存并重新打开演示文稿后是否仍然保留。

有关预定义效果和点击触发器，请参阅[形状动画](/slides/zh/php-java/shape-animation/)。

## **了解动画模型**

动画的组织结构为 **时间线 → 序列 → 效果 → 行为**：

- 每张幻灯片都有一个时间线，包含其主序列和交互序列。
- 一个[Sequence](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/)包含可能针对不同形状的效果。
- 一个[Effect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/)标识目标形状、预设、子类型和效果时间。
- 通过[Effect::getBehaviors](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getbehaviors/)返回的集合包含实现该效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/)创建效果并访问[getBehaviors](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getbehaviors/)集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用[clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/clear/)。

[BehaviorFactory](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/)可以创建下文所示的八种行为类型。运动路径请参阅[构建运动路径](#build-a-motion-path)。每个代码片段都包含其导入，并假设已加载 PHP/Java Bridge 和 Aspose.Slides PHP 库。后续编辑示例会说明使用的输出文件。

### **旋转**

使用[createRotationEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createrotationeffect/)创建旋转。[getBy](https://reference.aspose.com/slides/zh/php-java/aspose.slides/rotationeffect/getby/)指定相对角度（度）；[getFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/rotationeffect/getfrom/)和[getTo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/rotationeffect/getto/)指定端点。

示例从 Spin 效果开始，用一个旋转行为替换其预设操作，并为该操作设置两秒持续时间。相对角度 90 度表示形状从起始方向旋转四分之一圈，因此无需显式指定起始角度。

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

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间和旋转编辑示例均基于此文件。

### **缩放**

使用[createScaleEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createscaleeffect/)并提供 X/Y 百分比：[getFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/scaleeffect/getfrom/)和[getTo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/scaleeffect/getto/)描述起始和结束大小，而[getBy](https://reference.aspose.com/slides/zh/php-java/aspose.slides/scaleeffect/getby/)描述相对变化。这里的 100 表示原始大小。

示例在两秒内将两个维度从 100% 增长到 125%。使用相同的水平和垂直百分比可保持形状比例；不同的百分比会导致某一维度被拉伸。

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

### **颜色**

使用[createColorEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createcoloreffect/)将填充从蓝色更改为橙色。[getFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/coloreffect/getfrom/)和[getTo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/coloreffect/getto/)是颜色；[getBy](https://reference.aspose.com/slides/zh/php-java/aspose.slides/coloreffect/getby/)是颜色偏移。行为的[BehaviorPropertyCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorpropertycollection/)标识被动画化的属性。

形状的实心填充初始化为蓝色，以匹配动画的起始颜色。选择填充颜色属性告诉行为要更改形状的哪一部分；仅有颜色端点不足以确定该属性。保存的效果描述了两秒的过渡到橙色。

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

### **滤镜**

使用[createFilterEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createfiltereffect/)选择擦除方式。[getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filtereffect/gettype/)、[getSubtype](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filtereffect/getsubtype/)和[getReveal](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filtereffect/getreveal/)分别指定滤镜、方向以及是显示还是隐藏形状。

本示例配置了一个两秒的擦除效果，使用右方向子类型显示形状。滤镜设置属于效果内部的行为，因此在移除预设的原始操作后进行配置。

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

### **属性**

使用[createPropertyEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createpropertyeffect/)动画化不透明度。[getFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/propertyeffect/getfrom/)、[getTo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/propertyeffect/getto/)和[getBy](https://reference.aspose.com/slides/zh/php-java/aspose.slides/propertyeffect/getby/)是字符串，需通过[getValueType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/propertyeffect/getvaluetype/)和[getCalcMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/propertyeffect/getcalcmode/)进行解释。请在端点或相对偏移之间进行选择，而不是同时设置三者。

此例选择的属性是不透明度，数值字符串表示从 25% 不透明度变化到完全不透明。线性插值描述了这些值之间的逐渐变化。将此示例改用于其他属性时，请为该属性选择合适的值类型和端点值。

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

### **设置**

使用[createSetEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createseteffect/)通过[getTo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/seteffect/getto/)赋值可见性。设置行为不在端点之间进行插值。

示例选择可见性属性，并在行为运行时将字符串 `visible` 赋给它。此矩形在本最小演示文稿中已经是可见的，因此仅此赋值可能不会产生明显的视觉变化。此类操作在更大的效果中用于控制形状何时隐藏或显示。

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

### **命令**

使用[createCommandEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createcommandeffect/)并配置[getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commandeffect/gettype/)、[getCommandString](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commandeffect/getcommandstring/)和[getShapeTarget](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commandeffect/getshapetarget/)。在工作目录中放置名为 `sample.wav` 的 WAV 录音。示例使用[addAudioFrameEmbedded](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addaudioframeembedded/)将其嵌入，并将播放命令附加到音频帧。

音频帧既是效果的目标也是命令的目标。这将播放请求关联到嵌入的录音；仅有命令字符串并不能确定要控制的媒体对象。效果被配置为在放映期间点击时启动。

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

保存后，命令存储在 `command.pptx` 中；它不会播放录音。播放需要支持该命令及其媒体目标的放映播放器。

## **管理行为集合**

[BehaviorCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/)支持[add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/add/)、[insert](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/insert/)、[remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/remove/)，以及[removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/removeat/)。本示例打开 `rotation.pptx`，添加缩放行为，将其在旋转前插入，随后移除旋转。对同一对象的移除再插入会改变其存储位置而不产生副本。

编辑顺序将集合从 rotation–scale 变为 scale–rotation，最后只剩 scale。索引始终指向当前集合，因此在重新排序后移除时使用旋转的新索引。最终枚举确认了将被保存的行为。

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

输出为 `ScaleEffect`：仅保留下缩放。集合顺序本身并不安排行为依次执行。仅在全部替换时才使用 clear 清空集合。

## **配置行为时间**

行为拥有独立的[Timing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/)，与[Effect::getTiming](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/gettiming/)返回的时间无关。效果时间安排整个效果；行为时间描述其中的具体操作。

### **设置持续时间、延迟、重复次数和加速**

打开 `rotation.pptx`，使用[getDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getduration/)设置持续时间，使用[getTriggerDelayTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/gettriggerdelaytime/)设置触发延迟（秒），然后通过[setRepeatCount](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/setrepeatcount/)配置重复次数。[getAccelerate](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getaccelerate/)和[getDecelerate](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getdecelerate/)是持续时间的分数，二者之和不超过 1。

输入文件为旋转示例中创建的文件，其中第一个行为已知为旋转。此示例仅修改该行为的时间，90 度角保持不变。将角度与时间分离，使得在不重新构建动画的情况下更容易调整节奏。

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

该行为使用两秒持续时间、半秒延迟，重复计数为 3。其持续时间的前后 20% 用于加速和减速。

其他重复策略包括[getRepeatDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrepeatduration/)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrepeatuntilendslide/)、[getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrepeatuntilnextclick/)；请选择一种而非同时启用全部。[getAutoReverse](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getautoreverse/)将在正向播放后逆向播放。加速和减速仅适用于连续变化，不适用于离散赋值或命令。

## **构建运动路径**

使用[createMotionEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorfactory/createmotioneffect/)创建运动。[getFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioneffect/getfrom/)、[getTo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioneffect/getto/)、[getBy](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioneffect/getby/)描述基于百分比的坐标或偏移。若需可编辑路径，请创建[MotionPath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motionpath/)并使用[MotionEffect::setPath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioneffect/setpath/)赋值。[MotionPath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motionpath/)存储路径命令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioncommandpathtype/)选择操作：

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 设置起始位置。 |
| LineTo | One | 沿直线段移动到终点。 |
| CurveTo | Three | 按两个控制点和终点绘制三次曲线。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 结束路径。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motionpathpointstype/)描述点的编辑特性，如拐角点或平滑点。它不会替代命令类型。曲线示例使用曲线点类型，直线段使用拐角点类型。

路径坐标相对于幻灯片尺寸归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。正 Y 向下。绝对命令使用路径坐标系的绝对位置；相对命令使用相对于当前位置信息的偏移。这与[getOrigin](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioneffect/getorigin/)（选择路径参考框架）和[getPathEditMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioneffect/getpatheditmode/)（控制形状移动时路径的行为）是分离的。

### **创建直线路径**

创建一个包含起始点、一个直线段和结束命令的运动行为。[MotionPath::add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motionpath/add/)接受命令类型、点数组、点类型和相对坐标标志。

起始命令建立 (0, 0)，直线以 (0.25, 0) 结束，使路径在水平方向上位移幻灯片宽度的四分之一。结束命令无坐标点。路径分配后，将运动行为添加到效果即可将该路线关联到矩形。

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

`motion.pptx` 包含一个具有三条路径命令的运动行为。以下文件编辑示例使用此已知结构。

### **比较绝对坐标和相对坐标**

这两个路径对象描述相同的路线。绝对命令结束于 (0.3, 0.1)；相对命令在当前位 (0.2, 0) 基础上添加 (0.1, 0.1)。

两条路径的起点相同。对于相对直线，将其 X、Y 偏移加到当前位即可得到终点；对于绝对直线，直接读取终点坐标。若不转换坐标而仅切换标志，会得到不同的路线。

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

将任一路径分配给运动行为即可在演示文稿中使用。最后的布尔参数决定该命令是否使用相对坐标。

### **用曲线替换直线**

打开 `motion.pptx`，将其直线命令替换为三次曲线。先提供两个控制点，随后提供终点。

起始位置由前一命令提供。前两个点定义曲线形状，第三个点为终点；它们不是三个连续的目的地。同步更新命令类型、点编辑类型以及点数组，可使段落与新几何保持一致。

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

`curve.pptx` 中的路径仍有三条命令，只是其中的中间命令现在定义为曲线。

## **检查并编辑已保存的路径**

每个[MotionCmdPath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioncmdpath/)都提供[getPoints](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioncmdpath/getpoints/)、[getCommandType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioncmdpath/getcommandtype/)、[getPointsType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioncmdpath/getpointstype/)和[isRelative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motioncmdpath/isrelative/)。以下示例使用 `motion.pptx` 中已知的三命令路径。对于任意输入，请先定位目标效果，检查命令类型和点数后再按索引编辑。

### **读取命令和坐标**

读取路径而不修改。结束和闭合循环命令不需要点，因此需允许空点数组。

输出在列出点之前，先将每个数值型命令类型与其相对坐标标志配对，这有助于在修改路径前区分是端点还是偏移。曲线会列出三个点，而本文件中的直线只列出一个。

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

列表包含起始点、绝对直线结束于 (0.25, 0) 和结束命令。

### **更改端点**

打开 `motion.pptx`，替换直线的点数组以移动其端点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单个点会改变其目的地，而不影响命令类型、时间或在集合中的位置。由于命令使用绝对坐标，新点对指定的是位置而非偏移。

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

`motion-endpoint.pptx` 中的直线结束于 (0.4, 0.1)；原文件保持不变。

### **替换段落**

使用[insert](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motionpath/insert/)和[removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/motionpath/removeat/)替换 `motion.pptx` 中的直线。插入会将旧直线移至索引 2。

该示例演示了替换命令对象而非编辑其现有坐标。插入后，集合临时包含起始命令、新直线、旧直线和结束命令。移除索引 2 即可删除旧直线，保留新路线。

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

保存的路径仍有三条命令，新直线结束于 (0.2, 0.1)，结束命令位于最后。

## **修改并验证现有行为**

当行为索引未知时，可按类型选择。本例打开 `rotation.pptx`，找到其[RotationEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/rotationeffect/)，更改角度，并在重新打开后检查保存的数值。

类型检查使循环跳过非旋转行为。第二次加载将已保存的文件读取到另一演示对象中，从而比较的是持久化数据而非仍在内存中的值。此示例仍假设已知的效果位于主序列的第一位；在任意演示文稿中仅按类型选择并不能保证定位到正确的效果。

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

输出为 `Rotation preserved: true`。对其他行为同样使用类型检查模式。要完成完整的保留检查，请比较目标形状、效果、行为类型及顺序、时间以及路径命令。对浮点值使用数值容差。对于动画布局未知的演示文稿，请参阅[读取形状动画](/slides/zh/php-java/shape-animation/#read-shape-animations)以遍历主序列和交互序列。

## **行为顺序、预设与播放**

[BehaviorCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behaviorcollection/) 中的顺序是效果操作的存储顺序。它不是一个播放列表，行为并不会自动等待前一个完成。时间和封闭的效果决定调度。行为可以重叠，同一属性的操作可能通过[additive](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behavioradditivetype/)和[accumulation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/behavioraccumulatetype/)设置相互影响。不要仅靠重新排序集合来调度 “移动后旋转”；请使用显式时间或如[形状动画](/slides/zh/php-java/shape-animation/) 中描述的独立效果。

效果的[getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/gettype/)和[getSubtype](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getsubtype/)描述其预设，并非已编辑行为树的完整描述。请选择预设和子类型后再自定义行为：更改预设会重建集合并丢弃自定义操作。例如，将自定义 Spin 效果改为 Fade 可能会用设置和滤镜行为替代其旋转行为。更改预设或子类型后请再次检查集合。清除预设行为也可能移除预设所需的可见性或初始化操作。示例使用可见形状并替换行为，而不重新构建每个预设的实现。

## **格式兼容性**

保留的行为树并不保证在所有查看器或导出渲染器中完全相同地播放。请分别检查保存的数据和渲染输出。

| 格式或输出 | 需要验证的内容 |
| --- | --- |
| PPTX | 本示例的首选格式。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放效果。 |
| PPT | 传统二进制格式可能与 PPTX 不同。请单独进行保存‑重新打开‑播放的循环测试；不要仅凭 PPTX 成功就推断 PPT 完全支持。 |
| PDF、PNG、JPEG 以及其他静态幻灯片图像 | 仅包含静态幻灯片表示，不包含可播放的行为时间轴或保证的最终动画帧。 |
| [HTML5](/slides/zh/php-java/export-to-html5/) | 在导出选项中启用形状动画后可以播放受支持的动画。请在浏览器中测试自定义组合。 |
| [Animated GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/) | 存储渲染后的帧，而非可编辑行为或点击触发的交互。请检查实际渲染的运动。 |
| [Video](/slides/zh/php-java/convert-powerpoint-to-video/) | 将动画帧渲染并编码为视频。支持受限于渲染器的[支持的动画和效果](/slides/zh/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)；命令和交互事件不会转化为可编辑时间轴。 |

## **常见问题**

**为什么在我没有添加任何行为之前，效果已经包含行为？**

创建预定义效果时可能会自动生成其底层操作。检查它们后再决定是扩展预设还是替换其行为。

**将行为移动到集合开头会让它先播放吗？**

不一定。集合顺序并不能替代时间设置。请检查延迟、持续时间以及同一属性上操作之间的交互。

**为什么结束命令没有点？**

结束命令标记路径结束，不需要坐标。读取文件中的路径时请留意可能出现的空点数组。

**一次成功的往返保存足以确认播放吗？**

不行。重新打开只能确认属性是否被保留。还需在幻灯片放映播放器或动画导出中单独测试其视觉表现。