---
title: Prezentációk lokalizációjának automatizálása PHP-ben
linktitle: Prezentációk lokalizációja
type: docs
weight: 100
url: /hu/php-java/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- helyesírási nyelv
- nyelvazonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Állítsa be a helyesírási nyelveket PowerPoint és OpenDocument prezentációk szövegéhez PHP-ben az Aspose.Slides használatával, beleértve az alapértelmezetteket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egyes szövegrészekhez konfigurálja a helyesírási metaadatokat. Használja a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) a helyesírási nyelv azonosításához, a [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setSpellCheck) a helyesírás-ellenőrzés engedélyezéséhez vagy letiltásához, valamint a [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setProofDisabled) a szélesebb körű „ne ellenőrizze” állapot vezérléséhez. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző helyesírási szabályokat is tartalmazhat.

Ez a cikk bemutatja, hogyan rendelhet nyelvet egy adott szöveghez, hogyan állíthatja be az új szöveg alapértelmezett nyelvét a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) segítségével, hogyan építhet többnyelvű bekezdéseket, hogyan választhat a `SpellCheck` és a `ProofDisabled` között, és hogyan őrizheti meg a kívánt beállításokat a [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) használata során. Ezek a tulajdonságok metaadatot tárolnak a bemutatóalkalmazások számára; nem fordítják le a szöveget, nem végeznek szótári alapú helyesírás-ellenőrzést, és nem adnak vissza hibás szavakat.

## **A helyesírási nyelv beállítása a szöveghez**

Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/), érje el a szükséges szövegrészt a [Portion::getPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getPortionFormat) segítségével, és állítsa be annak nyelvazonosítóját. Az alábbi példa létrehoz egy alakzatot, brit angolt állít be helyesírási nyelvként, és a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) segítségével menti az eredményt:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Az új szöveg alapértelmezett nyelvének beállítása**

Használja a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust annak a helyesírási nyelvnek a megadására, amelyet az Aspose.Slides az újonnan létrehozott szövegre alkalmaz. Ez a beállítás akkor hasznos, ha a bemutató nagy része vagy egészben ugyanazt a nyelvet használja. Nem változtatja meg a már kifejezett nyelvi metaadatot tartalmazó szöveg nyelvét.

Az alábbi példa egy olyan bemutatót hoz létre, amelynek új szövege német helyesírási szabályokat használ:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Több nyelv használata egy bekezdésben**

Egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) a szövegrészek gyűjteményét tartalmazza. Hozzon létre külön [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) elemet minden nyelvhez, és állítsa be annak `LanguageId` értékét függetlenül.

Ez a példa egy bekezdést hoz létre angol és francia részekkel:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Helyesírás-ellenőrzés engedélyezése vagy letiltása az egyes részeknél**

A [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) örökli a [BasePortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/) által definiált közös szövegtulajdonságokat. Érje el egy rész formátumát a [Portion::getPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getPortionFormat) segítségével, és használja a [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setSpellCheck) metódust annak szabályozására, hogy a bemutatóalkalmazás ellenőrizheti-e a helyesírást az adott részhez. Az alapérték `false`: a `true` engedélyezi a helyesírás-ellenőrzést, míg a `false` letiltja azt.

A beállítás az egyes szövegrészekre vonatkozik. Így a ugyanabban a bekezdésben lévő különböző részek eltérő értékeket használhatnak. A [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) és a `setSpellCheck` kiegészítő célokat szolgálnak: az `setLanguageId` meghatározza a helyesírási nyelvet, míg a `setSpellCheck` szabályozza, hogy a rész számára engedélyezve van-e a helyesírás-ellenőrzés.

A [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setProofDisabled) szintén a helyesírást vezérli, de a szélesebb körű „ne ellenőrizze” állapotot egy [NullableBool](https://reference.aspose.com/slides/hu/php-java/aspose.slides/nullablebool/) értékkel reprezentálja. Használja a `setSpellCheck` metódust, ha kifejezetten a helyesírás-ellenőrzés be- vagy kikapcsolására van szükség. Használja a `setProofDisabled` metódust, ha a bemutató „nem ellenőrzött” metaadatait, beleértve a `NotDefined` állapotot, meg kell őrizni vagy explicit módon szabályozni. Ha mindkét tulajdonságot beállítja, tartsa konzisztensen az értékeket; ne kombinálja a `setSpellCheck(true)`-t a `setProofDisabled(NullableBool::True)`-val.

Ezek a tulajdonságok a PowerPoint és egyéb bemutatóalkalmazások által használt helyesírási metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótári alapú helyesírás-ellenőrzéshez, és nem ad vissza hibás szavak listáját.

Az alábbi teljes példa bemutat egy bemeneti bemutató betöltését, különböző helyesírási beállítások és nyelvek hozzárendelését két részhez ugyanabban a bekezdésben, a végeredmény mentését, újbóli megnyitását és a tárolt értékek ellenőrzését:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

A [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) azonos formázású szomszédos részeket egyesíti. A `SpellCheck` érték különbözése önmagában nem tartja szét ezeket a részeket; az egyesítés után az eredményrész megtartja az első rész `SpellCheck` értékét. Ha a részeknek különböző helyesírási beállításokra van szükségük, hívja a `joinPortionsWithSameFormatting` metódust a beállítások hozzárendelése előtt, vagy ellenőrizze az eredményrész határait, és alkalmazza újra a beállításokat utána. A különböző `LanguageId` értékű részek továbbra is külön maradnak, mivel a helyesírási nyelv formázása eltérő.

## **GYIK**

**A nyelvazonosító lefordítja a szöveget?**

Nem. A [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) a helyesírási és nyelvtani metaadatokat tárolja; nem módosítja a szövegtartalmat. A szöveget külön kell lefordítani, majd a megfelelő nyelvazonosítót beállítani az egyes lefordított részekhez.

**A helyesírási nyelv befolyásolja a betűtípusokat, elválasztást vagy sortörést?**

Nem. A nyelvazonosító csak a helyesírásra vonatkozik. A szöveg megjelenítése és elrendezése elsősorban az elérhető [fonts](/slides/hu/php-java/powerpoint-fonts/), az írásrendszer és a szövegkeret beállításaitól függ. A megbízható megjelenítéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/php-java/font-substitution/) lehetőséget, vagy ágyazza be a betűtípusokat a [embed fonts](/slides/hu/php-java/embedded-font/) résznél.

**Egy bekezdés használhat több helyesírási nyelvet?**

Igen. Rendeljen minden nyelvet egy külön részhez, ahogyan a többnyelvű bekezdés példában látható.

**A `setDefaultTextLanguage` vagy a `setLanguageId` a megfelelő?**

Használja a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust, ha alapértelmezett nyelvet akar megadni az újonnan létrehozott szöveghez. Használja a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) metódust, ha egy adott résznek explicit helyesírási nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.