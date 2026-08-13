---
title: Licenseren
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
description: "Pas licenties toe, beheer ze en los problemen op in Aspose.Slides voor C++. Zorg voor ononderbroken toegang tot alle functies met onze stapsgewijze gids voor licenseren."
---
## **Overzicht**

Aspose.Slides kan in evaluatiemodus of met een geldige licentie worden gebruikt. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe wanneer presentaties worden geopend of opgeslagen en beperkt de tekstextractie tot één dia.

Dit artikel legt uit hoe licenseren werkt in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand, stream of ingebedde resource met behulp van de `License`-klasse. Het artikel toont ook hoe u kunt controleren of een licentie correct is toegepast.

## **Aspose.Slides evalueren**

{{% alert color="info" %}} 

U kunt een evaluatieversie van **Aspose.Slides for C++** downloaden van [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.CPP/). De evaluatieversie biedt dezelfde functionaliteit als het gelicentieerde product. In feite is het evaluatiepakket identiek aan het gekochte pakket-het wordt simpelweg gelicenseerd zodra u een paar regels code toevoegt om de licentie toe te passen.

Zodra u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u [een licentie aanschaffen](https://purchase.aspose.com/buy). We raden aan de beschikbare abonnementstypen te bekijken. Als u vragen heeft, kunt u gerust contact opnemen met het sales-team van Aspose.

Elke Aspose-licentie omvat een eenjarige abonnement voor gratis upgrades, inclusief nieuwe versies en foutoplossingen die gedurende die periode worden uitgebracht. Of u nu een gelicentieerde of een evaluatieversie gebruikt, u krijgt gratis en onbeperkte technische ondersteuning.

{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* Hoewel de Aspose.Slides-evaluatieversie (zonder toegepaste licentie) de volledige productfunctionaliteit biedt, voegt ze een evaluatiewatermerk toe aan de bovenkant van het document tijdens het openen en opslaan.
* Tekstextractie is beperkt tot één dia bij gebruik van de evaluatieversie.

{{% alert color="info" %}} 

Om Aspose.Slides zonder beperkingen te testen, kunt u een **30-daagse tijdelijke licentie** aanvragen. Voor meer informatie, zie de pagina [Hoe een tijdelijke licentie aanvragen](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licenseren in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie aanschaft en deze toepast door een paar regels code toe te voegen.
* De licentie is een platte-tekst XML-bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement, enzovoort.
* Het licentiebestand is digitaal ondertekend, dus mag het niet worden gewijzigd. Zelfs een accidentele wijziging - zoals het toevoegen van een regeleinde - maakt het bestand ongeldig.
* Aspose.Slides for C++ zoekt het licentiebestand doorgaans in de volgende locaties:
  * Een pad dat expliciet in uw code is opgegeven
  * De map die de DLL van het component bevat (meegeleverd met Aspose.Slides)
  * De map die de assembly bevat die de DLL van het component aanroept
* Om de beperkingen van de evaluatieversie te vermijden, moet u de licentie instellen voordat u Aspose.Slides gebruikt. Een licentie hoeft slechts één keer per toepassing of proces te worden ingesteld.

## **Licentie toepassen**

Een licentie kan worden geladen vanuit een **bestand**, een **stream** of een **ingebedde resource**.

{{% alert color="info" %}}

Aspose.Slides levert de [License](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.license/)‑klasse voor licentie‑operaties.

{{% /alert %}} 

{{% alert color="warning" %}}

Nieuwe licenties kunnen Aspose.Slides alleen activeren vanaf versie 21.4 of later. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.

{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen is het licentiebestand in dezelfde map als de DLL van het component (meegeleverd met Aspose.Slides) te plaatsen en alleen de bestandsnaam op te geven, zonder het pad.

De volgende C++‑code toont hoe u een licentiebestand instelt:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

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

U kunt een licentie vanuit een stream laden. De volgende C++‑code toont hoe u een licentie vanuit een stream toepast:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Licentie valideren**

Om te controleren of een licentie correct is ingesteld, kunt u deze valideren. De volgende C++‑code toont hoe u een licentie valideert:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Thread-veiligheid**

{{% alert title="Note" color="warning" %}} 

De [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode is **niet thread-safe**. Als u deze methode vanuit meerdere threads tegelijk moet aanroepen, wordt aanbevolen synchronisatie-primitieven (zoals een lock) te gebruiken om mogelijke problemen te voorkomen.

{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentievalidatie gebeurt lokaal met behulp van het licentiebestand; er is geen internetverbinding nodig.

### Wat gebeurt er nadat het eenjarige abonnement is verlopen? Zal de bibliotheek stoppen met werken?

Nee. De licentie is levenslang: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases meer gebruiken zonder te vernieuwen.