---
title: Optimieren Sie die Bildverwaltung in PowerPoint mit Python
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
- Präsentation
- Python
- Aspose.Slides
description: "Optimieren Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für Python über .NET, verbessern Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---

## **Übersicht**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Quellen auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien auf verschiedene Weise.

{{% alert  title="Tipp" color="primary" %}}
Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten — insbesondere, wenn Sie Standardformatierungsoptionen wie Größenänderung oder das Anwenden von Effekten verwenden wollen — siehe [Bilderrahmen zu Präsentationen mit Python hinzufügen](https://docs.aspose.com/slides/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}}
Sie können Bild‑ und Präsentations‑I/O‑Operationen verwenden, um Bilder zwischen Formaten zu konvertieren. Siehe diese Seiten: Bild zu JPG konvertieren ([image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)); JPG zu Bild konvertieren ([JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)); JPG zu PNG konvertieren ([JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)); PNG zu JPG konvertieren ([PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)); PNG zu SVG konvertieren ([PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)); SVG zu PNG konvertieren ([SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)).
{{% /alert %}}

Aspose.Slides unterstützt die Arbeit mit Bildern in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen.

## **Bilder, die lokal gespeichert sind, zu Folien hinzufügen**

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
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster ist die oberste Folie, die Informationen — Design, Layout usw. — für alle darunter liegenden Folien speichert und steuert. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesen Master verwendet.

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


## **Ein Bild als Folienhintergrund festlegen**

Sie möchten möglicherweise ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien verwenden. Details finden Sie unter [Bild als Hintergrund für eine Folie festlegen](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide).

## **SVG zu Präsentationen hinzufügen**

Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) der Klasse [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) verwenden.

Um ein Bildobjekt aus einem SVG zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) und fügen Sie es der Bildsammlung der Präsentation hinzu.  
2. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekt aus dem [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/).  
3. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)‑Objekt mit dem [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

Das folgende Python‑Beispiel zeigt, wie man ein SVG‑Bild zu einer Präsentation hinzufügt, indem diese Schritte verwendet werden:
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Inhalt einer SVG-Datei lesen.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Erstelle ein SvgImage-Objekt.
        svg_image = slides.SvgImage(svg_content)

        # Erstelle ein PPImage-Objekt.
        pp_image = presentation.images.add_image(svg_image)

        # Erstelle ein neues PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Speichere die Präsentation im PPTX-Format.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **SVG in eine Menge von Formen konvertieren**

Aspose.Slides konvertiert SVGs in eine Menge von Formen, ähnlich wie PowerPoint SVG‑Dateien verarbeitet.

![PowerPoint‑Popup‑Menü](img_01_01.png)

Diese Funktionalität wird durch eine Überladung der Methode [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) in der Klasse [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) bereitgestellt, die ein [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) als erstes Argument akzeptiert.

Der Beispielcode unten zeigt, wie man eine SVG‑Datei in eine Menge von Formen konvertiert.
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Inhalt der SVG-Datei lesen.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Erstelle ein SvgImage-Objekt.
        svg_image = slides.SvgImage(svg_content)

        # Hole die Foliengröße.
        slide_size = presentation.slide_size.size

        # Konvertiere das SVG-Bild in eine Gruppe von Formen und skaliere es auf die Foliengröße.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Speichere die Präsentation im PPTX-Format.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **Bilder als EMF in Folien hinzufügen**

Aspose.Slides für Python ermöglicht das Einfügen von Enhanced Metafile (EMF)‑Bildern in Präsentationen.

Das folgende Python‑Beispiel demonstriert dies:
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```


## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides erlaubt das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich der von Folienformen genutzten Bilder. Dieser Abschnitt beschreibt mehrere Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API bietet einfache Methoden, um ein Bild durch rohe Byte‑Daten, eine [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)-Instanz oder ein anderes bereits in der Sammlung vorhandenes Bild zu ersetzen.

Gehen Sie wie folgt vor:

1. Laden Sie die Präsentation, die die Bilder enthält, mit der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.  
3. Ersetzen Sie das Zielbild durch das neue Bild mittels des Byte‑Arrays.  
4. Alternativ laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)-Objekt und ersetzen das Zielbild durch dieses Objekt.  
5. Oder ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation vorhanden ist.  
6. Speichern Sie die bearbeitete Präsentation als PPTX‑Datei.
```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
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

    # Speichern Sie die Präsentation in einer Datei.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
Mit Asposes kostenlosem [Text zu GIF](https://products.aspose.app/slides/text-to-gif)-Konverter können Sie Text leicht animieren und GIFs aus Text erstellen.
{{% /alert %}}

## **FAQ**

**Bleibt die Originalauflösung des Bildes nach dem Einfügen erhalten?**  
Ja. Die Quellpixel werden beibehalten, jedoch hängt das endgültige Aussehen davon ab, wie das [picture](/slides/de/python-net/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, dasselbe Logo gleichzeitig in Dutzenden von Folien zu ersetzen?**  
Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation — Änderungen werden auf alle Elemente, die diese Ressource nutzen, übertragen.

**Kann ein eingefügtes SVG in bearbeitbare Formen konvertiert werden?**  
Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren; danach werden einzelne Teile mit den üblichen Formeigenschaften editierbar.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**  
[Weisen Sie das Bild als Hintergrund](https://docs.aspose.com/slides/python-net/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu — alle Folien, die diesen Master/Layout verwenden, übernehmen den Hintergrund.

**Wie kann ich verhindern, dass die Präsentation durch viele Bilder stark anwächst?**  
Verwenden Sie ein einzelnes Bild mehrfach statt Duplikaten, wählen Sie angemessene Auflösungen, komprimieren Sie beim Speichern und halten Sie wiederholte Grafiken nach Möglichkeit im Master.