---
title: Informatie over presentaties ophalen en bijwerken op Android
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Java voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en deze eigenschappen kunt bijwerken wanneer nodig.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Formaat van een presentatie controleren**

Voordat u aan een presentatie werkt, wilt u misschien weten in welk formaat (PPT, PPTX, ODP en anderen) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze Java‑code:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Presentatie‑eigenschappen ophalen**

Deze Java‑code laat zien hoe u presentatieseigenschappen (informatie over de presentatie) kunt ophalen:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

U wilt misschien de eigenschappen bekijken onder de klasse DocumentProperties.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) methode die u in staat stelt wijzigingen aan te brengen in presentatieseigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe u enkele presentatieseigenschappen kunt bewerken:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingsattributen kunt u deze links nuttig vinden:

- [Controleren of een presentatie versleuteld is](https://docs.aspose.com/slides/nl/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie alleen-lezen is (schrijfbeveiligd)](https://docs.aspose.com/slides/nl/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie met wachtwoord beschermd is voordat deze wordt geladen](https://docs.aspose.com/slides/nl/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat is gebruikt om een presentatie te beschermen](https://docs.aspose.com/slides/nl/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar ingesloten‑lettertype‑informatie op presentatieniveau en vergelijk die vermeldingen vervolgens met de set van daadwerkelijk gebruikte lettertypen in de inhoud om te bepalen welke lettertypen essentieel zijn voor het renderen.

**Hoe kan ik snel zien of het bestand verborgen dia’s bevat en hoeveel?**

Itereer door de slide‑collection en inspecteer de zichtbaarheids‑vlag van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige slide‑size en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te anticiperen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen refereren?**

Ja. Doorloop alle charts, controleer hun data‑source en noteer of de data intern of via een link is, inclusief eventuele gebroken links.

**Hoe kan ik ‘zware’ dia's beoordelen die mogelijk het renderen of PDF‑export vertragen?**

Voor elke dia tel je het aantal objecten en zoek je naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om potentiële prestatieknelpunten te markeren.