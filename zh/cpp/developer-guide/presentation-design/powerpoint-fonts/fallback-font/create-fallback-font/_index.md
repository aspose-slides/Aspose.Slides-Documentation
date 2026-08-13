---
title: 在 C++ 中为演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/cpp/create-fallback-font/
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
- C++
- Aspose.Slides
description: "掌握 Aspose.Slides for C++，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上文本显示一致。"
---
## **概述**

Aspose.Slides 允许您为演示文稿的渲染和导出操作指定回退字体。当主字体不包含特定字符的字形时，会使用回退字体。

回退行为通过回退规则进行配置。每条规则将 Unicode 范围与可能包含所需字形的一个或多个字体关联。您可以为不同字符范围定义规则，向现有规则添加或移除回退字体，并在回退字体规则集合中组织多条规则。

回退规则是运行时渲染设置。它们不会修改演示文稿文件本身，也不会存储在 PPTX 文件内部。

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontfallbackrule/) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/) 类，以指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/) 类表示指定的 Unicode 范围（用于搜索缺失的字形）与可能包含正确字形的字体列表之间的关联：

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// 使用多种方式添加字体列表:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

也可以对已有的 [FontFallBackRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/) 对象使用 [Remove()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontfallbackrule/remove/) 移除回退字体，或使用 [AddFallBackFonts()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) 添加回退字体。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrulescollection/) 可用于组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/) 对象，以在需要为多个 Unicode 范围指定回退字体替换规则时使用。

{{% alert color="info" title="See also" %}} 
- [创建回退字体集合](/slides/zh/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

### 什么是回退字体、字体替换和字体嵌入之间的区别？

回退字体仅在主字体缺少字符时使用。[Font substitution](/slides/zh/cpp/font-substitution/) 将整个指定的字体替换为另一种字体。[Font embedding](/slides/zh/cpp/embedded-font/) 将字体打包到输出文件中，使接收者能够按预期查看文本。

### 回退字体是在导出为 PDF、PNG 或 SVG 时应用，还是仅在屏幕渲染时应用？

是的。回退会影响所有需要绘制字符但源字体中不存在这些字符的 [rendering and export operations](/slides/zh/cpp/convert-presentation/)。

### 配置回退会改变演示文稿文件本身吗？该设置会在以后打开时保留下来吗？

不会。回退规则是您代码中的运行时渲染设置；它们不会存储在 .pptx 文件中，也不会在 PowerPoint 中出现。

### 操作系统（Windows/Linux/macOS）以及字体目录的集合会影响回退选择吗？

会。引擎会从可用的系统文件夹以及您提供的任何 [additional paths](/slides/zh/cpp/custom-font/) 中解析字体。如果字体在物理上不可用，引用该字体的规则将无法生效。

### 回退是否适用于 WordArt、SmartArt 和图表？

会。 当这些对象包含文本时，同样的字形替换机制会用于渲染缺失的字符。