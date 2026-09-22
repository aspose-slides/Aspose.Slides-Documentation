---
title: Bepaal het originele presentatiesformaat in Node.js
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/nodejs-java/detect-presentation-source-format/
keywords:
- bronformaat
- detecteer presentatiesformaat
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lees het originele formaat van een geladen presentatie in Node.js met Aspose.Slides voor Node.js via Java, vergelijk detectie-API's en verwerk bestanden, streams en legacy-formaten."
---
## **Overzicht**

Na het laden van een presentatie, roep de [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSourceFormat) methode aan om het oorspronkelijke formaat te bepalen. Gebruik deze wanneer latere verwerking afhankelijk is van het formaat waarvan de huidige instantie is geladen.

Het bronformaat verschilt van het [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) dat is geselecteerd voor een uitvoerbestand. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

## **Lees het bronformaat van een bestand**

Dit voorbeeld vereist een bestaand bestand `sample.pptx`. Het laadt het bestand en selecteert een toepassingsverwerkingsbeleid met behulp van [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSourceFormat), in plaats van de bestandsnaam. Wijzig het invoerpad om andere formaten te proberen. Het voorbeeld drukt het geselecteerde beleid af; vervang de berichten door uw eigen toepassingslogica.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Herken de ondersteunde waarden**

De klasse [SourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sourceformat/) definieert gehele getalconstanten die de volgende presentatieformaten onderscheiden. De onderstaande extensies zijn conventionele extensies, geen reconstructie van de originele bestandsnaam.

| SourceFormat‑waarde | Extensie | Formaat |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentatie 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentatie |
| `Pptm` | `.pptm` | Macro‑ingeschakelde Office Open XML‑presentatie |
| `Pps` | `.pps` | PowerPoint‑diavoorstelling 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑ingeschakelde Office Open XML‑diavoorstelling |
| `Pot` | `.pot` | PowerPoint‑sjabloon 97–2003 |
| `Potx` | `.potx` | Office Open XML‑sjabloon |
| `Potm` | `.potm` | Macro‑ingeschakelde Office Open XML‑sjabloon |
| `Odp` | `.odp` | OpenDocument‑presentatie |
| `Otp` | `.otp` | OpenDocument‑presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF‑presentatie |
| `Xml` | `.xml` | PowerPoint‑XML‑presentatie |

## **Lees het bronformaat van een stream**

Dit voorbeeld vereist een bestaand bestand `sample.pps`. Het lezen van de bytes naar een geheugen‑stream modelleert invoer ontvangen zonder bestandsnaam, bijvoorbeeld een database‑waarde of een geüploade byte‑array. De [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) constructor ontvangt alleen de stream.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij het laden via een bestandspad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy‑PPS‑ en‑POT‑inhoud worden gerapporteerd als `SourceFormat.Ppt`; het PPS‑voorbeeld hierboven drukt de gehele waarde van `SourceFormat.Ppt` af.

Als uw applicatie het onderscheid moet behouden, bewaar dan de originele bestandsnaam of sub‑type metadata apart. Een extensie is een nuttige hint voor deze legacy‑subtypen, maar mag niet de enige basis zijn voor het identificeren van willekeurige presentatiedata.

## **Vergelijk detectie vóór en na het laden**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) en [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) wanneer u een bestand moet inspecteren vóór het laden van het volledige presentatiemodel. Gebruik [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSourceFormat) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en drukt de gehele waarden van `LoadFormat.Pptx` en `SourceFormat.Pptx` respectievelijk af. In productie kiest u de API die past bij uw verwerkingsstadium; een al geladen presentatie heeft geen tweede inspectie nodig uitsluitend om het bronformaat te verkrijgen.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

De resultaten gebruiken constanten uit verschillende klassen: [LoadFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sourceformat/). Vergelijk hun numerieke waarden niet en ga er niet van uit dat elk formaat identieke detectieresultaten oplevert. PowerPoint XML kan vóór het laden gerapporteerd worden als `LoadFormat.Unknown` en na het laden als `SourceFormat.Xml`.

## **Houd bron- en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het drukt de gehele waarde van `SourceFormat.Pptx` zowel vóór als na het opslaan van de originele instantie af. Alleen de nieuwe instantie geladen vanuit de ODP‑uitvoer rapporteert `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Een presentatie die van nul wordt aangemaakt met `new Presentation()` rapporteert `SourceFormat.Pptx`. Deze heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw aangemaakte instantie, niet bewijs dat er een PPTX‑bestand is geladen. Houd bij of uw applicatie de instantie heeft aangemaakt of geladen, wanneer dat onderscheid van belang is.

## **Koppel een bronformaat aan een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het koppelt elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sourceformat/) waarde aan een conventionele extensie, zonder de invoer‑bestandsnaam te ontleden. De fallback voorkomt dat stilzwijgend een extensie wordt toegekend aan een niet‑herkende waarde.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Deze koppeling converteert geen bestand of herstelt geen legacy PPS/POT‑subtype dat verloren ging tijdens het laden van een stream. Voor daadwerkelijk opslaan, selecteer expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) of gebruik de conversie die wordt getoond in [Save Presentations in Their Original Format](/slides/nl/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door op te slaan en opnieuw te openen**

Dit zelfstandige voorbeeld maakt een presentatie aan en schrijft drie bestanden in de werkmap, waarbij bestaande bestanden met dezelfde namen worden overschreven. Het opent elke uitvoer opnieuw, zowel via pad als via een geheugen‑stream. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert het laden via pad `Pps`, terwijl het laden van dezelfde bytes zonder bestandsnaam `Ppt` rapporteert.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

De volgende tabel vat de identificatie van bronformaten samen voor presentaties met overeenkomende extensies. Namen duiden constanten aan; de JavaScript‑voorbeelden drukken hun gehele waarden af:

| Opgeslagen formaat | SourceFormat vanaf een bestandspad | SourceFormat vanaf een naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectievelijk | Zelfde als bestandspad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectievelijk | Zelfde als bestandspad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectievelijk | Zelfde als bestandspad |
| ODP, OTP | `Odp`, `Otp` respectievelijk | Zelfde als bestandspad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑inhoud wordt geïdentificeerd als `Ppt` voor naamloze streams. De tabel beschrijft identificatie van formaten, niet het behoud van elke presentatiefunctie tijdens conversie.

## **FAQ**

**Verandert het opslaan naar ODP het bronformaat van een presentatie geladen vanuit PPTX?**

Nee. De bestaande instantie rapporteert nog steeds `Pptx`. Een instantie geladen vanuit het opgeslagen ODP‑bestand rapporteert `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welk API moet ik gebruiken als de presentatie al geladen is?**

Lees [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSourceFormat). Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) voor inspectie vóór het laden.