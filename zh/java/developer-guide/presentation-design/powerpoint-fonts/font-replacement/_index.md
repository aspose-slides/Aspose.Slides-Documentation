---
title: 用 Java 简化演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/java/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中无缝替换字体，以确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致。"
---

## **更换字体**

如果您改变了对使用某种字体的想法，您可以将该字体替换为另一种字体。所有旧字体的实例都将被新字体取代。

Aspose.Slides 允许您以如下方式替换字体：

1. 加载相关的演示文稿。 
2. 加载将被替换的字体。 
3. 加载新字体。 
4. 替换字体。 
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了字体替换：
```java
// 加载演示文稿
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 加载将被替换的源字体
    IFontData sourceFont = new FontData("Arial");
    
    // 加载新字体
    IFontData destFont = new FontData("Times New Roman");
    
    // 替换字体
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // 保存演示文稿
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

要设置在特定条件下（例如无法访问字体）会发生什么的规则，请参阅[**字体替代**](/slides/zh/java/font-substitution/)。 

{{% /alert %}}

## **FAQ**

**“字体替换”、 “字体替代” 和 “回退字体” 有什么区别？**

替换是指在整个文档中有意地将一种字体族切换为另一种字体族。[替代](/slides/zh/java/font-substitution/) 是一种规则，例如“如果字体不可用，使用 X”。[回退](/slides/zh/java/fallback-font/) 则在基字体已安装但不包含所需字符时，针对单个缺失字形进行手动应用。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；批注也是文档的一部分，会被字体引擎考虑在内。

**字体会在嵌入的 OLE 对象（例如 Excel）内部更改吗？**

不会。[OLE 内容](/slides/zh/java/manage-ole/) 由其自身的应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能显示为图像或作为外部可编辑内容。

**我可以仅在演示文稿的某部分（按幻灯片或区域）进行字体替换吗？**

如果在所需对象/范围层面更改字体，而不是对整个文档执行全局替换，则可以实现有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何事先确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/)：它提供[使用中的字体族列表](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getFonts--)以及关于[替代/“未知”字体的信息](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getSubstitutions--)，帮助您规划替换工作。

**在转换为 PDF/图片时，字体替换是否生效？**

会的。在导出期间，Aspose.Slides 会应用相同的[字体选择/替代顺序](/slides/zh/java/font-selection-sequence/)，因此预先进行的替换将在转换时得到尊重。

**我需要在系统中安装目标字体，还是可以附加一个字体文件夹？**

无需安装：库允许从用户文件夹[加载外部字体](/slides/zh/java/custom-font/)，以供[渲染和导出](/slides/zh/java/convert-powerpoint/)时使用。

**替换能解决字符显示为方框（“豆腐块”）的问题吗？**

只有当目标字体实际包含所需字形时才会生效。如果不包含，请[配置回退](/slides/zh/java/fallback-font/)以覆盖缺失字符。