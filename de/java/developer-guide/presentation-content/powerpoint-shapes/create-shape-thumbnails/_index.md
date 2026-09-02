---
title: Miniaturansichten von Präsentationsformen in Java erstellen
linktitle: Form-Miniaturansichten
type: docs
weight: 70
url: /de/java/create-shape-thumbnails/
keywords:
- Form-Miniaturansicht
- Form-Bild
- Form rendern
- Form-Rendering
- Visuelle Grenzen
- Form-Grenzen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erzeugen Sie hochqualitative Form-Miniaturansichten aus PowerPoint-Folien mit Aspose.Slides for Java – erstellen und exportieren Sie Präsentations-Miniaturansichten einfach."
---
## **Einleitung**

Aspose.Slides for Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides for Java ihnen, Miniaturbilder der Folienformen zu erzeugen.

Dieser Artikel erklärt, wie Folien‑Miniaturbilder auf verschiedene Arten erzeugt werden können:

- Erzeugen einer Form‑Miniatur innerhalb einer Folie.
- Erzeugen einer Form‑Miniatur für eine Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen einer Form‑Miniatur innerhalb der Grenzen des Aussehens einer Form.

## **Eine Form‑Miniatur aus einer Folie erzeugen**
Um mit Aspose.Slides for Java eine Form‑Miniatur aus einer beliebigen Folie zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.
1. [Abrufen des Form‑Miniatur‑Bildes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getImage--) der referenzierten Folie in der Standardskala.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieses Beispielcode zeigt, wie Sie eine Form‑Miniatur aus einer Folie erzeugen:

```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstelle ein vollskaliertes Bild
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Speichere das Bild im PNG-Format auf die Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Miniatur mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um mit Aspose.Slides for Java die Form‑Miniatur einer Folie zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.
1. [Abrufen des Form‑Miniatur‑Bildes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieses Beispielcode zeigt, wie Sie eine Form‑Miniatur basierend auf einem definierten Skalierungsfaktor erzeugen:

```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstelle ein vollskaliertes Bild
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Speichere das Bild im PNG-Format auf die Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Miniatur basierend auf den Grenzen des Form‑Aussehens erstellen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht es Entwicklern, eine Miniatur innerhalb der Grenzen des Aussehens der Form zu erzeugen. Sie berücksichtigt alle Formeffekte. Das erzeugte Form‑Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. Um eine Miniatur einer Folienform innerhalb ihrer Erscheinungsgrenze zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.
1. Abrufen des Miniaturbildes der referenzierten Folie mit Form‑Grenzen als Erscheinungsbild.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode basiert auf den oben genannten Schritten:

```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstelle ein vollskaliertes Bild
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Speichere das Bild im PNG-Format auf die Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ermitteln der tatsächlichen visuellen Grenzen einer Form**

Die Rahmen‑Eigenschaften von [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)—ihre Methoden `getX()`, `getY()`, `getWidth()` und `getHeight()`—beschreiben das im Präsentationsmodell gespeicherte Rechteck. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anders ausgerichtetes Rechteck einnehmen. Drehungen, Konturen, Pfeilspitzen, Textlayout und Überlauf, generierte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getVisualBounds--) , um diesen belegten Bereich ohne Erzeugung eines Bildes zu berechnen. Die Methode liefert ein [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in Folienkoordinaten. Das zurückgegebene Rechteck ist nicht auf die Folie beschränkt, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Folienursprung hinausgeht.

[Shape.getVisualBounds](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getVisualBounds--) ist derzeit nicht im [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)-Interface deklariert. Daher sollten Sie die aus der Folien‑Form‑Sammlung erhaltene Form als Interface‑Wert beibehalten und erst beim Aufruf der Methode casten.

Das folgende Beispiel ermittelt und vergleicht den Rahmen und die visuellen Grenzen:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Das gleiche [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kann verwendet werden, um benachbarte Formen an seiner linken, rechten, oberen oder unteren Kante auszurichten; in einem generierten Layout ausreichend Platz zu reservieren; oder Inhalte außerhalb eines erlaubten Bereichs zu erkennen. Visuelle Grenzen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppenformen, bei denen der gespeicherte Rahmen nicht das vollständig gerenderte Ergebnis repräsentiert.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getVisualBounds--), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [IShape.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getImage--) wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapethumbnailbounds/) gibt `ShapeThumbnailBounds.Shape` die Bildgröße anhand der Form‑Grenzen, einschließlich Kontureinstellungen, während `ShapeThumbnailBounds.Appearance` die Größe anhand des Aussehens der Form bestimmt und das Ergebnis auf die Folienbegrenzungen beschränkt. Im Gegensatz dazu liefert [Shape.getVisualBounds](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getVisualBounds--) nur das berechnete Rechteck und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern einer Miniatur?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt die [visuellen Effekte](/slides/de/java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als versteckt markiert ist? Wird sie trotzdem als Miniatur gerendert?**

Eine versteckte Form bleibt Teil des Modells und kann gerendert werden; die versteckte Markierung beeinflusst die Slideshow‑Anzeige, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/) (einschließlich [GroupShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/), und [SmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/smartart/)) dargestellt wird, kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten [bereitstellen](/slides/de/java/custom-font/) (oder die [Schriftart‑Ersetzungen konfigurieren](/slides/de/java/font-substitution/)), um unerwünschte Fallbacks und Textumlauf zu vermeiden.