---
title: Dia szekciók kezelése prezentációkban PHP-val
linktitle: Dia Szekció
type: docs
weight: 90
url: /hu/php-java/slide-section/
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
- PHP
- Aspose.Slides
description: "Dia szekciók kezelése az Aspose.Slides for PHP via Java segítségével: szekciók létrehozása, átnevezése, átrendezése, lekérése és a szekció diáinak feldolgozása PPTX prezentációkban."
---
## **Bevezetés**

A szekciók egymás után következő diákból névvel ellátott csoportokat szerveznek anélkül, hogy megváltoztatnák a diák tartalmát. Az Aspose.Slides for PHP via Java segítségével szekciókat hozhat létre, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat a [Presentation::getSections](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSections) metódussal.

A szekciók különösen hasznosak, ha:
- egy nagy prezentációt logikai témákra vagy fejezetekre kell felosztani;
- a diák különböző csoportjait különböző együttműködőkre kell kiosztani;
- a diákat csoportként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon tömör szekciónévket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a prezentáció struktúrájának részei, használja a szekció API-kat a tagság meghatározásához, ahelyett, hogy a dia pozíciókból következtetne.

## **Szekciók létrehozása és kezelése**

A szekció létrehozásához a [SectionCollection::addSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/#addSection) metódust használja, megadva a nevét és a kezdő diát. Az Aspose.Slides a prezentáció aktuális szekciószerkezetéből határozza meg, mely diák tartoznak a szekcióhoz.

Ugyanaz a [SectionCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/) lehetővé teszi azt is, hogy:
- mozgassa a szekciót a diái együtt a [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides) használatával;
- csak a szekciódefiníciót távolítsa el a [SectionCollection::removeSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/#removeSection) segítségével, amely megtartja a diákat;
- a szekciót és diáit távolítsa el a [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides) segítségével;
- üres szekciót adjon hozzá a végén a [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/#appendEmptySection) segítségével.

A következő példa két szekciót hoz létre, az egyiknek áthelyezést végez, eltávolítja azt a diái együtt, majd egy üres szekciót fűz hozzá:
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

Az ezek után a prezentáció tartalmazza a `Introduction` szekciót a diái együtt, valamint egy üres `Appendix` szekciót. A `Results` szekciót és a diáit eltávolították.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez hívja meg a [Section::setName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#setName) metódust. A szekció diái és pozíciója változatlan marad.

A következő példa egy szekciót hoz létre és megváltoztatja a nevét:
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

## **Diák lekérése szekciókból**

Az [Presentation::getSections](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSections) metódus egy [SectionCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/) objektumot ad vissza, amelyet index szerint feldolgozhat. Minden [Section](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/) esetén hívja meg a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getSlidesListOfSection) metódust, hogy megkapja az adott szekcióba jelenleg tartozó diák listáját. A metódus egy [SectionSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionSlideCollection/) objektumot ad vissza, amely számot és indexelt hozzáférést biztosít.

A következő példa két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [name](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getStartedFromSlide), diákszámát és diaszámokat. Indexelt hozzáféréshez a [SectionCollection::get_Item](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionCollection/#get_Item) és a [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SectionSlideCollection/#get_Item) metódusokat használja. Az üres szekció esetén a visszaadott gyűjtemény mérete nulla, és a `get_Item` nem kerül meghívásra.
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

A szekció tagságát a prezentáció szekciószerkezete határozza meg. Ne számítsa ki kézzel egy szekció tartományát a [Section::getStartedFromSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getStartedFromSlide), a dia indexek és a következő szekció kezdő diája alapján.

A szerkezeti módosítások megváltoztathatják a szekcióhoz visszaadott diák számát és azok dia számait is. Ide tartozik a diák átrendezése, egy dia klónozása egy szekcióba, egy szekció és diái áthelyezése, diák eltávolítása és szekciók eltávolítása. A következő példa minden ilyen változás után meghívja a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getSlidesListOfSection) metódust, ahelyett, hogy a szekció korábbi határait feltételezné.
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

Hívja meg a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getSlidesListOfSection) metódust újra, amikor a diák vagy szekciók átrendezésre, klónozásra, áthelyezésre vagy eltávolításra kerülnek. Ez biztosítja, hogy a további feldolgozás az aktuális prezentációs struktúrához igazodjon.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatait. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX; PPT-re konvertálás eltávolítja a későbbi iterációhoz szükséges szekciószerkezetet.

## **GYIK**

**A szekciók megmaradnak, ha PPT (PowerPoint 97–2003) formátumba mentünk?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, ezért a szekciócsoportosítás elveszik, amikor .ppt‑be mentünk.

**Lehet egy teljes szekciót „elrejteni”?**

Nem. A szekciónak nincs láthatósági állapota. Tartalmának elrejtéséhez hívja meg a [Slide::setHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Slide/#setHidden) metódust minden szekcióbeli diára.

**Hogyan találhatom meg azt a szekciót, amely tartalmaz egy diát?**

Iteráljon végig a [Presentation::getSections](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSections) által visszaadott gyűjteményen, hívja meg minden szekcióra a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getSlidesListOfSection) metódust, és hasonlítsa össze a visszakapott diák listáját a céldával. Nem üres szekció esetén a [Section::getStartedFromSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getStartedFromSlide) visszaadja az első diát; üres szekció esetén `null` értéket ad.