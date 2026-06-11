---
title: Skapa och tillämpa WordArt-effekter i Python
linktitle: WordArt
type: docs
weight: 110
url: /sv/python-net/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt-mall
- WordArt-effekt
- skuggeffekt
- visningseffekt
- glödeffekt
- WordArt-transformation
- 3D-effekt
- yttre skuggeffekt
- inre skuggeffekt
- Python
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar WordArt-effekter i Aspose.Slides för Python via .NET. Denna steg-för-steg-guide hjälper utvecklare att förbättra presentationer med stilren, professionell text i Python."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva ha Office installerat. Den här artikeln ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar texttransformationer, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt gör det möjligt att behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

**WordArt i Microsoft PowerPoint**

För att använda WordArt i Microsoft PowerPoint måste du välja en av de fördefinierade WordArt‑mallarna. En WordArt‑mall är en uppsättning effekter som appliceras på en text eller dess form. 

**WordArt i Aspose.Slides**

I Aspose.Slides för Python via .NET 20.10 implementerade vi stöd för WordArt och gjorde förbättringar av funktionen i efterföljande versioner av Aspose.Slides för Python via .NET. 

Med Aspose.Slides för Python via .NET kan du enkelt skapa din egen WordArt‑mall (en effekt eller en kombination av effekter) i Python och applicera den på texter. 

## Skapa en enkel WordArt‑mall och tillämpa den på en text

**Använda Aspose.Slides** 

Först skapar vi en enkel text med den här Python‑koden: 

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
Nu ställer vi in textens teckenhöjd till ett större värde för att göra effekten mer märkbar med hjälp av den här koden:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Använda Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt‑effekt. Från menyn till vänster kan du ange inställningarna för en ny WordArt. 

Detta är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Använda Aspose.Slides**

Här applicerar vi SmallGrid‑mönsterfärgen på texten och lägger till en svart textkant med bredd 1 med hjälp av den här koden:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Den resulterande texten:

![todo:image_alt_text](image-20200930114108-4.png)

## Tillämpa andra WordArt‑effekter

**Använda Microsoft PowerPoint**

Från programmets gränssnitt kan du applicera dessa effekter på en text, textblock, form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan Skugga, Reflektion och Glöd‑effekter appliceras på en text; 3D‑format- och 3D‑rotations‑effekter kan appliceras på ett textblock; egenskapen Mjuka kanter kan appliceras på ett formobjekt (den har fortfarande en effekt när ingen 3D‑format‑egenskap är inställd). 

### Applicera skuggeffekter

Här avser vi att endast ställa in egenskaper som gäller en text. Vi applicerar skuggeffekten på en text med den här koden i Python:

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

Aspose.Slides‑API stöder tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 
Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Använda Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Använda Aspose.Slides**

Aspose.Slides möjliggör faktiskt att du applicerar två typer av skuggor samtidigt: InnerShadow och PresetShadow.

**Obs!**

- När OuterShadow och PresetShadow används tillsammans appliceras endast OuterShadow‑effekten. 
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande/applikade effekten på PowerPoint‑versionen. Till exempel i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras OuterShadow‑effekten. 

### Applicera visning på texter

Vi lägger till visning på texten med detta kodexempel i Python:

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

### Applicera glöd‑effekt på texter

Vi applicerar glöd‑effekten på texten för att få den att lysa eller sticka ut med hjälp av den här koden:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Du kan ändra parametrarna för skugga, visning och glöd. Effekternas egenskaper sätts på varje del av texten separat. 

{{% /alert %}} 

### Använda transformationer i WordArt

Vi använder Transform‑egenskapen (inbyggd i hela textblocket) med den här koden:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Både Microsoft PowerPoint och Aspose.Slides för Python via .NET tillhandahåller ett visst antal fördefinierade transformationstyper. 

{{% /alert %}} 

**Använda PowerPoint**

För att komma åt fördefinierade transformationstyper, gå via: **Format** -> **TextEffect** -> **Transform**

**Använda Aspose.Slides**

För att välja en transformationstyp, använd enum‑värdet TextShapeType. 

### Applicera 3D‑effekter på texter och former

Vi sätter en 3D‑effekt på en textform med detta exempel på kod:

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

Den resulterande texten och dess form:

![todo:image_alt_text](image-20200930114816-9.png)

Vi applicerar en 3D‑effekt på texten med den här Python‑koden:

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

Resultatet av operationen:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Appliceringen av 3D‑effekter på texter eller deras former samt interaktioner mellan effekter baseras på vissa regler. 
Tänk på en scen för en text och den form som innehåller texten. 3D‑effekten innehåller en 3D‑objektrepresentation och scenen där objektet placerades. 
- När scenen är inställd för både figuren och texten får figurscenen högre prioritet — textscenen ignoreras. 
- När figuren saknar egen scen men har 3D‑representation används textscenen. 
- Annars—när formen ursprungligen inte har någon 3D‑effekt—är formen platt och 3D‑effekten appliceras endast på texten. 
Beskrivningarna är kopplade till egenskaperna [ThreeDFormat.LightRig](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/) och [ThreeDFormat.Camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Applicera yttre skuggeffekter på texter**
Aspose.Slides för Python via .NET tillhandahåller klasserna [**IOuterShadow**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.effects/ioutershadow/) och [**IInnerShadow**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.effects/iinnershadow/) som låter dig applicera skuggeffekter på text som finns i en TextFrame. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). 
2. Hämta referensen till en bild genom att använda dess index. 
3. Lägg till en AutoShape av typ Rectangle på bilden. 
4. Åtkomst till TextFrame som är associerad med AutoShape. 
5. Ställ in FillType för AutoShape till NoFill. 
6. Instansiera OuterShadow‑klassen 
7. Ställ in BlurRadius för skuggan. 
8. Ställ in Direction för skuggan 
9. Ställ in Distance för skuggan. 
10. Ställ in RectanglelAlign till TopLeft. 
11. Ställ in PresetColor för skuggan till Black. 
12. Skriv presentationen som en PPTX‑fil. 

Denna exempel­kod i Python—en implementering av stegen ovan—visar hur du applicerar den yttre skuggeffekten på en text:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Hämta referens till bilden
    sld = pres.slides[0]

    # Lägg till en AutoShape av typen Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Lägg till TextFrame till rektangeln
    ashp.add_text_frame("Aspose TextBox")

    # Inaktivera formfyllning ifall vi vill få skugga av texten
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Lägg till yttre skugga och sätt alla nödvändiga parametrar
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Skriv presentationen till disk
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Applicera inre skuggeffekt på former**
Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). 
2. Hämta en referens till bilden. 
3. Lägg till en AutoShape av typen Rectangle. 
4. Aktivera InnerShadowEffect. 
5. Ställ in alla nödvändiga parametrar. 
6. Ställ in ColorType till Scheme. 
7. Ställ in Scheme‑färgen. 
8. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil. 

Denna exempel­kod (baserad på stegen ovan) visar hur du lägger till en anslutning mellan två former i Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Hämta referens till en bild
    slide = presentation.slides[0]

    # Lägg till en AutoShape av typen Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Lägg till TextFrame till rektangeln
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Aktivera inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Sätt alla nödvändiga parametrar
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Ställ in ColorType som Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Ställ in Scheme-färg
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Spara presentationen
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag använda WordArt‑effekter med olika typsnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides stöder Unicode och fungerar med alla större typsnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan appliceras oavsett språk, även om typsnitts‑tillgänglighet och rendering kan bero på systemets typsnitt.

**Kan jag applicera WordArt‑effekter på master‑bildernas element?**

Ja, du kan applicera WordArt‑effekter på former i master‑bilder, inklusive titel‑platshållare, sidfot eller bakgrundstext. Ändringar i master‑layouten kommer att återspeglas på alla associerade bilder.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av `get_image`‑metoden från klasserna [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) eller [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.