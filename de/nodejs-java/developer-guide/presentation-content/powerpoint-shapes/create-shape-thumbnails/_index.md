---
title: Form-Miniaturansichten erstellen
type: docs
weight: 70
url: /de/nodejs-java/create-shape-thumbnails/
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides für Node.js via Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen getrennt in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides für Node.js via Java, Miniaturbilder der Folienformen zu erzeugen.

{{% /alert %}} 

In diesem Thema zeigen wir, wie Miniaturbilder von Folienformen in verschiedenen Situationen erzeugt werden:

- Erzeugen einer Miniaturansicht einer Form innerhalb einer Folie.
- Erzeugen einer Miniaturansicht einer Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen einer Miniaturansicht innerhalb der Begrenzungen des Erscheinungsbildes einer Form.

## **Erzeugen von Form‑Miniaturansichten aus Folien**
Um eine Form‑Miniaturansicht aus einer beliebigen Folie mit Aspose.Slides für Node.js via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. [Rufen Sie das Form‑Miniaturbild](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) der referenzierten Folie in der Standardskala ab.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie Sie eine Form‑Miniaturansicht aus einer Folie erzeugen:
```javascript
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Erstelle ein Bild im Vollmaßstab
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Speichere das Bild auf der Festplatte im PNG-Format
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


## **Erzeugen von Form‑Miniaturansichten mit benutzerdefiniertem Skalierungsfaktor**
Um die Form‑Miniaturansicht einer Folie mit Aspose.Slides für Node.js via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. [Rufen Sie das Form‑Miniaturbild](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen ab.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie Sie eine Form‑Miniaturansicht basierend auf einem definierten Skalierungsfaktor erzeugen:
```javascript
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild im Vollmaßstab
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


## **Erzeugen einer Form‑Miniaturansicht innerhalb von Begrenzungen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Begrenzungen des Erscheinungsbildes der Form zu erzeugen. Sie berücksichtigt alle Formeffekte. Das erzeugte Form‑Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. Um ein Miniaturbild einer Folienform innerhalb ihrer Erscheinungsbegrenzung zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Miniaturbild der referenzierten Folie mit Form‑Begrenzungen als Erscheinungsbild ab.
4. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode basiert auf den oben genannten Schritten:
```javascript
// Instanziieren Sie eine Presentation‑Klasse, die die Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild im Vollmaßstab
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


## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturansichten verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/ ) und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/ ), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Begrenzungen beim Rendern einer Miniaturansicht?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/nodejs-java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das ausgeblendete Flag beeinflusst die Anzeige in der Diashow, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppierungsformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) und [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten bereitstellen](/slides/de/nodejs-java/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/nodejs-java/font-substitution/)), um unerwünschte Ersatzdarstellungen und Textumbrüche zu vermeiden.