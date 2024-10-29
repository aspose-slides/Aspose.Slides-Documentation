---
title: 管理 Python 中的 PowerPoint 段落
type: docs
weight: 40
url: /zh/python-net/manage-paragraph/
keywords: "添加 PowerPoint 段落, 管理段落, 段落缩进, 段落属性, HTML 文本, 导出段落文本, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中创建和管理 PowerPoint 演示文稿中的段落、文本、缩进和属性"
---

Aspose.Slides 提供了在 Python 中处理 PowerPoint 文本、段落和部分所需的所有接口和类。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) 接口，允许您添加代表段落的对象。`ITextFame` 对象可以包含一个或多个段落（每个段落通过换行符创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) 接口，允许您添加代表部分的对象。`IParagraph` 对象可以包含一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) 接口，允许您添加代表文本及其格式属性的对象。

`IParagraph` 对象能够通过其基础的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤说明如何添加一个文本框，其中包含 3 个段落，每个段落包含 3 个部分：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) 关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) 对象并将其添加到 [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) 的 `IParagraphs` 集合中。
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) 对象（默认段落的两个 Portion 对象）并将每个 `IPortion` 对象添加到每个 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `IPortion` 对象公开的格式属性将您首选的格式功能应用于每个部分。
9. 保存修改后的演示文稿。

此 Python 代码实现了添加包含部分的段落的步骤：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 访问第一个幻灯片
    slide = pres.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # 访问 AutoShape 的 TextFrame
    tf = ashp.text_frame

    # 使用不同文本格式创建段落和部分
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # 将 PPTX 写入磁盘
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理段落项目符号**

项目符号列表帮助您快速有效地组织和呈现信息。带项目符号的段落通常更容易阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向选定的幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的项目符号 `Type` 设置为 `Symbol` 并设置项目符号字符。
8. 设置段落 `Text`。
9. 为项目符号设置段落 `Indent`。
10. 为项目符号设置颜色。
11. 设置项目符号的高度。
12. 将新段落添加到 `TextFrame` 段落集合中。
13. 添加第二个段落并重复第 7 到 13 步骤中的过程。
14. 保存演示文稿。

此 Python 代码向您展示如何添加段落项目符号：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建演示文稿实例
with slides.Presentation() as pres:
    # 访问第一个幻灯片
    slide = pres.slides[0]

    # 添加并访问 AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问创建的 autoshape 的文本框
    txtFrm = aShp.text_frame

    # 移除默认现有段落
    txtFrm.paragraphs.remove_at(0)

    # 创建段落
    para = slides.Paragraph()

    # 设置段落项目符号样式和符号
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # 设置段落文本
    para.text = "欢迎使用 Aspose.Slides"

    # 设置项目符号缩进
    para.paragraph_format.indent = 25

    # 设置项目符号颜色
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # 设置项目符号高度
    para.paragraph_format.bullet.height = 100

    # 将段落添加到文本框中
    txtFrm.paragraphs.add(para)

    # 创建第二个段落
    para2 = slides.Paragraph()

    # 设置段落项目符号类型和样式
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # 添加段落文本
    para2.text = "这是编号项目符号"

    # 设置项目符号缩进
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # 设置项目符号高度
    para2.paragraph_format.bullet.height = 100

    # 将段落添加到文本框中
    txtFrm.paragraphs.add(para2)

    # 将演示文稿写入 PPTX 文件
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理图片项目符号**

项目符号列表帮助您快速有效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 并设置图像。
9. 设置段落 `Text`。
10. 为项目符号设置段落 `Indent`。
11. 设置项目符号的颜色。
12. 为项目符号设置高度。
13. 将新段落添加到 `TextFrame` 段落集合中。
14. 添加第二个段落并根据先前的步骤重复该过程。
15. 保存修改后的演示文稿。

此 Python 代码向您展示如何添加和管理图片项目符号：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 访问第一个幻灯片
    slide = presentation.slides[0]

    # 实例化用于项目符号的图像
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # 添加并访问 AutoShape
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问创建的 autoshape 的文本框
    textFrame = autoShape.text_frame

    # 移除默认现有段落
    textFrame.paragraphs.remove_at(0)

    # 创建新段落
    paragraph = slides.Paragraph()
    paragraph.text = "欢迎使用 Aspose.Slides"

    # 设置段落项目符号样式和图像
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # 设置项目符号高度
    paragraph.paragraph_format.bullet.height = 100

    # 将段落添加到文本框中
    textFrame.paragraphs.add(paragraph)

    # 将演示文稿写入 PPTX 文件
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # 将演示文稿写入 PPT 文件
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **管理多级项目符号**

项目符号列表帮助您快速有效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 创建第一个段落实例，通过 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类并设置深度为 0。
7. 创建第二个段落实例，通过 `Paragraph` 类并设置深度为 1。
8. 创建第三个段落实例，通过 `Paragraph` 类并设置深度为 2。
9. 创建第四个段落实例，通过 `Paragraph` 类并设置深度为 3。
10. 将新段落添加到 `TextFrame` 段落集合中。
11. 保存修改后的演示文稿。

此 Python 代码向您展示如何添加和管理多级项目符号：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建演示文稿实例
with slides.Presentation() as pres:
    # 访问第一个幻灯片
    slide = pres.slides[0]
    
    # 添加并访问 AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问创建的 autoshape 的文本框
    text = aShp.add_text_frame("")
    
    # 清除默认段落
    text.paragraphs.clear()

    # 添加第一个段落
    para1 = slides.Paragraph()
    para1.text = "内容"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别
    para1.paragraph_format.depth = 0

    # 添加第二个段落
    para2 = slides.Paragraph()
    para2.text = "第二级"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别
    para2.paragraph_format.depth = 1

    # 添加第三个段落
    para3 = slides.Paragraph()
    para3.text = "第三级"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别
    para3.paragraph_format.depth = 2

    # 添加第四个段落
    para4 = slides.Paragraph()
    para4.text = "第四级"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别
    para4.paragraph_format.depth = 3

    # 将段落添加到集合中
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # 将演示文稿写入 PPTX 文件
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **使用自定义编号列表管理段落**

[IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/) 接口提供了 `NumberedBulletStartWith` 属性和其他可让您管理具有自定义编号或格式的段落的属性。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 访问包含段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 访问 autoshape [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例并将 `NumberedBulletStartWith` 设置为 2。
7. 使用 `Paragraph` 类创建第二个段落实例并将 `NumberedBulletStartWith` 设置为 3。
8. 使用 `Paragraph` 类创建第三个段落实例并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 段落集合中。
10. 保存修改后的演示文稿。

此 Python 代码向您展示如何添加和管理具有自定义编号或格式的段落：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问创建的 autoshape 的文本框
    textFrame = shape.text_frame

    # 移除默认现有段落
    textFrame.paragraphs.remove_at(0)

    # 第一个列表
    paragraph1 = slides.Paragraph()
    paragraph1.text = "项目符号 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "项目符号 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "项目符号 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **设置段落缩进**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其索引访问相关幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
1. 在矩形自动形状中添加一个包含三个段落的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
1. 隐藏矩形线条。
1. 通过它们的 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 设置缩进。
1. 将修改后的演示文稿写入 PPT 文件。

此 Python 代码向您展示如何设置段落缩进：

```python
import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation() as pres:

    # 获取第一个幻灯片
    sld = pres.slides[0]

    # 添加矩形形状
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # 向矩形添加文本框
    tf = rect.add_text_frame("这是第一行 \r这是第二行 \r这是第三行")

    # 设置文本适应形状
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # 隐藏矩形的线条
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # 获取文本框中的第一个段落并设置其缩进
    para1 = tf.paragraphs[0]
    # 设置段落项目符号样式和符号
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # 获取文本框中的第二个段落并设置其缩进
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # 获取文本框中的第三个段落并设置其缩进
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # 将演示文稿写入磁盘
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **为段落设置悬挂缩进**

此 Python 代码向您展示如何为段落设置悬挂缩进：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "示例"
    para2 = slides.Paragraph()
    para2.text = "为段落设置悬挂缩进"
    para3 = slides.Paragraph()
    para3.text = "此 C# 代码向您展示如何为段落设置悬挂缩进： "

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **管理段落的结束段落运行属性**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其位置获取包含段落的幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
1. 向矩形添加一个包含两个段落的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
1. 为段落设置 `FontHeight` 和字体类型。
1. 设置段落的结束属性。
1. 将修改后的演示文稿写入 PPTX 文件。

此 Python 代码向您展示如何在 PowerPoint 中设置段落的结束属性：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("示例文本"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("示例文本 2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **将 HTML 文本导入段落**

Aspose.Slides 提供了增强的支持，以将 HTML 文本导入段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 添加并访问 autoshape [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)。
5. 移除 `ITextFrame` 中的默认段落。
6. 在 TextReader 中读取源 HTML 文件。
7. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/) 中。
9. 保存修改后的演示文稿。

此 Python 代码实现了将 HTML 文本导入段落的步骤：

```python
import aspose.slides as slides

# 创建空的演示文稿实例
with slides.Presentation() as pres:
    # 访问演示文稿的默认第一个幻灯片
    slide = pres.slides[0]

    # 添加自动形状以容纳 HTML 内容
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # 向形状添加文本框
    ashape.add_text_frame("")

    # 清除添加的文本框中的所有段落
    ashape.text_frame.paragraphs.clear()

    # 使用流读取器加载 HTML 文件
    with open(path + "file.html", "rt") as tr:
        # 将 HTML 流读取器中的文本添加到文本框中
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # 保存演示文稿
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **将段落文本导出为 HTML**

Aspose.Slides 提供了增强的支持，以将文本（包含在段落中）导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过其索引访问相关幻灯片的引用。
3. 访问包含将导出为 HTML 的文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
5. 创建 `StreamWriter` 的实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您首选的段落。

此 Python 代码向您展示如何将 PowerPoint 段落文本导出为 HTML：

```python
import aspose.slides as slides

# 加载演示文稿文件
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # 访问演示文稿的默认第一个幻灯片
    slide = pres.slides[0]

    # 目标索引
    index = 0

    # 访问添加的形状
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # 将段落数据写入 HTML，提供段落起始索引、要复制的段落总数
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```