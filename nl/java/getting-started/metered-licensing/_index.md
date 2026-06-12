---
title: Metered licentiëring
type: docs
weight: 100
url: /nl/java/metered-licensing/
keywords:
- licentie
- metered licentie
- licentiesleutels
- publieke sleutel
- privésleutel
- verbruikshoeveelheid
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor Java metered licentiëring u in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, waarbij u alleen betaalt voor wat u gebruikt."
---
## **Introductie**

Metered licentiëring is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt betalen op basis van uw gebruik van Aspose.Slides API‑functies, kiest u voor metered licentiëring.

## **Metered‑sleutels toepassen**

{{% alert color="primary" %}} 

Metered licentiëring is een nieuw licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt betalen op basis van uw gebruik van Aspose.Slides API‑functies, kiest u voor metered licentiëring.

Wanneer u een metered‑licentie aanschaft, krijgt u sleutels (en geen licentiebestand). Deze metered‑sleutel kan worden toegepast met de [Metered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/)‑klasse die Aspose levert voor meter‑operaties. Voor meer details, zie [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/)‑klasse.

1. Geef uw openbare en privésleutels door aan de [setMeteredKey](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-)‑methode.

1. Voer enige verwerking uit (voer taken uit).

1. Roep de [getConsumptionQuantity](https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/#getConsumptionQuantity--)‑methode van de `Metered`‑klasse aan.

U zou de hoeveelheid/kwantiteit van API‑aanvragen die u tot nu toe verbruikt heeft moeten zien.

Deze voorbeeldcode laat zien hoe u metered licentiëring gebruikt:

```java
// Maakt een instantie van de Metered‑klasse
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Geeft de publieke en private sleutel door aan het Metered‑object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Haalt de verbruikshoeveelheid op vóór API‑aanroepen
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Doe iets met de Aspose.Slides‑API hier
    // ...

    // Haalt de verbruikshoeveelheid op na API‑aanroepen
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="OPMERKING" %}} 

Om metered licentiëring te gebruiken, hebt u een stabiele internetverbinding nodig, omdat het licentiemecanisme continu via internet met onze services communiceert en berekeningen uitvoert.

{{% /alert %}} 

## **FAQ**

**Kan ik een metered licentie combineren met een reguliere (perpetuele of tijdelijke) licentie in dezelfde applicatie?**

Ja. Metered is een aanvullend licentiemechanisme dat naast bestaande [licentiemethoden](/slides/nl/java/licensing/) kan worden gebruikt. U kiest welk mechanisme wordt toegepast wanneer de applicatie start.

**Wat telt er precies als verbruik onder een metered licentie: operaties of bestanden?**

API‑gebruik wordt geteld, oftewel het aantal aanvragen of operaties. U kunt het huidige verbruik opvragen via [verbruik‑volgmethode] (https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/).

**Is metered geschikt voor microservices en serverless‑omgevingen waarbij instanties vaak opnieuw worden gestart?**

Ja. Omdat de afrekening plaatsvindt op het niveau van API‑aanroepen, zijn scenario’s met frequente cold starts compatibel, mits er een stabiele netwerktoegang is voor de metered‑berekeningen.

**Verschilt de functionaliteit van de bibliotheek wanneer een metered licentie wordt gebruikt ten opzichte van een perpetual licentie?**

Nee. Het betreft alleen het licentie‑ en betaalmechanisme; de mogelijkheden van het product blijven hetzelfde.

**Hoe verhoudt metered zich tot de trial‑versie en de tijdelijke licentie?**

De trial‑versie heeft beperkingen en watermerken, de [tijdelijke licentie](https://purchase.aspose.com/temporary-license/) verwijdert beperkingen voor 30 dagen, en metered verwijdert beperkingen en brengt kosten in rekening op basis van daadwerkelijk gebruik.

**Kan ik het budget beheersen door automatisch te reageren wanneer een verbruikslimiet wordt overschreden?**

Ja. Een gangbare aanpak is periodiek het huidige verbruik uit te lezen via [volgmethode] (https://reference.aspose.com/slides/nl/java/com.aspose.slides/metered/) en eigen limieten of waarschuwingen te implementeren op applicatie‑ of bewakingsniveau.