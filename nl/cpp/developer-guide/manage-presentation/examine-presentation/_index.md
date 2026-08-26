---
title: Opvragen en bijwerken van presentatiesinformatie in C++
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/cpp/examine-presentation/
keywords:
- presentatietype
- presentatieweigenschappen
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
description: "Verken dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met C++ voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer een presentatietype**

U wilt wellicht achterhalen in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich op dit moment bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze C++‑code:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Deze C++‑code laat zien hoe u presentatieweigenschappen (informatie over de presentatie) kunt ophalen:

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Werk presentatieweigenschappen bij**

Aspose.Slides biedt de [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) methode waarmee u wijzigingen in presentatieweigenschappen kunt aanbrengen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe u enkele presentatieweigenschappen kunt bewerken:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder weergegeven.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingsattributen kunt u deze links nuttig vinden:

- [Presentaties met wachtwoord beveiligen](/slides/nl/cpp/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/cpp/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [embedded-font information](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) op presentatieniveau en vergelijk die vermeldingen vervolgens met de set van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen essentieel zijn voor de weergave.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [slide collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidecollection/) en controleer voor elke dia de [visibility flag](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/get_hidden/).

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [slide size and orientation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slidesize/) met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of diagrammen externe gegevensbronnen refereren?**

Ja. Doorloop alle [charts](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/), controleer hun [data source](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) en noteer of de gegevens intern of via een koppeling zijn, inclusief eventuele kapotte koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Voor elke dia telt u het aantal objecten en zoekt u naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om mogelijke prestatieknelpunten te markeren.