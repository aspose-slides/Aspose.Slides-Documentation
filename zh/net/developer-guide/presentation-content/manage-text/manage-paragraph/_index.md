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
description: "使用 Aspose.Slides for .NET 在 PPT、PPTX 和 ODP 演示文稿中，优化对齐、间距和样式，实现段落格式化的高级控制（C#）。"
---

Aspose.Slides 提供了处理 PowerPoint 文本、段落和部分所需的所有接口和类，适用于 C#。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 接口，允许您添加表示段落的对象。`ITextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 接口，允许您添加表示文本片段的对象。`IParagraph` 对象可以包含一个或多个片段（iPortions 对象的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 接口，允许您添加表示文本及其格式属性的对象。

`IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤演示如何添加一个包含 3 个段落且每个段落包含 3 个部分的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 获取与该 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 对象，并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 的 `IParagraphs` 集合中。
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) 对象（默认段落使用两个 Portion 对象），并将每个 `IPortion` 对象添加到相应 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `IPortion` 对象提供的格式化属性，为每个部分应用您首选的格式化功能。
9. 保存修改后的演示文稿。

下面的 C# 代码实现了添加包含部分的段落的步骤：
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

项目符号列表可帮助您快速高效地组织和呈现信息。使用项目符号的段落更易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向所选幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将段落的项目符号 `Type` 设置为 `Symbol` 并设置项目符号字符。
9. 设置段落的 `Text`。
10. 设置段落的项目符号 `Indent`。
11. 为项目符号设置颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落，并重复步骤7至13的过程。
15. 保存演示文稿。

下面的 C# 代码演示如何添加段落项目符号：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];


    // 添加并访问自动形状
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问自动形状的文本框
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

    // 创建第二个段落
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

项目符号列表可帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)，并设置图像。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 为项目符号设置颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落，并根据前面的步骤重复此过程。
15. 保存修改后的演示文稿。

下面的 C# 代码演示如何添加和管理图片项目符号：
```c#
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation presentation = new Presentation();

// 访问第一张幻灯片
ISlide slide = presentation.Slides[0];

// 实例化子弹用的图像
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// 添加并访问自动形状
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// 访问自动形状的文本框
ITextFrame textFrame = autoShape.TextFrame;

// 删除默认段落
textFrame.Paragraphs.RemoveAt(0);

// 创建一个新段落
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// 设置段落项目符号样式和图像
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 设置项目符号高度
paragraph.ParagraphFormat.Bullet.Height = 100;

// 将段落添加到文本框
textFrame.Paragraphs.Add(paragraph);

// 将演示文稿保存为 PPTX 文件
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// 将演示文稿保存为 PPT 文件
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **管理多级项目符号**

项目符号列表可帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

下面的 C# 代码演示如何添加和管理多级项目符号：
```c#
// 实例化一个表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];
    
    // 添加并访问自动形状
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建自动形状的文本框
    ITextFrame text = aShp.AddTextFrame("");
    
    // 清除默认段落
    text.Paragraphs.Clear();

    // 添加第一段
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para1.ParagraphFormat.Depth = 0;

    // 添加第二段
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para2.ParagraphFormat.Depth = 1;

    // 添加第三段
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 设置项目符号级别
    para3.ParagraphFormat.Depth = 2;

    // 添加第四段
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

    // 将演示文稿保存为 PPTX 文件
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **管理带自定义编号列表的段落**

[IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) 属性等，可用于管理具有自定义编号或格式的段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 访问包含该段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

下面的 C# 代码演示如何添加和管理具有自定义编号或格式的段落：
```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 访问已创建自动形状的文本框
	ITextFrame textFrame = shape.TextFrame;

	// 删除默认的现有段落
	textFrame.Paragraphs.RemoveAt(0);

	// 第一列表
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


## **设置段落缩进**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
4. 向矩形自动形状添加一个包含三个段落的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 隐藏矩形线条。
6. 通过它们的 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 设置缩进。
7. 将修改后的演示文稿写入为 PPT 文件。

下面的 C# 代码演示如何设置段落缩进：
```c#
 // 实例化 Presentation 类
 Presentation pres = new Presentation();

 // 获取第一张幻灯片
 ISlide sld = pres.Slides[0];

 // 添加一个矩形形状
 IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

 // 为矩形添加 TextFrame
 ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

 // 设置文本以适应形状
 tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

 // 隐藏矩形的线条
 rect.LineFormat.FillFormat.FillType = FillType.Solid;

 // 获取 TextFrame 中的第一个段落并设置其缩进
 IParagraph para1 = tf.Paragraphs[0];

 // 设置段落项目符号样式和符号
 para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
 para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 para1.ParagraphFormat.Alignment = TextAlignment.Left;

 para1.ParagraphFormat.Depth = 2;
 para1.ParagraphFormat.Indent = 30;

 // 获取 TextFrame 中的第二个段落并设置其缩进
 IParagraph para2 = tf.Paragraphs[1];
 para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
 para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 para2.ParagraphFormat.Alignment = TextAlignment.Left;
 para2.ParagraphFormat.Depth = 2;
 para2.ParagraphFormat.Indent = 40;

 // 获取 TextFrame 中的第三个段落并设置其缩进
 IParagraph para3 = tf.Paragraphs[2];
 para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
 para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 para3.ParagraphFormat.Alignment = TextAlignment.Left;
 para3.ParagraphFormat.Depth = 2;
 para3.ParagraphFormat.Indent = 50;

 // 将演示文稿写入磁盘
 pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **为段落设置悬挂缩进**

下面的 C# 代码演示如何为段落设置悬挂缩进：
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **管理段落的结束运行属性**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其位置获取包含该段落的幻灯片的引用。
3. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
4. 向矩形添加一个包含两个段落的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 为段落设置 `FontHeight` 和字体类型。
6. 为段落设置结束属性。
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示如何在 PowerPoint 中为段落设置结束属性：
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

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。
4. 添加并访问 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
5. 删除 `ITextFrame` 中的默认段落。
6. 使用 TextReader 读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/)。
9. 保存修改后的演示文稿。

下面的 C# 代码实现了将 HTML 文本导入段落的步骤：
```c#
// 创建空的演示文稿实例
using (Presentation pres = new Presentation())
{
    // 访问演示文稿的默认第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 添加 AutoShape 用于容纳 HTML 内容
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // 向形状添加文本框
    ashape.AddTextFrame("");

    // 清除已添加文本框中的所有段落
    ashape.TextFrame.Paragraphs.Clear();

    // 使用流读取器加载 HTML 文件
    TextReader tr = new StreamReader("file.html");

    // 将 HTML 流读取器的文本添加到文本框
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // 保存演示文稿
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **将段落文本导出为 HTML**

Aspose.Slides 提供了将文本（包含在段落中）导出为 HTML 的增强支持。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载所需的演示文稿。
2. 通过索引访问相应幻灯片的引用。
3. 访问包含将导出为 HTML 的文本的形状。
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。
6. 提供起始索引给 StreamWriter 并导出您选择的段落。

下面的 C# 代码演示如何将 PowerPoint 段落文本导出为 HTML：
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

    // 将段落数据写入 HTML，指定段落起始索引和要复制的段落数量
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **将段落保存为图像**

在本节中，我们将探讨两个示例，演示如何将由 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 接口表示的文本段落保存为图像。两个示例都包括使用 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口的 `GetImage` 方法获取包含段落的形状图像、计算段落在形状中的边界，并将其导出为位图图像。这些方法使您能够从 PowerPoint 演示文稿中提取特定文本部分并保存为单独的图像，便于在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿文件，包含一张幻灯片，第一 个形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

**示例 1**

在此示例中，我们获取第二个段落的图像。为此，我们从演示文稿的第一页提取形状的图像，然后计算该形状文本框中第二个段落的边界。随后将段落重新绘制到新的位图图像中，并以 PNG 格式保存。当需要将特定段落保存为单独图像且保持文本的精确尺寸和格式时，此方法特别有用。

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


结果如下：

![段落图像](paragraph_to_image_output.png)

**示例 2**

在此示例中，我们在前一种方法的基础上为段落图像添加缩放因子。形状从演示文稿中提取并以 `2` 的缩放因子保存为图像。这样在导出段落时可以得到更高分辨率的输出。随后在考虑缩放的情况下计算段落的边界。缩放在需要更高细节的图像时特别有用，例如用于高质量打印材料。

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


## **常见问题**

**我可以完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置 ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)) 将换行关闭，这样行就不会在框的边缘换行。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个片段）的边界矩形，以了解其在幻灯片上的精确位置和大小。

**段落对齐（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) 是在 [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) 中的段落级设置；它适用于整个段落，而不受各个片段格式的影响。

**我能为段落的部分（例如某个词）设置拼写检查语言吗？**

可以。语言在片段级别设置 ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/))，因此单个段落中可以共存多种语言。