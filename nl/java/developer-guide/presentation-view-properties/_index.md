---
title: Presentatie‑weergave‑eigenschappen ophalen en bijwerken in Java
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- schetsinhoud
- schets‑iconen
- verticale splitter vastklikken
- enkele weergave
- balkstatus
- afmeting
- automatisch aanpassen
- standaard zoom
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Java om PPT, PPTX en ODP‑dia’s aan te passen—layout, zoomniveaus en weergave‑instellingen te regelen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onder­inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet tonen bij het weergeven van schetsinhoud in een van de inhoudsgebieden van de normale weergavemöde.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale scheidingsbalk moet vastklikken in een geminimaliseerde staat wanneer het zij‑gebied voldoende klein is.

Eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur geeft aan één enkel inhoudsgebied dat het volledige venster vult boven de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie kiezen om een van de inhoudsgebieden over het gehele venster te tonen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geven de staat aan waarin de horizontale of verticale scheidingsbalk moet worden weergegeven. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) geven de afmeting van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave aan, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) overeenkomstig.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmeting van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd, noch gemaximaliseerd).

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe grootte bij het aanpassen van de grootte van het venster dat de weergave binnen de applicatie bevat.

Een voorbeeld hieronder laat zien hoe u toegang krijgt tot de eigenschappen [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) van een presentatie.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Herstel de weergave-eigenschappen van de presentatie
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standaard zoomwaarde instellen**

{{% alert color="info" %}} 

Aspose.Slides for Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) evenals [getNotesViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in [Aspose.Slides](/slides/nl/) worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het voorbeeld hieronder hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```java
import com.aspose.slides.*;

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

### Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), niet per sectie, dus één set parameters geldt voor het volledige document wanneer het wordt geopend.

### Kan ik vooraf verschillende weergave‑staten definiëren voor verschillende gebruikers?

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Bekijk‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

### Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) op presentatieniveau worden opgeslagen, kunt u ze in een sjabloon insluiten en vervolgens nieuwe documenten op basis daarvan maken met dezelfde initiële weergave‑configuratie.