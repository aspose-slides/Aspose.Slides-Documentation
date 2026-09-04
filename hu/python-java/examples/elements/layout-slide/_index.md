---
title: Elrendezésdia
type: docs
weight: 20
url: /hu/python-java/examples/elements/layout-slide/
keywords:
- kódrészlet
- elrendezésdia
- elrendezésdia hozzáadása
- elrendezésdia elérése
- elrendezésdia eltávolítása
- nem használt elrendezésdia
- elrendezésdia klónozása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Kezelje az elrendezésdiókat az Aspose.Slides for Python via Java segítségével: adjon hozzá, érjen el, távolítson el, tisztítsa meg, és klónozza az elrendezéseket PowerPoint és OpenDocument prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet **elrendezésdiák** használni az Aspose.Slides for Python via Java segítségével. Egy elrendezésdia meghatározza a normál diák által öröklött tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezésdiókat, valamint megtisztíthatja a nem használtakat a prezentáció méretének csökkentése érdekében.

Telepítse a csomagot a [Telepítés](/slides/hu/python-java/installation/) leírása szerint. Minden példa importálja a `asposeslides`‑t a JVM indítása előtt, majd a JVM futása közben importálja az API‑t.

## **Elrendezésdia hozzáadása**

Hozzon létre egy egyedi elrendezésdát a újrahasználható formázás meghatározásához. A következő példa egy szövegdobozt ad egy új elrendezéshez, majd két olyan diát hoz létre, amely használja azt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Hozzon létre egy elrendezésdát üres elrendezéstípussal és egy egyéni névvel.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Szövegdobozt ad az elrendezésdiához.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Két diát ad hozzá, amelyek az elrendezés szövegét öröklik.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Megjegyzés 1:** Az elrendezésdiák sablonként szolgálnak az egyes diákhoz. Egyszer definiálhatja a közös elemeket, és újra felhasználhatja őket sok diában.

> 💡 **Megjegyzés 2:** Amikor alakzatokat vagy szöveget ad hozzá egy elrendezésdiahoz, az azon alapuló összes dia automatikusan megjeleníti a közös tartalmat.
> Az alábbi képernyőkép két olyan diát mutat, amelyek egy szövegdobozt örökölnek ugyanabból az elrendezésdíából.

![Diák öröklő elrendezési tartalom](layout-slide-result.png)

## **Elrendezésdia elérése**

A elrendezésdiók elérhetők index vagy elrendezéstípus szerint, például üres, cím vagy szekciófejléc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Hozzáférés egy elrendezésdiához index szerint.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Hozzáférés egy elrendezésdiához típus szerint.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Elrendezésdia eltávolítása**

Távolítson el egy adott elrendezésdát, ha már nincs rá szükség.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Nem használt elrendezésdiák eltávolítása**

Távolítsa el azokat az elrendezésdiókat, amelyeket egyetlen normál dia sem használ, a prezentáció méretének csökkentése érdekében.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Elrendezésdia klónozása**

Másolja meg egy elrendezésdát, és adja hozzá a másolatot az elrendezésdiák gyűjteményének végéhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Összegzés:** Az elrendezésdiák segítenek egységes formázás fenntartásában egy prezentáció során. Az Aspose.Slides lehetővé teszi, hogy szükség szerint létrehozza, kezelje, újra használja és megtisztítsa az elrendezéseket.