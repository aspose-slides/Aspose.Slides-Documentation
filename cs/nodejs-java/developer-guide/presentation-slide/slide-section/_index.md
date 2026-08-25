---
title: Správa sekcí snímků v prezentacích pomocí JavaScriptu
linktitle: Sekce snímku
type: docs
weight: 90
url: /cs/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte sekce snímků pomocí Aspose.Slides pro Node.js přes Java: vytvářejte, přejmenovávejte, přeskupujte, získávejte a zpracovávejte snímky sekcí v prezentacích PPTX."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímku. S Aspose.Slides pro Node.js prostřednictvím Javy můžete vytvářet, přeskupovat, přejmenovávat, zkoumat a odstraňovat sekce pomocí metody [Presentation.getSections](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSections).

Sekce jsou zejména užitečné, když:

- velká prezentace musí být rozdělena do logických témat nebo kapitol;
- různé skupiny snímků jsou přiřazeny různým spolupracovníkům;
- snímky je třeba zpracovávat, přesouvat nebo slučovat jako skupiny.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, využijte API sekcí k určení příslušnosti místo odvození z pozic snímků.

## **Vytváření a správa sekcí**

Použijte [SectionCollection.addSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/#addSection) k vytvoření sekce zadáním jejího názvu a úvodního snímku. Aspose.Slides určuje, které snímky patří do sekce, ze současné struktury sekcí v prezentaci.

Stejný [SectionCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/) vám také umožňuje:

- přesunout sekci spolu s jejími snímky pomocí [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- odstranit pouze definici sekce pomocí [SectionCollection.removeSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/#removeSection), což zachová její snímky;
- odstranit sekci i s jejími snímky pomocí [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- přidat prázdnou sekci na konec pomocí [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji spolu s jejími snímky a přidá prázdnou sekci:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Po těchto operacích obsahuje prezentace sekci `Introduction` se svými snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Pro přejmenování sekce zavolejte její metodu [Section.setName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#setName). Snímky sekce a její pozice zůstávají beze změny.

Následující příklad vytvoří sekci a změní její název:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Získání snímků ze sekcí**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSections) vrací [SectionCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectioncollection/), ke které můžete přistupovat pomocí indexu. Pro každou [Section](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/) zavolejte [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getSlidesListOfSection), abyste získali snímky, které do ní aktuálně patří. Metoda vrací [SectionSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectionslidecollection/), která poskytuje počet a indexovaný přístup.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou sekci, poté vypíše pro každou sekci [název](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getName), [identifikátor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getSectionId), [úvodní snímek](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getStartedFromSlide), počet snímků a čísla snímků. Používá [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) k načtení jak prvního snímku, tak každého snímku ve sbírce. Pro prázdnou sekci má vrácená kolekce velikost nula, indexovaný přístup je přeskočen a smyčka neprovádí žádné operace.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Příslušnost ke sekci je určena strukturou sekcí v prezentaci. Nepočítejte ručně rozsah sekce z [Section.getStartedFromSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getStartedFromSlide), indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou změnit jak snímky vrácené pro sekci, tak jejich čísla. To zahrnuje přeskupování snímků, klonování snímku do sekce, přesunutí sekce spolu s jejími snímky, odstraňování snímků a odstraňování sekcí. Další příklad volá [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getSlidesListOfSection) po každé takové změně místo zachování předpokladů o dřívějších hranicích sekce.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Volajte [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getSlidesListOfSection) znovu vždy, když jsou snímky nebo sekce přeskupeny, klonovány, přesunuty nebo odstraněny. Tím zajistíte, že následné zpracování bude odpovídat aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Používejte tento postup s formátem, který sekce podporuje, například PPTX; převod na PPT odstraní strukturu sekcí potřebnou pro následnou iteraci.

## **Často kladené otázky**

**Jsou sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí je při uložení do .ppt ztraceno.

**Lze celou sekci „skrýt“?**

Ne. Sekce nemá stav viditelnosti. Pro skrytí jejího obsahu zavolejte [Slide.setHidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#setHidden) pro každý snímek v sekci.

**Jak mohu najít sekci, která obsahuje konkrétní snímek?**

Projděte každou sekci ve sbírce vrácené metodou [Presentation.getSections](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSections), zavolejte pro ni [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getSlidesListOfSection) a porovnejte vrácené snímky s požadovaným snímkem. Pro ne‑prázdnou sekci vrací [Section.getStartedFromSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getStartedFromSlide) její první snímek; pro prázdnou sekci vrací `null`.