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
description: "精通 Aspose.Slides for C++，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持一致的文本显示。"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) 类，以指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) 类表示在指定的 Unicode 范围（用于搜索缺失字形）与可能包含适当字形的字体列表之间的关联：
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


还可以 [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) 回退字体或 [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) 到现有的 [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) 可用于组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) 对象，以在需要为多个 Unicode 范围指定回退字体替换规则时使用。

{{% alert color="primary" title="另请参阅" %}} 
- [Create Fallback Fonts Collection](/slides/zh/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替代和字体嵌入之间有什么区别？**

回退字体仅在主字体缺少字符时使用。[Font substitution](/slides/zh/cpp/font-substitution/) 用另一个字体替换整个指定的字体。[Font embedding](/slides/zh/cpp/embedded-font/) 将字体打包到输出文件中，使接收者能够按预期查看文本。

**回退字体是在导出为 PDF、PNG 或 SVG 时应用，还是仅在屏幕渲染时应用？**

是的。回退会影响所有需要绘制字符但源字体中缺失的 [渲染和导出操作](/slides/zh/cpp/convert-presentation/)。

**配置回退会改变演示文稿文件本身吗？该设置在以后打开时会保持吗？**

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 中，也不会出现在 PowerPoint 中。

**操作系统（Windows/Linux/macOS）及字体目录集合会影响回退选择吗？**

是的。引擎会从可用的系统文件夹以及您提供的任何 [额外路径](/slides/zh/cpp/custom-font/) 中解析字体。如果字体实际不可用，引用该字体的规则将无法生效。

**回退对 WordArt、SmartArt 和图表有效吗？**

是的。当这些对象包含文本时，使用相同的字形替换机制来渲染缺失的字符。