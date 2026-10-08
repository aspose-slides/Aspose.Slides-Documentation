---
title: 在 C++ 中配置演示文稿的字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/cpp/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替换
- 替换字体
- 字体替换
- 替换规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中配置字体替换规则并检查在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时被替代的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在渲染或转换演示文稿时使用可用的字体来替代无法访问的字体。替换仅影响渲染输出；它不会更改演示文稿内容中分配的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染过程中将进行的替换。这有助于在安装了不同字体的环境中保持输出的一致性。

如果字体可用但没有专用的粗体字形，请参阅[处理没有专用粗体字形的字体](/slides/zh/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。该章节解释了在 PDF 导出期间如何对受影响的文本进行光栅化以及对文本选择、搜索和缩放的影响。

## **获取字体替换**

使用[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)方法来确定在渲染演示文稿时将会替换哪些字体。该方法返回[FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)对象，这些对象标识原始字体名称和替代字体名称。

下面的 C++ 示例列出了演示文稿的所有字体替换：

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **获取选定幻灯片的字体替换**

使用带有 `System::ArrayPtr<int32_t> slides` 参数的[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)重载，仅检查渲染特定幻灯片所需的替换。当您仅渲染或导出演示文稿的部分内容、增量检查大型演示文稿、定位依赖于不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时，此功能非常有用。

`slides` 数组包含从 1 开始的幻灯片索引：`1` 标识第一张幻灯片。相比之下，[Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 方法使用从 0 开始的索引，因此同一张幻灯片应写作 `presentation->get_Slide(0)`。在构建数组时请记住此差异，以避免因偏移导致的错误。

通过[Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/)方法调用该重载。它仅返回在渲染所选幻灯片时确定的替换。每个结果都是一个[FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)对象，包含原始字体名称和替代字体名称。结果反映了当前的字体环境、已配置的回退规则、存储在[IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/)中的替换规则，以及[外部加载的字体](/slides/zh/cpp/custom-font/)。

相同的替换可能被多个选定幻灯片所需。在创建字体清单或预检报告时请对结果去重。下面的示例报告每个返回的替换，然后创建唯一字体映射的已排序列表：

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

[IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) 接口提供了两个重载。根据渲染操作的范围选择使用：

| 重载 | 使用场景 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)（无参数） | 需要获取整个演示文稿的替换。 |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)（带 `System::ArrayPtr<int32_t> slides`） | 需要获取选定范围、增量检查或局部导出的替换。 |

## **设置字体替换规则**

指定当源字体不可用时 Aspose.Slides 应使用的替代字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用[WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/)条件创建[FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/)。  
4. 将规则添加到[FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/)。  
5. 通过[IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)方法分配该集合。  
6. 渲染或转换演示文稿。

下面的 C++ 示例在 `SomeRareFont` 不可用时用 `Arial` 替代它，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
若要无条件地更改整个演示文稿使用的字体，请参阅[字体替换](/slides/zh/cpp/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换过程中标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 能够用规则指定的可用字体替换不可访问的字体时即可生效。

Office Math 公式还有额外的需求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算和渲染公式布局。将其他数学字体（例如 **STIX Two Math**）设为替代的规则无法取代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装或作为[外部字体](/slides/zh/cpp/custom-font/)加载。

此限制仅适用于公式布局。上述替换规则仍适用于普通演示文稿文本。

## **常见问题**

**Font Replacement 与 Font Substitution 有何区别？**

[Font replacement](/slides/zh/cpp/font-replacement/) 会在整个演示文稿中有意地将一种字体更改为另一种字体。Font substitution 在满足配置条件（例如原始字体不可用）时为渲染输出选择替代字体。

**替换规则何时生效？**

这些规则在渲染和转换期间参与[字体选择序列](/slides/zh/cpp/font-selection-sequence/)。使用 `WhenInaccessible` 时，仅当 Aspose.Slides 无法访问源字体时才会使用该规则。

**如果缺少字体且未配置替换规则会怎样？**

Aspose.Slides 会根据其字体选择流程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替换吗？**

可以。您可以[加载外部字体](/slides/zh/cpp/custom-font/)，让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 会随库分发字体吗？**

不会。您需自行提供字体并遵守其许可证。

**不同操作系统（Windows、Linux、macOS）之间的替换结果会不同吗？**

会。各操作系统的已安装字体和字体搜索位置不同，某台机器可用的字体在另一台机器上可能需要替换。

**如何在批量转换中保持字体选择的一致性？**

在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/cpp/custom-font/)，并在许可允许的情况下[嵌入字体](/slides/zh/cpp/embedded-font/)。您也可以在导出前调用[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)以识别意外的替换。