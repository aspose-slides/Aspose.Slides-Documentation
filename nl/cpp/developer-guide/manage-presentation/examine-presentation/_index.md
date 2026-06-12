---
title: Presentatie-informatie ophalen en bijwerken in C++
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/cpp/examine-presentation/
keywords:
- presentatieformaat
- presentatie-eigenschappen
- documenteigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX onderzoeken
- PPT onderzoeken
- ODP onderzoeken
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met C++ voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel laat zien hoe je presentatiewinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe je het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen kunt bijwerken wanneer nodig.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer het formaat van een presentatie**

Voordat je met een presentatie werkt, wil je mogelijk weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

Je kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze C++-code:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Haal presentatieweigenschappen op**

Deze C++-code laat zien hoe je presentatieweigenschappen (informatie over de presentatie) kunt ophalen:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Werk presentatieweigenschappen bij**

Aspose.Slides biedt de [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationinfo/updatedocumentproperties/)-methode die je in staat stelt wijzigingen aan te brengen in presentatieweigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe je enkele presentatieweigenschappen kunt bewerken:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingskenmerken ervan, kunnen deze links nuttig zijn:

- [Controleren of een presentatie versleuteld is](https://docs.aspose.com/slides/nl/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie schrijfbeveiligd (alleen‑lezen) is](https://docs.aspose.com/slides/nl/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie met wachtwoord beveiligd is voordat deze wordt geladen](https://docs.aspose.com/slides/nl/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat is gebruikt om een presentatie te beveiligen](https://docs.aspose.com/slides/nl/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [informatie over ingesloten lettertypen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) op presentatieniveau, en vergelijk vervolgens die vermeldingen met de verzameling [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen cruciaal zijn voor het renderen.

**Hoe kan ik snel bepalen of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [dia-collectie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/get_hidden/) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte en -oriëntatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slidesize/) met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen refereren?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) en noteer of de gegevens intern of op een link gebaseerd zijn, inclusief eventuele kapotte links.

**Hoe kan ik 'zware' dia's beoordelen die het renderen of exporteren naar PDF kunnen vertragen?**

Tel per dia het aantal objecten en zoek naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om mogelijke prestatieknelpunten te markeren.