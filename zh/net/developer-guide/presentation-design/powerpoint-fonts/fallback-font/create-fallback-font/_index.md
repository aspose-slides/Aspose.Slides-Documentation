---
title: 在 .NET 中为演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "精通 Aspose.Slides for .NET，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持文本显示一致。"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 类来指定回退字体的规则。[FontFallBackRule] 类表示在指定的 Unicode 范围（用于搜索缺失的字形）与可能包含适当字形的字体列表之间的关联：
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多种方式可以添加字体列表:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```




也可以 [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) 回退字体或 [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 添加到现有的 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) 可用于组织 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 对象的列表，在需要为多个 Unicode 范围指定回退字体替换规则时。

{{% alert color="primary" title="See also" %}} 
- [创建回退字体集合](/slides/zh/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替换和字体嵌入有什么区别？**

回退字体仅在主字体缺少字符时使用。[字体替换](/slides/zh/net/font-substitution/) 将整个指定的字体替换为另一种字体。[字体嵌入](/slides/zh/net/embedded-font/) 将字体打包在输出文件中，以便接收者能够如预期那样查看文本。

**回退字体是在导出为 PDF、PNG、SVG 等格式时应用，还是仅在屏幕渲染时应用？**

是的。回退会影响所有需要绘制字符但源字体中缺少这些字符的 [渲染和导出操作](/slides/zh/net/convert-presentation/)。

**配置回退会更改演示文稿文件本身吗？该设置在后续打开时会保持吗？**

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 文件中，也不会出现在 PowerPoint 中。

**操作系统（Windows / Linux / macOS）及字体目录集合会影响回退选择吗？**

是的。引擎会从可用的系统文件夹以及您提供的任何 [附加路径](/slides/zh/net/custom-font/) 中解析字体。如果某个字体实际不存在，则引用该字体的规则无法生效。

**回退在 WordArt、SmartArt 和图表中有效吗？**

是的。当这些对象包含文本时，同样的字形替换机制会用于渲染缺失的字符。