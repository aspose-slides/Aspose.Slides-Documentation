---
title: Anpassa presentationsformer i Python
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/python-net/custom-shape/
keywords:
- anpassad form
- lägga till form
- skapa form
- ändra form
- formgeometri
- geometri bana
- banapunkter
- redigera punkter
- lägga till punkt
- ta bort punkt
- redigeringsoperation
- rundat hörn
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för Python via .NET: geometribanor, rundade hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formens geometri med hjälp av redigeringspunkter och geometriska banor. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) för att ändra befintliga former, utföra grundläggande redigeringsoperationer, lägga till eller ta bort punkter och applicera uppdaterad geometri tillbaka på en form.

Den demonstrerar också hur du skapar anpassade och sammansatta former, bygger former med rundade hörn, avgör om en formgeometri är sluten och extraherar formelement för konturanalys.

## **Ändra en form med redigeringspunkter**

I PowerPoint kan du använda **Edit Points** för att ändra en fyrkant:

* Flytta ett hörn inåt eller utåt.
* Justera krökningen vid en punkt.
* Lägg till nya punkter.

Att redigera punkter låter dig ändra en forms kontur eller använda en befintlig form som grund för en ny.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

När du redigerar PowerPoint‑former, håll dessa begrepp i åtanke:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* En forms bana består av ankarpunkter som är sammankopplade med segment.
* Ett segment kan vara rakt eller kurvat. Ankspunkter och kontrollhandtag bestämmer dess form.
* Ankspunkter kan vara hörnpunkter, raka punkter eller jämna punkter:
  * Vid en hörnpunkt kan intilliggande segment mötas i en vinkel.
  * Vid en jämn punkt är de två kontrollhandtagen i linje och lika långt från ankspunkten.
  * Vid en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankspunkten.
* Att flytta ankspunkter eller justera deras handtag förändrar formens kontur.

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑instans representerar en geometribana för objektet [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) från [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)‑instansen kan du använda metoden [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* För att ange [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) för former med en enda bana och [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) för former med flera banor.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Genom att använda egenskaperna [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) och [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) kan du ställa in utseendet för en geometribana.
* Genom att använda egenskapen [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) kan du hämta geometribanen för en [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) som en array av bansegment.

## **Enkla redigeringsoperationer**

Använd följande metoder för att redigera en geometribana. Överlagringar som tar ett index infogar ett segment på den nollbaserade positionen i banans segmentarray.

| Operation | Metod |
| --- | --- |
| Lägg till eller infoga en rak linje. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Lägg till eller infoga en kubisk Bézier-kurva med två kontrollpunkter och en slutpunkt. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Lägg till eller infoga en kvadratisk Bézier-kurva med en kontrollpunkt och en slutpunkt. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Lägg till en elliptisk båg med angivna dimensioner och vinklar i grader. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Stäng den aktuella figuren genom att ansluta dess slutpunkt till startpunkten. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Sätt startpunkten för en figur. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Ta bort ett segment på ett nollbaserat index. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Lägg till anpassade punkter till en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) och tillämpar den redigerade banan med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Koordinaterna är lokala för formen: båda nya punkterna ligger i dess centrum, 100 punkter från vänster och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på den övre och nedre kanten, vilket drar dessa kanter inåt.

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

Detta exempel ändrar en hjärtformad kontur genom att ta bort segmentet på nollbaserat index 2 med [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Genom att applicera den modifierade banan med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) uppdateras formens kontur.

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

Detta exempel bygger en femspetsig stjärna med [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Växlande yttre och inre radier på 100 respektive 50 punkter definierar spetsarna och indragningarna; ett steg på 72 grader placerar de fem spetsarna jämnt. Banen stängs med [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) och appliceras på en rektangulär form med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), vilket ersätter dess kontur.

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

Detta exempel definierar två slutna [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑objekt för den övre och nedre tredjedelen av en form. Genom att applicera båda banorna med [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) skapas en enda sammansatt form med ett glapp över dess mitttredjedel.

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

## **Skapa en anpassad form med rundade hörn**

Detta exempel kombinerar raka segment med [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) för att skapa en form med inåtriktade rundade hörn. Varje hörnstorlek ställer in bågens bredd och höjd i punkter, och ett -90‑gradssvep ritar en motsols kvartselips. Den färdiga banan appliceras med [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), och presentationen sparas i PPTX‑format.

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

Följande hjälpfunktion kontrollerar om varje icke‑tom geometribana avslutas med ett stängningssegment. Den läser [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) och jämför det sista segmentets [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) med [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Den returnerar false när det inte finns några icke‑tomma banor. Den kontrollerar det sista kommandet för varje bana; den granskar inte varje delfigur inom en bana. Exemplet skriver ut `True` för en rektangel.

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

## **Inspektera geometribankommandon**

Ladda ner [contour.pptx](contour.pptx) och placera den i din arbetskatalog. Den första formen på den första sliden har en rak övre kant, en kubisk Bézier-kurva och en rak avslutande kant. Använd [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) för att läsa dess banor. För varje bana listar [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) segmenten i ritningsordning. Varje segments [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) bestämmer hur dess [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) ska tolkas.

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Formen ligger på (200, 100) punkter på sliden. De rapporterade koordinaterna är lokala för formen. Dess övre‑vänstra hörn är (0, 0), x ökar åt höger och y ökar nedåt. Det stängande segmentet återvänder till startpunkten utan extra koordinater.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint form med en rak överkant, en kurvig kant från övre högra till nedre vänstra och en rak vänsterkant](contour.png)

## **Extrahera och inspektera formelement**

Använd [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) för att inspektera en befintlig form som element som innehåller banpunkter och punkttyper. Varje returnerad [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) exponerar sina [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/)‑ och [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/)‑arrayer. Denna representation är användbar för konturanalys eller för att föra geometrin till anpassade ritverktyg.

Exemplet öppnar en presentation, hittar den första geometriformen direkt på den första sliden och skriver ut dess bansegment. Använd en presentation som innehåller en form med raka och kurviga segment för att se båda typerna av utdata. Det söker inte inuti grupper.

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
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

Arrayerna motsvarar varandra enligt index: `points[i]` är en punkt och `types[i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` ritar en linje från föregående punkt till den aktuella punkten. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följda av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar slutpunkten för slutenhet.

Punkttyper innehåller också flaggor. Maskera med `0x07` för att identifiera segmenttypen och testa `0x80` separat för att upptäcka ett slutet delspår. Till exempel betyder `129` (`0x81`) en linjeslutpunkt som stänger ett delspår, och `131` (`0x83`) en Bézier‑slutpunkt som stänger ett. Att bara jämföra råvärdet med `1` eller `3` skulle missa dessa fall. Andra flaggor, såsom streck (`0x10`) och markör (`0x20`), ändrar inte bassegmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), med X som ökar åt höger och Y som ökar nedåt. För en icke‑grupperad form innehåller de extraherade koordinaterna redan dess [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)‑ och [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)‑position och återspeglar dess aktuella bredd och höjd. Till exempel har en icke‑roterad rektangel på `(100, 200)` med storleken `120 × 80` konturboundar `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativt till dess icke‑roterade ram.

De extraherade punkterna tillämpar inte formens [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) eller horisontella och vertikala speglingar. För att reproducera den visade konturen, applicera dessa transformationer kring formens centrum. För grupperade former, ta även hänsyn till gruppens koordinatmappning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade slide‑koordinaterna eller att en förflyttning eller skalning ska tillämpas dubbelt om den redan återspeglas i barnets ram.

**Inspektion kontra redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys‑ eller ritkod behöver punkt‑/typ‑arrayer. Använd [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) när du behöver geometrikommandon i formens lokala koordinatsystem eller vill redigera dess geometri. Applicera redigerade banor via [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) eller [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Vad händer med fyllning och kontur när geometrin ersätts?**

Stilen förblir på formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag korrekt en anpassad form tillsammans med dess geometri?**

Använd formens [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)‑egenskap; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det erforderliga [slide](/slides/sv/python-net/convert-powerpoint-to-png/)-området eller själva [shape](/slides/sv/python-net/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.