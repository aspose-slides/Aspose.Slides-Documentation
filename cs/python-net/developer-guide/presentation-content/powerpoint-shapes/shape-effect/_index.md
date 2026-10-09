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
description: "Přeměňte své soubory PPT, PPTX a ODP pomocí pokročilých efektů tvarů s Aspose.Slides pro Python—vytvořte poutavé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/python-net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Možnosti Preset jsou v podstatě osvědčená kombinace dvou nebo více efektů, která vypadá dobře. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody pod třídou [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Aplikovat efekt stínu**

Aspose.Slides pro Python pomocí .NET podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření, aby odpovídaly designu vaší prezentace.

### **Aplikovat vnější stín**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín se rozšiřuje za okraje tvaru, čímž vytváří dojem, že tvar je nad snímkem. Upravte jeho barvu, směr, vzdálenost a poloměr rozostření, aby odpovídaly osvětlení a stylu vaší šablony.

Tento kód v Pythonu ukazuje, jak aplikovat [vnější efekt stínu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) na obdélník:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Stínový efekt](shadow_effect.png)

### **Aplikovat vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získala zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a způsobuje, že vypadá zdviženě, zatímco vnitřní stín stínuje vnitřek jeho okrajů.

Zavolejte [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), poté nakonfigurujte [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Větší hodnoty poloměru rozostření vytvářejí měkčí okraje.

Tento příklad v Pythonu vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Pro odstranění vnitřního stínu zavolejte [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) na formát efektu tvaru.

## **Aplikovat efekt odrazu**

Pro aplikaci efektu odrazu v Aspose.Slides pro Python pomocí .NET můžete přidat zrcadlový odraz k tvarům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt vylepšuje estetiku vašich prezentací tím, že tvarům dodává hladší a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro jednotný design.

Tento kód v Pythonu ukazuje, jak aplikovat [efekt odrazu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) na tvar:

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

## **Aplikovat efekt záře**

Pro aplikaci efektu záře na tvar v Aspose.Slides pro Python pomocí .NET můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, čímž se zlepšuje celkový vzhled vašich snímků.

Tento kód v Pythonu ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) na tvar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt záře](glow_effect.png)

## **Aplikovat efekt měkkých hran**

Pro aplikaci efektu měkkých hran v Aspose.Slides pro Python pomocí .NET můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr můžete snadno nastavit, abyste dosáhli požadovaného efektu u různých tvarů ve vaší prezentaci.

Tento kód v Pythonu ukazuje, jak aplikovat [měkké hrany](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) na tvar:

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

## **Často kladené otázky**

**Mohu na stejný tvar aplikovat více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.