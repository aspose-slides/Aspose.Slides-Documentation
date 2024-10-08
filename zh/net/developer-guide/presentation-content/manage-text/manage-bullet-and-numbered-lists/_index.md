---
title: 管理项目符号和编号列表
type: docs
weight: 70
url: /net/manage-bullet-and-numbered-lists
keywords: "项目符号, 项目符号列表, 数字, 编号列表, 图片项目符号, 多级项目符号, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在C#或.NET中创建PowerPoint演示文稿中的项目符号和编号列表"
---

在**Microsoft PowerPoint**中，您可以像在Word和其他文本编辑器中一样创建项目符号和编号列表。**Aspose.Slides for .NET**也允许您在演示文稿的幻灯片中使用项目符号和编号。

### 为什么使用项目符号列表？

项目符号列表帮助您快速有效地组织和呈现信息。

**项目符号列表示例**

在大多数情况下，项目符号列表有以下三个主要功能：

- 吸引读者或观众注意重要信息
- 便于读者或观众快速查找要点
- 有效传达和传递重要细节。

### 为什么使用编号列表？

编号列表同样有助于组织和呈现信息。理想情况下，当条目的顺序（例如，*步骤 1，步骤 2*等）很重要时，或者当需要引用某个条目（例如，*参见步骤 3*）时，应使用数字（而不是项目符号）。

**编号列表示例**

以下是**创建项目符号**过程中的步骤（步骤 1 到步骤 15）的摘要：

1. 创建演示文稿类的实例。
2. 执行多个任务（步骤 3 到步骤 14）。
3. 保存演示文稿。

## 创建项目符号

要创建项目符号列表，请按照以下步骤：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 通过[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)对象访问幻灯片（您要在其中添加项目符号列表）。
3. 在选定的幻灯片中添加一个[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。
4. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。
5. 删除[TextFrame]()中的默认段落。
6. 使用[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)类创建第一个段落实例。
8. 设置项目符号类型为符号，然后设置项目符号字符。
9. 设置段落文本。
10. 设置段落缩进以设置项目符号。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将创建的段落添加到[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)段落集合中。
14. 添加第二个段落并重复步骤7-12。
15. 保存演示文稿。

以下C#示例代码——是上述步骤的实现——展示了如何在幻灯片中创建项目符号列表：

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
    paragraph.Text = "我的文本";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## 创建图片项目符号

Aspose.Slides for .NET允许您更改项目符号列表上的项目符号。您可以用自定义符号或图像替换项目符号。如果您想为列表增添视觉趣味，或者更引起对列表中条目的关注，您可以使用您自己的图像作为项目符号。

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规项目符号，您可能想选择一个带透明背景的简单图形图像。这类图像作为自定义项目符号效果最好。

无论如何，您选择的图像将被缩小到非常小的尺寸，因此我们强烈建议您选择在列表中看起来不错的图像（作为项目符号的替代品）。

{{% /alert %}} 

要创建图片项目符号，请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 使用[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)对象访问幻灯片集合中的所需幻灯片。
3. 在所选幻灯片中添加一个[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。
4. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。
5. 删除[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)中的默认段落。
6. 使用[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)类创建第一个段落实例。
7. 从磁盘加载图像并将其添加到[Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images)，然后使用[AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index)方法返回的[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)实例。
8. 设置项目符号类型为图片，然后设置图像。
9. 设置段落文本。
10. 设置段落缩进以设置项目符号。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将创建的段落添加到[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)段落集合中。
14. 添加第二个段落并重复步骤7-13。
15. 保存演示文稿。

以下C#代码展示了如何在幻灯片中创建图片项目符号：

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
    paragraph.Text = "我的文本";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## 创建多级项目符号

要创建一个包含不同级别项目的项目符号列表——即在主项目符号列表下的附加列表——请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 使用[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)对象访问幻灯片集合中的所需幻灯片。
3. 在所选幻灯片中添加一个[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)。
4. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)。
5. 删除[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)中的默认段落。
6. 使用[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)类创建第一个段落实例，深度设置为0。
7. 使用Paragraph类创建第二个段落实例，深度设置为1。
8. 使用Paragraph类创建第三个段落实例，深度设置为2。
9. 使用Paragraph类创建第四个段落实例，深度设置为3。
10. 将创建的段落添加到[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)段落集合中。
11. 保存演示文稿。

以下代码是上述步骤的实现，展示了如何在C#中创建多级项目符号列表：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "我的文本 深度 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "我的文本 深度 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "我的文本 深度 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "我的文本 深度 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## 创建数字

以下C#代码展示了如何在幻灯片中创建编号列表：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "我的文本 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "我的文本 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```