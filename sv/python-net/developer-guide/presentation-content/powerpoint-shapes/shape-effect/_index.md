---
title: Applicera formeffekter i presentationer med Python
linktitle: Formeffekt
type: docs
weight: 30
url: /sv/python-net/shape-effect
keywords:
- formeffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuk kant-effekt
- effektformat
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Omvandla dina PPT-, PPTX- och ODP-filer med avancerade formeffekter med Aspose.Slides för Python—skapa slående, professionella bildspel på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att framhäva en form, skiljer de sig från [fyllningar](/slides/sv/python-net/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en formens glöd osv.

![Formseffekt](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen har PowerPoint alternativ under **Preset**. Preset‑alternativen är i princip en beprövad, bra‑utseende kombination av två eller fler effekter. På så sätt, genom att välja ett förinställt alternativ, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Aspose.Slides för Python via .NET stödjer yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärpedjup för att passa din presentationsdesign.

### **Applicera en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att sticka ut mot bildbakgrunden. Skuggan sträcker sig bortom formens kanter och skapar intrycket att formen är upphöjd över bilden. Justera dess färg, riktning, avstånd och oskärpedjup för att matcha belysning och stil i din mall.

Den här Python‑koden visar hur du tillämpar [yttre skuggeffekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) på en rektangel:

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

![Skuggeffekt](shadow_effect.png)

### **Applicera en inre skugga**

När du återskapar en malls visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att verka upphöjd, medan en inre skugga skuggar insidan av dess kanter.

Anropa [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), konfigurera sedan [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Större värden för oskärpedjup ger mjukare kanter.

Det här Python‑exemplet skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX‑fil:

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

![Ljusblå rektangel med inre skugga](inner_shadow_effect.png)

För att ta bort den inre skuggan, anropa [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) på formens effektformat.

## **Applicera en reflektionseffekt**

För att tillämpa en reflektionseffekt i Aspose.Slides för Python via .NET kan du lägga till en spegel‑liknande reflektion på former, och justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetiken i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Den är enkel att implementera med enkel kod, vilket möjliggör snabb tillämpning på flera element för en enhetlig design.

Den här Python‑koden visar hur du tillämpar [reflektionseffekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) på en form:

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

![Reflektionseffekt](reflection_effect.png)

## **Applicera en glödeffekt**

För att tillämpa en glödeffekt på en form i Aspose.Slides för Python via .NET kan du lägga till en mjuk, lysande aura runt former, och justera egenskaper som färg och storlek. Denna effekt hjälper till att framhäva former och ger ett attraktivt, iögonfallande visuellt inslag till din presentation. Den är enkel att implementera med minimal kod, vilket förbättrar det övergripande utseendet på dina bilder.

Den här Python‑koden visar hur du tillämpar [glödeffekt](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) på en form:

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

![Glödeffekt](glow_effect.png)

## **Applicera en mjuk kant‑effekt**

För att applicera en mjuk kant‑effekt i Aspose.Slides för Python via .NET kan du skapa en jämn, suddig övergång runt kanten på en form. Denna effekt ger ett mer subtilt och förfinat intryck, perfekt för designer som behöver ett mjukt, avskalat utseende. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Den här Python‑koden visar hur du tillämpar [mjuka kanter](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) på en form:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Mjuk kant‑effekt](soft_edges_effect.png)

## **Applicera en oskärpe‑effekt**

Använd formoskärpa för att mjuka upp en forms fyllning och kontur samtidigt som formen förblir redigerbar. Anropa [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) på formens effektformat. Radien mäts i punkter (1/72 tum): använd ett icke‑negativt värde, där större värden ger starkare oskärpa. En radie på noll lämnar utseendet oförändrat.

Inställningen [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) styr den synliga gränsen för effekten. Med `False` klipps oskärpan till de ursprungliga målade gränserna, inklusive konturen. Med `True` kan oskärpan sträcka sig bortom dessa gränser. Ingen av inställningarna ändrar formens position eller dimensioner.

Jämförelsen nedan använder samma fyllning, kontur och formdimensioner genomgående. Övre raden använder `grow = False`; nedre raden använder `grow = True`.

![Original rektangel jämfört med oskärpedjup på 5 och 15 punkter, med grow avstängt och aktiverat](shape_blur_comparison.png)

Det här Python‑exemplet skapar en orange rektangel med en mörkblå kontur, applicerar en 5‑punkts oskärpa och uppdaterar sedan till en 15‑punkts oskärpa genom att anropa [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) igen. Det sparar båda de oskarpa tillstånden, anropar sedan [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) och sparar formen utan oskärpa.

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

Formoskärpa påverkar både fyllning och kontur tillsammans. En mjuk kant‑effekt tonar formens kanter, medan skuggoskärpa mjukar endast skuggan. Bildtransformeringseffekter verkar på bildinnehåll; detta exempel applicerar oskärpa direkt på formens effektformat utan att konvertera formen till en bild.

## **Vanliga frågor**

**Kan jag använda flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autogestalter, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.