---
title: Hantera upphöjd och nedsänkt text i presentationer med Python via Java
linktitle: Upphöjd och nedsänkt
type: docs
weight: 80
url: /sv/python-java/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för Python via Java och lyft dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides tillhandahåller funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑ (PPT, PPTX) och OpenDocument‑ (ODP) presentationer. Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller kommentera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att bevara tydlighet och precision. I den här artikeln lär du dig hur du sömlöst tillämpar upphöjd‑ och nedsänkt‑stilar och säkerställer professionella resultat i varje bild.

## **Hantera upphöjd och nedsänkt text**

Du kan lägga till upphöjd och nedsänkt text i vilken del av ett stycke som helst. För att tillämpa denna formatering i en Aspose.Slides‑textram använder du metoden [setEscapement](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#setEscapement) i klassen [PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/).

Escapement‑värdet sträcker sig från -100 % (nedsänkt) till 100 % (upphöjd). Till exempel:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en bild via dess index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) av typen [ShapeType.Rectangle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#Rectangle) på bilden.
- Åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
- Rensa befintliga stycken.
- Skapa ett stycke för att innehålla upphöjd text och lägg till det i bildens [paragraph collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParagraphs).
- Skapa en portion.
- Använd [setEscapement](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#setEscapement) för att ange ett värde mellan 0 och 100 för upphöjd (0 betyder ingen upphöjd).
- Ange texten för [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) och lägg till den i styckets portionssamling.
- Skapa ett stycke för att innehålla nedsänkt text och lägg till det i bildens [paragraph collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParagraphs).
- Skapa en portion.
- Använd [setEscapement](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#setEscapement) för att ange ett värde mellan -100 och 0 för nedsänkt (0 betyder ingen nedsänkt).
- Ange texten för [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) och lägg till den i styckets portionssamling.
- Spara presentationen som en PPTX‑fil.

Följande exempel implementerar dessa steg:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Skapa en presentation.
presentation = Presentation()
try:
    # Hämta bilden.
    slide = presentation.getSlides().get_Item(0)

    # Skapa en textruta.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Skapa ett stycke för upphöjd text.
    superscript_paragraph = Paragraph()

    # Skapa en del med normal text.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Skapa en del med upphöjd text.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Skapa ett stycke för nedsänkt text.
    subscript_paragraph = Paragraph()

    # Skapa en del med normal text.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Skapa en del med nedsänkt text.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Lägg till styckena i textrutan.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kommer upphöjd och nedsänkt att bevaras vid export till PDF eller andra format?**

Ja, Aspose.Slides behåller korrekt upphöjd och nedsänkt formatering vid export av presentationer till PDF, PPT/PPTX, bilder och andra stödda format. Den specialiserade formateringen förblir intakt i alla utdatafiler.

**Kan upphöjd och nedsänkt kombineras med andra formateringsstilar som fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom en enda textportion. Du kan aktivera fetstil, kursiv, understrykning och samtidigt tillämpa upphöjd eller nedsänkt genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides stödjer formatering i de flesta objekt, inklusive tabeller och diagramdelar. När du arbetar med SmartArt måste du komma åt de lämpliga elementen (t.ex. [SmartArtNode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/)) och deras textbehållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/)‑egenskaperna på liknande sätt.