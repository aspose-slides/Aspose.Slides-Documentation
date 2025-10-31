---
title: Erstellen von Vorschaubildern für Präsentationsformen in Python
linktitle: Form-Vorschaubilder
type: docs
weight: 70
url: /de/python-net/create-shape-thumbnails/
keywords:
- Form-Vorschaubild
- Formbild
- Form rendern
- Form-Rendering
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erzeugen Sie hochwertige Vorschaubilder von Formen aus PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für Python via .NET – erstellen und exportieren Sie Präsentations‑Vorschaubilder einfach."
---

## **Einleitung**

Aspose.Slides for Python via .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Sie können diese Folien in Microsoft PowerPoint anzeigen, indem Sie die Präsentationsdatei öffnen. Entwicklern kann es jedoch gelegentlich nötig sein, Bilder von Formen separat in einem Bildbetrachter zu betrachten. In solchen Fällen kann Aspose.Slides Vorschaubilder für Folienformen generieren. Dieser Artikel erklärt, wie man diese Funktion nutzt.

## **Vorschaubilder von Formen aus Folien generieren**

Wenn Sie eine Vorschau eines bestimmten Objekts statt der gesamten Folie benötigen, können Sie ein Vorschaubild für eine einzelne Form rendern. Aspose.Slides ermöglicht das Exportieren jeder Form in ein Bild, sodass Sie leicht leichtgewichtige Vorschauen, Symbole oder Assets für nachgelagerte Prozesse erstellen können.

Um ein Vorschaubild aus einer beliebigen Form zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
1. Holen Sie sich eine Referenz zu einer Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich eine Referenz zu einer Form auf dieser Folie.
1. Rendern Sie das Vorschaubild der Form.
1. Speichern Sie das Vorschaubild im gewünschten Format.

Das folgende Beispiel erzeugt ein Form‑Vorschaubild.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen Sie ein Bild mit der Standardskala.
    with shape.get_image() as thumbnail:
        # Speichern Sie das Bild im PNG-Format auf dem Datenträger.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Vorschaubilder mit benutzerdefiniertem Skalierungsfaktor erzeugen**

Dieser Abschnitt zeigt, wie man in Aspose.Slides Vorschaubilder von Formen mit einem vom Benutzer definierten Skalierungsfaktor erzeugt. Durch die Kontrolle der Skalierung können Sie die Größe des Vorschaubildes für Vorschauen, Exporte oder hochauflösende Displays feinabstimmen.

Um ein Vorschaubild für eine beliebige Form auf einer Folie zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
1. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich die Ziel‑Form auf dieser Folie.
1. Rendern Sie das Vorschaubild der Form mit dem angegebenen Skalierungsfaktor.
1. Speichern Sie das Vorschaubild im gewünschten Format.

Das folgende Beispiel erzeugt ein Vorschaubild mit einem vom Benutzer definierten Skalierungsfaktor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen Sie ein Bild mit der definierten Skalierung.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Speichern Sie das Bild im PNG-Format auf dem Datenträger.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Vorschaubilder unter Verwendung der Anzeigegrenzen einer Form erzeugen**

Dieser Abschnitt zeigt, wie man ein Vorschaubild innerhalb der Anzeigegrenzen einer Form erzeugt. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Vorschaubild ist durch die Foliengrenzen begrenzt.

Um ein Vorschaubild einer beliebigen Folienform innerhalb ihrer Anzeigegrenzen zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation]-Klasse.
1. Holen Sie sich eine Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich die Ziel‑Form auf dieser Folie.
1. Rendern Sie das Vorschaubild der Form mit den angegebenen Grenzen.
1. Speichern Sie das Vorschaubild im gewünschten Bildformat.

Das folgende Beispiel erstellt ein Vorschaubild mit benutzerdefinierten Grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Erstellen Sie ein Bild der Form unter Berücksichtigung der Anzeigegrenzen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Speichern Sie das Bild im PNG-Format auf dem Datenträger.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Vorschaubildern verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), und andere. Formen können auch [als Vektor‑SVG exportiert](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) werden, indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen den SHAPE‑ und APPEARANCE‑Grenzen beim Rendern eines Vorschaubildes?**

`SHAPE` verwendet die Geometrie der Form; `APPEARANCE` berücksichtigt [visuelle Effekte](/slides/de/python-net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie weiterhin als Vorschaubild gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblende‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape] (https://reference.aspose.com/slides/python-net/aspose.slides/shape/) repräsentiert wird (einschließlich [GroupShape] (https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart] (https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) und [SmartArt] (https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), kann als Vorschaubild oder als SVG gespeichert werden.

**Beeinflussen systemseitig installierte Schriftarten die Qualität von Vorschaubildern für Textformen?**

Ja. Sie sollten die [benötigten Schriftarten bereitstellen](/slides/de/python-net/custom-font/) (oder die [Schriftartersetzungen konfigurieren](/slides/de/python-net/font-substitution/)), um unerwünschte Rückfallbacks und Textumlauf zu vermeiden.