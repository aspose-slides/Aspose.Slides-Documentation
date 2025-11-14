---
title: Präsentationsbetrachter
type: docs
weight: 50
url: /de/python-net/presentation-viewer/
keywords: "PowerPoint-Präsentation ansehen, ppt ansehen, PPTX ansehen, Python, Aspose.Slides für Python über .NET"
description: "PowerPoint-Präsentation in Python ansehen"
---

Aspose.Slides für Python über .NET wird verwendet, um Präsentationsdateien zu erstellen, die Folien enthalten. Diese Folien können angezeigt werden, indem Präsentationen mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch Folien auch als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder ihren eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht es Aspose.Slides für Python über .NET, eine einzelne Folie als Bild zu exportieren. Dieser Artikel beschreibt, wie das geht. 

## **Live-Beispiel**
Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides API implementieren können:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **SVG-Bild aus Folie generieren**
Um ein SVG-Bild aus einer gewünschten Folie mit Aspose.Slides für Python zu generieren, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Erhalten Sie die Referenz der gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
- Holen Sie sich das SVG-Bild in einem Datenstrom.
- Speichern Sie den Datenstrom in einer Datei.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # Greifen Sie auf die erste Folie zu
    sld = pres.slides[0]

    # Erstellen Sie ein Datenstromobjekt
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # Generieren Sie das SVG-Bild der Folie und speichern Sie es im Datenstrom
        sld.write_as_svg(svg_stream)
```

## **SVG mit benutzerdefinierten Form-IDs generieren**
Aspose.Slides für Python über .NET kann verwendet werden, um [SVG ](https://docs.fileformat.com/page-description-language/svg/)aus Folien mit benutzerdefinierten Form-IDs zu generieren. Dazu verwenden Sie die ID-Eigenschaft von [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/), die die benutzerdefinierte ID von Formen im generierten SVG darstellt. Der CustomSvgShapeFormattingController kann verwendet werden, um die Form-ID festzulegen.

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```

## **Thumbnail-Bild von Folien erstellen**
Aspose.Slides für Python über .NET hilft Ihnen, Thumbnail-Bilder der Folien zu generieren. Um das Thumbnail einer gewünschten Folie mit Aspose.Slides für Python über .NET zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation("pres.pptx") as pres:
    # Greifen Sie auf die erste Folie zu
    sld = pres.slides[0]

    # Erstellen Sie ein vollformatiges Bild
    with sld.get_image(1, 1) as bmp:
        # Speichern Sie das Bild auf der Festplatte im JPEG-Format
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

## **Thumbnail mit benutzerdefinierten Abmessungen erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation("pres.pptx") as pres:
    # Greifen Sie auf die erste Folie zu
    sld = pres.slides[0]

    # Benutzerdefinierte Dimension
    desiredX = 1200
    desiredY = 800

    # Ermitteln des skalierten Wertes von X und Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

    # Erstellen Sie ein vollformatiges Bild
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # Speichern Sie das Bild auf der Festplatte im JPEG-Format
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```

## **Thumbnail aus Folie in der Notizenansicht erstellen**
Um das Thumbnail einer gewünschten Folie in der Notizenansicht mit Aspose.Slides für Python über .NET zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab in der Notizenansicht.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

Der folgende Code generiert ein Thumbnail der ersten Folie einer Präsentation in der Notizenansicht.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation("pres.pptx") as pres:
    # Greifen Sie auf die erste Folie zu
    sld = pres.slides[0]

    # Benutzerdefinierte Dimension
    desiredX = 1200
    desiredY = 800

    # Ermitteln des skalierten Wertes von X und Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

    # Erstellen Sie ein vollformatiges Bild                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # Speichern Sie das Bild auf der Festplatte im JPEG-Format
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```