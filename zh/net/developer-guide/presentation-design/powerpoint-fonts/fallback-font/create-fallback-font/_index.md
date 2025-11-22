---
title: 创建回退字体
type: docs
weight: 10
url: /zh/net/create-fallback-font/
keywords: "字体, 回退字体, PowerPoint 演示文稿 C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint 中的回退字体（C# 或 .NET）"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 类，用于指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 类表示在指定的 Unicode 范围内搜索缺失字形时，与可能包含相应字形的字体列表之间的关联：
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多种方式添加字体列表:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


也可以 [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) 回退字体或 [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 添加到已有的 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)可用于组织一组 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 对象，以便为多个 Unicode 范围指定回退字体替换规则。

{{% alert color="primary" title="另请参阅" %}} 
- [创建回退字体集合](/slides/zh/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问答**

**回退字体、字体替换和字体嵌入有什么区别？**

回退字体仅在主字体缺少字符时使用。 [字体替换](/slides/zh/net/font-substitution/) 用另一种字体替换整个指定的字体。 [字体嵌入](/slides/zh/net/embedded-font/) 将字体打包到输出文件中，使接收者能够按预期查看文本。

**回退字体是在导出为 PDF、PNG 或 SVG 时生效，还是仅在屏幕渲染时生效？**

是的。回退会影响所有需要绘制字符但源字体中不存在的 [渲染和导出操作](/slides/zh/net/convert-presentation/)。

**配置回退会改变演示文稿文件本身吗？设置会在以后打开时保留吗？**

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 中，也不会出现在 PowerPoint 中。

**操作系统（Windows/Linux/macOS）和字体目录集合会影响回退选择吗？**

会。引擎会从系统可用文件夹以及您提供的任何 [附加路径](/slides/zh/net/custom-font/) 中解析字体。如果字体在物理上不可用，引用该字体的规则将无法生效。

**回退是否适用于 WordArt、SmartArt 和图表？**

会。当这些对象包含文本时，使用相同的字形替换机制来渲染缺失字符。