---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/net/examples/elements/text-box/
keywords:
- 文字方塊
- 新增文字方塊
- 存取文字方塊
- 移除文字方塊
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中操作文字方塊：使用 C# 為 PPT、PPTX 與 ODP 簡報新增、格式化、對齊、換行、自動調整大小和樣式設定文字。"
---
在 Aspose.Slides 中，**文字方塊** 由 `AutoShape` 代表。幾乎所有形狀都可以包含文字，但一般的文字方塊沒有填滿或邊框，只顯示文字。

本指南說明如何以程式方式新增、存取與移除文字方塊。

## **新增文字方塊**

文字方塊僅是沒有填滿或邊框且包含格式化文字的 `AutoShape`。以下說明如何建立：

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 建立一個矩形形狀（預設為填滿且有邊框且沒有文字）。
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // 移除填滿與邊框，使其看起來像一般的文字方塊。
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // 設定文字格式。
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // 指定實際的文字內容。
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **注意：** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作為文字方塊使用。

## **依內容存取文字方塊**

若要找出所有包含特定關鍵字（例如「Slide」）的文字方塊，請遍歷形狀並檢查其文字：

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // 只有 AutoShape 可以包含可編輯的文字。
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // 對符合的文字方塊執行某些操作。
            }
        }
    }
}
```

## **依內容移除文字方塊**

此範例會找出並刪除第一張投影片中所有包含特定關鍵字的文字方塊：

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **提示：** 在迭代時修改形狀集合前，務必先建立其副本，以避免集合修改錯誤。