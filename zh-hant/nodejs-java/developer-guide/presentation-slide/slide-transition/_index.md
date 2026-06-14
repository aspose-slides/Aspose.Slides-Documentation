---
title: 使用 JavaScript 在簡報中管理投影片過渡
linktitle: 投影片過渡
type: docs
weight: 80
url: /zh-hant/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 JavaScript 中自訂投影片過渡，提供 PowerPoint 與 OpenDocument 簡報的逐步指南。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在簡報中管理投影片過渡效果。它展示了如何對投影片套用過渡類型、設定過渡行為（例如點擊時前進或在指定時間後前進）、檢查並停用自動前進、使用 Morph 過渡及其類型，以及設定過渡效果選項。範例示範了如何載入或建立簡報、修改選取投影片的過渡設定，並將結果儲存為 PPTX 檔案。本文還回答了有關過渡速度、過渡音效、將相同過渡套用至多個投影片，以及檢查投影片目前設定的過渡等常見問題。

## **新增投影片過渡**
若要建立簡單的投影片過渡效果，請依照以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation)類別的實例。
2. 透過 TransitionType 列舉，對投影片套用 Aspose.Slides for Node.js via Java 所提供的其中一種投影片過渡類型。
3. 寫入已修改的簡報檔案。

```javascript
// 實例化 Presentation 類別以載入原始簡報檔案
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // 在第 1 張投影片套用圓形類型過渡
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // 在第 2 張投影片套用梳狀類型過渡
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // 將簡報寫入磁碟
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **新增進階投影片過渡**
在上述章節中，我們僅在投影片上套用了簡單的過渡效果。現在，若要讓此簡單過渡效果更佳且可控，請依照以下步驟：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation)類別的實例。
2. 對投影片套用 Aspose.Slides for Node.js via Java 所提供的其中一種投影片過渡類型。
3. 您也可以將過渡設為點擊前進、在特定時間後前進，或同時兩者。
4. 如果投影片過渡已啟用「點擊前進」，則僅在使用者點擊滑鼠時才會前進。此外，若設定了「在時間後前進」屬性，過渡將於指定的時間過後自動前進。
5. 將已修改的簡報寫入為簡報檔案。

```javascript
// 實例化表示簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 張投影片套用圓形類型過渡
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // 設定 3 秒的過渡時間
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // 在第 2 張投影片套用梳狀類型過渡
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // 設定 5 秒的過渡時間
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // 在第 3 張投影片套用縮放類型過渡
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // 設定 7 秒的過渡時間
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // 將簡報寫入磁碟
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 過渡**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 現在支援[Morph Transition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MorphTransition)。此過渡是 PowerPoint 2019 中引入的新型 Morph 過渡。

{{% /alert %}} 

Morph 過渡可讓您在投影片之間以平滑的方式動畫移動。本篇文章說明其概念與使用方式。若要有效使用 Morph 過渡，您需要兩張至少具有一個共同物件的投影片。最簡單的方式是複製投影片，然後在第二張投影片上將該物件移動到其他位置。

下列程式碼片段示範如何將投影片的副本（包含文字）加入簡報，並為第二張投影片設定[morph type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TransitionType)過渡。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 過渡類型**
新增了[TransitionMorphType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TransitionMorphType)列舉。它代表不同類型的 Morph 投影片過渡。

TransitionMorphType 列舉包含三個成員：

- ByObject：Morph 過渡將以形狀視為不可分割的物件來執行。
- ByWord：Morph 過渡將在可能的情況下以文字為單位轉移文字。
- ByChar：Morph 過渡將在可能的情況下以字元為單位轉移文字。

下列程式碼片段示範如何為投影片設定 Morph 過渡並變更 Morph 類型：

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定過渡效果**
Aspose.Slides for Node.js via Java 支援設定各種過渡效果，例如從黑色、從左側、從右側等。若要設定過渡效果，請依照以下步驟：

- 建立[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)類別的實例。
- 取得該投影片的參考。
- 設定過渡效果。
- 將簡報寫入為[PPTX](https://docs.fileformat.com/presentation/pptx/)檔案。

以下範例中，我們已設定過渡效果。

```javascript
// 建立 Presentation 類別的實例
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // 設定效果
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // 將簡報寫入磁碟
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以控制投影片過渡的播放速度嗎？**

可以。使用[TransitionSpeed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/transitionspeed/)設定（例如 slow/medium/fast）來設定過渡的[speed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/setspeed/)。

**我可以為過渡附加音訊並使其循環播放嗎？**

可以。您可以為過渡嵌入音效，並透過如 sound mode 與 loop 等設定控制其行為（例如[setSound](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/setsound/)、[setSoundMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/)、[setSoundLoop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)，以及如[setSoundIsBuiltIn](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/)、[setSoundName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)等中繼資料）。

**將相同過渡套用到每張投影片的最快方法是什麼？**

在每張投影片的過渡設定中配置所需的過渡類型；過渡是依投影片儲存的，因此在所有投影片上套用相同類型即可得到一致的結果。

**我如何檢查投影片目前設定的過渡是什麼？**

檢查投影片的[transition settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 並讀取其[transition type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideshowtransition/gettype/)；該值即告訴您目前套用了哪種效果。