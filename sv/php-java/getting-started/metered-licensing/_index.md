---
title: Måttbaserad licensiering
type: docs
weight: 100
url: /sv/php-java/metered-licensing/
keywords:
- licens
- måttbaserad licens
- licensnycklar
- offentlig nyckel
- privat nyckel
- förbrukningskvantitet
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för PHP via Java-baserad måttlicensiering låter dig bearbeta PowerPoint- och OpenDocument-filer flexibelt och endast betala för det du använder."
---
## **Introduktion**

Måttbaserad licensiering är en licensieringsmekanism som kan användas tillsammans med befintliga licensieringsmetoder. Om du vill faktureras baserat på din användning av Aspose.Slides API‑funktioner, väljer du måttbaserad licensiering.

## **Använda måttbaserade nycklar**

När du köper en måttbaserad licens får du nycklar (och ingen licensfil). Denna måttbaserade nyckel kan tillämpas med klassen [Metered](https://reference.aspose.com/slides/sv/php-java/aspose.slides/metered/) som Aspose tillhandahåller för mätoperationer. För mer information, se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Skapa en instans av klassen [Metered](https://reference.aspose.com/slides/sv/php-java/aspose.slides/metered/).

1. Skicka dina offentliga och privata nycklar till metoden [setMeteredKey](https://reference.aspose.com/slides/sv/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Utför någon bearbetning (utför uppgifter).

1. Anropa metoden [getConsumptionQuantity](https://reference.aspose.com/slides/sv/php-java/aspose.slides/metered/#getConsumptionQuantity--) i klassen `Metered` .

Du bör se mängden/antalet API‑förfrågningar du har förbrukat hittills.

Detta exempel visar hur du använder måttbaserad licensiering:

```php
// Skapar en instans av Metered-klassen
$metered = new Metered();

try {
    // Skickar de offentliga och privata nycklarna till Metered-objektet
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Hämtar den förbrukade kvantiteten före API-anrop
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Gör något med Aspose.Slides API här
    // ...

    // Hämtar den förbrukade kvantiteten efter API-anrop
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="OBS" %}} 
För att använda måttbaserad licensiering behöver du en stabil internetanslutning eftersom licensieringsmekanismen använder internet för att ständigt kommunicera med våra tjänster och utföra beräkningar.
{{% /alert %}} 

## **FAQ**

**Kan jag använda en måttbaserad licens tillsammans med en vanlig licens (permanent eller tillfällig) i samma applikation?**

Ja. Måttbaserad är en extra licensieringsmekanism som kan användas tillsammans med befintliga [licensing methods](/slides/sv/php-java/licensing/). Du väljer vilken mekanism som ska tillämpas när applikationen startar.

**Vad räknas exakt som förbrukning under en måttbaserad licens: operationer eller filer?**

API‑användning räknas, dvs antalet förfrågningar eller operationer. Du kan hämta den aktuella förbrukningen via [consumption-tracking methods](https://reference.aspose.com/slides/sv/php-java/aspose.slides/metered/) .

**Är måttbaserad lämplig för mikrotjänster och serverlösa miljöer där instanser startas om ofta?**

Ja. Eftersom redovisningen sker på API‑anrop‑nivå är scenarier med frekventa kallstarter kompatibla, förutsatt att det finns stabil nätverksåtkomst för måttbaserade beräkningar.

**Skiljer sig bibliotekets funktionalitet när man använder en måttbaserad licens jämfört med en permanent licens?**

Nej. Detta gäller bara licens- och faktureringsmekanismen; produktens möjligheter är desamma.

**Hur förhåller sig måttbaserad licensiering till provversionen och den tillfälliga licensen?**

Provversionen har begränsningar och vattenstämplar, den [temporary license](https://purchase.aspose.com/temporary-license/) tar bort begränsningarna i 30 dagar, och måttbaserad tar bort begränsningar och debiterar baserat på faktisk användning.

**Kan jag kontrollera budgeten genom att automatiskt reagera när en förbrukningströskel överskrids?**

Ja. En vanlig praxis är att periodiskt läsa av den aktuella förbrukningen via [tracking methods](https://reference.aspose.com/slides/sv/php-java/aspose.slides/metered/) och implementera egna begränsningar eller varningar på applikations- eller övervakningsnivå.