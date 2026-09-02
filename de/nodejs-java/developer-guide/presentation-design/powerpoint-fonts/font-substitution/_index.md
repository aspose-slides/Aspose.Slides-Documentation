---
title: Schriftart-Substitution in Präsentationen mit JavaScript konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurieren Sie Schriftart-Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für Node.js über Java beim Rendern oder Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Die Schriftart-Substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentation zugewiesene Schriftart.

Sie können die zu verwendende Schriftart definieren, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides während des Renderns vornimmt. Dies hilft, die Ausgabe über Umgebungen mit unterschiedlichen installierten Schriftarten hinweg konsistent zu halten.

## **Schriftart-Substitutionen abrufen**

Verwenden Sie die [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑Methode, um zu bestimmen, welche Schriftarten beim Rendern der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die den ursprünglichen und den substituierten Schriftartnamen identifizieren.

Das folgende JavaScript‑Beispiel listet alle Schriftart‑Substitutionen für eine Präsentation auf:

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

## **Schriftart-Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑Überladung mit einem Array von Folienindizes, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien lokalisieren möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftartenpaket für einen Server oder Container vorbereiten oder Renderunterschiede diagnostizieren, ohne nicht relevante Folien zu verarbeiten.

Die Überladung erwartet ein Java‑Primitive `int[]`. Erstellen Sie es mit `java.newArray("int", [...])`; ein einfaches JavaScript‑Array wird zu `Integer[]` konvertiert und passt nicht zu dieser Überladung.

Das Array enthält einsbasierte Folienindizes: `1` bezeichnet die erste Folie. Im Gegensatz dazu verwendet der [Presentation.getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslides/)‑Sammlungszugriff nullbasierte Indizierung, sodass dieselbe Folie über `presentation.getSlides().get_Item(0)` angesprochen wird. Berücksichtigen Sie diesen Unterschied beim Erstellen des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über [Presentation.getFontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getfontsmanager/) auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Treffer ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsubstitutioninfo/)‑Objekt, das die ursprünglichen und substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriftarten](/slides/de/nodejs-java/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie benötigt werden. Entfernen Sie Duplikate aus den Ergebnissen, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Bericht erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftartzuordnungen:

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

Die Klasse [FontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/) stellt beide Überladungen bereit. Wählen Sie eine entsprechend dem Umfang der Rendering‑Operation:

| Überladung | Verwenden, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Sie benötigen Substitutionen für die gesamte Präsentation. |
| [getSubstitutions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Sie benötigen Substitutionen für einen ausgewählten Bereich, inkrementelle Prüfung oder Teilexport. |

## **Schriftart-Substitutionsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftartdefinitionen für die Quell‑ und Ersatzschriftarten.
3. Erstellen Sie eine [FontSubstRule](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsubstcondition/)‑Bedingung.
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung mithilfe der [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)‑Methode zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende JavaScript‑Beispiel ersetzt `SomeRareFont` durch `Arial`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu überprüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

{{% alert color="info" title="Hinweis" %}}
Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Font Replacement](/slides/de/nodejs-java/font-replacement/).
{{% /alert %}}

## **Einschränkungen für Schriftarten von mathematischen Gleichungen**

Schriftart-Substitutionsregeln sind Teil des standardmäßigen Schriftartauswahlprozesses, der beim Rendern und Konvertieren verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die durch eine Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, kann Aspose.Slides diese genaue Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere mathematische Schriftart wie **STIX Two Math** substituiert, kann **Cambria Math** hierfür nicht ersetzen, und das Rendering kann weiterhin melden, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** für Aspose.Slides bereit. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externen Font](/slides/de/nodejs-java/custom-font/) hoch.

Diese Einschränkung gilt für das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart-Ersetzung und Schriftart-Substitution?**

[Font replacement](/slides/de/nodejs-java/font-replacement/) ändert bewusst eine Schriftart überall in der Präsentation in eine andere. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, zum Beispiel wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen an der [font selection sequence](/slides/de/nodejs-java/font-selection-sequence/) während des Renderns und der Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten gelegene verfügbare Schriftart gemäß seinem Schriftartauswahlprozess aus. Das Ergebnis hängt von den im Laufzeitumfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [externen Fonts laden](/slides/de/nodejs-java/custom-font/), damit Aspose.Slides sie beim Rendern und Konvertieren verwenden kann.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können sich die Substitutionsresultate zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchpfade für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine auf einem Rechner verfügbare Schriftart auf einem anderen möglicherweise substituiert werden muss.

**Wie kann ich die Schriftartauswahl bei Stapelkonvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jeder Maschine oder jedem Container, [laden Sie erforderliche externe Schriftarten](/slides/de/nodejs-java/custom-font/) und [betten Sie Schriftarten ein](/slides/de/nodejs-java/embedded-font/), sofern die Lizenz dies erlaubt. Sie können außerdem vor dem Export [FontsManager.getSubstitutions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aufrufen, um unerwartete Substitutionen zu identifizieren.