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
- upravit body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte a přizpůsobte tvary v prezentacích PowerPoint s Aspose.Slides pro Python přes Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí upravovacích bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) pro úpravu existujících tvarů, provádět základní operace úpravy cesty, přidávat nebo odebírat body a aplikovat aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, vytvořit tvary s zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, a převést mezi [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí upravovacích bodů**

Představte si čtverec. V PowerPointu můžete pomocí **edit points**:

* posunout roh čtverce dovnitř nebo ven
* specifikovat zakřivení rohu nebo bodu
* přidat nové body do čtverce
* manipulovat body na čtverci atd.

V podstatě můžete provádět popsané úkoly na libovolném tvaru. Pomocí edit points můžete měnit tvar nebo vytvořit nový tvar z existujícího tvaru.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Než začnete upravovat tvary v PowerPointu pomocí edit points, možná budete chtít zvážit následující body o tvarech:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Když je tvar uzavřený, postrádá počáteční nebo koncový bod. Když je tvar otevřený, má začátek a konec. 
* Všechny tvary se skládají alespoň ze 2 kotevních bodů spojených čarami.
* Čára může být rovná nebo zakřivená. Kotevní body určují povahu čáry. 
* Kotevní body existují jako rohové body, rovné body nebo plynulé body:
  * Rohový bod je bod, kde se dva rovné úseky spojují pod úhlem. 
  * Plynulý bod je bod, kde jsou dva úchyty umístěny na jedné přímce a segmenty čáry se spojují v plynulou křivku. V tomto případě jsou všechny úchyty od kotevního bodu odděleny stejnou vzdáleností. 
  * Rovný bod je bod, kde jsou dva úchyty na jedné přímce a segmenty čáry se spojují v plynulou křivku. V tomto případě nemusí být úchyty od kotevního bodu odděleny stejnou vzdáleností. 
* Posunutím nebo úpravou kotevních bodů (což mění úhel čar) můžete změnit vzhled tvaru. 

Pro úpravu tvarů v PowerPointu pomocí edit points poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/). 

* Instancia [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/). 
* Pro získání [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/) můžete použít metodu [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#getGeometryPaths). 
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#setGeometryPath) pro *plné tvary* a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/#setGeometryPaths) pro *složené tvary*.
* Pro přidání segmentů můžete použít metody pod [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/). 
* Pomocí metod [GeometryPath.setStroke](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/#setStroke) a [GeometryPath.setFillMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/#setFillMode) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [GeometryPath.getPathData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/#getPathData) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/) jako pole segmentů cesty. 
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete převést [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Použijte [geometryPathToGraphicsPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeutil/) a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeutil/) (z třídy [ShapeUtil](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapeutil/)) pro převod [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a zpět. 

## **Jednoduché operace úpravy**

Níže uvedené signatury ukazují základní operace úpravy:

**Přidat čáru** na konec cesty:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Přidat čáru** na určenou pozici v cestě:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Přidat kubickou Bézierovu křivku** na konec cesty:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Přidat kubickou Bézierovu křivku** na určenou pozici v cestě:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Přidat kvadratickou Bézierovu křivku** na konec cesty:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Přidat kvadratickou Bézierovu křivku** na určenou pozici v cestě:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Připojit daný oblouk** k cestě:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Uzavřít aktuální útvar** cesty:

- `geometry_path.closeFigure()`

**Nastavit pozici pro další bod**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Odstranit segment cesty** na daném indexu:

- `geometry_path.removeAt(index)`


## **Přidání vlastních bodů do tvaru**
1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/) a nastavte typ [ShapeType.Rectangle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Rectangle).
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) ze tvaru.
3. Přidejte nový bod mezi dva horní body v cestě.
4. Přidejte nový bod mezi dva spodní body v cestě.
5. Aplikujte cestu na tvar.

Tento Python kód vám ukazuje, jak přidat vlastní body do tvaru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Odstranění bodů z tvaru**

1. Vytvořte instanci [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/) a nastavte typ [ShapeType.Heart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Heart). 
2. Získejte instance [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) ze tvaru.
3. Odstraňte segment cesty.
4. Aplikujte cestu na tvar.

Tento Python kód vám ukazuje, jak odstranit body z tvaru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

1. Vypočítejte body pro tvar.
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/). 
3. Vyplňte cestu body.
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/). 
5. Aplikujte cestu na tvar.

Tento Python kód vám ukazuje, jak vytvořit vlastní tvar:

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Vytvoření složeného vlastního tvaru**

  1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/).
  2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/).
  3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/).
  4. Aplikujte cesty na tvar.

Tento Python kód vám ukazuje, jak vytvořit složený vlastní tvar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

Tento Python kód vám ukazuje, jak vytvořit vlastní tvar s zakřivenými rohy (směrem dovnitř):

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

A uzavřený tvar je definován jako takový, kde se všechny jeho strany spojují a tvoří jedinou hranici bez mezer. Takový tvar může být jednoduchý geometrický útvar nebo složitá vlastní obrysová čára. Následující ukázkový kód ukazuje, jak zjistit, zda je geometrie tvaru uzavřená:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Převod GeometryPath na java.awt.Shape** 

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometryshape/).
2. Vytvořte instanci třídy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Převeďte instanci [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instanci [GeometryPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/geometrypath/) procházením jejího [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) a opětovným přehráním každého segmentu do cesty.
4. Aplikujte cesty na tvar.

Tento Python kód implementuje výše uvedené kroky pro převod grafické cesty na geometrickou cestu:

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
    # Vytvořte nový tvar.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Získat geometrickou cestu tvaru.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Vytvořte novou grafickou cestu s textem.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
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

    # Použijte textovou cestu spolu s původní geometrickou cestou.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se pouze obrys. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otáčet vlastní tvar spolu s jeho geometrií?**

Použijte metodu [setRotation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setRotation) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána s jeho vlastním souřadnicovým systémem.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/python-java/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/python-java/create-shape-thumbnails/) do rastrového formátu; to zjednoduší další práci s rozsáhlými geometriemi.