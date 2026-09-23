---
title: Ophalen en bijwerken van presentatie‑weergave‑eigenschappen in Java
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
- dimensiegrootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Java om PPT-, PPTX- en ODP‑dia's aan te passen—lay‑outs, zoomniveaus en weergave‑instellingen bij te stellen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onder‑inhoudsgebied. Eigenschappen die betrekking hebben op de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst was opgeslagen.

De methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

De interfaces [INormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties) en hun afstammelingen, en de enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType) zijn toegevoegd.

## **Over INormalViewProperties**

Vertegenwoordigt de normale weergave‑eigenschappen.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van de schetsinhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter moet vastklikken in een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur heeft voor een enkel‑inhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden over het gehele venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geven de toestand aan waarin de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) bepalen de afmetingen van respectievelijk het linker‑ of bovenste dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SplitterBarStateType#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) dienovereenkomstig.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmetingen van het dia‑gebied (breedte wanneer het een kind is van [getRestoredTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer het een kind is van [getRestoredLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd noch gemaximaliseerd). 

De methode [getDimensionSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) geeft de grootte van het dia‑gebied aan (breedte wanneer het een kind is van restoredTop, hoogte wanneer het een kind is van restoredLeft).

De methode [getAutoAdjust](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Hieronder wordt een voorbeeld gegeven dat laat zien hoe u de eigenschappen [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) van een presentatie kunt benaderen.

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

## **Standaardzoomwaarde instellen**

{{% alert color="info" %}} 

Aspose.Slides for Java ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) evenals [getNotesViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmeermatig worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
2. Stel de [View Properties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) in.
3. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in procenten voor diaview
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in procenten voor notitie‑view

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterafstand instellen**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) om toegang te krijgen tot de weergave‑instellingen voor de gehele presentatie. De methoden [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#getGridSpacing--) en [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een enkele dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten één inch gelijk zijn. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch interval in, en slaat het resultaat op.

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

Het raster verschilt van [drawing guides](/slides/nl/java/drawing-guides/). Rasterafstand regelt een regulier interval, terwijl tekengidsen individuele horizontale of verticale uitlijninglijnen zijn. Het toevoegen, verplaatsen of verwijderen van tekengidsen verandert de rasterafstand niet.

Zowel het raster als de tekengidsen zijn hulpmiddelen bij het bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Reacties weergeven of verbergen bij het openen van een presentatie**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) om toegang te krijgen tot de weergave‑instellingen voor de gehele presentatie. Gebruik [IViewProperties.getShowComments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#getShowComments--) en [IViewProperties.setShowComments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) om de opgeslagen voorkeur te lezen of te wijzigen of opmerkingen moeten worden weergegeven wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt alleen de opgeslagen weergave‑voorkeur. Het voegt geen opmerkingen toe, verwijdert ze, bewerkt ze of lost ze op. Het verbergen van opmerkingen behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie [Presentation Comments](/slides/nl/java/presentation-comments/) voor handelingen die de opmerkingen zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met opmerkingen. Het geeft de huidige zichtbaarheid weer, vraagt om de opmerkingen te verbergen en slaat een nieuwe PPTX op zonder opmerkingen te verwijderen. Het gebruikt ook [IViewProperties.setLastView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iviewproperties/#setLastView-int-) met [ViewType.SlideView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewtype/#SlideView) om de initiële bewerkingsweergave te configureren naast de zichtbaarheid van opmerkingen.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze instelling bepaalt niet of opmerkingen worden opgenomen in PDF-, HTML-, afbeelding-, notitie‑ of hand‑out‑exporten. Configureer de relevante export‑specifieke opties afzonderlijk.

## **Veelgestelde vragen**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het verwijderen van tekengidsen de rasterafstand?**

Nee. Tekengidsen en rasterafstand zijn onafhankelijke instellingen. Het verwijderen van gidsen laat het opgeslagen rasterinterval onveranderd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), niet per sectie, zodat één set parameters van toepassing is op het volledige document bij het openen.

**Kan ik vooraf verschillende weergave‑staten definiëren voor verschillende gebruikers?**

Nee. De instellingen worden opgeslagen in het bestand en worden gedeeld. Viewer‑applicaties kunnen de gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [weergave‑eigenschappen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getViewProperties--) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.