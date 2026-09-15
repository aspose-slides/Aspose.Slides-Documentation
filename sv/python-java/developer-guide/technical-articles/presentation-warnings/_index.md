---
title: Hantera presentationsvarningar i Python via Java
type: docs
weight: 90
url: /sv/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteruppringning
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- teckensnittssubstitution
- digital signatur
- presentation inläsning
- rendering av presentation
- konvertering av presentation
- sparande av presentation
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du samlar in, klassificerar och hanterar varningar när du läser in, renderar, konverterar och sparar presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides kan rapportera återhämtningsbara problem medan den läser in, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposter, innehåll som inte kan bevaras, teckensnittssubstitution och begränsningar i ett målformat. En varningsåteruppringning låter en applikation registrera dessa villkor och avgöra om den aktuella operationen kan fortsätta.

Implementera `IWarningCallback`-gränssnittet via `jpype.JProxy` och undersök `getWarningType` och `getDescription`-värdena som levereras via `IWarningInfo`. Returnera [ReturnAction.Continue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/returnaction/#Continue) för att acceptera varningen eller [ReturnAction.Abort](https://reference.aspose.com/slides/sv/python-java/aspose.slides/returnaction/#Abort) för att stoppa operationen.

Använd [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setWarningCallback) för varningar som uppstår när en presentation öppnas. Renderings- och exportalternativklasser ärver [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveoptions/#setWarningCallback), som tar emot varningar från bildrendering, konvertering och sparande. Eftersom själva varningen inte identifierar applikationsoperationen, associera varje återuppringningsinstans med ett operationstadium när du bygger en samlad rapport.

## **Varningar och Undantag**

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om återuppringningen returnerar `ReturnAction.Continue`. Ett undantag innebär att den begärda operationen inte kan slutföras normalt; undantag konverteras inte till varningar och kan inte hanteras av en varningspolicy.

Att returnera `ReturnAction.Abort` får varningsdistributören att avsluta den aktuella operationen genom att kasta ett undantag. Det offentliga undantaget beror på operationen och presentationsformatet. Till exempel kan inläsning ge ett [PptxReadException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptreadexception/), medan sparande eller export kan ge ett [PptxException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxexception/). Hantera undantaget vid gränsen för operationen och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avbrytandet istället för att förlita sig på en undantagstyp eller meddelande. Återuppringningen registrerar varningen innan den returnerar `ReturnAction.Abort`, vilket säkerställer att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

Klassen [WarningType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/) tillhandahåller heltalskonstanter för följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Källpresentationen innehåller korruption som kan göra ett dokument sparat i sitt ursprungliga format oanvändbart. | Avbryt. |
| [DataLoss](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/#DataLoss) | Text, diagram, bilder eller annan data kan saknas efter inläsning eller sparande. | Avbryt. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Presentation kan förlora viktig formatering. | Avbryt i strikt valideringsläge; annars registrera och fortsätt. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | En begränsad formateringsskillnad kan uppstå. | Registrera för diagnostik och fortsätt. |
| [CompatibilityIssue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Resultatet kanske inte öppnas eller fungerar korrekt i vissa program eller äldre versioner. | Logga och fortsätt om inte kompatibilitet är obligatorisk. |
| [UnexpectedContent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/warningtype/#UnexpectedContent) | Källan innehåller icke‑stödd eller okänd data vars effekt kanske ännu inte är känd. | Registrera och fortsätt, eller behandla som fel i en strikt policy. |

Kategorin bör styra policysbeslutet. Spara värdet som returneras av `getDescription` för diagnostik, men förlita dig inte på dess formulering för applikationslogik eftersom meddelandetexten kan variera mellan varningsscenarier och produktversioner.

## **Samla och klassificera varningar**

Följande exempel använder en applikationsnivårapport för hela bearbetningskedjan. En separat återuppringningsinstans märker varningar från inläsning, rendering, PDF‑konvertering och PPTX‑sparande. Policyn avbryter vid källkorruption eller dataförlust, avbryter eventuellt vid stor formateringsförlust och fortsätter för övriga varningar.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Skicka `False` för `abort_on_major_formatting_loss` när du konstruerar `WarningPolicy` om stora formateringsskillnader är acceptabla. Kompatibilitetsproblem, mindre formateringsförlust och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy.get_action` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga varningsscenarier**

Varningar kan uppstå i olika steg av ett arbetsflöde:

- **Digitala signaturer:** En signerad presentation kan ge en varning under inläsning att dess signatur kommer att gå förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`‑tillstånd via `IPresentationSignedWarningInfo`. En återuppringning i laddningsfasen låter applikationen avvisa filen eller uttryckligen acceptera den rapporterade förlusten.
- **Teckensnittssubstitution:** Ett otillgängligt teckensnitt kan ersättas när en bild renderas eller exporteras. Varningar för teckensnittssubstitution rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle anse ett visst utbyte visuellt acceptabelt. För att observera detta beteende, använd en inmatningspresentation som innehåller text i ett teckensnitt som inte är tillgängligt för runtime. Varningsbeskrivningen identifierar ersättningen; konfigurera de erforderliga teckensnitten eller [teckensnittssubstitutionsregler](/slides/sv/python-java/font-substitution/) innan du försöker igen.
- **Ej stöd eller oväntat innehåll:** En läsare kan stöta på presentationsposter eller funktioner den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en mer allvarlig kategori när data eller formatering är kända att påverkas.
- **Formatkompatibilitet:** Sparande till ett annat presentationsformat kan utelämna funktioner eller producera ett resultat som beter sig annorlunda i vissa program. Till exempel rapporterar sparande av en presentation med mer än åtta horisontella eller åtta vertikala ritningsguider till äldre PPT ett `CompatibilityIssue`. Återuppringning i sparningsfasen kan registrera förlusten och fortsätta, eller avvisa den om bevarande av alla guider krävs.
- **Laddningsbeteende:** Inläsningsalternativ och äldre beteenden kan också producera varningar. Till exempel identifierar `IObsoletePresLockingBehaviorWarningInfo` användning av ett föråldrat presentationslåsningsbeteende som ett `CompatibilityIssue`.

Varningar beror på källdokumentet, målformatet, operationen och Aspose.Slides‑versionen. Anta inte att varje fil genererar en varning eller att ett scenario alltid motsvarar endast en kategori.

## **Hantera avbrutna operationer säkert**

När en återuppringning returnerar `ReturnAction.Abort`, använd inte ett objekt som misslyckades att laddas och anta inte att en renderings‑ eller sparutdata är komplett. Operationen kan avslutas efter att en outputfil har skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, t.ex. `validated-output.pptx`. Ersätt en befintlig presentation först när operationen har avslutats framgångsrikt, varningsrapporten uppfyller applikationspolicyn och outputen kan öppnas och kontrolleras. Detta förhindrar att en giltig källfil skrivs över med ett partiellt eller avvisat resultat.

En tom varningsrapport garanterar inte att varje källfunktion har bevarats. Tillämpa eventuella ytterligare innehålls‑ och visuella kontroller som applikationen kräver. Se även [Öppna presentationer](/slides/sv/python-java/open-presentation/) och [Spara presentationer](/slides/sv/python-java/save-presentation/).

## **Vanliga frågor**

**Kan en varningsåteruppringning hantera varje Aspose.Slides‑fel?**

Nej. Den hanterar återhämtningsbara tillstånd som rapporteras som varningar. Undantag som inträffar oberoende av återuppringningen måste hanteras av applikationen runt inläsning-, renderings-, konverterings- eller sparningsanropet.

**Garanterar returnering av `ReturnAction.Continue` identiskt resultat?**

Nej. Den tillåter bara att bearbetningen fortsätter. Det rapporterade tillståndet kan fortfarande orsaka data-, formaterings- eller kompatibilitetsskillnader, så granska de insamlade varningstyperna och beskrivningarna.

**Hur kan en applikation identifiera vilken operation som producerade en varning?**

Skapa en återuppringningsinstans för varje operation och lagra ett applikationsdefinierat stadium tillsammans med de värden som returneras av `getWarningType` och `getDescription`, enligt exemplet.