---
title: Hantera presentationsplatshållare i Python
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/python-java/manage-placeholder/
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
- Java
- Aspose.Slides
description: "Lär dig hur du granskar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärvning med Aspose.Slides för Python via Java."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och allmänna innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller en masternbild.

Aspose.Slides exponerar platshållarinformation via metoden [Shape.getPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getPlaceholder). Metoden returnerar ett [Placeholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholder/)‑objekt eller `None` för en normal form. Använd [Placeholder.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholder/#getType) för att avgöra vad platshållaren är avsedd att innehålla.

Formtypen spelar fortfarande roll efter att du vet platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras ofta av en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).
- En ifylld bildplatshållare kan representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/).
- En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/).
- En innehållsplatshållare kan innehålla flera sorters innehåll. Kontrollera både [Placeholder.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholder/#getType) och den körande formtypen i stället för att anta att varje platshållare är en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholder/#getType) beskriver en platshållares roll; den garanterar inte formens kör‑tidstyp. Använd alltid en typkontroll innan du får åtkomst till text‑, bild‑, diagram‑, tabell‑ eller media‑specifika medlemmar.
{{% /alert %}}

## **Förstå platshållarärvning**

Platshållare bildar en hierarki:

1. En masternbild definierar återanvändbara stilar och, i vissa fall, masternivå‑platshållare.
2. En layoutbild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från mastern.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från sin layout.

Anropa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getBasePlaceholder) för att gå ett nivå upp i hierarkin. En bildplatshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin mastern‑platshållare. Metoden returnerar `None` när formen saknar grund‑platshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras grund‑platshållare:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Att redigera en platshållare på en vanlig bild skapar eller ändrar en lokal överskuggning för den bilden. Att redigera den relaterade layouten eller mastern kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen grund‑platshållare och börjar inte ärva bara för att den befinner sig på samma koordinater.

## **Ändra text i en platshållare**

Titel‑, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stödjer normalt text. Kontrollera att det är en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) innan du använder dess [getTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#getTextFrame)‑metod.

Detta exempel uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mönstret undviker att behandla bild‑, diagram‑, tabell‑ eller media‑platshållare som [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/). Det identifierar även platshållaren efter syfte i stället för att förlita sig på ett bräckligt formindex.

## **Ställ in hjälpträknare på en layout**

Hjälpträknare är den design‑tid‑instruktion som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ställ in anpassad hjälpträknare på layout‑platshållaren i stället för att försöka nå den via en vanlig bilds form‑samling. Åtkomst till layouten sker via [Slide.getLayoutSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getLayoutSlide) och iterera över samlingen som returneras av [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getShapes).

Följande exempel ändrar titel‑ och undertitel‑hjälpträknare på den layout som används av den första bilden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hjälpträknare är inte normalt bildinnehåll. De är avsedda för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller riktigt innehåll visas hjälpträkaren inte längre. Att ändra en hjälpträknare ersätter inte befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/), ersätt bilden via [PictureFillFormat.getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#getPicture) och [Picture.setImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#setImage).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addPictureFrame) och ta bort den tomma platshållaren.

Nästa exempel stödjer båda fallen och sparar presentationen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ersättningen som skapats för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [Shape.getPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getPlaceholder) saknar en setter. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är väsentligt att behålla relationen till platshållaren, förbered och fyll i platshållaren i PowerPoint först och uppdatera sedan den resulterande [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/python-java/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållar‑metadata.

## **Arbeta med diagram‑ och innehållsplatshållare**

En ifylld diagram‑platshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/). Detta exempel hittar ett sådant diagram genom både platshållartyp och kör‑tidstyp, ändrar dess titel och sparar filen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En allmän innehållsplatshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholdertype/#Object). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts, inspektera den faktiska formtypen för att lära dig vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholdertype/#Media) eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides konverterar inte en tom [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/)‑platshållare till ett [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/) enbart genom att ändra [Placeholder.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/placeholder/#getType); typen kan inte ändras via API‑et. För att fylla ett tomt diagram‑ eller innehållsområde programmässigt, lägg till det behövda objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/python-java/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsbok‑data.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande end‑to‑end‑exempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar lämpligt innehåll och sparar utdata. Exemplet undviker medvetet att anta ett formindex eller att behandla varje platshållare som samma typ.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Vad är en grund‑platshållare?**

En grund‑platshållare är den motsvarande formen på layouten eller mastern som en annan platshållare ärver från. Använd [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getBasePlaceholder) för att hämta den. En vanlig lokal form returnerar `None` eftersom den inte är en del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller hjälpträknare via en layout, men befintligt titelinnehåll lagras på de vanliga bilderna. För att ersätta faktisk titeltext i hela en presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bild‑nummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd sidhuvuds‑ och sidfot‑hanterarna på lämplig bild, layout, master, anteckningar eller utdrags‑nivå. Se [Manage Presentation Header and Footer](/slides/sv/python-java/presentation-header-and-footer/) för kompletta exempel.