---
title: Betűkészletek beágyazása prezentációkba PHP használatával
linktitle: Beágyazott betűkészletek
type: docs
weight: 40
url: /hu/php-java/embedded-font/
keywords:
- betűkészlet hozzáadása
- betűkészlet beágyazása
- betűkészlet beágyazás
- beágyazott betűkészlet lekérése
- beágyazott betűkészlet hozzáadása
- beágyazott betűkészlet eltávolítása
- beágyazott betűkészlet tömörítése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a beágyazott betűkészleteket a PowerPointban az Aspose.Slides for PHP via Java használatával. Betűkészletek hozzáadása, lekérése, eltávolítása és tömörítése a szöveg megjelenésének megőrzése és a fájlméret csökkentése érdekében."
---
## **Bevezetés**

A betűkészletek beágyazása a betűtípus‑adatokat a PowerPoint‑prezentációba tárolja. Ha a megjelenítő támogatja a beágyazott betűkészleteket, akkor a szöveget a betűkészletekkel jelenítheti meg, még ha azok nincsenek is telepítve a célrendszeren. Ez segít megőrizni a sortöréseket, a szövegközöket és a diaelrendezést.

Az Aspose.Slides for PHP via Java lehetővé teszi beágyazott betűkészletek lekérdezését, hozzáadását és eltávolítását a [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/) osztályon keresztül, amely a [Presentation::getFontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getFontsManager) visszaadja. A beágyazott betűtípus‑adat méretét is csökkentheted a prezentáció által nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. Betűkészlet beágyazása előtt győződj meg arról, hogy a betűtípus‑adatok elérhetők az Aspose.Slides számára, és a licenc engedélyezi a beágyazást.

## **Beágyazott betűkészletek lekérése és eltávolítása**

Használd a [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a prezentációban tárolt betűkészletek listázásához. Egy betűkészlet eltávolításához add át a listából a betűt a [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) metódusnak, majd mentsd el a prezentációt.

Az alábbi példa listázza a `EmbeddedFonts.pptx` fájl beágyazott betűkészleteit, és eltávolítja a Calibrít, ha megtalálható:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Egy beágyazott betűkészlet eltávolítása a tárolt betűtípus‑adatot törli; a szöveghez rendelt betűt nem változtatja meg. Ha a betűt a célrendszeren telepítve van, a szöveg továbbra is használhatja azt. Egyébként a rendereléshez szükség lehet [font substitution](/slides/hu/php-java/font-substitution/)-ra, ami befolyásolhatja az elrendezést.

## **Betűtípus‑adatok és beágyazási engedélyek ellenőrzése**

Használd a [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/) osztályt a betűkészletek beágyazása előtti vizsgálatához. Hívd a [FontsManager::getFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getFonts) metódust a prezentációban használt betűkészletek lekéréséhez. Minden egyes betűkészlethez add át egy [FontData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontdata/) objektumot és a szükséges [FontStyleType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontstyletype/) értéket a [FontsManager::getFontBytes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getFontBytes) metódusnak. A metódus a betűtípus‑stílus bináris adatait adja vissza, vagy `null`‑t, ha a kért betűt vagy stílust nem találja. Ne add át a `null` eredményt a [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) metódusnak, mert az byte‑tömböt vár.

[EmbeddingLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/embeddinglevel/) egy jelzőenumeráció, amely a betűtípusban tárolt beágyazási korlátozásokat jelzi:

- `Installable` engedélyezi a beágyazást és a tartós telepítést egy másik rendszeren, a betűtípus licencétől függően.
- `Restricted` tilos a beágyazás, hacsak a betűtípus jogtulajdonosától nem kapunk engedélyt, ha ez az egyetlen használati engedély jelző.
- `PreviewPrint` engedélyezi az ideiglenes használatot megtekintéshez és nyomtatáshoz; a betűkészletet tartalmazó dokumentumnak csak olvashatónak kell lennie.
- `Editable` engedélyezi az ideiglenes használatot, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NoSubsetting` egy további korlátozás, amely megtiltja a csak egy részhalmaz beágyazását. Ha ez a jelző jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` egy további korlátozás, amely csak bitmap változatok beágyazását engedélyezi, nem az outline adatokat. Ha a betűtípusnak nincs bitmap változata, nem lehet beágyazni.

Az első négy érték a használati engedélyt írja le, míg a `NoSubsetting` és a `BitmapOnly` kombinálható velük. Ellenőrizd a módosítókat bitwise műveletekkel. Mivel az `Installable` értéke null, maszkoljuk a használati engedély biteket, és hasonlítsuk össze az eredményt az `Installable`‑nel, ahelyett, hogy flagként ellenőriznénk. A jelenlegi betűtípusoknak legfeljebb egy használati engedély bitet kell beállítaniuk. Régebbi betűtípusok, amelyek egynél több bitet állítanak be, kompatibilitás céljából a lenti segéd a legkevésbé korlátozó engedélyt választja: `Editable`, majd `PreviewPrint`, majd `Restricted`.

Az alábbi példa ellenőrzi a normál, félkövér, dőlt és félkövér‑dőlt adatokat minden, a `FontsManager::getFonts` által visszaadott betűkészlethez. Kihagyja a nem elérhető stílusokat, a korlátozott, bitmap‑only betűkészleteket, a csak megtekintésre és nyomtatásra korlátozottakat, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűkészleteket. Ha bármely elérhető stílus `NoSubsetting`‑et tartalmaz, az összes karaktert beágyazza az adott betűcsaládhoz.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ez az ellenőrzés jelentést készít minden betűfájlban kódolt korlátozásról. Nem ad licencet, nem bizonyítja, hogy a betűt legális módon szerezted be, és nem helyettesíti a betűtípus licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűkészletek hozzáadása**

Használd a [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) metódust betűkészlet beágyazásához. A túlterhelések elfogadnak egy [FontData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontdata/) objektumot vagy egy byte‑tömböt, amely a betűtípus‑adatokat tartalmazza. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/embedfontcharacters/) enumeráció szabályozza, hogy mely karakterek legyenek belefoglalva:

- `All` beágyazza a betűkészlet összes karakterét. Ezt a lehetőséget akkor használd, ha a címzetteknek szerkeszteniük kell a prezentációt és új szöveget beírni.
- `OnlyUsed` csak a prezentációban használt karaktereket ágyazza be a fájlméret csökkentése érdekében. Ezt a lehetőséget választod egy kész prezentációhoz, amely elsősorban megtekintésre szolgál.

Az alábbi példa a [FontsManager::getFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getFonts) segítségével lekéri a `Fonts.pptx` fájlban használt betűkészleteket, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűkészleteknek elérhetőnek kell lenniük azon a gépen, amelyen a kód fut. A már létező beágyazott betűkészletek megtartják a jelenlegi karakterkészletüket.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Beágyazott betűkészletek tömörítése**

A [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#compressEmbeddedFonts) a beágyazott betűtípus‑adatot a nem használt karakterek eltávolításával csökkenti. Már beágyazott betűkészleteken működik, így a méretcsökkenés a prezentációban található fel nem használt betűtípus‑adat mennyiségétől függ.

Az alábbi példa tömöríti az `EmbeddedFonts.pptx` fájl betűkészleteit, és az eredményt külön fájlként menti:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tartsd meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem állnak rendelkezésre a beágyazott betűtípusból, még akkor sem, ha eredetileg az összes karaktert beágyaztad.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűkészlet a renderelés során még mindig helyettesítésre kerül-e?**

Hívd a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getSubstitutions) metódust abban a környezetben, ahol a prezentációt rendereled, hogy megtudd, mely betűkészleteket cseréli ki az Aspose.Slides. Ellenőrizd továbbá a [font substitution](/slides/hu/php-java/font-substitution/) beállításokat és a [font fallback](/slides/hu/php-java/fallback-font/) szabályokat. A fallback a hiányzó karaktereket kezeli, így egy betűkészlet beágyazása nem oldja meg azokat a karaktereket, amelyek a betűkészletben nincsenek.

**Érdemes általános betűkészleteket, például Arial‑t vagy Calibri‑t beágyazni?**

A döntést a célkörnyezet alapján hozd meg. Ha a szükséges betűkészletek minden olyan gépen rendelkezésre állnak, amely megnyitja vagy rendereli a prezentációt, a beágyazás felesleges fájlméret-növekedést okozhat. Ha a címzettek vagy a szerverek esetleg nem rendelkeznek ezekkel a betűkkel, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve hogy a licencük engedélyezi azt.