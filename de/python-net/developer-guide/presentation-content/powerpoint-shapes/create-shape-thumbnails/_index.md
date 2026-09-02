---
title: Miniaturbilder von Präsentationsformen in Python erstellen
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/python-net/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Formbild
- Form rendern
- Form-Rendering
- Visuelle Grenzen
- Formgrenzen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Generieren Sie hochwertige Miniaturbilder von Formen aus PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via .NET – erstellen und exportieren Sie Präsentationsminiaturbilder einfach."
---
## **Einleitung**

Aspose.Slides for Python via .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Sie können diese Folien in Microsoft PowerPoint anzeigen, indem Sie die Präsentationsdatei öffnen. Entwickler müssen jedoch manchmal Bilder von Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen kann Aspose.Slides Miniaturbilder für Folienformen erzeugen. Dieser Artikel erklärt, wie diese Funktion verwendet wird.

## **Miniaturbilder von Formen aus Folien erzeugen**

Wenn Sie eine Vorschau eines bestimmten Objekts anstelle der gesamten Folie benötigen, können Sie ein Miniaturbild für eine einzelne Form rendern. Aspose.Slides ermöglicht den Export jeder Form als Bild, sodass Sie leicht schlanke Vorschauen, Symbole oder Assets für die Weiterverarbeitung erstellen können.

Um ein Miniaturbild aus einer beliebigen Form zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Referenz zu einer Folie anhand ihrer ID oder ihres Index ab.
3. Rufen Sie eine Referenz zu einer Form auf dieser Folie ab.
4. Rendern Sie das Miniaturbild der Form.
5. Speichern Sie das Miniaturbild im gewünschten Format.

Das nachstehende Beispiel erzeugt ein Miniaturbild einer Form.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Erstellen Sie ein Bild mit dem Standardmaßstab.
    with shape.get_image() as thumbnail:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Miniaturbilder mit benutzerdefiniertem Skalierungsfaktor erzeugen**

Dieser Abschnitt zeigt, wie Sie Miniaturbilder von Formen mit einem benutzerdefinierten Skalierungsfaktor in Aspose.Slides erzeugen. Durch die Steuerung des Maßstabs können Sie die Größe des Miniaturbildes feinabstimmen, um Vorschauen, Exporte oder hochauflösende Displays zu bedienen.

Um ein Miniaturbild für eine beliebige Form auf einer Folie zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Folie anhand ihrer ID oder ihres Index ab.
3. Rufen Sie die Ziel‑Form auf dieser Folie ab.
4. Rendern Sie das Miniaturbild der Form mit dem angegebenen Skalierungsfaktor.
5. Speichern Sie das Miniaturbild im gewünschten Format.

Das nachstehende Beispiel erzeugt ein Miniaturbild mit einem benutzerdefinierten Skalierungsfaktor.

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

Dieser Abschnitt zeigt, wie Sie ein Miniaturbild innerhalb der Anzeigegrenzen einer Form erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Miniaturbild ist durch die Foliengrenzen eingeschränkt.

Um ein Miniaturbild einer beliebigen Folienform innerhalb ihrer Anzeigegrenzen zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Folie anhand ihrer ID oder ihres Index ab.
3. Rufen Sie die Ziel‑Form auf dieser Folie ab.
4. Rendern Sie das Miniaturbild der Form mit den angegebenen Grenzen.
5. Speichern Sie das Miniaturbild im gewünschten Bildformat.

Das nachstehende Beispiel erstellt ein Miniaturbild mit benutzerdefinierten Grenzen.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Erstellen Sie ein Bild der Form anhand der Erscheinungsgrenzen.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Ermitteln der tatsächlichen visuellen Grenzen einer Form**

Die Rahmen‑Eigenschaften einer [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) — `Shape.x`, `Shape.y`, `Shape.width` und `Shape.height` — beschreiben das im Präsentationsmodell gespeicherte Rechteck. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anderes achsenparallel ausgerichtetes Rechteck einnehmen. Drehungen, Konturen, Pfeilspitzen, Textlayout und -überlauf, generierte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape.get_visual_bounds](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_visual_bounds/), um diesen belegten Bereich ohne Erzeugung eines Bildes zu berechnen. Die Methode gibt ein Fließkomma‑Rechteck in Folienkoordinaten zurück. Das zurückgegebene Rechteck wird nicht an die Folie geklippt, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Folienursprung hinausgeht.

Das nachstehende Beispiel ermittelt und vergleicht den Rahmen und die visuellen Grenzen:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Das gleiche Rechteck kann verwendet werden, um benachbarte Formen an seiner `left`, `right`, `top` oder `bottom`‑Kante auszurichten; ausreichend Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines erlaubten Bereichs zu erkennen. Visuelle Grenzen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppierungsformen, bei denen der gespeicherte Rahmen nicht das vollständig gerenderte Ergebnis darstellt.

Verwenden Sie [Shape.get_visual_bounds](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_visual_bounds/), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [Shape.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/), wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapethumbnailbounds/) legt `ShapeThumbnailBounds.SHAPE` die Bildgröße anhand der Form‑Grenzen fest, einschließlich Kontureinstellungen, während `ShapeThumbnailBounds.APPEARANCE` die Größe anhand der Anzeige der Form bestimmt und das Ergebnis auf die Foliengrenzen beschränkt. Im Gegensatz dazu gibt `Shape.get_visual_bounds` nur das berechnete Rechteck zurück und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Miniaturbildern von Formen verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/python-net/aspose.slides/imageformat/), und andere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/write_as_svg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen SHAPE‑ und APPEARANCE‑Grenzen beim Rendern eines Miniaturbildes?**

`SHAPE` verwendet die Geometrie der Form; `APPEARANCE` berücksichtigt [visuelle Effekte](/slides/de/python-net/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblend‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Bildes der Form.

**Werden Gruppierungsformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/) und [SmartArt](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriften die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten [die erforderlichen Schriften bereitstellen](/slides/de/python-net/custom-font/) (oder [Schriftersatz konfigurieren](/slides/de/python-net/font-substitution/)), um unerwünschte Fallbacks und Textumbruch zu vermeiden.