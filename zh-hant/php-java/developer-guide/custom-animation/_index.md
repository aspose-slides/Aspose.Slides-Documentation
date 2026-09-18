---
title: 在 PHP 中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/php-java/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 移動路徑
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中建立、檢查與修改自訂動畫行為及可編輯的移動路徑。"
---
## **概觀**

自訂動畫行為允許您在動畫效果中控制個別操作，例如變更顏色、旋轉形狀或沿可編輯的移動路徑移動。本指南說明如何建立與組合行為、設定它們的時序、檢查與修改既有動畫，並驗證它們的屬性在儲存與重新開啟簡報後仍能保留。

對於預先定義的效果與點擊觸發，請參閱[Shape Animation](/slides/zh-hant/php-java/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **Timeline → Sequence → Effect → Behaviors**：

- 每張投影片都有一個時間軸，包含其主要序列與互動序列。
- 一個[Sequence](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/)包含效果，可能針對不同的形狀。
- 一個[Effect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/)識別目標形狀、預設、子類型以及效果時序。
- 由[Effect::getBehaviors](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getbehaviors/)回傳的集合包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立個別行為**

呼叫[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/)建立效果，並存取[getBehaviors](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getbehaviors/)集合。預設可以自動填充此集合。擴充預設時保留其操作，或在有意替換時使用[clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/clear/)。

[BehaviorFactory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/)建立下列八種行為類型。移動路徑的說明見[Build a Motion Path](#build-a-motion-path)。每個程式碼片段皆包含其 import，並假設已載入 PHP/Java Bridge 及 Aspose.Slides PHP 函式庫。後續編輯範例會說明使用的輸出檔案。

### **旋轉**

使用[createRotationEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createrotationeffect/)建立旋轉。[getBy](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/rotationeffect/getby/)指定相對角度（度）；[getFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/rotationeffect/getfrom/)與[getTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/rotationeffect/getto/)指定端點。

此範例以 Spin 效果開始，將其預設操作替換為單一旋轉行為，並將該操作的持續時間設為兩秒。90 度的相對角度表示形狀從起始方向旋轉四分之一圈，因此不需要明確的起始角度。

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

`rotation.pptx` 包含一個形狀與一個旋轉行為。以下的集合、時序與旋轉編輯範例均使用此檔案。

### **縮放**

使用[createScaleEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createscaleeffect/)搭配 X/Y 百分比：[getFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/scaleeffect/getfrom/)與[getTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/scaleeffect/getto/)描述起始與結束大小，而[getBy](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/scaleeffect/getby/)描述相對變化。此處 100 代表原始大小。

範例將兩個維度從 100% 成長至 125%，持續兩秒。使用相同的水平與垂直百分比可保持形狀比例；不同的百分比則會使某一維度較另一維度伸展。

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

### **顏色**

使用[createColorEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createcoloreffect/)將填色從藍色變為橙色。[getFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/coloreffect/getfrom/)與[getTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/coloreffect/getto/)是顏色；[getBy](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/coloreffect/getby/)是顏色偏移。此行為的[BehaviorPropertyCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorpropertycollection/)指出被動畫化的屬性。

形狀的實心填色先設為藍色，與動畫的起始顏色相符。選取填色屬性告訴行為要變更形狀的哪一部分；僅有顏色端點並不會指明屬性。儲存的效果描述了兩秒的過渡到橙色。

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

### **濾鏡**

使用[createFilterEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createfiltereffect/)選取擦除方式。[getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filtereffect/gettype/)、[getSubtype](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filtereffect/getsubtype/)與[getReveal](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filtereffect/getreveal/)分別指定濾鏡、方向以及是顯示還是隱藏形狀。

此範例設定兩秒的擦除，以右方向子類別顯示形狀。濾鏡設定屬於效果內的行為，因此在移除預設原始操作後再進行設定。

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

### **屬性**

使用[createPropertyEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createpropertyeffect/)為不透明度設定動畫。[getFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/propertyeffect/getfrom/)、[getTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/propertyeffect/getto/)、[getBy](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/propertyeffect/getby/)是字串，會由[getValueType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/propertyeffect/getvaluetype/)與[getCalcMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/propertyeffect/getcalcmode/)解釋。請選擇端點或相對偏移，而非同時設定全部三項。

此例選取的不透明度屬性，數值字串表示從 25% 不透明度變為完整不透明度。線性插值描述了在這些值之間的漸變。若要將範例套用到其他屬性，請為該屬性選擇適當的值類型與端點值。

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

### **設定**

使用[createSetEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createseteffect/)透過[getTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/seteffect/getto/)指派可見性。設定行為不會在端點之間插值。

範例選取可見性屬性，並在行為執行時指派字串`visible`。在此最小簡報中矩形本身已可見，因此此指派本身可能不會產生明顯的視覺變化。此類操作在控制形狀何時隱藏或顯示的較大效果中很有用。

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

### **指令**

使用[createCommandEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createcommandeffect/)並設定[getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commandeffect/gettype/)、[getCommandString](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commandeffect/getcommandstring/)與[getShapeTarget](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commandeffect/getshapetarget/)。將名為`sample.wav`的 WAV 錄音放在工作目錄中。此範例使用[addAudioFrameEmbedded](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addaudioframeembedded/)內嵌錄音，並為音訊框架附加播放指令。

音訊框架同時是效果的目標與指令的目標。這會將播放請求連結到已內嵌的錄音；指令字串本身不會指明要控制哪個媒體物件。效果設定為在投影片放映期間點擊時開始。

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

儲存會將指令寫入`command.pptx`；不會自動播放錄音。播放需要支援此指令與其媒體目標的投影片放映程式。

## **管理行為集合**

[BehaviorCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/)支援[add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/add/)、[insert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/insert/)、[remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/remove/)、[removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/removeat/)。此範例開啟`rotation.pptx`，加入縮放，將其插入至旋轉之前，最後移除旋轉。移除後重新插入相同物件會改變其在集合中的位置，而不會製作副本。

編輯順序將集合從 rotation–scale 變為 scale–rotation，最後僅剩縮放。索引指的是目前的集合，因此在重新排序後，移除使用的是旋轉的最新索引。最終列舉確認將被儲存的行為。

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

輸出為`ScaleEffect`：僅剩縮放。僅靠集合順序本身不會排程行為依序播放。只有在全部取代時才清除集合。

## **設定行為時序**

行為擁有自己的[Timing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/)，獨立於[Effect::getTiming](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/gettiming/)回傳的時序。效果時序排程整個效果；行為時序描述其中的單一操作。

### **設定持續時間、延遲、重複與加速**

開啟`rotation.pptx`，以秒為單位設定持續時間([getDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getduration/))與觸發延遲([getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/gettriggerdelaytime/))，然後透過[setRepeatCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatcount/)設定重複次數。[getAccelerate](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getaccelerate/)與[getDecelerate](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getdecelerate/)為持續時間的分數，總和請勿超過 1。

輸入檔案即前述旋轉範例建立的檔案，第一個行為已知為旋轉。本範例僅變更該行為的時序；其 90 度角度保持不變。將角度與時序分離，使得在不重新建構動畫的情況下調整節奏更為容易。

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

此行為使用兩秒持續時間、半秒延遲，且重複次數為 3。持續時間的首尾各 20% 用於加速與減速。

其他重複政策包括[getRepeatDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatduration/)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatuntilendslide/)、[getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatuntilnextclick/)，請選擇單一政策，而非同時啟用。[getAutoReverse](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getautoreverse/)會在正向播放後倒放動畫。加速與減速僅適用於連續變化，不適用於離散指派或指令。

## **建立移動路徑**

使用[createMotionEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorfactory/createmotioneffect/)建立移動。[getFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioneffect/getfrom/)、[getTo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioneffect/getto/)、[getBy](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioneffect/getby/)描述以百分比為基礎的座標或偏移。若需可編輯路徑，請建立[MotionPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motionpath/)，並以[MotionEffect::setPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioneffect/setpath/)指派。[MotionPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motionpath/)儲存路徑指令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioncommandpathtype/)選擇操作類型：

| 指令 | 點數 | 說明 |
| --- | --- | --- |
| MoveTo | 一 | 設定起始位置。 |
| LineTo | 一 | 沿直線段移動至端點。 |
| CurveTo | 三 | 沿由兩個控制點和端點定義的三次曲線。 |
| CloseLoop | 無 | 返回起始位置。 |
| End | 無 | 結束路徑。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motionpathpointstype/)描述點的編輯特性，如拐角點或平滑點。它不取代指令類型。曲線範例使用曲線點類型，直線段則使用拐角點類型。

路徑座標正規化為投影片尺寸：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正向 Y 向下。絕對指令以路徑座標系統指定位置；相對指令以當前位置的偏移指定。這與[getOrigin](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioneffect/getorigin/)選擇路徑參考框架，以及[getPathEditMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioneffect/getpatheditmode/)控制形狀移動時路徑的行為分開。

### **建立直線路徑**

建立包含起始點、一條直線段與結束指令的移動行為。[MotionPath::add](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motionpath/add/)接受指令類型、其點、點類型與相對座標旗標。

起始指令設定 (0, 0)，直線結束於 (0.25, 0)，使路徑在水平上位移投影片寬度的四分之一。結束指令無座標點。指派路徑後，將移動行為加入效果，即可將此路徑套用到矩形。

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

`motion.pptx` 包含一個移動行為與三個路徑指令。以下的檔案編輯範例皆使用此已知結構。

### **比較絕對座標與相對座標**

以下兩個路徑物件描述相同路線。絕對指令的端點為 (0.3, 0.1)；相對指令則在當前位置 (0.2, 0) 上加上 (0.1, 0.1)。

兩條路徑皆從相同位置開始。對於相對直線，將其 X 與 Y 偏移加至當前位置即可得到端點；對於絕對直線，直接讀取端點。若不將座標轉換而僅切換旗標，將產生不同的路徑。

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

將任一路徑指派給移動行為即可在簡報中使用。最後的布林參數用於為該指令選擇相對座標。

### **以曲線取代直線**

開啟`motion.pptx`，將其直線指令替換為三次曲線。先提供兩個控制點，最後提供端點。

起始位置由前一個指令提供。前兩個點塑造曲線形狀，第三個點為目的地；它們不是三個連續的目的地。同步更新指令類型、點編輯類型與點陣列，可確保段落與新幾何形狀一致。

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

`curve.pptx` 中的路徑仍有三個指令，只是其中的中間指令現在定義為曲線。

## **檢查與編輯已儲存的路徑**

每個[MotionCmdPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioncmdpath/)提供[getPoints](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioncmdpath/getpoints/)、[getCommandType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioncmdpath/getcommandtype/)、[getPointsType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioncmdpath/getpointstype/)、[isRelative](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motioncmdpath/isrelative/)。以下範例使用 `motion.pptx` 中已知的三指令路徑。對於任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數。

### **讀取指令與座標**

在不改變路徑的情況下讀取。結束與關閉迴路指令不需要點，請允許空的點陣列。

輸出會先列出每個數值指令類型與其相對座標旗標，然後列出其點。這讓您在修改路徑前能區分端點與偏移。曲線會列出三個點，而本檔的直線僅列出一個點。

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

此清單包含起始點、絕對直線於 (0.25, 0) 結束，與結束指令。

### **變更端點**

開啟`motion.pptx`，替換直線的點陣列以移動其端點。

在輸入檔案中，索引 0 為起始指令，索引 1 為直線。替換直線的單一點會改變其目的地，而不會改變指令類型、時序或在集合中的位置。因為指令使用絕對座標，新點組指定的是位置而非增加的偏移。

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

`motion-endpoint.pptx` 中的直線結束於 (0.4, 0.1)；原始檔未被修改。

### **取代段落**

使用[insert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motionpath/insert/)與[removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/motionpath/removeat/)取代 `motion.pptx` 中的直線。插入會將舊的直線移至索引 2。

此示例說明取代指令物件，而非編輯其現有座標。插入後，集合暫時包含起始指令、新直線、舊直線與結束指令。移除索引 2 後，舊直線被捨棄，新的路徑保留下來。

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

儲存的路徑仍有三個指令，新直線結束於 (0.2, 0.1)，結束指令仍在最後。

## **修改與驗證現有行為**

當行為的索引未知時，可依類型選取。本範例開啟`rotation.pptx`，找出其[RotationEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/rotationeffect/)，變更角度，並在重新開啟後檢查儲存的值。

類型檢查允許迴圈跳過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，因此比較的是持久化資料，而非仍在記憶體中的值。此範例仍假設已知的效果是主要序列中的第一個；依類型選取行為並不會在任意簡報中自動定位正確的效果。

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

輸出為`Rotation preserved: true`。可將相同的類型檢查模式套用於其他行為。若要完整檢查保留情況，請比較目標形狀、效果、行為類型與順序、時序以及路徑指令。對於浮點數值請使用數值容差。若簡報的動畫佈局未知，請參閱[Read Shape Animations](/slides/zh-hant/php-java/shape-animation/#read-shape-animations)以遍歷主要與互動序列。

## **行為順序、預設與播放**

[BehaviorCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behaviorcollection/)中的順序是效果操作的儲存順序。它並不是播放清單，並不會自動讓每個行為等候前一個完成。時序與封裝的效果決定排程。行為可以重疊，同一屬性的操作可能透過[additive](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behavioradditivetype/)與[accumulation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behavioraccumulatetype/)設定相互作用。不要僅依靠重新排序集合來排程「先移動再旋轉」；請使用明確的時序或如[Shape Animation](/slides/zh-hant/php-java/shape-animation/)所述的分別效果。

效果的[getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/gettype/)與[getSubtype](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getsubtype/)描述其預設。它們不是已編輯行為樹的完整描述。請先選擇預設與子類型，再自訂行為：變更預設會重新建構集合並捨棄自訂操作。例如，將自訂的 Spin 效果改為 Fade 會以設定與濾鏡行為取代其旋轉行為。變更預設或子類型後，請再次檢查集合。清除預設行為也可能移除預設所需的可見性或初始化操作。示例故意使用可見形狀並取代其行為，未重新建構每個預設的實作。

## **格式相容性**

保留的行為樹並不保證在每個檢視器或匯出渲染器中都有相同的播放效果。請分別檢查已儲存的資料與渲染輸出。

| 格式或輸出 | 需要驗證的項目 |
| --- | --- |
| PPTX | 作為本範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放。 |
| PPT | 舊版二進位表示法可能與 PPTX 不同。請執行另一次儲存-重新開啟循環與播放測試；不要僅以 PPTX 成功推斷支援所有自訂組合。 |
| PDF、PNG、JPEG 及其他靜態投影片影像 | 僅包含靜態投影片表示，未包含可播放的行為時間軸或保證的最終動畫畫面。 |
| [HTML5](/slides/zh-hant/php-java/export-to-html5/) | 在匯出選項啟用形狀動畫時，可播放支援的動畫。請在瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/) | 儲存已渲染的畫格，未包含可編輯的行為或點擊觸發的互動。請檢查實際渲染的移動。 |
| [Video](/slides/zh-hant/php-java/convert-powerpoint-to-video/) | 渲染動畫畫格並編碼為影片。支援僅限於渲染器的[支援動畫與效果](/slides/zh-hant/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)；指令與互動事件不會變成可編輯的時間軸。 |

## **常見問題**

**為什麼我的效果在還未加入任何行為前就已包含行為？**

建立預先定義的效果時可能會同時建立其底層操作。請先檢查它們，再決定是要擴充預設還是取代其行為。

**將行為移至開頭就會先播放嗎？**

不一定。集合順序無法替代時序。請檢查延遲、持續時間以及同屬性操作之間的相互作用。

**為什麼結束指令沒有點？**

結束指令標示路徑結束，無需座標。檢查從檔案讀取的路徑時，請留意可能為空的點陣列。

**成功的來回儲存是否足以確認播放？**

否。重新開啟僅確認您檢查的屬性是否被保留。仍需在投影片放映程式或動畫匯出中分別測試，以確認其視覺行為。