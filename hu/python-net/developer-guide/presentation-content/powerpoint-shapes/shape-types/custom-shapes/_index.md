---
title: Alakzatok testreszabása prezentációkban Python használatával
linktitle: Egyedi alakzat
type: docs
weight: 20
url: /hu/python-net/custom-shape/
keywords: 
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometriája
- geometriai útvonal
- útvonal pontok
- pontok szerkesztése
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python .NET segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Bevezetés**

Gondolj egy négyzetre. PowerPointban a **Edit Points** használatával a következőket teheted:

* a négyzet sarkát befelé vagy kifelé mozdíthatod,
* a sarok vagy pont görbületét állíthatod,
* új pontokat adhatsz a négyzethez,
* kezelheted a pontjait.

Ezeket a műveleteket bármely alakzatra alkalmazhatod. A **Edit Points** segítségével módosíthatsz egy alakzatot, vagy új alakzatot hozhatsz létre egy meglévőből.

## **Alakzat szerkesztési tippek**

!["Edit Points" parancs](custom_shape_0.png)

Mielőtt elkezdenéd szerkeszteni a PowerPoint alakzatokat a **Edit Points** használatával, vedd figyelembe a következő megjegyzéseket az alakzatokról:

* Egy alakzat (vagy annak útvonala) lehet **zárt** vagy **nyitott**.
* Egy zárt alakzatnak nincs kezdő vagy befejező pontja; egy nyitott alakzatnak van kezdete és vége.
* Minden alakzat legalább két rögzítési ponttal rendelkezik, amelyeket vonalláncok kötnek össze.
* Egy szegmens lehet egyenes vagy íves; a rögzítési pontok határozzák meg a szegmens jellegét.
* A rögzítési pontok lehetnek **sarok**, **simított**, vagy **egyenes**:
  * A **sarok** pont az, ahol két egyenes szegmens szögnél találkozik.
  * A **smooth** (simított) pont két egymással kollineáris fogantyúval rendelkezik, és a szomszédos szegmensek sima görbét alkotnak. Ebben az esetben a két fogantyú ugyanolyan távolságra van a rögzítési ponttól.
  * A **straight** (egyenes) pont szintén két kollineáris fogantyúval rendelkezik, és a szomszédos szegmensek sima görbét alkotnak. Ebben az esetben a fogantyúknek nem kell ugyanakkora távolságra lenniük a rögzítési ponttól.
* A rögzítési pontok mozgatásával vagy szerkesztésével (ezáltal a szegmens szögeit változtatva) megváltoztathatod az alakzat megjelenését.

A PowerPoint alakzatok szerkesztéséhez az Aspose.Slides a [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) osztályt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) példány egy [GeometryShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/) objektum geometriai útvonalát reprezentálja.
* A [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) egy [GeometryShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/) példányból való lekéréséhez használd a [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/get_geometry_paths/) metódust.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) beállításához használd a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/set_geometry_path/) metódust *egyszerű alakzatok* esetén, és a [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/set_geometry_paths/) metódust *összetett alakzatok* esetén.
* Szegmensek hozzáadásához használd a [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) metódusait.
* A [GeometryPath.stroke](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/stroke/) és a [GeometryPath.fill_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/fill_mode/) tulajdonságokkal szabályozhatod egy geometriai útvonal megjelenését.
* A [GeometryPath.path_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/path_data/) tulajdonsággal kaphatod meg egy alakzat geometriai útvonalát, útvonal szegmensek tömbjeként.

## **Egyszerű szerkesztési műveletek**

Az alábbi módszerek egyszerű szerkesztési műveletekhez használhatók.

**Vonal hozzáadása** a útvonal végéhez:
```py
line_to(point)
line_to(x, y)
```

**Vonal hozzáadása** az útvonal egy meghatározott pozíciójába:
```py    
line_to(point, index)
line_to(x, y, index)
```

**Köbös Bézier-görbe hozzáadása** a útvonal végéhez:
```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Köbös Bézier-görbe hozzáadása** az útvonal egy meghatározott pozíciójába:
```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Kvadratikus Bézier-görbe hozzáadása** a útvonal végéhez:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Kvadratikus Bézier-görbe hozzáadása** az útvonal egy meghatározott pozíciójába:
```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Ív hozzáfűzése** egy útvonalhoz:
```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Az aktuális alakzat lezárása** egy útvonalban:
```py
close_figure()
```

**A következő pont pozíciójának beállítása**:
```py
move_to(point)
move_to(x, y)
```

**Az útvonal szegmensének eltávolítása** egy megadott indexnél:
```py
remove_at(index)
```

## **Egyedi pontok hozzáadása alakzatokhoz**

Ebben a részben megtanulod, hogyan definiálj egy szabadkézi alakzatot saját pontsorozatod hozzáadásával. A pontok és a szegmens típusok (egyenes vagy íves) megadásával, valamint opcionálisan az útvonal lezárásával pontos egyedi grafikákat – sokszögeket, ikonokat, felhívásokat vagy logókat – rajzolhatsz közvetlenül a diáidra.

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/) példányt, és állítsd be a [ShapeType.RECTANGLE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapetype/) típusát.
2. Szerezd meg a [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) példányt az alakzatról.
3. Illessz be egy új pontot a két felső pont közé az útvonalon.
4. Illessz be egy új pontot a két alsó pont közé az útvonalon.
5. Alkalmazd a frissített útvonalat az alakzatra.

Az alábbi Python kód bemutatja, hogyan lehet egyedi pontokat hozzáadni egy alakzathoz:
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

![Egyedi pontok](custom_shape_1.png)

## **Pontok eltávolítása alakzatokból**

Néha egy egyedi alakzat felesleges pontokat tartalmaz, amelyek bonyolítják a geometriát vagy befolyásolják a megjelenítését. Ez a szakasz bemutatja, hogyan távolíthatsz el konkrét pontokat egy alakzat útvonaláról, hogy egyszerűsítsd a körvonalat, és tisztább, pontosabb eredményt érj el.

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/) példányt, és állítsd be a [ShapeType.HEART](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapetype/) típust.
2. Szerezd meg a [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) példányt az alakzatról.
3. Távolíts el egy szegmenst az útvonalról.
4. Alkalmazd a frissített útvonalat az alakzatra.

Az alábbi Python kód bemutatja, hogyan lehet pontokat eltávolítani egy alakzatból:
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

![Eltávolított pontok](custom_shape_2.png)

## **Egyedi alakzatok létrehozása**

Alakíts egyedi vektor alakzatokat egy [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) meghatározásával, és sorokból, ívekből, valamint Bézier-görbékből állítva össze. Ez a szakasz bemutatja, hogyan építs egy egyedi geometriát a semmiből, és hogyan add hozzá az eredményül kapott alakzatot a diádhoz.

1. Számold ki az alakzat pontjait.
2. Hozz létre egy [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) példányt.
3. Töltsd fel az útvonalat a pontokkal.
4. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/) példányt.
5. Alkalmazd az útvonalat az alakzatra.

Az alábbi Python kód bemutatja, hogyan hozhatsz létre egy egyedi alakzatot:
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

![Egyedi alakzat](custom_shape_3.png)

## **Összetett egyedi alakzatok létrehozása**

Összetett egyedi alakzat létrehozásával több geometriai útvonalat egyetlen, újrahasznosítható alakzattá egyesíthetsz a dián. Definiáld és egyesítsd ezeket az útvonalakat, hogy komplex vizuálokat építs, amelyek túllépnek a standard alakzatkészleten.

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/) példányt.
2. Hozd létre az első [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) példányt.
3. Hozd létre a második [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) példányt.
4. Alkalmazd mindkét útvonalat az alakzatra.

Az alábbi Python kód bemutatja, hogyan hozhatsz létre egy összetett egyedi alakzatot:
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

![Összetett alakzat](custom_shape_4.png)

## **Egyedi alakzatok görbe sarkokkal**

Ez a szakasz bemutatja, hogyan rajzolj egy egyedi alakzatot simán ívelt sarkokkal geometriai útvonal segítségével. Egyenes szegmenseket és köríveket kombinálva alkotod meg a körvonalat, majd hozzáadod a kész alakzatot a diádhoz.

Az alábbi Python kód bemutatja, hogyan hozhatsz létre egy egyedi alakzatot ívelt sarkokkal:
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

![Ívelt sarkok](custom_shape_6.png)

## **Ellenőrizd, hogy egy alakzat geometriája zárt-e**

Egy zárt alakzat olyan, amelynek minden oldala összekapcsolódik, egyetlen szegélyt alkotva részak nélkül. Egy ilyen alakzat lehet egyszerű geometriai forma vagy összetett egyedi körvonal. Az alábbi kódrészlet bemutatja, hogyan ellenőrizheted, hogy egy alakzat geometriája zárt-e:
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

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan forgatom helyesen egy egyedi alakzatot a geometriájával együtt?**

Használd az alakzat [rotation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/rotation/) tulajdonságát; a geometria az alakzattal együtt forog, mivel az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatok egy egyedi alakzatot képpé a végeredmény "lezárásához"?**

Igen. Exportáld a szükséges [slide](/slides/hu/python-net/convert-powerpoint-to-png/) területet vagy közvetlenül a [shape](/slides/hu/python-net/create-shape-thumbnails/) objektumot raszteres formátumba; ez egyszerűsíti a további munkát nehéz geometriákkal.