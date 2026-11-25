---
title: Tillämpa formeffekter i presentationer med Python via Java
linktitle: Formeffekt
type: docs
weight: 30
url: /sv/python-java/shape-effect/
keywords:
- formeffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjukkanter-effekt
- effektformat
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Omvandla dina PPT‑ och PPTX‑filer med avancerade formeffekter med Aspose.Slides för Python via Java—skapa slående, professionella bilder på sekunder."
---
## **Introduktion**

Även om effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fills](/slides/sv/python-java/shape-formatting/#gradient-fill) eller konturer. Genom att använda PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd, osv.

![Formeffekt](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen erbjuder PowerPoint alternativ under **Preset**. Preset‑alternativen är kombinationer av två eller fler effekter som är kända för att se bra ut. På så sätt, genom att välja en förinställning, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Tillämpa en skuggeffekt**

Aspose.Slides for Python via Java stöder yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärpe‑radie för att matcha din presentations design.

### **Tillämpa en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att sticka ut mot bildens bakgrund. Skuggan sträcker sig utanför formens kanter och ger intrycket att formen lyfts över sliden. Justera dess färg, riktning, avstånd och oskärpe‑radie för att matcha belysning och stil i din mall.

Denna Python‑kod visar hur du tillämpar [outer shadow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) på en rektangel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Skuggeffekt](shadow_effect.png)

### **Tillämpa en inre skugga**

När du återger en mallens visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att se upphöjd ut, medan en inre skugga skuggar insidan av dess kanter.

Anropa [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), konfigurera sedan skuggan som returneras av [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Större värden för oskärpe‑radien ger mjukare kanter.

Detta Python‑exempel skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX‑fil. Skuggans riktning är 225 grader, avståndet 7 punkter och oskärpe‑radien 6 punkter:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Ljusblå rektangel med inre skugga](inner_shadow_effect.png)

För att ta bort den inre skuggan, anropa [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) på formens effektformat.

### **Tillämpa, ändra och ta bort en förinställd skugga**

Anropa [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), använd sedan [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) för att välja en [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). För att byta stil, ändra förinställningen på samma form. Anropa [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) för att ta bort skuggan samtidigt som fyllning och kontur bevaras.

Exemplet klonar rektangeln i varje steg så att du kan jämföra alla fyra tillstånd sida‑vid‑sida på en slide. Båda skuggorna är förskjutna med 10 punkter. En riktning på 225° placerar den första skuggan ovanför och till vänster om rektangeln. En riktning på 45° placerar den andra nedanför och till höger.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Original | Första förinställning | Andra förinställning | Efter borttagning |
| :---: | :---: | :---: | :---: |
| ![Ingen skugga](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![Ingen skugga efter borttagning](preset_shadow_removed.png) |

## **Tillämpa en reflektionseffekt**

För att tillämpa en reflektionseffekt i Aspose.Slides for Python via Java kan du lägga till en spegel‑liknande reflektion på former, justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar dina presentationers estetik genom att ge former ett mer polerat och sofistikerat utseende. Den är enkel att implementera med kort kod, vilket möjliggör snabb tillämpning över flera element för en enhetlig design.

Denna Python‑kod visar hur du tillämpar [reflection effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) på en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Reflektionseffekt](reflection_effect.png)

## **Tillämpa en glöd‑effekt**

För att tillämpa en glöd‑effekt på en form i Aspose.Slides for Python via Java kan du lägga till en mjuk, lysande aura runt former, justera egenskaper som färg och storlek. Denna effekt hjälper former att sticka ut och ger ett attraktivt, ögonfallande visuellt element till din presentation. Den är enkel att implementera med minimal kod och förbättrar det totala utseendet på dina slides.

Denna Python‑kod visar hur du tillämpar [glow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) på en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Glöd‑effekt](glow_effect.png)

## **Tillämpa en mjuka kanter‑effekt**

För att tillämpa en mjuka kanter‑effekt i Aspose.Slides for Python via Java kan du skapa en jämn, suddig övergång runt en forms kanter. Denna effekt ger ett mer subtilt och raffinerat intryck, perfekt för designer som behöver ett mjukt, skonsamt utseende. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna Python‑kod visar hur du tillämpar [soft edges effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) på en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Mjuka kanter‑effekt](soft_edges_effect.png)

## **Tillämpa en oskärpe‑effekt**

Använd form‑oskärpa för att mjuka upp en forms fyllning och kontur samtidigt som formen förblir redigerbar. Anropa [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) på formens effektformat. Radien mäts i punkter (1/72 tum): använd ett icke‑negativt värde, där större värden ger starkare oskärpa. En radie på noll lämnar utseendet orört.

Inställningen [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) styr de synliga gränserna för effekten. Med `False` klipps oskärpan till de ursprungligt målade gränserna, inklusive konturen. Med `True` kan oskärpan sträcka sig utanför dessa gränser. Ingen av inställningarna ändrar formens position eller dimensioner.

Jämförelsen nedan använder samma fyllning, kontur och formdimensioner genomgående. Översta raden använder `grow = False`; nedersta raden använder `grow = True`.

![Original rektangel jämfört med oskärper på 5 och 15 punkter, med grow inaktiverat och aktiverat](shape_blur_comparison.png)

Detta Python‑exempel skapar en orange rektangel med en mörkblå kontur, tillämpar en 5‑punkts oskärpa och uppdaterar sedan till en 15‑punkts oskärpa genom att anropa [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) igen. Det sparar båda oskärpta tillstånden, anropar sedan [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) och sparar formen utan oskärpa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Form‑oskärpa påverkar fyllning och kontur tillsammans. En mjuka kanter‑effekt tonar ner formens kanter, medan skuggoskärpa bara mjukar upp skuggan. Bild‑transformations‑effekter arbetar på bildinnehåll; detta exempel applicerar oskärpa direkt på formens effektformat utan att konvertera formen till en bild.

## **FAQ**

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag tillämpa effekter på?**

Du kan tillämpa effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag tillämpa effekter på grupperade former?**

Ja, du kan tillämpa effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.