---
title: Konfiguration von Font‑Substitution in Präsentationen mit Python über Java
linktitle: Font‑Substitution
type: docs
weight: 70
url: /de/python-java/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart‑Substitution
- Schriftart ersetzen
- Schriftart‑Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Konfigurieren Sie Font‑Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für Python über Java beim Rendern oder Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen."
---
## **Übersicht**

Font‑Substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution beeinflusst die gerenderte Ausgabe; sie ändert nicht die der Präsentation zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und die Substitutionen einsehen, die Aspose.Slides beim Rendern vornimmt. So bleibt die Ausgabe in Umgebungen mit unterschiedlichen installierten Schriftarten konsistent.

## **Font‑Substitutionen abrufen**

Verwenden Sie die [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions)-Methode, um zu bestimmen, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstitutioninfo/)-Objekte zurück, die den ursprünglichen und den substituierten Schriftnamen identifizieren.

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

Verwenden Sie die Überladung von [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions) mit einem Java‑Integer‑Array‑Argument, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Das ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell überprüfen, Folien finden möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren wollen, ohne nicht relevante Folien zu verarbeiten.

Das `slides`‑Array enthält ein‑basiert indizierte Folienzahlen: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der Zugriff auf die Sammlung über [Presentation.getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) null‑basiertes Indexieren, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` adressiert wird. Beachten Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über die [Presentation.getFontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getFontsManager)-Methode auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Eintrag ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstitutioninfo/)-Objekt, das den ursprünglichen und den substituierten Schriftnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstrulecollection/) gespeicherte Substitutionsregeln sowie [extern geladene Schriftarten](/slides/de/python-java/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate, wenn Sie ein Schriftinventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erzeugt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Die Klasse [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) bietet beide Überladungen. Wählen Sie je nach Umfang des Render‑Vorgangs:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions) ohne Argumente | Sie Substitutionen für die gesamte Präsentation benötigen. |
| [getSubstitutions](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions) mit einem Java‑Integer‑Array | Sie Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen teilweisen Export benötigen. |

## **Font‑Substitutionsregeln festlegen**

Um anzugeben, welche Schriftart Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftart.
3. Erstellen Sie ein [FontSubstRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstrule/) mit der Bedingung [WhenInaccessible](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die Methode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende Python‑Beispiel ersetzt `Arial` durch `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu prüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

## **Einschränkungen für Schriftarten in mathematischen Gleichungen**

Font‑Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Verwendet eine Gleichung **Cambria Math**, kann Aspose.Slides diese exakte Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart, etwa **STIX Two Math**, substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Stellen Sie **Cambria Math** Aspose.Slides zur Verfügung, um eine solche Präsentation zu rendern oder zu konvertieren. Installieren Sie sie im Betriebssystem oder laden Sie sie als [ externe Schriftart](/slides/de/python-java/custom-font/) geladen.

Diese Einschränkung betrifft nur das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für den regulären Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

[Font replacement](/slides/de/python-java/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Font‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, zum Beispiel wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [font selection sequence](/slides/de/python-java/font-selection-sequence/) während des Renderns und Konvertierens teil. Mit `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am besten passende verfügbare Schriftart gemäß seinem Schriftartauswahlprozess. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/python-java/custom-font/), sodass Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzbedingungen einzuhalten.

**Können Substitutions‑Ergebnisse zwischen Windows, Linux und macOS variieren?**

Ja. Installierte Schriftarten und Suchpfade unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/python-java/custom-font/) und [betten Sie Schriftarten ein](/slides/de/python-java/embedded-font/), sofern die Lizenz dies zulässt. Sie können auch vor dem Export [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions) aufrufen, um unerwartete Substitutionen zu erkennen.