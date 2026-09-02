---
title: Ophalen en bijwerken van presentatie-informatie in .NET
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met .NET voor snellere inzichten en slimmer content-audit."
---
## **Overzicht**

Dit artikel toont hoe je presentatie‑informatie kunt inspecteren in Aspose.Slides. Het legt uit hoe je het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetagegevens.

## **Controleer een presentatieformaat**

Voordat je aan een presentatie werkt, wil je misschien weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

Je kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze C#‑code:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Haal presentatie‑eigenschappen op**

Deze C#‑code laat zien hoe je presentatie‑eigenschappen kunt ophalen (informatie over de presentatie):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Je wilt misschien de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/documentproperties/#properties) klasse bekijken.

## **Werk presentatie‑eigenschappen bij**

Aspose.Slides biedt de methode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) waarmee je wijzigingen kunt aanbrengen in presentatie‑eigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe je enkele presentatie‑eigenschappen kunt bewerken:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen staan hieronder weergegeven.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en haar beveiligingsattributen vind je de volgende links wellicht nuttig:

- [Presentaties met wachtwoord beveiligen](/slides/nl/net/password-protected-presentation/)
- [Presentaties met schrijfbescherming](/slides/nl/net/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [informatie over ingesloten lettertypen](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts/) op het presentatieniveau en vergelijk die vermeldingen vervolgens met de lijst van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen cruciaal zijn voor weergave.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Doorloop de [dia‑collectie](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/) en controleer voor elke dia de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/hidden/).

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slidesize/) en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of diagrammen verwijzen naar externe gegevensbronnen?**

Ja. Doorloop alle [diagrammen](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/) en noteer of de gegevens intern of via een koppeling zijn, inclusief eventuele kapotte koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Tel per dia het aantal objecten en let op grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om potentiële prestatie‑knelpunten te markeren.