---
title: Licenties
type: docs
weight: 90
url: /nl/java/licensing/
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
- Java
- Aspose.Slides
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides voor Java. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiegids."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe aan elke dia van elke presentatie die hij opslaat en snoeit de tekst die uw code via de API leest.

Dit artikel legt uit hoe licenties werken in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen uit een bestand, stream of ingebedde resource met behulp van de `License`‑klasse. Het artikel laat ook zien hoe u kunt verifiëren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**

{{% alert color="info" title="Note" %}}
U kunt een evaluatieversie van **Aspose.Slides for Java** downloaden vanaf de [downloadpagina](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). De evaluatieversie biedt dezelfde functionaliteiten als de gelicentieerde versie van het product. Het evaluatiepakket is hetzelfde als het aangekochte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat u een paar regels code hebt toegevoegd (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u een [licentie aanschaffen](https://purchase.aspose.com/pricing/slides/java/). We raden u aan de verschillende abonnementstypen te bekijken. Als u vragen heeft, neem dan contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie wordt geleverd met een eenjarenabonnement voor gratis upgrades naar nieuwe versies of correcties die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten (of zelfs evaluatieversies) krijgen gratis en onbeperkte technische ondersteuning.
{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* De evaluatieversie (zonder opgegeven licentie) biedt volledige productfunctionaliteit, maar voegt een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die hij opslaat.
* Tekst die uw code via de API leest, inclusief tekst die zojuist is ingesteld, wordt afgekapt tot de eerste paar tekens, gevolgd door een melding over de evaluatiebeperking. Tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Note" %}}
Om Aspose.Slides te testen zonder beperkingen, kunt u een **30‑daagse Tijdelijke Licentie** aanvragen. Zie de pagina [How to get a Temporary License](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}}

## **Licenties in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie heeft aangekocht en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement, enzovoort.
* Het licentiebestand is digitaal ondertekend, dus mag u het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.
* Aspose.Slides for Java probeert de licentie meestal te vinden op de volgende locaties:
  * Een expliciet pad
  * De map die Aspose.Slides.jar bevat
* Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft een licentie slechts één keer per toepassing of proces in te stellen.

{{% alert color="info" title="Note" %}}
U wilt misschien de [Metered Licensing](/slides/nl/java/metered-licensing/) bekijken.
{{% /alert %}} 

## **Een licentie toepassen**

Een licentie kan worden geladen uit een **bestand** of **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides biedt de [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/)‑klasse voor licentie‑operaties.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of hoger. Vroegere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

### **Bestand**

De gemakkelijkste manier om een licentie in te stellen is door het licentiebestand te plaatsen in de map die Aspose.Slides.jar of de JAR van uw applicatie bevat.

Deze Java‑code toont u hoe u een licentiebestand instelt:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt het pad naar het licentiebestand in
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode de licentienaam aan het einde van het opgegeven pad overeenkomen met de naam van uw licentiebestand.

Bijvoorbeeld, u kunt de licentienaam wijzigen naar *Aspose.Slides.Java.lic.xml*. Vervolgens moet u in uw code het pad naar het bestand (dat eindigt op *Aspose.Slides.Java.lic.xml*) doorgeven aan de [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode.
{{% /alert %}}

### **Stream**

U kunt een licentie laden vanuit een stream. Deze Java‑code toont u hoe u een licentie vanuit een stream toepast:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt de licentie in via een stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java-brug**

Als u Aspose.Slides for PHP via Java gebruikt, kunt u een licentie instellen via een PHP/Java‑brug. Deze brug maakt het mogelijk Java‑klassen te gebruiken in PHP‑syntaxis. Voor meer informatie, zie [License in PHP](/slides/nl/php-java/licensing/).

## **Een licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. Deze Java‑code toont u hoe u een licentie valideert:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread‑veiligheid**

{{% alert color="warning" title="Warning" %}}
De [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑methode is niet thread‑veilig. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, wilt u mogelijk synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen.
{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er nadat het eenjarenabonnement verlopen is? Stopt de bibliotheek met werken?

Nee. De licentie is perpetual: u kunt blijven werken met versies die vóór uw abonnements einddatum zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te verlengen.