---
title: 通过 Java 使用 Python 简化演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/python-java/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中无缝替换字体，以确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致性。"
---
## **概述**

Aspose.Slides 允许您在整个演示文稿中将一种字体替换为另一种。当字体被替换后，原始字体的所有实例都会改为新字体。

要执行字体替换，加载演示文稿，定义源字体和替换字体，调用字体替换方法，并将修改后的演示文稿保存为 PPTX 文件。此方法在您有意将整个演示文稿的字体族从一种切换到另一种时非常有用。

## **替换字体**

如果您改变了对某种字体的使用意图，可以将该字体替换为另一种字体。旧字体的所有实例都将被新字体取代。

Aspose.Slides 允许您按以下方式替换字体：

1. 加载相关演示文稿。  
2. 加载将被替换的字体。  
3. 加载新字体。  
4. 执行字体替换。  
5. 将修改后的演示文稿写入为 PPTX 文件。

以下 Python 代码演示了字体替换：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# 加载演示文稿。
presentation = Presentation("Fonts.pptx")
try:
    # 加载将被替换的源字体。
    source_font = FontData("Arial")

    # 加载新字体。
    destination_font = FontData("Times New Roman")

    # 替换字体。
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # 保存演示文稿。
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 
要设置在特定条件下（例如无法访问某个字体）会发生什么的规则，请参阅[字体替换](/slides/zh/python-java/font-substitution/)。 
{{% /alert %}}

## **常见问题**

**“字体替换”、 “字体替换（substitution）” 和 “回退字体” 有何区别？**

替换是指在整个文档中有意将一种字体族切换为另一种。[字体替换](/slides/zh/python-java/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[回退字体](/slides/zh/python-java/fallback-font/) 在基础字体已安装但不包含所需字符时，对单个缺失字形生效。

**替换是否会影响母版幻灯片、布局、备注和批注？**

会。替换会影响所有使用原始字体的演示对象，包括母版幻灯片和备注；批注也是文档的一部分，会被字体引擎考虑。

**嵌入的 OLE 对象（例如 Excel）内部的字体会随之改变吗？**

不会。[OLE 内容](/slides/zh/python-java/manage-ole/) 由其自身的应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或可外部编辑的内容形式显示。

**我可以仅在演示文稿的部分（按幻灯片或区域）替换字体吗？**

可以进行有针对性的替换，只需在所需的对象/范围层级更改字体，而不是对整个文档进行全局替换。渲染时的整体字体选择逻辑保持不变。

**如何预先确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)：它提供[使用中的字体族]((https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getFonts))列表以及[替换/“未知”字体]((https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions))信息，帮助规划替换工作。

**字体替换在转换为 PDF/图像时有效吗？**

有效。在导出时，Aspose.Slides 会应用相同的[字体选择/替换顺序](/slides/zh/python-java/font-selection-sequence/)，因此事先进行的替换会在转换过程中得到遵循。

**是否必须在系统中安装目标字体，还是可以附加 fonts 文件夹？**

无需安装：库允许从用户文件夹[加载外部字体](/slides/zh/python-java/custom-font/)，供[渲染和导出](/slides/zh/python-java/convert-powerpoint/)时使用。

**替换能否修复显示为“豆腐块”（方框）而不是字符的情况？**

仅当目标字体实际包含所需字形时才会修复。如果不包含，请[配置回退字体](/slides/zh/python-java/fallback-font/)以覆盖缺失字符。