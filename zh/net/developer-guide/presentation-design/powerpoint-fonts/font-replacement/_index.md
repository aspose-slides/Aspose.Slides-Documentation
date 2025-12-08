---
title: 字体替换 - PowerPoint C# API
linktitle: 字体替换
type: docs
weight: 60
url: /zh/net/font-replacement/
keywords: "字体, 替换字体, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: 使用 C# PowerPoint API，您可以在演示文稿中显式地将字体替换为另一种字体。
---

## **替换字体**

如果您改变了对使用某种字体的想法，您可以将该字体替换为另一种字体。旧字体的所有实例都将被新字体替换。

Aspose.Slides 允许您通过以下方式替换字体：

1. 加载相关的演示文稿。 
2. 加载将被替换的字体。 
3. 加载新字体。 
4. 执行字体替换。 
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示了字体替换：
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
要设置确定在特定条件下（例如无法访问字体）会发生什么的规则，请参阅 [**Font Substitution**](/slides/zh/net/font-substitution/)。 
{{% /alert %}}

## **常见问题**

**“字体替换”“字体替代”和“回退字体”之间有什么区别？**

替换是对整个文档有意地从一个字体系列切换到另一个系列。[Substitution](/slides/zh/net/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[Fallback](/slides/zh/net/fallback-font/) 在基础字体已安装但不包含所需字符时，对单个缺失字形进行精准应用。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会考虑它们。

**嵌入的 OLE 对象（例如 Excel）内部的字体会改变吗？**

不会。[OLE content](/slides/zh/net/manage-ole/) 由其所属的应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或外部可编辑内容的形式显示。

**我可以只在演示文稿的部分（如特定幻灯片或区域）替换字体吗？**

如果在所需的对象/范围层面更改字体，而不是对整个文档进行全局替换，则可以实现有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的 [字体管理器](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)：它提供正在使用的 [字体系列](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) 列表和关于 [替代/“未知”字体](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) 的信息，帮助规划替换。

**字体替换在转换为 PDF/图像时有效吗？**

是的。导出时，Aspose.Slides 会应用相同的 [font selection/substitution sequence](/slides/zh/net/font-selection-sequence/)，因此事先进行的替换将在转换期间生效。

**我需要在系统中安装目标字体吗，还是可以附加一个字体文件夹？**

不需要安装：库允许从用户文件夹 [加载外部字体](/slides/zh/net/custom-font/)，用于 [渲染和导出](/slides/zh/net/convert-powerpoint/)。

**替换能解决字符显示为“豆腐块”（方块）的问题吗？**

仅在目标字体实际包含所需字形时有效。如果没有，请 [configure fallback](/slides/zh/net/fallback-font/) 以覆盖缺失字符。