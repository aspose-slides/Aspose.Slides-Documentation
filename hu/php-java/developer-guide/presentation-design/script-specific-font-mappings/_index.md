---
title: Szkript-specifikus téma betűtípusok kezelése PHP-ben
linktitle: Szkript-specifikus téma betűtípusok
type: docs
weight: 15
url: /hu/php-java/script-specific-font-mappings/
keywords:
- szkript-specifikus betűtípus
- téma betűtípus leképezés
- többnyelvű prezentáció
- írásrendszer
- cirill betűtípus
- arab betűtípus
- japán betűtípus
- grúz betűtípus
- thaana betűtípus
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Vizsgálja, adja hozzá, cserélje ki és távolítsa el a szkript-specifikus betűtípus-leképezéseket a PowerPoint témákban az Aspose.Slides for PHP segítségével Java-n keresztül."
---
## **Áttekintés**

A prezentáció témája különböző betűtípus‑családokat választhat különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is téma‑betűtípusokat használ, egy koordinált betűtípus‑sémát kövessen, miközben a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez megfelelő betűtípusokat alkalmaz.

A téma [FontScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) egy fő betűtípus‑gyűjteményt tartalmaz, amelyet általában a címsorokhoz használnak, valamint egy mellék betűtípus‑gyűjteményt, amelyet a törzsszöveghez használnak. A Latin‑ és Kelet‑Ázsiai betűtípus‑beállításaikon kívül mindkét [Fonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/) gyűjtemény leképezéseket biztosít az írásrendszer‑címkék és a betűtípus‑családnevek között.

Ez a cikk bemutatja, hogyan lehet ezeket a leképezéseket megvizsgálni és módosítani a prezentáció mester‑témájában, valamint ellenőrizni, hogy a változások megmaradnak‑e egy mentés‑újratöltés ciklus után.

## **Szkriptcímkék megértése**

A szkript‑betűtípus‑módszerek négybetűs BCP 47 szkript‑alcímkéket használnak az írásrendszerek azonosításához. Gyakori értékek:

| Szkriptcímke | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűtípus‑sémájához tartoznak, nem egyedi szövegrészekhez. Egy prezentáció különböző leképezéseket definiálhat a fő és a mellék gyűjteményekhez, illetve elhagyhat leképezéseket egyes szkriptekhez.

## **Szkriptbetűtípus-leképezések elérése és vizsgálata**

Használja a [Presentation::getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasterTheme) metódust a prezentáció‑szintű téma eléréséhez. A [MasterTheme::getFontScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/#getFontScheme), a [FontScheme::getMajor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/#getMajor) és a [FontScheme::getMinor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/#getMinor) módszerek hozzáférést biztosítanak a két [Fonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/) gyűjteményhez.

Hívja a [Fonts::getScriptFontMap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/#getScriptFontMap) metódust az összes leképezés lekéréséhez egy gyűjteményből. Egy írásrendszer kereséséhez hívja a [Fonts::getScriptFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/#getScriptFont)‑t a szkriptcímkével. A `Fonts::getScriptFont` `null`‑t ad vissza, ha az adott gyűjtemény nem definiálja a kért leképezést.

## **Leképezések módosítása és tartósság ellenőrzése**

Használja a [Fonts::setScriptFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/#setScriptFont)‑t új leképezés létrehozásához vagy a meglévő betűtípus‑család felülírásához. A [Fonts::removeScriptFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/#removeScriptFont)‑t a leképezés eltávolításához.

Az alábbi vég‑vég példakód beolvassa az összes létező fő és mellék leképezést, megkeresi a japán fő betűtípust, módosítja a cirill fő betűtípust, eltávolítja a thaana mellék leképezést, elmenti a prezentációt, majd újra megnyitja annak ellenőrzésére, hogy mindkét változás megtartásra került‑e. A törlés lépését függetlené tesszük a kezdeti témától, a kód csak akkor hoz létre thaana leképezést, ha az még nincs definiálva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Az ellenőrzés ugyanazt a `null` viselkedést használja, mint egy szokásos lekérdezés: a törlés mentése után a `Fonts::getScriptFont("Thaa")` `null`‑t ad a mellék gyűjteményre.

## **Témaleképezések megkülönböztetése egyéb betűtípus‑beállításoktól**

A szkript‑specifikus téma leképezések részt vesznek a betűtípus‑kiválasztásban, de más problémákat oldanak meg, mint a közvetlen szövegformázás, helyettesítés és tartalék:

| Mechanizmus | Cél | A téma leképezés módosításának hatása |
|---|---|---|
| Szkript‑specifikus téma betűtípus leképezés | Kiválaszt egy fő vagy mellék téma betűtípust egy írásrendszerhez. | Az a szöveg, amely még mindig a megfelelő téma betűtípust használja, az új leképezett családra fordítható. |
| Betűtípus, amely kifejezetten egy szövegrészhez van hozzárendelve | Rögzíti a kért betűtípus‑családot azon részre a téma helyett. | A rész változatlan maradhat, mert közvetlen formázása felülírja a téma választását. |
| Betűtípus helyettesítés | Kicserél egy kért betűtípust, ha az nem érhető el, vagy ha egy helyettesítési szabály érvényesül. | A betűtípus kérés után lép működésbe; nem definiálja újra a téma szkript leképezését. |
| Betűtípus tartalék | Biztosítja a kiválasztott betűtípusban hiányzó glifeket, gyakran meghatározott Unicode tartományokhoz. | Kitölti a hiányzó glifek lefedettségét; nem módosítja a tárolt téma leképezést. |

További információért a két utolsó mechanizmusról lásd a [Font Substitution](/slides/hu/php-java/font-substitution/) és a [Fallback Fonts](/slides/hu/php-java/fallback-font/) oldalakat.

A [Presentation::getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasterTheme)‑ben történő leképezés‑módosítás csak azon tartalmakra hat, amelyek hatékony formázása még mindig az adott témára támaszkodik. A szöveg szintén örökölhet téma‑felülírást egy mestertől, elrendezéstől vagy diától, vagy kifejezetten hozzárendelt betűtípust használhat. Vizsgálja meg ezeket a szinteket, ha a látható eredmény nem a prezentáció‑szintű leképezésnek megfelelő.

## **Leképezett betűtípusok elérhetővé tétele és az eredmény ellenőrzése**

Egy szkript‑leképezés csak egy betűtípus‑család nevét tárolja; nem telepíti vagy tölti be a megfelelő betűtípus‑fájlt. A következetes megjelenítéshez és exportáláshoz minden leképezett betűtípust telepíteni kell a környezetben, vagy elérhetővé kell tenni az Aspose.Slides számára egy egyéni forráson keresztül, például a [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts) vagy a [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) segítségével. Az elérhető betöltési lehetőségekért lásd a [Custom Fonts](/slides/hu/php-java/custom-font/) oldalt.

A mentett leképezés ellenőrzése csak azt igazolja, hogy a téma‑definíció megmaradt. Nem bizonyítja, hogy a betűtípus elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést eredményezi. Rendereljen reprezentatív szöveget minden szükséges írásrendszerhez képben vagy PDF‑ben, és ellenőrizze a kimenetet. Ez felfedi a hiányzó betűtípusokat, a nem teljes glif‑lefedettséget, a tartalék‑viselkedést és az elrendezés‑változásokat, mielőtt a prezentációt terjesztené. Lásd a [Convert PowerPoint Presentations](/slides/hu/php-java/convert-powerpoint/) oldalt a renderelési és exportálási példákért.

## **GYIK**

**Mi a visszatérési értéke a `Fonts::getScriptFont`‑nak, ha egy szkript nincs leképezve?**

`[Fonts::getScriptFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/#getScriptFont)` `null`‑t ad vissza, ha a kért szkript leképezés nincs definiálva az adott fő vagy mellék betűtípus‑gyűjteményben.

**A `Fonts::setScriptFont` hozzáad egy második leképezést, ha a szkript már létezik?**

Nem. `[Fonts::setScriptFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fonts/#setScriptFont)` létrehozza a leképezést, ha hiányzik, és felülírja a leképezett betűtípus‑családot, ha a megfelelő szkriptcímke már jelen van.

**Miért nem változott meg egyes szövegek, amikor a téma leképezését módosítottam?**

A szöveg lehet, hogy kifejezetten egy betűtípust kapott, örököl egy másik témát felülírás révén, vagy a renderelés során helyettesítés vagy tartalék befolyásolja. Egy prezentáció‑szintű szkript‑leképezés csak azokra a szövegekre hat, amelyek hatékony formázása továbbra is arra a téma‑betűtípus‑gyűjteményre hivatkozik.

**Elég-e a mentés és újra megnyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újra megnyitás csak a téma‑adatok tartósságát ellenőrzi. Emellett rendereljen reprezentatív szöveget minden szükséges írásrendszerre, hogy megerősítse, hogy a leképezett betűtípusok elérhetők és tartalmazzák a szükséges glifeket.