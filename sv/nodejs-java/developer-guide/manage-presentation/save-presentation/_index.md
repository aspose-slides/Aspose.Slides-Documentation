---
title: Spara presentationer i JavaScript
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/nodejs-java/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyrbild
- spara framsteg
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du sparar presentationer med Aspose.Slides för Node.js via Java—exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Open Presentations in JavaScript](/slides/sv/nodejs-java/open-presentation/) beskrev hur man använder klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att öppna en presentation. Den här artikeln förklarar hur man skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Node.js kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa klassens `save`‑metod på [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/). Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Utför någon arbetsuppgift här...

    // Spara presentationen till en fil.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utskriftsström till klassens `save`‑metod på [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/). En presentation kan skrivas till många olika strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Spara presentationen till strömmen.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/). Använd metoden [setLastView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setLastView) med ett värde från uppräkningen [ViewType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i det strikt Office Open XML‑formatet**

Aspose.Slides låter dig spara en presentation i det strikt Office Open XML‑formatet. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/) och sätt dess konformitetsegenskap när du sparar. Om du sätter [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) sparas utdatakfilen i det strikt Office Open XML‑formatet.

Exemplet nedan skapar en presentation och sparar den i det strikt Office Open XML‑formatet.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Spara presentationen i det Strikta Office Open XML-formatet.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som begränsar den okomprimerade storleken på någon fil till 4 GB (2^32 byte), den komprimerade storleken på någon fil och den totala storleken på arkivet, och den begränsar även arkivet till 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa begränsningar till 2^64.

Metoden [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) låter dig välja när ZIP64‑formatutökningar ska användas vid sparande av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatutökningar.
- [Always](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur man sparar en presentation som PPTX med ZIP64‑formatutökningar aktiverade:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
När du sparar med [Zip64Mode.Never](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Never) kastas ett [PptxException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer utan att uppdatera miniatyrbilden**

Metoden [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) styr miniatyrbildsgenerering när en presentation sparas till PPTX:

- Om den sätts till `true` uppdateras miniatyrbilden under sparandet. Detta är standardvärdet.
- Om den sätts till `false` bevaras den aktuella miniatyrbilden. Om presentationen saknar miniatyrbild genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyrbild.

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

## **Spara framstegsuppdateringar i procent**

Rapportering av sparningsframsteg konfigureras via metoden [setProgressCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) på [SaveOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/) och dess underklasser. Tillhandahåll en Java‑proxy som implementerar gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/); under exporten får återanropet periodiska procentuella uppdateringar.

Följande kodsnuttar visar hur man använder `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Använd procentvärdet för framsteg här.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [fri PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) som låter dig dela en presentation i flera filer genom att spara valda bildspel som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds “snabb sparning” (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell “snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/nodejs-java/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/nodejs-java/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt — se till att de refererade sökvägarna förblir åtkomliga.

**Kan jag ställa in/spara dokumentmetadata (Författare, Titel, Företag, Datum)?**

Ja. Standard [document properties](/slides/sv/nodejs-java/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.