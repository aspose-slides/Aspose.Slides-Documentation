---
title: Hantera presentationsvarningar i Java
type: docs
weight: 90
url: /sv/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteruppringning
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- teckensnittssubstitution
- digital signatur
- presentationsladdning
- presentationsrendering
- presentationskonvertering
- presentationssparning
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Lär dig hur du samlar in, klassificerar och hanterar varningar när du läser in, renderar, konverterar och sparar presentationer med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides kan rapportera återhämtningsbara problem när den läser in, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposter, innehåll som inte kan bevaras, teckensnittssubstitution och begränsningar i måformatet. En varningsåteruppringning låter en applikation registrera dessa förhållanden och avgöra om den aktuella operationen kan fortsätta.

Implementera gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarningcallback/) och granska värdena för [getWarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--) som tillhandahålls via [IWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/). Returnera [ReturnAction.Continue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/returnaction/#Continue) för att acceptera varningen eller [ReturnAction.Abort](https://reference.aspose.com/slides/sv/java/com.aspose.slides/returnaction/#Abort) för att stoppa operationen.

Använd [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) för varningar som uppstår när en presentation öppnas. Renderings- och exportalternativklasser ärver [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), som tar emot varningar från bildrendering, konvertering och sparning. Eftersom själva varningen inte identifierar vilken applikationsoperation som sker, bör du koppla varje återuppringningsinstans till ett operationsstadium när du bygger en kombinerad rapport.

## **Varningar och undantag**

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om återuppringningen returnerar `ReturnAction.Continue`. Ett undantag betyder att den begärda operationen inte kan slutföras normalt; undantag konverteras inte till varningar och kan inte hanteras av en varningspolicy.

Att returnera `ReturnAction.Abort` får varningsdistributören att avsluta den aktuella operationen genom att kasta ett undantag. Det offentliga undantaget beror på operationen och presentationsformatet. Till exempel kan inläsning ge ett [PptxReadException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptreadexception/), medan sparning eller export kan ge ett [PptxException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxexception/). Hantera undantaget vid operationens gränssnitt och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avbrottet istället för att förlita dig på en specifik undantagstyp eller meddelande. Återuppringningen registrerar varningen innan den returnerar `ReturnAction.Abort`, vilket säkerställer att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

[WarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/)-klassen tillhandahåller heltalskonstanter för följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Den ursprungliga presentationen innehåller korruption som kan göra ett dokument sparat i dess ursprungliga format oanvändbart. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/#DataLoss) | Text, diagram, bilder eller annan data kan saknas efter inläsning eller sparning. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Presentation kan förlora viktig formatering. | Avbryt i strikt valideringsläge; annars registrera och fortsätt. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | En begränsad formateringsskillnad kan uppstå. | Registrera för diagnostik och fortsätt. |
| [CompatibilityIssue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Resultatet kanske inte öppnas eller fungerar korrekt i vissa program eller äldre versioner. | Logga och fortsätt såvida inte kompatibilitet är obligatorisk. |
| [UnexpectedContent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/warningtype/#UnexpectedContent) | Källan innehåller ej stödd eller okänd innehåll vars effekt ännu inte är känd. | Registrera och fortsätt, eller behandla som ett fel i en strikt policy. |

Kategorin bör styra policybeslutet. Spara värdet som returneras av [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--) för diagnostik, men förlita dig inte på dess formulering i applikationslogiken eftersom meddelandetext kan variera mellan varningsscenarier och produktversioner.

## **Samla och klassificera varningar**

Följande exempel använder en applikationsnivårapport för hela behandlingskedjan. En separat återuppringningsinstans märker varningar från inläsning, rendering, PDF-konvertering och PPTX-sparning. Policyn avbryter vid källkorruption eller dataförlust, avbryter valfritt vid stor formateringsförlust och fortsätter för övriga varningar.

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

Skicka `false` för `abortOnMajorFormattingLoss` när du konstruerar `WarningPolicy` om större formateringsskillnader är acceptabla. Kompatibilitetsproblem, mindre formateringsförlust och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy.getAction` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga varningsscenarier**

Varningar kan uppstå i olika steg av ett arbetsflöde:

- **Digitala signaturer:** En signerad presentation kan producera en varning under inläsning att dess signatur kommer att gå förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`-tillstånd via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationsignedwarninginfo/). En återuppringning i inläsningsstadiet låter applikationen avvisa filen eller uttryckligen acceptera den rapporterade förlusten.
- **Teckensnittssubstitution:** Ett otillgängligt teckensnitt kan ersättas medan en bild renderas eller exporteras. Varningar om teckensnittssubstitution rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle anse att en viss ersättning är visuellt acceptabel. För att observera detta beteende, använd en inmatningspresentation som innehåller text i ett teckensnitt som inte är tillgängligt för runtime. Varningsbeskrivningen identifierar substitutionen; konfigurera de nödvändiga teckensnitten eller [teckensnittssubstitutionsregler](/slides/sv/java/font-substitution/) innan du försöker igen.
- **Ej stödd eller oväntat innehåll:** En laddare kan stöta på presentationsposter eller funktioner som den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en allvarligare kategori när data eller formatering är kända för att påverkas.
- **Formatkompatibilitet:** Att spara till ett annat presentationsformat kan utelämna funktioner eller producera ett resultat som beter sig annorlunda i vissa program. Till exempel rapporterar sparning av en presentation med mer än åtta horisontella eller åtta vertikala ritguider till legacy PPT ett `CompatibilityIssue`. Återuppringningen i sparningsstadiet kan registrera förlusten och fortsätta, eller avvisa den om bevarande av alla guider krävs.
- **Inläsningsbeteende:** Inläsningsalternativ och äldre beteenden kan också producera varningar. Till exempel identifierar [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) användning av ett föråldrat presentationslåsningsbeteende som ett `CompatibilityIssue`.

Varningar beror på källdokumentet, målformatet, operationen och Aspose.Slides-versionen. Anta inte att varje fil genererar en varning eller att ett scenario alltid motsvarar endast en kategori.

## **Hantera avbrutna operationer på ett säkert sätt**

När en återuppringning returnerar `ReturnAction.Abort` får du inte använda ett objekt som misslyckades med att läsas in och du får inte anta att en renderings- eller sparutgång är komplett. Operationen kan avslutas efter att en utdatfil har skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, t.ex. `validated-output.pptx`. Ersätt en befintlig presentation först när operationen har slutförts framgångsrikt, varningsrapporten uppfyller applikationspolicyn och utsignalen kan öppnas och kontrolleras. Detta förhindrar att en giltig källfil skrivs över med ett partiellt eller avvisat resultat.

En tom varningsrapport är ingen garanti för att varje källfunktion har bevarats. Tillämpa eventuella ytterligare innehålls- och visuella kontroller som krävs av applikationen. Se även [Open Presentations](/slides/sv/java/open-presentation/) och [Save Presentations](/slides/sv/java/save-presentation/).

## **FAQ**

**Kan en varningsåteruppringning hantera varje Aspose.Slides-fel?**

Nej. Den hanterar återhämtningsbara förhållanden som rapporteras som varningar. Undantag som uppstår oberoende av återuppringningen måste hanteras av applikationen runt inläsning, rendering, konvertering eller sparningsanropet.

**Garanterar returnering av `ReturnAction.Continue` identiskt resultat?**

Nej. Det tillåter bara att bearbetningen fortsätter. Det rapporterade förhållandet kan fortfarande orsaka data-, formaterings- eller kompatibilitetsskillnader, så granska de insamlade varningstyperna och beskrivningarna.

**Hur kan en applikation identifiera vilken operation som genererade en varning?**

Skapa en återuppringningsinstans för varje operation och lagra ett applikationsdefinierat stadium tillsammans med de värden som returneras av [getWarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--), som visas i exemplet.