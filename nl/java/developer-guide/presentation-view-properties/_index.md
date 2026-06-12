---
title: Presentatieweergave-eigenschappen ophalen en bijwerken in Java
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- verticale splitter vastzetten
- enkele weergave
- balkstatus
- dimensiegrootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek de weergave-eigenschappen van Aspose.Slides voor Java om PPT-, PPTX- en ODP-dia's aan te passen - lay-outs, zoomniveaus en weergave-instellingen bij te stellen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onder‑inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de toepassing in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Methoden[getShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de toepassing pictogrammen moet weergeven bij het tonen van de outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Methoden[getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter naar een geminimaliseerde staat moet springen wanneer het zij‑gebied voldoende klein wordt.

Eigenschap[getPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur geeft aan één volledige venster‑inhoudsgebied in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld kan de toepassing ervoor kiezen om een van de inhoudsgebieden in het gehele venster weer te geven.

Methoden[getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificeren in welke toestand de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored).

Methoden[getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificeren de afmetingen van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored) is toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) dienovereenkomstig.

## **Over het herstellen van INormalViewProperties**

Specificeert de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).  

Methode[getDimensionSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificeert de grootte van het dia‑gebied (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).  

Methode[getAutoAdjust](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe grootte bij het wijzigen van de omvang van het venster waarin de weergave zich bevindt.  

Een voorbeeld hieronder laat zien hoe u toegang kunt krijgen tot de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) voor een presentatie.

```java
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
## **Standaardzoomwaarde instellen**

{{% alert color="primary" %}} 

Aspose.Slides voor Java ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie zodat, wanneer de presentatie wordt geopend, de zoom al ingesteld is. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatically worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe u de [View‑eigenschappen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in [Aspose.Slides](/slides/nl/) kunt instellen.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
1. Stel de [View‑eigenschappen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```java
Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoom‑waarde in procenten voor dia‑weergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoom‑waarde in procenten voor notitie‑weergave 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **FAQ**

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) worden gedefinieerd op presentatieniveau ([Normale weergave](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Dia‑weergave](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), niet per sectie, dus een enkele set parameters geldt voor het gehele document wanneer het wordt geopend.

**Kan ik vooraf verschillende weergave‑toestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑toepassingen kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [weergave‑eigenschappen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.