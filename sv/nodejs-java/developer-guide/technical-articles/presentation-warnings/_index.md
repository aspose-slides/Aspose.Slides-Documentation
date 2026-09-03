---
title: Hantera presentationsvarningar i Node.js
type: docs
weight: 90
url: /sv/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningscallback
- varningspolicy
- dataförlust
- källkorruption
- kompatibilitetsproblem
- teckensnittsersättning
- digital signatur
- presentationens laddning
- presentationens rendering
- presentationens konvertering
- presentationens sparning
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Lär dig hur du samlar in, klassificerar och hanterar varningar när du laddar, renderar, konverterar och sparar presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides kan rapportera återställningsbara problem när den laddar, renderar, konverterar eller sparar en presentation. Exempel inkluderar skadade källposter, innehåll som inte kan bevaras, teckensnittsersättning och begränsningar i ett målformat. En varnings‑callback låter en applikation registrera dessa förhållanden och besluta om den pågående operationen får fortsätta.

Använd `java.newProxy` för att implementera [IWarningCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarningcallback/)‑gränssnittet i JavaScript och undersök värdena från [getWarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--) som levereras via [IWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/). Returnera [ReturnAction.Continue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/returnaction/#Continue) för att acceptera varningen eller [ReturnAction.Abort](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/returnaction/#Abort) för att stoppa operationen.

Använd [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) för varningar som uppstår när en presentation öppnas. Renderings‑ och exportalternativklasser ärver [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), som tar emot varningar från bildrendering, konvertering och sparning. Eftersom själva varningen inte identifierar vilken applikationsoperation som gjorts, bör varje callback‑instans kopplas till ett operation‑steg när du bygger en samlad rapport.

## **Varningar och Undantag**

En varning beskriver ett tillstånd som Aspose.Slides kan återhämta sig från om callbacken returnerar `ReturnAction.Continue`. Ett undantag betyder att den begärda operationen inte kan slutföras normalt; undantag omvandlas inte till varningar och kan inte hanteras av en varningspolicy.

Genom att returnera `ReturnAction.Abort` begärs varningsdistributören att avsluta den pågående operationen genom att kasta ett undantag. Det offentliga undantaget beror på operationen och presentationsformatet. Till exempel kan laddning resultera i ett [PptxReadException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxreadexception/) eller [PptReadException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptreadexception/), medan sparning eller export kan ge ett [PptxException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxexception/). Fånga felet från Java‑bron vid operationens gräns och använd varningsrapporten för att avgöra om applikationspolicyn orsakade avslutet i stället för att förlita dig på en enda undantagstyp eller meddelande. Callbacken registrerar varningen innan `ReturnAction.Abort` returneras, så att orsaken förblir tillgänglig för applikationen.

## **Varningskategorier**

Klassen [WarningType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/) tillhandahåller heltalskonstanter för följande kategorier:

| Varningstyp | Betydelse | Typisk policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Källpresentationen innehåller korruption som kan göra ett dokument sparat i dess ursprungsformat oanvändbart. | Avbryt. |
| [DataLoss](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/#DataLoss) | Text, diagram, bilder eller annan data kan saknas efter inläst eller sparat. | Avbryt. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Presentation kan förlora viktig formatering. | Avbryt i strikt valideringsläge; annars registrera och fortsätt. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | En begränsad formateringsskillnad kan förekomma. | Registrera för diagnostik och fortsätt. |
| [CompatibilityIssue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Resultatet kanske inte öppnas eller beter sig korrekt i vissa program eller äldre versioner. | Logga och fortsätt om inte kompatibilitet är obligatorisk. |
| [UnexpectedContent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Källan innehåller icke‑stött eller oigenkännt innehåll vars effekt kanske ännu inte är känd. | Registrera och fortsätt, eller behandla som ett fel i en strikt policy. |

Kategorin bör styra policybeslutet. Spara värdet som returneras av [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--) för diagnostik, men förlita dig inte på dess ordalydelse i applikationslogiken eftersom meddelandetexten kan variera mellan varningsscenarier och produktversioner.

## **Samla och Klassificera Varningar**

Följande JavaScript‑exempel använder en applikations‑nivårapport för hela behandlings‑pipeline. En separat callback‑instans märker varningar från laddning, rendering, PDF‑konvertering och PPTX‑sparning. Policyn avbryter vid källkorruption eller dataförlust, avbryter eventuellt vid stor formateringsförlust och fortsätter för övriga varningar.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Skicka `false` för `abortOnMajorFormattingLoss` när du konstruerar `WarningPolicy` om stora formateringsskillnader är acceptabla. Kompatibilitetsproblem, mindre formateringsförlust och oväntat innehåll behålls fortfarande i rapporten även när operationen fortsätter. Utöka `WarningPolicy.getAction` om applikationen måste avvisa någon av dessa kategorier.

## **Vanliga Varningsscenario**

Varningar kan visas i olika steg av ett arbetsflöde:

- **Digital signatures:** En signerad presentation kan ge en varning under laddning om att dess signatur går förlorad under bearbetning. Aspose.Slides rapporterar detta `DataLoss`‑tillstånd via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationsignedwarninginfo/). En callback i laddningsstadiet låter applikationen avvisa filen eller explicit acceptera den rapporterade förlusten.
- **Font substitution:** Ett otillgängligt teckensnitt kan ersättas medan en bild renderas eller exporteras. Varningar om teckensnittsersättning rapporteras som `DataLoss`, så den strikta policyn ovan avbryter även om applikationen skulle anse ersättningen visuellt acceptabel. För att observera detta beteende, använd en input‑presentation som innehåller text i ett teckensnitt som inte finns tillgängligt för körningen. Varningsbeskrivningen identifierar ersättningen; konfigurera de nödvändiga teckensnitten eller [font substitution rules](/slides/sv/nodejs-java/font-substitution/) innan du försöker igen.
- **Unsupported or unexpected content:** En laddare kan stöta på presentationsposter eller funktioner den inte känner igen. Sådana varningar kan använda `UnexpectedContent`, eller en allvarligare kategori när data eller formatering är känt att påverkas.
- **Format compatibility:** Sparning till ett annat presentationsformat kan utelämna funktioner eller skapa ett resultat som beter sig annorlunda i vissa program. Till exempel rapporterar sparning av en presentation med mer än åtta horisontella eller åtta vertikala ritningsguider till äldre PPT ett `CompatibilityIssue`. Callbacken i sparningsstadiet kan registrera förlusten och fortsätta, eller avvisa den om alla guider måste bevaras.
- **Loading behavior:** Laddningsalternativ och äldre beteenden kan också ge varningar. Till exempel identifierar [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) användning av ett föråldrat presentations‑låsningsbeteende som ett `CompatibilityIssue`.

Varningar beror på källdokumentet, målformatet, operationen och Aspose.Slides‑versionen. Anta inte att varje fil ger en varning eller att ett scenario alltid matchar endast en kategori.

## **Hantera Avbrutna Operationer På Ett Säkert Sätt**

När en callback returnerar `ReturnAction.Abort` får du inte använda ett objekt som misslyckades att laddas och får inte anta att en renderings‑ eller sparutdata är fullständig. Operationen kan avslutas efter att en utdatafil har skapats men innan den är färdig.

Spara validerade resultat till en separat sökväg, t.ex. `validated-output.pptx`. Ersätt en befintlig presentation först när operationen har slutförts framgångsrikt, varningsrapporten uppfyller applikationspolicyn och utdata kan öppnas och kontrolleras. Detta undviker att skriva över en giltig källfil med ett partiellt eller avvisat resultat.

En tom varningsrapport garanterar inte att alla källfunktioner har bevarats. Applicera eventuella ytterligare innehålls‑ och visuella kontroller som krävs av applikationen. Se också [Open Presentations](/slides/sv/nodejs-java/open-presentation/) och [Save Presentations](/slides/sv/nodejs-java/save-presentation/).

## **FAQ**

**Kan en varningscallback hantera varje Aspose.Slides‑fel?**

Nej. Den hanterar återställningsbara förhållanden som rapporteras som varningar. Undantag som uppstår oberoende av callbacken måste hanteras av applikationen runt laddnings‑, renderings‑, konverterings‑ eller sparningsanropet.

**Garanterar att returnera `ReturnAction.Continue` ett identiskt utdata?**

Nej. Det tillåter bara att behandlingen fortsätter. Det rapporterade tillståndet kan fortfarande orsaka data‑, formaterings‑ eller kompatibilitetsavvikelser, så granska de insamlade varningstyperna och beskrivningarna.

**Hur kan en applikation identifiera vilken operation som genererade en varning?**

Skapa en callback‑instans för varje operation och lagra ett applikations‑definierat steg tillsammans med värdena som returneras av [getWarningType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getWarningType--) och [getDescription](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarninginfo/#getDescription--), som visas i exemplet.