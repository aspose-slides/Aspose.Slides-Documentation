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
description: "Skapa presentationer med Aspose.Slides—producerar PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation i Aspose.Slides, lägger till enkelt innehåll på en bild och sparar resultatet som en fil.

## **Skapa PowerPoint-presentation**

För att lägga till en enkel rak linje på ett valt bild i presentationen, följ stegen nedan:

1. Skapa en instans av Presentation‑klassen.
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en AutoShape av typ Linje med addAutoShape‑metoden som exponeras av Shapes‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till en autoshape av typen linje
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vilka format kan jag spara en ny presentation i?**

Du kan spara till [PPTX, PPT och ODP](/slides/sv/nodejs-java/save-presentation/), och exportera till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/sv/nodejs-java/convert-powerpoint-to-png/) och [bilder](/slides/sv/nodejs-java/convert-powerpoint-to-png/), bland annat.

**Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Läs in mallen och spara i önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/nodejs-java/supported-file-formats/).

**Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ställ in [bildstorlek](/slides/sv/nodejs-java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller anpassade dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediefiler) för att minska minnesanvändningen?**

Använd [BLOB‑hanteringsstrategier](/slides/sv/nodejs-java/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra fil‑baserade arbetsflöden framför enbart minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/nodejs-java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provvattenstämpeln och begränsningarna?**

[Applicera en licens](/slides/sv/nodejs-java/licensing/) en gång per process. Licens‑XML‑filen måste förbli oförändrad, och licensinställningarna bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX-filen jag skapar?**

Ja. [Digitala signaturer](/slides/sv/nodejs-java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/nodejs-java/presentation-via-vba/) och spara makro‑aktiverade filer som PPTM/PPSM.