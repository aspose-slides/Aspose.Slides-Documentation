---
title: Hantera presentationsvarningar i PHP
type: docs
weight: 90
url: /sv/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningscallback
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- teckensnittssubstitution
- digital signatur
- presentationsinläsning
- presentationrendering
- presentationskonvertering
- presentationssparande
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Lär dig hur du samlar in, klassificerar och hanterar varningar när du läser in, renderar, konverterar och sparar presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides kan rapportera återställbara problem när den läser in, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposter, innehåll som inte kan bevaras, teckensnittssubstitution och begränsningar i ett målformat. En varningscallback låter en applikation registrera dessa förhållanden och besluta om den aktuella operationen kan fortsätta.

Skapa en PHP-klass med en publik `warning`-metod och exponera den via PHP Java Bridge som Java‑gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarningcallback/) med hjälp av `java_closure`. Granska värdena från [getWarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--) som levereras via [IWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/). Returnera [ReturnAction::Continue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/returnaction/#Continue) för att acceptera varningen eller [ReturnAction::Abort](https://reference.aspose.com/slides/sv/php-java/aspose.slides/returnaction/#Abort) för att stoppa operationen.

Använd [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setWarningCallback) för varningar som uppstår när en presentation öppnas. Rendering‑ och exportalternativklasser ärver [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setWarningCallback), som tar emot varningar från bild‑rendering, konvertering och sparande. Eftersom varningen själv inte identifierar vilken applikationsoperation som gäller, bör du associera varje callback‑instans med ett operationsstadium när du bygger en kombinerad rapport.

## **Varningar och Undantag**

Java‑undantag exponeras för PHP via PHP Java Bridge; fånga dem vid operationens gräns, som visas i exemplet nedan. Java‑gränssnitts­länkarna i den här artikeln beskriver det callback‑kontrakt som används av bryggan.

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om callbacken returnerar `ReturnAction::Continue`. Ett undantag innebär att den begärda operationen inte kan slutföras normalt; undantag konverteras inte till varningar och kan inte hanteras av en varningspolicy.

Att returnera `ReturnAction::Abort` ber varningsdistributören att avsluta den aktuella operationen genom att generera ett undantag. Det publika undantaget beror på operationen och presentationens format. Till exempel kan inläsning ge ett [PptxReadException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptreadexception/), medan sparande eller export kan ge ett [PptxException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxexception/). Hantera undantaget vid operationens gräns och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avslutet istället för att förlita dig på en specifik undantagstyp eller meddelande. Callbacken registrerar varningen innan den returnerar `ReturnAction::Abort`, vilket säkerställer att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

Klassen [WarningType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/) tillhandahåller heltalskonstanter för följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Källpresentationen innehåller korruption som kan göra ett dokument sparat i dess ursprungsformat oanvändbart. | Avbryt. |
| [DataLoss](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/#DataLoss) | Text, diagram, bilder eller annan data kan saknas efter inläsning eller sparning. | Avbryt. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Presentation kan förlora viktig formatering. | Avbryt i strikt valideringsläge; annars registrera och fortsätt. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | En begränsad formateringsskillnad kan uppstå. | Registrera för diagnostik och fortsätt. |
| [CompatibilityIssue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Resultatet kanske inte öppnas eller fungerar korrekt i vissa program eller äldre versioner. | Logga och fortsätt om inte kompatibilitet är obligatorisk. |
| [UnexpectedContent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/warningtype/#UnexpectedContent) | Källan innehåller icke‑stödd eller oidentifierad innehåll vars effekt ännu inte är känd. | Registrera och fortsätt, eller behandla som ett fel i en strikt policy. |

Kategorin bör styra policybeslutet. Spara värdet som returneras av [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--) för diagnostik, men förlita dig inte på dess formulering i affärslogiken eftersom meddelandetexten kan variera mellan varningsscenario och produktversioner.

## **Samla in och klassificera varningar**

Följande exempel använder en applikations‑nivårapport för hela bearbetningskedjan. En separat callback‑instans märker varningar från inläsning, rendering, PDF‑konvertering och PPTX‑sparande. Policyn avbryter vid källkorruption eller dataförlust, avbryter eventuellt vid större formateringsförlust, och fortsätter för övriga varningar. Callbacken konverterar varningsvärden till inhemska PHP‑värden med `java_values` innan de registreras och jämförs.

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

Skicka `false` för `abortOnMajorFormattingLoss` när du konstruerar `WarningPolicy` om stora formateringsavvikelser är acceptabla. Kompatibilitetsproblem, mindre formateringsförlust och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy::getAction` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga varningsscenarier**

Varningar kan uppstå i olika steg av ett arbetsflöde:

- **Digital signaturer:** En signerad presentation kan ge en varning vid inläsning att dess signatur kommer att gå förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`‑tillstånd via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationsignedwarninginfo/). En inläsnings‑stadie‑callback låter applikationen avvisa filen eller explicit acceptera den rapporterade förlusten.
- **Teckensnittssubstitution:** Ett otillgängligt teckensnitt kan ersättas medan en bild renderas eller exporteras. Varningsmeddelanden om teckensnittssubstitution rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle betrakta en viss ersättning som visuellt acceptabel. För att observera detta beteende, använd en inmatningspresentation som innehåller text i ett teckensnitt som inte är tillgängligt för körmiljön. Varningsbeskrivningen identifierar ersättningen; konfigurera de erforderliga teckensnitten eller [teckensnittssubstitutionsregler](/slides/sv/php-java/font-substitution/) innan du försöker igen.
- **Ej stödd eller oväntad innehåll:** En inläsare kan stöta på presentationsposter eller funktioner den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en allvarligare kategori när data eller formatering är kända för att vara påverkade.
- **Formatkompatibilitet:** Att spara till ett annat presentationsformat kan utelämna funktioner eller producera ett resultat som beter sig annorlunda i vissa program. Till exempel rapporterar sparande av en presentation med mer än åtta horisontella eller åtta vertikala ritningsguider till äldre PPT ett `CompatibilityIssue`. Spar‑stadie‑callbacken kan registrera förlusten och fortsätta, eller avvisa den om bevarande av alla guider krävs.
- **Inläsningsbeteende:** Inläsningsalternativ och äldre beteenden kan också ge varningar. Till exempel identifierar [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) användning av ett föråldrat presentations‑låsningsbeteende som ett `CompatibilityIssue`.

Varningar beror på källdokumentet, målformatet, operationen och Aspose.Slides‑versionen. Anta inte att varje fil ger en varning eller att ett scenario alltid motsvarar en enda kategori.

## **Hantera avbrutna operationer på ett säkert sätt**

När en callback returnerar `ReturnAction::Abort` får du inte använda ett objekt som misslyckades att läsas in och får inte anta att en rendering‑ eller sparutdata är komplett. Operationen kan avslutas efter att en utdatafil skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, t.ex. `validated-output.pptx`. Ersätt en befintlig presentation först efter att operationen har slutförts framgångsrikt, varningsrapporten uppfyller applikationspolicyn och utdata kan öppnas och kontrolleras. Detta förhindrar att en giltig källfil skrivs över med ett partiellt eller avvisat resultat.

En tom varningsrapport garanterar inte att varje källfunktion har bevarats. Tillämpa eventuella ytterligare innehålls‑ och visuella kontroller som krävs av applikationen. Se även [Open Presentations](/slides/sv/php-java/open-presentation/) och [Save Presentations](/slides/sv/php-java/save-presentation/).

## **FAQ**

**Kan en varningscallback hantera varje Aspose.Slides‑fel?**

Nej. Den hanterar återställbara tillstånd som rapporteras som varningar. Undantag som inträffar oberoende av callbacken måste hanteras av applikationen runt inläsning, rendering, konvertering eller sparningsanropet.

**Garanterar returnering av `ReturnAction::Continue` identiskt resultat?**

Nej. Det tillåter bara bearbetningen att fortsätta. Det rapporterade tillståndet kan fortfarande orsaka data-, formaterings‑ eller kompatibilitetsskillnader, så granska de insamlade varningstyperna och -beskrivningarna.

**Hur kan en applikation identifiera vilken operation som producerade en varning?**

Skapa en callback‑instans för varje operation och lagra ett applikations‑definierat stadium tillsammans med de värden som returneras av [getWarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--), som visas i exemplet.