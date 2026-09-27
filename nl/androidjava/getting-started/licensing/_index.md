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
description: "Licenties toepassen, beheren en oplossen in Aspose.Slides for Android via Java. Zorg voor ononderbroken toegang tot alle functies met onze licentiehandleiding."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe aan elke dia van elke presentatie die wordt opgeslagen en verkort tekst die uw code uit presentaties leest.

Dit artikel legt uit hoe licenseren werkt in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen uit een bestand, stream of ingebedde resource met behulp van de [License](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/)‑klasse. Het artikel laat ook zien hoe u kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**

{{% alert color="info" title="Opmerking" %}}

U kunt een evaluatieversie van **Aspose.Slides for Android via Java** downloaden vanaf de [downloadpagina](https://releases.aspose.com/slides/nl/androidjava/). De evaluatieversie biedt dezelfde functionaliteiten als de gelicentieerde versie van het product. Het evaluatiepakket is identiek aan het gekochte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat u een paar regels code hebt toegevoegd (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u een [licentie aanschaffen](https://purchase.aspose.com/pricing/slides/nl/android-java/). We raden u aan de verschillende abonnementsvormen door te nemen. Als u vragen heeft, neem dan contact op met het Aspose‑verkoopteam.

Elke Aspose‑licentie wordt geleverd met een eenjarig abonnement voor gratis upgrades naar nieuwe versies of correcties die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten (of zelfs evaluatieversies) krijgen gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* De evaluatieversie (zonder gespecificeerde licentie) biedt volledige productfunctionaliteit, maar voegt een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die wordt opgeslagen.
* Tekst die uw code uit een presentatie leest, wordt afgeknipt tot de eerste paar tekens, gevolgd door een melding over de evaluatiebeperking. Tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Opmerking" %}}

Om Aspose.Slides zonder beperkingen te testen, kunt u vragen om een **30‑daagse tijdelijke licentie**. Zie de pagina [How to get a Temporary License](https://purchase.aspose.com/temporary-license) voor meer informatie.

{{% /alert %}}

## **Licenseren in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie heeft gekocht en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor deze is gelicentieerd, de vervaldatum van het abonnement, enzovoort.
* Het licentiebestand is digitaal ondertekend, dus u mag het bestand niet wijzigen. Zelfs het per ongeluk toevoegen van een extra regeleinde maakt het ongeldig.
* Aspose.Slides for Android via Java zoekt de licentie doorgaans op de volgende locaties:
  * Een expliciet pad
  * De map die Aspose.Slides.jar bevat
* Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft een licentie slechts één keer per applicatie of proces in te stellen.

## **Een licentie toepassen**

Een licentie kan worden geladen uit een **bestand** of **stream**.

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" title="Waarschuwing" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.

{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen, is door het licentiebestand in de map te plaatsen die Aspose.Slides.jar of de JAR‑van uw applicatie bevat.

{{% alert color="info" title="Opmerking" %}}

Op Android worden de bibliotheek en uw app verpakt in de APK, dus er is geen map die het JAR‑bestand van de bibliotheek bevat, en een relatief pad zoals *Aspose.Slides.Android.via.Java.lic* wijst niet naar een bestand in uw app. Voeg het licentiebestand toe aan de assets van uw app en laad het vanaf een stream, zoals getoond in [Stream from App Assets](#stream-from-app-assets).

{{% /alert %}}

Deze Java‑code laat zien hoe u een licentiebestand instelt:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt het pad naar het licentiebestand in
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Waarschuwing" %}}

Als u het licentiebestand in een andere directory plaatst, moet bij het aanroepen van de [setLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode de bestandsnaam aan het einde van het opgegeven pad exact overeenkomen met de naam van uw licentiebestand.

Bijvoorbeeld, u kunt de bestandsnaam wijzigen naar *Aspose.Slides.Android.via.Java.lic.xml*. Vervolgens moet u in uw code het pad naar dit bestand (dat eindigt op *Aspose.Slides.Android.via.Java.lic.xml*) doorgeven aan de [setLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑methode.

{{% /alert %}}

### **Stream**

U kunt een licentie laden vanaf een stream. Deze Java‑code laat zien hoe u een licentie vanuit een stream toepast:

``` java
// Instantieert de License-klasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Stelt de licentie in via een stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Stream uit App Assets**

Plaats in een Android‑app het licentiebestand in de *assets*‑map van de app‑module, *app/src/main/assets*, zodat het wordt meegeleverd in de APK. Open het bestand met de [getAssets](https://developer.android.com/reference/android/content/Context#getAssets())‑methode en geef de stream door aan de [setLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑methode. De code draait binnen een `Activity`, bijvoorbeeld in de `onCreate`‑methode, vóórdat de app Aspose.Slides gebruikt:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

De bestandsnaam die aan de [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String))‑methode wordt doorgegeven, is relatief ten opzichte van de *assets*‑map. Als het bestand daar niet aanwezig is, logt de code de fout en blijft Aspose.Slides in evaluatiemodus. Om te controleren of de licentie is toegepast, zie [Licentie valideren](#validating-a-license).

## **Licentie valideren**

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

## **Threadveiligheid**

{{% alert color="warning" title="Waarschuwing" %}}

De [setLicense](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑methode is niet thread‑safe. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, kunt u best synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen.

{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentie‑validatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding nodig.

### Wat gebeurt er nadat de eenjarige abonnement verloopt? Stopt de bibliotheek met werken?

Nee. De licentie is permanent: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u komt echter niet in aanmerking voor nieuwere releases zonder de licentie te vernieuwen.