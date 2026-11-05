---
title: PowerPoint-vormen opmaken in Python
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetslijn
- verbindingstype opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijstinten vormweergave
- vorm draaien
- 3D schuineffect
- 3D rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in Python met Aspose.Slides—stel vullings-, lijn‑ en effectstijlen in voor PPT‑, PPTX‑ en ODP‑bestanden met precisie en volledige controle."
---
## **Introductie**

Formatteer vormen in PowerPoint door hun contouren, opvullingen en effecte aan te passen. Aspose.Slides for Python via .NET stelt u in staat deze instellingen programmatisch te regelen, inclusief transparantie, rotatie en 3D‑opmaak.

![Opties voor vormopmaak in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET biedt klassen en eigenschappen waarmee u vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Gebruik [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) om de contour van een vorm te beheren. Dit voorbeeld maakt een niet‑gevulde rechthoek met een blauwe, gestippelde contour. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) selecteert een samengestelde dikke‑dunne lijn, terwijl [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) de breedte op 7 punten zet en [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) het stiptpatroon kiest.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Aangepaste lijnstreep Patronen instellen**

Gebruik [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste streep‑ en tussenruimte‑lengtes bieden, bijvoorbeeld voor merkimago‑contouren of technische diagrammen. Het toewijzen van een patroon zet automatisch [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) op [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Lijstitems wisselen af tussen streep‑ en tussenruimte‑lengtes, beginnend met een streep. Elke waarde is een veelvoud van de lijndikte: `[4, 2]` bij een breedte van 3 punten levert een 12‑punt streep gevolgd door een 6‑punt tussenruimte op. Gebruik paren van eindige, niet‑negatieve waarden om volledige streep‑en‑tussenruimte‑segmenten te definiëren. Het voorbeeld gebruikt positieve waarden zodat elke streep en tussenruimte zichtbaar blijft.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte eindpunten. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon met het dubbele van de breedte, waardoor zowel de streep‑ als de tussenruimte‑lengtes verdubbelen. De vijfde schakelt van een aangepast patroon naar een doorgetrokken lijn.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Zet de laatste lijn terug naar een solide stijl.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Om terug te keren naar een vooraf gedefinieerde gestippelde stijl, wijs [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) toe aan [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste stippatronen, een bredere lijn met het eerste patroon, en een doorgetrokken lijn in PowerPoint](custom-dash-patterns.png)

### **Lijn‑eindpunten instellen**

Gebruik [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) om de uiteinden van een open lijn te bepalen. De enumeratie [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) biedt drie expliciete eindstijlen:

- `FLAT`: De lijn eindigt precies bij het eindpunt.
- `ROUND`: Een halve cirkelvormige eindpunt strekt zich halverwege de lijndikte voorbij het eindpunt uit.
- `SQUARE`: Een vierkant eindpunt strekt zich halverwege de lijndikte voorbij het eindpunt uit.

De enumeratie bevat eveneens `NOT_DEFINED`, wat betekent dat er geen eindstijl expliciet is toegewezen.

Eindpunten verschillen van pijlpuntjes, die symbolen aan de lijnuiteinden toevoegen, en van hoeken, die de hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpuntjes uit via [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) en [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) zodat alleen de eindvormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen, 20 punten breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante eindpunten. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante eindpunten steken 10 punten verder uit dan elk eindpunt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round**, en **Square**.

![Platte, ronde en vierkante eindpunten op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) om de lijninstellingen te benaderen, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) om de schetsinstellingen te benaderen, en [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) te selecteren.

De volgende Python‑code toont hoe een [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) effect toe te passen, de expliciet toegewezen waarde uit te lezen, en het effect te verwijderen met [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

De waarde die door [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) wordt geretourneerd, vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden overgeërfd van een thema, master‑dia of lay‑dia, gebruik dan [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), krijg toegang tot [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), en lees [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat overerving is opgelost. Dit voorbeeld vereist een bestaande presentatie met minstens één vorm op de eerste dia en drukt beide waarden af:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Hoek‑stijlen opmaken**

Hier zijn de drie opties voor hoek‑stijlen:

* Rond
* Miter
* Afgeschuind

De hoek‑stijl bepaalt hoe twee contoursegmenten elkaar op een hoek ontmoeten. Gebruik **Rond** voor ronde hoeken, **Miter** voor scherpe hoeken, of **Afgeschuind** voor afgeplatte hoeken.

![De hoek‑stijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe contouren van 15 punten breed. Het stelt [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) in op respectievelijk de miter, afgeschuinde en ronde waarden van [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), om te vergelijken hoe de hoeken worden getekend.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Miter‑hoeken beperken bij scherpe hoeken**

Gebruik [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) in combinatie met [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) ingesteld op [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek mag uitsteken.

De limiet is een verhouding tussen de afstand van de binnen‑ en buitenhoek van de verbinding en de lijndikte. Een waarde van `8` staat een miter‑lengte toe tot acht keer de lijndikte; het is geen maat in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgeplatte verbinding op die hoek. Een grotere limiet maakt scherpere punten mogelijk. Deze instelling beïnvloedt alleen miter‑verbindingen; bij een hoek die binnen beide limieten blijft, is er geen zichtbaar effect.

Dit voorbeeld maakt twee identieke, niet‑gevulde driehoeken met contouren van 20 punten breed. De linkse driehoek gebruikt een limiet van `2`, de rechtse `8`. Elke driehoek is 80 punten breed en 160 punten hoog, waardoor de verhouding van miter‑lengte‑tot‑lijndikte van de bovenste hoek ongeveer `4,12` bedraagt. Hierdoor schuint PowerPoint de linkse punt af en behoudt het de rechtere punt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat in PowerPoint: **Miter‑limiet 2** links en **Miter‑limiet 8** rechts.

![Een afgeplatte top met miter‑limiet 2 en een puntige top met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Verloop‑opvulling**

Een verloop‑opvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars via [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). De methode [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) plaatst de kleurstops op 0 en 1, het begin en het einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De ellips met verloop‑opvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). U kunt een rendering‑stijl kiezen zonder de in de presentatie opgeslagen verloop‑opvulling te veranderen.

### **Hoek van lineair verloop instellen**

Gebruik [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) om de oriëntatie van een [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) opvulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar onder, `180` van rechts naar links, en `270` van onder naar boven. Gedeeltelijke hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd naar één volledige rotatie; bijvoorbeeld `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken kan worden vergeleken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat in PowerPoint:

![Lineaire verlopen op 0°, 45° en 90° in de bovenste rij, en 135°, 180° en 270° in de onderste rij](linear-gradient-angles.png)

### **Lineair verloop schalen met de vorm**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) accepteert een [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) waarde. Stel deze expliciet in op `FALSE` om de geometrische verloop‑hoek te behouden wanneer de proporties van de vorm veranderen, of op `TRUE` om het verloop te schalen met de breedte en hoogte van de vorm. Met inschakelde schaal kan de zichtbare hoek afwijken van de toegewezen hoek op een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurstops als bij de hoek‑vergelijking. De linker kolom gebruikt `FALSE`; de rechter kolom gebruikt `TRUE`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; de wijziging van breedte en hoogte van de tweede rechthoek toont hoe de opvulling reageert op grootte‑aanpassing zonder de verloopinstellingen te wijzigen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat in PowerPoint, met schaal uitgeschakeld links en ingeschakeld rechts:

![Brede en hoge rechthoeken met een 45‑graden verloop, waarbij linear_gradient_scaled FALSE links wordt vergeleken met TRUE rechts](linear-gradient-scaling.png)

Met uitgeschakelde schaal behouden de diagonale kleurbanden dezelfde oriëntatie in beide rechthoeken. Met ingeschakelde schaal strekken de banden zich uit volgens de verhoudingen van de vorm. Dit helpt om het verloop van een sjabloon te reproduceren bij het aanpassen van een vorm naar een andere grootte. Op een vierkant verandert het inschakelen van schalen de weergave van dit `45`‑graden verloop niet.

Zowel de hoek‑ als de schaalinstellingen gelden voor lineaire verlopen. Ze regelen geen [GradientShape.RADIAL of GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) opvullingen.

### **Hoek combineren met verloop‑richting**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) selecteert een verloop‑stijl uit de enumeratie [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoek‑stijlen het gebied waarin de kleuren worden verdeeld wijzigen zonder de [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) aan te passen. Houd de richting ongewijzigd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken hebben hetzelfde uiterlijk: eerst de richting instellen of daarna de hoek verandert het resultaat niet.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Patroon‑opvulling**

Een patroon‑opvulling brengt een tweekleurig ontwerp aan, zoals stippen, strepen of ruiten. Dit voorbeeld gebruikt [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) om een raster‑patroon te selecteren. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) levert de lichtgrijze achtergrond, en [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) levert de gele patroonkleur.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De rechthoek met patroon‑opvulling](pattern-fill.png)

## **Afbeeldings‑opvulling**

Een afbeelding‑opvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en laadt deze via [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) in de afbeeldingsverzameling van de presentatie. Het instellen van [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) op de tegel‑modus herhaalt de afbeelding binnen de rechthoek. De bronafbeelding die hier wordt gebruikt, staat hieronder:

![De lotus‑afbeelding](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met afbeelding‑opvulling](picture-fill.png)

### **Afbeelding als tegel‑textuur gebruiken**

Wilt u een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, gebruik dan de volgende eigenschappen van de klasse [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Stelt de afbeelding‑opvulmodus in — `TILE` of `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definieert de horizontale schaal van de tegel als een percentage.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definieert de verticale schaal van de tegel als een percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) om deze te herhalen op 50 % van de oorspronkelijke grootte. Offsets van −32 punten verschuiven de tegels horizontaal en verticaal; uitlijning rechtsonder en draaien in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tegel‑opties](tile-options.png)

## **Effenkleur‑opvulling**

Een effen opvulling geeft een vorm één enkele, uniforme kleur. Dit voorbeeld stelt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) in op de effen‑opvulmodus en kent geel toe via [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), waarna de rechthoek in een presentatie wordt opgeslagen.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met effen kleur‑opvulling](solid-color-fill.png)

### **Kleuren kopiëren behoudend themareferenties**

Gebruik [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) om een kleuromschrijving te kopiëren, inclusief het kleurtype, de themareferentie en eventuele transformaties. Dit is handig bij het overzetten van een opvulkleur tussen vormen die de presentatiethema‑kleuren moeten blijven volgen. De methode kopieert alleen de kleur: hij kopieert niet het opvultype, de contour of andere vorm‑opmaak. Stel de bestemming’s [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) expliciet in.

Dit voorbeeld maakt drie rechthoeken, van links naar rechts: de bron, een themabewuste kopie, en een vaste RGB‑kopie. De bron gebruikt [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) om te verwijzen naar de eerste accentkleur en voegt een tint toe via [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). De RGB‑kopie gebruikt de effectieve opvulkleur van de bron zodat alle drie aanvankelijk identiek lijken. Het toewijzen van [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) stelt een vaste RGB‑waarde in en wist alle bestaande kleurtransformaties.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Thema-referenties volgen de nieuwe accentkleur; de vaste RGB-waarde niet.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Voor de themawijziging komen alle drie de opvullingen overeen:

![Bron, copy_from‑bestemming en vaste RGB‑bestemming met identieke blauwe opvullingen](color-copy-before.png)

Na de themawijziging volgen de bron en de themabewuste kopie de nieuwe accentkleur en behouden hun tint. De vaste RGB‑kopie blijft blauw:

![Bron en copy_from‑bestemming met oranje opvullingen, terwijl de vaste RGB‑bestemming blauw blijft](color-copy-after.png)

De gekopieerde definitie is onafhankelijk van de bron. Een latere wijziging van de themareferentie van de bron, het toewijzen van een andere kleur, of het toevoegen of verwijderen van transformaties verandert de bestemming niet. Een themawijziging beïnvloedt beide vormen nog steeds, omdat elke vorm afzonderlijk naar dezelfde themakleur verwijst.

Het opslaan en opnieuw openen van de PPTX behoudt het gekopieerde [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), de themareferentie en de [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) collectie; het wordt niet omgezet naar RGB.

Bij het kopiëren tussen verschillende themacontexten, zoals presentaties met verschillende accentpaletten, wordt de gekopieerde referentie geïnterpreteerd ten opzichte van het thema van de bestemming. Dezelfde referentie en transformaties kunnen daardoor een andere zichtbare kleur opleveren. Zie [Presentation Theme](/slides/nl/python-net/presentation-theme/) voor meer informatie over het configureren van themakleuren.

## **Achtergrond van de dia als vorm‑opvulling gebruiken**

Gebruik [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Stel eerst [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) in op [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) om een expliciete opvulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van zijn eigen stijl‑opvulling. Alleen het inschakelen van deze vlag verwijdert geen bestaande expliciete opvulling.

Dit verschilt van [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): een achtergrond‑opvulling bedekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen opvulling die objecten zichtbaar laat. Een verloop blijft dan uitgelijnd met de dia in plaats van opnieuw te beginnen binnen elke vorm.

Het volgende voorbeeld maakt een master‑achtergrond die wordt geërfd door de dia en plaatst een magenta‑band achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste heeft geen opvulling, en de rechtse schakelt van achtergrond‑opvulling naar een expliciete oranje‑opvulling.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Erf het verloop van de master.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Schakel de achtergrondvulling uit voordat een expliciete vulling wordt toegepast.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat, van links naar rechts: **achtergrond‑opvulling**, **geen opvulling**, en **expliciete opvulling**. De magenta‑band wordt verborgen door de linker‑ en rechter‑rechthoeken maar blijft zichtbaar door de middelste rechthoek.

![Achtergrond‑opvulling, geen opvulling en expliciete oranje‑opvulling over een magenta‑band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die direct op de dia is gedefinieerd of wordt geërfd van een lay‑dia. De vorm gebruikt de geëvalueerde achtergrond van de dia; het voorbeeld laat zowel de dia‑ als de lay‑achtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een effen opvulling bepaalt de alfa‑component van de kleur de ondoorzichtigheid: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant wordt zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De rotatie van de vorm](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Gebruik [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) om een vorm diepte en afgeschaalde randen te geven. Dit voorbeeld maakt een groene ellips met een oranje contour, stelt [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) in op 4 punten, en past een circulaire bovenste schuine rand toe met een breedte en hoogte van 6 punten via [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Een front‑gerichte orthografische camera en drie‑punt verlichting maken de schuine rand zichtbaar.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Het 3D‑beeld van een vorm wordt bestuurd door de camera‑instellingen. Dit voorbeeld gebruikt [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) met breedte‑ (latitude), lengte‑ (longitude) en revolutie‑ (revolution) hoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) en evenwichtige verlichting via [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), waarna de opgemaakte rechthoek wordt opgeslagen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen regelen**

De eigenschap [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) geeft aan hoe een individuele vorm wordt weergegeven wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. Het activeert de zwart‑wit‑weergave niet op zichzelf, en het wijzigt de opvulling, lijn of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `AUTOMATIC` laat de render‑applicatie de conversie kiezen, `GRAY` en `LIGHT_GRAY` gebruiken grijstinten, `BLACK_WHITE` gebruikt uitsluitend zwart en wit, `BLACK` en `WHITE` dwingen één kleur, `COLOR` behoudt de normale kleurweergave, en `HIDDEN` laat de vorm weg in zwart‑wit‑modus. `NOT_DEFINED` betekent dat er geen vorm‑specifieke modus is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en stelt [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) in op grijs. De opgeslagen vorm behoudt zijn oranje opvulling voor normale kleermodus en vraagt grijze weergave aan applicaties die zwart‑wit‑instellingen respecteren:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

In normale kleurmodus behoudt de rechthoek zijn oranje opvulling. In een zwart‑wit‑workflow wordt grijze weergave gebruikt omdat de modus is ingesteld op `GRAY`. Hiermee kunt u een volledig‑kleurige dia behouden terwijl u een aparte weergave definieert voor afdrukken, voorbeeldweergave of andere workflows die de zwart‑wit‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) om de positie, grootte en opmaak van diaplaatshouders te herstellen vanuit de overeenkomstige lay‑plaatshouders. Dit voorbeeld vereist een bestaande presentatie met lay‑gebaseerde plaatshouders en reset elke dia vóór het opslaan. Vormen zonder overeenkomstige lay‑plaatshouder worden niet gereset.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Beïnvloedt vorm‑opmaak de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effectinstellingen voegen over het algemeen weinig data toe in vergelijking met ingebedde afbeeldingen en media. Afbeeldings‑opvullingen kunnen de bestandsgrootte verhogen omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — opvulling, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, behandel hun stijlen dan als identiek en groepeer die vormen logisch; dit vereenvoudigt later stijlbeheer.

**Kan ik een set aangepaste vorm‑stijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeld‑vormen met de gewenste stijlen in een sjabloon‑presentatie of een .POTX‑sjabloonbestand. Wanneer u een nieuwe presentatie maakt, open dan het sjabloon, kloon de gestileerde vormen die u nodig heeft, en pas hun opmaak toe waar nodig.