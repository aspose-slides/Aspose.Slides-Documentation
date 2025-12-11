---
title: 在 С++ 中为演示文稿指定回退字体
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
- С++
- Aspose.Slides
description: "深入了解 Aspose.Slides for С++，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持文本显示一致。"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) 类，以指定应用回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) 类表示在指定的 Unicode 范围（用于搜索缺失字形）与可能包含适当字形的字体列表之间的关联：

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


也可以对现有的 [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) 对象调用 [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) 移除回退字体，或调用 [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) 添加回退字体。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) 可用于组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) 对象，以在需要为多个 Unicode 范围指定回退字体替换规则时使用。

{{% alert color="primary" title="另请参见" %}} 
- [创建回退字体集合](/slides/zh/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替换和字体嵌入之间有什么区别？**

回退字体仅用于主字体中缺失的字符。[字体替换](/slides/zh/cpp/font-substitution/) 用另一个字体替换整个指定的字体。[字体嵌入](/slides/zh/cpp/embedded-font/) 将字体打包到输出文件中，以便接收者能够按预期查看文本。

**回退字体是在导出为 PDF、PNG 或 SVG 时使用，还是仅在屏幕渲染时使用？**

是的。回退会影响所有 [渲染和导出操作](/slides/zh/cpp/convert-presentation/)，只要需要绘制字符但源字体中不存在这些字符。

**配置回退会更改演示文稿文件本身吗？该设置在以后打开时会保留吗？**

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 文件中，也不会出现在 PowerPoint 中。

**操作系统（Windows/Linux/macOS）以及字体目录集合会影响回退选择吗？**

会。引擎会从可用的系统文件夹以及您提供的任何 [附加路径](/slides/zh/cpp/custom-font/) 中解析字体。如果字体实际不存在，则引用该字体的规则无法生效。

**回退适用于 WordArt、SmartArt 和图表吗？**

会。当这些对象包含文本时，同样的字形替换机制会用于渲染缺失的字符。