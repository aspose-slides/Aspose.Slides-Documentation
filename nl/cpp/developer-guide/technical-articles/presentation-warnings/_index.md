---
title: Presentatiewaarschuwingen afhandelen in C++
type: docs
weight: 70
url: /nl/cpp/presentation-warnings/
aliases:
- /cpp/waarschuwingen-ophalen-callbacks-voor-lettertypevervanging-in-aspose-slides/
keywords:
- waarschuwingscallback
- waarschuwingsbeleid
- gegevensverlies
- broncorruptie
- compatibiliteitsprobleem
- lettertypevervanging
- digitale handtekening
- presentatie laden
- presentatie renderen
- presentatie conversie
- presentatie opslaan
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, classificeren en afhandelen tijdens het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides kan herstelbare problemen melden tijdens het laden, renderen, converteren of opslaan van een presentatie. Voorbeelden zijn beschadigde bronrecords, inhoud die niet bewaard kan blijven, lettertypevervanging en beperkingen van een doelindeling. Een waarschuwingscallback stelt een applicatie in staat deze condities te registreren en te bepalen of de huidige bewerking kan doorgaan.

Implementeer de [IWarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/iwarningcallback/) interface en bekijk de [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) en [IWarningInfo::get_Description](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/iwarninginfo/get_description/) methoden die via [IWarningInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/iwarninginfo/) worden geleverd. Retourneer [ReturnAction::Continue](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/returnaction/) om de waarschuwing te accepteren of `ReturnAction::Abort` om de bewerking te stoppen.

Gebruik [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_warningcallback/) voor waarschuwingen die worden gegenereerd bij het openen van een presentatie. Render- en exportoptieklassen erven [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_warningcallback/), die waarschuwingen ontvangt van slide-rendering, conversie en opslaan. Omdat de waarschuwing zelf de applicatie‑bewerking niet identificeert, koppel je elke callback‑instantie aan een bewerkingsfase wanneer je een gecombineerd rapport opstelt.

## **Waarschuwingen en uitzonderingen**

Een waarschuwing beschrijft een toestand waarvan Aspose.Slides kan herstellen als de callback `ReturnAction::Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet worden afgehandeld door een waarschuwingsbeleid.

Het teruggeven van `ReturnAction::Abort` vraagt de waarschuwingsdispatcher de huidige bewerking te beëindigen door een uitzondering op te werpen. De openbare uitzondering hangt af van de bewerking en het presentatiesformaat. Bijvoorbeeld, bij laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxreadexception/) of [PptReadException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptreadexception/) optreden, terwijl bij opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxexception/) kan optreden. Handel de uitzondering af aan de grens van de bewerking en gebruik het waarschuwingsrapport om te bepalen of het applicatiebeleid de beëindiging heeft veroorzaakt in plaats van te vertrouwen op één exceptietype of bericht. De callback registreert de waarschuwing voordat `ReturnAction::Abort` wordt geretourneerd, zodat de reden beschikbaar blijft voor de applicatie.

## **Waarschuwingscategorieën**

De enumeratie [WarningType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/warningtype/) biedt de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| `SourceFileCorruption` | De bronpresentatie bevat corruptie die een document dat in het oorspronkelijke formaat is opgeslagen onbruikbaar kan maken. | Afbreken. |
| `DataLoss` | Tekst, diagrammen, afbeeldingen of andere gegevens kunnen ontbreken na het laden of opslaan. | Afbreken. |
| `MajorFormattingLoss` | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders registreren en doorgaan. |
| `MinorFormattingLoss` | Er kan een beperkte opmaakverschil optreden. | Registreren voor diagnostiek en doorgaan. |
| `CompatibilityIssue` | Het resultaat opent mogelijk niet of gedraagt zich niet correct in sommige applicaties of oudere versies. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| `UnexpectedContent` | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan het effect nog onbekend kan zijn. | Registreren en doorgaan, of behandelen als fout in een strikt beleid. |

De categorie moet de beleidsbeslissing bepalen. Sla de waarschuwingsbeschrijving op voor diagnostiek, maar baseer de applicatielogica niet op de bewoording ervan, omdat de berichttekst kan variëren tussen waarschuwingsscenario's en productversies.

## **Verzamel en classificeer waarschuwingen**

Het volgende voorbeeld gebruikt één applicatieniveau‑rapport voor de volledige verwerkings‑pipeline. Een afzonderlijke callback‑instantie labelt waarschuwingen van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid stopt bij broncorruptie of gegevensverlies, stopt eventueel bij groot formatteringsverlies, en gaat door bij andere waarschuwingen.

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

Stel `abortOnMajorFormattingLoss` in op `false` wanneer grote formatteringsverschillen acceptabel zijn. Compatibiliteitsproblemen, klein formatteringsverlies en onverwachte inhoud blijven behouden in het rapport, zelfs wanneer de bewerking doorgaat. Breid `WarningPolicy::GetAction` uit als de applicatie een van die categorieën moet afwijzen.

## **Veelvoorkomende waarschuwingsscenario's**

Waarschuwingen kunnen verschijnen in verschillende stadia van een workflow:

- **Digitale handtekeningen:** Een ondertekende presentatie kan tijdens het laden een waarschuwing geven dat de handtekening tijdens de verwerking verloren gaat. Aspose.Slides rapporteert deze `DataLoss`‑conditie via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Een callback in de laadfase laat de applicatie het bestand afwijzen of het gemelde verlies expliciet accepteren.
- **Lettertype‑vervanging:** Een niet‑beschikbaar lettertype kan worden vervangen terwijl een slide wordt gerenderd of geëxporteerd. Lettertype‑vervangingswaarschuwingen worden gerapporteerd als `DataLoss`, dus het bovenstaande strikte beleid stopt zelfs als de applicatie een bepaalde vervanging visueel acceptabel zou vinden. Om dit gedrag te observeren, gebruik een invoerpresentatie met tekst in een lettertype dat niet beschikbaar is voor de runtime. De waarschuwingsbeschrijving identificeert de vervanging; configureer de vereiste lettertypen of [font substitution rules](/slides/nl/cpp/font-substitution/) voordat u het opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatierecords of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer gegevens of opmaak bekend is aangetast.
- **Formaat‑compatibiliteit:** Opslaan naar een ander presentatiefomaat kan functies weglaten of een resultaat opleveren dat zich anders gedraagt in sommige applicaties. Bijvoorbeeld, het opslaan van een presentatie met meer dan acht horizontale of acht verticale tekenen‑hulp‑lijnen naar legacy PPT rapporteert een `CompatibilityIssue`. De callback in de opslaan‑fase kan het verlies registreren en doorgaan, of het afwijzen als het behouden van alle hulplijnen vereist is.
- **Laadgedrag:** Laadopties en legacy‑gedragingen kunnen ook waarschuwingen genereren. Bijvoorbeeld, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identificeert het gebruik van een verouderde presentatie‑vergrendelingsgedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het bron‑document, het doel‑formaat, de bewerking en de versie van Aspose.Slides. Ga niet ervan uit dat elk bestand een waarschuwing oplevert of dat een scenario altijd aan slechts één categorie is gekoppeld.

## **Behandel afgebroken bewerkingen veilig**

Wanneer een callback `ReturnAction::Abort` retourneert, gebruik dan geen object dat niet kon worden geladen en ga niet ervan uit dat een render‑ of opslaoutput compleet is. De bewerking kan beëindigen nadat een uitvoerbestand is aangemaakt, maar voordat het voltooid is.

Sla gevalideerde resultaten op naar een apart pad, zoals `validated-output.pptx`. Vervang een bestaande presentatie alleen nadat de bewerking succesvol is voltooid, het waarschuwingsrapport aan het toepassingsbeleid voldoet, en de uitvoer geopend en gecontroleerd kan worden. Dit voorkomt het overschrijven van een geldig bronbestand met een gedeeltelijk of afgewezen resultaat.

Een leeg waarschuwingsrapport garandeert niet dat elke bron‑functie behouden is gebleven. Pas eventuele extra inhoud‑ en visuele controles toe die de applicatie vereist. Zie ook [Open Presentations](/slides/nl/cpp/open-presentation/) en [Save Presentations](/slides/nl/cpp/save-presentation/).

## **FAQ**

**Kan een waarschuwingscallback elke Aspose.Slides‑fout afhandelen?**

Nee. Het behandelt alleen herstelbare omstandigheden die als waarschuwingen worden gerapporteerd. Uitzonderingen die onafhankelijk van de callback optreden, moeten door de applicatie worden afgehandeld rond de laad‑, render‑, conversie‑ of opsla‑aanroep.

**Garandeert het retourneren van `ReturnAction::Continue` een identieke output?**

Nee. Het staat alleen toe dat de verwerking wordt voortgezet. De gerapporteerde toestand kan nog steeds leiden tot verschillen in gegevens, opmaak of compatibiliteit, dus controleer de verzamelde waarschuwings‑typen en -beschrijvingen.

**Hoe kan een applicatie de bewerking identificeren die een waarschuwing heeft veroorzaakt?**

Maak voor elke bewerking een callback‑instantie aan en sla een door de applicatie gedefinieerde fase op samen met het waarschuwings‑type en de beschrijving, zoals getoond in het voorbeeld.