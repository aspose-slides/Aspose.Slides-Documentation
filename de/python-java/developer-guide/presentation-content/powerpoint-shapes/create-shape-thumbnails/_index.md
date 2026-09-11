---
title: Erstellen von Miniaturbildern von Präsentationsformen in Python via Java
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/python-java/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Form-Bild
- Form rendern
- Form-Rendering
- visuelle Grenzen
- Form-Grenzen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erzeugen Sie hochwertige Form-Miniaturbilder aus PowerPoint‑Folien mit Aspose.Slides für Python via Java – erstellen und exportieren Sie Präsentations‑Miniaturbilder ganz einfach."
---
## **Einführung**

Aspose.Slides for Python via Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for Python via Java, Miniaturbilder der Folienformen zu erzeugen.

Dieser Artikel erklärt, wie man Shape-Thumbnails auf verschiedene Weise erstellt:

- Ein Shape-Thumbnail innerhalb einer Folie erzeugen.
- Ein Shape-Thumbnail für eine Folienform mit benutzerdefinierten Abmessungen erzeugen.
- Ein Shape-Thumbnail innerhalb der Grenzen des Aussehens einer Form erzeugen.

## **Ein Shape-Thumbnail aus einer Folie generieren**
Um ein Shape-Thumbnail aus einer beliebigen Folie mit Aspose.Slides for Python via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über deren ID oder Index.
1. [Rufen Sie das Shape-Thumbnail-Bild](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) einer Form auf der referenzierten Folie in der Standardskala ab.
1. Speichern Sie das Thumbnail-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie man ein Shape-Thumbnail aus einer Folie erzeugt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt.
presentation = Presentation("Thumbnail.pptx")
try:
    # Erstellen Sie ein Bild in voller Auflösung.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Speichern Sie das Bild im PNG-Format auf dem Datenträger.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Thumbnail mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Shape-Thumbnail einer Folie mit Aspose.Slides for Python via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über deren ID oder Index.
1. [Rufen Sie das Shape-Thumbnail-Bild](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) einer Form auf der referenzierten Folie mit benutzerdefinierten Abmessungen ab.
1. Speichern Sie das Thumbnail-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie man ein Shape-Thumbnail basierend auf einem definierten Skalierungsfaktor erzeugt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt.
presentation = Presentation("Thumbnail.pptx")
try:
    # Erstellen Sie ein Bild, das in beide Richtungen um den Faktor 2 skaliert ist.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Speichern Sie das Bild im PNG-Format auf dem Datenträger.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Bounds-basiertes Shape-Appearance-Thumbnail erstellen**
Diese Methode zum Erstellen von Thumbnails von Formen ermöglicht es Entwicklern, ein Thumbnail innerhalb der Grenzen des Aussehens der Form zu erzeugen. Sie berücksichtigt alle Formeffekte. Das erzeugte Shape-Thumbnail wird durch die Folienbegrenzungen eingeschränkt. Um ein Thumbnail einer Folienform innerhalb der Grenzen ihres Aussehens zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über deren ID oder Index.
1. Rufen Sie das Thumbnail-Bild einer Form auf der referenzierten Folie unter Verwendung ihrer Erscheinungsgrenzen ab.
1. Speichern Sie das Thumbnail-Bild in dem von Ihnen gewünschten Bildformat.

Dieser Beispielcode basiert auf den obigen Schritten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt.
presentation = Presentation("Thumbnail.pptx")
try:
    # Erstellen Sie ein Bild in voller Auflösung.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Speichern Sie das Bild im PNG-Format auf dem Datenträger.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Tatsächliche visuelle Begrenzungen einer Form abrufen**

Die Rahmen‑Eigenschaften von [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)—seine Methoden [getX](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getWidth) und [getHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getHeight)—beschreiben das im Präsentationsmodell gespeicherte Rechteck. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anderes achsenparallel ausgerichtetes Rechteck einnehmen. Drehungen, Konturen, Pfeilspitzen, Textlayout und Überlauf, generierte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getVisualBounds), um diesen belegten Bereich ohne Erstellen eines Bildes zu berechnen. Die Methode gibt ein [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in Folienkoordinaten zurück. Das zurückgegebene Rechteck wird nicht auf die Folie zugeschnitten, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Folienursprung hinausreicht.

Das folgende Beispiel ruft die Rahmen‑ und visuellen Begrenzungen ab und vergleicht sie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Das gleiche [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kann verwendet werden, um benachbarte Formen an dessen linker, rechter, oberer oder unterer Kante auszurichten; genug Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines zulässigen Bereichs zu erkennen. Visuelle Begrenzungen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppformen, bei denen der gespeicherte Rahmen möglicherweise nicht das vollständige gerenderte Ergebnis darstellt.

Verwenden Sie [Shape.getVisualBounds](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getVisualBounds), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [Shape.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage), wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapethumbnailbounds/#Shape) liefert die Bildgröße anhand der Formbegrenzungen, einschließlich Kontureinstellungen, während [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapethumbnailbounds/#Appearance) die Größe anhand des Aussehens der Form bestimmt und das Ergebnis auf die Folienbegrenzungen beschränkt. Im Gegensatz dazu gibt [Shape.getVisualBounds](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getVisualBounds) nur das berechnete Rechteck zurück und schneidet es nicht an die Folie ab.

## **FAQ**

**Welche Bildformate können beim Speichern von Shape-Thumbnails verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/), und andere. Formen können zudem als Vektor‑[SVG](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#writeAsSvgToBytes) exportiert werden, indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape- und Appearance‑Grenzen beim Rendern eines Thumbnails?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/python-java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als versteckt markiert ist? Wird sie trotzdem als Thumbnail gerendert?**

Eine versteckte Form bleibt Teil des Modells und kann gerendert werden; das Hidden‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Formabbildes.

**Werden Gruppformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes als [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) dargestellte Objekt (einschließlich [GroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/), und [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/)) kann als Thumbnail oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Thumbnails für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten [bereitstellen](/slides/de/python-java/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/python-java/font-substitution/)), um unerwünschte Fallbacks und Textumfluss zu vermeiden.