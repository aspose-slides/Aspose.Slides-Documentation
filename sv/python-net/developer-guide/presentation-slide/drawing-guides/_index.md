---
title: Hantera ritningshjälplinjer i presentationer i Python
linktitle: Ritningshjälplinjer
type: docs
weight: 85
url: /sv/python-net/drawing-guides/
keywords:
- ritningshjälplinje
- horisontell hjälplinje
- vertikal hjälplinje
- justeringshjälplinje
- bildvy
- masterbild
- layoutbild
- noteringsmaster
- handout-master
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lägg till, hämta och rensa horisontella och vertikala ritningshjälplinjer i PowerPoint-presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Ritningshjälplinjer är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent när de redigerar en presentation i PowerPoint. De är särskilt användbara när ett program genererar en presentation som senare ska finjusteras manuellt: programmet kan spara samma justeringshjälpmedel som författare ska följa när de lägger till eller flyttar innehåll.

Ritningshjälplinjer är redigeringshjälpmedel, inte bildinnehåll. De visas inte i en bildspelsvisning eller i renderad output. Aspose.Slides för Python via .NET exponerar dem via gränssnittet [IDrawingGuidesCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguidescollection/) . En hjälplinje representeras av [IDrawingGuide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet av den aktuella bilden eller masteren. En vertikal hjälplinje använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell hjälplinje använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till hjälplinjer i bildvyn**

Använd [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) för att hantera hjälplinjer som visas när du redigerar vanliga bilder. Anropa [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguidescollection/add/) med ett [Orientation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal hjälplinje till höger om bildens centrum och en horisontell hjälplinje under den:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till ritningshjälplinjer**

Egenskapen [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguidescollection/count/) och indexeraren ger åtkomst till befintliga hjälplinjer. Egenskaperna [IDrawingGuide.orientation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguide/position/) och [IDrawingGuide.color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguide/color/) kan läsas eller ändras.

Följande exempel läser bildvynshjälplinjerna från presentationen som skapades ovan:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Lägg till hjälplinjer till master‑ och layoutbilder**

En slide‑master och var och en av dess layoutbilder kan ha egna samlingar av ritningshjälplinjer. Använd [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterslide/drawing_guides/) för en master‑bild och [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ilayoutslide/drawing_guides/) för en layout‑bild.

Följande exempel lägger till en vertikal hjälplinje till den första master‑bilden och en horisontell hjälplinje till den första layout‑bilden:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till hjälplinjer till antecknings‑ och handout‑masters**

Antecknings‑masters och handout‑masters stöder också ritningshjälplinjer. Använd [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasternotesslide/drawing_guides/) och [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) för att få åtkomst till deras samlingar. Om en presentation inte innehåller någon av dessa masters, skapar [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) eller [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) standard‑masteren och returnerar den.

Följande exempel lägger till en horisontell hjälplinje till en antecknings‑master och en vertikal hjälplinje till en handout‑master:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Rensa ritningshjälplinjer**

Anropa [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/idrawingguidescollection/clear/) för att ta bort alla hjälplinjer från en viss samling. Att rensa en samling påverkar inte hjälplinjer som lagras i en annan omfattning.

Följande exempel rensar bildvynshjälplinjerna och alla hjälplinjer på slide‑masters, layout‑bilder, antecknings‑mastern och handout‑mastern utan att skapa saknade masters:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Visas ritningshjälplinjer i ett bildspel eller exporterade bilder?**

Nej. Ritningshjälplinjer är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningshjälplinje läggas till direkt på en enskild normalbild?**

Redigeringshjälplinjer för normalbilder lagras i presentationens bildvynsegenskaper. Separata hjälplinjessamlingar finns för slide‑masters, layout‑bilder, antecknings‑masters och handout‑masters.

**Vilka enheter används för hjälplinje‑positioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänster kant och horisontella positioner mäts från övre kanten.

**Tar rensning av ritningshjälplinjer bort former eller ändrar bildinnehållet?**

Nej. Metoden `clear` tar endast bort hjälplinjerna i den valda samlingen. Former och annat bildinnehåll förblir oförändrat.