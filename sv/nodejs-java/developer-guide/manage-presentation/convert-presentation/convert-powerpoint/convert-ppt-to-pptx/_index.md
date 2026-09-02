---
title: "Konvertera PPT till PPTX i Node.js"
linktitle: "PPT till PPTX"
type: docs
weight: 20
url: /sv/nodejs-java/convert-ppt-to-pptx/
keywords:
  - "konvertera PowerPoint"
  - "konvertera presentation"
  - "konvertera bild"
  - "konvertera PPT"
  - "PPT till PPTX"
  - "spara PPT som PPTX"
  - "exportera PPT till PPTX"
  - "PowerPoint"
  - "presentation"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "Konvertera äldre PPT-filer till PPTX i Node.js med Aspose.Slides. Inkluderar JavaScript-exempel för enkel‑fil och batchkonvertering, felhantering och noggrannhetsanteckningar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides för Node.js via Java kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur du konverterar en fil eller en katalog med filer och förklarar vad som ska kontrolleras efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/). `finally`‑blocket disponerar presentationen och frigör dess resurser.

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

Filändelsen väljer inte utmatningsformatet i sig; argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) gör det. Håll indata‑ och utdatasökvägarna olika om du måste behålla original‑PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av satsen.

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

För produktionsbelastningar, logga hela felet, avgör om en befintlig utdatafil får skrivas över, och skriv misslyckade filnamn till en återförsöks‑ eller granskningskö. Skadade filer, lösenordsskyddade filer som öppnas utan korrekt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla få konverteringen att misslyckas. Se [Password-Protected Presentations](/slides/sv/nodejs-java/password-protected-presentation/) för inläsning av krypterade filer.

## **Noggrannhet och äldre funktioner**

Konverteringen bevarar normalt bilder, master‑bilder, layouter, text, former, bilder, tabeller och diagram. Dock representerar inte PPT och PPTX varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande PPTX‑version, eller som inte stöds av biblioteket, kan normaliseras, utelämnas eller visas annorlunda.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑styrningar, inbäddade media, ovanliga typsnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makronyckalkformat, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste finnas kvar. Verifiera också att nödvändiga typsnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programatiskt och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Betrakta inte ett lyckat anrop till [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) som bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När du ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella PowerPoint‑versioner, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är enklare att granska och återställa än det äldre binära PPT‑formatet. Behåll original‑PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller någon annan utdatatyp, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/slides/sv/nodejs-java/convert-presentation/) i stället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT‑till‑PPTX‑konverterare](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑behandling eller felhantering på applikationsnivå, använd Node.js via Java‑API‑et.

## **Relaterade artiklar**

- [PPT vs PPTX](/slides/sv/nodejs-java/ppt-vs-pptx/)
- [Spara presentationer i Node.js](/slides/sv/nodejs-java/save-presentation/)
- [Filformat som stöds](/slides/sv/nodejs-java/supported-file-formats/)
- [Öppna presentationer i Node.js](/slides/sv/nodejs-java/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides för Node.js via Java läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet garanteras inte för varje äldre eller ej‑stött funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga typsnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när filen läses in. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag ta bort PPT‑filen efter konvertering?**

Behåll originalet tills du har verifierat PPTX‑filen i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras annorlunda.