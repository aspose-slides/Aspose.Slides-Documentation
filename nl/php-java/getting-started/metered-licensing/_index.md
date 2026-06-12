---
title: Metered licentiëring
type: docs
weight: 100
url: /nl/php-java/metered-licensing/
keywords:
- licentie
- metered licentie
- licentiesleutels
- publieke sleutel
- privé sleutel
- verbruikshoeveelheid
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor PHP via Java metered licentiëring u in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, waarbij u alleen betaalt voor wat u gebruikt."
---
## **Introduction**

Metered licensing is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als je wilt betalen op basis van je gebruik van de Aspose.Slides API‑functies, kies je voor metered licensing.

## **Toepassen van metered‑sleutels**

Wanneer je een metered‑licentie aanschaft, ontvang je sleutels (en geen licentiebestand). Deze metered‑sleutel kan worden toegepast met de [Metered](https://reference.aspose.com/slides/nl/php-java/aspose.slides/metered/)‑klasse die Aspose biedt voor meter‑bewerkingen. Voor meer details, zie [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/php-java/aspose.slides/metered/)‑klasse.

1. Geef je publieke en private sleutels door aan de [setMeteredKey](https://reference.aspose.com/slides/nl/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-)‑methode.

1. Voer wat verwerking uit (voer taken uit).

1. Roep de [getConsumptionQuantity](https://reference.aspose.com/slides/nl/php-java/aspose.slides/metered/#getConsumptionQuantity--)‑methode van de `Metered`‑klasse aan.

Je zou de hoeveelheid/aantal API‑verzoeken die je tot nu toe hebt geconsumeerd moeten zien.

Deze voorbeeldcode laat zien hoe je metered licensing gebruikt:

```php
// Maakt een instantie van de Metered-klasse
$metered = new Metered();

try {
    // Geeft de publieke en private sleutels door aan het Metered-object
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Haalt de verbruikte hoeveelheid op vóór API-aanroepen
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Doe hier iets met de Aspose.Slides-API
    // ...

    // Haalt de verbruikte hoeveelheid op na API-aanroepen
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Om metered licensing te gebruiken, heb je een stabiele internetverbinding nodig omdat het licentiemechanisme het internet gebruikt om voortdurend met onze services te communiceren en berekeningen uit te voeren.

{{% /alert %}} 

## **FAQ**

**Kan ik een metered‑licentie samen gebruiken met een reguliere licentie (permanent of tijdelijk) in dezelfde applicatie?**

Ja. Metered is een aanvullend licentiemechanisme dat naast bestaande [licentiemethoden](/slides/nl/php-java/licensing/) kan worden gebruikt. Je kiest welk mechanisme je toepast wanneer de applicatie start.

**Wat telt precies mee als consumptie onder een metered‑licentie: bewerkingen of bestanden?**

API‑gebruik wordt geteld, dat wil zeggen het aantal verzoeken of bewerkingen. Je kunt de huidige consumptie opvragen via [verbruik‑tracking methoden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/metered/).

**Is metered geschikt voor microservices en serverless omgevingen waarin instanties vaak opnieuw opstarten?**

Ja. Omdat de boekhouding op het niveau van API‑calls plaatsvindt, zijn scenario’s met frequente koude starts compatibel, mits er een stabiele netwerktoegang is voor metered‑berekeningen.

**Verschilt de functionaliteit van de bibliotheek bij gebruik van een metered‑licentie ten opzichte van een permanente licentie?**

Nee. Het gaat alleen om het licentie‑ en factureringsmechanisme; de mogelijkheden van het product zijn hetzelfde.

**Hoe verhoudt metered zich tot de proefversie en de tijdelijke licentie?**

De proefversie heeft beperkingen en watermerken, de [temporary license](https://purchase.aspose.com/temporary-license/) verwijdert de beperkingen voor 30 dagen, en metered verwijdert de beperkingen en brengt kosten in rekening op basis van daadwerkelijk gebruik.

**Kan ik het budget beheersen door automatisch te reageren wanneer een consumptiedrempel wordt overschreden?**

Ja. Een veelgebruikte praktijk is om periodiek de huidige consumptie uit te lezen via [tracking methods](https://reference.aspose.com/slides/nl/php-java/aspose.slides/metered/) en je eigen limieten of waarschuwingen te implementeren op applicatie‑ of monitoringsniveau.