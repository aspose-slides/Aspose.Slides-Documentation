---
title: "Zpracování varování v prezentaci v Java"
type: docs
weight: 90
url: /cs/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- "callback varování"
- "politika varování"
- "ztráta dat"
- "poškození zdroje"
- "problém kompatibility"
- "nahrazení fontu"
- "digitální podpis"
- "načítání prezentace"
- "vykreslování prezentace"
- "konverze prezentace"
- "ukládání prezentace"
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Naučte se shromažďovat, klasifikovat a reagovat na varování během načítání, vykreslování, konverze a ukládání prezentací s Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides může hlásit opravitelná problémy během načítání, vykreslování, konverze nebo ukládání prezentace. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, náhradu fontů a omezení cílového formátu. Callback varování umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může aktuální operace pokračovat.

Implementujte rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarningcallback/) a prozkoumejte hodnoty [getWarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--) poskytované prostřednictvím [IWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/). Vraťte [ReturnAction.Continue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/returnaction/#Continue) pro přijetí varování nebo [ReturnAction.Abort](https://reference.aspose.com/slides/cs/java/com.aspose.slides/returnaction/#Abort) pro zastavení operace.

Použijte [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) pro varování vyvolaná při otevírání prezentace. Třídy pro vykreslování a exportní možnosti dědí [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), které přijímají varování z vykreslování snímků, konverze a ukládání. Protože samotné varování neidentifikuje operaci aplikace, při vytváření kombinované zprávy přiřaďte každou instanci callbacku ke konkrétnímu stádiu operace.

## **Varování a výjimky**

Varování popisuje stav, ze kterého se Aspose.Slides může zotavit, pokud callback vrátí `ReturnAction.Continue`. Výjimka znamená, že požadovaná operace nemůže být dokončena normálně; výjimky nejsou převáděny na varování a nemohou být zpracovány politikou varování.

Vrácení `ReturnAction.Abort` žádá dispatchera varování, aby ukončil aktuální operaci vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například při načítání může nastat [PptxReadException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptreadexception/), zatímco při ukládání nebo exportu může nastat [PptxException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxexception/). Výjimku zachyťte na hranici operace a použijte zprávu o varování k určení, zda ukončení způsobila politika aplikace, místo spoléhaní se na jeden podtyp výjimky nebo zprávu. Callback zaznamená varování před vrácením `ReturnAction.Abort`, čímž zajistí, že důvod zůstane aplikaci dostupný.

## **Kategorie varování**

Třída [WarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/) poskytuje celočíselné konstanty pro následující kategorie:

| Typ varování | Význam | Typická politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Zdrojová prezentace obsahuje poškození, které může způsobit, že dokument uložený v původním formátu bude nepoužitelný. | Zrušit. |
| [DataLoss](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/#DataLoss) | Text, grafy, obrázky nebo jiná data mohou po načtení nebo uložení chybět. | Zrušit. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Prezentace může ztratit důležité formátování. | Zrušit v režimu přísné validace; jinak zaznamenat a pokračovat. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Může nastat omezený rozdíl ve formátování. | Zaznamenat pro diagnostiku a pokračovat. |
| [CompatibilityIssue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Výsledek se nemusí otevřít nebo správně fungovat v některých aplikacích nebo starších verzích. | Zaznamenat a pokračovat, pokud není kompatibilita povinná. |
| [UnexpectedContent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/warningtype/#UnexpectedContent) | Zdroj obsahuje nepodporovaný nebo nerozpoznaný obsah, jehož vliv ještě nemusí být znám. | Zaznamenat a pokračovat, nebo v přísné politice považovat za chybu. |

Kategorie by měla řídit rozhodnutí o politice. Uložte hodnotu vrácenou metodou [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--) pro diagnostiku, ale nespoléhejte se na její znění v aplikační logice, protože text zprávy se může lišit mezi různými scénáři varování a verzemi produktu.

## **Shromažďování a klasifikace varování**

Následující příklad používá jednu reportáž na úrovni aplikace pro celý zpracovatelský řetězec. Samostatná instance callbacku označuje varování z načítání, vykreslování, konverze do PDF a ukládání PPTX. Politika zruší operaci při poškození zdroje nebo ztrátě dat, volitelně zruší při velké ztrátě formátování a pro ostatní varování pokračuje.

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
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
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
                image.save("slide-1.png", ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
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

Při konstrukci `WarningPolicy` předávejte `false` pro `abortOnMajorFormattingLoss`, pokud jsou hlavní rozdíly ve formátování přijatelné. Problémy s kompatibilitou, menší ztráta formátování a neočekávaný obsah jsou i nadále uchovávány v reportu, i když operace pokračuje. Rozšiřte `WarningPolicy.getAction`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře varování**

Varování se mohou vyskytnout v různých fázích pracovního postupu:

- **Digitální podpisy:** Podepsaná prezentace může během načítání vyvolat varování, že její podpis bude během zpracování ztracen. Aspose.Slides hlásí tento stav `DataLoss` prostřednictvím [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback v načítací fázi umožní aplikaci soubor odmítnout nebo výslovně přijmout hlášenou ztrátu.
- **Náhrada fontu:** Nedostupný font může být nahrazen během vykreslování snímku nebo exportu. Varování o náhradě fontu jsou hlášena jako `DataLoss`, takže přísná politika výše zruší operaci i když by aplikace považovala konkrétní náhradu za vizuálně přijatelné. Pro pozorování tohoto chování použijte vstupní prezentaci obsahující text ve fontu, který není v runtime dostupný. Popis varování identifikuje náhradu; nakonfigurujte požadované fonty nebo [pravidla nahrazení fontů](/slides/cs/java/font-substitution/) před opětovným pokusem.
- **Nepodporovaný nebo neočekávaný obsah:** Načítací modul může narazit na záznamy prezentace nebo funkce, které nezná. Taková varování mohou použít `UnexpectedContent`, nebo závažnější kategorii, pokud jsou data nebo formátování ovlivněny.
- **Kompatibilita formátu:** Ukládání do jiného formátu prezentace může vynechat funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například ukládání prezentace s více než osmi vodorovnými nebo svislými vodicími čarami do staršího PPT hlásí `CompatibilityIssue`. Callback v úložné fázi může zaznamenat ztrátu a pokračovat, nebo ji odmítnout, pokud je vyžadováno zachování všech čar.
- **Chování načítání:** Možnosti načítání a starší chování mohou také generovat varování. Například [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifikuje použití zastaralého chování zamykání prezentace jako `CompatibilityIssue`.

Varování závisí na zdrojovém dokumentu, cílovém formátu, operaci a verzi Aspose.Slides. Nepředpokládejte, že každý soubor vyvolá varování nebo že scénář vždy patří jen do jedné kategorie.

## **Bezpečné zacházení s přerušenými operacemi**

Když callback vrátí `ReturnAction.Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup z vykreslování nebo ukládání je kompletní. Operace může být ukončena po vytvoření výstupního souboru, ale před jeho dokončením.

Uložte ověřené výsledky do samostatné cesty, například `validated-output.pptx`. Existující prezentaci přepište až po úspěšném dokončení operace, když zpráva o varování splňuje politiku aplikace a výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru neúplným nebo odmítnutým výsledkem.

Prázdná zpráva o varování není zárukou, že všechny funkce zdroje byly zachovány. Použijte jakékoli další kontrolní a vizuální kontroly požadované aplikací. Viz také [Otevření prezentací](/slides/cs/java/open-presentation/) a [Uložení prezentací](/slides/cs/java/save-presentation/).

## **Často kladené otázky**

**Může callback varování zvládnout každou chybu Aspose.Slides?**

**Ne. Zpracovává pouze podmínky, které lze zotavit a jsou hlášeny jako varování. Výjimky, které nastanou nezávisle na callbacku, musí aplikace zachytit kolem volání načítání, vykreslování, konverze nebo ukládání.**

**Zaručuje vrácení `ReturnAction.Continue` stejný výstup?**

**Ne. Pouze umožňuje pokračování zpracování. Nahlášený stav může i nadále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto přezkoumejte shromážděné typy varování a jejich popisy.**

**Jak může aplikace identifikovat operaci, která vyvolala varování?**

**Vytvořte instanci callbacku pro každou operaci a uložte aplikací definované stadium spolu s hodnotami vrácenými metodami [getWarningType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getWarningType--) a [getDescription](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarninginfo/#getDescription--), jak je ukázáno v příkladu.**