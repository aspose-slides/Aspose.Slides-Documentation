---
title: Licenties
description: "Aspose.Slides voor Node.js via .NET biedt verschillende aankoopplannen of een Gratis proefversie en een tijdelijke licentie van 30 dagen voor evaluatie volgens het licentie‑ en abonnementsbeleid."
type: docs
weight: 80
url: /nl/nodejs-net/licensing/
---
Soms is voor de beste evaluatieresultaten een praktische aanpak nodig. Daarom biedt Aspose.Slides verschillende aankoopplannen en ook een Gratis proefversie en een tijdelijke licentie van 30 dagen voor evaluatie.

{{% alert color="primary" %}}
Let op dat er verschillende algemene beleidsregels en praktijken bestaan die u gidsen bij het evalueren, correct licentiëren en aanschaffen van onze producten. U kunt ze vinden in de ["Aankoopbeleid en FAQ"](https://purchase.aspose.com/policies) sectie.
{{% /alert %}}

## **Aspose.Slides evalueren**
U kunt Aspose.Slides eenvoudig downloaden voor evaluatie. Het evaluatiepakket is hetzelfde als het aangeschafte pakket. De evaluatieversie wordt gewoon een gelicentieerde versie zodra u een paar regels code toevoegt om de licentie toe te passen. 

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige functionaliteit van het product, maar voegt een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. Daarnaast bent u beperkt tot één dia bij het extraheren van tekst uit presentatiedia's.

{{% alert color="primary" %}} 
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Raadpleeg [Hoe een tijdelijke licentie verkrijgen?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}} 

## **Over de licentie**
U kunt eenvoudig een evaluatieversie van Aspose.Slides voor Node.js via .NET downloaden vanaf de [downloadpagina](https://releases.aspose.com/slides/nl/nodejs-net/). De evaluatieversie biedt absoluut **dezelfde mogelijkheden** als de gelicentieerde versie van Aspose.Slides. Bovendien wordt de evaluatieversie gewoon gelicentieerd zodra u een licentie aanschaft en een paar regels code toevoegt om de licentie toe te passen.

De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement, enzovoort. Het bestand is digitaal ondertekend, dus wijzig het bestand niet. Zelfs het per ongeluk toevoegen van een extra regeleinde aan de inhoud van het bestand maakt het ongeldig.

Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft de licentie slechts één keer per applicatie of proces in te stellen.

## Aangeschafte licentie

Na aankoop moet u het licentiebestand of de stream toepassen. 

{{% alert color="primary" %}}
U moet de licentie instellen:
* slechts één keer per toepassingsdomein
* voordat u andere Aspose.Slides‑klassen gebruikt
{{% /alert %}}

{{% alert color="primary" %}}
U kunt prijsinformatie vinden op de [“Pricing Information”](https://purchase.aspose.com/pricing/slides/nl/family) pagina.
{{% /alert %}}

### **Een licentie instellen in Aspose.Slides voor Node.js via .NET**

Licenties kunnen worden toegepast vanaf deze locaties:

* Expliciet pad
* Stream
* Als een Metered‑licentie – een nieuw licentiemechanisme

{{% alert color="primary" %}}
Gebruik de **setLicense**‑methode om een component te licentiëren.

Hoewel meerdere aanroepen van **setLicense** niet schadelijk zijn, verspillen ze wel resources (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

#### **Een licentie toepassen via een bestand**

Dit code‑fragment wordt gebruikt om een licentiebestand in te stellen:

**Node.js**

```javascript
// Importeer de Aspose.Slides-module voor PowerPoint-bestandsmanipulatie
const asposeSlides = require('aspose.slides.via.net');

// Deze functie initialiseert de Aspose.Slides-bibliotheek met een licentie
function setupAsposeSlidesLicense() {
	
    // Initialiseer de License-klasse vanuit de Aspose.Slides-module
    var license = new asposeSlides.License();
    
    // Pas de licentie toe vanuit een bestand
    // Vervang "your_license_file.lic" door het pad naar uw daadwerkelijke licentiebestand
    license.setLicense("your_license_file.lic");
}

// Voer de functie uit om de licentie voor Aspose.Slides in te stellen
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
Wanneer u de setLicense‑methode aanroept, moet de licentienaam overeenkomen met die van uw licentiebestand. U kunt bijvoorbeeld de bestandsnaam van het licentiebestand wijzigen in "Aspose.Slides.lic.xml". Vervolgens moet u in uw code de nieuwe licentienaam (Aspose.Slides.lic.xml) doorgeven aan de setLicense‑methode.
{{% /alert %}}