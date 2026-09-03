---
title: Zpracování varování prezentací v .NET
type: docs
weight: 120
url: /cs/net/presentation-warnings/
aliases:
- /net/ziskani-callbacku-varovani-pro-nahradu-pismen-v-aspose-slides/
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
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak shromažďovat, klasifikovat a reagovat na varování při načítání, vykreslování, konverzi a ukládání prezentací pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides může hlásit obnovitelné problémy během načítání, vykreslování, konverze nebo ukládání prezentace. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, nahrazení písma a omezení cílového formátu. Callback varování umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může aktuální operace pokračovat.

Implementujte rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/iwarningcallback/) a prozkoumejte vlastnosti [WarningType](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/iwarninginfo/warningtype/) a [Description](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/iwarninginfo/description/) poskytované prostřednictvím [IWarningInfo](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/iwarninginfo/). Vraťte [ReturnAction.Continue](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/returnaction/) pro přijetí varování nebo `ReturnAction.Abort` pro zastavení operace.

Použijte [LoadOptions.WarningCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/warningcallback/) pro varování vyvolaná při otevírání prezentace. Třídy pro vykreslování a exportní možnosti dědí [SaveOptions.WarningCallback](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/warningcallback/), které přijímají varování z vykreslování snímků, konverze a ukládání. Protože samotné varování neidentifikuje operaci aplikace, při vytváření kombinované zprávy přiřaďte každou instanci callbacku ke konkrétnímu stadiu operace.

## **Varování a výjimky**

Varování popisuje stav, ze kterého se Aspose.Slides může zotavit, pokud callback vrátí `ReturnAction.Continue`. Výjimka znamená, že požadovaná operace nemůže být dokončena normálně; výjimky nejsou převáděny na varování a nemohou být zpracovány pomocí politiky varování.

Vrácení `ReturnAction.Abort` požaduje od dispatchera varování ukončit aktuální operaci vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například při načítání může být vyvolána [PptxReadException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptreadexception/), zatímco při ukládání nebo exportu může být vyvolána [PptxException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxexception/). Zpracujte výjimku na hranici operace a použijte zprávu o varování k určení, zda politiku aplikace způsobila ukončení, místo spoléhání se na jeden podtyp výjimky nebo zprávu. Callback zaznamená varování před vrácením `ReturnAction.Abort`, čímž zajistí, že důvod zůstane aplikaci dostupný.

## **Kategorie varování**

Výčtová položka [WarningType](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/warningtype/) poskytuje následující kategorie:

| Typ varování | Význam | Typická politika |
| --- | --- | --- |
| `SourceFileCorruption` | Zdrojová prezentace obsahuje poškození, které může způsobit, že dokument uložený v původním formátu bude nepoužitelný. | Přerušit. |
| `DataLoss` | Po načtení nebo uložení může chybět text, grafy, obrázky nebo jiná data. | Přerušit. |
| `MajorFormattingLoss` | Prezentace může ztratit důležité formátování. | Přerušit ve přísném validačním režimu; jinak zaznamenat a pokračovat. |
| `MinorFormattingLoss` | Může nastat omezený rozdíl ve formátování. | Zaznamenat pro diagnostiku a pokračovat. |
| `CompatibilityIssue` | Výsledek se nemusí otevřít nebo fungovat správně v některých aplikacích nebo starších verzích. | Zaznamenat a pokračovat, pokud kompatibilita není povinná. |
| `UnexpectedContent` | Zdroj obsahuje nepodporovaný nebo nerozpoznaný obsah, jehož dopad ještě není znám. | Zaznamenat a pokračovat, nebo v přísné politice považovat za chybu. |

Kategorie by měla řídit rozhodnutí o politice. Uložte `Description` pro diagnostiku, ale nespoléhejte se na její znění pro logiku aplikace, protože text zprávy se může lišit mezi scénáři varování a verzemi produktu.

## **Shromažďování a klasifikace varování**

Následující příklad používá jednu zprávu na úrovni aplikace pro celý zpracovatelský řetězec. Samostatná instance callbacku označuje varování z načítání, vykreslování, konverze do PDF a ukládání do PPTX. Politika přeruší při poškození zdroje nebo ztrátě dat, volitelně přeruší při velké ztrátě formátování a pro ostatní varování pokračuje.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Nastavte `abortOnMajorFormattingLoss` na `false`, pokud jsou velké rozdíly ve formátování přijatelné. Problémy s kompatibilitou, drobná ztráta formátování a neočekávaný obsah jsou i nadále zahrnuty ve zprávě, i když operace pokračuje. Rozšiřte `WarningPolicy.GetAction`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře varování**

Varování se mohou objevit v různých fázích pracovního postupu:

- **Digitální podpisy:** Podepsaná prezentace může během načítání vyvolat varování, že její podpis bude během zpracování ztracen. Aspose.Slides hlásí tento stav `DataLoss` prostřednictvím [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Callback ve fázi načítání umožňuje aplikaci soubor odmítnout nebo explicitně přijmout hlášenou ztrátu.
- **Náhrada písma:** Nedostupné písmo může být nahrazeno během vykreslování nebo exportu snímku. Varování o náhradě písma jsou hlášena jako `DataLoss`, takže přísná politika výše přeruší operaci, i když by aplikace považovala konkrétní náhradu za vizuálně přijatelnou. Pro pozorování tohoto chování použijte vstupní prezentaci obsahující text v písmu, které není k dispozici běhovému prostředí. Popis varování identifikuje náhradu; nakonfigurujte požadovaná písma nebo [font substitution rules](/slides/cs/net/font-substitution/) před opětovným pokusem.
- **Nepodporovaný nebo neočekávaný obsah:** Načítací komponenta může narazit na záznamy nebo funkce prezentace, které nepozná. Taková varování mohou používat `UnexpectedContent`, nebo závažnější kategorii, pokud jsou data nebo formátování známé jako postižené.
- **Kompatibilita formátu:** Ukládání do jiného formátu prezentace může vynechat některé funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například uložení prezentace s více než osmi vodorovnými nebo osmi svislými vodícími čarami do staršího formátu PPT hlásí `CompatibilityIssue`. Callback ve fázi ukládání může zaznamenat ztrátu a pokračovat, nebo ji odmítnout, pokud je vyžadováno zachování všech vodících čar.
- **Chování při načítání:** Možnosti načítání a starší chování mohou také vyvolávat varování. Například [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifikuje použití zastaralého chování uzamykání prezentace jako `CompatibilityIssue`.

Varování závisí na zdrojovém dokumentu, cílovém formátu, operaci a verzi Aspose.Slides. Nepředpokládejte, že každý soubor vytvoří varování nebo že scénář vždy spadá do jediné kategorie.

## **Bezpečné zacházení s přerušenými operacemi**

Když callback vrátí `ReturnAction.Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup z vykreslování nebo ukládání je kompletní. Operace může být ukončena po vytvoření výstupního souboru, ale před jeho dokončením.

Uložte ověřené výsledky do samostatné cesty, např. `validated-output.pptx`. Existující prezentaci přepište až poté, co operace úspěšně skončí, zpráva o varování splní politiku aplikace a výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru částečným nebo odmítnutým výsledkem.

Prázdná zpráva o varování není zárukou, že všechny zdrojové funkce byly zachovány. Proveďte jakékoliv další kontrolní a vizuální testy požadované aplikací. Viz také [Open Presentations](/slides/cs/net/open-presentation/) a [Save Presentations](/slides/cs/net/save-presentation/).

## **Často kladené otázky**

**Může callback varování zvládnout každou chybu Aspose.Slides?**

Ne. Zpracovává obnovitelné podmínky hlášené jako varování. Výjimky, které nastanou nezávisle na callbacku, musí být řešeny aplikací kolem volání načtení, vykreslování, konverze nebo ukládání.

**Zaručuje vrácení `ReturnAction.Continue` identický výstup?**

Ne. Pouze umožňuje pokračovat ve zpracování. Nahlášený stav může stále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto je nutné přezkoumat shromážděné typy varování a jejich popisy.

**Jak může aplikace identifikovat operaci, která vyprodukovala varování?**

Vytvořte pro každou operaci samostatnou instanci callbacku a uložte aplikací definované stadium spolu s `WarningType` a `Description`, jak je ukázáno v příkladu.