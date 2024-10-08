---
title: 创建后备字体
type: docs
weight: 10
url: /net/create-fallback-font/
keywords: "字体, 后备字体, PowerPoint 演示 C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中的 PowerPoint 的后备字体"
---

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 类，以指定应用后备字体的规则。 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 类表示用于搜索缺失字形的指定 Unicode 范围与可能包含正确字形的字体列表之间的关联：

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//使用多种方式可以添加字体列表：
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



还可以 [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) 后备字体或 [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) 可用于组织 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) 对象的列表，当需要为多个 Unicode 范围指定后备字体替换规则时。

{{% alert color="primary" title="另请参阅" %}} 
- [创建后备字体集合](/slides/net/create-fallback-fonts-collection/)
{{% /alert %}}