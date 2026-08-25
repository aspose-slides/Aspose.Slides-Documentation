---
title: Hantera bildmaster för presentationer i Python
linktitle: Bildmaster
type: docs
weight: 80
url: /sv/python-net/slide-master/
keywords:
- bildmaster
- masterbild
- PPT-masterbild
- flera masterbilder
- jämför masterbilder
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
description: "Hantera bildmaster i Aspose.Slides för Python via .NET: åtkomst, redigering, kloning, jämförelse och borttagning av masterbilder i PowerPower‑ och OpenDocument-presentationer."
---
## **Översikt**

En **slide master** definierar gemensamma designinställningar för en grupp bilder. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation enhetlig utan att upprepa samma formatering på varje bild.

Aspose.Slides for Python via .NET stöder samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Vanliga bilder refererar normalt inte direkt till en masterbild. Istället använder en vanlig bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Slide master** – definierar den delade designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layoutnivåformatering.  
1. **Normal slide** – innehåller det faktiska presentationsinnehållet och använder en layoutbild.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) . Alla masterbilder i en presentation är tillgängliga via samlingen `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Apply or Change Slide Layouts](/slides/sv/python-net/slide-layout/).
{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn från **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

I Aspose.Slides, använd samlingen `masters` för att komma åt masterbilder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Du kan också hämta masterbilden som en normal bild använder via dess layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Vad en Slide Master Innehåller**

En masterbild är ett bildlikt objekt. Den ärver gemensamt bildbeteende från klassen [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/) . Därför exponeras många av samma bildegenskaper som används av vanliga och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) .

Vanligt använda medlemmar för masterbilder inkluderar:

| Member | Syfte |
| --- | --- |
| `background` | Ställer in masternivåns bildbakgrund. |
| `shapes` | Lagrar former placerade på master, såsom logotyper, bildramar och delad text. |
| `layout_slides` | Lagrar de layoutbilder som tillhör master. |
| `theme_manager` | Ger åtkomst till mastertemats API:er. |
| `header_footer_manager` | Kontrollerar sidhuvuden, sidfötter, datum och bildnummer för master och dess underlayouter. |
| `get_depending_slides` | Returnerar vanliga bilder som är beroende av master genom deras layouter. |

## **Lägg till en bild i en Slide Master**

När du lägger till en bild på en masterbild visas den på bilder som använder layout från den mastern. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

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

För mer information om bildramar, se [Picture Frame](/slides/sv/python-net/picture-frame/).

## **Arbeta med Platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint är platshållarkommandon tillgängliga i Slide Master‑vyn.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med den layoutbild som tillhör mastern:

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

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titelplatshållaren och applicerar en linjär gradientfyllning:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/python-net/manage-placeholder/) och [Text Formatting](/slides/sv/python-net/text-formatting/).

## **Ändra bakgrund för en Slide Master**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första masterbilden:

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

För relaterade ämnen, se [Presentation Background](/slides/sv/python-net/presentation-background/) och [Presentation Theme](/slides/sv/python-net/presentation-theme/).

## **Klona en Slide Master till en annan presentation**

Använd `add_clone`‑metoden på klassen [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/) för att kopiera en masterbild till en annan presentation. Den kopierade masterbilden kan sedan användas av layouter och bilder i mål‑presentationen.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Om du behöver klona vanliga bilder tillsammans med deras master, se [Clone Slides](/slides/sv/python-net/clone-slides/).

## **Lägg till flera Slide Masters**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika sektioner kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Följande exempel klonar standard‑masteren, ger klonen en annan bakgrund, får en tom layout under den klonade masteren och lägger till en ny bild baserad på den layouten:

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

## **Jämför Slide Masters**

Masterbilder kan jämföras med `equals`‑metoden som ärvs från [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/) . Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Compare Presentation Slides](/slides/sv/python-net/compare-slides/).

## **Ställ in Slide Master‑vyn som standardvy**

Använd egenskapen `last_view` på presentationens [ViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/) för att kontrollera den vy som PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

För fler vyinställningar, se [Save Presentation](/slides/sv/python-net/save-presentation/).

## **Ta bort oanvända masterbilder**

Presentationer kan ibland innehålla masterbilder som inte längre används av några vanliga bilder. Att ta bort oanvända masterbilder kan minska filstorleken och förenkla underhållet av mallar.

Använd `remove_unused` för att ta bort oanvända masterbilder från samlingen `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Du kan också använda low‑code‑metoden `remove_unused_master_slides` från klassen [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Vad är skillnaden mellan en slide master och en layoutbild?

En slide master definierar gemensamma designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en masterbild och definierar en specifik placering av platshållare. En normal bild använder en layoutbild, så den ärver både från layouten och masteren.

### Kan en presentation innehålla flera slide masters?

Ja. En presentation kan innehålla flera slide masters. Använd flera masterbilder när olika sektioner kräver olika visuella system eller varumärkesprofil.

### Bör jag lägga till platshållare på en masterbild eller en layoutbild?

I de flesta fall bör du lägga till platshållare på layoutbilder. Placera delade visuella element och gemensam formatering på masterbilden, och placera sedan innehålls‑platshållare på de layouter som de vanliga bilderna kommer att använda.

### Kan jag ta bort en masterbild som fortfarande används?

Nej. En masterbild som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en städrutin för oanvända masterbilder som bara tar bort masterbilder som inte används.