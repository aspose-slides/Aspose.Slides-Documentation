---
title: Presentatie-informatie ophalen en bijwerken in .NET
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
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met .NET voor snellere inzichten en slimmer inhoudsaudits."
---
## **Overzicht**

Dit artikel toont hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen kunt bijwerken indien nodig.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer het formaat van een presentatie**

Voordat u aan een presentatie werkt, wilt u wellicht achterhalen in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze C#‑code:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Presentatie‑eigenschappen ophalen**

Deze C#‑code laat zien hoe u presentatie‑eigenschappen (informatie over de presentatie) kunt ophalen:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

U wilt mogelijk de [properties under the DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/documentproperties/#properties)‑klasse bekijken.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationinfo/methods/updatedocumentproperties)‑methode waarmee u wijzigingen in presentatie‑eigenschappen kunt aanbrengen.

Stel, we hebben een PowerPoint‑presentatie met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint-presentatie](input_properties.png)

Dit codevoorbeeld laat zien hoe u enkele presentatie‑eigenschappen kunt bewerken:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint-presentatie](output_properties.png)

## **Handige links**

Om meer informatie te krijgen over een presentatie en de beveiligingsattributen, kunnen de volgende links nuttig zijn:

- [Controleren of een presentatie versleuteld is](https://docs.aspose.com/slides/nl/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie schrijfbeveiligd (alleen‑lezen) is](https://docs.aspose.com/slides/nl/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie wachtwoordbeveiligd is voordat deze wordt geladen](https://docs.aspose.com/slides/nl/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat is gebruikt om een presentatie te beschermen](https://docs.aspose.com/slides/nl/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar informatie over ingesloten lettertypen op presentatieniveau en vergelijk die items vervolgens met de set van daadwerkelijk gebruikte lettertypen in de inhoud om te bepalen welke lettertypen cruciaal zijn voor het renderen.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de slide-collection en inspecteer de zichtbaarheidsvlag van elke dia.

**Kan ik detecteren of een aangepaste dia‑afmeting en oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige slide-size en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of grafieken verwijzen naar externe gegevensbronnen?**

Ja. Doorloop alle charts, controleer hun data source en noteer of de data intern of linkgebaseerd is, inclusief eventuele kapotte koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die het renderen of exporteren naar PDF kunnen vertragen?**

Voor elke dia tel je het aantal objecten en let je op grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om mogelijke prestatieknelpunten te signaleren.