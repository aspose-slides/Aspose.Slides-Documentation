---
title: Betűtípus helyettesítés beállítása prezentációkban PHP használatával
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/php-java/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus helyettesítés
- betűtípus cseréje
- betűtípus csere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Állítsa be a betűtípus helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for PHP-ban Java segítségével a PowerPoint és OpenDocument prezentációk megjelenítése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy olyan betűtípus helyett, amely a prezentáció megjelenítése vagy konvertálása során nem érhető el. A helyettesítés a megjelenített kimenetet érinti; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Megadhatja, hogy melyik betűtípust használja, ha egy adott betűtípus nem áll rendelkezésre, és ellenőrizheti a Aspose.Slides által a megjelenítés során végrehajtott helyettesítéseket. Ez segít az output konzisztens megtartásában különböző, eltérő telepített betűtípusokkal rendelkező környezetek között.

Ha egy betűtípus elérhető, de nem rendelkezik dedikált félkövér változattal, lásd a [Betűtípusok kezelése dedikált félkövér betűtípus nélkül](/slides/hu/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) című szakaszt. Az a szakasz bemutatja, hogyan lehet rasterizálni az érintett szöveget a PDF exportálás során, valamint a szövegválasztásra, keresésre és méretezésre gyakorolt hatásokat.

## **Betűtípus helyettesítések lekérése**

Használja a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) metódust annak meghatározásához, hogy mely betűtípusok lesznek helyettesítve a prezentáció megjelenítésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok nevét azonosítják.

A következő PHP példa felsorolja az összes betűtípus helyettesítést egy prezentációhoz:

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

## **Kijelölt diák betűtípus helyettesítéseinek lekérése**

Használja a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) túlterhelését `int[] slides` argumentummal, hogy csak a konkrét diák megjelenítéséhez szükséges helyettesítéseket vizsgálja. Ez akkor hasznos, ha a prezentáció egy részét jeleníti meg vagy exportálja, nagy prezentációt inkrementálisan ellenőriz, olyan diákot keres, amelyek nem elérhető betűtípusoktól függenek, egy minimális betűtípuscsomagot készít a szerver vagy tároló számára, vagy a megjelenítési különbségeket diagnosztizálja anélkül, hogy a nem kapcsolódó diákot feldolgozná.

A `slides` tömb egy‑alapú diák indexeket tartalmaz: az `1` az első diát jelöli. Ezzel szemben a [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) gyűjtemény‑hozzáférő null‑alapú indexelést használ, így ugyanaz a dia `$presentation->getSlides()->get_Item(0)` formában érhető el. Tartsa szem előtt ezt a különbséget a tömb építésekor, hogy elkerülje az egy‑off hibákat.

Hívja meg a túlterhelést a [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) metóduson keresztül. Ez csak a kiválasztott diák megjelenítése közben meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) objektum, amely tartalmazza az eredeti és a helyettesített betűtípusok nevét. Az eredmény tükrözi az aktuális betűtípus‑környezetet, a konfigurált tartalék‑szabályokat, a [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűtípusokat](/slides/hu/php-java/custom-font/).

Ugyanaz a helyettesítés több mint egy kiválasztott dián is szükséges lehet. Szűrje le a duplikált eredményeket, amikor betűtípus‑leltárt vagy előrepülés‑jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus‑leképezésekről:

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

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) osztály mindkét túlterhelést biztosítja. Válasszon egyet a megjelenítési művelet hatókörének megfelelően:

| Túlterhelés | Mikor használja |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) argumentumok nélkül | Ha a teljes prezentációhoz van szükség helyettesítésekre. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) `int[] slides`‑el | Ha egy kiválasztott tartományhoz, inkrementális ellenőrzéshez vagy részleges exportáláshoz van szükség helyettesítésekre. |

## **Betűtípus helyettesítési szabályok beállítása**

A betűtípus megadásához, amelyet az Aspose.Slides-nek kell használnia, ha a forrásbetűtípus nem érhető el:

1. Töltse be a prezentációt.
2. Hozzon létre betűtípus‑definíciókat a forrás‑ és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) elemet a [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Az [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) metódussal rendelje hozzá a gyűjteményt.
6. Renderelje vagy konvertálja a prezentációt.

A következő PHP példa a `SomeRareFont` helyett az `Arial` betűtípust használja, amikor a `SomeRareFont` nem érhető el, majd rendereli az első diát a eredmény ellenőrzéséhez. A helyettesítő betűtípust elérhetőnek kell lennie az Aspose.Slides számára.

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
A prezentációban használt betűtípusok feltétel nélküli módosításához lásd a [Betűtípus csere](/slides/hu/php-java/font-replacement/) című oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusoknál**

A betűtípus helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus‑kiválasztási folyamat részét képezik. Rendszeres szövegnél működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípusra tudja cserélni.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slides-nek pontosan azt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípust (például **STIX Two Math**) helyettesítő szabály nem helyettesítheti a **Cambria Math** betűtípust ebben a célban, és a renderelés továbbra is jelezheti, hogy **Cambria Math** szükséges.

Egy ilyen prezentáció rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust elérhetővé az Aspose.Slides számára. Telepítse azt az operációs rendszerbe, vagy töltse be [külső betűtípusként](/slides/hu/php-java/custom-font/).

Ez a korlátozás az egyenleti elrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció szokásos szövegére.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtípus helyettesítés között?**

[Betűtípus csere](/slides/hu/php-java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentáció során. A betűtípus helyettesítés a megjelenített kimenethez választ egy betűtípust, amikor a konfigurált feltétel teljesül, például amikor az eredeti betűtípus nem érhető el.

**Mikor kerülnek alkalmazásra a helyettesítési szabályok?**

A szabályok a [betűtípus választási sorozat](/slides/hu/php-java/font-selection-sequence/) résztvevői a renderelés és konvertálás során. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem tudja elérni a forrásbetűtípust.

**Mi történik, ha egy betűtípus hiányzik, és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a saját betűtípus‑kiválasztási folyamata szerint a legközelebbi elérhető betűtípust választja. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [Betölthet külső betűtípusokat](/slides/hu/php-java/custom-font/), hogy az Aspose.Slides a renderelés és konvertálás során használhassa őket.

**Terjeszti-e az Aspose a betűtípusokat a könyvtárral?**

Nem. Ön felelős a betűtípusok biztosításáért és azok licencfeltételeinek betartásáért.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként eltérnek, ezért egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus kiválasztást konzisztenssé kötegelt konvertálások során?**

Használjon azonos betűtípus‑fájlokat és verziókat minden gépen vagy konténeren, [töltse be a szükséges külső betűtípusokat](/slides/hu/php-java/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/php-java/embedded-font/), ha a licenc engedélyezi. Az exportálás előtt hívhatja a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) metódust is, hogy azonosítsa a váratlan helyettesítéseket.