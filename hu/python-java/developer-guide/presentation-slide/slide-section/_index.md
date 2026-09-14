---
title: Diásszakciók kezelése prezentációkban Python segítségével Java-n keresztül
linktitle: Diásszakció
type: docs
weight: 90
url: /hu/python-java/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- szekció diáinak lekérése
- szekció diáinak feldolgozása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Kezelje a diásszakciókat az Aspose.Slides for Python via Java segítségével: hozzon létre, nevezzen át, rendezzen újra, kérje le és dolgozza fel a szekció diákat PPTX prezentációkban."
---
## **Bevezetés**

A szekciók a egymást követő diákat név szerint csoportosított egységekbe szervezik anélkül, hogy módosítanák a dia tartalmát. Az Aspose.Slides for Python via Java segítségével szekciókat hozhat létre, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat a [Presentation.getSections](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSections) metóduson keresztül.

A szekciók különösen hasznosak, ha:
- egy nagy bemutatót logikai témákra vagy fejezetekre kell felosztani;
- a diák különböző csoportjait különböző együttműködőknek rendelik;
- a diát csoportként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon tömör szekciónéveket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a bemutató struktúrájának részei, a szekció API-kat használja a tagság meghatározásához a diákat pozíciók alapján történő kiszámítás helyett.

## **Szekciók létrehozása és kezelése**

A [SectionCollection.addSection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/#addSection) használatával hozhat létre egy szekciót a nevét és a kezdődiát megadva. Az Aspose.Slides a bemutató jelenlegi szekcióstruktúrája alapján határozza meg, mely diák tartoznak a szekcióhoz.

Az ugyanaz a [SectionCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/) lehetővé teszi, hogy:
- egy szekciót a diáiával együtt mozgassa a [reorderSectionWithSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) használatával;
- csak a szekciódefiníciót távolítsa el a [removeSection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/#removeSection) segítségével, amely megtartja a diákot;
- a szekciót és a diáiát egyaránt eltávolítsa a [removeSectionWithSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- egy üres szekciót adjon a véghez a [appendEmptySection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/#appendEmptySection).

A következő példa két szekciót hoz létre, az egyiket áthelyezi, azt a diáiával együtt eltávolítja, és egy üres szekciót fűz hozzá:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Ezek után a bemutató tartalmazza a `Introduction` szekciót a diáiával, valamint egy üres `Appendix` szekciót. A `Results` szekció és annak diái eltávolításra kerültek.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez hívja meg a [Section.setName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#setName) metódust. A szekció diái és pozíciója változatlan marad.

A következő példa egy szekciót hoz létre, és megváltoztatja a nevét:

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Diaok lekérése szekciókból**

A [Presentation.getSections](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSections) metódus visszaad egy [SectionCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectioncollection/) objektumot, amelyen iterálhat. Minden [Section](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/) esetén hívja meg a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getSlidesListOfSection) metódust, hogy megkapja a jelenleg hozzá tartozó diák listáját. A metódus egy [SectionSlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectionslidecollection/) objektumot ad vissza, amely számlálót, indexelt hozzáférést és iterálást biztosít.

A következő példa két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [name](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getStartedFromSlide), dia számát és dia sorszámát. A [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectionslidecollection/#get_Item) használatával olvassa el az első diát, és egy `for` utasítással dolgozza fel az összes diát. Az üres szekció esetében a visszaadott kollekció mérete nulla, a metódus nem kerül meghívásra, és az iteráció nem hajt végre műveletet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

A szekció tagságát a bemutató szekcióstruktúrája határozza meg. Ne számítsa ki manuálisan egy szekció tartományát a [Section.getStartedFromSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getStartedFromSlide), diák indexeiből és a következő szekció kezdődiájából.

A strukturális szerkesztések megváltoztathatják egy szekcióhoz visszaadott diák számát és azok sorszámát is. Ide tartozik a diák átrendezése, egy dia klónozása egy szekcióba, egy szekció és diái áthelyezése, diák eltávolítása, valamint szekciók törlése. A következő példa minden ilyen módosítás után meghívja a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getSlidesListOfSection) metódust, ahelyett, hogy megtartaná a szekció korábbi határait.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Hívja újra a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getSlidesListOfSection) metódust, amikor csak diák vagy szekciók átrendezésre, klónozásra, áthelyezésre vagy eltávolításra kerülnek. Ez biztosítja, hogy a további feldolgozás a jelenlegi bemutató struktúrájával összhangban legyen.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatokat. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX; PPT-re konvertálás eltávolítja a későbbi iterációhoz szükséges szekciószerkezetet.

## **GYIK**

**Megmaradnak a szekciók, ha PPT (PowerPoint 97–2003) formátumba mentjük?**

Nem. A PPT formátum nem támogatja a szekció metaadatokat, ezért a szekciócsoportosítás elveszik, ha .ppt formátumba ment.

**Lehet egy egész szekciót "rejtetté" tenni?**

Nem. A szekciónak nincs láthatósági állapota. A tartalma elrejtéséhez hívja meg a [Slide.setHidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#setHidden) metódust a szekció minden egyes diáján.

**Hogyan találhatom meg a diát tartalmazó szekciót?**

Iteráljon a [Presentation.getSections](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSections) által visszaadott gyűjteményen, minden szekcióhoz hívja meg a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getSlidesListOfSection) metódust, és hasonlítsa össze a visszaadott diát a céldiával. Egy nem üres szekció esetén a [Section.getStartedFromSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/section/#getStartedFromSlide) visszaadja az első diát; egy üres szekció esetén `None` értéket ad vissza.