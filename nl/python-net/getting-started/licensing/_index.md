---
title: Licenties
type: docs
weight: 80
url: /nl/python-net/licensing/
keywords:
- licentie
- tijdelijke licentie
- licentie instellen
- licentie gebruiken
- licentie valideren
- licentiebestand
- evaluatieversie
- Python
- Aspose.Slides
description: "Leer hoe u licenties toepast, beheert en problemen oplost in Aspose.Slides for Python via .NET. Zorg voor onderbrekingsvrije toegang tot alle functies met onze stapsgewijze licentiegids."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe aan elke dia van elke presentatie die ze opslaat en wordt tekst die uw code uit presentaties leest afgekapt.

## **Aspose.Slides evalueren**

U kunt een evaluatieversie van **Aspose.Slides for Python via .NET** downloaden van de [downloadpagina](https://pypi.org/project/Aspose.Slides/). De evaluatieversie biedt dezelfde functies als het gelicentieerde product. Het evaluatiepakket is identiek aan het aangeschafte pakket en wordt gelicentieerd nadat u een paar regels code heeft toegevoegd om de licentie toe te passen.

Wanneer u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u een [licentie aanschaffen](https://purchase.aspose.com/pricing/slides/nl/python-net/). We raden aan de beschikbare abonnementsopties te bekijken. Als u vragen heeft, neem dan contact op met het verkoopteam van Aspose.

Elke Aspose-licentie omvat een abonnement van één jaar met gratis upgrades naar nieuwe versies en correcties die gedurende die periode worden uitgebracht. Zowel gelicentieerde als evaluatiegebruikers ontvangen gratis, onbeperkte technische ondersteuning.

**Beperkingen van de evaluatieversie**

* De evaluatieversie (wanneer er geen licentie is toegepast) biedt volledige functionaliteit, maar voegt een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die ze opslaat.
* Tekst die uw code uit een presentatie leest, wordt afgekapt tot de eerste paar tekens, gevolgd door een melding over de evaluatiebeperking. Tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Opmerking" %}}
Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Zie de pagina [Hoe een tijdelijke licentie verkrijgen](https://purchase.aspose.com/temporary-license) voor details.
{{% /alert %}}

## **Licenties in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie heeft aangeschaft en een paar regels code heeft toegevoegd om deze toe te passen.
* De licentie is een eenvoudige XML‑tekstbestand dat details bevat zoals de productnaam, het aantal ontwikkelaars dat wordt gedekt, de vervaldatum van het abonnement, enzovoort.
* Het licentiebestand is digitaal ondertekend, dus mag u het niet wijzigen. Zelfs het toevoegen van een enkele regeleinde maakt het ongeldig.
* Aspose.Slides for Python via .NET zoekt de licentie op het pad dat u opgeeft. Een relatief pad, of een bestandsnaam zonder pad, wordt opgelost ten opzichte van de huidige werkmap, die niet noodzakelijkerwijs de map is die uw Python‑script bevat.
* Om de evaluatiebeperkingen te vermijden, stelt u de licentie in voordat u Aspose.Slides gebruikt. U hoeft dit slechts één keer per toepassing of proces in te stellen.

{{% alert color="info" title="Opmerking" %}}
U kunt ook de [Metered licenties](/slides/nl/python-net/metered-licensing/) bekijken.
{{% /alert %}}

## **Een licentie toepassen**

Een licentie kan worden geladen vanuit een **bestand** of een **stream**.

{{% alert color="info" title="Opmerking" %}}
Aspose.Slides biedt de klasse [License](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/) om licenties te beheren.
{{% /alert %}}

{{% alert color="warning" title="Waarschuwing" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Vroegere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.
{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen is het pad van het licentiebestand door te geven aan de [set_license](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/set_license/)‑methode. Als u alleen de bestandsnaam opgeeft, zoals in het voorbeeld hieronder, zoekt Aspose.Slides het bestand in de huidige werkmap.

```py
import aspose.slides as slides

# Instantieert de License-klasse.
license = slides.License()

# Stelt het pad van het licentiebestand in.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Waarschuwing" %}}
Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van [License.set_license](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/set_license/#str) de bestandsnaam aan het einde van het expliciete pad overeenkomen met de naam van uw licentiebestand.

U kunt bijvoorbeeld het licentiebestand hernoemen naar *Aspose.Slides.lic.xml*. Geef vervolgens in uw code het volledige pad naar dat bestand (dat eindigt op Aspose.Slides.lic.xml) door aan de [License.set_license](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/set_license/#str)‑methode.
{{% /alert %}}

### **Stream**

U kunt een licentie laden vanuit een stream. Het volgende Python‑voorbeeld toont hoe u een licentie vanuit een stream toepast:

```py
import aspose.slides as slides

# Instantieert de License-klasse.
license = slides.License()

# Stel de licentie in vanuit een stream.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Een licentie valideren**

Om te controleren of de licentie correct is toegepast, kunt u deze valideren. Het volgende Python‑codefragment laat zien hoe u een licentie valideert:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Threadveiligheid**

{{% alert color="warning" title="Waarschuwing" %}}
De [License.set_license](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/set_license/)‑methode is niet thread‑veilig. Als u deze gelijktijdig vanuit meerdere threads moet aanroepen, gebruik dan een synchronisatie‑primitive, zoals `threading.Lock`, om problemen te voorkomen.
{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er wanneer het abonnement van een jaar verloopt? Stoppen de bibliotheek en functies met werken?

Nee. De licentie is levenslang: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te verlengen.