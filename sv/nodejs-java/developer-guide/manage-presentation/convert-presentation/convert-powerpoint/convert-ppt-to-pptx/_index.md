---
title: Konvertera PPT till PPTX i Node.js
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/nodejs-java/convert-ppt-to-pptx/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- PPT till PPTX
- spara PPT som PPTX
- exportera PPT till PPTX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i Node.js med Aspose.Slides. Inkluderar JavaScript-exempel för enstaka fil- och batchkonvertering, felhantering och noggrannhetsanteckningar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides för Node.js via Java kan läsa en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Den här artikeln visar hur du konverterar en fil eller en katalog med filer och förklarar vad du bör kontrollera efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) med argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/). `finally`‑blocket frigör presentationen och dess resurser.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Läs in den äldre PPT-presentationen.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Spara presentationen i PPTX-format.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Filändelsen väljer inte output‑formatet automatiskt; det gör argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/). Håll in‑ och utdata‑sökvägarna olika om du behöver behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Exemplet nedan konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

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

För produktionsarbetsbelastningar, logga hela felet, avgör om en befintlig utdatafil får skrivas över, och skriv misslyckade filnamn till en återförsök‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan rätt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla orsaka att en konvertering misslyckas. Se [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) för att läsa in krypterade filer.

## **Noggrannhet och äldre funktioner**

Konvertering bevarar normalt bilder, masterbilder, layouter, text, former, bilder, tabeller och diagram. Dock representerar PPT och PPTX inte varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande i PPTX eller som inte stöds av biblioteket kan normaliseras, utelämnas eller visas på ett annat sätt.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade media, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programvarumässigt igen och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Behandla inte ett lyckat anrop av [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) som bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När du bör använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella versioner av PowerPoint, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller en annan utdata‑typ, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) istället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT to PPTX converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑behandling eller felhantering på applikationsnivå, använd Node.js via Java‑API:et.

## **Relaterade artiklar**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **Vanliga frågor**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides för Node.js via Java läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet kan inte garanteras för varje äldre eller ej‑stödd funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialanimeringar eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när filen läses in. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag ta bort PPT‑filen efter konverteringen?**

Behåll den ursprungliga filen tills du har verifierat PPTX‑filen i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopi om en äldre funktion konverteras på ett annat sätt.