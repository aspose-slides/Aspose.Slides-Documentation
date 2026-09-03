---
title: Beheer presentatiewaarschuwingen in .NET
type: docs
weight: 120
url: /nl/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwingscallback
- waarschuwingsbeleid
- gegevensverlies
- broncorruptie
- compatibiliteitsprobleem
- lettertypevervanging
- digitale handtekening
- presentatieladen
- presentatie-renderen
- presentatieconversie
- presentatieopslaan
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, classificeren en erop kunt reageren tijdens het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides kan herstellende problemen melden tijdens het laden, renderen, converteren of opslaan van een presentatie. Voorbeelden zijn beschadigde bronrecords, inhoud die niet bewaard kan worden, lettertypevervanging en beperkingen van een doelindeling. Een waarschuwingscallback laat een applicatie deze omstandigheden registreren en beslissen of de huidige bewerking kan worden voortgezet.

Implementeer de [IWarningCallback](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/iwarningcallback/)‑interface en bekijk de [WarningType](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/iwarninginfo/warningtype/)‑ en [Description](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/iwarninginfo/description/)‑eigenschappen die via [IWarningInfo](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/iwarninginfo/) worden geleverd. Retourneer [ReturnAction.Continue](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/returnaction/) om de waarschuwing te accepteren of `ReturnAction.Abort` om de bewerking te stoppen.

Gebruik [LoadOptions.WarningCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/warningcallback/) voor waarschuwingen die optreden tijdens het openen van een presentatie. Rendering‑ en export‑optieklassen erven van [SaveOptions.WarningCallback](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/warningcallback/), die waarschuwingen ontvangt van slide‑rendering, conversie en opslaan. Omdat de waarschuwing zelf de applicatie‑bewerking niet identificeert, koppel je elke callback‑instantie aan een bewerkingsfase wanneer je een gecombineerd rapport opbouwt.

## **Waarschuwingen en uitzonderingen**

Een waarschuwing beschrijft een toestand waarvan Aspose.Slides kan herstellen indien de callback `ReturnAction.Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet door een waarschuwingsbeleid worden afgehandeld.

Het retourneren van `ReturnAction.Abort` vraagt de waarschuwingsdispatcher de huidige bewerking te beëindigen door een uitzondering te genereren. De publieke uitzondering hangt af van de bewerking en het presentatieformaat. Bijvoorbeeld, bij het laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxreadexception/) of [PptReadException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptreadexception/) optreden, terwijl bij opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxexception/) kan optreden. Handel de uitzondering af aan de grens van de bewerking en gebruik het waarschuwingsrapport om te bepalen of het applicatie‑beleid de beëindiging heeft veroorzaakt in plaats van te vertrouwen op één subtype of bericht. De callback registreert de waarschuwing vóór het retourneren van `ReturnAction.Abort`, zodat de reden beschikbaar blijft voor de applicatie.

## **Waarschuwingscategorieën**

De [WarningType](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/warningtype/)‑enumeratie biedt de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| `SourceFileCorruption` | De bronpresentatie bevat corruptie die ervoor kan zorgen dat een document dat in het oorspronkelijke formaat wordt opgeslagen onbruikbaar is. | Afbreken. |
| `DataLoss` | Tekst, grafieken, afbeeldingen of andere gegevens kunnen ontbreken na het laden of opslaan. | Afbreken. |
| `MajorFormattingLoss` | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders registreren en doorgaan. |
| `MinorFormattingLoss` | Er kan een beperkte opmaakverschil optreden. | Registreren voor diagnostiek en doorgaan. |
| `CompatibilityIssue` | Het resultaat kan mogelijk niet openen of correct functioneren in sommige applicaties of oudere versies. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| `UnexpectedContent` | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan het effect nog onbekend kan zijn. | Registreren en doorgaan, of behandelen als een fout in een strikte policy. |

De categorie moet de beleidsbeslissing sturen. Sla `Description` op voor diagnostische doeleinden, maar baseer applicatielogica niet op de exacte formulering omdat de berichttekst kan variëren tussen waarschuwingsscenario’s en productversies.

## **Verzamel en classificeer waarschuwingen**

Het onderstaande voorbeeld gebruikt één applicatieniveau‑rapport voor de volledige verwerkingspijplijn. Een aparte callback‑instantie labelt waarschuwingen afkomstig van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid stopt bij broncorruptie of gegevensverlies, stopt optioneel bij groot opmaakverlies en gaat door bij overige waarschuwingen.

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

Stel `abortOnMajorFormattingLoss` in op `false` wanneer grote opmaakverschillen acceptabel zijn. Compatibiliteitsproblemen, klein opmaakverlies en onverwachte inhoud blijven toch in het rapport behouden, zelfs wanneer de bewerking wordt voortgezet. Breid `WarningPolicy.GetAction` uit als de applicatie een van die categorieën moet afwijzen.

## **Algemene waarschuwingsscenario's**

Waarschuwingen kunnen op verschillende momenten in een workflow optreden:

- **Digitale handtekeningen:** Een ondertekende presentatie kan een waarschuwing genereren tijdens het laden dat de handtekening verloren gaat tijdens de verwerking. Aspose.Slides rapporteert deze `DataLoss`‑toestand via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Een callback in de laadfase laat de applicatie het bestand afwijzen of de gemelde verlies expliciet accepteren.
- **Lettertypevervanging:** Een niet‑beschikbaar lettertype kan worden vervangen terwijl een slide wordt gerenderd of geëxporteerd. Lettertypevervangingswaarschuwingen worden gerapporteerd als `DataLoss`, zodat het strikte beleid hierboven zelfs afbreekt wanneer de applicatie een bepaalde vervanging visueel acceptabel zou vinden. Om dit gedrag te observeren, gebruik een invoerpresentatie met tekst in een lettertype dat niet beschikbaar is voor de runtime. De waarschuwingsbeschrijving identificeert de vervanging; configureer de vereiste lettertypen of [lettertypevervangingsregels](/slides/nl/net/font-substitution/) voordat je het opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatierecords of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer gegevens of opmaak bekend is aangetast.
- **Formaatcompatibiliteit:** Opslaan naar een ander presentatieformaat kan kenmerken weglaten of een resultaat opleveren dat zich anders gedraagt in sommige applicaties. Bijvoorbeeld, het opslaan van een presentatie met meer dan acht horizontale of acht verticale tekengidsen naar legacy PPT rapporteert een `CompatibilityIssue`. De callback in de opslaanfase kan het verlies registreren en doorgaan, of het afwijzen als het behouden van alle gidsen vereist is.
- **Laadgedrag:** Laad‑opties en verouderde gedragingen kunnen eveneens waarschuwingen genereren. Bijvoorbeeld, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identificeert het gebruik van een verouderd presentatie‑vergrendelingsgedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het bron‑document, het doelformaat, de bewerking en de Aspose.Slides‑versie. Ga er niet van uit dat elk bestand een waarschuwing oplevert of dat een scenario altijd in één enkele categorie valt.

## **Afgebroken bewerkingen veilig afhandelen**

Wanneer een callback `ReturnAction.Abort` retourneert, gebruik dan niet een object dat niet geladen kon worden en ga er niet van uit dat een render‑ of opslaan‑output compleet is. De bewerking kan beëindigd worden na het aanmaken van een output‑bestand maar vóór het volledig afronden.

Sla gevalideerde resultaten op naar een apart pad, bijvoorbeeld `validated-output.pptx`. Vervang een bestaande presentatie pas nadat de bewerking succesvol is voltooid, het waarschuwingsrapport voldoet aan het applicatie‑beleid, en de output geopend en gecontroleerd kan worden. Dit voorkomt het overschrijven van een geldig bronbestand met een gedeeltelijk of afgewezen resultaat.

Een leeg waarschuwingsrapport garandeert niet dat elk bronkenmerk behouden is. Voer alle aanvullende inhoud‑ en visuele controles uit die de applicatie vereist. Zie ook [Open Presentations](/slides/nl/net/open-presentation/) en [Save Presentations](/slides/nl/net/save-presentation/).

## **FAQ**

**Kan een waarschuwingscallback elke Aspose.Slides‑fout afhandelen?**

Nee. Hij behandelt alleen herstellende toestanden die als waarschuwingen worden gerapporteerd. Uitzonderingen die onafhankelijk van de callback optreden, moeten door de applicatie rond de laaddienst, render‑, conversie‑ of opslaan‑aanroep worden afgehandeld.

**Garandeert het retourneren van `ReturnAction.Continue` identieke output?**

Nee. Het staat alleen toe dat de verwerking doorgaat. De gerapporteerde toestand kan nog steeds leiden tot verschillen in data, opmaak of compatibiliteit, dus controleer de verzamelde waarschuwings‑typen en beschrijvingen.

**Hoe kan een applicatie de bewerking identificeren die een waarschuwing heeft geproduceerd?**

Maak voor elke bewerking een eigen callback‑instantie aan en bewaar een door de applicatie gedefinieerde fase samen met `WarningType` en `Description`, zoals getoond in het voorbeeld.