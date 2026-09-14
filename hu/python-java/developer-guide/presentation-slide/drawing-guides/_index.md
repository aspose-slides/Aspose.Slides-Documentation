---
title: Rajzoló segédvonalak kezelése prezentációkban Pythonban
linktitle: Rajzoló segédvonalak
type: docs
weight: 85
url: /hu/python-java/drawing-guides/
keywords:
- rajzoló segédvonal
- vízszintes segédvonal
- függőleges segédvonal
- igazítási segédvonal
- dia nézet
- mester dia
- elrendezési dia
- jegyzetmester
- előlapmester
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Horizontális és függőleges rajzoló segédvonalak hozzáadása, elérése és törlése PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

A rajzoló segédvonalak állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák következetes igazításában a PowerPoint prezentáció szerkesztése közben. Különösen hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később manuálisan finomítanak: az alkalmazás elmentheti ugyanazokat az igazítási segédeszközöket, amelyeket a szerzőknek követniük kell a tartalom hozzáadása vagy áthelyezése során.

A rajzoló segédvonalak szerkesztési segédeszközök, nem dia tartalom. Nem jelennek meg diavetítésben vagy a megjelenített kimenetben. Az Aspose.Slides for Python via Java a [DrawingGuidesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguidescollection/) osztályon keresztül teszi elérhetővé őket. Egy segédvonalat a [DrawingGuide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguide/) reprezentálja, és rendelkezik orientációval, pozícióval és színnel.

A pozíciót pontban mérik a szóban forgó dia vagy mester bal felső sarkától. A függőleges segédvonal vízszintes koordinátát használ, általában 0 és a dia szélessége között. A vízszintes segédvonal függőleges koordinátát használ, általában 0 és a dia magassága között.

## **Segédvonalak hozzáadása a Dia nézethez**

A [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) használatával kezelhetők a normál diák szerkesztése közben megjelenő segédvonalak. Hívja meg a [DrawingGuidesCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguidescollection/#add) metódust egy [Orientation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/orientation/) értékkel és egy pontban megadott pozícióval.

A következő példa egy függőleges segédvonalat ad a dia középpontjának jobb oldalához, és egy vízszintes segédvonalat alá:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Segédvonalak elérése**

A [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguidescollection/#getCount) és a [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguidescollection/#get_Item) metódusok hozzáférést biztosítanak a meglévő segédvonalakhoz. A [DrawingGuide.getOrientation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguide/#getOrientation), a [DrawingGuide.getPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguide/#getPosition) és a [DrawingGuide.getColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguide/#getColor) metódusok értékeket adnak vissza, amelyeket a megfelelő beállító metódusokkal is módosíthat.

A következő példa beolvassa a dia-nézet segédvonalait a fent létrehozott prezentációból:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Segédvonalak hozzáadása a mester- és elrendezési diákhoz**

A diamester és annak minden elrendezési diája saját rajzoló segédvonal-gyűjteménnyel rendelkezhet. Használja a [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getDrawingGuides) metódust egy mesterdiához, és a [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/#getDrawingGuides) metódust egy elrendezési diához.

A következő példa egy függőleges segédvonalat ad az első mesterdiához és egy vízszintes segédvonalat az első elrendezési diához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Segédvonalak hozzáadása a jegyzet- és előlapmesterekhez**

A jegyzetmesterek és előlapmesterek is támogatják a rajzoló segédvonalakat. Használja a [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslide/#getDrawingGuides) és a [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) metódusokat a gyűjtemények eléréséhez. Ha a prezentáció nem tartalmazza ezeket a mestereket, a `MasterNotesSlideManager.setDefaultMasterNotesSlide` vagy a `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` létrehozza az alapértelmezett mestert és visszaadja azt.

A következő példa egy vízszintes segédvonalat ad egy jegyzetmesterhez és egy függőleges segédvonalat egy előlapmesterhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rajzoló segédvonalak törlése**

Hívja meg a [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguidescollection/#clear) metódust, hogy eltávolítsa az összes segédvonalat egy adott gyűjteményből. Egy gyűjtemény törlése nem befolyásolja a másik tartományban tárolt segédvonalakat.

A következő példa törli a dia-nézet segédvonalait és az összes segédvonalat a diamestereken, elrendezési diákon, a jegyzetmesteren és az előlapmesteren, anélkül hogy hiányzó mestereket hozna létre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Megjelennek a rajzoló segédvonalak diavetítésben vagy exportált képeken?**

Nincs. A rajzoló segédvonalak szerkesztési igazítási segédeszközök, és nem jelennek meg a prezentáció tartalmaként.

**Hozzáadható a rajzoló segédvonal közvetlenül egy egyedi normál diához?**

A normál dia szerkesztési segédvonalai a prezentáció dia-nézet tulajdonságaiban tárolódnak. Külön segédvonal-gyűjtemények érhetők el a diamesterekhez, elrendezési diákhoz, jegyzetmesterekhez és előlapmesterekhez.

**Milyen egységeket használnak a segédvonalak pozícióihoz?**

A pozíciók pontban vannak megadva, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciók a bal szélről, a vízszintes pozíciók a felső szélről mérődnek.

**A rajzoló segédvonalak törlése eltávolítja a formákat vagy megváltoztatja a dia tartalmát?**

Nincs. A [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/drawingguidescollection/#clear) metódus csak a kiválasztott gyűjtemény segédvonalait távolítja el. A formák és egyéb dia tartalom változatlan marad.