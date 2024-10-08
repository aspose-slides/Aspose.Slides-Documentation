---
title: PowerPoint in PNG konvertieren
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-png/
keywords: PowerPoint in PNG, PPT in PNG, PPTX in PNG, Python, Aspose.Slides für Python über .NET
description: PowerPoint-Präsentation in PNG konvertieren
---

## **Über die Konvertierung von PowerPoint in PNG**

Das PNG-Format (Portable Network Graphics) ist nicht so populär wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe keine Rolle spielt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tipp" color="primary" %}} Sie möchten möglicherweise die kostenlosen **PowerPoint in PNG Konverter** von Aspose ausprobieren: [PPTX in PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT in PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine live Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie diese Schritte durch:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie das Folienobjekt aus der [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Sammlung unter dem [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Interface.
3. Verwenden Sie die [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode, um das Thumbnail für jede Folie zu erhalten.
4. Verwenden Sie die [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) Methode, um das Folien-Thumbnail im PNG-Format zu speichern.

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PNG konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen.

Dieser Code in Python demonstriert die beschriebene Funktion:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG-Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width` und `height` Argumente für `ImageSize` übergeben.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in PNG konvertieren, während Sie die Größe der Bilder festlegen:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```