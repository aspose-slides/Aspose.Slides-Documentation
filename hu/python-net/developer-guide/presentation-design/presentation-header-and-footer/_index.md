---
title: Prezentáció fejléceinek és lábléceinek kezelése Pythonban
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/python-net/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- elosztó
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a lábléc, dátum-idő, dia-szám és fejléc helyfoglalókat a diákon, jegyzetoldalakon és elosztókon az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

A PowerPoint a lap típusa szerint különböző fej- és lábléchelyfoglalókat használ. Az Aspose.Slides for Python via .NET lehetővé teszi ezen helyfoglalók szövegének és láthatóságának vezérlését fej/lábléckezelő osztályok segítségével.

Az elérhető helyfoglalók a hatókör függvényében változnak:

| Hatókör | Fejléc | Lábléc | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Normál dia | Nem | Igen | Igen | Igen |
| Jegyzetmester | Igen | Igen | Igen | Igen |
| Jegyzetdia | Igen | Igen | Igen | Igen |
| Eloszlásmester | Igen | Igen | Igen | Igen |

Egy normál prezentációs diának nincs fejléchez tartozó helyfoglalója. A fejlécek a jegyzetoldalakon és az elosztásokon érhetők el. Normál diáknál a láblécet, a dátum/idő és a dia‑szám helyfoglalókat kell használni.

A változtatás hatóköre attól függ, melyik kezelőt használja. A [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slideheaderfootermanager/) osztály egy normál diát vezérel. A [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslideheaderfootermanager/) osztály egy jegyzetdiát vezérel. A mester‑ és elrendezéskezelők is képesek a beállításokat a függő diákra továbbadni, míg a [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) osztály az eloszlás mestert kezeli.

## **Állítsa be a láblécet, dátum/időt és a dia számait normál diákon**

Normál diák esetén az alapmunkafolyamat: hozzáfér a dia fejléc/lábléckezelőjéhez, beállítja a lábléc és dátum/idő szöveget, engedélyezi a szükséges helyfoglalókat, és elmenti a prezentációt. A dia‑számok a prezentáció generálja, így csak a láthatóságukat kell szabályozni.

Használja a [`set_footer_text`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) és a [`set_date_time_text`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) metódusokat a szöveg beállításához, valamint a [`set_footer_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), és a [`set_slide_number_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) metódusokat a megfelelő helyfoglalók megjelenítéséhez.

Az alábbi végponti példa azonos láblécet, dátum/idő szöveget és dia‑szám láthatóságot alkalmaz az összes normál diára:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Ha csak egyetlen diát szeretne frissíteni, közvetlenül férjen hozzá ahhoz a diához a [`slides`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) gyűjteményen keresztül, a teljes gyűjtemény bejárása helyett.

## **Fejlécek és láblécek beállítása a Jegyzetmesten**

A jegyzetmester közös formázást és helyfoglaló‑viselkedést határoz meg a jegyzetoldalak számára. Használja a [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/) osztályt, ha csak a jegyzetmestert szeretné módosítani.

Az alábbi példa beállítja a fejlécet, láblécet és dátum/idő szöveget a jegyzetmestre, és az összes támogatott helyfoglalót láthatóvá teszi azon a mesteren:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Egy prezentáció nem feltétlenül tartalmaz jegyzetmestert, ezért a módosítás előtt ellenőrizze, hogy a visszaadott érték nem `None`.

## **Jegyzetmester beállításainak alkalmazása a gyermek‑jegyzet diákra**

A jegyzetmester képes a fej‑ és láblécbeállításokat saját magára és az összes függő jegyzetdiára alkalmazni. Használja a [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/) dedikált propagációs metódusait, ha ugyanazokat a beállításokat akarja a jegyzet‑hierarchiában alkalmazni.

Például a [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) és a [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) frissíti a jegyzetmester fejlécét és az összes gyermekfejlécet. Hasonló metódusok érhetők el a láblécek, dátum/idő és dia‑számok számára is.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

A fent használt propagációs metódusok: [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), és a [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Fejlécek és láblécek beállítása egy egyedi jegyzet dián**

Egy jegyzetdia egy adott normál diahoz tartozik. Használja a [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslideheaderfootermanager/) osztályt, ha csak azt a jegyzetoldalt kívánja testreszabni.

A [`add_notes_slide`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslidemanager/add_notes_slide/) metódus visszaadja az aktuális dia jegyzetdiáját, és létrehozza, ha még nem létezik. Az alábbi példa az első prezentációs diához tartozó jegyzetoldalt konfigurálja:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Ha először a jegyzetmester beállításait propagálja, majd egyedi jegyzetdián változtat, a későbbi per‑dia beállítások lehetővé teszik a jegyzetoldal független testreszabását.

## **Fejlécek és láblécek beállítása az Eloszlás Mesteren**

Az eloszlás oldalak az eloszlás mestert használják a fejléc, lábléc, dátum/idő és oldal‑szám helyfoglalókhoz. A jegyzetoldalakkal ellentétben az eloszlás beállításait az eloszlás mester kezeli, nem az egyedi eloszlás diák.

Használja a [`master_handout_slide`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) tulajdonságot az eloszlás mester eléréséhez. Ha nincs jelen, hívja a [`set_default_master_handout_slide`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) metódust a alapértelmezett eloszlás mester létrehozásához.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **A hatókör és az öröklődés megértése**

Válassza ki a kívánt hatókörnek megfelelő fej/lábléckezelőt:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slideheaderfootermanager/) módosítja a láblécet, dátum/időt és dia‑szám beállításokat egy normál dián.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslideheaderfootermanager/) egy elrendezésdiát vezérel, és a támogatott beállításokat a függő diákra továbbíthatja.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslideheaderfootermanager/) egy normál dia mestert vezérel, és a támogatott beállításokat a függő diákra továbbíthatja.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/) a jegyzetmestert vezérli, és a beállításokat az összes függő jegyzetdiára terjeszti.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslideheaderfootermanager/) egy jegyzetdiát módosít, és a fejléchelyfoglalót a lábléc, dátum/idő és dia‑szám mellett támogatja.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) az eloszlás mestert módosítja, és a négy helyfoglalót egyaránt támogatja.

Használjon propagációt egy mester vagy elrendezés esetén, ha ugyanazt a beállítást szeretné alkalmazni a teljes hierarchián. Egyéni dia vagy jegyzetdia‑kezelő használata akkor indokolt, ha helyi beállításra van szükség egyetlen oldalhoz.

## **GYIK**

**Hozzáadhatok fejlécet egy normál diához?**

Nem. A PowerPoint nem definiál fejléchelyfoglalót normál diákra. Normál diák esetén a lábléc, dátum/idő és dia‑szám helyfoglalókat kell használni. Fejléchelyfoglalók csak a jegyzetoldalakon és elosztásokon érhetők el.

**Mi van, ha egy lábléc, dátum/idő vagy dia‑szám helyfoglaló nem látható?**

Használja a megfelelő fej/lábléckezelőt a láthatóság ellenőrzéséhez és szükség esetén engedélyezéséhez. Például a [`is_footer_visible`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) jelzi, hogy a lábléchelyfoglaló jelen van‑e, a [`set_footer_visibility`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) pedig módosítja a láthatóságát.

**Hogyan indíthatom a dia‑számozást 1‑nél eltérő értékről?**

Állítsa be a prezentáció [`first_slide_number`](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/first_slide_number/) tulajdonságát. Ezután a dia‑szám helyfoglalók az új számozási sorozatot használják.

**Mi történik a fejlécekkel és láblécekkel PDF‑re, képekre vagy HTML‑re exportáláskor?**

A látható fej‑ és láblécelemek a prezentáció tartalmával együtt kerülnek renderelésre a kimeneti formátumban. Megjelenésük a exportált lap típusától és a megfelelő helyfoglaló láthatósági beállításoktól függ.