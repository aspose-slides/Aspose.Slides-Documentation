---
title: Ersetzen von Bildern in der Präsentationsbildsammlung
type: docs
weight: 110
url: /python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides für Python über .NET ermöglicht es, die in Folienformen hinzugefügten Bilder zu ersetzen. Dieser Artikel erklärt, wie das Bild in der Präsentationsbildsammlung mithilfe verschiedener Ansätze ersetzt werden kann.

{{% /alert %}} 
## **Bild in der Präsentationsbildsammlung ersetzen**
Aspose.Slides für Python über .NET bietet einfache API-Methoden zum Ersetzen der Bilder in der Präsentationsbildsammlung. Bitte folgen Sie den folgenden Schritten:

1. Laden Sie die Präsentationsdatei mit dem Bild, das sie enthält, unter Verwendung der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Laden Sie ein Bild aus einer Datei in ein Byte-Array.
1. Ersetzen Sie das Zielbild durch das neue Bild im Byte-Array.
1. Laden Sie im zweiten Ansatz das Bild in ein Image-Objekt und ersetzen Sie das Zielbild durch das geladene Bild.
1. Ersetzen Sie im dritten Ansatz das Bild durch ein bereits hinzugefügtes Bild in der Präsentationsbildsammlung.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#Instanz der Präsentation erstellen
with slides.Presentation("pres.pptx") as presentation:

    #der erste Weg
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #der zweite Weg
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #der dritte Weg
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #Die Präsentation speichern
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```