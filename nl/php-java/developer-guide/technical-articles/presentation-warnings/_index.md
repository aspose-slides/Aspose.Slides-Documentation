---
title: Presentatiewaarschuwingen behandelen in PHP
type: docs
weight: 90
url: /nl/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwing callback
- waarschuwingsbeleid
- gegevensverlies
- broncorruptie
- compatibiliteitsprobleem
- lettertype-substitutie
- digitale handtekening
- presentatie laden
- presentatie renderen
- presentatieconversie
- presentatie opslaan
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, classificeren en behandelen bij het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides kan herstelbare problemen melden terwijl het een presentatie laadt, rendert, converteert of opslaat. Voorbeelden zijn beschadigde bronrecords, inhoud die niet behouden kan worden, lettertype‑substitutie en beperkingen van een doelformaat. Een waarschuwing‑callback laat een applicatie deze condities registreren en beslissen of de huidige bewerking kan worden voortgezet.

Maak een PHP‑klasse met een openbare `warning`‑methode en stel deze via PHP Java Bridge beschikbaar als de Java [IWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarningcallback/)‑interface met `java_closure`. Onderzoek de waarden van [getWarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) die via [IWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/) worden geleverd. Retourneer [ReturnAction::Continue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/returnaction/#Continue) om de waarschuwing te accepteren of [ReturnAction::Abort](https://reference.aspose.com/slides/nl/php-java/aspose.slides/returnaction/#Abort) om de bewerking te stoppen.

Gebruik [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setWarningCallback) voor waarschuwingen die worden gegenereerd tijdens het openen van een presentatie. Rendering‑ en exportoptieklassen erven van [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setWarningCallback), die waarschuwingen ontvangt van slide‑rendering, conversie en opslaan. Omdat de waarschuwing zelf de applicatie‑bewerking niet identificeert, koppelt u elke callback‑instantie aan een bewerkingsfase wanneer u een gecombineerd rapport bouwt.

## **Waarschuwingen en uitzonderingen**

Java‑exceptions worden via PHP Java Bridge beschikbaar gesteld aan PHP; vang ze op de grens van de bewerking, zoals weergegeven in het voorbeeld hieronder. De Java‑interface‑links in dit artikel beschrijven het callback‑contract dat door de bridge wordt gebruikt.

Een waarschuwing beschrijft een conditie waarvan Aspose.Slides kan herstellen als de callback `ReturnAction::Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet worden afgehandeld door een waarschuwingsbeleid.

Het retourneren van `ReturnAction::Abort` vraagt de waarschuwing‑dispatcher om de huidige bewerking te beëindigen door een exception op te werpen. De publieke exception is afhankelijk van de bewerking en het presentatief­formaat. Bijvoorbeeld, bij laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxreadexception/) of [PptReadException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptreadexception/) optreden, terwijl bij opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxexception/) kan voorkomen. Handhaaf de exception aan de grens van de bewerking en gebruik het waarschuwingsrapport om te bepalen of het applicatie‑beleid de beëindiging heeft veroorzaakt in plaats van te vertrouwen op één subtype of bericht. De callback registreert de waarschuwing voordat `ReturnAction::Abort` wordt geretourneerd, zodat de reden beschikbaar blijft voor de applicatie.

## **Waarschuwingscategorieën**

De [WarningType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/)‑klasse biedt integer‑constanten voor de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/#SourceFileCorruption) | De bronpresentatie bevat corruptie die een in het oorspronkelijke formaat opgeslagen document onbruikbaar kan maken. | Afbreken. |
| [DataLoss](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/#DataLoss) | Tekst, grafieken, afbeeldingen of andere gegevens kunnen ontbreken na het laden of opslaan. | Afbreken. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders registreren en doorgaan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Een beperkte opmaakverschil kan optreden. | Registreren voor diagnostiek en doorgaan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Het resultaat opent of gedraagt zich mogelijk niet correct in sommige applicaties of oudere versies. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| [UnexpectedContent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/warningtype/#UnexpectedContent) | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan de impact nog niet bekend is. | Registreren en doorgaan, of behandelen als fout in een streng beleid. |

De categorie dient de beleidsbeslissing te sturen. Sla de waarde die door [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) wordt geretourneerd op voor diagnostiek, maar baseer de toepassingslogica niet op de bewoording, omdat de berichttekst kan variëren tussen waarschuwingsscenario’s en productversies.

## **Waarschuwingen verzamelen en classificeren**

Het volgende voorbeeld gebruikt één applicatieniveau‑rapport voor de volledige verwerkingspijplijn. Een aparte callback‑instantie labelt waarschuwingen van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid breekt af bij broncorruptie of gegevensverlies, breekt eventueel af bij aanzienlijk formatteringsverlies, en gaat door bij andere waarschuwingen. De callback zet waarschuwingswaarden om naar native PHP‑waarden met `java_values` voordat ze worden geregistreerd en vergeleken.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Geef `false` door voor `abortOnMajorFormattingLoss` bij het construeren van `WarningPolicy` als grote opmaakverschillen acceptabel zijn. Compatibiliteitsproblemen, klein formatteringsverlies en onverwachte inhoud blijven wel in het rapport behouden, zelfs wanneer de bewerking doorgaat. Breid `WarningPolicy::getAction` uit als de applicatie een van die categorieën moet afwijzen.

## **Algemene waarschuwingsscenario’s**

Waarschuwingen kunnen op verschillende fasen van een workflow verschijnen:

- **Digitale handtekeningen:** Een ondertekende presentatie kan bij het laden een waarschuwing geven dat de handtekening verloren gaat tijdens de verwerking. Aspose.Slides meldt deze `DataLoss`‑conditie via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationsignedwarninginfo/). Een callback in de laadfase laat de applicatie het bestand afwijzen of expliciet de gemelde verlies accepteren.
- **Lettertype‑substitutie:** Een niet‑beschikbaar lettertype kan worden vervangen terwijl een slide wordt gerenderd of geëxporteerd. Lettertype‑substitutie‑waarschuwingen worden gerapporteerd als `DataLoss`, zodat het strikte beleid hierboven afbreekt, zelfs als de applicatie een specifieke vervanging visueel acceptabel zou vinden. Gebruik een invoerpresentatie met tekst in een lettertype dat niet beschikbaar is op de runtime om dit gedrag te observeren. De waarschuwing‑beschrijving identificeert de substitutie; configureer de vereiste lettertypen of [lettertype‑substitutieregels](/slides/nl/php-java/font-substitution/) voordat u het opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatierecords of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer data of opmaak bekend is beïnvloed.
- **Formaatcompatibiliteit:** Opslaan naar een ander presentatief­formaat kan functies weglaten of een resultaat opleveren dat zich anders gedraagt in sommige applicaties. Bijvoorbeeld, opslaan van een presentatie met meer dan acht horizontale of acht verticale tekengidsen naar legacy PPT meldt een `CompatibilityIssue`. De callback in de slaffase kan het verlies registreren en doorgaan, of het afwijzen als het behouden van alle gidsen vereist is.
- **Laadgedrag:** Laad‑opties en legacy‑gedrag kunnen ook waarschuwingen genereren. Bijvoorbeeld, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identificeert het gebruik van een verouderd presentatie‑vergrendelingsgedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het bron‑document, het doelformaat, de bewerking en de Aspose.Slides‑versie. Ga er niet van uit dat elk bestand een waarschuwing genereert of dat een scenario altijd in slechts één categorie valt.

## **Veilig afgebroken bewerkingen afhandelen**

Wanneer een callback `ReturnAction::Abort` retourneert, gebruik dan geen object dat niet succesvol is geladen en ga er niet van uit dat een render‑ of output‑bestand compleet is. De bewerking kan stoppen nadat een output‑bestand is aangemaakt maar voordat het volledig is voltooid.

Sla gevalideerde resultaten op naar een apart pad, bijvoorbeeld `validated-output.pptx`. Vervang een bestaande presentatie pas nadat de bewerking succesvol heeft afgerond, het waarschuwingsrapport voldoet aan het toepassingsbeleid en de output geopend en gecontroleerd kan worden. Dit voorkomt dat een geldig bronbestand wordt overschreven door een gedeeltelijk of afgewezen resultaat.

Een leeg waarschuwingsrapport garandeert niet dat elke bronfunctie behouden is gebleven. Pas eventuele extra inhoud‑ en visuele controles toe die de applicatie vereist. Zie ook [Open Presentations](/slides/nl/php-java/open-presentation/) en [Save Presentations](/slides/nl/php-java/save-presentation/).

## **FAQ**

**Kan een waarschuwingscallback elke Aspose.Slides‑fout afhandelen?**

Nee. Hij handelt alleen herstelbare condities af die als waarschuwingen worden gerapporteerd. Exceptions die onafhankelijk van de callback optreden, moeten door de applicatie rondom het laad‑, render‑, conversie‑ of opslaan‑oproep worden afgehandeld.

**Garandeert het retourneren van `ReturnAction::Continue` identieke output?**

Nee. Het staat alleen toe dat de verwerking doorgaat. De gerapporteerde conditie kan nog steeds leiden tot gegevens‑, opmaak‑ of compatibiliteitsverschillen, dus controleer de verzamelde waarschuwings­types en beschrijvingen.

**Hoe kan een applicatie de bewerking identificeren die een waarschuwing heeft gegenereerd?**

Maak voor elke bewerking een callback‑instantie en sla een door de applicatie gedefinieerde fase op samen met de waarden die door [getWarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) worden geretourneerd, zoals getoond in het voorbeeld.