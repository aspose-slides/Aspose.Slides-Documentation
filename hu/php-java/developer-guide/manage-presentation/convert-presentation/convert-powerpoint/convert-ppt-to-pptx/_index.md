---
title: PPT konvertálása PPTX-re PHP-ben
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Örökölt PPT fájlok konvertálása PPTX-re PHP-ben az Aspose.Slides segítségével. Tartalmaz PHP példákat egyedi és kötegelt konverzióra, hibakezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for PHP via Java képes betölteni egy PPT fájlt és PPTX‑ként elmenteni Microsoft PowerPoint nélkül. Ez a cikk bemutatja, hogyan konvertálhat egy fájlt vagy egy könyvtárban lévő fájlokat, és elmagyarázza, mit kell ellenőrizni a konverzió után.

## **PPT fájl konvertálása PPTX‑re**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk felszabadítja a prezentációt és elengedi annak erőforrásait.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Töltse be az örökölt PPT prezentációt.
$presentation = new Presentation("presentation.ppt");
try {
    // Mentse a prezentációt PPTX formátumban.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/#Pptx) argumentum végzi. Tartsa külön a bemeneti és kimeneti útvonalakat, ha meg kell őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

A következő példa minden egyes `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja le a többi feldolgozását.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Termelési környezetben naplózza a teljes kivételt, döntse el, hogy a meglévő kimeneti fájl felülírható-e, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok, amelyek a szükséges jelszó nélkül próbálják megnyitni, a hozzá nem férhető útvonalak és a nem támogatott tartalom mind a konverzió hibájához vezethetnek. Lásd a [Jelszóval védett prezentációk](/slides/hu/php-java/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Hűség és örökölt funkciók**

A konverzió általában megőrzi a diák, fővázlatok, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy olyan örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálásra, kihagyásra vagy eltérő megjelenítésre kerülhet.

Ellenőrizze a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiafájlokat, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy sima PPTX fájl nem makró‑támogatott formátum, ezért használjon megfelelő makró‑támogatott munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Emellett ellenőrizze, hogy a szükséges betűtípusok és külső erőforrások jelen vannak-e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy megjelenítik.

Fontos dokumentumok esetén programozottan nyissa meg újra a létrehozott PPTX-et, ellenőrizze a kulcsfontosságú diák számát és tartalmát, majd hasonlítsa össze a megjelenését és a diavetítés viselkedését a célzott megjelenítőben. Ne tekintse a sikeres [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX reprezentációval rendelkezik.

## **Mikor használjuk a PPTX-et**

Használjon PPTX-et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és visszaállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT-et archiválási vagy visszaállítási másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szüksége, használja a [Prezentációk konvertálása több formátumba](/slides/hu/php-java/convert-presentation/) formátum‑specifikus útmutatót, ahelyett, hogy azt feltételezné, hogy minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Egy alkalmi fájl vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja a PHP API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/php-java/ppt-vs-pptx/)
- [Prezentációk mentése PHP‑ben](/slides/hu/php-java/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/php-java/supported-file-formats/)
- [Prezentációk megnyitása PHP‑ben](/slides/hu/php-java/open-presentation/)

## **GYIK**

**Átkonvertálhatom a PPT‑t PPTX‑re anélkül, hogy a Microsoft PowerPoint telepítve lenne?**

Igen. Az Aspose.Slides for PHP via Java betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑ről PPTX‑re konvertálás pontosan megőrzi az összes tartalmat?**

Megőrzi a gyakori prezentációtartalmakat, de a teljes pontosság nem garantált minden örökölt vagy nem támogatott funkció esetén. Tekintse át a generált fájlt, ha makrókat, OLE‑ vagy ActiveX‑objektumokat, médiafájlokat, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Átkonvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a fájl betöltésekor megadja a helyes jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés meghiúsul.

**Töröljem a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg a PPTX-et a fontos nézőkben és munkafolyamatokban ellenőrizte. Ez egy visszaállítási másolatot biztosít, ha egy örökölt funkció másként konvertálódik.