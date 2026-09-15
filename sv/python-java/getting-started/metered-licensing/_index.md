---
title: Metered-licensiering
type: docs
weight: 100
url: /sv/python-java/metered-licensing/
keywords:
- licens
- metered-licens
- licensnycklar
- offentlig nyckel
- privat nyckel
- förbrukningskvantitet
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Python via Java metered-licensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt, och bara betala för det du använder."
---
## **Introduktion**

Metered-licensiering är en licensmekanism som kan användas tillsammans med befintliga licensmetoder. Om du vill bli fakturerad baserat på din användning av Aspose.Slides API‑funktioner, välj metered‑licensiering.

## **Applicera metered‑nycklar**

{{% alert color="info" title="Obs" %}}

Metered‑licensiering är en ny licensmekanism som kan användas tillsammans med befintliga licensmetoder. Om du vill bli fakturerad baserat på din användning av Aspose.Slides API‑funktioner, välj metered‑licensiering.

När du köper en metered‑licens får du nycklar (inte en licensfil). Denna metered‑nyckel kan appliceras med klassen [Metered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/) som tillhandahålls av Aspose för mätning. För mer information, se [Vanliga frågor om metered‑licensiering](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/).

1. Skicka dina offentliga och privata nycklar till metoden [setMeteredKey](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/#setMeteredKey).

1. Utför någon bearbetning (utför uppgifter).

1. Anropa metoden [getConsumptionQuantity](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/#getConsumptionQuantity) i klassen [Metered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/).

Du bör se mängden/kvantiteten av API‑förfrågningar du har förbrukat hittills.

Detta exempel visar hur du använder metered‑licensiering:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Skapa en instans av Metered-klassen.
metered = Metered()

try:
    # Skicka de offentliga och privata nycklarna till Metered-objektet.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Hämta den förbrukade kvantiteten före API-anrop.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Gör något med Aspose.Slides API här.
    # ...

    # Hämta den förbrukade kvantiteten efter API-anrop.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Varning"  %}}

För att använda metered‑licensiering behöver du en stabil internetanslutning eftersom licensmekanismen använder internet för att kontinuerligt kommunicera med våra tjänster och utföra beräkningar.

{{% /alert %}}

## **FAQ**

**Kan jag använda en metered‑licens tillsammans med en vanlig licens (evig eller tillfällig) i samma applikation?**

Ja. Metered är en extra licensmekanism som kan användas tillsammans med befintliga [licensmetoder](/slides/sv/python-java/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startar.

**Vad räknas exakt som förbrukning under en metered‑licens: operationer eller filer?**

API‑användning räknas, det vill säga antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [förbrukningsspårningsmetoder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/).

**Är metered lämplig för mikrotjänster och serverlösa miljöer där instanser startas om ofta?**

Ja. Eftersom redovisning sker på API‑anropnivå är scenarier med frekventa kalla starter kompatibla, förutsatt att det finns stabil nätverkstillgång för metered‑beräkningar.

**Skiljer sig bibliotekets funktionalitet när man använder en metered‑licens jämfört med en evig licens?**

Nej. Detta gäller endast licens‑ och faktureringsmekanismen; produktens funktioner är desamma.

**Hur förhåller sig metered till provversionen och den tillfälliga licensen?**

Provversionen har begränsningar och vattenstämplar, den [tillfälliga licensen](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och metered tar bort begränsningarna och debiterar baserat på faktisk användning.

**Kan jag kontrollera budgeten genom att automatiskt reagera när en förbrukningströskel överskrids?**

Ja. En vanlig praxis är att periodiskt läsa aktuell förbrukning via [spårningsmetoder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/) och implementera egna gränser eller varningar på applikations‑ eller övervakningsnivå.