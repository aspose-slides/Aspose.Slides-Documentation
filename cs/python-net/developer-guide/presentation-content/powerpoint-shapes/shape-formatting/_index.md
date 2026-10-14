---
title: Formátování tvarů PowerPointu v Pythonu
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/python-net/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spojení
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- vykreslování tvaru ve stupních šedi
- otočení tvaru
- 3D ocelový efekt
- 3D rotační efekt
- obnovení formátování
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak formátovat tvary PowerPointu v Pythonu pomocí Aspose.Slides — nastavte výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s precizností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože jsou tvary složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete formátovat tvary nastavením, která řídí, jak jsou vyplněny jejich vnitřky.

![formátování-tvaru-v-powerpointu](format-shape-powerpoint.png)

Aspose.Slides for Python poskytuje třídy a vlastnosti, které umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Postup je následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) tvaru.
1. Nastavte barvu čáry tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v Pythonu ukazuje, jak formátovat obdélník `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Odstraňte výplň z obdélníkového tvaru, aby byly viditelné jen jeho čáry.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Aplikujte formátování na čáry obdélníku.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Nastavte barvu čáry obdélníku.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Uložte soubor PPTX na disk.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použití skicových efektů na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) pro přístup k nastavení čáry, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) pro přístup k nastavení skicu a [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Následující kód v Pythonu ukazuje, jak aplikovat efekt [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Přístup k formátu čáry tvaru a jeho skicovému formátu.
    sketch_format = shape.line_format.sketch_format

    # Aplikujte skicový efekt.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Přečtěte skicový efekt přiřazený přímo tvaru.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Odstraňte skicový efekt.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Hodnota vrácená `SketchFormat.sketch_type` představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), přistupte k vlastnosti `sketch_format` vráceného objektu a přečtěte jeho vlastnost `sketch_type`. Efektivní hodnota odráží formátování, které je skutečně aplikováno po vyřešení dědičnosti:

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

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení, když PowerPoint spojí dvě čáry pod úhlem (například v rohu tvaru), použije nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, může být výhodnější volba **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód v Pythonu ukazuje, jak byly tři obdélníky (jak je vidět na obrázku výše) vytvořeny pomocí nastavení spojení Miter, Bevel a Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

	# Získejte první snímek.
	slide = presentation.slides[0]

	# Přidejte tři automatické tvary typu Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Nastavte barvu výplně pro každý obdélníkový tvar.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Nastavte šířku čáry.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Nastavte barvu čáry pro každý obdélník.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Nastavte styl spoje.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Přidejte text ke každému obdélníku.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Uložte soubor PPTX na disk.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradientní výplň**

V PowerPointu je Gradientní výplň formátovací možnost, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně přecházela do druhé.

Postup pro aplikaci gradientní výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) tvaru na `GRADIENT`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `add` kolekce `gradient_stops`, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v Pythonu ukazuje, jak aplikovat efekt gradientní výplně na elipsu:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Aplikujte gradientní formátování na elipsu.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Nastavte směr gradientu.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Přidejte dva gradientové body.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Uložte soubor PPTX na disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud se gradient v exportovaném obrázku liší od toho v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl renderování, aniž byste měnili gradientní výplň uloženou v prezentaci.

## **Vzorová výplň**

V PowerPointu je Vzorová výplň formátovací možnost, která umožňuje aplikovat dvoubarevný vzor – například tečky, proužky, křížové šrafování nebo šachovnici – na tvar. Můžete si vybrat vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které se mají použít.

Postup pro aplikaci vzorové výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) tvaru na `PATTERN`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) vzoru.
1. Nastavte [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v Pythonu ukazuje, jak aplikovat vzorovou výplň na obdélník:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Nastavte typ výplně na Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Nastavte styl vzoru.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Nastavte barvy pozadí a popředí vzoru.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Uložte soubor PPTX na disk.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Obrázková výplň formátovací možnost, která umožňuje vložit obrázek do tvaru – prakticky použít obrázek jako pozadí tvaru.

Postup pro použití Aspose.Slides k aplikaci obrázkové výplně na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) tvaru na `PICTURE`.
1. Nastavte režim obrázkové výplně na `TILE` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Přiřaďte tento obrázek vlastnosti `picture.image` formátu výplně `picture_fill_format` tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor **lotus.png** s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

Následující kód v Pythonu ukazuje, jak vyplnit tvar obrázkem:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Nastavte typ výplně na Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Nastavte režim obrázkové výplně.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Načtěte obrázek a přidejte jej do zdrojů prezentace.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Nastavte obrázek.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Uložte soubor PPTX na disk.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Obrázek dlaždic jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dláždění, můžete použít následující vlastnosti třídy [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Nastavuje režim obrázkové výplně – `TILE` nebo `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Řídí, zda se dlaždice převrátí horizontálně, vertikálně nebo obojí.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definuje horizontální měřítko dlaždice v procentech.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    first_slide = presentation.slides[0]

    # Přidejte automatický tvar obdélníku.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Nastavte typ výplně tvaru na Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Načtěte obrázek a přidejte jej do zdrojů prezentace.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Přiřaďte obrázek k tvaru.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Nakonfigurujte režim obrázkové výplně a vlastnosti dláždění.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Uložte soubor PPTX na disk.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Možnosti dlaždic](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Jednobarevná výplň formátovací možnost, která vyplní tvar jednou rovnoměrnou barvou. Tento jednoduchý podklad se použije bez gradientů, textur nebo vzorů.

Postup pro aplikaci jednobarevné výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) tvaru na `SOLID`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v Pythonu ukazuje, jak aplikovat jednobarevnou výplň na obdélník v PowerPoint snímku:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Nastavte typ výplně na Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Nastavte barvu výplně.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Uložte soubor PPTX na disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu můžete při použití jednobarevné, gradientní, obrázkové nebo texturové výplně také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že bude tvar více průhledný a podklad nebo podřazené objekty budou částečně viditelné.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte typ výplně na `SOLID`.
1. Použijte `Color.from_argb` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]
    
    # Přidejte automatický obdélníkový tvar s plnou výplní.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Přidejte transparentní obdélníkový automatický tvar nad pevný tvar.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Rotace tvarů**

Aspose.Slides umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovým požadavkem.

Postup pro otočení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte vlastnost `rotation` tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak otočit tvar o 5 stupňů:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Otočte tvar o 5 stupňů.
    shape.rotation = 5

    # Uložte soubor PPTX na disk.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rotace tvaru](shape-rotation.png)

## **Přidání 3D ocelových efektů**

Aspose.Slides umožňuje aplikovat 3D ocelové efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Postup pro přidání 3D ocelových efektů na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) tvaru pro definování nastavení ocelování.
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak aplikovat 3D ocelové efekty na tvar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Přidejte tvar na snímek.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Nastavte vlastnosti ThreeDFormat tvaru.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![3D ocelový efekt](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

Aspose.Slides umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Postup pro aplikaci 3D rotace na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Nastavte [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) a [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) tvaru pro definování 3D rotace.
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak aplikovat 3D rotační efekty na tvar:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Uložte prezentaci jako soubor PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![3D rotační efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování tvarů**

Vlastnost [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Nevytváří černobílý režim sama o sobě a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `AUTOMATIC` nechá aplikaci pro vykreslování zvolit konverzi, `GRAY` a `LIGHT_GRAY` používají šedé odstíny, `BLACK_WHITE` používá pouze černou a bílou, `BLACK` a `WHITE` vynutí jedinou barvu, `COLOR` zachová normální barvy a `HIDDEN` skryje tvar v černobílém režimu. `NOT_DEFINED` znamená, že žádný režim na úrovni tvaru není přiřazen.

Následující kód v Pythonu vytvoří barevný tvar a zpřístupní jej šedě v černobílém režimu zobrazení:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Zachovejte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

V normálním barevném režimu si obdélník ponechává oranžovou výplň. V černobílém pracovním postupu se zobrazí šedě, protože jeho režim je nastaven na `GRAY`. To vám umožní zachovat plnofarebný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Následující kód v Pythonu ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů s místodržci na [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Resetujte každý tvar na snímku, který má placeholder v rozložení.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze mírně. Vložené obrázky a média zaujímají většinu místa, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a prakticky nezvětšují velikost souboru.

**Jak mohu detekovat tvary na snímku, které mají totožné formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v dalších prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly v šabloně snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, naklonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je potřeba.