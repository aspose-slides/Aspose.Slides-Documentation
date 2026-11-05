---
title: PowerPoint-vormen formatteren in Python via Java
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetsvormlijn
- verbindingstijl opmaken
- verloop opvulling
- patroon opvulling
- afbeelding opvulling
- textuur opvulling
- effen kleur opvulling
- vorm transparantie
- zwart-wit vormweergave
- grijswaarden vormweergave
- vorm roteren
- 3D-bevel effect
- 3D-rotatie effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe je PowerPoint‑vormen kunt formatteren in Python via Java met Aspose.Slides—stel opvul‑, lijn‑ en effectstijlen in voor PPT‑ en PPTX‑bestanden met precisie en volledige controle."
---
## **Inleiding**

Formatteer vormen in PowerPoint door hun contouren, opvullingen en effecten aan te passen. Aspose.Slides for Python via Java stelt je in staat deze instellingen programmatisch te beheren, inclusief transparantie, rotatie en 3D‑opmaak.

![Opties voor vormopmaak in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java biedt klassen en methoden die je in staat stellen vormen te formatteren met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) om de omtrek van een vorm te regelen. Dit voorbeeld maakt een niet‑opgevulde rechthoek met een blauwe, gestippelde omtrek. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) selecteert een dikke‑dunne samengestelde lijn, terwijl [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) de breedte instelt op 7 punten en [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) het stippelpatroon selecteert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Aangepaste dash‑patronen voor lijnen instellen**

Gebruik [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste dash‑lengtes en -gaten bieden, bijvoorbeeld voor merkspecifieke omtrekken of technische diagrammen. Het toewijzen van een patroon wijzigt automatisch de line dash stijl naar [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Array‑items wisselen af tussen dash‑ en gatlengtes, beginnend met een dash. Elke waarde is een veelvoud van de lijnbreedte: `[4, 2]` bij een breedte van 3 punten produceert een dash van 12 punten gevolgd door een gat van 6 punten. Gebruik paren van eindige, niet‑negatieve waarden om volledige dash‑en‑gap‑segmenten te definiëren. Het voorbeeld gebruikt positieve waarden om elke dash en elk gat zichtbaar te houden.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte caps. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon bij dubbel de breedte, waardoor zowel de dash‑ als de gatlengtes worden verdubbeld. De vijfde schakelt over van een aangepast patroon naar een doorlopende lijn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpiy.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Zet de laatste lijn terug naar een doorlopende stijl.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om in plaats daarvan terug te keren naar een vooraf gedefinieerde gestippelde stijl, geef je [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) door aan [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste dash‑patronen, een bredere lijn die het eerste patroon gebruikt, en een doorlopende lijn in PowerPoint](custom-dash-patterns.png)

### **Lijncaps instellen**

Gebruik [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) om de uiteinden van een open lijn in te stellen. De klasse [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) biedt drie expliciete cap‑stijlen:

- `Flat`: De lijn stopt bij het eindpunt.
- `Round`: Een halve cirkelvormige cap strekt zich uit voorbij het eindpunt met de helft van de lijndikte.
- `Square`: Een vierkante cap strekt zich uit voorbij het eindpunt met de helft van de lijndikte.

De klasse bevat ook `NotDefined`, wat betekent dat er geen cap‑stijl expliciet is toegewezen.

Caps verschillen van pijlpuntjes, die symbolen aan het einde van een lijn toevoegen, en van joins, die de hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpuntjes uit via [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) en [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) zodat alleen de cap‑vormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen, 20 punten breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante caps. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante caps steken 10 punten uit voorbij elk eindpunt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round**, en **Square**.

![Platte, ronde en vierkante caps op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten op vormlijnen toepassen**

Een schetseffect laat een vormlijn handgetekend lijken. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) om de lijninstellingen op te vragen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) om de schetseigenschappen op te vragen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) om een waarde uit de klasse [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) te selecteren.

De volgende Python‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑slide of lay‑slide, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) en lees het schetstype uit de geretourneerde effectieve lijnopmaak, zoals hieronder wordt getoond. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat erfelijkheid is opgelost. Dit voorbeeld vereist een bestaande presentatie met ten minste één vorm op de eerste dia en geeft beide waarden weer:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Aansluitingstijlen formatteren**

Hier zijn de drie opties voor het type verbinding:

* Rond
* Miter
* Afgeschuind

De aansluitstijl bepaalt hoe twee omtrekkende segmenten bij een hoek elkaar ontmoeten. Gebruik **Rond** voor afgeronde hoeken, **Miter** voor scherpe hoeken, of **Afgeschuind** voor afgeplatte hoeken.

![De aansluitstijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe omtrekken van 15 punten breed. Het gebruikt [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) om respectievelijk de miter‑, bevel‑ en round‑waarden van [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) in te stellen, om te vergelijken hoe de hoeken worden getekend.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Miter‑verbindingen beperken bij scherpe hoeken**

Gebruik [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) samen met [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) ingesteld op [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek mag uitsteken.

De limiet is een verhouding van de afstand tussen de binnen‑ en buitenhoek van de join tot de lijndikte. Bijvoorbeeld, een waarde van `8` staat een miter‑lengte toe tot acht keer de lijndikte; het is geen meting in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgeschuurde join op die hoek. Een grotere limiet maakt scherpere punten mogelijk. De instelling beïnvloedt alleen miter‑joins, en wijzigen heeft geen zichtbaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, niet‑opgevulde driehoeken met omtrekken van 20 punten breed. De linker‑driehoek gebruikt een limiet van `2`, de rechter een limiet van `8`. Elke driehoek is 80 punten breed en 160 punten hoog, waardoor de verhouding van miter‑lengte tot lijndikte van de bovenste hoek ongeveer `4.12` is. Daardoor schuint PowerPoint de linker‑apex af en behoudt de rechter‑apex.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat in PowerPoint: **Miter‑limiet 2** links en **miter‑limiet 8** rechts.

![Een afgeschuurde apex met miter‑limiet 2 en een puntige apex met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Verloop‑opvulling**

Een verloop‑opvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars via [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). De methode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) plaatst de kleurstops op 0 en 1, het begin en het einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De ellips met verloop‑opvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een render­stijl selecteren zonder de verloop‑opvulling die in de presentatie is opgeslagen te wijzigen.

### **Hoek van lineair verloop instellen**

Gebruik [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) om de oriëntatie van een [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) opvulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Gedeeltelijke hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd tot één omwenteling; bijvoorbeeld, `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek kan worden vergeleken onafhankelijk van de verhoudingen van de rechthoeken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat in PowerPoint:

![Lineaire verlopen van 0, 45 en 90 graden in de bovenste rij, en 135, 180 en 270 graden in de onderste rij](linear-gradient-angles.png)

### **Lineair verloop schalen met de vorm**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepteert een [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) waarde. Stel het expliciet in op `False_` om de geometrische verloop‑hoek te behouden wanneer de vormafmetingen veranderen, of op `True_` om het verloop te schalen met de breedte en hoogte van de vorm. Met inschakelen van schalen kan de zichtbare hoek afwijken van de toegewezen hoek bij een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurstops als de hoekvergelijking. De linkerkolom gebruikt `False_`; de rechterkolom gebruikt `True_`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; het wijzigen van de breedte en hoogte van de tweede rechthoek laat zien hoe de opvulling reageert op herschalen zonder de verloop‑instellingen te veranderen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat in PowerPoint, met schalen uitgeschakeld links en ingeschakeld rechts:

![Brede en hoge rechthoeken met een 45‑graden verloop, vergelijking LinearGradientScaled False links met True rechts](linear-gradient-scaling.png)

Met uitgeschakelde schaal blijven de diagonale kleurenbanden in beide rechthoeken dezelfde oriëntatie behouden. Met ingeschakelde schaal worden de banden uitgerekt met de verhoudingen van de vorm. Dit helpt een sjabloon‑verloop te reproduceren wanneer een vorm wordt aangepast naar een andere grootte. Op een vierkante vorm verandert inschakelen van schalen het uiterlijk van dit `45`‑graden verloop niet.

Zowel de hoek‑ als de schaalinstellingen gelden voor lineaire verlopen. Ze bepalen geen [GradientShape.Radial of GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) opvullingen.

### **Hoek combineren met verloop­richting**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) selecteert een verloopstijl uit de klasse [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoekstijlen het gebied waarin de kleuren worden verdeeld wijzigen zonder de hoek die via [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) is toegewezen te veranderen. Houd de richting ongewijzigd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken zien er identiek uit: de richting voor of na de hoek instellen verandert het resultaat niet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Patroon‑opvulling**

Een patroon‑opvulling brengt een tweekleurig ontwerp aan, zoals stippen, strepen of raster. Dit voorbeeld gebruikt [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) om een raster‑patroon te selecteren. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) levert de lichtgrijze achtergrond, en [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) levert de gele patroonkleur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De rechthoek met patroon‑opvulling](pattern-fill.png)

## **Afbeeldings‑opvulling**

Een afbeelding‑opvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en gebruikt [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) om deze in de afbeeldingsverzameling van de presentatie te laden. Het instellen van [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) op de getegelde modus herhaalt de afbeelding binnen de rechthoek. De gebruikte bronafbeelding staat hieronder:

![De lotusafbeelding](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De vorm met afbeelding‑opvulling](picture-fill.png)

### **Afbeelding als tegeltextuur gebruiken**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, dan kun je de volgende methoden van de klasse [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeelding‑opvulmodus in — `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Regelt of de tegel horizontaal, verticaal of in beide richtingen wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) om deze te herhalen op 50 % van de oorspronkelijke grootte. Offsets van −32 punten verschuiven de tegels horizontaal en verticaal; uitlijning rechtsonder en spiegelen in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleur‑opvulling**

Een effen opvulling geeft een vorm één enkele, uniforme kleur. Dit voorbeeld gebruikt [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) om de effen‑opvulmodus in te stellen en wijst geel toe via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), waarna de rechthoek in een presentatie wordt opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De vorm met effen kleur‑opvulling](solid-color-fill.png)

### **Kleuren kopiëren terwijl thema‑referenties behouden blijven**

Gebruik [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) om een kleurdefinitie te kopiëren, inclusief het kleurtype, de thema‑referentie en transformaties. Dit is handig bij het overzetten van een opvulkleur tussen vormen die de presentatie‑thema moeten blijven volgen. De methode kopieert alleen de kleur: hij kopieert niet het opvultype, de omtrek of andere vormopmaak. Stel het opvultype van de bestemming expliciet in met [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType).

Dit voorbeeld maakt drie rechthoeken, van links naar rechts: de bron, een thema‑bewuste kopie, en een vaste RGB‑kopie. De bron gebruikt [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) om te verwijzen naar de eerste accentkleur en voegt een tint toe via [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add). De RGB‑kopie gebruikt de effectieve opvulkleur van de bron zodat alle drie aanvankelijk identiek lijken. Het aanroepen van [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) stelt een vaste RGB‑waarde in en wist eventuele bestaande kleurtansformaties.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # Thema-referenties volgen de nieuwe accentkleur; de vaste RGB-waarde doet dat niet.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor de themawijziging komen alle drie de opvullingen overeen:

![Bron, copyFrom‑bestemming en vaste RGB‑bestemming met identieke blauwe opvullingen](color-copy-before.png)

Na de themawijziging volgen de bron en de thema‑bewuste kopie de nieuwe accentkleur en behouden hun tint. De vaste RGB‑kopie blijft blauw:

![Bron en copyFrom‑bestemming met oranje opvullingen, terwijl de vaste RGB‑bestemming blauw blijft](color-copy-after.png)

De gekopieerde definitie staat onafhankelijk van de bron. Een latere wijziging van de thema‑referentie van de bron, het toewijzen van een andere kleur, of het toevoegen/verwijderen van transformaties verandert de bestemming niet. Een themawijziging heeft nog steeds invloed op beide vormen omdat elke vorm onafhankelijk naar dezelfde themakleur verwijst.

Opslaan en heropenen van de PPTX behoudt het type van de gekopieerde kleur dat wordt geretourneerd door [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType), de themareferentie en de transformatieset die wordt geretourneerd door [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform); het wordt niet naar RGB geflatteerd.

Bij het kopiëren tussen verschillende themacontexten, zoals presentaties met verschillende accentpaletten, wordt de gekopieerde referentie opgezocht tegen het thema van de bestemming. Dezelfde referentie en transformaties kunnen daardoor een andere zichtbare kleur produceren. Zie [Presentation Theme](/slides/nl/python-java/presentation-theme/) voor meer informatie over het configureren van themakleuren.

## **Achtergrond van de dia gebruiken als vorm‑opvulling**

Gebruik [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Stel het opvultype in met [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) op [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) om eventuele expliciete opvulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van zijn eigen stijl‑opvulling. Alleen het inschakelen van de vlag verwijdert geen bestaande expliciete opvulling.

Dit verschilt van [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): een achtergrond‑opvulling dekt objecten achter de vorm af met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen opvulling die objecten zichtbaar laat. Een verloop blijft uitgelijnd met de dia in plaats van opnieuw te beginnen binnen elke vorm.

Het volgende voorbeeld maakt een master‑achtergrond die wordt geërfd door de dia en plaatst een magenta‑band achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste heeft geen opvulling, en de rechtse schakelt van achtergrond‑opvulling naar een expliciete oranje‑opvulling.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Erf het verloop van de master.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Schakel achtergrondvulling uit voordat je een expliciete vulling toepast.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat, van links naar rechts: **achtergrond‑opvulling**, **geen opvulling**, en **expliciete opvulling**. De magenta‑band wordt verborgen door de linker‑ en rechterrechthoeken maar blijft zichtbaar via de middelste rechthoek.

![Achtergrond‑opvulling, geen opvulling en expliciete oranje‑opvulling over een magenta‑band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die rechtstreeks op de dia is gedefinieerd of van een lay‑out wordt geërfd. De vorm gebruikt de opgeloste achtergrond van de dia; het voorbeeld laat zowel de dia‑ als de lay‑out‑achtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een effen opvulling bepaalt het alfa‑component van de kleur de doorzichtigheid: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant wordt zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑bevel‑effecten toevoegen**

Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) om een vorm diepte en afgeplatte randen te geven. Dit voorbeeld maakt een groene ellips met een oranje omtrek, gebruikt [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) om de diepte op 4 punten in te stellen, en past een cirkelvormige bovenste bevel toe met een breedte en hoogte van 6 punten via [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Een front‑gerichte orthografische camera en drie‑punt verlichting maken het bevel zichtbaar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![Het 3D‑bevel‑effect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Het 3D‑beeld van een vorm wordt bestuurd door zijn camera‑instellingen. Dit voorbeeld gebruikt [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) met breedte‑, lengte‑ en revolutiehoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) en gebalanceerde verlichting via [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), waarna de geformatteerde rechthoek wordt opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit‑rendering voor vormen regelen**

De methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) specificeert hoe een individuele vorm wordt gerenderd wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het activeert de zwart‑wit‑weergave niet zelf, en het verandert de opvulling, lijn of andere opmaak van de vorm niet in de normale kleurmodus.

Gebruik een waarde uit de klasse [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de render‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen modus op vormniveau is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en gebruikt [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) om de modus op grijs in te stellen. De opgeslagen vorm behoudt zijn oranje opvulling voor normale kleurweergave en vraagt grijze kleuring aan applicaties die zwart‑wit‑weergave respecteren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In normale kleurmodus behoudt de rechthoek zijn oranje opvulling. In een zwart‑wit‑workflow gebruikt hij grijze kleuring omdat de modus is ingesteld op `Gray`. Hiermee kun je een volledige‑kleur dia behouden terwijl je een aparte weergave voor afdrukken, preview of andere workflows definieert die zwart‑wit‑instellingen respecteren.

## **Opmaak resetten**

Gebruik [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) om de positie, grootte en opmaak van dia‑plaatsaanduidingen te herstellen vanuit de overeenkomende lay‑plaatsaanduidingen. Dit voorbeeld vereist een bestaande presentatie met lay‑gerelateerde plaatsaanduidingen en reset elke dia vóór het opslaan. Vormen zonder overeenkomstige lay‑plaatsaanduidingen worden niet gereset.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Beïnvloedt vormopmaak de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effectinstellingen voegen doorgaans weinig data toe vergeleken met ingesloten afbeeldingen en media. Afbeeldings‑opvullingen kunnen de bestandsgrootte vergroten omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de sleutel‑opmaak‑eigenschappen van elke vorm — opvulling, lijn en effectinstellingen. Als alle overeenkomende waarden gelijk zijn, beschouw dan hun stijlen als identiek en groepeer die vormen logisch; dit vereenvoudigt later stijlbeheer.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon‑diareeks of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloont je de gestylede vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.