---
title: Licenties
type: docs
weight: 120
url: /nl/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides voor C++. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze gids voor licenties."
---
## **Overzicht**

Aspose.Slides kan worden gebruikt in evaluatiemodus of met een geldige licentie. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt het extraheren van tekst tot één dia.

Dit artikel legt uit hoe licenties werken in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingebedde resource met behulp van de `License`‑klasse. Het artikel toont ook hoe u kunt controleren of een licentie correct is toegepast.

## **Evalueer Aspose.Slides**

{{% alert color="primary" %}} 

U kunt een evaluatieversie van **Aspose.Slides for C++** downloaden vanaf [de NuGet‑downloadpagina](https://www.nuget.org/packages/Aspose.Slides.CPP/). De evaluatieversie biedt dezelfde functionaliteit als het gelicentieerde product. In feite is het evaluatie‑pakket identiek aan het gekochte; het wordt gewoon gelicentieerd zodra u een paar regels code toevoegt om de licentie toe te passen.

Wanneer u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u [een licentie aanschaffen](https://purchase.aspose.com/buy). We raden u aan de beschikbare abonnementsvormen te bekijken. Als u vragen heeft, kunt u gerust contact opnemen met het Aspose‑verkoopteam.

Elke Aspose‑licentie bevat een abonnement van één jaar voor gratis upgrades, inclusief nieuwe versies en bug‑fixes die gedurende die periode worden uitgebracht. Of u nu een gelicentieerde of een evaluatieversie gebruikt, u ontvangt gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Hoewel de Aspose.Slides‑evaluatieversie (wanneer er geen licentie is toegepast) de volledige productfunctionaliteit biedt, voegt hij een evaluatiewatermerk toe aan de bovenkant van het document tijdens open‑ en opslaan‑bewerkingen.
* Tekstuitvoer is beperkt tot één dia bij gebruik van de evaluatieversie.

{{% alert color="primary" %}} 

Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Voor meer informatie, zie de pagina [Hoe krijg je een tijdelijke licentie](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licenties in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie hebt aangeschaft en deze toepast door een paar regels code toe te voegen.
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement en meer.
* Het licentiebestand is digitaal ondertekend, dus mag het niet worden gewijzigd. Zelfs een accidentele wijziging — zoals het toevoegen van een regeleinde — maakt het bestand ongeldig.
* Aspose.Slides for C++ zoekt doorgaans naar het licentiebestand op de volgende locaties:
  * Een pad dat expliciet in uw code is opgegeven
  * De map die de DLL van het component bevat (meegeleverd met Aspose.Slides)
  * De map die de assembly bevat die de DLL van het component aanroept
* Om de beperkingen van de evaluatieversie te vermijden, moet u de licentie instellen voordat u Aspose.Slides gebruikt. Een licentie hoeft slechts één keer per toepassing of proces te worden ingesteld.

## **Een licentie toepassen**

Een licentie kan worden geladen vanuit een **bestand**, een **stream** of een **ingebedde resource**.

{{% alert color="primary" %}}

Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.license/)‑klasse voor licentie‑bewerkingen.

{{% /alert %}} 

{{% alert color="warning" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.

{{% /alert %}}

### **File**

De eenvoudigste manier om een licentie in te stellen, is het licentiebestand in dezelfde map als de DLL van het component te plaatsen (meegeleverd met Aspose.Slides) en alleen de bestandsnaam op te geven, zonder het pad.

De onderstaande C++‑code laat zien hoe u een licentiebestand instelt:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode de bestandsnaam aan het einde van het opgegeven expliciete pad exact overeenkomen met de naam van uw licentiebestand.

Bijvoorbeeld, als u uw licentiebestand hernoemt naar *Aspose.Slides.lic.xml*, moet u het volledige pad dat eindigt op *Aspose.Slides.lic.xml* doorgeven aan de [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode in uw code.

{{% /alert %}}

### **Stream**

U kunt een licentie laden vanuit een stream. De onderstaande C++‑code laat zien hoe u een licentie toepast vanuit een stream:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Een licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. De onderstaande C++‑code laat zien hoe u een licentie valideert:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Thread‑veiligheid**

{{% alert title="Note" color="warning" %}} 

De [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode is **niet thread‑veilig**. Als u deze methode tegelijk vanuit meerdere threads moet aanroepen, wordt aanbevolen om synchronisatie‑primitieven (zoals een lock) te gebruiken om mogelijke problemen te voorkomen.

{{% /alert %}}

## **FAQ**

**Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?**

Ja. Licentievalidatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding nodig.

**Wat gebeurt er nadat het eenjarige abonnement is verlopen? Stopt de bibliotheek met werken?**

Nee. De licentie is levenslang: u kunt de versies blijven gebruiken die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te vernieuwen.