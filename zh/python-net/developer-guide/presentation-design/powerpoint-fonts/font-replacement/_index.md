---
title: 在演示文稿中使用 Python 简化字体替换
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
description: "通过 .NET 在 Aspose.Slides Python 中无缝替换字体，确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致。"
---

## **替换字体**

如果您改变了对某种字体的使用意向，可以用另一种字体替换它。所有旧字体的实例都会被新字体替换。

Aspose.Slides 允许您按以下方式替换字体：

1. 加载相关的演示文稿。  
2. 加载要被替换的字体。  
3. 加载新字体。  
4. 替换字体。  
5. 将修改后的演示文稿保存为 PPTX 文件。

以下 Python 代码演示了字体替换：

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

{{% alert title="注意" color="warning" %}}  
要设置在特定条件下（例如字体无法访问）会发生什么的规则，请参阅[**字体替代**](/slides/zh/python-net/font-substitution/)。  
{{% /alert %}}

## **常见问题**

**“字体替换”“字体替代”和“后备字体”之间有什么区别？**  

替换是指在整个文档中有意将一种字体族切换为另一种。[字体替代](/slides/zh/python-net/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[后备字体](/slides/zh/python-net/fallback-font/) 则在缺少特定字符时针对单个缺失字形进行应用，前提是已安装的基本字体不包含所需字符。

**替换是否适用于母版幻灯片、布局、备注和批注？**  

是的。替换会影响所有使用原始字体的演示对象，包括母版幻灯片和备注；批注也是文档的一部分，会被字体引擎考虑在内。

**嵌入的 OLE 对象（例如 Excel）内部的字体会随之变化吗？**  

不会。[OLE 内容](/slides/zh/python-net/manage-ole/) 由其所属应用程序自行控制。演示文稿中的替换不会重新格式化内部 OLE 数据；其可能以图像或外部可编辑内容的形式显示。

**我可以只在演示文稿的某部分（按幻灯片或区域）进行字体替换吗？**  

可以实现有针对性的替换，只需在所需对象/范围层级更改字体，而不是对整个文档执行全局替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**  

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)：它提供[已使用字体族列表](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/)以及关于[替代/“未知”字体的信息](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)，有助于规划替换工作。

**字体替换在转为 PDF/图像时是否仍然有效？**  

有效。在导出过程中，Aspose.Slides 会应用相同的[字体选择/替代顺序](/slides/zh/python-net/font-selection-sequence/)，因此事先完成的替换会在转换时得到保留。

**是否必须在系统中安装目标字体，或可以附加字体文件夹？**  

无需安装：库支持从用户文件夹[加载外部字体](/slides/zh/python-net/custom-font/)，可在[渲染和导出](/slides/zh/python-net/convert-powerpoint/)期间使用。

**替换能否解决出现“豆腐块”（方块）而非字符的问题？**  

仅当目标字体确实包含所需字形时才能解决。如果不包含，请[配置后备字体](/slides/zh/python-net/fallback-font/)以覆盖缺失字符。