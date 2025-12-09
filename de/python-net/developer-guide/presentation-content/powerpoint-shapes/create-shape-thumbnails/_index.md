---
title: Erstellen von Miniaturbildern von Präsentationsformen in Python
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/python-net/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Form-Bild
- Form rendern
- Form-Rendering
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Generieren Sie hochwertige Form-Miniaturbilder aus PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python über .NET – einfach Präsentationsminiaturbilder erstellen und exportieren."
---

## **Einleitung**

Aspose.Slides for Python via .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Sie können diese Folien in Microsoft PowerPoint anzeigen, indem Sie die Präsentationsdatei öffnen. Entwickler müssen jedoch manchmal Bilder von Formen separat in einem Bildbetrachter ansehen. In solchen Fällen kann Aspose.Slides Miniaturbilder für Folienformen erzeugen. Dieser Artikel erklärt, wie Sie diese Funktion verwenden.

## **Miniaturbilder von Formen aus Folien erzeugen**

Wenn Sie eine Vorschau eines bestimmten Objekts statt der gesamten Folie benötigen, können Sie ein Miniaturbild für eine einzelne Form rendern. Aspose.Slides ermöglicht das Exportieren jeder Form in ein Bild, wodurch das Erstellen leichter Vorschauen, Icons oder Assets für die Weiterverarbeitung einfach wird.

So erzeugen Sie ein Miniaturbild aus einer beliebigen Form:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich einen Verweis auf eine Form auf dieser Folie.
1. Rendern Sie das Miniaturbild der Form.
1. Speichern Sie das Miniaturbild im gewünschten Format.

Das folgende Beispiel erzeugt ein Miniaturbild einer Form.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen Sie ein Bild mit der Standard-Skalierung.
    with shape.get_image() as thumbnail:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```


## **Miniaturbilder mit benutzerdefiniertem Skalierungsfaktor erzeugen**

Dieser Abschnitt zeigt, wie Sie Miniaturbilder von Formen mit einem vom Benutzer definierten Skalierungsfaktor in Aspose.Slides erzeugen. Durch die Kontrolle der Skalierung können Sie die Größe des Miniaturbilds an Vorschauen, Exporte oder hochauflösende Displays anpassen.

So erzeugen Sie ein Miniaturbild für jede Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich die Ziel‑Form auf dieser Folie.
1. Rendern Sie das Miniaturbild der Form mit dem angegebenen Skalierungsfaktor.
1. Speichern Sie das Miniaturbild im gewünschten Format.

Das folgende Beispiel erzeugt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.
```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen Sie ein Bild mit dem definierten Maßstab.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```


## **Miniaturbilder unter Verwendung der Anzeigegrenzen einer Form erzeugen**

Dieser Abschnitt zeigt, wie Sie ein Miniaturbild innerhalb der Anzeigegrenzen einer Form erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Miniaturbild ist durch die Foliengrenzen begrenzt.

So erzeugen Sie ein Miniaturbild einer beliebigen Folienform innerhalb ihrer Anzeigegrenzen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich die Ziel‑Form auf dieser Folie.
1. Rendern Sie das Miniaturbild der Form mit den angegebenen Grenzen.
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Das folgende Beispiel erstellt ein Miniaturbild mit benutzerdefinierten Grenzen.
```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Erstellen Sie ein Bild der Form mit Anzeigegrenzen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```


## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturbildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), indem der Forminhalt als SVG gespeichert wird.

**Was ist der Unterschied zwischen SHAPE‑ und APPEARANCE‑Grenzen beim Rendern eines Miniaturbilds?**

`SHAPE` verwendet die Geometrie der Form; `APPEARANCE` berücksichtigt [visuelle Effekte](/slides/de/python-net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblend‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Form‑Bildes.

**Werden Gruppformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (einschließlich [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), und [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) dargestellt wird, kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systemseitig installierte Schriftarten die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die benötigten Schriftarten bereitstellen [/slides/python-net/custom-font/](https://example.com) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/python-net/font-substitution/)), um unerwünschte Rückfälle und Textumfluss zu vermeiden.