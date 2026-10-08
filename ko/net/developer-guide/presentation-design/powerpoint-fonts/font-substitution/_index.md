---
title: .NET에서 프레젠테이션의 글꼴 대체 구성
linktitle: 글꼴 대체
type: docs
weight: 70
url: /ko/net/font-substitution/
keywords:
- 글꼴
- 대체 글꼴
- 글꼴 대체
- 글꼴 교체
- 글꼴 교체
- 대체 규칙
- 교체 규칙
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint와 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 .NET용 Aspose.Slides에서 글꼴 대체 규칙을 구성하고 대체된 글꼴을 검사합니다."
---
## **개요**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

특정 글꼴이 사용 불가능할 때 사용할 글꼴을 정의할 수 있으며, Aspose.Slides가 렌더링 중에 수행할 대체 작업을 확인할 수 있습니다. 이를 통해 서로 다른 설치된 글꼴을 가진 환경에서도 출력 일관성을 유지할 수 있습니다.

If a font is available but has no dedicated bold typeface, see [전용 굵은 글꼴이 없는 글꼴 처리](/slides/ko/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). That section explains how to rasterize the affected text during PDF export and the consequences for text selection, searching, and scaling.

## **글꼴 대체 가져오기**

Use the [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

The following C# example lists all font substitutions for a presentation:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **선택된 슬라이드에 대한 글꼴 대체 가져오기**

Use the [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) overload with an `int[] slides` argument to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The `slides` array contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection indexer is zero-based, so that same slide is accessed as `presentation.Slides[0]`. Keep this difference in mind when building the array to avoid off-by-one errors.

Call the overload through the [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) property. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment and [externally loaded fonts](/slides/ko/net/custom-font/). Substitution rules stored in an [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) change the rendered output but are not reflected in the result.

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

The [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interface provides both overloads. Choose one according to the scope of the rendering operation:

| 오버로드 | 다음과 같은 경우에 사용 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | 전체 프레젠테이션에 대한 대체가 필요할 때. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | 선택된 범위, 증분 검사 또는 부분 내보내기가 필요할 때. |

## **글꼴 대체 규칙 설정**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.
2. Create font definitions for the source and substitute fonts.
3. Create a [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) with the [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) condition.
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Assign the collection to the [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) property.
6. Render or convert the presentation.

The following C# example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
For an unconditional change to the fonts used throughout a presentation, see [Font Replacement](/slides/ko/net/font-replacement/).
{{% /alert %}}

## **수식 글꼴에 대한 제한 사항**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [external font](/slides/ko/net/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **FAQ**

**글꼴 교체와 글꼴 대체의 차이점은 무엇입니까?**

[Font replacement](/slides/ko/net/font-replacement/) intentionally changes one font to another throughout the presentation. Font substitution selects a font for rendered output when the configured condition is met, such as when the original font is unavailable.

**대체 규칙은 언제 적용됩니까?**

The rules participate in the [font selection sequence](/slides/ko/net/font-selection-sequence/) during rendering and conversion. With `WhenInaccessible`, a rule is used only when Aspose.Slides cannot access the source font.

**글꼴이 없고 대체 규칙이 구성되지 않은 경우 어떻게 됩니까?**

Aspose.Slides selects the closest available font according to its font selection process. The result depends on the fonts available in the runtime environment.

**외부 글꼴을 로드하여 대체를 방지할 수 있습니까?**

Yes. You can [load external fonts](/slides/ko/net/custom-font/) so Aspose.Slides can use them during rendering and conversion.

**Aspose는 라이브러리와 함께 글꼴을 배포합니까?**

No. You are responsible for providing fonts and complying with their licenses.

**Windows, Linux, macOS 간에 대체 결과가 다를 수 있습니까?**

Yes. Installed fonts and font search locations differ by operating system, so a font available on one machine may require substitution on another.

**일괄 변환 시 글꼴 선택을 일관되게 유지하려면 어떻게 해야 합니까?**

Use the same font files and versions on every machine or container, [load required external fonts](/slides/ko/net/custom-font/), and [embed fonts](/slides/ko/net/embedded-font/) when licensing permits. You can also call [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) before export to identify unexpected substitutions.