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
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides voor .NET. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze licentiegids."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt het extraheren van tekst tot één dia.

Dit artikel legt uit hoe licenties werken in Aspose.Slides en hoe u een licentie kunt toepassen voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingesloten resource met behulp van de `License`‑klasse. Het artikel laat ook zien hoe u kunt verifiëren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**
{{% alert color="primary" %}} 

U kunt een evaluatieversie van **Aspose.Slides for NET** downloaden van [de NuGet‑downloadpagina](https://www.nuget.org/packages/Aspose.Slides.NET/). De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie van het product. Het evaluatiepakket is hetzelfde als het aangekochte pakket. De evaluatieversie wordt gewoon gelicentieerd nadat u een paar regels code hebt toegevoegd (om de licentie toe te passen).

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u [een licentie kopen](https://purchase.aspose.com/buy). We raden u aan de verschillende abonnementsvormen door te nemen. Als u vragen heeft, neem dan contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie wordt geleverd met een eenjarige abonnement voor gratis upgrades naar nieuwe versies of patches die binnen de abonnementsperiode worden uitgebracht. Gebruikers met gelicentieerde producten of zelfs evaluatieversies krijgen gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Hoewel de evaluatieversie van Aspose.Slides (zonder opgegeven licentie) de volledige productfunctionaliteit biedt, voegt deze een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. 
* U bent beperkt tot één dia bij het extraheren van tekst uit presentatieslides.

{{% alert color="primary" %}} 

Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Zie de pagina [Hoe een tijdelijke licentie te krijgen](https://purchase.aspose.com/temporary-license) voor meer informatie.

{{% /alert %}}

## **Licenties in Aspose.Slides**
* Een evaluatieversie wordt gelicentieerd nadat u een licentie heeft gekocht en een paar regels code hebt toegevoegd (om de licentie toe te passen).
* De licentie is een platte‑tekst XML‑bestand dat details bevat, zoals de productnaam, het aantal ontwikkelaars waarvoor het is gelicentieerd, de vervaldatum van het abonnement, enzovoort. 
* Het licentiebestand is digitaal ondertekend, dus u mag het bestand niet wijzigen. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.
* Aspose.Slides for .NET zoekt normaal gesproken de licentie op de volgende locaties:
  * Een expliciet pad
  * De map die de dll van het component bevat (meegeleverd met Aspose.Slides)
  * De map die de assembly bevat die de dll van het component heeft aangeroepen (meegeleverd met Aspose.Slides)
  * De map die de entry‑assembly bevat (uw .exe)
  * Een ingesloten resource in de assembly die de dll van het component heeft aangeroepen (meegeleverd met Aspose.Slides).
* Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u Aspose.Slides gebruikt. U hoeft de licentie slechts één keer per applicatie of proces in te stellen.

{{% alert color="primary" %}} 

U wilt misschien [Metered Licensing](https://docs.aspose.com/slides/nl/net/metered-licensing/) bekijken.

{{% /alert %}} 

## **Licentie toepassen**
Een licentie kan worden geladen vanuit een **bestand**, **stream** of **ingesloten resource**. 

{{% alert color="primary" %}}

Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/net/aspose.slides/license)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" %}} 

Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.

{{% /alert %}}

### **File**
De eenvoudigste methode om een licentie in te stellen vereist dat u het licentiebestand in dezelfde map plaatst als de DLL van het component (meegeleverd met Aspose.Slides) en alleen de bestandsnaam zonder pad opgeeft.

Deze C#‑code toont hoe u een licentiebestand instelt:

``` csharp
// Maakt een instantie van de License‑klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Stelt het pad van het licentiebestand in
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Als u het licentiebestand in een andere directory plaatst, moet bij het aanroepen van de [SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/#setlicense_1)‑methode de licentiebestandsnaam aan het einde van het opgegeven expliciete pad exact overeenkomen met uw licentiebestand.

Bijvoorbeeld, u kunt de licentiebestandsnaam wijzigen naar *Aspose.Slides.lic.xml*. Vervolgens moet u in uw code het pad naar het bestand (dat eindigt op *Aspose.Slides.lic.xml*) doorgeven aan de [SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/#setlicense_1)‑methode.

{{% /alert %}}

### **Stream**
U kunt een licentie laden vanuit een stream. Deze C#‑code toont hoe u een licentie vanuit een stream toepast:

``` csharp
// Maakt een instantie van de License‑klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Stelt de licentie in via een stream
license.SetLicense(myStream);
```

### **Embedded Resource**
U kunt de licentie in uw applicatie opnemen (om verlies te voorkomen) door de licentie toe te voegen als een ingesloten resource in een van de assemblies die de component‑DLL (meegeleverd met Aspose.Slides) aanroepen. 

Zo voegt u een licentiebestand toe als ingesloten resource:

1. In Visual Studio voegt u het licentiebestand (.lic) toe aan het project via: Ga naar **Bestand** > **Bestaand item toevoegen** > **Toevoegen**. 
2. Selecteer het bestand in de **Solution Explorer**.
3. In het **Eigenschappen**‑venster stelt u **Build Action** in op **Embedded Resource**.
4. Om de ingesloten licentie in de assembly te benaderen, voegt u het licentiebestand toe als ingesloten resource aan het project en geeft u vervolgens de bestandsnaam door aan de `SetLicense`‑methode. 


De `License`‑klasse vindt het licentiebestand automatisch in de ingesloten resources. U hoeft de methoden `GetExecutingAssembly` en `GetManifestResourceStream` van de `System.Reflection.Assembly`‑klasse in het Microsoft .NET‑framework niet aan te roepen.

``` csharp
// Maakt een instantie van de License‑klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Geeft de naam van het licentiebestand door dat in de assembly is ingesloten
license.SetLicense("Aspose.Slides.lic");
```

## **Licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. Deze C#‑code toont hoe u een licentie valideert:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Thread‑veiligheid**

{{% alert title="Note" color="warning" %}} 

De [license.SetLicense](https://reference.aspose.com/slides/nl/net/aspose.slides/license/setlicense/)‑methode is niet thread‑veilig. Als deze methode gelijktijdig vanuit meerdere threads moet worden aangeroepen, kunt u synchronisatie‑primitieven (zoals een lock) gebruiken om problemen te voorkomen. 

{{% /alert %}}

## **FAQ**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentievalidatie gebeurt lokaal met behulp van het licentiebestand; er is geen internetverbinding nodig.

**Wat gebeurt er nadat het eenjarige abonnement verloopt? Stop de bibliotheek met werken?**

Nee. De licentie is eeuwigdurend: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u bent alleen niet gerechtigd nieuwere releases te gebruiken zonder vernieuwing.