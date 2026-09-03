---
title: Hantera presentationsvarningar i .NET
type: docs
weight: 120
url: /sv/net/presentation-warnings/
aliases:
- /net/hamta-varningsåteruppringningar-för-typsnitt-substitution-i-aspose-slides/
keywords:
- varningsåteruppringning
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- typsnittssubstitution
- digital signatur
- presentationsladdning
- presentationsrendering
- presentationskonvertering
- presentationssparning
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du samlar, klassificerar och hanterar varningar när du laddar, renderar, konverterar och sparar presentationer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides kan rapportera återhämtningsbara problem medan den laddar, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposteringar, innehåll som inte kan bevaras, typsnittsbyte och begränsningar i ett målformat. En varningsåteruppringning låter en applikation registrera dessa villkor och avgöra om den aktuella operationen kan fortsätta.

Implementera [IWarningCallback](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/iwarningcallback/) gränssnittet och granska [WarningType](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/iwarninginfo/warningtype/) och [Description](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/iwarninginfo/description/) egenskaper som levereras via [IWarningInfo](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/iwarninginfo/). Returnera [ReturnAction.Continue](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/returnaction/) för att acceptera varningen eller `ReturnAction.Abort` för att stoppa operationen.

Använd [LoadOptions.WarningCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/warningcallback/) för varningar som uppstår när en presentation öppnas. Renderings- och exportalternativklasser ärver [SaveOptions.WarningCallback](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/warningcallback/), som tar emot varningar från bildrendering, konvertering och sparning. Eftersom varningen själv inte identifierar applikationsoperationen, associera varje återuppringningsinstans med ett operationsstadium när du bygger en kombinerad rapport.

## **Varningar och Undantag**

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om återuppringningen returnerar `ReturnAction.Continue`. Ett undantag betyder att den begärda operationen inte kan slutföras normalt; undantag konverteras inte till varningar och kan inte hanteras av en varningspolicy.

Att returnera `ReturnAction.Abort` ber varningsdispatchern att avsluta den aktuella operationen genom att kasta ett undantag. Det offentliga undantaget beror på operationen och presentationsformatet. Till exempel kan laddning ge ett [PptxReadException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptreadexception/), medan sparning eller export kan ge ett [PptxException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxexception/). Hantera undantaget vid operationens gräns och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avstängningen istället för att förlita sig på en undantagsundertyps eller meddelande. Återuppringningen registrerar varningen innan den returnerar `ReturnAction.Abort`, vilket säkerställer att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

Enumen [WarningType](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/warningtype/) tillhandahåller följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| `SourceFileCorruption` | Källpresentationen innehåller korruption som kan göra ett dokument sparat i sitt ursprungliga format oanvändbart. | Abort. |
| `DataLoss` | Text, diagram, bilder eller annan data kan vara frånvarande efter laddning eller sparning. | Abort. |
| `MajorFormattingLoss` | Presentation kan förlora viktig formatering. | Abort i strikt valideringsläge; annars registrera och fortsätt. |
| `MinorFormattingLoss` | En begränsad formateringsskillnad kan uppstå. | Registrera för diagnostik och fortsätt. |
| `CompatibilityIssue` | Resultatet kanske inte öppnas eller fungerar korrekt i vissa applikationer eller äldre versioner. | Logga och fortsätt om inte kompatibilitet är obligatorisk. |
| `UnexpectedContent` | Källan innehåller icke‑stödd eller oidentifierad innehåll vars effekt ännu kan vara okänd. | Registrera och fortsätt, eller behandla som fel i en strikt policy. |

Kategorin bör styra policybeslutet. Spara `Description` för diagnostik, men förlita dig inte på dess formulering för applikationslogik eftersom meddelandetexten kan variera mellan varningsscenarier och produktversioner.

## **Samla och Klassificera Varningar**

Följande exempel använder en applikationsnivårapport för hela bearbetningskedjan. En separat återuppringningsinstans märker varningar från laddning, rendering, PDF‑konvertering och PPTX‑sparning. Policyn avbryter vid källkorruption eller dataförlust, avbryter eventuellt vid stor formateringsförlust och fortsätter för andra varningar.

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

Sätt `abortOnMajorFormattingLoss` till `false` när stora formateringsskillnader är acceptabla. Kompatibilitetsproblem, mindre formateringsförlust och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy.GetAction` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga Varningsscenario**

Varningar kan uppstå i olika steg av ett arbetsflöde:

- **Digital signaturer:** En signerad presentation kan generera en varning vid laddning att dess signatur kommer att gå förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`‑tillstånd via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). En laddningsstadie‑återuppringning låter applikationen avvisa filen eller explicit acceptera den rapporterade förlusten.
- **Typsnittsbyte:** Ett otillgängligt typsnitt kan ersättas medan en bild renderas eller exporteras. Typsnittsbytesvarningar rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle anse ett visst byte visuellt acceptabelt. För att observera detta beteende, använd en inmatningspresentation som innehåller text i ett typsnitt som inte är tillgängligt för körningen. Varnarens beskrivning identifierar bytet; konfigurera de erforderliga typsnitten eller [typsnittsbytesregler](/slides/sv/net/font-substitution/) innan du försöker igen.
- **Ej stödjt eller oväntat innehåll:** En laddare kan stöta på presentationsposter eller funktioner den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en allvarligare kategori när data eller formatering är kända att vara påverkade.
- **Formatkompatibilitet:** Sparning till ett annat presentationsformat kan utelämna funktioner eller producera ett resultat som beter sig annorlunda i vissa applikationer. Till exempel rapporterar sparning av en presentation med mer än åtta horisontella eller åtta vertikala ritguider till äldre PPT ett `CompatibilityIssue`. Sparningsstadie‑återuppringning kan registrera förlusten och fortsätta, eller avvisa den om bevarande av alla guider krävs.
- **Laddningsbeteende:** Laddningsalternativ och äldre beteenden kan också producera varningar. Till exempel identifierar [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) användning av ett föråldrat presentationslåsningsbeteende som ett `CompatibilityIssue`.

Varningar beror på källdokumentet, målformatet, operationen och Aspose.Slides‑versionen. Anta inte att varje fil genererar en varning eller att ett scenario alltid motsvarar endast en kategori.

## **Säkert hantera avbrutna operationer**

När en återuppringning returnerar `ReturnAction.Abort`, använd inte ett objekt som misslyckades att laddas och anta inte att en renderings‑ eller sparutgång är fullständig. Operationen kan avslutas efter att en utdatafil skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, t.ex. `validated-output.pptx`. Ersätt en befintlig presentation först när operationen har avslutats framgångsrikt, varningsrapporten uppfyller applikationspolicyn och utdata kan öppnas och kontrolleras. Detta undviker att skriva över en giltig källfil med ett partiellt eller avvisat resultat.

En tom varningsrapport är ingen garanti för att varje källfunktion har bevarats. Applicera eventuella ytterligare innehålls‑ och visuella kontroller som krävs av applikationen. Se också [Öppna presentationer](/slides/sv/net/open-presentation/) och [Spara presentationer](/slides/sv/net/save-presentation/).

## **FAQ**

**Kan en varningsåteruppringning hantera varje Aspose.Slides‑fel?**

Nej. Den hanterar återhämtningsbara tillstånd som rapporteras som varningar. Undantag som uppstår oberoende av återuppringningen måste hanteras av applikationen runt laddnings‑, renderings‑, konverterings‑ eller sparningsanropet.

**Garantiar returnering av `ReturnAction.Continue` identiskt utdata?**

Nej. Den tillåter bara att bearbetningen fortsätter. Det rapporterade tillståndet kan fortfarande orsaka data‑, formaterings‑ eller kompatibilitetsskillnader, så granska de insamlade varningstyperna och beskrivningarna.

**Hur kan en applikation identifiera den operation som producerade en varning?**

Skapa en återuppringningsinstans för varje operation och lagra ett applikationsdefinierat stadium tillsammans med `WarningType` och `Description`, som visas i exemplet.