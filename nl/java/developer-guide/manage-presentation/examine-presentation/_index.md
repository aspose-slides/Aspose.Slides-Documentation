---
title: Presentatie‑informatie ophalen en bijwerken in Java
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/java/examine-presentation/
keywords:
- presentatieformaat
- presentatie‑eigenschappen
- document‑eigenschappen
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
- Java
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint‑ en OpenDocument‑presentaties met Java voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen, en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/) API's en tonen typische bewerkingen voor het werken met presentatiemeta‑gegevens.

## **Controleer het formaat van een presentatie**

Voordat u aan een presentatie werkt, wilt u wellicht weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze Java‑code:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Haal presentatieweigenschappen op**

Deze Java‑code laat zien hoe u presentatieweigenschappen (informatie over de presentatie) kunt opvragen:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

U wilt misschien de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#DocumentProperties--) klasse bekijken.

## **Werk presentatieweigenschappen bij**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) methode die u in staat stelt wijzigingen aan te brengen in presentatieweigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Oorspronkelijke documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit codevoorbeeld laat zien hoe u enkele presentatieweigenschappen kunt bewerken:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder weergegeven.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingsattributen kunt u deze links handig vinden:

- [Controleren of een presentatie versleuteld is](https://docs.aspose.com/slides/nl/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie schrijfbeveiligd (alleen‑lezen) is](https://docs.aspose.com/slides/nl/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie met wachtwoord is beveiligd voordat deze wordt geladen](https://docs.aspose.com/slides/nl/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat is gebruikt om een presentatie te beveiligen](https://docs.aspose.com/slides/nl/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [embedded‑font‑informatie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) op presentatieniveau, en vergelijk die vermeldingen vervolgens met de set van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getFonts--) om te bepalen welke lettertypen cruciaal zijn voor weergave.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Doorloop de [slide‑collectie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/) en controleer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getHidden--) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlideSize--) en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te anticiperen.

**Is er een snelle manier om te zien of grafieken naar externe gegevensbronnen verwijzen?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getDataSourceType--), en noteer of de gegevens intern of via een koppeling zijn, inclusief eventuele verbroken koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die het weergeven of exporteren naar PDF kunnen vertragen?**

Tel voor elke dia het aantal objecten en let op grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om mogelijke prestatieknelpunten te markeren.