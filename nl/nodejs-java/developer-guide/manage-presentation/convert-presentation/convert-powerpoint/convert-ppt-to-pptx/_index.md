---
title: PPT converteren naar PPTX in Node.js
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
description: "Converteer legacy PPT‑bestanden naar PPTX in Node.js met Aspose.Slides. Bevat JavaScript‑voorbeelden voor enkel‑bestand‑ en batch‑conversie, foutafhandeling en nauwkeurigheidsopmerkingen."
---
## **Overzicht**

PPT is het verouderde binaire PowerPoint‑formaat, terwijl PPTX het nieuwere Open XML‑formaat is. Aspose.Slides voor Node.js via Java kan een PPT‑bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel toont hoe u één bestand of een map met bestanden kunt converteren en legt uit wat u na de conversie moet controleren.

## **Een PPT‑bestand naar PPTX converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse en roep vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) aan met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/). Het `finally`‑blok verwijdert de presentatie en geeft de resources vrij.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Laad de oude PPT‑presentatie.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Sla de presentatie op in PPTX‑formaat.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De bestandsextensie bepaalt niet automatisch het uitvoerformaat; dat doet het argument [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/). Houd de invoer‑ en uitvoer‑paden verschillend als u het oorspronkelijke PPT‑bestand wilt behouden.

## **Meerdere PPT‑bestanden converteren**

Het volgende voorbeeld converteert elk `.ppt`‑bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat een mislukte conversie de rest van de batch niet stopt.

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

Voor productie‑omgevingen moet u de volledige fout loggen, bepalen of een bestaand uitvoerbestand overschreven mag worden, en de namen van mislukte bestanden naar een retry‑ of review‑wachtrij schrijven. Beschadigde bestanden, met een wachtwoord beveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet‑ondersteunde inhoud kunnen allemaal een conversie laten mislukken. Zie [Password-Protected Presentations](/slides/nl/nodejs-java/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en verouderde functies**

Conversie behoudt normaal gesproken dia's, master‑dia’s, lay‑outs, tekst, vormen, afbeeldingen, tabellen en grafieken. Echter, PPT en PPTX vertegenwoordigen niet elke functie op exact dezelfde manier. Een verouderde functie zonder PPTX‑equivalent, of die niet door de bibliotheek wordt ondersteund, kan genormaliseerd, weggelaten of anders weergegeven worden.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingebedde of gekoppelde OLE‑objecten, ActiveX‑besturingselementen, ingebedde media, ongebruikelijke lettertypen of VBA‑macro’s bevat. Een gewone PPTX‑file is geen macro‑ingeschakelde indeling, dus gebruik een geschikt macro‑ingeschakeld workflow wanneer VBA beschikbaar moet blijven. Controleer ook dat vereiste lettertypen en externe bronnen aanwezig zijn in de omgeving waarin de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten dient u de gegenereerde PPTX programmatisch opnieuw te openen en de belangrijkste dia‑aantallen en inhoud te inspecteren, waarna u het uiterlijk en het diavoorstelling‑gedrag in de beoogde viewer vergelijkt. Beschouw een succesvolle [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save)‑aanroep niet als bewijs dat elke verouderde functie een exacte PPTX‑representatie heeft.

## **Wanneer PPTX gebruiken**

Gebruik PPTX wanneer de presentatie bewerkt zal worden in huidige PowerPoint‑versies, wordt uitgewisseld met systemen die met Open XML‑pakketten werken, of wordt opgeslagen in een formaat dat makkelijker te inspecteren en te herstellen is dan het verouderde binaire PPT. Bewaar het oorspronkelijke PPT als een archief‑ of rollback‑kopie totdat de geconverteerde presentatie uw nauwkeurigheidscontroles heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander outputtype nodig hebt, gebruik dan de format‑specifieke richtlijnen in [Convert Presentations to Multiple Formats](/slides/nl/nodejs-java/convert-presentation/) in plaats van aan te nemen dat alle doelen bewerkbare PowerPoint‑functies behouden.

## **Online‑converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT to PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batchverwerking of foutafhandeling op applicatieniveau, gebruik de Node.js via Java‑API.

## **Gerelateerde artikelen**

- [PPT vs PPTX](/slides/nl/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/slides/nl/nodejs-java/save-presentation/)
- [Supported File Formats](/slides/nl/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/slides/nl/nodejs-java/open-presentation/)

## **FAQ**

**Kan ik PPT naar PPTX converteren zonder dat Microsoft PowerPoint geïnstalleerd is?**

Ja. Aspose.Slides voor Node.js via Java laadt en slaat presentaties op zonder dat Microsoft PowerPoint vereist is.

**Zal de PPT‑naar‑PPTX conversie alle inhoud exact behouden?**

Het behoudt de gangbare presentatiedata, maar exacte nauwkeurigheid is niet gegarandeerd voor elke verouderde of niet‑ondersteunde functie. Controleer het gegenereerde bestand wanneer het macro’s, OLE‑ of ActiveX‑objecten, media, gespecialiseerde animaties of ongebruikelijke lettertypen bevat.

**Kan ik een met wachtwoord beveiligd PPT‑bestand converteren?**

Ja, als u het juiste wachtwoord opgeeft bij het laden van het bestand. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat de laadoperatie mislukt.

**Moet ik het PPT‑bestand na conversie verwijderen?**

Bewaar het origineel totdat u de PPTX heeft gecontroleerd in de viewers en workflows die voor u van belang zijn. Dit biedt een rollback‑kopie als een verouderde functie anders wordt geconverteerd.