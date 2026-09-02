---
title: Ophalen en bijwerken van presentatiesinformatie op Android
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
description: "Verken dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Java voor snellere inzichten en slimmere inhoudscontroles."
---
## **Overzicht**

Dit artikel toont hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en deze eigenschappen kunt bijwerken wanneer dat nodig is.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemeta‑gegevens.

## **Controleer het formaat van een presentatie**

Voordat u aan een presentatie werkt, wilt u misschien weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie momenteel staat.

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

## **Verkrijg presentatie‑eigenschappen**

Deze Java‑code toont u hoe u presentatie‑eigenschappen kunt ophalen (informatie over de presentatie):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

U kunt de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) klasse bekijken.

## **Werk presentatie‑eigenschappen bij**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) methode die u in staat stelt wijzigingen aan te brengen in presentatie‑eigenschappen.

Stel, we hebben een PowerPoint‑presentatie met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld toont u hoe u enkele presentatie‑eigenschappen kunt bewerken:

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

- [Presentaties met wachtwoord beveiligen](/slides/nl/androidjava/password-protected-presentation/)
- [Presentaties met schrijfbeveiliging](/slides/nl/androidjava/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [informatie over ingesloten lettertypen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) op presentatieniveau, en vergelijk vervolgens die vermeldingen met de set van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getFonts--) om te bepalen welke lettertypen cruciaal zijn voor het renderen.

**Hoe kan ik snel bepalen of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [dia‑collectie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/) en inspecteer de [zichtbaarheids‑vlag](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getHidden--) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlideSize--) en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en noteer of de gegevens intern of op een koppeling gebaseerd zijn, inclusief eventuele verbroken koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die het renderen of PDF‑export kunnen vertragen?**

Tel per dia het aantal objecten en zoek naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; wijs een ruwe complexiteitsscore toe om mogelijke prestatiefocuspunten te markeren.