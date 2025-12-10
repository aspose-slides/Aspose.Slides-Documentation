---
title: 在 Java 中为演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/java/create-fallback-font/
keywords:
- 回退字体
- 回退规则
- 应用字体
- 替换字体
- Unicode 范围
- 缺失字形
- 正确字形
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "精通 Aspose.Slides for Java，以在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持一致的文本显示。"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 类，以指定应用回退字体的规则。 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 类表示在指定的 Unicode 范围内搜索缺失字形时，与可能包含正确字形的字体列表之间的关联：
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


也可以 [remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字体或 [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) 可用于组织一组 [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) 对象的列表，以便在需要为多个 Unicode 区间指定回退字体替换规则时使用。

{{% alert color="primary" title="另请参阅" %}} 
- [创建回退字体集合](/slides/zh/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替换和字体嵌入之间有什么区别？**

回退字体仅在主字体缺少字符时使用。[Font substitution](/slides/zh/java/font-substitution/) 将整个指定的字体替换为另一种字体。[Font embedding](/slides/zh/java/embedded-font/) 将字体打包到输出文件中，以便接收者能够按预期查看文本。

**回退字体是仅在导出为 PDF、PNG 或 SVG 时应用，还是仅在屏幕渲染时应用？**

是的。回退会影响所有在字符需要绘制但源字体中不存在时的[渲染和导出操作](/slides/zh/java/convert-presentation/)。

**配置回退会更改演示文稿文件本身吗？该设置在以后打开时会保留吗？**

不会。回退规则是代码中的运行时渲染设置，不会存储在 .pptx 文件中，也不会在 PowerPoint 中显示。

**操作系统（Windows/Linux/macOS）和字体目录集合会影响回退选择吗？**

是的。引擎会从可用的系统文件夹以及您提供的任何[附加路径](/slides/zh/java/custom-font/)中解析字体。如果字体实际上不可用，引用该字体的规则将无法生效。

**回退对 WordArt、SmartArt 和图表有效吗？**

是的。当这些对象包含文本时，相同的字形替换机制会用于渲染缺失的字符。