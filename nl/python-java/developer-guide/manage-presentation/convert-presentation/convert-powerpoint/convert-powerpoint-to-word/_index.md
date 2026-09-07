---
title: PowerPoint-presentaties omzetten naar Word-documenten in Python via Java
linktitle: PowerPoint naar Word
type: docs
weight: 110
url: /nl/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint converteren
- presentatie converteren
- PowerPoint naar Word
- presentatie naar Word
- PPT naar Word
- PPTX naar Word
- ODP naar Word
- PowerPoint naar DOCX
- PPT naar DOCX
- PPTX naar DOCX
- PowerPoint naar DOC
- PPT opslaan als DOCX
- PPTX opslaan als DOCX
- PPT exporteren naar DOCX
- PPTX exporteren naar DOCX
- Python
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties omzetten naar Word in Python via Java met Aspose.Slides en Aspose.Words, waarbij dia-afbeeldingen worden gecombineerd met bewerkbare tekst."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑ en OpenDocument‑presentaties kunt converteren naar Word‑documenten met Aspose.Slides voor Python via Java in combinatie met Aspose.Words voor Java. Aspose.Slides rendert elke dia en leest de tekst, terwijl Aspose.Words het Word‑document maakt via JPype. Microsoft Office is niet vereist.

Het resulterende document bevat een dia‑afbeelding, gevolgd door bewerkbare tekst die is geëxtraheerd uit de boven‑niveau auto‑vormen van die dia. De afbeelding behoudt het visuele uiterlijk van de dia; afzonderlijke vormen, grafieken en tabellen worden niet omgezet naar bewerkbare Word‑objecten. De geëxtraheerde tekst behoudt niet de oorspronkelijke opmaak of positionering.

## **PowerPoint naar Word converteren**

1. Installeer [Aspose.Slides for Python via Java](/slides/nl/python-java/installation/) en een compatibele Java‑runtime.  
2. Download [Aspose.Words for Java](https://releases.aspose.com/words/java/). Plaats het hoofd‑JAR‑bestand in een `lib`‑map naast uw script en hernoem het naar `aspose-words.jar`, of pas het pad in het voorbeeld aan zodat het overeenkomt met het gedownloade bestand.  
3. Plaats de invoer‑presentatie, `sample.pptx`, in de werkmap. Het pad `lib/aspose-words.jar` is eveneens relatief ten opzichte van die map.  
4. Voer de volgende Python‑code uit om `output.docx` te maken.

Het voorbeeld laadt de bron met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en rendert dia's met [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage). Het gebruikt [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) van Aspose.Words om de afbeeldingen en tekst in het Word‑document in te voegen.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Pas de dia-afbeelding aan op de breedte van het tekstgebied, behoudende de beeldverhouding.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Voeg platte tekst toe van de auto-vormen op het hoogste niveau, inclusief tekstvakken.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Elke dia begint op een nieuwe pagina. Lange geëxtraheerde tekst of uitzonderlijk hoge dia‑afbeeldingen kunnen extra pagina's vereisen. De code voegt alleen pagina‑eindes toe tussen dia's en geeft de presentatie en gerenderde afbeeldingen vrij in `finally`‑blokken. De JVM blijft beschikbaar voor volgende conversies in hetzelfde Python‑proces.

## **FAQ**

**Welke bibliotheken zijn vereist?**

Gebruik Aspose.Slides for Python via Java, JPype, een compatibele Java‑runtime en Aspose.Words for Java. Beide Aspose‑bibliotheken draaien in dezelfde JVM. Aspose.Slides verwerkt de presentatie; Aspose.Words schrijft het Word‑document.

**Kan ik PPT‑ en ODP‑bestanden evenals PPTX converteren?**

Ja. Vervang `sample.pptx` door een PPT‑ of ODP‑bestand. Zie [Supported File Formats](/slides/nl/python-java/supported-file-formats/) voor de ondersteunde invoerformaten voor presentaties.

**Is alle dia‑inhoud bewerkbaar in Word?**

Nee. Elke dia wordt ingevoegd als een statische afbeelding, met platte tekst uit de boven‑niveau auto‑vormen eronder toegevoegd. Tekst in groepen, tabellen, SmartArt en grafieken, evenals aantekeningen voor de spreker, wordt niet geëxtraheerd door dit voorbeeld. Animaties en overgangen worden niet gereproduceerd in het Word‑document.

**Kan ik opslaan als DOC in plaats van DOCX?**

Ja. Verander de uitvoernaam naar `output.doc`. Aspose.Words bepaalt het uitvoerformaat op basis van de bestandsextensie bij het gebruik van deze opslaafunctie.