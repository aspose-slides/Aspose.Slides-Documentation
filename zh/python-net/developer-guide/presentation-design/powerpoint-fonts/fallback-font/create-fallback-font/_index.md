---
title: 创建后备字体
type: docs
weight: 10
url: /python-net/create-fallback-font/
keywords: "字体, 后备字体, PowerPoint 演示文稿 Python, Aspose.Slides for Python via .NET"
description: "Python 中 PowerPoint 的后备字体"
---

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类来指定应用后备字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类表示指定 Unicode 范围与用于搜索缺失字形的字形列表之间的关联：

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#使用多种方式添加字体列表：
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

还可以 [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) 后备字体或 [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) 可用于组织 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 对象的列表，当需要为多个 Unicode 范围指定后备字体替换规则时。

{{% alert color="primary" title="另见" %}} 
- [创建后备字体集合](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}