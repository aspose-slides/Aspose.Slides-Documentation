---
title: 使用 Python 简化演示文稿中的字体替换
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
description: "通过 .NET 在 Aspose.Slides Python 中无缝替换字体，确保 PowerPoint 和 OpenDocument 演示文稿的排版保持一致。"
---

## **替换字体**

如果您改变了使用某种字体的想法，您可以将该字体替换为另一种字体。旧字体的所有实例都将被新字体替换。

Aspose.Slides 允许您通过以下方式替换字体：

1. 加载相关的演示文稿。
2. 加载将要被替换的字体。
3. 加载新字体。
4. 执行字体替换。
5. 将修改后的演示文稿写入为 PPTX 文件。

此 Python 代码演示了字体替换：
```py
import aspose.pydrawing as draw
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 加载将被替换的源字体
    sourceFont = slides.FontData("Arial")

    # 加载新字体
    destFont = slides.FontData("Times New Roman")

    # 替换字体
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # 保存演示文稿
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 
要设置在特定条件下（例如字体无法访问）会发生什么的规则，请参阅[**字体替换**](/slides/zh/python-net/font-substitution/)。 
{{% /alert %}}

## **常见问题**

**“字体替换”、 “字体替代” 与 “后备字体” 有何区别？**

替换是指在整个文档中有意地将一种字体族切换为另一种。[替代](/slides/zh/python-net/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[后备](/slides/zh/python-net/fallback-font/) 则在基础字体已安装但缺少所需字符时，对单个缺失字形进行精准应用。

**替换是否适用于母版幻灯片、布局、备注和评论？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；评论也是文档的一部分，会被字体引擎考虑在内。

**嵌入的 OLE 对象（例如 Excel）中的字体会改变吗？**

不会。[OLE 内容](/slides/zh/python-net/manage-ole/) 受其自身应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或可外部编辑的内容形式显示。

**我可以只在演示文稿的某部分（按幻灯片或区域）替换字体吗？**

如果在所需的对象/范围级别更改字体，而不是对整个文档进行全局替换，则可以进行有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)：它提供正在使用的[字体族列表](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/)以及关于[替代/“未知”字体](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)的信息，这有助于规划替换。

**在转换为 PDF/图像时字体替换是否有效？**

是的。导出时，Aspose.Slides 会应用相同的[字体选择/替代顺序](/slides/zh/python-net/font-selection-sequence/)，因此事先进行的替换将在转换时得到保留。

**我需要在系统中安装目标字体，还是可以附加一个字体文件夹？**

不需要安装：库允许从用户文件夹[加载外部字体](/slides/zh/python-net/custom-font/)，以供[渲染和导出](/slides/zh/python-net/convert-powerpoint/)时使用。

**替换能解决字符显示为“豆腐块”（方框）的问题吗？**

仅当目标字体实际包含所需字形时才会生效。如果没有，请[配置后备字体](/slides/zh/python-net/fallback-font/)以覆盖缺失字符。