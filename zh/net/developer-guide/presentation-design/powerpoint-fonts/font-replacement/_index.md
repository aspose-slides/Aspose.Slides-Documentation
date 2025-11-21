---
title: 在 .NET 中简化演示文稿的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/net/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中无缝替换字体，确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致。"
---

## **替换字体**

如果您改变主意，不想使用某种字体，可以将该字体替换为另一种字体。所有旧字体的实例都会被新字体取代。

Aspose.Slides 允许您按以下方式替换字体：

1. 加载相关演示文稿。  
2. 加载将被替换的字体。  
3. 加载新字体。  
4. 替换字体。  
5. 将修改后的演示文稿写入为 PPTX 文件。

以下 C# 代码演示了字体替换：
```c#
// 加载演示文稿
Presentation presentation = new Presentation("Fonts.pptx");

// 加载将被替换的源字体
IFontData sourceFont = new FontData("Arial");

// 加载新字体
IFontData destFont = new FontData("Times New Roman");

// 替换字体
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// 保存演示文稿
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 

要设置在特定条件下（例如字体无法访问）会发生什么的规则，请参阅[**字体替换**](/slides/zh/net/font-substitution/)。 

{{% /alert %}}

## **常见问题**

**“字体替换”、 “字体替换（Substitution）” 和 “回退字体” 有何区别？**

替换是指在整个文档中有意从一个字体族切换到另一个字体族。[替换](/slides/zh/net/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[回退](/slides/zh/net/fallback-font/) 则在缺少特定字符时针对单个缺失字形进行处理，前提是已安装的基础字体不包含所需字符。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会将其考虑在内。

**嵌入的 OLE 对象（例如 Excel）内部的字体会随之改变吗？**

不会。[OLE 内容](/slides/zh/net/manage-ole/) 受其所属应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或外部可编辑内容的形式显示。

**我可以只在演示文稿的某部分（按幻灯片或区域）替换字体吗？**

如果在所需对象/范围层级上更改字体，而不是对整个文档执行全局替换，则可以实现有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)，它提供[使用中的字体族列表](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/)以及关于[替换/“未知”字体](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)的信息，从而帮助规划替换。

**在转换为 PDF/图像时字体替换是否有效？**

有效。导出时，Aspose.Slides 会应用相同的[字体选择/替换顺序](/slides/zh/net/font-selection-sequence/)，因此提前进行的替换将在转换过程中得到保留。

**我需要在系统中安装目标字体，还是可以附加一个字体文件夹？**

不需要安装：库允许从用户文件夹[加载外部字体](/slides/zh/net/custom-font/)，以在[渲染和导出](/slides/zh/net/convert-powerpoint/)期间使用。

**替换能否解决字符显示为“豆腐块”（方框）的问题？**

仅当目标字体实际包含所需字形时才会解决。如果不包含，请[配置回退字体](/slides/zh/net/fallback-font/)以覆盖缺失的字符。