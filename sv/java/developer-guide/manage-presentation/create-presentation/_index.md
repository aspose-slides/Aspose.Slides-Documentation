---
title: Skapa presentationer i Java
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Skapa presentationer i Java med Aspose.Slides — producera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programatiskt för pålitliga resultat."
---
## **Översikt**

Denna artikel visar hur du skapar en presentation i Aspose.Slides, lägger till enkelt innehåll på en bild och sparar resultatet som en fil. Den demonstrerar också hur du skapar och sparar en ny presentation, öppnar en befintlig presentation i ett stödt format och sparar den till ett annat format. Dessutom innehåller artikeln en kort FAQ som täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

## **Skapa en presentation**

Att skapa en PowerPoint‑fil från början i Aspose.Slides för Java är lika enkelt som att instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/). Konstruktorn levererar automatiskt en tom presentation med en enda bild, vilket ger dig en omedelbar yta för former, text, diagram eller annat innehåll som din applikation behöver. När du har modifierat den bilden – eller lagt till nya – kan du spara resultatet som PPTX, äldre PPT eller till och med OpenDocument‑format. Nedanstående korta kodexempel visar detta arbetsflöde genom att lägga till en enkel form på den första bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till bilden enligt dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/)‑objekt av typen `Cloud` med hjälp av metoden `addAutoShape` som finns i samlingen `Shapes`.
1. Lägg till text i auto‑formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

I exemplet nedan läggs en molnform till på den första bilden i presentationen.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en auto-form av typen Cloud.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den nya presentationen](new_presentation.png)

## **FAQ**

**Vilka format kan jag spara en ny presentation till?**

Du kan spara till [PPTX, PPT, och ODP](/slides/sv/java/save-presentation/), och exportera till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/java/convert-powerpoint-to-xps/), [HTML](/slides/sv/java/convert-powerpoint-to-html/), [SVG](/slides/sv/java/convert-powerpoint-to-png/), och [bilder](/slides/sv/java/convert-powerpoint-to-png/), bland annat.

**Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Ladda mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/java/supported-file-formats/).

**Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ställ in [bildstorlek](/slides/sv/java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller anpassade dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändningen?**

Använd [BLOB‑hanteringsstrategier](/slides/sv/java/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför rent minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta med samma [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provvattenstämpeln och begränsningarna?**

[Applicera en licens](/slides/sv/java/licensing/) en gång per process. Licens‑XML‑filen måste förbli oförändrad, och licensinställningarna bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera den PPTX jag skapar?**

Ja. [Digitala signaturer](/slides/sv/java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/java/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.