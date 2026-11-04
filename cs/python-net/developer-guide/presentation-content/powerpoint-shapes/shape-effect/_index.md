---
title: Aplikace efektů tvarů v prezentacích pomocí Pythonu
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/python-net/shape-effect
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přeměňte své soubory PPT, PPTX a ODP pomocí pokročilých efektů tvarů s Aspose.Slides pro Python — vytvořte poutavé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/python-net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze aplikovat na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Možnosti Preset jsou v podstatě osvědčená kombinace dvou nebo více efektů. Tím, že vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití efektu stínu**

Aspose.Slides pro Python via .NET podporuje vnější i vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikl proti pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar zvednutý nad snímek. Nastavte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby ladily s osvětlením a stylem vaší šablony.

Tento kód v Pythonu ukazuje, jak aplikovat [vnější efekt stínu](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) na obdélník:

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

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získal zapuštěný vzhled. Vnější stín se rozšiřuje mimo tvar a činí ho vypadajícím jako zvednutý, zatímco vnitřní stín stínuje vnitřní část jeho okrajů.

Zavolejte [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), poté nakonfigurujte [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Větší hodnoty poloměru rozostření produkují měkčí hrany.

Tento příklad v Pythonu vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

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

Chcete‑li odstranit vnitřní stín, zavolejte [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) na formát efektu tvaru.

## **Použití efektu odrazu**

Pro použití efektu odrazu v Aspose.Slides pro Python via .NET můžete přidat zrcadlový odraz k tvarům, upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvarům dodává uhlazenější a sofistikovanější vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro jednotný design.

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

## **Použití efektu záře**

Pro použití efektu záře na tvar v Aspose.Slides pro Python via .NET můžete přidat jemnou, svítící aurou kolem tvarů, upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek vaší prezentaci. Je snadno realizovatelný s minimálním množstvím kódu, čímž zlepšuje celkový vzhled vašich snímků.

Tento kód v Pythonu ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) na tvar:

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

## **Použití efektu měkkých okrajů**

Pro použití efektu měkkých okrajů v Aspose.Slides pro Python via .NET můžete vytvořit plynulý, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr lze snadno upravit tak, aby se dosáhlo požadovaného efektu napříč různými tvary ve vaší prezentaci.

Tento kód v Pythonu ukazuje, jak aplikovat [měkké okraje](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) na tvar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt měkkých okrajů](soft_edges_effect.png)

## **Použití efektu rozostření**

Použijte rozostření tvaru ke změkčení výplně a obrysu tvaru při zachování možnosti úpravy tvaru. Zavolejte [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty způsobují silnější rozostření. Poloměr nula ponechává vzhled nezměněný.

Nastavení [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) řídí viditelné hranice efektu. S hodnotou `False` je rozostření oříznuto na původní nakreslené hranice, včetně obrysu. S hodnotou `True` může rozostření přesahovat za tyto hranice. Žádné z nastavení nemění pozici ani rozměry tvaru.

Porovnání níže používá stejnou výplň, obrys a rozměry tvaru v celém průběhu. Horní řada používá `grow = False`; spodní řada používá `grow = True`.

![Původní obdélník porovnán s rozostřením 5 a 15 bodů, s vypnutým a zapnutým grow](shape_blur_comparison.png)

Tento příklad v Pythonu vytvoří oranžový obdélník s tmavě modrým obrysem, použije rozostření 5 bodů a poté jej aktualizuje na rozostření 15 bodů opětovným zavoláním [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Uloží oba rozostřené stavy, pak zavolá [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) a uloží tvar bez rozostření.

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

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých okrajů ztmavne hrany tvaru, zatímco rozostření stínu změkčuje pouze stín. Efekty transformace obrazu operují na obsahu obrazu; tento příklad aplikuje rozostření přímo na formát efektu tvaru bez převodu tvaru na obrázek.

## **Často kladené otázky**

**Mohu použít více efektů na stejném tvaru?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru pro dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete aplikovat na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.