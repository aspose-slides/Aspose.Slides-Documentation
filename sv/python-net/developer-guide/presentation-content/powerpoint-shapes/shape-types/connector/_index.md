---
title: "Hantera kopplingar i presentationer med Python"
linktitle: "Koppling"
type: docs
weight: 10
url: /sv/python-net/connector/
keywords:
- "koppling"
- "kopplingstyp"
- "kopplingspunkt"
- "kopplingslinje"
- "kopplingsvinkel"
- "koppla former"
- "PowerPoint"
- "presentation"
- "Python"
- "Aspose.Slides"
description: "Ge Python‑appar möjlighet att rita, koppla och automatiskt routa linjer i PowerPoint‑ och OpenDocument‑bilder—få full kontroll över raka, armbågs‑ och kurviga kopplingar."
---
## **Introduktion**

En PowerPoint‑koppling är en specialiserad linje som länkar två former och förblir fäst när formerna flyttas eller omplaceras på en bild. Kopplingar fäster vid **anslutningspunkter** (gröna punkter) på former. Anslutningspunkter visas när pekaren närmar sig dem. **Justeringhandtag** (gula punkter), som finns på vissa kopplingar, låter dig ändra en kopplings position och form.

## **Kopplingstyper**

I PowerPoint kan du använda tre typer av kopplingar: rak, armbåge (vinklad) och böjd.

Aspose.Slides stöder följande kopplingstyper:

| Kopplingstyp                    | Bild                                                       | Antal justeringspunkter |
| ------------------------------- | ---------------------------------------------------------- | ----------------------- |
| `ShapeType.LINE`                | ![Linjekoppling](shapetype-lineconnector.png)             | 0                       |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Raka koppling 1](shapetype-straightconnector1.png)       | 0                       |
| `ShapeType.BENT_CONNECTOR2`     | ![Böjd koppling 2](shapetype-bent-connector2.png)          | 0                       |
| `ShapeType.BENT_CONNECTOR3`     | ![Böjd koppling 3](shapetype-bentconnector3.png)           | 1                       |
| `ShapeType.BENT_CONNECTOR4`     | ![Böjd koppling 4](shapetype-bentconnector4.png)           | 2                       |
| `ShapeType.BENT_CONNECTOR5`     | ![Böjd koppling 5](shapetype-bentconnector5.png)           | 3                       |
| `ShapeType.CURVED_CONNECTOR2`   | ![Kurvad koppling 2](shapetype-curvedconnector2.png)       | 0                       |
| `ShapeType.CURVED_CONNECTOR3`   | ![Kurvad koppling 3](shapetype-curvedconnector3.png)       | 1                       |
| `ShapeType.CURVED_CONNECTOR4`   | ![Kurvad koppling 4](shapetype-curvedconnector4.png)       | 2                       |
| `ShapeType.CURVED_CONNECTOR5`   | ![Kurvad koppling 5](shapetype.curvedconnector5.png)       | 3                       |

## **Koppla former med kopplingar**

Detta avsnitt visar hur man länkar former med kopplingar i Aspose.Slides. Du lägger till en koppling på en bild, fäster dess start och slut på målföremål. Genom att använda anslutningsställen säkerställs att kopplingen förblir "fast" på former även när de flyttas eller ändrar storlek.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden enligt dess index.
3. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)-objekt på bilden med hjälp av metoden `add_auto_shape` som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/).
4. Lägg till en koppling med metoden `add_connector` som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) och ange kopplingstypen.
5. Koppla formerna med kopplingen.
6. Anropa metoden `reroute` för att tillämpa den kortaste anslutningsvägen.
7. Spara presentationen.

Följande Python‑kod visar hur man lägger till en böjd koppling mellan två former (en ellips och en rektangel):

```python
import aspose.slides as slides

# Skapa ett Presentation‑objekt för att skapa en PPTX‑fil.
with slides.Presentation() as presentation:

    # Hämta shapes‑samlingen för den första bilden.
    shapes = presentation.slides[0].shapes

    # Lägg till en ellips‑AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Lägg till en rektangel‑AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Lägg till en koppling på bilden.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Koppla formerna med kopplingen.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Anropa reroute för att ange den kortaste vägen.
    connector.reroute()

    # Spara presentationen.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
`connector.reroute`‑metoden omdirigerar en koppling och tvingar den att följa den kortaste möjliga vägen mellan former. För att göra detta kan metoden ändra värdena `start_shape_connection_site_index` och `end_shape_connection_site_index`.
{{% /alert %}}

## **Ange anslutningspunkter**

Detta avsnitt förklarar hur man fäster en koppling vid en specifik anslutningspunkt på en form i Aspose.Slides. Genom att rikta in sig på exakta anslutningsställen kan du styra kopplingsrutten och layouten, vilket ger rena och förutsägbara diagram i dina presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden enligt dess index.
3. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)-objekt på bilden med hjälp av metoden `add_auto_shape` som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/).
4. Lägg till en koppling med metoden `add_connector` på objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) och ange kopplingstypen.
5. Koppla formerna med kopplingen.
6. Ange dina föredragna anslutningspunkter på formerna.
7. Spara presentationen.

Följande Python‑kod visar hur man anger en föredragen anslutningspunkt:

```python
import aspose.slides as slides

# Skapa ett Presentation‑objekt för att skapa en PPTX‑fil.
with slides.Presentation() as presentation:

    # Hämta shapes‑samlingen för den första bilden.
    shapes = presentation.slides[0].shapes

    # Lägg till en ellips‑AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Lägg till en rektangel‑AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Lägg till en koppling till bildens shapes‑samling.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Koppla formerna med kopplingen.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Ange föredraget anslutningsställe‑index på ellipsen.
    site_index = 6

    # Kontrollera att det föredragna indexet ligger inom det tillgängliga antalet anslutningsställen.
    if  ellipse.connection_site_count > site_index:
        # Tilldela det föredragna anslutningsstället på ellips‑AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Spara presentationen.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Justera kopplingspunkter**

Du kan ändra kopplingar med deras justeringspunkter. Endast kopplingar som exponerar justeringspunkter kan redigeras på detta sätt. För detaljer om vilka kopplingar som stödjer justeringar, se tabellen under [Connector Types](/slides/sv/python-net/connector/#connector-types).

### **Enkelt fall**

Tänk på ett fall där en koppling mellan två former (A och B) korsar en tredje form (C):

![Kopplingshindring](connector-obstruction.png)

Kodexempel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

För att undvika den tredje formen, justera kopplingen genom att flytta dess vertikala segment åt vänster:

![Fixad kopplingshindring](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Komplexa fall**

För mer avancerade justeringar, överväg följande:

- En justerbar punkt i en koppling styrs av en formel som bestämmer dess position. Att ändra denna punkt kan förändra kopplingens övergripande form.
- En kopplings justeringspunkter lagras i en strikt ordnad array, numrerade från kopplingens start till dess slut.
- Värdena för justeringspunkterna representerar procent av kopplingsformens bredd/höjd.
  - Formen begränsas av kopplingens start- och slutpunkter och skalas med 1000.
  - Den första, andra och tredje justeringspunkten representerar: procent av bredd, procent av höjd och återigen procent av bredd, respektive.
- När koordinaterna för justeringspunkterna beräknas, ta hänsyn till kopplingens rotation och reflektion. **Obs:** För alla kopplingar som listas under [Connector Types](/slides/sv/python-net/connector/#connector-types) är rotationsvinkeln 0.

#### **Fall 1**

Tänk på ett fall där två textramsobjekt länkas med en koppling:

![Länkade former](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa ett Presentation‑objekt för att skapa en PPTX‑fil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Hämta den första bilden.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Lägg till en koppling.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Ange kopplingens riktning.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Ange kopplingens färg.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Ange kopplingens linjetjocklek.
    connector.line_format.width = 3

    # Koppla formerna med kopplingen.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Hämta kopplingens justeringspunkter.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Justering**

Ändra kopplingens justeringspunktsvärden genom att öka breddprocenten med 20 % respektive höjdprocenten med 200 %:

```python
    # Ändra värdena för justeringspunkterna.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Resultatet:

![Kopplingsjustering 1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen för kopplingens segment, skapa en form som motsvarar den vertikala komponenten av kopplingen vid `connector.adjustments[0]`:

```python
    # Rita den vertikala komponenten av kopplingen.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Resultatet:

![Kopplingsjustering 2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** demonstrerade vi en enkel kopplingsjustering med grundläggande principer. I vanliga scenarier måste du ta hänsyn till kopplingens rotation och dess visningsinställningar (styrda av `connector.rotation`, `connector.frame.flip_h` och `connector.frame.flip_v`). Så här fungerar processen.

Först, lägg till ett nytt textramsobjekt (**Till 1**) på bilden (för anslutning) och skapa en ny grön koppling som länkar det till de befintliga objekten.

```python
    # Skapa ett nytt målobjekt.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Skapa en ny koppling.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Koppla objekten med den nyskapade kopplingen.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Hämta kopplingens justeringspunkter.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Ändra värdena för justeringspunkterna.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Resultatet:

![Kopplingsjustering 3](connector-adjusted-3.png)

Sedan, skapa en form som motsvarar den **horisontella** delen av kopplingen som passerar genom den nya kopplingens justeringspunkt, `connector.adjustments[0]`. Använd värdena från `connector.rotation`, `connector.frame.flip_h` och `connector.frame.flip_v` och applicera den standardformel för koordinatkonvertering vid rotation runt en given punkt `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grader och kopplingen visas vertikalt, så motsvarande kod är:

```python
    # Spara kopplingens koordinater.
    x = connector.x
    y = connector.y
    
    # Korrigera kopplingens koordinater om den är speglad.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Använd justeringspunktens värde som koordinat.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Omvandla koordinaterna eftersom sin(90°) = 1 och cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Bestäm bredden på den horisontella segmentet med hjälp av värdet för den andra justeringspunkten.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Resultatet:

![Kopplingsjustering 4](connector-adjusted-4.png)

Vi demonstrerade beräkningar som involverar enkla justeringar och mer komplexa justeringspunkter (de som tar hänsyn till rotation). Med denna kunskap kan du utveckla din egen modell – eller skriva kod – för att erhålla ett `GraphicsPath`‑objekt eller till och med sätta en kopplings justeringspunktsvärde baserat på specifika bildkoordinater.

## **Hitta kopplingslinjens vinklar**

Använd exemplet nedan för att bestämma vinkeln på kopplingslinjer i en bild med Aspose.Slides. Du lär dig hur du läser en kopplings ändpunkter och beräknar dess orientering så att du exakt kan justera pilar, etiketter och andra former.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Åtkomst till kopplingslinjeformen.
4. Använd linjens bredd och höjd samt formramens bredd och höjd för att beräkna vinkeln.

Följande Python‑kod visar hur man beräknar vinkeln för en kopplingslinjeform:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Hur kan jag avgöra om en koppling kan "fästas" på en specifik form?**

Kontrollera att formen exponerar [anslutningsställen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/connection_site_count/). Om det inte finns några eller antalet är noll, är fästning inte tillgänglig; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är klokt att kontrollera antalet ställen innan du fäster.

**Vad händer med en koppling om jag raderar en av de anslutna formerna?**

Dess ändar kommer att lossna; kopplingen kvarstår på bilden som en vanlig linje med fria start/slut. Du kan antingen ta bort den eller omfördela anslutningarna och, vid behov, [reroute](https://reference.aspose.com/slides/sv/python-net/aspose.slides/connector/reroute/).

**Behålls kopplingsbindningar när en bild kopieras till en annan presentation?**

Generellt ja, förutsatt att de målformer som är kopplade också kopieras. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste återfästa dem.