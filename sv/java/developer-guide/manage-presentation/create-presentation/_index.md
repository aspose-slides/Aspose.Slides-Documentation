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
description: "Skapa presentationer i Java med Aspose.Slides—generera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur man skapar en presentation i Aspose.Slides, lägger till en form med text på dess första bild och sparar resultatet som en PPTX‑fil. För att öppna en befintlig presentation och spara den i ett annat format, se [Open Presentations](/slides/sv/java/open-presentation/) och [Save Presentations](/slides/sv/java/save-presentation/). En kort FAQ i slutet täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

Innan du börjar, lägg till Aspose.Slides for Java i ditt projekt från Asposes Maven‑arkiv. Se [Installation](/slides/sv/java/installation/) för Maven‑inställningen och för vad Linux kräver utöver detta.

## **Skapa en presentation**

Att skapa en PowerPoint‑fil från början i Aspose.Slides for Java börjar med en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/). Konstruktorn levererar en tom presentation med en enda bild, redo för former, text, diagram eller annat innehåll som din applikation behöver. När du har ändrat den bilden eller lagt till nya kan du spara resultatet i PPTX-, äldre PPT- eller OpenDocument‑format.

För att skapa en presentation och placera en form med text på dess första bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.  
2. Hämta den bilden med index 0 från samlingen som [getSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlides--) returnerar.  
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) av typen `Cloud` med metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), och sätt dess text med [setText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Spara presentationen som en PPTX‑fil med metoden [save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Exemplet nedanför är ett komplett program. I Maven‑projektet från [Installation](/slides/sv/java/installation/), spara det som *src/main/java/HelloSlides.java* och kör `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Skapa en presentation. Den innehåller redan en tom bild.
        Presentation presentation = new Presentation();
        try {
            // Hämta den första bilden.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Lägg till en molnform och sätt in text i den.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Spara presentationen som en PPTX-fil.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Molnets övre vänstra hörn är 20 punkter från vänsterkant och 20 punkter från överkant av bilden, och formen är 200 punkter bred och 80 punkter hög. Programmet sparar *new_presentation.pptx* med en bild som innehåller molnet och dess text. Utan licens lägger Aspose.Slides också till ett utvärderingsvattenmärke på varje bild den sparar; se [Licensing](/slides/sv/java/licensing/).

Resultatet:

![Den nya presentationen](new_presentation.png)

## **Vanliga frågor**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT, och ODP](/slides/sv/java/save-presentation/), och exportera till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/java/convert-powerpoint-to-xps/), [HTML](/slides/sv/java/convert-powerpoint-to-html/), [SVG](/slides/sv/java/render-a-slide-as-an-svg-image/), och [bilder](/slides/sv/java/convert-powerpoint-to-png/), bland annat.

### Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Läs in mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/java/supported-file-formats/).

### Hur styr jag bildens storlek/bildförhållande när jag skapar en presentation?

Ställ in [bildstorleken](/slides/sv/java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändningen?

Använd [BLOB‑hanteringsstrategier](/slides/sv/java/manage-blob/), begränsa lagring i minnet genom att utnyttja temporära filer, och föredra fil‑baserade arbetsflöden framför rena minnes‑strömmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort provvattensmärket och begränsningarna?

[Tilldela en licens](/slides/sv/java/licensing/) en gång per process. Licens‑XML‑filen får inte ändras, och licensinställningarna bör synkroniseras om flera trådar är inblandade.

### Kan jag digitalt signera den PPTX jag skapar?

Ja. [Digitala signaturer](/slides/sv/java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/java/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.