---
title: Prezentáció nagyításának kezelése Pythonban Java-n keresztül
linktitle: Zoom kezelése
type: docs
weight: 60
url: /hu/python-java/manage-zoom/
keywords:
- nagyítás
- nagyítási keret
- dia nagyítás
- szakasz nagyítás
- összefoglaló nagyítás
- nagyítás hozzáadása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Hozzon létre és testreszabjon nagyításokat az Aspose.Slides for Python via Java segítségével — ugorjon szakaszok között, adjon hozzá bélyegképeket és átmeneteket a PowerPoint prezentációkba."
---
## **Bevezetés**

A PowerPoint nagyítások lehetővé teszik, hogy egy diavetítés során adott diák és szakaszok között navigáljon. Az Aspose.Slides for Python via Java használatával létrehozhat dia-, szakasz- és összefoglaló nagyításokat, valamint testreszabhatja azok előnézeteit, szegélyeit és átmeneteit.

![PowerPoint nagyítás áttekintés](overview.png)

* Az egész bemutató egyetlen dián történő összegzéséhez használja a [Összefoglaló nagyítást](#summary-zoom).
* Kiválasztott diák megjelenítéséhez használja a [Dia nagyítást](#slide-zoom).
* Egyetlen szakasz megjelenítéséhez használja a [Szakasz nagyítást](#section-zoom).

## **Dia nagyítás**

A dia nagyítás dinamikusabbá teheti a bemutatót, lehetővé téve, hogy szabadon navigáljon a diák között bármilyen sorrendben, anélkül, hogy megszakítaná a bemutató folyamatát. A dia nagyítások ideálisak rövid, kevés szakaszt tartalmazó prezentációkhoz, de más bemutatási forgatókönyvekben is alkalmazhatók.

A dia nagyítások lehetővé teszik, hogy egyetlen áttekintő diáról kapcsolódó információkat fedezzen fel.

![Dia nagyításra kiválasztott diák](slidezoomsel.png)

Dia nagyítás objektumokhoz az Aspose.Slides a [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) felsorolást, a [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) osztályt és a [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) osztály metódusait biztosítja.

### **Nagyítási keretek létrehozása**

Használja a [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) metódust, hogy egy áttekintő dián egyedi diákra mutató hivatkozásokat helyezzen el. Ez a példa két különálló háttérrel és felirattal rendelkező céldiát hoz létre, majd mindkettő előnézetét hozzáadja az első diához, és PPTX formátumban menti a bemutatót. A keret pozíciója és mérete pontokban van megadva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nagyítási keretek létrehozása egyéni képekkel**

Adjon meg egy egyéni képet a [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) metódusnak, hogy lecserélje a céldia alapértelmezett előnézetét. Ez a példa egy helyi képet igényel, amelyet a [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) metódussal tölt be, majd a [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) segítségével hozzáadja a bemutatóhoz. Az eredményül kapott keret ezt a képet jeleníti meg, miközben a második diára mutat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nagyítási keretek formázása**

Ez a példa két dia nagyítási keretet testreszab. Az első kerethez egy helyi képet rendel a [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) metódussal, a második keretnek pedig egy öt pont vastag, szaggatott-pontozott rózsaszín szegélyt ad a [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) segítségével. A [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) `False` értékre állítása elrejti a második keret háttérét. Egy helyi kép szükséges az egyéni előnézethez; mindkét keret megtartja a céldiákat a mentett PPTX-ben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szakasz nagyítás**

A szakasz nagyítás egy szakaszra hivatkozik a bemutatóban. Használja, hogy visszatérjen egy témához vagy megmutassa, hogyan kapcsolódnak egymáshoz a bemutató különböző részei.

![Szakasz kiválasztása szakasz nagyításhoz](seczoomsel.png)

Szakasz nagyítás objektumokhoz az Aspose.Slides a [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) osztályt és a [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) osztály metódusait biztosítja.

### **Szakasz nagyítási keretek létrehozása**

Hozzon létre egy szakaszt a [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) metódussal, majd adja át a visszakapott szakaszt a [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) metódusnak. Ez a példa egy szakasz nagyítást helyez el az első dián, amely egy színes diával kezdődő szakaszra mutat. A keret pozíciója és mérete pontokban van megadva, a bemutató PPTX‑ként kerül mentésre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Szakasz nagyítási keretek létrehozása egyéni képekkel**

A [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) képoverloadja lehetővé teszi egy egyéni előnézet megjelenítését a cél szakasz megváltoztatása nélkül. Ez a példa egy helyi képet igényel, amelyet a [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) betölt, majd a [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) hozzáad a bemutatóhoz. A mentett bemutató az első dián egy szakasz nagyítást tartalmaz, amely az újonnan létrehozott szakaszra hivatkozik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Szakasz nagyítás cél szakaszának módosítása**

Használja a [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) metódust, hogy egy meglévő szakasz nagyítást átirányítson anélkül, hogy újra létrehozná. Válasszon egy feltöltött szakaszt ugyanabból a bemutatóból a [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) gyűjteményből. Egy üres szakasz megadása nem változtatja meg a jelenlegi célt, ezért a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) ellenőrzése ajánlott a hozzárendelés előtt. További információért a szakaszokról lásd a [Szakaszok kezelése](/slides/hu/python-java/slide-section/) oldalt.

Az alábbi példa betölt egy bemutató fájlt, amelynek több feltöltött szakaszt kell tartalmaznia, egy már létező `Section navigation` nevű szakasz nagyítással és egy `Results` egyedi névű szakaszzal. A nagyítást minden dián megkeresi, és a név alapján találja meg a célt, ahelyett, hogy a gyűjtemény indexét használná, amely a szakaszok átrendezésekor változhat. Ha a nevek nem egyediek, használja a [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) metódust a cél azonosításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Szakasz nagyítási keretek formázása**

Ez a példa a szakasz nagyítást 100 × 75 pont méretre átméretezi, egy helyi képet rendel a [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) metódussal, és egy 2,5 pont vastag, szaggatott-pontozott barna szegélyt alkalmaz. Engedélyezi a [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) metódussal, hogy a szakasz után visszatérjen a kiinduló diára, letiltja a [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) használatát, és a [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) értékét 1,5 másodpercre állítja. Egy helyi kép szükséges az egyéni előnézethez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Összefoglaló nagyítás**

Az összefoglaló nagyítás áttekintést nyújt a bemutató szakaszairól. Diavetítés közben használhatja, hogy egy szakaszra ugorjon, előre lépjen, vagy visszatérjen egy témához anélkül, hogy a diákat sorban követné.

![Szakaszok kiválasztása összefoglaló nagyításhoz](sumzoomsel.png)

Összefoglaló nagyítás objektumokhoz az Aspose.Slides a [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), a [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) és a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) osztályokat, valamint a [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) metódusait biztosítja.

### **Összefoglaló nagyítás létrehozása**

Használja a [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) metódust, hogy a bemutató szakaszainak áttekintését hozza létre. Ez a példa négy szakaszt hoz létre különböző diák háttérrel, majd egy összefoglaló nagyítást ad az első diához. A keret pozíciója és mérete pontokban van megadva, az áttekintés PPTX‑ként kerül mentésre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Összefoglaló nagyítás szakasz hozzáadása és eltávolítása**

Az összefoglaló nagyítás a [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) objektumait a [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) tárolja. Ez a példa egy két szakaszból álló áttekintést hoz létre, egy harmadik szakaszt ad hozzá a [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) metódussal, majd az első szakasz bejegyzését eltávolítja a [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) segítségével. Az eltávolítás után a bemutató szakasza és diái érintetlenek maradnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Összefoglaló nagyítás szakaszok formázása**

Ez a példa a [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) első bejegyzését (nulla‑alapú index `0`) formázza. Egy helyi képet igényel a [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) metódus, 1,5 pont vastag, szaggatott-pontozott fekete szegélyt alkalmaz, és a [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) értékét 1,5 másodpercre állítja. A [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) `False` értékre állítása letiltja az automatikus visszatérést az összefoglaló diára a bejegyzésnél.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Vissza tudom irányítani a “szülő” diára a cél megjelenítése után?**

Igen. Hívja a [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) metódust `True` értékkel, hogy a cél tartalom megjelenítése után visszatérjen a kiinduló diára.

**Módosíthatom a nagyítási átmenet „sebességét” vagy időtartamát?**

Igen. Használja a [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) metódust a másodpercben megadott átmeneti idő szabályozásához.

**Van korlátozás arra, hány nagyítási objektumot tartalmazhat egy bemutató?**

Nincs dokumentált szigorú API‑korlát. A gyakorlati korlátok a bemutató összetettségétől és a megjelenítő teljesítményétől függenek. Sok nagyítási keretet hozzáadhat, de vegye figyelembe a fájlméretet és a renderelési időt.