---
title: 在 Android 上管理簡報的投影片轉場
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
description: "探索如何在 Aspose.Slides for Android via Java 中自訂投影片轉場，並提供針對 PowerPoint 與 OpenDocument 簡報的逐步指南。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 來管理簡報中的投影片轉場。它展示了如何將轉場類型套用至投影片、設定點擊或指定時間後前進等轉場行為、檢查與停用自動前進、使用 Morph 轉場及其類型，並設定轉場效果選項。範例說明了如何載入或建立簡報、修改選取投影片的轉場設定，並將結果儲存為 PPTX 檔。本文亦回答了關於轉場速度、轉場聲音、將相同轉場套用至多張投影片，以及檢查投影片目前設定的轉場等常見問題。

## **新增投影片轉場**
要建立簡單的投影片轉場效果，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
1. 透過 TransitionType 列舉，將 Aspose.Slides for Android via Java 所提供的轉場效果之一套用至投影片。
1. 寫入已修改的簡報檔案。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在投影片 1 上套用圓形類型轉場
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在投影片 2 上套用梳狀類型轉場
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 將簡報寫入磁碟
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **新增進階投影片轉場**
在上述段落中，我們僅在投影片上套用了簡單的轉場效果。現在，為了讓該簡單轉場效果更完善且受控，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
1. 透過 Aspose.Slides for Android via Java 所提供的轉場效果之一套用投影片轉場類型。
1. 您也可以將轉場設定為點擊前進、在特定時間後前進或兩者同時。
1. 若投影片轉場已啟用「點擊前進」，則只有在使用者點擊滑鼠時才會前進。此外，若設定了「在時間後前進」屬性，則在指定的時間過後會自動前進。
1. 將已修改的簡報寫入為簡報檔案。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在投影片 1 上套用圓形類型轉場
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 設定 3 秒的轉場時間
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在投影片 2 上套用梳狀類型轉場
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 設定 5 秒的轉場時間
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在投影片 3 上套用縮放類型轉場
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 設定 7 秒的轉場時間
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 將簡報寫入磁碟
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 轉場**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 現已支援 [Morph Transition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMorphTransition)。它代表了 PowerPoint 2019 中推出的全新 Morph 轉場。

{{% /alert %}} 

Morph 轉場允許您在兩張投影片之間呈現平滑的動畫移動。本文描述了其概念與使用方式。若要有效使用 Morph 轉場，您需要有兩張至少共享一個物件的投影片。最簡單的方式是複製投影片，然後將第二張投影片上的物件移動到不同位置。

以下程式碼片段示範了如何將包含文字的投影片副本加入簡報，並為第二張投影片設定 [morph type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TransitionType) 轉場。

```java
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

- ByObject：Morph 轉場會將形狀視為不可分割的物件來執行。
- ByWord：Morph 轉場在可能的情況下，會以字詞為單位傳輸文字。
- ByChar：Morph 轉場在可能的情況下，會以字元為單位傳輸文字。

以下程式碼片段示範了如何為投影片設定 Morph 轉場並變更 Morph 類型：

```java
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
Aspose.Slides for Android via Java 支援設定各種轉場效果，例如「由黑色淡入」、「由左側淡入」、「由右側淡入」等。若要設定轉場效果，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 取得投影片的參照。
- 設定轉場效果。
- 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例示範了我們如何設定轉場效果。

```java
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

**我可以控制投影片轉場的播放速度嗎？**

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/transitionspeed/) 設定（例如 slow、medium、fast）來設定轉場的 [speed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-)。

**我可以為轉場附加音訊並使其循環播放嗎？**

可以。您可以為轉場嵌入音效，並透過如 setSound、setSoundMode、setSoundLoop 等設定來控制其行為，同時可使用 setSoundIsBuiltIn 與 setSoundName 等中繼資料。

**將相同的轉場套用至每張投影片的最快方法是什麼？**

在每張投影片的轉場設定上配置所需的轉場類型；轉場是依投影片儲存的，因此在所有投影片上套用相同類型即可取得一致的效果。

**我要如何檢查投影片目前設定了哪種轉場？**

檢查投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--)，並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)，該值即告訴您目前套用了哪種效果。