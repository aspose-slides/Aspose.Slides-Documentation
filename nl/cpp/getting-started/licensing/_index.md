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
description: "Pas licenties toe, beheer ze en los problemen op in Aspose.Slides voor C++. Zorg voor ononderbroken toegang tot alle functies met onze stap-voor-stap gids voor licenties."
---
## **Overzicht**

Aspose.Slides kan in evaluatiemodus of met een geldige licentie worden gebruikt. De evaluatieversie biedt dezelfde functionaliteit als de gelicentieerde versie, maar voegt een evaluatiewatermerk toe aan elke dia van elke presentatie die wordt opgeslagen en kort de tekst af die uw code uit presentaties leest.

Dit artikel legt uit hoe licenties werken in Aspose.Slides en hoe u een licentie toepast voordat u de bibliotheek gebruikt. Een licentie kan worden geladen vanuit een bestand of een stream met behulp van de `License`‑klasse. Het artikel toont ook hoe u kunt valideren of een licentie correct is toegepast.

## **Evalueren Aspose.Slides**

{{% alert color="info" title="Note" %}}
U kunt een evaluatieversie van **Aspose.Slides for C++** downloaden van [zijn NuGet‑downloadpagina](https://www.nuget.org/packages/Aspose.Slides.Cpp/) of, als ZIP‑pakket, van de [downloadpagina](https://releases.aspose.com/slides/nl/cpp/). De evaluatieversie biedt dezelfde functionaliteit als het gelicentieerde product. In feite is het evaluatiepakket identiek aan het aangekochte – het wordt simpelweg gelicentieerd zodra u een paar code‑regels toevoegt om de licentie toe te passen.

Wanneer u tevreden bent met uw evaluatie van **Aspose.Slides**, kunt u [een licentie aanschaffen](https://purchase.aspose.com/pricing/slides/nl/cpp/). We raden aan de beschikbare abonnementsvormen te bekijken. Als u vragen heeft, neem dan gerust contact op met het verkoopteam van Aspose.

Elke Aspose‑licentie omvat een één‑jarig abonnement voor gratis upgrades, inclusief nieuwe versies en bug‑fixes die gedurende die periode worden uitgebracht. Of u nu een gelicentieerde of een evaluatieversie gebruikt, u ontvangt gratis en onbeperkte technische ondersteuning.
{{% /alert %}} 

**Beperkingen van de evaluatieversie**

* De evaluatieversie (zonder een opgegeven licentie) biedt volledige functionaliteit van het product, maar voegt een tekstvak met een evaluatiewatermerk toe aan elke dia van elke presentatie die wordt opgeslagen.
* Tekst die uw code uit een presentatie leest, wordt afgeknipt tot de eerste paar tekens, gevolgd door een melding over de evaluatiebeperking. Tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Note" %}}
Om Aspose.Slides zonder beperkingen te testen, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Voor meer informatie, zie de pagina [Hoe een tijdelijke licentie aan te vragen](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licenties in Aspose.Slides**

* Een evaluatieversie wordt gelicentieerd nadat u een licentie heeft gekocht en deze toepast door een paar code‑regels toe te voegen.
* De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor deze is gelicentieerd, de vervaldatum van het abonnement en meer.
* Het licentiebestand is digitaal ondertekend, dus mag het niet worden aangepast. Zelfs een accidentele wijziging—zoals het toevoegen van een regeleinde—zal het bestand ongeldig maken.
* Wanneer u een bestandsnaam zonder map opgeeft, zoekt Aspose.Slides for C++ het licentiebestand alleen in de huidige werkdirectory. Het zoekt niet in de map van uw uitvoerbare bestand of van de Aspose.Slides‑bibliotheek, geef dus het volledige pad op wanneer het licentiebestand elders is opgeslagen.
* Om de beperkingen van de evaluatieversie te vermijden, moet u de licentie instellen voordat u Aspose.Slides gebruikt. Een licentie hoeft slechts één keer per applicatie of proces te worden ingesteld.

## **Licentie toepassen**

Een licentie kan worden geladen vanuit een **bestand** of een **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides biedt de [License](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/)‑klasse voor licentie‑bewerkingen.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Nieuwe licenties kunnen Aspose.Slides alleen activeren met versie 21.4 of hoger. Oudere versies gebruiken een ander licentiesysteem en zullen deze licenties niet herkennen.
{{% /alert %}}

### **Bestand**

De eenvoudigste manier om een licentie in te stellen, is het licentiebestand in de werkdirectory van uw programma te plaatsen en alleen de bestandsnaam op te geven, zonder pad. Anders moet u het volledige pad naar het bestand opgeven.

De volgende C++‑code past het licentiebestand *Aspose.Slides.lic* toe vanuit de werkdirectory van het programma:

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

Als de licentie geldig is, keert [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/) terug en eindigt het programma zonder output; vanaf dat moment werkt Aspose.Slides zonder de evaluatiebeperkingen. Als het bestand niet in de werkdirectory staat, gooit de methode een [FileNotFoundException](https://reference.aspose.com/slides/nl/cpp/system.io/filenotfoundexception/) met het bericht *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Het voorbeeld behandelt de exceptie niet, dus stopt het programma.

{{% alert color="warning" title="Warning" %}}
Als u het licentiebestand in een andere map plaatst, moet bij het aanroepen van de [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode de bestandsnaam aan het einde van het opgegeven expliciete pad precies overeenkomen met de naam van uw licentiebestand.

Bijvoorbeeld, als u uw licentiebestand hernoemt naar *Aspose.Slides.lic.xml*, moet u het volledige pad dat eindigt op *Aspose.Slides.lic.xml* doorgeven aan de [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode in uw code.
{{% /alert %}}

### **Stream**

Laad een licentie vanuit een stream wanneer uw programma de licentie niet als een bestand opslaat dat het kan benoemen, bijvoorbeeld wanneer het de licentie uit een database leest. [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/) accepteert elke [Stream](https://reference.aspose.com/slides/nl/cpp/system.io/stream/) die de licentie bevat. Om het voorbeeld kort te houden, opent de volgende C++‑code *Aspose.Slides.lic* in de werkdirectory met [File::OpenRead](https://reference.aspose.com/slides/nl/cpp/system.io/file/openread/) en past de licentie toe vanuit die stream:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Een geldige licentie levert hetzelfde resultaat op als in het bestand‑voorbeeld. Als het bestand niet bestaat, gooit [File::OpenRead](https://reference.aspose.com/slides/nl/cpp/system.io/file/openread/) een [FileNotFoundException](https://reference.aspose.com/slides/nl/cpp/system.io/filenotfoundexception/) voordat de licentie wordt toegepast, en stopt het programma.

## **Licentie valideren**

Om te controleren of een licentie correct is ingesteld, roep u [License::IsLicensed](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/islicensed/) aan. Het retourneert `true` alleen nadat een geldige licentie is toegepast, en `false` daarvoor. De volgende C++‑code past het licentiebestand vanuit de werkdirectory toe en controleert het vervolgens:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Met een geldige licentie geeft het programma *License is good!* weer. Als het bestand ontbreekt of niet een licentiebestand is, gooit [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/) een exceptie vóór de controle, en stopt het programma zonder iets af te drukken. Als het bestand een licentie is waarvan de handtekening niet overeenkomt, bijvoorbeeld omdat het is bewerkt, retourneert SetLicense zonder fout maar `IsLicensed` geeft `false` terug, waardoor er niets wordt afgedrukt en Aspose.Slides in evaluatiemodus blijft.

## **Thread‑veiligheid**

{{% alert color="warning" title="Warning" %}}
De [License::SetLicense](https://reference.aspose.com/slides/nl/cpp/aspose.slides/license/setlicense/)‑methode is **niet thread‑veilig**. Als u deze methode gelijktijdig vanuit meerdere threads wilt aanroepen, wordt aanbevolen synchronisatiemechanismen (zoals een lock) te gebruiken om mogelijke problemen te voorkomen.
{{% /alert %}}

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?

Ja. Licentie‑validatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er nadat het één‑jarig abonnement is verlopen? Zal de bibliotheek stoppen met werken?

Nee. De licentie is levenslang: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te vernieuwen.