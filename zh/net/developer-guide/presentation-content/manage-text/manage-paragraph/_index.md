---
title: 在 .NET 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 创建和格式化段落、部分、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for .NET 将文本表示为文本框、段落和部分的层次结构：

* [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 表示文本框中的一个段落，并提供对其部分以及段落级格式的访问。
* [IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/) 表示段落中的一个文本运行。每个部分可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个部分来包含不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **使用多个部分创建段落**

以下步骤创建一个包含三个段落、每个段落有三个部分的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。
5. 使用默认段落并向文本框再添加两个 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 对象。
6. 为每个段落添加足够的 [IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/) 对象以容纳三部分。默认段落已经包含一个空的部分。
7. 设置每个部分的文本。
8. 通过 [IPortion.PortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/portionformat/) 应用字符级格式。
9. 保存修改后的演示文稿。

以下 C# 示例实现了上述步骤：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **创建项目符号和编号列表**

### **创建项目符号或编号列表**

项目符号和编号使相关项目更易于浏览。在 Aspose.Slides 中，列表设置通过 [IBulletFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/) 定义。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向选定的幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/)。
7. 将 [IBulletFormat.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/type/) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/net/aspose.slides/bullettype/) 并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落并将 [IBulletFormat.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/type/) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/net/aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

以下 C# 示例创建了符号项目符号和编号项目符号：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **使用图片项目符号**

图片项目符号允许使用自定义图像代替符号或数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 并访问其 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/) 并设置其文本。
7. 将 [IBulletFormat.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/type/) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/net/aspose.slides/bullettype/)。
8. 通过 [IBulletFormat.Picture](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/picture/) 指定图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

以下 C# 示例创建了图片项目符号：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **创建多级列表**

将 [IParagraphFormat.Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/depth/) 设置为在列表的不同层级放置段落。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [IParagraphFormat.Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/depth/) 值分别设为 `0`、`1`、`2`、`3`。
5. 将段落添加到文本框并保存演示文稿。

以下 C# 示例创建了四级项目符号列表：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **自定义编号列表起始值**

使用 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 设置编号段落的起始数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 并向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 将对应段落的 [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 分别设为 `2`、`3`、`7`。
5. 将段落添加到文本框并保存演示文稿。

以下 C# 示例为每个段落分配自定义起始编号：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **控制段落布局和结束属性**

### **设置首行缩进**

使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 属性控制段落的首行缩进。该属性仅移动首行相对于段落左边距的位置。正值将首行向右移动，而其余行保持与段落正文对齐。

当需要整体移动段落时使用 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginleft/)。仅需移动首行时使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/)。

下面的示例创建多个段落并对不同的 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 值进行演示，以展示首行缩进对段落布局的影响。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 并移除默认段落。
5. 创建若干段落并为它们设置不同的 [Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

以下代码展示了如何设置段落缩进：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

效果如下：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，其中首行位于其余行的左侧。在 Aspose.Slides 中，可通过 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 属性实现。将 `Indent` 设置为负值即可使首行相对于段落正文向左移动。

实际使用中，[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginleft/) 定义段落正文的左侧位置，而 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 定义首行相对于该左侧的偏移。要创建悬挂缩进，请为 `MarginLeft` 设置正值并为 `Indent` 设置负值。

此格式常用于参考文献、书目、词汇表条目等，需要换行后对齐到段落正文而非首行首字符的场景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 并移除默认段落。
5. 为每个段落创建并设置正的 [MarginLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginleft/) 值。
6. 将负的 [Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 值应用于段落，以实现悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

以下代码展示了如何为段落设置悬挂缩进：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

效果如下：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落结束运行属性**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/endparagraphportionformat/) 属性控制段落结束标记的格式。以下示例为第二个段落的结束标记分配字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 并清除其默认段落。
3. 创建两个段落并向它们添加文本部分。
4. 为第二个段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/portionformat/)。
5. 设置 [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/fontheight/) 和 [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/latinfont/)。
6. 将该格式分配给 [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/endparagraphportionformat/) 并保存演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphcollection/addfromhtml/) 将 HTML 标记转换为文本框中的段落和部分。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 访问一张幻灯片并添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphcollection/addfromhtml/)。
6. 保存修改后的演示文稿。

以下 C# 示例将 HTML 导入文本框：

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **将段落文本导出为 HTML**

使用 [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphcollection/exporttohtml/) 将选定范围的段落导出为 HTML。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。
4. 调用 [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphcollection/exporttohtml/) 并提供起始段落索引和要导出的段落数。
5. 将返回的 HTML 字符串写入文件。

以下 C# 示例导出第一个文本形状中的所有段落：

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **将段落渲染为图像**

[IParagraph.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getimage/) 可直接渲染单个段落并返回一个 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)。使用 [IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/) 将结果保存到文件或流。无需渲染包含的形状或手动裁剪位图。

如果段落在其父集合中未找到、没有有效的渲染边界，或无法渲染，则 [IParagraph.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getimage/) 可能返回 `null`。保存前请检查返回值，并在使用后释放图像。

#### **以默认比例渲染段落**

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一形状是一个包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

以下示例在默认比例下渲染第二个段落，并以 PNG 格式保存返回的图像。`using` 声明可确保图像被正确释放。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

结果如下：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中渲染段落并进行缩放**

使用接受 `float scaleX` 和 `float scaleY` 参数的 [IParagraph.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getimage/) 重载，可设置水平和垂直缩放因子。下面的示例创建一个表格，在其第一个单元格中以两倍默认宽高渲染段落，并将结果保存为 PNG 图像。

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

`scale` 为 `1` 时保持该轴的默认像素大小。例如，两个因子均为 `2` 时，图像的宽高约为默认尺寸的两倍，像素数约为四倍。较大的因子通常可在放大或高分辨率输出时获得更锐利的文本，但也会增加内存使用和文件大小。因子小于 `1` 会生成更小、细节更少的图像。使用相同的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

在需要包含形状填充、边框或其他可视上下文时，使用 [IShape.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/getimage/) 渲染整个形状仍然有价值。若只需段落图像，请使用 [IParagraph.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getimage/)。

## **常见问题**

**我可以完全禁用文本框内的换行吗？**

可以。将 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/wraptext/) 设置为 false 可禁用换行，使行不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [IParagraph.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/getrect/) 获取段落的边界矩形。[IPortion.GetRect](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/getrect/) 可获取单个部分的边界。

**段落对齐（左、右、居中或两端对齐）在哪里控制？**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/alignment/) 是段落级设置，适用于整个段落，而不受单独部分格式的影响。

**我可以为段落的一部分设置校对语言吗？**

可以。为单独的部分设置 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/languageid/)，这样一个段落可以包含多种语言的文本。