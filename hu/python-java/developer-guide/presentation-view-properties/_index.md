---
title: Prezentációs nézeti tulajdonságok lekérése és frissítése Pythonon keresztül Java-val
linktitle: Nézeti tulajdonságok
type: docs
weight: 80
url: /hu/python-java/presentation-view-properties/
keywords:
- nézeti tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egy nézet
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
description: "Az Aspose.Slides for Python via Java használatával konfigurálhatja a normál nézet elrendezését, a dia és a jegyzetek nagyítását, a rács távolságát, valamint a megjegyzések láthatóságát a PowerPoint prezentációkban."
---
## **Bevezetés**

A PowerPoint normál nézetben a dia a bélyegképek vagy vázlat oldalsó ablaka és a jegyzetek ablaka között jelenik meg. Az Aspose.Slides for Python via Java a prezentáció mentett szerkesztési beállításait teszi elérhetővé a [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) segítségével. Ezek közé tartozik az ablaktábla elrendezése, a nagyítási szintek, a rács távolsága és a megjegyzések láthatósága.

## **A NormalViewProperties tulajdonságokról**

Használja a [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) metódust a [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) osztály eléréséhez. A [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) szabályozza, hogy ikont jelenjen-e meg a dia címek mellett a vázlatban. A [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) lehetővé teszi, hogy az oldalsó ablaktábla minimalizált állapotba ugráljon, ha a felhasználó szűkíti. A [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) egy panelek megjelenítésének előnyben részesítését jelzi a teljes ablakban.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) szabályozza a elválasztót az oldalsó ablaktábla és a dia között. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) szabályozza a jegyzetek ablaka feletti elválasztót. Mindkettő egy [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) értéket fogad el: `Minimized`, `Maximized` vagy `Restored`.

## **A NormalViewProperties visszaállításáról**

Amikor egy elválasztót visszaállítanak, a [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) adja meg az oldalsó ablaktábla mentett méretét, a [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) pedig a felső diapozíció mentett méretét. Mindkettő egy [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) példányt ad vissza. A [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) metódus 0‑tól 100‑ig terjedő százalékot fogad, a [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) pedig szabályozza, hogy a szerkesztő méretezze‑e‑a az ablak átméretezésekor.

Ez a példa egy meglévő prezentációt frissít. Visszaállítja a vízszintes elválasztót, a [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) által visszaadott méretet 80%-ra állítja be automatikus igazítással, és maximalizálja a függőleges elválasztót. Emellett meghívja a [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) metódust az ikonok vázlat nézetben való megjelenítéséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az alapértelmezett nagyítási érték beállítása**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) és [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) független nagyítási beállításokat tárolnak a szerkesztő számára. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a kép export felbontását.

Ez a példa megnyit egy meglévő prezentációt, és meghívja a [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) metódust, hogy a diát az szerkesztőablakhoz igazítsa. A jegyzetoldal esetén letiltja az automatikus skálázást, és a [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) metódussal rögzített 80%-os nagyítást állít be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A rács távolságának beállítása**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) beállítja a szerkesztési rácsvonalak közötti távolságot a teljes prezentációban. Pozitív értéket vár pontban, 72 pont egy hüvelykben. Ez a példa kiírja a jelenlegi távolságot egy meglévő prezentációban, és egy negyed hüvelykes rácsot ment 18 pontra állított intervallummal.

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

A rács rögzített intervallumban ismétlődik. A [Drawing guides](/slides/hu/python-java/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelölnek. Mindkettő szerkesztősegéd, és csak azokat a szerkesztőket jeleníti meg, amelyek támogatják. A diavetítések és a PDF, kép vagy SVG exportok kihagyják őket.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) egy előnyben részesítést tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor használnak. Egy meglévő, megjegyzésekkel rendelkező prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy rejtett megjegyzésekkel másolatot ment. Emellett meghívja a [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) értékkel, hogy a másolat dianézetben nyíljon meg.

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

A megjegyzések elrejtése megőrzi azok szövegét, szerzőit, pozícióit, válaszait és állapotát. A megjegyzések módosításához lásd a [Presentation Comments](/slides/hu/python-java/presentation-comments/) cikket. Az export beállítások szabályozzák, hogy a megjegyzések megjelennek-e PDF-ben, HTML-ben, képeken, jegyzetekben vagy szórólapokon.

## **FAQ**

**Miért rejtőzik el a rács, amikor újra megnyitom a prezentációt?**  
A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A rajzsegédletek törlése megváltoztatja a rács távolságát?**  
Nem. A segédlet hozzáadása, mozgatása vagy törlése nem változtatja meg a rács intervallumát.

**Lehetnek a prezentáció különböző szekciói különböző nézeti beállításokkal?**  
Nem. A [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) az egész prezentációra érvényes.

**Menthetek különböző nézeti beállításokat különböző felhasználók számára?**  
A fájl egyetlen nézetbeállítást tárol mindenki számára. A szerkesztő esetleg a felhasználó helyi beállításait is alkalmazhatja.

**Menthetek nézetbeállításokat egy sablonba?**  
Igen. A sablonból létrehozott prezentációk öröklik a sablonban tárolt nézetbeállításokat.