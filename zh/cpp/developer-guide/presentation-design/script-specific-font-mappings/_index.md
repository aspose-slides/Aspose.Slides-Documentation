---
title: 管理 C++ 中的脚本特定主题字体
linktitle: 脚本特定主题字体
type: docs
weight: 15
url: /zh/cpp/script-specific-font-mappings/
keywords:
- 脚本特定字体
- 主题字体映射
- 多语言演示文稿
- 书写系统
- 西里尔字体
- 阿拉伯字体
- 日文字体
- 格鲁吉亚字体
- 塔纳字体
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 检查、添加、替换和删除 PowerPoint 主题中的脚本特定字体映射。"
---
## **概述**

演示文稿主题可以为不同的书写系统选择不同的字体族。这使得使用主题字体的多语言文本能够在遵循统一的字体方案的同时，为西里尔文、阿拉伯文、日文、格鲁吉亚文、塔纳文等脚本使用合适的字体。

主题的[IFontScheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/ifontscheme/)包含一个主要字体集合（通常用于标题）和一个次要字体集合（通常用于正文）。除了它们的拉丁和东亚字体属性外，这两个集合都通过[IFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifonts/)接口公开从书写系统标签到字体族名称的映射。

本文展示了如何检查和修改演示文稿主主题中的这些映射，并验证更改在保存‑重新加载周期中是否得以保留。

## **了解脚本标签**

脚本字体方法使用四字符 BCP 47 脚本子标签来标识书写系统。常见值包括：

| 脚本标签 | 书写系统 |
|---|---|
| `Cyrl` | 西里尔文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 简体中文 |
| `Jpan` | 日文 |
| `Geor` | 格鲁吉亚文 |
| `Thaa` | 塔纳文 |

这些映射属于主题字体方案，而不是单个文本段落。演示文稿可以为主要和次要集合定义不同的映射，也可以对某些脚本省略映射。

## **访问并检查脚本字体映射**

使用[Presentation::get_MasterTheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_mastertheme/)获取演示文稿级别的主题。[FontScheme::get_Major](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/fontscheme/get_major/)和[FontScheme::get_Minor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/fontscheme/get_minor/)方法返回两个[IFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifonts/)集合。

调用[Fonts::GetScriptFontMap](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fonts/getscriptfontmap/)可检索集合中的所有映射。要查找某个书写系统，使用其脚本标签调用[Fonts::GetScriptFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fonts/getscriptfont/)。当该集合未定义请求的映射时，`GetScriptFont`返回空字符串。

## **修改映射并验证持久化**

使用[Fonts::SetScriptFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fonts/setscriptfont/)创建映射或替换其当前的字体族。使用[Fonts::RemoveScriptFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fonts/removescriptfont/)删除映射。

下面的端到端示例读取所有现有的主要和次要映射，查找日文主要字体，修改西里尔文主要字体，删除塔纳文次要映射，保存演示文稿并重新打开以验证两项更改。为了使删除步骤独立于初始主题，示例仅在未定义塔纳文映射时才创建该映射。

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

验证使用与普通查找相同的空字符串行为：删除后保存时，`GetScriptFont(u"Thaa")`对次要集合返回空字符串。

## **区分主题映射与其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的问题不同于直接的文本格式化、替换和回退：

| 机制 | 目的 | 更改主题映射的影响 |
|---|---|---|
| 脚本特定主题字体映射 | 为书写系统选择主要或次要主题字体。 | 仍使用相应主题字体的文本可以解析为新的映射字体族。 |
| 显式分配给文本段落的字体 | 将请求的字体族固定在该段落上，而不是依赖主题。 | 由于直接格式化覆盖了主题选择，该段落可能保持不变。 |
| 字体替换 | 当请求的字体不可用或符合替换规则时替换请求的字体。 | 它在请求字体后生效；不重新定义主题的脚本映射。 |
| 字体回退 | 为所选字体不包含的字形提供补充，通常针对特定 Unicode 范围。 | 它填补缺失字形覆盖；不更改已存储的主题映射。 |

有关后两种机制的更多信息，请参阅[Font Substitution](/slides/zh/cpp/font-substitution/)和[Fallback Fonts](/slides/zh/cpp/fallback-font/)。

在[Presentation::get_MasterTheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_mastertheme/)中更改映射仅影响其有效格式仍依赖该主题的内容。当可见结果未遵循演示文稿级别映射时，请检查主模板、布局或幻灯片层级的覆盖，或检查是否使用了显式分配的字体。

## **使映射字体可用并验证结果**

脚本映射仅存储字体族名称；它不会安装或加载对应的字体文件。为实现一致的渲染和导出，必须在环境中安装每个映射的字体，或通过自定义来源（如[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/loadexternalfonts/)或[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)）提供给 Aspose.Slides。请参阅[Custom Fonts](/slides/zh/cpp/custom-font/)了解可用的加载选项。

验证已保存的映射仅确认主题定义被保留，并不证明该字体可用、包含所有必需字形或产生预期布局。应将每个必需书写系统的代表性文本渲染为图像或 PDF 并检查输出，以捕获缺失字体、字形覆盖不足、回退行为以及布局变化。有关渲染和导出示例，请参阅[Convert PowerPoint Presentations](/slides/zh/cpp/convert-powerpoint/)。

## **常见问题**

**当脚本未映射时，`GetScriptFont` 返回什么？**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fonts/getscriptfont/)在请求的脚本映射未在该主要或次要字体集合中定义时返回空字符串。

**当脚本已存在时，`SetScriptFont` 会添加第二个映射吗？**

不会。[Fonts::SetScriptFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fonts/setscriptfont/)在缺失时创建映射，若相同脚本标签已存在则替换已映射的字体族。

**为何更改主题映射后某些文本未变化？**

该文本可能显式分配了字体、通过覆盖继承了不同的主题，或在渲染期间受到替换或回退的影响。演示文稿级别的脚本映射仅控制其有效格式仍引用该主题字体集合的文本。

**仅保存并重新打开能验证多语言输出吗？**

不能。重新打开只能验证主题数据的持久性，还需渲染每个必需书写系统的代表性文本，以确认映射字体可用且包含所需字形。