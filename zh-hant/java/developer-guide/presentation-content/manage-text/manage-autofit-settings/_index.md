---
title: 使用 Java 的 AutoFit 強化您的簡報
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/java/manage-autofit-settings/
keywords:
- 文字方塊
- AutoFit
- 不要自動調整
- 適合文字
- 縮小文字
- 換行文字
- 調整形狀大小
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中管理 AutoFit 設定，以優化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容易讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會使用 **Resize shape to fix text** 設定——自動調整文字方塊大小，以確保文字始終能容納其中。

![PowerPoint 中的文字方塊](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊（增加高度），以容納更多文字。  
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊（減少高度），以清除多餘空間。

在 PowerPoint 中，有 4 個重要參數或選項可控制文字方塊的自動調整行為：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint 中的自動調整選項](autofit-options-powerpoint.png)

Aspose.Slides for Java 提供類似的選項——位於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat) 類別下的某些屬性——讓您能控制簡報中文字方塊的自動調整行為。

## **調整形狀大小以適應文字**

如果您希望文字在更改後始終適合其所在的方塊，必須使用 **Resize shape to fix text** 選項。設定此屬性，請將來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat) 類別的 [AutofitType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 屬性設為 `Shape`。

![PowerPoint 中的自動適應設定](alwaysfit-setting-powerpoint.png)

以下 Java 程式碼示範如何在 PowerPoint 簡報中指定文字必須始終適合其方塊：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

若文字變長或變大，文字方塊會自動調整大小（增加高度）以確保全部文字容納其中。若文字變短，則會相反處理。

## **不要自動調整**

如果您希望文字方塊或形狀在文字內容變更時保持原始尺寸，必須使用 **Do not Autofit** 選項。設定此屬性，請將來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat) 類別的 [AutofitType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 屬性設為 `None`。

![PowerPoint 中的「不要自動調整」設定](donotautofit-setting-powerpoint.png)

以下 Java 程式碼示範如何在 PowerPoint 簡報中指定文字方塊必須始終保留其尺寸：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

當文字超出方塊時，會溢出顯示。

## **文字溢出時縮小**

若文字超出方塊，透過 **Shrink text on overflow** 選項，您可以指定縮小文字的大小與間距，使其適合方塊。設定此屬性，請將來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat) 類別的 [AutofitType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 屬性設為 `Normal`。

![PowerPoint 中的「文字溢出時縮小」設定](shrinktextonoverflow-setting-powerpoint.png)

以下 Java 程式碼示範如何在 PowerPoint 簡報中指定文字在溢出時縮小：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 選項時，僅在文字超出方塊時才會套用此設定。
{{% /alert %}}

## **文字換行**

如果您希望文字在超出形狀的寬度時自動換行，必須使用 **Wrap text in shape** 參數。設定此屬性，請將來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat) 類別的 [WrapText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/TextFrameFormat#getWrapText--) 屬性設為 `true`。

以下 Java 程式碼示範如何在 PowerPoint 簡報中使用換行設定：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}}
如果將形狀的 `WrapText` 屬性設為 `False`，當文字長度超過形狀寬度時，文字會在單行延伸至形狀邊界之外。
{{% /alert %}}

## **常見問題**

**文字框的內邊距會影響 AutoFit 嗎？**

會。內邊距（Padding）會減少可用文字區域，導致 AutoFit 提前觸發——會更早縮小字型或調整形狀大小。請在調整 AutoFit 前檢查並設定邊距。

**AutoFit 如何與手動換行與軟換行互動？**

強制換行會保留原位，AutoFit 會在其周圍調整字型大小與間距。移除不必要的換行通常能減少 AutoFit 必須執行的縮減幅度。

**變更主題字型或觸發字型替換會影響 AutoFit 結果嗎？**

會。替換為字型度量不同的字型會改變文字寬度/高度，從而改變最終的字型大小與換行方式。每次更換字型或發生替換後，請重新檢查投影片。