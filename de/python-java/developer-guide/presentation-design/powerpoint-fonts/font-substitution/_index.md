---
title: Konfigurieren von Font-Substitution in Präsentationen mit Python über Java
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/python-java/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Konfigurieren Sie Font-Substitutionsregeln und prüfen Sie ersetzte Schriftarten in Aspose.Slides für Python via Java beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Font substitution ermöglicht Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentation zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides beim Rendern vornimmt. Das hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

Wenn eine Schriftart verfügbar ist, aber keinen eigenen Fettschrifttyp hat, siehe [Umgang mit Schriften ohne dedizierten Fettschrifttyp](/slides/de/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text beim PDF‑Export gerastert wird und welche Folgen das für Textauswahl, Suche und Skalierung hat.

## **Font‑Substitutionen abrufen**

Verwenden Sie die [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions)-Methode, um zu bestimmen, welche Schriftarten ersetzt werden, wenn die Präsentation gerendert wird. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/)-Objekte zurück, die den ursprünglichen und den ersetzten Schriftsnamen identifizieren.

Das folgende Python‑Beispiel listet alle Font‑Substitutionen für eine Präsentation auf:

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

## **Font‑Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die Überladung von [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) mit einem Java‑Integer‑Array‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Das ist nützlich, wenn Sie nur einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftartpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren möchten, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basierten Folien‑Index: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)-Sammlungs‑Accessor eine nullbasierte Indizierung, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` angesprochen wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager)-Methode auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Rückgabewert ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/)-Objekt, das den ursprünglichen und den ersetzten Schriftsnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriftarten](/slides/de/python-java/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Die [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/)-Klasse bietet beide Überladungen. Wählen Sie je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) ohne Argumente | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) mit einem Java‑Integer‑Array | Sie benötigen Substitutionen für einen ausgewählten Bereich, inkrementelle Prüfung oder Teil‑Export. |

## **Font‑Substitutionsregeln festlegen**

Um anzugeben, welche Schriftart Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftart‑Definitionen für die Quell‑ und Ersatzschriftart.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible)-Bedingung.
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList)-Methode zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Python‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu prüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

{{% alert color="info" title="Hinweis" %}}

Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/python-java/font-replacement/).

{{% /alert %}}

## **Einschränkungen für Math‑Gleichungs‑Schriftarten**

Font‑Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahl‑Prozesses, der beim Rendering und bei der Konvertierung verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, muss Aspose.Slides genau diese Schriftart zur Berechnung und zum Rendern des Gleichungs‑Layouts besitzen. Eine Regel, die eine andere Math‑Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering meldet möglicherweise weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [external font](/slides/de/python-java/custom-font/) geladen.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

[Font replacement](/slides/de/python-java/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Font substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/python-java/font-selection-sequence/)‑Prozess während Rendering und Konvertierung teil. Mit `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seinem Auswahl‑Prozess. Das Ergebnis hängt von den in der Laufzeitumgebung vorhandenen Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitutionen zu vermeiden?**

Ja. Sie können [load external fonts](/slides/de/python-java/custom-font/) laden, damit Aspose.Slides sie beim Rendering und bei der Konvertierung verwenden kann.

**Verteilt Aspose Schriftarten zusammen mit der Bibliothek?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzbedingungen einzuhalten.

**Können sich Substitutions‑Ergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen möglicherweise substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [load required external fonts](/slides/de/python-java/custom-font/) und [embed fonts](/slides/de/python-java/embedded-font/), wenn die Lizenz es erlaubt. Sie können außerdem vor dem Export [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) aufrufen, um unerwartete Substitutionen zu erkennen.