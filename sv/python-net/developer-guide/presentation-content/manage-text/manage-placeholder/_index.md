---
title: Hantera presentationens platshållare i Python
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
- prompttext
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du inspekterar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår arv av platshållare med Aspose.Slides för Python via .NET."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationmall. Vanliga exempel är titel, brödtext, bild, diagram och generella innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller mastern.

Aspose.Slides exponerar platshållarinformation via egenskapen [Shape.placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/placeholder/). Egenskapen returnerar ett [Placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholder/) objekt eller `None` för en normal form. Använd [Placeholder.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholder/type/) för att avgöra vad platshållaren är avsedd att innehålla.

Formklassen är fortfarande viktig efter att du känner till platshållartypen:

- En tom text-, bild-, diagram- eller innehållsplatshållare representeras vanligtvis av en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).
- En ifylld bildplatshållare kan representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/).
- En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [Placeholder.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholder/type/) och den körtidsformklassen i stället för att anta att varje platshållare är en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholder/type/) beskriver en platshållares roll; den garanterar inte formens körtidsklass. Använd alltid en typkontroll innan du får åtkomst till text-, bild-, diagram-, tabell- eller mediaspecifika medlemsvariabler.
{{% /alert %}}

## **Förstå arv av platshållare**

Platshållare bildar en hierarki:

1. En mastern bild definierar återanvändbara stilar och, i vissa fall, masternivåns platshållare.
2. En layoutbild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från mastern.
3. En normal bild innehåller platshållarna för den bilden och kan ärva från dess layout.

Anropa [Shape.get_base_placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_base_placeholder/) för att gå upp en nivå i denna hierarki. En bildplatshållare returnerar normalt sin layoutplatshållare; en layoutplatshållare kan returnera sin mastern platshållare. Metoden returnerar `None` när formen inte har någon basplatshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras basplatshållare:

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

Att redigera en platshållare på en normal bild skapar eller ändrar ett lokalt överskuggande för den bilden. Att redigera den relaterade layouten eller mastern kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen basplatshållare och börjar inte ärva bara för att den har samma koordinater.

## **Ändra text i en platshållare**

Titel-, centrerad-titel-, undertext-, brödtext- och textplatshållare stöder normalt text. Kontrollera efter en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) innan du använder dess [text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/text_frame/) egenskap.

Detta exempel uppdaterar den första titelplatshållaren på den första bilden och sparar resultatet:

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

Detta mönster undviker att behandla bild-, diagram-, tabell- eller mediaplatshållare som [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) objekt. Det identifierar även platshållaren efter syfte i stället för att förlita sig på ett bräckligt formindex.

## **Ange prompttext på en layout**

Prompttext är den designtidinstruktion som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ställ in anpassad prompttext på layoutplatshållaren istället för att försöka nå den via en normal bilds formsamling. Åtkomst till layouten sker via [Slide.layout_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/layout_slide/) och iterera över [LayoutSlide.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/shapes/).

Följande exempel ändrar titel- och undertextpromptarna på den layout som används av den första bilden:

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

Prompttext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram såsom PowerPoint. När en användare eller ett program levererar riktigt innehåll visas prompten inte längre. Att ändra en prompt ersätter inte heller befintlig text på bilder som använder layouten.

## **Uppdatera en bildplatshållare**

Det finns två fall att hantera:

- Om bildplatshållaren redan är ifylld och representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/), ersätt bilden via [PictureFillFormat.picture](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/picture/) och [Picture.image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picture/image/).
- Om den fortfarande är en tom platshållare, lägg till en bildram vid platshållarens koordinater med [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/) och ta bort den tomma platshållaren.

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

Ersättningen som skapats för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [Shape.placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/placeholder/) är skrivskyddad. Den behåller den reserverade positionen men ärver inte längre platshållarspecifik beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll i platshållaren i PowerPoint först, uppdatera sedan den resulterande [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/python-net/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållarmetadata.

## **Arbeta med diagram- och innehållsplatshållare**

En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/). Detta exempel hittar ett sådant diagram både via platshållartyp och körtidsklass, ändrar dess titel och sparar filen:

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

En generell innehållsplatshållare har vanligtvis [PlaceholderType.OBJECT](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholdertype/). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. När den har fyllts i, inspektera den faktiska formklassen för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.CHART](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholdertype/), eller [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) platshållare till ett [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/) enbart genom att ändra [Placeholder.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/placeholder/type/); typen är skrivskyddad. För att fylla ett tomt diagram- eller innehållsområde programmässigt, lägg till det erforderliga objektet vid platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

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

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layoutplatshållaren. Använd de dedikerade [chart management articles](/slides/sv/python-net/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsboksdata.

## **Fullständigt exempel: Uppdatera text eller bildinnehåll**

Följande end‑to‑end‑exempel öppnar en mall, söker den första bilden efter antingen en titel- eller bildplatshållare, kontrollerar platshållar- och formklasser, uppdaterar lämpligt innehåll och sparar resultatet. Exemplet undviker medvetet att anta ett formindex eller att behandla varje platshållare som samma formklass.

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

## **Vanliga frågor**

**Vad är en basplatshållare?**

En basplatshållare är den motsvarande formen på layouten eller mastern som en annan platshållare ärver från. Använd [Shape.get_base_placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_base_placeholder/) för att hämta den. En vanlig lokal form returnerar `None` eftersom den inte är en del av platshållarhierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layoutplatshållare?**

Du kan ändra ärvd formatering eller prompttext via en layout, men befintligt titelinnehåll lagras på de vanliga bilderna. För att ersätta den egentliga titeltexten i hela presentationen, iterera över bilderna och uppdatera varje titelplatshållare.

**Hur hanterar jag datum-, bildnummer-, sidhuvud- och sidfotplatshållare?**

Använd hanterarna för sidhuvud och sidfot på den passande bilden, layouten, mastern, anteckningarna eller utdelningsomfånget. Se [Manage Presentation Header and Footer](/slides/sv/python-net/presentation-header-and-footer/) för kompletta exempel.