---
title: Konvertera PPT och PPTX till JPG i Python
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/python-java/convert-powerpoint-to-jpg/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- PowerPoint till JPG
- PPT till JPG
- PPTX till JPG
- spara bild som JPG
- exportera PPT till JPG
- exportera PPTX till JPG
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX) bilder till JPG-bilder i Python via Java. Ange anpassade bilddimensioner och rendera anteckningar samt kommentarer med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides för Python via Java låter dig konvertera PowerPoint‑ och OpenDocument‑presentationer (PPT, PPTX och ODP) till JPEG‑bilder. Du kan exportera varje bild eller en markerad bild för att skapa miniatyrer, bygga en presentationsvisare eller bädda in förhandsgranskningar av bilder i en webbplats eller applikation.

## **Konvertera PowerPoint PPT/PPTX till JPG**

1. Läs in presentationen med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta bilderna med [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides).
3. Anropa [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) med horisontella och vertikala skalningsfaktorer för att rendera varje bild.
4. Spara varje renderad bild som JPEG med [ImageFormat.Jpeg](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/#Jpeg) och frigör sedan bildresurserna.

{{% alert color="info" title="Obs" %}}
Exportering till JPG skapar en separat bild för varje bild. Spara den renderade bilden i stället för att spara presentationen direkt i ett bildformat.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Konvertera PowerPoint PPT/PPTX till JPG med anpassade dimensioner**

Beräkna horisontella och vertikala skalningsfaktorer från de önskade pixelmåtten och den ursprungliga bildstorleken, och skicka sedan dem till [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage). Följande exempel riktar in sig på en 1200 × 800‑pixel bild för varje bild.

Att använda olika skalningsfaktorer kan sträcka bilden. För att bevara bildförhållandet, använd samma skalningsfaktor för båda axlarna; den resulterande bredden och höjden följer då bildens ursprungliga proportioner.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Rendera kommentarer när du sparar bilder som bilder**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/) för att konfigurera anteckningar och kommentarer, och tillämpa layouten via [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Detta exempel placerar anteckningar längst ner, trunkerar anteckningar som inte får plats, och visar kommentarer till höger i ett 200‑pixel‑brett område. Det sparar varje renderad bild som en JPG‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag konvertera flera bilder eller presentationer till JPG?**

Ja. Exemplen loopar igenom alla bilder och sparar en JPG per bild. För att bearbeta flera presentationer, upprepa konverteringen för varje indatafil och använd separata utdata‑mappar eller unika filnamn för att undvika att bilder skrivs över.

**Inkluderas diagram, SmartArt, tabeller och former i bilderna?**

Dessa objekt renderas som en del av bilden. Se till att de teckensnitt som används av presentationen finns tillgängliga i konverteringsmiljön för att minska skillnader som orsakas av teckensnittssubstitution.

**Hur kan jag minska minnesanvändningen vid export av stora presentationer?**

Processa bilder en åt gången, frigör varje bild efter att den sparats och undvik onödigt stora utskriftsdimensioner. Minneskraven beror på bildens innehåll och bildstorlek.

## **Se också**

- [Konvertera PowerPoint till PNG](/slides/sv/python-java/convert-powerpoint-to-png/).
- [Rendera en bild som en SVG‑bild](/slides/sv/python-java/render-a-slide-as-an-svg-image/).