---
title: Betűtípus-helyettesítés beállítása prezentációkban PHP használatával
linktitle: Betűtípus-helyettesítés
type: docs
weight: 70
url: /hu/php-java/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus-helyettesítés
- betűtípus cseréje
- betűtípus-csere
- helyettesítési szabály
- cserélési szabály
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: Állítsa be a betűtípus-helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for PHP-ban Java-on keresztül a PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során.
---
## **Áttekintés**

A betűtípus‑helyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy olyan betűtípus helyett, amelyet a prezentáció renderelése vagy konvertálása során nem lehet elérni. A helyettesítés a megjelenített kimenetet befolyásolja; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Megadhatja, hogy melyik betűtípust használja, ha egy adott betűtípus nem áll rendelkezésre, és megvizsgálhatja a helyettesítéseket, amelyeket az Aspose.Slides a renderelés során végrehajt. Ez segít az eredmény konzisztens megtartásában a különböző telepített betűtípusokkal rendelkező környezetek között.

## **Betűtípus‑helyettesítések lekérdezése**

Használja a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getsubstitutions/) metódust annak meghatározásához, hogy a prezentáció renderelése során mely betűtípusok lesznek helyettesítve. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok neveit azonosítják.

Az alábbi PHP példa felsorolja a prezentáció összes betűtípus‑helyettesítését:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Betűtípus‑helyettesítések lekérdezése a kiválasztott diákhoz**

Használja a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getsubstitutions/) túlterhelést `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket vizsgálja. Ez hasznos, ha a prezentáció egy részét rendereli vagy exportálja, egy nagy prezentációt fokozatosan ellenőrzi, olyan diákokat keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuscsomagot készít szerverhez vagy konténerhez, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diát feldolgozná.

A `slides` tömb egy‑alapú diákindexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation::getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) gyűjteményhozzáférő nullábas indexelést használ, így ugyanaz a dia `$presentation->getSlides()->get_Item(0)`‑ként érhető el. Tartsa szem előtt ezt a különbséget a tömb építésekor, hogy elkerülje az egy‑off‑by‑one hibákat.

Hívja meg a túlterhelést a [Presentation::getFontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getFontsManager) metóduson keresztül. Csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusok neveit tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet, a beállított visszaeső szabályokat, a [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat, valamint a [külső betöltésű betűtípusokat](/slides/hu/php-java/custom-font/).

Ugyanaz a helyettesítés több kiválasztott dián is előfordulhat. Szűrje le a duplikátumokat, amikor betűtípus‑leltárt vagy elő‑letöltési jelentést készít. Az alábbi példa minden visszakapott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus‑leképezésekről:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

A [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/) osztály mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet hatókörének megfelelően:

| Túlterhelés | Használja, ha |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getsubstitutions/) argumentumok nélkül | A teljes prezentációhoz szükséges a helyettesítések. |
| [getSubstitutions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getsubstitutions/) `int[] slides` paraméterrel | Kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz van szükség helyettesítésekre. |

## **Betűtípus‑helyettesítési szabályok beállítása**

A forrásbetűtípus nem elérhető esetén a következő lépésekben adhatja meg, hogy az Aspose.Slides mely betűtípust használja:

1. Töltse be a prezentációt.  
2. Hozzon létre betűtípus‑definíciókat a forrás és a helyettesítő betűtípusokhoz.  
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstcondition/) feltétellel.  
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsubstrulecollection/) gyűjteményhez.  
5. Rendelje hozzá a gyűjteményt a [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) metódus segítségével.  
6. Renderelje vagy konvertálja a prezentációt.

Az alábbi PHP példa a `Arial` betűtípust használja a `SomeRareFont` helyett, amikor a `SomeRareFont` nem érhető el, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
A prezentációban felhasznált betűtípusok mindenütt történő feltétlen módosításához lásd a [Font Replacement](/slides/hu/php-java/font-replacement/) oldalt.
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípus‑helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus‑kiválasztási folyamat részei. Normál szövegnél működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípussal helyettesíthet.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math**‑ot használ, az Aspose.Slides számára előfordulhat, hogy pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípust, például **STIX Two Math**‑ot helyettesítő szabály nem tudja felváltani a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is azt jelezheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye elérhetővé a **Cambria Math**‑ot az Aspose.Slides számára. Telepítse a rendszerben, vagy töltse be egy [külső betűtípusként](/slides/hu/php-java/custom-font/).

Ez a korlátozás az egyenlet‑elrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a normál prezentáció‑szövegre.

## **FAQ**

**Mi a különbség a betűtípус‑csere és a betűtípus‑helyettesítés között?**

[Font replacement](/slides/hu/php-java/font-replacement/) célzottan megváltoztat egy betűtípust egy másikra a teljes prezentáció során. A betűtípus‑helyettesítés egy betűtípust választ a megjelenített kimenethez, amikor a beállított feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [font selection sequence](/slides/hu/php-java/font-selection-sequence/) folyamatában renderelés és konvertálás közben. `WhenInaccessible` esetén a szabály csak akkor kerül használatra, ha az Aspose.Slides nem tudja elérni a forrásbetűtípust.

**Mi történik, ha egy betűtípus hiányzik és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata szerint. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [Betöltheti a külső betűtípusokat](/slides/hu/php-java/custom-font/), hogy az Aspose.Slides használni tudja őket a renderelés és konvertálás során.

**Terjeszti-e az Aspose a betűtípusokat a könyvtárral együtt?**

Nem. Ön felelős a betűtípusok biztosításáért és a licencfeltételek betartásáért.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként különböznek, így egy gépen elérhető betűtípus másik gépen helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konverziók során?**

Használjon ugyanazokat a betűtípus‑fájlokat és verziókat minden gépen vagy konténerben, [töltse be a szükséges külső betűtípusokat](/slides/hu/php-java/custom-font/), és [ágyazzon be betűtípusokat](/slides/hu/php-java/embedded-font/), ha a licenc ezt megengedi. Exportálás előtt meghívhatja a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getsubstitutions/) metódust is, hogy azonosítsa a váratlan helyettesítéseket.