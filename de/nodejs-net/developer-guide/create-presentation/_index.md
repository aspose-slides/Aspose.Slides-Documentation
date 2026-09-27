---
title: Präsentationen in Node.js via .NET erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/nodejs-net/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PowerPoint erstellen
- PPTX erstellen
- Textfeld hinzufügen
- Folie hinzufügen
- Foliengröße
- Breitbild
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen Sie PowerPoint‑Präsentationen in JavaScript mit Aspose.Slides für Node.js via .NET: Fügen Sie ein Textfeld und Folien hinzu, setzen Sie eine Foliengröße von 16:9 und speichern Sie das Ergebnis als PPTX."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation mit Aspose.Slides für Node.js via .NET erstellt, eine Textbox zu ihrer ersten Folie hinzufügt und das Ergebnis als PPTX-Datei speichert. Er zeigt außerdem, wie man weitere Folien hinzufügt und wie man die Präsentation auf Breitbild‑Folien (16:9) umstellt.

Die Beispiele benötigen ein Projekt, das wie in [Installation](/slides/de/nodejs-net/installation/) beschrieben eingerichtet ist. Speichern Sie jedes Beispiel als `.js`‑Datei im Projektordner und führen Sie es aus diesem Ordner mit `node` aus, zum Beispiel `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Node.js via .NET hat keine eigene API‑Referenz. Es spiegelt die Aspose.Slides‑API für .NET mit camelCase‑Namensgebung wider, sodass die API‑Links in diesem Artikel zu den entsprechenden Klassen und Mitgliedern in der [Aspose.Slides für .NET API‑Referenz](https://reference.aspose.com/slides/net/) führen.
{{% /alert %}}

## **Erstellen einer Präsentation mit einer Textbox**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Eine neue Präsentation enthält bereits eine leere Folie.
2. Rufen Sie diese Folie aus der Sammlung [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) ab. Sammlungen in diesem Paket werden mit `get(index)` gelesen, und die Indizes beginnen bei 0.
3. Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) ein Rechteck hinzu und setzen Sie den [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) seines [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).
4. Speichern Sie die Präsentation mit der Methode [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) und dem Wert `SaveFormat.Pptx`.
5. Rufen Sie `dispose` in einem `finally`‑Block auf, um die .NET‑Ressourcen, die der Präsentation zugrunde liegen, freizugeben.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Die Position (x, y) und die Größe (Breite, Höhe) sind in Punkten.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Das Skript schreibt `new-presentation.pptx` in den Projektordner. Die Datei enthält eine Folie mit einem ausgefüllten Rechteck, dessen obere linke Ecke 50 Punkte vom linken bzw. oberen Rand der Folie entfernt ist. Das Rechteck ist 400 Punkte breit und 100 Punkte hoch, und sein Text ist zentriert. Ein Punkt entspricht 1/72 Zoll. Ohne Lizenz fügt Aspose.Slides der Folie außerdem ein Evaluations‑Wasserzeichen hinzu; siehe [Lizenzierung](/slides/de/nodejs-net/licensing/).

## **Folien hinzufügen**

Eine neue Präsentation hat eine Folie. Um weitere hinzuzufügen, übergeben Sie einer Layout‑Folie die Methode [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) der `slides`‑Sammlung. Die Methode [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) der Sammlung [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) liefert das erste Layout eines angegebenen [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

Das folgende Beispiel fügt zwei Folien mit dem Layout Blank hinzu:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Skript gibt `Slide count: 3` aus und schreibt `three-slides.pptx`. Die neuen Folien werden nach der ersten angehängt und enthalten keine Formen. Eine neue Präsentation hat immer ein Blank‑Layout, aber eine Präsentation, die Sie aus einer Datei öffnen, besitzt möglicherweise kein Layout des gewünschten Typs; in diesem Fall gibt `getByType` `null` zurück, prüfen Sie also das Ergebnis, bevor Sie es weitergeben.

## **Foliengröße festlegen**

Eine neue Präsentation verwendet 4:3‑Folien mit 720 × 540 Punkten (10 × 7,5 Zoll). Um stattdessen Breitbild‑Folien zu erstellen, rufen Sie die Methode [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) des [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) der Präsentation mit einem Wert vom Typ [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) und einem Wert vom Typ [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) auf. Der Skalierungstyp gibt Aspose.Slides vor, wie mit Formen umgegangen werden soll, die bereits auf den Folien vorhanden sind; `DoNotScale` lässt sie unverändert, was die richtige Wahl für eine Präsentation ohne Inhalt ist.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Skript gibt `Slide size: 960 x 540 points` aus, was 13,33 × 7,5 Zoll entspricht, und schreibt `widescreen.pptx`. `SlideSizeType.OnScreen16x9` hat dasselbe Seitenverhältnis 16:9, ist aber kleiner: 720 × 405 Punkte.

## **FAQ**

**In welchen Einheiten werden Positionen und Größen gemessen?**

In Punkten. Ein Zoll entspricht 72 Punkten, daher hat die Standard‑4:3‑Folie 720 × 540 Punkte, und eine 16:9‑Breitbildfolie hat 960 × 540 Punkte.

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Jeder Wert der Aufzählung [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), zum Beispiel `SaveFormat.Ppt` für PowerPoint 97–2003, `SaveFormat.Odp` für OpenDocument oder `SaveFormat.Pdf`. Für PDF‑Ausgabe siehe [PowerPoint in PDF konvertieren](/slides/de/nodejs-net/convert-powerpoint-to-pdf/).

**Warum enthält die gespeicherte Präsentation den Text „Evaluation only“?**

Ohne Lizenz fügt Aspose.Slides den Folien, die es speichert, ein Evaluations‑Wasserzeichen hinzu. Wenden Sie eine Lizenz wie in [Lizenzierung](/slides/de/nodejs-net/licensing/) beschrieben an, um sie zu entfernen.

**Warum sollte ich `dispose` aufrufen?**

Ein `Presentation`‑Objekt wird von einem .NET‑Objekt unterstützt, das Speicher und andere Ressourcen hält. Durch Aufrufen von `dispose` werden diese freigegeben, sobald Sie die Präsentation nicht mehr benötigen, und das Aufrufen in einem `finally`‑Block gibt sie selbst bei einem Fehler frei.