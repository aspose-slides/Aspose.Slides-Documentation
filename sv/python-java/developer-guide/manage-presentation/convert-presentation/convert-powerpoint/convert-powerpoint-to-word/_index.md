---
title: Konvertera PowerPoint-presentationer till Word-dokument i Python via Java
linktitle: PowerPoint till Word
type: docs
weight: 110
url: /sv/python-java/convert-powerpoint-to-word/
keywords:
- konvertera PowerPoint
- konvertera presentation
- PowerPoint till Word
- presentation till Word
- PPT till Word
- PPTX till Word
- ODP till Word
- PowerPoint till DOCX
- PPT till DOCX
- PPTX till DOCX
- PowerPoint till DOC
- spara PPT som DOCX
- spara PPTX som DOCX
- exportera PPT till DOCX
- exportera PPTX till DOCX
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till Word i Python via Java med Aspose.Slides och Aspose.Words, genom att kombinera bildspelbilder med redigerbar text."
---
## **Översikt**

Denna artikel förklarar hur man konverterar PowerPoint- och OpenDocument-presentationer till Word-dokument med Aspose.Slides för Python via Java tillsammans med Aspose.Words för Java. Aspose.Slides renderar varje bild och läser dess text, medan Aspose.Words skapar Word-dokumentet via JPype. Microsoft Office krävs inte.

Det resulterande dokumentet innehåller en bild av bilden följt av redigerbar text som extraheras från bildens autoformer på toppnivå. Bilden bevarar bildens visuella utseende; enskilda former, diagram och tabeller konverteras inte till redigerbara Word-objekt. Den extraherade texten behåller inte den ursprungliga textformateringen eller positioneringen.

## **Konvertera PowerPoint till Word**

1. Installera [Aspose.Slides for Python via Java](/slides/sv/python-java/installation/) och en kompatibel Java-runtime.
2. Ladda ner [Aspose.Words for Java](https://releases.aspose.com/words/java/). Placera dess huvud‑JAR‑fil i en `lib`‑katalog bredvid ditt skript och döp om den till `aspose-words.jar`, eller justera sökvägen i exemplet så att den matchar den nedladdade filen.
3. Placera inmatningspresentationen, `sample.pptx`, i arbetskatalogen. Sökvägen `lib/aspose-words.jar` är också relativ till den katalogen.
4. Kör följande Python‑kod för att skapa `output.docx`.

Exemplet läser in källan med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och renderar bilder med [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage). Det använder [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) från Aspose.Words för att infoga bilderna och texten i Word‑dokumentet.

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

        # Anpassa bildspelsbilden till textområdets bredd, och bevara dess bildförhållande.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Lägg till vanlig text från autoformer på toppnivå, inklusive textrutor.
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

Varje bild startar på en ny sida. Lång extraherad text eller ovanligt höga bildbilder kan kräva extra sidor. Koden lägger endast till sidbrytningar mellan bilder och frigör presentationen och de renderade bilderna i `finally`‑block. JVM förblir tillgänglig för efterföljande konverteringar i samma Python‑process.

## **Vanliga frågor**

**Vilka bibliotek krävs?**

Använd Aspose.Slides för Python via Java, JPype, en kompatibel Java-runtime och Aspose.Words för Java. Båda Aspose‑biblioteken körs i samma JVM. Aspose.Slides hanterar presentationen; Aspose.Words skriver Word‑dokumentet.

**Kan jag konvertera PPT‑ och ODP‑filer samt PPTX?**

Ja. Byt ut `sample.pptx` mot en PPT‑ eller ODP‑fil. Se [Stödda filformat](/slides/sv/python-java/supported-file-formats/) för presentationens inmatningsformat.

**Är allt bildinnehåll redigerbart i Word?**

Nej. Varje bild infogas som en statisk bild, med vanlig text från autoformer på toppnivå som läggs till under. Text i grupper, tabeller, SmartArt och diagram, samt skräddarsedlar, extraheras inte av detta exempel. Animationer och övergångar återges inte i Word‑dokumentet.

**Kan jag spara som DOC istället för DOCX?**

Ja. Ändra utdatafilens namn till `output.doc`. Aspose.Words väljer utdataformatet baserat på filnamnstillägget när detta spara‑overload används.