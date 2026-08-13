---
title: 为 .NET 中的演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/net/create-fallback-font/
keywords:
- 回退字体
- 回退规则
- 应用字体
- 替换字体
- Unicode 区间
- 缺失字形
- 正确字形
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "掌握 Aspose.Slides for .NET，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上文本显示一致。"
---
## **概述**

Aspose.Slides 允许您为演示文稿的渲染和导出操作指定回退字体。当主字体不包含特定字符的字形时，会使用回退字体。

回退行为通过回退规则进行配置。每个规则将 Unicode 区间与可能包含所需字形的一个或多个字体关联。您可以为不同的字符区间定义规则，向现有规则添加或移除回退字体，并在回退字体规则集合中组织多个规则。

回退规则是运行时渲染设置。它们不会修改演示文稿文件本身，也不会存储在 PPTX 文件中。

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/zh/net/aspose.slides/iFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/zh/net/aspose.slides/FontFallBackRule) 类，用于指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/zh/net/aspose.slides/FontFallBackRule) 类表示指定的 Unicode 区间（用于搜索缺失的字形）与可能包含正确字形的字体列表之间的关联：

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//使用多种方式添加字体列表：
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以对现有的 [FontFallBackRule](https://reference.aspose.com/slides/zh/net/aspose.slides/FontFallBackRule) 对象使用 [Remove()](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontfallbackrule/methods/remove) 移除回退字体，或使用 [AddFallBackFonts()](https://reference.aspose.com/slides/zh/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 添加回退字体。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/zh/net/aspose.slides/fontfallbackrulescollection) 可用于组织一组 [FontFallBackRule](https://reference.aspose.com/slides/zh/net/aspose.slides/FontFallBackRule) 对象，以便为多个 Unicode 区间指定回退字体替换规则。

{{% alert color="info" title="另请参见" %}} 
- [创建回退字体集合](/slides/zh/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

### 回退字体、字体替换和字体嵌入之间有什么区别？

回退字体仅在主字体缺少字符时使用。[字体替换](/slides/zh/net/font-substitution/) 将整个指定的字体替换为另一个字体。[字体嵌入](/slides/zh/net/embedded-font/) 将字体打包在输出文件中，使接收者能够按预期查看文本。

### 回退字体是在导出为 PDF、PNG 或 SVG 时应用，还是仅在屏幕渲染时应用？

是的。回退会影响所有需要绘制字符但源字体中缺少这些字符的 [渲染和导出操作](/slides/zh/net/convert-presentation/)。

### 配置回退会更改演示文稿文件本身吗，设置会在以后打开时保留吗？

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 中，也不会出现在 PowerPoint 中。

### 操作系统（Windows/Linux/macOS）以及字体目录的设置会影响回退选择吗？

会。引擎会从可用的系统文件夹以及您提供的任何 [附加路径](/slides/zh/net/custom-font/) 中解析字体。如果某个字体实际不可用，引用该字体的规则将无法生效。

### 回退对 WordArt、SmartArt 和图表有效吗？

会。当这些对象包含文本时，同样的字形替换机制会用于渲染缺失的字符。