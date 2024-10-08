---
title: 管理 C# 中的 PowerPoint 段落
type: docs
weight: 40
url: /net/manage-paragraph/
keywords: 
- 添加段落
- 管理段落
- 段落缩进
- 段落属性
- HTML 文本
- 导出段落文本
- PowerPoint 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中创建和管理 PowerPoint 演示文稿中的段落、文本、缩进和属性"
---

Aspose.Slides 提供了您在 C# 中处理 PowerPoint 文本、段落和部分所需的所有接口和类。

* Aspose.Slides 提供 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 接口，使您能够添加表示段落的对象。一个 `ITextFrame` 对象可以包含一个或多个段落（每个段落通过换行符创建）。
* Aspose.Slides 提供 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 接口，使您能够添加表示部分的对象。一个 `IParagraph` 对象可以包含一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 接口，使您能够添加表示文本及其格式属性的对象。

一个 `IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加多个包含多个部分的段落**

以下步骤展示了如何添加一个包含 3 个段落的文本框，每个段落包含 3 个部分：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 相关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 对象并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 的 `IParagraphs` 集合中。
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 对象（默认段落两个部分对象）并将每个 `IPortion` 对象添加到每个 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `IPortion` 对象公开的格式属性为每个部分应用首选格式特征。
9. 保存修改后的演示文稿。

此 C# 代码是添加包含部分的段落的步骤实现：

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{
    // Accesses the first slide
    ISlide slide = pres.Slides[0];

    // Adds a Rectangle IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accesses the AutoShape TextFrame
    ITextFrame tf = ashp.TextFrame;

    // Creates Paragraphs and Portions with different text formats
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
    // Saves the modified presentation
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **管理段落项目符号**
项目符号列表帮助您快速有效地组织和呈现信息。带项目符号的段落通常更容易阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向选定幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。 
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 为段落设置项目符号的 `Type` 为 `Symbol`，并设置项目符号字符。
8. 设置段落 `Text`。
9. 为项目符号设置段落 `Indent`。
10. 为项目符号设置颜色。
11. 设置项目符号的高度。
12. 将新段落添加到 `TextFrame` 的段落集合中。
13. 添加第二个段落，重复步骤 7 到 13 中给出的过程。
14. 保存演示文稿。

此 C# 代码展示了如何添加段落项目符号：

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide slide = pres.Slides[0];


    // Adds and accesses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the autoshape text frame
    ITextFrame txtFrm = aShp.TextFrame;

    // Removes the default paragraph
    txtFrm.Paragraphs.RemoveAt(0);

    // Creates a paragraph
    Paragraph para = new Paragraph();

    // Sets a paragraph bullet style and symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Sets a paragraph text
    para.Text = "欢迎使用 Aspose.Slides";

    // Sets bullet indent
    para.ParagraphFormat.Indent = 25;

    // Sets bullet color
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Sets Bullet Height
    para.ParagraphFormat.Bullet.Height = 100;

    // Adds Paragraph to text frame
    txtFrm.Paragraphs.Add(para);

    // Creates second paragraph
    Paragraph para2 = new Paragraph();

    // Sets paragraph bullet type and style
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Adds paragraph text
    para2.Text = "这是编号项目符号";

    // Sets bullet indent
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Sets Bullet Height
    para2.ParagraphFormat.Bullet.Height = 100;

    // Adds Paragraph to text frame
    txtFrm.Paragraphs.Add(para2);

    // Saves the modified presentation
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **管理图片项目符号**
项目符号列表帮助您快速有效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)，并设置图像。
9. 设置段落 `Text`。
10. 为项目符号设置段落 `Indent`。
11. 为项目符号设置颜色。
12. 为项目符号设置高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落并重复之前的步骤。
15. 保存修改后的演示文稿。

此 C# 代码展示了如何添加和管理图片项目符号：

```c#
// Instantiates a Presentation class that represents a PPTX file
Presentation presentation = new Presentation();

// Accesses the first slide
ISlide slide = presentation.Slides[0];

// Instantiates the image for bullets
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Adds and accesses Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accesses the autoshape textframe
ITextFrame textFrame = autoShape.TextFrame;

// Removes the default paragraph
textFrame.Paragraphs.RemoveAt(0);

// Creates a new paragraph
Paragraph paragraph = new Paragraph();
paragraph.Text = "欢迎使用 Aspose.Slides";

// Sets paragraph bullet style and image
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Sets bullet Height
paragraph.ParagraphFormat.Bullet.Height = 100;

// Adds paragraph to text frame
textFrame.Paragraphs.Add(paragraph);

// Writes the presentation as a PPTX file
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Writes the presentation as a PPT file
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **管理多级项目符号**
项目符号列表帮助您快速有效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

此 C# 代码展示了如何添加和管理多级项目符号：

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide slide = pres.Slides[0];
    
    // Adds and accesses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the text frame of created autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Clears the default paragraph
    text.Paragraphs.Clear();

    // Adds the first paragraph
    IParagraph para1 = new Paragraph();
    para1.Text = "内容";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para1.ParagraphFormat.Depth = 0;

    // Adds the second paragraph
    IParagraph para2 = new Paragraph();
    para2.Text = "第二级";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para2.ParagraphFormat.Depth = 1;

    // Adds the third paragraph
    IParagraph para3 = new Paragraph();
    para3.Text = "第三级";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para3.ParagraphFormat.Depth = 2;

    // Adds the fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.Text = "第四级";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para4.ParagraphFormat.Depth = 3;

    // Adds paragraphs to collection
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Writes the presentation as a PPTX file
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **管理带有自定义编号列表的段落**
[IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) 属性等，允许您管理具有自定义编号或格式的段落。

1. 创建 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 访问包含段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

此 C# 代码展示了如何添加和管理具有自定义编号或格式的段落：

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Accesses the text frame of created autoshape
	ITextFrame textFrame = shape.TextFrame;

	// Removes the default exisiting paragraph
	textFrame.Paragraphs.RemoveAt(0);

	// First list
	var paragraph1 = new Paragraph { Text = "项目符号 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "项目符号 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "项目符号 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **设置段落缩进**
1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过其索引访问相关幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
1. 向矩形 autoshape 添加一个包含三个段落的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
1. 隐藏矩形的线条。
1. 通过其 BulletOffset 属性设置每个 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 的缩进。
1. 将修改后的演示文稿写入 PPT 文件。

此 C# 代码展示了如何设置段落缩进：

```c#
// Instantiate Presentation Class
Presentation pres = new Presentation();

// Gets the first slide
ISlide sld = pres.Slides[0];

// Adds a Rectangle Shape
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Adds TextFrame to the Rectangle
ITextFrame tf = rect.AddTextFrame("这是第一行 \r这是第二行 \r这是第三行");

// Sets the text to fit the shape
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Hides the lines of the Rectangle
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Gets the first Paragraph in the TextFrame and set its Indent
IParagraph para1 = tf.Paragraphs[0];

// Sets paragraph bullet style and symbol
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// Gets second Paragraph in the TextFrame and set its Indent
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// Gets third Paragraph in the TextFrame and sets its Indent
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// Writes the Presentation to disk
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **为段落设置悬挂缩进**

此 C# 代码展示了如何为段落设置悬挂缩进：

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "示例"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "为段落设置悬挂缩进"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "此 C# 代码展示了如何为段落设置悬挂缩进："
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **管理段落的结束段落运行属性**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过其位置获取包含段落的幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
1. 向矩形添加一个包含两个段落的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
1. 为段落设置 `FontHeight` 和字体类型。
1. 设置段落的结束属性。
1. 将修改后的演示文稿写入 PPTX 文件。

此 C# 代码展示了如何为 PowerPoint 中的段落设置结束属性：

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("示例文本"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("示例文本 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **将 HTML 文本导入到段落中**
Aspose.Slides 提供了增强的支持，以将 HTML 文本导入到段落中。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
4. 添加并访问 autoshape [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
5. 删除 `ITextFrame` 中的默认段落。
6. 使用 TextReader 读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) 中。
9. 保存修改后的演示文稿。

此 C# 代码是将 HTML 文本导入段落的步骤实现：

```c#
// Creates Empty presentation instance
using (Presentation pres = new Presentation())
{
    // Acessses the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Adds the AutoShape to house the HTML content
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Adds text frame to the shape
    ashape.AddTextFrame("");

    // Clears all paragraphs in the added text frame
    ashape.TextFrame.Paragraphs.Clear();

    // Loads the HTML file using stream reader
    TextReader tr = new StreamReader("file.html");

    // Adds the text from HTML stream reader in text frame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Saves Presentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **将段落文本导出为 HTML**
Aspose.Slides 提供了增强的支持，将文本（包含在段落中）导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载所需的演示文稿。
2. 通过其索引访问相关幻灯片的引用。
3. 访问包含要导出为 HTML 的文本的形状。
4. 访问形状 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 创建 `StreamWriter` 的实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您选择的段落。

此 C# 代码展示了如何将 PowerPoint 段落文本导出为 HTML：

```c#
// Loads the presentation file
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Acessses the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Accesses the required  index
    int index = 0;

    // Accesses the added shape
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Writes paragraphs data to HTML by specifying paragraph starting index and number of paragraphs to be copied
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```