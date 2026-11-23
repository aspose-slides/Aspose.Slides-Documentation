---
title: 使用 PHP 管理簡報中的幻燈片過渡
linktitle: 幻燈片過渡
type: docs
weight: 80
url: /zh-hant/php-java/slide-transition/
keywords:
- 幻燈片過渡
- 新增幻燈片過渡
- 套用幻燈片過渡
- 進階幻燈片過渡
- Morph 過渡
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "套用幻燈片過渡、設定自動幻燈片前進，並使用 Aspose.Slides for PHP via Java 自訂 Morph 及其他過渡效果。"
---
## **概觀**

幻燈片過渡控制幻燈片在投影片放映期間的顯示方式。使用 Aspose.Slides for PHP via Java，您可以為每張幻燈片選擇過渡效果，設定透過滑鼠點擊或計時器的前進方式，並調整特定效果的選項。本文使用 PHP 範例套用過渡、設定精確的過渡持續時間、管理幻燈片計時，並在兩張幻燈片之間建立 Morph 過渡。範例還示範如何將設定儲存為 PPTX 檔案。

## **新增幻燈片過渡**

要套用過渡，使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 取得幻燈片的過渡設定。使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 並傳入來自 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列舉的值，然後儲存簡報。

以下範例將 Circle 過渡套用於第一張幻燈片，將 Comb 過渡套用於第二張。使用至少包含兩張幻燈片的 `input.pptx` 檔案。

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

## **輪形過渡**

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) 方法控制有多少徑向區段揭示目標幻燈片。使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 從 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中選擇 Wheel，然後呼叫 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 取得 [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 設定。

範例會建立兩組相同的幻燈片。每組以黑色幻燈片開始，以金色矩形覆蓋的幻燈片結束。第 2 張幻燈片使用一個扇形，第 4 張使用八個扇形。兩個過渡均使用相同的慢速，透過 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) 設定，並以 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 明確設定為 8,000 毫秒。

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

在 PowerPoint 中開啟已儲存的簡報並開始投影片放映。從第 1 張前進到第 2 張時會看到單一順時針掃描。再從第 3 張前進到第 4 張時會看到八個徑向區段同時揭示相同的矩形。

## **淡入黑色的 Reveal 過渡**

將目標幻燈片的過渡類型設定為 Reveal，然後在其 [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) 設定上呼叫 [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack)。範例建立一張青綠色來源幻燈片與一張珊瑚色目標幻燈片，然後將兩張幻燈片複製。每組使用相同的兩秒 Reveal 過渡。只有第二組會在淡入時經過黑色。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中開啟已儲存的簡報並開始投影片放映。從第 1 張前進到第 2 張時會看到青綠色直接淡入珊瑚色。再從第 3 張前進到第 4 張時，畫面會短暫變暗至近黑色，然後顯示珊瑚色幻燈片。兩張幻燈片都保留原本的背景顏色。

下方列出每半秒的畫面截圖。比較每列的中間畫面即可看出差異。

![PowerPoint 播放顯示淡入黑色未啟用（上）與啟用（下）。僅下列會通過近乎黑色。](reveal-through-black.png)

## **新增進階幻燈片過渡**

您可以設定幻燈片在螢幕上停留的時間，以及是否以滑鼠點擊前進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允許檢視者透過點擊滑鼠前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，讓檢視者可以點擊前進或等待計時器。若僅使用計時器，請傳入 `false` 給 [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)。延遲決定投影片何時自動前進；它不會設定視覺過渡效果的持續時間。

此範例為前三張幻燈片分別指派不同效果，並分別在 3、5、7 秒後自動前進。滑鼠點擊亦可前進這些幻燈片。使用至少包含三張幻燈片的 `input.pptx` 檔案。

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

要檢查是否已啟用計時前進，請呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。僅有儲存的延遲並不表示計時器已啟動。

下一個範例開啟上述儲存的檔案，回報每個已啟用的計時器，並對延遲超過兩秒的幻燈片停用自動前進。對這些幻燈片啟用滑鼠點擊，然後儲存更新後的設定。

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

## **精確控制過渡計時**

使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 以毫秒為單位指定過渡效果的確切長度。幻燈片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 方法會透過 [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) 透露這些設定：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | 設定過渡效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 設定幻燈片自動前進前的延遲（毫秒）。將 `true` 傳入 [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以啟用此計時器。 |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | 從 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 中選擇預先定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時使用此設定。 |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 僅控制過渡效果；它不決定幻燈片保持可見的時間。請分別設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型和 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 值推算效果持續時間。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750‑ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **將相同持續時間套用至每張幻燈片**

為了保持節奏一致，為每張幻燈片套用相同的效果與精確持續時間。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中選擇 Fade，並將每個過渡的持續時間設定為 750 毫秒。它另行啟用在 5,000 毫秒後的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

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

        // 設定自動前進，與效果持續時間互不影響。
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **為個別幻燈片設定不同持續時間**

不同幻燈片可以使用不同的效果持續時間。例如，為標題幻燈片使用較短的過渡，為章節介紹使用較長的過渡。此範例為第一張幻燈片設定 500 毫秒，為第二張設定 1,200 毫秒。使用至少包含兩張幻燈片的 `input.pptx` 檔案。

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

### **將過渡與動畫輸出協同**

在製作 [animated GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/php-java/export-to-html5/) 或 [video](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以符合預期節奏。例如，在場景之間使用 600 毫秒的淡入，並分別調整每張幻燈片的前進延遲，以留出旁白或內容的時間。

對於 GIF 和影片，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 fps 下的 18 幀。於 HTML5 匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有過渡持續時間**

在修改過渡之前呼叫 [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) 以判斷是否已儲存明確值。`-1` 表示未設定明確持續時間；非負值則表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型和 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 值推算該持續時間。設定過渡類型可能會初始化持續時間，請先檢查原始設定。

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

Morph 轉場在連續幻燈片之間動畫化物件的變化。要建立簡單的 Morph 效果，請複製幻燈片、在複製的幻燈片上移動或調整物件大小，並將 Morph 轉場套用於第二張幻燈片。這會讓相對應的物件在原始狀態與修改後狀態之間動畫化。

以下範例建立一張包含文字矩形的幻燈片，複製該幻燈片，並在複製稿上變更矩形的位置與大小。接著從 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列舉中選擇 Morph 作為第二張幻燈片的過渡類型。於支援 Morph 的簡報檢視器中開啟已儲存的檔案，即可在投影片放映時看到效果。

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

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) 將每個形狀視為完整物件。
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) 盡可能以單字為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元為單位動畫化文字。

使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 選取 Morph，然後存取 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)。取得的值會回傳一個 [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) 物件，您可透過其 [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張幻燈片設定為以字詞為單位的 Morph 動畫。

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

## **設定過渡效果**

某些過渡會公開額外選項，例如方向或是否從黑屏開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 所選的過渡。先設定類型，然後使用從 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 取得的適當過渡物件。

以下範例將 Cut 轉場套用於 `input.pptx` 的第一張幻燈片。它透過 [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) 呼叫 [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack)，使過渡從黑色畫面開始。

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

## **FAQ**

**我可以控制幻燈片過渡的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請優先使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)。若預先定義的 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)（Slow、Medium 或 Fast）足以滿足需求，且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)。這些設定僅控制過渡效果，與自動前進的延遲無關。

**我可以在過渡中加入音訊並讓它循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 中的 `StartSound` 傳入 [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)，並以 `true` 啟用 [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop)。音訊會持續循環，直到投影片放映中的下一個音效事件。

**將相同過渡套用到每張幻燈片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合，對每張幻燈片的過渡呼叫 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 並傳入相同的值。於同一迴圈中設定任何計時與效果選項，以確保所有幻燈片的行為一致。

**我如何檢查目前在某張幻燈片上設定的過渡是什麼？**

對該幻燈片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 結果呼叫 [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType)。它會回傳 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列舉中的值；若為 None，表示未套用任何過渡效果。