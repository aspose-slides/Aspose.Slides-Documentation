---
title: 超链接
type: docs
weight: 130
url: /zh/net/examples/elements/hyperlink/
keywords:
- 超链接示例
- 添加超链接
- 访问超链接
- 删除超链接
- 更新超链接
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 和 Aspose.Slides 添加、编辑和删除超链接：链接文本、形状、幻灯片、URL 和电子邮件；为 PPT、PPTX 和 ODP 设置目标和操作。"
---

演示如何在形状上添加、访问、删除和更新超链接，使用 **Aspose.Slides for .NET**。

## 添加超链接

创建一个带有指向外部网站的超链接的矩形形状。
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## 访问超链接

读取形状文本部分的超链接信息。
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## 删除超链接

清除形状文本中的超链接。
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## 更新超链接

更改现有超链接的目标。使用 `HyperlinkManager` 修改已包含超链接的文本，这模拟了 PowerPoint 安全更新超链接的方式。
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // 在现有文本中更改超链接应通过
    // 使用 HyperlinkManager 而不是直接设置属性。
    // 这模拟了 PowerPoint 安全更新超链接的方式。
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
