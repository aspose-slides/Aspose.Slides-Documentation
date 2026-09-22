---
title: Hämta och uppdatera presentationsinformation i JavaScript
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/nodejs-java/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med JavaScript för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformat och läsa dess dokumentmetadata utan att skapa en komplett presentationsobjektmodell. Detta är användbart när du behöver klassificera filer, bygga ett inventarium eller inspektera egenskaper innan du bestämmer dig för om du ska ladda och bearbeta presentationsinnehållet.

Den här artikeln demonstrerar lättviktig inspektion via [PresentationFactory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/) och [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/), samt riktade uppdateringar via [DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/).

## **Kontrollera presentationsformat**

Om du redan har en laddad presentation, se [Bestäm det ursprungliga presentationsformatet](/slides/sv/nodejs-java/detect-presentation-source-format/) för detektering efter inläsning och begränsningarna för äldre PPT-, PPS- och POT-strömmar.

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) instans. Metoden [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/getloadformat/) rapporterar det identifierade formatet, såsom PPTX, PPT eller ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Bygg ett lättviktigt presentationsinventarium**

När du bearbetar många presentationsfiler kan du behöva ett kompakt inventarium för validering, indexering eller ett dokumenthanteringssystem. I detta scenario, använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) för att erhålla ett [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/)‑objekt, och anropa sedan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar ingen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans och kräver inte att du traverserar hela presentationsobjektmodellen.

De utökade egenskaperna som exponeras av [DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/) tillhandahåller följande inventarievärden:

| Metod | Inventarievärde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getSlides) | Totalt antal bilder. |
| [getHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Antal dolda bilder. |
| [getNotes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getNotes) | Antal bilder som innehåller anteckningar. |
| [getParagraphs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Totalt antal stycken, när tillgängligt. |
| [getWords](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getWords) | Totalt antal ord. |
| [getMultimediaClips](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Totalt antal ljud‑ och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑objekt och skriver ut ett kompakt inventarium. Det kombinerar också [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) med [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) för att visa innehållsgrupper såsom typsnitt, teman och bildtitlar.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Varje [HeadingPair](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/headingpair/) levererar ett gruppnamn via [HeadingPair.getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/headingpair/#getName) och antalet objekt i gruppen via [HeadingPair.getCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) returnerar en platt, ordnad array, så konsumera antalet på varandra följande titlar som specificeras av varje rubrikpar.

### **Lagrade metadata och formatbegränsningar**

De inventarieegenskaper som returneras av [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) speglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar presentationsobjektmodellen för att omräkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om applikationen som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller utökade dokumentegenskaper för bild, anteckning, dold bild, stycke, ord och multimedieräknare, samt rubrikpar och deltitlar. Tillgänglighet beror på vilka egenskaper som skrevs av dokumentproducenten.  
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte uppdaterats av dokumentproducenten returnerar Aspose.Slides dess lagrade eller standardvärde istället för att beräkna det från bilderna.  
- **ODP:** OpenDocument‑metadata ger allmän dokumentstatistik, såsom antal sidor, stycken och ord, men dessa värden motsvarar inte varje PowerPoint‑specifik utökad egenskap. Metadata för dolda bilder, noteringsbilder, multimedia, rubrikpar och deltitlar kan saknas, och inventarieegenskaperna kan returnera standardvärden. Begränsa dig inte till att ett nollvärde eller en tom array är bevis på att motsvarande innehåll saknas.

Använd den lättviktiga metadata‑metoden för inventarier och preliminära kontroller. Ladda presentationen och inspektera dess levande objektmodell när resultatet måste återspegla ändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

De egenskaper som returneras av [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) kan också ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans. Applicera ändringarna med [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), och skriv sedan den bundna presentationen med [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Följande bild visar de ursprungliga dokumentegenskaperna för PowerPoint‑presentationen.

![Ursprungliga dokumentegenskaper för PowerPoint‑presentationen](input_properties.png)

Följande exempel ändrar titel och senast sparade tid och skriver resultatet till en ny fil:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Följande bild visar de uppdaterade dokumentegenskaperna för PowerPoint‑presentationen.

![Uppdaterade dokumentegenskaper för PowerPoint‑presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Lösenordsskydda presentationer](/slides/sv/nodejs-java/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/nodejs-java/write-protected-presentation/)

## **FAQ**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Ladda presentationen och använd [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getfontsmanager/). Anropa [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) för att erhålla de inbäddade typsnitten och [FontsManager.getFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getfonts/) för att få de typsnitt som används i presentationen. Jämför de två resultaten för att hitta typsnitt som krävs för rendering men som inte är inbäddade.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) och [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Detta är lämpligt för ett lättviktigt inventarium. Om presentationen har modifierats i minnet kan den lagrade metadata vara saknad eller föråldrad, eller så behöver du verifiera levande värden genom att iterera över [Presentation.getSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslides/) och inspektera varje bilds [Slide.getHidden](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/gethidden/)‑metod istället.

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de skiljer sig från standardvärdena?**

Ja. Ladda presentationen och anropa [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslidesize/). Använd [SlideSize.getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesize/getsize/), och [SlideSize.getOrientation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesize/getorientation/) för att jämföra de aktuella inställningarna med den förväntade förinställningen och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Lokalisera varje [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/) och anropa [ChartData.getDataSourceType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). För en extern arbetsbok, anropa [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Datakälltyp och sökväg identifierar en extern referens, men att verifiera om målet är tillgängligt kräver en separat resurstillgångskontroll.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF‑export?**

Det finns ingen enskild komplexitetsegenskap. Traversera [Presentation.getSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslides/) och varje bilds [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getShapes)‑samling. Använd antal former och närvaron av stora bilder, effekter, animationer eller multimedia som screening‑signaler, och mät en representativ rendering eller export innan du behandlar en bild som en bekräftad prestandaflaskhals.