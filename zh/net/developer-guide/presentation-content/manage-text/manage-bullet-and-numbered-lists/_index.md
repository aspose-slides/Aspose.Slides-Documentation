---
title: 在 .NET 中管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/net/manage-bullet-and-numbered-lists
keywords:
  - 项目符号
  - 项目符号列表
  - 编号列表
  - 符号项目符号
  - 图片项目符号
  - 自定义项目符号
  - 多级列表
  - 创建项目符号
  - 添加项目符号
  - 添加列表
  - PowerPoint
  - OpenDocument
  - 演示文稿
  - .NET
  - C#
  - Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中管理项目符号和编号列表。一步一步的指南。"
---

在 **Microsoft PowerPoint** 中，您可以像在 Word 和其他文本编辑器中一样创建项目符号和编号列表。**Aspose.Slides for .NET** 也允许您在演示文稿的幻灯片中使用项目符号和编号。 

## **为什么使用项目符号列表？**

项目符号列表帮助您快速高效地组织和呈现信息。 

**项目符号列表示例**

在大多数情况下，项目符号列表具有以下三大功能：

- 吸引读者或观众注意重要信息
- 使读者或观众能够轻松扫描关键点
- 高效地传达重要细节。

## **为什么使用编号列表？**

编号列表同样有助于组织和呈现信息。当条目的顺序（例如 *步骤 1，步骤 2* 等）重要或需要引用某条目（例如，*参见步骤 3*）时，最好使用数字（替代项目符号）。 

**编号列表示例**

下面是 **创建项目符号** 过程中的步骤摘要（步骤 1 到步骤 15）：

1. 创建 Presentation 类的实例。 
2. 执行多个任务（步骤 3 到步骤 14）。
3. 保存演示文稿。 

## **创建项目符号**

要创建项目符号列表，请按照以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) 对象访问幻灯片集合中的目标幻灯片（即您想要添加项目符号列表的幻灯片）。
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。
4. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。
5. 移除 [TextFrame]() 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 类创建第一个段落实例。
8. 将项目符号类型设置为 Symbol，然后设置项目符号字符。
9. 设置段落文本。
10. 设置段落缩进以确定项目符号位置。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 的段落集合中。
14. 添加第二个段落并重复步骤 7-12。
15. 保存演示文稿。

下面的 C# 示例代码实现了上述步骤，演示了如何在幻灯片中创建项目符号列表：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ……
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **创建图片项目符号**

Aspose.Slides for .NET 允许您更改项目符号列表中的项目符号。您可以将项目符号替换为自定义符号或图像。如果您想为列表增添视觉趣味或进一步突出列表项，可以使用自己的图像作为项目符号。 

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规的项目符号，建议选择具有透明背景的简洁图形图像。这类图像最适合作为自定义项目符号。 

无论如何，所选图像都会被缩小到很小的尺寸，因此我们强烈建议您选择在列表中作为项目符号替代时仍然清晰的图像。 

{{% /alert %}} 

要创建图片项目符号，请按照以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) 对象访问幻灯片集合中的目标幻灯片。
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。
4. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。
5. 移除 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 类创建第一个段落实例。
7. 从磁盘加载图像并将其添加到 [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images)，然后使用从 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) 方法返回的 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 实例。
8. 将项目符号类型设置为 Picture，然后设置图像。
9. 设置段落文本。
10. 设置段落缩进以确定项目符号位置。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 的段落集合中。
14. 添加第二个段落并重复步骤 7-13。
15. 保存演示文稿。

下面的 C# 代码演示了如何在幻灯片中创建图片项目符号：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **创建多级项目符号**

要创建包含不同层级项目的项目符号列表（主列表下的子列表），请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) 对象访问幻灯片集合中的目标幻灯片。
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。
4. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。
5. 移除 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 中的默认段落。
6. 使用 [Paragraph] 类创建第一个段落实例，并将深度设置为 0。
7. 使用 Paragraph 类创建第二个段落实例，并将深度设置为 1。
8. 使用 Paragraph 类创建第三个段落实例，并将深度设置为 2。
9. 使用 Paragraph 类创建第四个段落实例，并将深度设置为 3。
10. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 的段落集合中。
11. 保存演示文稿。

以下代码实现了上述步骤，演示了如何在 C# 中创建多级项目符号列表：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **创建编号**

下面的 C# 代码演示了如何在幻灯片中创建编号列表：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**使用 Aspose.Slides 创建的项目符号和编号列表能导出为 PDF 或图像等其他格式吗？**

是的，Aspose.Slides 在将演示文稿导出为 PDF、图像等格式时，完全保留项目符号和编号列表的格式和结构，确保结果一致。

**是否可以从现有演示文稿中导入项目符号或编号列表？**

是的，Aspose.Slides 允许您从现有演示文稿中导入并编辑项目符号或编号列表，同时保留其原始的格式和外观。

**Aspose.Slides 是否支持在多语言创建的演示文稿中使用项目符号和编号列表？**

是的，Aspose.Slides 完全支持多语言演示文稿，您可以使用任何语言创建项目符号和编号列表，包括特殊或非拉丁字符。