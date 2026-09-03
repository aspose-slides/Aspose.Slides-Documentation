---
title: "Řízení varování prezentací v PHP"
type: docs
weight: 90
url: /cs/php-java/presentation-warnings/
aliases:
- /php-java/ziskavani-varovaci-callbacku-pro-nahradu-pismen-v-aspose-slides/
keywords:
- varovný callback
- politika varování
- ztráta dat
- poškození zdroje
- problém kompatibility
- náhrada písma
- digitální podpis
- načítání prezentace
- vykreslování prezentace
- konverze prezentace
- ukládání prezentace
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Naučte se, jak sbírat, klasifikovat a reagovat na varování při načítání, vykreslování, převodu a ukládání prezentací pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides může hlásit obnovitelné problémy během načítání, vykreslování, převodu nebo ukládání prezentace. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, nahrazení písem a omezení cílového formátu. Callback varování umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může současná operace pokračovat.

Vytvořte třídu PHP s veřejnou metodou `warning` a exponujte ji prostřednictvím PHP Java Bridge jako rozhraní Java [IWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarningcallback/) pomocí `java_closure`. Prozkoumejte hodnoty [getWarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--) poskytované prostřednictvím [IWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/). Vraťte [ReturnAction::Continue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/returnaction/#Continue) pro přijetí varování nebo [ReturnAction::Abort](https://reference.aspose.com/slides/cs/php-java/aspose.slides/returnaction/#Abort) pro zastavení operace.

Použijte [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setWarningCallback) pro varování vyvolaná při otevírání prezentace. Třídy pro vykreslování a export dědí [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setWarningCallback), která přijímá varování z vykreslování snímků, převodu a ukládání. Protože samotné varování neidentifikuje operaci aplikace, při vytváření kombinované zprávy přiřaďte každou instanci callbacku ke konkrétní fázi operace.

## **Varování a výjimky**

Java výjimky jsou zpřístupněny v PHP přes PHP Java Bridge; zachytávejte je na hranici operace, jak je ukázáno v příkladu níže. Odkazy na rozhraní Java v tomto článku popisují smlouvu callbacku používanou mostem.

Varování popisuje podmínku, ze které se Aspose.Slides může zotavit, pokud callback vrátí `ReturnAction::Continue`. Výjimka znamená, že požadovaná operace nemůže být dokončena normálně; výjimky nejsou převedeny na varování a nemohou být zpracovány politikou varování.

Vrácení `ReturnAction::Abort` požaduje, aby dispatcher varování ukončil aktuální operaci vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například při načítání může vzniknout [PptxReadException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptreadexception/), zatímco při ukládání nebo exportu může vzniknout [PptxException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxexception/). Ošetřete výjimku na hranici operace a použijte zprávu o varování k určení, zda ukončení způsobila politika aplikace, místo spoléhaní se na jeden podtyp výjimky nebo zprávu. Callback zaznamená varování před vrácením `ReturnAction::Abort`, čímž zajistí, že důvod zůstane dostupný aplikaci.

## **Kategorie varování**

Třída [WarningType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/) poskytuje celočíselné konstanty pro následující kategorie:

| Typ varování | Význam | Typická politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Zdrojová prezentace obsahuje poškození, které může způsobit, že dokument uložený v původním formátu bude nevyužitelný. | Přerušit. |
| [DataLoss](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/#DataLoss) | Text, grafy, obrázky nebo jiná data mohou po načtení či uložení chybět. | Přerušit. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Prezentace může ztratit důležité formátování. | Přerušit ve strict validačním režimu; jinak zaznamenat a pokračovat. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Může se vyskytnout omezený rozdíl ve formátování. | Zaznamenat pro diagnostiku a pokračovat. |
| [CompatibilityIssue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Výsledek se nemusí otevřít nebo se správně chovat v některých aplikacích nebo starších verzích. | Zaznamenat a pokračovat, pokud není kompatibilita povinná. |
| [UnexpectedContent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/warningtype/#UnexpectedContent) | Zdroj obsahuje nepodporovaný nebo neznámý obsah, jehož dopad ještě není znám. | Zaznamenat a pokračovat, nebo považovat za chybu ve strict politice. |

Kategorie by měla řídit rozhodnutí o politice. Uložte hodnotu vrácenou metodou [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--) pro diagnostiku, ale nespoléhejte se na její znění v aplikační logice, protože text zprávy se může lišit mezi scénáři varování a verzemi produktu.

## **Sbírat a klasifikovat varování**

Následující příklad používá jednu aplikační zprávu pro celý zpracovatelský řetězec. Samostatná instance callbacku označuje varování z načítání, vykreslování, konverze do PDF a ukládání PPTX. Politika přerušuje při poškození zdroje nebo ztrátě dat, volitelně přerušuje při velkém ztrátě formátování a pokračuje u ostatních varování. Callback před zaznamenáním a porovnáním převádí hodnoty varování na nativní PHP hodnoty pomocí `java_values`.

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

Při konstruování `WarningPolicy` předávejte `false` pro `abortOnMajorFormattingLoss`, pokud jsou akceptovatelné větší rozdíly ve formátování. Problémy s kompatibilitou, menší ztráta formátování a neočekávaný obsah jsou i nadále zahrnuty ve zprávě, i když operace pokračuje. Rozšiřte `WarningPolicy::getAction`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře varování**

Varování se mohou objevit v různých fázích pracovního postupu:

- **Digitální podpisy:** Podepsaná prezentace může během načítání vyvolat varování, že její podpis bude při zpracování ztracen. Aspose.Slides hlásí tuto podmínku `DataLoss` prostřednictvím [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback v načítací fázi umožňuje aplikaci soubor odmítnout nebo výslovně přijmout hlášenou ztrátu.
- **Náhrada písem:** Nedostupné písmo může být nahrazeno během vykreslování nebo exportu snímku. Varování o náhradě písem jsou hlášena jako `DataLoss`, takže výše uvedená přísná politika přeruší i v případě, že by aplikace považovala konkrétní náhradu za vizuálně přijatelnou. Pro otestování tohoto chování použijte vstupní prezentaci s textem v písmu, které není v runtime dostupné. Popis varování identifikuje náhradu; před opakováním nakonfigurujte požadovaná písma nebo [pravidla náhrady písem](/slides/cs/php-java/font-substitution/).
- **Nepodporovaný nebo neočekávaný obsah:** Načítač může narazit na záznamy nebo funkce prezentace, které nepozná. Taková varování mohou použít `UnexpectedContent` nebo závažnější kategorii, pokud jsou data či formátování ovlivněny.
- **Kompatibilita formátu:** Ukládání do jiného formátu prezentace může vynechat funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například uložení prezentace s více než osmi vodorovnými nebo svislými vodicími čarami do staršího PPT hlásí `CompatibilityIssue`. Callback v ukládací fázi může ztrátu zaznamenat a pokračovat, nebo ji odmítnout, pokud je vyžadováno zachování všech vodicích čar.
- **Chování načítání:** Možnosti načítání a starší chování mohou také vyvolávat varování. Například [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifikuje použití zastaralého chování zamykání prezentace jako `CompatibilityIssue`.

Varování závisí na zdrojovém dokumentu, cílovém formátu, operaci a verzi Aspose.Slides. Nepředpokládejte, že každý soubor vyvolá varování nebo že scénář vždy spadá do jediné kategorie.

## **Bezpečné zacházení s přerušenými operacemi**

Když callback vrátí `ReturnAction::Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup vykreslení nebo uložení je kompletní. Operace může skončit po vytvoření výstupního souboru, ale před jeho dokončením.

Ukládejte ověřené výsledky do samostatné cesty, např. `validated-output.pptx`. Existující prezentaci nahraďte až po úspěšném dokončení operace, po splnění politiky varování a po prověření, že výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru částečným nebo odmítnutým výsledkem.

Prázdná zpráva o varování nezaručuje, že byly zachovány všechny zdrojové funkce. Proveďte jakékoli další kontrolní a vizuální testy požadované aplikací. Viz také [Open Presentations](/slides/cs/php-java/open-presentation/) a [Save Presentations](/slides/cs/php-java/save-presentation/).

## **Často kladené otázky**

**Can a warning callback handle every Aspose.Slides error?**

Ne. Zpracovává obnovitelné podmínky hlášené jako varování. Výjimky, které nastanou nezávisle na callbacku, musí být ošetřeny aplikací kolem volání načítání, vykreslování, konverze nebo ukládání.

**Does returning `ReturnAction::Continue` guarantee identical output?**

Ne. Pouze umožňuje pokračovat ve zpracování. Hlásená podmínka může stále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto je nutné přezkoumat získané typy a popisy varování.

**How can an application identify the operation that produced a warning?**

Vytvořte instanci callbacku pro každou operaci a uložte aplikací definovanou fázi společně s hodnotami vrácenými metodami [getWarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--), jak je ukázáno v příkladu.