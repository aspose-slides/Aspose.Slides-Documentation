---
title: Ophalen en bijwerken van presentatieweergave-eigenschappen in Java
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- verticale-splitter-vastklikken
- enkele weergave
- balkstatus
- dimensie-grootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Java om de lay-out van de normale weergave, de zoom van dia's en notities, de rasterafstand en de zichtbaarheid van opmerkingen in PowerPoint-presentaties te configureren."
---
## **Introductie**

In de normale weergave van PowerPoint verschijnt de dia tussen een zijpaneel voor miniaturen of een outline en een notitiepaneel eronder. Aspose.Slides for Java maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Deze omvatten de paneelindeling, zoomniveaus, rasterafstand en zichtbaarheid van commentaren.

## **Over INormalViewProperties**

Gebruik [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) om de [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) interface te benaderen. [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) bepaalt of er pictogrammen naast de titels van dia's verschijnen in de outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) zorgt ervoor dat het zijpaneel klikt naar zijn geminimaliseerde toestand wanneer de gebruiker het smaller maakt. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) geeft de voorkeur aan het weergeven van één paneel in het volledige venster.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) regelt de scheidingslijn tussen het zijpaneel en de dia. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) regelt de scheidingslijn boven het notitiepaneel. Beide accepteren een [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) waarde van `Minimized`, `Maximized` of `Restored`.

## **Over het herstellen van INormalViewProperties**

Wanneer een scheidingslijn wordt hersteld, levert [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) de opgeslagen grootte van het zijpaneel en levert [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) de opgeslagen grootte van het bovenste dia‑gebied. Beide exposeren [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Hun [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) methode accepteert een percentage van 0 tot 100, en [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) bepaalt of de editor de grootte aanpast wanneer het venster van formaat verandert.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheidingslijn, stelt de grootte die door [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) wordt geretourneerd in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheidingslijn. Het roept ook [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) aan om pictogrammen weer te geven in de outline‑weergave.

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

## **Stel de standaardzoomwaarde in**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) slaan onafhankelijke zoominstellingen op voor de editor. Deze instellingen hebben geen invloed op de afmetingen van de dia, de weergave van de diavoorstelling, of de resolutie bij export naar afbeelding.

Dit voorbeeld opent een bestaande presentatie en roept [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) aan om de dia aan te passen aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schaal uit en roept het [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) aan om een vaste zoom van 80% in te stellen.

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

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) stelt de afstand tussen bewerkingsrasterlijnen in de hele presentatie in. Het neemt een positieve waarde in points, met 72 points per inch. Dit voorbeeld toont de huidige afstand in een bestaande presentatie en slaat een kwart‑inch raster op door het interval in te stellen op 18 points.

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

Het raster herhaalt zich met een vast interval. [Drawing guides](/slides/nl/java/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze weergeven. Diavoorstellingen en export naar PDF, afbeeldingen of SVG laten ze weg.

## **Toon of verberg commentaren bij het openen van een presentatie**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met commentaren toont dit voorbeeld de huidige instelling en slaat een kopie op waarin de commentaren verborgen zijn. Het roept ook [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) aan met [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) zodat de kopie opent in de diaweergave.

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

Het verbergen van commentaren behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de commentaren zelf te wijzigen, zie [Presentation Comments](/slides/nl/java/presentation-comments/). Exportinstellingen bepalen of commentaren verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**

De presentatie slaat het rasterinterval op. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het wissen van tekenhulpmiddelen de rasterafstand?**

Nee. Het toevoegen, verplaatsen of verwijderen van een gids laat het rasterinterval ongewijzigd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**

Nee. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) is van toepassing op de gehele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**

Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan bovendien de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**

Ja. Presentaties die uit het sjabloon zijn gemaakt, erven de opgeslagen weergave‑instellingen.