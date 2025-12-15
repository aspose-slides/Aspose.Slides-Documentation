---
title: 在 Android 上为演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 精通 Aspose.Slides for Android，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持文本显示一致。"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) 类来指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) 类表示在指定的 Unicode 范围（用于搜索缺失的字形）与可能包含适当字形的字体列表之间的关联：
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Minjo, MS Gothic");

//使用多种方式添加字体列表：
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


也可以 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字体或 [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 添加到现有的 [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) 可用于组织一组 [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) 对象，以便为多个 Unicode 范围指定回退字体替换规则。

{{% alert color="primary" title="另请参见" %}} 
- [创建回退字体集合](/slides/zh/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替换和字体嵌入有何区别？**

回退字体仅在主字体缺少字符时使用。[字体替换](/slides/zh/androidjava/font-substitution/) 将整个指定的字体替换为另一种字体。[字体嵌入](/slides/zh/androidjava/embedded-font/) 将字体打包到输出文件中，以便接收者能够按预期查看文本。

**回退字体是在导出为 PDF、PNG 或 SVG 时应用，还是仅在屏幕渲染时应用？**

是的。回退影响所有 [渲染和导出操作](/slides/zh/androidjava/convert-presentation/)，只要字符必须绘制但在源字体中不存在。

**配置回退会更改演示文稿文件本身吗？该设置在以后打开时会保持吗？**

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 文件中，也不会出现在 PowerPoint 中。

**操作系统（Windows/Linux/macOS）和字体目录集合会影响回退选择吗？**

会。引擎会从可用的系统文件夹以及您提供的任何 [附加路径](/slides/zh/androidjava/custom-font/) 中解析字体。如果字体在物理上不可用，引用该字体的规则将无法生效。

**回退对 WordArt、SmartArt 和图表有效吗？**

会。当这些对象包含文本时，使用相同的字形替换机制来渲染缺失的字符。