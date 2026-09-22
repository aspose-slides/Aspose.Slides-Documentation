---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen op Android
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/androidjava/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- schetsinhoud
- schets‑pictogrammen
- verticale splitter vastklikken
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Android via Java om PPT-, PPTX‑ en ODP‑presentaties aan te passen — lay‑outs, zoomniveaus en weergave‑instellingen wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie contentregio's: de dia zelf, een zij‑contentregio en een onderste contentregio. Eigenschappen met betrekking tot de positionering van de verschillende contentregio's. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van de presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet tonen bij het weergeven van de outline‑inhoud in een van de contentregio's van de normale weergavemodus.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter naar een geminimaliseerde staat moet springen wanneer de zijregio voldoende klein is.

Eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker een enkel‑contentregio over het volledige venster wil zien in plaats van de standaard normale weergave met drie contentregio's. Indien ingeschakeld, kan de applicatie ervoor kiezen om een van de contentregio's over het hele venster weer te geven.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificeren de status waarin de horizontale of verticale splitterbalk weergegeven moet worden. Een horizontale splitterbalk scheidt de dia van de contentregio onder de dia, een verticale splitterbalk scheidt de dia van de zij‑contentregio. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificeren de afmetingen van respectievelijk de bovenste of zij‑diaregeio van de normale weergave, wanneer [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored) wordt toegepast voor [getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) overeenkomstig.

## **Over het herstellen van INormalViewProperties**

Specificeert de afmetingen van de diaregio (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer de regio een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).  

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificeert de grootte van de diaregio (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).  

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van de zij‑contentregio moet compenseren voor de nieuwe grootte bij het aanpassen van het venster dat de weergave bevat binnen de applicatie.  

Een voorbeeld hieronder laat zien hoe u toegang krijgt tot de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) voor een presentatie.

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

## **Stel de standaard zoomwaarde in**

{{% alert color="info" %}} 

Aspose.Slides voor Android via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van een presentatie in te stellen. Zowel [getSlideViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) als [getNotesViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) aan.  
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) in.  
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand. In het onderstaande voorbeeld hebben we de zoomwaarde voor zowel de diaweergave als de notitie‑weergave ingesteld.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in procenten voor de diaweergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in procenten voor de notitieweergave 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Instellen van rasterafstand**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--) om de weergave‑instellingen voor de gehele presentatie op te vragen. De methoden [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) en [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een enkele dia. De rasterafstand wordt gespecificeerd in punten, waarbij 72 punten één inch gelijk zijn. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch interval in en slaat het resultaat op.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het raster verschilt van [tekenrichtlijnen](/slides/nl/androidjava/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekenrichtlijnen individueel gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of verwijderen van tekenrichtlijnen verandert de rasterafstand niet.

Zowel het raster als tekenrichtlijnen zijn hulpmiddelen bij het bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Veelgestelde vragen**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het verwijderen van tekenrichtlijnen de rasterafstand?**

Nee. Tekenrichtlijnen en rasterafstand zijn onafhankelijke instellingen. Het verwijderen van richtlijnen laat het opgeslagen rasterinterval onaangetast.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--) worden op presentatieniveau gedefinieerd ([Normale weergave](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Dia‑weergave](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), niet per sectie, dus één set parameters geldt voor het gehele document bij het openen.

**Kan ik verschillende weergave‑staten vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen de voorkeuren van de gebruiker respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [weergave‑eigenschappen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--) op presentatieniveau worden opgeslagen, kunt u ze in een sjabloon opnemen en nieuwe documenten daarvan maken met dezelfde initiële weergave‑configuratie.