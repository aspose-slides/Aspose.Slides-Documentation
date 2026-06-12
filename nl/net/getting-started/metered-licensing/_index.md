---
title: Metered licentiëring
type: docs
weight: 90
url: /nl/net/metered-licensing/
keywords:
- licentie
- metered licentie
- licentiesleutels
- openbare sleutel
- privésleutel
- verbruikshoeveelheid
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor .NET metered licentiëring u in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, en alleen betaalt voor wat u gebruikt."
---
## **Introductie**

Metered licentiëring is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt worden gefactureerd op basis van uw gebruik van de Aspose.Slides API‑functies, kiest u voor metered licentiëring.

## **Metered-sleutels toepassen**

Wanneer u een metered‑licentie aanschaft, ontvangt u sleutels (en geen licentiebestand). Deze metered‑sleutel kan worden toegepast met behulp van de [Metered](https://reference.aspose.com/slides/nl/net/aspose.slides/metered/)‑klasse die Aspose heeft geleverd voor meteringsbewerkingen. Voor meer details, zie de [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/net/aspose.slides/metered/)‑klasse.
1. Geef uw openbare en privé‑sleutels door aan de [SetMeteredKey](https://reference.aspose.com/slides/nl/net/aspose.slides/metered/setmeteredkey/)‑methode.
1. Voer enige verwerking uit (voert taken uit).
1. Roep de [GetConsumptionQuantity](https://reference.aspose.com/slides/nl/net/aspose.slides/metered/getconsumptionquantity/)‑methode van de `Metered`‑klasse aan.

U zou de hoeveelheid/aantal API‑verzoeken die u tot nu toe hebt verbruikt moeten zien.

Deze voorbeeldcode laat zien hoe u metered licentiëring kunt gebruiken:

```cs
// Maakt een instantie van de Metered‑klasse
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Geeft de openbare en privésleutels door aan het Metered‑object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Haalt de hoeveelheid metered‑gegevens op vóór de API‑aanroep
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Doe hier iets met de Aspose.Slides‑API
// ...

// Haalt de hoeveelheid metered‑gegevens op na de API‑aanroep
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Om metered licentiëring te gebruiken, heeft u een stabiele internetverbinding nodig omdat het licentiemecanisme het internet gebruikt om voortdurend met onze services te communiceren en berekeningen uit te voeren.

{{% /alert %}} 

## **FAQ**

**Kan ik een metered‑licentie samen gebruiken met een reguliere licentie (perpetueel of tijdelijk) in dezelfde applicatie?**

Ja. Metered is een extra licentiemechanisme dat naast bestaande [licensing methods](/slides/nl/net/licensing/) kan worden gebruikt. U kiest welk mechanisme u toepast wanneer de applicatie start.

**Wat telt precies als verbruik onder een metered‑licentie: bewerkingen of bestanden?**

API‑gebruik wordt geteld, dat wil zeggen het aantal verzoeken of bewerkingen. U kunt het huidige verbruik verkrijgen via de [consumption-tracking methods](https://reference.aspose.com/slides/nl/net/aspose.slides/metered/).

**Is metered geschikt voor microservices en serverless omgevingen waar instanties vaak opnieuw opstarten?**

Ja. Omdat de boekhouding op het niveau van API‑aanroepen plaatsvindt, zijn scenario's met frequente cold starts compatibel, mits er een stabiele netwerktoegang is voor metered‑berekeningen.

**Verschilt de functionaliteit van de bibliotheek bij gebruik van een metered‑licentie ten opzichte van een perpetual‑licentie?**

Nee. Het betreft alleen het licentie‑ en facturatiemechanisme; de mogelijkheden van het product zijn hetzelfde.

**Hoe verhoudt metered zich tot de proefversie en de tijdelijke licentie?**

De proefversie heeft beperkingen en watermerken, de [temporary license](https://purchase.aspose.com/temporary-license/) verwijdert de beperkingen voor 30 dagen, en metered verwijdert de beperkingen en rekent op basis van daadwerkelijk gebruik.

**Kan ik het budget beheersen door automatisch te reageren wanneer een verbruikdrempel wordt overschreden?**

Ja. Een gebruikelijke aanpak is om periodiek het huidige verbruik uit te lezen via de [tracking methods](https://reference.aspose.com/slides/nl/net/aspose.slides/metered/) en uw eigen limieten of waarschuwingen te implementeren op applicatieniveau of monitoringniveau.