---
title: Måttbaserad licensiering
type: docs
weight: 100
url: /sv/nodejs-java/metered-licensing/
keywords:
- licens
- måttbaserad licens
- licensnycklar
- publik nyckel
- privat nyckel
- förbrukningskvantitet
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Node.js via Java måttbaserad licensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt, och bara betalar för det du använder."
---
## **Introduktion**

Måttbaserad licensiering är en licensieringsmekanism som kan användas tillsammans med befintliga licensieringsmetoder. Om du vill bli fakturerad baserat på din användning av Aspose.Slides API‑funktioner väljer du måttbaserad licensiering.

## **Applicera måttnycklar**

När du köper en måttbaserad licens får du nycklar (inte en licensfil). Denna måttnyckel kan tillämpas med hjälp av klassen [Metered](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/metered/) som Aspose tillhandahåller för mätoperationer. För mer information, se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/metered/).

2. Skicka dina offentliga och privata nycklar till metoden [setMeteredKey](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/metered/#setMeteredKey).

3. Utför någon bearbetning (utför uppgifter).

4. Anropa metoden [getConsumptionQuantity](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) i klassen `Metered`.

Du bör se mängden/antalet API‑förfrågningar du har förbrukat hittills.

Denna exempel kod visar hur du använder måttbaserad licensiering:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Skapar en instans av Metered-klassen
var metered = new aspose.slides.Metered();

// Skickar den offentliga och privata nyckeln till Metered-objektet
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Hämtar den förbrukade kvantiteten innan API-anrop
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Gör något med Aspose.Slides API här
// ...

// Hämtar den förbrukade kvantiteten efter API-anrop
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
För att använda måttbaserad licensiering behöver du en stabil internetanslutning eftersom licensieringsmekanismen använder internet för att kontinuerligt interagera med våra tjänster och utföra beräkningar.
{{% /alert %}} 

## **FAQ**

**Kan jag använda en måttbaserad licens tillsammans med en vanlig licens (perpetuell eller tillfällig) i samma applikation?**

Ja. Måttbaserad licens är en ytterligare licensieringsmekanism som kan användas tillsammans med befintliga [licensing methods](/slides/sv/nodejs-java/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startar.

**Vad räknas exakt som förbrukning under en måttbaserad licens: operationer eller filer?**

API‑användning räknas, dvs. antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [consumption-tracking methods](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/metered/).

**Är måttbaserad licens lämplig för mikrotjänster och serverlösa miljöer där instanser startas om ofta?**

Ja. Eftersom redovisning sker på API‑anropnivå är scenarier med frekventa kalla starter kompatibla, förutsatt att det finns stabil nätverkstillgång för måttbaserade beräkningar.

**Skiljer sig bibliotekets funktionalitet när man använder en måttbaserad licens jämfört med en perpetual licens?**

Nej. Detta gäller endast licens- och faktureringsmekanismen; produktens funktioner är desamma.

**Hur förhåller sig måttbaserad licens till provversionen och den tillfälliga licensen?**

Provversionen har begränsningar och vattenstämplar, den [temporary license](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och måttbaserad licens tar bort begränsningarna och debiterar baserat på verklig användning.

**Kan jag kontrollera budgeten genom att automatiskt reagera när en förbrukningströskel överskrids?**

Ja. En vanlig praxis är att periodiskt läsa den aktuella förbrukningen via [tracking methods](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/metered/) och implementera egna gränser eller aviseringar på applikations- eller övervakningsnivå.