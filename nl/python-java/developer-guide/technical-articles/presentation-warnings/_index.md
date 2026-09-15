---
title: Afhandelen van Presentatiewaarschuwingen in Python via Java
type: docs
weight: 90
url: /nl/python-java/presentation-warnings/
aliases:
- /python-java/haal-waarschuwingen-op-voor-lettertypevervanging-in-aspose-slides/
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
- presentatie converteren
- presentatie opslaan
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, classificeren en behandelen tijdens het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides kan herstelbare problemen melden tijdens het laden, renderen, converteren of opslaan van een presentatie. Voorbeelden zijn beschadigde bronrecords, inhoud die niet bewaard kan blijven, lettertype‑vervanging en beperkingen van een doelformaat. Een waarschuwings‑callback stelt een toepassing in staat deze omstandigheden te registreren en te bepalen of de huidige bewerking kan worden voortgezet.

Implementeer de `IWarningCallback`‑interface via `jpype.JProxy` en bekijk de waarden van `getWarningType` en `getDescription` die via `IWarningInfo` worden geleverd. Retourneer [ReturnAction.Continue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/returnaction/#Continue) om de waarschuwing te accepteren of [ReturnAction.Abort](https://reference.aspose.com/slides/nl/python-java/aspose.slides/returnaction/#Abort) om de bewerking te stoppen.

Gebruik [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setWarningCallback) voor waarschuwingen die worden gegenereerd bij het openen van een presentatie. Rendering‑ en exportoptie‑klassen erven [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setWarningCallback), die waarschuwingen ontvangt van slide‑rendering, conversie en opslaan. Omdat de waarschuwing zelf de toepassingsbewerking niet identificeert, koppel je elke callback‑instantie aan een bewerkingsfase bij het opstellen van een gecombineerd rapport.

## **Waarschuwingen en uitzonderingen**

Een waarschuwing beschrijft een situatie waarvan Aspose.Slides kan herstellen als de callback `ReturnAction.Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet door een waarschuwings‑policy worden afgehandeld.

Wanneer `ReturnAction.Abort` wordt geretourneerd, vraagt de waarschuwingsdispatcher de huidige bewerking te beëindigen door een uitzondering te werpen. De openbare uitzondering hangt af van de bewerking en het presentatiefomaat. Bijvoorbeeld, bij het laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxreadexception/) of [PptReadException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptreadexception/) optreden, terwijl bij het opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxexception/) kan verschijnen. Handel de uitzondering af aan de grens van de bewerking en gebruik het waarschuwingsrapport om te bepalen of het beleid van de toepassing de beëindiging heeft veroorzaakt in plaats van te vertrouwen op één subtype of bericht van de uitzondering. De callback registreert de waarschuwing voordat `ReturnAction.Abort` wordt geretourneerd, zodat de reden beschikbaar blijft voor de toepassing.

## **Waarschuwingscategorieën**

De klasse [WarningType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/) biedt gehele‑cijfer‑constanten voor de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/#SourceFileCorruption) | De bronpresentatie bevat corruptie die een document dat in het originele formaat is opgeslagen onbruikbaar kan maken. | Afbreken. |
| [DataLoss](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/#DataLoss) | Tekst, grafieken, afbeeldingen of andere gegevens kunnen ontbreken na het laden of opslaan. | Afbreken. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders registreren en doorgaan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Een beperkte opmaakverschil kan optreden. | Registreren voor diagnostiek en doorgaan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Het resultaat kan in sommige toepassingen of oudere versies niet openen of correct functioneren. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| [UnexpectedContent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/warningtype/#UnexpectedContent) | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan het effect nog onbekend kan zijn. | Registreren en doorgaan, of behandelen als een fout in een strikt beleid. |

De categorie moet de beleidsbeslissing sturen. Sla de waarde die door `getDescription` wordt geretourneerd op voor diagnostiek, maar baseer de toepassingslogica niet op de bewoording omdat de berichttekst kan variëren tussen waarschuwingsscenario's en productversies.

## **Verzamel en classificeer waarschuwingen**

Het volgende voorbeeld gebruikt één toepassings‑niveau rapport voor de volledige verwerkingspijplijn. Een afzonderlijke callback‑instantie labelt waarschuwingen van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid beëindigt bij bron‑corruptie of gegevensverlies, stopt eventueel bij grote opmaakverlies, en gaat door voor andere waarschuwingen.

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

Geef `False` op voor `abort_on_major_formatting_loss` bij het construeren van `WarningPolicy` als grote opmaakverschillen acceptabel zijn. Compatibiliteitsproblemen, klein opmaakverlies en onverwachte inhoud blijven nog steeds in het rapport behouden, zelfs wanneer de bewerking wordt voortgezet. Breid `WarningPolicy.get_action` uit als de toepassing een van deze categorieën moet afwijzen.

## **Veelvoorkomende waarschuwingsscenario's**

Waarschuwingen kunnen optreden in verschillende fasen van een workflow:

- **Digitale handtekeningen:** Een ondertekende presentatie kan bij het laden een waarschuwing genereren dat de handtekening verloren gaat tijdens de verwerking. Aspose.Slides meldt deze `DataLoss`‑conditie via `IPresentationSignedWarningInfo`. Een callback in de laadfase stelt de toepassing in staat het bestand te weigeren of het gemelde verlies expliciet te accepteren.
- **Lettertype‑vervanging:** Een niet‑beschikbaar lettertype kan worden vervangen tijdens het renderen of exporteren van een dia. Waarschuwingen over lettertype‑vervanging worden gemeld als `DataLoss`, waardoor het strikte beleid hierboven afbreekt, zelfs als de toepassing een bepaalde vervanging visueel acceptabel zou vinden. Om dit gedrag te observeren, gebruik een invoerpresentatie met tekst in een lettertype dat niet beschikbaar is voor de runtime. De waarschuwingsbeschrijving identificeert de vervanging; configureer de vereiste lettertypen of [font substitution rules](/slides/nl/python-java/font-substitution/) voordat u het opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatie‑records of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer gegevens of opmaak bekend is aangetast.
- **Formaat‑compatibiliteit:** Opslaan naar een ander presentatiefomaat kan functies weglaten of een resultaat opleveren dat zich anders gedraagt in sommige toepassingen. Bijvoorbeeld, een presentatie met meer dan acht horizontale of acht verticale tekengidsen opslaan naar een legacy PPT meldt een `CompatibilityIssue`. De callback in de opslaanfase kan het verlies registreren en doorgaan, of het afwijzen als het behouden van alle gidsen vereist is.
- **Laadgedrag:** Laadopties en legacy‑gedragingen kunnen eveneens waarschuwingen genereren. Bijvoorbeeld, `IObsoletePresLockingBehaviorWarningInfo` identificeert het gebruik van een verouderd presentatie‑vergrendelingsgedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het bron‑document, het doelformaat, de bewerking en de versie van Aspose.Slides. Ga niet ervan uit dat elk bestand een waarschuwing oplevert of dat een scenario altijd aan slechts één categorie gekoppeld is.

## **Afgebroken bewerkingen veilig afhandelen**

Wanneer een callback `ReturnAction.Abort` retourneert, gebruik dan geen object dat niet geladen kon worden en ga niet ervan uit dat een render‑ of opslaag‑output compleet is. De bewerking kan beëindigen nadat een uitvoerbestand is aangemaakt maar vóórdat het voltooid is.

Sla gevalideerde resultaten op naar een apart pad, bijvoorbeeld `validated-output.pptx`. Vervang een bestaande presentatie pas nadat de bewerking succesvol is afgerond, het waarschuwingsrapport voldoet aan het beleids‑van de toepassing, en de output geopend en gecontroleerd kan worden. Dit voorkomt het overschrijven van een geldig bronbestand met een gedeeltelijk of afgewezen resultaat.

Een leeg waarschuwingsrapport biedt geen garantie dat elke bron‑eigenschap behouden is gebleven. Pas eventuele extra inhouds‑ en visuele controles toe die de toepassing vereist. Zie ook [Open Presentations](/slides/nl/python-java/open-presentation/) en [Save Presentations](/slides/nl/python-java/save-presentation/).

## **FAQ**

**Kan een waarschuwings‑callback elke Aspose.Slides‑fout afhandelen?**

Nee. Het handelt herstelbare situaties af die worden gerapporteerd als waarschuwingen. Uitzonderingen die onafhankelijk van de callback optreden, moeten door de toepassing worden afgehandeld rond het laad‑, render‑, conversie‑ of opslaag‑oproep.

**Garandeert het retourneren van `ReturnAction.Continue` identieke output?**

Nee. Het staat alleen toe de verwerking voort te zetten. De gerapporteerde situatie kan nog steeds data‑, opmaak‑ of compatibiliteitsverschillen veroorzaken, dus controleer de verzamelde waarschuwings‑typen en beschrijvingen.

**Hoe kan een toepassing de bewerking identificeren die een waarschuwing heeft veroorzaakt?**

Maak voor elke bewerking een callback‑instantie aan en sla een door de toepassing gedefinieerde fase op samen met de waarden die door `getWarningType` en `getDescription` worden geretourneerd, zoals in het voorbeeld wordt getoond.