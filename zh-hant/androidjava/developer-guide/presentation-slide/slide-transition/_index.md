---
title: 在 Android 上管理簡報的投影片過渡
linktitle: 投影片過渡
type: docs
weight: 80
url: /zh-hant/androidjava/slide-transition/
keywords:
- 投影片過渡
- 新增投影片過渡
- 套用投影片過渡
- 進階投影片過渡
- Morph 過渡
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 套用投影片過渡、設定自動投影片前進，並自訂 Morph 及其他過渡效果。"
---
## **概觀**

投影片過渡控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Android via Java，您可以為每張投影片選擇過渡效果、設定以滑鼠點擊或計時器的方式前進，以及調整特定於效果的選項。本文使用 Java 範例套用過渡、設定精確的過渡持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 過渡。這些範例也說明如何將設定儲存為 PPTX 檔案。

## **新增投影片過渡**

若要套用過渡，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 取得投影片的過渡設定。使用 [setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 搭配來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitiontype/) 列舉的值，然後儲存簡報。

以下示例將 Circle 過渡套用於第一張投影片，將 Comb 過渡套用於第二張。請使用至少包含兩張投影片的 `input.pptx` 檔案。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **新增進階投影片過渡**

您可以設定投影片在螢幕上停留的時間以及是否以滑鼠點擊前進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) 允許觀眾透過點擊滑鼠前進投影片放映。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) 指定自動前進之前的延遲時間（毫秒）。

同時啟用點擊和計時前進，讓觀眾可以點擊前進或等待計時器。若只使用計時器，請將 `false` 傳遞給 [setAdvanceOnClick]。延遲時間決定投影片放映何時前進；它不會設定視覺過渡效果的持續時間。

此示例為前三張投影片指定不同的效果，並分別在 3、5、7 秒後啟用自動前進。滑鼠點擊也可前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

若要檢查是否已啟用計時前進，請呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--)。僅有已儲存的延遲並不表示計時器已啟動。

下一個示例會開啟上述儲存的檔案，回報每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。它會為這些投影片啟用滑鼠點擊，並儲存更新後的設定。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **精確控制過渡計時**

使用 [setDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) 以毫秒為單位指定過渡效果的精確長度。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 方法透過 [ISlideShowTransition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/) 透露這些設定：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | 設定過渡效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 設定投影片自動前進前的延遲時間（毫秒）。將 `true` 傳遞給 [setAdvanceAfter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 以啟動此計時器。 |
| [setSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | 從 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionspeed/) 中選擇預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時使用。 |

[setDuration] 僅控制過渡效果；它不決定投影片保持可見的時間。請分別設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型與 [getSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) 的值決定效果持續時間。

### **為每張投影片套用相同持續時間**

為了保持一致的節奏，對每張投影片套用相同的效果與精確持續時間。此示例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitiontype/) 中選取 Fade，並為每個過渡設定 750 毫秒的持續時間。同時設定在 5,000 毫秒後自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 獨立於效果持續時間設定自動前進。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **為個別投影片設定不同持續時間**

不同的投影片可以使用不同的效果持續時間。例如，對標題投影片使用較短的過渡，對章節介紹使用較長的過渡。此示例將第一張投影片的持續時間設定為 500 毫秒，第二張為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **將過渡與動畫輸出協調**

在製作 [animated GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/androidjava/export-to-html5/) 或 [video](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以符合預期的節奏。例如，在場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以允許其旁白或內容的時間。

對於 GIF 和影片，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 fps 時的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有過渡持續時間**

在修改過渡之前呼叫 [getDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) 以判斷是否已儲存明確的值。`-1` 表示未設定明確的持續時間；非負值則指定以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型與 [getSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) 的值來決定該持續時間。設定過渡類型可能會初始化持續時間，因此請先檢查原始設定。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph 過渡**

Morph 過渡會對連續投影片之間的物件變化進行動畫化。若要建立簡單的 Morph 效果，請複製投影片、在複製的投影片上移動或調整物件大小，然後將 Morph 過渡套用於第二張投影片。此作法讓過渡動畫於相對應的物件之原始與修改狀態之間切換。

以下示例建立包含文字矩形的投影片，複製該投影片，並在複製品上變更矩形的位置與大小。接著為第二張投影片從 [TransitionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitiontype/) 列舉中選取 Morph。於支援 Morph 的簡報檢視器中開啟儲存的檔案，即可在投影片放映時看到效果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 過渡類型**

[TransitionMorphType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) 將每個形狀視為整體物件。
- [ByWord](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) 在可能的情況下，以單詞為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) 在可能的情況下，以字元為單位動畫化文字。

使用 [setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 於存取 [getValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getValue--) 前選取 Morph。取得的值會提供 [IMorphTransition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imorphtransition/) 介面，其 [setMorphType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) 方法可選擇匹配模式。

此示例開啟前節建立的簡報，並將第二張投影片設定為使用基於單詞的 Morph 動畫。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **設定過渡效果**

某些過渡會提供額外選項，例如方向或效果是否從黑畫面開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 所選的過渡。請先設定類型，然後使用 [getValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getValue--) 提供的適當介面。

以下示例對 `input.pptx` 的第一張投影片套用 Cut 過渡。它透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioptionalblacktransition/) 呼叫 [setFromBlack](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-)，使過渡從黑畫面開始。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以控制投影片過渡的播放速度嗎？**

可以。若需要以毫秒為單位的精確效果持續時間，請使用 [setDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)。若預先定義的 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionspeed/) 類別（Slow、Medium 或 Fast）已足夠且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-)。這些設定會獨立於自動前進延遲，控制過渡效果。

**我可以將音訊附加到過渡並使其循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionsoundmode/) 列舉中的 StartSound 傳遞給 [setSoundMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-)，並以 `true` 啟用 [setSoundLoop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-)。音訊會持續循環，直到投影片放映中的下一個音效事件。

**將相同過渡套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--) 集合，對每張投影片的過渡呼叫 [setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 並使用相同的值。於同一迴圈中設定所有計時與效果選項，以保持各投影片之行為一致。

**我如何檢查投影片目前設定的過渡是什麼？**

呼叫投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 結果上的 [getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islideshowtransition/#getType--)。它會返回 [TransitionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitiontype/) 列舉中的值；None 表示未套用任何過渡效果。