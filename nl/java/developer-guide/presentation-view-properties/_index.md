---
title: Presentatie‑weergave‑eigenschappen ophalen en bijwerken in Java
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/java/presentation-view-properties/
keywords: 
- weergave‑eigenschappen
- normale weergave
- inhoudsstructuur
- structuur‑iconen
- snap verticale scheidingsbalk
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides for Java om PPT, PPTX en ODP‑dia’s aan te passen — lay‑outs, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderste inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de toepassing in staat om de weergavetoestand naar het bestand op te slaan, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst werd opgeslagen.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

[INormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de eigenschappen van de normale weergave voor.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificeren of de toepassing pictogrammen moet tonen wanneer de inhoudsopmaak in een van de inhoudsgebieden van de normale weergavemodus wordt weergegeven.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale scheidingsbalk moet omslaan naar een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

Eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) bepaalt of de gebruiker de voorkeur geeft aan één enkel inhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de toepassing kiezen om een van de inhoudsgebieden in het gehele venster te tonen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geven de toestand aan waarin de horizontale of verticale scheidingsbalk moet worden getoond. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificeren de grootte van respectievelijk het bovenste of zij‑dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored) is toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) dienovereenkomstig.

## **Over het herstellen van INormalViewProperties** 

Geeft de afmetingen op van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd noch gemaximaliseerd). 

Method [getDimensionSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificeert de grootte van het dia‑gebied (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) bepaalt of de grootte van het zij‑inhoudsgebied moet worden gecompenseerd voor de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave binnen de toepassing bevat.

Een voorbeeld hieronder laat zien hoe u de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) kunt benaderen voor een presentatie.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Aspose.Slides for Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatically worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/) bestand.  
   In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in procenten voor de diaweergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in procenten voor de notitie‑weergave 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de rasterafstand in**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) om de weergave‑instellingen voor de gehele presentatie te benaderen. De [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#getGridSpacing--) en [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) methoden lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een individuele dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, toont de huidige rasterafstand, stelt een kwart‑inch‑interval in en slaat het resultaat op.

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

Het raster verschilt van de [drawing guides](/slides/nl/java/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekengidsen individueel gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van tekengidsen verandert de rasterafstand niet.

Zowel het raster als tekengidsen zijn hulpmiddelen voor bewerking. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de kijker of editor.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van tekengidsen de rasterafstand?**

Nee. Tekengidsen en rasterafstand zijn onafhankelijke instellingen. Het wissen van gidsen laat het opgeslagen raster‑interval ongewijzigd.

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), niet per sectie, dus een enkele set parameters geldt voor het gehele document bij het openen.

**Kan ik verschillende weergave‑toestanden vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Toepassingen voor weergave kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon maken met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) op presentatieniveau worden opgeslagen, kunt u ze opnemen in een sjabloon en nieuwe documenten hiervan maken met dezelfde initiële weergaveconfiguratie.