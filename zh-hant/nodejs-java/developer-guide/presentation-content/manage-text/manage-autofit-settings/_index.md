---
title: 使用 JavaScript 的 AutoFit 增強您的簡報
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/nodejs-java/manage-autofit-settings/
keywords:
- 文字方塊
- AutoFit
- 不自動調整
- 符合文字
- 縮小文字
- 換行文字
- 調整形狀
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中管理 AutoFit 設定，以優化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會對該文字方塊使用 **Resize shape to fix text** 設定 — 它會自動調整文字方塊的大小，以確保其中的文字始終能夠容納。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊 — 增加其高度 — 以容納更多文字。 
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊 — 減少其高度 — 以清除多餘的空間。 

在 PowerPoint 中，以下四個重要的參數或選項可控制文字方塊的自動調整行為：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java 提供了類似的選項 — 某些位於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別下的屬性 — 讓您能夠控制簡報中文字方塊的自動調整行為。

## **調整形狀以符合文字**

如果您希望文字在方塊內即使在文字變更後仍能始終適合該方塊，必須使用 **Resize shape to fix text** 選項。若要指定此設定，請從 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別呼叫 [setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) 方法，並傳入 `Shape` 值。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 JavaScript 程式碼示範如何指定文字在 PowerPoint 簡報中必須始終適合其方塊：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

如果文字變長或變大，文字方塊會自動調整大小（高度增加），以確保所有文字都能容納其中。若文字變短，則會發生相反的情況。

## **不自動調整**

如果您希望文字方塊或形狀不論內部文字如何變更皆保留其尺寸，必須使用 **Do not Autofit** 選項。若要指定此設定，請從 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別呼叫 [setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) 方法，並傳入 `None` 值。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 JavaScript 程式碼示範如何指定文字方塊在 PowerPoint 簡報中必須永遠保留其尺寸：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

當文字過長而無法容納於方塊時，文字會溢出。

## **文字溢出時縮小**

如果文字過長而無法容納於方塊，可透過 **Shrink text on overflow** 選項指定將文字的大小與間距縮減，以使其適合方塊。若要指定此設定，請從 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別呼叫 [setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) 方法，並傳入 `Normal` 值。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 JavaScript 程式碼示範如何在 PowerPoint 簡報中指定文字在溢出時必須縮小：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
當使用 **Shrink text on overflow** 選項時，設定僅在文字過長而無法容納於方塊時套用。
{{% /alert %}}

## **換行文字**

如果您希望文字在形狀內部換行，當文字超出形狀邊界（僅寬度）時，必須使用 **Wrap text in shape** 參數。若要指定此設定，必須從 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別呼叫 [setWrapText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) 方法，並傳入 `true` 值。

以下 JavaScript 程式碼示範如何在 PowerPoint 簡報中使用換行文字設定：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
如果對形狀呼叫 `setWrapText` 方法並傳入 `False` 值，當形狀內的文字長度超過形狀寬度時，文字會以單行方式延伸超出形狀邊界。 
{{% /alert %}}

## **常見問題**

**文字框的內部邊距會影響 AutoFit 嗎？**

是的。填充（內部邊距）會減少文字可使用的區域，因此 AutoFit 會較早啟動 — 更早縮小字型或調整形狀大小。請在調整 AutoFit 前檢查並調整邊距。

**AutoFit 與手動和軟換行如何互動？**

強制換行會保留下來，AutoFit 會依據這些換行調整字型大小與間距。移除不必要的換行通常可減少 AutoFit 必須縮小文字的程度。

**變更佈景主題字型或觸發字型替換會影響 AutoFit 結果嗎？**

是的。替換為具有不同字形度量的字型會改變文字的寬度/高度，進而影響最終的字型大小與換行。任何字型變更或替換後，都需重新檢查投影片。