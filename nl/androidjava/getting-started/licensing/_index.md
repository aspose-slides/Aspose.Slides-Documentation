---
title: Licensering
type: docs
weight: 90
url: /nl/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Licenties toepassen, beheren en oplossen in Aspose.Slides voor Android via Java. Zorg voor ononderbroken toegang tot alle functies met onze licentiegids."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt het extraheren van tekst tot één dia.

Dit artikel legt uit hoe licenseren werkt in Aspose.Slides en hoe je een licentie toepast voordat je de bibliotheek gebruikt. Een licentie kan worden geladen vanaf een bestand, stream of ingesloten bron met behulp van de `License`‑klasse. Het artikel laat ook zien hoe je kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**

{{% alert color="primary" %}} 

Je kunt een evaluatieversie van **Aspose.Slides for Android via Java** downloaden vanaf de [downloadpagina](https://releases.aspose.com/slides/nl/androidjava/). De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie van het product. Het evaluatie‑pakket is hetzelfde als het aangeschafte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat je een paar regels code toevoegt (om de licentie toe te passen).

Zodra je tevreden bent met je evaluatie van **Aspose.Slides**, kun je een [licentie kopen](https://purchase.aspose.com/buy). We raden je aan de verschillende abonnementsvormen te bekijken. Als je vragen hebt, neem contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie wordt geleverd met een eenjarig abonnement voor gratis upgrades naar nieuwe versies of correcties die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten (of zelfs evaluatieversies) krijgen gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Terwijl de evaluatieversie van Aspose.Slides (zonder een opgegeven licentie) de volledige productfunctionaliteit biedt, voegt zij een evaluatiewatermerk toe bovenaan het document bij openen en opslaan. 
* Je bent beperkt tot één dia bij het extraheren van teksten uit presentatiedia’s.

{{% alert color="primary" %}} 

Om Aspose.Slides zonder beperkingen te testen, kun je een **30‑daagse tijdelijke licentie** aanvragen. Zie de pagina [How to get a Temporary License](https://purchase.aspose.com/temporary-license) voor meer informatie.

{{% /alert %}}

## **Licenties in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat je een licentie aanschaft en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor deze gelicentieerd is, de vervaldatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus je mag het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.
* Aspose.Slides for Android via Java zoekt de licentie doorgaans op de volgende locaties:
  * Een expliciet pad
  * De map die Aspose.Slides.jar bevat
* Om de beperkingen van de evaluatieversie te omzeilen, moet je vóór het gebruik van **Aspose.Slides** een licentie instellen. Je hoeft de licentie slechts één keer per applicatie of proces in te stellen.

## **Een licentie toepassen**

Een licentie kan worden geladen vanaf een **bestand** of **stream**.

{{% alert color="primary" %}}

Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Vroigere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.

{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen, is door het licentiebestand in de map te plaatsen die Aspose.Slides.jar of de jar‑bestanden van jouw applicatie bevat.

Deze Java‑code laat zien hoe je een licentiebestand instelt:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt het licentiebestandspad in
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Als je het licentiebestand in een andere map plaatst, moet je bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode de bestandsnaam aan het einde van het opgegeven expliciete pad exact laten overeenkomen met de naam van je licentiebestand.

Bijvoorbeeld, je kunt de licentiebestandnaam wijzigen naar *Aspose.Slides.Android.via.Java.lic.xml*. Vervolgens moet je in je code het pad naar dit bestand (dat eindigt op *Aspose.Slides.Android.via.Java.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode.

{{% /alert %}}

### **Stream**

Je kunt een licentie laden vanuit een stream. Deze Java‑code laat zien hoe je een licentie vanuit een stream toepast:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt de licentie in via een stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Een licentie valideren**

Om te controleren of een licentie correct is ingesteld, kun je deze valideren. Deze Java‑code laat zien hoe je een licentie valideert:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Threadveiligheid**

{{% alert title="Note" color="warning" %}} 

De [SetLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑methode is niet thread‑safe. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, kun je beter synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen. 

{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentie‑validatie gebeurt lokaal met behulp van het licentiebestand; er is geen internetverbinding nodig.

**Wat gebeurt er wanneer het eenjarig abonnement verloopt? Stop de bibliotheek dan met werken?**

Nee. De licentie is eeuwigdurend: je kunt blijven werken met versies die vóór de einddatum van je abonnement zijn uitgebracht; je komt alleen niet meer in aanmerking voor nieuwere releases zonder verlenging.