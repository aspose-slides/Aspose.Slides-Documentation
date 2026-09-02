---
title: Správa sekcí snímků v prezentacích pomocí Pythonu
linktitle: Sekce snímku
type: docs
weight: 100
url: /cs/python-net/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- získat snímky sekce
- zpracovat snímky sekce
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte sekce snímků pomocí Aspose.Slides pro Python přes .NET: vytvářejte, přejmenujte, přeuspořádejte, získávejte a zpracovávejte snímky sekcí v prezentacích PPTX."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímku. S Aspose.Slides pro Python prostřednictvím .NET můžete vytvářet, přeskupovat, přejmenovávat, kontrolovat a odstraňovat sekce pomocí vlastnosti [Presentation.sections](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/sections/) .

Sekce jsou zvláště užitečné, když:

- velká prezentace musí být rozdělena na logické témata nebo kapitoly;
- různé skupiny snímků jsou přiřazeny různým spolupracovníkům;
- snímky je třeba zpracovávat, přesouvat nebo slučovat jako skupiny.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, použijte API sekcí k určení příslušnosti místo odvození z pozic snímků.

## **Vytváření a správa sekcí**

K vytvoření sekce pomocí určení jejího názvu a úvodního snímku použijte [SectionCollection.add_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/add_section/) . Aspose.Slides určuje, které snímky patří do sekce, na základě aktuální struktury sekcí v prezentaci.

Stejný [SectionCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/) vám také umožní:

- přesunout sekci spolu se svými snímky pomocí [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) ;
- odebrat pouze definici sekce pomocí [SectionCollection.remove_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/remove_section/) , přičemž snímky zůstávají zachovány;
- odebrat sekci i její snímky pomocí [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) ;
- přidat prázdnou sekci na konec pomocí [SectionCollection.append_empty_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/append_empty_section/) .

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji spolu se svými snímky a přidá prázdnou sekci:

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

Po těchto operacích prezentace obsahuje sekci `Introduction` se svými snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Pro přejmenování sekce nastavte její vlastnost [Section.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/name/) . Snímky sekce a její pozice zůstávají beze změny.

Následující příklad vytvoří sekci a změní její název:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Získání snímků ze sekcí**

Vlastnost [Presentation.sections](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/sections/) vrací [SectionCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/) , přes kterou můžete iterovat. Pro každou [Section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/) zavolejte [Section.get_slides_list_of_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/get_slides_list_of_section/) , abyste získali snímky, které do ní právě patří. Metoda vrací [SectionSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectionslidecollection/) , která poskytuje počet, indexovaný přístup a iteraci.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou sekci, pak vytiskne pro každou sekci její [name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/name/) , [identifier](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/section_id/) , [starting slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/started_from_slide/) , počet snímků a čísla snímků. Používá indexovaný přístup k načtení prvního snímku a smyčku `for` k zpracování všech snímků. Pro prázdnou sekci má vrácená kolekce počet nula, index se nevyužívá a iterace neproběhne.

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

Příslušnost k sekci je určena strukturou sekcí v prezentaci. Nepočítejte rozsah sekce ručně z [Section.started_from_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/started_from_slide/) , indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou změnit jak snímky vrácené pro sekci, tak jejich čísla. To zahrnuje přeskupení snímků, klonování snímku do sekce, přesunutí sekce spolu se svými snímky, odstraňování snímků a odstraňování sekcí. Následující příklad volá [Section.get_slides_list_of_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/get_slides_list_of_section/) po každé takové změně namísto zachování předpokladů o dřívějších hranicích sekce.

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

Zavolejte [Section.get_slides_list_of_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/get_slides_list_of_section/) znovu vždy, když jsou snímky nebo sekce přeskupeny, klonovány, přesunuty nebo odstraněny. Tím se zajistí, že následné zpracování odpovídá aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Použijte tento postup s formátem, který sekce podporuje, například PPTX; konverze do PPT odstraní strukturu sekcí potřebnou pro následnou iteraci.

## **Často kladené otázky**

**Zachovají se sekce při uložení do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztratí.

**Může být celá sekce "skrytá"?**

Ne. Sekce nemá stav viditelnosti. Pro skrytí jejího obsahu nastavte pro každý snímek v sekci vlastnost [Slide.hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/) .

**Jak mohu najít sekci, která obsahuje snímek?**

Iterujte přes [Presentation.sections](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/sections/) , pro každou sekci zavolejte [Section.get_slides_list_of_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/get_slides_list_of_section/) a porovnejte vrácené snímky s cílovým snímkem. Pro ne‑prázdnou sekci [Section.started_from_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/started_from_slide/) vrací její první snímek; pro prázdnou sekci vrací `None`.