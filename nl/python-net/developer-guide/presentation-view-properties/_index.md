---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in Python
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/python-net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- inhoud van overzicht
- overzichtspictogrammen
- verticale splitter vastklampen
- enkele weergave
- balkstatus
- dimensiegrootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Python via .NET om de indeling van de normale weergave, zoom van dia en notities, rasterafstand en zichtbaarheid van opmerkingen in PowerPoint‑presentaties te configureren."
---
## **Inleiding**

In de normale weergave van PowerPoint wordt de dia weergegeven tussen een zijpaneel voor miniaturen of een overzicht en een notitiepaneel eronder. Aspose.Slides voor Python via .NET maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Deze omvatten de paneelindeling, zoomniveaus, rasterafstand en zichtbaarheid van opmerkingen.

## **Over NormalViewProperties**

Gebruik [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) om het object [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) te benaderen. [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) bepaalt of er pictogrammen naast diatitels in het overzicht verschijnen. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) laat het zijpaneel vastklampen aan de geminimaliseerde toestand wanneer de gebruiker het verkleint. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) geeft de voorkeur aan het weergeven van één paneel in het volledige venster.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) regelt de scheidingslijn tussen het zijpaneel en de dia. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) regelt de scheidingslijn boven het notitiepaneel. Beide accepteren een [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/)‑waarde van `MINIMIZED`, `MAXIMIZED` of `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![A conceptual editor separates a side panel, slide region and bottom region with labelled vertical and horizontal splitters.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*In de normale weergave regelt de verticale scheidingslijn de breedte van het zijpaneel. De horizontale scheidingslijn regelt de ruimte boven het notitiepaneel.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Over het herstellen van NormalViewProperties**

Wanneer een scheidingslijn wordt hersteld, levert [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) de opgeslagen grootte van het zijpaneel en levert [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) de opgeslagen grootte van het bovenste dia‑gebied. Beide exposing [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). De eigenschap [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) accepteert een percentage van 0 tot 100, en [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) bepaalt of de editor de grootte aanpast wanneer het venster wordt gewijzigd.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheidingslijn, stelt [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) in op 80 % met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheidingslijn. Het schakelt ook [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) in voor de overzichtsweergave.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaard zoomwaarde instellen**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) en [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) slaan onafhankelijke zoominstellingen op voor de editor. Deze instellingen beïnvloeden de afmetingen van de dia, de weergave van de diavoorstelling of de resolutie van afbeeldingsexport niet.

Dit voorbeeld opent een bestaande presentatie en schakelt [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) in om de dia aan te passen aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schaalvergroting uit en stelt [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) in op een vaste zoom van 80 %.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterafstand instellen**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) bepaalt de afstand tussen bewerkingsrasterlijnen in de hele presentatie. Het accepteert een positieve waarde in punten, met 72 punten per duim. Dit voorbeeld print de huidige afstand in een bestaande presentatie en slaat een raster van een kwart duim op door het interval op 18 punten in te stellen.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Het raster herhaalt zich met een vast interval. [Tekeningsgidsen](/slides/nl/python-net/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn bewerkingshulpmiddelen en verschijnen alleen in editors die ze weergeven. Diavoorstellingen en export naar PDF, afbeeldingen of SVG laten ze weg.

## **Opmerkingen weergeven of verbergen bij het openen van een presentatie**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met opmerkingen print dit voorbeeld de huidige instelling en slaat een kopie op met verborgen opmerkingen. Het stelt ook [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) in op [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) zodat de kopie opent in diavoorstellingweergave.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Het verbergen van opmerkingen behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de opmerkingen zelf te wijzigen, zie [Presentation Comments](/slides/nl/python-net/presentation-comments/). Exportinstellingen bepalen of opmerkingen verschijnen in PDF, HTML, afbeeldingen, notities of hand-outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**

De presentatie slaat het rasterinterval op. Om het raster te zien, schakel je de rasterzichtbaarheid in de editor in.

**Verandert het wissen van tekeningsgidsen de rasterafstand?**

Nee. Een gids toevoegen, verplaatsen of verwijderen laat het rasterinterval ongewijzigd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**

Nee. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) geldt voor de gehele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**

Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan bovendien de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**

Ja. Presentaties die uit het sjabloon worden gemaakt, erven de daarin opgeslagen weergave‑instellingen.