---
title: 用Python简化演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/python-net/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: “在 Aspose.Slides Python via .NET 中无缝替换字体，确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致。”
---

## **替换字体**

如果您改变了对某种字体的使用意图，可以将该字体替换为另一种字体。所有旧字体的实例都会被新字体所替代。

Aspose.Slides 允许您通过以下方式替换字体：

1. 加载相关的演示文稿。  
2. 加载将被替换的字体。  
3. 加载新字体。  
4. 执行替换。  
5. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码演示了字体替换：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

如需设置在特定条件下的处理规则（例如字体无法访问时），请参阅[**字体替代**](/slides/zh/python-net/font-substitution/)。 

{{% /alert %}}

## **常见问题**

**“字体替换”、“字体替代”和“后备字体”之间有什么区别？**

- 替换是指在整个文档中有意将一种字体族整体切换为另一种。  
- [**字体替代**](/slides/zh/python-net/font-substitution/) 是一种规则，例如“如果某字体不可用，则使用 X”。  
- [**后备字体**](/slides/zh/python-net/fallback-font/) 则在缺少特定字形时，仅针对单个缺失字符进行补救，前提是基字体已安装但不包含所需字符。

**替换是否会影响母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示对象，包括母版幻灯片和备注；批注同样属于文档的一部分，会被字体引擎考虑。

**嵌入的 OLE 对象（例如 Excel）中的字体会随之改变吗？**

不会。[OLE 内容](/slides/zh/python-net/manage-ole/) 由其自身的应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或外部可编辑内容的形式显示。

**我可以只在演示文稿的部分（按幻灯片或区域）替换字体吗？**

如果在所需对象/范围层面更改字体，而不是对整个文档执行全局替换，则可以实现有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)：它提供[已使用的字体族列表](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/)以及有关[替代/“未知”字体的信息](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)，帮助您规划替换工作。

**字体替换在转换为 PDF/图片时是否仍然生效？**

会的。在导出过程中，Aspose.Slides 会执行相同的[字体选择/替代序列](/slides/zh/python-net/font-selection-sequence/)，因此提前进行的替换会在转换时得到遵循。

**是否必须在系统中安装目标字体，还是可以附加字体文件夹？**

无需安装：库支持从用户文件夹[加载外部字体](/slides/zh/python-net/custom-font/)，用于[渲染和导出](/slides/zh/python-net/convert-powerpoint/)。

**替换后能否解决字符显示为“方块”（ tofu ）的问题？**

仅当目标字体实际包含所需字形时才会解决。如果仍有缺失字符，请[配置后备字体](/slides/zh/python-net/fallback-font/)以覆盖这些缺失字符。