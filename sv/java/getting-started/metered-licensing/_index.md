---
title: Meterad licensiering
type: docs
weight: 100
url: /sv/java/metered-licensing/
keywords:
- licens
- meterad licens
- licensnycklar
- offentlig nyckel
- privat nyckel
- förbrukningsmängd
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Java meterad licensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt, och endast betala för det du använder."
---
## **Introduktion**

Meterad licensiering är en licensieringsmekanism som kan användas tillsammans med befintliga licensieringsmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API-funktioner väljer du meterad licensiering.

## **Använd meterade nycklar**

{{% alert color="primary" %}} 

Meterad licensiering är en ny licensieringsmekanism som kan användas tillsammans med befintliga licensieringsmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API-funktioner väljer du meterad licensiering.

När du köper en meterad licens får du nycklar (och inte en licensfil). Denna meterade nyckel kan tillämpas med hjälp av klassen [Metered](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/) som Aspose tillhandahåller för meteringsoperationer. För mer information, se [Vanliga frågor om meterad licensiering](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/).

1. Skicka dina offentliga och privata nycklar till metoden [setMeteredKey](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Utför någon bearbetning (utför uppgifter).

1. Anropa metoden [getConsumptionQuantity](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/#getConsumptionQuantity--) i klassen `Metered`.

Du bör se mängden/antalet API-förfrågningar du har förbrukat hittills.

Den här exempelkoden visar hur du använder meterad licensiering:

```java
// Skapar en instans av Metered-klassen
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Skickar de offentliga och privata nycklarna till Metered-objektet
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Hämtar den förbrukade kvantiteten före API-anrop
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Gör något med Aspose.Slides API här
    // ...

    // Hämtar den förbrukade kvantiteten efter API-anrop
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

För att använda meterad licensiering behöver du en stabil internetanslutning eftersom licensieringsmekanismen använder internet för att kontinuerligt interagera med våra tjänster och utföra beräkningar.

{{% /alert %}} 

## **Vanliga frågor**

**Kan jag använda en meterad licens tillsammans med en vanlig licens (perpetuell eller tillfällig) i samma applikation?**

Ja. Meterad är en extra licensieringsmekanism som kan användas tillsammans med befintliga [licensieringsmetoder](/slides/sv/java/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startas.

**Vad räknas exakt som förbrukning under en meterad licens: operationer eller filer?**

API-användning räknas, dvs. antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [spårningsmetoder för förbrukning](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/).

**Är meterad lämplig för mikrotjänster och serverlösa miljöer där instanser ofta startas om?**

Ja. Eftersom redovisning sker på API-anropsnivå är scenarier med frekventa kalla startar kompatibla, förutsatt att det finns stabil nätverkstillgång för meterade beräkningar.

**Skiljer sig bibliotekets funktionalitet när man använder en meterad licens jämfört med en perpetuell licens?**

Nej. Detta gäller endast licens- och faktureringsmekanismen; produktens funktioner är desamma.

**Hur förhåller sig meterad licensiering till provversionen och den tillfälliga licensen?**

Provversionen har begränsningar och vattenmärken, den [tillfälliga licensen](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och meterad licensiering tar bort begränsningarna och debiterar baserat på faktisk användning.

**Kan jag kontrollera budgeten genom att automatiskt reagera när en förbrukningströskel överskrids?**

Ja. En vanlig metod är att periodiskt läsa den aktuella förbrukningen via [spårningsmetoder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/) och implementera egna gränser eller varningar på applikations- eller övervakningsnivå.