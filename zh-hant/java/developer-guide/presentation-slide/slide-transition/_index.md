---
title: 使用 Java 管理簡報中的投影片過渡
linktitle: 投影片過渡
type: docs
weight: 80
url: /zh-hant/java/slide-transition/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 套用投影片過渡、設定自動投影片前進，並自訂 Morph 與其他過渡效果。"
---
## **概覽**

投影片過渡控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Java，您可以為每張投影片選擇過渡效果、設定滑鼠點擊或計時器的前進方式，並對特定效果調整選項。本文使用 Java 範例說明如何套用過渡、設定確切過渡持續時間、管理投影片計時，以及在兩張投影片之間建立 Morph 過渡。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片過渡**

要套用過渡，先以 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 取得投影片的過渡設定。使用 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 並傳入來自 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列舉的值，然後儲存簡報。

以下範例將 Circle 過渡套用於第一張投影片，將 Comb 過渡套用於第二張投影片。請使用包含至少兩張投影片的 `input.pptx` 檔案。

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

## **Wheel 過渡**

[IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) 的 [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) 方法控制揭露目標投影片的徑向區段數量。先使用 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 將投影片的過渡類型設定為 Wheel（來自 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)），然後存取作為 [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) 的 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)。

此範例建立兩組相同的投影片：一張黑色投影片，接著是一張帶有金色矩形的投影片。目標投影片分別使用 1 與 8 的輻條數，並透過 [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) 設定相同速度，並使用 [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) 明確設定 8,000 毫秒的持續時間，以便輕鬆觀察差異。

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從第 1 張投影片前進到第 2 張，然後從第 3 張前進到第 4 張。於 PowerPoint 播放時，驗證過的 1 條輻條會以一次順時針掃描揭露投影片；驗證過的 8 條輻條則同時以八個徑向區段揭露。目標內容與過渡計時相同，唯一差異在於揭露區段的數量。

## **新增進階投影片過渡**

您可以設定投影片在螢幕上停留的時間，以及滑鼠點擊是否會前進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) 允許觀眾點擊滑鼠前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) 指定自動前進前的延遲時間（以毫秒為單位）。

同時啟用點擊與計時前進，讓觀眾可以點擊前進或等待計時器。若只想使用計時器，請將 `false` 傳入 [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-)。延遲控制投影片放映何時前進；它不會設定視覺過渡效果的持續時間。

此範例為前三張投影片分別指派不同的效果，並分別在 3、5、7 秒後啟用自動前進。滑鼠點擊亦可前進這些投影片。請使用包含至少三張投影片的 `input.pptx` 檔案。

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

要檢查是否已啟用計時前進，呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--)。僅有延遲值並不代表計時器已啟用。

下一個範例開啟先前儲存的檔案，報告每個已啟用的計時器，並對延遲大於兩秒的投影片停用自動前進，同時為這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

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

使用 [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) 以毫秒為單位指定過渡效果的確切長度。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 方法透過 [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) 暴露此設定：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | 設定過渡效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 設定投影片自動前進前的延遲時間（毫秒）。將 `true` 傳入 [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 以啟用此計時器。 |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | 從 [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 列舉中選取預定義的速度類別：Slow、Medium 或 Fast。當未指定確切持續時間時會使用此設定。 |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) 僅控制過渡效果；它不決定投影片在螢幕上停留的時間。請另外設定自動前進的延遲時間。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型與 [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 的值推算效果持續時間。

<!-- visual-explanation:slide-transition:start -->
[![分離的條形標示 750 毫秒的過渡持續時間與 5,000 毫秒的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*此示範為每張投影片設定 750 毫秒的淡出過渡，並分別在 5,000 毫秒後啟用自動前進。過渡持續時間控制效果；前進時間控制何時離開投影片。這些條形僅是示意設定，並非實測的合成時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **為所有投影片套用相同持續時間**

為了保持節奏一致，將相同的效果與確切持續時間套用到每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 中選取 Fade，並為每個過渡設定 750 毫秒的持續時間。它同時在 5,000 毫秒後啟用自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 配置自動前進，與效果持續時間無關。
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

不同投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的過渡，為章節介紹使用較長的過渡。此範例為第一張投影片設定 500 毫秒，為第二張投影片設定 1,200 毫秒。請使用至少兩張投影片的 `input.pptx` 檔案。

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

在製作 [animated GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/)、[HTML5 簡報](/slides/zh-hant/java/export-to-html5/) 或 [影片](/slides/zh-hant/java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以符合預期節奏。例如，在場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 與影片，請將輸出幀速率與效果持續時間協調：600 毫秒相當於 30 幀每秒時的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的過渡持續時間**

在修改過渡之前呼叫 [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) 以判斷是否已儲存明確值。`-1` 表示未設定明確持續時間；非負值表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型與 [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 的值推算。設定過渡類型可能會初始化持續時間，因此請先檢查原始設定。

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

Morph 過渡會在連續投影片之間動畫化物件的變化。要建立簡單的 Morph 效果，請複製投影片、在複製的投影片上移動或調整物件大小，並將 Morph 過渡套用到第二張投影片。這樣會讓對應的物件在原始與修改後的狀態之間動畫化。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在複製品上變更矩形的位置與大小。接著從 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列舉中選取 Morph 為第二張投影片的過渡類型。將儲存的檔案在支援 Morph 的簡報檢視器中開啟，即可於投影片放映時看到效果。

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

[TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) 將每個形狀視為完整的物件。
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) 盡可能以字為單位匹配並動畫化文字。
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元為單位匹配並動畫化文字。

使用 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 選取 Morph，然後存取 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)。取得的值會提供 [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) 介面，透過其 [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) 方法選擇匹配模式。

此範例開啟前節建立的簡報，並將第二張投影片設定為以字為單位的 Morph 動畫。

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

某些過渡會暴露額外選項，例如方向或是否從黑屏開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 所選的過渡類型。先設定類型，然後使用 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) 取得相應的介面。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 過渡，並透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) 的 [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) 讓過渡從黑屏開始。

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

## **常見問題集**

**我可以控制投影片過渡的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請優先使用 [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-)。若預定義的 [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 分類（Slow、Medium 或 Fast）已足夠且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-)。這些設定獨立於自動前進的延遲時間，僅控制過渡效果本身。

**我可以將音訊附加到過渡並讓它循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) 列舉中的 StartSound 傳入 [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-)，並以 `true` 啟用 [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-)。音訊會在投影片放映中持續循環，直至下一個音效事件發生。

**將相同過渡套用到每張投影片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 集合，對每張投影片的過渡呼叫 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)，傳入相同的值。於同一迴圈中設定所有計時與效果選項，即可在所有投影片間保持一致的行為。

**我如何檢查投影片上目前設定的過渡是什麼？**

對投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 結果呼叫 [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--)。它會傳回來自 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列舉的值；若為 None，表示未套用任何過渡效果。