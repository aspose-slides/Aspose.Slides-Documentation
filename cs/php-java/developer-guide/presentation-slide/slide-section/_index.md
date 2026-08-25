---
title: Správa sekcí snímků v prezentacích pomocí PHP
linktitle: Sekce snímků
type: docs
weight: 90
url: /cs/php-java/slide-section/
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
- PHP
- Aspose.Slides
description: "Spravujte sekce snímků pomocí Aspose.Slides pro PHP přes Java: vytvářejte, přejmenovávejte, přeskupujte, získávejte a zpracovávejte snímky sekcí v prezentacích PPTX."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímku. S Aspose.Slides pro PHP přes Java můžete vytvářet, přeskupovat, přejmenovávat, prohlížet a odstraňovat sekce pomocí metody [Presentation::getSections](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSections).

Sekce jsou zvláště užitečné, když:

- velká prezentace potřebuje být rozdělena na logická témata nebo kapitoly;
- různé skupiny snímků jsou přiřazeny různým spolupracovníkům;
- snímek je třeba zpracovat, přesunout nebo sloučit jako skupinu.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, použijte API sekcí k určení členství místo odvození z pozic snímků.

## **Vytváření a správa sekcí**

Pomocí [SectionCollection::addSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/#addSection) vytvoříte sekci zadáním jejího názvu a úvodního snímku. Aspose.Slides určuje, které snímky patří do sekce, z aktuální struktury sekcí v prezentaci.

Stejná [SectionCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/) vám také umožňuje:

- přesunout sekci společně s jejími snímky pomocí [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- odstranit pouze definici sekce pomocí [SectionCollection::removeSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/#removeSection), což zachová její snímky;
- odstranit sekci i její snímky pomocí [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- přidat prázdnou sekci na konec pomocí [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji společně s jejími snímky a přidá prázdnou sekci:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Po těchto operacích obsahuje prezentace sekci `Introduction` s jejími snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Chcete-li sekci přejmenovat, zavolejte její metodu [Section::setName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#setName). Snímky sekce a její pozice zůstanou nezměněny.

Následující příklad vytvoří sekci a změní její název:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Získání snímků ze sekcí**

Metoda [Presentation::getSections](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSections) vrací [SectionCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/), kterou můžete zpracovávat pomocí indexu. Pro každou [Section](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/), zavolejte [Section::getSlidesListOfSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getSlidesListOfSection), abyste získali snímky, které do ní aktuálně patří. Metoda vrací [SectionSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionSlideCollection/), která poskytuje počet a indexovaný přístup.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou sekci, poté vytiskne každé sekce [name](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getStartedFromSlide), počet snímků a čísla snímků. Používá [SectionCollection::get_Item](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionCollection/#get_Item) a [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SectionSlideCollection/#get_Item) pro indexovaný přístup. Pro prázdnou sekci vrácená kolekce má velikost nula a `get_Item` není voláno.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Členství v sekci je určeno strukturou sekcí v prezentaci. Nepočítejte ručně rozsah sekce z [Section::getStartedFromSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getStartedFromSlide), indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou změnit jak snímky vrácené pro sekci, tak jejich čísla. Patří sem přeskupování snímků, klonování snímku do sekce, přesun sekce společně s jejími snímky, odstraňování snímků i odstraňování sekcí. Další příklad volá [Section::getSlidesListOfSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getSlidesListOfSection) po každé takové změně místo zachovávání předpokladů o dřívějších hranicích sekce.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Volajte [Section::getSlidesListOfSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getSlidesListOfSection) znovu vždy, když jsou snímky nebo sekce přeskupeny, klonovány, přesunuty nebo odstraněny. Tím zajistíte, že následné zpracování bude odpovídat aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Použijte tento postup s formátem, který sekce podporuje, například PPTX; převod do PPT odstraní strukturu sekcí potřebnou pro pozdější iteraci.

## **Často kladené otázky**

**Je zachována struktura sekcí při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se po uložení do .ppt ztratí.

**Lze celou sekci „skrýt“?**

Ne. Sekce nemá stav viditelnosti. Pro skrytí jejího obsahu zavolejte [Slide::setHidden](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Slide/#setHidden) pro každý snímek v sekci.

**Jak najdu sekci, která obsahuje snímek?**

Procházejte kolekci vrácenou metodou [Presentation::getSections](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSections), zavolejte [Section::getSlidesListOfSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getSlidesListOfSection) pro každou sekci a porovnejte vrácené snímky s cílovým snímkem. Pro ne‑prázdnou sekci vrací [Section::getStartedFromSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getStartedFromSlide) její první snímek; pro prázdnou sekci vrací `null`.