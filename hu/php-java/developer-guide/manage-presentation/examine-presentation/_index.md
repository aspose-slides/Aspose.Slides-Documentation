---
title: Prezentáció információinak lekérése és frissítése PHP-ben
linktitle: Prezentáció információk
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
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP használatával a gyorsabb betekintés és okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani a bemutató formátumát, és beolvassa a dokumentum metaadatait anélkül, hogy teljes bemutató objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell kategorizálni, leltárt készíteni, vagy tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti és feldolgozza a bemutató tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) segítségével, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) használatával.

## **Ellenőrizze a bemutató formátumát**

Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) metódust egy fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hozna létre. A [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#getLoadFormat) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

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

## **Könnyű bemutató leltár felépítése**

Amikor sok bemutató fájlt dolgoz fel, szüksége lehet egy kompakt leltárra az érvényesítéshez, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben a forgatókönyvben használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) objektum megszerzéséhez, majd hívja a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt, és nem igényli a teljes bemutató objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltár értékeket szolgáltatják:

| Metódus | Leltár érték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getSlides) | A diák teljes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getHiddenSlides) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getNotes) | Azon diák száma, amelyek tartalmaznak jegyzetet. |
| [getParagraphs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getParagraphs) | A bekezdések teljes száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getWords) | A szavak teljes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Az audio és video klipek teljes száma. |

Az alábbi példa ezeket az értékeket beolvassa anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat ki. Emellett kombinálja a [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getHeadingPairs) metódust a [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getTitlesOfParts) metódussal, hogy megjelenítse a tartalomcsoportokat, például betűtípusok, témák és dia címek.

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

Minden [HeadingPair](https://reference.aspose.com/slides/hu/php-java/aspose.slides/headingpair/) egy csoportnevet és az adott csoportban lévő elemek számát adja meg. A [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getTitlesOfParts) egy lapos, rendezett tömböt ad vissza, ezért a sorozatos címek számát kell felhasználni, amelyet minden fejlécpár megad.

### **Tárolt metaadatok és formátumkorlátozások**

A [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott leltár tulajdonságok a forrásdokumentumban elérhető metaadataikat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a bemutató objektummodellt, hogy újraszámolja ezeket az értékeket a hívás során. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha az utoljára mentő alkalmazás nem frissítette a dokumentum tulajdonságait.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia elemek számlálásához, valamint a fejlécpárokhoz és részcímekhez. Az elérhetőség attól függ, hogy a dokumentum előállítója melyik tulajdonságot írta ki.
- **PPT:** A bináris formátum tárolhatja a megfelelő dokumentum-összefoglaló tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissült a dokumentum előállítója által, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza ahelyett, hogy a diákból számolná ki.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldal-, bekezdés- és szószámot, de ezek az értékek nem felelnek meg minden PowerPoint‑specifikus kiterjesztett tulajdonságnak. A rejtett diák, jegyzet‑diák, multimédia, fejlécpár és részcím metaadatok hiányozhatnak, és a leltár tulajdonságok alapértelmezett értékeket adhatnak vissza. Ne tekintse a null értéket vagy az üres tömböt végleges bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárakhoz és előzetes ellenőrzésekhez. Töltse be a bemutatót és ellenőrizze a folyó objektummodellt, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges bemutató tartalmát kell ellenőriznie.

## **Bemutató tulajdonságainak frissítése**

A [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott tulajdonságok szintén módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hoznának létre. Alkalmazza a változtatásokat a [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) metódussal, majd írja ki a kötött bemutatót a [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) segítségével.

Az alábbi kép a PowerPoint bemutató eredeti dokumentumtulajdonságait mutatja.

![PowerPoint bemutató eredeti dokumentumtulajdonságai](input_properties.png)

Az alábbi példa módosítja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

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

Az alábbi kép a PowerPoint bemutató módosított dokumentumtulajdonságait mutatja.

![PowerPoint bemutató módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos linkek**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd a következő cikkeket:

- [Jelszóval védett prezentációk](/slides/hu/php-java/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/php-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva és melyek azok?**

Töltse be a bemutatót, és használja a [Presentation::getFontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getFontsManager) metódust. Hívja a [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a beágyazott betűkészletek megszerzéséhez, valamint a [FontsManager::getFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getFonts) metódust a bemutató által használt betűkészletekhez. Hasonlítsa össze a két eredményt, hogy megtalálja a megjelenítéshez szükséges, de nincs beágyazva lévő betűkészleteket.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz‑e rejtett diákat és hány darab van?**

Ha a tárolt dokumentum‑metaadatok elegendőek, olvassa a [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getHiddenSlides) értékét a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) és a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével. Ez alkalmas egy könnyű leltárhoz. Ha a bemutatót memória‑szinten módosították, a tárolt metaadatok hiányozhatnak vagy elavultak, vagy ha a valós értékeket kell ellenőrizni, akkor járja be a [Presentation::getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) gyűjteményt, és minden dia [Slide::getHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getHidden) metódusát vizsgálja.

**Feldolgozható‑e, hogy a bemutató egyedi diamérettel és orientációval rendelkezik‑e, és eltér‑e‑nek a alapértelmezett beállításoktól?**

Igen. Töltse be a bemutatót, és hívja a [Presentation::getSlideSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlideSize) metódust. Használja a [SlideSize::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/#getSize) és [SlideSize::getOrientation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/#getOrientation) metódusokat a jelenlegi beállítások összehasonlítására a várt előre definiált értékekkel és méretekkel.

**Van‑e gyors módja annak, hogy megtekintsem, a diagramok külső adatforrásokra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) elemet, és hívja a [ChartData::getDataSourceType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getDataSourceType) metódust. Külső munkafüzet esetén hívja a [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) metódust. Az adatforrás típusa és elérési útja meghatározza a külső hivatkozást, de annak elérhetőségének ellenőrzése külön erőforrás‑ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF‑exportot?**

Nincs egyetlen „komplexitás” tulajdonság. Járja be a [Presentation::getSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) és minden dia [BaseSlide::getShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getShapes) gyűjteményét. A alakzatok számát, valamint a nagy képek, effektusok, animációk vagy multimédia jelenlétét használja szűrőjelzőként, és mérjen egy reprezentatív renderelést vagy exportot, mielőtt a diát megerősített teljesítmény‑szűkítőnek tekintené.