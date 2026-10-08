---
title: Konfigurera teckensnittssubstitution i presentationer i .NET
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/net/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittssubstitution
- byt teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Konfigurera regler för teckensnittssubstitution och granska substituerade teckensnitt i Aspose.Slides för .NET vid rendering eller konvertering av PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

You can define the font to use when a particular font is unavailable, and you can inspect the substitutions that Aspose.Slides will make during rendering. This helps keep output consistent across environments with different installed fonts.

If a font is available but has no dedicated bold typeface, see [Hantera teckensnitt utan dedikerad fet stil](/slides/sv/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). That section explains how to rasterize the affected text during PDF export and the consequences for text selection, searching, and scaling.

## **Hämta teckensnittssubstitutioner**

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

## **Hämta teckensnittssubstitutioner för valda bilder**

Use the [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) overload with an `int[] slides` argument to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The `slides` array contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection indexer is zero-based, so that same slide is accessed as `presentation.Slides[0]`. Keep this difference in mind when building the array to avoid off-by-one errors.

Call the overload through the [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) property. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment and [externt inlästa teckensnitt](/slides/sv/net/custom-font/). Substitution rules stored in an [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) change the rendered output but are not reflected in the result.

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

| Överlagring | Använd den när |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) utan argument | Du behöver substitutioner för hela presentationen. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) med `int[] slides` | Du behöver substitutioner för ett valt område, inkrementell kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

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
For an unconditional change to the fonts used throughout a presentation, see [Teckensnittsersättning](/slides/sv/net/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [externt teckensnitt](/slides/sv/net/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Teckensnittsersättning](/slides/sv/net/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för renderat utdrag när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**

The rules participate in the [font selection sequence](/slides/sv/net/font-selection-sequence/) during rendering and conversion. With `WhenInaccessible`, a rule is used only when Aspose.Slides cannot access the source font.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**

Aspose.Slides selects the closest available font according to its font selection process. The result depends on the fonts available in the runtime environment.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Yes. You can [load external fonts](/slides/sv/net/custom-font/) so Aspose.Slides can use them during rendering and conversion.

**Distribuerar Aspose teckensnitt med biblioteket?**

No. You are responsible for providing fonts and complying with their licenses.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Yes. Installed fonts and font search locations differ by operating system, so a font available on one machine may require substitution on another.

**Hur kan jag göra teckensnittsvalet konsistent i batchkonverteringar?**

Use the same font files and versions on every machine or container, [load required external fonts](/slides/sv/net/custom-font/), and [embed fonts](/slides/sv/net/embedded-font/) when licensing permits. You can also call [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) before export to identify unexpected substitutions.