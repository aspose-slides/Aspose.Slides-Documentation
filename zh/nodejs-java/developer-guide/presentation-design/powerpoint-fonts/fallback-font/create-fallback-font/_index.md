---
title: 创建回退字体
type: docs
weight: 10
url: /zh/nodejs-java/create-fallback-font/
---

## **回退规则**

Aspose.Slides 支持 [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) 类和 [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) 类来指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) 类表示在指定的 Unicode 范围（用于搜索缺失的字形）与可能包含适当字形的字体列表之间的关联：
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// 使用多种方式添加字体列表:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


也可以 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字体或 [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 添加到现有的 [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) 可用于组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) 对象，以便在需要为多个 Unicode 范围指定回退字体替换规则时使用。

{{% alert color="primary" title="See also" %}} 
- [创建回退字体集合](/slides/zh/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替换和字体嵌入之间有什么区别？**

回退字体仅在主字体缺少字符时使用。[Font substitution](/slides/zh/nodejs-java/font-substitution/) 将整个指定字体替换为另一个字体。[Font embedding](/slides/zh/nodejs-java/embedded-font/) 将字体打包到输出文件中，使接收者能够按预期查看文本。

**回退字体是应用于 PDF、PNG、SVG 等导出时，还是仅在屏幕渲染时生效？**

是的。回退会影响所有需要绘制字符但源字体中不存在的情况，包括 [rendering and export operations](/slides/zh/nodejs-java/convert-presentation/)。

**配置回退会修改演示文稿文件本身吗？此设置在以后打开时会保留吗？**

不会。回退规则是代码中的运行时渲染设置，不会存储在 .pptx 文件中，也不会在 PowerPoint 中显示。

**操作系统 (Windows/Linux/macOS) 和字体目录集合会影响回退选择吗？**

会。引擎会从系统可用的文件夹以及您提供的任何 [additional paths](/slides/zh/nodejs-java/custom-font/) 中解析字体。如果字体实际不存在，则引用该字体的规则无法生效。

**回退在 WordArt、SmartArt 和图表中有效吗？**

会。当这些对象包含文本时，会使用相同的字形替换机制来渲染缺失的字符。