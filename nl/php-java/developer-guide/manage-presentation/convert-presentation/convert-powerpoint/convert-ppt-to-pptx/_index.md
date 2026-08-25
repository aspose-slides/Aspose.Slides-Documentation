---
title: Converteer PPT naar PPTX in PHP
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPT naar PPTX
- PPT opslaan als PPTX
- PPT exporteren naar PPTX
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Converteer legacy PPT-bestanden naar PPTX in PHP met Aspose.Slides. Inclusief PHP-voorbeelden voor één bestand en batchconversie, foutafhandeling en nauwkeurigheidsnotities."
---
## **Overzicht**

PPT is het legacy-binaire PowerPoint-formaat, terwijl PPTX het nieuwere Open XML-formaat is. Aspose.Slides for PHP via Java kan een PPT-bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel toont hoe u één bestand of een map met bestanden kunt converteren en legt uit wat er gecontroleerd moet worden na de conversie.

## **Converteer een PPT-bestand naar PPTX**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) class, roep vervolgens [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) aan met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/#Pptx). Het `finally`-blok ruimt de presentatie op en geeft de resources vrij.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Laad de legacy PPT-presentatie.
$presentation = new Presentation("presentation.ppt");
try {
    // Sla de presentatie op in PPTX-formaat.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De bestandsextensie bepaalt niet automatisch het uitvoerformaat; het argument [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/#Pptx) doet dat. Houd de invoer- en uitvoer-paden verschillend als u het oorspronkelijke PPT-bestand wilt behouden.

## **Converteer meerdere PPT-bestanden**

Het volgende voorbeeld converteert elk `.ppt`-bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat één mislukte conversie de rest van de batch niet stopt.

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

Voor productie-workloads moet de volledige uitzondering worden gelogd, besluiten of een bestaand uitvoerbestand mag worden overschreven, en mislukte bestandsnamen naar een herhaal- of beoordelings-queue schrijven. Beschadigde bestanden, met een wachtwoord beveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet-ondersteunde inhoud kunnen allemaal een conversie doen falen. Zie [Password-Protected Presentations](/slides/nl/php-java/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en legacy-functies**

Conversie behoudt normaal gesproken dia's, masters, lay-outs, tekst, vormen, afbeeldingen, tabellen en grafieken. PPT en PPTX vertegenwoordigen echter niet elke functionaliteit op exact dezelfde manier. Een legacy-functie zonder PPTX-equivalent, of die niet door de bibliotheek wordt ondersteund, kan genormaliseerd, weggelaten of anders weergegeven worden.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingebedde of gekoppelde OLE-objecten, ActiveX-besturingselementen, ingebedde media, ongebruikelijke lettertypen of VBA-macro's bevat. Een regulier PPTX-bestand is geen macro-ingeschakeld formaat, dus gebruik een geschikte macro-ingeschakelde workflow wanneer VBA beschikbaar moet blijven. Verifieer ook dat vereiste lettertypen en externe bronnen aanwezig zijn in de omgeving waarin de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten moet u de gegenereerde PPTX programmatisch opnieuw openen en belangrijke aantallen dia's en inhoud inspecteren, daarna de weergave en diavoorstelling-gedrag vergelijken in de beoogde viewer. Beschouw een succesvolle aanroep van [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) niet als bewijs dat elke legacy-functie een exacte PPTX-representatie heeft.

## **Wanneer PPTX gebruiken**

Gebruik PPTX wanneer de presentatie wordt bewerkt in huidige PowerPoint-versies, wordt uitgewisseld met systemen die met Open XML-pakketten werken, of wordt opgeslagen in een formaat dat makkelijker te inspecteren en te herstellen is dan het legacy-binaire PPT. Bewaar het oorspronkelijke PPT als archief- of rollback-kopie totdat de geconverteerde presentatie uw nauwkeurigheidscontroles heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander outputtype nodig heeft, gebruik dan de formaat-specifieke richtlijnen in [Convert Presentations to Multiple Formats](/slides/nl/php-java/convert-presentation/) in plaats van aan te nemen dat alle doelen bewerkbare PowerPoint-functies behouden.

## **Online-converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT to PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batch-verwerking of foutafhandeling op toepassingsniveau, gebruik de PHP-API.

## **Gerelateerde artikelen**

- [PPT vs PPTX](/slides/nl/php-java/ppt-vs-pptx/)
- [Presentaties opslaan in PHP](/slides/nl/php-java/save-presentation/)
- [Ondersteunde bestandsformaten](/slides/nl/php-java/supported-file-formats/)
- [Presentaties openen in PHP](/slides/nl/php-java/open-presentation/)

## **Veelgestelde vragen**

**Kan ik PPT naar PPTX converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja. Aspose.Slides for PHP via Java laadt en slaat presentaties op zonder dat Microsoft PowerPoint vereist is.

**Zal de conversie van PPT naar PPTX alle inhoud precies behouden?**

Het behoudt de gangbare presentatiewijzigingen, maar exacte nauwkeurigheid is niet gegarandeerd voor elke legacy- of niet-ondersteunde functie. Controleer het gegenereerde bestand wanneer het macro’s, OLE- of ActiveX-objecten, media, gespecialiseerde animaties of ongebruikelijke lettertypen bevat.

**Kan ik een met wachtwoord beveiligd PPT-bestand converteren?**

Ja, als u het juiste wachtwoord opgeeft bij het laden van het bestand. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat de laad-operatie faalt.

**Moet ik het PPT-bestand na de conversie verwijderen?**

Bewaar het origineel totdat u de PPTX hebt gecontroleerd in de viewers en workflows die voor u van belang zijn. Dit biedt een rollback-kopie als een legacy-functie anders wordt geconverteerd.