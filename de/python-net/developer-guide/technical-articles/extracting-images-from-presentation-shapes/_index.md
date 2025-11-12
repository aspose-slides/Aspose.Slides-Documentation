---
title: Bilder aus Präsentationsformen in Python extrahieren
linktitle: Bild aus Form
type: docs
weight: 90
url: /de/python-net/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- Folienhintergrund
- Formhintergrund
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET extrahieren — schnelle, codefreundliche Lösung."
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und oft auch als Folienhintergründe verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), eine Sammlung von [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)‑Objekten, hinzugefügt. 

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst finden, indem Sie jede Folie und anschließend jede Form durchsuchen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #Zugriff auf die Präsentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Zugriff auf die erste Folie
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Abrufen des Hintergrundbildes  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Abrufen des Hintergrundbildes  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Festlegen des gewünschten Bildformats 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```

## **FAQ**

**Kann ich das Originalbild ohne Zuschnitt, Effekte oder Formtransformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/), d.h. die ursprünglichen Pixel ohne Zuschnitt oder Styling‑Effekte. Der Ablauf geht die Bildsammlung der Präsentation und die [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekte durch, die die Rohdaten speichern.

**Besteht das Risiko, beim Speichern vieler Bilder auf einmal identische Dateien zu duplizieren?**

Ja, wenn Sie alles ungefiltert speichern. Die [image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) einer Präsentation kann identische Binärdaten enthalten, die von verschiedenen Formen oder Folien referenziert werden. Um Duplikate zu vermeiden, vergleichen Sie vor dem Schreiben Hashes, Größen oder Inhalte der extrahierten Daten.

**Wie kann ich feststellen, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Traversierung manuell eine Zuordnung: Jedes Mal, wenn Sie eine Referenz zu einem [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) finden, notieren Sie, welche Formen es verwenden.

**Kann ich in OLE-Objekten eingebettete Bilder, z. B. angehängte Dokumente, extrahieren?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen zunächst das OLE‑Paket selbst extrahieren und dann dessen Inhalt mit separaten Werkzeugen analysieren. Präsentationsbildformen arbeiten über [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.