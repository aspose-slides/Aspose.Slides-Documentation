---
title: 從 .NET 簡報取得段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/net/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中取得段落邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概觀**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小與座標。它展示了如何使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/getrect/) 從 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 取得段落矩形，如何取得表格儲存格文字框內的段落座標，並強調了測量單位、文字換行對邊界的影響、像素轉換以及有效段落格式化值等重要細節。

## **取得段落的矩形座標**

使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/getrect/) 取得段落的邊界矩形。

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **取得表格儲存格文字框內段落的大小**

若要取得表格儲存格文字框中 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/) 的大小與座標，請使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/getrect/)。回傳的矩形是相對於表格儲存格文字框的，所以在需要幻燈片層級座標時，需加入表格位置與儲存格偏移量。

以下範例取得表格儲存格內段落的邊界，並在幻燈片上繪製矩形以視覺化這些邊界：

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **常見問題**

**段落座標以什麼單位度量？**

它們以點（point）為單位，1 英吋等於 72 點。此單位適用於幻燈片上所有座標與尺寸。

**換行會影響段落的邊界嗎？**

會。若在 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 上啟用 [TextFrameFormat.WrapText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/wraptext/)，文字會依區域寬度斷行，從而改變段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染或匯出時選擇的 DPI。

**如何取得考慮樣式繼承的「有效」段落格式參數？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/net/shape-effective-properties/)。它會回傳縮排、間距、換行、RTL 等最終合併的值。