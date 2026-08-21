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
- Formen iterieren
- Text iterieren
- Formen sammeln
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
description: "Verwenden Sie die Aspose.Slides Low-Code-API in JavaScript, um Präsentationen zu konvertieren und zusammenzuführen, durch Inhalte zu iterieren, Formen zu sammeln und die Größe der Präsentation zu reduzieren."
---
## **Übersicht**

Der Namespace `aspose.slides` stellt statische Hilfsklassen für gängige Präsentationsoperationen bereit. Diese Helfer kapseln häufig verwendete Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Formen sammeln und nicht genutzten Inhalt mit weniger Code entfernen können.

Low‑Code‑Helfer sind besonders nützlich, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Helper | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei-zu-Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/merger/) | Kombinieren vollständiger Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, Form, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/collect/) | Abrufen von Formen aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/) | Entfernen ungenutzter Master‑ und Layouts und Reduzieren eingebetteter Schriftartdaten. |

## **Präsentation konvertieren**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/#autoByExtension), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Die Klasse [Convert](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/) bietet außerdem dedizierte Methoden für PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern oder eine Exportoption konfigurieren müssen, die vom gewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/nodejs-java/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/merger/#process), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis angehängt werden sollen, ohne sie einzeln auswählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/nodejs-java/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die Klasse [ForEach](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/) ruft für jeden angeforderten Typ von Präsentationselement einen Callback auf. Sie vermeidet verschachtelte Schleifen und ist praktisch für eine prüfende oder formatierende Durchsuchung der gesamten Präsentation. In Node.js erstellen Sie Implementierungen der Callback‑Schnittstellen mit `java.newProxy`.

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

Standardmäßig umfasst die Traversierung von Formen und Text die normalen, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notizfolien verarbeiten. Verwenden Sie direkte Schleifen, wenn die Durchlaufreihenfolge, ein früher Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig ist.

## **Formen sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/collect/#shapes), wenn Sie eine Sammlung aller Formen einer Präsentation benötigen, anstatt für jede Form einen Callback zu erhalten. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

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

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), wenn jede Form sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

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

Entfernen Sie zunächst ungenutzte Layouts, bevor Sie ungenutzte Master entfernen, damit ein Master, der nach der Layout‑Bereinigung unreferenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, wenn Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später benötigen könnten. Weitere Details finden Sie unter [Slide Master](/nodejs-java/slide-master/) und [Embedded Font](/nodejs-java/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API statt des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn eine Standard‑Operation auf eine komplette Datei oder Präsentation zutrifft und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Nutzen Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, Zwischenergebnisse prüfen oder ein Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/merger/#process) erfordert Eingabedateien im selben Format. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, beispielsweise mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/convert/#autoByExtension), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notiz‑Folien?**

[ForEach.slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#slide) iteriert über normale Präsentationsfolien. Präsentationsweite [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#paragraph) und [ForEach.portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#portion) umfassen standardmäßig normale, Master‑ und Layout‑Folien. Verwenden Sie deren Überladungen mit `includeNotes` = `true`, um Notiz‑Folien mit einzubeziehen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/#shape), um jede Form sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/collect/#shapes), wenn Sie ein iterierbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Macht Compress die Präsentationsdatei immer kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Sind diese nicht vorhanden, reduzieren die entsprechenden [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/)‑Operationen die Dateigröße möglicherweise nicht.

**Werden Änderungen, die durch ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/foreach/)‑Callback geändert oder [Compress](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)