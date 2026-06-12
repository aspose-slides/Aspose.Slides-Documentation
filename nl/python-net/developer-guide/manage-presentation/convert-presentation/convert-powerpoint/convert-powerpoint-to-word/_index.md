---
title: PowerPoint‑presentaties naar Word‑documenten converteren in Python
linktitle: PowerPoint naar Word
type: docs
weight: 110
url: /nl/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint naar DOCX
- OpenDocument naar DOCX
- presentatie naar DOCX
- dia naar DOCX
- PPT naar DOCX
- PPTX naar DOCX
- ODP naar DOCX
- PowerPoint naar DOC
- OpenDocument naar DOC
- presentatie naar DOC
- dia naar DOC
- PPT naar DOC
- PPTX naar DOC
- ODP naar DOC
- PowerPoint naar Word
- OpenDocument naar Word
- presentatie naar Word
- dia naar Word
- PPT naar Word
- PPTX naar Word
- ODP naar Word
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- ODP converteren
- Python
- Aspose.Slides
description: "Leer hoe u moeiteloos PowerPoint‑ en OpenDocument‑presentaties naar Word‑documenten kunt converteren met Aspose.Slides voor Python via .NET. Onze stapsgewijze handleiding met voorbeeld‑Python‑code biedt de oplossing voor ontwikkelaars die hun document‑werkstromen willen stroomlijnen."
---
## **Overzicht**

Dit artikel biedt een oplossing voor ontwikkelaars om PowerPoint‑ en OpenDocument‑presentaties naar Word‑documenten te converteren met Aspose.Slides for Python via .NET en Aspose.Words for Python via .NET. De stapsgewijze handleiding leidt je door elke fase van het conversie‑proces.

## **Een presentatie converteren naar een Word‑document**

Volg de onderstaande instructies om een PowerPoint‑ of OpenDocument‑presentatie naar een Word‑document te converteren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad een presentiebestand.  
2. Maak een instantie van de [Document](https://reference.aspose.com/words/python-net/aspose.words/document/)‑ en [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/)‑klassen om een Word‑document te genereren.  
3. Stel de paginagrootte van het Word‑document in zodat deze overeenkomt met die van de presentatie via de eigenschap [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
4. Stel de marges in het Word‑document in via de eigenschap [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
5. Doorloop alle presentatieslides via de eigenschap [Presentation.slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/).  
   - Genereer een slide‑afbeelding met de `get_image`‑methode van de [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/)‑klasse en sla deze op in een geheugen‑stream.  
   - Voeg de slide‑afbeelding toe aan het Word‑document met de `insert_image`‑methode van de [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/)‑klasse.  
6. Sla het Word‑document op in een bestand.

Stel dat we een presentatie "sample.pptx" hebben die er als volgt uitziet:

![PowerPoint‑presentatie](PowerPoint.png)

```py
import aspose.slides as slides
import aspose.words as words

# Laad een presentatie‑bestand.
with slides.Presentation("sample.pptx") as presentation:

    # Maak Document‑ en DocumentBuilder‑objecten aan.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Stel de paginagrootte in het Word‑document in.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Stel de marges in het Word‑document in.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Doorloop alle presentatieslides.
    for slide in presentation.slides:

        # Genereer een slide‑afbeelding en sla deze op in een geheugen‑stream.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Voeg de slide‑afbeelding toe aan het Word‑document.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Sla het Word‑document op in een bestand.
    document.save("output.docx")
```

Het resultaat:

![Word‑document](Word.png)

{{% alert color="primary" %}} 
Probeer onze [**Online PPT‑naar‑Word‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-word) om te zien wat je kunt behalen door PowerPoint‑ en OpenDocument‑presentaties naar Word‑documenten te converteren. 
{{% /alert %}}

## **Veelgestelde vragen**

**Welke componenten moeten geïnstalleerd worden om PowerPoint‑ en OpenDocument‑presentaties naar Word‑documenten te converteren?**

Je hoeft alleen de respectieve pakketten voor [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) en [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) toe te voegen aan je Python‑project. Beide pakketten werken als zelfstandige API’s en er is geen Microsoft Office‑installatie nodig.

**Worden alle PowerPoint‑ en OpenDocument‑presentatieformaten ondersteund?**

Aspose.Slides for Python .NET [ondersteunt alle presentatieformaten](/slides/nl/python-net/supported-file-formats/), waaronder PPT, PPTX, ODP en andere gangbare bestandstypen. Dit zorgt ervoor dat je kunt werken met presentaties die zijn gemaakt in verschillende versies van Microsoft PowerPoint.