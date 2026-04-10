---
title: 在 .NET 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/net/manage-paragraph/
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
description: "使用 Aspose.Slides for .NET 精通段落格式——在 C# 中优化 PPT、PPTX 和 ODP 演示文稿的对齐、间距和样式。"
---
Aspose.Slides 提供了在 C# 中处理 PowerPoint 文本、段落和部分所需的所有接口和类。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 接口，以便向其中添加表示段落的对象。`ITextFame` 对象可以拥有一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 接口，以便向其中添加表示部分的对象。`IParagraph` 对象可以拥有一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/) 接口，以便向其中添加表示文本及其格式属性的对象。

`IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤展示了如何添加一个包含 3 个段落且每个段落包含 3 个部分的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 获取与该 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 对象并将其添加到 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 的 `IParagraphs` 集合中。
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/) 对象（默认段落创建两个 Portion 对象），并将每个 `IPortion` 对象添加到相应 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `IPortion` 对象公开的格式属性为每个部分应用首选的格式功能。
9. 保存修改后的演示文稿。

```c#
// 实例化一个表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 添加一个矩形 IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // 访问 AutoShape 的 TextFrame
    ITextFrame tf = ashp.TextFrame;

    // 创建具有不同文本格式的段落和部分
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // 保存修改后的演示文稿
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **管理段落项目符号**
项目符号列表帮助您快速高效地组织和呈现信息。带项目符号的段落始终更易阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向选定的幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将段落的项目符号 `Type` 设置为 `Symbol` 并设置项目符号字符。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 为项目符号设置颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落并重复步骤 7 到 13 的过程。
15. 保存演示文稿。

```c#
// 实例化一个表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];


    // 添加并访问 Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问 autoshape 的文本框
    ITextFrame txtFrm = aShp.TextFrame;

    // 删除默认段落
    txtFrm.Paragraphs.RemoveAt(0);

    // 创建段落
    Paragraph para = new Paragraph();

    // 设置段落项目符号样式和符号
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 设置段落文本
    para.Text = "Welcome to Aspose.Slides";

    // 设置项目符号缩进
    para.ParagraphFormat.Indent = 25;

    // 设置项目符号颜色
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    // 设置项目符号高度
    para.ParagraphFormat.Bullet.Height = 100;

    // 将段落添加到文本框
    txtFrm.Paragraphs.Add(para);

    // 创建第二段落
    Paragraph para2 = new Paragraph();

    // 设置段落项目符号类型和样式
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // 添加段落文本
    para2.Text = "This is numbered bullet";

    // 设置项目符号缩进
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    // 设置项目符号高度
    para2.ParagraphFormat.Bullet.Height = 100;

    // 将段落添加到文本框
    txtFrm.Paragraphs.Add(para2);


    // 保存修改后的演示文稿
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **管理图片项目符号**
项目符号列表帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 并设置图像。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 为项目符号设置颜色。
12. 为项目符号设置高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落并根据前面的步骤重复过程。
15. 保存修改后的演示文稿。

```c#
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation presentation = new Presentation();

// 访问第一张幻灯片
ISlide slide = presentation.Slides[0];

// 实例化用于项目符号的图像
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// 添加并访问 Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// 访问 autoshape 的文本框
ITextFrame textFrame = autoShape.TextFrame;

// 删除默认段落
textFrame.Paragraphs.RemoveAt(0);

// 创建新的段落
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// 设置段落项目符号样式和图像
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 设置项目符号高度
paragraph.ParagraphFormat.Bullet.Height = 100;

// 将段落添加到文本框
textFrame.Paragraphs.Add(paragraph);

// 将演示文稿写入为 PPTX 文件
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// 将演示文稿写入为 PPT 文件
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **管理多级项目符号**
项目符号列表帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation)class 的实例。
2. 通过索引访问相应幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/) 类创建第一个段落实例并将深度设置为 0。
7. 使用 `Paragraph` 类创建第二个段落实例并将深度设置为 1。
8. 使用 `Paragraph` 类创建第三个段落实例并将深度设置为 2。
9. 使用 `Paragraph` 类创建第四个段落实例并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

```c#
// 实例化一个表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问创建的 autoshape 的文本框
    ITextFrame text = aShp.AddTextFrame("");
    
    // 清除默认段落
    text.Paragraphs.Clear();

    // 添加第一段落
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para1.ParagraphFormat.Depth = 0;

    // 添加第二段落
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para2.ParagraphFormat.Depth = 1;

    // 添加第三段落
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para3.ParagraphFormat.Depth = 2;

    // 添加第四段落
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para4.ParagraphFormat.Depth = 3;

    // 将段落添加到集合中
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // 将演示文稿写入为 PPTX 文件
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **管理具有自定义编号列表的段落**
[IBulletFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/numberedbulletstartwith) 属性等，允许您管理具有自定义编号或格式的段落。

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation)class 的实例。
2. 访问包含该段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/) 类创建第一个段落实例并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/net/aspose.slides/ibulletformat/numberedbulletstartwith) 设置为 2。
7. 使用 `Paragraph` 类创建第二个段落实例并将 `NumberedBulletStartWith` 设置为 3。
8. 使用 `Paragraph` 类创建第三个段落实例并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 访问创建的 autoshape 的文本框
	ITextFrame textFrame = shape.TextFrame;

	// 删除默认存在的段落
	textFrame.Paragraphs.RemoveAt(0);

	// 第一个列表
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **为段落设置首行缩进**

使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 属性控制段落的首行缩进。此属性仅移动相对于段落左边距的第一行。正值会将首行向右移动，而其余行保持与段落主体对齐。

需要移动整个段落时使用 [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginleft/)。仅需移动首行时使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/)。

下面的示例创建了多个段落，并对它们应用不同的 `Indent` 值，以演示首行缩进如何影响段落布局。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/)。
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/) 并删除默认段落。
5. 创建多个段落并为它们设置不同的 [Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 值。
6. 将段落添加到文本框中。
7. 保存修改后的演示文稿。

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

结果：

![段落的首行缩进](first_line_indent.png)

## **为段落设置悬挂缩进**

悬挂缩进是一种段落布局，第一行位于其余行的左侧。 在 Aspose.Slides 中，您可以使用 [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 属性实现此效果。 将 `Indent` 设置为负值即可将第一行相对于段落正文向左移动。

实际操作中， [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginleft/) 定义段落正文的左侧位置， [IParagraphFormat.Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 定义第一行相对于该左侧边距的位置。 要创建悬挂缩进，需将正的 `MarginLeft` 值与负的 `Indent` 值结合使用。

此格式在参考文献、词汇表条目以及其他需要换行后行对齐到段落正文而不是首行字符的段落中非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/)。
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/) 并删除默认段落。
5. 为每个段落创建并设置正的 [MarginLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginleft/) 值。
6. 设置负的 [Indent](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/indent/) 值以实现悬挂缩进效果。
7. 将段落添加到文本框中。
8. 保存修改后的演示文稿。

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

结果：

![段落的悬挂缩进](hanging_indent.png)

## **管理段落结束运行属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。  
2. 获取包含该段落的幻灯片的引用（通过其位置）。  
3. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/)。  
4. 向矩形添加一个带有两个段落的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/)。  
5. 为段落设置 `FontHeight` 和字体类型。  
6. 为段落设置 End 属性。  
7. 将修改后的演示文稿写入为 PPTX 文件。

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **将 HTML 文本导入段落**
Aspose.Slides 提供了将 HTML 文本导入段落的增强支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/)。
4. 添加并访问 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。
5. 删除 `ITextFrame` 中的默认段落。
6. 在 TextReader 中读取源 HTML 文件。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphcollection/)。
9. 保存修改后的演示文稿。

```c#
// 创建空的演示文稿实例
using (Presentation pres = new Presentation())
{
    // 访问演示文稿的默认第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 添加 AutoShape 用于放置 HTML 内容
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // 向形状添加文本框
    ashape.AddTextFrame("");

    // 清除已添加文本框中的所有段落
    ashape.TextFrame.Paragraphs.Clear();

    // 使用流读取器加载 HTML 文件
    TextReader tr = new StreamReader("file.html");

    // 将 HTML 流读取器中的文本添加到文本框中
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // 保存演示文稿
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **将段落文本导出为 HTML**
Aspose.Slides 提供了将段落中的文本导出为 HTML 的增强支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例并加载所需的演示文稿。
2. 通过索引访问相应幻灯片的引用。
3. 访问包含要导出为 HTML 的文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/)。
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您选择的段落。

```c#
// 加载演示文稿文件
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // 访问演示文稿的默认第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 访问所需的索引
    int index = 0;

    // 访问添加的形状
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // 通过指定段落起始索引和要复制的段落数量，将段落数据写入 HTML
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **将段落保存为图像**

本节将展示两个示例，演示如何将由 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 接口表示的文本段落保存为图像。两个示例都包括使用 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 接口的 `GetImage` 方法获取包含段落的形状图像、计算段落在形状内的边界，并将其导出为位图图像。这些方法可帮助您从 PowerPoint 演示文稿中提取特定文本部分并将其保存为单独的图像，适用于各种后续使用场景。

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

**示例 1**

在本示例中，我们获取第二段落的图像。为此，我们首先从演示文稿的第一张幻灯片中提取形状图像，然后计算该形状文本框中第二段落的边界。随后将段落重新绘制到新的位图图像中，并以 PNG 格式保存。此方法在需要将特定段落单独保存为图像且保持文本的精确尺寸和格式时非常有用。

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// 将形状保存为内存中的位图。
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// 创建内存中的形状位图。
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// 计算第二段落的边界。
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// 计算输出图像的尺寸（最小尺寸 - 1x1 像素）。
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 为段落准备位图。
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// 将段落从形状位图重新绘制到段落位图。
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

结果：

![段落图像](paragraph_to_image_output.png)

**示例 2**

本示例在前述方法的基础上加入了缩放因子。我们从演示文稿中提取形状并以 `2` 倍缩放因子保存为图像，从而在导出段落时获得更高分辨率的输出。随后在考虑缩放的情况下计算段落边界。缩放在需要更精细图像（例如用于高质量印刷材料）时尤为有用。

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// 将形状以缩放方式保存为内存中的位图。
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// 从内存中创建形状位图。
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// 计算第二段落的边界。
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// 计算输出图像的尺寸（最小尺寸 - 1x1 像素）。
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 为段落准备位图。
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// 将段落从形状位图重新绘制到段落位图。
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**我可以完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置 ([WrapText](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat/wraptext/)) 将换行关闭，行就不会在框边缘换行。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个部分）的边界矩形，以了解其在幻灯片上的确切位置和尺寸。

**段落对齐（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphformat/alignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphformat/) 级别的设置，适用于整个段落，而不受单独部分格式的影响。

**我能为段落的某一部分（例如一个词）单独设置拼写检查语言吗？**

可以。语言在部分级别设置 ([PortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/languageid/))，因此一个段落中可以共存多种语言。