---
title: 在 Android 上简化演示文稿的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/androidjava/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Android 中无缝替换字体，以确保 PowerPoint 和 OpenDocument 演示文稿中的排版一致性。"
---

## **替换字体**

如果您改变主意不再使用某种字体，可以将该字体替换为另一种字体。旧字体的所有实例都将被新字体替代。

Aspose.Slides 允许您以以下方式替换字体：

1. 加载相关的演示文稿。  
2. 加载将被替换的字体。  
3. 加载新字体。  
4. 替换字体。  
5. 将修改后的演示文稿写入 PPTX 文件。

下面的 Java 代码演示了字体替换：
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

要设置在特定条件下（例如无法访问字体）会发生什么的规则，请参阅[**字体替代**](/slides/zh/androidjava/font-substitution/)。

{{% /alert %}}

## **常见问题**

**“字体替换”、 “字体替代” 与 “后备字体” 有何区别？**

替换是指在整个文档中有意地将一个字体族切换为另一个。[替代](/slides/zh/androidjava/font-substitution/) 是一种规则，例如“如果字体不可用，则使用 X”。[后备字体](/slides/zh/androidjava/fallback-font/) 在缺少特定字形时针对单个缺失字符进行应用，前提是已安装的基础字体不包含所需字符。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会将其纳入考虑。

**字体会在嵌入的 OLE 对象（例如 Excel）内变化吗？**

不会。[OLE 内容](/slides/zh/androidjava/manage-ole/) 由其自身的应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能以图像或外部可编辑内容的形式显示。

**我可以仅在演示文稿的部分（按幻灯片或区域）替换字体吗？**

如果在所需对象/范围层面更改字体而不是对整个文档执行全局替换，则可以实现有针对性的替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[字体管理器](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/)：它提供[使用中的字体族列表](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--)以及有关[替代/“未知”字体的信息](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--)，有助于规划替换。

**在转换为 PDF/图像时字体替换是否有效？**

有效。在导出过程中，Aspose.Slides 应用相同的[字体选择/替代序列](/slides/zh/androidjava/font-selection-sequence/)，因此提前进行的替换会在转换时得到遵循。

**我需要在系统中安装目标字体，还是可以附加一个字体文件夹？**

无需安装：库支持从用户文件夹[加载外部字体](/slides/zh/androidjava/custom-font/)，用于[渲染和导出](/slides/zh/androidjava/convert-powerpoint/)。

**替换能解决显示为方块（“豆腐块”）的问题吗？**

仅当目标字体实际包含所需字形时才会生效。如果不包含，请[配置后备字体](/slides/zh/androidjava/fallback-font/)以覆盖缺失字符。