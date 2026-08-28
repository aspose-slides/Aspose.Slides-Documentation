---
title: "Dia's van presentaties naar afbeeldingen converteren in Python"
linktitle: "Dia naar afbeelding"
type: docs
weight: 41
url: /nl/python-net/convert-slide/
keywords:
- dia converteren
- dia exporteren
- dia naar afbeelding
- dia opslaan als afbeelding
- dia naar EMF
- dia naar PNG
- dia naar JPEG
- dia naar bitmap
- dia naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Converteren van dia's uit PPT-, PPTX- en ODP-presentaties naar PNG, JPEG, GIF, TIFF, EMF en andere afbeeldingsformaten in Python met Aspose.Slides."
---
## **Inleiding**

Aspose.Slides for Python via .NET kan individuele dia's uit PowerPoint- en OpenDocument-presentaties weergeven als PNG, JPEG, GIF, TIFF en andere afbeeldingsformaten.

Om een dia om te zetten naar een afbeelding, volgt u de onderstaande stappen:

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Selecteer de dia die u wilt weergeven.
3. Indien nodig, configureer het renderen met de klasse [RenderingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/) .
4. Roep de methode [Slide.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/) aan. Deze retourneert een object van het type [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) .
5. Roep de methode [IImage.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/save/) aan en specificeer het uitvoerformaat met een waarde van [ImageFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imageformat/) .

## **Een dia omzetten naar een PNG-afbeelding**

De eenvoudigste conversie gebruikt de standaard renderinstellingen. Het resulterende [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) object kan in het geheugen worden verwerkt of naar een bestand worden opgeslagen.

Het volgende Python‑voorbeeld rendert de eerste dia en slaat deze op als een PNG‑afbeelding:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Dia's omzetten naar afbeeldingen met aangepaste afmetingen**

Gebruik de overload van [Slide.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) die een [Size](https://reference.aspose.com/slides/nl/python-net/aspose.pydrawing/size/)‑waarde accepteert om een dia met exacte pixelafmetingen weer te geven.

Het volgende voorbeeld maakt een JPEG‑afbeelding van 1820 × 1040 pixels:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Dia's met notities en opmerkingen omzetten naar afbeeldingen**

Standaard bevatten dia‑afbeeldingen geen notities of opmerkingen. Wijs een object van het type [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/) toe aan de eigenschap [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) om te bepalen waar notities en opmerkingen worden weergegeven.

Het volgende voorbeeld plaatst ingekorte notities onder de dia en opmerkingen rechts ervan:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Voor het converteren van dia’s naar afbeeldingen, stel de eigenschap [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) niet in op [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notespositions/). Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte kan bevatten. Gebruik in plaats daarvan [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notespositions/) .
{{% /alert %}}

## **Dia's omzetten naar afbeeldingen met TIFF‑opties**

De klasse [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/) stelt u in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF‑afbeelding te beheersen.

Het volgende voorbeeld rendert de eerste dia als een TIFF‑afbeelding van 2160 × 2880 pixels met 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Alle dia's omzetten naar afbeeldingen**

Itereer over de dia‑collectie om de volledige presentatie om te zetten in een reeks afbeeldingen. Verborgen dia's worden meegenomen, tenzij u ze expliciet overslaat.

Het volgende voorbeeld rendert elke dia als een JPEG‑afbeelding met horizontale en verticale schaalfactoren van 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Enhanced Metafile‑uitvoer maken**

Enhanced Metafile (EMF) is nuttig wanneer vector‑gebaseerde afbeeldingen moeten worden uitgewisseld met Microsoft Office of andere Windows‑toepassingen die Windows‑metabestanden ondersteunen. In tegenstelling tot een pixel‑gebaseerde afbeelding kan een EMF vector‑tekenbewerkingen behouden die schalen zonder dezelfde verlies van scherpte. Echter, EMF is voornamelijk een compatibiliteitsformaat voor toepassingen met Windows‑metabestandondersteuning, geen universeel uitwisselingsformaat. Bovendien kan complexe dia‑inhoud, zoals bitmap‑afbeeldingen en sommige effecten, als gerasterde elementen worden opgeslagen binnen de vector‑metabestand‑container.

### **Een dia exporteren naar EMF**

De methode [Slide.write_as_emf](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/write_as_emf/) schrijft een [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/) naar een doelflow in EMF‑formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑bestandstroom:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

De aanroeper bezit de stroom die aan [Slide.write_as_emf](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/write_as_emf/) wordt doorgegeven en moet deze sluiten. Aspose.Slides schrijft op de huidige positie van de stroom en laat de stroom open.

### **Een SVG‑afbeelding omzetten naar EMF en toevoegen aan een presentatie**

Gebruik [SvgImage.write_as_emf](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/write_as_emf/) om SVG‑inhoud om te zetten naar EMF. De resulterende bytes kunnen aan de presentatie worden toegevoegd via [ImageCollection.add_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/add_image/) en op een dia worden geplaatst met [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/) .

Het volgende voorbeeld maakt een [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) van SVG‑markup, converteert deze naar een EMF in het geheugen, voegt het metafile toe aan de eerste dia en slaat de presentatie op:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/write_as_emf/) neemt geen eigendom van de bestemmingsstroom. Na het schrijven staat de stroompositie aan het einde van de gegenereerde gegevens. Roep `getvalue` aan om de volledige buffer te verkrijgen, ongeacht de huidige stroompositie, zoals hierboven getoond. Houd de stroom open totdat de gegevens zijn gelezen en sluit deze daarna.

EMF‑generatie is beschikbaar op de besturingssystemen die worden ondersteund door Aspose.Slides for Python via .NET, maar het renderen kan per platform verschillen wanneer lettertypen of native grafische afhankelijkheden niet beschikbaar zijn. Installeer de lettertypen die door de broninhoud worden gebruikt of configureer geschikte vervangingen, volg de [platformvereisten](/slides/nl/python-net/system-requirements/) voor Aspose.Slides, en valideer het resultaat in de doel‑EMF‑toepassing. Linux‑ en macOS‑toepassingen hebben vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleur‑emoji rendering**

{{% alert title="Note" color="info" %}}
Om kleur‑emoji’s correct weer te geven bij het converteren van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie gebruikmaakt van **Segoe UI Emoji** en dit lettertype ontbreekt, kunnen emoji’s in monochroom verschijnen in de uitvoerafbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia’s met animaties?**

Nee. De methode [Slide.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/) rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia’s als afbeeldingen worden geëxporteerd?**

Ja. Verborgen dia’s kunnen worden gerenderd zoals gewone dia’s. Neem ze op in de verwerkingslus, zoals getoond in het bovenstaande voorbeeld.

**Worden schaduwen en andere effecten behouden in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.