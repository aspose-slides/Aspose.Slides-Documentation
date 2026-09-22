---
title: Prezentációs információk lekérése és frissítése PHP-ben
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/php-java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok módosítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP használatával, a gyorsabb betekintés és az intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani a bemutató formátumát, és a dokumentum metaadatait elolvasni anélkül, hogy teljes bemutató objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell osztályozni, leltárt kell építeni, vagy tulajdonságokat kell ellenőrizni, mielőtt eldöntené, hogy betölti‑e és feldolgozza‑e a bemutató tartalmát.

Ez a cikk a könnyű ellenőrzést mutatja be a [PresentationFactory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) segítségével, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) használatával.

## **Ellenőrizze a bemutató formátumát**

Ha már betöltött bemutatóval rendelkezik, tekintse meg a [Determine the Original Presentation Format](/slides/hu/php-java/detect-presentation-source-format/) cikket a betöltés utáni felismeréshez és a régi PPT, PPS, valamint POT adatfolyamok korlátozásairól.

Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) metódust egy fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hozna létre. A [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#getLoadFormat) metódus visszaadja a felismert formátumot, például PPTX, PPT vagy ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Könnyű bemutató leltár létrehozása**

Amikor sok bemutató fájlt dolgoz fel, előfordulhat, hogy egy kompakt leltárra van szüksége érvényesítéshez, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben az esetben használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) objektum megszerzéséhez, majd hívja a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a dokumentum metaadatainak olvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt, és nem igényli a teljes bemutató objektummodell átlapozását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket tartalmazzák:

| Módszer | Leltár értéke |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getSlides) | A diák összes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getHiddenSlides) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getNotes) | Azon diák száma, amelyekhez jegyzet tartozik. |
| [getParagraphs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getParagraphs) | A bekezdések összes száma, ha rendelkezésre áll. |
| [getWords](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getWords) | A szavak összes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Az audio‑ és videoklipek összes száma. |

Az alábbi példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt ír ki. Emellett kombinálja a [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getHeadingPairs) és a [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getTitlesOfParts) eredményét a tartalomcsoportok, például betűtípusok, témák és diacímek megjelenítéséhez.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Minden [HeadingPair](https://reference.aspose.com/slides/hu/php-java/aspose.slides/headingpair/) egy csoportnevet és az abban szereplő elemek számát adja meg. A [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getTitlesOfParts) egy lapos, rendezett tömböt térít vissza, ezért a címsorok számát a megfelelő heading pair által meghatározott egymást követő címek alapján kell felhasználni.

### **Tárolt metaadatok és formátumkorlátozások**

A [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a bemutató objektummodellt, hogy újraszámolja ezeket az értékeket a hívás során. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha az utolsó mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a dia, jegyzet, rejtett dia, bekezdés, szó és multimédia számlálásához, valamint a heading pair-ekhez és a részcímekhez. Elérhetőségük attól függ, mely tulajdonságokat írta a dokumentum készítője.
- **PPT:** A bináris formátum tárolhatja a megfelelő dokumentum‑összefoglaló tulajdonságokat. Ha egy tulajdonság hiányzik, vagy a dokumentumkészítő nem frissítette, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza, a diák alapján számolt érték helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat tartalmaznak, például oldal-, bekezdés- és szószámot, de ezek az értékek nem felelnek meg minden PowerPoint‑specifikus kiterjesztett tulajdonságnak. A rejtett dia, jegyzet dia, multimédia, heading‑pair és részcím metaadatok előfordulhatnak, vagy hiányozhatnak, és a leltártulajdonságok alapértelmezett értékeket adhatnak vissza. A nulla értéket vagy a üres tömböt ne tekintse végleges bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárakhoz és előzetes ellenőrzésekhez. Töltse be a bemutatót, és ellenőrizze annak élő objektummodelljét, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges bemutató tartalmát kell ellenőrizni.

## **A bemutató tulajdonságainak frissítése**

A [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a változtatásokat a [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) segítségével, majd írja a köthez kapcsolt bemutatót a [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) metódussal.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja.

![A PowerPoint bemutató eredeti dokumentumtulajdonságai](input_properties.png)

Az alábbi példa megváltoztatja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja.

![A PowerPoint bemutató módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A kapcsolódó biztonsági ellenőrzésekkel és védelmi beállításokkal kapcsolatban tekintse meg a következő cikkeket:

- [Password-Protect Presentations](/slides/hu/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/php-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok beágyazottak-e, és melyek azok?**

Töltse be a bemutatót, és használja a [Presentation::getFontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getFontsManager) metódust. Hívja a [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a beágyazott betűtípusok lekéréséhez, valamint a [FontsManager::getFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getFonts) metódust a bemutató által használt betűtípusokhoz. A két eredmény összehasonlításával megtalálhatja azokat a betűtípusokat, amelyek a rendereléshez szükségesek, de nincsenek beágyazva.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz‑e rejtett diát, és ha igen, hány darabot?**

Ha a tárolt dokumentum‑metaadat elegendő, olvassa a [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getHiddenSlides) értékét a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) és a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével. Ez egy könnyű leltárhoz alkalmas. Ha a bemutatót a memóriában módosították, a tárolt metaadat hiányozhat vagy elavulhat, vagy ha élő értékeket kell ellenőrizni, iteráljon a [Presentation::getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) gyűjteményen, és a [Slide::getHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getHidden) metódussal ellenőrizze az egyes diák állapotát.

**Kideríthetem, hogy egyéni dia‑méret és tájolás van‑e beállítva, és eltér‑e az alapértelmezettől?**

Igen. Töltse be a bemutatót, és hívja a [Presentation::getSlideSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlideSize) metódust. Az [SlideSize::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/#getSize) és [SlideSize::getOrientation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/#getOrientation) metódusokkal hasonlítsa össze a jelenlegi beállításokat a várt előre definiált értékekkel és méretekkel.

**Van gyors mód arra, hogy lássam, a diagramok külső adatforrásra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) elemet, és hívja a [ChartData::getDataSourceType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getDataSourceType) metódust. Külső munkafüzet esetén hívja a [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) metódust. Az adatforrás típusa és az elérési út jelzi a külső hivatkozást, de annak elérhetősége külön erőforrás‑ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákokat, amelyek lassíthatják a renderelést vagy a PDF‑exportot?**

Nincs egyetlen „komplexitás” tulajdonság. Járja be a [Presentation::getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) gyűjteményt, és minden dia [BaseSlide::getShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getShapes) gyűjteményét. A shape‑számok, nagy képek, effektusok, animációk vagy multimédia jelenléte jelzésként szolgálhat, és mérje le egy reprezentatív renderelés vagy export időt, mielőtt egy diát végleges teljesítmény‑szűkítőnek tekintene.