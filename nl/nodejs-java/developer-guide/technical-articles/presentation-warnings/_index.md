---
title: Beheer presentatiewaarschuwingen in Node.js
type: docs
weight: 90
url: /nl/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwingscallback
- waarschuwingsbeleid
- dataverlies
- broncorruptie
- compatibiliteitsprobleem
- lettertypevervanging
- digitale handtekening
- presentatie laden
- presentatie renderen
- presentatieconversie
- presentatie opslaan
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt verzamelen, classificeren en behandelen tijdens het laden, renderen, converteren en opslaan van presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides kan herstelbare problemen rapporteren tijdens het laden, renderen, converteren of opslaan van een presentatie. Voorbeelden zijn beschadigde bronrecords, inhoud die niet behouden kan blijven, lettertypevervanging en beperkingen van een doelindeling. Een waarschuwingscallback stelt een toepassing in staat deze situaties vast te leggen en te bepalen of de huidige bewerking kan doorgaan.

Gebruik `java.newProxy` om de [IWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarningcallback/) Java‑interface in JavaScript te implementeren en bekijk de waarden van [getWarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) die worden geleverd via [IWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/). Retourneer [ReturnAction.Continue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/returnaction/#Continue) om de waarschuwing te accepteren of [ReturnAction.Abort](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/returnaction/#Abort) om de bewerking te stoppen.

Gebruik [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) voor waarschuwingen die worden gegenereerd bij het openen van een presentatie. Rendering‑ en exportoptieklassen erven van [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), die waarschuwingen ontvangt van slide‑rendering, conversie en opslaan. Omdat de waarschuwing zelf de toepassingsbewerking niet identificeert, koppelt u elke callback‑instantie aan een bewerkingsfase bij het samenstellen van een gecombineerd rapport.

## **Waarschuwingen en uitzonderingen**

Een waarschuwing beschrijft een situatie waarin Aspose.Slides kan herstellen als de callback `ReturnAction.Continue` retourneert. Een uitzondering betekent dat de gevraagde bewerking niet normaal kan worden voltooid; uitzonderingen worden niet omgezet in waarschuwingen en kunnen niet worden afgehandeld door een waarschuwingsbeleid.

Het retourneren van `ReturnAction.Abort` vraagt de waarschuwingsdispatcher de huidige bewerking te beëindigen door een uitzondering op te werpen. De openbare uitzondering hangt af van de bewerking en het presentatieformaat. Bijvoorbeeld, bij het laden kan een [PptxReadException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxreadexception/) of een [PptReadException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptreadexception/) optreden, terwijl bij opslaan of exporteren een [PptxException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxexception/) kan verschijnen. Vang de fout van de Java‑bridge op het einde van de bewerking op en gebruik het waarschuwingsrapport om te bepalen of het toepassingsbeleid de beëindiging heeft veroorzaakt in plaats van te vertrouwen op één type uitzondering of bericht. De callback legt de waarschuwing vast voordat `ReturnAction.Abort` wordt geretourneerd, zodat de reden beschikbaar blijft voor de toepassing.

## **Waarschuwingscategorieën**

De [WarningType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/)‑klasse biedt integer‑constanten voor de volgende categorieën:

| Waarschuwingstype | Betekenis | Typisch beleid |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | De bronpresentatie bevat corruptie die een document dat in het originele formaat is opgeslagen onbruikbaar kan maken. | Afbreken. |
| [DataLoss](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/#DataLoss) | Tekst, grafieken, afbeeldingen of andere data kunnen ontbreken na het laden of opslaan. | Afbreken. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | De presentatie kan belangrijke opmaak verliezen. | Afbreken in strikte validatiemodus; anders vastleggen en doorgaan. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Er kan een beperkte opmaakverschil optreden. | Vastleggen voor diagnostiek en doorgaan. |
| [CompatibilityIssue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Het resultaat opent mogelijk niet of gedraagt zich niet correct in sommige applicaties of oudere versies. | Loggen en doorgaan tenzij compatibiliteit verplicht is. |
| [UnexpectedContent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | De bron bevat niet‑ondersteunde of niet‑herkende inhoud waarvan het effect nog niet bekend is. | Vastleggen en doorgaan, of behandelen als een fout bij een strikt beleid. |

De categorie moet de beleidsbeslissing sturen. Sla de waarde op die door [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) wordt geretourneerd voor diagnostiek, maar baseer de toepassingslogica niet op de precieze formulering, want de berichttekst kan verschillen per waarschuwingsscenario en productversie.

## **Verzamel en classificeer waarschuwingen**

Het volgende JavaScript‑voorbeeld gebruikt één toepassingsniveau‑rapport voor de volledige verwerkingspipeline. Een afzonderlijke callback‑instantie labelt waarschuwingen van laden, renderen, PDF‑conversie en PPTX‑opslaan. Het beleid breekt af bij broncorruptie of gegevensverlies, breekt eventueel af bij grote opmaakverlies, en gaat door bij andere waarschuwingen.

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

Geef `false` op voor `abortOnMajorFormattingLoss` wanneer u `WarningPolicy` construeert als grote opmaakverschillen acceptabel zijn. Compatibiliteitsproblemen, klein opmaakverlies en onverwachte inhoud blijven toch in het rapport aanwezig, zelfs wanneer de bewerking doorgaat. Breid `WarningPolicy.getAction` uit als de toepassing een van die categorieën moet afwijzen.

## **Veelvoorkomende waarschuwingsscenario's**

- **Digitale handtekeningen:** Een gesigneerde presentatie kan tijdens het laden een waarschuwing geven dat de handtekening verloren gaat tijdens de verwerking. Aspose.Slides rapporteert deze `DataLoss`‑situatie via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationsignedwarninginfo/). Een callback in de laadfase stelt de toepassing in staat het bestand te weigeren of de gemelde verlies expliciet te aanvaarden.
- **Lettertypevervanging:** Een niet‑beschikbaar lettertype kan worden vervangen terwijl een dia wordt gerenderd of geëxporteerd. Waarschuwingen over lettertypevervanging worden gerapporteerd als `DataLoss`, zodat het strikte beleid hierboven afbreekt, zelfs als de toepassing een bepaalde vervanging visueel acceptabel zou vinden. Om dit gedrag te observeren, gebruikt u een invoerpresentatie met tekst in een lettertype dat niet beschikbaar is voor de runtime. De waarschuwingsbeschrijving identificeert de vervanging; configureer de benodigde lettertypen of [lettertypevervangingsregels](/slides/nl/nodejs-java/font-substitution/) voordat u het opnieuw probeert.
- **Niet‑ondersteunde of onverwachte inhoud:** Een loader kan presentatie‑records of functies tegenkomen die hij niet herkent. Dergelijke waarschuwingen kunnen `UnexpectedContent` gebruiken, of een ernstigere categorie wanneer data of opmaak bekend is aangetast.
- **Formaatcompatibiliteit:** Opslaan naar een ander presentatieformaat kan functies weglaten of een resultaat opleveren dat zich anders gedraagt in sommige applicaties. Bijvoorbeeld, het opslaan van een presentatie met meer dan acht horizontale of acht verticale tekengidsen naar legacy PPT meldt een `CompatibilityIssue`. De callback in de bewaar‑fase kan het verlies vastleggen en doorgaan, of het weigeren als het behouden van alle gidsen vereist is.
- **Laadgedrag:** Laadopties en legacy‑gedragingen kunnen ook waarschuwingen genereren. Bijvoorbeeld, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identificeert het gebruik van een verouderd presentatielock‑gedrag als een `CompatibilityIssue`.

Waarschuwingen hangen af van het brondocument, het doelformaat, de bewerking en de Aspose.Slides‑versie. Ga er niet van uit dat elk bestand een waarschuwing oplevert of dat een scenario altijd alleen in één categorie valt.

## **Veilig omgaan met afgebroken bewerkingen**

Wanneer een callback `ReturnAction.Abort` retourneert, gebruik dan geen object dat niet is geladen en ga er niet van uit dat een render‑ of opslaagoutput compleet is. De bewerking kan beëindigen nadat een uitvoerbestand is aangemaakt maar voordat het volledig is voltooid.

Sla gevalideerde resultaten op naar een apart pad, bijvoorbeeld `validated-output.pptx`. Vervang een bestaande presentatie alleen nadat de bewerking succesvol is afgerond, het waarschuwingsrapport voldoet aan het toepassingsbeleid, en de uitvoer kan worden geopend en gecontroleerd. Dit voorkomt het overschrijven van een geldig bronbestand met een gedeeltelijk of afgewezen resultaat.

Een leeg waarschuwingsrapport garandeert niet dat elke bronfunctie behouden is gebleven. Pas eventuele aanvullende inhoud‑ en visuele controles toe die de toepassing vereist. Zie ook [Open presentaties](/slides/nl/nodejs-java/open-presentation/) en [Opslaan presentaties](/slides/nl/nodejs-java/save-presentation/).

## **FAQ**

**Kan een waarschuwingscallback elke Aspose.Slides‑fout afhandelen?**

Nee. Het behandelt herstelbare situaties die als waarschuwingen worden gerapporteerd. Uitzonderingen die onafhankelijk van de callback optreden, moeten door de toepassing rond de laad‑, render‑, conversie‑ of opslaag‑aanroep worden behandeld.

**Garandeert het retourneren van `ReturnAction.Continue` identieke output?**

Nee. Het staat alleen toe dat de verwerking doorgaat. De gerapporteerde situatie kan nog steeds leiden tot verschillen in data, opmaak of compatibiliteit, dus controleer de verzamelde waarschuwingssoorten en beschrijvingen.

**Hoe kan een toepassing de bewerking identificeren die een waarschuwing heeft veroorzaakt?**

Maak voor elke bewerking een callback‑instantie en sla een door de toepassing gedefinieerde fase op samen met de waarden die door [getWarningType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getWarningType--) en [getDescription](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarninginfo/#getDescription--) worden geretourneerd, zoals weergegeven in het voorbeeld.