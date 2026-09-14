---
title: Diavetítések fejlécének és láblécének kezelése Pythonon keresztül Java segítségével
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/python-java/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- kézjegyzék
- jegyzetek
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a lábléc, dátum/idő, dia-szám és fejléc helyőrzőket diákon, jegyzetoldalakon és kézjegyzékeken az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A PowerPoint különböző fejléc- és lábléchelyőrzőket használ az oldal típusától függően. Az Aspose.Slides for Python via Java lehetővé teszi, hogy a szöveget és a láthatóságot ezeknél a helyőrzőknél a fejléc/lábléc kezelő osztályok segítségével szabályozza.

Az elérhető helyőrzők a hatókörön (scope) múlnak:

| Hatókör | Fejléc | Lábléc | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Általános dia | Nem | Igen | Igen | Igen |
| Jegyzet mester | Igen | Igen | Igen | Igen |
| Jegyzet dia | Igen | Igen | Igen | Igen |
| Kézjegyzék mester | Igen | Igen | Igen | Igen |

Az általános bemutatódia nem tartalmaz fejléchelyőrzőt. A fejlécek a jegyzetoldalon és a kézjegyzékeken érhetők el. Általános diák esetén helyette a lábléc, a dátum/idő és a dia‑szám helyőrzőket kell használni.

A módosítás hatóköre attól a kezelőtől függ, amelyet használ. A [SlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideheaderfootermanager/) osztály egy általános diát vezérel. A [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslideheaderfootermanager/) osztály egy jegyzet diát vezérel. A mester‑ és elrendezéskezelők szintén propagálhatják a beállításokat a függő diákra, míg a [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) osztály a kézjegyzék mestert kezeli.

## **Lábléc, Dátum/Idő és Dia Számok beállítása általános diákon**

Általános diák esetén az alapmunkafolyamat az, hogy elérje az egyes diák fejléc/lábléc kezelőjét, beállítja a lábléc és a dátum/idő szövegét, engedélyezi a szükséges helyőrzőket, majd menti a bemutatót. A dia‑számokat a bemutató generálja, így csak a láthatóságukat kell szabályozni.

Használja az [setFooterText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) és az [setDateTimeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) segítségével állíthatja be a szöveget, a [setFooterVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), a [setDateTimeVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) és a [setSlideNumberVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) segítségével jelenítheti meg a megfelelő helyőrzőket.

Az alábbi end-to-end példa ugyanazt a láblécet, a dátum/idő szöveget és a dia‑szám láthatóságot alkalmazza minden általános diára:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ha csak egy diát kell frissíteni, a [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) metóduson keresztül közvetlenül érje el azt a diát, a teljes gyűjtemény bejárása helyett.

## **Fejlécek és láblécek beállítása a Jegyzet Mesteren**

A jegyzet mester közös formázást és helyőrzőbehajtást határoz meg a jegyzetoldalak számára. Használja a [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/) osztályt, ha csak a jegyzet mestert kívánja módosítani.

Az alábbi példa beállítja a fejlécet, a láblécet és a dátum/idő szöveget a jegyzet mesteren, és az összes támogatott helyőrzőt láthatóvá teszi azon a mesteren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A `getMasterNotesSlide` metódus `None` értéket ad vissza, ha a bemutató nem tartalmaz jegyzet mestert.

## **Jegyzet Mester beállításainak alkalmazása a Gyermek Jegyzet Diákra**

A jegyzet mester képes a fejléc és lábléc beállításokat saját magára és az összes függő jegyzet diára alkalmazni. Használja a dedikált propagációs metódusokat a [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/) osztályban, ha ugyanazokat a beállításokat szeretné alkalmazni a jegyzet hierarchián belül.

Például a [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) és a [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) frissítik a jegyzet mester fejlécét és az összes gyermekfejlécet. Hasonló metódusok érhetők el a láblécek, a dátum/idő és a dia‑számok számára is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A fent használt propagációs metódusok: [setFooterAndChildFootersText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), és a [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Fejlécek és láblécek beállítása egy egyedi Jegyzet Dián**

Egy jegyzet dia egy adott általános diához tartozik. Használja a [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslideheaderfootermanager/) osztályt, ha csak azt a jegyzet oldalt szeretné testreszabni.

A [addNotesSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslidemanager/#addNotesSlide) metódus visszaadja az aktuális dia jegyzet diáját, és létrehozza, ha még nem létezik. Az alábbi példa konfigurálja az első bemutató diasal összekapcsolt jegyzet oldalt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ha először a jegyzet mester beállításait propagálja, majd egy egyedi jegyzet diát módosít, a későbbi egyedi diabeállítások lehetővé teszik, hogy a jegyzet oldalt önállóan testreszabja.

## **Fejlécek és láblécek beállítása a Kézjegyzék Mestren**

A kézjegyzék oldalak a kézjegyzék mestert használják a fejléc, lábléc, dátum/idő és oldal‑szám helyőrzőikhez. A jegyzet oldalakkal ellentétben a kézjegyzék beállításait a kézjegyzék mester, nem pedig az egyes kézjegyzék diák kezelik.

Használja a `getMasterHandoutSlide` metódust a kézjegyzék mester eléréséhez. Ha nem létezik, hívja a `setDefaultMasterHandoutSlide` metódust az alapértelmezett kézjegyzék mester létrehozásához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A Hatókör és Öröklés megértése**

Válassza ki a kívánt hatókörnek megfelelő fejléc/lábléc kezelőt:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideheaderfootermanager/) megváltoztatja a lábléc, dátum/idő és dia‑szám beállításokat egy általános dián.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslideheaderfootermanager/) egy elrendezés diát vezérel, és képes a támogatott beállításokat a függő diákra propagálni.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslideheaderfootermanager/) egy általános dia mestert vezérel, és képes a támogatott beállításokat a függő diákra propagálni.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslideheaderfootermanager/) a jegyzet mestert vezérli, és a beállításokat az összes függő jegyzet diára propagálja.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslideheaderfootermanager/) egy jegyzet diát módosít, és a lábléc, dátum/idő és dia‑szám mellett egy fejléc helyőrzőt is támogat.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) a kézjegyzék mestert módosítja, és mind a négy helyőrző típust támogatja.

Használjon propagálást egy mester vagy elrendezés esetén, ha ugyanazt a beállítást az egész hierarchiában alkalmazni kell. Használjon egyedi diát vagy jegyzet‑diád kezelőt, ha egy oldalon helyi beállításra van szükség.

## **GYIK**

**Hozzáadhatok fejlécet egy általános diához?**

Nincs. A PowerPoint nem definiál fejléchelyőrzőt általános diákhoz. Általános diákon használja a lábléc, a dátum/idő és a dia‑szám helyőrzőket. A fejléchelyőrzők a jegyzetoldalakon és a kézjegyzékeken érhetők el.

**Mi történik, ha a lábléc, dátum/idő vagy dia‑szám helyőrző nem látható?**

Használja a megfelelő fejléc/lábléc kezelőt a láthatóság ellenőrzésére és engedélyezésére, ha szükséges. Például az [isFooterVisible](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) jelzi, hogy a lábléc helyőrző jelen van-e, a [setFooterVisibility](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) pedig módosítja annak láthatóságát.

**Hogyan kezdjem el a dia‑számozást 1‑nél eltérő értékkel?**

Hívja meg a bemutató [setFirstSlideNumber](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#setFirstSlideNumber) metódusát. Ezután a dia‑szám helyőrzők a frissített számozási sorozatot használják.

**Mi történik a fejlécekkel és láblécekkel PDF, képek vagy HTML exportálásakor?**

A látható fejléc‑ és lábléc elemek a kimeneti formátumban a bemutató többi tartalmával együtt kerülnek renderelésre. Megjelenésük az exportált oldal típusától és a megfelelő helyőrző láthatósági beállításoktól függ.