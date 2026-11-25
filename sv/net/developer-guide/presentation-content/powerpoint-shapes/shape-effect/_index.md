---
title: Applicera formeffekter i presentationer i .NET
linktitle: Formeffekt
type: docs
weight: 30
url: /sv/net/shape-effect/
keywords:
- formeffekt
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
description: "Transformera dina PPT- och PPTX-filer med avancerade formeffekter med Aspose.Slides för .NET—skapa slående, professionella bilder på sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att framhäva en form, skiljer de sig från [fyllningar](/slides/sv/net/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd, osv.

![Shape effect](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen har PowerPoint alternativ under **Preset**. Preset‑alternativen är i princip en välbeprövad kombination av två eller fler effekter. På så sätt, genom att välja ett förinställt värde, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) som låter dig applicera samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Aspose.Slides för .NET stöder yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärperadie för att matcha din presentationsdesign.

### **Applicera en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att framträda mot bildbakgrunden. Skuggan sträcker sig bortom formens kanter och ger intrycket att formen är upphöjd över bilden. Justera dess färg, riktning, avstånd och oskärperadie för att passa belysning och stil i din mall.

Detta C#‑kodexempel visar hur du applicerar [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) på en rektangel:

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

![Shadow effect](shadow_effect.png)

### **Applicera en inre skugga**

När du återger en malls visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att se upphöjd ut, medan en inre skugga skuggar insidan av dess kanter.

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

För att ta bort den inre skuggan, anropa [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) på formens effectformat.

### **Applicera, ändra och ta bort en förinställd skugga**

Anropa [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) och sätt [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) till en namngiven [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/). För att byta stil, ändra den förinställda på samma form. Anropa [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) för att ta bort skuggan samtidigt som fyllning och kontur bevaras.

Detta exempel behåller en kopia av rektangeln i varje steg. Båda skuggorna är förskjutna med 10 punkter. En riktning på 225° placerar den första skuggan ovanför och åt vänster om rektangeln, och 45° placerar den andra nedanför och åt höger.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Original | Första förinställning | Andra förinställning | Efter borttagning |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Applicera en reflektionseffekt**

För att applicera en reflektionseffekt i Aspose.Slides för .NET kan du lägga till en spegelliknande reflektion på former och justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetiken i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Det är enkelt att implementera med kort kod, vilket möjliggör snabb tillämpning på flera element för enhetlig design.

Detta C#‑kodexempel visar hur du applicerar [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) på en form:

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

![Reflection effect](reflection_effect.png)

## **Applicera en glödeffekt**

För att applicera en glödeffekt på en form i Aspose.Slides för .NET kan du lägga till en mjuk, ljus aura runt former och justera egenskaper som färg och storlek. Denna effekt hjälper former att sticka ut och tillför ett attraktivt, iögonfallande visuellt element i din presentation. Det är enkelt att implementera med minimal kod, vilket förbättrar det övergripande utseendet på dina bilder.

Detta C#‑kodexempel visar hur du applicerar [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) på en form:

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

![Glow effect](glow_effect.png)

## **Applicera en mjuk kant‑effekt**

För att applicera en mjuk kant‑effekt i Aspose.Slides för .NET kan du skapa en jämn, suddig övergång runt en formens kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som kräver en mjukare framtoning. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på diverse former i din presentation.

Detta C#‑kodexempel visar hur du applicerar [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) på en form:

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

![Soft edges effect](soft_edges_effect.png)

## **Applicera en oskärpeeffekt**

Använd bildoskärpa för att mjuka upp en formens fyllning och kontur samtidigt som formen förblir redigerbar. Anropa [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) på formens effectformat. Radien mäts i punkter (1/72 tum): använd ett icke‑negativt värde, större värden ger starkare oskärpa. En radie på noll lämnar utseendet oförändrat.

Inställningen [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) styr de synliga gränserna för effekten. Med `false` klipps oskärpan till de ursprungliga målade gränserna, inklusive konturen. Med `true` kan oskärpan sträcka sig utanför dessa gränser. Ingen av inställningarna ändrar formens position eller dimensioner.

Jämförelsen nedan använder samma fyllning, kontur och formdimensioner överallt. Översta raden använder `grow = false`; nedre raden använder `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Detta C#‑exempel skapar en orange rektangel med en mörkblå kontur, applicerar en 5‑punkts oskärpa och uppdaterar sedan till en 15‑punkts oskärpa genom att anropa [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) igen. Det sparar båda oskärpta tillstånd, anropar sedan [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) och sparar formen utan oskärpa.

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

Bildoskärpa påverkar fyllning och kontur tillsammans. En mjuk kant‑effekt tonar bort formens kanter, medan skuggoskärpa bara mjukar upp skuggan. Bildtransformeringseffekter verkar på bildinnehåll; detta exempel applicerar oskärpa direkt på formens effectformat utan att konvertera formen till en bild.

## **FAQ**

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autogestalter, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att appliceras på hela gruppen.