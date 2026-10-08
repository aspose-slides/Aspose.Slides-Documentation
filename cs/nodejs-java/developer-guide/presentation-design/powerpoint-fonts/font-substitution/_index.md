---
title: Konfigurace nahrazování písem v prezentacích pomocí JavaScriptu
linktitle: Nahrazování písem
type: docs
weight: 70
url: /cs/nodejs-java/font-substitution/
keywords:
- písmo
- nahrazující písmo
- nahrazování písem
- výměna písma
- nahrazení písma
- pravidlo nahrazování
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurujte pravidla nahrazování písem a prohlédněte nahrazená písma v Aspose.Slides pro Node.js pomocí Javy při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

You can define the font to use when a particular font is unavailable, and you can inspect the substitutions that Aspose.Slides will make during rendering. This helps keep output consistent across environments with different installed fonts.

If a font is available but has no dedicated bold typeface, see [Zpracování písem bez dedikovaného tučného řezu](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). That section explains how to rasterize the affected text during PDF export and the consequences for text selection, searching, and scaling.

## **Získat nahrazení písem**

Use the [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

The following JavaScript example lists all font substitutions for a presentation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Získat nahrazení písem pro vybrané snímky**

Use the [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) overload with an array of slide indexes to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The overload expects a Java primitive `int[]`. Create it with `java.newArray("int", [...])`; a plain JavaScript array is converted to `Integer[]` and does not match this overload.

The array contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) collection accessor uses zero-based indexing, so that same slide is accessed as `presentation.getSlides().get_Item(0)`. Keep this difference in mind when building the array to avoid off-by-one errors.

Call the overload through [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in a [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/), and [externally loaded fonts](/slides/cs/nodejs-java/custom-font/).

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

The [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) class provides both overloads. Choose one according to the scope of the rendering operation:

| Overload | Použijte, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) bez argumentů | Potřebujete nahrazení pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) s Java `int[]` indexů snímků | Potřebujete nahrazení pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavit pravidla nahrazování písem**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.
2. Create font definitions for the source and substitute fonts.
3. Create a [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) with the [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) condition.
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Assign the collection by using the [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) method.
6. Render or convert the presentation.

The following JavaScript example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
For an unconditional change to the fonts used throughout a presentation, see [Nahrazení písma](/slides/cs/nodejs-java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [externí písmo](/slides/cs/nodejs-java/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a nahrazováním písma?**

[Nahrazení písma](/slides/cs/nodejs-java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Nahrazování písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla nahrazování písem použijí?**

The rules participate in the [sekvenci výběru písma](/slides/cs/nodejs-java/font-selection-sequence/) during rendering and conversion. With `WhenInaccessible`, a rule is used only when Aspose.Slides cannot access the source font.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo nahrazování?**

Aspose.Slides selects the closest available font according to its font selection process. The result depends on the fonts available in the runtime environment.

**Mohu načíst externí písma, aby se zabránilo nahrazení?**

Yes. You can [načíst externí písma](/slides/cs/nodejs-java/custom-font/) so Aspose.Slides can use them during rendering and conversion.

**Distribuuje Aspose písma s knihovnou?**

No. You are responsible for providing fonts and complying with their licenses.

**Mohou se výsledky nahrazování lišit mezi Windows, Linux a macOS?**

Yes. Installed fonts and font search locations differ by operating system, so a font available on one machine may require substitution on another.

**Jak zajistit konzistentní výběr písem při dávkových konverzích?**

Use the same font files and versions on every machine or container, [načtěte požadovaná externí písma](/slides/cs/nodejs-java/custom-font/), and [vložte písma](/slides/cs/nodejs-java/embedded-font/) when licensing permits. You can also call [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) before export to identify unexpected substitutions.