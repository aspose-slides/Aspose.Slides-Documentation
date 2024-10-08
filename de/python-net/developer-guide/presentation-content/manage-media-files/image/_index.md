---
title: Bild
type: docs
weight: 10
url: /de/python-net/image/
keywords: "Bild hinzufügen, Foto hinzufügen, PowerPoint-Präsentation, EMF, SVG, Python, Aspose.Slides für Python über .NET"
description: "Bild zu PowerPoint-Folie oder Präsentation in Python hinzufügen"
---

## **Bilder in Folien in Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Speicherorten in Folien einfügen. Ebenso ermöglicht Aspose.Slides, Bilder durch verschiedene Verfahren zu Folien in Ihren Präsentationen hinzuzufügen.

{{% alert title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten—insbesondere wenn Sie planen, Standardformatierungsoptionen zu verwenden, um seine Größe zu ändern, Effekte hinzuzufügen usw.—sehen Sie sich [Bilderrahmen](https://docs.aspose.com/slides/python-net/picture-frame/) an. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Ein- und Ausgabebetriebsvorgänge, die Bilder und PowerPoint-Präsentationen betreffen, manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Sehen Sie sich diese Seiten an: konvertieren [Bild zu JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Vorgänge mit Bildern in diesen beliebten Formaten: JPEG, PNG, BMP, GIF und anderen. 

## **Hinzufügen von lokal gespeicherten Bildern zu Folien**

Sie können ein oder mehrere Bilder auf Ihrem Computer auf eine Folie in einer Präsentation hinzufügen. Dieser Beispielcode in Python zeigt Ihnen, wie Sie ein Bild zu einer Folie hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Hinzufügen von Bildern aus dem Internet zu Folien**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, auf Ihrem Computer nicht verfügbar ist, können Sie das Bild direkt aus dem Internet hinzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Bild aus dem Internet zu einer Folie in Python hinzufügen:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[ERSETZEN MIT URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Hinzufügen von Bildern zu Folienmaster**

Ein Folienmaster ist die oberste Folie, die Informationen (Thema, Layout usw.) über alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die zu diesem Folienmaster gehört. 

Dieser Python-Beispielcode zeigt Ihnen, wie Sie ein Bild zu einem Folienmaster hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Hinzufügen von Bildern als Folienhintergrund**

Sie möchten möglicherweise ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien verwenden. In diesem Fall sollten Sie sich *[Bilder als Hintergründe für Folien festlegen](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **Hinzufügen von SVG zu Präsentationen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) verwenden, die zur [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Schnittstelle gehört.

Um ein Bildobjekt basierend auf einem SVG-Bild zu erstellen, können Sie es so machen:

1. Erstellen Sie ein SvgImage-Objekt, um es in die ImageShapeCollection einzufügen
2. Erstellen Sie ein PPImage-Objekt aus ISvgImage
3. Erstellen Sie ein PictureFrame-Objekt unter Verwendung der IPPImage-Schnittstelle

Dieser Beispielcode zeigt Ihnen, wie Sie die oben beschriebenen Schritte implementieren, um ein SVG-Bild in eine Präsentation hinzuzufügen:
```py 
import aspose.slides as slides

# Erstellen Sie eine neue Präsentation
with slides.Presentation() as p:
    # Lesen Sie den Inhalt der SVG-Datei
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Erstellen Sie ein SvgImage-Objekt
        svgImage = slides.SvgImage(svgContent)

        # Erstellen Sie ein PPImage-Objekt
        ppImage = p.images.add_image(svgImage)

        # Erstellt ein neues PictureFrame 
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # Präsentation im PPTX-Format speichern
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Konvertieren von SVG in eine Gruppe von Formen**
Die Konvertierung von SVG in eine Gruppe von Formen durch Aspose.Slides ist ähnlich wie die PowerPoint-Funktionalität, die verwendet wird, um mit SVG-Bildern zu arbeiten:

![PowerPoint-Popup-Menü](img_01_01.png)

Die Funktionalität wird durch eine der Überladungen der Methode [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/) der [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Schnittstelle bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/) Objekt als erstes Argument übernimmt.

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Methode verwenden, um eine SVG-Datei in eine Gruppe von Formen zu konvertieren:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lesen Sie den Inhalt der SVG-Datei
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Erstellen Sie ein SvgImage-Objekt
        svgImage = slides.SvgImage(svgContent)

        # Holen Sie die Foliengröße
        slide_size = presentation.slide_size.size

        # Konvertieren Sie das SVG-Bild in eine Gruppe von Formen, indem Sie es auf die Foliengröße skalieren
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # Präsentation im PPTX-Format speichern
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, das EMF-Bild hinzuzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Aufgabe ausführen:

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose [Text nach GIF](https://products.aspose.app/slides/text-to-gif) Konverter können Sie Texte einfach animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}