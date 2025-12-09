---
title: 字体替换 - PowerPoint JavaScript API
linktitle: 字体替换
type: docs
weight: 60
url: /zh/nodejs-java/font-replacement/
description: 使用 JavaScript API 在 PowerPoint 中通过显式替换方法学习如何替换字体。
---

## **替换字体**

如果您改变了使用某种字体的想法，可以将该字体替换为另一种字体。所有旧字体的出现位置都会被新字体替换。

Aspose.Slides 允许您按以下方式替换字体：

1. 加载相关的演示文稿。 
2. 加载将被替换的字体。 
3. 加载新字体。 
4. 执行字体替换。 
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 JavaScript 代码演示了字体替换：
```javascript
// 加载演示文稿
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 加载将被替换的源字体
    var sourceFont = new aspose.slides.FontData("Arial");
    // 加载新字体
    var destFont = new aspose.slides.FontData("Times New Roman");
    // 替换字体
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // 保存演示文稿
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

要设置在特定条件下（例如字体无法访问时）会发生什么的规则，请参阅 [**字体替代**](/slides/zh/nodejs-java/font-substitution/)。

{{% /alert %}}

## **常见问题**

**“字体替换”、“字体替代”和“后备字体”之间有什么区别？**

替换是指在整个文档中有意将一种字体族切换为另一种字体族。[**字体替代**](/slides/zh/nodejs-java/font-substitution/)是一种规则，例如“如果字体不可用，则使用 X”。[**后备字体**](/slides/zh/nodejs-java/fallback-font/)则在缺少特定字形时针对单个字符进行应用，前提是已安装的基础字体不包含所需字符。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会考虑它们。

**嵌入的 OLE 对象（例如 Excel）内部的字体会改变吗？**

不会。[**OLE 内容**](/slides/zh/nodejs-java/manage-ole/)由其所在的应用程序自行控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能会以图像形式或外部可编辑内容显示。

**我可以仅在演示文稿的部分（按幻灯片或区域）替换字体吗？**

如果在所需的对象/范围层级更改字体，而不是对整个文档进行全局替换，则可以实现有针对性的替换。在渲染过程中的整体字体选择逻辑保持不变。

**我如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[**字体管理器**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/)：它提供正在使用的[**字体族列表**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/)以及关于[**替代/“未知”字体**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)的信息，这有助于规划替换。

**在转换为 PDF/图像时，字体替换有效吗？**

是的。在导出时，Aspose.Slides 会使用相同的[**字体选择/替代顺序**](/slides/zh/nodejs-java/font-selection-sequence/)，因此提前进行的替换将在转换过程中得到保留。

**我需要在系统中安装目标字体吗，还是可以附加一个字体文件夹？**

无需安装：库支持从用户文件夹[**加载外部字体**](/slides/zh/nodejs-java/custom-font/)，以用于[**渲染和导出**](/slides/zh/nodejs-java/convert-powerpoint/)。

**替换能修复显示为 “tofu”（方块）而非字符的情况吗？**

仅当目标字体实际上包含所需字形时才会生效。如果没有，请[**配置后备字体**](/slides/zh/nodejs-java/fallback-font/)以覆盖缺失的字符。