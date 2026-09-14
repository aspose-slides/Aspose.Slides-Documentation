---
title: Spravovat sekce snímků v prezentacích pomocí Pythonu přes Javu
linktitle: Sekce snímků
type: docs
weight: 90
url: /cs/python-java/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- načíst snímky sekce
- zpracovat snímky sekce
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravovat sekce snímků pomocí Aspose.Slides pro Python přes Javu: vytvářet, přejmenovávat, měnit pořadí, načítat a zpracovávat snímky sekcí v prezentacích PPTX."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímků. S Aspose.Slides pro Python prostřednictvím Javy můžete vytvářet, měnit pořadí, přejmenovávat, prohlížet a odstraňovat sekce pomocí metody [Presentation.getSections](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSections).

Sekce jsou zvláště užitečné, když:

- velká prezentace musí být rozdělena do logických témat nebo kapitol;
- různé skupiny snímků jsou přiřazeny různým spolupracovníkům;
- snímky je třeba zpracovávat, přesouvat nebo slučovat jako skupiny.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, použijte API sekcí k určení příslušnosti místo odvození z pozic snímků.

## **Vytvoření a správa sekcí**

Použijte [SectionCollection.addSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/#addSection) k vytvoření sekce zadáním jejího názvu a úvodního snímku. Aspose.Slides určuje, které snímky patří do sekce, z aktuální struktury sekcí prezentace.

Stejná [SectionCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/) vám také umožňuje:

- přesunout sekci spolu se svými snímky pomocí [reorderSectionWithSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- odstranit pouze definici sekce pomocí [removeSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/#removeSection), přičemž její snímky zůstávají;
- odstranit sekci i její snímky pomocí [removeSectionWithSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- přidat prázdnou sekci na konec pomocí [appendEmptySection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji spolu se svými snímky a připojí prázdnou sekci:

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

Po těchto operacích obsahuje prezentace sekci `Introduction` s jejími snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Pro přejmenování sekce zavolejte její metodu [Section.setName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#setName). Snímky sekce a její pozice zůstávají beze změny.

Následující příklad vytvoří sekci a změní její název:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Získání snímků ze sekcí**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSections) vrací [SectionCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectioncollection/), kterou můžete iterovat. Pro každou [Section](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/) zavolejte [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getSlidesListOfSection), abyste získali snímky, které do ní aktuálně patří. Metoda vrací [SectionSlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectionslidecollection/), která poskytuje počet, indexovaný přístup i iteraci.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou sekci, poté vypíše pro každou sekci [název](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getName), [identifikátor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getSectionId), [úvodní snímek](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getStartedFromSlide), počet snímků a čísla snímků. Používá [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectionslidecollection/#get_Item) k načtení prvního snímku a příkaz `for` k zpracování každého snímku. Pro prázdnou sekci má vrácená kolekce velikost nula, metoda se nevolá a iterace neprovádí žádné operace.

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

Příslušnost k sekci je určena strukturou sekcí v prezentaci. Nepočítejte rozsah sekce ručně z [Section.getStartedFromSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getStartedFromSlide), indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou změnit jak snímky vrácené pro sekci, tak jejich čísla. To zahrnuje změnu pořadí snímků, klonování snímku do sekce, přesunutí sekce spolu se svými snímky, odstraňování snímků i odstraňování sekcí. Následující příklad volá [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getSlidesListOfSection) po každé takové změně místo zachování předpokladů o bývalých mezích sekce.

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

Zavolejte [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getSlidesListOfSection) znovu vždy, když jsou snímky nebo sekce přeskládány, klonovány, přesouvány nebo odstraňovány. Tím zajistíte, že následné zpracování bude odpovídat aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Použijte tento postup s formátem, který sekce podporuje, například PPTX; převod do PPT odstraní strukturu sekcí potřebnou pro pozdější iteraci.

## **Často kladené otázky**

**Jsou sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztratí.

**Může být celá sekce „skryta“?**

Ne. Sekce nemá stav viditelnosti. Pro skrytí jejího obsahu zavolejte [Slide.setHidden](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setHidden) pro každý snímek v sekci.

**Jak mohu najít sekci, která obsahuje snímek?**

Iterujte přes kolekci vrácenou metodou [Presentation.getSections](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSections), pro každou sekci zavolejte [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getSlidesListOfSection) a porovnejte vrácené snímky s cílovým snímkem. Pro ne‑prázdnou sekci metoda [Section.getStartedFromSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/section/#getStartedFromSlide) vrací její první snímek; pro prázdnou sekci vrací `None`.