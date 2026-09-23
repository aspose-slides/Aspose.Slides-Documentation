---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése Pythonnal Java segítségével
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/python-java/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyablakos nézet
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
description: "Fedezze fel az Aspose.Slides for Python via Java nézet tulajdonságait a PPT, PPTX és ODP diák testreszabásához—állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

Normál nézet három tartalmi területet tartalmaz: a diát magát, egy oldali tartalmi területet és egy alsó tartalmi területet. A normál nézet tulajdonságai leírják ezen tartalmi területek elhelyezkedését. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézet állapotát a fájlba, így újranyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót legutóbb mentették.

A [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódust adjuk hozzá, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.

Hozzáadtuk a [NormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/) , [NormalViewRestoredProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/) osztályokat és a [SplitterBarStateType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/) felsorolást.

## **A NormalViewProperties osztályról**

A normál nézet tulajdonságait képviseli.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) metódusok határozzák meg, hogy az alkalmazás ikonokat jelenítsen-e, ha vázlat tartalmat jelenít meg a normál nézet bármely tartalmi területén.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) metódusok határozzák meg, hogy a függőleges elválasztó sáv minimális állapotba álljon-e, amikor az oldalsó terület elég kicsi.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) metódusok határozzák meg, hogy a felhasználó inkább egy teljes ablakos, egyetlen tartalmi területet szeretne-e a három tartalmi területből álló szabványos normál nézet helyett. Engedélyezve az alkalmazás választhatja, hogy egy tartalmi területet jelenítsen meg az egész ablakban.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) metódusok határozzák meg, hogy a vízszintes vagy függőleges elválasztó sáv melyik állapotban jelenjen meg. A vízszintes elválasztó sáv elválasztja a diát a diát alatti tartalmi területtől; a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalmi területtől. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) és a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) metódusok meghatározzák a normál nézet felső vagy oldalsó diaterületének méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/python-java/aspose.slides/splitterbarstatetype/#Restored) érték van alkalmazva a [getVerticalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) metódusokra, illetve.

## **A NormalViewProperties helyreállításáról**

Meghatározza a normál nézet diaterületének méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) gyermekeként, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) gyermekeként), amikor a terület változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) metódus határozza meg a diaterület méretét (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredTop) gyermekeként, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) gyermekeként).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) metódus határozza meg, hogy az oldalsó tartalmi terület mérete kompenzálja-e az új méretet, amikor az alkalmazáson belüli nézetablak méretét változtatják.

Az alábbi példa bemutatja, hogyan férhetünk hozzá a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódushoz egy bemutató esetén.

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

    # A bemutató nézet tulajdonságainak visszaállítása.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az alapértelmezett nagyítási érték beállítása**

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Python via Java támogatja az alapértelmezett nagyítási érték beállítását, így a bemutató megnyitásakor már alkalmazva van. Ez a bemutató [ViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) beállításával valósítható meg. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getSlideViewProperties) és a [getNotesViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNotesViewProperties) programozottan konfigurálható. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) számára az Aspose.Slides-ben.
{{% /alert %}}

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) [View Properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/) értékét.
3. Mentse a bemutatót [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában beállítjuk a nagyítási értéket a dianézethez és a jegyzetnézethez egyaránt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # A bemutató nézet tulajdonságainak beállítása.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Nagyítási százalék a dianézethez.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Nagyítási százalék a jegyzet nézethez.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A rácstávolság beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) metódust a bemutató szintű nézet beállítások eléréséhez. A [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getGridSpacing) és a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setGridSpacing) metódusok olvassák vagy módosítják az alaprendszer szerkesztő rácsának intervallumát. Ez a beállítás a teljes bemutatóra vonatkozik, nem egyetlen diára. A rácstávolság pontban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogy az API dokumentációja előírja.

A következő példa megnyit egy létező `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, beállít egy negyed hüvelykes intervallumot, majd elmenti az eredményt.

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

A rács különbözik a [drawing guides](/slides/hu/python-java/drawing-guides/)-tól. A rácstávolság egy szabályos intervallumot szabályoz, míg a rajzolási segédvonalak egyesével elhelyezett vízszintes vagy függőleges igazítási vonalak. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rácstávolságot.

A rács és a rajzolási segédvonalak egyaránt szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF-ben, képekben, SVG-ben vagy diavetítésben. A rácstávolság tárolása nem garantálja, hogy a szerkesztő megjeleníti a rácsot: láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése a bemutató megnyitásakor**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) metódust a bemutató szintű nézet beállítások eléréséhez. A [ViewProperties.getShowComments](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getShowComments) és a [ViewProperties.setShowComments](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setShowComments) segítségével olvashatja vagy módosíthatja a tárolt preferenciát, hogy a megjegyzéseket meg kell-e jeleníteni, amikor a bemutatót a PowerPoint vagy egy másik kompatibilis szerkesztő nyitja meg.

Ez a beállítás csak a tárolt nézetpreferenciát szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt és nem old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, pozícióit, válaszait és állapotát. Tekintse meg a [Presentation Comments](/slides/hu/python-java/presentation-comments/) oldalt a megjegyzéseket módosító műveletekhez.

A következő példához egy meglévő, `comments.pptx` fájlra van szükség, amely tartalmaz megjegyzéseket. Kiírja a jelenlegi láthatósági beállítást, kéri a megjegyzések elrejtését, és egy új PPTX fájlt ment, anélkül hogy eltávolítana bármilyen megjegyzést. Emellett a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewtype/#SlideView) értékkel használja a kezdeti szerkesztő nézet és a megjegyzések láthatóságának beállításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a beállítás nem határozza meg, hogy a megjegyzések szerepelnek-e a PDF, HTML, kép, jegyzet vagy osztólagos exportokban. A megfelelő exportspecifikus beállításokat külön kell konfigurálni.

## **GYIK**

**Miért nem látható a rács, amikor újra megnyitom a bemutatót?**  
A fájl tárolja a rácstávolságot, de a szerkesztő szabályozza, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**A rajzolási segédvonalak törlése megváltoztatja a rácstávolságot?**  
Nem. A rajzolási segédvonalak és a rácstávolság független beállítások. A segédvonalak törlése nem változtatja meg a tárolt rácsintervallumot.

**Beállíthatok különböző nézetbeállításokat a bemutató egyes szakaszaira?**  
A [View settings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) a bemutató szinten vannak meghatározva ([Normal View](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), nem szekciónként, ezért egyetlen paraméterkészlet érvényes a teljes dokumentumra a megnyitáskor.

**Előre definiálhatok különböző nézetállapotokat különböző felhasználók számára?**  
Nem. A beállítások a fájlban vannak tárolva, és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl csak egy nézettulajdonság-készletet tartalmaz.

**Elkészíthetek sablont előre definiált View Properties-szal, hogy az új bemutatók ugyanúgy nyíljanak meg?**  
Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getViewProperties) a bemutató szinten vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kiinduló nézetkonfigurációval.