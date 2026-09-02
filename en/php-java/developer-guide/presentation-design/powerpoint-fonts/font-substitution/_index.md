---
title: Configure Font Substitution in Presentations Using PHP
linktitle: Font Substitution
type: docs
weight: 70
url: /php-java/font-substitution/
keywords:
- font
- substitute font
- font substitution
- replace font
- font replacement
- substitution rule
- replacement rule
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Configure font substitution rules and inspect substituted fonts in Aspose.Slides for PHP via Java when rendering or converting PowerPoint and OpenDocument presentations."
---

## **Overview**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

You can define the font to use when a particular font is unavailable, and you can inspect the substitutions that Aspose.Slides will make during rendering. This helps keep output consistent across environments with different installed fonts.

## **Get Font Substitutions**

Use the [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

The following PHP example lists all font substitutions for a presentation:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Get Font Substitutions for Selected Slides**

Use the [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) overload with an `int[] slides` argument to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The `slides` array contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) collection accessor uses zero-based indexing, so that same slide is accessed as `$presentation->getSlides()->get_Item(0)`. Keep this difference in mind when building the array to avoid off-by-one errors.

Call the overload through the [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getFontsManager) method. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in a [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/), and [externally loaded fonts](/slides/php-java/custom-font/).

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

The [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) class provides both overloads. Choose one according to the scope of the rendering operation:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | You need substitutions for the entire presentation. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | You need substitutions for a selected range, incremental check, or partial export. |

## **Set Font Substitution Rules**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.
2. Create font definitions for the source and substitute fonts.
3. Create a [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) with the [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) condition.
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Assign the collection by using the [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) method.
6. Render or convert the presentation.

The following PHP example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

For an unconditional change to the fonts used throughout a presentation, see [Font Replacement](/slides/php-java/font-replacement/).

{{% /alert %}}

## **Limitations for Math Equation Fonts**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [external font](/slides/php-java/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Font replacement](/slides/php-java/font-replacement/) intentionally changes one font to another throughout the presentation. Font substitution selects a font for rendered output when the configured condition is met, such as when the original font is unavailable.

**When are substitution rules applied?**

The rules participate in the [font selection sequence](/slides/php-java/font-selection-sequence/) during rendering and conversion. With `WhenInaccessible`, a rule is used only when Aspose.Slides cannot access the source font.

**What happens when a font is missing and no substitution rule is configured?**

Aspose.Slides selects the closest available font according to its font selection process. The result depends on the fonts available in the runtime environment.

**Can I load external fonts to avoid substitution?**

Yes. You can [load external fonts](/slides/php-java/custom-font/) so Aspose.Slides can use them during rendering and conversion.

**Does Aspose distribute fonts with the library?**

No. You are responsible for providing fonts and complying with their licenses.

**Can substitution results differ between Windows, Linux, and macOS?**

Yes. Installed fonts and font search locations differ by operating system, so a font available on one machine may require substitution on another.

**How can I make font selection consistent in batch conversions?**

Use the same font files and versions on every machine or container, [load required external fonts](/slides/php-java/custom-font/), and [embed fonts](/slides/php-java/embedded-font/) when licensing permits. You can also call [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) before export to identify unexpected substitutions.
