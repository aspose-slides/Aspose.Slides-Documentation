---
title: 在簡報中使用 PHP 套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/php-java/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中建立與自訂形狀動畫，讓您的簡報脫穎而出！"
---
## **簡介**

動畫是可以套用到文字、圖像、形狀或[圖表](https://docs.aspose.com/slides/zh-hant/php-java/animated-charts/)的視覺效果。它們為簡報或其組成部分賦予活力。

## **為何在簡報中使用動畫？**

使用動畫，您可以  

* 控制資訊的流向  
* 強調重要要點  
* 提升觀眾的興趣或參與度  
* 讓內容更易閱讀、同化或處理  
* 吸引讀者或觀眾注意簡報中的重要部份  

PowerPoint 提供了大量選項與工具，用於 **進場**、**退場**、**強調**與**移動路徑**類別的動畫與動畫效果。

## **Aspose.Slides 中的動畫**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空間下提供您處理動畫所需的類別與型別，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttype) 列舉中提供超過 **150 個動畫效果**。這些效果本質上與 PowerPoint 中使用的效果相同（或等效）。

## **將動畫套用至文字方塊**

Aspose.Slides for PHP via Java 允許您將動畫套用至形狀中的文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。  
4. 將文字加入 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#getTextFrame)。  
5. 取得主要的效果序列。  
6. 將動畫效果加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。  
7. 使用 `TextAnimation.setBuildType` 方法，並使用 `BuildType` 列舉中的值。  
8. 將簡報寫入磁碟，儲存為 PPTX 檔案。  

以下 PHP 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設為 *By 1st Level Paragraphs* 值：

```php
  # 建立一個代表簡報檔案的 Presentation 類別實例。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 新增帶文字的 AutoShape
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # 取得投影片的主要序列。
    $sequence = $sld->getTimeline()->getMainSequence();
    # 為形狀新增 Fade 動畫效果
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # 依第一層段落為形狀文字加入動畫
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # 將 PPTX 檔案儲存至磁碟
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}}  
除了將動畫套用至文字之外，您也可以將動畫套用至單一[段落](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)。請參閱[**動畫文字**](/slides/zh-hant/php-java/animated-text/)。  
{{% /alert %}} 

## **將動畫套用至圖片框架**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe)。  
4. 取得主要的效果序列。  
5. 將動畫效果加入 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe)。  
6. 將簡報寫入磁碟，儲存為 PPTX 檔案。  

以下 PHP 程式碼示範如何將 `Fly` 效果套用至圖片框架：

```php
  # 建立代表簡報檔案的 Presentation 類別實例。
  $pres = new Presentation();
  try {
    # 載入要加入簡報影像集合的圖像
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 在投影片上新增圖片框架
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # 取得投影片的主要序列。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 為圖片框架新增 From Left 飛入動畫效果
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # 將 PPTX 檔案儲存至磁碟
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將動畫套用至形狀**

1. 建立 the [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。  
4. 加入一個斜角 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)（當此物件被點擊時，動畫會播放）。  
5. 在斜角形狀上建立效果序列。  
6. 建立自訂的 `UserPath`。  
7. 新增移動至 `UserPath` 的指令。  
8. 將簡報寫入磁碟，儲存為 PPTX 檔案。  

以下 PHP 程式碼示範如何將 `PathFootball`（path football）效果套用至形狀：

```php
  # 建立代表 PPTX 檔案的 Presentation 類別實例。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 從頭建立現有形狀的 PathFootball 效果。
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # 加入 PathFootBall 動畫效果
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 建立某種「按鈕」。
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # 為此按鈕建立效果序列。
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # 建立自訂使用者路徑。物件僅會在按鈕點擊後移動。
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 加入移動指令，因為建立的路徑是空的。
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **取得套用於形狀的動畫效果**

以下範例說明如何使用來自 [Sequence](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/) 類別的 `getEffectsByShape` 方法，取得套用於形狀的所有動畫效果。

**範例 1：取得普通投影片上形狀的動畫效果**

先前您已了解如何在 PowerPoint 簡報的形狀上加入動畫效果。以下範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一張普通投影片上第一個形狀所套用的效果。

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # 取得投影片的主要動畫序列。
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # 取得第一張投影片上的第一個形狀。
    $shape = $firstSlide->getShapes()->get_Item(0);

    # 取得套用於該形狀的動畫效果。
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

**範例 2：取得所有動畫效果，包含從占位區繼承的效果**

如果普通投影片上的形狀具有佈局投影片和/或母片投影片上的占位區，且這些占位區已加入動畫效果，則在投影片放映時，形狀的所有效果都會被播放，包含從占位區繼承的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中有一張投影片僅包含一個頁腳形狀，文字為「Made with Aspose.Slides」，且已套用 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假設在 **layout** 投影片的頁腳占位區套用了 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最後，**Fly In** 效果套用於 **master** 投影片的頁腳占位區。

![Master shape animation effect](master-shape-animation.png)

以下範例程式碼示範如何使用 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別的 `getBasePlaceholder` 方法，存取形狀的占位區，並取得套用於頁腳形狀的動畫效果，包含來自佈局與母片投影片占位區的繼承效果。

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// 取得普通投影片上形狀的動畫效果。
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// 取得版面投影片上占位區的動畫效果。
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// 取得母片投影片上占位區的動畫效果。
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
Type: 47, subtype: 2              // 飛入, 底部
Type: 134, subtype: 45            // 分割, 垂直進入
Type: 126, subtype: 22            // 隨機條, 水平
```

## **變更動畫效果時間設定方法**

Aspose.Slides for PHP via Java 允許您變更動畫效果的 Timing 屬性。

這是 Microsoft PowerPoint 中的 Animation Timing 面板：

![example1_image](shape-animation.png)

以下是 PowerPoint Timing 與 [Effect Timing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#getTiming) 屬性之對應關係：

- PowerPoint Timing **Start** 下拉選單對應至 [Timing::getTriggerType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/#getTriggerType) 方法。  
- PowerPoint Timing **Duration** 對應至 [Timing::getDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/#getDuration) 方法。動畫的持續時間（以秒為單位）為動畫完成一個週期所需的總時間。  
- PowerPoint Timing **Delay** 對應至 [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/#getTriggerDelayTime) 方法。  

以下說明如何變更 Effect Timing 屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。  
2. 使用 [Effect::getTiming](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#getTiming) 方法設定您需要的新值。  
3. 儲存已修改的 PPTX 檔案。  

以下 PHP 程式碼示範此操作：

```php
  # 建立代表簡報檔案的 Presentation 類別實例。
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 取得投影片的主要序列。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 取得主要序列的第一個效果。
    $effect = $sequence->get_Item(0);
    # 將效果的 TriggerType 更改為點擊時開始
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # 更改效果的 Duration
    $effect->getTiming()->setDuration(3.0);
    # 更改效果的 TriggerDelayTime
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # 將 PPTX 檔案儲存至磁碟
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **動畫效果音效**

Aspose.Slides 提供以下方法，讓您在動畫效果中使用音效：

- [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **新增動畫效果音效**

以下 PHP 程式碼示範如何新增動畫效果音效，並在下一個效果開始時停止它：

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 將音訊加入簡報的音訊集合
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
    # 取得投影片的主要序列。
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # 取得主要序列的第一個效果
    $firstEffect = $sequence->get_Item(0);
    # 檢查效果是否為「無聲音」
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # 為第一個效果加入音效
      $firstEffect->setSound($effectSound);
    }
    # 取得投影片的第一個互動序列。
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # 設定效果的「停止先前音效」旗標
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **擷取動畫效果音效**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 取得主要的效果序列。  
4. 擷取每個動畫效果中嵌入的 [setSound(IAudio value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。  

以下 PHP 程式碼示範如何擷取動畫效果中嵌入的音效：

```php
  # 建立代表簡報檔案的 Presentation 類別實例。
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 取得投影片的主要序列。
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # 擷取效果音訊的位元組陣列
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **動畫結束後**

Aspose.Slides for PHP via Java 允許您變更動畫效果的 After animation 屬性。

這是 Microsoft PowerPoint 中的 Animation Effect 面板與延伸功能表：

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉選單對應以下方法：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setAfterAnimationType) 方法，用於描述 After animation 類型：  
  * PowerPoint **More Colors** 對應至 [AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/#Color) 型別；  
  * PowerPoint **Don't Dim** 項目對應至 [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/#DoNotDim) 型別（預設的 after animation 類型）；  
  * PowerPoint **Hide After Animation** 項目對應至 [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 型別；  
  * PowerPoint **Hide on Next Mouse Click** 項目對應至 [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 型別；  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setAfterAnimationColor) 方法，用於定義 after animation 的顏色格式。此方法與 [AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/#Color) 類型一起使用。如果您將類型變更為其他，after animation 的顏色將被清除。  

以下 PHP 程式碼示範如何變更 after animation 效果：

```php
  # 建立代表簡報檔案的 Presentation 類別實例
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 取得主要序列的第一個效果
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 將 after animation 類型變更為 Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # 設定 after animation 暗淡顏色
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **動畫文字**

Aspose.Slides 提供以下方法，讓您在動畫效果的 *Animate text* 區塊中工作：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setAnimateTextType) 方法，描述效果的 animate text 類型。形狀文字可以被動畫化：  
  - 一次全部 ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/animatetexttype/#AllAtOnce) 型別)  
  - 逐字 ([AnimateTextType::ByWord](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/animatetexttype/#ByWord) 型別)  
  - 逐字母 ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/animatetexttype/#ByLetter) 型別)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setDelayBetweenTextParts) 設定動畫文字部份（字或字母）之間的延遲。正值表示效果持續時間的百分比，負值表示以秒為單位的延遲。  

以下說明如何變更 Effect Animate text 屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。  
2. 使用 [setBuildType(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textanimation/#setBuildType) 方法與 [BuildType::AsOneObject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/buildtype/#AsOneObject) 值，關閉 *By Paragraphs* 動畫模式。  
3. 使用 [setAnimateTextType(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setAnimateTextType) 與 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/#setDelayBetweenTextParts) 方法設定新值。  
4. 儲存已修改的 PPTX 檔案。  

以下 PHP 程式碼示範此操作：

```php
  # 建立代表簡報檔案的 Presentation 類別實例。
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 取得主要序列的第一個效果
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 將效果的文字動畫類型變更為「As One Object」
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # 將效果的動畫文字類型變更為「By word」
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 設定單字之間的延遲為效果持續時間的 20%
    $firstEffect->setDelayBetweenTextParts(20.0);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**如何確保在將簡報發佈至網路時保留動畫？**

[Export to HTML5](/slides/zh-hant/php-java/export-to-html5/) 並啟用負責 [shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimateshapes/) 與 [transition](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimatetransitions/) 動畫的 [options](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/)。純 HTML 不會播放投影片動畫，HTML5 則會。

**變更形狀的 Z 軸順序（圖層順序）如何影響動畫？**

動畫與繪製順序是獨立的：效果控制出現/消失的時間與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getzorderposition/) 決定何者覆蓋何者。最終可見結果由兩者組合決定。（這是一般 PowerPoint 的行為；Aspose.Slides 的效果與形狀模型遵循相同邏輯。）

**在將動畫轉換為影片時，某些效果是否有限制？**

一般而言，[動畫受到支援](/slides/zh-hant/php-java/convert-powerpoint-to-video/)，但在少數情況或特定效果可能會有不同的呈現方式。建議使用您所使用的效果與相應的函式庫版本進行測試。