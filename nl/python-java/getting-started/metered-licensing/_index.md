---
title: Metered licentie
type: docs
weight: 100
url: /nl/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor Python via Java metered-licensing je in staat stelt PowerPoint- en OpenDocument-bestanden flexibel te verwerken, waarbij je alleen betaalt voor wat je gebruikt."
---
## **Inleiding**

Metered licensing is een licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt worden gefactureerd op basis van uw gebruik van de Aspose.Slides API-functies, kiest u voor metered licensing.

## **Metered-sleutels toepassen**

{{% alert color="info" title="Opmerking" %}}
Metered licensing is een nieuw licentiemechanisme dat naast bestaande licentiemethoden kan worden gebruikt. Als u wilt worden gefactureerd op basis van uw gebruik van de Aspose.Slides API-functies, kiest u voor metered licensing.
{{% /alert %}}

Wanneer u een metered-licentie aanschaft, ontvangt u sleutels (en geen licentiebestand). Deze metered-sleutel kan worden toegepast met de [Metered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/)‑klasse die door Aspose wordt geleverd voor meteroperaties. Zie voor meer details de [FAQ over Metered licenties](https://purchase.aspose.com/faqs/licensing/metered).

1. Maak een instantie van de [Metered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/)‑klasse.

1. Geef uw openbare en privésleutels door aan de [setMeteredKey](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/#setMeteredKey)‑methode.

1. Voer enige verwerking uit (voer taken uit).

1. Roep de [getConsumptionQuantity](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/#getConsumptionQuantity)‑methode van de [Metered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/)‑klasse aan.

U zou de hoeveelheid/het aantal API‑verzoeken dat u tot nu toe heeft verbruikt moeten zien.

Deze voorbeeldcode toont hoe u metered licensing kunt gebruiken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Maak een instantie van de Metered-klasse.
metered = Metered()

try:
    # Geef de openbare en privésleutel door aan het Metered-object.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Haal de verbruikte hoeveelheid op vóór API-aanroepen.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Doe iets met de Aspose.Slides API hier.
    # ...

    # Haal de verbruikte hoeveelheid op na API-aanroepen.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Waarschuwing" %}}
Om metered licensing te gebruiken, heeft u een stabiele internetverbinding nodig, omdat het licentiemechanisme internet gebruikt om voortdurend met onze diensten te communiceren en berekeningen uit te voeren.
{{% /alert %}}

## **FAQ**

**Kan ik een metered-licentie samen met een reguliere (perpetuele of tijdelijke) licentie in dezelfde applicatie gebruiken?**

Ja. Metered is een aanvullend licentiemechanisme dat naast bestaande [licentiemethoden](/slides/nl/python-java/licensing/) kan worden gebruikt. U kiest welk mechanisme u toepast wanneer de applicatie start.

**Wat telt precies mee als verbruik onder een metered-licentie: operaties of bestanden?**

Het gebruik van de API wordt geteld, dus het aantal verzoeken of operaties. U kunt het huidige verbruik opvragen via [consumption‑tracking methods](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/).

**Is metered geschikt voor microservices en serverloze omgevingen waarin instanties vaak opnieuw opstarten?**

Ja. Omdat de boekhouding op het niveau van API‑aanroepen gebeurt, zijn scenario’s met frequente cold starts compatibel, mits er een stabiele netwerktoegang is voor metered‑berekeningen.

**Verschilt de functionaliteit van de bibliotheek bij gebruik van een metered-licentie ten opzichte van een perpetual‑licentie?**

Nee. Dit betreft alleen het licentie‑ en factureringsmechanisme; de mogelijkheden van het product blijven gelijk.

**Hoe verhoudt metered zich tot de proefversie en de tijdelijke licentie?**

De proefversie heeft beperkingen en watermerken, de [tijdelijke licentie](https://purchase.aspose.com/temporary-license/) verwijdert de beperkingen voor 30 dagen, en metered verwijdert de beperkingen en brengt kosten in rekening op basis van daadwerkelijk gebruik.

**Kan ik het budget beheersen door automatisch te reageren wanneer een verbruikdrempel wordt overschreden?**

Ja. Een veelvoorkomende aanpak is om periodiek het huidige verbruik uit te lezen via [tracking methods](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/) en uw eigen limieten of waarschuwingen te implementeren op applicatie‑ of monitoringsniveau.