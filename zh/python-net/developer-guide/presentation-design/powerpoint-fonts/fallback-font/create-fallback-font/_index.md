---
title: 在 Python 中为演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "通过 .NET 使用 Aspose.Slides for Python 设置 PPT、PPTX 和 ODP 文件中的回退字体，确保在任何设备或操作系统上文本显示一致。"
---

## **指定回退字体**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类，以指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 类表示在指定的 Unicode 区间内搜索缺失字形时，与可能包含正确字形的字体列表的关联：

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#使用多种方式添加字体列表：
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

也可以通过 [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) 移除回退字体，或使用 [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) 将回退字体添加到已有的 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) 可用于组织多个 [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) 对象的列表，以便为多个 Unicode 区间指定回退字体替换规则。

{{% alert color="primary" title="另见" %}} 
- [创建回退字体集合](/slides/zh/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替换和字体嵌入有什么区别？**

回退字体仅在主字体缺少字符时使用。[字体替换](/slides/zh/python-net/font-substitution/) 会将整个指定的字体替换为另一个字体。[字体嵌入](/slides/zh/python-net/embedded-font/) 将字体打包进输出文件，使接收者能够按预期查看文本。

**回退字体是在导出为 PDF、PNG 或 SVG 时生效，还是仅在屏幕渲染时生效？**

是的。回退会影响所有需要绘制但源字体中不存在字符的[渲染和导出操作](/slides/zh/python-net/convert-presentation/)。

**配置回退会改变演示文稿文件本身吗？设置在以后打开时会保留吗？**

不会。回退规则是代码中的运行时渲染设置，不会存储在 .pptx 中，也不会出现在 PowerPoint 中。

**操作系统（Windows/Linux/macOS）和字体目录集合会影响回退选择吗？**

会。引擎会从系统可用文件夹以及您提供的任何[附加路径](/slides/zh/python-net/custom-font/)中解析字体。如果字体在物理上不可用，引用该字体的规则将无法生效。

**回退在 WordArt、SmartArt 和图表中也有效吗？**

有效。当这些对象包含文本时，使用相同的字形替换机制来渲染缺失字符。