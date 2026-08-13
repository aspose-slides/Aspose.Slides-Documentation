---
title: Licenseren
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
description: "Licenties toepassen, beheren en oplossen in Aspose.Slides voor Java. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiehandleiding."
---
## **Overzicht**

Aspose.Slides kan in evaluatiemodus of met een geldige licentie worden gebruikt. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt het extraheren van tekst tot één dia.

In dit artikel wordt uitgelegd hoe licenseren werkt in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, een stream of een ingebedde resource met behulp van de `License`‑klasse. Het artikel laat ook zien hoe u kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**

{{% alert color="info" %}} 

U kunt een evaluatieversie van **Aspose.Slides for Java** downloaden vanaf de [downloadpagina](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). De evaluatieversie biedt dezelfde functionaliteiten als de gelicentieerde versie van het product. Het evaluatie‑pakket is identiek aan het gekochte pakket. De evaluatieversie wordt gewoon gelicentieerd zodra u een paar regels code toevoegt (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u een [licentie aanschaffen](https://purchase.aspose.com/buy). We raden u aan de verschillende abonnementsopties door te nemen. Bij vragen kunt u contact opnemen met het Aspose‑verkoopteam.

Elke Aspose‑licentie wordt geleverd met een eenjarig abonnement voor gratis upgrades naar nieuwe versies of fixes die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten (of zelfs evaluatieversies) krijgen gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Hoewel de evaluatieversie van Aspose.Slides (zonder opgegeven licentie) de volledige productfunctionaliteit biedt, voegt deze een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. 
* Bij het extraheren van tekst uit presentatiedia’s bent u beperkt tot één dia.

{{% alert color="info" %}} 

Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Zie de pagina [How to get a Temporary License](https://purchase.aspose.com/temporary-license) voor meer informatie.

{{% /alert %}}

## **Licenseren in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd zodra u een licentie aanschaft en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de verloopdatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus u mag het bestand niet wijzigen. Zelfs een per ongeluk toegevoegde regeleinde in de inhoud van het bestand maakt het ongeldig.
* Aspose.Slides for Java zoekt het licentiebestand doorgaans op de volgende locaties:
  * Een expliciet pad
  * De map waarin Aspose.Slides.jar zich bevindt
* Om de beperkingen van de evaluatieversie te vermijden, moet u vóór het gebruik van **Aspose.Slides** een licentie instellen. U hoeft de licentie slechts één keer per toepassing of proces in te stellen.

{{% alert color="info" %}} 

U kunt ook [Metered Licensing](/slides/nl/java/metered-licensing/) bekijken.

{{% /alert %}} 


## **Licentie toepassen**

Een licentie kan worden geladen vanuit een **bestand** of een **stream**.

{{% alert color="info" %}}

Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.

{{% /alert %}}

### **Bestand**

De eenvoudigste methode om een licentie in te stellen, is door het licentiebestand in de map te plaatsen die Aspose.Slides.jar of de jar‑bestanden van uw toepassing bevat.

Deze Java‑code toont hoe u een licentiebestand instelt:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt het pad van het licentiebestand in
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License#setLicense-java.lang.String-)‑methode de bestandsnaam aan het einde van het opgegeven expliciete pad exact overeenkomen met uw licentiebestand.

Bijvoorbeeld, u kunt de licentiebestandsnaam wijzigen naar *Aspose.Slides.Java.lic.xml*. Vervolgens moet u in uw code het pad naar dit bestand (dat eindigt op *Aspose.Slides.Java.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License#setLicense-java.lang.String-)‑methode.

{{% /alert %}}

### **Stream**

U kunt een licentie laden vanuit een stream. Deze Java‑code laat zien hoe u een licentie vanuit een stream toepast:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt de licentie in via een stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java‑bridge**

Als u Aspose.Slides for PHP via Java gebruikt, kunt u een licentie instellen via een PHP/Java‑bridge. Deze bridge maakt het mogelijk Java‑klassen in PHP‑syntaxis te gebruiken. Voor meer informatie, zie [License in PHP](/slides/nl/php-java/licensing/).

## **Licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. Deze Java‑code toont hoe u een licentie valideert:

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

{{% alert title="Note" color="warning" %}} 

De [SetLicense](https://reference.aspose.com/slides/nl/java/com.aspose.slides/License#setLicense-java.io.InputStream-)‑methode is niet thread‑safe. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, kunt u beter synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen. 

{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentie‑validatie gebeurt lokaal met behulp van het licentiebestand; er is geen internetverbinding nodig.

### Wat gebeurt er nadat het eenjarige abonnement is verlopen? Stop de bibliotheek met werken?

Nee. De licentie is eeuwigdurend: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder het abonnement te verlengen.