---
title: Low-Code-Präsentationsoperationen in JavaScript
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/nodejs-java/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Folien iterieren
- Shapes iterieren
- Text iterieren
- Shapes sammeln
- Präsentation komprimieren
- Unbenutzte Master-Folien entfernen
- Unbenutzte Layout-Folien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in JavaScript, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Shapes zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Der Namespace `aspose.slides` stellt statische Hilfsklassen für gängige Präsentationsoperationen bereit. Diese Hilfsmittel kapseln häufig genutzte Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Shapes sammeln und unbenutzten Inhalt mit weniger Code entfernen können.

Low‑Code‑Hilfsmittel sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Shapes, Export‑Einstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Hilfsmittel zusammen:

| Hilfsmittel | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/merger/) | Kombinieren vollständiger Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, jedes Shape, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/collect/) | Abrufen von Shapes aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/) | Entfernen ungenutzter Master‑ und Layout‑Folien und Reduzieren eingebetteter Schriftartdaten. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/#autoByExtension), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format anhand des Ausgabepfads und schreibt das Ergebnis.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Die Klasse [Convert](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/) bietet außerdem dedizierte Methoden für die Ausgabe als PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern müssen oder eine Exportoption konfigurieren wollen, die vom ausgewählten Hilfsmittel nicht bereitgestellt wird. Siehe [Präsentation konvertieren](/slides/de/nodejs-java/convert-presentation/) für formatabhängige Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/merger/#process), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabepräsentationen müssen dasselbe Dateiformat besitzen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Das Hilfsmittel ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen ausgleichen müssen. Siehe [Präsentationen zusammenführen](/slides/de/nodejs-java/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die Klasse [ForEach](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/) ruft für jeden angeforderten Typ eines Präsentationselements einen Callback auf. Sie vermeidet verschachtelte Sammlungsschleifen und ist praktisch für eine Präsentations‑weite Inspektion oder Formatierungsänderungen. In Node.js erstellen Sie Implementierungen der Callback‑Schnittstellen mit `java.newProxy`.

Das folgende Beispiel verwendet [ForEach.slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#paragraph) und [ForEach.portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#portion), um die entsprechenden Elemente zu prüfen:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Standardmäßig umfasst die Präsentations‑weite Shape‑ und Text‑Durchlauf normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notizfolien verarbeiten. Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlaufreihenfolge, ein früher Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig ist.

## **Shapes sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/collect/#shapes), wenn Sie eine Sammlung aller Shapes in einer Präsentation benötigen, anstatt für jedes Shape einen Callback zu verwenden. Dies ist nützlich, wenn derselbe Satz mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), wenn jedes Shape sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die Klasse [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/) kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Entfernen Sie ungenutzte Layouts vor ungenutzten Mastern, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie später die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten benötigen. Weitere Details finden Sie unter [Folienmaster](/slides/de/nodejs-java/slide-master/) und [Eingebettete Schriftart](/slides/de/nodejs-java/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Hilfsmittel, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erfordert. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, den Zwischenzustand prüfen oder ein Verhalten konfigurieren müssen, das das Hilfsmittel nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/merger/#process) erfordert Eingabepräsentationen im selben Format. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, beispielsweise mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/#autoByExtension), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#slide) durchläuft normale Präsentationsfolien. Präsentationsweite [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#paragraph) und [ForEach.portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#portion) Operationen schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` auf `true`, um Notizfolien einzuschließen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), um jedes Shape sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/collect/#shapes), wenn Sie ein iterierbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Verkleinert Compress immer die Präsentationsdatei?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Wenn keines davon vorhanden ist, können die entsprechenden [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/)‑Operationen die Dateigröße möglicherweise nicht verringern.

**Werden Änderungen, die von ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Hilfsmittel arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/)‑Callback geändert oder [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/slides/de/nodejs-java/convert-presentation/)
- [Präsentationen zusammenführen](/slides/de/nodejs-java/merge-presentation/)
- [Folienmaster](/slides/de/nodejs-java/slide-master/)
- [Textfeld verwalten](/slides/de/nodejs-java/manage-textbox/)
- [Eingebettete Schriftart](/slides/de/nodejs-java/embedded-font/)