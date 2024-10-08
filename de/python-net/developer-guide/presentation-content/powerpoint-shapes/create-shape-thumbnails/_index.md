---
title: Erstellen von Form-Thumbnails
type: docs
weight: 70
url: /de/python-net/create-shape-thumbnails/
keywords: "Form Thumbnail. PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Form Thumbnail in PowerPoint-Präsentation in Python"
---

Aspose.Slides für Python über .NET wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite ein Folie ist. Diese Folien können geöffnet werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Aber manchmal müssen Entwickler die Bilder der Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides für Python über .NET, Thumbnail-Bilder der Folienformen zu generieren. Wie man diese Funktion nutzt, wird in diesem Artikel beschrieben. 
Dieser Artikel erklärt, wie man Folien-Thumbnails auf verschiedene Weise generiert:

- Generierung eines Form-Thumbnails innerhalb einer Folie.
- Generierung eines Form-Thumbnails für eine Folienform mit benutzerdefinierten Abmessungen.
- Generierung eines Form-Thumbnails im Bereich des Erscheinungsbilds einer Form.
- Generierung eines Thumbnails eines SmartArt-Kindknotens.
## **Form-Thumbnail von Folie generieren**
Um ein Form-Thumbnail aus einer beliebigen Folie mit Aspose.Slides für Python über .NET zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie über ihre ID oder ihren Index.
1. Holen Sie sich das Thumbnail-Bild der Form der referenzierten Folie im Standardmaßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

Das folgende Beispiel generiert ein Form-Thumbnail.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Erstellen Sie ein Bild im Vollmaßstab
    with presentation.slides[0].shapes[0].get_image() as bitmap:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format
        bitmap.save("Shape_thumbnail_out.png", slides.ImageFormat.PNG)
```


## **Thumbnail mit benutzerdefiniertem Skalierungsfaktor generieren**
Um das Form-Thumbnail einer beliebigen Folienform mit Aspose.Slides für Python über .NET zu generieren:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie über ihre ID oder ihren Index.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie mit Formgrenzen.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

Das folgende Beispiel generiert ein Thumbnail mit einem benutzerdefinierten Skalierungsfaktor.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "HelloWorld.pptx") as p:
    # Erstellen Sie ein Bild im Vollmaßstab
    with p.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.SHAPE, 1, 1) as bitmap:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format
        bitmap.save("Scaling Factor Thumbnail_out.png", slides.ImageFormat.PNG)
```


## **Thumbnail des Erscheinungsbilds der Formgrenzen erstellen**
Diese Methode zur Erstellung von Thumbnails von Formen ermöglicht es Entwicklern, ein Thumbnail im Bereich des Erscheinungsbilds der Form zu generieren. Sie berücksichtigt alle Formeffekte. Das generierte Form-Thumbnail ist durch die Foliengrenzen eingeschränkt. Um ein Thumbnail einer beliebigen Folienform im Bereich ihres Erscheinungsbilds zu generieren, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie über ihre ID oder ihren Index.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie mit Formgrenzen als Erscheinungsbild.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

Das folgende Beispiel erstellt ein Thumbnail mit einem benutzerdefinierten Skalierungsfaktor.

```py
import aspose.slides as slides

# Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Erstellen Sie ein Erscheinungsbild begrenztes Formbild
    with presentation.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.APPEARANCE, 1, 1) as bitmap:
        # Speichern Sie das Bild auf der Festplatte im PNG-Format
        bitmap.save("Shape_thumbnail_Bound_Shape_out.png", slides.ImageFormat.PNG)
```