---
title: 超連結
type: docs
weight: 130
url: /zh-hant/net/examples/elements/hyperlink/
keywords:
- 超連結
- 新增超連結
- 存取超連結
- 移除超連結
- 更新超連結
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中新增與管理超連結：連結文字、形狀與影像，為 PPT、PPTX 與 ODP 設定目標與動作，提供 C# 範例。"
---
本文示範如何在形狀上使用 **Aspose.Slides for .NET** 添加、存取、移除和更新超連結。

## **新增超連結**

建立一個矩形形狀，並將超連結指向外部網站。

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **存取超連結**

從形狀的文字部分讀取超連結資訊。

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **移除超連結**

從形狀的文字中清除超連結。

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **更新超連結**

變更現有超連結的目標。使用 `HyperlinkManager` 來修改已包含超連結的文字，模擬 PowerPoint 安全更新超連結的方式。

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // 在現有文字中變更超連結應該透過
    // 使用 HyperlinkManager 而不是直接設定屬性。
    // 這模擬了 PowerPoint 安全更新超連結的方式。
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```