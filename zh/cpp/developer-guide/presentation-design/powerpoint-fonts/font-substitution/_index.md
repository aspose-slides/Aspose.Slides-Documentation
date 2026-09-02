---
title: 在 C++ 中配置演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/cpp/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在使用 Aspose.Slides for C++ 渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置字体替代规则并检查被替代的字体。"
---
## **概述**

字体替代允许 Aspose.Slides 在渲染或转换演示文稿时使用可用字体来代替无法访问的字体。替代仅影响渲染输出；它不会更改分配给演示文稿内容的字体。

您可以定义在特定字体不可用时使用的替代字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替代操作。这有助于在安装的字体不同的环境之间保持输出的一致性。

## **获取字体替代**

使用 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 方法确定在渲染演示文稿时会替代哪些字体。该方法返回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsubstitutioninfo/) 对象，用于标识原始字体名称和替代字体名称。

以下 C++ 示例列出了演示文稿的所有字体替代：

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

## **获取选定幻灯片的字体替代**

使用带有 `System::ArrayPtr<int32_t> slides` 参数的 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 重载，仅检查渲染特定幻灯片所需的替代。这在以下场景中非常有用：渲染或导出演示文稿的部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

`slides` 数组包含基于 **1** 的幻灯片索引：`1` 标识第一张幻灯片。相比之下，[Presentation::get_Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slide/) 方法使用 **0** 基的索引，因此同一张幻灯片应写作 `presentation->get_Slide(0)`。构建数组时请记住此差异，以避免 off‑by‑one 错误。

通过 [Presentation::get_FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_fontsmanager/) 方法调用该重载。它仅返回在渲染所选幻灯片时确定的替代。每个结果都是一个 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsubstitutioninfo/) 对象，包含原始字体名称和替代字体名称。结果反映了当前的字体环境、已配置的回退规则、存储在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsubstrulecollection/) 中的替代规则以及 [externally loaded fonts](/slides/zh/cpp/custom-font/)。

同一替代可能被多个选定幻灯片触发。创建字体清单或预检报告时请去重。下面的示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

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

[IFontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/) 接口提供两种重载。根据渲染操作的范围选择使用：

| 重载 | 使用场景 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 无参数 | 您需要获取整个演示文稿的替代字体。 |
| [GetSubstitutions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 带 `System::ArrayPtr<int32_t> slides` 参数 | 您需要针对选定范围、增量检查或部分导出获取替代字体。 |

## **设置字体替代规则**

指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsubstrule/)。  
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsubstrulecollection/)。  
5. 使用 [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) 方法分配该集合。  
6. 渲染或转换演示文稿。

以下 C++ 示例在 `SomeRareFont` 不可用时将 `Arial` 替代为 `SomeRareFont`，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

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
如需对整个演示文稿中使用的字体进行无条件更改，请参阅 [Font Replacement](/slides/zh/cpp/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 可以用规则指定的可用字体替代不可访问的字体时即可生效。

Office Math 公式有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算并渲染公式布局。将其替代为其他数学字体（例如 **STIX Two Math**）的规则无法满足此需求，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装或作为 [external font](/slides/zh/cpp/custom-font/) 加载。

此限制仅适用于公式布局。上述替代规则仍然适用于普通演示文稿文本。

## **常见问题**

**What is the difference between font replacement and font substitution?**  
[Font replacement](/slides/zh/cpp/font-replacement/) 会在整个演示文稿中有意将一种字体更改为另一种字体。字体替代则在满足配置条件（例如原始字体不可用）时，为渲染输出选择替代字体。

**When are substitution rules applied?**  
这些规则在渲染和转换期间参与 [font selection sequence](/slides/zh/cpp/font-selection-sequence/)。使用 `WhenInaccessible` 时，仅在 Aspose.Slides 无法访问源字体时才使用该规则。

**What happens when a font is missing and no substitution rule is configured?**  
Aspose.Slides 会根据其字体选择流程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**Can I load external fonts to avoid substitution?**  
可以。您可以 [load external fonts](/slides/zh/cpp/custom-font/) 让 Aspose.Slides 在渲染和转换期间使用它们。

**Does Aspose distribute fonts with the library?**  
不。您负责提供字体并遵守其许可协议。

**Can substitution results differ between Windows, Linux, and macOS?**  
可以。不同操作系统的已安装字体及搜索位置不同，同一字体在一台机器上可用而在另一台机器上可能需要替代。

**How can I make font selection consistent in batch conversions?**  
在每台机器或容器上使用相同的字体文件和版本，[load required external fonts](/slides/zh/cpp/custom-font/)，并在许可允许时 [embed fonts](/slides/zh/cpp/embedded-font/)。您还可以在导出前调用 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 以识别意外的替代。