---
title: Zpracování varování prezentací v Node.js
type: docs
weight: 90
url: /cs/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback varování
- politika varování
- ztráta dat
- poškození zdroje
- problém kompatibility
- náhrada písma
- digitální podpis
- načítání prezentace
- renderování prezentace
- konverze prezentace
- ukládání prezentace
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Zjistěte, jak shromažďovat, klasifikovat a reagovat na varování při načítání, renderování, převodu a ukládání prezentací s Aspose.Slides pro Node.js pomocí Javy."
---
## **Přehled**

Aspose.Slides může během načítání, renderování, konverze nebo ukládání prezentace hlásit opravitelná problémy. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, náhradu písem a omezení cílového formátu. Callback varování umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může aktuální operace pokračovat.

Použijte `java.newProxy` k implementaci rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarningcallback/) v JavaScriptu a prozkoumejte hodnoty [getWarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--) poskytované přes [IWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/). Vraťte [ReturnAction.Continue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/returnaction/#Continue) pro přijetí varování nebo [ReturnAction.Abort](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/returnaction/#Abort) pro zastavení operace.

Použijte [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) pro varování vyvolaná při otevírání prezentace. Třídy pro renderování a export dědí [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), která přijímá varování z renderování snímků, konverze a ukládání. Protože samotné varování neidentifikuje aplikaci, při sestavování kombinované zprávy přiřaďte každou instanci callbacku ke konkrétnímu etapě operace.

## **Varování a výjimky**

Varování popisuje podmínku, ze které se Aspose.Slides může zotavit, pokud callback vrátí `ReturnAction.Continue`. Výjimka znamená, že požadovaná operace nemůže dokončit normálně; výjimky nejsou převedeny na varování a nelze je zpracovat politikou varování.

Vrácení `ReturnAction.Abort` požaduje od dispatchera varování ukončit aktuální operaci vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například načítání může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptreadexception/), zatímco ukládání nebo export může vyvolat [PptxException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxexception/). Zachyťte chybu z Java mostu na hranici operace a použijte zprávu o varování k určení, zda ukončení způsobila politika aplikace, místo spoléhaní se na konkrétní podtyp výjimky nebo zprávu. Callback zaznamená varování před vrácením `ReturnAction.Abort`, čímž zajistí, že důvod zůstane aplikaci dostupný.

## **Kategorie varování**

Třída [WarningType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/) poskytuje celočíselné konstanty pro následující kategorie:

| Typ varování | Význam | Typická politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Zdrojová prezentace obsahuje poškození, které může učinit dokument uložený v původním formátu nepoužitelným. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/#DataLoss) | Po načtení nebo uložení může chybět text, grafy, obrázky nebo jiná data. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Prezentace může ztratit důležité formátování. | Abort ve strict validačním režimu; jinak zaznamenat a pokračovat. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Může dojít k omezenému rozdílu ve formátování. | Zaznamenat pro diagnostiku a pokračovat. |
| [CompatibilityIssue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Výsledek se nemusí otevřít nebo chovat správně v některých aplikacích či starších verzích. | Logovat a pokračovat, pokud není kompatibilita povinná. |
| [UnexpectedContent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Zdroj obsahuje nepodporovaný nebo neznámý obsah, jehož dopad ještě není znám. | Zaznamenat a pokračovat, nebo považovat za chybu v přísné politice. |

Kategorie by měla řídit rozhodnutí o politice. Uložte hodnotu vrácenou metodou [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--) pro diagnostiku, ale nespoléhejte na její znění v aplikační logice, protože text zprávy se může lišit mezi scénáři varování a verzemi produktu.

## **Sbírejte a klasifikujte varování**

Následující příklad v JavaScriptu používá jeden report na úrovni aplikace pro celý zpracovatelský řetězec. Samostatná instance callbacku označuje varování z načítání, renderování, konverze do PDF a ukládání PPTX. Politika přeruší při poškození zdroje nebo ztrátě dat, volitelně přeruší při velké ztrátě formátování a pro ostatní varování pokračuje.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Při konstrukci `WarningPolicy` předávejte `false` pro `abortOnMajorFormattingLoss`, pokud jsou velké rozdíly ve formátování akceptovatelné. Problémy s kompatibilitou, menší ztráty formátování a neočekávaný obsah jsou i tak zachovány v reportu, i když operace pokračuje. Rozšiřte `WarningPolicy.getAction`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře varování**

Varování se mohou objevit v různých fázích pracovního postupu:

- **Digitální podpisy:** Podepsaná prezentace může při načítání vyvolat varování, že podpis bude během zpracování ztracen. Aspose.Slides hlásí tento stav jako `DataLoss` přes [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ve fázi načítání umožní aplikaci soubor odmítnout nebo výslovně přijmout hlášenou ztrátu.
- **Náhrada písem:** Nedostupné písmo může být nahrazeno během renderování nebo exportu snímku. Varování o náhradě písem jsou hlášena jako `DataLoss`, takže přísná politika výše ukončí operaci, i když by aplikace považovala konkrétní náhradu za vizuálně přijatelnou. Chcete‑li pozorovat toto chování, použijte vstupní prezentaci s textem nastaveným na písmo, které není v runtime dostupné. Popis varování identifikuje náhradu; nastavte požadovaná písma nebo [font substitution rules](/slides/cs/nodejs-java/font-substitution/) před dalším pokusem.
- **Nepodporovaný nebo neočekávaný obsah:** Načítací modul může narazit na záznamy nebo funkce prezentace, které nepozná. Taková varování mohou použít `UnexpectedContent` nebo závažnější kategorii, pokud jsou data či formátování ovlivněny.
- **Kompatibilita formátu:** Ukládání do jiného formátu může vynechat funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například uložení prezentace s více než osmi vodorovnými nebo svislými vodícími čarami do staršího PPT hlásí `CompatibilityIssue`. Callback ve fázi ukládání může ztrátu zaznamenat a pokračovat, nebo ji odmítnout, pokud je vyžadováno zachování všech vodítek.
- **Chování při načítání:** Možnosti načítání a starší chování mohou také vyvolávat varování. Například [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifikuje použití zastaralého chování zamykání prezentace jako `CompatibilityIssue`.

Varování závisí na zdrojovém dokumentu, cílovém formátu, operaci i verzi Aspose.Slides. Nepředpokládejte, že každý soubor vyvolá varování nebo že scénář vždy spadá do jedné kategorie.

## **Bezpečné zacházení s přerušenými operacemi**

Když callback vrátí `ReturnAction.Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup renderování nebo ukládání je kompletní. Operace může skončit po vytvoření výstupního souboru, ale před jeho dokončením.

Ukládejte ověřené výsledky do samostatné cesty, např. `validated-output.pptx`. Existující prezentaci přepište až po úspěšném dokončení operace, pokud zpráva o varování splňuje politiku aplikace a výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru neúplným nebo odmítnutým výsledkem.

Prázdná zpráva o varování není zárukou, že každá funkce zdroje byla zachována. Proveďte další obsahové a vizuální kontroly požadované aplikací. Viz také [Open Presentations](/slides/cs/nodejs-java/open-presentation/) a [Save Presentations](/slides/cs/nodejs-java/save-presentation/).

## **Často kladené otázky**

**Může callback varování ošetřit každou chybu Aspose.Slides?**

Ne. Zpracovává pouze opravitelná podmínky hlášená jako varování. Výjimky, které nastanou nezávisle na callbacku, musí být ošetřeny aplikací okolo volání načítání, renderování, konverze nebo ukládání.

**Zaručuje vrácení `ReturnAction.Continue` identický výstup?**

Ne. Jen povoluje pokračovat ve zpracování. Hlásená podmínka může stále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto přezkoumejte shromážděné typy a popisy varování.

**Jak může aplikace identifikovat operaci, která varování vyvolala?**

Vytvořte instanci callbacku pro každou operaci a uložte aplikací definovanou fázi společně s hodnotami vrácenými metodami [getWarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--), jak je ukázáno v příkladu.