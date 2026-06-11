---
title: Hantera bildmaster i presentationer med Python
linktitle: Bildmaster
type: docs
weight: 80
url: /sv/python-net/slide-master/
keywords:
- bildmaster
- masterbild
- PPT-masterbild
- flera masterbilder
- jämföra masterbilder
- bakgrund
- platshållare
- klona masterbild
- kopiera masterbild
- duplicera masterbild
- oanvänd masterbild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera bildmaster i Aspose.Slides för Python via .NET: åtkomst, redigering, kloning, jämförelse och borttagning av masterbilder i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **slide master** definierar gemensamma designinställningar för en grupp bilder. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för Python via .NET stöder samma modell. En presentation kan innehålla en eller flera master‑bilder, och varje master‑bild kan innehålla flera layout‑bilder. Normala bilder refererar vanligtvis inte till en master‑bild direkt. Istället använder en normal bild en layout‑bild, och den layout‑bilden tillhör en master‑bild.

Hierarkin är:

1. **Slide master** – definierar den delade designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layoutnivåformatering.  
1. **Normal slide** – innehåller det faktiska presentationsinnehållet och använder en layout slide.

![Hierarkin av masterbilder, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) . Alla master‑bilder i en presentation är tillgängliga via samlingen `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en master‑bild och en layout‑bild båda definierar en bakgrund, använder bilder baserade på den layouten layout‑bakgrunden. För mer information om layout‑bilder, se [Apply or Change Slide Layouts](/python-net/slide-layout/).
{{% /alert %}}

## **Åtkomst till slide master**

I PowerPoint kan du öppna Slide Master‑vyn från **View** > **Slide Master**.

![Slide Master-kommandot på PowerPoint View-fliken](slide-master_3.jpg)

I Aspose.Slides, använd samlingen `masters` för att komma åt master‑bilder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Du kan också hämta master‑bilden som används av en normal bild via dess layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Vad en slide master innehåller**

En master‑bild är ett bildliknande objekt. Den ärver gemensamt bildbeteende från klassen [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/) , så den exponerar många av samma bildegenskaper som används av normala och layout‑bilder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) .

Vanligt använda master‑bildmedlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `background` | Anger masternivåns bildbakgrund. |
| `shapes` | Lagrar former som placerats på mastern, såsom logotyper, bildramar och delad text. |
| `layout_slides` | Lagrar layoutbilderna som tillhör mastern. |
| `theme_manager` | Ger åtkomst till mastertema‑API:erna. |
| `header_footer_manager` | Styr sidhuvuden, sidfötter, datum och bildnummer för mastern och dess underliggande layouter. |
| `get_depending_slides` | Returnerar normala bilder som är beroende av mastern genom sina layouter. |

## **Lägg till en bild i en slide master**

När du lägger till en bild i en master‑bild visas den på bilder som använder layouter från den mastern. Detta är praktiskt för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första master‑bilden:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

För mer information om bildramar, se [Picture Frame](/python-net/picture-frame/).

## **Arbeta med platshållare**

Platshållare definieras normalt på layout‑bilder. Master‑bilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon i Slide Master‑vyn.

![Infoga platshållarkommandet i PowerPoint Slide Master-vyn](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med layout‑bilden som tillhör mastern:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Du kan också formatera platshållarformer som redan finns på en master‑bild. Följande exempel hittar titel‑platshållaren och applicerar en linjär gradientfyllning:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formaterad titelplatshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) och [Text Formatting](/python-net/text-formatting/).

## **Ändra en slide masters bakgrund**

En master‑bakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första master‑bilden:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

För relaterade ämnen, se [Presentation Background](/python-net/presentation-background/) och [Presentation Theme](/python-net/presentation-theme/).

## **Klona en slide master till en annan presentation**

Använd metoden `add_clone` på klassen [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/) för att kopiera en master‑bild till en annan presentation. Den kopierade master‑bilden kan sedan användas av layouter och bilder i mål‑presentationen.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Om du behöver klona normala bilder tillsammans med deras master, se [Clone Slides](/python-net/clone-slides/).

## **Lägg till flera slide master**

En presentation kan innehålla flera master‑bilder. Detta är användbart när olika avsnitt kräver annan varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint-kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standard‑master‑bilden, ger klonen en annan bakgrund, hämtar en tom layout under den klonade master‑bilden och lägger till en ny bild baserad på den layouten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Jämför slide master**

Master‑bilder kan jämföras med metoden `equals` som ärvs från klassen [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/) . Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, som bild‑ID:n, eller dynamiska platshållarvärden, som aktuellt datum.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

För mer information, se [Compare Presentation Slides](/python-net/compare-slides/).

## **Ställ in Slide Master-vyn som standardvy**

Använd egenskapen `last_view` på presentationens [ViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

För fler vyinställningar, se [Save Presentation](/python-net/save-presentation/).

## **Ta bort oanvända masterbilder**

Presentationer kan ibland innehålla master‑bilder som inte längre används av några normala bilder. Att ta bort oanvända master‑bilder kan minska filstorleken och förenkla underhållet av mallar.

Använd `remove_unused` för att ta bort oanvända master‑bilder från samlingen `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Du kan också använda låg‑kod‑metoden `remove_unused_master_slides` från klassen [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vad är skillnaden mellan en slide master och en layout slide?**

En slide master definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layout slide tillhör en master‑bild och definierar en specifik placering av platshållare. En normal bild använder en layout slide och ärver därmed både layout‑ och master‑inställningarna.

**Kan en presentation innehålla flera slide master?**

Ja. En presentation kan innehålla flera slide master. Använd flera master‑bilder när olika avsnitt behöver olika visuella system eller varumärkesprofil.

**Ska jag lägga till platshållare på en master‑bild eller en layout slide?**

I de flesta fall lägger du till platshållare på layout‑bilder. Placera delade visuella element och gemensam formatering på master‑bilden och innehållsplatshållare på de layouter som de normala bilderna ska använda.

**Kan jag ta bort en master‑bild som fortfarande används?**

Nej. En master‑bild som har beroende bilder kan inte tas bort säkert direkt. Flytta först de beroende bilderna till layouter under en annan master, eller använd en rengöringsmetod för oanvända master‑bilder som endast tar bort master‑bilder som inte används.