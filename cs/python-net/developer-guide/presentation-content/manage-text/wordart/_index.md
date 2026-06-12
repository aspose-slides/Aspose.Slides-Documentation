---
title: Vytvořte a použijte efekty WordArt v Pythonu
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
- efekt zobrazení
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- Python
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat efekty WordArt v Aspose.Slides for Python via .NET. Tento krok za krokem průvodce pomáhá vývojářům vylepšit prezentace stylovým, profesionálním textem v Pythonu."
---
## **Overview**

Efekty WordArt vám umožňují přidávat vizuálně atraktivní, stylizovaný text do vašich prezentací PowerPoint. S Aspose.Slides mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint—bez nutnosti instalace Office. Tento článek poskytuje přehled práce s WordArtem, včetně toho, jak aplikovat transformace textu, výplňové styly, obrysy, stíny a další možnosti formátování, aby byl obsah prezentace výražnější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo výraznější.

**WordArt v Microsoft PowerPoint**

Chcete-li použít WordArt v Microsoft PowerPoint, musíte vybrat jednu z předdefinovaných šablon WordArt. Šablona WordArt je sada efektů, které se aplikují na text nebo jeho tvar.

**WordArt v Aspose.Slides**

V Aspose.Slides for Python via .NET 20.10 jsme implementovali podporu pro WordArt a v následných vydáních Aspose.Slides for Python via .NET jsme funkci vylepšovali.  
S Aspose.Slides for Python via .NET můžete snadno v Pythonu vytvořit vlastní šablonu WordArt (jednotlivý efekt nebo kombinaci efektů) a použít ji na texty.

## Vytvoření jednoduché šablony WordArt a její použití na text

**Použití Aspose.Slides** 

Nejprve vytvoříme jednoduchý text pomocí tohoto Python kódu: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Nyní nastavíme výšku písma textu na vyšší hodnotu, aby byl efekt výraznější, pomocí tohoto kódu:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Použití Microsoft PowerPoint**

Přejděte do nabídky efektů WordArt v Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

V nabídce vpravo můžete vybrat předdefinovaný efekt WordArt. V nabídce vlevo můžete zadat nastavení pro nový WordArt.  

Níže jsou některé z dostupných parametrů nebo možností:

![todo:image_alt_text](image-20200930114015-3.png)

**Použití Aspose.Slides**

Zde aplikujeme barvu vzoru SmallGrid na text a pomocí tohoto kódu přidáme černý okraj textu o šířce 1.

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Výsledný text:

![todo:image_alt_text](image-20200930114108-4.png)

## Použití dalších efektů WordArt

**Použití Microsoft PowerPoint**

Z rozhraní programu můžete tyto efekty aplikovat na text, textový blok, tvar nebo podobný prvek:

![todo:image_alt_text](image-20200930114129-5.png)

Například efekty Stín, Odraz a Záření lze použít na text; efekty 3D Formát a 3D Rotace lze použít na textový blok; vlastnost Měkké hrany lze použít na objekt tvaru (má účinek i když není nastavena žádná vlastnost 3D Formát).

### Aplikace stínových efektů

Zde zamýšlíme nastavit vlastnosti vztahující se pouze k textu. Stínový efekt na text aplikujeme pomocí tohoto kódu v Pythonu:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

API Aspose.Slides podporuje tři typy stínů: OuterShadow, InnerShadow a PresetShadow.  
S PresetShadow můžete aplikovat stín na text (použitím předdefinovaných hodnot).

**Použití Microsoft PowerPoint**

V PowerPointu můžete použít jeden typ stínu. Zde je příklad:

![todo:image_alt_text](image-20200930114225-6.png)

**Použití Aspose.Slides**

Aspose.Slides ve skutečnosti umožňuje aplikovat dva typy stínů najednou: InnerShadow a PresetShadow.

**Poznámky:**
- Když jsou použity OuterShadow a PresetShadow společně, použije se pouze efekt OuterShadow.  
- Pokud jsou OuterShadow a InnerShadow použity zároveň, výsledný nebo aplikovaný efekt závisí na verzi PowerPointu. Například v PowerPointu 2013 se efekt zdvojnásobí. V PowerPointu 2007 se použije efekt OuterShadow.

### Aplikace zobrazení na texty

Přidáme zobrazení k textu pomocí tohoto ukázkového kódu v Pythonu:

```py 
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

### Aplikace zářivého efektu na texty

Použijeme zářivý efekt na text, aby zazářil nebo vynikl, pomocí tohoto kódu:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Výsledek operace:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Můžete měnit parametry pro stín, zobrazení a záření. Vlastnosti efektů jsou nastaveny na každou část textu samostatně. 
{{% /alert %}} 

### Použití transformací ve WordArt

Použijeme vlastnost Transform (platnou pro celý blok textu) pomocí tohoto kódu:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Výsledek:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Jak Microsoft PowerPoint, tak Aspose.Slides for Python via .NET nabízejí určitý počet předdefinovaných typů transformací. 
{{% /alert %}} 

**Použití PowerPoint**

Pro přístup k předdefinovaným typům transformací přejděte na: **Format** -> **TextEffect** -> **Transform**

**Použití Aspose.Slides**

Pro výběr typu transformace použijte výčtový typ TextShapeType.

### Aplikace 3D efektů na texty a tvary

Nastavíme 3D efekt na textový tvar pomocí tohoto ukázkového kódu:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Výsledný text a jeho tvar:

![todo:image_alt_text](image-20200930114816-9.png)

Na text aplikujeme 3D efekt pomocí tohoto Python kódu:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Výsledek operace:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Použití 3D efektů na texty nebo jejich tvary a interakce mezi efekty se řídí určitými pravidly.

Zvažte scénu pro text a tvar, který text obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, na které je objekt umístěn.

- Když je scéna nastavena jak pro objekt, tak pro text, má scéna objektu vyšší prioritu – scéna textu je ignorována.  
- Když objekt nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.  
- Jinak—pokud tvar původně nemá 3D efekt—tvar je plochý a 3D efekt se aplikuje pouze na text.

Popisy jsou spojeny s vlastnostmi [ThreeDFormat.LightRig](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/) a [ThreeDFormat.Camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/). 
{{% /alert %}} 

## **Použití vnějších stínových efektů na texty**
Aspose.Slides for Python via .NET poskytuje třídy [**IOuterShadow**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/ioutershadow/) a [**IInnerShadow**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/iinnershadow/), které umožňují aplikovat stínové efekty na text obsažený v TextFrame. Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).  
2. Získejte referenci na snímek pomocí jeho indexu.  
3. Přidejte do snímku AutoShape typu Rectangle.  
4. Získejte přístup k TextFrame přidruženému k AutoShape.  
5. Nastavte vlastnost FillType AutoShape na NoFill.  
6. Instancujte třídu OuterShadow.  
7. Nastavte BlurRadius stínu.  
8. Nastavte Direction (směr) stínu.  
9. Nastavte Distance (vzdálenost) stínu.  
10. Nastavte RectanglelAlign na TopLeft.  
11. Nastavte PresetColor stínu na Black.  
12. Uložte prezentaci jako soubor PPTX.  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Získat odkaz na snímek
    sld = pres.slides[0]

    # Přidat AutoShape typu Obdélník
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Přidat TextFrame do obdélníku
    ashp.add_text_frame("Aspose TextBox")

    # Zakázat výplň tvaru, pokud chceme získat stín textu
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Přidat vnější stín a nastavit všechny potřebné parametry
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Uložit prezentaci na disk
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití vnitřního stínového efektu na tvary**
Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).  
2. Získejte referenci na snímek.  
3. Přidejte AutoShape typu Rectangle.  
4. Povolte InnerShadowEffect.  
5. Nastavte všechna potřebná nastavení.  
6. Nastavte ColorType na Scheme.  
7. Nastavte Scheme Color.  
8. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Tento ukázkový kód (založený na výše uvedených krocích) ukazuje, jak v Pythonu přidat spojku mezi dvěma tvary:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Získat odkaz na snímek
    slide = presentation.slides[0]

    # Přidat AutoShape typu Obdélník
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Přidat TextFrame do obdélníku
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Povolit inner_shadow_effect
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Nastavit všechny potřebné parametry
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Nastavit ColorType jako Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Nastavit Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Uložit prezentaci
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu používat efekty WordArt s různými fonty nebo skripty (např. arabština, čínština)?**  
Ano, Aspose.Slides podporuje Unicode a funguje se všemi hlavními fonty a skripty. Efekty WordArt, jako stín, výplň a obrys, lze aplikovat bez ohledu na jazyk, i když dostupnost fontů a jejich vykreslování mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky hlavního snímku (slide master)?**  
Ano, můžete aplikovat efekty WordArt na tvary na hlavních snímcích, včetně zástupců titulků, zápatí nebo textu na pozadí. Změny provedené v rozložení masteru se projeví ve všech přidružených snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**  
Lehce. Efekty WordArt, jako stíny, záře a gradientové výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek efektů WordArt bez uložení prezentace?**  
Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí metody `get_image` ze tříd [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) nebo [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením či exportem celé prezentace.