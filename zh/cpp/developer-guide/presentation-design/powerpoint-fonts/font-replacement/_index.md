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
description: "在 Aspose.Slides for C++ 中无缝替换字体，确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致。"
---
## **概述**

Aspose.Slides 允许您在整个演示文稿中将一种字体替换为另一种字体。进行字体替换时，所有原始字体的实例都会被更改为新字体。

要执行字体替换，加载演示文稿，定义源字体和替换字体，调用字体替换方法，然后将修改后的演示文稿保存为 PPTX 文件。此方法在您有意在整个演示文稿中从一种字体族切换到另一种字体族时非常有用。

## **替换字体**

如果您改变了对某种字体的使用想法，可以将该字体替换为另一种字体。旧字体的所有实例都会被新字体取代。

Aspose.Slides 允许您通过以下方式替换字体：

1. 加载相关演示文稿。  
2. 加载将被替换的字体。  
3. 加载新字体。  
4. 替换字体。  
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C++ 代码演示了字体替换：

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

{{% alert title="注意" color="warning" %}} 

要设置在特定条件下（例如无法访问字体）会发生何种行为的规则，请参阅 [**字体替换**](/slides/zh/cpp/font-substitution/)。 

{{% /alert %}}

## **常见问题**

**“字体替换”、 “字体替代” 与 “回退字体” 有何区别？**

替换是有意在整个文档中将一种字体族切换为另一种。[**字体替代**](/slides/zh/cpp/font-substitution/) 是一种规则，例如“如果字体不可用，使用 X”。[**回退字体**](/slides/zh/cpp/fallback-font/) 在缺少特定字符时针对单个缺失字形进行应用，前提是基础字体已安装但不包含所需字符。

**替换是否会影响母版幻灯片、布局、备注和批注？**

会。替换会影响所有使用原始字体的演示对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会对其进行处理。

**替换会改变嵌入的 OLE 对象（例如 Excel）中的字体吗？**

不会。[**OLE 内容**](/slides/zh/cpp/manage-ole/) 由其所属应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或外部可编辑内容的形式显示。

**我可以仅在演示文稿的某部分（按幻灯片或区域）进行字体替换吗？**

如果在所需对象/范围层面更改字体，而不是对整个文档进行全局替换，则可以实现有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的 [字体管理器](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/)：它提供了 [使用中的字体族列表](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getfonts/) 与关于 [替代/“未知”字体](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getsubstitutions/) 的信息，有助于规划替换工作。

**在转换为 PDF/图像时，字体替换是否生效？**

会。导出时，Aspose.Slides 会应用相同的 [字体选择/替代顺序](/slides/zh/cpp/font-selection-sequence/)，因此事先进行的替换将在转换过程中得到遵循。

**是否必须在系统中安装目标字体，还是可以附加字体文件夹？**

无需安装：库支持从用户文件夹 [加载外部字体](/slides/zh/cpp/custom-font/)，用于 [渲染和导出](/slides/zh/cpp/convert-powerpoint/)。  

**替换能解决字符显示为“豆腐块”（方框）的问题吗？**

仅当目标字体确实包含所需字形时才会解决。如果没有，请 [配置回退字体](/slides/zh/cpp/fallback-font/) 以覆盖缺失字符。