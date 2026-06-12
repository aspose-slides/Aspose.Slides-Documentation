---
title: Metered licentiëring
type: docs
weight: 100
url: /nl/nodejs-java/metered-licensing/
keywords:
- licentie
- metered licentie
- licentiesleutels
- publieke sleutel
- private sleutel
- verbruik hoeveelheid
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor Node.js via Java metered licentiëring u in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, waarbij u alleen betaalt voor wat u gebruikt."
---
## **Introductie**

Metered licensing is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt betalen op basis van uw gebruik van de Aspose.Slides API‑functies, kiest u voor metered licensing.

## **Metered‑sleutels toepassen**

Wanneer u een metered‑licentie aanschaft, ontvangt u sleutels (en geen licentiebestand). Deze metered‑sleutel kan worden toegepast met de [Metered](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/metered/)‑klasse die Aspose biedt voor meter‑bewerkingen. Zie voor meer details de [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/metered/)‑klasse.

1. Geef uw publieke en private sleutels door aan de [setMeteredKey](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/metered/#setMeteredKey)‑methode.

1. Voer enige verwerking uit (voert taken uit).

1. Roep de [getConsumptionQuantity](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/metered/#getConsumptionQuantity)‑methode van de `Metered`‑klasse aan.

U zou de hoeveelheid/het aantal API‑verzoeken die u tot nu toe heeft verbruikt, moeten zien.

Deze voorbeeldcode laat zien hoe u metered licensing gebruikt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Maakt een instantie van de Metered-klasse
var metered = new aspose.slides.Metered();

// Geeft de publieke en private sleutels door aan het Metered-object
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Haalt de verbruikte hoeveelheid op vóór API-aanroepen
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Doe iets met de Aspose.Slides API hier
// ...

// Haalt de verbruikte hoeveelheid op na API-aanroepen
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"%}} 

Om metered licensing te gebruiken, heeft u een stabiele internetverbinding nodig, omdat het licentiemechanisme het internet gebruikt om voortdurend met onze services te communiceren en berekeningen uit te voeren.

{{% /alert %}} 

## **FAQ**

**Kan ik een metered‑licentie samen gebruiken met een reguliere (perpetuele of tijdelijke) licentie in dezelfde applicatie?**

Ja. Metered is een extra licentiemechanisme dat naast bestaande [licensing methods](/slides/nl/nodejs-java/licensing/) kan worden gebruikt. U kiest welk mechanisme u toepast wanneer de applicatie start.

**Wat telt precies als verbruik onder een metered‑licentie: bewerkingen of bestanden?**

API‑gebruik wordt geteld, wat betekent het aantal verzoeken of bewerkingen. U kunt het huidige verbruik opvragen via [consumption‑tracking methods](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/metered/).

**Is metered geschikt voor microservices en serverless omgevingen waarin instanties vaak worden herstart?**

Ja. Aangezien de boekhouding op API‑aanroepniveau wordt gedaan, zijn scenario’s met frequente cold starts compatibel, mits er een stabiele netwerktoegang is voor metered‑berekeningen.

**Verschilt de functionaliteit van de bibliotheek bij gebruik van een metered‑licentie ten opzichte van een perpetuele licentie?**

Nee. Dit gaat alleen over het licentie‑ en factureringsmechanisme; de mogelijkheden van het product zijn hetzelfde.

**Hoe verhoudt metered zich tot de proefversie en de tijdelijke licentie?**

De proefversie heeft beperkingen en watermerken, de [temporary license](https://purchase.aspose.com/temporary-license/) verwijdert de beperkingen voor 30 dagen, en metered verwijdert de beperkingen en rekent op basis van daadwerkelijk gebruik.

**Kan ik het budget beheersen door automatisch te reageren wanneer een consumptiedrempel wordt overschreden?**

Ja. Een veelgebruikte praktijk is om periodiek het huidige verbruik uit te lezen via [tracking methods](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/metered/) en uw eigen limieten of waarschuwingen op applicatie‑ of monitoringsniveau te implementeren.