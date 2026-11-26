---
title: Přizpůsobení tvarů prezentace v Pythonu pomocí Java
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/python-java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte a přizpůsobte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) pro úpravu existujících tvarů, provádět základní operace úprav cest, přidávat nebo odstraňovat body a aplikovat aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, sestavit tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, prozkoumat prvky tvaru a převést obrysy textu Java AWT na geometrické cesty.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** k úpravě čtverce:

* Přesunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Při úpravě tvarů v PowerPointu si pamatujte na následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Cesta tvaru se skládá z kotvících bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotvící body a ovládací úchyty určují jeho tvar.
* Kotvící body existují jako rohové body, přímé body nebo hladké body:
  * V rohovém bodě se sousední segmenty mohou setkat pod úhlem.
  * V hladkém bodě jsou oba ovládací úchyty zarovnané a stejně vzdálené od kotvícího bodu.
  * V přímém bodě jsou oba ovládací úchyty zarovnané, ale mohou mít různou vzdálenost od kotvícího bodu.
* Posunutím kotvících bodů nebo úpravou jejich úchytů se mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů **Aspose.Slides** poskytuje třídu [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) můžete použít metodu [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) pro tvary s jednou cestou a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Pomocí metod [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) a [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete číst [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) přes jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) a přehrát segmenty na [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Jednoduché operace úprav**

Použijte následující metody k úpravě geometrické cesty. Přetížení, která přijímají index, vloží segment na tuto nulovou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídícími body a koncovým bodem. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídícím bodem a koncovým bodem. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Uzavřít aktuální obrazec spojením jeho koncového bodu se startovním bodem. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Nastavit počáteční bod obrazce. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Odstranit segment na nultém indexu. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) a použije upravenou cestu s metodou [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levého okraje a 50 bodů od horního okraje. Indexy segmentů 1 a 4 je umístí na horní a dolní hranu, čímž tyto hrany stáhnou dovnitř.

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

## **Odstranění bodů z tvaru**

Tento příklad mění obrys tvaru srdce odstraněním segmentu na nulovém indexu 2 pomocí [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Aplikace upravené cesty metodou [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje konturu tvaru.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

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

## **Vytvoření vlastního tvaru**

Tento příklad vytváří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zanoření; krok 72 stupňů rovnoměrně rozděluje pět špiček. Cesta je uzavřena metodou [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) a aplikována na obdélníkový tvar pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), čímž nahradí jeho obrys.

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

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) pro horní a dolní třetinu tvaru. Aplikací obou cest metodou [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) se vytvoří jeden složený tvar s mezerou ve střední třetině.

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

## **Vytvoření vlastního tvaru s zakřivenými rohy**

Tento příklad kombinuje přímé segmenty s metodou [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) pro vytvoření tvaru se zakřivenými rohy dovnitř. Každá velikost rohu určuje šířku a výšku oblouku v bodech a úhel -90 stupňů vykreslí proti směru hodinových ručiček čtvrt kružnice. Dokončená cesta je aplikována metodou [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) a prezentace je uložena ve formátu PPTX.

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

## **Zjištění, zda je geometrie tvaru uzavřená**

Následující pomocná metoda kontroluje, zda každý neprázdný geometrický path končí uzavíracím segmentem. Čte [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) a porovnává poslední segmentů [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) s [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Vrací `False`, když neexistují neprázdné cesty. Kontroluje poslední příkaz každé cesty; neprozkoumává každou podpostavu v rámci cesty. Příklad vypíše `True` pro obdélník.

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

## **Kontrola příkazů geometrické cesty**

Stáhněte [contour.pptx](contour.pptx) a umístěte jej do pracovního adresáře aplikace. První tvar na první snímku má rovnou horní hranu, kubickou Bézierovu křivku a rovnou uzavírací hranu. Použijte [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) k načtení cest tvaru a [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) k načtení segmentů každé cesty ve vykreslovacím pořadí. Pro každý segment [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) určuje příkaz a stanoví, jak interpretovat hodnoty vrácené metodou [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

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

Tvar leží na souřadnicích (200, 100) bodů na snímku. Uvedené souřadnice jsou lokální k tvaru, přičemž (0, 0) je v jeho levém horním rohu, x roste doprava a y roste dolů. Uzavírací segment se vrací na počáteční bod bez dalších souřadnic.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Tvar PowerPoint s přímým horním okrajem, zakřiveným okrajem od pravého horního ke levému dolnímu a přímým levým okrajem](contour.png)

## **Extrahování a kontrola prvků tvaru**

Použijte [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) k prozkoumání existujícího tvaru jako prvků obsahujících body cesty a typy bodů. Každý vrácený prvek přetypujte na [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) pomocí `jpype.JObject` a získejte pole bodů a typů přes metody [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) a [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Tento výstup je užitečný pro analýzu kontur nebo předávání geometrie vlastním kreslícím nástrojům.

Příklad otevírá `input.pptx`, najde první geometrický tvar přímo na první snímku a vypíše jeho segmenty cesty. Použijte prezentaci obsahující tvar s přímými i zakřivenými segmenty, abyste viděli oba typy výstupu. Nepřepočítává se uvnitř skupin.

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

Pole jsou zarovnána podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje figuru a typ `1` kreslí čáru z předchozího bodu na aktuální bod. Kubický Bézierův segment začíná na předchozím koncovém bodě a používá tři po sobě jdoucí položky typu `3`: dva řídící body a nový koncový bod. Smyčka tyto tři položky spotřebuje najednou a kontroluje koncový bod, zda uzavírá.

Typy bodů také obsahují příznaky. Maskujte s `0x07` pro určení typu segmentu a testujte `0x80` samostatně pro detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá. Java ukládá tyto příznaky v podepsaných bytech; maskování zachovává zamýšlené bitové hodnoty. Porovnání surové hodnoty jen s `1` nebo `3` by tyto případy přehlédlo. Ostatní příznaky, jako pomlčka (`0x10`) a značka (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 inch), přičemž X roste doprava a Y roste dolů. Pro ne-skupinový tvar již extrahované souřadnice zahrnují pozici vrácenou metodami [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) a [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) a odrážejí aktuální šířku a výšku. Například neotočený obdélník v `(100, 200)` s rozměry `120 × 80` má ohraničení kontury `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y, abyste získali souřadnice relativní k neotočenému rámci.

Extrahované body neaplikují rotaci tvaru, kterou vrací [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), ani horizontální a vertikální převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. U skupinových tvarů také zohledněte mapování souřadnic skupiny a transformace; nepřepokládejte, že extrahované body jsou finální vykreslené souřadnice snímku, ani neaplikujte posun nebo měřítko dvakrát, pokud již jsou zahrnuty v rámu potomka.

**Kontrola vs. úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analýza nebo kreslící kód potřebuje pole bodů/typů. Použijte [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), pokud potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Aplikujte upravené cesty pomocí [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) nebo [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Převod Java AWT Shape na GeometryPath**

Tento příklad kombinuje obdélníkový obrys s textem převedeným na geometrii. Metoda [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) obrysu zakáže jeho výplň. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) vytvoří obrys textu v [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) poskytuje přesun, čáru, kvadratický, kubický a uzavírací segment, které příklad přehraje na [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Text používá písmo Arial o velikosti 40 bodů. Obrys je posunut o 20 bodů vodorovně a umístěn tak, že jeho vizuální horní část je 10 bodů pod horním okrajem tvaru. Cesta textu je vyplněna, zatímco původní obdélník zůstává jen obrysem. Aplikací obou cest metodou [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) vznikne jeden tvar obsahující obdélník i text.

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

    # Získat geometrickou cestu tvaru.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Vytvořit novou grafickou cestu s textem.
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

    # Převést grafickou cestu na geometrickou cestu.
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

    # Použít textovou cestu společně s původní geometrickou cestou.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane u tvaru; pouze se změní kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu tvaru [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation); geometrie se otáčí společně s tvarem, protože je svázána s jeho vlastním souřadnicovým systémem.

**Mohu převést vlastní tvar na obrázek, aby se „uzamkl“ výsledek?**

Ano. Exportujte požadovanou [slide](/slides/cs/python-java/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/python-java/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s komplexními geometriemi.