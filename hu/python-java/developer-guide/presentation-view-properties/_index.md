---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése Pythonon keresztül Java-val
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/python-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó snap
- egyetlen nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához – módosítsa az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: a diából, egy oldalsó tartalmi régióból és egy alsó tartalmi régióból. A normál nézet tulajdonságai leírják ezen tartalmi régiók elhelyezkedését. Ez az információ lehetővé teszi, hogy az alkalmazás elmentse a nézetállapotát a fájlba, így újranyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt az utolsó alkalommal mentették.

A [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódus hozzá lett adva, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.

A [NormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/) és a [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/) osztályok, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/) felsorolás lett hozzáadva.

## **A NormalViewProperties leírása**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) metódusok meghatározzák, hogy az alkalmazás ikonokat jelenítsen-e meg, ha a vázlat tartalmat bármelyik tartalmi régióban a normál nézet módban jeleníti meg.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) metódusok meghatározzák, hogy a függőleges elválasztó sáv minimalizált állapotba snap-eljen-e, ha az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) metódusok meghatározzák, hogy a felhasználó egy teljesablakos egyetlen tartalmi régiót részesít-e előnyben a három tartalmi régióval rendelkező szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót jeleníthet meg az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) metódusok meghatározzák, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban jelenjen meg. A vízszintes elválasztó sáv elválasztja a diát a diát alatti tartalmi régiótól; a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) és a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) metódusok meghatározzák a normál nézet felső vagy oldalsó diarégiójának méretezését, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Restored) értéket alkalmazzák a [getVerticalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) metódusokra.

## **A NormalViewProperties visszaállításának leírása**

Meghatározza a diarégió (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) gyermekeként jelenik meg; magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) gyermekeként jelenik meg) méretét a normál nézetben, amikor a régió változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) metódus meghatározza a diarégió méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) gyermekeként jelenik meg; magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) gyermekeként jelenik meg).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja-e az új méretet, amikor az alkalmazáson belül a nézetet tartalmazó ablakot átméretezik.

Az alábbi példa bemutatja, hogyan lehet elérni a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódust egy prezentációhoz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Állítsa vissza a prezentáció nézet tulajdonságait.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az alapértelmezett nagyítási érték beállítása**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java támogatja az alapértelmezett nagyítási érték beállítását, így a prezentáció megnyitásakor már alkalmazva van. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) beállításával valósítható meg egy prezentációban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getSlideViewProperties) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNotesViewProperties) programozottan konfigurálható. Ebben a témában egy példán keresztül megmutatjuk, hogyan kell beállítani a [View Properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) értékét a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) esetében az [Aspose.Slides](/slides/hu/) segítségével.
{{% /alert %}}

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) értékét a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) számára.
1. Mentse a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában mind a dianézet, mind a jegyzet nézet nagyítási értékét beállítjuk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Állítsa be a prezentáció nézet tulajdonságait.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Nagyítási százalék a dianézethez.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Nagyítási százalék a jegyzet nézethez.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Beállíthatok-e különböző nézetbeállításokat egy prezentáció különböző részeihez?**

A [View settings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), nem szakaszonként, ezért egyetlen paraméterkészlet vonatkozik a teljes dokumentumra megnyitáskor.

**Előre definiálhatok-e különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl önmagában egyetlen nézettulajdonság-készletet tartalmaz.

**Készíthetek-e sablont előre definiált View Properties értékekkel, hogy az új prezentációk ugyanígy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) a prezentáció szintjén tárolódnak, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kezdeti nézetkonfigurációval.