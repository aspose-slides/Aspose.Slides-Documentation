---
title: Python segítségével diák szakaszainak kezelése előadásokban
linktitle: Dia szakasz
type: docs
weight: 100
url: /hu/python-net/slide-section/
keywords:
- szakasz létrehozása
- szakasz hozzáadása
- szakasz szerkesztése
- szakasz módosítása
- szakasz neve
- szakasz diáinak lekérése
- szakasz diáinak feldolgozása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Dia szakaszok kezelése az Aspose.Slides for Python via .NET segítségével: szakaszok létrehozása, átnevezése, átrendezése, lekérése és a szakasz diák feldolgozása PPTX előadásokban."
---
## **Bevezetés**

A szakaszok egymás után következő diákat nevezett csoportokba szerveznek a diatartalom módosítása nélkül. Az Aspose.Slides for Python via .NET segítségével szakaszokat hozhat létre, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat a [Presentation.sections](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/sections/) tulajdonságon keresztül.

A szakaszok különösen akkor hasznosak, ha:

- egy nagy prezentációt logikai témákra vagy fejezetekre kell felosztani;
- a diák különböző csoportjait különböző együttműködőknek kell hozzárendelni;
- a diákat csoportként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon tömör szakaszneveket, amelyek leírják a csoportosított diák célját. Mivel a szakaszok a prezentáció struktúrájának részei, a szekció API-kat használja a tagság meghatározásához, a diák pozíciójából történő levezetés helyett.

## **Szakaszok létrehozása és kezelése**

Használja a [SectionCollection.add_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/add_section/) metódust szakasz létrehozásához a neve és a kezdő dia megadásával. Az Aspose.Slides a prezentáció aktuális szakaszstruktúrájából határozza meg, mely diák tartoznak a szakaszhoz.

Ugyanaz a [SectionCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/) lehetővé teszi továbbá:

- egy szakasz és annak diái áthelyezését a [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) használatával;
- csak a szakaszdefiníció eltávolítását a [SectionCollection.remove_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/remove_section/) segítségével, a diák megmaradnak;
- egy szakasz és annak diáinak eltávolítását a [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) használatával;
- egy üres szakasz hozzáadását a végére a [SectionCollection.append_empty_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/append_empty_section/) segítségével.

A következő példa két szakaszt hoz létre, egyikét áthelyezi, eltávolítja a diáival együtt, majd egy üres szakaszt fűz hozzá:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Ezek után a prezentáció a `Introduction` szakaszt tartalmazza a diáival, valamint egy üres `Appendix` szakaszt. A `Results` szakasz és annak diái eltávolításra kerültek.

## **Szakaszok átnevezése**

Egy szakasz átnevezéséhez állítsa be a [Section.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/name/) tulajdonságot. A szakasz diái és pozíciója változatlan marad.

A következő példa egy szakaszt hoz létre és megváltoztatja a nevét:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Diák lekérése a szakaszokból**

A [Presentation.sections](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/sections/) tulajdonság egy [SectionCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectioncollection/)‑t ad vissza, amelyen iterálhat. Minden egyes [Section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/) esetén hívja meg a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/get_slides_list_of_section/) metódust, hogy megkapja a jelenleg hozzá tartozó diák listáját. A metódus egy [SectionSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectionslidecollection/)‑t ad vissza, amely számlálót, indexelt hozzáférést és iterálást biztosít.

A következő példa két feltöltött szakaszt és egy üres szakaszt hoz létre, majd kiírja minden szakasz [name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/started_from_slide/), diaszámát és a diák sorszámait. Indexelt hozzáférést használ az első dia beolvasásához, és egy `for` ciklust a minden dia feldolgozásához. Az üres szakasz esetén a visszaadott gyűjtemény száma nulla, az indexet nem használják, és az iterálás nem hajt végre lépéseket.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

A szakaszhovatartozás a prezentáció szakaszstruktúráján alapul. Ne számolja ki manuálisan egy szakasz tartományát a [Section.started_from_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/started_from_slide/), diaindexek és a következő szakasz kezdődiája alapján.

A struktúrális módosítások megváltoztathatják egy szakaszhoz visszaadott diák listáját és a diák számát is. Ide tartozik a diák átrendezése, egy dia klónozása egy szakaszba, egy szakasz és diáinak áthelyezése, diák eltávolítása és szakaszok törlése. A következő példa minden ilyen változás után meghívja a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/get_slides_list_of_section/) metódust, ahelyett, hogy a szakasz korábbi határaira vonatkozó feltételezéseket megtartaná.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Hívja újra a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/get_slides_list_of_section/) metódust, amikor csak diák vagy szakaszok átrendezésre, klónozásra, áthelyezésre vagy eltávolításra kerülnek. Ez biztosítja, hogy a további feldolgozás a jelenlegi prezentációs struktúrához legyen igazítva.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szakaszmetaadatokat. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szakaszokat, például PPTX‑szel; a PPT‑re konvertálás eltávolítja a későbbi iterációhoz szükséges szakaszstruktúrát.

## **GYIK**

**Megmaradnak a szakaszok a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szakaszmetaadatokat, ezért a szakaszcsoportosítás elveszik, amikor .ppt‑ként menti a fájlt.

**Lehet egy egész szakaszt „elrejteni”?**

Nem. A szakasznak nincs láthatósági állapota. A tartalom elrejtéséhez állítsa be a [Slide.hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/hidden/) tulajdonságot minden egyes diánál a szakaszon belül.

**Hogyan találhatom meg azt a szakaszt, amelyik egy adott diát tartalmaz?**

Iteráljon a [Presentation.sections](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/sections/) kollekción, hívja meg a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/get_slides_list_of_section/) metódust minden szakaszra, és hasonlítsa össze a visszaadott diák listáját a keresett diával. Egy nem üres szakasz esetén a [Section.started_from_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/section/started_from_slide/) az első diát adja vissza; egy üres szakasz esetén `None`‑t ad.