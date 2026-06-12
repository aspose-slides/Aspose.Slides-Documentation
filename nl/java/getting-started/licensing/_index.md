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
description: "Pas licenties toe, beheer en los problemen op in Aspose.Slides voor Java. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiehandleiding."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt het extraheren van tekst tot één dia.

Dit artikel legt uit hoe licenseren werkt in Aspose.Slides en hoe je een licentie toepast voordat je de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingesloten resource met behulp van de `License`‑klasse. Het artikel toont ook hoe je kunt controleren of een licentie correct is toegepast.

## **Evaluatie van Aspose.Slides**

{{% alert color="primary" %}} 

Je kunt een evaluatieversie van **Aspose.Slides for Java** downloaden vanaf de [downloadpagina](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). De evaluatieversie biedt dezelfde functionaliteiten als de gelicentieerde versie van het product. Het evaluatiepakket is identiek aan het gekochte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat je een paar regels code hebt toegevoegd (om de licentie toe te passen).

Zodra je tevreden bent met je evaluatie van **Aspose.Slides**, kun je een [licentie kopen](https://purchase.aspose.com/buy). We raden je aan de verschillende abonnementsvormen te bekijken. Als je vragen hebt, neem dan contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie wordt geleverd met een eenjarig abonnement voor gratis upgrades naar nieuwe versies of bugfixes die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten (of zelfs evaluatieversies) krijgen gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Terwijl de Aspose.Slides‑evaluatieversie (zonder opgegeven licentie) de volledige productfunctionaliteit biedt, plaatst ze een evaluatiewatermerk bovenaan het document bij openen en opslaan. 
* Je bent beperkt tot één dia bij het extraheren van tekst uit presentatiedia's.

{{% alert color="primary" %}} 

Om Aspose.Slides zonder beperkingen te testen, kun je vragen om een **30‑daagse tijdelijke licentie**. Zie de [How to get a Temporary License](https://purchase.aspose.com/temporary-license) pagina voor meer informatie.

{{% /alert %}}

## **Licenties in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat je een licentie hebt gekocht en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het is gelicentieerd, de vervaldatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus je mag het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud maakt het ongeldig.
* Aspose.Slides for Java zoekt doorgaans de licentie op de volgende locaties:
  * Een expliciet pad
  * De map die Aspose.Slides.jar bevat
* Om de beperkingen van de evaluatieversie te voorkomen, moet je een licentie instellen voordat je **Aspose.Slides** gebruikt. Je hoeft een licentie slechts één keer per toepassing of proces in te stellen.

{{% alert color="primary" %}} 

Je wilt misschien [Metered Licensing](/slides/nl/java/metered-licensing/) zien.

{{% /alert %}} 


## **Een licentie toepassen**

Een licentie kan worden geladen vanaf een **bestand** of **stream**.

{{% alert color="primary" %}}

Aspose.Slides levert de [License](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.

{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen is door het licentiebestand in de map te plaatsen die Aspose.Slides.jar of de jar van je toepassing bevat.

Deze Java‑code laat zien hoe je een licentiebestand instelt:

``` java
// Maakt een instantie van de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt het pad naar het licentiebestand in
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Als je het licentiebestand in een andere directory plaatst, moet bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License#setLicense-java.lang.String-)‑methode de bestandsnaam aan het einde van het opgegeven expliciete pad exact overeenkomen met je licentiebestand.

Bijvoorbeeld, je kunt de licentiebestandnaam wijzigen naar *Aspose.Slides.Java.lic.xml*. Vervolgens moet je in je code het pad naar het bestand (dat eindigt op *Aspose.Slides.Java.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License#setLicense-java.lang.String-)‑methode.

{{% /alert %}}

### **Stream**

Je kunt een licentie laden vanuit een stream. Deze Java‑code laat zien hoe je een licentie vanuit een stream toepast:

``` java
// Maakt een instantie van de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt de licentie in via een stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Als je Aspose.Slides for PHP via Java gebruikt, kun je een licentie instellen via een PHP/Java‑bridge. Deze bridge maakt het mogelijk Java‑klassen in PHP‑syntaxis te gebruiken. Zie voor meer informatie [License in PHP](/slides/nl/php-java/licensing/).

## **Een licentie valideren**

Om te controleren of een licentie correct is ingesteld, kun je deze valideren. Deze Java‑code toont hoe je een licentie valideert:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Threadveiligheid**

{{% alert title="Note" color="warning" %}} 

De [SetLicense](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License#setLicense-java.io.InputStream-)‑methode is niet thread‑safe. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, kun je overwegen synchronisatie‑mechanismen (zoals een lock) te gebruiken om problemen te voorkomen. 

{{% /alert %}}

## **FAQ**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentie‑validatie gebeurt lokaal met behulp van het licentiebestand; er is geen internetverbinding nodig.

**Wat gebeurt er nadat het eenjarige abonnement is verlopen? Stopt de bibliotheek met werken?**

Nee. De licentie is eeuwigdurend: je kunt blijven werken met versies die vóór de einddatum van je abonnement zijn uitgebracht; je komt alleen niet in aanmerking voor nieuwere releases zonder te verlengen.