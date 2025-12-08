---
title: Präsentationsbetrachter
type: docs
weight: 50
url: /de/nodejs-java/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentationsbetrachter
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides für Node.js über Java
description: "PowerPoint-Präsentationsbetrachter in JavaScript"
---

Aspose.Slides für Node.js über Java wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. In manchen Fällen müssen Entwickler die Folien jedoch als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder einen eigenen Präsentationsviewer erstellen. In solchen Fällen ermöglicht Aspose.Slides den Export einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie das funktioniert.

## **SVG‑Bild aus einer Folie erzeugen**

Um mit Aspose.Slides ein SVG‑Bild aus einer Präsentationsfolie zu erzeugen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über deren Index.
1. Öffnen Sie einen Dateistream.
1. Speichern Sie die Folie als SVG‑Bild in den Dateistream.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **SVG mit einer benutzerdefinierten Shape‑ID erzeugen**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape‑ID zu erzeugen. Verwenden Sie dafür die `setId`‑Methode von [SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape‑ID festzulegen.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **Miniaturbild einer Folie erstellen**

Aspose.Slides hilft Ihnen, Miniaturbilder von Folien zu erzeugen. Um mit Aspose.Slides ein Miniaturbild einer Folie zu erzeugen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über deren Index.
1. Holen Sie das Miniaturbild der referenzierten Folie in einem definierten Maßstab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Miniaturbild einer Folie mit benutzerdefinierten Abmessungen erstellen**

Um ein Miniaturbild einer Folie mit benutzerdefinierten Abmessungen zu erstellen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über deren Index.
1. Holen Sie das Miniaturbild der referenzierten Folie mit den definierten Abmessungen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Miniaturbild einer Folie mit Sprecher‑Notizen erstellen**

Um das Miniaturbild einer Folie mit Sprecher‑Notizen mithilfe von Aspose.Slides zu erzeugen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) Klasse.
1. Verwenden Sie die `RenderingOptions.setSlidesLayoutOptions`‑Methode, um die Position der Sprecher‑Notizen festzulegen.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über deren Index.
1. Holen Sie das Miniaturbild der referenzierten Folie mit den Rendering‑Optionen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Live‑Beispiel**

Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides‑API implementieren können:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kann ich einen Präsentationsviewer in eine Node.js‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides auf der Serverseite verwenden, um Folien als Bilder oder HTML zu rendern und im Browser anzuzeigen. Navigations‑ und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Wie lässt sich die Darstellung von Folien in einem benutzerdefinierten Viewer am besten umsetzen?**

Empfohlen wird, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in HTML zu konvertieren und das Ergebnis dann in einem Bildsteuerelement (für Desktop) bzw. einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen und vielen Folien um?**

Bei großen Decks sollten Sie Lazy‑Loading oder das Rendern von Folien bei Bedarf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicherverbrauch und Ladezeit reduziert werden.
---
title: Präsentationsbetrachter
type: docs
weight: 50
url: /de/nodejs-java/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentationsbetrachter
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides für Node.js über Java
description: "PowerPoint-Präsentationsbetrachter in JavaScript"
---
