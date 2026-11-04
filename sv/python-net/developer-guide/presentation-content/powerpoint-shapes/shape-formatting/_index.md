---
title: Formatera PowerPoint-former i Python
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/python-net/shape-formatting/
keywords:
- formatera form
- formatera linje
- skisseringseffekt
- skissformlinje
- formatera fogstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- svartvit formrendering
- gråskala formrendering
- rotera form
- 3D-fasadseffekt
- 3D-rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint-former i Python med Aspose.Slides—ställ in fyllning, linje och effektstilar för PPT, PPTX och ODP-filer med precision och full kontroll."
---
## **Introduktion**

Formatera former i PowerPoint genom att justera deras konturer, fyllningar och effekter. Aspose.Slides för Python via .NET låter dig kontrollera dessa inställningar programmässigt, inklusive transparens, rotation och 3D‑formatering.

![Formateringsalternativ för former i PowerPoint](format-shape-powerpoint.png)

Aspose.Slides för Python via .NET tillhandahåller klasser och egenskaper som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Använd [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) för att kontrollera en formens kontur. Detta exempel skapar en ofylld rektangel med en blå, streckad kontur. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) väljer en tjock‑tunn kombinerad linje, medan [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) sätter dess bredd till 7 punkter och [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) väljer streckmönstret.

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

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

### **Ange anpassade linjestreckmönster**

Använd [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) när fördefinierade linjestilar inte tillhandahåller de strecklängder och mellanrum du behöver, exempelvis för varumärkta konturer eller tekniska diagram. Att tilldela ett mönster sätter automatiskt [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) till [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Listposterna alternerar mellan streck- och mellanrumslängder, med ett streck först. Varje värde är en multipel av linjebredden: `[4, 2]` vid en bredd på 3 punkter ger ett 12‑punkts streck följt av ett 6‑punkts mellanrum. Använd par av ändliga, icke‑negativa värden för att definiera kompletta streck‑och‑mellanrum‑segment. Exemplet använder positiva värden för att hålla varje streck och mellanrum synliga.

Detta exempel skapar fem blå linjer med samma längd och platta ändar. De första tre jämför mönster vid en bredd på 3 punkter. Den fjärde upprepar det första mönstret med dubbelt så stor bredd, vilket dubblar både streck- och mellanrumslängderna. Den femte byter från ett anpassat mönster till en solid linje.

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

    # Återställ den sista linjen till en solid stil.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

För att återgå till en fördefinierad streckad stil istället, tilldela [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) till [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Den valda stilen styr linjens utseende.

Resultatet i PowerPoint, från topp till botten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; och **Solid, 3 pt**.

![Tre anpassade streckmönster, en bredare linje som använder det första mönstret, och en solid linje i PowerPoint](custom-dash-patterns.png)

### **Ställ in linjeändar**

Använd [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) för att ange ändarna på en öppen linje. Uppräkningen [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) ger tre explicita kapstil:

- `FLAT`: Strecket slutar vid slutpunkten.
- `ROUND`: En halvcirkelformad ände sträcker sig förbi slutpunkten med halva linjebredden.
- `SQUARE`: En fyrkantig ände sträcker sig förbi slutpunkten med halva linjebredden.

Uppräkningen innehåller också `NOT_DEFINED`, vilket betyder att ingen kapstil har tilldelats explicit.

Ändarna skiljer sig från pilspetsar, som lägger till symboler i linjeändarna, och fogar, som styr hörnen mellan linjesegment. Detta exempel inaktiverar pilspetsar via [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) och [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) så att endast kapformerna jämförs.

Följande exempel skapar tre i övrigt identiska horisontella linjer, 20 punkter breda. Från topp till botten använder de platta, runda och fyrkantiga ändar. Deras slutpunkter har samma horisontella koordinater; de runda och fyrkantiga ändarna sträcker sig 10 punkter förbi varje slutpunkt.

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

Resultatet i PowerPoint, från topp till botten: **Flat**, **Round** och **Square**.

![Platta, runda och fyrkantiga ändar på identiska tjocka linjer i PowerPoint](line-caps.png)

## **Tillämpa skisseringseffekter på formlinjer**

En skisseringseffekt får en formlinje att se handritad ut. Använd [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) för att komma åt linjeinställningarna, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) för att komma åt skisseringsinställningarna, och [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Följande Python‑kod visar hur man applicerar en [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

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

Det värde som returneras av [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) representerar den inställning som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), gå till [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), och läs [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Det effektiva värdet reflekterar den formatering som faktiskt appliceras efter att arv har lösts. Detta exempel kräver en befintlig presentation med minst en form på första bilden och skriver ut båda värdena:

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

## **Formatera fogstilar**

Här är de tre fogtyp‑alternativen:

* Round
* Miter
* Bevel

Fogstilen styr hur två kontursegment möts i ett hörn. Använd **Round** för avrundade hörn, **Miter** för skarpa hörn, eller **Bevel** för platta hörn.

![Fogstilen i presentationen](join-style-powerpoint.png)

Detta exempel skapar tre svarta rektanglar med blå konturer 15 punkter breda. Det sätter [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) till respektive miter‑, bevel‑ och round‑värden från [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) för att jämföra hur hörnen ritas.

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

### **Begränsa Miter-fogar vid skarpa hörn**

Använd [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) med [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) satt till [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) för att begränsa hur långt ett skarpt hörn kan sträcka sig.

Gränsen är ett förhållande mellan avståndet mellan de inre och yttre hörnen av fogaren och linjebredden. Till exempel tillåter ett värde på `8` en miter‑längd på upp till åtta gånger linjebredden; det är ingen mätning i punkter. Om hörnet skulle överskrida gränsen använder PowerPoint en fasad‑fog vid det hörnet. En större gräns tillåter skarpare spetsar. Inställningen påverkar bara miter‑fogar, och att ändra den har ingen synlig effekt när hörnet förblir inom båda gränserna.

Detta exempel skapar två identiska, ofyllda trianglar med konturer 20 punkter breda. Den vänstra triangeln använder en gräns på `2`, och den högra använder `8`. Varje triangel är 80 punkter bred och 160 punkter hög, vilket ger dess översta hörn ett miter‑längd‑till‑linjebredd‑förhållande på ungefär `4.12`. Således fasar PowerPoint det vänstra spetsen och behåller det högra spetsen.

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

Resultatet i PowerPoint: **Miter limit 2** på vänster sida och **miter limit 8** på höger sida.

![Ett fasat hörn med mitergräns 2 och ett spetsigt hörn med mitergräns 8 i PowerPoint](miter-limits.png)

## **Gradientfyllning**

En gradientfyllning blandar färger över en form. Detta exempel fyller en ellips med en linjär gradient i 45‑graders vinkel från rött till lila med hjälp av [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Metoden [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) placerar färgstopp vid 0 och 1, början och slut på gradienten. Att rensa befintliga stopp säkerställer att endast dessa två färger används.

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

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Choose a Gradient Rendering Style](/slides/sv/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

### **Ställ in linjär gradientvinkel**

Använd [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) för att kontrollera orienteringen av en [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/)‑fyllning. Vinkeln mäts i grader och ökar medurs: `0` går från vänster till höger, `90` från topp till botten, `180` från höger till vänster och `270` från botten till toppen. Bråkvinklar stöds. Finitiva vinklar utanför `[0, 360)` normaliseras till en varv; exempelvis blir `-45` till `315` och `360` till `0`.

Detta exempel skapar sex rektanglar med identiska röd‑, grön‑ och blå‑stopp på positionerna `0`, `0.5` och `1`. Skalning är inaktiverad så att vinkeln kan jämföras oberoende av rektanglarnas proportioner. Vinklarna, från vänster till höger, är `0`, `45` och `90` i första raden, och `135`, `180` och `270` i den andra raden.

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

![Linjär gradient vid 0, 45 och 90 grader i översta raden, och 135, 180 och 270 grader i nedersta raden](linear-gradient-angles.png)

### **Skala en linjär gradient med formen**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) accepterar ett [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)-värde. Sätt det explicit till `FALSE` för att behålla den geometriska gradientvinkeln när formens proportioner ändras, eller till `TRUE` för att skala gradienten med formens bredd och höjd. Med skalning aktiverad kan den synliga vinkeln skilja sig från den tilldelade vinkeln på en icke‑kvadratisk form.

Följande exempel använder en `45`‑graders vinkel och samma färgstopp som vinkeljämförelsen. Den vänstra kolumnen använder `FALSE`; den högra kolumnen använder `TRUE`. Varje kolumn innehåller en bred rektangel ovanför en hög rektangel. Båda börjar med samma breda dimensioner; förändring av den andra rektangelns bredd och höjd demonstrerar hur fyllningen svarar på storleksändring utan att ändra gradientinställningarna.

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

![Breda och långa rektanglar med en 45‑graders gradient, jämför linear_gradient_scaled FALSE till vänster och TRUE till höger](linear-gradient-scaling.png)

Med skalning inaktiverad behåller de diagonala färgbanden samma orientering i båda rektanglarna. Med skalning aktiverad sträcks banden med formens proportioner. Detta hjälper till att återge en mall‑gradient när en form anpassas till en annan storlek. På en kvadrat ändras inte utseendet på denna `45`‑graders gradient när skalning aktiveras.

Både vinkeln och skalningsinställningarna gäller för linjära gradienter. De styr inte [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/)‑fyllningar.

### **Kombinera vinkeln med gradientriktning**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) väljer en gradientstil från uppräkningen [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); den ersätter inte ett numeriskt vinkelvärde. För en linjär gradient kan hörnstilarna ändra det område över vilket färgerna fördelas utan att ändra [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Behåll riktningen oförändrad när du jämför vinklar eller skalning.

Följande exempel applicerar samma inställningar i omvänd ordning. De två rektanglerna ser likadana ut: att tilldela riktningen före eller efter vinkeln ändrar inte resultatet.

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

## **Mönsterfyllning**

En mönsterfyllning applicerar en tvåfärgsdesign, såsom prickar, ränder eller rutnät. Detta exempel använder [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) för att välja ett nätmönster. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) levererar den ljusgrå bakgrunden, och [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) levererar den gula mönsterfärgen.

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

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

En bildfyllning använder en bild inuti en form. Detta exempel kräver en lokal bild och använder [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) för att ladda den i presentationens bildsamling. Att sätta [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) till det tiled‑läget upprepar bilden inom rektangeln. Källbilden som används här visas nedan:

![Lotusbilden](lotus.png)

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

![Formen med bildfyllning](picture-fill.png)

### **Tile-bild som textur**

Om du vill sätta en tiled bild som en textur och anpassa tesselleringen kan du använda följande egenskaper i klassen [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ställer in bildfyllningsläget — antingen `TILE` eller `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Anger justeringen av plattorna inom formen.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Styr om plattan vänds horisontellt, vertikalt eller båda.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ställer in den horisontella förskjutningen av plattan (i punkter) från formens ursprung.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ställer in den vertikala förskjutningen av plattan (i punkter) från formens ursprung.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definierar den horisontella skalan av plattan i procent.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definierar den vertikala skalan av plattan i procent.

Detta exempel kräver en lokal bild och konfigurerar [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) för att upprepa den på 50 % av sin ursprungliga storlek. Förskjutningar på −32 punkter flyttar plattorna horisontellt och vertikalt; justering längst ner till höger samt spegling i båda riktningarna bestämmer hur den upprepade texturen arrangeras.

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

![Plattalternativen](tile-options.png)

## **Solid färgfyllning**

En solid fyllning ger en form en enda, jämn färg. Detta exempel sätter [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) till solid‑fyllningsläget och tilldelar gul via [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), och sparar sedan rektangeln i en presentation.

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

![Formen med solid färgfyllning](solid-color-fill.png)

## **Använd bildbakgrunden som formfyllning**

Använd [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) när en form ska matcha bildbakgrunden, exempelvis i en presentationsmall. Sätt först [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) till [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) för att ta bort eventuell explicit fyllning. Med denna kombination använder formen bildbakgrunden istället för sin stilmålning. Att bara aktivera flaggan tar inte bort en existerande explicit fyllning.

Detta skiljer sig från [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): bakgrundsfyllning täcker objekt bakom formen med motsvarande område av bildbakgrunden, medan ingen fyllning låter dessa objekt vara synliga. En gradient förblir justerad med bilden snarare än att starta om i varje form.

Följande exempel skapar en master‑bakgrund som ärvs av bilden och placerar ett magentaband bakom tre rektanglar. Den vänstra rektangeln använder bakgrunden, den mellersta har ingen fyllning, och den högra byter från bakgrundsfyllning till en explicit orange fyllning.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Ärva gradienten från master.
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

    # Lägg till detta objekt först så det visas bakom rektanglarna.
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

    # Inaktivera bakgrundsfyllning före applicering av en explicit fyllning.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Bakgrundsfyllning, ingen fyllning och explicit orange fyllning över ett magentaband](background-fill.png)

Samma beteende gäller för en bakgrund som definieras direkt på bilden eller ärvs från en layout. Formen använder bildens lösta bakgrund; exemplet lämnar både bild‑ och layoutbakgrund odefinierade så att master‑bakgrunden levereras.

## **Ställ in transparens**

För en solid fyllning styr färgens alfa‑komponent opaciteten: 0 är helt transparent och 255 är helt opaque. Detta exempel använder ett alfavärde på 128 för en gul rektangel, vilket gör den ungefär 50 % transparent så att rektangeln under förblir synlig. Färgen tilldelas via [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

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

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Använd [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) för att rotera en form i bildplanet. Vinkeln mäts i grader; detta exempel roterar en rektangel 5 grader medurs och sparar presentationen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Formens rotation](shape-rotation.png)

## **Lägg till 3D-fasadseffekter**

Använd [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) för att ge en form djup och fasade kanter. Detta exempel skapar en grön ellips med orange kontur, sätter [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) till 4 punkter och applicerar en cirkulär top‑bevel med bredd och höjd på 6 punkter via [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). En front‑facing ortografisk kamera och tre‑punkt belysning gör fasen synlig.

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

![3D-fasadseffekten](3D-bevel-effect.png)

## **Lägg till 3D-rotationsseffekter**

En forms 3D‑vy styrs av dess kamerainställningar. Detta exempel använder [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) med latitud, longitud och revolutionsvinklar på 40, 35 respektive 20 grader. Det väljer en isometrisk kamera via [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) och balanserad belysning via [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), och sparar sedan den formaterade rektangeln.

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

![3D-rotationsseffekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

Egenskapen [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vitt läge. Den möjliggör inte svart‑vit visning i sig, och den ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från uppräkningen [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `AUTOMATIC` renderingsprogrammet välja konverteringen, `GRAY` och `LIGHT_GRAY` använder gråtoner, `BLACK_WHITE` använder endast svart och vitt, `BLACK` och `WHITE` tvingar en enda färg, `COLOR` behåller normal färgsättning, och `HIDDEN` utesluter formen i svart‑vitt läge. `NOT_DEFINED` betyder att inget form‑nivå‑läge är tilldelat.

Detta exempel skapar en orange rektangel och sätter [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) till gray. Den sparade formen behåller sin orange fyllning för normalt färgläge och begär grå färgsättning från program som hedrar svart‑vit displayinställning:

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

I normalt färgläge behåller rektangeln sin orange fyllning. I ett svart‑vitt arbetsflöde använder den grå färgsättning eftersom dess läge är satt till `GRAY`. Detta låter dig bevara en färgrik bild medan du definierar ett tydligt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som hedrar presentationens svart‑vita displayinställningar.

## **Återställ formatering**

Använd [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) för att återställa position, storlek och formatering av bildplatshållare från motsvarande layout‑platshållare. Detta exempel kräver en befintlig presentation med layout‑länkade platshållare och återställer varje bild innan sparning. Former utan motsvarande layout‑platshållare återställs inte.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Påverkar formateringen av former den slutgiltiga presentationsfilens storlek?**

Färger, linjestilar och effektinställningar adderar generellt lite data jämfört med inbäddade bilder och media. Bildfyllningar kan öka filstorleken eftersom deras bilder lagras i presentationen.

**Hur kan jag identifiera former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar till en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempel­former med önskade stilar i en mall‑bildspel eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stiliserade former du behöver och återapplicera deras formatering där det krävs.