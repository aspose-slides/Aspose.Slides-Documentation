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
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides voor PHP via Java. Zorg voor onbeperkte toegang tot alle functies met onze stapsgewijze licentiehandleiding."
---
## **Inleiding**

Soms is een praktische aanpak nodig voor de beste evaluatieresultaten. Daarom biedt Aspose.Slides verschillende aankoop‑plannen en tevens een Gratis Proefversie en een 30‑daagse Tijdelijke Licentie voor evaluatie.

{{% alert color="info" title="Note" %}}
Let op: er zijn verschillende algemene beleidslijnen en werkwijzen die u begeleiden bij het evalueren, correct licenseren en aanschaffen van onze producten. Deze vindt u in de ["Aankoopbeleid en FAQ"](https://purchase.aspose.com/policies) sectie.
{{% /alert %}}

## **Aspose.Slides evalueren**
U kunt eenvoudig Aspose.Slides downloaden voor evaluatie. Het evaluatie‑pakket is identiek aan het gekochte pakket. De evaluatieversie wordt automatisch gelicenseerd zodra u enkele regels code toevoegt om de licentie toe te passen.

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige productfunctionaliteit, met twee beperkingen:

* Er wordt een evaluatiewatermerk‑tekstvak in het midden van elke dia van elke presentatie die wordt opgeslagen, toegevoegd.
* Tekst die uw code uit een presentatie leest, wordt afgekapt tot de eerste paar tekens, gevolgd door een melding over de evaluatiebeperking. Tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Note" %}}
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30‑daagse Tijdelijke Licentie** aanvragen. Raadpleeg [Hoe krijg ik een tijdelijke licentie?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}} 

## **Over de licentie**
U kunt eenvoudig een evaluatieversie van Aspose.Slides voor PHP via Java downloaden vanaf de [downloadpagina](https://packagist.org/packages/aspose/slides). De evaluatieversie biedt absoluut **dezelfde mogelijkheden** als de gelicentieerde versie van Aspose.Slides. Bovendien wordt de evaluatieversie automatisch gelicenseerd zodra u een licentie aanschaft en een paar regels code toevoegt om de licentie toe te passen.

De licentie is een platte XML‑tekstbestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het is gelicentieerd, de vervaldatum van het abonnement, enzovoort. Het bestand is digitaal ondertekend; wijzig het bestand niet. Zelfs een per ongeluk toegevoegde regeleinde in de inhoud maakt het bestand ongeldig.

Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft de licentie slechts één keer per toepassing of proces in te stellen.

{{% alert color="info" title="Note" %}}
U wilt misschien [Metered Licensing](/slides/nl/php-java/metered-licensing/) zien.
{{% /alert %}} 

## **Aangekochte licentie**

Na aankoop dient u het licentiebestand of de stream toe te passen.

{{% alert color="info" title="Note" %}}
U moet de licentie:
* éénmaal per toepassingsdomein instellen
* voordat u enige andere Aspose.Slides‑klassen gebruikt
{{% /alert %}}

{{% alert color="info" title="Note" %}}
U vindt prijsinformatie op de [“Prijzinformatie”](https://purchase.aspose.com/pricing/slides/family) pagina.
{{% /alert %}}

### **Een licentie instellen in Aspose.Slides voor PHP via Java**

Licenties kunnen worden toegepast vanaf de volgende locaties:

* Expliciet pad
* Stream
* Als een Metered‑licentie – een nieuw licentie‑mechanisme

{{% alert color="info" title="Note" %}}
Gebruik de **setLicense**‑methode om een component te licenseren.

Hoewel meerdere oproepen naar **setLicense** niet schadelijk zijn, zijn ze wel een verspilling van middelen (processor).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.
{{% /alert %}}

#### **Licentie toepassen met een bestand**

Deze code‑fragment wordt gebruikt om een licentiebestand in te stellen:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Het voorbeeld verwacht het licentiebestand naast het script en geeft het absolute pad door: Aspose.Slides draait binnen Tomcat, dus het lost geen relatief pad op ten opzichte van uw scriptmap. Bij het aanroepen van de setLicense‑methode moet de licentienaam gelijk zijn aan die van uw licentiebestand. Bijvoorbeeld, u kunt de licentiebestandsnaam wijzigen naar "Aspose.Slides.lic.xml". Vervolgens moet u in uw code de nieuwe licentienaam (Aspose.Slides.lic.xml) doorgeven aan de setLicense‑methode.

#### **Licentie toepassen vanuit een stream**

Dit code‑fragment wordt gebruikt om een licentie vanuit een stream toe te passen:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie gebeurt lokaal met het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er nadat het een‑jarig abonnement verloopt? Stopt de bibliotheek met werken?

Nee. De licentie is eeuwigdurend: u kunt versies blijven gebruiken die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder verlenging.