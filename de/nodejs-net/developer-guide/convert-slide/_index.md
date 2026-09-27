---
title: Präsentationsfolien in Node.js via .NET zu Bildern konvertieren
linktitle: Folie zu Bild
type: docs
weight: 40
url: /de/nodejs-net/convert-slide/
keywords:
- Folie konvertieren
- Folie zu Bild
- Folie zu PNG
- Folie als Bild speichern
- Folie rendern
- Folien-Miniaturansicht
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Rendern Sie Folien aus PPTX-, PPT- und ODP-Präsentationen als PNG-Bilder in JavaScript mit Aspose.Slides für Node.js via .NET, entweder mit einem Skalierungsfaktor oder mit einer genauen Größe in Pixeln."
---
## **Übersicht**

Aspose.Slides for Node.js via .NET rendert Folien aus PowerPoint‑ und OpenDocument‑Präsentationen als Bilder, zum Beispiel um Folienvorschauen auf einer Webseite anzuzeigen. Dieser Artikel zeigt zwei Möglichkeiten, die Bildgröße festzulegen: einen Skalierungsfaktor relativ zur Foliengröße und eine exakte Größe in Pixeln. Beide Beispiele speichern PNG‑Dateien.

Die Beispiele gehen von einer Präsentation mit dem Namen `sample.pptx` im Projektordner aus, den Sie in [Installation](/slides/de/nodejs-net/installation/) eingerichtet haben. Jede PowerPoint‑Präsentation ist geeignet. Speichern Sie jedes Beispiel als `.js`‑Datei im Projektordner und führen Sie es dort mit `node` aus.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides for Node.js via .NET hat keine eigene API‑Referenz. Sie spiegelt die Aspose.Slides for .NET API mit camelCase‑Namen wider, sodass die API‑Links in diesem Artikel zu den entsprechenden Klassen und Mitgliedern in der [Aspose.Slides for .NET API‑Referenz](https://reference.aspose.com/slides/de/net/) führen.
{{% /alert %}}

Um eine Folie in ein Bild zu konvertieren, führen Sie folgende Schritte aus:

1. Öffnen Sie die Präsentation mit dem [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/presentation/)‑Konstruktor.
2. Holen Sie sich eine Folie aus der [slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/)‑Sammlung mit `get(index)`. Indizes beginnen bei 0.
3. Rendern Sie die Folie mit `getImageWithScale` oder `getImageWithImageSize`. In der .NET API‑Referenz sind beide Überladungen von [Slide.GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/slide/getimage/). Sie geben ein Bildobjekt zurück, das dem [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) entspricht.
4. Speichern Sie das Bild mit seiner [save](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/save/)‑Methode und einem [ImageFormat](https://reference.aspose.com/slides/de/net/aspose.slides/imageformat/)‑Wert und rufen Sie anschließend seine `dispose`‑Methode auf.

## **Jede Folie in ein PNG‑Bild konvertieren**

`getImageWithScale` nimmt einen horizontalen und einen vertikalen Skalierungsfaktor entgegen. Bei einem Skalierungsfaktor von 1 wird ein Punkt der Folie zu einem Pixel des Bildes. Das folgende Beispiel rendert jede Folie mit einem Skalierungsfaktor von 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Ein Skalierungsfaktor von 1 rendert einen Pixel pro Punkt; 2 verdoppelt die Breite und die Höhe.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Das Skript schreibt für jede Folie eine Datei, `slide_1.png`, `slide_2.png` usw., nummeriert ab 1. Für eine 16:9‑Präsentation mit Folien von 960 × 540 Punkten ist jedes Bild 1920 × 1080 Pixel groß. Versteckte Folien werden ebenfalls gerendert; um sie zu überspringen, prüfen Sie die [hidden](https://reference.aspose.com/slides/de/net/aspose.slides/slide/hidden/)‑Eigenschaft der Folie. Jedes Bild wird in einem eigenen `finally`‑Block freigegeben, wodurch es vor dem Rendern der nächsten Folie entsorgt wird. Ohne Lizenz zeigen die Bilder außerdem ein Evaluierungs‑Wasserzeichen; siehe [Licensing](/slides/de/nodejs-net/licensing/).

## **Eine Folie in ein Bild mit vorgegebener Größe konvertieren**

`getImageWithImageSize` nimmt ein Objekt mit `width` und `height` in Pixeln entgegen. Das folgende Beispiel rendert die erste Folie 1280 Pixel breit und berechnet die Höhe aus der Foliengröße, sodass das Bild das Seitenverhältnis der Folie beibehält:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Die Eigenschaft [slideSize.size](https://reference.aspose.com/slides/de/net/aspose.slides/slidesize/size/) liefert die Folienbreite und -höhe in Punkten. Für eine 16:9‑Präsentation gibt das Skript `Saved a 1280 x 720 image` aus und schreibt `slide_1_1280px.png`; für eine 4:3‑Präsentation beträgt das Bild 1280 × 960 Pixel.

## **FAQ**

**Warum ist das Bild von `getImage` ohne Argumente so klein?**

Ohne Argumente rendert `getImage` die Folie mit 20 % ihrer Größe in Punkten, sodass eine Folie von 960 × 540 Punkten zu einem Bild von 192 × 108 Pixeln wird. Verwenden Sie `getImageWithScale` oder `getImageWithImageSize`, um die Größe festzulegen.

**Wie speichere ich JPEG oder andere Bildformate?**

Übergeben Sie der `save`‑Methode des Bildes einen anderen `ImageFormat`‑Wert, zum Beispiel `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Das Format wird aus dem `ImageFormat`‑Wert abgeleitet, nicht aus der Dateierweiterung, also halten Sie beide konsistent.

**Warum sieht der Text in den Bildern unter Linux anders aus?**

Aspose.Slides kann nur Schriftarten verwenden, die auf dem Rechner installiert sind, der die Folien rendert. Wenn eine Präsentation eine Schriftart verwendet, die fehlt (z. B. Calibri auf einem typischen Linux‑Server), greift Aspose.Slides auf eine installierte Ersatzschrift zurück, was das Aussehen des Textes und Zeilenumbrüche ändern kann. Installieren Sie die Schriftarten, die Ihre Präsentationen benötigen, um die gleichen Bilder wie unter Windows zu erhalten.

**Warum schlägt `getThumbnailWithImageSize` mit einem TypeError fehl?**

Die README des Pakets verwendet `getThumbnailWithImageSize`, aber das Paket stellt keine `getThumbnail`‑Methoden bereit. Verwenden Sie stattdessen `getImageWithImageSize`; es akzeptiert dasselbe `{ width, height }`‑Argument.