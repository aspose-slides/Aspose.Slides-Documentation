---
title: Presentaties exporteren naar XAML in PHP
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/php-java/export-to-xaml/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- PPT opslaan als XAML
- PPTX opslaan als XAML
- ODP opslaan als XAML
- PPT exporteren naar XAML
- PPTX exporteren naar XAML
- ODP exporteren naar XAML
- PHP
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia’s naar XAML met Aspose.Slides voor PHP via Java — snelle, Office-vrije oplossing die jouw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties exporteert naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe je een presentatie opslaat in XAML met de standaardinstellingen, en demonstreert hoe je de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia’s. Het artikel beantwoordt ook enkele veelgestelde vragen over fallback‑lettertypen, XAML‑stackcompatibiliteit en het gedrag bij het exporteren van verborgen dia’s.

## **Over XAML**

XAML is een op XML gebaseerd opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

Je kunt werken met XAML‑bestanden in een visueel ontwerper of de markup rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende PHP‑voorbeeld toont hoe je een presentatie exporteert naar XAML met de standaardinstellingen. Initialiseert de PHP Java Bridge en laad `aspose.slides.php` voordat je de voorbeelden in dit artikel uitvoert. Plaats `pres.pptx` in de werkmap van de Java‑Bridge‑server, of geef een absoluut pad op dat voor die server toegankelijk is.

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

Standaard worden de geëxporteerde dia’s opgeslagen in een `pres`‑submap van de huidige werkmap van de Java‑Bridge‑server. De map wordt automatisch aangemaakt en eventuele benodigde afbeeldingen worden daar ook opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bronbestandsnaam zonder extensie. Voor `pres.pptx` krijgen de uitvoerbestanden de namen `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs als je een absoluut pad naar de invoerpresentatie opgeeft, wordt de uitvoermap aangemaakt relatief ten opzichte van de huidige werkmap van de Java‑Bridge‑server, in plaats van naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de [IXamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloptions/)‑interface om te regelen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de uitvoer naar een aangepaste locatie op te slaan, lever je een Java‑proxy die [IXamlOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/) implementeert en geef je een instantie van jouw implementatie door aan de [setOutputSaver](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/#setOutputSaver)‑methode van [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/).

Om verborgen dia’s op te nemen in de XAML‑uitvoer, roep je [setExportHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) aan met `true`, zoals getoond in het onderstaande PHP‑voorbeeld:

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

## **Alle gegenereerde XAML‑artefacten vastleggen**

Een XAML‑export kan een XAML‑document opleveren voor elke geëxporteerde dia plus afzonderlijke afbeeldingen en ondersteunende resources. Koppel een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/) aan [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/#setOutputSaver) om deze artefacten te ontvangen in plaats van de standaard bestandsopschoner. Start de export met de XAML‑specifieke [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save)‑overload die XAML‑opties accepteert.

De PHP Java Bridge‑functie `java_closure` stelt een PHP‑object beschikbaar als de Java‑interface. Houd zowel de PHP‑saver als de bijbehorende proxy in leven totdat de export voltooid is. De interface‑koppelingen verwijzen naar de Java‑API die door de proxy wordt geïmplementeerd.

### **Levenscyclus van de callback begrijpen**

De exporter roept [IXamlOutputSaver::save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) apart aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML resources kan refereren via relatieve paden.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire resources mogen niet gedecodeerd worden als tekst.
- De saver is verantwoordelijk voor het bewaren of persisteren van de data vóór terugkeer. De voorbeelden converteren elk Java‑byte‑array naar een PHP‑binaire string die eigendom is van de applicatie.
- Beschouw de export als geslaagd alleen wanneer de presentatie‑save‑operatie terugkeert en elke callback succesvol is afgerond. Verspil geen opslagfouten en start geen onopgemerkte achtergrond‑writes. Als persistentie later plaatsvindt, rapporteer dan het totale succes pas nadat die stap ook geslaagd is.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) is ook van toepassing op een aangepaste saver. De standaardinstelling, `false`, sluit XAML‑documenten van verborgen dia’s uit. Door `true` door te geven, worden ze en alle benodigde resources voor hun export meegenomen. Het aantal resources hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, verzamelt elk artefact in een PHP‑associatief array van binaire strings, en drukt de naam, het type en het byte‑aantal af. Het behoudt de opgegeven namen exact. Dubbele namen maken de collectie ongeldig in plaats van stilletjes een artefact te overschrijven. Het voorbeeld controleert dit voordat de resultaten worden gebruikt.

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

    // Alleen XAML wordt behandeld als UTF-8-tekst voor optionele inspectie.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Extensie‑controles zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende resource‑typen. Laat de bytes ongewijzigd wanneer je ze opslaat of verzendt. PHP‑strings kunnen binaire data behouden, inclusief null‑bytes. Beschouw een string alleen als UTF‑8‑tekst bij het inspecteren van XAML; converteer beeld‑ of resource‑bytes niet.

### **Verzamelde artefacten in een ZIP‑archief verpakken**

Dit op zichzelf staande voorbeeld verzamelt de export, valideert de namen en schrijft de originele bytes naar een ZIP‑archief. Een exclusief aangemaakte taakmap scheidt gelijktijdige exporttaken. Dit voorbeeld vereist de PHP‑Phar‑extensie met ZIP‑ondersteuning. ZIP‑items gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie conflicteren, leiden tot afwijzing van het gehele pakket vóór het schrijven.

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

Het voorbeeld gebruikt [PharData](https://www.php.net/manual/en/class.phardata.php) om één lokaal ZIP‑archief te schrijven in de werkmap van het PHP‑proces; de exporter zelf schrijft geen losse XAML‑‑ of afbeeldingsbestanden. Voor externe opslag vervang je de stap die het archief schrijft door uploads van de verzamelde binaire strings. Gebruik een export‑taak‑identifier plus de volledige relatieve artefact‑naam als blob‑sleutel, of sla de taak‑identifier, relatieve naam en binaire data op in een database‑rij. Publiceer de taak pas nadat alle uploads voltooid zijn of de database‑transactie is gecommit. Ruim een gedeeltelijke uitvoer op als persistentie mislukt.

Voor grote presentaties kan een aangepaste saver elk artefact direct persisteren naar applicatie‑opslag om te voorkomen dat er een extra kopie van de volledige export in het applicatie‑geheugen wordt gehouden. Houd elke callback synchroon vanuit het perspectief van de exporter: keer pas terug nadat de bestemming de bytes heeft geaccepteerd, en laat fouten naar de aanroeper doordringen.

### **Resource‑namen behouden en referenties verifiëren**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dat vereist, maar behoud relatieve mappen. Gebruik niet alleen [basename](https://www.php.net/manual/en/function.basename.php) tenzij elke gegenereerde naam gegarandeerd uniek is en resource‑referenties geldig blijven.
- Pas validatie van namen specifiek voor de bestemming toe. Bij het schrijven van losse bestanden, wijs absolute paden en traversalsegmenten af, los de bestemming op tot een absoluut pad en controleer dat het onder de beoogde exportmap blijft, inclusief de map‑scheidingsteken in de containment‑check. Gebruik een door de applicatie beheerde map zonder symbolische links die een redirect kunnen veroorzaken.
- Gebruik een aparte saver‑ en opslag‑namespace voor elke exporttaak. Detecteer conflicten na normalisatie van scheidingstekens en volgens de case‑sensitivity‑regels van de bestemming.
- Voordat je publiceert, parseer elk XAML‑document als XML en inspecteer de bestands‑gebaseerde resource‑referenties, zoals afbeelding‑`Source` of `ImageSource`‑attributen. Los elke relatieve URI op tegen de map van het bijbehorende XAML‑artefact, normaliseer de resulterende opslage‑naam, en bevestig dat de corresponderende map‑sleutel, ZIP‑item of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies afzonderlijk van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen resource beschikbaar zijn als `pres/images/image1.png`. Het enkel bewaren van `image1.png` zou die relatie doorbreken. Voor object‑opslag, behoud dezelfde structuur onder de taak‑prefix en maak die resource‑URL’s toegankelijk voor de XAML‑consumer. Open het voltooide ZIP‑bestand opnieuw om de item‑namen en resource‑bytes te verifiëren, en laad representatieve dia’s in de doeltijd‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgezocht.

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het oorspronkelijke lettertype niet beschikbaar is op de machine?**

Roep [setDefaultRegularFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) aan via [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het originele lettertype ontbreekt. Dit garandeert niet dat de gegenereerde XAML het fallback‑lettertype referenceert of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de door de XAML gereferende lettertypen aanwezig zijn in de omgeving waar het wordt weergegeven.

**Is de geëxporteerde XAML uitsluitend bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

Aspose.Slides exporteert WPF‑XAML via zijn openbare API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, is niet gegarandeerd. Test de gegenereerde markup in jouw doelomgeving.

**Worden verborgen dia’s ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia’s niet meegenomen. Je kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/) — houd het uitgeschakeld als je ze niet wilt exporteren.