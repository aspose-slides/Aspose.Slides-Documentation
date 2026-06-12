---
title: Beheer hyperlinks in presentaties met Python
linktitle: Beheer hyperlink
type: docs
weight: 20
url: /nl/python-net/manage-hyperlinks/
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
- mutabele hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Python
description: "Beheer hyperlinks moeiteloos in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET—verbeter interactiviteit en workflow binnen enkele minuten."
---
## **Introductie**

Een hyperlink is een verwijzing naar een externe bron, een object of data‑item, of een specifieke locatie binnen een bestand. Veelvoorkomende hyperlink‑typen in PowerPoint‑presentaties omvatten:

* Links naar websites ingebed in tekst, vormen of media
* Links naar dia's

Aspose.Slides voor Python via .NET maakt een breed scala aan hyperlinkgerelateerde bewerkingen in presentaties mogelijk.

## **URL‑hyperlinks toevoegen**

Deze sectie legt uit hoe je URL‑hyperlinks toevoegt aan diaverschijnselen bij het werken met Aspose.Slides. Het behandelt het toewijzen van linkadressen aan tekst, vormen en afbeeldingen om soepele navigatie tijdens presentaties te garanderen.

### **URL‑hyperlinks aan tekst toevoegen**

Het volgende code‑voorbeeld laat zien hoe je een website‑hyperlink aan tekst toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑hyperlinks aan vormen of frames toevoegen**

Het volgende code‑voorbeeld laat zien hoe je een website‑hyperlink aan een vorm toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑hyperlinks aan media toevoegen**

Aspose.Slides stelt je in staat hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden.

Het volgende code‑voorbeeld laat zien hoe je een hyperlink aan een **afbeelding** toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg een afbeelding toe aan de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Maak een afbeeldingframe op dia 1 met de eerder toegevoegde afbeelding.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Het volgende code‑voorbeeld laat zien hoe je een hyperlink aan een **audio‑bestand** toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Het volgende code‑voorbeeld laat zien hoe je een hyperlink aan een **video** toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Je wilt misschien [OLE beheren in presentaties met Python](/slides/nl/python-net/manage-ole/).
{{% /alert %}}

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Omdat hyperlinks je in staat stellen objecten of locaties te refereren, kun je ze gebruiken om een inhoudsopgave samen te stellen.

De voorbeeldcode hieronder laat zien hoe je een inhoudsopgave met hyperlinks maakt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks opmaken**

Deze sectie toont hoe je het uiterlijk van hyperlinks in Aspose.Slides kunt opmaken. Je leert kleur en andere stijlopties te beheren om de hyperlink‑opmaak consistent te houden over tekst, vormen en afbeeldingen.

### **Kleur van hyperlink**

Met de [color_source](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/color_source/)‑eigenschap van de [Hyperlink](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/)‑klasse kun je de kleur van een hyperlink instellen en de kleurinformatie uitlezen. Deze functie werd geïntroduceerd in PowerPoint 2019, dus wijzigingen via deze eigenschap zijn niet van toepassing op eerdere versies van PowerPoint.

Het volgende voorbeeld demonstreert hoe je hyperlinks met verschillende kleuren aan dezelfde dia toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks uit presentaties verwijderen**

Deze sectie legt uit hoe je hyperlinks uit presentaties verwijdert bij het werken met Aspose.Slides. Je leert hoe je linktargets van tekst, vormen en afbeeldingen wist, terwijl je de oorspronkelijke inhoud en opmaak behoudt.

### **Hyperlinks uit tekst verwijderen**

Het volgende voorbeeld toont hoe je hyperlinks uit tekst op een presentatiedia verwijdert:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Hyperlinks uit vormen of frames verwijderen**

Het volgende voorbeeld toont hoe je hyperlinks uit vormen op een presentatiedia verwijdert:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Mutabele hyperlinks**

De [Hyperlink](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/)‑klasse is mutabel. Met deze klasse kun je de waarden van de volgende eigenschappen wijzigen:

- [target_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Het volgende code‑fragment laat zien hoe je een hyperlink aan een dia toevoegt en vervolgens de tooltip bewerkt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ondersteunde eigenschappen in IHyperlinkQueries**

Je kunt [HyperlinkQueries](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkqueries/) benaderen vanuit de presentatie, dia of tekst die de hyperlink bevat.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/hyperlink_queries/)

De [HyperlinkQueries](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkqueries/)‑klasse ondersteunt de volgende methoden:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Je wilt misschien Aspose’s eenvoudige, gratis online [PowerPoint‑editor](https://products.aspose.app/slides/nl/editor) bekijken.
{{% /alert %}}

## **Veelgestelde vragen**

**Hoe kan ik interne navigatie maken, niet alleen naar een dia, maar naar een “sectie” of de eerste dia van een sectie?**

Secties in PowerPoint zijn groeppingen van dia’s; navigatie richt zich technisch gezien op een specifieke dia. Om “naar een sectie te navigeren” link je meestal naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de master‑dia koppelen zodat hij op alle dia’s werkt?**

Ja. Master‑dia‑ en layout‑elementen ondersteunen hyperlinks. Dergelijke links verschijnen op onderliggende dia’s en zijn klikbaar tijdens de diavoorstelling.

**Worden hyperlinks behouden bij exporteren naar PDF, HTML, afbeeldingen of video?**

In [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/python-net/convert-powerpoint-to-html/) ja — links blijven over het algemeen behouden. Bij exporteren naar [images](/slides/nl/python-net/convert-powerpoint-to-png/) en [video](/slides/nl/python-net/convert-powerpoint-to-video/) wordt de klikbaarheid niet meegenomen vanwege de aard van die formaten (raster‑frames/video ondersteunen geen hyperlinks).