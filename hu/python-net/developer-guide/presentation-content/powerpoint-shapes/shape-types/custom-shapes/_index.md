---
title: Az előadások alakzatainak testreszabása Pythonban
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
description: "Alakzatok létrehozása és testreszabása PowerPoint-prezentációkban az Aspose.Slides for Python .NET-en keresztül: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides-ben a forma geometria szerkesztésével szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan kell használni a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) osztályt a meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és az frissített geometria visszaalkalmazásához egy alakzatra.

Bemutatja továbbá, hogyan lehet egyéni és összetett alakzatokat létrehozni, ívelt sarkokkal rendelkező alakzatokat építeni, meghatározni, hogy egy alakzat geometria zárt‑e, és alakzat‑elemeket kinyerni a körvonal elemzéséhez.

## **Alakzat módosítása szerkesztési pontokkal**

A PowerPointban a **Edit Points** használatával módosíthat egy négyzetet:

* Mozgasson egy sarkot beljebb vagy kifelé.
* Állítsa be a görbületet egy pontnál.
* Új pontok hozzáadása.

A pontok szerkesztése lehetővé teszi egy alakzat körvonalának módosítását, vagy egy meglévő alakzat felhasználását alapként egy újhoz.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint alakzatok szerkesztésekor tartsa szem előtt a következő fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Egy alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy ívelt. A horgonypontok és a vezérlő nyelesek határozzák meg formáját.
* A horgonypontok létezhetnek sarokpontként, egyenes pontként vagy sima pontként:
  * Sarokpontnál a szomszédos szegmensek szöggel csatlakozhatnak.
  * Sima pontnál a két vezérlő nyél egyvonalú és egyenlő távolságra van a horgonyponttól.
  * Egyenes pontnál a két vezérlő nyél egyvonalú, de eltérő távolságban lehet a horgonyponttól.
* A horgonypontok mozgatása vagy nyélük állítása megváltoztatja az alakzat körvonalát.

A PowerPoint alakzatok szerkesztési pontokkal történő módosításához az **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) osztályt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) példány a [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) objektum geometriai útvonalát képviseli.
* A [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) lekéréséhez a [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) példányból használhatja a [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) metódust.
* Egy alakzathoz a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) beállításához használhatja ezeket a metódusokat: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) egyetlen útvonallal rendelkező alakzatokhoz és [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) több útvonallal rendelkező alakzatokhoz.
* Szegmensek hozzáadásához használhatja a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) alatti metódusokat.
* A [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) és [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) tulajdonságok használatával beállíthatja egy geometriai útvonal megjelenését.
* A [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) tulajdonság használatával lekérheti egy [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) geometriai útvonalát útvonal‑szegmenseket tartalmazó tömbként.

## **Egyszerű szerkesztési műveletek**

Használja a következő metódusokat egy geometriai útvonal szerkesztéséhez. Az indexet elfogadó túlterhelések egy szegmenst illesztenek be a nullától indexelt pozícióba az útvonal szegmens tömbjében.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáfűzése vagy beszúrása. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Köbös Bézier görbe hozzáfűzése vagy beszúrása két vezérlőponttal és egy végponttal. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Kvadratikus Bézier görbe hozzáfűzése vagy beszúrása egy vezérlőponttal és egy végponttal. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Elliptikus ív hozzáfűzése a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Az aktuális alakzat lezárása a végpontjának az indítóponttal való összekapcsolásával. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Az alakzat kiindulási pontjának beállítása. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Szegmens eltávolítása egy nullától indexelt pozíción. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) használatával, és a szerkesztett útvonalat a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) alkalmazza. A koordináták az alakzathoz helyiértékűek: mindkét új pont a középpontjában van, 100 pontbalra a bal szélről és 50 pontbalra a tetejétől. Az 1‑es és 4‑es szegmensindexek a pontokat a felső és alsó élre helyezik, így ezeket az éleket befelé húzva.

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

Ez a példa egy szív alakú körvonalat módosít azzal, hogy eltávolítja a 2‑es nullától indexelt szegmenst a [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) segítségével. A módosított útvonal alkalmazása a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) frissíti az alakzat kontúrját.

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

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) segítségével. A 100 és 50 pontot váltakozó külső és belső sugár határozza meg a csúcsokat és a bemélyedéseket; egy 72‑fokos lépés egyenlően osztja el az öt csúcsot. Az útvonalat a [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) zárja le, és egy téglalap alakzatra a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) alkalmazza, ezzel felülírva a körvonalát.

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

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) objektumot definiál a forma felső és alsó egyharmadjára. Mindkét útvonal alkalmazása a [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) segítségével egyetlen összetett alakzatot hoz létre, amelynek középső egyharmadja nyílással rendelkezik.

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

## **Egyéni alakzat létrehozása ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) használatával, hogy egy belsőleg ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarokméret beállítja az ív szélességét és magasságát pontban, a -90‑fokos ív egy óramutatóval ellentétes negyedhélt rajzol. A kész útvonalat a [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) alkalmazza, és a prezentációt PPTX formátumban menti.

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

## **Megállapítás, hogy egy alakzat geometria zárt‑e**

Az alábbi segédprogram ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmensekkel végződik‑e. A [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) beolvas és a végső szegmens [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) értékét összehasonlítja a [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Ha nincs nem üres útvonal, hamis értéket ad vissza. Ez a végső parancsot ellenőrzi minden útvonalnál; nem vizsgálja meg az egyes alalakzatokat az útvonalon belül. A példa `True` értéket ír ki egy téglalap esetén.

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

## **Alakzat elemek kinyerése és vizsgálata**

Használja a [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) metódust, hogy megvizsgálja egy meglévő alakzat elemeit, amelyek útvonal‑pontokat és ponttípusokat tartalmaznak. Minden visszaadott [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) exponálja a [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) és [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) tömbjeit. Ez a megjelenítés hasznos a körvonal elemzéséhez vagy a geometria egyedi rajzoló eszközöknek való átadásához.

A példa megnyit egy prezentációt, megtalálja az első geometriai alakzatot közvetlenül az első dián, és kiírja az útvonal szegmenseit. Használjon olyan prezentációt, amelyben az alakzat egyenes és ívelt szegmenseket is tartalmaz, hogy mindkét típusú kimenetet lássa. Nem keres a csoportokban.

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

A tömbök index szerint egyeznek: a `points[i]` egy pont, a `types[i]` leírja a szerepét. A `0` típus egy új alakzatot indít, az `1` típus pedig egy vonalat rajzol az előző pontból az aktuális pontba. A köbös Bézier szegmens az előző végpontból indul és három egymást követő `3`‑as bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést együtt dolgozza fel, és a végpontot a lezárásra ellenőrzi.

A ponttípusok további jelzőket is tartalmaznak. `0x07` maszkkal azonosítható a szegmens típusa, a `0x80` külön tesztelhető a zárt alútvonal felismerésére. Például a `129` (`0x81`) egy vonalvégpontot jelent, amely egy alútvonalat zár le, a `131` (`0x83`) pedig egy Bézier‑végpontot, amely szintén lezár egy alútvonalat. Ha csak a nyers értéket `1`‑gyel vagy `3`‑mal hasonlítja, ezek a esetek kimaradnak. Más jelzők, mint a szaggatottság (`0x10`) és a marker (`0x20`), nem változtatják meg az alapszegmens típust.

**Koordináták és transzformációk.** A pontok pontban vannak mérve (1/72 hüvelyk), az X jobbra, a Y lefelé nő. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) pozíciót, és tükrözik az aktuális szélességet és magasságot. Például egy elforgatás nélküli téglalap a `(100, 200)` pozícióban, `120 × 80` mérettel, a körvonal határa `(100, 200)`–`(220, 280)`. Ne adja hozzá újra az alakzat pozícióját. Vonja le az X‑et és Y‑t a nem elforgatott kerethez képest.

A kinyert pontok nem alkalmazzák az alakzat [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) vagy a vízszintes és függőleges tükrözéseket. A megjelenített körvonal reprodukálásához ezeket a transzformációkat az alakzat középpontja körül alkalmazza. Csoportosított alakzatok esetén figyelembe kell venni a csoport koordináta leképezését és transzformációkat; ne feltételezze, hogy a kinyert pontok a végső megjelenített diaképpontok, vagy ne alkalmazzon kétszeres eltolást vagy méretezést, ha már a gyermek keretben tükröződik.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a körvonalat írják le; azok módosítása nem frissíti az eredeti alakzatot. Ezt a megközelítést akkor válassza, ha az elemzés vagy rajzoló kód pont/típus tömböket igényel. Használja a [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) metódust, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha a geometria szerkesztése a cél. Szerkessze az útvonalakat a [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) vagy [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) segítségével.

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**  
A stílus az alakzaton marad; csak a körvonal változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometrián.

**Hogyan forgathatom helyesen egy egyéni alakzatot a geometria együtt?**  
Használja az alakzat [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) tulajdonságát; a geometria az alakzattal együtt forog, mivel az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom-e egy egyéni alakzatot képpé a végeredmény „lefagyasztásához”?**  
Igen. Exportálja a szükséges [slide](/slides/hu/python-net/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/python-net/create-shape-thumbnails/) képet raszteres formátumba; ez egyszerűsíti a komplex geometriákkal való további munkát.