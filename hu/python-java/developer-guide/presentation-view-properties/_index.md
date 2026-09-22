---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése Pythonon keresztül Java
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/python-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyszerű nézet
- osztóállapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához – állítsa be az elrendezéseket, a nagyítási szinteket és a megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi régióból áll: maga a dia, egy oldalsó tartalmi régió és egy alsó tartalmi régió. A normál nézet tulajdonságai leírják ezen tartalmi régiók elhelyezkedését. Ezek az információk lehetővé teszik az alkalmazás számára, hogy a nézet állapotát a fájlba mentse, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a prezentációt legutóbb mentették.

A [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódust hozzáadtuk, hogy hozzáférést biztosítson a prezentáció normál nézet tulajdonságaihoz.

A [NormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/) és a [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/) osztályok, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/) felsorolás került hozzáadásra.

## **A NormalViewProperties-ról**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) metódusok határozzák meg, hogy az alkalmazás megjelenítse‑e az ikonokat, ha a vázlat tartalmat a normál nézet bármely tartalmi régiójában jeleníti meg.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) metódusok határozzák meg, hogy a függőleges osztóvonal automatikusan minimalizált állapotba lépjen‑e, amikor az oldalsó régió elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) metódusok határozzák meg, hogy a felhasználó egy teljes ablakos egyetlen tartalmi régiót részesít‑e előnyben a három tartalmi régióval rendelkező szokásos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót megjeleníthet a teljes ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) metódusok határozzák meg, hogy a vízszintes vagy függőleges osztóvonal milyen állapotban jelenjen meg. A vízszintes osztóvonal elválasztja a diát a diát alatti tartalmi régiótól; a függőleges osztóvonal elválasztja a diát az oldalsó tartalmi régiótól. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) és a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) metódusok határozzák meg a normál nézet bal vagy felső diarégiójának méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Restored) értéket alkalmazzák a [getVerticalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) metódusokra.

## **A NormalViewProperties visszaállításáról**

Megadja a diarégió (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) leszármazottja, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) leszármazottja) méretét a normál nézetben, amikor a régió változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) metódus megadja a diarégió méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) leszármazottja, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) leszármazottja).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) metódus meghatározza, hogy az oldalsó tartalmi régió mérete kompenzálja‑e az új méretet az ablak átméretezésekor, amely a nézetet tartalmazza az alkalmazáson belül.

Az alábbi példa azt mutatja be, hogyan lehet elérni a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódust egy prezentációhoz.

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

    # A prezentáció nézet tulajdonságainak visszaállítása.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alapértelmezett nagyítási érték beállítása**

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Python via Java támogatja az alapértelmezett nagyítási érték beállítását, így a prezentáció megnyitásakor már alkalmazva van. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) beállításával érhető el a prezentációban. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getSlideViewProperties) valamint a [getNotesViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNotesViewProperties) programozottan konfigurálható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumban az Aspose.Slides‑ben.
{{% /alert %}}

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) értékét a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) számára.
1. Írja a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában a nagyítási értéket állítjuk be mind a dia nézethez, mind a jegyzet nézethez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # A prezentáció nézet tulajdonságainak beállítása.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Nagyítási százalék a dia nézethez.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Nagyítási százalék a jegyzet nézethez.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rácsállás beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) metódust a prezentáció teljes körű nézetbeállításainak eléréséhez. A [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getGridSpacing) és a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setGridSpacing) metódusok olvassák vagy módosítják a szerkesztő rácsának intervallumát. Ez a beállítás az egész prezentációra vonatkozik, nem egy adott diára. A rácsállás pontokban van megadva, ahol 72 pont egy hüvelyket jelent. Pozitív értéket használjon, ahogy az API dokumentáció előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja annak aktuális rácsállását, beállít egy negyed hüvelykes intervallumot, majd elmenti a módosított fájlt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A rács különbözik a [drawing guides](/slides/hu/python-java/drawing-guides/)-tól. A rácsállás egy szabályos intervallust szabályoz, míg a rajzolási segédvonalak egyedileg elhelyezett vízszintes vagy függőleges igazító vonalak. A segédvonalak hozzáadása, áthelyezése vagy törlése nem változtatja meg a rácsállást.

Mind a rács, mind a rajzolási segédvonalak szerkesztési segédeszközök. Nem jelennek meg diatartalomként PDF‑ben, képeken, SVG‑ben vagy diavetítésben. A rácsállás tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a néző vagy szerkesztő beállításaitól is függ.

## **GYIK**

**Miért nem látható a rács a prezentáció újranyitása után?**

A fájl tárolja a rácsállást, de a szerkesztő dönt arról, hogy a rács megjelenik‑e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**Megváltoztatja a rajzolási segédvonalak törlése a rácsállást?**

Nem. A rajzolási segédvonalak és a rácsállás egymástól független beállítások. A segédvonalak törlése nem módosítja a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a prezentáció egyes szakaszaihoz?**

A [View settings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) a prezentáció szintjén vannak definiálva ([Normal View](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), nem szakaszonként, így egyetlen paraméterkészlet érvényes a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és megosztottak. A megjelenítő alkalmazások figyelembe vehetik a felhasználói preferenciákat, de a fájl maga csak egy nézettulajdonság‑készletet tartalmaz.

**Készíthetek sablont előre definiált nézettulajdonságokkal, hogy az új prezentációk ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) a prezentáció szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle azonos kezdeti nézetkonfigurációval.