---
title: 在 .NET 簡報中取得段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/net/paragraph/
keywords:
- 段落邊界
- 文字片段邊界
- 段落座標
- 片段座標
- 段落大小
- 文字片段大小
- 文字框
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中取得段落與文字片段的邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概述**

本篇說明如何取得 Aspose.Slides 中段落與文字片段的界限、尺寸與座標。示範如何使用 `GetRect()` 取得 `TextFrame` 中段落的矩形、如何取得表格儲存格文字框內段落與片段的座標，並強調測量單位、換行對界限的影響、像素轉換以及實際段落格式值等重要細節。

## **取得 TextFrame 中段落與片段的座標**
使用 Aspose.Slides for .NET，開發人員現在可以取得 TextFrame 的段落集合中段落的矩形座標。也能取得段落內片段集合中片段的座標。此主題將透過範例說明如何取得段落的矩形座標以及段落內片段的位置。

## **取得段落的矩形座標**
已新增方法 **GetRect()**。它可取得段落的界限矩形。

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **取得表格儲存格 TextFrame 中段落與片段的尺寸與座標**

若要取得表格儲存格文字框中 [Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion) 或 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph) 的尺寸與座標，可使用 [IPortion.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/methods/getrect) 與 [IParagraph.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/methods/getrect) 方法。

以下範例程式碼示範上述操作：

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **常見問題**

**段落與文字片段的座標以什麼單位回傳？**

以點 (point) 為單位，1 吋 = 72 點。此單位適用於投影片上所有座標與尺寸。

**換行會影響段落的界限嗎？**

會。若在 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 中啟用 [wrapping](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/wraptext/)，文字會依區域寬度換行，從而改變段落的實際界限。

**段落座標能可靠地對應到匯出影像的像素嗎？**

能。可使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染/匯出時所選的 DPI。

**如何取得考慮樣式繼承後的「有效」段落格式參數？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/net/shape-effective-properties/)；它會回傳縮排、間距、換行、RTL 等最終合併的值。