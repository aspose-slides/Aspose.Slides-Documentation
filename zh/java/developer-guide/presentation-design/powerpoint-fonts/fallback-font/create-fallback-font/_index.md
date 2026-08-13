---
title: 在 Java 中为演示文稿指定后备字体
linktitle: 后备字体
type: docs
weight: 10
url: /zh/java/create-fallback-font/
keywords:
- 后备字体
- 后备规则
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
description: "精通 Aspose.Slides for Java，在 PPT、PPTX 和 ODP 文件中设置后备字体，确保在任何设备或操作系统上文本显示一致。"
---
## **概述**

Aspose.Slides 允许您为演示文稿的渲染和导出操作指定后备字体。当主字体不包含特定字符的字形时，会使用后备字体。

后备行为通过后备规则进行配置。每个规则将 Unicode 范围与一个或多个可能包含所需字形的字体关联。您可以为不同字符范围定义规则、从现有规则中添加或移除后备字体，并在后备字体规则集合中组织多个规则。

后备规则是运行时渲染设置。它们不会修改演示文稿文件本身，也不会存储在 PPTX 文件中。

## **后备规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule) 类，以指定应用后备字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule) 类表示指定的 Unicode 范围（用于搜索缺失字形）与可能包含正确字形的字体列表之间的关联：

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多种方式添加字体列表：
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以 [remove](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 后备字体或 [addFallBackFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRulesCollection) 可用于组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontFallBackRule) 对象，以便在需要为多个 Unicode 范围指定后备字体替换规则时使用。

{{% alert color="info" title="另请参见" %}} 
- [创建后备字体集合](/slides/zh/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

### 回退字体、字体替换和字体嵌入之间有什么区别？

后备字体仅用于主字体中缺失的字符。[Font substitution](/slides/zh/java/font-substitution/) 将整个指定字体替换为另一个字体。[Font embedding](/slides/zh/java/embedded-font/) 将字体打包到输出文件中，以便接收者能够按预期查看文本。

### 后备字体是仅在屏幕渲染时生效，还是在 PDF、PNG、SVG 等导出时也会应用？

是的。后备字体会影响所有需要绘制字符但源字体中缺失的 [rendering and export operations](/slides/zh/java/convert-presentation/)（渲染和导出操作）。

### 配置后备字体会更改演示文稿文件本身吗？设置会在以后打开时保持吗？

不会。后备规则是您代码中的运行时渲染设置；它们不会存储在 .pptx 中，也不会出现在 PowerPoint 中。

### 操作系统（Windows/Linux/macOS）及字体目录集合会影响后备字体的选择吗？

会。引擎会从可用的系统文件夹以及您提供的任何 [additional paths](/slides/zh/java/custom-font/)（附加路径）中解析字体。如果某个字体实际不可用，则引用该字体的规则无法生效。

### 后备字体在 WordArt、SmartArt 和图表中是否有效？

是的。当这些对象包含文本时，同样的字形替换机制会用于渲染缺失的字符。