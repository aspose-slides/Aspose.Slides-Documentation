---
title: Csatlakozók kezelése prezentációkban Python segítségével
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/python-net/connector/
keywords:
- csatlakozó
- csatlakozó típusa
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Lehetővé teszi a Python alkalmazások számára, hogy rajzoljanak, összekapcsoljanak és automatikusan útvonalazzanak vonalakat PowerPoint és OpenDocument diákon—teljes irányítást biztosítva az egyenes, könyök és ívelt csatlakozók felett."
---
## **Bevezetés**

A PowerPoint csatlakozó egy speciális vonal, amely két alakzatot köt össze, és a dián az alakzatok mozgatása vagy áthelyezése esetén is rögzítve marad. A csatlakozók a **kapcsolódási pontokhoz** (zöld pontok) rögzülnek az alakzatokon. A kapcsolódási pontok akkor jelennek meg, amikor a mutató közelíti őket. A **állítási fogantyúk** (sárga pontok), bizonyos csatlakozók esetén elérhetők, lehetővé teszik a csatlakozó helyének és alakjának módosítását.

## **Csatlakozó típusok**

A PowerPointban három típusú csatlakozót használhat: egyenes, könyök (szögelt) és ívelt.

Az Aspose.Slides a következő csatlakozó típusokat támogatja:

| Csatlakozó típusa               | Kép                                                        | Állítási pontok száma |
| ------------------------------- | ---------------------------------------------------------- | --------------------- |
| `ShapeType.LINE`                | ![Vonal csatlakozó](shapetype-lineconnector.png)          | 0                     |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Egyenes csatlakozó 1](shapetype-straightconnector1.png) | 0                     |
| `ShapeType.BENT_CONNECTOR2`     | ![Ívelt csatlakozó 2](shapetype-bent-connector2.png)       | 0                     |
| `ShapeType.BENT_CONNECTOR3`     | ![Ívelt csatlakozó 3](shapetype-bentconnector3.png)        | 1                     |
| `ShapeType.BENT_CONNECTOR4`     | ![Ívelt csatlakozó 4](shapetype-bentconnector4.png)        | 2                     |
| `ShapeType.BENT_CONNECTOR5`     | ![Ívelt csatlakozó 5](shapetype-bentconnector5.png)        | 3                     |
| `ShapeType.CURVED_CONNECTOR2`   | ![Ívelt csatlakozó 2](shapetype-curvedconnector2.png)      | 0                     |
| `ShapeType.CURVED_CONNECTOR3`   | ![Ívelt csatlakozó 3](shapetype-curvedconnector3.png)      | 1                     |
| `ShapeType.CURVED_CONNECTOR4`   | ![Ívelt csatlakozó 4](shapetype-curvedconnector4.png)      | 2                     |
| `ShapeType.CURVED_CONNECTOR5`   | ![Ívelt csatlakozó 5](shapetype.curvedconnector5.png)      | 3                     |

## **Alakzatok összekapcsolása csatlakozókkal**

Ez a szakasz bemutatja, hogyan lehet alakzatokat összekapcsolni csatlakozókkal az Aspose.Slides-ban. Hozzáad egy csatlakozót a diára, a kezdő és végpontját a cél alakzatokhoz rögzítve. A kapcsolódási pontok használata biztosítja, hogy a csatlakozó a "ragasztott" állapotban maradjon az alakzatokhoz, még ha azok mozognak vagy méreteződnek is.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze be a dia hivatkozását az indexe alapján.
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) objektumot a diához a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) objektum által nyújtott `add_auto_shape` metódus segítségével.
1. Adjon hozzá egy csatlakozót a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) objektum által nyújtott `add_connector` metódus használatával, és adja meg a csatlakozó típusát.
1. Kapcsolja össze az alakzatokat a csatlakozóval.
1. Hívja meg a `reroute` metódust a legrövidebb kapcsolati útvonal alkalmazásához.
1. Mentse a prezentációt.

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt egy PPTX fájl létrehozásához.
with slides.Presentation() as presentation:

    # Eléri az alakzatok gyűjteményét az első dián.
    shapes = presentation.slides[0].shapes

    # Hozzáad egy ellipszis AutoShape-et.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Hozzáad egy téglalap AutoShape-et.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Hozzáad egy csatlakozót a diára.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Összekapcsolja az alakzatokat a csatlakozóval.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Meghívja a reroute metódust a legrövidebb út beállításához.
    connector.reroute()

    # Mentse a prezentációt.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
A `connector.reroute` metódus újratervezi a csatlakozót, és kényszeríti, hogy a alakzatok között a lehető legrövidebb utat vegye. Ennek érdekében a metódus módosíthatja a `start_shape_connection_site_index` és `end_shape_connection_site_index` értékeket.
{{% /alert %}}

## **Kapcsolódási pontok megadása**

Ez a szakasz bemutatja, hogyan lehet egy csatlakozót egy alakzat adott kapcsolódási pontjához rögzíteni az Aspose.Slides-ban. A pontos kapcsolódási helyek megcélzása lehetővé teszi a csatlakozó útvonalának és elrendezésének vezérlését, így tiszta és előre látható diagramokat hozhat létre a prezentációiban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze be a dia hivatkozását az indexe alapján.
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) objektumot a diához a `add_auto_shape` metódus segítségével a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) objektumtól.
1. Adjon hozzá egy csatlakozót a `add_connector` metódusra a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) objektumon, és adja meg a csatlakozó típusát.
1. Kapcsolja össze az alakzatokat a csatlakozóval.
1. Állítsa be a kívánt kapcsolódási pontokat az alakzatokon.
1. Mentse a prezentációt.

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt egy PPTX fájl létrehozásához.
with slides.Presentation() as presentation:

    # Az első dia alakzatgyűjteményéhez fér hozzá.
    shapes = presentation.slides[0].shapes

    # Hozzáad egy ellipszis AutoShape-et.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Hozzáad egy téglalap AutoShape-et.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Hozzáad egy csatlakozót a dia alakzatgyűjteményéhez.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Összekapcsolja az alakzatokat a csatlakozóval.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Beállítja a preferált kapcsolódási hely indexét az ellipszisnél.
    site_index = 6

    # Ellenőrzi, hogy a preferált index a rendelkezésre álló helyek számán belül van-e.
    if  ellipse.connection_site_count > site_index:
        # Hozzáadja a preferált kapcsolódási helyet az ellipszis AutoShape-hez.
        connector.start_shape_connection_site_index = site_index

    # Mentse a prezentációt.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **A csatlakozó pontjainak módosítása**

A csatlakozókat módosíthatja a beállítási pontjaik használatával. Csak azok a csatlakozók módosíthatók ezzel, amelyek beállítási pontokat biztosítanak. A részletekért, hogy mely csatlakozók támogatják a módosításokat, lásd a [Connector Types](/slides/hu/python-net/connector/#connector-types) alatti táblázatot.

### **Egyszerű eset**

Tekintsen egy olyan esetre, ahol egy csatlakozó két alakzat (A és B) között egy harmadik alakzatot (C) metsz.

![Csatlakozó akadálya](connector-obstruction.png)

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

A harmadik alakzat elkerüléséhez módosítsa a csatlakozót úgy, hogy a függőleges szakaszát balra mozdítja:

![Javított csatlakozó akadálya](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Összetett esetek**

Haladóbb módosításokhoz vegye figyelembe a következőket:

- A csatlakozó állítható pontját egy képlet szabályozza, amely meghatározza a pozícióját. Ennek a pontnak a módosítása megváltoztathatja a csatlakozó teljes alakját.
- A csatlakozó állítási pontjai szigorúan rendezett tömbben tárolódnak, a csatlakozó kezdettől a végéig számozva.
- Az állítási pont értékek a csatlakozó alakzat szélességének/magasságának százalékát jelentik.
  - Az alakzatot a csatlakozó kezdő és végpontjai határolják, és 1000-vel skálázódik.
  - Az első, második és harmadik állítási pont a következőt jelenti: szélesség százaléka, magasság százaléka, és újra a szélesség százaléka.
- Az állítási pontok koordinátáinak kiszámításakor vegye figyelembe a csatlakozó forgatását és tükröződését. **Megjegyzés:** Az [Connector Types](/slides/hu/python-net/connector/#connector-types) alatt felsorolt összes csatlakozó esetén a forgatási szög 0.

#### **Eset 1**

Tekintsen egy olyan esetre, ahol két szövegkeret objektumot egy csatlakozó kapcsol össze:

![Kapcsolt alakzatok](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt egy PPTX fájl létrehozásához.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Lekéri az első diát.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Hozzáad egy csatlakozót.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Beállítja a csatlakozó irányát.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Beállítja a csatlakozó színét.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Beállítja a csatlakozó vonalvastagságát.
    connector.line_format.width = 3

    # Összekapcsolja az alakzatokat a csatlakozóval.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Lekéri a csatlakozó állítási pontjait.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Módosítás**

Módosítsa a csatlakozó állítási pontjainak értékeit úgy, hogy a szélesség százalékát 20%-kal, a magasság százalékát pedig 200%-kal növeli:

```python
    # Módosítsa az állítási pontok értékeit.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Az eredmény:

![Csatlakozó módosítás 1](connector-adjusted-1.png)

Egy olyan modell definiálásához, amely lehetővé teszi a csatlakozó szegmensek koordinátáinak és alakjának meghatározását, hozzon létre egy alakzatot, amely a `connector.adjustments[0]` függőleges komponensének felel meg:

```python
    # Rajzolja meg a csatlakozó függőleges komponensét.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Az eredmény:

![Csatlakozó módosítás 2](connector-adjusted-2.png)

#### **Eset 2**

Az **Eset 1**-ben egyszerű csatlakozó módosítást mutattunk be alapelvek használatával. Általános esetekben figyelembe kell venni a csatlakozó forgatásét és a megjelenítési beállításait (amelyeket a `connector.rotation`, `connector.frame.flip_h` és `connector.frame.flip_v` szabályoz). Íme, hogyan működik a folyamat.

Először adjon hozzá egy új szövegkeret objektumot (**To 1**) a diához (kapcsolódás céljából), és hozzon létre egy új zöld csatlakozót, amely összeköti a meglévő objektumokkal.

```python
    # Hozzon létre egy új célobjektumot.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Hozzon létre egy új csatlakozót.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Kapcsolja össze az objektumokat az újonnan létrehozott csatlakozóval.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Lekéri a csatlakozó állítási pontjait.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Módosítsa az állítási pontok értékeit.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Az eredmény:

![Csatlakozó módosítás 3](connector-adjusted-3.png)

Másodszor hozzon létre egy alakzatot, amely a csatlakozó **vízszintes** szakaszának felel meg, amely áthalad az új csatlakozó állítási pontján, a `connector.adjustments[0]`-n. Használja a `connector.rotation`, `connector.frame.flip_h`, és `connector.frame.flip_v` értékeket, és alkalmazza a szabványos koordinátakonverziós képletet a meghatározott `x0` pont körüli forgatáshoz:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

A mi esetünkben az objektum forgatási szöge 90 fok, és a csatlakozó függőlegesen jelenik meg, ezért a megfelelő kód a következő:

```python
    # Mentse el a csatlakozó koordinátáit.
    x = connector.x
    y = connector.y
    
    # Javítsa a csatlakozó koordinátáit, ha meg van fordítva.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Használja az állítási pont értékét koordinátaként.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Konvertálja a koordinátákat, mert sin(90°) = 1 és cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Határozza meg a vízszintes szakasz szélességét a második állítási pont értéke alapján.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Az eredmény:

![Csatlakozó módosítás 4](connector-adjusted-4.png)

Bemutattuk az egyszerű módosítások és a komplexebb állítási pontok (amelyek figyelembe veszik a forgást) számításait. Ezzel a tudással saját modell kidolgozhat— vagy kódot írhat— egy `GraphicsPath` objektum előállításához vagy akár egy csatlakozó állítási pontjainak értékének beállításához meghatározott diakoordináták alapján.

## **A csatlakozó vonalak szögeinek meghatározása**

Használja az alábbi példát a csatlakozó vonalak szögének meghatározásához egy dián az Aspose.Slides segítségével. Megtanulja, hogyan olvassa ki egy csatlakozó végpontjait, és számolja ki annak tájolását, hogy pontosan illeszthesse a nyilakat, címkéket és egyéb alakzatokat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze be a dia hivatkozását az index alapján.
1. Hozzáfér a csatlakozó vonal alakzathoz.
1. Használja a vonal szélességét és magasságát, valamint az alakzat keretének szélességét és magasságát a szög kiszámításához.

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

## **GYIK**

**Hogyan deríthetem ki, hogy egy csatlakozó "ragasztva" tud-e maradni egy adott alakzathoz?**

Ellenőrizze, hogy az alakzat [connection sites](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/connection_site_count/) elérhető-e. Ha nincs vagy a szám nulla, a ragasztás nem lehetséges; ebben az esetben használjon szabad végpontokat, és helyezze el őket manuálisan. Célszerű a helyek számát ellenőrizni a csatlakoztatás előtt.

**Mi történik egy csatlakozóval, ha törlök egy kapcsolódó alakzatot?**

A végpontjai leválasztódnak; a csatlakozó a dián egy szokásos vonalként marad szabad kezdő/end pontokkal. Törölheti vagy újrakötheti a kapcsolódásokat, és ha szükséges, [reroute](https://reference.aspose.com/slides/hu/python-net/aspose.slides/connector/reroute/)‑t hívhat.

**Megmaradnak-e a csatlakozó kötései, ha egy diát másik prezentációba másolok?**

Általában igen, amennyiben a cél alakzatok is másolásra kerülnek. Ha a diát egy másik fájlba illeszti be a kapcsolódó alakzatok nélkül, a végpontok szabadokká válnak, és újra kell őket csatlakoztatni.