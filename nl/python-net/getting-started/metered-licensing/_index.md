---
title: Metered-licenties
type: docs
weight: 90
url: /nl/python-net/metered-licensing/
keywords:
- licentie
- metered-licentie
- licentiesleutels
- openbare sleutel
- privésleutel
- verbruikshoeveelheid
- Python
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor Python via .NET metered-licenties u in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, waarbij u alleen betaalt voor wat u gebruikt."
---
## **Inleiding**

Metered‑licenties is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt worden gefactureerd op basis van uw gebruik van de Aspose.Slides API‑functies, kiest u voor metered‑licenties.

## **Metered‑sleutels toepassen**

{{% alert color="primary" %}} 

Metered‑licenties is een nieuw licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt worden gefactureerd op basis van uw gebruik van de Aspose.Slides API‑functies, kiest u voor metered‑licenties.

Wanneer u een metered‑licentie aanschaft, ontvangt u sleutels (en geen licentiebestand). Deze metered‑sleutel kan worden toegepast met de [Metered](https://reference.aspose.com/slides/nl/python-net/aspose.slides/metered/)‑klasse die Aspose biedt voor meter‑operaties. Zie voor meer details de [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/python-net/aspose.slides/metered/)‑klasse.
1. Geef uw openbare en privésleutels door aan de [set_metered_key](https://reference.aspose.com/slides/nl/python-net/aspose.slides/metered/set_metered_key/#str-str)‑methode.
1. Voer enige verwerking uit (voer taken uit).
1. Roep de [get_consumption_quantity](https://reference.aspose.com/slides/nl/python-net/aspose.slides/metered/get_consumption_quantity/#)‑methode van de `Metered`‑klasse aan.

U zou de hoeveelheid/het aantal API‑verzoeken dat u tot nu toe verbruikt heeft, moeten zien.

Deze voorbeeldcode laat zien hoe u metered‑licenties gebruikt:

```python
import aspose.slides as slides

# Maakt een instantie van de Metered-klasse
metered = slides.Metered()

# Geeft de openbare en privésleutels door aan het Metered-object
metered.set_metered_key("<valid public key>", "<valid private key>")

# Haalt de verbruikshoeveelheid op vóór API-aanroepen
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Doe iets met de Aspose.Slides API hier
# ...

# Haalt de verbruikshoeveelheid op na API-aanroepen
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Om metered‑licenties te gebruiken, heeft u een stabiele internetverbinding nodig, omdat het licentiemechanisme het internet gebruikt om voortdurend met onze diensten te communiceren en berekeningen uit te voeren.

{{% /alert %}} 

## **FAQ**

**Kan ik een metered‑licentie samen met een reguliere (perpetuele of tijdelijke) licentie gebruiken in dezelfde applicatie?**

Ja. Metered is een extra licentiemechanisme dat naast bestaande [licensing methods](/slides/nl/python-net/licensing/) kan worden gebruikt. U kiest welk mechanisme u toepast wanneer de applicatie start.

**Wat telt precies als verbruik onder een metered‑licentie: bewerkingen of bestanden?**

API‑gebruik wordt geteld, d.w.z. het aantal aanvragen of bewerkingen. U kunt het huidige verbruik opvragen via [verbruik‑trackingmethoden](https://reference.aspose.com/slides/nl/python-net/aspose.slides/metered/).

**Is metered geschikt voor micro‑services en serverless omgevingen waarin instanties vaak opnieuw opstarten?**

Ja. Aangezien de boekhouding plaatsvindt op het niveau van API‑aanroepen, zijn scenario’s met frequente cold starts compatibel, mits er een stabiele netwerktoegang is voor metered‑berekeningen.

**Verschilt de functionaliteit van de bibliotheek bij gebruik van een metered‑licentie ten opzichte van een perpetual‑licentie?**

Nee. Het gaat alleen om het licentie‑ en facturatiemechanisme; de mogelijkheden van het product blijven hetzelfde.

**Hoe verhoudt metered zich tot de proefversie en de tijdelijke licentie?**

De proefversie heeft beperkingen en watermerken, de [temporary license](https://purchase.aspose.com/temporary-license/) verwijdert de beperkingen gedurende 30 dagen, en metered verwijdert beperkingen en brengt kosten in rekening op basis van werkelijk gebruik.

**Kan ik het budget beheersen door automatisch te reageren wanneer een verbruikdrempel wordt overschreden?**

Ja. Een veelgebruikte praktijk is om periodiek het huidige verbruik te lezen via [tracking methods](https://reference.aspose.com/slides/nl/python-net/aspose.slides/metered/) en uw eigen limieten of waarschuwingen op applicatie‑ of bewakingsniveau te implementeren.