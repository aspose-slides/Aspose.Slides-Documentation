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
description: "使用 Aspose.Slides for Node.js via Java 套用投影片轉場、設定自動投影片前進，並自訂 Morph 及其他轉場效果。"
---
## **概述**

投影片轉場控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Node.js via Java，您可以為每張投影片選擇轉場效果、設定滑鼠點擊或計時器的前進方式，並調整特定效果的選項。本文使用 JavaScript 範例套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例還示範如何將設定保存為 PPTX 檔案。

## **新增投影片轉場**

要套用轉場，先使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 取得投影片的轉場設定。使用來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitiontype/) 列舉的值呼叫 [setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setType)，之後儲存簡報。

以下範例將 Circle 轉場套用於第一張投影片，Comb 轉場套用於第二張投影片。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間，以及是否透過滑鼠點擊前進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允許觀眾透過點擊滑鼠前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，讓觀眾可以點擊或等待計時器前進。若僅使用計時器，請將 `false` 傳給 [setAdvanceOnClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)。延遲時間決定投影片何時前進；它不會設定視覺轉場效果的持續時間。

此範例將不同效果分別套用至前三張投影片，並分別在 3、5、7 秒後自動前進。滑鼠點擊同樣可以前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，請呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。僅有存儲的延遲並不代表計時器已啟動。

下一個範例會開啟上述儲存的檔案，報告每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

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

## **精準控制轉場時機**

使用 [setDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 以毫秒為單位指定轉場效果的確切長度。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 方法透過 [SlideShowTransition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/) 顯示這些設定：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | 設定轉場效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 設定投影片自動前進前的延遲時間（毫秒）。若要啟用此計時器，請將 `true` 傳給 [setAdvanceAfter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter)。 |
| [setSpeed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | 從 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionspeed/)（慢速、 中速、 快速）選擇預先定義的速度類別。當未指定確切持續時間時使用此設定。 |

[setDuration] 僅控制轉場效果本身；它不會決定投影片的顯示時間。請另行設定自動前進的延遲時間。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型和 [getSpeed] 的值來計算效果持續時間。

### **將相同持續時間套用至每張投影片**

為了保持節奏一致，將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitiontype/) 中選取 Fade，並將每個轉場的持續時間設為 750 毫秒。另行啟用在 5,000 毫秒後自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // 設定自動前進，與效果持續時間無關。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **為個別投影片設定不同持續時間**

不同投影片可以使用不同的效果持續時間。例如，標題投影片使用較短的轉場，章節導入投影片使用較長的轉場。此範例將第一張投影片的持續時間設為 500 毫秒，第二張投影片設為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

### **協調動畫輸出與轉場**

在準備 [animated GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/nodejs-java/export-to-html5/) 或 [video](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以匹配預期的節奏。例如，在場景之間使用 600 毫秒的淡出，並分別調整每張投影片的前進延遲，以允許旁白或內容的時間。

對於 GIF 與影片，請將輸出影格速率與效果持續時間協調：600 毫秒相當於 30 fps 時的 18 幀。HTML5 中，請在匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的轉場持續時間**

在修改轉場之前呼叫 [getDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#getDuration) 以判斷是否已儲存明確的值。`-1` 代表未設定明確持續時間；非負值表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型和 [getSpeed] 的值來決定該持續時間。設定轉場類型可能會初始化持續時間，因此請先檢查原始設定。

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

Morph 轉場會在連續投影片之間動畫化物件的變化。要建立簡單的 Morph 效果，請複製一張投影片、在複製的投影片上移動或調整物件大小，然後將 Morph 轉場套用至第二張投影片。這會讓對應的物件在原始狀態與修改後的狀態之間進行動畫。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在複製稿上變更矩形的位置與大小。然後於第二張投影片的 [TransitionType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitiontype/) 列舉中選取 Morph。於支援 Morph 的簡報檢視器中開啟已儲存的檔案，即可在投影片放映時看到效果。

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

[TransitionMorphType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) 將每個圖形視為整體物件。
- [ByWord](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) 盡可能以詞彙匹配方式動畫文字。
- [ByChar](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元匹配方式動畫文字。

使用 [setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setType) 在存取 [getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#getValue) 之前先選取 Morph。取得的值會提供一個 [MorphTransition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/morphtransition/) 物件，可透過其 [setMorphType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/morphtransition/#setMorphType) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為基於詞彙的 Morph 動畫。

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

某些轉場會暴露額外的選項，例如方向或是否從黑屏開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setType) 所選的轉場。先設定類型，然後使用從 [getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#getValue) 取得的相應轉場物件。

以下範例將 Cut 轉場套用至 `input.pptx` 的第一張投影片。它透過 [OptionalBlackTransition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/optionalblacktransition/) 呼叫 [setFromBlack](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack)，使轉場從黑屏開始。

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

## **常見問題**

**我可以控制投影片轉場的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請優先使用 [setDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setDuration)。若僅需使用預先定義的 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionspeed/)（慢速、 中速、 快速）類別且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setSpeed)。這些設定會獨立於自動前進的延遲時間，僅控制轉場效果。

**我可以為轉場附加音訊並使其循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setSound) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionsoundmode/) 中的 `StartSound` 傳給 [setSoundMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode)，並將 [setSoundLoop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) 設為 `true`。音訊會持續循環，直到投影片放映中的下一個音效事件出現。

**如何最快地將相同的轉場套用至每張投影片？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSlides) 集合，對每張投影片的轉場呼叫 [setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#setType) 並傳入相同的值。可在同一迴圈中設定計時與效果選項，以確保所有投影片的行為一致。

**我該如何檢查投影片目前設定的轉場？**

對投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 結果呼叫 [getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/#getType)。它會回傳來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitiontype/) 列舉的值；`None` 表示未套用任何轉場效果。