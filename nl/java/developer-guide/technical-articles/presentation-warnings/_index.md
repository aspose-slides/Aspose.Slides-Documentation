---
title: Beheer presentatiewaarschuwingen in Java
type: docs
weight: 90
url: /nl/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwingscallback
- waarschuwingsbeleid
- gegevensverlies
- broncorruptie
- compatibiliteitsprobleem
- fontvervanging
- digitale handtekening
- presentatie laden
- presentatie renderen
- presentatie conversie
- presentatie opslaan
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, categoriseren en behandelen tijdens het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides kan herstelbare problemen melden tijdens het laden, renderen, converteren of opslaan van een presentatie. Voorbeelden zijn beschadigde bronrecords, inhoud die niet kan worden bewaard, fontvervanging en beperkingen van een doelindeling. Een waarschuwingscallback laat een toepassing deze omstandigheden registreren en besluiten of de huidige bewerking kan doorgaan.

Implementeer de [IWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarningcallback/) interface en bekijk de waarden van [getWarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) die via [IWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/) worden geleverd. Retourneer [ReturnAction.Continue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/returnaction/#Continue) om de waarschuwing te accepteren of [ReturnAction.Abort](https://reference.aspose.com/slides/nl/java/com.aspose.slides/returnaction/#Abort) om de bewerking te stoppen.

Gebruik [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) voor waarschuwingen die worden opgehaald tijdens het openen van een presentatie. Rendering‑ en exportoptieklassen erven van [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), die waarschuwingen ontvangt van slide‑rendering, conversie en opslaan. Omdat de waarschuwing zelf niet aangeeft welke toepassingsbewerking eraan ten grondslag ligt, koppelt u elke callback‑instantie aan een bewerkingsstadium wanneer u een gecombineerd rapport opstelt.

## **Waarschuwingen en Uitzonderingen**

Een waarschuwing beschrijft een toestand waaruit Aspose.Slides kan herstellen als de callback `ReturnAction.Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet worden afgehandeld door een waarschuwingsbeleid.

Het retourneren van `ReturnAction.Abort` vraagt de waarschuwingsdispatcher de huidige bewerking te beëindigen door een uitzondering te genereren. De openbare uitzondering hangt af van de bewerking en het presentatieformaat. Bijvoorbeeld, laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxreadexception/) of [PptReadException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptreadexception/) opleveren, terwijl opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxexception/) kan opleveren. Handel de uitzondering af aan de rand van de bewerking en gebruik het waarschuwingsrapport om te bepalen of het beleid van de toepassing de beëindiging heeft veroorzaakt, in plaats van te vertrouwen op één subtype of bericht van een uitzondering. De callback registreert de waarschuwing voordat `ReturnAction.Abort` wordt geretourneerd, zodat de reden beschikbaar blijft voor de toepassing.

## **Waarschuwingscategorieën**

De [WarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/) klasse biedt gehele constanten voor de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/#SourceFileCorruption) | De bronpresentatie bevat corrupties die een document dat in zijn oorspronkelijke indeling wordt opgeslagen onbruikbaar kunnen maken. | Afbreken. |
| [DataLoss](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/#DataLoss) | Tekst, diagrammen, afbeeldingen of andere gegevens kunnen ontbreken na het laden of opslaan. | Afbreken. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders registreren en doorgaan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Een beperkte opmaakverschil kan optreden. | Registreren voor diagnostiek en doorgaan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Het resultaat opent mogelijk niet of functioneert niet correct in sommige toepassingen of oudere versies. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| [UnexpectedContent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/warningtype/#UnexpectedContent) | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan het effect nog onbekend is. | Registreren en doorgaan, of behandelen als fout bij een strikt beleid. |

De categorie moet de beleidsbeslissing sturen. Bewaar de waarde die door [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) wordt geretourneerd voor diagnostiek, maar baseer de toepassingslogica niet op de exacte formulering, omdat de berichttekst kan variëren tussen waarschuwingsscenario's en productversies.

## **Verzamel en classificeer waarschuwingen**

Het volgende voorbeeld gebruikt één rapport op toepassingsniveau voor de volledige verwerkingspijplijn. Een aparte callback‑instantie labelt waarschuwingen van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid breekt af bij broncorruptie of gegevensverlies, breekt optioneel af bij groot opmaakverlies en gaat door bij andere waarschuwingen.

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

Geef `false` door voor `abortOnMajorFormattingLoss` bij het construeren van `WarningPolicy` als grote opmaakverschillen acceptabel zijn. Compatibiliteitsproblemen, klein opmaakverlies en onverwachte inhoud blijven nog steeds in het rapport behouden, zelfs wanneer de bewerking doorgaat. Breid `WarningPolicy.getAction` uit als de toepassing een van die categorieën moet weigeren.

## **Veelvoorkomende waarschuwingsscenario's**

Waarschuwingen kunnen op verschillende stappen van een workflow verschijnen:

- **Digitale handtekeningen:** Een ondertekende presentatie kan tijdens het laden een waarschuwing geven dat de handtekening verloren gaat tijdens de verwerking. Aspose.Slides rapporteert deze `DataLoss`‑toestand via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationsignedwarninginfo/). Een callback in de laadfase laat de toepassing het bestand afwijzen of expliciet de gemelde verlies accepteren.
- **Fontvervanging:** Een niet‑beschikbaar font kan worden vervangen terwijl een slide wordt gerenderd of geëxporteerd. Fontvervangingswaarschuwingen worden gerapporteerd als `DataLoss`, zodat het bovenstaande strikte beleid afbreekt zelfs als de toepassing een bepaalde vervanging visueel acceptabel zou vinden. Om dit gedrag te observeren, gebruik een invoerpresentatie met tekst in een font dat niet beschikbaar is voor de runtime. De waarschuwingbeschrijving identificeert de vervanging; configureer de vereiste fonts of [font substitution rules](/slides/nl/java/font-substitution/) voordat u opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatierecords of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer gegevens of opmaak bekend zijn aangetast.
- **Formaatcompatibiliteit:** Opslaan naar een ander presentatiesformaat kan functies weglaten of een resultaat opleveren dat zich anders gedraagt in sommige toepassingen. Bijvoorbeeld, opslaan van een presentatie met meer dan acht horizontale of acht verticale tekengidsen naar legacy PPT rapporteert een `CompatibilityIssue`. De callback in de opslafase kan het verlies registreren en doorgaan, of het weigeren als het behouden van alle gidsen vereist is.
- **Laadgedrag:** Laadopties en legacy‑gedrag kunnen ook waarschuwingen genereren. Bijvoorbeeld, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identificeert het gebruik van een verouderd presentatielock‑gedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het bronbestand, het doelformaat, de bewerking en de versie van Aspose.Slides. Ga er niet van uit dat elk bestand een waarschuwing oplevert of dat een scenario altijd slechts één categorie gebruikt.

## **Veilig afgebroken bewerkingen afhandelen**

Wanneer een callback `ReturnAction.Abort` retourneert, gebruik dan geen object dat niet geladen kon worden en ga er niet van uit dat een render‑ of opslaan‑output compleet is. De bewerking kan eindigen nadat een output‑bestand is aangemaakt maar vóórdat het volledig is afgerond.

Sla gevalideerde resultaten op naar een apart pad, bijvoorbeeld `validated-output.pptx`. Vervang een bestaande presentatie pas nadat de bewerking succesvol is afgerond, het waarschuwingsrapport aan het beleid voldoet, en de output kan worden geopend en gecontroleerd. Dit voorkomt het overschrijven van een geldig bronbestand met een gedeeltelijk of afgewezen resultaat.

Een leeg waarschuwingsrapport garandeert niet dat elk bronkenmerk bewaard is gebleven. Pas eventuele extra inhouds‑ en visuele controles toe die de toepassing vereist. Zie ook [Open Presentations](/slides/nl/java/open-presentation/) en [Save Presentations](/slides/nl/java/save-presentation/).

## **FAQ**

**Kan een waarschuwingscallback elke Aspose.Slides‑fout afhandelen?**

Nee. Het behandelt alleen herstelbare toestanden die als waarschuwingen worden gerapporteerd. Uitzonderingen die onafhankelijk van de callback optreden, moeten door de toepassing rond het laad‑, render‑, conversie‑ of opslaan‑call worden afgehandeld.

**Garandeert het retourneren van `ReturnAction.Continue` identieke output?**

Nee. Het staat alleen toe dat de verwerking doorgaat. De gerapporteerde toestand kan nog steeds leiden tot verschillen in gegevens, opmaak of compatibiliteit, dus beoordeel de verzamelde waarschuwingssoorten en beschrijvingen.

**Hoe kan een toepassing de bewerking identificeren die een waarschuwing heeft veroorzaakt?**

Maak een callback‑instantie voor elke bewerking en sla een door de toepassing gedefinieerde fase op samen met de waarden die door [getWarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) worden geretourneerd, zoals getoond in het voorbeeld.