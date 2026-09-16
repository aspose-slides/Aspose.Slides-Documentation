---
title: Exportera presentationer till XAML i PHP
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/php-java/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML med Aspose.Slides för PHP via Java — snabb, kontorsfri lösning som behåller din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur man exporterar PowerPoint‑presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur man sparar en presentation till XAML med standardinställningar och demonstrerar hur man anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservteckensnitt, XAML‑stack‑kompatibilitet och beteendet för export av dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk som WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande PHP‑exempel visar hur man exporterar en presentation till XAML med standardinställningar. Initiera PHP Java Bridge och ladda `aspose.slides.php` innan du kör exemplen i den här artikeln. Placera `pres.pptx` i Java Bridge‑serverns arbetskatalog, eller ange en absolut sökväg som är tillgänglig för den servern.

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

Som standard sparas de exporterade bilderna i en `pres`‑undermapp i Java Bridge‑serverns nuvarande arbetskatalog. Mappen skapas automatiskt, och eventuella nödvändiga bilder sparas där också.

Namn på output‑mappen tas från källfilens namn utan dess filändelse. För `pres.pptx` får utskriftsfilerna namn `pres/Slide_1.xaml`, `pres/Slide_2.xaml` osv. Även om du anger en absolut sökväg till inmatningspresentationen skapas output‑mappen relativt till Java Bridge‑serverns nuvarande arbetskatalog, snarare än bredvid indatafilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd gränssnittet [IXamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara resultatet på en anpassad plats, tillhandahåll en Java‑proxy som implementerar [IXamlOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/) och skicka en instans av din implementation till [setOutputSaver](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/#setOutputSaver)-metoden på [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/).

För att inkludera dolda bilder i XAML‑utdata, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) med `true`, som visas i följande PHP‑exempel:

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

## **Fånga alla genererade XAML‑artefakter**

En XAML‑export kan producera ett XAML‑dokument för varje exporterad bild samt separata bilder och stödresurser. Tilldela en anpassad [IXamlOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/) till [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/#setOutputSaver) för att ta emot dessa artefakter istället för att använda standardfil‑system‑spararen. Starta exporten med den XAML‑specifika [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save)-överlagringen som accepterar XAML‑alternativ.

PHP Java Bridge `java_closure`‑funktionen exponerar ett PHP‑objekt som Java‑gränssnittet. Håll både PHP‑spararen och dess proxy levande tills exporten är klar. Gränssnittslänkarna pekar på Java‑API:et som implementeras av proxyn.

### **Förstå återuppringningslivscykeln**

Exportören anropar [IXamlOutputSaver::save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat för varje genererad artefakt:

- `path` identifierar artefakten och kan inkludera relativa kataloger. Behåll denna information eftersom XAML kan referera resurser med relativa sökvägar.
- `data` innehåller artefaktens byte. Bilder och andra binära resurser får inte avkodas som text.
- Spararen är ansvarig för att behålla eller lagra data innan den returneras. Exemplen konverterar varje Java‑byte‑array till en PHP‑binärsträng som ägs av applikationen.
- Betrakta exporten som lyckad endast när presentations‑sparåtgärden returnerar och varje återuppringning har slutförts framgångsrikt. Skriv inte över lagringsfel eller påbörja osynliga bakgrundsskrivningar. Om lagring sker efteråt, rapportera total framgång först när även det steget lyckas.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) gäller också för en anpassad sparare. Standardinställningen, `false`, exkluderar XAML‑dokument för dolda bilder. Att skicka `true` inkluderar dem samt alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en återuppringning per bild eller en fast återuppringningsordning.

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel laddar `pres.pptx`, samlar varje artefakt i en PHP‑associativ array av binära strängar och skriver ut dess namn, typ och byte‑antal. Det bevarar de angivna namnen exakt. Dubblettnamn markerar samlingen som ogiltig istället för att tyst skriva över en artefakt. Exemplet kontrollerar detta innan resultaten används.

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

    // Endast XAML behandlas som UTF-8-text för valfri inspektion.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Filändelsekontroller är användbara för inspektion; behåll alla artefakter, inklusive okända resurstypen. Lämna byte‑värdena oförändrade vid lagring eller överföring. PHP‑strängar kan behålla binär data, inklusive noll‑byte. Behandla en sträng som UTF‑8‑text endast när du inspekterar XAML; transkoda inte bild‑ eller resurs‑byte.

### **Packa samlade artefakter i ett ZIP‑arkiv**

Detta självständiga exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytena i ett ZIP‑arkiv. En uteslutande skapad jobbkatalog separerar samtidiga exportjobb. Detta exempel kräver PHP‑Phar‑tillägget med ZIP‑stöd. ZIP‑poster använder snedstreck framåt och behåller relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

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

Exemplet använder [PharData](https://www.php.net/manual/en/class.phardata.php) för att skriva ett lokalt ZIP‑arkiv i PHP‑processens arbetskatalog; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring, ersätt steget för arkivskrivning med uppladdningar av de insamlade binära strängarna. Använd ett export‑job‑identifierare plus det fullständiga relativa artefakt‑namnet som en blob‑nyckel, eller lagra job‑identifieraren, relativt namn och binär data i en databasrad. Publicera jobbet först när alla uppladdningar är klara eller databastransaktionen har begåtts. Rensa delvis utdata om lagring misslyckas.

För stora presentationer kan en anpassad sparare lagra varje artefakt direkt i applikationslagring för att undvika att hålla en extra kopia av hela exporten i applikationsminnet. Håll varje återuppringning synkron från exportörens perspektiv: returnera först när destinationen har accepterat bytena, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa kataloger. Använd inte bara [basename](https://www.php.net/manual/en/function.basename.php) såvida inte varje genererat namn är känt att vara unikt och resursreferenser förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. När du skriver lösa filer, avvisa rotade sökvägar och traverseringssegment, lös destinationen till en absolut sökväg och verifiera att den ligger under den avsedda exportkatalogen, inklusive katalogseparatorn i innehållskontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje exportjobb. Upptäck kollisioner efter separator‑normalisering och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, analysera varje XAML‑dokument som XML och inspektera dess filbaserade resursreferenser, såsom bild‑`Source` eller `ImageSource`‑attribut. Lös varje relativ URI mot den innehållande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande karta‑nyckel, ZIP‑post eller lagrad objekt finns. Behandla externa URI‑er och XAML‑markup‑uttryck separat från relativa filnamn.
- Till exempel, om `pres/Slide_1.xaml` refererar till `images/image1.png`, måste den lagrade resursen vara tillgänglig som `pres/images/image1.png`. Att bara behålla `image1.png` skulle bryta den relationen. För objektslagring, bevara samma struktur under jobb‑prefixet och gör dessa resurs‑URL:er tillgängliga för XAML‑konsumenten. Återöppna det färdiga ZIP‑arkivet för att verifiera postnamn och resurs‑byte, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löser korrekt.

## **Vanliga frågor**

**Hur kan jag säkerställa förutsägbara teckensnitt om det ursprungliga teckensnittet inte är tillgängligt på maskinen?**

Anropa [setDefaultRegularFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/) — den används som reservteckensnitt under exporten när det ursprungliga saknas. Detta garanterar inte att den genererade XAML‑referensen använder reservteckensnittet eller att teckensnittet är tillgängligt på målmaskinen. Se till att de teckensnitt som XAML refererar till finns i miljön där den visas.

**Är den exporterade XAML endast avsedd för WPF, eller kan den även användas i andra XAML‑stackar?**

Aspose.Slides exporterar WPF‑XAML via sitt publika API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) i [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.