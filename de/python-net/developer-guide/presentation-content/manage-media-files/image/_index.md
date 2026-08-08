---
title: Bildverwaltung in PowerPoint mit Python optimieren
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/python-net/image/
keywords:
- Bild hinzufügen
- Bild hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Bild ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Vereinfachen Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für Python über .NET, optimieren Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einleitung**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Quellen in Folien einfügen. Ähnlich ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien auf verschiedene Arten.

{{% alert  title="Tipp" color="primary" %}}
Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten – insbesondere, wenn Sie planen, Standardformatierungsoptionen wie Größenänderung oder das Anwenden von Effekten zu verwenden – siehe [Bilderrahmen zu Präsentationen mit Python hinzufügen](https://docs.aspose.com/slides/de/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}}
Sie können Bild‑ und Präsentations‑I/O‑Operationen nutzen, um Bilder zwischen Formaten zu konvertieren. Siehe diese Seiten: konvertieren [Bild zu JPG](https://products.aspose.com/slides/de/python-net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/de/python-net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/de/python-net/conversion/jpg-to-png/); konvertieren [PNG zu JPG](https://products.aspose.com/slides/de/python-net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/de/python-net/conversion/png-to-svg/); und konvertieren [SVG zu PNG](https://products.aspose.com/slides/de/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides unterstützt die Arbeit mit Bildern in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen.

## **Bilder lokal zu Folien hinzufügen**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie in einer Präsentation hinzufügen. Das folgende Python‑Beispiel zeigt, wie man ein Bild zu einer Folie hinzufügt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie es direkt aus dem Web einfügen.

Das folgende Python‑Beispiel zeigt, wie man ein Bild von einer URL zu einer Folie hinzufügt:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Rohbildbytes herunterladen.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster ist die übergeordnete Folie, die Informationen – Thema, Layout usw. – für alle darunter liegenden Folien speichert und steuert. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesen Master verwendet.

Das folgende Python‑Beispiel zeigt, wie man ein Bild zu einem Folienmaster hinzufügt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder als Folienhintergründe hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Weitere Details siehe *[Bilder als Hintergründe für Folien festlegen](/slides/de/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG‑Inhalte können einer Präsentation mit der Klasse [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/) hinzugefügt werden. Das resultierende SVG‑Bild kann dann zur Bildsammlung der Präsentation hinzugefügt und zur Erstellung eines Bildrahmens verwendet werden.

Das folgende Python‑Beispiel importiert einen eigenständigen SVG‑String. Alle von diesem SVG verwendeten Bilder, Stile und anderen Ressourcen sind direkt im SVG‑Inhalt eingebettet.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG in eine Menge von Formen konvertieren**

Aspose.Slides konvertiert SVGs in eine Menge von Formen, ähnlich wie PowerPoint mit SVGs umgeht.

![PowerPoint‑Popup‑Menü](img_01_01.png)

Diese Funktionalität wird durch eine Überladung der Methode [add_group_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_group_shape/) in der Klasse [ShapeCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/) bereitgestellt, die ein [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/) als erstes Argument übernimmt. 

Der Beispielcode unten zeigt, wie man eine SVG‑Datei in eine Menge von Formen konvertiert.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG-Dateiinhalt lesen.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # SvgImage-Objekt erstellen.
        svg_image = slides.SvgImage(svg_content)

        # Foliengröße ermitteln.
        slide_size = presentation.slide_size.size

        # SVG-Bild in eine Gruppe von Formen konvertieren und auf die Foliengröße skalieren.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Präsentation im PPTX-Format speichern.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder als EMF zu Folien hinzufügen**

Aspose.Slides für Python ermöglicht das Einfügen von Enhanced Metafile (EMF)-Bildern in Präsentationen.

Das folgende Python‑Beispiel demonstriert dies:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich derjenigen, die von Folienformen verwendet werden. Dieser Abschnitt beschreibt mehrere Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API stellt einfache Methoden zum Ersetzen eines Bildes durch rohe Byte‑Daten, eine [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/)‑Instanz oder ein anderes bereits in der Sammlung vorhandenes Bild bereit.

Folgen Sie diesen Schritten:

1. Laden Sie die Präsentation, die die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
1. Ersetzen Sie das Zielbild durch das neue Bild unter Verwendung des Byte‑Arrays.
1. Alternativ laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
1. Oder ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation vorhanden ist.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:

    # Der erste Weg.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Der zweite Weg.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Der dritte Weg.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Die Präsentation in einer Datei speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Mit Asposes kostenlosem [Text‑zu‑GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Text einfach animieren und GIFs aus Text erstellen.
{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die ursprünglichen Pixel werden beibehalten, jedoch hängt das endgültige Erscheinungsbild davon ab, wie das [Bild](/slides/de/python-net/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, dasselbe Logo gleichzeitig auf Dutzenden von Folien zu ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation – die Änderungen werden auf alle Elemente, die diese Ressource verwenden, übertragen.

**Kann ein eingefügtes SVG in bearbeitbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, wonach einzelne Teile mit den üblichen Formeigenschaften bearbeitbar werden.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**

[Weisen Sie das Bild als Hintergrund zu](/slides/de/python-net/presentation-background/) auf dem Master‑Slide oder dem entsprechenden Layout – alle Folien, die diesen Master/Layout verwenden, übernehmen den Hintergrund.

**Wie verhindere ich, dass eine Präsentation durch viele Bilder zu groß wird?**

Verwenden Sie eine einzelne Bildressource mehrfach statt Duplikaten, wählen Sie vernünftige Auflösungen, wenden Sie beim Speichern Kompression an und behalten Sie wiederholte Grafiken nach Möglichkeit im Master.