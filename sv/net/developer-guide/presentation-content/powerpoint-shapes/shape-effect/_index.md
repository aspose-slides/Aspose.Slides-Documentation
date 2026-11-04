---
title: Tillämpa formseffekter i presentationer i .NET
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/net/shape-effect/
keywords:
- formseffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuk kantseffekt
- effektformat
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Omvandla dina PPT- och PPTX-filer med avancerade formseffekter med Aspose.Slides för .NET - skapa slående, professionella bildspel på sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/net/shape-formatting/#gradient-fill) eller konturer. Genom att använda PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en formes glöd osv.

![Formeffekt](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen har PowerPoint alternativ under **Preset**. Preset‑alternativen är i huvudsak en välkänd bra kombination av två eller flera effekter. På så sätt, genom att välja en förinställning, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Tillämpa en skuggeffekt**

Aspose.Slides för .NET stöder yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärperadie för att matcha din presentationsdesign.

### **Tillämpa en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att sticka ut mot bildens bakgrund. Skuggan sträcker sig utanför formens kanter och skapar intrycket att formen lyfts över bilden. Justera dess färg, riktning, avstånd och oskärperadie för att matcha belysning och stil i din mall.

Denna C#‑kod visar hur du tillämpar [yttre skuggeffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) på en rektangel:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Skuggeffekt](shadow_effect.png)

### **Tillämpa en inre skugga**

När du återger en mallens visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att verka upphöjd, medan en inre skugga skuggar insidan av dess kanter.

Anropa [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), konfigurera sedan [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Större värden ger mjukare kanter.

Detta C#‑exempel skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX‑fil:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Ljusblå rektangel med en inre skugga](inner_shadow_effect.png)

För att ta bort den inre skuggan, anropa [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) på formens effektformat.

## **Tillämpa en reflektionseffekt**

För att tillämpa en reflektionseffekt i Aspose.Slides för .NET kan du lägga till en spegelliknande reflektion på former, justera parametrar såsom avstånd, transparens och storlek. Denna effekt förbättrar estetik i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Det är enkelt att implementera med enkel kod, vilket möjliggör snabb tillämpning på flera element för en konsekvent design.

Denna C#‑kod visar hur du tillämpar [reflektionseffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) på en form:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Reflektionseffekt](reflection_effect.png)

## **Tillämpa en glödeffekt**

För att tillämpa en glödeffekt på en form i Aspose.Slides för .NET kan du lägga till en mjuk, ljus aura runt former, justera egenskaper som färg och storlek. Denna effekt hjälper till att få former att sticka ut och ger ett attraktivt, iögonfallande visuellt element till din presentation. Det är enkelt att implementera med minimal kod, vilket förbättrar det övergripande utseendet på dina bilder.

Denna C#‑kod visar hur du tillämpar [glödeffekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) på en form:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Glödeffekt](glow_effect.png)

## **Tillämpa en mjuk kantseffekt**

För att tillämpa en mjuka kanter‑effekt i Aspose.Slides för .NET kan du skapa en jämn, suddig övergång runt en forms kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som behöver ett försiktigt, mjukare utseende. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna C#‑kod visar hur du tillämpar [mjuka kanter](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) på en form:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Mjuk kant‑effekt](soft_edges_effect.png)

## **Tillämpa en oskärpeeffekt**

Använd formoskärpa för att mjuka upp en forms fyllning och kontur samtidigt som formen förblir redigerbar. Anropa [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) på formens effektformat. Radien mäts i punkter (1/72 tum): använd ett icke‑negativt värde, där större värden ger starkare oskärpa. En radie på noll lämnar utseendet oförändrat.

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/)‑inställningen styr de synliga gränserna för effekten. Med `false` beskärs oskärpan till de ursprungliga målade gränserna, inklusive konturen. Med `true` kan oskärpan sträcka sig utanför dessa gränser. Ingen av inställningarna ändrar formens position eller dimensioner.

Jämförelsen nedan använder samma fyllning, kontur och formdimensioner överallt. Den översta raden använder `grow = false`; den nedersta raden använder `grow = true`.

![Original rektangel jämfört med oskärpearadier på 5 och 15 punkter, med grow inaktiverat och aktiverat](shape_blur_comparison.png)

Detta C#‑exempel skapar en orange rektangel med en mörkblå kontur, applicerar en 5‑punkts oskärpa och uppdaterar sedan till en 15‑punkts oskärpa genom att anropa [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) igen. Det sparar båda oskärpade tillstånden, anropar sedan [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) och sparar formen utan oskärpa.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Formoskärpa påverkar både fyllning och kontur tillsammans. En mjuk kant‑effekt tonar formens kanter, medan skugga‑oskärpa mjukar upp endast skuggan. Bildtransformations‑effekter verkar på bildinnehåll; detta exempel applicerar oskärpa direkt på formens effektformat utan att konvertera formen till en bild.

## **FAQ**

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag tillämpa effekter på?**

Du kan tillämpa effekter på olika former, inklusive automatiska former, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag tillämpa effekter på grupperade former?**

Ja, du kan tillämpa effekter på grupperade former. Effekten kommer att appliceras på hela gruppen.