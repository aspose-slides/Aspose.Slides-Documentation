---
title: Anpassa former i presentationer med Python
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/python-net/custom-shape/
keywords:
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometribana
- banpunkter
- redigera punkter
- lägg till punkt
- ta bort punkt
- redigeringsoperation
- rundat hörn
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET: geometribanor, rundade hörn, sammansatta former."
---
## **Introduktion**

Tänk på en kvadrat. I PowerPoint, med **Edit Points**, kan du:

* flytta en kvadrats hörn inåt eller utåt,
* justera krökningen av ett hörn eller en punkt,
* lägga till nya punkter på kvadraten,
* manipulera dess punkter.

Du kan tillämpa dessa operationer på vilken form som helst. Med **Edit Points** kan du modifiera en form eller skapa en ny från en befintlig form.

## **Tips för redigering av former**

!["Redigera punkter"-kommando](custom_shape_0.png)

Innan du börjar redigera PowerPoint-former med **Edit Points**, överväg följande anteckningar om former:

* En form (eller dess bana) kan vara **sluten** eller **öppen**.
* En sluten form har ingen start- eller slutpunkt; en öppen form har en början och ett slut.
* Varje form har minst två ankarpunkter som är kopplade med linjesegment.
* Ett segment är antingen rakt eller kurvigt; ankarpunkterna bestämmer segmentets natur.
* Ankarpunkter kan vara **corner**, **smooth**, eller **straight**:
  * En **corner**-punkt är där två raka segment möts i en vinkel.
  * En **smooth**-punkt har två handtag som är kollineära, och de angränsande segmenten bildar en mjuk kurva. I detta fall är båda handtagen på samma avstånd från ankaret.
  * En **straight**-punkt har också två kollineära handtag, och de angränsande segmenten bildar en mjuk kurva. I detta fall behöver handtagen inte vara på samma avstånd från ankaret.
* Genom att flytta eller redigera ankarpunkter (och därmed ändra segmentvinklar) kan du förändra formens utseende.

För att redigera PowerPoint-former tillhandahåller Aspose.Slides klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) .

* En [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) instans representerar geometribanan för ett [GeometryShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/)‑objekt.
* För att hämta [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) från en [GeometryShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/)‑instans, använd metoden [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* För att ange [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) för en form, använd [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/set_geometry_path/) för *solida former* och [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/set_geometry_paths/) för *sammansatta former*.
* För att lägga till segment, använd metoderna på [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) .
* Använd egenskaperna [GeometryPath.stroke](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/stroke/) och [GeometryPath.fill_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/fill_mode/) för att styra ett geometribans utseende.
* Använd egenskapen [GeometryPath.path_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/path_data/) för att hämta en formes geometribana som en array av bansegment.

## **Enkla redigeringsoperationer**

Följande metoder används för enkla redigeringsoperationer.

**Lägg till en linje** till slutet av en bana:

```py
line_to(point)
line_to(x, y)
```

**Lägg till en linje** på en angiven position i en bana:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Lägg till en kubisk Bezier-kurva** till slutet av en bana:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Lägg till en kubisk Bezier-kurva** på en angiven position i en bana:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Lägg till en kvadratisk Bezier-kurva** till slutet av en bana:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Lägg till en kvadratisk Bezier-kurva** på en angiven position i en bana:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Lägg till en båge** till en bana:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Stäng den aktuella figuren** i en bana:

```py
close_figure()
```

**Ange positionen för nästa punkt**:

```py
move_to(point)
move_to(x, y)
```

**Ta bort bansegmentet** på ett givet index:

```py
remove_at(index)
```

## **Lägg till anpassade punkter till former**

Här lär du dig hur du definierar en frihandsform genom att lägga till din egen sekvens av punkter. Genom att ange ordnade punkter och segmenttyper (raka eller kurviga) och eventuellt stänga banan kan du rita precisa anpassade grafik—polygoner, ikoner, förklaringar eller logotyper—direkt på dina bilder.

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/) och ange dess [ShapeType.RECTANGLE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapetype/) .
2. Hämta en [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/)‑instans från formen.
3. Infoga en ny punkt mellan de två övre punkterna på banan.
4. Infoga en ny punkt mellan de två nedre punkterna på banan.
5. Applicera den uppdaterade banan på formen.

Följande Python‑kod visar hur man lägger till anpassade punkter till en form:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Custom points](custom_shape_1.png)

##  **Ta bort punkter från former**

Ibland innehåller en anpassad form onödiga punkter som komplicerar dess geometri eller påverkar hur den renderas. Den här sektionen visar hur man tar bort specifika punkter från en formes bana så att du kan förenkla konturen och uppnå renare, mer precisa resultat.

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/) och ange dess typ [ShapeType.HEART](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapetype/) .
2. Hämta en [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/)‑instans från formen.
3. Ta bort ett segment från banan.
4. Applicera den uppdaterade banan på formen.

Följande Python‑kod visar hur man tar bort punkter från en form:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Removed points](custom_shape_2.png)

##  **Skapa anpassade former**

Skapa skräddarsydda vektorformer genom att definiera en [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) och komponera den av linjer, bågar och Bézier‑kurvor. Den här sektionen visar hur du bygger en anpassad geometri från grunden och lägger till den resulterande formen på din bild.

1. Beräkna punkterna för formen.
2. Skapa en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) .
3. Fyll banan med punkterna.
4. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/) .
5. Applicera banan på formen.

Följande Python‑kod visar hur man skapar en anpassad form:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Custom shape](custom_shape_3.png)

## **Skapa sammansatta anpassade former**

Att skapa en sammansatt anpassad form låter dig kombinera flera geometribanor till en enda återanvändbar form på en bild. Definiera och slå ihop dessa banor för att bygga komplexa visualiseringar som går utöver standarduppsättningen av former.

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/) .
2. Skapa den första instansen av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) .
3. Skapa den andra instansen av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/) .
4. Applicera båda banorna på formen.

Följande Python‑kod visar hur man skapar en sammansatt anpassad form:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Composite shape](custom_shape_4.png)

## **Skapa anpassade former med rundade hörn**

Den här sektionen visar hur du ritar en anpassad form med mjukt rundade hörn med hjälp av en geometribana. Du kombinerar raka segment och cirkulära bågar för att forma konturen och lägger till den färdiga formen på din bild.

Följande Python‑kod visar hur man skapar en anpassad form med rundade hörn:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Curved corners](custom_shape_6.png)

## **Bestäm om en formes geometri är sluten**

En sluten form definieras som en där alla sidor är sammanlänkade och bildar en enda gräns utan luckor. En sådan form kan vara en enkel geometrisk form eller en komplex anpassad kontur. Följande kodexempel visar hur man kontrollerar om en formes geometri är sluten:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Vad händer med fyllningen och konturen efter att geometrin har ersatts?**

Stilen förblir på formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [rotation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometryshape/rotation/)‑egenskap; geometrin roterar med formen eftersom den är bunden till formens egna koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att “låsa” resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/python-net/convert-powerpoint-to-png/)‑området eller själva [shape](/slides/sv/python-net/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med tunga geometrier.