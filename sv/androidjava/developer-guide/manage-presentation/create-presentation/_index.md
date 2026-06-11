---
title: Skapa presentationer på Android
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Skapa presentationer i Java med Aspose.Slides för Android—producera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Denna artikel visar hur man skapar en presentation i Aspose.Slides, lägger till enkelt innehåll på en bild och sparar resultatet som en fil. Den demonstrerar också hur man skapar och sparar en ny presentation, öppnar en befintlig presentation i ett stödjande format och sparar den till ett annat format.

## **Skapa en PowerPoint-presentation**
För att lägga till en enkel rak linje på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av Presentation-klassen.
1. Hämta referensen till en bild genom att använda dess Index.
1. Lägg till en AutoShape av typen Linje med metoden addAutoShape som exponeras av Shapes-objektet.
1. Skriv den ändrade presentationen som en PPTX-fil.

I exemplen nedan har vi lagt till en linje på den första bilden i presentationen.

```java
// Instansiera ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägg till en autoshape av typen linje
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vilka format kan jag spara en ny presentation i?**

Du kan spara till [PPTX, PPT och ODP](/slides/sv/androidjava/save-presentation/), och exportera till [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/sv/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/), [SVG](/slides/sv/androidjava/convert-powerpoint-to-png/) och [bilder](/slides/sv/androidjava/convert-powerpoint-to-png/), bland andra.

**Kan jag starta från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Ladda mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/androidjava/supported-file-formats/).

**Hur kontrollerar jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ställ in [bildstorlek](/slides/sv/androidjava/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändning?**

Använd [BLOB-hanteringsstrategier](/slides/sv/androidjava/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför rena minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta med samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) instans från [flera trådar](/slides/sv/androidjava/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provvattenstämpeln och begränsningarna?**

[Applicera en licens](/slides/sv/androidjava/licensing/) en gång per process. Licensens XML måste förbli oförändrad, och licensinställningarna bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX-filen jag skapar?**

Ja. [Digitala signaturer](/slides/sv/androidjava/digital-signature-in-powerpoint/) (tillägg och verifiering) stödjs för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [skapa/redigera VBA-projekt](/slides/sv/androidjava/presentation-via-vba/) och spara makroaktiverade filer såsom PPTM/PPSM.