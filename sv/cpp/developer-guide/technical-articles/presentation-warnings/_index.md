---
title: Hantera presentationsvarningar i C++
type: docs
weight: 70
url: /sv/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteruppringning
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- teckensnittsersättning
- digital signatur
- presentationladdning
- presentation renderning
- presentation konvertering
- presentation sparning
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Lär dig hur du samlar in, klassificerar och hanterar varningar när du läser in, renderar, konverterar och sparar presentationer med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides kan rapportera återhämtningsbara problem när den läser in, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposter, innehåll som inte kan bevaras, teckensnittsersättning och begränsningar i ett målformat. En varningsåteruppringning låter en applikation registrera dessa förhållanden och bestämma om den aktuella operationen kan fortsätta.

Implementera gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/iwarningcallback/) och granska metoderna [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) och [IWarningInfo::get_Description](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/iwarninginfo/get_description/) som tillhandahålls via [IWarningInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/iwarninginfo/). Returnera [ReturnAction::Continue](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/returnaction/) för att acceptera varningen eller `ReturnAction::Abort` för att stoppa operationen.

Använd [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_warningcallback/) för varningar som uppstår när en presentation öppnas. Renderings- och exportalternativklasser ärver [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_warningcallback/), som tar emot varningar från bildrendering, konvertering och sparning. Eftersom själva varningen inte identifierar applikationsoperationen, associera varje återuppringningsinstans med ett operationsstadium när du bygger en samlad rapport.

## **Varningar och Undantag**

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om återuppringningen returnerar `ReturnAction::Continue`. Ett undantag betyder att den begärda operationen inte kan slutföras normalt; undantag omvandlas inte till varningar och kan inte hanteras av en varningspolicy.

Att returnera `ReturnAction::Abort` ber varningsdistributören avsluta den aktuella operationen genom att kasta ett undantag. Det publika undantaget beror på operationen och presentationsformatet. Till exempel kan inläsning ge ett [PptxReadException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptreadexception/), medan sparning eller export kan ge ett [PptxException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxexception/). Hantera undantaget vid operationens gränssnitt och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avslutandet i stället för att förlita sig på en undantagstyp eller meddelande. Återuppringningen registrerar varningen innan den returnerar `ReturnAction::Abort`, vilket säkerställer att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

Enumeration [WarningType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/warningtype/) tillhandahåller följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| `SourceFileCorruption` | Källpresentationen innehåller korruption som kan göra ett dokument sparat i sitt ursprungliga format oanvändbart. | Avbryt. |
| `DataLoss` | Text, diagram, bilder eller annan data kan saknas efter inläsning eller sparning. | Avbryt. |
| `MajorFormattingLoss` | Presentation kan förlora viktig formatering. | Avbryt i strikt valideringsläge; annars registrera och fortsätt. |
| `MinorFormattingLoss` | En begränsad formateringsskillnad kan uppstå. | Registrera för diagnostik och fortsätt. |
| `CompatibilityIssue` | Resultatet kanske inte öppnas eller fungerar korrekt i vissa applikationer eller äldre versioner. | Logga och fortsätt om inte kompatibilitet är obligatorisk. |
| `UnexpectedContent` | Källan innehåller ej stödd eller okänd innehåll vars effekt kanske ännu inte är känd. | Registrera och fortsätt, eller behandla som fel i en strikt policy. |

Kategorin bör styra policybeslutet. Spara varningsbeskrivningen för diagnostik, men lita inte på dess formulering för applikationslogik eftersom meddelandetexten kan variera mellan varningsscenarier och produktversioner.

## **Samla och klassificera varningar**

Följande exempel använder en applikationsnivårapport för hela bearbetningskedjan. En separat återuppringningsinstans märker varningar från inläsning, rendering, PDF-konvertering och PPTX-sparning. Policyn avbryter vid källkorruption eller dataförlust, avbryter eventuellt vid stor formateringsförlust och fortsätter för andra varningar.

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

Sätt `abortOnMajorFormattingLoss` till `false` när stora formateringsskillnader är acceptabla. Kompatibilitetsproblem, små formateringsförluster och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy::GetAction` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga varningsscenarier**

- **Digitala signaturer:** En signerad presentation kan ge en varning under inläsning att dess signatur kommer att gå förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`-tillstånd via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). En återuppringning i inläsningsstadiet låter applikationen avvisa filen eller uttryckligen acceptera den rapporterade förlusten.
- **Teckensnittsersättning:** Ett otillgängligt teckensnitt kan ersättas medan en bild renderas eller exporteras. Varningar om teckensnittsersättning rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle anse en viss ersättning visuellt acceptabel. För att observera detta beteende, använd en inmatningspresentation som innehåller text i ett teckensnitt som inte är tillgängligt för runtime. Varningsbeskrivningen identifierar ersättningen; konfigurera de erforderliga teckensnitten eller [teckensnittsersättningsregler](/slides/sv/cpp/font-substitution/) innan du försöker igen.
- **Ej stödligt eller oväntat innehåll:** En laddare kan stöta på presentationsposter eller funktioner den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en mer allvarlig kategori när data eller formatering är kända att påverkas.
- **Formatkompatibilitet:** Sparning till ett annat presentationsformat kan utelämna funktioner eller skapa ett resultat som beter sig annorlunda i vissa applikationer. Till exempel rapporterar sparning av en presentation med mer än åtta horisontella eller åtta vertikala ritguider till äldre PPT en `CompatibilityIssue`. Återuppringning i sparningsstadiet kan registrera förlusten och fortsätta, eller avvisa den om bevarande av alla guider krävs.
- **Inläsningsbeteende:** Inläsningsalternativ och äldre beteenden kan också ge varningar. Till exempel identifierar [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) användning av ett föråldrat presentationslåsningsbeteende som en `CompatibilityIssue`.

Varningar beror på källdokumentet, målformatet, operationen och Aspose.Slides-versionen. Anta inte att varje fil producerar en varning eller att ett scenario alltid motsvarar endast en kategori.

## **Hantera avbrutna operationer på ett säkert sätt**

När en återuppringning returnerar `ReturnAction::Abort`, använd inte ett objekt som misslyckades att laddas och anta inte att en renderings- eller sparutdata är komplett. Operationen kan avslutas efter att en utdatafil skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, t.ex. `validated-output.pptx`. Ersätt en befintlig presentation först efter att operationen avslutats framgångsrikt, varningsrapporten uppfyller applikationspolicyn och utdata kan öppnas och kontrolleras. Detta undviker att skriva över en giltig källfil med ett partiellt eller avvisat resultat.

En tom varningsrapport är ingen garanti för att varje källfunktion har bevarats. Tillämpa eventuella ytterligare innehålls- och visuella kontroller som krävs av applikationen. Se också [Öppna presentationer](/slides/sv/cpp/open-presentation/) och [Spara presentationer](/slides/sv/cpp/save-presentation/).

## **FAQ**

**Kan en varningsåteruppringning hantera varje Aspose.Slides-fel?**

Nej. Den hanterar återhämtningsbara tillstånd som rapporteras som varningar. Undantag som uppstår oberoende av återuppringningen måste hanteras av applikationen runt inläsnings-, renderings-, konverterings- eller sparningsanropet.

**Garanterar returnering av `ReturnAction::Continue` identisk utdata?**

Nej. Den tillåter bara att bearbetningen fortsätter. Det rapporterade tillståndet kan fortfarande orsaka data-, formaterings- eller kompatibilitetsskillnader, så granska de insamlade varningstyperna och beskrivningarna.

**Hur kan en applikation identifiera den operation som producerade en varning?**

Skapa en återuppringningsinstans för varje operation och lagra ett applikationsdefinierat stadium tillsammans med varningstypen och beskrivningen, som visas i exemplet.