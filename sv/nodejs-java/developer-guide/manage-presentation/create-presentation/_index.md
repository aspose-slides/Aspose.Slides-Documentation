---
title: Skapa presentationer i JavaScript
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/nodejs-java/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PPT
- ny PPT
- skapa PPTX
- ny PPTX
- skapa ODP
- ny ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa presentationer med Aspose.Slides - producera PPT, PPTX och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation i Aspose.Slides, lägger till en textruta på dess första bild och sparar resultatet som en fil.

Innan du börjar, installera paketet `aspose.slides.via.java` från npm, tillsammans med JDK, Python och de C++-byggverktyg som behövs. Se [Installation](/slides/sv/nodejs-java/installation/).

## **Skapa en PowerPoint-presentation**

För att skapa en presentation och placera en textruta på dess första bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.
1. Hämta den bilden från [slide collection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslides/) med dess index 0.
1. Lägg till en rektangel med metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/addautoshape/) och sätt dess text med [setText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/settext/).
1. Spara presentationen som en PPTX‑fil med metoden [save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/save/).
1. Frigör presentationen med metoden [dispose](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/dispose/) och avsluta processen.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides körs i en Java-virtuell maskin som håller Node.js igång, så avsluta processen explicit.
process.exit(0);
```

Rektangelns övre vänstra hörn är 50 punkt från vänster kant och 50 punkt från bildens övre kant, och rektangeln är 400 punkt bred och 100 punkt hög. Spara koden som *hello.js* i din projektmapp och kör `node hello.js`: den sparar *hello.pptx*, med en bild som innehåller den rektangeln och dess text, i den aktuella mappen.

Aspose.Slides körs i en Java‑virtuell maskin som `java`‑paketet startar inuti Node.js‑processen. Den virtuella maskinen hindrar Node.js från att avsluta sig själv när skriptet är färdigt, så exemplet avslutas med `process.exit(0)`.

Utan licens lägger Aspose.Slides också till ett utvärderingsvattenstämpel på varje bild den sparar; se [Licensing](/slides/sv/nodejs-java/licensing/).

## **FAQ**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT och ODP](/slides/sv/nodejs-java/save-presentation/), och exportera till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/), och [images](/slides/sv/nodejs-java/convert-powerpoint-to-png/), bland annat.

### Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Läs in mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [are supported](/slides/sv/nodejs-java/supported-file-formats/).

### Hur kontrollerar jag bildstorlek/bildförhållande när jag skapar en presentation?

Ställ in [slide size](/slides/sv/nodejs-java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller anpassade dimensioner) och välj hur innehållet ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediefiler) för att minska minnesanvändningen?

Använd [BLOB management strategies](/slides/sv/nodejs-java/manage-blob/), begränsa lagring i minnet genom att utnyttja temporära filer, och föredra filbaserade arbetsflöden framför rena minnesströmmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) instans från [multiple threads](/slides/sv/nodejs-java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort utvärderingsvattenstämpeln och begränsningarna?

[Apply a license](/slides/sv/nodejs-java/licensing/) en gång per process. License‑XML‑filen måste förbli oförändrad, och licensinställningen bör synkroniseras om flera trådar är inblandade.

### Kan jag digitalt signera PPTX‑filen jag skapar?

Ja. [Digital signatures](/slides/sv/nodejs-java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [create/edit VBA projects](/slides/sv/nodejs-java/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.