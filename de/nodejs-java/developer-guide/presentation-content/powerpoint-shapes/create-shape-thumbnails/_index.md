---
title: Erstellen von Miniaturbildern von Präsentationsformen in JavaScript
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/nodejs-java/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Form-Bild
- Form rendern
- Form-Rendering
- visuelle Begrenzungen
- Formbegrenzungen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Generieren Sie hochwertige Form-Miniaturbilder aus PowerPoint-Folien mit JavaScript und Aspose.Slides für Node.js – einfach Präsentations-Miniaturbilder erstellen und exportieren."
---
## **Einführung**

Aspose.Slides wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können durch Öffnen der Präsentationsdateien mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides dabei, Miniaturbilder der Folienformen zu erzeugen. Die Verwendung dieser Funktion wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie man Folien‑Miniaturbilder auf unterschiedliche Weise erzeugt:

- Erzeugen eines Form‑Miniaturbildes innerhalb einer Folie.
- Erzeugen eines Form‑Miniaturbildes für eine Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen eines Form‑Miniaturbildes innerhalb der Begrenzungen des Erscheinungsbildes einer Form.

## **Erzeugen von Form‑Miniaturbildern aus Folien**
So erzeugen Sie ein Form‑Miniaturbild aus einer beliebigen Folie mit Aspose.Slides für Node.js über Java:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
3. [Rufen Sie das Form‑Miniaturbild](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#getImage--) der referenzierten Folie in der Standardgröße ab.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie man ein Form‑Miniaturbild aus einer Folie erzeugt:

```javascript
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Erzeugen von Form‑Miniaturbildern mit benutzerdefiniertem Skalierungsfaktor**
So erzeugen Sie das Form‑Miniaturbild einer Folie mit Aspose.Slides für Node.js über Java:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
3. [Rufen Sie das Form‑Miniaturbild](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen ab.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie man ein Form‑Miniaturbild basierend auf einem definierten Skalierungsfaktor erzeugt:

```javascript
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Erzeugen von Form‑Miniaturbildern mit Begrenzungen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Begrenzungen des Erscheinungsbildes der Form zu erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Form‑Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. So erzeugen Sie ein Miniaturbild einer Folienform in den Grenzen ihres Erscheinungsbildes:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
3. Rufen Sie das Miniaturbild der referenzierten Folie mit den Formgrenzen als Erscheinungsbild ab.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode basiert auf den oben genannten Schritten:

```javascript
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ermitteln der tatsächlichen visuellen Begrenzungen einer Form**

Die Rahmen‑Eigenschaften einer [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/)‑Klasse – ihre Methoden `getX()`, `getY()`, `getWidth()` und `getHeight()` – beschreiben das im Präsentationsmodell gespeicherte Rechteck. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anderes achsen­ausgerichtetes Rechteck einnehmen. Drehungen, Konturen, Pfeilspitzen, Textlayout und Überlauf, erzeugte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getVisualBounds--) , um diesen belegten Bereich ohne Erstellung eines Bildes zu berechnen. Die Methode gibt ein [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)‑Objekt in Folienkoordinaten zurück. Das zurückgegebene Rechteck wird nicht auf die Folie zugeschnitten, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Folienursprung hinausreicht.

Das folgende Beispiel ermittelt und vergleicht die Rahmen‑ und visuellen Begrenzungen:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Dasselbe Rechteck kann verwendet werden, um benachbarte Formen links, rechts, oben oder unten auszurichten; ausreichend Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines erlaubten Bereichs zu erkennen. Visuelle Begrenzungen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppierungen, bei denen der gespeicherte Rahmen nicht das vollständige gerenderte Ergebnis darstellt.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getVisualBounds--) , wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [Shape.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getImage--) , wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapethumbnailbounds/) legt `ShapeThumbnailBounds.Shape` die Bildgröße anhand der Formgrenzen (einschließlich Kontureinstellungen) fest, während `ShapeThumbnailBounds.Appearance` die Größe anhand des Erscheinungsbildes der Form bestimmt und das Ergebnis auf die Folienbegrenzungen beschränkt. Im Gegensatz dazu gibt [Shape.getVisualBounds](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getVisualBounds--) nur das berechnete Rechteck zurück und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/writeassvg/), indem der Forminhalt als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Begrenzungen beim Rendern eines Miniaturbildes?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt dabei [visuelle Effekte](/slides/de/nodejs-java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine verborgene Form bleibt Teil des Modells und kann gerendert werden; das Versteckt‑Flag wirkt sich nur auf die Präsentationsanzeige aus, verhindert jedoch nicht die Erzeugung des Form‑Bildes.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) (einschließlich [GroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) und [SmartArt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartart/)) repräsentiert wird, kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriften die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriften [bereitstellen](/slides/de/nodejs-java/custom-font/) (oder [Schriftart‑Ersetzungen konfigurieren](/slides/de/nodejs-java/font-substitution/)), um unerwünschte Rückfälle und Textumlauf zu vermeiden.