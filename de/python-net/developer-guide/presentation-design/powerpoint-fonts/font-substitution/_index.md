---
title: Font-Substitution in Präsentationen mit Python konfigurieren
linktitle: Font-Substitution
type: docs
weight: 70
url: /de/python-net/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Substitution
- Schriftart austauschen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für Python über .NET beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Font substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die Schriftart, die dem Präsentationsinhalt zugewiesen ist.

Sie können festlegen, welche Schriftart verwendet werden soll, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides während des Renderns vornimmt. Dies hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

## **Abrufen von Font Substitutions**

Verwenden Sie die [FontsManager.get_substitutions](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_substitutions/)‑Methode, um zu ermitteln, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die den ursprünglichen und den substituierten Schriftartnamen identifizieren.

Das folgende Python‑Beispiel listet alle Font Substitutions für eine Präsentation auf:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Abrufen von Font Substitutions für ausgewählte Folien**

Verwenden Sie [FontsManager.get_substitutions](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_substitutions/) mit einer Liste von Folien‑Indizes, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation schrittweise überprüfen, Folien finden möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren wollen, ohne unverwandte Folien zu verarbeiten.

Die Liste enthält ein‑basiert nummerierte Folien‑Indizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu ist die [Presentation.slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slides/de/)‑Sammlung nullbasiert, sodass dieselbe Folie über `presentation.slides[0]` angesprochen wird. Beachten Sie diesen Unterschied beim Erstellen der Liste, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Methode über die [Presentation.fonts_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/fonts_manager/)‑Eigenschaft auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jedes Ergebnis ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsubstitutioninfo/)‑Objekt, das den ursprünglichen und den substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [IFontSubstRuleCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriftarten](/slides/de/python-net/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Deduplizieren Sie die Ergebnisse, wenn Sie ein Schrift‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Die [FontsManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/)‑Klasse stellt beide Varianten der Methode bereit. Wählen Sie je nach Umfang des Rendering‑Vorgangs:

| Methodenaufruf | Verwenden Sie sie, wenn |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_substitutions/) ohne Argumente | Sie Substitutionen für die gesamte Präsentation benötigen. |
| [get_substitutions](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_substitutions/) mit einer Liste von Folien‑Indizes | Sie Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen Teil‑Export benötigen. |

## **Festlegen von Font Substitution Rules**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftart‑Definitionen für die Quell‑ und Ersatzschriftarten.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsubstrule/) mit der [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsubstcondition/)‑Bedingung.
4. Fügen Sie die Regel zu einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung der [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/font_subst_rule_list/)‑Eigenschaft zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Python‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/python-net/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Math‑Equation‑Schriftarten**

Font Substitution Rules sind Teil des standardmäßigen Schriftart‑Auswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Verwendet eine Gleichung **Cambria Math**, muss Aspose.Slides genau diese Schriftart zur Berechnung und zum Rendern des Gleichungs‑Layouts bereitstehen. Eine Regel, die eine andere mathematische Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering meldet möglicherweise weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/python-net/custom-font/) laden.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

[Font replacement](/slides/de/python-net/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Font substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die ursprüngliche Schriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/python-net/font-selection-sequence/)‑Prozess während Rendering und Konvertierung teil. Mit `WHEN_INACCESSIBLE` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten liegende verfügbare Schriftart gemäß seinem Schriftart‑Auswahlprozess. Das Ergebnis hängt von den im Runtime‑Umfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [external fonts](/slides/de/python-net/custom-font/) laden, damit Aspose.Slides sie beim Rendering und bei der Konvertierung verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können sich Substitutionsergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade unterscheiden sich je nach Betriebssystem, sodass eine auf einem Rechner verfügbare Schriftart auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/python-net/custom-font/) und [betten Sie Schriftarten ein](/slides/de/python-net/embedded-font/), sofern die Lizenz dies zulässt. Sie können außerdem vor dem Export [FontsManager.get_substitutions](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_substitutions/) aufrufen, um unerwartete Substitutionen zu erkennen.