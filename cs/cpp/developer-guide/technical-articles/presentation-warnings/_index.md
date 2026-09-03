---
title: Zpracování výstrah prezentace v C++
type: docs
weight: 70
url: /cs/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback výstrah
- politika výstrah
- ztráta dat
- poškození zdroje
- problém kompatibility
- substituce písma
- digitální podpis
- načítání prezentace
- renderování prezentace
- konverze prezentace
- ukládání prezentace
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Naučte se, jak sbírat, klasifikovat a reagovat na výstrahy během načítání, renderování, konverze a ukládání prezentací pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides může hlásit obnovitelné problémy během načítání, renderování, konverze nebo ukládání prezentace. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, substituci písem a omezení cílového formátu. Výstražná zpětná volání (callback) umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může současná operace pokračovat.

Implementujte rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/iwarningcallback/) a prozkoumejte metody [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) a [IWarningInfo::get_Description](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/iwarninginfo/get_description/) poskytované prostřednictvím [IWarningInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/iwarninginfo/). Vraťte [ReturnAction::Continue](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/returnaction/) pro přijetí výstrahy nebo `ReturnAction::Abort` pro zastavení operace.

Použijte [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_warningcallback/) pro výstrahy vyvolané během otevírání prezentace. Třídy možností renderování a exportu dědí [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_warningcallback/), který přijímá výstrahy z renderování snímků, konverze a ukládání. Protože samotná výstraha neidentifikuje aplikaci operaci, při vytváření kombinované zprávy přiřaďte každou instanci zpětné volání ke konkrétnímu stadiu operace.

## **Výstrahy a výjimky**

Výstraha popisuje stav, ze kterého se Aspose.Slides může zotavit, pokud zpětná volání vrátí `ReturnAction::Continue`. Výjimka znamená, že požadovaná operace nemůže být dokončena normálně; výjimky nejsou převedeny na výstrahy a nemohou být zpracovány politikou výstrah.

Vrácení `ReturnAction::Abort` žádá dispečera výstrah, aby ukončil aktuální operaci vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například načítání může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptreadexception/), zatímco ukládání nebo export může vyvolat [PptxException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxexception/). Zpracujte výjimku na hranici operace a použijte zprávu o výstrahách k určení, zda ukončení způsobila politika aplikace namísto spolehání se na jeden typ výjimky nebo zprávu. Zpětná volání zaznamená výstrahu před vrácením `ReturnAction::Abort`, čímž zajistí, že důvod zůstane aplikaci dostupný.

## **Kategorie výstrah**

Výčtová hodnota [WarningType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/warningtype/) poskytuje následující kategorie:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| `SourceFileCorruption` | Zdrojová prezentace obsahuje poškození, které může způsobit, že dokument uložený v původním formátu bude nepoužitelný. | Abort. |
| `DataLoss` | Text, grafy, obrázky nebo jiné údaje mohou po načtení nebo uložení chybět. | Abort. |
| `MajorFormattingLoss` | Prezentace může ztratit důležité formátování. | Abort in strict validation mode; otherwise record and continue. |
| `MinorFormattingLoss` | Může dojít k omezenému rozdílu ve formátování. | Record for diagnostics and continue. |
| `CompatibilityIssue` | Výsledek se nemusí otevřít nebo chovat správně v některých aplikacích nebo starších verzích. | Log and continue unless compatibility is mandatory. |
| `UnexpectedContent` | Zdroj obsahuje nepodporovaný nebo neznámý obsah, jehož dopad ještě není znám. | Record and continue, or treat as an error in a strict policy. |

Kategorie by měla řídit rozhodnutí o politice. Uložte popis výstrahy pro diagnostiku, ale nespoléhejte se na jeho znění v aplikační logice, protože text zprávy se může lišit mezi různými scénáři výstrah a verzemi produktu.

## **Sbírejte a klasifikujte výstrahy**

Následující příklad používá jeden aplikační report pro celý zpracovatelský řetězec. Samostatná instance zpětné volání označuje výstrahy z načítání, renderování, konverze do PDF a ukládání PPTX. Politika ukončuje operaci při poškození zdroje nebo ztrátě dat, volitelně ukončuje při velké ztrátě formátování a u ostatních výstrah pokračuje.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Nastavte `abortOnMajorFormattingLoss` na `false`, pokud jsou velké rozdíly ve formátování přijatelné. Problémy s kompatibilitou, malé ztráty formátování a neočekávaný obsah jsou i nadále zahrnuty v reportu, i když operace pokračuje. Rozšiřte `WarningPolicy::GetAction`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře výstrah**

Výstrahy se mohou objevit v různých fázích pracovního postupu:

- **Digitální podpisy:** Podepsaná prezentace může během načítání vyvolat výstrahu, že její podpis bude během zpracování ztracen. Aspose.Slides hlásí tento stav `DataLoss` prostřednictvím [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Zpětná volání ve fázi načítání umožňuje aplikaci soubor odmítnout nebo explicitně přijmout hlášenou ztrátu.
- **Substituce písma:** Nedostupné písmo může být nahrazeno během renderování nebo exportu snímku. Výstrahy o substituci písma jsou hlášeny jako `DataLoss`, takže přísná politika výše ukončí i když by aplikace považovala konkrétní náhradu za vizuálně přijatelnou. Pro pozorování tohoto chování použijte vstupní prezentaci obsahující text v písmu, které není k dispozici běhovému prostředí. Popis výstrahy identifikuje substituci; nakonfigurujte požadovaná písma nebo [font substitution rules](/slides/cs/cpp/font-substitution/) před opětovným pokusem.
- **Nevyžádaný nebo neočekávaný obsah:** Načítač může narazit na záznamy prezentace nebo funkce, které nepozná. Takové výstrahy mohou použít `UnexpectedContent`, nebo závažnější kategorii, pokud jsou data nebo formátování známé, že jsou ovlivněny.
- **Kompatibilita formátu:** Ukládání do jiného formátu prezentace může vynechat funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například ukládání prezentace s více než osmi horizontálními nebo osmi vertikálními vodicími čarami do staršího PPT hlásí `CompatibilityIssue`. Zpětná volání ve fázi ukládání může zaznamenat ztrátu a pokračovat, nebo ji odmítnout, pokud je vyžadováno zachovat všechny vodicí čáry.
- **Chování načítání:** Možnosti načítání a starší chování mohou také generovat výstrahy. Například [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifikuje použití zastaralého chování zamykání prezentace jako `CompatibilityIssue`.

Výstrahy závisí na zdrojovém dokumentu, cílovém formátu, operaci a verzi Aspose.Slides. Nepředpokládejte, že každý soubor vygeneruje výstrahu nebo že scénář vždy odpovídá pouze jedné kategorii.

## **Bezpečné zacházení s přerušenými operacemi**

Když zpětná volání vrátí `ReturnAction::Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup renderování nebo uložení je kompletní. Operace může skončit po vytvoření výstupního souboru, ale před jeho dokončením.

Uložte ověřené výsledky do samostatné cesty, například `validated-output.pptx`. Přepište existující prezentaci až po úspěšném dokončení operace, pokud zpráva o výstrahách splňuje politiku aplikace a výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru částečným nebo odmítnutým výsledkem.

Prázdná zpráva o výstrahách není zárukou, že všechny zdrojové funkce byly zachovány. Proveďte jakékoli další obsahové a vizuální kontroly požadované aplikací. Viz také [Open Presentations](/slides/cs/cpp/open-presentation/) a [Save Presentations](/slides/cs/cpp/save-presentation/).

## **Často kladené otázky**

**Může výstražná zpětná volání (callback) zvládnout každou chybu Aspose.Slides?**

Ne. Zpracovává jen obnovitelné podmínky hlášené jako výstrahy. Výjimky, které nastanou nezávisle na zpětné volání, musíte ošetřit v aplikaci okolo volání načítání, renderování, konverze nebo ukládání.

**Zaručuje vrácení `ReturnAction::Continue` identický výstup?**

Ne. Pouze povoluje pokračovat ve zpracování. Nahlášený stav může stále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto je nutné přezkoumat shromážděné typy a popisy výstrah.

**Jak může aplikace identifikovat operaci, která vyprodukovala výstrahu?**

Vytvořte samostatnou instanci zpětné volání pro každou operaci a uložte aplikací definované stadium spolu s typem výstrahy a popisem, jak ukazuje příklad.