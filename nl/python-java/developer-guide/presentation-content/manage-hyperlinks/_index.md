---
title: Hyperlinks in presentaties beheren in Python via Java
linktitle: Hyperlink beheren
type: docs
weight: 20
url: /nl/python-java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- teksthyperlink
- diahyperlink
- vormhyperlink
- afbeeldinghyperlink
- videohyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer hyperlinks moeiteloos in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java—verhoog de interactiviteit en workflow in enkele minuten."
---
## **Introductie**

Een hyperlink is een verwijzing naar een object, gegevens of een locatie. Veelvoorkomende hyperlinks in PowerPoint‑presentaties omvatten:

* Links naar websites in tekst, vormen of media
* Links naar dia's

Aspose.Slides for Python via Java stelt je in staat om vele taken met betrekking tot hyperlinks in presentaties uit te voeren. 

{{% alert color="info" title="Note" %}} 
Je wilt misschien Aspose's eenvoudige, [gratis online PowerPoint‑editor.](https://products.aspose.app/slides/nl/editor)
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

### **URL‑hyperlinks toevoegen aan tekst**

Deze Python‑code laat zien hoe je een website‑hyperlink aan tekst kunt toevoegen:
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

### **URL‑hyperlinks toevoegen aan vormen of frames**

Deze voorbeeldcode in Python via Java laat zien hoe je een website‑hyperlink aan een vorm kunt toevoegen:
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

### **URL‑hyperlinks toevoegen aan media**

Aspose.Slides stelt je in staat hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden. 

Deze voorbeeldcode laat zien hoe je een hyperlink aan een **afbeelding** toevoegt:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Voegt afbeelding toe aan de presentatie
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Maakt een afbeeldingframe op dia 1 gebaseerd op eerder toegevoegde afbeelding
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Deze voorbeeldcode laat zien hoe je een hyperlink aan een **audiobestand** toevoegt:
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

Deze voorbeeldcode laat zien hoe je een hyperlink aan een **video** toevoegt:
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

{{% alert color="success" title="Tip" %}} 
Je wilt misschien *[OLE beheren](/slides/nl/python-java/manage-ole/)* zien.
{{% /alert %}}

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Aangezien hyperlinks je in staat stellen verwijzingen naar objecten of plaatsen toe te voegen, kun je ze gebruiken om een inhoudsopgave te maken. 

Deze voorbeeldcode laat zien hoe je een inhoudsopgave met hyperlinks maakt:
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

## **Hyperlinks opmaken**

### **Kleur**

Met de eigenschap [Hyperlink.setColorSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setColorSource) in de klasse [Hyperlink](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/) kun je de kleur voor hyperlinks instellen en ook de kleurinformatie van hyperlinks ophalen. De functionaliteit werd voor het eerst geïntroduceerd in PowerPoint 2019, dus wijzigingen met betrekking tot deze eigenschap zijn niet van toepassing op oudere PowerPoint‑versies.

Deze voorbeeldcode demonstreert een bewerking waarbij hyperlinks met verschillende kleuren aan dezelfde dia worden toegevoegd:
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

## **Hyperlinks uit presentaties verwijderen**

### **Hyperlinks uit tekst verwijderen**

Deze Python‑code laat zien hoe je de hyperlink uit tekst op een presentatiedia verwijdert:
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

### **Hyperlinks uit vormen of frames verwijderen**

Deze Python‑code laat zien hoe je de hyperlink uit een vorm op een presentatiedia verwijdert:
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

## **Aanpasbare hyperlink**

De klasse [Hyperlink](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/) is aanpasbaar. Met deze klasse kun je de waarden van de volgende eigenschappen wijzigen:

- [setTargetFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Het codefragment laat zien hoe je een hyperlink aan een dia toevoegt en later de tooltip bewerkt:
```python
import jpage
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

    # Wijzigt de tooltip van de hyperlink die al is toegevoegd
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ondersteunde eigenschappen in HyperlinkQueries**

Je kunt [HyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/) benaderen vanuit een presentatie, dia of tekst waarvoor de hyperlink is gedefinieerd. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getHyperlinkQueries)

De klasse [HyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/) ondersteunt deze methoden en eigenschappen: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Hoe kan ik interne navigatie creëren, niet alleen naar een dia, maar naar een "sectie" of de eerste dia van een sectie?**

Secties in PowerPoint zijn groeperingen van dia's; navigatie richt zich technisch gezien op een specifieke dia. Om "naar een sectie te navigeren" link je meestal naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de master‑dia koppelen zodat deze op alle dia's werkt?**

Ja. Elementen van de master‑dia en lay‑out ondersteunen hyperlinks. Dergelijke links verschijnen op onderliggende dia's en zijn klikbaar tijdens de diavoorstelling.

**Worden hyperlinks behouden bij het exporteren naar PDF, HTML, afbeeldingen of video?**

In [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/python-java/convert-powerpoint-to-html/) ja—links worden doorgaans behouden. Bij export naar [afbeeldingen](/slides/nl/python-java/convert-powerpoint-to-png/) en [video](/slides/nl/python-java/convert-powerpoint-to-video/) is klikbaarheid niet meer aanwezig vanwege de aard van die formaten (raster‑frames/video ondersteunen geen hyperlinks).