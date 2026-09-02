---
title: Converteer PPT naar PPTX in PHP
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/php-java/convert-ppt-to-pptx/
keywords:
- converteer PowerPoint
- converteer presentatie
- converteer dia
- converteer PPT
- PPT naar PPTX
- sla PPT op als PPTX
- exporteer PPT naar PPTX
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Converteer legacy PPT-bestanden naar PPTX in PHP met Aspose.Slides. Bevat PHP-voorbeelden voor enkel bestand en batchconversie, foutafhandeling en nauwkeurigheids-notities."
---
## **Overzicht**

PPT is het oudere binaire PowerPoint‑formaat, terwijl PPTX het nieuwere Open XML‑formaat is. Aspose.Slides for PHP via Java kan een PPT‑bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel laat zien hoe u één bestand of een map met bestanden kunt converteren en legt uit wat er na de conversie gecontroleerd moet worden.

## **Een PPT‑bestand naar PPTX converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en roep vervolgens [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) aan met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/#Pptx). Het `finally`‑blok verwijdert de presentatie en geeft de gebruikte resources vrij.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Laad de oude PPT-presentatie.
$presentation = new Presentation("presentation.ppt");
try {
    // Sla de presentatie op in PPTX-formaat.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De bestandsextensie bepaalt niet automatisch het uitvoerformaat; dat doet het argument [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/#Pptx). Houd de invoer‑ en uitvoer‑paden verschillend als u het oorspronkelijke PPT‑bestand wilt behouden.

## **Meerdere PPT‑bestanden converteren**

Het volgende voorbeeld converteert elk `.ppt`‑bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat één mislukte conversie de rest van de batch niet stopt.

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

Voor productieworkloads dient u de volledige exceptie te loggen, te bepalen of een bestaand uitvoerbestand overschreven mag worden, en de namen van mislukte bestanden naar een retry‑ of review‑wachtrij te schrijven. Beschadigde bestanden, met wachtwoord beveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet‑ondersteunde inhoud kunnen allemaal een conversie laten mislukken. Zie [Password-Protected Presentations](/php-java/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en legacy‑functionaliteiten**

Conversie behoudt normaal gesproken dia’s, masters, lay‑outs, tekst, vormen, afbeeldingen, tabellen en grafieken. Echter, PPT en PPTX representeren niet elke functionaliteit op exact dezelfde manier. Een legacy‑functionaliteit zonder PPTX‑equivalent, of die niet wordt ondersteund door de bibliotheek, kan genormaliseerd, weggelaten of anders weergegeven worden.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingebedde of gekoppelde OLE‑objecten, ActiveX‑besturingselementen, ingebedde media, ongewone lettertypen of VBA‑macro’s bevat. Een gewoon PPTX‑bestand is geen macro‑ingeschakeld formaat, dus gebruik een geschikt macro‑ingeschakeld werkproces wanneer VBA beschikbaar moet blijven. Verifieer bovendien dat de vereiste lettertypen en externe resources aanwezig zijn in de omgeving waarin de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten dient u de gegenereerde PPTX programmatisch opnieuw te openen en belangrijke dia‑aantallen en inhoud te inspecteren, waarna u het uiterlijk en het dia‑show‑gedrag in de beoogde viewer vergelijkt. Beschouw een succesvolle aanroep van [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) niet als bewijs dat elke legacy‑functionaliteit een exacte PPTX‑representatie heeft.

## **Wanneer PPTX te gebruiken**

Gebruik PPTX wanneer de presentatie wordt bewerkt in huidige PowerPoint‑versies, wordt uitgewisseld met systemen die met Open XML‑pakketten werken, of wordt opgeslagen in een formaat dat makkelijker te inspecteren en te herstellen is dan het legacy binaire PPT. Bewaar het oorspronkelijke PPT als een archief‑ of rollback‑kopie totdat de geconverteerde presentatie uw nauwkeurigheidscontroles heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander uitvoertype nodig hebt, gebruik dan de format‑specifieke richtlijnen in [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) in plaats van aan te nemen dat alle doelformaten bewerkbare PowerPoint‑functionaliteiten behouden.

## **Online‑converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT to PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batchverwerking of foutafhandeling op applicatieniveau gebruikt u de PHP‑API.

## **Gerelateerde artikelen**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Save Presentations in PHP](/php-java/save-presentation/)
- [Supported File Formats](/php-java/supported-file-formats/)
- [Open Presentations in PHP](/php-java/open-presentation/)

## **FAQ**

**Kan ik PPT naar PPTX converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja. Aspose.Slides for PHP via Java laadt en slaat presentatie‑bestanden op zonder dat Microsoft PowerPoint vereist is.

**Zal de PPT‑naar‑PPTX conversie alle inhoud exact behouden?**

Het behoudt de gangbare presentatie‑inhoud, maar exacte nauwkeurigheid is niet gegarandeerd voor elke legacy‑ of niet‑ondersteunde functionaliteit. Controleer het gegenereerde bestand wanneer het macro’s, OLE‑ of ActiveX‑objecten, media, gespecialiseerde animaties of ongewone lettertypen bevat.

**Kan ik een met wachtwoord beveiligd PPT‑bestand converteren?**

Ja, als u bij het laden van het bestand het juiste wachtwoord opgeeft. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat de laad‑operatie faalt.

**Moet ik het PPT‑bestand na de conversie verwijderen?**

Bewaar het origineel totdat u de PPTX in de viewers en workflows die voor u belangrijk zijn heeft geverifieerd. Dit biedt een rollback‑kopie voor het geval een legacy‑functionaliteit anders wordt geconverteerd.