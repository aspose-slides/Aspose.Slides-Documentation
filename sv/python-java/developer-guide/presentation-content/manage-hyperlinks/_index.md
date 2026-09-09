---
title: Hantera presentationshyperlänkar i Python via Java
linktitle: Hantera hyperlänk
type: docs
weight: 20
url: /sv/python-java/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildfilhyperlänk
- videohyperlänk
- muterbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera enkelt hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java—förbättra interaktivitet och arbetsflöde på några minuter."
---
## **Introduktion**

En hyperlänk är en referens till ett objekt, data eller en plats. Vanliga hyperlänkar i PowerPoint‑presentationer inkluderar:

* Länkar till webbplatser i text, former eller media
* Länkar till bilder

Aspose.Slides för Python via Java låter dig utföra många uppgifter som involverar hyperlänkar i presentationer. 

{{% alert color="info" title="Obs" %}} 
Du kanske vill testa Asposes enkla, [gratis online PowerPoint‑redigerare.](https://products.aspose.app/slides/sv/editor)
{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

### **Lägg till URL‑hyperlänkar till text**

Denna Python‑kod visar hur du lägger till en webbplats‑hyperlänk till text:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lägg till URL‑hyperlänkar till former eller ramar**

Detta exempel i Python via Java visar hur du lägger till en webbplats‑hyperlänk till en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lägg till URL‑hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud‑ och videofiler. 

Detta exempel visar hur du lägger till en hyperlänk till en **bild**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Lägger till bild i presentationen
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Skapar bildram på bild 1 baserat på tidigare tillagd bild
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Detta exempel visar hur du lägger till en hyperlänk till en **ljudfil**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Detta exempel visar hur du lägger till en hyperlänk till en **video**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tips" %}} 
Du kanske vill se *[Hantera OLE](/slides/sv/python-java/manage-ole/)*.
{{% /alert %}}

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Eftersom hyperlänkar låter dig lägga till referenser till objekt eller platser kan du använda dem för att skapa en innehållsförteckning. 

Detta exempel visar hur du skapar en innehållsförteckning med hyperlänkar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatera hyperlänkar**

### **Färg**

Med egenskapen [Hyperlink.setColorSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/#setColorSource) i klassen [Hyperlink](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/) kan du ange färgen för hyperlänkar och även hämta färginformation från hyperlänkar. Funktionen introducerades först i PowerPoint 2019, så ändringar som rör egenskapen gäller inte äldre PowerPoint‑versioner.

Detta exempel demonstrerar en operation där hyperlänkar med olika färger läggs till på samma bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ta bort hyperlänkar från presentationer**

### **Ta bort hyperlänkar från text**

Denna Python‑kod visar hur du tar bort hyperlänken från text på en presentationsbild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ta bort hyperlänkar från former eller ramar**

Denna Python‑kod visar hur du tar bort hyperlänken från en form på en presentationsbild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Muterbar hyperlänk**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/) är muterbar. Med denna klass kan du ändra värdena för dessa egenskaper:

- [setTargetFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Kodsnutten visar hur du lägger till en hyperlänk till en bild och redigerar dess verktygstips senare:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Ändrar verktygstipset för hyperlänken som redan har lagts till
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stödda egenskaper i HyperlinkQueries**

Du kan komma åt [HyperlinkQueries](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkqueries/) från en presentation, bild eller text för vilken hyperlänken är definierad. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkqueries/) stöder dessa metoder och egenskaper: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinkss)

## **FAQ**

**Hur kan jag skapa intern navigering inte bara till en bild, utan till en "sektion" eller den första bilden i en sektion?**

Sektioner i PowerPoint är grupperingar av bilder; navigering riktar sig tekniskt sett till en specifik bild. För att "navigera till en sektion" länkar du vanligtvis till dess första bild.

**Kan jag bifoga en hyperlänk till master‑bildens element så att den fungerar på alla bilder?**

Ja. Master‑bildens och layout‑element stödjer hyperlänkar. Sådana länkar visas på underordnade bilder och är klickbara under bildspelet.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

I [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/python-java/convert-powerpoint-to-html/) ja – länkar bevaras i allmänhet. Vid export till [bilder](/slides/sv/python-java/convert-powerpoint-to-png/) och [video](/slides/sv/python-java/convert-powerpoint-to-video/) överförs inte klickbarheten på grund av formatens natur (raster‑ramar/video stöder inga hyperlänkar).