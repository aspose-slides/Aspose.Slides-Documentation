---
title: Maak en pas WordArt-effecten toe in Python
linktitle: WordArt
type: docs
weight: 110
url: /nl/python-net/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduweffect
- reflectie-effect
- gloeieffect
- WordArt-transformatie
- 3D-effect
- buitenschaduweffect
- inner schaduweffect
- Python
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides for Python via .NET. Deze stap-voor-stap gids helpt ontwikkelaars om presentaties te verbeteren met professionele tekst in Python."
---
## **Overzicht**

WordArt-effecten stellen u in staat om tekst op te maken met vullingen, contouren, schaduwen, reflecties, gloed, transformaties en 3D-opmaak. Dit artikel legt uit hoe u deze effecten kunt maken en aanpassen in PowerPoint-presentaties met Aspose.Slides for Python via .NET, zonder dat Microsoft Office geïnstalleerd is.

## **Maak een eenvoudige WordArt-sjabloon en pas deze toe op tekst**

De volgende voorbeelden maken een eenvoudige WordArt-stijl door de tekst, het lettertype, de patroonvulling en de contour in te stellen.

Elke voorbeeld maakt een nieuwe presentatie aan en voegt een rechthoek toe aan de eerste dia; een invoerbestand is niet vereist. Het eerste voorbeeld stelt de tekst in op "Aspose.Slides". De positie en afmetingen van de vorm worden gemeten in punten:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Stel het lettertype in op Arial Black op 36 punten om de opmaak beter zichtbaar te maken:

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

Pas een [SMALL_GRID](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternstyle/) patroon toe met een donkeroranje voorgrond en een witte achtergrond, en voeg vervolgens een zwarte tekstcontour toe met een breedte van 1 punt:

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

De resulterende tekst:

![De eenvoudige WordArt-sjabloon](WordArt_template.png)

## **Pas andere WordArt-effecten toe**

De volgende voorbeelden laten zien hoe u schaduwen, reflecties, gloed, transformaties en 3D-effecten op tekst kunt toepassen.

### **Pas buitenschaduw-effecten toe**

Een buitenschaduw voegt diepte toe door een schaduw achter de tekst te plaatsen. U kunt de kleur, richting, afstand, vervagingsstraal, schaal en scheefstand aanpassen.

Dit voorbeeld roept [enable_outer_shadow_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) aan en stelt een zwarte schaduw in met een vervagingsstraal van 4 punten, een richting van 230 graden en een afstand van 30 punten. Schaalwaarden van 100 behouden de grootte van de schaduw, terwijl een horizontale scheefstand deze 20 graden kantelt. De alfa-transformatie stelt de dekking in op 32%:

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

De resulterende tekst:

![Het buitenschaduw-effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wanneer buitenschaduwen en voorinstelde schaduwen samen worden gebruikt, wordt alleen de buitenschaduw toegepast.
- Als buitenschaduwen en binnenste schaduwen tegelijk worden gebruikt, hangt het resulterende effect af van de PowerPoint-versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen de buitenschaduw wordt toegepast.
{{% /alert %}}

### **Pas reflectie-effecten toe**

Een reflectie creëert een spiegelbeeld van de tekst. Pas de positie, schaal, vervaging en dekking aan om het uiterlijk te regelen.

Dit voorbeeld roept [enable_reflection_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/effectformat/enable_reflection_effect/) aan en draait de reflectie verticaal met een schaal van -100%. Het gebruikt een vervagingsstraal van 0.5 punt en een afstand van 4.72 punt. De dekking daalt van 60% naar 0.9% tussen posities 0% en 60% langs de reflectie:

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

De resulterende tekst:

![Het reflectie-effect](reflection_effect.png)

### **Pas gloed-effecten toe**

Een gloed voegt een zachte gekleurde omtrek rond de tekst toe. Pas de kleur, dekking en straal aan om het effect te regelen.

Dit voorbeeld roept [enable_glow_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/effectformat/enable_glow_effect/) aan en past een rode gloed toe met 54% dekking en een straal van 7 punten:

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

De resulterende tekst:

![Het gloed-effect](glow_effect.png)

### **Pas WordArt-transformaties toe**

WordArt-transformaties buigen, rekken of vervormen een blok tekst.

Stel [transform](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/transform/) in op [ARCH_UP_POUR](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textshapetype/) om het volledige tekstframe naar boven te buigen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

De resulterende tekst:

![De WordArt-transformatie](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET biedt een reeks vooraf gedefinieerde [transformation types](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Pas 3D-effecten toe op vormen en tekst**

U kunt 3D-effecten toepassen op een vorm of op de tekst ervan. Afscherpingen, extrusie, verlichting en camera-instellingen bepalen het uiteindelijke uiterlijk.

Het volgende voorbeeld gebruikt [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/) om ronde afscherpingen, oranje extrusie en een donkerrode omtrek toe te voegen aan de rechthoek. Afmetingen van de afscherpingen, extrusiehoogte, omtrekbreedte en diepte worden gemeten in punten. Een plastic materiaal, evenwichtige verlichting gedraaid met 40 graden rond de Z-as, en een perspectiefcamera bepalen het uiterlijk:

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

De resulterende vorm:

![Het vorm-3D-effect](shape_3D_effect.png)

Dit voorbeeld past een vergelijkbare 3D-opmaak toe op de tekst via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/three_d_format/). Kleinere afscherpingen vormen de letterranden, terwijl extrusie en verlichting de tekst diepte geven:

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

De resulterende tekst:

![Het tekst-3D-effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
De toepassing van 3D-effecten op tekst of hun vormen—en de interactie tussen deze effecten—wordt beheerst door specifieke regels. Beschouw een scène waarin zowel tekst als de vorm die de tekst bevat aanwezig is. Een 3D-effect omvat de 3D-representatie van het object en de scène waarin het geplaatst is.

- Als er voor zowel de vorm als de tekst een scène is ingesteld, heeft de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D-representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D-effect heeft, wordt deze als plat beschouwd en wordt het 3D-effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de eigenschappen [ThreeDFormat.light_rig](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/light_rig/) en [ThreeDFormat.camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Om de tekst vlak en leesbaar te houden terwijl de 3D-opmaak van de vorm behouden blijft, zie [Keep Text Flat on a 3D Shape](/slides/nl/python-net/3d-presentation/) voor een vergelijking van beide instellingen en een volledig Python-voorbeeld.

## **FAQ**

**Kan ik WordArt-effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides for Python via .NET ondersteunt Unicode en werkt met alle belangrijke lettertypen en scripts. WordArt-effecten zoals schaduw, vulling en contour kunnen worden toegepast, ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt-effecten toepassen op elementen van de slide-master?**

Ja, u kunt WordArt-effecten toepassen op vormen in de master-dia’s, inclusief titel-placeholder-objecten, voetteksten of achtergrondtekst. Wijzigingen in de master-lay-out worden doorgevoerd naar alle bijbehorende dia’s.

**Beïnvloeden WordArt-effecten de bestandsgrootte van de presentatie?**

Licht. WordArt-effecten zoals schaduwen, gloed en verloopvullingen kunnen de bestandsgrootte een beetje doen toenemen door extra opmaakmetadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt-effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met behulp van [Slide.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/), of individuele vormen renderen met [Shape.get_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/). Hiermee kunt u het resultaat in het geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.