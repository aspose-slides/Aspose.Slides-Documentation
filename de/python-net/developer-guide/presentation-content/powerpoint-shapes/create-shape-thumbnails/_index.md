---
title: Miniaturbilder von Präsentationsformen in Python erstellen
linktitle: Formen‑Miniaturbilder
type: docs
weight: 70
url: /de/python-net/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Erzeugen Sie hochwertige Miniaturbilder von Formen aus PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Python via .NET – erstellen und exportieren Sie Präsentations‑Miniaturbilder ganz einfach."
---

## **Einleitung**

Aspose.Slides für Python via .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Sie können diese Folien in Microsoft PowerPoint ansehen, indem Sie die Präsentationsdatei öffnen. Entwickler müssen jedoch manchmal die Bilder von Formen separat in einem Bildbetrachter betrachten. In solchen Fällen kann Aspose.Slides Miniaturbilder für Folienformen erzeugen. Dieser Artikel erklärt, wie diese Funktion verwendet wird.

## **Miniaturbilder von Formen aus Folien erzeugen**

Wenn Sie eine Vorschau eines bestimmten Objekts statt der gesamten Folie benötigen, können Sie ein Miniaturbild für eine einzelne Form rendern. Aspose.Slides ermöglicht den Export jeder Form als Bild, sodass Sie leicht leichte Vorschauen, Symbole oder Assets für nachgelagerte Verarbeitungen erstellen können.

So erzeugen Sie ein Miniaturbild aus einer beliebigen Form:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie anhand ihrer ID oder ihres Index.  
3. Holen Sie sich eine Referenz zu einer Form auf dieser Folie.  
4. Rendern Sie das Miniaturbild der Form.  
5. Speichern Sie das Miniaturbild im gewünschten Format.

Das folgende Beispiel erzeugt ein Miniaturbild einer Form.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Bild mit der Standardskala erstellen.
    with shape.get_image() as thumbnail:
        # Bild im PNG‑Format auf die Festplatte speichern.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Miniaturbilder mit einem benutzerdefinierten Skalierungsfaktor erzeugen**

In diesem Abschnitt wird gezeigt, wie Miniaturbilder von Formen mit einem vom Benutzer definierten Skalierungsfaktor in Aspose.Slides erzeugt werden. Durch die Kontrolle der Skalierung können Sie die Miniaturgröße genau an Vorschauen, Exporte oder hochauflösende Displays anpassen.

So erzeugen Sie ein Miniaturbild für eine beliebige Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.  
3. Holen Sie sich die Ziel‑Form auf dieser Folie.  
4. Rendern Sie das Miniaturbild der Form mit dem angegebenen Skalierungsfaktor.  
5. Speichern Sie das Miniaturbild im gewünschten Format.

Das folgende Beispiel erzeugt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanziieren der Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Bild mit der definierten Skalierung erstellen.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Bild im PNG‑Format auf die Festplatte speichern.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Miniaturbilder anhand der Darstellung‑Grenzen einer Form erzeugen**

In diesem Abschnitt wird gezeigt, wie ein Miniaturbild innerhalb der Darstellung‑Grenzen einer Form erzeugt wird. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Miniaturbild ist auf die Folien‑Grenzen beschränkt.

So erzeugen Sie ein Miniaturbild einer beliebigen Folienform innerhalb ihrer Darstellung‑Grenzen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.  
3. Holen Sie sich die Ziel‑Form auf dieser Folie.  
4. Rendern Sie das Miniaturbild der Form mit den angegebenen Grenzen.  
5. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Das folgende Beispiel erstellt ein Miniaturbild mit benutzerdefinierten Grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanziieren der Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Bild der Form mit Darstellung‑Grenzen erstellen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Bild im PNG‑Format auf die Festplatte speichern.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Welche Bildformate können beim Speichern von Formen‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen SHAPE‑ und APPEARANCE‑Grenzen beim Rendern eines Miniaturbilds?**

`SHAPE` verwendet die Geometrie der Form; `APPEARANCE` berücksichtigt [visuelle Effekte](/slides/de/python-net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblend‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Form‑Bildes.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) und [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten bereitstellen [/slides/python-net/custom-font/](https://reference.aspose.com/slides/python-net/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/python-net/font-substitution/)), um unerwünschte Fallbacks und Textumbruch zu vermeiden.