---
title: Konvertera PowerPoint till PDF i Node.js via .NET
linktitle: PowerPoint till PDF
type: docs
weight: 30
url: /sv/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint till PDF
- konvertera PowerPoint till PDF
- PPTX till PDF
- PPT till PDF
- ODP till PDF
- spara presentation som PDF
- PDF/A
- PdfOptions
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PPTX-, PPT- och ODP-presentationer till PDF i JavaScript med Aspose.Slides för Node.js via .NET, och skapa arkiv-PDF/A-filer med PdfOptions."
---
## **Översikt**

Aspose.Slides for Node.js via .NET konverterar PowerPoint- och OpenDocument-presentationer till PDF utan Microsoft PowerPoint. Varje synlig bild blir en PDF-sida med samma storlek som bilden, och texten förblir markerbar och sökbar. Denna artikel visar standardkonverteringen och en konvertering till PDF/A med [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

Exemplen förutsätter en presentation med namnet `sample.pptx` i projektmappen som du har skapat i [Installation](/slides/sv/nodejs-net/installation/). Vilken PowerPoint-presentation som helst fungerar. Spara varje exempel som en `.js`-fil i projektmappen och kör den från den mappen med `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET har ingen egen API-referens. Den speglar Aspose.Slides for .NET API med camelCase-namn, så API-länkarna i den här artikeln leder till de matchande klasserna och medlemmarna i [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Konvertera en presentation till PDF**

För att konvertera en presentation till PDF, följ dessa steg:

1. Öppna presentationen genom att skicka dess sökväg till konstruktorn [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Samma kod fungerar för PPTX-, PPT- och ODP‑filer.
2. Anropa metoden [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) med utsökvägen och `SaveFormat.Pdf`.
3. Anropa `dispose` i ett `finally`‑block för att frigöra .NET‑resurserna som stödjer presentationen.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Skriptet skriver `sample.pdf` till projektmappen. Konverteringen använder standardinställningarna: varje bild som inte är dold blir en sida, i bildordning. Utan licens visas även en utvärderingsvattenstämpel på varje sida; se [Licensing](/slides/sv/nodejs-net/licensing/).

## **Konvertera en presentation till PDF/A**

För att styra utdata, skicka ett [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑objekt som det tredje argumentet till `save`. Följande exempel sätter egenskapen [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) till `PdfCompliance.PdfA2b`, vilket producerar en PDF/A-2b‑fil. PDF/A är ISO‑standarden för långtidsarkivering: bland annat kräver den att varje teckensnitt som dokumentet använder är inbäddat i filen.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Skriptet skriver `sample-pdfa.pdf` med samma sidor som standardkonverteringen. För att bekräfta att en fil uppfyller standarden, kontrollera den med en PDF/A‑validator såsom [veraPDF](https://verapdf.org/). Andra värden för [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) väljer andra standarder, som `PdfA1b`, `PdfA2a` eller `PdfUa` för åtkomst.

## **Vanliga frågor**

**Hur inkluderar jag dolda bilder i PDF:en?**

Dolda bilder hoppas över som standard. Sätt egenskapen [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) på `PdfOptions` till `true` och skicka alternativen till `save`.

**Kan jag skydda PDF:en med ett lösenord?**

Ja. Sätt egenskapen [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) på `PdfOptions` innan du anropar `save`. PDF‑läsare frågar då efter lösenordet innan de öppnar filen.

**Kan jag konvertera endast några av bilderna?**

Ja. Skicka en array med bildpositioner som det fjärde argumentet till `save`. Positioner börjar på 1, och det tredje argumentet kan vara `null` om du inte behöver några alternativ: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` skriver en PDF med den första och tredje bilden.

**Varför ser texten annorlunda ut när jag konverterar på Linux?**

Aspose.Slides kan endast använda teckensnitt som är installerade på maskinen som kör konverteringen. När en presentation använder ett teckensnitt som saknas, till exempel Calibri på en vanlig Linux‑server, använder Aspose.Slides ett installerat teckensnitt i dess ställe, vilket kan förändra hur texten ser ut och var radbrytningar sker. Installera de teckensnitt som dina presentationer använder för att få samma resultat som på Windows.

**Kan jag få PDF:en som en Buffer istället för en fil?**

Ja. `presentation.saveToBuffer(SaveFormat.Pdf)` returnerar PDF:en som en Node.js `Buffer`, vilket är praktiskt när du skickar resultatet i ett HTTP‑svar. Den accepterar också `PdfOptions` som sitt andra argument.