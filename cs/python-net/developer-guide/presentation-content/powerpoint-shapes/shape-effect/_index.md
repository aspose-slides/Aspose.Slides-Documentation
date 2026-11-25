---
title: Použití efektů tvarů v prezentacích s Pythonem
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/python-net/shape-effect
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přetvořte své soubory PPT, PPTX a ODP pomocí pokročilých efektů tvarů s Aspose.Slides pro Python — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/python-net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Volby Preset jsou v podstatě osvědčená kombinace dvou nebo více efektů, která vypadá dobře. Tímto způsobem, když vyberete přednastavení, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), které vám umožní aplikovat stejné efekty na tvary v prezentacích PowerPoint.

## **Použití efektu stínu**

Aspose.Slides pro Python přes .NET podporuje vnější a vnitřní stíny pro tvary. Můžete upravit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Aplikace vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín se rozprostírá za okraje tvaru a vytváří dojem, že tvar je nad snímkem. Upravením jeho barvy, směru, vzdálenosti a poloměru rozostření přizpůsobíte osvětlení a styl šablony.

Tento Python kód ukazuje, jak aplikovat [vnější efekt stínu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) na obdélník:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt stínu](shadow_effect.png)

### **Aplikace vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získala zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a vytváří dojem vyvýšeného, zatímco vnitřní stín zalamuje vnitřní stranu jeho okrajů.

Volejte [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), pak nakonfigurujte [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Větší hodnoty poloměru rozostření produkují měkčí okraje.

Tento Python příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Pro odebrání vnitřního stínu zavolejte [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) na formátu efektu tvaru.

### **Aplikace, změna a odebrání přednastaveného stínu**

Zavolejte [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) a nastavte vlastnost [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) stínu na hodnotu typu [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Pro změnu stylu změňte přednastavení na stejném tvaru. Zavolejte [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) aby se odebral stín, přičemž zůstane zachováno vyplnění a obrys.

Tento příklad ukazuje čtyři fáze vedle sebe na jednom snímku. Před každou změnou duplikuje obdélník, abyste mohli porovnat výsledky. Oba stíny jsou posunuty o 10 bodů. Směr 225° umístí první stín nad a vlevo od obdélníku, a 45° umístí druhý pod a vpravo.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillFormat.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Originál | První přednastavení | Druhé přednastavení | Po odebrání |
| :---: | :---: | :---: | :---: |
| ![Bez stínu](preset_shadow_original.png) | ![Stín vlevo nahoře](preset_shadow_top_left.png) | ![Stín vpravo dole](preset_shadow_bottom_right.png) | ![Žádný stín po odebrání](preset_shadow_removed.png) |

## **Použití efektu odrazu**

Pro použití efektu odrazu v Aspose.Slides pro Python přes .NET můžete přidat zrcadlový odraz na tvary a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt vylepšuje estetiku vašich prezentací tím, že tvary získají hladší a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití na více prvcích pro jednotný design.

Tento Python kód ukazuje, jak aplikovat [efekt odrazu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) na tvar:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt odrazu](reflection_effect.png)

## **Použití efektu záře**

Pro použití efektu záře na tvar v Aspose.Slides pro Python přes .NET můžete přidat měkkou, zářivou aurou kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, což zlepšuje celkový vzhled vašich snímků.

Tento Python kód ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) na tvar:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt záře](glow_effect.png)

## **Použití efektu měkkých hran**

Pro použití efektu měkkých hran v Aspose.Slides pro Python přes .NET můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Můžete snadno upravit parametry jako poloměr, abyste dosáhli požadovaného efektu na různých tvarech v prezentaci.

Tento Python kód ukazuje, jak aplikovat [měkké hrany](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) na tvar:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt měkkých hran](soft_edges_effect.png)

## **Použití efektu rozostření**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru při zachování možnosti editace tvaru. Zavolejte [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž vyšší hodnoty vytvářejí silnější rozostření. Poloměr nula ponechá vzhled beze změny.

Nastavení [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) řídí viditelné hranice efektu. S `False` je rozostření oříznuto na původní natřenou oblast, včetně obrysu. S `True` může rozostření přesáhnout tyto hranice. Žádné z nastavení nemění pozici ani rozměry tvaru.

Porovnání níže používá stejnou výplň, obrys a rozměry tvaru po celou dobu. Horní řada používá `grow = False`; spodní řada používá `grow = True`.

![Původní obdélník porovnán s poloměry rozostření 5 a 15 bodů, s vypnutým a zapnutým grow](shape_blur_comparison.png)

Tento Python příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije 5‑bodové rozostření a poté jej aktualizuje na 15‑bodové rozostření voláním [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) znovu. Uloží oba rozostřené stavy, pak zavolá [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) a uloží tvar bez rozostření.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých hran zeslabuje okraje tvaru, zatímco rozostření stínu zeslabuje pouze stín. Efekty transformace obrazu působí na obsah obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru bez převodu tvaru na obrázek.

## **Často kladené otázky**

**Mohu na stejný tvar aplikovat více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jediný tvar a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete aplikovat na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se aplikuje na celou skupinu.