---
title: 使用 C++ 简化演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/cpp/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "无缝地在 Aspose.Slides for C++ 中替换字体，以确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致性。"
---

## **替换字体**

如果您改变了使用某种字体的想法，可以将该字体替换为另一种字体。旧字体的所有实例都将被新字体替换。

Aspose.Slides 允许您以这种方式替换字体：

1. 加载相关的演示文稿。 
2. 加载将被替换的字体。 
3. 加载新字体。 
4. 替换字体。 
5. 将修改后的演示文稿写入为 PPTX 文件。

以下 C++ 代码演示了字体替换：
``` cpp
// 加载演示文稿
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 加载将被替换的源字体
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 加载新字体
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// 替换字体
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// 保存演示文稿
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
要设置确定特定条件下（例如字体无法访问）会发生什么的规则，请参阅[**字体替换**](/slides/zh/cpp/font-substitution/)。 
{{% /alert %}}

## **常见问题**

**“字体替换”、“字体替代”和“后备字体”之间有什么区别？**

Replacement 是在整个文档中将一个字体族有意地切换为另一个字体族。[Substitution](/slides/zh/cpp/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[Fallback](/slides/zh/cpp/fallback-font/) 在基础字体已安装但不包含所需字符时，对单个缺失字形进行外科式的应用。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会考虑它们。

**嵌入的 OLE 对象（例如 Excel）中的字体会改变吗？**

不会。[OLE content](/slides/zh/cpp/manage-ole/) 受其自身应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能显示为图像或作为可外部编辑的内容。

**我能只在演示文稿的某部分（按幻灯片或区域）替换字体吗？**

如果在所需对象/范围级别更改字体，而不是对整个文档进行全局替换，则可以进行有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)：它提供使用中的[families in use](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/)列表以及关于[substitutions/"unknown" fonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getsubstitutions/)的信息，帮助规划替换。

**在转换为 PDF/图像时，字体替换有效吗？**

是的。导出时，Aspose.Slides 会应用相同的[font selection/substitution sequence](/slides/zh/cpp/font-selection-sequence/)，因此预先进行的替换将在转换期间得到遵守。

**我需要在系统中安装目标字体吗，还是可以附加一个字体文件夹？**

无需安装：库允许从用户文件夹[加载外部字体](/slides/zh/cpp/custom-font/)用于[渲染和导出](/slides/zh/cpp/convert-powerpoint/)。

**替换能修复“豆腐块”（方框）而不是字符吗？**

仅当目标字体实际包含所需字形时才会生效。如果没有，请[配置后备字体](/slides/zh/cpp/fallback-font/)以覆盖缺失字符。