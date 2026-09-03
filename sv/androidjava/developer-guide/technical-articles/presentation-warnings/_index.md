---
title: Hantera presentationsvarningar på Android
type: docs
weight: 90
url: /sv/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteruppringning
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- teckensnittssubstitution
- digital signatur
- presentationsläsning
- presentationsrendering
- presentationskonvertering
- presentationssparning
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du samlar in, klassificerar och hanterar varningar när du läser in, renderar, konverterar och sparar presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides kan rapportera återhämtningsbara problem när den läser in, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposter, innehåll som inte kan bevaras, teckensnittssubstitution och begränsningar i ett målformat. En varningsåteruppringning låter en applikation registrera dessa förhållanden och besluta om den aktuella operationen kan fortsätta.

Implementera gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarningcallback/) och undersök värdena [getWarningType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) som tillhandahålls via [IWarningInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarninginfo/). Returnera [ReturnAction.Continue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/returnaction/#Continue) för att acceptera varningen eller [ReturnAction.Abort](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/returnaction/#Abort) för att stoppa operationen.

Använd [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) för varningar som uppstår när en presentation öppnas. Rendering- och exportalternativklasser ärver [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), som tar emot varningar från bildritning, konvertering och sparning. Eftersom själva varningen inte identifierar vilken applikationsoperation som inträffade, associera varje återuppringningsinstans med ett operationstadium när du bygger en samlet rapport.

## **Varningar och Undantag**

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om återuppringningen returnerar `ReturnAction.Continue`. Ett undantag innebär att den begärda operationen inte kan slutföras normalt; undantag konverteras inte till varningar och kan inte hanteras av en varningspolicy.

Att returnera `ReturnAction.Abort` begär att varningsdistributören terminerar den aktuella operationen genom att kasta ett undantag. Det offentliga undantaget beror på operationen och presentationsformatet. Till exempel kan inläsning ge en [PptxReadException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptreadexception/), medan sparning eller export kan ge en [PptxException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxexception/). Hantera undantaget vid operationens gräns och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avslutet istället för att förlita dig på en undantagsundertyp eller meddelande. Återuppringningen registrerar varningen innan den returnerar `ReturnAction.Abort`, vilket säkerställer att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

Klassen [WarningType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/) tillhandahåller heltalskonstanter för följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Källpresentationen innehåller korruption som kan göra ett dokument sparat i sitt ursprungliga format oanvändbart. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/#DataLoss) | Text, diagram, bilder eller annan data kan saknas efter inläsning eller sparning. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Presentation kan förlora viktig formatering. | Abortera i strikt valideringsläge; annars registrera och fortsätt. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | En begränsad formateringsskillnad kan förekomma. | Registrera för diagnostik och fortsätt. |
| [CompatibilityIssue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Resultatet kanske inte öppnas eller beter sig korrekt i vissa applikationer eller äldre versioner. | Logga och fortsätt om inte kompatibilitet är obligatorisk. |
| [UnexpectedContent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Källan innehåller otillåtet eller oidentifierat innehåll vars effekt kanske ännu inte är känd. | Registrera och fortsätt, eller behandla som fel i en strikt policy. |

Kategorin bör styra policysbeslutet. Spara värdet som returneras av [getDescription](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) för diagnostik, men förlita dig inte på dess formulering för applikationslogik eftersom meddelandetexten kan variera mellan varningsscenarier och produktversioner.

## **Samla och Klassificera Varningar**

Följande exempel använder en applikationsnivårapport för hela bearbetningskedjan. En separat återuppringningsinstans märker varningar från inläsning, rendering, PDF‑konvertering och PPTX‑sparning. Policyn avbryter vid källkorruption eller dataförlust, avbryter eventuellt vid stor formateringsförlust och fortsätter för övriga varningar.

Placera `input.pptx` i en skrivbar applikationskatalog och skicka den katalogen till `PresentationWarningExample.run`. Exemplet sparar sina utdata i samma katalog. Kör presentationsbearbetning i en bakgrundstråd för att hålla Android‑användargränssnittet responsivt.

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

Skicka `false` för `abortOnMajorFormattingLoss` när du konstruerar `WarningPolicy` om stora formateringsskillnader är acceptabla. Kompatibilitetsproblem, mindre formateringsförlust och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy.getAction` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga Varningsscenarier**

Varningar kan uppstå i olika steg i ett arbetsflöde:

- **Digitala signaturer:** En signerad presentation kan ge en varning under inläsning att dess signatur kommer att gå förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`‑tillstånd via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Ett återuppringningssteg för inläsning låter applikationen avvisa filen eller explicit acceptera den rapporterade förlusten.
- **Teckensnittssubstitution:** Ett otillgängligt teckensnitt kan ersättas medan en bild renderas eller exporteras. Varningar om teckensnittssubstitution rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle anse ett visst byte visuellt acceptabelt. För att observera detta beteende, använd en inmatningspresentation som innehåller text i ett teckensnitt som inte är tillgängligt för körmiljön. Varningsbeskrivningen identifierar substitutionen; konfigurera de erforderliga teckensnitten eller [teckensnittssubstitutionsregler](/slides/sv/androidjava/font-substitution/) innan du försöker igen.
- **Ej stöd eller oväntat innehåll:** En läsare kan stöta på presentationsposter eller funktioner den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en allvarligare kategori när data eller formatering är kända att vara påverkade.
- **Formatkompatibilitet:** Sparning till ett annat presentationsformat kan utelämna funktioner eller ge ett resultat som beter sig annorlunda i vissa applikationer. Till exempel rapporterar sparning av en presentation med mer än åtta horisontella eller åtta vertikala ritguider till äldre PPT ett `CompatibilityIssue`. Återuppringning i sparningsstadiet kan registrera förlusten och fortsätta, eller avvisa den om bevarande av alla guider är nödvändigt.
- **Inläsningsbeteende:** Inläsningsalternativ och äldre beteenden kan också ge varningar. Till exempel identifierar [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) användning av ett föråldrat presentationslåsningsbeteende som ett `CompatibilityIssue`.

Varningar beror på källdokument, målformat, operation och Aspose.Slides‑version. Anta inte att varje fil ger en varning eller att ett scenario alltid motsvarar endast en kategori.

## **Hantera avbrutna operationer på ett säkert sätt**

När en återuppringning returnerar `ReturnAction.Abort` får du inte använda ett objekt som misslyckades med att läsas in och du får inte anta att en renderings‑ eller sparutdata är komplett. Operationen kan avslutas efter att en utdatafil skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, exempelvis `validated-output.pptx`. Ersätt en befintlig presentation först när operationen avslutats framgångsrikt, varningsrapporten uppfyller applikationspolicyn och utdata kan öppnas och kontrolleras. Detta förhindrar att en giltig källfil skrivs över med ett partiellt eller avvisat resultat.

En tom varningsrapport garanterar inte att varje källfunktion har bevarats. Tillämpa eventuella ytterligare innehålls‑ och visuella kontroller som krävs av applikationen. Se även [Öppna presentationer](/slides/sv/androidjava/open-presentation/) och [Spara presentationer](/slides/sv/androidjava/save-presentation/).

## **FAQ**

**Kan en varningsåteruppringning hantera varje Aspose.Slides‑fel?**

Nej. Den hanterar återhämtningsbara förhållanden som rapporteras som varningar. Undantag som uppstår oberoende av återuppringningen måste hanteras av applikationen runt inläsning‑, renderings‑, konverterings‑ eller sparningsanropet.

**Garantiar återlämnande av `ReturnAction.Continue` identiskt resultat?**

Nej. Det tillåter endast att bearbetningen fortsätter. Det rapporterade tillståndet kan fortfarande orsaka data-, formaterings‑ eller kompatibilitetsavvikelser, så granska de insamlade varningstyperna och beskrivningarna.

**Hur kan en applikation identifiera vilken operation som skapade en varning?**

Skapa en återuppringningsinstans för varje operation och lagra ett applikationsdefinierat stadium tillsammans med värdena som returneras av [getWarningType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), som visas i exemplet.