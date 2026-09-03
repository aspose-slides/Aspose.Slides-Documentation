---
title: Zpracování varování prezentací na Androidu
type: docs
weight: 90
url: /cs/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback varování
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
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak sbírat, klasifikovat a reagovat na varování při načítání, vykreslování, konverzi a ukládání prezentací pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Aspose.Slides může během načítání, vykreslování, konverze nebo ukládání prezentace hlásit obnovitelné problémy. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, náhradu písma a omezení cílového formátu. Callback pro varování umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může aktuální operace pokračovat.

Implementujte rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarningcallback/) a prozkoumejte hodnoty poskytované přes [IWarningInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarninginfo/): [getWarningType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarninginfo/#getDescription--). Vraťte [ReturnAction.Continue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/returnaction/#Continue) pro přijetí varování nebo [ReturnAction.Abort](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/returnaction/#Abort) pro zastavení operace.

Pro varování vznikající při otevírání prezentace použijte [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-). Třídy pro renderování a export dědí [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), která přijímá varování při vykreslování, konverzi a ukládání snímků. Protože samotné varování neurčuje, o jakou aplikaci se jedná, při sestavování kombinované zprávy přiřaďte každou instanci callbacku ke konkrétnímu stadiu operace.

## **Varování a výjimky**

Varování popisuje stav, ze kterého se Aspose.Slides může zotavit, pokud callback vrátí `ReturnAction.Continue`. Výjimka znamená, že požadovaná operace nemůže normálně dokončit; výjimky nejsou převáděny na varování a nelze je ošetřit pomocí politiky varování.

Vrácení `ReturnAction.Abort` požaduje od dispatchera varování ukončení aktuální operace vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například při načítání může dojít k [PptxReadException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptreadexception/), zatímco při ukládání nebo exportu se může objevit [PptxException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxexception/). Výjimku ošetřete na hranici operace a použijte zprávu o varování k určení, zda ukončení způsobila politika aplikace, namísto spoléhaní se na jeden typ výjimky nebo zprávu. Callback zaznamená varování před vrácením `ReturnAction.Abort`, čímž zůstane důvod dostupný aplikaci.

## **Kategorie varování**

Třída [WarningType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/) poskytuje celočíselné konstanty pro následující kategorie:

| Typ varování | Význam | Typická politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Zdrojová prezentace obsahuje poškození, které může učinit dokument uložený v původním formátu nepoužitelným. | Ukončit. |
| [DataLoss](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/#DataLoss) | Po načtení nebo uložení může chybět text, grafy, obrázky nebo jiná data. | Ukončit. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Prezentace může ztratit důležitou formátování. | Ukončit ve striktním validačním režimu; jinak zaznamenat a pokračovat. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Může dojít k omezenému rozdílu ve formátování. | Zaznamenat pro diagnostiku a pokračovat. |
| [CompatibilityIssue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Výsledek se může v některých aplikacích nebo starších verzích neotevřít či nesprávně chovat. | Zaznamenat a pokračovat, pokud kompatibilita není povinná. |
| [UnexpectedContent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Zdroj obsahuje nepodporovaný nebo nerozpoznaný obsah, jehož dopad ještě není znám. | Zaznamenat a pokračovat, nebo považovat za chybu ve striktní politice. |

Kategorie by měla řídit rozhodnutí o politice. Uložte hodnotu vrácenou metodou [getDescription](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) pro diagnostiku, ale nespoléhejte se na její znění pro logiku aplikace, protože text zprávy se může lišit mezi různými scénáři varování a verzemi produktu.

## **Sbírejte a klasifikujte varování**

Níže uvedený příklad používá jednu aplikací úrovňovou zprávu pro celý zpracovatelský řetězec. Samostatná instance callbacku označuje varování z načítání, renderování, konverze do PDF a ukládání jako PPTX. Politika ukončuje při poškození zdroje nebo ztrátě dat, volitelně ukončuje při velké ztrátě formátování a pokračuje u ostatních varování.

Umístěte soubor `input.pptx` do zapisovatelného adresáře aplikace a předávejte tento adresář metodě `PresentationWarningExample.run`. Příklad ukládá výstupy do téhož adresáře. Spusťte zpracování prezentace na pozadí, aby uživatelské rozhraní Androidu zůstalo responzivní.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Při konstrukci `WarningPolicy` předávejte `false` pro parametr `abortOnMajorFormattingLoss`, pokud jsou rozdíly ve formátování přijatelnější. Problémy s kompatibilitou, menší ztráty formátování a neočekávaný obsah zůstávají i nadále v reportu, i když operace pokračuje. Rozšiřte metodu `WarningPolicy.getAction`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře varování**

Varování se mohou objevit v různých fázích workflow:

- **Digitální podpisy:** Podepsaná prezentace může při načítání vyvolat varování, že její podpis bude během zpracování ztracen. Aspose.Slides tuto podmínku `DataLoss` hlásí přes [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ve fázi načítání umožní aplikaci soubor odmítnout nebo výslovně přijmout hlášenou ztrátu.
- **Náhrada písma:** Nedostupné písmo může být nahrazeno během vykreslování snímku nebo exportu. Varování o náhradě písma jsou hlášena jako `DataLoss`, takže výše uvedená striktní politika ukončí i tehdy, když by aplikace považovala konkrétní náhradu za vizuálně přijatelnou. Pro pozorování tohoto chování použijte vstupní prezentaci obsahující text v písmu, které není v době běhu dostupné. Popis varování identifikuje náhradu; nakonfigurujte požadovaná písma nebo [pravidla náhrady písma](/slides/cs/androidjava/font-substitution/) před opakovaným pokusem.
- **Nepodporovaný nebo neočekávaný obsah:** Načítač může narazit na záznamy nebo funkce prezentace, které nepozná. Taková varování mohou používat `UnexpectedContent` nebo vážnější kategorizaci, pokud jsou data či formátování ovlivněny.
- **Kompatibilita formátu:** Ukládání do jiného formátu prezentace může vynechat funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například ukládání prezentace s více než osmi horizontálními či vertikálními vodicími čarami do staršího PPT může hlásit `CompatibilityIssue`. Callback ve fázi ukládání může ztrátu zaznamenat a pokračovat, nebo ji odmítnout, pokud je vyžadováno zachování všech čar.
- **Chování při načítání:** Možnosti načítání a staré chování mohou také vyvolávat varování. Například [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifikuje použití zastaralého zamykání prezentace jako `CompatibilityIssue`.

Varování závisí na zdrojovém dokumentu, cílovém formátu, operaci a verzi Aspose.Slides. Nepředpokládejte, že každý soubor vytvoří varování nebo že scénář vždy patří do jedné kategorie.

## **Bezpečné zpracování ukončených operací**

Když callback vrátí `ReturnAction.Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup renderování nebo uložení je kompletní. Operace může skončit po vytvoření výstupního souboru, ale před jeho dokončením.

Ukládejte ověřené výsledky do jiného umístění, například `validated-output.pptx`. Existující prezentaci přepište až po úspěšném dokončení operace, pokud zpráva o varování splňuje politiku aplikace a výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru částečným nebo odmítnutým výsledkem.

Prázdná zpráva o varování není zárukou, že všechny zdrojové funkce byly zachovány. Proveďte další kontrole obsahu a vizuální kontroly požadované aplikací. Viz také [Open Presentations](/slides/cs/androidjava/open-presentation/) a [Save Presentations](/slides/cs/androidjava/save-presentation/).

## **Často kladené otázky**

**Může callback pro varování zvládnout každou chybu Aspose.Slides?**

Ne. Zvládá jen obnovitelné podmínky hlášené jako varování. Výjimky, které nastanou nezávisle na callbacku, musí aplikace ošetřit kolem volání načítání, renderování, konverze nebo ukládání.

**Zaručuje vrácení `ReturnAction.Continue` identický výstup?**

Ne. Pouze povoluje pokračování zpracování. Hlásená podmínka může stále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto přezkoumejte shromážděné typy a popisy varování.

**Jak může aplikace identifikovat operaci, která varování vyvolala?**

Vytvořte instanci callbacku pro každou operaci a uložte aplikací definované stadium spolu s hodnotami vrácenými metodami [getWarningType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), jak je ukázáno v příkladu.