---
title: Afhandelen van presentatiewaarschuwingen op Android
type: docs
weight: 90
url: /nl/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwingscallback
- waarschuwingsbeleid
- gegevensverlies
- broncorruptie
- compatibiliteitsprobleem
- lettertype-substitutie
- digitale handtekening
- presentatie laden
- presentatie renderen
- presentatieconversie
- presentatie opslaan
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, categoriseren en erop kunt reageren tijdens het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides kan herstelbare problemen melden tijdens het laden, renderen, converteren of opslaan van een presentatie. Voorbeelden zijn beschadigde bronrecords, inhoud die niet kan worden bewaard, lettertype‑substitutie en beperkingen van het doel‑formaat. Een waarschuwings‑callback stelt een toepassing in staat deze omstandigheden vast te leggen en te bepalen of de huidige bewerking kan worden voortgezet.

Implementeer de [IWarningCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarningcallback/)‑interface en bekijk de waarden [getWarningType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) die via [IWarningInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarninginfo/) worden geleverd. Retourneer [ReturnAction.Continue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/returnaction/#Continue) om de waarschuwing te accepteren of [ReturnAction.Abort](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/returnaction/#Abort) om de bewerking te stoppen.

Gebruik [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) voor waarschuwingen die worden opgegeven tijdens het openen van een presentatie. Rendering‑ en export‑optieklassen erven [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), die waarschuwingen ontvangen van dia‑rendering, conversie en opslaan. Omdat de waarschuwing zelf de toepassingsoperatie niet identificeert, koppel je elke callback‑instantie aan een operationele fase wanneer je een gecombineerd rapport opstelt.

## **Waarschuwingen en uitzonderingen**

Een waarschuwing beschrijft een toestand waarvan Aspose.Slides kan herstellen als de callback `ReturnAction.Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet worden afgehandeld door een waarschuwings‑beleid.

Het retourneren van `ReturnAction.Abort` vraagt de waarschuwingsdispatcher om de huidige bewerking te beëindigen door een uitzondering op te werpen. De publieke uitzondering hangt af van de bewerking en het presentatie‑formaat. Bijvoorbeeld, bij laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxreadexception/) of [PptReadException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptreadexception/) verschijnen, terwijl bij opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxexception/) kan optreden. Handel de uitzondering af aan de grens van de bewerking en gebruik het waarschuwings­rapport om te bepalen of het toepassingsbeleid de beëindiging heeft veroorzaakt in plaats van te vertrouwen op één exceptie‑subtype of bericht. De callback registreert de waarschuwing voordat `ReturnAction.Abort` wordt geretourneerd, zodat de reden beschikbaar blijft voor de toepassing.

## **Waarschuwingscategorieën**

De [WarningType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/)‑klasse biedt integer‑constanten voor de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | De bronpresentatie bevat corruptie die een document dat in het oorspronkelijke formaat is opgeslagen onbruikbaar kan maken. | Afbreken. |
| [DataLoss](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/#DataLoss) | Tekst, diagrammen, afbeeldingen of andere gegevens kunnen ontbreken na laden of opslaan. | Afbreken. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders registreren en doorgaan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Er kan een beperkte opmaakverschil optreden. | Registreren voor diagnostiek en doorgaan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Het resultaat kan in sommige toepassingen of oudere versies niet correct openen of functioneren. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| [UnexpectedContent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan het effect nog onbekend kan zijn. | Registreren en doorgaan, of behandelen als een fout in een strikt beleid. |

De categorie moet de beleidsbeslissing aansturen. Bewaar de waarde die wordt geretourneerd door [getDescription](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) voor diagnostiek, maar baseer je applicatielogica niet op de formulering omdat de berichttekst kan variëren tussen waarschuwingsscenario’s en productversies.

## **Verzamel en classificeer waarschuwingen**

Het volgende voorbeeld gebruikt één toepassings‑rapport voor de volledige verwerkings‑pipeline. Een aparte callback‑instantie labelt waarschuwingen van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid breekt af bij bron‑corruptie of gegevensverlies, breekt eventueel af bij groot opmaakverlies, en gaat verder voor andere waarschuwingen.

Plaats `input.pptx` in een beschrijfbare toepassingsmap en geef die map door aan `PresentationWarningExample.run`. Het voorbeeld slaat zijn uitvoer op in dezelfde map. Voer de presentatie‑verwerking uit op een achtergrond‑thread zodat de Android‑gebruikersinterface responsief blijft.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Geef `false` op voor `abortOnMajorFormattingLoss` bij het construeren van `WarningPolicy` als grote opmaakverschillen acceptabel zijn. Compatibiliteitsproblemen, klein opmaakverlies en onverwachte inhoud blijven echter behouden in het rapport, zelfs als de bewerking doorgaat. Breid `WarningPolicy.getAction` uit als de toepassing enige van die categorieën moet afwijzen.

## **Algemene waarschuwingsscenario's**

Waarschuwingen kunnen op verschillende momenten in een workflow verschijnen:

- **Digitale handtekeningen:** Een ondertekende presentatie kan bij het laden een waarschuwing genereren dat de ondertekening verloren gaat tijdens de verwerking. Aspose.Slides meldt deze `DataLoss`‑toestand via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Een callback in de laadfase stelt de toepassing in staat het bestand te verwerpen of het gemelde verlies expliciet te accepteren.
- **Lettertype‑substitutie:** Een niet‑beschikbaar lettertype kan worden vervangen terwijl een dia wordt gerenderd of geëxporteerd. Lettertype‑substitutie‑waarschuwingen worden gemeld als `DataLoss`, zodat het strikte beleid hierboven zelfs afbreekt als de toepassing een bepaalde vervanging visueel acceptabel zou vinden. Om dit gedrag te observeren, gebruik een invoerpresentatie met tekst in een lettertype dat niet beschikbaar is voor de runtime. De waarschuwingsbeschrijving identificeert de substitutie; configureer de vereiste lettertypen of [lettertype‑substitutieregels](/slides/nl/androidjava/font-substitution/) voordat je het opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatierecords of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer gegevens of opmaak bekend is aangetast.
- **Formaat‑compatibiliteit:** Opslaan naar een ander presentatief­formaat kan functies weglaten of een resultaat opleveren dat anders werkt in sommige toepassingen. Bijvoorbeeld, het opslaan van een presentatie met meer dan acht horizontale of acht verticale tekengidsen naar een legacy‑PPT rapporteert een `CompatibilityIssue`. De callback in de opslaanfase kan het verlies registreren en doorgaan, of het verwerpen als het behouden van alle gidsen vereist is.
- **Laadgedrag:** Laadopties en legacy‑gedrag kunnen ook waarschuwingen genereren. Bijvoorbeeld, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identificeert het gebruik van een verouderd presentatie‑vergrendelingsgedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het bron‑document, het doel‑formaat, de bewerking en de versie van Aspose.Slides. Neem niet aan dat elk bestand een waarschuwing genereert of dat een scenario altijd slechts één categorie betreft.

## **Beëindigde operaties veilig afhandelen**

Wanneer een callback `ReturnAction.Abort` retourneert, gebruik dan geen object dat niet geladen kon worden en ga er niet van uit dat een render‑ of opslag‑output volledig is. De bewerking kan beëindigen nadat een uitvoerbestand is aangemaakt maar vóórdat het voltooid is.

Sla gevalideerde resultaten op naar een apart pad, bijvoorbeeld `validated-output.pptx`. Vervang een bestaande presentatie pas nadat de bewerking succesvol is voltooid, het waarschuwings­rapport aan het toepassingsbeleid voldoet, en de uitvoer geopend en gecontroleerd kan worden. Dit voorkomt het overschrijven van een geldig bronbestand met een onvolledig of verworpen resultaat.

Een leeg waarschuwings­rapport is geen garantie dat elke bronfunctie behouden is gebleven. Voer alle aanvullende inhouds‑ en visuele controles uit die de toepassing vereist. Zie ook [Open Presentations](/slides/nl/androidjava/open-presentation/) en [Save Presentations](/slides/nl/androidjava/save-presentation/).

## **FAQ**

**Kan een waarschuwings‑callback elke Aspose.Slides‑fout afhandelen?**

Nee. Het handelt alleen herstelbare toestanden af die als waarschuwingen worden gemeld. Uitzonderingen die onafhankelijk van de callback optreden, moeten door de toepassing rond de laad‑, render‑, conversie‑ of opslag‑aanroep worden afgehandeld.

**Garandeert het retourneren van `ReturnAction.Continue` een identieke output?**

Nee. Het staat alleen toe dat de verwerking doorgaat. De gemelde toestand kan nog steeds leiden tot verschillen in gegevens, opmaak of compatibiliteit, dus controleer de verzamelde waarschuwings­types en -beschrijvingen.

**Hoe kan een toepassing de bewerking identificeren die een waarschuwing heeft gegenereerd?**

Creëer een callback‑instantie voor elke bewerking en sla een door de toepassing gedefinieerde fase op samen met de waarden die worden geretourneerd door [getWarningType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), zoals getoond in het voorbeeld.