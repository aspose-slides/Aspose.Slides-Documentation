---
title: Ophalen en bijwerken van presentatieweergave-eigenschappen op Android
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/androidjava/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- verticale-splitter-vastklikken
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaard zoom
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Android via Java om de lay-out van de normale weergave, de zoom van dia's en notities, de rasterafstand en de zichtbaarheid van opmerkingen in PowerPoint-presentaties te configureren."
---
## **Inleiding**

In de normale weergave van PowerPoint verschijnt de dia tussen een zijpaneel voor miniaturen of een outline en een notitiepaneel eronder. Aspose.Slides voor Android via Java maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Deze omvatten de lay-out van de panelen, zoomniveaus, rasterafstand en zichtbaarheid van opmerkingen.

## **Over INormalViewProperties**

Gebruik [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) om toegang te krijgen tot de interface [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) bepaalt of pictogrammen naast diatitel in de outline verschijnen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) laat het zijpaneel vastklikken op zijn geminimaliseerde toestand wanneer de gebruiker het verkleint. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) geeft de voorkeur aan het weergeven van één paneel in het volledige venster.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) regelt de scheidingsbalk tussen het zijpaneel en de dia. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) regelt de scheidingsbalk boven het notitiepaneel. Beide accepteren een waarde van het type [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) van `Minimized`, `Maximized` of `Restored`.

## **Over het herstellen van INormalViewProperties**

Wanneer een scheidingsbalk wordt hersteld, levert [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) de opgeslagen grootte van het zijpaneel en levert [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) de opgeslagen grootte van het bovenste dia‑gebied. Beide geven toegang tot [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). De methode [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) accepteert een percentage van 0 tot 100, en [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) bepaalt of de editor de grootte aanpast wanneer het venster wordt gewijzigd.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheidingsbalk, stelt de grootte die door [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) wordt geretourneerd in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheidingsbalk. Het roept ook [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) aan om pictogrammen weer te geven in de outline‑weergave.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de standaard zoomwaarde in**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) slaan onafhankelijke zoominstellingen op voor de editor. Deze instellingen hebben geen invloed op de afmetingen van de dia, de weergave van de diavoorstelling of de resolutie bij het exporteren van afbeeldingen.

Dit voorbeeld opent een bestaande presentatie en roept [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) aan om de dia passend te maken in het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schaal uit en roept [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) aan om een vaste zoom van 80% in te stellen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de rasterafstand in**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) stelt de afstand tussen bewerkingsrasterlijnen in de gehele presentatie in. Het neemt een positieve waarde in punten, met 72 punten per inch. Dit voorbeeld toont de huidige afstand in een bestaande presentatie en slaat een kwart‑inch raster op door het interval in te stellen op 18 punten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het raster herhaalt zich met een vaste interval. [Drawing guides](/slides/nl/androidjava/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze weergeven. Diavoorstellingen en exports naar PDF, afbeeldingen of SVG laten ze weg.

## **Toon of verberg opmerkingen bij het openen van een presentatie**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met opmerkingen toont dit voorbeeld de huidige instelling en slaat een kopie op met verborgen opmerkingen. Het roept ook [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) aan met [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) zodat de kopie opent in de dia‑weergave.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het verbergen van opmerkingen behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de opmerkingen zelf te wijzigen, zie [Presentation Comments](/slides/nl/androidjava/presentation-comments/). Exportinstellingen bepalen of opmerkingen verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**

De presentatie bewaart het rasterinterval. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het verwijderen van tekenhulplijnen de rasterafstand?**

Nee. Het toevoegen, verplaatsen of verwijderen van een hulplijn laat het rasterinterval onveranderd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**

Nee. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) is van toepassing op de gehele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**

Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan ook de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**

Ja. Presentaties die op basis van het sjabloon worden gemaakt, erven de opgeslagen weergave‑instellingen.