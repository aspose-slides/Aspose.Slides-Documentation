---
title: PPT, PPTX und ODP in JPG konvertieren in Python
linktitle: Folien zu JPG
type: docs
weight: 60
url: /de/python-net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint in JPG konvertieren
- Präsentation in JPG konvertieren
- Folie in JPG konvertieren
- PPT in JPG konvertieren
- PPTX in JPG konvertieren
- ODP in JPG konvertieren
- PowerPoint zu JPG
- Präsentation zu JPG
- Folie zu JPG
- PPT zu JPG
- PPTX zu JPG
- ODP zu JPG
- PowerPoint in JPEG konvertieren
- Präsentation in JPEG konvertieren
- Folie in JPEG konvertieren
- PPT in JPEG konvertieren
- PPTX in JPEG konvertieren
- ODP in JPEG konvertieren
- PowerPoint zu JPEG
- Präsentation zu JPEG
- Folie zu JPEG
- PPT zu JPEG
- PPTX zu JPEG
- ODP zu JPEG
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ihre Folien aus PowerPoint- und OpenDocument-Präsentationen mit nur wenigen Zeilen Python-Code in hochwertige JPEG-Bilder umwandeln. Optimieren Sie Präsentationen für die Webnutzung, das Teilen und die Archivierung. Lesen Sie jetzt die vollständige Anleitung!"
---

## **Über die Konvertierung von PowerPoint in JPG**
Mit [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) können Sie PowerPoint PPT- oder PPTX-Präsentationen in JPG-Bilder in Python konvertieren. Es ist auch möglich, PPT/PPTX in BMP, PNG oder SVG in Python zu konvertieren. Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentationsbetrachter zu implementieren und das Thumbnail für jede Folie zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor Urheberrechtsverletzungen schützen oder die Präsentation im Nur-Lese-Modus darstellen möchten. Aspose.Slides ermöglicht es, die gesamte Präsentation oder eine bestimmte Folie in Bildformate zu konvertieren.

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder konvertiert, möchten Sie vielleicht diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT in JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG konvertieren**
Hier sind die Schritte, um PPT/PPTX in JPG zu konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich das Folienobjekt vom [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Typ aus der [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Sammlung.
3. Erstellen Sie das Thumbnail jeder Folie und konvertieren Sie es dann in JPG. Die [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode wird verwendet, um ein Thumbnail einer Folie zu erhalten; sie gibt ein [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) Objekt als Ergebnis zurück. Die [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode muss von der benötigten Folie des [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Typs aufgerufen werden; die Skalen des resultierenden Thumbnails werden in die Methode übergeben.
4. Nachdem Sie das Folien-Thumbnail erhalten haben, rufen Sie die [**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) Methode vom Thumbnail-Objekt auf. Übergeben Sie den resultierenden Dateinamen und das Bildformat an die Methode. 

{{% alert color="primary" %}} 
**Hinweis**: Die Konvertierung von PPT/PPTX in JPG unterscheidet sich von der Konvertierung in andere Typen in der Aspose.Slides .NET API. Für andere Typen verwenden Sie normalerweise die [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) Methode, aber hier benötigen Sie die [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) Methode.
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Folien_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen konvertieren**
Um die Abmessungen des resultierenden Thumbnails und des JPG-Bildes zu ändern, können Sie die *ScaleX*- und *ScaleY*-Werte festlegen, indem Sie sie in die [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode übergeben:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

gewünschteX = 1200
gewünschteY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * gewünschteX
scaleY = (float)(1.0 / pres.slide_size.size.height) * gewünschteY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Folien_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Online-Service können Sie [JPG in JPG](https://products.aspose.app/slides/collage/jpg) oder PNG in PNG Bilder zusammenfügen, [Foto-Raster](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

Mit denselben Prinzipien, die in diesem Artikel beschrieben sind, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: konvertieren [Bild in JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); konvertieren [JPG in Bild](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); konvertieren [JPG in PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), konvertieren [PNG in JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); konvertieren [PNG in SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), konvertieren [SVG in PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Siehe weitere Optionen zur Konvertierung von PPT/PPTX in Bilder wie:

- [PPT/PPTX zu SVG-Konvertierung](/slides/de/python-net/render-a-slide-as-an-svg-image/).