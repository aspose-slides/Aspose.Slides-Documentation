---
title: 在 Android 上管理簡報中的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 80
url: /zh-hant/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "探索如何在 Aspose.Slides for Android via Java 中自訂投影片轉場，並提供 PowerPoint 與 OpenDocument 簡報的逐步指南。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中管理簡報的投影片轉場。它展示了如何將轉場類型套用到投影片、設定轉場行為（例如點擊或在指定時間後前進）、使用 Morph 轉場及其類型，以及設定轉場效果選項。範例說明了如何載入或建立簡報、修改所選投影片的轉場設定，並將結果儲存為 PPTX 檔案。本文亦回答了關於轉場速度、轉場音效、將相同轉場套用到多張投影片以及檢查投影片目前設定的轉場等常見問題。

## **新增投影片轉場**
若要建立簡單的投影片轉場效果，請依下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 透過 TransitionType 列舉，自 Aspose.Slides for Android via Java 所提供的轉場效果中，將投影片轉場類型套用至投影片。
3. 寫入已修改的簡報檔案。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在第 1 張投影片套用 circle 類型的轉場
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在第 2 張投影片套用 comb 類型的轉場
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 將簡報寫入磁碟
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **新增進階投影片轉場**
在上述章節中，我們僅在投影片上套用了簡單的轉場效果。現在，若要讓這個簡單的轉場效果更完善且可控，請依下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 透過 Aspose.Slides for Android via Java 所提供的轉場效果，將投影片轉場類型套用至投影片。
3. 您也可以將轉場設定為「在點擊時前進」、在特定時間後前進，或兩者兼具。
4. 若投影片轉場已啟用「在點擊時前進」，則僅在使用者點擊滑鼠時才會前進；若設定了「在指定時間後前進」屬性，則會在指定的時間過後自動前進。
5. 將已修改的簡報寫入為簡報檔案。

```java
import com.aspose.slides.*;

// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 張投影片套用 circle 類型的轉場
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 點擊時前進或於 3 秒後自動前進
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在第 2 張投影片套用 comb 類型的轉場
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 點擊時前進或於 5 秒後自動前進
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在第 3 張投影片套用 zoom 類型的轉場
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 點擊時前進或於 7 秒後自動前進
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 將簡報寫入磁碟
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 轉場**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 現已支援 [Morph Transition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMorphTransition)。它們代表 PowerPoint 2019 中引入的新型 Morph 轉場。

{{% /alert %}} 

Morph 轉場允許您在兩張投影片之間建立平滑的移動動畫。本文說明了概念以及如何使用 Morph 轉場。若要有效使用 Morph 轉場，您需要兩張投影片至少有一個共同的物件。最簡單的方式是複製投影片，然後在第二張投影片上將該物件移到其他位置。

下列程式碼片段示範如何將帶有文字的投影片複製到簡報，並將第二張投影片的轉場設定為 [morph type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TransitionType)。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Morph 轉場類型**
已新增 [TransitionMorphType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TransitionMorphType) 列舉，代表不同類型的 Morph 投影片轉場。

TransitionMorphType 列舉有三個成員：

- ByObject：Morph 轉場會將形狀視為不可分割的物件進行處理。
- ByWord：Morph 轉場會在可能的情況下，以單字為單位傳輸文字。
- ByChar：Morph 轉場會在可能的情況下，以字元為單位傳輸文字。

下列程式碼片段示範如何將 Morph 轉場套用到投影片並變更 Morph 類型：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定轉場效果**
Aspose.Slides for Android via Java 支援設定各種轉場效果，例如「從黑色淡入」「從左側」或「從右側」等。若要設定轉場效果，請依下列步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 取得投影片的參考。
- 設定轉場效果。
- 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例示範了如何設定轉場效果。

```java
import com.aspose.slides.*;

// 建立 Presentation 類別的實例
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 設定效果
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // 將簡報寫入磁碟
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問與答**

### 我可以控制投影片轉場的播放速度嗎？

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionspeed/) 設定（例如 slow、medium、fast）來設定轉場的 [speed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-)。

### 我可以在轉場上附加音訊並設定循環播放嗎？

可以。您可以為轉場嵌入聲音，並透過如 [setSound](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-) 等設定來控制行為，並可使用 [setSoundIsBuiltIn](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 以及 [setSoundName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) 等中繼資料。

### 要將相同的轉場套用到每張投影片，最快的方法是什麼？

在每張投影片的轉場設定中配置所需的轉場類型；轉場是依投影片儲存的，將相同類型套用於所有投影片即可得到一致的結果。

### 我要如何檢查投影片目前設定的轉場是什麼？

檢查投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--)，並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)，該值即表示目前套用的效果。