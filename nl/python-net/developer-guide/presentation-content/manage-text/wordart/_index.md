---
title: WordArt-effecten maken en toepassen in Python
linktitle: WordArt
type: docs
weight: 110
url: /nl/python-net/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduw-effect
- display-effect
- gloei-effect
- WordArt-transformatie
- 3D-effect
- buitenste schaduw-effect
- interne schaduw-effect
- Python
- Aspose.Slides
description: "Leer hoe je WordArt-effecten kunt maken en aanpassen in Aspose.Slides for Python via .NET. Deze stapsgewijze handleiding helpt ontwikkelaars om presentaties te verbeteren met stijlvolle, professionele tekst in Python."
---
## **Overzicht**

WordArt‑effecten stellen je in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan je PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmatically WordArt maken, aanpassen en beheren, net zoals in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief hoe je teksttransformaties, vulstijlen, contouren, schaduwen en andere opmaakopties toepast om je presentatie‑inhoud expressiever en boeiender te maken. WordArt behandelt tekst als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

**WordArt in Microsoft PowerPoint**

Om WordArt in Microsoft PowerPoint te gebruiken, moet je een van de vooraf gedefinieerde WordArt‑sjablonen selecteren. Een WordArt‑sjabloon is een set effecten die op een tekst of de bijbehorende vorm wordt toegepast. 

**WordArt in Aspose.Slides**

In Aspose.Slides for Python via .NET 20.10 hebben we ondersteuning voor WordArt geïmplementeerd en de functionaliteit in latere releases verder verbeterd. 

Met Aspose.Slides for Python via .NET kun je eenvoudig je eigen WordArt‑sjabloon (één effect of een combinatie van effecten) maken in Python en toepassen op teksten. 

## Een eenvoudig WordArt‑sjabloon maken en toepassen op een tekst

**Gebruik Aspose.Slides** 

Eerst maken we een eenvoudige tekst met deze Python‑code: 

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
Vervolgens stellen we de letterhoogte van de tekst in op een grotere waarde om het effect opvallender te maken via deze code:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Gebruik Microsoft PowerPoint**

Ga naar het WordArt‑effectmenu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Aan de rechterkant kun je een vooraf gedefinieerd WordArt‑effect kiezen. Aan de linkerkant kun je de instellingen voor een nieuw WordArt specificeren. 

Dit zijn enkele van de beschikbare parameters of opties:

![todo:image_alt_text](image-20200930114015-3.png)

**Gebruik Aspose.Slides**

Hier passen we de SmallGrid‑patronkleur toe op de tekst en voegen we een zwarte tekstrand van 1‑punt toe met deze code:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

De resulterende tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## Andere WordArt‑effecten toepassen

**Gebruik Microsoft PowerPoint**

Via de interface van het programma kun je deze effecten toepassen op een tekst, tekstblok, vorm of soortgelijk element:

![todo:image_alt_text](image-20200930114129-5.png)

Bijvoorbeeld: Shadow, Reflection en Glow kunnen op een tekst worden toegepast; 3D‑Formaat en 3D‑Rotatie kunnen op een tekstblok worden toegepast; Soft Edges kan op een Shape‑object worden toegepast (het heeft nog steeds effect wanneer er geen 3D‑Formaat‑eigenschap is ingesteld). 

### Schaduw‑effecten toepassen

Hier richten we ons alleen op de eigenschappen van een tekst. We passen het schaduw‑effect toe op een tekst met deze Python‑code:

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

Aspose.Slides‑API ondersteunt drie soorten schaduwen: OuterShadow, InnerShadow en PresetShadow. 

Met PresetShadow kun je een schaduw voor een tekst toepassen (met vooraf ingestelde waarden). 

**Gebruik Microsoft PowerPoint**

In PowerPoint kun je één type schaduw gebruiken. Hieronder een voorbeeld:

![todo:image_alt_text](image-20200930114225-6.png)

**Gebruik Aspose.Slides**

Aspose.Slides staat zelfs toe om twee soorten schaduwen tegelijk toe te passen: InnerShadow en PresetShadow.

**Opmerkingen:**

- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast. 
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. In PowerPoint 2007 wordt het OuterShadow‑effect toegepast. 

### Display toepassen op teksten

We voegen display toe aan de tekst via dit Python‑voorbeeld:

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

### Glow‑effect toepassen op teksten

We passen het glow‑effect toe op de tekst zodat deze straalt of opvalt met deze code:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Je kunt de parameters voor schaduw, display en glow aanpassen. De eigenschappen van de effecten worden afzonderlijk ingesteld op elk tekstdeel. 

{{% /alert %}} 

### Transformaties gebruiken in WordArt

We gebruiken de Transform‑eigenschap (van toepassing op het gehele tekstblok) via deze code:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Het resultaat:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zowel Microsoft PowerPoint als Aspose.Slides for Python via .NET bieden een bepaald aantal vooraf gedefinieerde transformatietypes. 

{{% /alert %}} 

**Gebruik PowerPoint**

Om toegang te krijgen tot de vooraf gedefinieerde transformatietypes, ga naar: **Format** → **TextEffect** → **Transform**

**Gebruik Aspose.Slides**

Om een transformatietype te selecteren, gebruik je de `TextShapeType`‑enum. 

### 3D‑effecten toepassen op teksten en vormen

We stellen een 3D‑effect in op een tekstvorm met deze voorbeeldcode:

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

De resulterende tekst en vorm:

![todo:image_alt_text](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze Python‑code:

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

Het resultaat van de bewerking:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

De toepassing van 3D‑effecten op teksten of hun vormen en de interacties tussen effecten volgen bepaalde regels. 

Beschouw een scène voor een tekst en de vorm die die tekst bevat. Het 3D‑effect bestaat uit een 3D‑objectrepresentatie en de scène waarop het object geplaatst is. 

- Wanneer de scène is ingesteld voor zowel de figuur als de tekst, krijgt de figuur‑scène de hogere prioriteit – de tekst‑scène wordt genegeerd. 
- Wanneer de figuur geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekst‑scène gebruikt. 
- Anders – wanneer de vorm oorspronkelijk geen 3D‑effect heeft – is de vorm plat en wordt het 3D‑effect alleen op de tekst toegepast. 

De beschrijvingen zijn gerelateerd aan de eigenschappen [ThreeDFormat.LightRig](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/) en [ThreeDFormat.Camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Outer Shadow‑effecten toepassen op teksten**
Aspose.Slides for Python via .NET biedt de [**IOuterShadow**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/ioutershadow/) en [**IInnerShadow**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/iinnershadow/) klassen die je in staat stellen schaduw‑effecten toe te passen op tekst binnen een TextFrame. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Verkrijg de referentie van een dia met behulp van de index.
3. Voeg een AutoShape van het type Rectangle toe aan de dia.
4. Open de TextFrame die aan de AutoShape is gekoppeld.
5. Stel de FillType van de AutoShape in op NoFill.
6. Maak een instantie van de OuterShadow‑klasse.
7. Stel de BlurRadius van de schaduw in.
8. Stel de Direction van de schaduw in.
9. Stel de Distance van de schaduw in.
10. Stel de RectanglelAlign in op TopLeft.
11. Stel de PresetColor van de schaduw in op Black.
12. Schrijf de presentatie naar een PPTX‑bestand.

Deze voorbeeldcode in Python—een implementatie van de bovenstaande stappen—laat zien hoe je het outer shadow‑effect op een tekst toepast:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Verkrijg referentie van de dia
    sld = pres.slides[0]

    # Voeg een AutoShape van het type RECTANGLE toe
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Voeg TextFrame toe aan de rechthoek
    ashp.add_text_frame("Aspose TextBox")

    # Schakel vormvulling uit voor het geval we de schaduw van de tekst willen krijgen
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Voeg een buitenste schaduw toe en stel alle nodige parameters in
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Sla de presentatie op naar schijf
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Inner Shadow‑effect toepassen op vormen**
Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie van de dia.
3. Voeg een AutoShape van het type Rectangle toe.
4. Schakel InnerShadowEffect in.
5. Stel alle benodigde parameters in.
6. Stel de ColorType in op Scheme.
7. Stel de Scheme‑kleur in.
8. Schrijf de presentatie naar een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

Deze voorbeeldcode (gebaseerd op de bovenstaande stappen) laat zien hoe je een connector tussen twee vormen toevoegt in Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Verkrijg referentie van een dia
    slide = presentation.slides[0]

    # Voeg een AutoShape van type Rectangle toe
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Voeg TextFrame toe aan de rechthoek
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Schakel inner_shadow_effect in    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Stel alle benodigde parameters in
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Stel ColorType in als Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Stel Scheme-kleur in
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Sla presentatie op
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en omtrek kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave afhankelijk kan zijn van de systeem‑lettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de slide‑master?**

Ja, je kunt WordArt‑effecten toepassen op vormen op master‑dia’s, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay‑out worden doorgevoerd in alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, glows en gradient‑vullingen kunnen de bestandsgrootte iets verhogen door extra opmaak‑metadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten previewen zonder de presentatie op te slaan?**

Ja, je kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met de `get_image`‑methode van de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑ of [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/)‑klassen. Hierdoor kun je het resultaat in‑memory of op het scherm bekijken voordat je de volledige presentatie opslaat of exporteert.