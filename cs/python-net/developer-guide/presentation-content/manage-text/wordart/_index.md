---
title: Vytvoření a aplikace efektů WordArt v Pythonu
linktitle: WordArt
type: docs
weight: 110
url: /cs/python-net/wordart/
keywords:
- WordArt
- vytvořit WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt odrazu
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- Python
- Aspose.Slides
description: "Vytvořte a přizpůsobte efekty WordArt v Aspose.Slides pro Python via .NET. Tento krok za krokem průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v Pythonu."
---
## **Přehled**

Efekty WordArt vám umožňují stylizovat text pomocí výplní, obrysů, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvořit a přizpůsobit tyto efekty v prezentacích PowerPoint pomocí Aspose.Slides for Python via .NET, aniž by byl nainstalován Microsoft Office.

## **Vytvoření jednoduché šablony WordArt a její aplikace na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, písma, vzorové výplně a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na její první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na "Aspose.Slides". Pozice a rozměry tvaru jsou měřeny v bodech:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Nastavte písmo na Arial Black o velikosti 36 bodů, aby bylo formátování výraznější:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Použijte vzor [SMALL_GRID](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternstyle/) s tmavě oranžovým popředím a bílým pozadím a poté přidejte černý obrys textu o šířce 1 bod:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použití dalších efektů WordArt**

Následující příklady ukazují, jak na text aplikovat stíny, odrazy, záři, transformace a 3D efekty.

### **Aplikace vnějšího stínu**

Vnější stín přidává hloubku umístěním stínu za text. Můžete upravit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [enable_outer_shadow_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) a nastaví černý stín s poloměrem rozostření 4 body, směrem 230 stupňů a vzdáleností 30 bodů. Hodnota měřítka 100 zachovává velikost stínu, zatímco vodorovné zkosení ho nakloní o 20 stupňů. Alfa transformace nastaví jeho neprůhlednost na 32 %:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Když jsou použity současně vnější a předdefinované stíny, použije se pouze vnější stín.
- Pokud jsou použity současně vnější a vnitřní stíny, výsledný efekt závisí na verzi PowerPointu. Například v PowerPointu 2013 je efekt zdvojený, zatímco v PowerPointu 2007 se použije pouze vnější stín.
{{% /alert %}}

### **Aplikace odrazu**

Odraz vytváří zrcadlovou kopii textu. Nastavením jeho polohy, měřítka, rozostření a neprůhlednosti můžete ovlivnit jeho vzhled.

Tento příklad volá [enable_reflection_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/effectformat/enable_reflection_effect/) a převrátí odraz vertikálně se skalou -100 %. Používá poloměr rozostření 0,5 bodu a vzdálenost 4,72 bodu. Neprůhlednost klesá z 60 % na 0,9 % mezi pozicemi 0 % a 60 % podél odrazu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

![Efekt odrazu](reflection_effect.png)

### **Aplikace záře**

Záře přidává jemný barevný obrys kolem textu. Nastavením barvy, neprůhlednosti a poloměru můžete efekt ovládat.

Tento příklad volá [enable_glow_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/effectformat/enable_glow_effect/) a používá červenou záři s neprůhledností 54 % a poloměrem 7 bodů:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

![Efekt záře](glow_effect.png)

### **Aplikace transformací WordArt**

Transformace WordArt ohýbají, roztačují nebo deformují blok textu.

Nastavte [transform](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/transform/) na [ARCH_UP_POUR](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textshapetype/), aby se celý textový rámec zakřivil směrem vzhůru:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

![Transformace WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Aplikace 3D efektů na tvary a text**

Můžete aplikovat 3D efekty na tvar nebo na jeho text. Lisy, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/) k přidání kulatých listů, oranžové extruze a tmavě červeného konturu k obdélníku. Rozměry listu, výška extruze, šířka konturu a hloubka jsou měřeny v bodech. Plastový materiál, vyvážené osvětlení otočené o 40 stupňů kolem osy Z a perspektivní kamera definují jeho vzhled:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

![3D efekt tvaru](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/three_d_format/). Menší listy tvarují hrany písmen, zatímco extruze a osvětlení dávají textu hloubku:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Aplikace 3D efektů na text nebo jejich tvary — a interakce mezi těmito efekty — je řízena specifickými pravidly. Zvažte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena pro jak tvar, tak text, scéna tvaru má přednost a scéna textu je ignorována.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se aplikuje pouze na text.

Tyto chování se vztahují k vlastnostem [ThreeDFormat.light_rig](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/light_rig/) a [ThreeDFormat.camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Chcete-li zachovat text plochý a čitelný při zachování 3D formátování tvaru, podívejte se na [Keep Text Flat on a 3D Shape](/slides/cs/python-net/3d-presentation/) pro srovnání obou nastavení a kompletní Python příklad.

## **Často kladené otázky**

**Mohu používat efekty WordArt s různými fonty nebo písmy (např. arabské, čínské)?**

Ano, Aspose.Slides for Python via .NET podporuje Unicode a funguje se všemi hlavními fonty a písmy. Efekty WordArt, jako jsou stín, výplň a obrys, lze použít bez ohledu na jazyk, i když dostupnost fontů a vykreslování mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky master snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v master snímcích, včetně zástupců titulů, zápatí nebo textu na pozadí. Změny provedené v master rozložení se projeví ve všech přidružených snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientní výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek efektů WordArt bez uložení prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [Slide.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/), nebo vykreslit jednotlivé tvary pomocí [Shape.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/). To vám umožní prohlédnout výsledek v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.