---
title: "Schriftart‑Substitution in Präsentationen mit JavaScript konfigurieren"
linktitle: "Schriftart‑Substitution"
type: docs
weight: 70
url: /de/nodejs-java/font-substitution/
keywords:
- Schriftart
- Ersatzschriftart
- Schriftart‑Substitution
- Schriftart ersetzen
- Schriftart‑Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurieren Sie Schriftart‑Substitutionsregeln und prüfen Sie substituierte Schriftarten in Aspose.Slides für Node.js über Java beim Rendern oder Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen."
---
## **Übersicht**

Font‑Substitution ermöglicht es Aspose.Slides, eine verfügbare Schriftart anstelle einer nicht zugänglichen Schriftart zu verwenden, wenn eine Präsentation gerendert oder konvertiert wird. Die Substitution wirkt sich auf die gerenderte Ausgabe aus; sie ändert nicht die der Präsentation zugewiesene Schriftart.

Sie können die zu verwendende Schriftart festlegen, wenn eine bestimmte Schriftart nicht verfügbar ist, und Sie können die Substitutionen einsehen, die Aspose.Slides während des Renderns vornimmt. Dies hilft, die Ausgabe in Umgebungen mit unterschiedlichen installierten Schriftarten konsistent zu halten.

Wenn eine Schriftart verfügbar ist, aber keine dedizierte fette Schriftart hat, siehe [Schriftarten ohne dedizierte fette Schriftart behandeln](/slides/de/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Dieser Abschnitt erklärt, wie der betroffene Text beim PDF‑Export gerastert wird und welche Auswirkungen dies auf die Textauswahl, Suche und Skalierung hat.

## **Font‑Substitutionen abrufen**

Verwenden Sie die [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑Methode, um zu bestimmen, welche Schriftarten bei der Darstellung der Präsentation substituiert werden. Die Methode gibt [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)‑Objekte zurück, die die ursprünglichen und substituierten Schriftartnamen identifizieren.

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

## **Font‑Substitutionen für ausgewählte Folien abrufen**

Verwenden Sie die [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑Überladung mit einem Array von Folienindizes, um nur die Substitutionen zu prüfen, die zum Rendern bestimmter Folien erforderlich sind. Dies ist nützlich, wenn Sie einen Teil einer Präsentation rendern oder exportieren, eine große Präsentation inkrementell prüfen, Folien finden möchten, die von nicht verfügbaren Schriftarten abhängen, ein minimales Schriftartpaket für einen Server oder Container vorbereiten oder Rendering‑Unterschiede diagnostizieren wollen, ohne nicht relevante Folien zu verarbeiten.

Die Überladung erwartet ein Java‑Primitive `int[]`. Erstellen Sie es mit `java.newArray("int", [...])`; ein normales JavaScript‑Array wird in `Integer[]` konvertiert und passt nicht zu dieser Überladung.

Das Array enthält ein‑basierte Folienindizes: `1` identifiziert die erste Folie. Im Gegensatz dazu verwendet der [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/)‑Sammlungszugriff null‑basierte Indizierung, sodass dieselbe Folie als `presentation.getSlides().get_Item(0)` angesprochen wird. Beachten Sie diesen Unterschied beim Aufbau des Arrays, um Off‑by‑One‑Fehler zu vermeiden.

Rufen Sie die Überladung über [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) auf. Sie gibt nur die Substitutionen zurück, die beim Rendern der ausgewählten Folien ermittelt wurden. Jeder Treffer ist ein [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)‑Objekt, das den ursprünglichen und den substituierten Schriftartnamen enthält. Das Ergebnis spiegelt die aktuelle Schriftumgebung, konfigurierte Fallback‑Regeln, in einer [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) gespeicherte Substitutionsregeln und [extern geladene Schriftarten](/slides/de/nodejs-java/custom-font/) wider.

Die gleiche Substitution kann von mehr als einer ausgewählten Folie verlangt werden. Entfernen Sie Duplikate, wenn Sie ein Schriftarten‑Inventar oder einen Preflight‑Report erstellen. Das folgende Beispiel gibt jede zurückgegebene Substitution aus und erstellt anschließend eine sortierte Liste eindeutiger Schriftzuordnungen:

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

Die [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/)‑Klasse bietet beide Überladungen. Wählen Sie die passende je nach Umfang des Rendering‑Vorgangs:

| Überladung | Verwenden Sie sie, wenn |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) ohne Argumente | Sie Substitutionen für die gesamte Präsentation benötigen. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) mit einem Java `int[]` von Folienindizes | Sie Substitutionen für einen ausgewählten Bereich, eine inkrementelle Prüfung oder einen partiellen Export benötigen. |

## **Schriftart‑Substitutionsregeln festlegen**

Um die Schriftart anzugeben, die Aspose.Slides verwenden soll, wenn eine Quellschriftart nicht verfügbar ist:

1. Laden Sie die Präsentation.
2. Erstellen Sie Schriftart‑Definitionen für die Quell‑ und Ersatzschriftarten.
3. Erstellen Sie ein [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) mit der [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/)‑Bedingung.
4. Fügen Sie die Regel einer [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) hinzu.
5. Weisen Sie die Sammlung über die [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)‑Methode zu.
6. Rendern oder konvertieren Sie die Präsentation.

Das folgende JavaScript‑Beispiel substituiert `Arial` für `SomeRareFont`, wenn `SomeRareFont` nicht verfügbar ist, und rendert anschließend die erste Folie, um das Ergebnis zu prüfen. Die Ersatzschriftart muss für Aspose.Slides verfügbar sein.

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

Für eine bedingungslose Änderung der in einer gesamten Präsentation verwendeten Schriftarten siehe [Schriftart-Ersetzung](/slides/de/nodejs-java/font-replacement/).

{{% /alert %}}

## **Einschränkungen für Schriftarten von mathematischen Gleichungen**

Schriftart‑Substitutionsregeln sind Teil des Standard‑Schriftauswahlprozesses, der beim Rendering und bei der Konvertierung verwendet wird. Sie funktionieren für normalen Text, wenn Aspose.Slides eine nicht zugängliche Schriftart durch die in einer Regel angegebene verfügbare Schriftart ersetzen kann.

Office‑Math‑Gleichungen haben eine zusätzliche Anforderung. Wenn eine Gleichung **Cambria Math** verwendet, kann Aspose.Slides diese genaue Schriftart benötigen, um das Layout der Gleichung zu berechnen und zu rendern. Eine Regel, die eine andere Math‑Schriftart, wie **STIX Two Math**, substituiert, kann **Cambria Math** für diesen Zweck nicht ersetzen, und das Rendering meldet möglicherweise weiterhin, dass **Cambria Math** erforderlich ist.

Um eine solche Präsentation zu rendern oder zu konvertieren, stellen Sie **Cambria Math** Aspose.Slides zur Verfügung. Installieren Sie sie im Betriebssystem oder laden Sie sie als [externe Schriftart](/slides/de/nodejs-java/custom-font/) laden.

Diese Einschränkung bezieht sich auf das Gleichungs‑Layout. Die oben beschriebenen Substitutionsregeln gelten weiterhin für normalen Präsentationstext.

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Schriftart-Ersetzung](/slides/de/nodejs-java/font-replacement/) ändert bewusst eine Schriftart durch eine andere in der gesamten Präsentation. Schriftart‑Substitution wählt eine Schriftart für die gerenderte Ausgabe, wenn die konfigurierte Bedingung erfüllt ist, z. B. wenn die Originalschriftart nicht verfügbar ist.

**Wann werden Substitutionsregeln angewendet?**

Die Regeln nehmen am [Schriftauswahlsequenz](/slides/de/nodejs-java/font-selection-sequence/)‑Prozess während Rendering und Konvertierung teil. Bei `WhenInaccessible` wird eine Regel nur verwendet, wenn Aspose.Slides nicht auf die Quellschriftart zugreifen kann.

**Was passiert, wenn eine Schriftart fehlt und keine Substitutionsregel konfiguriert ist?**

Aspose.Slides wählt die am nächsten liegende verfügbare Schriftart gemäß seinem Schriftauswahlprozess. Das Ergebnis hängt von den im Laufzeit‑Umfeld verfügbaren Schriftarten ab.

**Kann ich externe Schriftarten laden, um Substitution zu vermeiden?**

Ja. Sie können [externe Schriftarten laden](/slides/de/nodejs-java/custom-font/), sodass Aspose.Slides sie beim Rendering und bei der Konvertierung verwenden kann.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Sie sind dafür verantwortlich, Schriftarten bereitzustellen und deren Lizenzen einzuhalten.

**Können sich Substitutionsergebnisse zwischen Windows, Linux und macOS unterscheiden?**

Ja. Installierte Schriftarten und Suchorte für Schriftarten unterscheiden sich je nach Betriebssystem, sodass eine Schriftart, die auf einem Rechner verfügbar ist, auf einem anderen substituiert werden muss.

**Wie kann ich die Schriftauswahl bei Batch‑Konvertierungen konsistent halten?**

Verwenden Sie dieselben Schriftdateien und -versionen auf jedem Rechner oder Container, [laden Sie erforderliche externe Schriftarten](/slides/de/nodejs-java/custom-font/), und [betten Sie Schriftarten ein](/slides/de/nodejs-java/embedded-font/), wann immer die Lizenz es zulässt. Sie können zudem vor dem Export [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aufrufen, um unerwartete Substitutionen zu identifizieren.