---
title: Formátování tvarů PowerPointu v Pythonu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/python-net/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- skicovací efekt
- skicová čára tvaru
- styl spoje
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturová výplň
- plná barva výplně
- průhlednost tvaru
- černobílé vykreslení tvaru
- stupně šedi vykreslení tvaru
- rotace tvaru
- 3D výztužový efekt
- 3D rotační efekt
- obnovení formátování
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak v Pythonu pomocí Aspose.Slides formátovat tvary PowerPointu — nastavte výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides for Python via .NET vám umožňuje tato nastavení řídit programově, včetně průhlednosti, rotace a 3D formátování.

![Možnosti formátování tvarů v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET poskytuje třídy a vlastnosti, které umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Použijte [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) k řízení obrysu tvaru. Tento příklad vytváří nevyplněný obdélník s modrým, čárkovaným obrysem. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) vybírá složenou čáru tlustá‑tenká, zatímco [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) nastavuje její šířku na 7 bodů a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) volí vzor čáry.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavení vlastních vzorů čárových čar**

Použijte [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) pokud předdefinované styly čar neposkytují požadované délky čárek a mezer, například pro značkové obrysy nebo technické diagramy. Při přiřazení vzoru se automaticky nastaví [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) na [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Seznam položek střídá délky čárek a mezer, začíná čárou. Každá hodnota je násobkem šířky čáry: `[4, 2]` při šířce 3 body vytváří čáru o délce 12 bodů následovanou mezerou 6 bodů. Používejte páry konečných, nezáporných hodnot k definování kompletních segmentů čáry a mezery. Příklad používá kladné hodnoty, aby byly všechny čáry a mezery viditelné.

Tento příklad vytváří pět modrých čar se stejnou délkou a plochými konci. První tři porovnávají vzory při šířce 3 body. Čtvrtý opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí délky čáry i mezery. Pátý přepíná z vlastního vzoru na plnou čáru.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Nastavte poslední čáru na plný styl.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Chcete-li se vrátit k předdefinovanému čárkovanému stylu, přiřaďte [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) k [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čárek, širší čára s prvním vzorem a plná čára v PowerPointu](custom-dash-patterns.png)

### **Nastavení konců čar**

Použijte [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) k nastavení konců otevřené čáry. Výčet [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) poskytuje tři explicitní styly konců:

- `FLAT`: Tětiva končí na koncovém bodě.
- `ROUND`: Polokruhový konec přesahuje koncový bod o polovinu šířky čáry.
- `SQUARE`: Čtvercový konec přesahuje koncový bod o polovinu šířky čáry.

Výčet také obsahuje `NOT_DEFINED`, což znamená, že žádný styl konce není explicitně přiřazen.

Konce se liší od šipek, které přidávají symboly na konce čar, a spojů, které řídí rohy mezi segmenty čar. Tento příklad zakazuje šipky pomocí [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) a [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/), aby byly porovnávány pouze tvary konců.

Následující příklad vytváří tři jinak identické vodorovné čáry, široké 20 bodů. Shora dolů používají ploché, kulaté a čtvercové konce. Jejich koncové souřadnice jsou stejné; kulaté a čtvercové konce přesahují o 10 bodů za každý konec.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round**, a **Square**.

![Plochý, kulatý a čtvercový konec na identických silných čarách v PowerPointu](line-caps.png)

## **Použití skicovacích efektů na čáry tvaru**

Skicovací efekt dává čáře tvaru vzhled ručně kreslený. Použijte [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) pro přístup k nastavení čáry, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) pro nastavení skicu a [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Následující Python kód ukazuje, jak aplikovat efekt [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Hodnota vrácená z [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) představuje nastavení přiřazené přímo tvaru. Pokud může formátování čáry být zděděno z motivu, hlavního snímku nebo rozložení, použijte [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), přistupte k [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) a přečtěte [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Efektivní hodnota odráží formátování, které je skutečně aplikováno po vyřešení dědění. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na první snímku a vytiskne obě hodnoty:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formátování stylů spojů**

Zde jsou tři možnosti typu spoje:

* Round
* Miter
* Bevel

Styl spoje řídí, jak se dva úseky obrysu setkají v rohu. Použijte **Round** pro zaoblené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spoje v prezentaci](join-style-powerpoint.png)

Tento příklad vytváří tři černé obdélníky s modrými obrysy širokými 15 bodů. Nastavuje [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) na miter, bevel a round hodnoty z [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), aby porovnal, jak jsou rohy vykresleny.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Omezení miterových spojů u ostrých rohů**

Použijte [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) s [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) nastaveným na [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) k omezení, jak daleko může ostrý roh vystupovat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spoje k šířce čáry. Například hodnota `8` umožňuje délku miteru až osmkrát větší než šířka čáry; není to měření v bodech. Pokud by roh překročil limit, PowerPoint použije zkosený spoj v tomto rohu. Větší limit umožňuje ostřejší špičky. Nastavení ovlivňuje pouze miterové spoje a změna nemá viditelný efekt, pokud roh zůstává v mezích.

Tento příklad vytváří dva identické, nevyplněné trojúhelníky s obrysy širokými 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník má šířku 80 bodů a výšku 160 bodů, což dává jeho hornímu rohu poměr délky miteru k šířce čáry přibližně `4.12`. Výsledkem je, že PowerPoint zkosení levý vrchol a zachová pravý.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zkosený vrchol s limitem miter 2 a špičatý vrchol s limitem miter 8 v PowerPointu](miter-limits.png)

## **Gradientní výplň**

Gradientní výplň míchá barvy napříč tvarem. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů od červené k fialové pomocí [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Metoda [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) umisťuje barevné zastavení na 0 a 1, na začátku a na konci gradientu. Vymazání existujících zastavení zajišťuje, že jsou použity jen tyto dvě barvy.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování bez změny gradientní výplně uložené v prezentaci.

### **Nastavení úhlu lineárního gradientu**

Použijte [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) k řízení orientace [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) výplně. Úhel se měří ve stupních a zvyšuje se po směru hodinových ručiček: `0` běží zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Podporovány jsou i zlomkové úhly. Konečné úhly mimo interval `[0, 360)` jsou normalizovány na jednu otáčku; například `-45` se stane `315` a `360` se stane `0`.

Tento příklad vytváří šest obdélníků s identickými červenými, zelenými a modrými zastaveními na pozicích `0`, `0.5` a `1`. Škálování je vypnuté, aby mohl být úhel porovnáván nezávisle na proporcích obdélníků. Úhly, zleva doprava, jsou `0`, `45` a `90` v první řadě a `135`, `180` a `270` ve druhé řadě.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek v PowerPointu:

![Lineární gradienty při 0°, 45° a 90° v horní řadě a 135°, 180° a 270° ve spodní řadě](linear-gradient-angles.png)

### **Škálování lineárního gradientu s tvarem**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) přijímá hodnotu typu [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Nastavte ji explicitně na `FALSE`, aby úhel geometrického gradientu zůstal stejný při změně proporcí tvaru, nebo na `TRUE`, aby se gradient škáloval s šířkou a výškou tvaru. Při povoleném škálování se viditelný úhel může lišit od přiřazeného úhlu u netroutného tvaru.

Následující příklad používá úhel `45` stupňů a stejné barevné zastavení jako v porovnání úhlů. Levý sloupec používá `FALSE`; pravý sloupec používá `TRUE`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku demonstruje, jak výplň reaguje na změnu velikosti bez změny nastavení gradientu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek v PowerPointu, se škálováním vypnutým vlevo a povoleným vpravo:

![Široké a vysoké obdélníky s 45‑stupňovým gradientem, porovnání linear_gradient_scaled FALSE vlevo s TRUE vpravo](linear-gradient-scaling.png)

Při vypnutém škálování si šikmé barevné pásy zachovávají stejnou orientaci v obou obdélnících. Při povoleném škálování se pásy roztahují s proporcemi tvaru. To pomáhá reprodukovat gradient šablony při přizpůsobení tvaru jiné velikosti. Na čtverci povolení škálování nemění vzhled tohoto 45‑stupňového gradientu.

Oba nastavení úhlu i škálování se vztahují na lineární gradienty. Neřídí výplně [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Kombinace úhlu se směrem gradientu**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) vybírá styl gradientu z výčtu [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); není náhradou za číselný úhel. Pro lineární gradient mohou styly rohu měnit oblast, na kterou jsou barvy rozloženy, aniž by měnily [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Při porovnávání úhlů nebo škálování ponechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: přiřazení směru před nebo po úhlu nemění výsledek.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Vzorová výplň**

Vzorová výplň používá dvoubarevný motiv, například tečky, pruhy nebo šachovnici. Tento příklad používá [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) k výběru vzoru mřížky. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) poskytuje světle šedé pozadí a [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) dodává žlutou barvu vzoru.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje lokální obrázek a používá [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) k načtení do kolekce obrázků prezentace. Nastavení [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) na režim dlaždic opakuje obrázek uvnitř obdélníku. Použitý zdrojový obrázek je zobrazen níže:

![Obrázek lotosu](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždice obrázku jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující vlastnosti třídy [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Nastavuje režim obrázkové výplně — buď `TILE`, nebo `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Řídí, zda je dlaždice překlopena horizontálně, vertikálně nebo obojí.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definuje horizontální měřítko dlaždice v procentech.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definuje vertikální měřítko dlaždice v procentech.

Tento příklad vyžaduje lokální obrázek a konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) tak, aby jej opakoval při 50 % původní velikosti. Posuny `−32` bodů posunou dlaždice horizontálně i vertikálně; zarovnání dolní‑pravé části a překlopení v obou směrech určuje, jak je opakovaná textura uspořádána.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Možnosti dlaždic](tile-options.png)

## **Plná barva výplně**

Plná výplň dává tvaru jednolitou barvu. Tento příklad nastaví [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na režim plné výplně a přiřadí žlutou barvu pomocí [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), poté uloží obdélník v prezentaci.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Tvar s plnou barvou výplně](solid-color-fill.png)

### **Kopírování barev při zachování odkazů na motiv**

Použijte [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) k kopírování definice barvy včetně jejího typu, odkazu na motiv a transformací. To je užitečné při přenosu výplňové barvy mezi tvary, aby nadále sledovaly motiv prezentace. Metoda kopíruje pouze barvu: nekopíruje typ výplně, obrys ani další formátování tvaru. Nastavte cílový [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) explicitně.

Tento příklad vytváří tři obdélníky, zleva doprava: zdroj, kopii, která respektuje motiv, a pevnou RGB kopii. Zdroj používá [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) k odkazu na první akcentní barvu a přidává tón pomocí [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). RGB kopie používá efektivní výplňovou barvu zdroje, takže všechny tři vypadají zpočátku identicky. Přiřazení [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) nastaví pevnou RGB hodnotu a vymaže jakékoli existující transformace barvy.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Odkazy na motiv sledují novou akcentní barvu; pevná hodnota RGB ne.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Před změnou motivu se všechny tři výplně shodují:

![Zdroj, cíl copy_from a pevný RGB cíl s identickými modrými výplněmi](color-copy-before.png)

Po změně motivu zdroj a kopie respektující motiv následují novou akcentní barvu a zachovávají svůj tón. Pevná RGB kopie zůstává modrá:

![Zdroj a copy_from cíl s oranžovými výplněmi, zatímco pevná RGB výplň zůstává modrá](color-copy-after.png)

Zkopírovaná definice je nezávislá na zdroji. Následná změna odkazu na motiv ve zdroji, přiřazení jiné barvy nebo přidání/odstranění transformací neovlivní cíl. Změna motivu však stále ovlivní oba tvary, protože každý samostatně odkazuje na stejnou barvu motivu.

Uložení a opětovné otevření PPTX zachová [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), odkaz na motiv a kolekci [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/); nevyrovná definici na RGB.

Při kopírování mezi různými kontexty motivu, například mezi prezentacemi s odlišnými akcentními paletami, se odkaz vyhodnocuje podle motivu cíle. Stejný odkaz a transformace tak mohou vést k odlišnému viditelnému odstínu. Viz [Presentation Theme](/slides/cs/python-net/presentation-theme/) pro více informací o konfiguraci barev motivu.

## **Použití pozadí snímku jako výplně tvaru**

Použijte [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nejprve nastavte [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), aby se odstranila jakákoliv explicitní výplň. S tímto nastavením tvar používá pozadí snímku místo vlastní výplně. Zapnutí příznaku samotné neodstraní existující explicitní výplň.

To se liší od [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): výplň pozadím zakrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň umožní viditelnost těchto objektů. Gradient zůstává zarovnán k snímku místo toho, aby se restartoval uvnitř každého tvaru.

Následující příklad vytváří hlavní pozadí zděděné snímkem a umístí magentový pruh za tři obdélníky. Levý obdélník používá pozadí, prostřední nemá výplň a pravý přepíná z výplně pozadím na explicitní oranžovou výplň.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Zdědit gradient z masteru.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Přidejte tento objekt jako první, aby se zobrazil za obdélníky.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Zakázat výplň pozadí před aplikací explicitní výplně.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek, zleva doprava: **výplň pozadím**, **žádná výplň**, a **explicitní výplň**. Magentový pruh je skryt levým a pravým obdélníkem, ale zůstává viditelný skrze prostřední obdélník.

![Výplň pozadím, žádná výplň a explicitní oranžová výplň přes magentový pruh](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozvržení. Tvar používá rozlišené pozadí snímku; příklad ponechává pozadí snímku i rozvržení nedefinována, takže jej dodává hlavní šablona.

## **Nastavení průhlednosti**

U plné výplně řídí alfa‑komponenta barvy neprůhlednost: 0 je zcela průhledná a 255 je zcela neprůhledná. Tento příklad používá alfa‑hodnotu 128 pro žlutý obdélník, což jej činí přibližně 50 % průhledným, takže pod ním zůstává vidět podkladový obdélník. Barva je přiřazena přes [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Rotace tvarů**

Použijte [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) k otočení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otočí obdélník o 5 stupňů po směru hodinových ručiček a uloží prezentaci.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rotace tvaru](shape-rotation.png)

## **Přidání 3D výztužových efektů**

Použijte [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) k dání tvaru hloubky a výztužových hran. Tento příklad vytváří zelenou elipsu s oranžovým obrysem, nastavuje [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) na 4 body a aplikuje kruhovou horní výztuž s šířkou a výškou 6 bodů pomocí [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Frontální ortografická kamera a troj‑bodové osvětlení činí výztuž viditelnou.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![3D výztužový efekt](3D-bevel-effect.png)

## **Přidání 3D rotací**

3D pohled tvaru se řídí nastavením kamery. Tento příklad používá [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) s úhly šířky, výšky a otáčení 40, 35 a 20 stupňů. Vybere izometrickou kameru přes [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) a vyvážené osvětlení přes [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), poté uloží naformátovaný obdélník.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![3D rotace efekt](3D-rotation-effect.png)

## **Ovládání černobílého vykreslování pro tvary**

Vlastnost [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) určuje, jak je jednotlivý tvar vykreslován, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Nepovoluje samotné černobílé zobrazení a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `AUTOMATIC` nechá aplikaci zvolit konverzi, `GRAY` a `LIGHT_GRAY` použijí šedé zbarvení, `BLACK_WHITE` použije pouze černou a bílou, `BLACK` a `WHITE` vynutí jedinou barvu, `COLOR` zachová normální zbarvení a `HIDDEN` vynechá tvar v černobílém režimu. `NOT_DEFINED` znamená, že není přiřazen žádný režim na úrovni tvaru.

Tento příklad vytvoří oranžový obdélník a nastaví [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) na šedou. Uložený tvar si zachová oranžovou výplň pro normální barevný režim a požaduje šedé zbarvení od aplikací, které respektují nastavení černobílého zobrazení:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

V normálním barevném režimu tvar zachovává oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zbarvení, protože jeho režim je nastaven na `GRAY`. To vám umožní zachovat plnobarevný snímek a přitom definovat odlišný vzhled pro tisk, náhled nebo jiné postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Použijte [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) k obnovení pozice, velikosti a formátování zástupných objektů snímku podle odpovídajících zástupných objektů rozvržení. Tento příklad vyžaduje existující prezentaci se zástupnými objekty propojenými s rozvržením a resetuje každý snímek před uložením. Tvary bez odpovídajících zástupných objektů rozvržení nejsou resetovány.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají jen málo dat ve srovnání s vloženými obrázky a médiemi. Obrázkové výplně mohou velikost souboru zvýšit, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru — výplň, čára a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvaru do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při tvorbě nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a znovu použijte jejich formátování tam, kde je potřeba.