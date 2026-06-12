---
title: Opvragen en bijwerken van presentatie‑weergave‑eigenschappen op Android
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/androidjava/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale‑splitter‑snap
- enkele weergave
- balk‑status
- dimensiegrootte
- automatisch‑aanpassen
- standaard‑zoom
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java weergave‑eigenschappen om PPT, PPTX en ODP‑dia’s aan te passen—lay‑outs, zoomniveaus en weergave‑instellingen wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijgebied en een onderste inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfaces en hun afstammelingen, enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType) zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van de outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter moet snappen naar een geminimaliseerde staat wanneer het zijgebied voldoende klein is.

De eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur geeft aan een enkelinhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden in het volledige venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geven de status aan waarin de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitterbalk scheidt de dia van het zijinhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificeren de afmetingen van respectievelijk het linkerdeel‑ of bovendeel‑slidegebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) overeenkomstig.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd noch gemaximaliseerd).

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder toont hoe u de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) voor een presentatie kunt benaderen.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Herstel de weergave‑eigenschappen van de presentatie
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Stel de standaard zoomwaarde in**

{{% alert color="primary" %}} 
Aspose.Slides voor Android via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) in [Aspose.Slides](/slides/nl/) in te stellen.
{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) aan.
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) in.
1. Sla de presentatie op als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand. In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notities‑weergave.

```java
Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in procenten voor de dia‑weergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in procenten voor de notitie‑weergave 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik verschillende weergave‑instellingen voor verschillende secties van een presentatie instellen?**

[View settings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--) zijn gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), niet per sectie, dus één set parameters geldt voor het volledige document wanneer het wordt geopend.

**Kan ik verschillende weergavetoestanden voor verschillende gebruikers vooraf definiëren?**

Nee. De instellingen worden opgeslagen in het bestand en zijn gedeeld. Viewer‑applicaties kunnen de gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon met vooraf gedefinieerde View Properties voorbereiden zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--) zijn opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.