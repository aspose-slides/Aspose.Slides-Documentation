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
- Strict Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparandeframsteg
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du sparar presentationer med Aspose.Slides för Node.js via Java - exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Open Presentations in JavaScript](/slides/sv/nodejs-java/open-presentation/) beskrev hur man använder [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑klassen för att öppna en presentation. Denna artikel förklarar hur man skapar och sparar presentationer. [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑klassen innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Node.js kan du spara till en **fil** eller **ström**. Denna artikel förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa `save`‑metoden på [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-klassen. Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Gör något arbete här...

    // Spara presentationen till en fil.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utgångsström till `save`‑metoden på [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-klassen. En presentation kan skrivas till många strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides låter dig ange den initiala vy som PowerPoint använder när den genererade presentationen öppnas via [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/)-klassen. Använd [setLastView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setLastView)-metoden med ett värde från [ViewType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewtype/)-enumerationen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Strict Office Open XML‑format**

Aspose.Slides låter dig spara en presentation i Strict Office Open XML‑formatet. Använd [PptxOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/)-klassen och sätt dess `conformance`‑egenskap vid sparning. Om du sätter [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) sparas utfilen i Strict Office Open XML‑format.

Exemplet nedan skapar en presentation och sparar den i Strict Office Open XML‑format.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Spara presentationen i Strict Office Open XML-formatet.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som begränsar den okomprimerade storleken på någon fil till 4 GB (2^32 byte), den komprimerade storleken på någon fil och den totala arkivstorleken, samt begränsar antalet filer i arkivet till 65 535 (2^16‑1). ZIP64‑formatförlängningar höjer dessa gränser till 2^64.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode)-metoden låter dig välja när ZIP64‑formatförlängningar ska användas vid sparning av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatförlängningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatförlängningar.
- [Always](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatförlängningar.

Följande kod demonstrerar hur man sparar en presentation som en PPTX‑fil med ZIP64‑formatförlängningar aktiverade:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utskriftsfiler.

Aspose.Slides tillhandahåller [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel)-metoden, som låter dig ange komprimeringsnivån som används när en presentation sparas i Office Open XML‑format.

Följande komprimeringsnivåer finns tillgängliga:

- [**None**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#None): Ingen komprimering tillämpas. Filer lagras som de är.
- [**Level1**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level1): Snabbast komprimering med lägst komprimeringsförhållande.
- [**Level2**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level2): Snabbare komprimering med något bättre förhållande än **Level1**.
- [**Level3**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level3): Bättre komprimering än **Level2** med måttlig påverkan på bearbetningstiden.
- [**Level4**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level4): Bättre komprimering än **Level3**.
- [**Level5**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level5): Förbättrad komprimering jämfört med **Level4** med extra bearbetningstid.
- [**Level6**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level6): Standardkomprimering som erbjuder en bra balans mellan hastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- [**Level7**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level7): Bättre komprimering än **Level6** men långsammare bearbetning.
- [**Level8**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level8): Bättre komprimering än **Level7**.
- [**Level9**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level9): Maximal komprimering. Ger minsta möjliga filstorlek men med längst bearbetningstid.

Följande exempel demonstrerar hur man sparar en presentation som en PPTX‑fil *utan komprimering*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Detta exempel visar hur man sparar en presentation som en PPTX‑fil med *maximal komprimering*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer utan att uppdatera miniatyren**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail)-metoden styr miniatyrgenerering när en presentation sparas till PPTX:

- Om den är satt till `true` uppdateras miniatyren under sparning. Detta är standard.
- Om den är satt till `false` bevaras den befintliga miniatyren. Om presentationen saknar miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyr.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Spara förloppsuppdateringar i procent**

Rapportering av sparprogress konfigureras via [setProgressCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setProgressCallback)-metoden på [SaveOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/)-klassen och dess underklasser. Tillhandahåll en Java‑proxy som implementerar [IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/)-gränssnittet; under export får callbacken periodiska procentuella uppdateringar.

Följande kodsnuttar visar hur man använder `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Använd procentsatsen för framsteg här.
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

Aspose har utvecklat en [free PowerPoint Splitter app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.

{{% /alert %}}

## **FAQ**

**Stöds ”snabb sparning” (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell ”snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-instans [isn’t thread-safe](/slides/sv/nodejs-java/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/nodejs-java/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (Författare, Titel, Företag, Datum)?**

Ja. Standard [document properties](/slides/sv/nodejs-java/presentation-properties/) stöds och skrivs till filen vid sparning.