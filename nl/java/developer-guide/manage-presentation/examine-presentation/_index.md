---
title: Presentatie-informatie ophalen en bijwerken in Java
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Java voor snellere inzichten en slimmere contentcontroles."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de API's [PresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/) en tonen typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer een presentatieformaat**

Voordat u aan een presentatie werkt, wilt u wellicht weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze Java‑code:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Haal presentatieweigenschappen op**

Deze Java‑code laat zien hoe u presentatieweigenschappen (informatie over de presentatie) kunt ophalen:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

U wilt mogelijk de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#DocumentProperties--) klasse bekijken.

## **Werk presentatieeigenschappen bij**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) methode die u in staat stelt wijzigingen aan te brengen in de presentatieweigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de documenteigenschappen zoals hieronder weergegeven.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe u enkele presentatieweigenschappen kunt bewerken:

```java
import com.aspose.slides.*;
import java.util.Date;

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

- [Presentaties met wachtwoord beveiligen](/slides/nl/java/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/java/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [informatie over ingesloten lettertypen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) op presentatieniveau, en vergelijk die vermeldingen vervolgens met de verzameling [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getFonts--) om te bepalen welke lettertypen cruciaal zijn voor het renderen.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [dia‑collectie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getHidden--) van elke dia.

**Kan ik detecteren of er een aangepast diaformaat en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlideSize--) en oriëntatie met de standaardpresets; dit helpt bij het anticiperen op gedrag bij afdrukken en exporteren.

**Is er een snelle manier om te zien of diagrammen naar externe gegevensbronnen verwijzen?**

Ja. Loop door alle [diagrammen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getDataSourceType--), en noteer of de gegevens intern of link‑gebaseerd zijn, inclusief eventuele verbroken koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die het renderen of PDF‑export kunnen vertragen?**

Tel per dia het aantal objecten en zoek naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om potentiële prestatie‑knelpunten te markeren.