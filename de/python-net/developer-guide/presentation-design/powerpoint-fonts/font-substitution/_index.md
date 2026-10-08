---
title: Schriftart-Substitution in Präsentationen mit Python konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/python-net/font-substitution/
keywords:
- Schriftart
- Ersetzungsschriftart
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie ersetzte Schriftarten in Aspose.Slides für Python über .NET beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und die Substitutionen prüfen, die Aspose.Slides beim Rendern vornimmt. Das hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

If a font is available but has no dedicated bold typeface, see [Schriftarten ohne dedizierten Fettschrifttyp behandeln](/slides/de/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). That section explains how to rasterize the affected text during PDF export and the consequences for text selection, searching, and scaling.

## **Schriftart‑Substitutionen abrufen**

Use the [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

Das folgende Python‑Beispiel listet alle Schriftart‑Substitutionen für eine Präsentation auf:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Schriftart‑Substitutionen für ausgewählte Folien abrufen**

Use [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The list contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection is zero-based, so that same slide is accessed as `presentation.slides[0]`. Keep this difference in mind when building the list to avoid off-by-one errors.

Call the method through the [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) property. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in an [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), and [externally loaded fonts](/slides/de/python-net/custom-font/).

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

The [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) class provides both forms of the method. Choose one according to the scope of the rendering operation:

| Methodaufruf | Verwendung |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Sie benötigen Substitutionen für einen ausgewählten Bereich, inkrementelle Prüfung oder Teil‑Export. |

## **Schriftart‑Substitutionsregeln festlegen**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.
2. Create font definitions for the source and substitute fonts.
3. Create a [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) with the [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) condition.
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Assign the collection to the [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) property.
6. Render or convert the presentation.

The following Python example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
For an unconditional change to the fonts used throughout a presentation, see [Font Replacement](/slides/de/python-net/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten von mathematischen Gleichungen**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [external font](/slides/de/python-net/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **FAQ**

**Was ist der Unterschied zwischen Schriftarten‑Ersetzung und Schriftarten‑Substitution?**

[Font replacement](/slides/de/python-net/font-replacement/) ändert bewusst eine Schriftart überall in der Präsentation zu einer anderen. Schriftarten‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, etwa wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/python-net/font-selection-sequence/) während Rendering und Konvertierung teil. Mit `WHEN_INACCESSIBLE` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was geschieht, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seinem Auswahlprozess. Das Ergebnis hängt von den im Laufzeit‑Umfeld installierten Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**

Ja. Sie können [load external fonts](/slides/de/python-net/custom-font/) sodass Aspose.Slides sie beim Rendering und bei der Konvertierung verwenden kann.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können Substitutionsresultate zwischen Windows, Linux und macOS variieren?**

Ja. Installierte Schriftarten und Suchpfade unterscheiden sich je nach Betriebssystem, sodass eine Schriftart auf einem Rechner verfügbar sein kann, auf einem anderen jedoch substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jeder Maschine oder jedem Container, [load required external fonts](/slides/de/python-net/custom-font/), und [embed fonts](/slides/de/python-net/embedded-font/), wenn die Lizenz es zulässt. Sie können auch vor dem Export [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) aufrufen, um unerwartete Substitutionen zu erkennen.