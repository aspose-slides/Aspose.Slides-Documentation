---
title: Formatera PowerPoint-former i Python via Java
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/python-java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss-effekt
- skissa formlinje
- formatera fogstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- svart‑vit rendering av former
- gråskala rendering av former
- rotera form
- 3D‑fasadeffekt
- 3D‑roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Python via Java med Aspose.Slides—ange fyllnings‑, linje‑ och effektsstilar för PPT‑ och PPTX‑filer med precision och full kontroll."
---
## **Introduktion**

Formatera former i PowerPoint genom att justera deras konturer, fyllningar och effekter. Aspose.Slides för Python via Java låter dig kontrollera dessa inställningar programatiskt, inklusive transparens, rotation och 3D‑formatering.

![Formateringsalternativ för former i PowerPoint](format-shape-powerpoint.png)

Aspose.Slides för Python via Java tillhandahåller klasser och metoder som gör att du kan formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Använd [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) för att kontrollera en formats kontur. Detta exempel skapar en ofylld rektangel med en blå, streckad kontur. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) väljer en tjock‑tunn sammansatt linje, medan [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) sätter dess bredd till 7 punkter och [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) väljer dash‑mönstret.

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

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

### **Ange anpassade linjedash‑mönster**

Använd [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) när fördefinierade linjestilar inte ger de dash‑längder och mellanrum du behöver, till exempel för varumärkta konturer eller tekniska diagram. När ett mönster tilldelas ändras linjedash‑stilen automatiskt till [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Array‑poster växlar mellan dash‑ och gap‑längder, med en dash först. Varje värde är en multipel av linjebredden: `[4, 2]` vid en bredd på 3 punkter ger ett 12‑punkts dash följt av ett 6‑punkts gap. Använd par av ändliga, icke‑negativa värden för att definiera kompletta dash‑och‑gap‑segment. Exemplet använder positiva värden för att hålla varje dash och gap synligt.

Detta exempel skapar fem blå linjer med samma längd och platta ändar. De första tre jämför mönster vid en bredd på 3 punkter. Den fjärde upprepar det första mönstret med dubbel bredd, vilket fördubblar både dash‑ och gap‑längderna. Den femte byter från ett anpassat mönster till en solid linje.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

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

    # Återställ den sista linjen till en solid stil.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För att återgå till en fördefinierad streckad stil, skicka [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) till [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Den valda stilen styr linjens utseende.

Resultatet i PowerPoint, uppifrån och ner: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; och **Solid, 3 pt**.

![Tre anpassade dash‑mönster, en bredare linje med första mönstret och en solid linje i PowerPoint](custom-dash-patterns.png)

### **Ange linjeändar (Caps)**

Använd [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) för att sätta ändarna på en öppen linje. Klassen [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) erbjuder tre explicita cap‑stilar:

- `Flat`: Linjen slutar vid ändpunkten.
- `Round`: En halvcirkelformad cap sträcker sig bortom ändpunkten med halva linjebredden.
- `Square`: En fyrkantig cap sträcker sig bortom ändpunkten med halva linjebredden.

Klassen innehåller också `NotDefined`, vilket betyder att ingen cap‑stil är explicit tilldelad.

Caps skiljer sig från pilspetsar, som lägger till symboler i linjeändarna, och från fogar, som styr hörnen mellan linjesegment. Detta exempel inaktiverar pilspetsar via [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) och [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) så att endast cap‑formerna jämförs.

Följande exempel skapar tre annars identiska horisontella linjer, 20 punkter breda. Uppifrån och ner använder de platta, runda och fyrkantiga caps. Deras ändpunkter har samma horisontella koordinater; de runda och fyrkantiga caps sträcker sig 10 punkter bortom varje ändpunkt.

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

Resultatet i PowerPoint, uppifrån och ner: **Flat**, **Round**, och **Square**.

![Platta, runda och fyrkantiga caps på identiska tjocka linjer i PowerPoint](line-caps.png)

## **Tillämpa skiss‑effekter på formlinjer**

En skiss‑effekt får en formlinje att se handritad ut. Använd [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) för att komma åt linjeinställningarna, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) för att komma åt skiss‑inställningarna, och [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) för att välja ett värde från klassen [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Följande Python‑kod visar hur du applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

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

Värdet som returneras av [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) representerar inställningen som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, huvud‑slide eller layout‑slide, använd [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) och läs skiss‑typen från den effektiva linjeformateringen, som visas nedan. Det effektiva värdet speglar den formatering som faktiskt tillämpas efter ärvning har lösts. Detta exempel kräver en befintlig presentation med minst en form på första sliden och skriver ut båda värdena:

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

## **Formatera fog‑stilar**

Här är de tre fog‑typ‑alternativen:

* Round
* Miter
* Bevel

Fog‑stilen styr hur två kontursegment möts i ett hörn. Använd **Round** för rundade hörn, **Miter** för spetsiga hörn, eller **Bevel** för avfasade hörn.

![Fog‑stilen i presentationen](join-style-powerpoint.png)

Detta exempel skapar tre svarta rektanglar med blå konturer 15 punkter breda. Det använder [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) för att sätta miter‑, bevel‑ och round‑värdena i [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), respektive, för att jämföra hur hörnen ritas.

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

### **Begränsa miter‑fogar i spetsiga hörn**

Använd [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) tillsammans med [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) satt till [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) för att begränsa hur långt ett spetsigt hörn kan sträcka sig.

Begränsningen är ett förhållande mellan avståndet mellan det inre och yttre hörnet på fogen och linjebredden. Till exempel tillåter ett värde på `8` en miter‑längd på upp till åtta gånger linjebredden; det är ingen mätning i punkter. Om hörnet skulle överstiga begränsningen använder PowerPoint en avfasad fog vid det hörnet. En större gräns ger skarpare punkter. Inställningen påverkar bara miter‑fogar, och att ändra den har ingen synlig effekt när hörnet förblir inom båda gränserna.

Detta exempel skapar två identiska, ofyllda trianglar med konturer 20 punkter breda. Den vänstra triangeln använder en gräns på `2`, och den högra använder `8`. Varje triangel är 80 punkter bred och 160 punkter hög, vilket ger dess översta hörn ett miter‑längd‑till‑linjebredd‑förhållande på cirka `4.12`. Följaktligen avfasar PowerPoint den vänstra spetsen och bevarar den högra spetsen.

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

Resultatet i PowerPoint: **Miter limit 2** till vänster och **miter limit 8** till höger.

![En avfasad spets med miter‑gräns 2 och en spetsig spets med miter‑gräns 8 i PowerPoint](miter-limits.png)

## **Gradientfyllning**

En gradientfyllning blandar färger över en form. Detta exempel fyller en ellips med en linjär gradient i 45‑gradars vinkel från röd till lila med hjälp av [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Metoden [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) placerar färgstopp vid 0 och 1, början och slut på gradienten. Att rensa befintliga stopp säkerställer att endast dessa två färger används.

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

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Choose a Gradient Rendering Style](/slides/sv/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

### **Ange vinkel för linjär gradient**

Använd [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) för att kontrollera orienteringen av en [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)‑fyllning. Vinkeln mäts i grader och ökar medurs: `0` går från vänster till höger, `90` från topp till botten, `180` från höger till vänster, och `270` från botten till topp. Bråktalsgrader stöds. Ändliga vinklar utanför `[0, 360)` normaliseras till en varv; exempelvis blir `-45` till `315` och `360` till `0`.

Detta exempel skapar sex rektanglar med identiska röda, gröna och blå stopp på positionerna `0`, `0.5` och `1`. Skalning är inaktiverad så att vinkeln kan jämföras oberoende av rektanglarnas proportioner. Vinklarna, från vänster till höger, är `0`, `45` och `90` i första raden, och `135`, `180` och `270` i andra raden.

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

Resultatet i PowerPoint:

![Linjär gradient vid 0, 45 och 90 grader i övre raden, samt 135, 180 och 270 grader i nedre raden](linear-gradient-angles.png)

### **Skala en linjär gradient med formen**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepterar ett [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)‑värde. Sätt det explicit till `False_` för att behålla den geometriska gradientvinkeln när formens proportioner ändras, eller till `True_` för att skala gradienten med formens bredd och höjd. Med skalning aktiverad kan den synliga vinkeln skilja sig från den tilldelade vinkeln på en icke‑kvadratisk form.

Följande exempel använder en `45`‑graders vinkel och samma färgstopp som vinkel‑jämförelsen. Den vänstra kolumnen använder `False_`; den högra kolumnen använder `True_`. Varje kolumn innehåller en bred rektangel ovanför en hög rektangel. Båda startar med samma breda dimensioner; ändringen av den andra rektangelns bredd och höjd demonstrerar hur fyllningen reagerar på storleksändring utan att ändra dess gradientinställningar.

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

Resultatet i PowerPoint, med skalning inaktiverad till vänster och aktiverad till höger:

![Breda och höga rektanglar med en 45‑graders gradient, jämförelse av LinearGradientScaled False till vänster med True till höger](linear-gradient-scaling.png)

Med skalning inaktiverad behåller de diagonala färgbanden samma orientering i båda rektanglarna. Med skalning aktiverad sträcks banden med formens proportioner. Detta hjälper till att reproducera en mallgradient när en form anpassas till en annan storlek. På en kvadrat ändrar inte aktivering av skalning utseendet på denna `45`‑graders gradient.

Både vinkel‑ och skalningsinställningarna gäller linjära gradienter. De styr inte [GradientShape.Radial eller GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)‑fyllningar.

### **Kombinera vinkel med gradient‑riktning**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) väljer en gradientstil från klassen [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); den är ingen ersättning för en numerisk vinkel. För en linjär gradient kan hörnstilarna ändra det område där färgerna fördelas utan att ändra vinkeln som tilldelats via [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Behåll riktningen oförändrad när du jämför vinklar eller skalning.

Följande exempel applicerar samma inställningar i omvänd ordning. De två rektanglarna har samma utseende: att ange riktningen före eller efter vinkeln ändrar inte resultatet.

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

## **Mönsterfyllning**

En mönsterfyllning applicerar en två‑färgsdesign, såsom prickar, ränder eller schackrutor. Detta exempel använder [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) för att välja ett galler‑mönster. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) anger den ljusgrå bakgrunden, och [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) anger den gula mönsterfärgen.

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

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

En bildfyllning använder en bild inuti en form. Detta exempel kräver en lokal bild och använder [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) för att ladda den i presentationens bildsamling. Att sätta [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) till tiled‑läget upprepar bilden inom rektangeln. Källbilden som används visas nedan:

![Lotus‑bilden](lotus.png)

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

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tila bild som textur**

Om du vill ange en tiled bild som en textur och anpassa tilningsbeteendet, kan du använda följande metoder i klassen [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ställer in bildfyllningsläge — antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Anger justeringen av tiles inom formen.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Styr om tile vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ställer in den horisontella förskjutningen av tile (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ställer in den vertikala förskjutningen av tile (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definierar horisontell skala för tile som en procentandel.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definierar vertikal skala för tile som en procentandel.

Detta exempel kräver en lokal bild och konfigurerar [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) för att upprepa den på 50 % av dess originalstorlek. Förskjutningar på −32 punkter flyttar tiles horisontellt och vertikalt; nederst‑höger‑justering och vändning i båda riktningarna bestämmer hur den upprepade texturen placeras.

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

Resultatet:

![Tile‑alternativen](tile-options.png)

## **Solid färgfyllning**

En solid fyllning ger en form en enda, enhetlig färg. Detta exempel använder [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) för att sätta solid‑fyllningsläge och tilldelar gul via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), sedan sparar rektangeln i en presentation.

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

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

### **Kopiera färger samtidigt som temareferenser bevaras**

Använd [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) för att kopiera en färgdefinition, inklusive dess färgtyp, temareferens och transformationer. Detta är användbart när en fyllningsfärg ska överföras mellan former som bör fortsätta följa presentationens tema. Metoden kopierar endast färgen: den kopierar inte fyllningstyp, kontur eller annan formformatering. Sätt destinationens fyllningstyp explicit med [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType).

Detta exempel skapar tre rektanglar, från vänster till höger: källan, en temamedveten kopia och en fast RGB‑kopia. Källan använder [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) för att referera till den första accentfärgen och lägger till en nyans via [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add). RGB‑kopian använder källans effektiva fyllningsfärg så att alla tre initialt ser identiska ut. Att anropa [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) sätter ett fast RGB‑värde och rensar eventuella befintliga färgtransformationer.

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

    # Temareferenser följer den nya accentfärgen; det fasta RGB‑värdet gör det inte.
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

Före temaförändringen matchar alla tre fyllningar:

![Källa, copyFrom‑destination och fast RGB‑destination med identiska blå fyllningar](color-copy-before.png)

Efter temaförändringen följer källan och den temamedvetna kopian den nya accentfärgen och behåller sin nyans. Den fasta RGB‑kopian förblir blå:

![Källa och copyFrom‑destination med orange fyllningar, medan den fasta RGB‑destinationen förblir blå](color-copy-after.png)

Den kopierade definitionen är oberoende av källan. Att senare ändra källans temareferens, tilldela en annan färg eller lägga till/ta bort dess transformationer ändrar inte destinationen. En temaförändring påverkar båda formerna eftersom varje form refererar oberoende till samma temafärg.

Att spara och öppna PPTX‑filen bevarar den kopierade färgens typ som returneras av [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType), temareferensen och transformationssamlingen som returneras av [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform); den plattar inte ner definitionen till RGB.

När du kopierar mellan olika temakontexter, såsom presentationer med olika accentpaletter, löses den kopierade referensen mot destinationens tema. Samma referens och transformationer kan därför ge en annan synlig färg. Se [Presentation Theme](/slides/sv/python-java/presentation-theme/) för mer om konfiguration av temafärger.

## **Använd bildbakgrund som formfyllning**

Använd [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) när en form ska matcha bildbakgrunden, till exempel i en presentationsmall. Sätt fyllningstypen med [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) till [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) först för att ta bort eventuell explicit fyllning. Med denna kombination använder formen bildbakgrunden istället för sin egen stilfyllning. Att endast sätta flaggan tar inte bort en befintlig explicit fyllning.

Detta skiljer sig från [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): bakgrundsfyllning täcker objekt bakom formen med motsvarande område av bildbakgrunden, medan ingen fyllning låter dessa objekt vara synliga. En gradient förblir justerad mot bilden snarare än att starta om inuti varje form.

Följande exempel skapar en huvud‑bakgrund som ärvs av sliden och placerar ett magentaband bakom tre rektanglar. Den vänstra rektangeln använder bakgrunden, den mellersta har ingen fyllning, och den högra växlar från bakgrundsfyllning till en explicit orange fyllning.

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

    # Ärva gradienten från master.
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

    # Lägg till detta objekt först så att det visas bakom rektanglarna.
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

    # Inaktivera bakgrundsfyllning innan en explicit fyllning appliceras.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet, från vänster till höger: **bakgrundsfyllning**, **ingen fyllning**, och **explicit fyllning**. Magentabandet är dolt av den vänstra och högra rektangeln men synligt genom den mellersta.

![Bakgrundsfyllning, ingen fyllning och explicit orange fyllning över ett magentaband](background-fill.png)

Samma beteende gäller för en bakgrund som definieras direkt på sliden eller ärvs från en layout. Formen använder slidens lösta bakgrund; exemplet lämnar både slide‑ och layout‑bakgrunder odefinierade så att huvud‑bakgrunden levererar den.

## **Ange transparens**

För en solid fyllning styr färgens alfakomponent opaciteten: 0 är helt genomskinlig och 255 är fullt opak. Detta exempel använder ett alfa‑värde på 128 för en gul rektangel, vilket gör den ungefär 50 % transparent så att rektangeln under förblir synlig. Färgen tilldelas via [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

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

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Använd [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) för att rotera en form i slidens plan. Vinkeln mäts i grader; detta exempel roterar en rektangel 5 grader medurs och sparar presentationen.

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

Resultatet:

![Formroteringen](shape-rotation.png)

## **Lägg till 3D‑fasadeffekter**

Använd [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) för att ge en form djup och fasade kanter. Detta exempel skapar en grön ellips med orange kontur, använder [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) för att sätta djupet till 4 punkter, och applicerar en cirkulär top‑bevel med bredd och höjd på 6 punkter via [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). En front‑facing ortografisk kamera och tre‑punkts belysning gör fasen synlig.

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

Resultatet:

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D‑roterings‑effekter**

En forms 3D‑vy styrs av dess kamerainställningar. Detta exempel använder [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) med latitud, longitud och revolutionsvinklar på 40, 35 och 20 grader. Det väljer en isometrisk kamera genom [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) och balanserad belysning genom [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), sedan sparas den formaterade rektangeln.

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

Resultatet:

![3D‑roterings‑effekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

Metoden [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) anger hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den aktiverar inte svart‑vit visning i sig, och den ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder bara svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vit modus. `NotDefined` betyder att inget form‑nivå läge är tilldelat.

Detta exempel skapar en orange rektangel och använder [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) för att sätta läget till grå. Den sparade formen behåller sin orange fyllning för normalt färgvisning och begär grå färgning från program som hedrar svart‑vita visningsinställningar:

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

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde för svart‑vit visning använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en full‑färgs‑slide samtidigt som du definierar ett separat utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Använd [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) för att återställa position, storlek och formatering av platshållare på sliden från motsvarande layout‑platshållare. Detta exempel kräver en befintlig presentation med layout‑länkade platshållare och återställer varje slide innan den sparas. Former utan motsvarande layout‑platshållare återställs inte.

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

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Färger, linjestilar och effektinställningar lägger generellt till lite data jämfört med inbäddade bilder och media. Bildfyllningar kan öka filstorleken eftersom deras bilder lagras i presentationen.

**Hur kan jag upptäcka former på en slide som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar behandlas deras stilar som identiska och formerna kan logiskt grupperas, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar till en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑slide‑deck eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stilade formerna du behöver och applicera deras formatering där det krävs.