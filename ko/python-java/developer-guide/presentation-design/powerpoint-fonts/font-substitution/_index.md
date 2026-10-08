---
title: Python via Java를 사용하여 프레젠테이션에서 글꼴 대체 구성
linktitle: 글꼴 대체
type: docs
weight: 70
url: /ko/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 Python via Java용 Aspose.Slides에서 글꼴 대체 규칙을 구성하고 대체된 글꼴을 검사합니다."
---
## **개요**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

Aspose.Slides에서 특정 글꼴을 사용할 수 없을 때 사용할 글꼴을 정의하고, 렌더링 중에 Aspose.Slides가 수행할 대체를 검사할 수 있습니다. 이를 통해 설치된 글꼴이 다른 환경에서도 출력 결과를 일관되게 유지할 수 있습니다.

If a font is available but has no dedicated bold typeface, see [전용 굵은 글꼴이 없는 글꼴 처리](/slides/ko/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). That section explains how to rasterize the affected text during PDF export and the consequences for text selection, searching, and scaling.

## **글꼴 대체 가져오기**

Use the [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

The following Python example lists all font substitutions for a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **선택한 슬라이드에 대한 글꼴 대체 가져오기**

Use the [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) overload with a Java integer array argument to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The `slides` array contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) collection accessor uses zero-based indexing, so that same slide is accessed as `presentation.getSlides().get_Item(0)`. Keep this difference in mind when building the array to avoid off-by-one errors.

Call the overload through the [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) method. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in a [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/), and [externally loaded fonts](/slides/ko/python-java/custom-font/).

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

The [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) class provides both overloads. Choose one according to the scope of the rendering operation:

| 오버로드 | 사용 시점 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | 선택한 범위, 증분 검사 또는 부분 내보내기가 필요할 때 |

## **글꼴 대체 규칙 설정**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.  
2. Create font definitions for the source and substitute fonts.  
3. Create a [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) with the [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) condition.  
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).  
5. Assign the collection by using the [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) method.  
6. Render or convert the presentation.

The following Python example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
프레젠테이션 전체에서 사용되는 글꼴을 무조건 변경하려면 [Font Replacement](/slides/ko/python-java/font-replacement/)를 참조하십시오.
{{% /alert %}}

## **수학 방정식 글꼴에 대한 제한 사항**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [external font](/slides/ko/python-java/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **FAQ**

**What is the difference between font replacement and font substitution?**  

[Font replacement](/slides/ko/python-java/font-replacement/) intentionally changes one font to another throughout the presentation. Font substitution selects a font for rendered output when the configured condition is met, such as when the original font is unavailable.

**When are substitution rules applied?**  

The rules participate in the [font selection sequence](/slides/ko/python-java/font-selection-sequence/) during rendering and conversion. With `WhenInaccessible`, a rule is used only when Aspose.Slides cannot access the source font.

**What happens when a font is missing and no substitution rule is configured?**  

Aspose.Slides selects the closest available font according to its font selection process. The result depends on the fonts available in the runtime environment.

**Can I load external fonts to avoid substitution?**  

Yes. You can [load external fonts](/slides/ko/python-java/custom-font/) so Aspose.Slides can use them during rendering and conversion.

**Does Aspose distribute fonts with the library?**  

No. You are responsible for providing fonts and complying with their licenses.

**Can substitution results differ between Windows, Linux, and macOS?**  

Yes. Installed fonts and font search locations differ by operating system, so a font available on one machine may require substitution on another.

**How can I make font selection consistent in batch conversions?**  

Use the same font files and versions on every machine or container, [load required external fonts](/slides/ko/python-java/custom-font/), and [embed fonts](/slides/ko/python-java/embedded-font/) when licensing permits. You can also call [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) before export to identify unexpected substitutions.