---
title: Prezentációk exportálása XAML-be PHP használatával
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/php-java/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- PHP
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-be az Aspose.Slides for PHP Java-on keresztül — gyors, Office-mentes megoldás, amely megőrzi a layoutot."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint‑prezentációkat exportálni XAML‑be az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést a XAML‑ba, bemutatja, hogyan lehet egy prezentációt XAML‑be menteni az alapértelmezett beállításokkal, és demonstrálja, hogyan lehet testre szabni az exportálást a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/) használatával, beleértve a rejtett diák exportálását is. A cikk továbbá válaszol néhány gyakori kérdésre, amelyek a tartalék betűtípusokra, a XAML‑verem kompatibilitásra és a rejtett diák exportálási viselkedésére vonatkoznak.

## **A XAML‑ról**

A XAML egy XML‑alapú jelölőnyelv, amelyet felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML‑fájlokkal dolgozhat vizuális tervezőben, vagy közvetlenül írhatja és szerkesztheti a jelölőt.

## **Prezentációk exportálása XAML‑be alapértelmezett beállításokkal**

Az alábbi PHP‑példa megmutatja, hogyan lehet egy prezentációt XAML‑be exportálni alapértelmezett beállításokkal. Inicializálja a PHP Java Bridge‑et, és töltse be a `aspose.slides.php`‑t, mielőtt a cikkben szereplő példákat futtatná. Helyezze a `pres.pptx`‑t a Java Bridge szerver munkakönyvtárába, vagy adjon meg egy abszolút útvonalat, amely a szerver számára elérhető.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Alapértelmezés szerint az exportált diák egy `pres` almappába kerülnek a Java Bridge szerver aktuális munkakönyvtárában. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek mentésre.

A kimeneti mappa neve a forrásfájl neve a kiterjesztés nélkül. A `pres.pptx` esetén a kimeneti fájlok nevei `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. Még ha abszolút útvonalat ad meg a bemeneti prezentációnak, a kimeneti mappa a Java Bridge szerver aktuális munkakönyvtárához viszonyítva jön létre, nem pedig a bemeneti fájl mellett.

## **Prezentációk exportálása XAML‑be egyéni beállításokkal**

Használja az [IXamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloptions/) interfészt, hogy szabályozza, hogyan exportálja az Aspose.Slides a prezentációt XAML‑be.

A kimenet egyedi helyre mentéséhez biztosítson egy Java proxy‑t, amely megvalósítja a [IXamlOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/) interfészt, és adja át ennek egy példányát a [setOutputSaver](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/#setOutputSaver) metódusnak a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/) objektumból.

A rejtett diák XAML‑kimenetben való szerepeltetéséhez hívja meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódust `true` értékkel, ahogy az alábbi PHP‑példában látható:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Az összes generált XAML‑artefaktus rögzítése**

Egy XAML‑exportum minden exportált dia számára egy XAML‑dokumentumot, valamint külön képeket és támogató erőforrásokat hozhat létre. Rendeljen egyedi [IXamlOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/) objektumot a [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/#setOutputSaver) metódushoz, hogy ezeket az artefaktusokat kapja meg a fájlrendszer‑alapértelmezett mentő helyett. Indítsa el az exportálást a XAML‑specifikus [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) túlterheléssel, amely XAML‑beállításokat fogad.

A PHP Java Bridge `java_closure` függvénye egy PHP‑objektumot tesz elérhetővé Java interfészként. Tartsa fenn mind a PHP‑mentőt, mind annak proxy‑ját, amíg az export be nem fejeződik. Az interfész‑linkek a proxy által megvalósított Java API‑ra mutatnak.

### **A visszahívási életciklus megértése**

Az exportáló külön-külön meghívja a [IXamlOutputSaver::save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metódust minden létrehozott artefaktusra:

- `path` azonosítja az artefaktust, és tartalmazhat relatív könyvtárakat. Őrizze meg ezt az információt, mivel a XAML gyakran hivatkozik erőforrásokra relatív útvonalakkal.
- `data` az artefaktus bájtjait tartalmazza. A képeket és egyéb bináris erőforrásokat ne dekódolja szövegként.
- A mentőnek felelőssége, hogy megőrizze vagy perzisztálja az adatokat a visszatérés előtt. A példák minden Java bájt‑tömböt PHP bináris stringgé alakítanak, amelyet az alkalmazás birtokol.
- Tekintse az exportot sikeresnek csak akkor, amikor a prezentáció mentési művelete visszatér, és minden visszahívás sikeresen befejeződött. Ne nyelje le a tárolási hibákat, és ne indítson megfigyelés nélküli háttér‑írásokat. Ha a perzisztálás később történik, a teljes sikerességet csak akkor jelentse, ha az a lépés is sikeres.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) egy egyéni mentőre is érvényes. Az alapértelmezett beállítás, `false`, kizárja a rejtett diák XAML‑dokumentumait. `true` megadása belefoglalja őket és minden exportáláshoz szükséges erőforrást. Az erőforrások száma a prezentációtól függ; ne feltételezze, hogy minden diának egy visszahívása van vagy hogy a visszahívások sorrendje rögzített.

### **Exportálás memóriába és az artefaktusok vizsgálata**

Ez a teljes példakód betölti a `pres.pptx`‑t, minden artefaktust egy PHP asszociatív tömbben tárol bináris stringként, majd kiírja nevét, típusát és bájt‑számát. Az eredeti neveket pontosan megőrzi. Azonos nevek esetén a gyűjtemény érvénytelennek minősül, ahelyett, hogy csendben felülírná az artefaktust. A példa ezt ellenőrzi, mielőtt felhasználná az eredményeket.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Csak a XAML-t kezeljük UTF-8 szövegként opcionális vizsgálathoz.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

A kiterjesztés‑ellenőrzések hasznosak a vizsgálathoz; őrizze meg az összes artefaktust, beleértve az ismeretlen erőforrás‑típusokat is. A bájt‑adatokat változatlanul hagyja tárolás vagy továbbítás során. A PHP stringek képesek bináris adatot tárolni, beleértve a null‑bájtokat is. A stringet csak akkor kezelje UTF‑8 szövegként, amikor XAML‑t vizsgál, ne transzkódolja a kép‑ vagy erőforrás‑bájtokat.

### **Gyűjtött artefaktusok csomagolása ZIP archívumba**

Ez az önálló példa összegyűjti az exportot, érvényesíti a neveket, és az eredeti bájtokat ZIP archívumba írja. Egy kizárólag létrehozott munkakönyvtár választja el a párhuzamos export‑feladatokat. A példa a PHP Phar‑kiterjesztést igényli ZIP‑támogatással. A ZIP‑bejegyzések előre‑perjelek és megtartják a relatív könyvtárakat. Nem biztonságos nevek vagy a normalizálás után ütköző nevek esetén az egész csomag elutasításra kerül, mielőtt írásra kerülne.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

A példa a [PharData](https://www.php.net/manual/en/class.phardata.php)‑t használja egy helyi ZIP archívum írására a PHP folyamat munkakönyvtárában; az exportáló maga nem ír laza XAML‑ vagy képfájlokat. Távoli tároláshoz cserélje ki az archiválási lépést a gyűjtött bináris stringek feltöltésére. Használjon export‑feladat‑azonosítót és a relatív artefaktus‑nevet blob‑kulcsként, vagy tárolja a feladat‑azonosítót, a relatív nevet és a bináris adatot egy adatbázis‑sorban. A feladatot csak akkor publikálja, amikor minden feltöltés befejeződött vagy a tranzakció elköteleződött. Ha a perzisztálás hibázik, tisztítsa meg a részleges kimenetet.

Nagy prezentációk esetén egy egyéni mentő közvetlenül az alkalmazás‑tárolóba mentheti az egyes artefaktusokat, ezáltal elkerülve a teljes export memóriában tartását. Tartsa a visszahívásokat szinkronban az exportáló szemszögéből: csak akkor térjen vissza, amikor a cél elfogadta a bájtokat, és engedje, hogy a hibák eljussanak a hívóhoz.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizálja az útválasztó karaktereket, ha a célkönyvtár megköveteli, de őrizze meg a relatív könyvtárakat. Ne használja kizárólag a [basename](https://www.php.net/manual/en/function.basename.php)‑t, hacsak minden generált név egyedi és az erőforrás‑hivatkozások érvényesek.
- Alkalmazzon cél‑specifikus név‑validációt. Laza fájlok írásakor utasítsa el a gyökér‑útvonalakat és a traversz szegmenseket, oldja fel a célt abszolút úttá, és ellenőrizze, hogy az a tervezett export‑könyvtár alatt marad‑e, beleértve a könyvtár‑elválasztót a tartalmazási ellenőrzésben. Használjon olyan alkalmazás‑vezérelt könyvtárat, amelynek nincsenek szimbolikus linkjei, amelyek átirányíthatják az írásokat.
- Használjon külön mentőt és tárolási névtér‑környezetet minden export‑feladathoz. Ütközéseket csak a szeparátor normalizálása után és a cél esetleges kis‑/nagybetű‑érzékenységének szabályai szerint detektáljon.
- Közzététel előtt minden XAML‑dokumentumot XML‑ként parse‑olja, és ellenőrizze annak fájl‑alapú erőforrás‑hivatkozásait, például a kép `Source` vagy `ImageSource` attribútumait. Oldja fel minden relatív URI‑t a tartalmazó XAML‑artefaktus könyvtárához képest, normalizálja a kapott tárolási nevet, és ellenőrizze, hogy a megfelelő térkép‑kulcs, ZIP‑bejegyzés vagy tárolt objektum létezik. Kezelje külön a külső URI‑kat és a XAML‑jelölő kifejezéseket a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png`‑re hivatkozik, a tárolt erőforrásnak `pres/images/image1.png`‑ként kell léteznie. Ha csak `image1.png` van megőrizve, a kapcsolat megszakad. Objektumtárolás esetén őrizze meg ugyanazt a struktúrát a feladat‑prefix alatt, és tegye elérhetővé ezeket az erőforrás‑URL‑eket a XAML‑fogyasztó számára. Nyissa meg a kész ZIP‑et, ellenőrizze a bejegyzés‑neveket és az erőforrás‑bájtokat, majd töltsön be reprezentatív diákat a cél‑XAML‑környezetben, hogy megbizonyosodjon a képek helyes feloldásáról.

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem elérhető a gépen?**

Hívja meg a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/) objektumban – ez lesz a tartalék betűtípus az exportálás során, ha az eredeti hiányzik. Ez nem garantálja, hogy a generált XAML a tartalék betűtípust használja vagy hogy a betűtípus elérhető a célgépen. Biztosítsa, hogy a XAML által hivatkozott betűtípusok a megjelenítő környezetben jelen legyenek.

**A exportált XAML csak WPF‑hez szánt, vagy használható más XAML‑veremekben is?**

Az Aspose.Slides a WPF XAML‑t exportálja a nyilvános API‑ján keresztül. Más XAML‑veremekkel, például az UWP‑vel vagy a Xamarin.Forms‑szal való kompatibilitás nem garantált. Tesztelje a generált jelölőt a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálásra kerüljenek?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódus segítségével szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/) objektumban – tartsa letiltva, ha nem kívánja őket exportálni.