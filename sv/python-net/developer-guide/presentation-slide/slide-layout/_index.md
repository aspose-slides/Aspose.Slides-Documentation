---
title: Tillämpa eller ändra bildlayouter i Python
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/python-net/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationdesign
- bilddesign
- oanvänd layout
- fotovisning
- titulbild
- titel och innehåll
- sektionrubrik
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar och anpassar bildlayouter i Aspose.Slides för Python via .NET. Utforska layouttyper, kontroll av platshållare, fotovisning och layoutmanipulation genom kodexempel i Python."
---
## **Introduktion**

Ett bildlayout definierar placeringen av platshållarboxar och formatering av innehållet på en bild. Den styr vilka platshållare som är tillgängliga och var de visas. Bildlayouter hjälper dig att snabbt och konsekvent designa presentationer—oavsett om du skapar något enkelt eller mer komplext. Några av de vanligaste bildlayouterna i PowerPoint inkluderar:

**Titelbildslayout** – Inkluderar två textplatshållare: en för titeln och en för undertiteln.

**Titel- och innehållslayout** – Har en mindre titelplatshållare högst upp och en större nedanför för huvudinnehåll (såsom text, punktlistor, diagram, bilder och mer).

**Tom layout** – Innehåller inga platshållare, vilket ger dig full kontroll att designa bilden från grunden.

Bildlayouter är en del av en bildmaster, som är den översta bilden som definierar layoutstilar för presentationen. Du kan komma åt och ändra layoutbilder via bildmastern—antingen efter deras typ, namn eller unika ID. Alternativt kan du redigera en specifik layoutbild direkt i presentationen.

För att arbeta med bildlayouter i Aspose.Slides för Python kan du använda:

- Egenskaper såsom [layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/layout_slides/) och [masters](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/masters/) under klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) 
- Typer som [LayoutSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/), och [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
För att lära dig mer om att arbeta med masternbilder, läs artikeln [Hantera PowerPoint‑masternbilder i Python](/slides/sv/python-net/slide-master/).
{{% /alert %}}

## **Lägg till bildlayouter i presentationer**

För att anpassa utseendet och strukturen på dina bilder kan du behöva lägga till nya layoutbilder i en presentation. Aspose.Slides för Python låter dig kontrollera om en viss layout redan finns, lägga till en ny om det behövs, och använda den för att infoga bilder baserat på den layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkom [MasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterlayoutslidecollection/).
3. Kontrollera om den önskade layoutbilden redan finns i samlingen. Om inte, lägg till den layoutbild du behöver.
4. Lägg till en tom bild baserad på den nya layoutbilden.
5. Spara presentationen.

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen för att öppna presentationsfilen.
with slides.Presentation("sample.pptx") as presentation:
    # Gå igenom layoutbildtyperna för att välja en layoutbild.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Ett scenario där presentationen inte innehåller alla layouttyper.
        # Presentationsfilen innehåller bara tomma och anpassade layouttyper.
        # Dock kan layoutbilder med anpassade typer ha igenkännliga namn,
        # så som "Title", "Title and Content", etc., som kan användas för att välja layoutbild.
        # Du kan också förlita dig på en uppsättning av platshållarformtyper.
        # Till exempel bör en titelbild bara ha Title-platshållartypen, och så vidare.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Lägg till en tom bild med den tillagda layoutbilden.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [remove_unused_layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) från klassen [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/), som låter dig ta bort oönskade och oanvända layoutbilder.

Följande Python‑kod visar hur man tar bort en layoutbild från en PowerPoint‑presentation:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till platshållare i bildlayouter**

Aspose.Slides erbjuder egenskapen [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/placeholder_manager/), som låter dig lägga till nya platshållare i en layoutbild.

Denna hanterare innehåller metoder för följande platshållartyper:

| PowerPoint‑platshållare | [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/) Method |
| ----------------------- | ------------------------------------------------------------ |
| ![Innehåll](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Innehåll (Vertikal)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertikal)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Bild](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Diagram](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabell](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online‑bild](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Följande Python‑kod demonstrerar hur man lägger till nya platshållarformer i den tomma layoutbilden:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Hämta den tomma layoutbilden.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Hämta platshållarhanteraren för layoutbilden.
    placeholder_manager = layout.placeholder_manager

    # Lägg till olika platshållare i den tomma layoutbilden.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Lägg till en ny bild med den tomma layouten.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

## **Ställ in synlighet för sidfot på en layoutbild**

I PowerPoint‑presentationer kan fotelement som datum, bildnummer och anpassad text visas eller döljas beroende på bildlayouten. Aspose.Slides för Python låter dig styra synligheten för dessa fot‑platshållare. Detta är användbart när du vill att vissa layouter ska visa fotinformation medan andra förblir rena och minimalistiska.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till en layoutbild efter dess index.
3. Ställ in fot‑platshållaren för bilden till synlig.
4. Ställ in bildnummer‑platshållaren till synlig.
5. Ställ in datum‑tid‑platshållaren till synlig.
6. Spara presentationen.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Ställ in synlighet för barn‑fot på en bild**

I PowerPoint‑presentationer kan fot‑element som datum, bildnummer och anpassad text kontrolleras på masternivå för att säkerställa konsistens över alla layoutbilder. Aspose.Slides för Python gör det möjligt att ställa in synlighet och innehåll för dessa fot‑platshållare på mastern och sprida dessa inställningar till alla underliggande layoutbilder. Detta tillvägagångssätt säkerställer enhetlig fotinformation i hela presentationen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till mastern efter dess index.
3. Ställ in masterns och alla barns fot‑platshållare till synliga.
4. Ställ in masterns och alla barns bildnummer‑platshållare till synliga.
5. Ställ in masterns och alla barns datum‑tid‑platshållare till synliga.
6. Spara presentationen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vad är skillnaden mellan en masternbild och en layoutbild?**

En masternbild definierar det övergripande temat och standardformateringen, medan layoutbilder definierar specifika arrangemang av platshållare för olika typer av innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja, du kan klona en layoutbild från en presentations [layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/layout_slides/)‑samling och infoga den i en annan med metoden `add_clone`.

**Vad händer om jag tar bort en layoutbild som fortfarande används av en bild?**

Om du försöker ta bort en layoutbild som fortfarande refereras av minst en bild i presentationen, kommer Aspose.Slides att kasta ett [PptxEditException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxeditexception/). För att undvika detta, använd [remove_unused_layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) som säkert tar bort endast de layoutbilder som inte används.