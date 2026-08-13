---
title: Mätlicensiering
type: docs
weight: 100
url: /sv/java/metered-licensing/
keywords:
- licens
- mätlicens
- licensnycklar
- offentlig nyckel
- privat nyckel
- förbrukningskvantitet
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Java mätlicensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt, och betala endast för det du använder."
---
## **Introduktion**

Metered licensing är en licensieringsmekanism som kan användas tillsammans med befintliga licensmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API‑funktioner, väljer du Metered licensing.

## **Använd Metered‑nycklar**

{{% alert color="info" %}} 

Metered licensing är en ny licensieringsmekanism som kan användas tillsammans med befintliga licensmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API‑funktioner, väljer du Metered licensing.

När du köper en metered‑licens får du nycklar (och inte en licensfil). Denna metered‑nyckel kan tillämpas med hjälp av klassen [Metered](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/) som Aspose tillhandahåller för mätoperationer. För mer information, se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/).

1. Skicka dina offentliga och privata nycklar till metoden [setMeteredKey](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Utför någon bearbetning (utför uppgifter).

1. Anropa metoden [getConsumptionQuantity](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/#getConsumptionQuantity--) i klassen `Metered`.

Du bör se mängden/antalet API‑förfrågningar du har förbrukat hittills.

Denna exempelkod visar hur du använder Metered licensing:

```java
// Skapar en instans av Metered-klassen
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Skickar den offentliga och privata nyckeln till Metered-objektet
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Hämtar det förbrukade kvantitetsvärdet före API-anrop
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Gör något med Aspose.Slides API här
    // ...

    // Hämtar det förbrukade kvantitetsvärdet efter API-anrop
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

För att använda Metered licensing behöver du en stabil internetanslutning eftersom licensieringsmekanismen använder internet för att kontinuerligt kommunicera med våra tjänster och utföra beräkningar.

{{% /alert %}} 

## **FAQ**

### Kan jag använda en metered‑licens tillsammans med en vanlig licens (perpetuell eller tillfällig) i samma applikation?

Ja. Metered är en extra licensieringsmekanism som kan användas tillsammans med befintliga [licensing methods](/slides/sv/java/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startar.

### Vad räknas exakt som förbrukning under en metered‑licens: operationer eller filer?

API‑användning räknas, dvs. antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [consumption‑tracking methods](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/).

### Är metered lämplig för mikrotjänster och serverlösa miljöer där instanser startas om ofta?

Ja. Eftersom redovisning sker på API‑anropsnivå är scenarier med frekventa kallstarter kompatibla, förutsatt att det finns stabil nätverkstillgång för metered‑beräkningar.

### Skiljer sig bibliotekets funktionalitet när man använder en metered‑licens jämfört med en perpetual‑licens?

Nej. Detta handlar endast om licens‑ och faktureringsmekanismen; produktens funktioner är desamma.

### Hur förhåller sig metered till provversionen och den temporära licensen?

Provversionen har begränsningar och vattenstämplar, den [temporary license](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och Metered tar bort begränsningarna och debiterar baserat på faktisk användning.

### Kan jag kontrollera budgeten genom att automatiskt reagera när ett förbrukningströskel värde överskrids?

Ja. En vanlig metod är att periodiskt läsa den aktuella förbrukningen via [tracking methods](https://reference.aspose.com/slides/sv/java/com.aspose.slides/metered/) och implementera egna gränser eller varningar på applikations‑ eller övervakningsnivå.