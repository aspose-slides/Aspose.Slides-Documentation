---
title: Erstellen von Miniaturbildern von Präsentationsformen auf Android
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/androidjava/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Form-Bild
- Form rendern
- Form-Rendering
- visuelle Begrenzungen
- Formbegrenzungen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erzeugen Sie hochwertige Miniaturbilder von Formen aus PowerPoint‑Folien mit Aspose.Slides für Android via Java – erstellen und exportieren Sie Präsentations‑Miniaturbilder einfach."
---
## **Einleitung**

Aspose.Slides for Android via Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for Android via Java ihnen, Miniaturbilder der Folienformen zu erzeugen.

In diesem Thema zeigen wir, wie man Folien‑Miniaturbilder in verschiedenen Situationen erzeugt:

- Erzeugen eines Form‑Miniaturbildes innerhalb einer Folie.
- Erzeugen eines Form‑Miniaturbildes für eine Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen eines Form‑Miniaturbildes innerhalb der Begrenzungen des Erscheinungsbildes einer Form.

## **Ein Form‑Miniaturbild aus einer Folie erzeugen**
Um ein Form‑Miniaturbild aus einer beliebigen Folie mit Aspose.Slides for Android via Java zu erzeugen, führen Sie Folgendes aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index ab.
1. [Rufen Sie das Form‑Miniaturbild](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShape#getImage--) der referenzierten Folie in der Standardskala ab.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie man ein Form‑Miniaturbild aus einer Folie erzeugt:

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ein Miniaturbild mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Form‑Miniaturbild einer Folie mit Aspose.Slides for Android via Java zu erzeugen, führen Sie Folgendes aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index ab.
1. [Rufen Sie das Form‑Miniaturbild](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen ab.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode zeigt, wie man ein Form‑Miniaturbild basierend auf einem definierten Skalierungsfaktor erzeugt:

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ein durch Begrenzungen definiertes Miniaturbild des Form‑Erscheinungsbildes erstellen**
Diese Methode zum Erstellen von Miniaturbildern von Formen ermöglicht es Entwicklern, ein Miniaturbild innerhalb der Begrenzungen des Erscheinungsbildes einer Form zu erzeugen. Alle Formeffekte werden berücksichtigt. Das erzeugte Form‑Miniaturbild ist durch die Folienbegrenzungen eingeschränkt. Um ein Miniaturbild einer Folienform innerhalb ihrer Erscheinungsgrenzen zu erzeugen, führen Sie Folgendes aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index ab.
1. Rufen Sie das Miniaturbild der referenzierten Folie mit den Formgrenzen als Erscheinungsbild ab.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Dieser Beispielcode basiert auf den obigen Schritten:

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Die tatsächlichen visuellen Begrenzungen einer Form ermitteln**

Die Rahmen‑Eigenschaften von [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)—seine `getX()`, `getY()`, `getWidth()` und `getHeight()`‑Methoden—beschreiben das Rechteck, das im Präsentationsmodell gespeichert ist. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anderes achsen‑ausgerichtetes Rechteck einnehmen. Drehungen, Konturen, Pfeilspitzen, Textlayout und -überlauf, erzeugte SmartArt‑Geometrie sowie andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getVisualBounds--) , um diesen belegten Bereich ohne Erzeugung eines Bildes zu berechnen. Die Methode gibt ein [RectF](https://developer.android.com/reference/android/graphics/RectF) in Folienkoordinaten zurück. Das zurückgegebene Rechteck wird nicht auf die Folie zugeschnitten, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Folienursprung hinausreicht.

[Shape.getVisualBounds](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getVisualBounds--) ist derzeit nicht im [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)‑Interface deklariert. Bewahren Sie daher die aus der Form‑Sammlung der Folie erhaltene Form als Interface‑Wert auf und casten Sie sie nur beim Aufruf der Methode.

Das folgende Beispiel holt und vergleicht die Rahmen‑ und visuellen Begrenzungen:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Das gleiche [RectF](https://developer.android.com/reference/android/graphics/RectF) kann verwendet werden, um benachbarte Formen an deren linker, rechter, oberer oder unterer Kante auszurichten; genügend Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines zulässigen Bereichs zu erkennen. Visuelle Begrenzungen sind insbesondere für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppierungen nützlich, bei denen der gespeicherte Rahmen nicht das volle gerenderte Ergebnis widerspiegelt.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getVisualBounds--), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [IShape.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getImage--), wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapethumbnailbounds/) legt `ShapeThumbnailBounds.Shape` die Bildgröße anhand der Form‑Grenzen fest, einschließlich Kontureinstellungen, während `ShapeThumbnailBounds.Appearance` die Größe anhand des Erscheinungsbildes der Form bestimmt und das Ergebnis auf die Folienbegrenzungen beschränkt. Im Gegensatz dazu gibt [Shape.getVisualBounds](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getVisualBounds--) nur das berechnete Rechteck zurück und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Begrenzungen beim Rendern eines Miniaturbildes?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/androidjava/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als versteckt markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine versteckte Form bleibt Teil des Modells und kann gerendert werden; das versteckte Flag beeinflusst die Anzeige in der Diashow, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppierungen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/) (einschließlich [GroupShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/) und [SmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/smartart/)) dargestellt wird, kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten [bereitstellen](/slides/de/androidjava/custom-font/) (oder [Schriftart‑Ersetzungen konfigurieren](/slides/de/androidjava/font-substitution/)), um unerwünschte Rückfallbacks und Textumbrüche zu vermeiden.