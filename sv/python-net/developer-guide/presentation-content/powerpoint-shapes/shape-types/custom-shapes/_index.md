---
title: "Anpassa presentationsformer i Python"
linktitle: "Anpassad form"
type: docs
weight: 20
url: /sv/python-net/custom-shape/
keywords:
- "anpassad form"
- "lägg till form"
- "skapa form"
- "ändra form"
- "formgeometri"
- "geometribana"
- "bannoter"
- "redigera punkter"
- "lägg till punkt"
- "ta bort punkt"
- "redigeringsoperation"
- "böjt hörn"
- "PowerPoint"
- "presentation"
- "Python"
- "Aspose.Slides"
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för Python via .NET: geometribanor, böjda hörn, sammansatta former."
---
## **Översikt**

Denna artikel förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) för att modifiera befintliga former, utföra grundläggande banredigeringsoperationer, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form.

Den visar också hur du skapar anpassade och sammansatta former, bygger former med böjda hörn, avgör om en formgeometri är sluten och extraherar formelement för konturanalys.

## **Ändra en form med redigeringspunkter**

I PowerPoint kan du använda **Redigeringspunkter** för att ändra en kvadrat:

* Flytta ett hörn inåt eller utåt.
* Justera kurvaturen vid en punkt.
* Lägg till nya punkter.

Att redigera punkter låter dig ändra en formes kontur eller använda en befintlig form som grund för en ny.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

När du redigerar PowerPoint‑former, ha dessa begrepp i åtanke:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* En formes bana består av ankarpunkter som är sammanlänkade av segment.
* Ett segment kan vara rakt eller kurvigt. Ankarpunkter och kontrollhandtag bestämmer dess form.
* Ankarpunkter finns som hörnpunkter, raka punkter eller mjuka punkter:
  * Vid en hörnpunkt kan anslutande segment mötas i en vinkel.
  * Vid en mjuk punkt är de två kontrollhandtagen i linje och lika långt från ankarpunkten.
  * Vid en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankarpunkten.
* Att flytta ankarpunkter eller justera deras handtag förändrar formens kontur.

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑instans representerar en geometrisk bana för objektet [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) från [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)-instansen kan du använda metoden [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* För att ange [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) för former med en enda bana och [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) för former med flera banor.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Genom att använda egenskaperna [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) och [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) kan du ange utseendet för en geometrisk bana.
* Genom att använda egenskapen [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) kan du hämta geometribanan för en [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) som en array av bansegment.

## **Enkla redigeringsoperationer**

Använd följande metoder för att redigera en geometrisk bana. Överlagringar som accepterar ett index infogar ett segment på den nollbaserade positionen i banans segmentarray.

| Operation | Metod |
| --- | --- |
| Lägg till eller infoga en rak linje. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Lägg till eller infoga en kubisk Bézier-kurva med två kontrollpunkter och en slutpunkt. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Lägg till eller infoga en kvadratisk Bézier-kurva med en kontrollpunkt och en slutpunkt. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Lägg till en elliptisk båge med angivna dimensioner och vinklar i grader. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Stäng den aktuella figuren genom att ansluta dess slutpunkt till startpunkten. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Ange startpunkten för en figur. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Ta bort ett segment på ett index med nollbas. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Lägg till anpassade punkter till en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) och tillämpar den redigerade banan med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Koordinaterna är lokala för formen: båda nya punkterna är i dess centrum, 100 punkter från vänster och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på övre respektive nedre kanten och drar dessa kanter inåt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Ta bort punkter från en form**

Detta exempel ändrar konturen på ett hjärtformat genom att ta bort segmentet på nollbaserat index 2 med [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). När den modifierade banan tillämpas med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) uppdateras formens kontur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Skapa en anpassad form**

Detta exempel bygger en femspetsig stjärna med [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Växlande yttre och inre radier på 100 respektive 50 punkter definierar spetsarna och inbuktningarna; ett steg på 72 grader placerar de fem spetsarna jämnt. Banan stängs med [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) och appliceras på en rektangulär form med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), vilket ersätter dess kontur.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Skapa en sammansatt anpassad form**

Detta exempel definierar två slutna [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑objekt för övre och nedre tredjedelen av en form. När båda banorna tillämpas med [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) skapas en enda sammansatt form med ett glapp över mitten av formen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Skapa en anpassad form med böjda hörn**

Detta exempel kombinerar raka segment med [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) för att skapa en form med inåtböjda hörn. Varje hörnstorlek anger bågens bredd och höjd i punkter, och en svepning på –90 grader ritar en moturs kvartselips. Den färdiga banan appliceras med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), och presentationen sparas i PPTX‑format.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta reda på om en formgeometri är sluten**

Följande hjälpfunktion kontrollerar om varje icke‑tom geometrisk bana avslutas med ett stängningssegment. Den läser [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) och jämför det sista segmentets [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) med [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Den returnerar false när det inte finns några icke‑tomma banor. Detta kontrollerar det sista kommandot för varje bana; den inspekterar inte varje delfigur inom en bana. Exemplet skriver ut `True` för en rektangel.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Extrahera och inspektera formelement**

Använd [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) för att inspektera en befintlig form som element som innehåller banpunkter och puntstyper. Varje returnerad [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) exponerar sina [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) och [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/)‑arrayer. Denna representation är användbar för konturanalys eller för att skicka geometri till anpassade ritverktyg.

Exemplet öppnar en presentation, hittar den första geometriska formen direkt på den första bilden och skriver ut dess bansegment. Använd en presentation som innehåller en form med raka och böjda segment för att se båda typerna av utdata. Den söker inte i grupper.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Behåll segmenttypen, exklusive flaggor.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Arrayerna motsvarar varandra via index: `points[i]` är en punkt och `types[i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` ritar en linje från föregående punkt till den aktuella. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följt av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar om slutpunkten stänger.

Punkt­typer innehåller också flaggor. Maskera med `0x07` för att identifiera segmenttypen och testa `0x80` separat för att upptäcka en sluten delbana. Exempelvis betyder `129` (`0x81`) en linjeslutpunkt som stänger en delbana, och `131` (`0x83`) betyder en Bézier‑slutpunkt som stänger en. Att bara jämföra det råa värdet med `1` eller `3` skulle missa dessa fall. Andra flaggor, såsom streck (`0x10`) och markör (`0x20`), förändrar inte grundsegmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), med X ökar åt höger och Y ökar nedåt. För en icke‑grupperad form innehåller de extraherade koordinaterna redan dess [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)‑ och [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)‑position och speglar dess aktuella bredd och höjd. Till exempel har en o‑roterad rektangel på `(100, 200)` med storlek `120 × 80` konturboundar `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativa till dess o‑roterade ram.

De extraherade punkterna tillämpas inte på formens [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) eller horisontella och vertikala speglingar. För att återge den visade konturen, applicera dessa transformationer runt formens centrum. För grupperade former, ta också hänsyn till gruppens koordinatmappning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade bildpunkterna eller att du ska applicera en förflyttning eller skala två gånger om den redan återges i barnets ram.

**Inspektion kontra redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys eller ritkod behöver punkt‑/typ‑arrayer. Använd [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) när du behöver geometrikommando i formens lokala koordinatsystem eller vill redigera dess geometri. Applicera redigerade banor via [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) eller [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **Vanliga frågor**

**Vad händer med fyllning och kontur efter att geometri har ersatts?**

Stilen förblir knuten till formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)-egenskap; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det erforderliga [bildspel](/slides/sv/python-net/convert-powerpoint-to-png/)‑området eller själva [formen](/slides/sv/python-net/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.