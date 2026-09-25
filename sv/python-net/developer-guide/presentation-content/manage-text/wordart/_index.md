---
title: Skapa och tillämpa WordArt‑effekter i Python
linktitle: WordArt
type: docs
weight: 110
url: /sv/python-net/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- Python
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för Python via .NET. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i Python."
---
## **Översikt**

WordArt‑effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Den här artikeln förklarar hur du skapar och anpassar dessa effekter i PowerPoint‑presentationer med Aspose.Slides för Python via .NET, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

Följande exempel bygger en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på dess första bild; ingen indatafil krävs. Det första exemplet sätter texten till "Aspose.Slides". Formens position och mått mäts i punkter:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Ställ in teckensnittet till Arial Black i 36 punkter för att göra formateringen mer märkbar:

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

Applicera ett [SMALL_GRID](https://reference.aspose.com/slides/sv/python-net/aspose.slides/patternstyle/)‑mönster med en mörk orange förgrund och en vit bakgrund, lägg sedan till en svart textkontur med en bredd på 1 punkt:

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

Den resulterande texten:

![Den enkla WordArt‑mallen](WordArt_template.png)

## **Tillämpa andra WordArt‑effekter**

Följande exempel demonstrerar hur du applicerar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Tillämpa yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpa, skalning och snedning.

Detta exempel anropar [enable_outer_shadow_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) och sätter en svart skugga med en oskärpa på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skalvärden på 100 bevarar skuggans storlek, medan horisontell snedning lutar den 20 grader. Alfa‑transformen sätter dess opacitet till 32 %:

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

Den resulterande texten:

![Yttre skuggeffekt](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- När yttre och förinställda skuggor används tillsammans tillämpas endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 dubblas effekten, medan i PowerPoint 2007 tillämpas endast den yttre skuggan.
{{% /alert %}}

### **Tillämpa reflektionseffekter**

En reflektion skapar en spegelvänd kopia av texten. Justera dess position, skalning, oskärpa och opacitet för att kontrollera dess utseende.

Detta exempel anropar [enable_reflection_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/effectformat/enable_reflection_effect/) och vänder reflektionen vertikalt med en skalning på -100 %. Det använder en oskärpa på 0,5 punkt och ett avstånd på 4,72 punkt. Opaciteten minskar från 60 % till 0,9 % mellan positionerna 0 % och 60 % längs reflektionen:

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

Den resulterande texten:

![Reflektionseffekt](reflection_effect.png)

### **Tillämpa glödeffekter**

En glöd lägger till en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [enable_glow_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/effectformat/enable_glow_effect/) och applicerar en röd glöd med 54 % opacitet och en radie på 7 punkter:

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

Den resulterande texten:

![Glödeffekt](glow_effect.png)

### **Tillämpa WordArt‑transformationer**

WordArt‑transformationer böjer, sträcker eller deformerar ett block med text.

Ställ in [transform](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/transform/) till [ARCH_UP_POUR](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textshapetype/) för att kurva hela text‑ramen uppåt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Den resulterande texten:

![WordArt‑transformationen](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python via .NET erbjuder ett antal fördefinierade [transformations‑typer](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Tillämpa 3D‑effekter på former och text**

Du kan applicera 3D‑effekter på en form eller på dess text. Avfasningar, extrusion, belysning och kamerainställningar styr det slutliga resultatet.

Följande exempel använder [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/) för att lägga till cirkulära avfasningar, orange extrusion och en mörkröd kontur på rektangeln. Avfasningsmåtten, extrusionens höjd, konturens bredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader runt Z‑axeln och en perspektivkamera definierar dess utseende:

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

Den resulterande formen:

![Formens 3D‑effekt](shape_3D_effect.png)

Detta exempel applicerar liknande 3D‑formatering på texten via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/three_d_format/). Mindre avfasningar formar bokstavskanten, medan extrusion och belysning ger texten djup:

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

Den resulterande texten:

![Textens 3D‑effekt](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Appliceringen av 3D‑effekter på text eller deras former – och interaktionen mellan dessa effekter – styrs av specifika regler. Tänk på en scen som involverar både text och den form som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och scenen där det placeras.

- Om en scen är inställd både för formen och för texten, har formens scen prioritet och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation, används textens scen.
- Om formen inte har någon 3D‑effekt alls behandlas den som platt, och 3D‑effekten tillämpas endast på texten.

Dessa beteenden relaterar till [ThreeDFormat.light_rig](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/light_rig/) och [ThreeDFormat.camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/camera/)‑egenskaper.
{{% /alert %}}

För att hålla texten platt och läsbar samtidigt som du behåller formens 3D‑formatering, se [Keep Text Flat on a 3D Shape](/slides/sv/python-net/3d-presentation/) för en jämförelse av båda inställningarna och ett komplett Python‑exempel.

## **FAQ**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. Arabiska, Kinesiska)?**

Ja, Aspose.Slides för Python via .NET stöder Unicode och fungerar med alla större teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan appliceras oavsett språk, även om teckensnittstillgänglighet och rendering kan bero på systemets teckensnitt.

**Kan jag applicera WordArt‑effekter på element i bildmaster?**

Ja, du kan applicera WordArt‑effekter på former i master‑bilder, inklusive titelplatshållare, sidfötter eller bakgrundstext. Ändringar i master‑layouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter filens storlek?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt (t.ex. PNG, JPEG) med [Slide.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/), eller rendera enskilda former med [Shape.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.