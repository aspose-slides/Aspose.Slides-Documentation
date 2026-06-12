---
title: Licenties
type: docs
weight: 80
url: /nl/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides voor PHP via Java. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiehandleiding."
---
## **Introductie**

Soms is voor de beste evaluatieresultaten een praktische aanpak nodig. Om die reden biedt Aspose.Slides verschillende aankoopplannen en ook een gratis proefversie en een tijdelijke licentie van 30 dagen voor evaluatie aan.

{{% alert color="primary" %}}
Let op dat er een aantal algemene beleidsregels en praktijken zijn die u begeleiden bij het evalueren, correct licenseren en aanschaffen van onze producten. U kunt ze vinden in de ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) sectie.
{{% /alert %}}

## **Aspose.Slides evalueren**
U kunt Aspose.Slides eenvoudig downloaden voor evaluatie. Het evaluatiepakket is hetzelfde als het gekochte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat u enkele regels code hebt toegevoegd om de licentie toe te passen.

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige functionaliteit van het product, maar voegt een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. U bent ook beperkt tot één dia bij het extraheren van tekst uit presentatiedia's.

{{% alert color="primary" %}} 
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30 Day Temporary License** aanvragen. Raadpleeg [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}} 

## **Over de licentie**
U kunt eenvoudig een evaluatieversie van Aspose.Slides voor PHP via Java downloaden via de [download page](https://packagist.org/packages/aspose/slides). De evaluatieversie biedt absoluut **dezelfde mogelijkheden** als de gelicentieerde versie van Aspose.Slides. Bovendien wordt de evaluatieversie simpelweg gelicentieerd nadat u een licentie heeft aangeschaft en een paar regels code heeft toegevoegd om de licentie toe te passen.

De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor deze gelicentieerd is, de vervaldatum van de abonnementen, enzovoort. Het bestand is digitaal ondertekend, dus wijzig het bestand niet. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.

Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft de licentie slechts één keer per applicatie of proces in te stellen.

{{% alert color="primary" %}} 
U wilt misschien [Metered Licensing](https://docs.aspose.com/slides/nl/php-java/metered-licensing/) bekijken.
{{% /alert %}} 

## **Aangekochte licentie**

Na aankoop moet u het licentiebestand of de -stream toepassen.

{{% alert color="primary" %}}
U moet de licentie instellen:
* slechts één keer per toepassingsdomein
* voordat u andere Aspose.Slides‑klassen gebruikt
{{% /alert %}}

{{% alert color="primary" %}}
U kunt prijsinformatie vinden op de [“Pricing Information”](https://purchase.aspose.com/pricing/slides/nl/family) pagina.
{{% /alert %}}

### **Een licentie instellen in Aspose.Slides voor PHP via Java**

Licenties kunnen worden toegepast vanaf deze locaties:

* Expliciet pad
* Stream
* Als een Metered License – een nieuw licentiemechanisme

{{% alert color="primary" %}}
Gebruik de **setLicense**‑methode om een component te licenseren.

Hoewel meerdere aanroepen van **setLicense** niet schadelijk zijn, is het een verspilling van middelen (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

#### **Een licentie toepassen met een bestand**

Deze code‑fragment wordt gebruikt om een licentiebestand in te stellen:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Bij het aanroepen van de setLicense‑methode moet de licentienaam hetzelfde zijn als die van uw licentiebestand. Bijvoorbeeld, u kunt de bestandsnaam van de licentie wijzigen naar "Aspose.Slides.lic.xml". Vervolgens moet u in uw code de nieuwe licentienaam (Aspose.Slides.lic.xml) doorgeven aan de setLicense‑methode.

#### **Een licentie toepassen vanuit een stream**

Deze code‑fragment wordt gebruikt om een licentie vanuit een stream toe te passen:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **FAQ**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentieverificatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding nodig.

**Wat gebeurt er nadat het eenjarig abonnement verloopt? Stopt de bibliotheek met werken?**

Nee. De licentie is eeuwigdurend: u kunt de versies blijven gebruiken die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te vernieuwen.