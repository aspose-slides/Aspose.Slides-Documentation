---
title: Prezentáció alakzatok testreszabása Pythonban Java-val
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/python-java/custom-shape/
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
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni a prezentáció alakzatait az Aspose.Slides‑ben a forma geometria szerkesztésével szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan lehet a [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) használatával módosítani meglévő alakzatokat, alapvető útvonal‑szerkesztési műveleteket végrehajtani, pontokat hozzáadni vagy eltávolítani, és az frissített geometriát visszaalkalmazni egy alakzatra.

Emellett bemutatja, hogyan lehet egyéni és összetett alakzatokat létrehozni, ívelt sarkokkal rendelkező alakzatokat építeni, meghatározni, hogy egy alakzat geometriája zárt‑e, ellenőrizni az alakzat elemeit, valamint a Java AWT szövegvázlatokat geometriai útvonalakká konvertálni.

## **Alakzat módosítása szerkesztési pontokkal**

* Egy sarkot befelé vagy kifelé mozgatni.
* A görbületet egy pontnál módosítani.
* Új pontokat hozzáadni.

A pontok szerkesztése lehetővé teszi a forma körvonalának módosítását, vagy egy meglévő alakzat használatát alapként egy újnál.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor tartsa szem előtt a következő fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy ívelt. A horgonypontok és a vezérlőkarok határozzák meg a formáját.
* A horgonypontok létezhetnek sarkopontként, egyenes pontként vagy sima pontként:
  * Sarkopontnál a szomszédos szegmensek szöget zárhatnak be.
  * Sima pontnál a két vezérlőkar egy vonalban helyezkedik el, és egyenlő távolságra van a horgonyponttól.
  * Egyenes pontnál a két vezérlőkar egy vonalban van, de különböző távolságra a horgonyponttól.
* A horgonypontok mozgatása vagy a karjaik módosítása megváltoztatja az alakzat körvonalát.

PowerPoint‑alakzatok szerkesztéséhez szerkesztési pontokkal a **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) osztályt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) példány egy [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) objektum geometriai útvonalát képviseli.
* A [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) lekéréséhez a [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) példányból használhatja a [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) metódust.
* A [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) beállításához egy alakzatra használhatja ezeket a metódusokat: a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) egyetlen útvonallal rendelkező alakzatokhoz, és a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) több útvonallal rendelkező alakzatokhoz.
* Szegmensek hozzáadásához a [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) alatti metódusokat használhatja.
* A [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) és a [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) metódusokkal beállíthatja egy geometriai útvonal megjelenését.
* A [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) metódussal a [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) geometriai útvonalát szegmens tömbként kérheti le.
* További alakzat‑geometria testreszabási lehetőségekhez egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumot olvashat el a [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) segítségével, és az szegmenseket egy [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑on újrajátszhatja.

## **Egyszerű szerkesztési műveletek**

Használja az alábbi metódusokat egy geometriai útvonal szerkesztéséhez. Az indexet elfogadó túlterhelések egy szegmenst szúrnak be a nulla‑alapú pozícióba a szegmens tömbben.

| Művelet | Módszer |
| --- | --- |
| Egyenes vonal hozzáfűzése vagy beszúrása. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Köbös Bézier‑görbe (két vezérlőponttal és egy végponttal) hozzáfűzése vagy beszúrása. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Másodfokú Bézier‑görbe (egy vezérlőponttal és egy végponttal) hozzáfűzése vagy beszúrása. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Elliptikus ív hozzáfűzése a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Az aktuális alakzat lezárása azzal, hogy a végpontot összekapcsolja a kezdőponttal. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Az alakzat kezdőpontjának beállítása. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Egy szegmens eltávolítása a nulla‑alapú indexen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy négyszög alakzatba a [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) használatával, és az editált útvonalat a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza. A koordináták az alakzaton belüliek: mindkét új pont a középpontban van, 100 ponttól balra és 50 ponttól fentről. A 1‑es és 4‑es szegmensindexek a felső és alsó élekre helyezik őket, befelé húzva ezeket az éleket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Pontok eltávolítása egy alakzatról**

Ez a példa a szív alakú körvonalat módosítja a [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) segítségével a nulla‑alapú 2‑es indexen történő szegmens törlésével. A módosított útvonal alkalmazása a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) segítségével frissíti az alakzat kontúrját.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Egyéni alakzat létrehozása**

Ez a példa egy ötcsúcsú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) használatával. A 100‑es és 50‑es pont sugár váltakozása határozza meg a csúcsokat és a benyomulásokat; egy 72‑fokos lépés egyenlően osztja el az öt csúcsot. Az útvonalat a [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) zárja le, majd a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza egy négyszög alakzatra, lecserélve annak körvonalát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) objektumot definiál a forma felső és alsó harmadjához. Mindkét útvonal alkalmazása a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) segítségével egyetlen összetett alakzatot hoz létre, amelynek középső harmadja hézaggal rendelkezik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Egyéni alakzat létrehozása ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) használatával, hogy egy belsőre ívelt sarkokkal rendelkező alakzatot kapjon. Minden sarok mérete az ív szélességét és magasságát határozza meg pontban, a -90‑fokos szög pedig egy óramutatóval ellentétes negyed‑ellipszist rajzol. A kész útvonalat a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza, és a prezentáció PPTX formátumban kerül mentésre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megállapítás, hogy egy alakzat geometriája zárt‑e**

Az alábbi segédprogram ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenssel végződik‑e. A [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) beolvassa, és a végső szegmens [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) értékét a [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/)‑val hasonlítja össze. Ha nincs nem üres útvonal, `False`‑t ad vissza. Ez a végső parancsot ellenőrzi minden útvonalnál; nem vizsgálja meg minden alalakzatot az útvonalon belül. A példa egy négyzet esetén `True`‑t ír ki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Geometriai útvonalparancsok ellenőrzése**

Töltse le a [contour.pptx](contour.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dia első alakzata egy egyenes felső élt, egy köbös Bézier‑görbét és egy egyenes záró élt tartalmaz. Használja a [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) metódust az alakzat útvonalainak beolvasásához, valamint a [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) metódust, hogy az egyes útvonalak szegmenseit rajzolási sorrendben olvassa. Minden szegmensnél a [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) határozza meg a parancsot, és megmutatja, hogyan kell értelmezni a [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) által visszaadott értékeket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

Az alakzat a dia (200, 100) pontjában helyezkedik el. A jelentett koordináták az alakzaton belüli helyi értékek, ahol a (0, 0) a bal‑felső sarok, az x jobbra nő, y pedig lefelé.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Alakzat elemek kinyerése és ellenőrzése**

Használja a [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) metódust, hogy egy meglévő alakzatot elemekként ellenőrizzen, melyek útvonali pontokat és ponttípusokat tartalmaznak. Az egyes visszakapott elemeket castolja a [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) típusra `jpype.JObject`‑kel, hogy a [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) és a [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) metódusokkal kérje le a pont‑ és típus‑tömböket. Ez a reprezentáció hasznos kontúrelemzéshez vagy a geometria egyedi rajzolóeszközöknek való átadásához.

A példa megnyitja az input.pptx‑et, megtalálja az első geometriai alakzatot közvetlenül az első dián, és kiírja annak szegmens‑adatait. Használjon egy prezentációt, amely egy alakzatot tartalmaz egyenes és ívelt szegmensekkel, hogy mindkét kimenetet lássa. Nem keres a csoportokon belül.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
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

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

A tömbök index szerint egyeznek: `points[i]` egy pont, `types[i]` pedig a szerepét írja le. A `0` típus egy alakzatot indít, az `1` típus egy vonalat rajzol az előző pontból az aktuális pontba. Egy köbös Bézier‑szegmens az előző végpontból indul, és három egymást követő `3`‑as bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre fogyasztja, és a végpontot ellenőrzi a lezárás szempontjából.

A ponttípusok flag‑eket is tartalmaznak. Maszkoljon `0x07`‑tel a szegmens típus azonosításához, és külön vizsgálja a `0x80`‑at a zárt alútpálya felismeréséhez. Például a `129` (`0x81`) egy vonal végpont, amely alútpályát zár, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén zár. A Java ezeket aláírt bájtokban tárolja; a maszkolás megőrzi a szándékolt biteket. A nyers érték összehasonlítása csak `1`‑gyel vagy `3`‑mal kihagyja ezeket az eseteket. Más flag‑ek, például a szaggatottság (`0x10`) és a marker (`0x20`), nem változtatják az alap szegmens típust.

**Koordináták és transzformációk.** A pontok pontban vannak mérve (1/72 hüvelyk), az X jobbra, Y pedig lefelé növekszik. Nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) és a [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) által visszaadott pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy fordulatlan téglalap a `(100, 200)`‑nél, `120 × 80` mérettel, a kontúr határa `(100, 200)`–`(220, 280)`. Ne adja hozzá újra az alakzat pozícióját. Vonja ki az X‑et és Y‑t, hogy a forgatás nélküli kerethez viszonyított koordinátákat kapja.

A kinyert pontok nem veszik figyelembe az alakzat [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) által visszaadott forgását, vagy a vízszintes illetve függőleges tükrözéseket. A megjelenített kontúr reprodukálásához ezeket a transzformációkat a forma középpontja körül kell alkalmazni. Csoportos alakzatoknál vegye figyelembe a csoport koordináta‑leképezését és transzformációit; ne feltételezze, hogy a kinyert pontok a végleges diavetítés‑koordináták, és ne alkalmazzon egy fordítást vagy méretezést kétszer, ha az már a gyermek keretben tükröződik.

**Ellenőrzés vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; módosításuk nem frissíti az eredeti alakzatot. Ezt a megközelítést válassza, ha az analízise vagy rajzoló kódja pont-/típus‑tömböket igényel. Használja a [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)‑t, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha szerkeszteni szeretné annak geometriáját. A szerkesztett útvonalakat alkalmazza a [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) vagy a [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) metódusokkal.

## **Java AWT Shape konvertálása GeometryPath‑ra**

Ez a példa egy négyszög kontúrt kombinál a szöveg geometriává konvertált változatával. A kontúr [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) metódusa letiltja a kitöltést. Egy [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) hozza létre a szöveg vázlatát egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumban. A [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) mozgás‑, vonal‑, kvadratikus‑, köbös‑ és záró szegmenseket ad, amelyeket a példa egy [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑on újrajátszik.

A szöveg 40‑pontos Arial betűtípussal jelenik meg. A kontúr 20 ponttal vízszintesen el van tolva, és a vizuális felső élétől 10 ponttal alul helyezkedik el az alakzat felső szélén. A szöveg útvonal kitöltött, míg az eredeti négyszög csak kontúrból áll. Mindkét útvonal a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) segítségével kerül alkalmazásra, egyetlen alakzatot hozva létre, amely tartalmazza a négyszöget és a szöveget.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Szerezze meg az alakzat geometriai útvonalát.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Készítsen egy új grafikus útvonalat szöveggel.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Alakítsa át a grafikus útvonalat geometriai útvonallá.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Alkalmazza a szöveg útvonalat az eredeti geometriai útvonalal együtt.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Mi történik a kitöltéssel és körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan forgassam helyesen egy egyéni alakzatot a geometriai adataival együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) metódusát; a geometria az alakzattal együtt forgik, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom‑e egy egyéni alakzatot képpé a „lezáráshoz”?**

Igen. Exportálja a szükséges [dia](/slides/hu/python-java/convert-powerpoint-to-png/) területet vagy az [alakzat](/slides/hu/python-java/create-shape-thumbnails/) sajátját raszterformátumba; ez leegyszerűsíti a komplex geometriák további kezelését.