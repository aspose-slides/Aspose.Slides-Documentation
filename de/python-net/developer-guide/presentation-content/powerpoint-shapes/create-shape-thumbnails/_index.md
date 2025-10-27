---
title: Erstellen von Miniaturbildern von Präsentationsformen in Python
linktitle: Formen‑Miniaturbilder
type: docs
weight: 70
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/create-shape-thumbnails/
keywords:
- Form‑Miniaturbild
- Form‑Bild
- Form rendern
- Form‑Rendering
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erzeugen Sie hochwertige Miniaturbilder von Formen aus PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Python via .NET – erstellen und exportieren Sie Präsentations‑Miniaturbilder ganz einfach."
---

## **Einleitung**

Aspose.Slides für Python via .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Sie können diese Folien in Microsoft PowerPoint ansehen, indem Sie die Präsentationsdatei öffnen. Entwickler müssen jedoch manchmal die Bilder von Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen kann Aspose.Slides Miniaturbilder für Folienformen erzeugen. Dieser Artikel erklärt, wie diese Funktion verwendet wird.

## **Miniaturbilder von Formen aus Folien erzeugen**

Wenn Sie eine Vorschau eines bestimmten Objekts anstelle der gesamten Folie benötigen, können Sie ein Miniaturbild für eine einzelne Form rendern. Aspose.Slides ermöglicht es, jede Form als Bild zu exportieren, sodass Sie leicht leichtgewichtige Vorschauen, Icons oder Assets für nachgelagerte Prozesse erstellen können.

So erzeugen Sie ein Miniaturbild einer beliebigen Form:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren ID oder Index.
1. Holen Sie sich einen Verweis auf eine Form auf dieser Folie.
1. Rendern Sie das Miniaturbild der Form.
1. Speichern Sie das Miniaturbild im gewünschten Format.

Das folgende Beispiel erzeugt ein Form‑Miniaturbild.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen eines Bildes mit der Standardskala.
    with shape.get_image() as thumbnail:
        # Das Bild im PNG‑Format auf die Festplatte speichern.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Miniaturbilder mit benutzerdefiniertem Skalierungsfaktor erzeugen**

In diesem Abschnitt wird gezeigt, wie Sie Form‑Miniaturbilder mit einem vom Benutzer definierten Skalierungsfaktor in Aspose.Slides erzeugen. Durch die Skalierung können Sie die Größe des Miniaturbildes exakt an Vorschauen, Exporte oder hochauflösende Anzeigen anpassen.

So erzeugen Sie ein Miniaturbild einer beliebigen Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich eine Folie über deren ID oder Index.
1. Holen Sie sich die Ziel‑Form auf dieser Folie.
1. Rendern Sie das Miniaturbild der Form mit dem angegebenen Skalierungsfaktor.
1. Speichern Sie das Miniaturbild im gewünschten Format.

Das folgende Beispiel erzeugt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanziieren der Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen eines Bildes mit der definierten Skalierung.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Das Bild im PNG‑Format auf die Festplatte speichern.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Miniaturbilder unter Verwendung der Darstellungsgrenzen einer Form erzeugen**

Dieser Abschnitt zeigt, wie Sie ein Miniaturbild innerhalb der Darstellungsgrenzen einer Form erzeugen. Dabei werden alle Form‑Effekte berücksichtigt. Das erzeugte Miniaturbild ist auf die Foliengrenzen beschränkt.

So erzeugen Sie ein Miniaturbild einer beliebigen Folienform innerhalb ihrer Darstellungsgrenzen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich eine Folie über deren ID oder Index.
1. Holen Sie sich die Ziel‑Form auf dieser Folie.
1. Rendern Sie das Miniaturbild der Form mit den angegebenen Grenzen.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Das folgende Beispiel erstellt ein Miniaturbild mit benutzerdefinierten Grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanziieren der Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Erstellen eines Bildes, das die Darstellungsgrenzen der Form verwendet.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Das Bild im PNG‑Format auf die Festplatte speichern.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), und weitere. Formen können außerdem als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen den Grenzen SHAPE und APPEARANCE beim Rendern eines Miniaturbildes?**

`SHAPE` verwendet die Geometrie der Form; `APPEARANCE` berücksichtigt [visuelle Effekte](/slides/de/python-net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblend‑Flag beeinflusst nur die Anzeige in der Diashow, verhindert jedoch nicht die Erzeugung des Form‑Bildes.

**Werden Gruppierungsformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) dargestellt wird (inklusive [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), und [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten bereitstellen [/slides/python-net/custom-font/](/slides/de/python-net/custom-font/) (oder [Schriftart‑Ersetzungen konfigurieren](/slides/de/python-net/font-substitution/)), um unerwünschte Fallbacks und Text‑Umbrüche zu vermeiden.