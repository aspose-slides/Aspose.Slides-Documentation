---
title: PowerPoint-Folien zu PNG konvertieren in JavaScript
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder in JavaScript mit Aspose.Slides für Node.js und gewährleisten Sie präzise, automatisierte Ergebnisse."
---
## **Übersicht**

Dieser Artikel erklärt, wie Präsentationsfolien mit Aspose.Slides für Node.js über Java in PNG‑Bilder konvertiert werden. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und sie als separates PNG‑Bild speichern.

Die nachstehenden Beispiele zeigen das Rendern im Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und die Auswahl eines Gradienten‑Renderstils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und greifen Sie über die [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides)-Sammlung auf ihre Folien zu. Das Beispiel rendert jede Folie mit [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) ohne Parameter, um ein Thumbnail zu erstellen. Anschließend wird [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) mit [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Die parameterlose Überladung von [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) rendert mit einer Skalierung von 0,2. Zum Beispiel erzeugt eine Folie mit den Maßen 720 × 540 Punkte ein Thumbnail mit 144 × 108 Pixel. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder eine explizite Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit den Maßen 720 × 540 Punkte ein Bild von 1440 × 1080 Pixel erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jedes Bild wird im PNG‑Format mit [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) gespeichert.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um die Ausgabedimensionen in Pixeln anzugeben, übergeben Sie eine Größe an [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) anstelle von Skalierungsfaktoren. Dieses Beispiel rendert jede Folie mit 960 × 720 Pixel und speichert das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Wählen Sie Dimensionen, die dem Seitenverhältnis der Folie entsprechen, um ein Verziehen des Bildes zu vermeiden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Einen Gradienten‑Renderstil wählen**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anders als in PowerPoint. Sie können die Methode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle), die von [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) geerbt wird, verwenden, um zu wählen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stopps bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert die gleiche erste Folie in beiden Modi mit [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Die nachstehenden Bilder zeigen die Ausgabe derselben Folie, wobei beide Verläufe in jedem Bild zu sehen sind:

| Standard | PowerPointUI |
| --- | --- |
| ![Cyan-zu-orange und blau-zu-gelb Verläufe gerendert mit Standard](gradient-Default.png) | ![Die gleichen Verläufe gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Standard` hellere Zwischenfarben, während `PowerPointUI` dunklere Zwischenfarben erzeugt. Der Unterschied hängt von den Farben und Stopps im Verlauf ab.

Wählen Sie `Standard`, wenn die Standardausgabe von Aspose.Slides Ihren Anforderungen entspricht. Probieren Sie `PowerPointUI`, wenn es Ihnen wichtig ist, das Erscheinungsbild in PowerPoint nachzubilden. Vergleichen Sie beide Ausgaben mit Ihrem gewünschten Ergebnis; keiner der Modi ist allgemein vorzuziehen.

## **FAQ**

**Wie kann ich eine bestimmte Form, z. B. ein Diagramm oder ein Bild, anstelle der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Thumbnails für einzelne Formen](/slides/de/nodejs-java/create-shape-thumbnails/), wodurch Sie eine Form als PNG‑Bild rendern können.

**Wird eine parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentations‑Instanz; [teilen Sie keine einzelne Instanz über Threads hinweg](/slides/de/nodejs-java/multithreading/).

**Welche Evaluierungsbeschränkungen gelten beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und wendet [weitere Einschränkungen](/slides/de/nodejs-java/licensing/) an, bis eine Lizenz aktiviert ist.