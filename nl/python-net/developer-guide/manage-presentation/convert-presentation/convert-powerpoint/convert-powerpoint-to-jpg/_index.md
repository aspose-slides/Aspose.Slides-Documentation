---
title: Converteer PPT, PPTX en ODP naar JPG in Python
linktitle: Dia's converteren naar JPG-afbeeldingen
type: docs
weight: 60
url: /nl/python-net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint converteren naar JPG
- presentatie converteren naar JPG
- dia converteren naar JPG
- PPT converteren naar JPG
- PPTX converteren naar JPG
- ODP converteren naar JPG
- PowerPoint naar JPG
- presentatie naar JPG
- dia naar JPG
- PPT naar JPG
- PPTX naar JPG
- ODP naar JPG
- PowerPoint converteren naar JPEG
- presentatie converteren naar JPEG
- dia converteren naar JPEG
- PPT converteren naar JPEG
- PPTX converteren naar JPEG
- ODP converteren naar JPEG
- PowerPoint naar JPEG
- presentatie naar JPEG
- dia naar JPEG
- PPT naar JPEG
- PPTX naar JPEG
- ODP naar JPEG
- Python
- Aspose.Slides
description: "Leer hoe u uw dia's van PowerPoint- en OpenDocument‑presentaties kunt omzetten naar JPEG‑afbeeldingen van hoge kwaliteit met slechts een paar regels code in Python. Optimaliseer presentaties voor gebruik op het web, delen en archiveren. Lees nu de volledige gids!"
---
## **Introductie**

Het converteren van PowerPoint- en OpenDocument‑presentaties naar JPG‑afbeeldingen helpt bij het delen van dia’s, het optimaliseren van de prestaties en het insluiten van inhoud in websites of applicaties. Aspose.Slides voor Python stelt je in staat om PPTX‑, PPT‑ en ODP‑bestanden te transformeren naar JPEG‑afbeeldingen van hoge kwaliteit. Deze gids legt verschillende methoden voor conversie uit.

Met deze functies is het eenvoudig om je eigen presentatieviewer te implementeren en een miniatuur voor elke dia te maken. Dit kan nuttig zijn als je de presentatiedia’s wilt beschermen tegen kopiëren of de presentatie in alleen‑lezen modus wilt tonen. Aspose.Slides stelt je in staat om de hele presentatie of een specifieke dia te converteren naar afbeeldingsformaten.

## **Presentatiedia’s converteren naar JPG‑afbeeldingen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
1. Haal het dia‑object van het type [Dia](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/) op uit de [Presentation.slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/) collectie.  
1. Maak een afbeelding van de dia met behulp van de [Dia.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#float-float) methode.  
1. Roep de [IImage.save(filename, format)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/save/#str-imageformat) methode aan op het afbeeldingsobject. Geef de uitvoerbestandsnaam en het afbeeldingsformaat als argumenten door.

{{% alert color="primary" %}}
**Opmerking:** PPT‑, PPTX‑ of ODP‑naar‑JPG‑conversie verschilt van de conversie naar andere formaten in de Aspose.Slides Python API. Voor andere formaten gebruik je doorgaans de [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) methode. Voor JPG‑conversie moet je echter de [IImage.save(filename, format)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/save/#str-imageformat) methode gebruiken.
{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Sla de afbeelding op schijf in JPEG‑formaat.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Dia’s converteren naar JPG met aangepaste afmetingen**

Om de afmetingen van de resulterende JPG‑afbeeldingen te wijzigen, kun je de afbeeldinggrootte instellen door deze mee te geven aan de [Slide.get_image(image_size)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) methode. Hiermee kun je afbeeldingen genereren met specifieke breedte‑ en hoogtewaarden, zodat de uitvoer voldoet aan je vereisten voor resolutie en beeldverhouding. Deze flexibiliteit is vooral nuttig bij het genereren van afbeeldingen voor webapplicaties, rapporten of documentatie, waar precieze afbeeldingsafmetingen vereist zijn.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Maak een dia-afbeelding van de opgegeven grootte.
        with slide.get_image(image_size) as thumbnail:
            # Sla de afbeelding op schijf in JPEG-formaat.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Opmerkingen weergeven bij het opslaan van dia’s als afbeeldingen**

Aspose.Slides voor Python biedt een functie waarmee je opmerkingen op de dia’s van een presentatie kunt weergeven bij het converteren naar JPG‑afbeeldingen. Deze functionaliteit is vooral nuttig om annotaties, feedback of discussies die door medewerkers aan PowerPoint‑presentaties zijn toegevoegd te behouden. Door deze optie in te schakelen, zorg je ervoor dat opmerkingen zichtbaar zijn in de gegenereerde afbeeldingen, waardoor het gemakkelijker wordt om feedback te bekijken en te delen zonder het oorspronkelijke presentatiebestand te openen.

Stel dat we een present‑bestand “sample.pptx” hebben met een dia die opmerkingen bevat:

![De dia met opmerkingen](slide_with_comments.png)

De volgende Python‑code converteert de dia naar een JPG‑afbeelding terwijl de opmerkingen behouden blijven:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Opties instellen voor de dia‑opmerkingen.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Converteer de eerste dia naar een afbeelding.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

Het resultaat:

![De JPG‑afbeelding met opmerkingen](image_with_comments.png)

## **Zie ook**

- [PowerPoint converteren naar GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/)
- [PowerPoint converteren naar PNG](/slides/nl/python-net/convert-powerpoint-to-png/)
- [PowerPoint converteren naar TIFF](/slides/nl/python-net/convert-powerpoint-to-tiff/)
- [PowerPoint converteren naar SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Om te zien hoe Aspose.Slides PowerPoint naar JPG‑afbeeldingen converteert, probeer deze gratis online converters: PowerPoint [PPTX naar JPG](https://products.aspose.app/slides/nl/conversion/pptx-to-jpg) en [PPT naar JPG](https://products.aspose.app/slides/nl/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Gratis online PPTX naar JPG‑converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG‑afbeeldingen samenvoegen, [fotogrijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 

Met dezelfde principes die in dit artikel worden beschreven, kun je afbeeldingen van het ene formaat naar het andere converteren. Zie voor meer informatie deze pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Veelgestelde vragen**

**Ondersteunt deze methode batchconversie?**

Ja, Aspose.Slides ondersteunt batchconversie van meerdere dia’s naar JPG in één bewerking.

**Ondersteunt de conversie SmartArt, diagrammen en andere complexe objecten?**

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, diagrammen, tabellen, vormen en meer. De weergave‑nauwkeurigheid kan echter iets verschillen ten opzichte van PowerPoint, vooral bij het gebruik van aangepaste of ontbrekende lettertypen.

**Zijn er beperkingen op het aantal dia’s dat verwerkt kan worden?**

Aspose.Slides zelf legt geen strikte limieten op het aantal dia’s dat je kunt verwerken. Je kunt echter een out‑of‑memory‑fout tegenkomen bij grote presentaties of afbeeldingen met hoge resolutie.