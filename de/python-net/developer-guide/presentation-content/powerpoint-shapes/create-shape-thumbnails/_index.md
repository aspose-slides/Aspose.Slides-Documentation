---
title: Erstellen von Thumbnails von Präsentationsformen in Python
linktitle: Form-Thumbnails
type: docs
weight: 70
url: /de/python-net/create-shape-thumbnails/
keywords:
- form thumbnail
- form bild
- render form
- form rendering
- PowerPoint
- präsentation
- Python
- Aspose.Slides
description: "Erzeugen Sie hochwertige Form-Thumbnail-Bilder aus PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via .NET – einfach Präsentations-Thumbnails erstellen und exportieren."
---

## **Einführung**

Aspose.Slides für Python via .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Sie können diese Folien in Microsoft PowerPoint anzeigen, indem Sie die Präsentationsdatei öffnen. Entwickler müssen jedoch manchmal die Bilder von Formen getrennt in einem Bildbetrachter ansehen. In solchen Fällen kann Aspose.Slides Thumbnail‑Bilder für Folienformen erzeugen. Dieser Artikel erklärt, wie diese Funktion verwendet wird.

## **Form‑Thumbnails aus Folien erzeugen**

Wenn Sie eine Vorschau eines bestimmten Objekts anstelle der gesamten Folie benötigen, können Sie ein Thumbnail für eine einzelne Form rendern. Aspose.Slides ermöglicht den Export jeder Form in ein Bild, wodurch sich leicht leichtgewichtige Vorschauen, Symbole oder Assets für nachgelagerte Verarbeitung erstellen lassen.

So erzeugen Sie ein Thumbnail aus einer beliebigen Form:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie anhand ihrer ID oder ihres Index.  
3. Holen Sie sich eine Referenz zu einer Form auf dieser Folie.  
4. Rendern Sie das Thumbnail‑Bild der Form.  
5. Speichern Sie das Thumbnail‑Bild im gewünschten Format.

Das folgende Beispiel erzeugt ein Form‑Thumbnail.

```py
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellt ein Bild mit dem Standardskalierungsfaktor.
    with shape.get_image() as thumbnail:
        # Speichert das Bild im PNG‑Format auf der Festplatte.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Thumbnails mit benutzerdefiniertem Skalierungsfaktor erzeugen**

Dieser Abschnitt zeigt, wie Sie Form‑Thumbnails mit einem vom Benutzer definierten Skalierungsfaktor in Aspose.Slides erzeugen. Durch die Steuerung der Skalierung können Sie die Thumbnail‑Größe an Vorschauen, Exporte oder hochauflösende Displays anpassen.

So erzeugen Sie ein Thumbnail für eine beliebige Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.  
3. Holen Sie sich die Ziel‑Form auf dieser Folie.  
4. Rendern Sie das Thumbnail‑Bild der Form mit dem angegebenen Skalierungsfaktor.  
5. Speichern Sie das Thumbnail‑Bild im gewünschten Format.

Das folgende Beispiel erzeugt ein Thumbnail mit einem benutzerdefinierten Skalierungsfaktor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanziiert die Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellt ein Bild mit dem definierten Skalierungsfaktor.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Speichert das Bild im PNG‑Format auf der Festplatte.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Thumbnails anhand der Erscheinungsgrenzen einer Form erzeugen**

Dieser Abschnitt zeigt, wie Sie ein Thumbnail innerhalb der Erscheinungsgrenzen einer Form erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Thumbnail ist durch die Foliengrenzen eingeschränkt.

So erzeugen Sie ein Thumbnail einer beliebigen Folienform innerhalb ihrer Erscheinungsgrenzen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.  
3. Holen Sie sich die Ziel‑Form auf dieser Folie.  
4. Rendern Sie das Thumbnail‑Bild der Form mit den angegebenen Grenzen.  
5. Speichern Sie das Thumbnail‑Bild im gewünschten Bildformat.

Das folgende Beispiel erstellt ein Thumbnail mit benutzerdefinierten Grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanziiert die Presentation‑Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Erstellt ein Bild mit Erscheinungs‑Grenzen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Speichert das Bild im PNG‑Format auf der Festplatte.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Thumbnails verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), und weitere. Formen können außerdem als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), indem der Forminhalt als SVG gespeichert wird.

**Was ist der Unterschied zwischen SHAPE‑ und APPEARANCE‑Grenzen beim Rendern eines Thumbnails?**

`SHAPE` verwendet die Geometrie der Form; `APPEARANCE` berücksichtigt [visuelle Effekte](/slides/de/python-net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Thumbnail gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblend‑Flag beeinflusst die Anzeige in der Präsentation, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) und [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), kann als Thumbnail oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Thumbnails für Textformen?**

Ja. Sie sollten die benötigten Schriftarten bereitstellen [/slides/python-net/custom-font/](/slides/de/python-net/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/python-net/font-substitution/)), um unerwünschte Ersatzschriften und Text‑Umbruch zu vermeiden.