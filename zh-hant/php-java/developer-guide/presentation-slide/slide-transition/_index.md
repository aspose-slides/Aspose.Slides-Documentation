---
title: 使用 PHP 管理簡報中的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 80
url: /zh-hant/php-java/slide-transition/
keywords:
- 投影片轉場
- 新增投影片轉場
- 套用投影片轉場
- 進階投影片轉場
- Morph 轉場
- 轉場類型
- 轉場效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 套用投影片轉場、設定自動投影片前進，並自訂 Morph 及其他轉場效果。"
---
## **概觀**

投影片轉場控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for PHP via Java，您可以為每張投影片選擇轉場效果、設定以滑鼠點擊或計時器前進，以及調整特定於效果的選項。本篇文章使用 PHP 範例說明如何套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例同時展示如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

要套用轉場，先以 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 取得投影片的轉場設定。使用來自 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列舉的值呼叫 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)，最後儲存簡報。

以下範例將 Circle 轉場套用到第一張投影片，將 Comb 轉場套用到第二張投影片。請使用至少有兩張投影片的 `input.pptx` 檔案。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Wheel 轉場**

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) 方法控制有多少個徑向區段會顯示目標投影片。使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 從 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中選取 Wheel，然後呼叫 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 以存取 [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 設定。

此範例建立兩組相同的投影片。每組以一張黑色投影片開始，最後以一張被金色矩形覆蓋的投影片結束。第 2 張投影片使用 1 根輻條，第 4 張投影片使用 8 根。兩個轉場皆使用相同的慢速，透過 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) 設定，並以 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 設定為 8,000 毫秒的明確持續時間。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中開啟已儲存的簡報並啟動投影片放映。從投影片 1 前進到投影片 2 時，會看到單一順時針掃過。再從投影片 3 前進到投影片 4，則會同時看到八個徑向區段同時揭露相同的矩形。

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間，以及是否以滑鼠點擊前進投影片放映。以下方法控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允許觀眾透過滑鼠點擊前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自動前進前的延遲時間（以毫秒為單位）。

同時啟用點擊與計時前進，讓觀眾可以點擊前進或等待計時器。若只想使用計時器，請對 [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 傳入 `false`。延遲時間控制投影片放映何時前進，並不會設定視覺轉場效果的持續時間。

此範例將不同的效果指派給前三張投影片，並分別在 3、5、7 秒後自動前進。這些投影片同樣可以透過滑鼠點擊前進。請使用至少有三張投影片的 `input.pptx` 檔案。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

若要檢查是否已啟用計時前進，請呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。僅儲存的延遲時間並不表示計時器已啟動。

下一個範例開啟上述儲存的檔案，報告每個已啟用的計時器，並在延遲超過兩秒的投影片上停用自動前進，改為啟用滑鼠點擊，最後儲存更新後的設定。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **精確控制轉場時間**

使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 可在毫秒為單位指定轉場效果的精確長度。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 方法會透過 [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) 透露這些設定：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | 設定轉場效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 設定投影片自動前進前的延遲時間（毫秒）。將 `true` 傳入 [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以啟用此計時器。 |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | 從 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 中選取預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時會使用此設定。 |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 僅控制轉場效果，並不決定投影片的可見時長。請自行設定自動前進的延遲時間。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型與 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 的值自行決定效果長度。

<!-- visual-explanation:slide-transition:start -->
![分隔條顯示 750 毫秒的轉場持續時間與 5,000 毫秒的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)
*此範例為每張投影片設定 750 毫秒的淡入淡出轉場，同時啟用 5,000 毫秒的自動前進。轉場持續時間控制視覺效果；前進時間控制何時離開投影片。這些條狀圖為示意設定，並非測量後的合併時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **為每張投影片套用相同持續時間**

為了保持節奏一致，請將相同的效果與精確持續時間套用到每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中選取 Fade，並將每個轉場的持續時間設為 750 毫秒。它同時在 5,000 毫秒後啟用自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // 配置自動前進，與效果持續時間無關。
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **為單張投影片設定不同持續時間**

不同的投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的轉場，為章節導入投影片使用較長的轉場。此範例將第一張投影片的持續時間設為 500 毫秒，第二張投影片設為 1,200 毫秒。請使用至少有兩張投影片的 `input.pptx` 檔案。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **與動畫輸出協調轉場**

在製作 [animated GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/php-java/export-to-html5/) 或 [video](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以符合預期節奏。例如，在場景之間使用 600 毫秒的淡入淡出，並分別為每張投影片設定自動前進延遲，以留出旁白或內容的時間。

對於 GIF 與影片，請將輸出幀速率與效果持續時間對齊：600 毫秒相當於 30 幀每秒時的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的轉場持續時間**

在修改轉場之前呼叫 [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) 以判斷是否已儲存明確值。`-1` 表示未設定明確持續時間；非負值則表示以毫秒為單位的已儲存持續時間。未設定的值並不是計算出的播放時長：Aspose.Slides 會根據轉場類型與 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 的值來決定該時長。設定轉場類型可能會初始化持續時間，因此請先檢查原始設定。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph 轉場**

Morph 轉場在連續投影片之間為物件變化製作動畫。要建立簡單的 Morph 效果，只需複製投影片、在副本上移動或調整物件大小，然後將 Morph 轉場套用到第二張投影片，即可使相對應的物件在原始與修改狀態之間動畫化。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在副本上變更矩形的位置與大小。然後從 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列舉中為第二張投影片選取 Morph。於支援 Morph 的簡報檢視器中開啟已儲存的檔案，即可在投影片放映時看到效果。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph 轉場類型**

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配並動畫化內容：

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) 將每個形狀視為整體物件。
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) 盡可能以單字為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元為單位動畫化文字。

使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 在存取 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 之前選取 Morph。取得的值會提供一個 [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) 物件，透過其 [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為以單字為基礎的 Morph 動畫。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **設定轉場效果**

部分轉場提供額外選項，例如方向或是否從黑屏開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 所選的轉場。先設定類型，然後透過 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 取得相應的轉場物件並設定選項。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 轉場。它透過 [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) 呼叫 [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack)，使轉場從黑屏開始。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **常見問與答**

**我可以控制投影片轉場的播放速度嗎？**

可以。當需要以毫秒為單位的精確效果持續時間時，請使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)。若預先定義的 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）已足夠且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)。這些設定會獨立於自動前進的延遲時間。

**我可以為轉場附加音訊並使其循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 中的 `StartSound` 傳入 [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)，並以 `true` 啟用 [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop)。音訊會持續循環，直到投影片放映中的下一個音效事件。

**將相同轉場套用到每張投影片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合，對每張投影片的轉場呼叫 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 並傳入相同的值。於同一迴圈中設定所有計時與效果選項，以確保各投影片行為一致。

**我如何檢查投影片目前設定了哪種轉場？**

對投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 結果呼叫 [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType)。它會回傳來自 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列舉的值；`None` 表示未套用任何轉場效果。