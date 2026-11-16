---
title: Hämta och uppdatera presentationsvyegenskaper i Python
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/python-net/presentation-view-properties/
keywords:
- vyegenskaper
- normalläge
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal splittrare
- enkel vy
- stapelläge
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Använd Aspose.Slides för Python via .NET för att konfigurera normallägets layout, bild- och anteckningszoom, rutnätsavstånd samt kommentarsynlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normalläge visas bilden mellan en sidopanel för miniatyrbilder eller en disposition och en anteckningspanel nedanför. Aspose.Slides för Python via .NET visar presentationens sparade redigeringsinställningar via [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Dessa inkluderar panelens layout, zoomnivåer, rutnätsavstånd och kommentarsynlighet.

## **Om NormalViewProperties**

Använd [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) för att komma åt objektet [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) styr huruvida ikoner visas bredvid bildrubriker i dispositionen. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) låter sidopanelen fästa i sitt minimerade tillstånd när användaren gör den smalare. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) anger en preferens för att visa en panel i hela fönstret.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) styr avdelaren mellan sidopanelen och bilden. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) styr avdelaren ovanför anteckningspanelen. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/)‑värde av `MINIMIZED`, `MAXIMIZED` eller `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![A conceptual editor separates a side panel, slide region and bottom region with labelled vertical and horizontal splitters.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*I normalläge styr den vertikala avdelaren bredden på sidopanelen. Den horisontella avdelaren styr utrymmet ovanför anteckningspanelen.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Om återställning av NormalViewProperties**

När en avdelare återställs, tillhandahåller [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) den sparade storleken på sidopanelen och [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) den sparade storleken på det övre bildområdet. Båda exponerar [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Dess [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/)‑egenskap accepterar en procentsats från 0 till 100, och [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) styr om redigeraren justerar storleken när fönstret ändras storlek.

Detta exempel uppdaterar en befintlig presentation. Det återställer den horisontella avdelaren, sätter [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) till 80 % med automatisk justering aktiverad, och maximerar den vertikala avdelaren. Det aktiverar också [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) för dispositionsvyn.

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

## **Ställ in standardzoomvärdet**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) och [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) lagrar oberoende zoominställningar för redigeraren. Dessa inställningar påverkar inte bilddimensioner, bildspelsuppspelning eller bildexportens upplösning.

Detta exempel öppnar en befintlig presentation och aktiverar [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) för att anpassa bilden till redigeringsfönstret. För anteckningssidan inaktiveras automatisk skalning och [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) sätts till en fast 80 % zoom.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in rutnätsavståndet**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett rutnät på en fjärdedel tum genom att sätta intervallet till 18 punkter.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Rutnätet upprepas med ett fast intervall. [Ritningsguider](/slides/sv/python-net/drawing-guides/) markerar enskilda horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas endast i redigerare som visar dem. Bildspel och export till PDF, bilder eller SVG utesluter dem.

## **Visa eller dölja kommentarer när presentationen öppnas**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) lagrar en preferens som kompatibla redigerare använder när presentationen öppnas. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det sätter också [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) till [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) så att kopian öppnas i bildvyn.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Att dölja kommentarer bevarar deras text, författare, positioner, svar och status. För att ändra kommentarerna själva, se [Presentationskommentarer](/slides/sv/python-net/presentation-comments/). Exportinställningar styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller handouts.

## **Vanliga frågor**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**

Presentationen sparar rutnätsintervallet. För att se rutnätet, aktivera rutnätsvisning i redigeraren.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Att lägga till, flytta eller rensa en guide lämnar rutnätsintervallet oförändrat.

**Kan olika avsnitt i en presentation ha olika visningsinställningar?**

Nej. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) gäller för hela presentationen.

**Kan jag spara olika visningsinställningar för olika användare?**

Filen sparar en uppsättning visningsegenskaper för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara visningsinställningar i en mall?**

Ja. Presentationer som skapas från mallen ärver dess sparade visningsinställningar.