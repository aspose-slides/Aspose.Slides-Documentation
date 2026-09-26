---
title: Licenties
type: docs
weight: 80
url: /nl/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Pas licenties toe, beheer en los problemen op in Aspose.Slides voor .NET. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiehandleiding."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe aan elke dia van elke presentatie die ze opslaat en snijdt de tekst af die uw code uit presentaties leest.

Dit artikel legt uit hoe licenties werken in Aspose.Slides en hoe u een licentie kunt toepassen voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingesloten resource met behulp van de `License`‑klasse. Het artikel laat ook zien hoe u kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**
{{% alert color="info" title="Opmerking" %}}
U kunt een evaluatieversie van **Aspose.Slides for .NET** downloaden vanaf [de NuGet‑downloadpagina](https://www.nuget.org/packages/Aspose.Slides.NET/). De evaluatieversie biedt dezelfde functionaliteiten als de gelicentieerde versie van het product. Het evaluatie‑pakket is identiek aan het aangeschafte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat u een paar regels code toevoegt (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u [een licentie aanschaffen](https://purchase.aspose.com/pricing/slides/nl/net/). Wij raden u aan de verschillende abonnementsopties door te nemen. Als u vragen heeft, neem dan contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie wordt geleverd met een jaarabonnement voor gratis upgrades naar nieuwe versies of fixes die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten of zelfs evaluatieversies krijgen gratis en onbeperkte technische ondersteuning.
{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* De evaluatieversie (zonder gespecificeerde licentie) biedt volledige productfunctionaliteit, maar voegt een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die ze opslaat.
* Tekst die uw code uit een presentatie leest, wordt afgekapt tot de eerste paar tekens, gevolgd door een melding over de evaluatielimiet. Tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Opmerking" %}}
Om Aspose.Slides zonder beperkingen te testen, kunt u vragen om een **30‑daagse tijdelijke licentie**. Zie de [Hoe een tijdelijke licentie te verkrijgen](https://purchase.aspose.com/temporary-license) pagina voor meer informatie.
{{% /alert %}}

## **Licenties in Aspose.Slides**
* Een evaluatieversie wordt gelicentieerd nadat u een licentie aanschaft en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een tekst‑XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus u mag het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.
* Aspose.Slides for .NET probeert de licentie doorgaans op de volgende locaties te vinden:
  * Een expliciet pad
  * De map die de DLL van de component bevat (meegeleverd in Aspose.Slides)
  * De map die de assembly bevat die de DLL van de component heeft aangeroepen (meegeleverd in Aspose.Slides)
  * De map die de entry‑assembly bevat (uw .exe)
  * Een ingesloten resource in de assembly die de DLL van de component heeft aangeroepen (meegeleverd in Aspose.Slides).
* Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u Aspose.Slides gebruikt. U hoeft een licentie slechts één keer per applicatie of proces in te stellen.

{{% alert color="info" title="Opmerking" %}}
U wilt misschien [Metered licenties](/slides/nl/net/metered-licensing/) bekijken.
{{% /alert %}} 

## **Licentie toepassen**
Een licentie kan worden geladen vanuit een **bestand**, **stream** of **ingesloten resource**. 

{{% alert color="info" title="Opmerking" %}}
Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/net/aspose.slides/license)‑klasse voor licentie‑bewerkingen.
{{% /alert %}} 

{{% alert color="warning" title="Waarschuwing" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

### **Bestand**
De eenvoudigste methode om een licentie in te stellen, is door het licentiebestand in dezelfde map te plaatsen als de DLL van de component (meegeleverd in Aspose.Slides) en alleen de bestandsnaam zonder pad op te geven.

Deze C#‑code laat zien hoe u een licentiebestand instelt:

``` csharp
// Instantieert de License-klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Stelt het pad van het licentiebestand in
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Waarschuwing" %}}
Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/#setlicense_1)‑methode de bestandsnaam aan het einde van het opgegeven pad gelijk zijn aan de naam van uw licentiebestand.

U kunt bijvoorbeeld de licentienaam wijzigen naar *Aspose.Slides.lic.xml*. Vervolgens moet u in uw code het pad naar het bestand (eindigend op *Aspose.Slides.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/#setlicense_1)‑methode.
{{% /alert %}}

### **Stroom**
U kunt een licentie uit een stream laden. Deze C#‑code laat zien hoe u een licentie uit een stream toepast:

``` csharp
// Instantieert de License-klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Open het licentiebestand als een stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Stelt de licentie in via een stream
license.SetLicense(licenseStream);
```

### **Ingebedde resource**
U kunt de licentie met uw applicatie bundelen (zodat u deze niet kwijtraakt) door de licentie toe te voegen als een ingebedde resource in een van de assemblies die de component‑DLL aanroepen (meegeleverd in Aspose.Slides). 

Zo voegt u een licentiebestand toe als een ingebedde resource:

1. Voeg in Visual Studio het licentiebestand (.lic) toe aan het project via **Bestand** > **Bestaand item toevoegen** > **Toevoegen**.  
2. Selecteer het bestand in de **Solution Explorer**.  
3. Stel in het **Properties**‑venster de **Build Action** in op **Embedded Resource**.  
4. Om toegang te krijgen tot de licentie die in de assembly is ingebed, voegt u het licentiebestand toe als een ingebedde resource aan het project en geeft u vervolgens de bestandsnaam door aan de `SetLicense`‑methode. 

De `License`‑klasse vindt het licentiebestand automatisch in de ingebedde resources. U hoeft de methoden `GetExecutingAssembly` en `GetManifestResourceStream` van de `System.Reflection.Assembly`‑klasse in het Microsoft .NET‑Framework niet aan te roepen.

Deze C#‑code laat zien hoe u een licentie instelt als een ingebedde resource:

``` csharp
// Instantieert de License-klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Geeft de bestandsnaam van de licentie door die in de assembly is ingebed
license.SetLicense("Aspose.Slides.lic");
```

## **Licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. Deze C#‑code laat zien hoe u een licentie valideert:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Threadveiligheid**

{{% alert color="warning" title="Waarschuwing" %}}
De [license.SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/)‑methode is niet thread‑safe. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, wilt u mogelijk synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen. 
{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er nadat het één‑jaarabonnement is verlopen? Stopt de bibliotheek met werken?

Nee. De licentie is levenslang: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te verlengen.