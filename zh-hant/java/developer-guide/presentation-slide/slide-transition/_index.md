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
description: "探索如何在 Aspose.Slides for Java 中自訂投影片過渡，提供針對 PowerPoint 與 OpenDocument 簡報的逐步指引。"
---
## **概觀**

此文章說明如何使用 Aspose.Slides 在簡報中管理投影片過渡。它展示了如何對投影片套用過渡類型、設定過渡行為（例如點擊時前進或在指定時間後前進）、檢查並停用自動前進、使用 Morph 過渡及其類型，以及設定過渡效果選項。範例說明如何載入或建立簡報、修改選取投影片的過渡設定，並將結果儲存為 PPTX 檔案。文章亦回答有關過渡速度、過渡音效、對多張投影片套用相同過渡以及檢查投影片目前設定之過渡的常見問題。

## **新增投影片過渡**
若要建立簡單的投影片過渡效果，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
2. 透過 TransitionType 列舉，對投影片套用 Aspose.Slides for Java 所提供的其中一種投影片過渡類型。
3. 將修改後的簡報寫入檔案。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在第 1 張投影片套用圓形類型過渡
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在第 2 張投影片套用梳狀類型過渡
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 將簡報寫入磁碟
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **新增進階投影片過渡**
在上述段落中，我們僅在投影片上套用了簡單的過渡效果。現在，為了讓此簡單過渡效果更加完善且可控，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
2. 對投影片套用 Aspose.Slides for Java 所提供的其中一種投影片過渡類型。
3. 您也可以將過渡設定為點擊時前進、在特定時間後前進，或兩者同時設定。
4. 若投影片過渡已啟用「點擊時前進」，則僅在使用者點擊滑鼠時才會前進。此外，若設定了「在時間後前進」屬性，則會在指定的時間過後自動前進。
5. 將修改後的簡報寫入簡報檔案。

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 張投影片套用圓形類型過渡
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 設定過渡時間為 3 秒
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在第 2 張投影片套用梳狀類型過渡
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 設定過渡時間為 5 秒
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在第 3 張投影片套用縮放類型過渡
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 設定過渡時間為 7 秒
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 將簡報寫入磁碟
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 過渡**
{{% alert color="info" %}} 

Aspose.Slides for Java 現在支援 [Morph Transition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMorphTransition)。它代表在 PowerPoint 2019 中推出的新型 Morph 過渡。

{{% /alert %}} 

The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

Morph 過渡允許您在投影片之間產生平滑的動畫移動。本文說明其概念及如何使用 Morph 過渡。若要有效使用 Morph 過渡，您需要有兩張至少共享一個物件的投影片。最簡單的做法是複製投影片，然後將第二張投影片上的物件移動到其他位置。

以下程式碼片段示範如何將帶有文字的投影片副本新增至簡報，並為第二張投影片設定 [morph type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TransitionType) 過渡。

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

## **Morph 過渡類型**
已新增 [TransitionMorphType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TransitionMorphType) 列舉。它代表不同類型的 Morph 投影片過渡。

TransitionMorphType 列舉包含三個成員：

- ByObject：Morph 過渡將以形狀作為不可分割的物件來執行。
- ByWord：在可能的情況下，Morph 過渡將以逐字（單詞）方式傳遞文字。
- ByChar：在可能的情況下，Morph 過渡將以逐字元方式傳遞文字。

以下程式碼片段示範如何為投影片設定 Morph 過渡並變更 Morph 類型：

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

## **設定過渡效果**
Aspose.Slides for Java 支援設定過渡效果，例如從黑色、從左側、從右側等。若要設定過渡效果，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
- 取得投影片的參照。
- 設定過渡效果。
- 將簡報寫入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例中，我們已設定過渡效果。

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

## **常見問題**

### 我可以控制投影片過渡的播放速度嗎？

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/transitionspeed/) 設定，將過渡的 [speed](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) 設為慢速、普通或快速等。

### 我可以為過渡加入音訊並使其循環嗎？

是的。您可以為過渡嵌入聲音，並透過設定（如聲音模式與循環）來控制其行為，例如使用 [setSound](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)，以及像是 [setSoundIsBuiltIn](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 和 [setSoundName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) 等中繼資料。

### 將相同過渡套用至每張投影片的最快方法是什麼？

在每張投影片的過渡設定中配置所需的過渡類型；過渡是以投影片為單位儲存的，因此在所有投影片上套用相同類型即可獲得一致的結果。

### 如何檢查投影片目前設定的過渡類型？

檢查投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslide/#getSlideShowTransition--)，並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideshowtransition/#setType-int-)；此值會明確指出套用的是哪種效果。