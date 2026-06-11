---
title: Metered licensiering
type: docs
weight: 90
url: /sv/python-net/metered-licensing/
keywords:
- licens
- metered-licens
- licensnycklar
- offentlig nyckel
- privat nyckel
- förbrukningskvantitet
- Python
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Python via .NET metered licensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt, och bara betala för det du använder."
---
## **Introduktion**

Metered licensing är en licensieringsmekanism som kan användas tillsammans med befintliga licensieringsmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API-funktioner väljer du Metered licensing.

## **Applicera Metered-nycklar**

{{% alert color="primary" %}} 

Metered licensing är en ny licensieringsmekanism som kan användas tillsammans med befintliga licensieringsmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API-funktioner väljer du Metered licensing.

När du köper en metered-licens får du nycklar (och ingen licensfil). Denna metered-nyckel kan tillämpas med klassen [Metered](https://reference.aspose.com/slides/sv/python-net/aspose.slides/metered/) som Aspose tillhandahåller för mätning. För mer information, se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/python-net/aspose.slides/metered/).
2. Skicka dina offentliga och privata nycklar till metoden [set_metered_key](https://reference.aspose.com/slides/sv/python-net/aspose.slides/metered/set_metered_key/#str-str).
3. Utför viss bearbetning (utför uppgifter).
4. Anropa metoden [get_consumption_quantity](https://reference.aspose.com/slides/sv/python-net/aspose.slides/metered/get_consumption_quantity/#) i klassen `Metered`.

Du bör se mängden/antalet API-förfrågningar du har förbrukat hittills.

Denna exempelkod visar hur du använder metered licensing:

```python
import aspose.slides as slides

# Skapar en instans av Metered-klassen
metered = slides.Metered()

# Skickar de offentliga och privata nycklarna till Metered-objektet
metered.set_metered_key("<valid public key>", "<valid private key>")

# Hämtar den förbrukade kvantiteten före API-anrop
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Gör något med Aspose.Slides API här
# ...

# Hämtar den förbrukade kvantiteten efter API-anrop
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

För att använda metered licensing behöver du en stabil internetanslutning eftersom licensieringsmekanismen använder internet för att kontinuerligt interagera med våra tjänster och utföra beräkningar.

{{% /alert %}} 

## **FAQ**

**Kan jag använda en metered-licens tillsammans med en vanlig licens (perpetuell eller tillfällig) i samma applikation?**

Ja. Metered är en ytterligare licensieringsmekanism som kan användas tillsammans med befintliga [licensieringsmetoder](/slides/sv/python-net/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startar.

**Vad räknas exakt som förbrukning under en metered-licens: operationer eller filer?**

API-användning räknas, det vill säga antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [förbrukningsspårningsmetoder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/metered/).

**Är metered lämplig för mikrotjänster och serverlösa miljöer där instanser startas om ofta?**

Ja. Eftersom redovisning sker på API-anropsnivå är scenarier med frekventa kallstartar kompatibla, förutsatt att det finns stabil nätverkstillgång för metered-beräkningar.

**Skiljer sig bibliotekets funktionalitet när du använder en metered-licens jämfört med en perpetual-licens?**

Nej. Detta handlar bara om licens- och faktureringsmekanismen; produktens funktioner är desamma.

**Hur förhåller sig metered till provversionen och den tillfälliga licensen?**

Provversionen har begränsningar och vattenstämplar, den [tillfälliga licensen](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och metered tar bort begränsningarna och debiterar baserat på faktisk användning.

**Kan jag kontrollera budgeten genom att automatiskt reagera när en förbrukningströskel överskrids?**

Ja. En vanlig praxis är att periodiskt läsa den aktuella förbrukningen via [spårningsmetoder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/metered/) och implementera egna gränser eller varningar på applikations- eller övervakningsnivå.