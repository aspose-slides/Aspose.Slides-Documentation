---
title: Dia mesterek kezelése a prezentációkban Pythonon keresztül Java-val
linktitle: Dia mester
type: docs
weight: 70
url: /hu/python-java/slide-master/
keywords:
- dia mester
- mester dia
- PPT mester dia
- több mester dia
- mester diák összehasonlítása
- háttér
- helyőrző
- mester dia klónozása
- mester dia másolása
- mester dia duplikálása
- használaton kívüli mester dia
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Dia mesterek kezelése az Aspose.Slides for Python via Java segítségével: mester diák elérése, szerkesztése, klónozása, összehasonlítása és eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **dia mester** közös tervezési beállításokat határoz meg egy diákkészlet számára. Tartalmazhat közös alakzatokat, logókat, háttérképeket, szövegstílusokat, téma beállításokat és lábléc beállításokat. PowerPointban a dia mester szerkesztése a szokásos módja annak, hogy a bemutató következetes legyen anélkül, hogy minden dián megismételné a formázást.

Aspose.Slides for Python via Java támogatja ugyanazt a modellt. Egy bemutató egy vagy több mesterdiát tartalmazhat, és minden mesterdia több elrendezés diát is tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy mesterdiára. Ehelyett egy normál dia egy elrendezés diát használ, amely egy mesterdiához tartozik.

A hierarchia:

1. **Dia mester** – meghatározza a közös tervezést és témát.
1. **Elrendezés dia** – meghatároz egy adott helyőrző- és elrendezési szintű formázást.
1. **Normál dia** – a tényleges bemutatótartalmat tartalmazza, és egy elrendezés diát használ.

![A mesterdiák, elrendezésdiák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ban egy dia mestert a [MasterSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/) osztály képviseli. A bemutató összes mesterdiája a [Presentation.getMasters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasters) gyűjteményen keresztül érhető el, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/) valósít meg.

{{% alert color="info" title="Inheritance" %}}

Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyeri el a hatalmat. Például ha egy mesterdia és egy elrendezés dia is meghatároz egy háttérképet, akkor a diagramok, amelyek ezen elrendezésen alapulnak, az elrendezés háttérjét használják. Az elrendezés diákról további információkért lásd a [Alkalmazza vagy módosítsa a diaelrendezéseket](/slides/hu/python-java/slide-layout/) oldalt.

{{% /alert %}}

## **Dia mesterek elérése**

PowerPointban a **Nézet** > **Dia mester** menüponttal nyithatja meg a Dia mester nézetet.

![A Dia mester parancs a PowerPoint Nézet lapon](slide-master_3.jpg)

Az Aspose.Slides-ban a [Presentation.getMasters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasters) gyűjteményt kell használni a mesterdiák eléréséhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

A normál dia által használt mesterdiát a saját elrendezésén keresztül is lekérheti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Mi van egy dia mesterben**

A mesterdia egy dia-szerű objektum. A [BaseSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/) osztályból származik, így sok olyan dia‑tulajdonságot is elér, amelyet a normál és elrendezés diák is használnak. A mesterspecifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/) API‑oldalon vannak felsorolva.

A gyakran használt mesterdiához tartozó tagok:

| Tag | Leírás |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getBackground) | Beállítja a mester‑szintű dia háttérképet. |
| [getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getShapes) | Tárolja a mesterre helyezett alakzatokat, például logókat, képkockákat és megosztott szöveget. |
| [getLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getLayoutSlides) | Tárolja a mesterhez tartozó elrendezés diákot. |
| [getThemeManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getThemeManager) | Hozzáférést biztosít a mester téma API‑khoz. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Kezeli a fejléc, lábléc, dátum és dia számot a mester és gyermek elrendezései számára. |
| [getDependingSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/#getDependingSlides) | Visszaadja a normál diákot, amelyek a mesteren keresztül függnek az elrendezéseiktől. |

## **Kép hozzáadása egy dia mesterhez**

Amikor képet ad hozzá egy mesterdiához, az a mesterhez tartozó elrendezéseket használó diákon jelenik meg. Ez hasznos logók, vízjelek, díszszalagok és egyéb ismétlődő vizuális elemek esetén.

Az alábbi példa egy logót ad az első mesterdiához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A képkockákról további információkért lásd a [Képkocka](/slides/hu/python-java/picture-frame/) oldalt.

## **Munkavégzés helyőrzőkkel**

A helyőrzőket általában az elrendezés diákon definiálják. A mesterdia biztosítja a megosztott stílust és témát, amelyet az elrendezések örökölnek, míg minden elrendezés dönt arról, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrző parancsok a Dia mester nézetben érhetők el.

![A Helyőrző beszúrása parancs a PowerPoint Dia mester nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides‑ban dolgozzon az adott mesterhez tartozó elrendezés diával:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Meglévő helyőrző alakzatok formázása is lehetséges egy mesterdián. Az alábbi példa megtalálja a cím helyőrzőt, és lineáris színátmenetes kitöltést alkalmaz rá:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző és szövegformázási lehetőségekért lásd a [Állítsa be a helyőrző szövegét](/slides/hu/python-java/manage-placeholder/) és a [Szövegformázás](/slides/hu/python-java/text-formatting/) oldalakat.

## **Dia mester háttér módosítása**

A mester háttér öröklődik az elrendezések és azok a diák számára, amelyek nem felülírják azt. Az alábbi példa szilárd háttérszínt állít be az első mesterdiára:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kapcsolódó témák: [Prezentáció háttér](/slides/hu/python-java/presentation-background/) és [Prezentáció téma](/slides/hu/python-java/presentation-theme/).

## **Dia mester klónozása egy másik bemutatóba**

Használja a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/#addClone) metódust, hogy egy mesterdiát másik bemutatóba másoljon. A másolt mester ezután felhasználható az elrendezések és diák számára a célbemutatóban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Ha normál diákot is klónozni szeretne a mesterével együtt, lásd a [Diák klónozása](/slides/hu/python-java/clone-slides/) oldalt.

## **Több dia mester hozzáadása**

Egy bemutató több mesterdiát is tartalmazhat. Ez akkor hasznos, ha a bemutató különböző részei különböző márkázást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok a mesterdiák beszúrásához és kezeléséhez](slide-master_9.jpg)

Az alábbi példa a alapértelmezett mestert klónozza, a klónnak más háttérszínt ad, egy elrendezést hoz létre a klónozott mester alatt, és egy új diát ad hozzá ehhez az elrendezéshez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dia mesterek összehasonlítása**

A mesterdiák összehasonlíthatók a [equals](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#equals) metódussal, amelyet a [BaseSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/) osztály örököl. Az összehasonlítás a struktúrát és a statikus tartalmat vizsgálja, például alakzatokat, szöveget, formázást, animációkat és egyéb dia‑beállításokat. Nem hasonlítja össze az egyedi azonosítókat, mint a dia‑ID‑k, vagy a dinamikus helyőrzőértékeket, mint az aktuális dátum.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

További információkért lásd a [Prezentáció diák összehasonlítása](/slides/hu/python-java/compare-slides/) oldalt.

## **Dia mester nézet beállítása alapértelmezett nézetként**

Használja a [setLastView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) osztályon, hogy szabályozza, melyik nézetet nyissa meg a PowerPoint először. Az alábbi példa a bemutatót a Dia mester nézetben nyitja meg:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

További nézetbeállításokért lásd a [Prezentáció mentése](/slides/hu/python-java/save-presentation/) oldalt.

## **Használaton kívüli mesterdiák eltávolítása**

A bemutatók néha tartalmaznak olyan mesterdiákat, amelyeket már egyetlen normál dia sem használ. A használaton kívüli mesterek eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablon karbantartását.

Használja a [removeUnused](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/#removeUnused) metódust a [Presentation.getMasters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasters) gyűjteményből való használaton kívüli mesterek eltávolításához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alacsony kódú [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedMasterSlides) metódus is használható:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mi a különbség egy dia mester és egy elrendezés dia között?**

Egy dia mester közös tervezési beállításokat definiál, például téma, háttér, közös alakzatok és szövegstílusok. Egy elrendezés dia egy mesterdiához tartozik, és egy adott helyőrző‑elrendezést határoz meg. Egy normál dia egy elrendezés diát használ, ezért örökli az elrendezés és a mester beállításait.

**Tartalmazhat-e egy bemutató több dia mestert?**

Igen. Egy bemutató több dia mestert is tartalmazhat. Használjon több mestert, ha a különböző részeknek különböző vizuális rendszerekre vagy márkázásra van szüksége.

**Hol kell helyőrzőket elhelyezni, a mesterdián vagy az elrendezés dián?**

A legtöbb esetben az elrendezés diákra kell helyőrzőket tenni. A megosztott vizuális elemeket és a közös formázást tegye a mesterdiára, majd a tartalomhelyőrzőket a normál diák által használt elrendezésekre helyezze.

**Törölhetek-e egy még használt mesterdiát?**

Nem. Egy olyan mesterdia, amelynek függő diái vannak, nem távolítható el biztonságosan közvetlenül. Először helyezze át ezeket a diákat egy másik mester alatti elrendezésekbe, vagy használjon olyan „nem használt‑mester” takarítási módszert, amely csak a nem használt mestereket távolítja el.