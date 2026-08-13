---
title: Meterlicenties
type: docs
weight: 100
url: /nl/java/metered-licensing/
keywords:
- licentie
- meterlicentie
- licentiesleutels
- publieke sleutel
- privésleutel
- verbruikshoeveelheid
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Java meterlicentie u in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, waarbij u alleen betaalt voor wat u gebruikt."
---
## **Inleiding**

Meterlicenties is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als je wilt dat je factuur gebaseerd is op je gebruik van Aspose.Slides‑API‑functies, kies je voor meterlicenties.

## **Meterlicenties Toepassen**

{{% alert color="info" %}} 

Meterlicenties is een nieuw licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als je wilt dat je factuur gebaseerd is op je gebruik van Aspose.Slides‑API‑functies, kies je voor meterlicenties.

Wanneer je een meterlicentie koopt, krijg je sleutels (en geen licentiebestand). Deze meterlicentie‑sleutel kan worden toegepast met de door Aspose geleverde [Metered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/)‑klasse voor meteringsbewerkingen. Voor meer details, zie [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/)‑klasse.

1. Geef je publieke en private sleutels door aan de [setMeteredKey](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-)‑methode.

1. Voer enige verwerking uit (voer taken uit).

1. Roep de [getConsumptionQuantity](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/#getConsumptionQuantity--)‑methode van de `Metered`‑klasse aan.

Je zou nu de hoeveelheid/aantal API‑verzoeken moeten zien die je tot nu toe hebt verbruikt.

Deze voorbeeldcode laat zien hoe je meterlicenties gebruikt:

```java
// Maakt een instantie van de Metered-klasse
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Geeft de publieke en private sleutels door aan het Metered-object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Haalt de verbruikshoeveelheid op vóór API-aanroepen
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Doe iets met de Aspose.Slides-API hier
    // ...

    // Haalt de verbruikshoeveelheid op na API-aanroepen
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE" %}} 

Om meterlicenties te gebruiken, heb je een stabiele internetverbinding nodig omdat het licentiemechanisme internet gebruikt om voortdurend met onze services te communiceren en berekeningen uit te voeren.

{{% /alert %}} 

## **FAQ**

### Kan ik een meterlicentie samen gebruiken met een reguliere (perpetuele of tijdelijke) licentie in dezelfde applicatie?

Ja. Metered is een aanvullend licentiemechanisme dat naast bestaande [licensing methods](/slides/nl/java/licensing/) kan worden gebruikt. Je kiest welk mechanisme je toepast wanneer de applicatie start.

### Wat telt precies als verbruik onder een meterlicentie: bewerkingen of bestanden?

Het API‑gebruik wordt geteld, d.w.z. het aantal verzoeken of bewerkingen. Je kunt het huidige verbruik ophalen via [consumption‑tracking methods](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/).

### Is meterlicentie geschikt voor microservices en serverless omgevingen waarin instanties vaak herstarten?

Ja. Omdat de verantwoording op het niveau van API‑aanroepen gebeurt, zijn scenario's met frequente koude starts compatibel, mits er een stabiele netwerkverbinding is voor meter‑berekeningen.

### Verschilt de functionaliteit van de bibliotheek bij gebruik van een meterlicentie ten opzichte van een perpetual licentie?

Nee. Het gaat hier alleen om het licentie‑ en facturatiemechanisme; de mogelijkheden van het product blijven gelijk.

### Hoe verhoudt meterlicentie zich tot de trial‑versie en de tijdelijke licentie?

De trial‑versie heeft beperkingen en watermerken, de [temporary license](https://purchase.aspose.com/temporary-license/) verwijdert de beperkingen voor 30 dagen, en meterlicentie verwijdert de beperkingen en brengt kosten in rekening op basis van daadwerkelijk gebruik.

### Kan ik het budget beheersen door automatisch te reageren wanneer een verbruikslimiet wordt overschreden?

Ja. Een gangbare praktijk is om periodiek het huidige verbruik uit te lezen via [tracking methods](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/) en je eigen limieten of waarschuwingen in te stellen op applicatie‑ of bewakingsniveau.