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
description: "通过 Java 掌握适用于 Android 的 Aspose.Slides，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持一致的文本显示。"
---
## **概述**

Aspose.Slides 允许您为演示文稿的渲染和导出操作指定回退字体。当主字体不包含特定字符的字形时，将使用回退字体。

回退行为通过回退规则进行配置。每条规则将一个 Unicode 范围与一个或多个可能包含所需字形的字体关联。您可以为不同的字符范围定义规则、向现有规则中添加或删除回退字体，并在回退字体规则集合中组织多个规则。

回退规则是运行时渲染设置。它们不会修改演示文稿文件本身，也不会存储在 PPTX 文件中。

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule) 类来指定要应用的回退字体规则。[FontFallBackRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule) 类表示指定的 Unicode 范围（用于搜索缺失的字形）与可能包含正确字形的字体列表之间的关联：

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多种方式添加字体列表:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

还可以 [remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字体或 [addFallBackFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule) 对象中。

可以使用 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRulesCollection) 来组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule) 对象，以便为多个 Unicode 范围指定回退字体替换规则。

{{% alert color="info" title="另请参阅" %}} 
- [Create Fallback Fonts Collection](/slides/zh/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题解答**

### 回退字体、字体替换和字体嵌入之间有什么区别？

回退字体仅在主字体缺少字符时使用。[字体替换](/slides/zh/androidjava/font-substitution/) 会将整个指定的字体替换为另一种字体。[字体嵌入](/slides/zh/androidjava/embedded-font/) 则将字体打包进输出文件，以便接收者能够按预期查看文本。

### 回退字体是在导出为 PDF、PNG 或 SVG 时应用，还是仅在屏幕渲染时生效？

是的。回退会影响所有 [渲染和导出操作](/slides/zh/androidjava/convert-presentation/)，只要需要绘制字符而源字体中不存在这些字符。

### 配置回退会更改演示文稿文件本身吗？此设置会在以后打开时保持吗？

不会。回退规则是您代码中的运行时渲染设置，未存储在 .pptx 文件中，也不会出现在 PowerPoint 中。

### 操作系统（Windows/Linux/macOS）及字体目录集合会影响回退选择吗？

会。引擎会从可用的系统文件夹以及您提供的任何 [附加路径](/slides/zh/androidjava/custom-font/) 中解析字体。如果某个字体在物理上不可用，则引用该字体的规则无法生效。

### 回退是否适用于 WordArt、SmartArt 和图表？

适用。当这些对象包含文本时，同样的字形替换机制会用于渲染缺失的字符。