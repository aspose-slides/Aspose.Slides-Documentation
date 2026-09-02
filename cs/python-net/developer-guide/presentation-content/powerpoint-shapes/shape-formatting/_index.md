---
title: Formátování objektů PowerPoint v Pythonu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/python-net/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spojení
- gradientové vyplnění
- vzorové vyplnění
- obrázkové vyplnění
- texturové vyplnění
- jednobarevné vyplnění
- průhlednost tvaru
- černobílé vykreslování tvaru
- vykreslování tvaru ve stupních šedi
- otočení tvaru
- 3D zkosený efekt
- 3D rotační efekt
- resetování formátování
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak v Pythonu pomocí Aspose.Slides formátovat objekty PowerPoint – nastavte styl výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat objekty. Protože objekty jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete objekty formátovat zadáním nastavení, která řídí, jak jsou jejich vnitřní oblasti vyplněny.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python poskytuje třídy a vlastnosti, které vám umožňují formátovat objekty pomocí stejných možností, které jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro objekt určit vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte [line style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linestyle/) objektu.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linedashstyle/) objektu.
1. Nastavte barvu čáry pro objekt.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód demonstruje, jak formátovat obdélníkový `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která reprezentuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Odeberte výplň z obdélníkového tvaru, aby byly viditelné pouze jeho čáry.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Použijte formátování na čáry obdélníku.
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

## **Použití skicových efektů na čáry objektu**

Skicový efekt způsobí, že čára objektu vypadá ručně kresleně. Použijte [Shape.line_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/line_format/) k přístupu k nastavením čáry, [LineFormat.sketch_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/lineformat/sketch_format/) k přístupu ke skicovým nastavením a [SketchFormat.sketch_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sketchformat/sketch_type/) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linesketchtype/) .

Následující Python kód ukazuje, jak aplikovat efekt [LineSketchType.CURVED](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.NONE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/linesketchtype/) :

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

Hodnota vrácená `SketchFormat.sketch_type` představuje nastavení přiřazené přímo objektu. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [LineFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/lineformat/get_effective/), přistupte k vlastnosti `sketch_format` vráceného objektu a přečtěte jeho `sketch_type`. Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

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

* Zaoblený
* Miter
* Bevel

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například na rohu objektu) používá nastavení **Zaoblený**. Pokud však kreslíte objekt s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styly spojení v prezentaci](join-style-powerpoint.png)

Následující Python kód demonstruje, jak byly tři obdélníky (jak je znázorněno na obrázku výše) vytvořeny pomocí nastavení spojení Miter, Bevel a Zaoblený:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

	# Získejte první snímek.
	slide = presentation.slides[0]

	# Přidejte tři automatické tvary typu Obdélník.
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

## **Gradientové vyplnění**

V PowerPointu je Gradient Fill formátovací možnost, která umožňuje aplikovat plynulý přechod barev na objekt. Například můžete použít dvě nebo více barev tak, aby jedna postupně přecházela v druhou.

Postup aplikace gradientového vyplnění na objekt pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) objektu na `GRADIENT`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `add` kolekce `gradient_stops`, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/gradientformat/) .
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód demonstruje, jak aplikovat gradientový efekt na elipsu:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Elipsa.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Aplikujte gradientové formátování na elipsu.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Nastavte směr gradientu.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Přidejte dva gradientové zastavení.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Uložte soubor PPTX na disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Elipsa s gradientovým vyplněním](gradient-fill.png)

## **Vzorkové vyplnění**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožňuje aplikovat dvoubarevný design – například tečky, proužky, křížové šrafování nebo šachovnici – na objekt. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides nabízí více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na objekty a zvýšit tak vizuální atraktivitu vašich prezentací. I po výběru předdefinovaného vzoru můžete ještě určit přesné barvy, které má použít.

Postup aplikace vzorového vyplnění na objekt pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) objektu na `PATTERN`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [back_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternformat/back_color/) vzoru.
1. Nastavte [fore_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternformat/fore_color/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód demonstruje, jak aplikovat vzorové vyplnění na obdélník:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Obdélník.
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

![Obdélník s vzorkovým vyplněním](pattern-fill.png)

## **Obrázkové vyplnění**

V PowerPointu je Picture Fill formátovací možnost, která vám umožňuje vložit obrázek uvnitř objektu – efektivně používá obrázek jako pozadí objektu.

Postup použití Aspose.Slides pro aplikaci obrázkového vyplnění na objekt:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) objektu na `PICTURE`.
1. Nastavte režim obrázkového vyplnění na `TILE` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Přiřaďte tento obrázek vlastnosti `picture.image` formátu `picture_fill_format` objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Řekněme, že máme soubor "lotus.png" s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

Následující Python kód demonstruje, jak vyplnit objekt obrázkem:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Nastavte typ výplně na obrázek.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Nastavte režim vyplnění obrázkem.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Načtěte obrázek a přidejte jej k prostředkům prezentace.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Nastavte obrázek.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Uložte soubor PPTX na disk.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Objekt s obrázkovým vyplněním](picture-fill.png)

### **Dlaždicový obrázek jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující vlastnosti třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Nastavuje režim obrázkového vyplnění – buď `TILE`, nebo `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_alignment/): Určuje zarovnání dlaždic uvnitř objektu.
- [tile_flip](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_flip/): Řídí, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [tile_offset_x](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_offset_x/): Nastavuje horizontální posun dlaždice (v bodech) od počátku objektu.
- [tile_offset_y](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_offset_y/): Nastavuje vertikální posun dlaždice (v bodech) od počátku objektu.
- [tile_scale_x](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definuje horizontální měřítko dlaždice v procentech.
- [tile_scale_y](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázkový kód ukazuje, jak přidat obdélníkový objekt s dlaždicovým obrázkovým vyplněním a nakonfigurovat možnosti dlaždic:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    first_slide = presentation.slides[0]

    # Přidejte automatický tvar typu Obdélník.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Nastavte typ výplně objektu na obrázek.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Načtěte obrázek a přidejte jej k prostředkům prezentace.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Přiřaďte obrázek objektu.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Nakonfigurujte režim vyplnění obrázkem a vlastnosti dlaždicování.
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

## **Jednobarevné vyplnění**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní objekt jednou, jednotnou barvou. Tato plná barva pozadí se použije bez gradientů, textur nebo vzorů.

Pro použití jednobarevného vyplnění na objekt pomocí Aspose.Slides postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) objektu na `SOLID`.
1. Přiřaďte požadovanou barvu výplně objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód demonstruje, jak aplikovat jednobarevné vyplnění na obdélník v PowerPoint snímku:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Nastavte typ výplně na Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Nastavte barvu výplně.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Uložte soubor PPTX na disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Objekt s jednobarevným vyplněním](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když na objektech použijete jednobarevné, gradientové, obrázkové nebo texturové vyplnění, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že objekt bude průhlednější, což umožní částečný náhled pozadí nebo podkladových objektů.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte typ výplně na `SOLID`.
1. Použijte `Color.from_argb` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující Python kód demonstruje, jak aplikovat průhlednou barvu výplně na obdélník:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]
    
    # Přidejte automatický tvar typu Obdélník s plnou výplní.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Přidejte průhledný obdélníkový automatický tvar nad plný tvar.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný objekt](shape-transparency.png)

## **Otáčení objektů**

Aspose.Slides umožňuje otáčet objekty v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétními požadavky na zarovnání nebo design.

Pro otáčení objektu na snímku postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte vlastnost `rotation` objektu na požadovaný úhel.
1. Uložte prezentaci.

Následující Python kód demonstruje otáčení objektu o 5 stupňů:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Otočte tvar o 5 stupňů.
    shape.rotation = 5

    # Uložte soubor PPTX na disk.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Otáčení objektu](shape-rotation.png)

## **Přidání 3D zkosených efektů**

Aspose.Slides umožňuje aplikovat 3D zkosené efekty na objekty konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/) .

Pro přidání 3D zkosených efektů na objekt postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/) objektu a definujte nastavení zkosení.
1. Uložte prezentaci.

Následující Python kód ukazuje, jak aplikovat 3D zkosené efekty na objekt:

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

    # Nastavte vlastnosti ThreeDFormat objektu.
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

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

Aspose.Slides umožňuje aplikovat 3D rotační efekty na objekty konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/) .

Pro aplikaci 3D rotace na objekt:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) .
1. Nastavte [camera_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/camera/camera_type/) a [light_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/lightrig/light_type/) objektu pro definování 3D rotace.
1. Uložte prezentaci.

Následující Python kód demonstruje, jak aplikovat 3D rotační efekty na objekt:

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

## **Řízení černobílého vykreslování objektů**

Vlastnost [Shape.black_white_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/black_white_mode/) určuje, jak je jednotlivý objekt vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Nezapíná černobílý režim samotný a nemění výplň, čáru ani jiné formátování objektu v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `AUTOMATIC` nechá aplikaci pro vykreslování zvolit konverzi, `GRAY` a `LIGHT_GRAY` používají šedé zabarvení, `BLACK_WHITE` používá pouze černou a bílou, `BLACK` a `WHITE` vynutí jedinou barvu, `COLOR` zachová normální barvy a `HIDDEN` vynechá objekt v černobílém režimu. `NOT_DEFINED` znamená, že žádný režim na úrovni objektu není přiřazen.

Následující Python kód vytvoří barevný objekt a způsobí, že se v černobílém režimu zobrazí šedě:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Zachovejte oranžovou výplň v barevném režimu, ale vykreslete objekt se šedým zabarvením v černobílém režimu.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

V normálním barevném režimu si obdélník ponechává oranžovou výplň. V pracovním postupu s černobílým zobrazením používá šedé zabarvení, protože jeho režim je nastaven na `GRAY`. To vám umožní zachovat plnofarebný snímek a současně definovat odlišný vzhled pro tisk, náhled nebo jiné workflow, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Následující Python kód ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech objektů s zástupci na [LayoutSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/) do výchozího nastavení:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Resetujte každý objekt na snímku, který má zástupce v rozložení.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ovlivňuje formátování objektů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry objektů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a téměř nepřidávají žádnou velikost.

**Jak mohu detekovat objekty na snímku, které sdílejí identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého objektu – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což zjednoduší následnou správu stylů.

**Mohu uložit sadu vlastních stylů objektů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové objekty s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte stylované objekty, které potřebujete, a znovu aplikujte jejich formátování podle potřeby.