---
title: Licenties
description: "Aspose.Slides voor Python via Java biedt verschillende aankoopplannen of een gratis proefversie en een 30-daagse Tijdelijke Licentie voor evaluatie, gebruikmakend van licentie- en abonnementbeleid."
type: docs
weight: 80
url: /nl/python-java/licensing/
---
Soms is voor de beste evaluatieresultaten een praktische aanpak nodig. Om die reden biedt Aspose.Slides verschillende aankoopplannen en ook een Gratis Proefversie en een 30‑daagse Tijdelijke Licentie voor evaluatie aan.

{{% alert color="primary" %}}
Houd er rekening mee dat er een aantal algemene beleidsregels en praktijken zijn die je begeleiden bij het evalueren, correct licentiëren en aankopen van onze producten. Je kunt ze vinden in de [Aankoopbeleid en FAQ](https://purchase.aspose.com/policies) sectie.
{{% /alert %}}

## **Aspose.Slides evalueren**
Je kunt Aspose.Slides eenvoudig downloaden voor evaluatie. Het evaluatie‑pakket is hetzelfde als het gekochte pakket. De evaluatieversie wordt simpelweg gelicenseerd nadat je enkele regels code hebt toegevoegd om de licentie toe te passen.

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige functionaliteit van het product, maar voegt een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. Je bent bovendien beperkt tot één dia bij het extraheren van tekst uit presentatiedia's.

{{% alert color="primary" %}} 
Als je Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kun je een **30‑daagse Tijdelijke Licentie** aanvragen. Raadpleeg [Hoe verkrijg ik een tijdelijke licentie?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}} 

## **Over de licentie**
Je kunt eenvoudig een evaluatieversie van Aspose.Slides voor Python via Java downloaden vanaf de [downloadpagina](https://releases.aspose.com/slides/nl/python-java/). De evaluatieversie biedt absoluut **dezelfde mogelijkheden** als de gelicentieerde versie van Aspose.Slides. Bovendien wordt de evaluatieversie simpelweg gelicenseerd nadat je een licentie hebt aangeschaft en een paar regels code hebt toegevoegd om de licentie toe te passen.

De licentie is een eenvoudige XML‑tekstfile die details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement, enzovoort. Het bestand is digitaal ondertekend, dus verander het bestand niet. Zelfs een onbedoelde extra regel in de inhoud van het bestand maakt het ongeldig.

Om de beperkingen van de evaluatieversie te vermijden, moet je een licentie instellen voordat je **Aspose.Slides** gebruikt. Je hoeft een licentie slechts één keer per toepassing of proces in te stellen.

## Aangeschafte licentie

Na aankoop moet je het licentiebestand of de stream toepassen.

{{% alert color="primary" %}}
U moet de licentie instellen:
* slechts één keer per toepassingsdomein
* vóór het gebruik van andere Aspose.Slides‑klassen
{{% /alert %}}

{{% alert color="primary" %}}
Je kunt prijsinformatie vinden op de [Prijsinformatie](https://purchase.aspose.com/pricing/slides/nl/family) pagina.
{{% /alert %}}

### **Een licentie instellen in Aspose.Slides voor Python via Java**

Licenties kunnen vanaf de volgende locaties worden toegepast:

* Expliciet pad
* Stream
* Als een Metered‑licentie – een nieuw licentiemechanisme

{{% alert color="primary" %}}
Gebruik de **setLicense**‑methode om een component te licentiëren.

Hoewel meerdere oproepen naar **setLicense** geen schade veroorzaken, verspillen ze wel processorbronnen.
{{% /alert %}}

{{% alert color="warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

#### **Een licentie toepassen met een bestand**

Deze code‑snippet wordt gebruikt om een licentiebestand in te stellen:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Bij het aanroepen van de setLicense‑methode moet de licentienaam gelijk zijn aan die van je licentiebestand. Bijvoorbeeld, je kunt de licentiebestandsnaam wijzigen naar "Aspose.Slides.lic.xml". Vervolgens moet je in je code de nieuwe licentienaam (Aspose.Slides.lic.xml) doorgeven aan de setLicense‑methode.

#### **Een licentie toepassen vanuit bytes**

Deze code‑snippet wordt gebruikt om een licentie toe te passen vanuit bytes:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Metered‑licentie toepassen

Aspose.Slides stelt ontwikkelaars in staat een metered‑sleutel toe te passen. Dit is een nieuw licentiemechanisme.

Het nieuwe licentiemechanisme wordt gebruikt naast de bestaande licentiemethode. Klanten die op basis van het gebruik van API‑functies gefactureerd willen worden, kunnen de Metered‑licentie gebruiken.

Na het doorlopen van alle benodigde stappen om dit type licentie te verkrijgen, ontvang je de sleutels, niet het licentiebestand. Deze metered‑sleutel kan worden toegepast met de speciaal hiervoor geïntroduceerde **Metered**‑klasse.

De volgende code‑voorbeeld laat zien hoe je publieke en private metered‑sleutels instelt:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Maak een instantie van de CAD Metered‑klasse aan
metered = Metered();

# Toegang tot de set_metered_key‑eigenschap en geef de publieke en private sleutels als parameters door
metered.setMeteredKey("*****", "*****");

# Haal de hoeveelheid verbruikte meterdata op vóór het aanroepen van de API
amountbefore = Metered.getConsumptionQuantity()

# Toon informatie
print("Amount Consumed Before: \" + amountbefore + \"" )

# Laad het document vanaf de schijf.
pres = Presentation();

# Haal het aantal pagina's van het document op
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# opslaan als PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Haal de hoeveelheid verbruikte meterdata op na het aanroepen van de API
amountafter = Metered.getConsumptionQuantity()

# Toon informatie
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Let op: je moet een stabiele internetverbinding hebben voor het correct gebruiken van de Metered‑licentie, aangezien het Metered‑mechanisme constante interactie met onze diensten vereist voor juiste berekeningen. Voor meer details, raadpleeg de [Metered licentie FAQ](https://purchase.aspose.com/faqs/licensing/metered) sectie.
{{% /alert %}}