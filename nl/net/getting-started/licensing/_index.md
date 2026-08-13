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
description: "Licenties toepassen, beheren en oplossen in Aspose.Slides voor .NET. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiehandleiding."  
---
## **Overzicht**

Aspose.Slides kan in evaluatiemodus of met een geldige licentie worden gebruikt. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt tekstextractie tot één dia.

Dit artikel legt uit hoe licenties werken in Aspose.Slides en hoe u een licentie kunt toepassen voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingebedde resource met behulp van de `License`‑klasse. Het artikel toont ook hoe u kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**
{{% alert color="info" %}} 
U kunt een evaluatieversie van **Aspose.Slides for NET** downloaden vanaf [de NuGet‑downloadpagina](https://www.nuget.org/packages/Aspose.Slides.NET/). De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie van het product. Het evaluatie‑pakket is identiek aan het aangeschafte pakket. De evaluatieversie wordt simpelweg gelicentieerd nadat u een paar regels code toevoegt (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u [een licentie kopen](https://purchase.aspose.com/buy). We raden u aan de verschillende abonnementsvormen door te nemen. Als u vragen heeft, neem contact op met het Aspose‑verkoopteam.

Elke Aspose‑licentie wordt geleverd met een één‑jaar abonnement voor gratis upgrades naar nieuwe versies of correcties die binnen de abonnementsperiode worden vrijgegeven. Gebruikers met gelicentieerde of zelfs evaluatie‑versies krijgen gratis en onbeperkte technische ondersteuning.
{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Hoewel de Aspose.Slides‑evaluatieversie (zonder gespecificeerde licentie) de volledige productfunctionaliteit biedt, voegt deze een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. 
* U bent beperkt tot één dia bij het extraheren van tekst uit presentatiedia’s.

{{% alert color="info" %}} 
Om Aspose.Slides te testen zonder beperkingen, kunt u om een **30‑dagen tijdelijke licentie** vragen. Zie de pagina [Hoe een tijdelijke licentie aanvragen](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}}

## **Licenties in Aspose.Slides**
* Een evaluatieversie wordt gelicentieerd nadat u een licentie hebt gekocht en een paar regels code toevoegt (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor deze is gelicentieerd, de vervaldatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus u mag het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud maakt het bestand ongeldig.
* Aspose.Slides for .NET zoekt de licentie doorgaans op de volgende locaties:
  * Een expliciet pad
  * De map die de DLL van de component bevat (meegeleverd in Aspose.Slides)
  * De map die de assembly bevat die de DLL van de component heeft aangeroepen (meegeleverd in Aspose.Slides)
  * De map die de entry‑assembly bevat (uw .exe)
  * Een ingebedde resource in de assembly die de DLL van de component heeft aangeroepen (meegeleverd in Aspose.Slides).
* Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen vóór gebruik van Aspose.Slides. U hoeft een licentie slechts één keer per applicatie of proces in te stellen.

{{% alert color="info" %}} 
U wilt misschien [Metered Licensing](https://docs.aspose.com/slides/nl/net/metered-licensing/) bekijken.
{{% /alert %}} 

## **Licentie toepassen**
Een licentie kan worden geladen vanuit een **bestand**, **stream** of **ingebedde resource**. 

{{% alert color="info" %}}
Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/net/aspose.slides/license)‑klasse voor licentie‑operaties.
{{% /alert %}} 

{{% alert color="warning" %}} 
Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Eerdere versies gebruiken een ander licentiesysteem en herkennen deze licenties niet.
{{% /alert %}}

### **Bestand**
De eenvoudigste methode om een licentie in te stellen, is door het licentiebestand in dezelfde map als de DLL van de component te plaatsen (meegeleverd in Aspose.Slides) en alleen de bestandsnaam zonder pad op te geven.

Deze C#‑code laat zien hoe u een licentiebestand instelt:

``` csharp
// Instantieert de License‑klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Stelt het pad van het licentiebestand in
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 
Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/#setlicense_1)‑methode de licentiebestandsnaam aan het einde van het opgegeven expliciete pad exact overeenkomen met uw licentiebestand.

Bijvoorbeeld, u kunt de licentiebestandsnaam wijzigen naar *Aspose.Slides.lic.xml*. Vervolgens moet u in uw code het pad naar het bestand (eindigend op *Aspose.Slides.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/#setlicense_1)‑methode.
{{% /alert %}}

### **Stream**
U kunt een licentie uit een stream laden. Deze C#‑code laat zien hoe u een licentie vanuit een stream toepast:

``` csharp
// Instantieert de License-klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Opent het licentiebestand als stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Stelt de licentie in via een stream
license.SetLicense(licenseStream);
```

### **Ingebedde resource**
U kunt de licentie aan uw applicatie toevoegen (zodat u deze niet kwijtraakt) door het licentiebestand als ingebedde resource in één van de assemblies te plaatsen die de component‑DLL aanroepen (meegeleverd in Aspose.Slides). 

Zo voegt u een licentiebestand toe als ingebedde resource:

1. Voeg in Visual Studio het licentiebestand (.lic) toe aan het project via **File** > **Add Existing Item** > **Add**. 
2. Selecteer het bestand in de **Solution Explorer**.
3. Stel in het **Properties**‑venster de **Build Action** in op **Embedded Resource**.
4. Om de ingebedde licentie in de assembly te benaderen, voeg het licentiebestand toe als ingebedde resource aan het project en geef vervolgens de licentiebestandsnaam door aan de `SetLicense`‑methode. 

De `License`‑klasse vindt het licentiebestand automatisch in de ingebedde resources. U hoeft de methoden `GetExecutingAssembly` en `GetManifestResourceStream` van de `System.Reflection.Assembly`‑klasse in het Microsoft .NET Framework niet handmatig aan te roepen.

Deze C#‑code laat zien hoe u een licentie als ingebedde resource instelt:

``` csharp
// Instantieert de License-klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Geeft de licentiebestandsnaam door die ingebed is in de assembly
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

## **Thread Safety**
{{% alert title="Opmerking" color="warning" %}} 
De [license.SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/)‑methode is niet thread‑safe. Als deze methode gelijktijdig vanuit meerdere threads wordt aangeroepen, kunt u synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen. 
{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie gebeurt lokaal met behulp van het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er nadat het één‑jaar abonnement is verlopen? Stopt de bibliotheek met werken?

Nee. De licentie is perpetual: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder verlenging.