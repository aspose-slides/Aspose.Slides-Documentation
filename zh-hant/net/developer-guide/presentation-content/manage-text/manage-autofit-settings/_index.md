---
title: 使用 .NET 的 AutoFit 功能提升簡報效果
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/net/manage-autofit-settings/
keywords:
- 文字方塊
- AutoFit
- 不自動調整大小
- 調整文字以適合
- 縮小文字
- 自動換行文字
- 調整形狀大小
- PowerPoint
- 簡報
- C#
- .NET
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中管理 AutoFit 設定，以最佳化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會使用 **Resize shape to fit text** 設定──它會自動調整文字方塊的大小，以確保文字始終適合其中。

![PowerPoint 中的文字方塊](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊（增加其高度），以容納更多文字。
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊（降低其高度），以清除多餘的空間。

在 PowerPoint 中，以下四個參數或選項會控制文字方塊的自動調整行為：

* **不自動調整大小**
* **文字溢位時縮小文字**
* **調整形狀大小以符合文字**
* **在形狀中換行文字**

![PowerPoint 中的自動調整選項](autofit-options-powerpoint.png)

Aspose.Slides for .NET 提供類似的選項——位於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat) 類別下的屬性——讓您能控制簡報中文字方塊的自動調整行為。

## **調整形狀大小以符合文字**

如果您希望文字在修改後始終適合其所在的方框，必須使用 **Resize shape to fit text** 功能。要指定此設定，請將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat) 類別的 `AutofitType` 屬性設為 `Shape`。

![調整形狀大小以符合文字](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

當文字變長或變大時，文字方塊將自動調整大小（高度增加），以確保所有文字皆能容納。當文字變短時，則會相反。

## **不自動調整大小**

如果您希望文字方塊或形狀無論文字如何變化都保持原始尺寸，必須使用 **Do not Autofit** 功能。要指定此設定，請將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat) 類別的 `AutofitType` 屬性設為 `None`。

![PowerPoint 中的「不自動調整大小」設定](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

當文字長度超過方框時，文字會溢出。

## **文字溢位時縮小文字**

如果文字長度超過方框，透過 **Shrink text on overflow** 功能，您可以指定將文字的大小與間距縮小，使其適合方框。要指定此設定，請將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat) 類別的 `AutofitType` 屬性設為 `Normal`。

![PowerPoint 中的「文字溢位時縮小文字」設定](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 功能時，僅在文字長度超過方框時才會套用此設定。
{{% /alert %}}

## **在形狀中換行文字**

如果您希望文字在寬度超出形狀邊界時能自動換行，就必須使用 **Wrap text in shape** 參數。要指定此設定，請將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat) 類別的 `WrapText` 屬性設為 `NullableBool.True`。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
如果將形狀的 `WrapText` 屬性設為 `NullableBool.False`，當文字長度超過形狀寬度時，文字會在同一行延伸超出形狀邊界。
{{% /alert %}}

## **常見問題**

**文字框的內部邊距會影響 AutoFit 嗎？**

是的。內部留白（Padding）會減少可用的文字區域，因此 AutoFit 會更早啟動——提前縮小字型或調整形狀尺寸。調整 AutoFit 前請先檢查並設定好邊距。

**AutoFit 與手動換行與軟換行如何互動？**

強制換行會保留下來，AutoFit 會根據這些換行點調整字型大小與間距。移除不必要的換行通常能減少 AutoFit 必須縮小文字的程度。

**變更主題字型或觸發字型替換會影響 AutoFit 結果嗎？**

會。替換為字型度量不同的字型會改變文字寬高，從而影響最終的字型大小與換行。任何字型變更或替換後，都應重新檢查投影片的顯示效果。