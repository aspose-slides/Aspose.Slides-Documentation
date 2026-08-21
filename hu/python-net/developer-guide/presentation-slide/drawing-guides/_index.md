---
title: Rajzolási segédvonalak kezelése prezentációkban Pythonban
linktitle: Rajzolási segédvonalak
type: docs
weight: 85
url: /hu/python-net/drawing-guides/
keywords:
- rajzolási segédvonal
- vízszintes segédvonal
- függőleges segédvonal
- igazítási segédvonal
- dia nézet
- mester dia
- elrendezési dia
- jegyzet mester
- előlap mester
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Adj hozzá, érj el és törölj vízszintes és függőleges rajzolási segédvonalakat PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

A rajzolási segédvonalak állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák következetes igazításában a PowerPoint‑ban történő prezentációszerkesztés során. Különösen akkor hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később kézi finomhangolás követ: az alkalmazás elmentheti ugyanazokat az igazítási segédleteket, amelyeket a szerzőknek követniük kell a tartalom hozzáadásakor vagy mozgatásakor.

A rajzolási segédvonalak szerkesztési segédeszközök, nem dia‑tartalom. Nem jelennek meg diavetítésben vagy a renderelt kimenetben. Az Aspose.Slides for Python via .NET a [IDrawingGuidesCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguidescollection/) felületen keresztül teszi elérhetővé őket. Egy segédvonalat a [IDrawingGuide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguide/) képviseli, és rendelkezik tájolással, pozícióval és színnel.

A pozíció pontban van megadva a megfelelő dia vagy mester bal‑felső sarkától számítva. A függőleges segédvonal vízszintes koordinátát használ, amely általában 0 és a dia szélessége között van. A vízszintes segédvonal függőleges koordinátát használ, amely általában 0 és a dia magassága között van.

## **Segédvonalak hozzáadása a dia nézethez**

Használd az [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) tulajdonságot a normál diák szerkesztése közben megjelenő segédvonalak kezeléséhez. Hívd meg a [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguidescollection/add/) metódust egy [Orientation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/orientation/) értékkel és egy pozícióval pontban.

Az alábbi példa egy függőleges segédvonalat ad a dia középpontja jobb oldalához, valamint egy vízszintes segédvonalat alatta:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Rajzolási segédvonalak elérése**

Az [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguidescollection/count/) tulajdonság és az indexer biztosítja a meglévő segédvonalak elérését. A [IDrawingGuide.orientation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguide/orientation/), a [IDrawingGuide.position](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguide/position/) és a [IDrawingGuide.color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguide/color/) tulajdonságok olvashatók és módosíthatók.

Az alábbi példa beolvassa a fent létrehozott prezentáció dia‑nézet segédvonalait:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Segédvonalak hozzáadása a mester és elrendezési diákhoz**

Egy dia mester és minden elrendezési diája saját rajzolási segédvonal‑gyűjteménnyel rendelkezhet. Használd az [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterslide/drawing_guides/) tulajdonságot egy mester diához, és az [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ilayoutslide/drawing_guides/) tulajdonságot egy elrendezési diához.

Az alábbi példa egy függőleges segédvonalat ad az első mester diához, valamint egy vízszintes segédvonalat az első elrendezési diához:

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

## **Segédvonalak hozzáadása a jegyzet‑ és előlap‑mesterekhez**

A jegyzet‑mesterek és az előlap‑mesterek is támogatják a rajzolási segédvonalakat. Használd az [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasternotesslide/drawing_guides/) és az [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) tulajdonságokat a gyűjteményeik eléréséhez. Ha egy prezentáció nem tartalmaz egy ilyen mestert, akkor az [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) vagy az [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) létrehozza az alapértelmezett mestert, és visszaadja azt.

Az alábbi példa egy vízszintes segédvonalat ad egy jegyzet‑mesterhez, valamint egy függőleges segédvonalat egy előlap‑mesterhez:

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

## **Rajzolási segédvonalak törlése**

Hívd meg a [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/idrawingguidescollection/clear/) metódust egy adott gyűjtemény minden segédvonalának eltávolításához. Egy gyűjtemény törlése nem érinti a másik hatókörben tárolt segédvonalakat.

Az alábbi példa törli a dia‑nézet segédvonalait, valamint az összes segédvonalat a dia‑mestereken, elrendezési diákon, a jegyzet‑mesteren és az előlap‑mesteren, anélkül hogy hiányzó mestereket hozna létre:

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

## **GYIK**

**Megjelennek a rajzolási segédvonalak diavetítésben vagy exportált képeken?**

Nem. A rajzolási segédvonalak szerkesztési segédeszközök, és nem jelennek meg a prezentáció tartalmaként.

**Hozzáadható-e egy rajzolási segédvonal közvetlenül egy egyedi normál diához?**

A normál diáknál az szerkesztési segédvonalak a prezentáció dia‑nézet tulajdonságaiban vannak tárolva. Külön gyűjtemények állnak rendelkezésre a dia‑mesterek, elrendezési diák, jegyzet‑mesterek és előlap‑mesterek számára.

**Milyen mértékegységet használnak a segédvonalak pozíciói?**

A pozíciók pontban vannak megadva, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciókat a bal él, a vízszintes pozíciókat a felső él alapján mérik.

**A rajzolási segédvonalak törlése eltávolítja-e a formákat vagy módosítja a dia‑tartalmat?**

Nem. A `clear` metódus csak a kiválasztott gyűjtemény segédvonalait távolítja el. A formák és egyéb dia‑tartalom változatlan marad.