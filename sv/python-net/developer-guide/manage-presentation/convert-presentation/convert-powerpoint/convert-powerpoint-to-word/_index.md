---
title: Konvertera PowerPoint-presentationer till Word-dokument i Python
linktitle: PowerPoint till Word
type: docs
weight: 110
url: /sv/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint till DOCX
- OpenDocument till DOCX
- presentation till DOCX
- bild till DOCX
- PPT till DOCX
- PPTX till DOCX
- ODP till DOCX
- PowerPoint till DOC
- OpenDocument till DOC
- presentation till DOC
- bild till DOC
- PPT till DOC
- PPTX till DOC
- ODP till DOC
- PowerPoint till Word
- OpenDocument till Word
- presentation till Word
- bild till Word
- PPT till Word
- PPTX till Word
- ODP till Word
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- konvertera ODP
- Python
- Aspose.Slides
description: "Lär dig hur du enkelt konverterar PowerPoint- och OpenDocument-presentationer till Word-dokument med Aspose.Slides för Python via .NET. Vår steg-för-steg-guide med exempel på Python-kod ger en lösning för utvecklare som vill effektivisera sina dokumentarbetsflöden."
---
## **Översikt**

Den här artikeln ger en lösning för utvecklare att konvertera PowerPoint- och OpenDocument‑presentationer till Word‑dokument med hjälp av Aspose.Slides för Python via .NET och Aspose.Words för Python via .NET. Steg‑för‑steg‑guiden guidar dig genom varje steg i konverteringsprocessen.

## **Konvertera en presentation till ett Word‑dokument**

Följ instruktionerna nedan för att konvertera en PowerPoint‑ eller OpenDocument‑presentation till ett Word‑dokument:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in en presentationsfil.
2. Instansiera klasserna [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) och [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) för att skapa ett Word‑dokument.
3. Ställ in sidstorleken för Word‑dokumentet så att den matchar presentationen med egenskapen [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
4. Ange marginaler i Word‑dokumentet med egenskapen [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Gå igenom alla presentationsbilder med egenskapen [Presentation.slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/).
    - Generera en bild av bilden med metoden `get_image` från klassen [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/) och spara den i ett minnesström.
    - Lägg till bildfilen i Word‑dokumentet med metoden `insert_image` från klassen [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).
6. Spara Word‑dokumentet till en fil.

Anta att vi har en presentation ”sample.pptx” som ser ut så här:

![PowerPoint-presentation](PowerPoint.png)

Följande Python‑kodexempel visar hur du konverterar PowerPoint‑presentationen till ett Word‑dokument:

```py
import aspose.slides as slides
import aspose.words as words

# Läs in en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:

    # Skapa Document- och DocumentBuilder-objekt.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Ställ in sidstorleken i Word-dokumentet.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Ställ in marginaler i Word-dokumentet.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Gå igenom alla presentationsbilder.
    for slide in presentation.slides:

        # Skapa en bild av bilden och spara den i ett minnesflöde.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Lägg till bildfilen i Word-dokumentet.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Spara Word-dokumentet till en fil.
    document.save("output.docx")
```

Resultatet:

![Word-dokument](Word.png)

{{% alert color="primary" %}} 
Prova vår [**Online PPT till Word‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-word) för att se vad du kan få ut av att konvertera PowerPoint- och OpenDocument‑presentationer till Word‑dokument. 
{{% /alert %}}

## **FAQ**

**Vilka komponenter behöver installeras för att konvertera PowerPoint- och OpenDocument‑presentationer till Word‑dokument?**

Du behöver bara lägga till de respektive paketen för [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) och [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) i ditt Python‑projekt. Båda paketen fungerar som fristående API:er och det krävs ingen installation av Microsoft Office.

**Stöds alla PowerPoint- och OpenDocument‑presentationsformat?**

Aspose.Slides for Python .NET [stöder alla presentationsformat](/slides/sv/python-net/supported-file-formats/), inklusive PPT, PPTX, ODP och andra vanliga filtyper. Detta säkerställer att du kan arbeta med presentationer som skapats i olika versioner av Microsoft PowerPoint.