---
title: Licenseren
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
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides for Android via Java. Zorg voor ononderbroken toegang tot alle functies met onze licentiehandleiding."
---
## **Overzicht**

Aspose.Slides kan in evaluatiemodus of met een geldige licentie worden gebruikt. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt tekstelementextractie tot één dia.

Dit artikel legt uit hoe licenseren werkt in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingebedde bron met behulp van de `License`‑klasse. Het artikel toont ook hoe u kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**

{{% alert color="info" %}} 

U kunt een evaluatieversie van **Aspose.Slides for Android via Java** downloaden vanaf de bijbehorende [downloadpagina](https://releases.aspose.com/slides/nl/androidjava/). De evaluatieversie biedt dezelfde functionaliteiten als de gelicentieerde versie van het product. Het evaluatie‑pakket is identiek aan het gekochte pakket. De evaluatieversie wordt simpelweg gelicentieerd zodra u een paar regels code toevoegt (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u een [licentie kopen](https://purchase.aspose.com/buy). We raden aan de verschillende abonnementsopties door te nemen. Als u vragen heeft, neem dan contact op met het Aspose‑verkoopteam.

Elke Aspose‑licentie wordt geleverd met een eenjarig abonnement voor gratis upgrades naar nieuwe versies of fixes die tijdens de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten (of zelfs evaluatieversies) krijgen gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Hoewel de evaluatieversie van Aspose.Slides (zonder opgegeven licentie) volledige productfunctionaliteit biedt, plaatst deze een evaluatiewatermerk bovenaan het document bij openen en opslaan. 
* Bij het extraheren van tekst uit presentatiedia’s bent u beperkt tot één dia.

{{% alert color="info" %}} 

Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Zie de pagina [Hoe een tijdelijke licentie te verkrijgen](https://purchase.aspose.com/temporary-license) voor meer informatie.

{{% /alert %}}

## **Licenseren in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie hebt aangeschaft en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een eenvoudig XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het is gelicentieerd, de vervaldatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus u mag het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud maakt het bestand ongeldig.
* Aspose.Slides for Android via Java zoekt de licentie doorgaans op de volgende locaties:
  * Een expliciet pad
  * De map die Aspose.Slides.jar bevat
* Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft de licentie slechts één keer per toepassing of proces in te stellen.

## **Een licentie toepassen**

Een licentie kan worden geladen vanuit een **bestand** of een **stream**.

{{% alert color="info" %}}

Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.

{{% /alert %}}

### **Bestand**

De eenvoudigste methode om een licentie in te stellen, is door het licentiebestand in de map te plaatsen die Aspose.Slides.jar of uw toepassings‑jar bevat.

Deze Java‑code laat zien hoe u een licentiebestand instelt:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt het pad naar het licentiebestand in
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode de bestandsnaam aan het einde van het opgegeven expliciete pad exact overeenkomen met de naam van uw licentiebestand.

Bijvoorbeeld, u kunt de bestandsnaam wijzigen naar *Aspose.Slides.Android.via.Java.lic.xml*. Vervolgens moet u in uw code het pad naar dat bestand (dat eindigt op *Aspose.Slides.Android.via.Java.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode.

{{% /alert %}}

### **Stream**

U kunt een licentie uit een stream laden. Deze Java‑code laat zien hoe u een licentie vanuit een stream toepast:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt de licentie in via een stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Een licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. Deze Java‑code laat zien hoe u een licentie valideert:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread‑veiligheid**

{{% alert title="Opmerking" color="warning" %}} 

De [SetLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑methode is niet thread‑veilig. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, overweeg dan synchronisatie‑mechanismen (zoals een lock) te gebruiken om problemen te voorkomen. 

{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie gebeurt lokaal met het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er wanneer het eenjarige abonnement afloopt? Stopt de bibliotheek met werken?

Nee. De licentie is eeuwigdurend: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te vernieuwen.