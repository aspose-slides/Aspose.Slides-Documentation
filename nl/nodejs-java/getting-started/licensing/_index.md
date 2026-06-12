---
title: Licenties
type: docs
weight: 80
url: /nl/nodejs-java/licensing/
keywords:
- licentie
- tijdelijke licentie
- licentie instellen
- licentie gebruiken
- licentie valideren
- licentiebestand
- evaluatieversie
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas licenties toe, beheer ze en los problemen op in Aspose.Slides voor Node.js. Zorg voor ononderbroken toegang tot de volledige functionaliteit met onze stapsgewijze licentiehandleiding."
---
## **Introductie**

Soms is voor de beste evaluatieresultaten een praktische aanpak nodig. Om die reden biedt Aspose.Slides verschillende aankoopopties en een gratis proefversie en een tijdelijke licentie van 30 dagen voor evaluatie.

{{% alert color="primary" %}}
Let op dat er een aantal algemene beleidsregels en praktijken zijn die u begeleiden bij het evalueren, correct licentiëren en aankopen van onze producten. U kunt ze vinden in de ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) sectie.
{{% /alert %}}

## **Aspose.Slides evalueren**
U kunt eenvoudig Aspose.Slides downloaden voor evaluatie. Het evaluatie‑pakket is hetzelfde als het gekochte pakket. De evaluatieversie wordt simpelweg gelicenseerd zodra u een paar regels code toevoegt om de licentie toe te passen.

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige functionaliteit van het product, maar voegt een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. Daarnaast bent u beperkt tot één dia bij het extraheren van tekst uit presentatiedia's.

{{% alert color="primary" %}} 
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30‑dagen tijdelijke licentie** aanvragen. Zie [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}} 

## **Over de licentie**
U kunt eenvoudig een evaluatieversie van Aspose.Slides voor Node.js via Java downloaden van de [downloadpagina](https://releases.aspose.com/slides/nl/nodejs-java/). De evaluatieversie biedt absoluut **dezelfde mogelijkheden** als de gelicentieerde versie van Aspose.Slides. Bovendien wordt de evaluatieversie simpelweg gelicenseerd zodra u een licentie aanschaft en een paar regels code toevoegt om de licentie toe te passen.

De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het licentied is, de vervaldatum van het abonnement, enzovoort. Het bestand is digitaal ondertekend, dus wijzig het bestand niet. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.

Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft de licentie slechts één keer per toepassing of proces in te stellen.

{{% alert color="primary" %}} 
U wilt misschien [Metered Licensing](https://docs.aspose.com/slides/nl/nodejs-java/metered-licensing/) bekijken.
{{% /alert %}} 

## **Aangeschafte licentie**

Na aankoop moet u het licentiebestand of de stream toepassen.

{{% alert color="primary" %}}
U moet de licentie instellen:
* slechts één keer per toepassingsdomein
* vóór het gebruiken van andere Aspose.Slides‑klassen
{{% /alert %}}

{{% alert color="primary" %}}
U kunt prijsinformatie vinden op de [“Pricing Information”](https://purchase.aspose.com/pricing/slides/nl/family) pagina.
{{% /alert %}}

### **Een licentie instellen in Aspose.Slides voor Node.js via Java**

Licenties kunnen worden toegepast vanaf deze locaties:

* Expliciet pad
* Stream
* Als een Metered‑licentie – een nieuw licentie‑mechanisme

{{% alert color="primary" %}}
Gebruik de **setLicense**‑methode om een component te licentiëren. Hoewel meerdere aanroepen van **setLicense** niet schadelijk zijn, zijn ze een verspilling van resources (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of hoger. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

#### **Een licentie toepassen met een bestand**

Deze code‑snippet wordt gebruikt om een licentiebestand in te stellen:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Bij het aanroepen van de setLicense‑methode moet de licentienaam gelijk zijn aan die van uw licentiebestand. U kunt bijvoorbeeld de bestandsnaam wijzigen naar "Aspose.Slides.lic.xml". Vervolgens moet u in uw code de nieuwe licentienaam (Aspose.Slides.lic.xml) doorgeven aan de setLicense‑methode.

#### **Een licentie toepassen vanuit een stream**

Deze code‑snippet wordt gebruikt om een licentie vanuit een stream toe te passen:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **FAQ**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentievalidatie wordt lokaal uitgevoerd met het licentiebestand; er is geen internetverbinding vereist.

**Wat gebeurt er nadat het eenjarig abonnement is verlopen? Stopt de bibliotheek met werken?**

Nee. De licentie is levenslang: u kunt door blijven gaan met het gebruiken van versies die zijn uitgebracht vóór de einddatum van uw abonnement; u kunt echter geen nieuwere releases gebruiken zonder te verlengen.