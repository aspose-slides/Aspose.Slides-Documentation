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
description: "使用 Aspose.Slides for Java 套用投影片過渡、設定自動投影片前進，並自訂 Morph 及其他過渡效果。"
---
## **概述**

投影片過渡控制投影片在投影片放映期間的呈現方式。使用 Aspose.Slides for Java，您可以為每張投影片選擇過渡效果、設定以滑鼠點擊或計時器方式前進，並調整特定於效果的選項。本文使用 Java 範例說明如何套用過渡、設定精確的過渡持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 過渡。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片過渡效果**

要套用過渡，先以 [**簡報**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別載入簡報，並透過 [**getSlideShowTransition**](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 取得投影片的過渡設定。使用 [**setType**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 並傳入來自 [**TransitionType**](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列舉的值，之後儲存簡報。

以下範例為第一張投影片套用 Circle 過渡，為第二張投影片套用 Comb 過渡。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

## **輪形過渡**

[IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) 的 [**setSpokes**](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) 方法控制顯示目的投影片的徑向區段數量。先使用 [**setType**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 將投影片的過渡類型設為 Wheel（來源自 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)），然後以 [**getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) 取得 [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) 介面。

此範例會建立兩組相同的投影片：先是黑色投影片，接著是一張帶有金色矩形的投影片。目的投影片分別使用 1 與 8 個輻條，其速度皆透過 [**setSpeed**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) 設定，且以 [**setDuration**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) 明確指定 8,000 毫秒的持續時間，以便輕易觀察差異。

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

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從投影片 1 前往投影片 2，接著從投影片 3 前往投影片 4。於 PowerPoint 播放時，驗證過的 1 個輻條會以順時針單一掃描顯示投影片；驗證過的 8 個輻條則同時以八個徑向區段顯示。目的內容與過渡計時相同，唯一差別在於顯示區段的數量。

## **使用 Reveal 過渡的淡入黑色效果**

將目的投影片的過渡類型設為 Reveal，然後在其 [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) 設定上呼叫 [**setThroughBlack**](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-)。此範例建立一張青綠色來源投影片與一張珊瑚色目的投影片，然後分別複製兩組。每組均使用兩秒的 Reveal 過渡，僅第二組會透過黑色淡入。

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中開啟已儲存的簡報並啟動投影片放映。從投影片 1 前往投影片 2，即可看到青綠色直接淡入珊瑚色。接著從投影片 3 前往投影片 4，畫面會略為變暗至近黑色，然後出現珊瑚色投影片。兩張投影片皆保留原始背景色。

下方列示每 0.5 秒截取的 PowerPoint 畫面框格，請比較每列的中間框格以觀察差異。

![PowerPoint 播放時禁用淡入黑色（上）與啟用淡入黑色（下）。僅下列畫面會經過近黑色。](reveal-through-black.png)

## **新增進階投影片過渡效果**

您可以設定投影片在螢幕上停留的時間以及是否透過滑鼠點擊前進投影片放映。以下方法負責此行為：

- [**setAdvanceOnClick**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) 允許觀眾透過滑鼠點擊前進。
- [**setAdvanceAfter**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 啟用自動前進。
- [**setAdvanceAfterTime**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) 指定自動前進前的延遲（毫秒）。

同時啟用點擊與計時前進，讓觀眾可點擊前進或等候計時器。若僅使用計時器，請將 `false` 傳遞給 [**setAdvanceOnClick**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-)。此延遲控制投影片放映何時前進，並不設定視覺過渡效果的持續時間。

此範例為前三張投影片分別指派不同的效果，並分別在 3、5、7 秒後自動前進。滑鼠點擊亦可前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，請呼叫 [**getAdvanceAfter**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--)。僅有儲存的延遲並不表示計時器已啟動。

下一個範例會開啟上述已儲存的檔案，報告每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進，改為啟用滑鼠點擊，最後儲存更新後的設定。

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

## **精確控制過渡時間**

使用 [**setDuration**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) 可在毫秒級別指定過渡效果的確切長度。投影片的 [**getSlideShowTransition**](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 方法會透過 [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) 介面公開這些設定：

| 方法 | 目的 |
| --- | --- |
| [**setDuration**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | 設定過渡效果本身的持續時間（毫秒）。 |
| [**setAdvanceAfterTime**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 設定投影片自動前進前的延遲（毫秒）。若要啟動此計時器，請將 `true` 傳遞給 [**setAdvanceAfter**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-)。 |
| [**setSpeed**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | 從 [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 列舉中選取預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時會使用此設定。 |

[**setDuration**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) 僅控制過渡效果，並不決定投影片的可見時間。自動前進的延遲需另行設定。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型與 [**getSpeed**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 的值推算效果長度。

<!-- visual-explanation:slide-transition:start -->
[![獨立的長條顯示 750 毫秒的過渡持續時間與 5,000 毫秒的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*此示範為每張投影片設定 750 毫秒的 Fade 過渡，並分別在 5,000 毫秒後啟用自動前進。過渡持續時間控制效果，前進時間控制離開投影片的時機。這些長條僅為示意設定，並非實測的綜合時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **將相同持續時間套用至每張投影片**

為了保持節奏一致，請將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 選取 Fade，並將每個過渡設定為 750 毫秒。再分別在 5,000 毫秒後啟用自動前進，且停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 配置自動前進，與效果持續時間獨立。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **為各投影片設定不同持續時間**

不同投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的過渡，為章節介紹投影片使用較長的過渡。此範例將第一張投影片設定為 500 毫秒，第二張投影片設定為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

### **在動畫輸出時協調過渡**

在製作 [animated GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/)、[HTML5 簡報](/slides/zh-hant/java/export-to-html5/) 或 [影片](/slides/zh-hant/java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以符合預期節奏。例如，在場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以容納旁白或內容的播放時間。

對於 GIF 與影片，請將輸出幀率與效果持續時間相匹配：600 毫秒相當於 30 幀每秒下的 18 幀。於 HTML5 匯出時，請在匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的過渡持續時間**

在修改過渡之前，先呼叫 [**getDuration**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) 以判斷是否已儲存明確的值。`-1` 代表未設定明確持續時間；非負值則表示已儲存的毫秒數。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型與 [**getSpeed**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 的值來決定此時間。設定過渡類型可能會初始化持續時間，故請先檢查原始設定。

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

Morph 過渡在連續投影片之間動畫化物件的變化。要建立簡單的 Morph 效果，先複製一張投影片，於複製件上移動或調整物件大小，然後將 Morph 過渡套用至第二張投影片。如此即可讓對應的物件在原始與修改狀態之間動畫化。

以下範例建立一張含文字矩形的投影片，複製該投影片，並在複製件上變更矩形的位置與大小。接著從 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列舉中選取 Morph 作為第二張投影片的過渡類型。於支援 Morph 的簡報檢視器中開啟已儲存的檔案，即可在放映時看到效果。

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

- [**ByObject**](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) 將每個圖形視為整體物件。
- [**ByWord**](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) 盡可能以單字為單位動畫化文字。
- [**ByChar**](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元為單位動畫化文字。

先使用 [**setType**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 選取 Morph，然後再呼叫 [**getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) 取得 [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) 介面，最後使用其 [**setMorphType**](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片的 Morph 動畫設定為以單字為單位。

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

某些過渡會曝光額外選項，例如方向或是否從黑屏開始。可用的選項取決於先前以 [**setType**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) 設定的過渡類型。先設定類型，然後透過 [**getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) 取得相應介面。

以下範例為 `input.pptx` 的第一張投影片套用 Cut 過渡，並透過 [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) 的 [**setFromBlack**](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) 讓過渡從黑色畫面開始。

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

可以。當您需要以毫秒為單位的精確效果持續時間時，請使用 [**setDuration**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-)。若預設的 [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/)（Slow、Medium 或 Fast）足以滿足需求，且未設定明確持續時間，則使用 [**setSpeed**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) 即可。這些設定皆獨立於自動前進的延遲。

**我能將音訊附加於過渡並設為迴圈播放嗎？**

可以。使用 [**setSound**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) 指定嵌入音訊，並將 [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) 中的 `StartSound` 傳遞給 [**setSoundMode**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-)，再將 [**setSoundLoop**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) 設為 `true`。音訊會持續迴圈播放，直到投影片放映中的下一個音效事件發生。

**將相同過渡套用至所有投影片的最快方法是什麼？**

遍歷簡報的 [**getSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 集合，在迴圈中對每張投影片的過渡呼叫 [**setType**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)，並在同一迴圈內設定所有計時與效果選項，以確保行為於各投影片間保持一致。

**我如何檢查投影片目前設定的過渡類型？**

對投影片的 [**getSlideShowTransition**](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 結果呼叫 [**getType**](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) 即可。它會回傳來自 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列舉的值；`None` 表示未套用任何過渡效果。