---
title: Prezentációs alakzatok testreszabása Pythonban
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/python-net/custom-shape/
keywords:
- egyéni alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Python .NET segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentációs alakzatokat az Aspose.Slides-ben a forma geometria szerkesztésével szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan kell használni a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) osztályt meglévő alakzatok módosításához, alapvető útvonal-szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és a frissített geometria visszaalkalmazásához egy alakzatra.

Ez továbbá bemutatja, hogyan hozhatunk létre egyéni és összetett alakzatokat, hogyan építhetünk alakzatokat ívelt sarkokkal, hogyan határozhatjuk meg, hogy egy alakzat geometriája zárt‑e, és hogyan vonhatunk ki alakzat‑elemeket a kontúr elemzéséhez.

## **Alakzat módosítása szerkesztési pontokkal**

PowerPointban a **Szerkesztési pontok** segítségével módosíthat egy négyzetet:

* Egy sarkot felfelé vagy lefelé mozgathat.
* A görbületet egy pontban állíthatja.
* Új pontokat adhat hozzá.

A pontok szerkesztése lehetővé teszi, hogy módosítsa egy alakzat körvonalát, vagy egy meglévő alakzatot alapul véve újat hozzon létre.

## **Alakzat‑szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor tartsa szem előtt a következőket:

* Egy alakzat (vagy az útvonala) lehet zárt vagy nyitott.
* Egy alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlő fogantyúk határozzák a formáját.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * Sarokpontnál a szomszédos szegmensek szöggel találkozhatnak.
  * Sima pontnál a két vezérlő fogantyú egyvonallal illeszkedik és egyenlő távolságra van a horgonyponttól.
  * Egyenes pontnál a két vezérlő fogantyú egyvonallal illeszkedik, de különböző távolságra lehet a horgonyponttól.
* A horgonypontok mozgatása vagy a fogantyúik módosítása megváltoztatja az alakzat körvonalát.

PowerPoint‑alakzatok szerkesztéséhez szerkesztési pontokkal az **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) osztályt biztosítja.

* Egy [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) példány a [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) objektum geometriai útvonalát képviseli.
* A [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) metódus segítségével lekérheti a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑t a [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) példányból.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑jének beállításához ezeket a metódusokat használhatja: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) egyetlen útvonallal rendelkező alakzatokhoz és [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) több útvonallal rendelkező alakzatokhoz.
* Szegmensek hozzáadásához használhatja a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) alatti metódusokat.
* A [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) és a [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) tulajdonságokkal beállíthatja egy geometriai útvonal megjelenését.
* A [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) tulajdonsággal lekérheti egy [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) geometriai útvonalát útvonal‑szegmensek tömbjeként.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkesztheti a geometriai útvonalat. Az indexet elfogadó túlterhelések egy szegmenst szúrnak be a nulla‑alapú pozícióban az útvonal szegmens‑tömbjében.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáfűzése vagy beszúrása. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Két vezérlőponttal és egy végponttal ellátott köb‑Bézier görbe hozzáfűzése vagy beszúrása. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Egy vezérlőponttal és egy végponttal ellátott kvadratikus Bézier görbe hozzáfűzése vagy beszúrása. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Elliptikus ív hozzáfűzése a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Az aktuális alakzat lezárása az végpontjának kezdőponthoz kötésével. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Az alakzat kezdőpontjának beállítása. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Szegmens eltávolítása egy nulla‑alapú indexnél. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot illeszt be egy téglalap alakzatba a [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) használatával, majd a szerkesztett útvonalat a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)‑vel alkalmazza. A koordináták az alakzathoz viszonyítva helyi értékek: mindkét új pont a középpontjában van, 100 pontbalra balról és 50 pontbalra felülről. Az 1‑es és 4‑es szegmens‑indexek a felső és alsó élre helyezik őket, így azok befelé húzzák az élét.

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

## **Pontok eltávolítása egy alakzatról**

Ez a példa egy szív alakú körvonalat módosít azzal, hogy a [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) metódussal eltávolítja a 2‑es nulla‑alapú indexű szegmenst. A módosított útvonal alkalmazása a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)‑vel frissíti az alakzat kontúrját.

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

## **Egyéni alakzat létrehozása**

Ez a példa ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) segítségével. A 100 és 50 pont közötti váltakozó külső‑ és belső‑sugár határozza a csúcsokat és bemetszéseket; a 72‑fokos lépés egyenletesen elosztja az öt csúcsot. Az útvonal a [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/)‑val zárul, majd a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)‑val egy téglalap alakzatra kerül, felülírva annak körvonalát.

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

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) objektumot definiál a forma felső és alsó harmadához. Mindkét útvonal a [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)‑val alkalmazva egyetlen összetett alakzatot hoz létre, amelynek a középső harmadában rés van.

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

## **Egyéni alakzat ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/)‑val, hogy egy belülre ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarok mérete a ív szélességét és magasságát pontban állítja be, a -90‑fokos ív pedig egy óramutató járásával ellentétes negyed‑ellipszist rajzol. A kész útvonalat a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)‑val alkalmazzák, majd a prezentációt PPTX formátumban mentik.

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

## **Megállapítás, hogy egy alakzat geometriája zárt‑e**

Az alábbi segédfüggvény azt ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmensen végződik‑e. A [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) olvasásával összeveti a végső szegmens [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) értékét a [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/)‑val. Ha nincsenek nem üres útvonalak, hamis értéket ad vissza. Ez a függvény az egyes útvonalak végső parancsát vizsgálja; nem elemzi a belső alalakzatokat. A példa a `True` értéket írja ki egy téglalap esetében.

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

## **Geometriai útvonalparancsok ellenőrzése**

Töltse le a [contour.pptx](contour.pptx) fájlt, és helyezze el a munkakönyvtárában. Az első dia első alakzata egy egyenes felső élt, egy köb‑Bézier görbét és egy egyenes záró élt tartalmaz. A [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) segítségével olvassa be az útvonalakat. Minden útvonalhoz a [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) felsorolja a szegmenseket rajzolási sorrendben. Az egyes szegmensek [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) határozza meg, hogyan értelmezze a [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) adatokat.

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

Az alakzat a dia (200, 100) pontjában helyezkedik el. A jelentett koordináták az alakzathoz helyi értékek. A bal‑felső sarok (0, 0), az X jobbra, a Y lefelé növekszik. A záró szegmens további koordináták nélkül visszatér a kiindulási pontra.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Alakzat‑elemek kinyerése és ellenőrzése**

Használja a [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) metódust egy meglévő alakzat elemként történő vizsgálatához, amelyek útvonalpontokat és ponttípusokat tartalmaznak. Minden visszaadott [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) a saját [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) és [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) tömbjeivel rendelkezik. Ez a reprezentáció hasznos a kontúr‑elemzéshez vagy a geometria egyedi rajzeszközöknek való átadásához.

A példa megnyit egy prezentációt, megtalálja az első geometriai alakzatot közvetlenül az első dián, és kiírja annak útvonal‑szegmenseit. Egy olyan prezentációt használjon, amelyben az alakzat egyenes és íves szegmenseket egyaránt tartalmaz, hogy mindkét típusú kimenetet lássa. A csoportos alakzatokon belül nem keres.

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

A tömbök index szerint egyeznek: a `points[i]` egy pont, a `types[i]` pedig annak szerepét írja le. Az `0` típus új alakzatot kezd, az `1` típus egy vonalat rajzol az előző pontból az aktuális pontba. Egy köb‑Bézier szegmens a korábbi végpontból indul, és három egymást követő `3`‑as bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre dolgozza fel, és a végpontot a lezárás szempontjából ellenőrzi.

A ponttípusok flag‑eket is tartalmaznak. Maszkold `0x07`‑tel a szegmens típus azonosításához, és teszteld `0x80`‑at külön a zárt alútvonal felismeréséhez. Például a `129` (`0x81`) egy vonal‑végpont, amely lezárja az alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén lezár. Ha csak a nyers értéket `1`‑gyel vagy `3`‑mal hasonlítja, ezek a esetek kimaradnak. A többi flag, például a szaggatott (`0x10`) és a marker (`0x20`), nem változtatja az alap szegmens típust.

**Koordináták és átalakítások.** A pontok pontban vannak megadva (1/72 hüvelyk), X jobbra, Y lefelé növekszik. Egy nem csoportosított alakzatra a kinyert koordináták már tartalmazzák a [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy (100, 200) bal‑felső sarokkal és 120 × 80 mérettel rendelkező nem forgatott téglalap kontúrja `(100, 200)–(220, 280)`. Ne adja hozzá újra az alakzat pozícióját. Vonja ki az X‑et és Y‑t a nem forgatott kerethez viszonyított koordinátákhoz.

A kinyert pontok nem alkalmazzák az alakzat [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) vagy a vízszintes‑ és függőleges tükrözéseket. A megjelenített kontúr reprodukálásához alkalmazza ezeket az átalakításokat az alakzat középpontjában. Csoportos alakzatok esetén vegye figyelembe a csoport koordinátatérképét és átalakításait; ne tételezze, hogy a kinyert pontok végleges, megjelenített dia‑koordináták, és ne alkalmazzon kétszeres eltolást vagy méretezést, ha az már benne van a gyermek keretben.

**Ellenőrzés vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; módosításuk nem frissíti az eredeti alakzatot. Ezt a megközelítést akkor válassza, ha elemzésnek vagy rajzkódrészletnek pont‑/típus‑tömbökre van szüksége. Használja a [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)‑t, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha szerkeszteni szeretné a geometriát. Szerkesztett útvonalakat alkalmazzon a [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) vagy a [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) metódusokkal.

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus az alakzathoz marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerül.

**Hogyan forgassam helyesen az egyéni alakzatot a geometriával együtt?**

Használja az alakzat [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) tulajdonságát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom-e az egyéni alakzatot egy képpé, hogy „lezárom” az eredményt?**

Igen. Exportálja a kívánt [slide](/slides/hu/python-net/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/python-net/create-shape-thumbnails/)‑t raszteres formátumba; ez egyszerűsíti a komplex geometriákkal való további munkát.