---
title: Přizpůsobení tvarů v prezentacích pomocí Pythonu
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/python-net/custom-shape/
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
- odebrat bod
- operace úprav
- zakřivený roh
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python na platformě .NET: geometrické cesty, zakřivené rohy, kompozitní tvary."
---
## **Úvod**

Zvažte čtverec. V PowerPointu můžete pomocí **Edit Points**:

* posunout roh čtverce dovnitř nebo ven,
* upravit zakřivení rohu nebo bodu,
* přidat nové body do čtverce,
* manipulovat s jeho body.

Tyto operace můžete použít na libovolný tvar. Pomocí **Edit Points** můžete upravit tvar nebo vytvořit nový z existujícího tvaru.

## **Tipy pro úpravu tvarů**

!["Edit Points" příkaz](custom_shape_0.png)

Před zahájením úprav tvarů v PowerPointu pomocí **Edit Points** si přečtěte tyto poznámky o tvarech:

* Tvar (nebo jeho cesta) může být **uzavřený** nebo **otevřený**.
* Uzavřený tvar nemá počáteční ani koncový bod; otevřený tvar má začátek i konec.
* Každý tvar má alespoň dva kotvící body spojené úsečkami.
* Úsek je buď přímý, nebo zakřivený; kotvící body určují povahu úseku.
* Kotvící body mohou být **roh**, **hladký** nebo **přímý**:
  * **Roh** je bod, kde se dva přímé úseky setkávají pod úhlem.
  * **Hladký** bod má dva úchyty, které jsou kolineární, a sousední úseky tvoří hladkou křivku. V tomto případě jsou oba úchyty ve stejné vzdálenosti od kotvícího bodu.
  * **Přímý** bod také má dva kolineární úchyty, a sousední úseky tvoří hladkou křivku. V tomto případě nemusí být úchyty ve stejné vzdálenosti od kotvícího bodu.
* Posunutím nebo úpravou kotvících bodů (tím změníte úhly úseků) můžete změnit vzhled tvaru.

Pro úpravu tvarů v PowerPointu poskytuje Aspose.Slides třídu [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/).

* Instance třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/) použijte metodu [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/) pro tvar použijte [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/set_geometry_path/) pro *pevné tvary* a [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/set_geometry_paths/) pro *kompozitní tvary*.
* Pro přidání úseků použijte metody třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/).
* Použijte vlastnosti [GeometryPath.stroke](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/stroke/) a [GeometryPath.fill_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/fill_mode/) pro řízení vzhledu geometrické cesty.
* Vlastnost [GeometryPath.path_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/path_data/) použijte k získání geometrické cesty tvaru jako pole úseků cesty.

## **Jednoduché operace úprav**

Následující metody se používají pro jednoduché operace úprav.

**Přidat čáru** na konec cesty:

```py
line_to(point)
line_to(x, y)
```

**Přidat čáru** na určenou pozici v cestě:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Přidat kubickou Bézierovu křivku** na konec cesty:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Přidat kubickou Bézierovu křivku** na určenou pozici v cestě:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Přidat kvadratickou Bézierovu křivku** na konec cesty:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Přidat kvadratickou Bézierovu křivku** na určenou pozici v cestě:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Připojit oblouk** k cestě:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Uzavřít aktuální obrazec** v cestě:

```py
close_figure()
```

**Nastavit polohu pro další bod**:

```py
move_to(point)
move_to(x, y)
```

**Odstranit úsek cesty** na daném indexu:

```py
remove_at(index)
```

## **Přidání vlastních bodů do tvarů**

Zde se naučíte, jak definovat volný tvar přidáním vlastní posloupnosti bodů. Zadáním uspořádaných bodů a typů úseků (přímý nebo zakřivený) a volitelným uzavřením cesty můžete vytvořit přesnou vlastní grafiku — polygony, ikony, vysvětlivky nebo loga — přímo ve vašich snímcích.

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/) a nastavte její [ShapeType.RECTANGLE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapetype/).
2. Získejte instanci [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/) ze tvaru.
3. Vložte nový bod mezi dva horní body na cestě.
4. Vložte nový bod mezi dva dolní body na cestě.
5. Aplikujte aktualizovanou cestu na tvar.

Následující kód v Pythonu ukazuje, jak přidat vlastní body do tvaru:

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

![Vlastní body](custom_shape_1.png)

##  **Odstranění bodů z tvarů**

Někdy vlastní tvar obsahuje zbytečné body, které komplikují jeho geometrii nebo ovlivňují vykreslení. Tento odstavec ukazuje, jak odstranit konkrétní body z cesty tvaru, abyste mohli zjednodušit obrys a dosáhnout čistších, přesnějších výsledků.

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/) a nastavte její typ [ShapeType.HEART](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapetype/).
2. Získejte instanci [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/) ze tvaru.
3. Odstraňte úsek z cesty.
4. Aplikujte aktualizovanou cestu na tvar.

Následující kód v Pythonu ukazuje, jak odstranit body z tvaru:

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

![Odstraněné body](custom_shape_2.png)

##  **Vytvoření vlastních tvarů**

Vytvořte jedinečné vektorové tvary definováním [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/) a jeho sestavením z úseků, oblouků a Bézierových křivek. Tento odstavec ukazuje, jak od základů vytvořit vlastní geometrii a přidat výsledný tvar do snímku.

1. Vypočítejte body pro tvar.
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/).
3. Naplňte cestu body.
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/).
5. Aplikujte cestu na tvar.

Následující kód v Pythonu ukazuje, jak vytvořit vlastní tvar:

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

![Vlastní tvar](custom_shape_3.png)

## **Vytvoření kompozitních vlastních tvarů**

Vytvoření kompozitního vlastního tvaru vám umožní spojit několik geometrických cest do jednoho, opakovaně použitelného tvaru na snímku. Definujte a sloučte tyto cesty pro vytvoření složitých vizuálů, které přesahují standardní sadu tvarů.

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/).
2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/).
3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometrypath/).
4. Aplikujte obě cesty na tvar.

Následující kód v Pythonu ukazuje, jak vytvořit kompozitní vlastní tvar:

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

![Kompozitní tvar](custom_shape_4.png)

## **Vytvoření vlastních tvarů se zakřivenými rohy**

Tento odstavec ukazuje, jak pomocí geometrické cesty nakreslit vlastní tvar s hladce zakřivenými rohy. Kombinujete přímé úseky a kruhové oblouky k vytvoření obrysu a přidáte hotový tvar do snímku.

Následující kód v Pythonu ukazuje, jak vytvořit vlastní tvar se zakřivenými rohy:

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

![Zakřivené rohy](custom_shape_6.png)

## **Zjištění, zda je geometrie tvaru uzavřená**

Uzavřený tvar je definován jako takový, jehož všechny strany jsou propojené, tvořící jedinou hranici bez mezer. Takový tvar může být jednoduchý geometrický tvar nebo složitý vlastní obrys. Následující příklad kódu ukazuje, jak zkontrolovat, zda je geometrie tvaru uzavřená:

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

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se pouze obrys. Výplň a obrys jsou automaticky použity na novou geometrii.

**Jak správně otáčet vlastní tvar spolu s jeho geometrií?**

Použijte vlastnost [rotation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/geometryshape/rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána s jeho vlastním souřadnicovým systémem.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek "uzamčen"?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/python-net/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/python-net/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s těžkými geometriemi.