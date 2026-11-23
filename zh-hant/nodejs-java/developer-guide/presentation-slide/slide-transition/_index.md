---
title: 使用 JavaScript 管理簡報中的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 80
url: /zh-hant/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "套用投影片轉場、設定自動投影片前進，並使用 Aspose.Slides for Node.js via Java 自訂 Morph 以及其他轉場效果。"
---
## **概觀**

投影片轉場控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Node.js via Java，您可以為每張投影片選擇轉場效果、設定以滑鼠點擊或計時器前進，並調整針對特定效果的選項。本文使用 JavaScript 範例說明如何套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

要套用轉場，請使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 取得投影片的轉場設定。使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 並搭配 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 列舉中的值，之後儲存簡報即可。

以下範例將 Circle 轉場套用於第一張投影片，將 Comb 轉場套用於第二張投影片。請使用至少兩張投影片的 `input.pptx` 檔案。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Wheel 轉場**

[WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) 的 [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) 方法控制揭露目標投影片的徑向扇區數量。在使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 從 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 設為 Wheel 之後，先取得 [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) 再呼叫 [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)。

此範例建立兩組相同的投影片：一張黑色投影片，接著是一張有金色矩形的投影片。目的投影片的扇區計數分別為 1 與 8，速度皆透過 [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) 設定，並以 [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 明確設定 8,000 毫秒的持續時間，以便容易觀察差異。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從第 1 張投影片切換到第 2 張，然後從第 3 張切換到第 4 張。在 PowerPoint 播放時，驗證過的 1 扇區會以順時針掃描一次顯示投影片；驗證過的 8 扇區則同時以八個徑向扇區顯示投影片。目的內容與轉場時機相同，差異僅在於揭露扇區的數量。

## **使用 Reveal 轉場的暗淡切換**

將目的投影片的轉場類型設為 Reveal，然後對其 [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/) 設定呼叫 [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack)。此範例建立一張青綠色來源投影片與一張珊瑚色目的投影片，然後將兩者皆複製。每對投影片使用相同的兩秒 Reveal 轉場，僅第二對會經過黑暗淡入。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中開啟已儲存的簡報並啟動投影片放映。從第 1 張投影片切換到第 2 張，您會看到青綠直接淡入珊瑚。再切換第 3 張到第 4 張，畫面會短暫變暗至接近黑色，然後珊瑚投影片出現。兩張投影片皆保留其原始背景顏色。

下表顯示 PowerPoint 每半秒截取的畫面。比較每列的中間畫面即可看到效果。

![PowerPoint 播放時，關閉（上）與啟用（下）暗淡切換的差異。僅底列會通過近黑色。](reveal-through-black.png)

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間，以及是否以滑鼠點擊前進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允許觀眾點擊滑鼠前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自動前進前的延遲（毫秒）。

同時啟用點擊與計時前進，讓觀眾可點擊前進或等待計時器。若僅使用計時器，請將 `false` 傳遞給 [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)。延遲決定投影片何時前進；它不會設定視覺轉場效果的持續時間。

此範例為前面三張投影片指派不同的效果，並分別在 3、5、7 秒後自動前進。滑鼠點擊亦可前進這些投影片。請使用至少三張投影片的 `input.pptx` 檔案。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

若要檢查是否已啟用計時前進，請呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。僅有存儲的延遲並不表示計時器已啟動。

下一個範例開啟上述儲存的檔案，列出每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **精確控制轉場計時**

使用 [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 可指定轉場效果的精確長度（毫秒）。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 方法會透過 [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) 暴露這些設定：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | 設定轉場效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 設定投影片自動前進前的延遲（毫秒）。若要啟動此計時器，請將 `true` 傳遞給 [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter)。 |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | 從 [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) 中選取預先定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時會使用此設定。 |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 只控制轉場效果；它不決定投影片的可視時間。請另行設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型與 [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) 的值來判斷效果長度。

<!-- visual-explanation:slide-transition:start -->
[![分隔條顯示 750 毫秒的轉場持續時間與 5,000 毫秒的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*此範例為每張投影片設定 750 毫秒淡入轉場，並分別在 5,000 毫秒後啟用自動前進。轉場持續時間控制效果；前進時間控制何時離開投影片。這些條條僅為示意設定，非實測的合併時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **將相同持續時間套用至每張投影片**

為了保持節奏一致，將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 中選取 Fade，並將每個轉場的持續時間設為 750 毫秒。接著分別在 5,000 毫秒後啟用自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // 獨立於效果持續時間設定自動前進。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **為單一投影片設定不同持續時間**

不同的投影片可以使用不同的效果持續時間。例如，對標題投影片使用較短的轉場，對章節引言投影片使用較長的轉場。此範例將第一張投影片的持續時間設定為 500 毫秒，第二張投影片設定為 1,200 毫秒。請使用至少兩張投影片的 `input.pptx` 檔案。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **將轉場與動畫輸出同步**

在製作 [animated GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/)、[HTML5 簡報](/slides/zh-hant/nodejs-java/export-to-html5/) 或 [影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以符合預期的節奏。例如，在場景之間使用 600 毫秒的淡入，並分別調整每張投影片的前進延遲，以容納旁白或內容的時間。

對 GIF 與影片而言，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 fps 下的 18 幀。對於 HTML5，請在匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步性。

### **讀取已存在的轉場持續時間**

在修改轉場之前呼叫 [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) 以判斷是否已儲存明確的值。`-1` 表示未設定明確持續時間；非負值則表示以毫秒為單位的儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型與 [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) 的值來推算。設定轉場類型可能會初始化持續時間，因此請先檢查原始設定。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph 轉場**

Morph 轉場會在連續投影片之間對物件的變化進行動畫化。要建立簡單的 Morph 效果，只需複製投影片、在複製版上移動或調整物件大小，並將 Morph 轉場套用於第二張投影片。如此即可讓相對應的物件在原始與修改狀態之間動畫化。

以下範例建立一張含文字矩形的投影片，複製該投影片，並在複製版上變更矩形的位置與大小。然後從 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 列舉中選取 Morph，作為第二張投影片的轉場類型。於支援 Morph 的簡報檢視器中開啟儲存的檔案，即可在投影片放映時看到效果。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 轉場類型**

[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配並動畫化內容：

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) 將每個圖形視為完整的物件。
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) 盡可能以詞彙為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元為單位動畫化文字。

使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 於取得 [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) 前選取 Morph。取得的值會回傳一個 [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) 物件，可透過其 [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為以詞為單位的 Morph 動畫。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **設定轉場效果**

某些轉場提供額外選項，例如方向或是否從黑色螢幕開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 設定的轉場。請先設定類型，之後再從 [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) 取得對應的轉場物件。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 轉場。透過 [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) 呼叫 [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack)，使轉場從黑色螢幕開始。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **常見問題集**

**我可以控制投影片轉場的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請優先使用 [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration)。若預先定義的 [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)（Slow、Medium 或 Fast）已足夠，且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed)。這些設定會獨立於自動前進的延遲來控制轉場效果。

**我可以將音訊附加到轉場並讓它循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) 中的 StartSound 傳遞給 [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode)，並以 `true` 呼叫 [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop)。音訊會持續循環，直到投影片放映中的下一個音效事件。

**將相同轉場套用到每張投影片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) 集合，對每張投影片的轉場呼叫 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType)，使用相同的值。於同一迴圈中設定任何計時與效果選項，即可確保所有投影片的行為保持一致。

**我如何檢查投影片目前設定了哪種轉場？**

對投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 結果呼叫 [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType)。它會回傳 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 列舉中的一個值；None 表示未套用任何轉場效果。