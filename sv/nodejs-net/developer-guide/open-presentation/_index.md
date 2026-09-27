---
title: Öppna presentationer i Node.js via .NET
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/nodejs-net/open-presentation/
keywords:
- öppna presentation
- öppna PowerPoint
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- presentation från buffer
- antal bildspel
- konvertera presentation
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Öppna PPTX-, PPT- och ODP-presentationer i JavaScript med Aspose.Slides för Node.js via .NET: läs från en filsökväg eller en Buffer, läs antalet bildspel och spara i ett annat format."
---
## **Översikt**

Aspose.Slides för Node.js via .NET öppnar PowerPoint- och OpenDocument-presentationer, såsom PPTX-, PPT- och ODP-filer, från en filsökväg eller från en Node.js `Buffer`. Den här artikeln visar båda sätten, läser antalet bildspel och sparar en öppnad presentation i ett annat format.

Exemplen förutsätter en presentation med namnet `sample.pptx` i projektmappen som du har konfigurerat i [Installation](/slides/sv/nodejs-net/installation/). Vilken PowerPoint-presentation som helst fungerar. Spara varje exempel som en `.js`-fil i projektmappen och kör den från den mappen med `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides för Node.js via .NET har ingen egen API-referens. Den speglar Aspose.Slides för .NET API med camelCase-namn, så API-länkarna i den här artikeln pekar på motsvarande klasser och medlemmar i [Aspose.Slides för .NET API-referensen](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Öppna en presentation från en fil**

För att öppna en presentation, skicka dess sökväg till [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)-konstruktorn. Aspose.Slides upptäcker formatet från filens innehåll snarare än från filändelsen, så samma kod öppnar PPTX-, PPT- och ODP-filer. En relativ sökväg löses upp mot den aktuella arbetskatalogen, vilket är projektmappen när du kör skriptet därifrån.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skriptet skriver ut antalet bildspel i `sample.pptx`, till exempel `Slide count: 9`. `count`-egenskapen i [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)-samlingen inkluderar dolda bildspel. Anropa `dispose` i ett `finally`-block, som visas, så att .NET-resurserna bakom presentationen frigörs även om din kod misslyckas.

## **Öppna en presentation från en buffer**

När en presentation kommer från en databas, en HTTP-uppladdning eller en annan källa som ger dig bytes snarare än en filsökväg, skicka en Node.js `Buffer` som det andra konstruktörsargumentet och `null` som det första. Följande exempel läser `sample.pptx` in i en buffer för att representera en sådan källa:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skriptet skriver ut samma bildspelsantal som i föregående exempel. Det andra argumentet måste vara en `Buffer`. För någon annan typ, såsom en `Uint8Array`, rapporterar konstruktorn inget fel; den skapar istället en ny presentation med ett tomt bildspel. Konvertera andra binära typer först med `Buffer.from`.

## **Spara en presentation i ett annat format**

För att konvertera en presentation till ett annat presentationsformat, öppna den och spara den med ett annat [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)-värde. Följande exempel skriver ut det format som Aspose.Slides upptäckte, vilket egenskapen [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) returnerar, och sparar presentationen som en OpenDocument-presentation:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Skriptet skriver ut `Source format: Pptx` och skapar `sample.odp`, som innehåller samma bildspel. `sourceFormat` returnerar `Ppt`, `Pptx` eller `Odp`. För att spara som PDF eller som bilder istället, se [Convert PowerPoint to PDF](/slides/sv/nodejs-net/convert-powerpoint-to-pdf/) och [Convert Slides to Images](/slides/sv/nodejs-net/convert-slide/).

## **Vanliga frågor**

**Hur öppnar jag en lösenordsskyddad presentation?**

Skapa ett [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)-objekt, sätt dess [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)-egenskap, och skicka objektet som det tredje konstruktörsargumentet: `new Presentation("protected.pptx", null, loadOptions)`. Utan rätt lösenord kastar konstruktorn ett fel.

**Varför kastar konstruktorn ett `Error` med ett tomt meddelande?**

När `Presentation`-konstruktorn misslyckas i .NET, till exempel för att filen saknas, inte är en presentation, eller kräver ett annat lösenord, får JavaScript ett `Error` vars meddelande är tomt. Innan du öppnar en fil, kontrollera att den finns relativt till arbetskatalogen, till exempel med `fs.existsSync`.

**Vilka format kan jag öppna?**

PowerPoint- och OpenDocument-presentationformat, inklusive PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP och FODP.