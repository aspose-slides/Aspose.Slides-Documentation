---
title: 在 .NET 中管理演示文稿的项目符号和编号列表
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

在 **Microsoft PowerPoint** 中，您可以像在 Word 和其他文本编辑器中一样创建项目符号和编号列表。**Aspose.Slides for .NET** 也支持在演示文稿的幻灯片中使用项目符号和编号。

## **为什么使用项目符号列表？**

项目符号列表帮助您快速高效地组织和呈现信息。

**项目符号列表示例**

在大多数情况下，项目符号列表具备以下三大功能：

- 将读者或观众的注意力引向重要信息
- 让读者或观众轻松扫描关键点
- 高效传达和交付重要细节。

## **为什么使用编号列表？**

编号列表同样有助于组织和呈现信息。当条目的顺序（例如 *第 1 步，第 2 步* 等）很重要，或需要引用某条目（例如 *见第 3 步*）时，最好使用编号而不是项目符号。

**编号列表示例**

以下是 **创建项目符号** 过程中的步骤摘要（第 1 步至第 15 步）：

1. 创建 Presentation 类的实例。 
2. 执行多个任务（第 3 步至第 14 步）。 
3. 保存演示文稿。 

## **创建项目符号**

通过以下步骤创建项目符号列表：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。 
2. 通过 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) 对象访问幻灯片集合中的目标幻灯片。 
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。 
4. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。 
5. 删除 [TextFrame]() 中的默认段落。 
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 类创建第一个段落实例。 
8. 将项目符号类型设为 Symbol 并设置项目符号字符。 
9. 设置段落文本。 
10. 设置段落缩进以显示项目符号。 
11. 设置项目符号的颜色。 
12. 设置项目符号的高度。 
13. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 的段落集合中。 
14. 添加第二个段落并重复步骤 7‑12。 
15. 保存演示文稿。

以下 C# 示例代码实现了上述步骤，演示如何在幻灯片中创建项目符号列表：
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
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **创建图片项目符号**

Aspose.Slides for .NET 允许您更改项目符号列表的项目符号。您可以用自定义符号或图片替代项目符号。如果想为列表增添视觉趣味或进一步吸引注意力，可以使用自己的图片作为项目符号。

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规项目符号，请选择具有透明背景的简洁图形图片。这类图片最适合作为自定义项目符号。 

无论如何，所选图片会被缩小到非常小的尺寸，因此强烈建议您选择在列表中作为项目符号替代品时仍然清晰可辨的图片。 

{{% /alert %}} 

创建图片项目符号的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。 
2. 使用 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) 对象访问幻灯片集合中的目标幻灯片。 
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。 
4. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。 
5. 删除 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 中的默认段落。 
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 类创建第一个段落实例。 
7. 从磁盘加载图片并将其添加到 [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images)，然后使用从 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) 方法返回的 [IPPImage] 实例。 
8. 将项目符号类型设为 Picture 并设置图片。 
9. 设置段落文本。 
10. 设置段落缩进以显示项目符号。 
11. 设置项目符号的颜色。 
12. 设置项目符号的高度。 
13. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 的段落集合中。 
14. 添加第二个段落并重复步骤 7‑13。 
15. 保存演示文稿。

以下 C# 代码演示如何在幻灯片中创建图片项目符号：
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

要创建包含不同层级项目的项目符号列表（即在主项目符号列表下的子列表），请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。 
2. 使用 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) 对象访问幻灯片集合中的目标幻灯片。 
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。 
4. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。 
5. 删除 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 中的默认段落。 
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) 类创建第一个段落实例，深度设为 0。 
7. 使用 Paragraph 类创建第二个段落实例，深度设为 1。 
8. 使用 Paragraph 类创建第三个段落实例，深度设为 2。 
9. 使用 Paragraph 类创建第四个段落实例，深度设为 3。 
10. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) 的段落集合中。 
11. 保存演示文稿。

下面的代码实现了上述步骤，展示了如何在 C# 中创建多级项目符号列表：
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


## **创建编号列表**

以下 C# 代码展示了如何在幻灯片中创建编号列表：
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

**使用 Aspose.Slides 创建的项目符号和编号列表可以导出为 PDF 或图像等其他格式吗？**

可以，Aspose.Slides 在将演示文稿导出为 PDF、图像等格式时，完全保留项目符号和编号列表的格式和结构，确保结果一致。

**是否可以从已有的演示文稿中导入项目符号或编号列表？**

可以，Aspose.Slides 允许您导入并编辑现有演示文稿中的项目符号或编号列表，并保留其原始格式和外观。

**Aspose.Slides 是否支持多语言演示文稿中的项目符号和编号列表？**

可以，Aspose.Slides 完全支持多语言演示文稿，您可以使用任何语言（包括特殊字符或非拉丁字符）创建项目符号和编号列表。