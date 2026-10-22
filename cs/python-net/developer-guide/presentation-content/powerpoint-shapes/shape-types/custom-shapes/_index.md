---
title: Přizpůsobení tvarů prezentace v Pythonu
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
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Python na platformě .NET: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) k úpravě existujících tvarů, provádění základních operací úpravy cesty, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také ukazuje, jak vytvořit vlastní a složené tvary, vytvářet tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, a extrahovat elementy tvaru pro analýzu kontury.

## **Změna tvaru pomocí editačních bodů**

* Přesunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožňuje změnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti následující koncepty:

* Tvar (nebo jeho cesta) může být buď uzavřená, nebo otevřená.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být rovný nebo zakřivený. Kotevní body a ovládací úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, rovné body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou oba ovládací úchyty zarovnány a stejně vzdálené od kotevního bodu.
  * U rovného bodu jsou oba ovládací úchyty zarovnány, ale mohou být od kotevního bodu v různých vzdálenostech.
* Přesunutí kotevních bodů nebo úprava jejich úchytek mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů **Aspose.Slides** poskytuje třídu [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Instancia [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Chcete-li získat [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), můžete použít metodu [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Chcete-li nastavit [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) pro tvar, můžete použít tyto metody: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) pro tvary s jednou cestou a [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Pomocí vlastností [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) a [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) můžete nastavit vzhled geometrické cesty.
* Pomocí vlastnosti [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) jako pole segmentů cesty.

## **Jednoduché operace úpravy**

Použijte následující metody k úpravě geometrické cesty. Přetížení, která přijímají index, vloží segment na tuto nula‑založenou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Přidat nebo vložit kubický Bézierův křivku se dvěma řídícími body a koncovým bodem. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Přidat nebo vložit kvadratický Bézierův křivku s jedním řídícím bodem a koncovým bodem. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Uzavřít aktuální obrazec spojení jeho koncového bodu se startovním bodem. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Nastavit počáteční bod obrazce. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Odstranit segment na nula‑založeném indexu. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) a použije upravenou cestu s [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levé strany a 50 bodů od horní. Indexy segmentů 1 a 4 je umístí na horní a dolní hranu, čímž tyto hrany stáhnou dovnitř.

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

## **Odstranění bodů ze tvaru**

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nula‑založeném indexu 2 pomocí [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Použití upravené cesty s [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) aktualizuje konturu tvaru.

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

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pětiprstý hvězdicový tvar pomocí [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zapuštění; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) a aplikována na obdélníkový tvar pomocí [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), čímž nahradí jeho obrys.

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

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) pro horní a dolní třetinu tvaru. Použití obou cest s [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) vytvoří jeden složený tvar s mezerou přes střední třetinu.

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

## **Vytvoření vlastního tvaru se zakřivenými rohy**

Tento příklad kombinuje rovné segmenty s [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) pro vytvoření tvaru se zakřivenými rohy dovnitř. Velikost každého rohu určuje šířku a výšku oblouku v bodech a úhel -90° vykresluje proti směru hodinových ručiček čtvrtkruh elipsy. Dokončená cesta je aplikována pomocí [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) a prezentace je uložena ve formátu PPTX.

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Následující pomocná funkce kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Čte [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) a porovnává příkaz posledního segmentu [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) s [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Vracejí false, když neexistují neprázdné cesty. Toto kontroluje poslední příkaz každé cesty; nezkoumá každou podfiguru v cestě. Příklad vytiskne `True` pro obdélník.

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

## **Extrahování a inspekce elementů tvaru**

Použijte [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) k inspekci existujícího tvaru jako elementů obsahujících body cesty a typy bodů. Každý vrácený [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) poskytuje pole [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) a [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Toto znázornění je užitečné pro analýzu kontury nebo předání geometrie vlastním kreslícím nástrojům.

Příklad otevře prezentaci, najde první geometrický tvar přímo na první snímku a vytiskne jeho segmenty cesty. Použijte prezentaci obsahující tvar s rovnými i zakřivenými segmenty, abyste viděli oba typy výstupu. Neprohledává skupiny.

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
                point_type = types[i] & 0x07  # Zachovat typ segmentu, vyjma příznaků.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Spotřebovat oba řídící body a koncový bod.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje obrazec a typ `1` kreslí čáru od předchozího bodu k aktuálnímu bodu. Kubický Bézier segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí položky typu `3`: dva řídící body následované novým koncovým bodem. Smyčka spotřebuje těchto tři položky najednou a kontroluje koncový bod na uzavřenost.

Typy bodů také obsahují příznaky. Maskujte pomocí `0x07` pro identifikaci typu segmentu a testujte `0x80` samostatně pro detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá podcestu. Porovnání surové hodnoty jen s `1` nebo `3` by tyto případy prošvihlo. Další příznaky, jako čárka (`0x10`) a značka (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), přičemž X roste doprava a Y dolů. Pro neagregovaný tvar již extrahované souřadnice zahrnují jeho pozici [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) a [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník v `(100, 200)` s velikostí `120 × 80` má hranice kontury `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y pro získání souřadnic relativně k neotočenému rámci.

Extrahované body neaplikují [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) tvaru ani vodorovné a svislé převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. Pro seskupené tvary také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou konečné vykreslené souřadnice snímku nebo že použijete posunutí či škálování dvakrát, pokud už je zahrnuto v rámci dítěte.

**Inspekce vs. úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analytické nebo kreslící kódy potřebují pole bodů/typů. Použijte [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) pokud potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Aplikujte upravené cesty pomocí [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) nebo [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává na tvaru; mění se pouze kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar společně s jeho geometrií?**

Použijte vlastnost [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána s jeho vlastním souřadnicovým systémem.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/python-net/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/python-net/create-shape-thumbnails/) do rastrového formátu; to zjednoduší další práci s komplexními geometriemi.