---
title: Applicera formeffekter i presentationer med Python via Java
linktitle: Formeffekt
type: docs
weight: 30
url: /sv/python-java/shape-effect/
keywords:
- formeffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjukkanteffekt
- effektformat
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formeffekter med Aspose.Slides för Python via Java—skapa slående, professionella bildspel på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/python-java/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd osv.

![Formseffekt](shape-effect.png)

PowerPoint tillhandahåller sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen erbjuder PowerPoint alternativ under **Preset**. Preset‑alternativen är kombinationer av två eller fler effekter som är kända för att se bra ut. På så sätt, genom att välja en förinställning, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en bra kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) som gör att du kan tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Aspose.Slides för Python via Java stöder yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärpe‑radie för att matcha designen i din presentation.

### **Applicera en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att sticka ut mot bildens bakgrund. Skuggan sträcker sig bortom formens kanter och skapar intrycket att formen är upphöjd över bilden. Justera dess färg, riktning, avstånd och oskärpe‑radie för att matcha belysning och stil i din mall.

Denna Python‑kod visar hur man applicerar [yttre skuggeffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) på en rektangel:

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

### **Applicera en inre skugga**

När du återger en malls visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att verka upphöjd, medan en inre skugga mörkar insidan av dess kanter.

Anropa [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), konfigurera sedan skuggan som returneras av [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Större värden för oskärpe‑radien ger mjukare kanter.

Denna Python‑exempel skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX‑fil. Skuggans riktning är 225 grader, avståndet är 7 punkter och dess oskärpe‑radie är 6 punkter:

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

## **Applicera en reflektionseffekt**

För att applicera en reflektionseffekt i Aspose.Slides för Python via Java kan du lägga till en spegel‑liknande reflektion på former och justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetiken i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Det är enkelt att implementera med enkel kod, vilket möjliggör snabb tillämpning på flera element för en enhetlig design.

Denna Python‑kod visar hur man applicerar [reflektionseffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) på en form:

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

## **Applicera en glödeffekt**

För att applicera en glödeffekt på en form i Aspose.Slides för Python via Java kan du lägga till en mjuk, lysande aura runt former och justera egenskaper som färg och storlek. Denna effekt hjälper former att sticka ut och lägger till ett attraktivt, iögonfallande visuellt element i din presentation. Det är enkelt att implementera med minimal kod, vilket förbättrar det övergripande utseendet på dina bildspel.

Denna Python‑kod visar hur man applicerar [glödeffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) på en form:

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

![Glödeffekt](glow_effect.png)

## **Applicera en mjukkantseffekt**

För att applicera en mjukkantseffekt i Aspose.Slides för Python via Java kan du skapa en jämn, suddig övergång runt en forms kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som kräver ett mjukt, mjukare intryck. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna Python‑kod visar hur man applicerar [mjukkantseffekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) på en form:

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

![Mjukkantseffekt](soft_edges_effect.png)

## **FAQ**

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.