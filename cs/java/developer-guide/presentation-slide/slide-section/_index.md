---
title: Správa sekcí snímků v prezentacích pomocí Javy
linktitle: Sekce snímků
type: docs
weight: 90
url: /cs/java/slide-section/
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
- Java
- Aspose.Slides
description: "Spravujte sekce snímků pomocí Aspose.Slides pro Javu: vytvářejte, přejmenovávejte, měňte pořadí, získávejte a zpracovávejte snímky sekcí v PPTX prezentacích."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímku. S Aspose.Slides pro Java můžete vytvářet, měnit pořadí, přejmenovávat, kontrolovat a odstraňovat sekce pomocí metody [Presentation.getSections](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSections--) .

Sekce jsou užitečné zejména tehdy, když:

- velká prezentace musí být rozdělena na logické témata nebo kapitoly;
- různé skupiny snímků jsou přiděleny různým spolupracovníkům;
- snímky je nutné zpracovávat, přesouvat nebo slučovat ve skupinách.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, používejte API sekcí k určení příslušnosti místo odvození z pozic snímků.

## **Vytváření a správa sekcí**

Metodou [ISectionCollection.addSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) vytvoříte sekci zadáním jejího názvu a úvodního snímku. Aspose.Slides určuje, které snímky do sekce patří, podle aktuální struktury sekcí v prezentaci.

Stejné rozhraní [ISectionCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/) vám také umožňuje:

- přesunout sekci spolu s jejími snímky pomocí [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- odstranit pouze definici sekce pomocí [ISectionCollection.removeSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), čímž zachováte její snímky;
- odstranit sekci i její snímky pomocí [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- přidat prázdnou sekci na konec pomocí [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji spolu se snímky a přidá prázdnou sekci:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Po těchto operacích obsahuje prezentace sekci `Introduction` s jejími snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Pro přejmenování sekce zavolejte její metodu [ISection.setName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#setName-java.lang.String-). Snímky a pozice sekce zůstávají beze změny.

Následující příklad vytvoří sekci a změní její název:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Získání snímků ze sekcí**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSections--) vrací [ISectionCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectioncollection/), kterou můžete iterovat. Pro každou [ISection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/) zavolejte [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getSlidesListOfSection--) a získáte snímky, které do ní aktuálně patří. Metoda vrací [ISectionSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectionslidecollection/), která poskytuje počet, indexovaný přístup i iteraci.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou sekci a poté vypíše pro každou sekci [name](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getStartedFromSlide--), počet snímků a čísla snímků. K načtení prvního snímku používá [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) a rozšířený příkaz `for` pro zpracování každého snímku. U prázdné sekce má vrácená kolekce velikost nula, metoda se nevolá a iterace neprovádí žádné operace.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Členství v sekci je určeno strukturou sekcí v prezentaci. Nepočítejte ručně rozsah sekce z [ISection.getStartedFromSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getStartedFromSlide--), indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou změnit jak snímky vrácené pro sekci, tak jejich čísla. To zahrnuje změnu pořadí snímků, klonování snímku do sekce, přesunutí sekce spolu se snímky, odstraňování snímků i odstraňování sekcí. Další příklad volá [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getSlidesListOfSection--) po každé takové změně místo zachovávání předpokladů o dřívějších mezích sekce.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Zavolejte [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getSlidesListOfSection--) znovu vždy, když jsou snímky nebo sekce přeuspořádány, klonovány, přesouvány nebo odstraňovány. Tím zajistíte, že následné zpracování bude odpovídat aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Použijte tento postup s formátem, který sekce podporuje, například PPTX; převod do PPT odstraní strukturu sekcí potřebnou pro pozdější iteraci.

## **FAQ**

**Zůstávají sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při uložení do .ppt ztratí.

**Lze celou sekci „skrýt“?**

Ne. Sekce nemá stav viditelnosti. Pro skrytí obsahu sekce zavolejte [ISlide.setHidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#setHidden-boolean-) pro každý snímek v sekci.

**Jak najít sekci, která obsahuje určitý snímek?**

Iterujte přes kolekci vrácenou metodou [Presentation.getSections](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSections--), pro každou sekci zavolejte [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getSlidesListOfSection--) a porovnejte vrácené snímky s cílovým snímkem. U nesmytné sekce metoda [ISection.getStartedFromSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getStartedFromSlide--) vrací první snímek; u prázdné sekce vrací `null`.