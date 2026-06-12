---
title: Formátování tvarů PowerPoint v Pythonu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/python-net/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- formátování stylu spojení
- gradientová výplň
- vzorkovaná výplň
- obrázková výplň
- texturovaná výplň
- jednobarevná výplň
- průhlednost tvaru
- otočení tvaru
- 3D zkosený efekt
- 3D otáčecí efekt
- resetování formátování
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak formátovat tvary PowerPointu v Pythonu pomocí Aspose.Slides — nastavte styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Jelikož jsou tvary složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysy. Navíc můžete formátovat tvary nastavením, které řídí, jak jsou jejich vnitřky vyplněny.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python poskytuje třídy a vlastnosti, které vám umožní formátovat tvary pomocí stejných možností, které jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte [line style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linestyle/) tvaru.
5. Nastavte šířku čáry.
6. Nastavte [dash style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linedashstyle/) tvaru.
7. Nastavte barvu čáry pro tvar.
8. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód ukazuje, jak naformátovat obdélníkový `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Nastavte barvu výplně pro tvar obdélníku.
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

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení PowerPoint spojuje dvě čáry pod úhlem (například v rohu tvaru) pomocí nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující Python kód ukazuje, jak byly tři obdélníky (jak je vidět na obrázku výše) vytvořeny pomocí nastavení typu spojení Miter, Bevel a Round:

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

	# Nastavte styl spojení.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Přidejte text do každého obdélníku.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Uložte soubor PPTX na disk.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradientová výplň**

V PowerPointu je Gradientová výplň formátovací možnost, která vám umožní aplikovat plynulé přechody barev na tvar. Například můžete použít dvě nebo více barev tak, že jedna postupně přechází v druhou.

Zde je postup, jak pomocí Aspose.Slides aplikovat gradientovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) tvaru na `GRADIENT`.
5. Přidejte své dva preferované barvy s definovanými pozicemi pomocí metod `add` kolekce `gradient_stops`, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/gradientformat/).
6. Uložte upravenou prezentaci jako soubor PPTX.

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Aplikujte gradientové formátování na elipsu.
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

![Elipsa s gradientovou výplní](gradient-fill.png)

## **Vzorkovaná výplň**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožní aplikovat dvoubarevný design – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzoru, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu vašich prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které se mají použít.

Zde je postup, jak pomocí Aspose.Slides aplikovat vzorkovanou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) tvaru na `PATTERN`.
5. Vyberte styl vzoru z předdefinovaných možností.
6. Nastavte [back_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternformat/back_color/) vzoru.
7. Nastavte [fore_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternformat/fore_color/) vzoru.
8. Uložte upravenou prezentaci jako soubor PPTX.

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

![Obdélník s vzorkovanou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Picture Fill formátovací možnost, která vám umožní vložit obrázek do tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je postup, jak pomocí Aspose.Slides aplikovat obrázkovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) tvaru na `PICTURE`.
5. Nastavte režim obrázkové výplně na `TILE` (nebo jiný preferovaný režim).
6. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) z obrázku, který chcete použít.
7. Přiřaďte tento obrázek k vlastnosti `picture.image` objektu `picture_fill_format` tvaru.
8. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor "lotus.png" s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

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

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit obrázek jako dlaždicovanou texturu a přizpůsobit chování dlaždicování, můžete použít následující vlastnosti třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Nastavuje režim obrázkové výplně – `TILE` nebo `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_alignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [tile_flip](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_flip/): Řídí, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [tile_offset_x](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_offset_x/): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [tile_offset_y](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_offset_y/): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [tile_scale_x](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definuje horizontální měřítko dlaždice v procentech.
- [tile_scale_y](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovanou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

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

    # Nakonfigurujte režim obrázkové výplně a vlastnosti dlaždicování.
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

![Možnosti dlaždicování](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tato jednobarevná pozadí se použije bez gradientů, textur ani vzorů.

Zde je postup, jak pomocí Aspose.Slides aplikovat jednobarevnou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) tvaru na `SOLID`.
5. Přiřaďte požadovanou barvu výplně tvaru.
6. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód ukazuje, jak aplikovat jednobarevnou výplň na obdélník v PowerPoint snímku:

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

V PowerPointu, když na tvary použijete jednobarevnou, gradientovou, obrázkovou nebo texturovanou výplň, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průhledný, což umožní viditelnost pozadí nebo podkladových objektů.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Zde je postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte typ výplně na `SOLID`.
5. Použijte `Color.from_argb` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
6. Uložte prezentaci.

Následující Python kód ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]
    
    # Přidejte plný obdélníkový automatický tvar.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Přidejte průhledný obdélníkový automatický tvar nad pevný tvar.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Pro otáčení tvaru na snímku postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte vlastnost `rotation` tvaru na požadovaný úhel.
5. Uložte prezentaci.

Následující Python kód ukazuje, jak otočit tvar o 5 stupňů:

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

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D zkosených efektů**

Aspose.Slides umožňuje aplikovat 3D zkosené efekty na tvary nastavením jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/).

Pro přidání 3D zkosených efektů na tvar postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
5. Uložte prezentaci.

Následující Python kód ukazuje, jak aplikovat 3D zkosené efekty na tvar:

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

![3D zkosený efekt](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

Aspose.Slides umožňuje aplikovat 3D otáčecí efekty na tvary nastavením jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/).

Pro aplikaci 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte [camera_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/camera/camera_type/) a [light_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/lightrig/light_type/) tvaru pro definování 3D otáčení.
5. Uložte prezentaci.

Následující Python kód ukazuje, jak aplikovat 3D otáčecí efekty na tvar:

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

![3D otáčecí efekt](3D-rotation-effect.png)

## **Resetování formátování**

Následující Python kód ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Resetujte každý tvar na snímku, který má zástupný prvek v rozložení.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a téměř nepřidávají žádnou velikost.

**Jak mohu na snímku zjistit tvary, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se shodují všechny odpovídající hodnoty, považujte jejich styl za identický a logicky seskupte tyto tvary, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opakované použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu použijte jejich formátování podle potřeby.