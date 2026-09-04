---
title: Mester dia
type: docs
weight: 30
url: /hu/python-java/examples/elements/master-slide/
keywords:
- kód példa
- mester dia
- mester dia hozzáadása
- mester dia elérése
- mester dia eltávolítása
- használaton kívüli mester dia
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Kezeld a mester diákat az Aspose.Slides for Python via Java segítségével: hozd létre, érjed el, távolítsd el, és tisztítsd meg a mestereket PowerPoint és OpenDocument prezentációkban."
---
A master slide-ek a PowerPoint diátekörök öröklési hierarchiájának legfelső szintjét alkotják. Egy **master slide** meghatározza a közös tervezési elemeket, mint például a háttér, a logók és a szövegformázás. **Layout slides** öröklődnek a master slide-ekből, és a **normal slides** öröklődnek a layout slide-ekből.

Ez a cikk bemutatja, hogyan hozhatunk létre, módosíthatunk és kezelhetünk master slide-eket a **Aspose.Slides for Python via Java** segítségével.

Telepítsd a csomagot a [Installation](/slides/hu/python-java/installation/) leírása szerint. Minden példa importálja a `asposeslides`-t a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **Mesterdia hozzáadása**

Ez a példa azt mutatja be, hogyan hozhatunk létre egy új master slide-et az alapértelmezett klónozásával. Ezután egy cégnév‑banner-t ad hozzá az összes diára az elrendezés öröklése révén.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Klónozza az alapértelmezett master diát.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Banner hozzáadása a cég nevével a master dia tetejére.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Az új master diát egy elrendezési diára rendeljük.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Az elrendezési diát a prezentáció első diához rendeljük.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
A master slide-ek lehetővé teszik a konzisztens márkázás vagy a megosztott tervezési elemek alkalmazását az összes dián. A masterben végzett módosítások automatikusan megjelennek a függő elrendezés‑ és normál diákon.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
A master slide-hez hozzáadott alakzatok és formázások öröklődnek az layout slide-ekre, és továbbadódnak az azokat használó normál diákra is. Az alábbi kép bemutatja, hogyan jelenik meg automatikusan egy master slide-re felvett szövegdoboz a végső dián.
{{% /alert %}}

![Mesteröröklés példa](master-slide-banner.png)

## **Mesterdia elérése**

A master slide-eket a prezentáció master gyűjteményén keresztül érheted el. Ez a példa lekéri az első master slide-et és megváltoztatja a háttértípusát.

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Mesterdia eltávolítása**

A master slide-et index vagy hivatkozás alapján is eltávolíthatod, miután már nem használják. Ez a példa egy klónozott master slide-et rendeli a prezentációhoz, majd eltávolítja az eredeti mastert index alapján.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Távolítsa el a nem használt eredeti master diát index alapján.
    # Alternatív megoldásként távolítsa el a nem használt master diát hivatkozás alapján:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Használaton kívüli master slide-ek eltávolítása**

Néhány prezentáció olyan master slide-eket tartalmaz, amelyeket nem használnak. Ezeknek a diák eltávolítása segíthet csökkenteni a fájl méretét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Távolítsa el az összes nem használt master diát, beleértve a Preserve‑ként megjelölt diákat.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```