---
title: Přizpůsobení tvarů prezentace v Pythonu přes Java
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
- odebrat bod
- operace editace
- zakřivený roh
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v PowerPoint prezentacích pomocí Aspose.Slides pro Python přes Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) k úpravě existujících tvarů, provádění základních operací editace cesty, přidávat nebo odstraňovat body a aplikovat aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, sestavit tvary s zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, prohlížet prvky tvaru a převést obrysy textu Java AWT na geometrické cesty.

## **Změna tvaru pomocí editačních bodů**

* Posunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Editace bodů vám umožňuje měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotevní body a řídicí úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou dva řídicí úchyty zarovnány a mají stejnou vzdálenost od kotevního bodu.
  * U přímého bodu jsou dva řídicí úchyty zarovnány, ale mohou mít různé vzdálenosti od kotevního bodu.
* Posunutí kotevních bodů nebo úprava jejich úchytů mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů **Aspose.Slides** poskytuje třídu [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* K získání [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) můžete použít metodu [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* K nastavení [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) pro tvary s jednou cestou a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) pro tvary s více cestami.
* K přidání segmentů můžete použít metody pod [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Pomocí metod [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) a [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete číst [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) přes jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) a přehrát segmenty na [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Jednoduché operace editace**

Použijte následující metody k úpravě geometrické cesty. Přetížení, která přijímají index, vloží segment na tuto nulovou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídicími body a koncovým bodem. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídicím bodem a koncovým bodem. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Uzavřít aktuální útvar spojením jeho koncového bodu s počátečním bodem. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Nastavit počáteční bod útvaru. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Odstranit segment na nulovém indexu. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) a aplikuje upravenou cestu pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Souřadnice jsou lokální vůči tvaru: oba nové body jsou uprostřed, 100 bodů od levého okraje a 50 bodů od horního okraje. Indexy segmentů 1 a 4 je umístí na horní a spodní hranu, čímž tyto hrany stáhnou dovnitř.

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

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nulovém indexu 2 pomocí [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Aplikace upravené cesty pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje konturu tvaru.

```python
import jpime
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

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zapouzdření; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) a aplikována na obdélníkový tvar pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), čímž se nahrazuje jeho obrys.

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

Tento příklad definuje dva uzavřené [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) objekty pro horní a dolí třetiny tvaru. Aplikace obou cest pomocí [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) vytvoří jeden složený tvar s prostorem ve střední třetině.

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

Tento příklad kombinuje přímé segmenty s [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) pro vytvoření tvaru se zakřivenými rohy dovnitř. Každá velikost rohu určuje šířku a výšku oblouku v bodech a úhel –90 stupňů vykreslí proti směru hodinových ručiček čtvrtkruh. Dokončená cesta je aplikována pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) a prezentace je uložena ve formátu PPTX.

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Následující pomocná metoda kontroluje, zda každý neprázdný geometrický cestovní segment končí uzavíracím segmentem. Čte [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) a porovnává poslední segmentův [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) s [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Vrací `False`, když neexistují neprázdné cesty. Tato kontrola zkoumá poslední příkaz každé cesty; neprověřuje každý podúsek uvnitř cesty. Příklad vypíše `True` pro obdélník.

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

## **Extrahování a inspekce prvků tvaru**

Použijte [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) k inspekci existujícího tvaru jako prvků obsahujících body cesty a typy bodů. Přetypujte každý vrácený prvek na [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) pomocí `jpype.JObject`, abyste získali pole bodů a typů přes metody [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) a [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Toto znázornění je užitečné pro analýzu kontury nebo předávání geometrie vlastním kreslícím nástrojům.

Příklad otevře `input.pptx`, najde první geometrický tvar přímo na první snímku a vypíše jeho segmenty cesty. Použijte prezentaci obsahující tvar se segmenty přímými i zakřivenými, abyste viděli oba typy výstupu. Nehledá uvnitř skupin.

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

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje útvar, typ `1` kreslí čáru od předchozího bodu k aktuálnímu bodu. Kubický Bézierův segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí položky typu `3`: dva řídící body a nový koncový bod. Smyčka tyto tři položky zpracovává společně a kontroluje koncový bod na uzavření.

Typy bodů také obsahují příznaky. Maskujte s `0x07` pro identifikaci typu segmentu a testujte `0x80` samostatně pro detekci uzavřeného podúseku. Například `129` (`0x81`) znamená koncový bod úseku, který uzavírá podúsek, a `131` (`0x83`) znamená Bézierův koncový bod, který uzavírá. Java ukládá tyto příznaky v podepsaných bajtech; maskování zachovává zamýšlené bitové hodnoty. Porovnání surové hodnoty pouze s `1` nebo `3` by tato případy přehlédlo. Ostatní příznaky, jako pomlčka (`0x10`) a značka (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), přičemž X roste doprava a Y dolů. Pro neoznačený tvar již extrahované souřadnice zahrnují pozici vrácenou metodami [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) a [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník na `(100, 200)` s rozměry `120 × 80` má hranice kontury `(100, 200)`–`(220, 280)`. Přidávejte pozici tvaru znovu nepřidávejte. Odečtěte jeho X a Y pro získání souřadnic relativně k neotočenému rámci.

Extrahované body neaplikují otáčení tvaru, získané metodou [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), ani horizontální a vertikální převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. U seskupených tvarů také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou konečné souřadnice na snímku, ani neaplikujte posun nebo měřítko dvakrát, pokud už je zahrnuto v rámci dítěte.

**Inspekce versus editace.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analýza nebo kreslící kód potřebuje pole bodů/typů. Použijte [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), pokud potřebujete příkazy geometrie v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Aplikujte upravené cesty přes [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) nebo [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Převod Java AWT Shape na GeometryPath**

Tento příklad kombinuje obdélníkový obrys s textem převedeným na geometrii. Metoda [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) obrysu deaktivuje jeho výplň. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) vytvoří obrys textu v [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) poskytuje pohyby, linie, kvadratické, kubické a uzavírací segmenty, které příklad přehraje na [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Text používá písmo Arial o velikosti 40 bodů. Obrys je posunut horizontálně o 20 bodů a umístěn tak, že jeho vizuální horní část je 10 bodů pod horním okrajem tvaru. Textová cesta je vyplněná, zatímco původní obdélník zůstává obrysem. Aplikací obou cest pomocí [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) vznikne jediný tvar obsahující obdélník i text.

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

    # Získání geometrické cesty tvaru.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Vytvoření nové grafické cesty s textem.
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

    # Převod grafické cesty na geometrickou cestu.
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

    # Aplikace textové cesty spolu s původní geometrickou cestou.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```

![example5_image](custom_shape_5.png)

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane na tvaru; změní se pouze kontura. Výplň a obrys se automaticky použijí na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu tvaru [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation); geometrie se otáčí spolu s tvarem, protože je svázána se souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl „uzamčen“?**

Ano. Exportujte požadovanou [prezentaci](/slides/cs/python-java/convert-powerpoint-to-png/) nebo samotný [tvar](/slides/cs/python-java/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s komplexními geometriemi.