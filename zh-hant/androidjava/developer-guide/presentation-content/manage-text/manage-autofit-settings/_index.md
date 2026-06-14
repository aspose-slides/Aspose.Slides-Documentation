---
title: 使用 Android 上的 AutoFit 增強您的簡報
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/androidjava/manage-autofit-settings/
keywords:
- 文字方塊
- 自動調整
- 不自動調整
- 文字適應
- 縮小文字
- 文字換行
- 調整圖形大小
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android (Java) 中管理 AutoFit 設定，以優化 PowerPoint 與 OpenDocument 簡報中的文字呈現，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會使用 **Resize shape to fix text** 設定──它會自動調整文字方塊的大小，以確保文字始終能放入其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊（增加高度），以容納更多文字。  
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊（減少高度），以清除多餘的空間。  

在 PowerPoint 中，有四個重要的參數或選項可控制文字方塊的自動調整行為：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java 提供了類似的選項──位於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat) 類別下的某些屬性──可讓您在簡報中控制文字方塊的自動調整行為。

## **Resize a Shape to Fit Text**

如果您希望文字在變更後始終能適應其所在的方塊，必須使用 **Resize shape to fix text** 選項。要設定此項，將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat) 類別中的 [AutofitType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 屬性設為 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 Java 程式碼示範如何在 PowerPoint 簡報中指定文字必須始終適應其方塊：

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

若文字變長或變大，文字方塊會自動重新調整大小（高度增加），以確保所有文字都能容納其中；若文字變短，則會相反。

## **Do Not Autofit**

如果您希望文字方塊或圖形在文字變更後仍保持原始尺寸，必須使用 **Do not Autofit** 選項。要設定此項，將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat) 類別中的 [AutofitType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 屬性設為 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 Java 程式碼示範如何在 PowerPoint 簡報中指定文字方塊必須保持其尺寸：

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

當文字過長而無法容納於方塊時，文字會溢出。

## **Shrink Text on Overflow**

如果文字過長而無法容納於方塊，透過 **Shrink text on overflow** 選項，您可以指定將文字的大小與間距縮小，使其適應方塊。要設定此項，將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat) 類別中的 [AutofitType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 屬性設為 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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
使用 **Shrink text on overflow** 選項時，僅在文字過長無法容納於方塊時才會套用此設定。
{{% /alert %}}

## **Wrap Text**

如果您希望文字在超出圖形邊界（僅寬度）時自動換行，必須使用 **Wrap text in shape** 參數。要設定此項，需將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat) 類別中的 [WrapText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) 屬性設為 `true`。

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
如果將 `WrapText` 屬性設為 `False`，當文字長度超過圖形寬度時，文字會沿單行延伸至圖形邊界之外。
{{% /alert %}}

## **常見問題**

**文字框的內部邊距會影響 AutoFit 嗎？**

會。內部邊距（Padding）會減少可用文字區域，導致 AutoFit 更早啟動──會更早縮小字型或調整圖形大小。請在調整 AutoFit 前先檢查並調整邊距。

**AutoFit 與手動換行及軟換行如何互動？**

強制換行會保持不變，AutoFit 會根據這些換行點調整字型大小與間距。移除不必要的換行通常能降低 AutoFit 縮小文字的幅度。

**變更主題字型或觸發字型替換會影響 AutoFit 結果嗎？**

會。替換為字型度量不同的字型會改變文字的寬度/高度，從而改變最終字型大小與換行方式。任何字型變更或替換後，都應重新檢查投影片。