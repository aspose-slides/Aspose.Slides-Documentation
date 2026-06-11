---
title: Mätad licensiering
type: docs
weight: 90
url: /sv/net/metered-licensing/
keywords:
- licens
- mätt licens
- licensnycklar
- offentlig nyckel
- privat nyckel
- förbrukningskvantitet
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för .NET mätad licensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt, och betala endast för det du använder."
---
## **Introduktion**

Mätad licensiering är en licensmekanism som kan användas tillsammans med befintliga licensmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API‑funktioner väljer du mätad licensiering.

## **Använda mätade nycklar**

När du köper en mätad licens får du nycklar (och inte en licensfil). Denna mätade nyckel kan tillämpas med hjälp av klassen [Metered](https://reference.aspose.com/slides/sv/net/aspose.slides/metered/) som Aspose tillhandahåller för mätoperationer. För mer information, se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/net/aspose.slides/metered/).
1. Skicka dina offentliga och privata nycklar till metoden [SetMeteredKey](https://reference.aspose.com/slides/sv/net/aspose.slides/metered/setmeteredkey/).
1. Utför någon bearbetning (utför uppgifter).
1. Anropa metoden [GetConsumptionQuantity](https://reference.aspose.com/slides/sv/net/aspose.slides/metered/getconsumptionquantity/) i klassen `Metered`.

Du bör se antalet/kvantiteten av API‑förfrågningar du har förbrukat hittills.

Det här exempelprogrammet visar hur du använder mätad licensiering:

```cs
// Skapar en instans av Metered-klassen
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Skickar de offentliga och privata nycklarna till Metered-objektet
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Hämtar den mätade datamängden före API-anrop
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Gör något med Aspose.Slides API här
// ...

// Hämtar den mätade datamängden efter API-anrop
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 
För att använda mätad licensiering behöver du en stabil internetanslutning eftersom licensmekanismen använder internet för att kontinuerligt interagera med våra tjänster och utföra beräkningar.
{{% /alert %}} 

## **FAQ**

**Kan jag använda en mätad licens tillsammans med en vanlig licens (perpetuell eller tillfällig) i samma applikation?**

Ja. Mätt är en extra licensmekanism som kan användas tillsammans med befintliga [licensing methods](/slides/sv/net/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startar.

**Vad räknas exakt som förbrukning under en mätad licens: operationer eller filer?**

API‑användning räknas, det vill säga antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [consumption-tracking methods](https://reference.aspose.com/slides/sv/net/aspose.slides/metered/).

**Är mätt lämplig för mikrotjänster och serverlösa miljöer där instanser startas om ofta?**

Ja. Eftersom redovisning sker på API‑anropnivå är scenarier med frekventa cold starts kompatibla, förutsatt att det finns stabil nätverkstillgång för mätade beräkningar.

**Skiljer sig bibliotekets funktionalitet när man använder en mätt licens jämfört med en perpetual licens?**

Nej. Detta handlar bara om licens- och faktureringsmekanismen; produktens funktioner är desamma.

**Hur förhåller sig mätt till provversionen och den tillfälliga licensen?**

Provversionen har begränsningar och vattenstämplar, den [temporary license](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och mätt tar bort begränsningarna och debiterar baserat på faktiskt bruk.

**Kan jag styra budgeten genom att automatiskt reagera när en förbrukningströskel överskrids?**

Ja. En vanlig praxis är att periodiskt läsa den aktuella förbrukningen via [tracking methods](https://reference.aspose.com/slides/sv/net/aspose.slides/metered/) och implementera egna gränser eller varningar på applikations- eller övervakningsnivå.