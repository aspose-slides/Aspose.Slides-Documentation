---
title: Hantera presentationsplatshållare i Python
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/python-net/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- innehållsplatshållare
- uppmaningstext
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du inspekterar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärvning med Aspose.Slides för Python via .NET."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och generella innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller master‑bild.

Aspose.Slides exponerar platshållarinformation via egenskapen [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). Egenskapen returnerar ett [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/)-objekt eller `None` för en normal form. Använd [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) för att avgöra vad platshållaren är avsedd att innehålla.

Formklassen är fortfarande relevant efter att du känner till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras ofta av en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- En ifylld bildplatshållare kan representeras av en [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- En ifylld diagramplatshållare kan representeras av en [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) och den körande formklassen istället för att anta att varje platshållare är en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) beskriver en platshållares roll; den garanterar inte formens körande klass. Använd alltid en typkontroll innan du får åtkomst till text‑, bild‑, diagram‑, tabell‑ eller mediaspecifika medlemmar.
{{% /alert %}}

## **Förstå platshållarärvning**

Platshållare bildar en hierarki:

1. En master‑bild definierar återanvändbara stilar och, i vissa fall, master‑nivå platshållare.
2. En layout‑bild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från master‑bilden.
3. En vanlig bild innehåller de platshållare som gäller för den bilden och kan ärva från sin layout.

Anropa [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) för att gå ett steg upp i hierarkin. En bildplatshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin master‑platshållare. Metoden returnerar `None` när formen inte har någon grund‑platshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras grund‑platshållare:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Att redigera en platshållare på en vanlig bild skapar eller ändrar en lokal åsidosättning för den bilden. Att redigera den relaterade layouten eller master‑bilden kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen grund‑platshållare och börjar inte ärva enbart eftersom den upptar samma koordinater.

## **Ta bort platshållarstatus**

När du anpassar en mall, använd [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) för att behålla ett befintligt objekt som en vanlig form. Dess [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/)‑egenskap blir `None`, men formen förblir i bildens samling. I kontrast tar [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) bort formen från den samlingen.

Följande exempel kräver `template.pptx` med minst en bild och en icke‑tom text‑platshållare på den första bilden. Använd en platshållare med formatering ärvd från dess layout eller master för att se effekten av att ta bort den relationen. Exemplet kontrollerar att samma form kvarstår, anropar metoden igen på den nu vanliga formen, och sparar resultatet.

{{% alert color="warning" title="Warning" %}}
Att ta bort platshållarstatus bevarar inte automatiskt ärvda utseendeinställningar. Exemplet nedan lämnar medvetet dessa inställningar oförändrade, så utdata kan se annorlunda ut. En form vars position och storlek är helt ärvda kan ha nollkoordinater och dimensioner efter anropet och bli osynlig även om den fortfarande finns i samlingen.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Att anropa metoden på en vanlig form har ingen effekt.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

För en matchande platshållare skrivs alla tre kontroller ut som `True`. Texten kvarstår, men ärvd position, storlek, rotation, teckensnitt, styckejustering, marginaler för text‑ram, vertikal ankare, fyllning och linjeinställningar kan förändras när platshållarrelationen tas bort. Till exempel kan ärvd titel‑formatering falla tillbaka till vanlig text‑formatering. Se [Slide Layout](/slides/sv/python-net/slide-layout/) för mer om layouter.

För att bevara det avsedda utseendet, fånga den lösta positionen, storleken och rotationen innan anropet, och kopiera de nödvändiga effektiva formateringsvärdena till separata variabler. Hämta dessa värden via [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), och [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Lita inte bara på att behålla effektiva‑format‑objekten, eftersom deras text‑formateringsvärden kan förändras efter att relationen har tagits bort. Tillämpa uttryckligen de fångade värdena på den vanliga formen efteråt, inklusive teckensnittsfamilj, storlek, stil, färg, styckeinställningar, text‑ram‑inställningar, fyllning och linje som används av din mall.

Ärvd formgeometri kan också behöva tilldelas explicit via [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). För en rektangulär text‑platshållare innebär detta att tilldela [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); att bara återställa fyllning och linje återställer kanske inte den synliga rektangeln. Mallar med extra effekter eller mer komplex formatering kräver att dessa inställningar också hanteras.

## **Ändra text i en platshållare**

Titel‑, centrerad‑titel‑, undertext‑, brödtext‑ och text‑platshållare stöder normalt text. Kontrollera för [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) innan du använder dess [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/)‑egenskap.

Detta exempel uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Detta mönster undviker att behandla bild‑, diagram‑, tabell‑ eller media‑platshållare som [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑objekt. Det identifierar också platshållaren efter syfte istället för att förlita sig på ett ömtåligt form‑index.

## **Ange uppmaningstext på en layout**

Uppmaningstext är den design‑tidsinstruktion som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ställ in anpassad uppmaningstext på layout‑platshållaren snarare än att försöka nå den via en normal bilds form‑samling. Åtkomst till layouten sker via [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) och iterera över [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Följande exempel ändrar titel‑ och undertext‑uppmaningar på layouten som används av den första bilden:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Uppmaningstext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller riktigt innehåll visas uppmaningen inte längre. Att ändra en uppmaning ersätter inte befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), ersätt bilden via [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) och [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) och ta bort den tomma platshållaren.

Nästa exempel stödjer båda fallen och sparar presentationen:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) är skrivskyddad. Den behåller den reserverade positionen men ärver inte längre platshållar‑specifik beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll i platshållaren i PowerPoint först, och uppdatera sedan den resulterande [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/python-net/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållar‑metadata.

## **Arbeta med diagram‑ och innehålls‑platshållare**

En ifylld diagram‑platshållare kan representeras av en [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Detta exempel hittar ett sådant diagram genom både platshållartyp och körande klass, ändrar dess titel och sparar filen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

En generell innehålls‑platshållare har vanligtvis [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts i, inspektera den faktiska formklassen för att ta reda på vad den innehåller. Specialiserade layouter kan också exponerar [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), eller [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑platshållare till ett [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) enbart genom att ändra [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); typen är skrivskyddad. För att programatiskt fylla ett tomt diagram‑ eller innehållsområde, lägg till det erforderliga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/python-net/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsbokdata.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande helhets‑exempel öppnar en mall, söker igenom den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar det lämpliga innehållet och sparar utdata. Exemplet undviker medvetet att anta ett form‑index eller att behandla varje platshållare som samma formklass.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vad är en grund‑platshållare?**

En grund‑platshållare är den motsvarande formen på layouten eller master‑bilden som en annan platshållare ärver från. Använd [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) för att hämta den. En vanlig lokal form returnerar `None` eftersom den inte är en del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller uppmaningstext via en layout, men befintligt titel‑innehåll lagras på de normala bilderna. För att ersätta faktiska titlar i en hel presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bild‑nummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd sidhuvuds‑ och sidfotshanterarna på lämplig bild, layout, master, anteckningar eller utdelnings‑nivå. Se [Manage Presentation Header and Footer](/slides/sv/python-net/presentation-header-and-footer/) för kompletta exempel.