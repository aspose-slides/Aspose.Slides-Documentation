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
description: "Leer hoe u licenties toepast, beheert en problemen oplost in Aspose.Slides voor Python via .NET. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiehandleiding."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in de evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt de teksterextractie tot een dia.

## **Aspose.Slides evalueren**

U kunt een evaluatieversie van **Aspose.Slides for Python via .NET** downloaden vanaf de [downloadpagina](https://pypi.org/project/Aspose.Slides/). De evaluatieversie biedt dezelfde functies als het gelicentieerde product. Het evaluatie‑pakket is identiek aan het gekochte pakket en wordt gelicentieerd nadat u een paar regels code hebt toegevoegd om de licentie toe te passen.

Wanneer u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u een [licentie kopen](https://purchase.aspose.com/buy). Wij raden aan de beschikbare abonnementsopties te bekijken. Als u vragen heeft, neem dan contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie omvat een eenjarig abonnement met gratis upgrades naar nieuwe versies en correcties die gedurende die periode worden uitgebracht. Zowel gelicentieerde als evaluatiegebruikers ontvangen gratis, onbeperkte technische ondersteuning.

**Beperkingen van de evaluatieversie**

* Hoewel de Aspose.Slides‑evaluatieversie (zonder toegepaste licentie) volledige functionaliteit biedt, voegt ze een evaluatiewatermerk toe aan de bovenkant van het document telkens wanneer u het opent of opslaat.
* Bij het extraheren van tekst uit een presentatie bent u beperkt tot een dia.

{{% alert color="primary" %}}
Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Zie de pagina [Hoe een tijdelijke licentie te verkrijgen](https://purchase.aspose.com/temporary-license) voor details.
{{% /alert %}}

## **Licencering in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie hebt gekocht en een paar regels code hebt toegevoegd om deze toe te passen.
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars dat wordt gedekt, de vervaldatum van het abonnement, enzovoort.
* Het licentiebestand is digitaal ondertekend, dus mag u het niet wijzigen. Zelfs het toevoegen van één regeleinde maakt het ongeldig.
* Aspose.Slides for Python via .NET zoekt meestal naar de licentie op de volgende locaties:
  * Een expliciet pad dat u opgeeft
  * De map die het Python‑script bevat dat Aspose.Slides for Python via .NET aanroept
* Om de evaluatiebeperkingen te vermijden, stelt u de licentie in voordat u Aspose.Slides gebruikt. U hoeft dit slechts één keer per toepassing of proces in te stellen.

{{% alert color="primary" %}}
U wilt misschien ook de [Metered Licensing](/slides/nl/python-net/metered-licensing/) bekijken.
{{% /alert %}}

## **Een licentie toepassen**

Een licentie kan worden geladen uit een **bestand**, **stream** of **ingebedde bron**. 

{{% alert color="primary" %}}
Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/)‑klasse aan om licenties te beheren.
{{% /alert %}}

{{% alert color="warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.
{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen is het licentiebestand in dezelfde map als de DLL van het component te plaatsen en alleen de bestandsnaam (zonder pad) op te geven.

De volgende Python‑code toont hoe u het licentiebestand instelt:

```py
import aspose.slides as slides

# Instantieert de License-klasse.
license = slides.License()

# Stelt het pad naar het licentiebestand in.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van [License.set_license()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/set_license/#str) de bestandsnaam aan het einde van het expliciete pad overeenkomen met de naam van uw licentiebestand.

U kunt bijvoorbeeld het licentiebestand hernoemen naar *Aspose.Slides.lic.xml*. Vervolgens geeft u in uw code het volledige pad naar dat bestand (dat eindigt op Aspose.Slides.lic.xml) door aan de [License.set_license()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/set_license/#str)‑methode.
{{% /alert %}}

### **Stream**

U kunt een licentie laden vanuit een stream. Het volgende Python‑voorbeeld toont hoe u een licentie vanaf een stream toepast:

```py
import aspose.slides as slides

# Instantieert de License-klasse.
license = slides.License()

# Stelt de licentie in vanuit een stream.
license.set_license(stream)
```

## **Validatie van een licentie**

Om te verifiëren dat de licentie correct is toegepast, kunt u deze valideren. De volgende Python‑code toont hoe u een licentie valideert:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Thread‑veiligheid**

{{% alert title="Note" color="warning" %}}
De [License.set_license](https://reference.aspose.com/slides/nl/python-net/aspose.slides/license/)‑methoden zijn niet thread‑veilig. Als ze gelijktijdig vanuit meerdere threads moeten worden aangeroepen, gebruik dan synchronisatie‑primitieven (bijv. `threading.Lock`) om problemen te voorkomen.
{{% /alert %}}

## **FAQ**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentievalidatie wordt lokaal uitgevoerd met behulp van het licentiebestand; een internetverbinding is niet vereist.

**Wat gebeurt er nadat het eenjarig abonnement is verlopen? Stop de bibliotheek met werken?**

Nee. De licentie is eeuwigdurend: u kunt de versies blijven gebruiken die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases meer gebruiken zonder te verlengen.