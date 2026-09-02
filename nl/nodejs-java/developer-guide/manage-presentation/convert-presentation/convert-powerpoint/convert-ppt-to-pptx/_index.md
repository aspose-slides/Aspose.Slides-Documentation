---
title: PPT naar PPTX converteren in Node.js
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPT naar PPTX
- PPT opslaan als PPTX
- PPT exporteren naar PPTX
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer legacy PPT-bestanden naar PPTX in Node.js met Aspose.Slides. Bevat JavaScript-voorbeelden voor enkele bestanden en batchconversie, foutafhandeling en notities over nauwkeurigheid."
---
## **Overzicht**

PPT is het legacy binaire PowerPoint-formaat, terwijl PPTX het nieuwere Open XML-formaat is. Aspose.Slides for Node.js via Java kan een PPT‑bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel laat zien hoe u één bestand of een map met bestanden kunt converteren en legt uit wat u moet controleren na de conversie.

## **Een PPT‑bestand converteren naar PPTX**

Laad het bronbestand met de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) en roep vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) aan met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/). Het `finally`‑blok maakt de presentatie vrij en geeft de resources vrij.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Laad de legacy PPT-presentatie.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Sla de presentatie op in PPTX-formaat.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De bestands­extensie bepaalt niet automatisch het uitvoerformaat; het argument [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) doet dat. Houd de invoer‑ en uitvoer‑paden verschillend als u het originele PPT‑bestand wilt behouden.

## **Meerdere PPT‑bestanden converteren**

Het volgende voorbeeld converteert elk `.ppt`‑bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat één mislukte conversie de rest van de batch niet stopt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Voor productie‑omgevingen dient u de volledige fout te loggen, te bepalen of een bestaand uitvoerbestand kan worden overschreven, en de namen van mislukte bestanden naar een retry‑ of review‑queue te schrijven. Beschadigde bestanden, met een wachtwoord beveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet‑ondersteunde inhoud kunnen allemaal een conversie doen mislukken. Zie [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en legacy‑functies**

Conversie behoudt normaal gesproken dia's, masters, lay-outs, tekst, vormen, afbeeldingen, tabellen en grafieken. Echter, PPT en PPTX vertegenwoordigen niet elke functie op exact dezelfde manier. Een legacy‑functie zonder PPTX‑equivalent, of die niet door de bibliotheek wordt ondersteund, kan genormaliseerd, weggelaten of anders weergegeven worden.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingesloten of gekoppelde OLE‑objecten, ActiveX‑besturingselementen, ingesloten media, ongebruikelijke lettertypen of VBA‑macro's bevat. Een eenvoudig PPTX‑bestand is geen macro‑ondersteund formaat, dus gebruik een geschikt macro‑ondersteund werkproces wanneer VBA beschikbaar moet blijven. Controleer bovendien of vereiste lettertypen en externe middelen aanwezig zijn in de omgeving waarin de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten, open de gegenereerde PPTX programmeringsmatig opnieuw en inspecteer belangrijke dia‑aantallen en inhoud, en vergelijk vervolgens het uiterlijk en het diavoorstellings‑gedrag in de beoogde viewer. Beschouw een succesvolle aanroep van [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) niet als bewijs dat elke legacy‑functie een exacte PPTX‑representatie heeft.

## **Wanneer PPTX te gebruiken**

Gebruik PPTX wanneer de presentatie wordt bewerkt in huidige PowerPoint‑versies, wordt uitgewisseld met systemen die met Open XML‑pakketten werken, of wordt opgeslagen in een formaat dat makkelijker te inspecteren en te herstellen is dan het legacy‑binaire PPT. Bewaar het oorspronkelijke PPT als een archief‑ of rollback‑kopie totdat de geconverteerde presentatie uw nauwkeurigheidscontroles heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander type uitvoer nodig heeft, gebruik dan de formaat‑specifieke richtlijnen in [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) in plaats van aan te nemen dat alle doelen bewerkbare PowerPoint‑functies behouden.

## **Online‑converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT naar PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batchverwerking of foutafhandeling op applicatieniveau, gebruik de Node.js via Java‑API.

## **Gerelateerde artikelen**

- [PPT versus PPTX](/nodejs-java/ppt-vs-pptx/)
- [Presentaties opslaan in Node.js](/nodejs-java/save-presentation/)
- [Ondersteunde bestandsformaten](/nodejs-java/supported-file-formats/)
- [Presentaties openen in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**Kan ik PPT naar PPTX converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja. Aspose.Slides for Node.js via Java laadt en slaat presentaties op zonder dat Microsoft PowerPoint vereist is.

**Zal de PPT‑naar‑PPTX‑conversie alle inhoud exact behouden?**

Het behoudt de algemene presentatiewaarde, maar exacte nauwkeurigheid is niet gegarandeerd voor elke legacy‑ of niet‑ondersteunde functie. Controleer het gegenereerde bestand wanneer het macro’s, OLE‑ of ActiveX‑objecten, media, gespecialiseerde animaties of ongebruikelijke lettertypen bevat.

**Kan ik een wachtwoord‑beveiligd PPT‑bestand converteren?**

Ja, als u het juiste wachtwoord opgeeft bij het laden van het bestand. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat het laden mislukt.

**Moet ik het PPT‑bestand na de conversie verwijderen?**

Bewaar het origineel tot u de PPTX hebt geverifieerd in de viewers en werkstromen die voor u van belang zijn. Dit biedt een rollback‑kopie als een legacy‑functie anders wordt geconverteerd.