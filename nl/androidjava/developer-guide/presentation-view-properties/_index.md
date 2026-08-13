---
title: Ophalen en bijwerken van presentatie‑weergave‑eigenschappen op Android
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/androidjava/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale splitter vastzetten
- enkele weergave
- balkstatus
- afmeting
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Android via Java om PPT-, PPTX- en ODP‑dia’s aan te passen - lay‑outs, zoomniveaus en weergave‑instellingen aanpassen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onderkant inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat wanneer het opnieuw wordt geopend de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst werd opgeslagen.

Method[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

De methoden[getShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en[setShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden[getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en[setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter moet worden vastgezet in een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De eigenschap[getPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en[setPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur heeft om een enkel‑inhoudsgebied op volledig venster te zien in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld kan de applicatie ervoor kiezen om een van de inhoudsgebieden over het gehele venster weer te geven.

De methoden[getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en[getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) bepalen de toestand waarin de horizontale of verticale splitsbalk moet worden weergegeven. Een horizontale splitsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) en[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

De methoden[getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en[getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) geven de afmetingen aan van respectievelijk het bovenste of zij‑dia‑gebied van de normale weergave, wanneer de waarde[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored) wordt toegepast op[getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en[getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) overeenkomstig.

## **Over het herstellen van INormalViewProperties**

Geeft de afmeting van het dia‑gebied (breedte wanneer een kind van[getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer een kind van[getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave aan, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).  

De methode[getDimensionSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificeert de grootte van het dia‑gebied (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).  

De methode[getAutoAdjust](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.  

Hieronder wordt een voorbeeld gegeven dat laat zien hoe u toegang krijgt tot de eigenschappen ViewProperties.getNormalViewProperties voor een presentatie.

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
## **Standaardzoomwaarde instellen**

{{% alert color="info" %}} 

Aspose.Slides voor Android via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de ViewProperties van een presentatie te configureren. getSlideViewProperties evenals getNotesViewProperties kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe u de View‑eigenschappen van een Presentation kunt instellen in Aspose.Slides. 

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de[Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.  
1. Stel de[View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van de[Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) in.  
1. Schrijf de presentatie weg als een[PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in percentages voor de diaweergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in percentages voor notitie‑weergave 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **FAQ**

### Kan ik verschillende weergave‑instellingen voor verschillende secties van een presentatie instellen?

View‑instellingen worden gedefinieerd op presentatieniveau (Normal View/Slide View), niet per sectie, dus één set parameters is van toepassing op het gehele document wanneer het wordt geopend.

### Kan ik verschillende weergavetoestanden vooraf definiëren voor verschillende gebruikers?

Nee. De instellingen worden opgeslagen in het bestand en gedeeld. Viewer‑applicaties kunnen rekening houden met gebruikersvoorkeuren, maar het bestand zelf bevat één set weergave‑eigenschappen.

### Kan ik een sjabloon met vooraf gedefinieerde View‑eigenschappen maken zodat nieuwe presentaties op dezelfde manier openen?

Ja. Omdat view‑eigenschappen worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten daarvan maken met dezelfde initiële weergave‑configuratie.