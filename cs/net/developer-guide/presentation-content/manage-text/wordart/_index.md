---
title: Vytvoření a aplikace WordArt efektů v .NET
linktitle: WordArt
type: docs
weight: 110
url: /cs/net/wordart/
keywords:
- WordArt
- vytvořit WordArt
- WordArt šablona
- WordArt efekt
- efekt stínu
- efekt odrazu
- efekt záře
- WordArt transformace
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- .NET
- C#
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro .NET. Tento postupný návod pomáhá vývojářům vylepšit prezentace profesionálním textem v C#."
---
## **Přehled**

Efekty WordArt vám umožňují stylizovat text pomocí výplní, obrysů, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvářet a přizpůsobovat tyto efekty v prezentacích PowerPoint pomocí Aspose.Slides pro .NET, bez nainstalovaného Microsoft Office.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, písma, výplně vzorem a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na „Aspose.Slides“. Pozice a rozměry tvaru jsou měřeny v bodech:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Zvolte písmo Arial Black o velikosti 36 bodů, aby bylo formátování výraznější:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/net/aspose.slides/patternstyle/) s tmavě oranžovým popředím a bílým pozadím, poté přidejte černý obrys textu s šířkou 1 bodu:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Výsledný text:

![The simple WordArt template](WordArt_template.png)

## **Použijte další efekty WordArt**

Následující příklady ukazují, jak na text použít stíny, odrazy, záři, transformace a 3D efekty.

### **Použijte efekty vnějšího stínu**

Vnější stín přidává hloubku umístěním stínu za text. Můžete upravit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Následující příklad volá [EnableOuterShadowEffect](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/enableoutershadoweffect/) a nastaví černý stín s rozostřením 4 body, směrem 230 stupňů a vzdáleností 30 bodů. Hodnota měřítka 100 zachovává velikost stínu, zatímco horizontální zkosení ho nakloní o 20 stupňů. Alfa transformace nastaví jeho průhlednost na 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Výsledný text:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Když jsou použity zároveň vnější a přednastavené stíny, použije se pouze vnější stín.
- Pokud jsou použity současně vnější a vnitřní stíny, výsledek závisí na verzi PowerPointu. Například ve PowerPointu 2013 se efekt zdvojnásobí, zatímco ve verzi 2007 se použije jen vnější stín.
{{% /alert %}}

### **Použijte efekty odrazu**

Odraz vytvoří zrcadlovou kopii textu. Nastavte jeho pozici, měřítko, rozostření a průhlednost, abyste ovládali vzhled.

Ukázkový kód volá [EnableReflectionEffect](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/enablereflectioneffect/) a převrací odraz vertikálně se měřítkem -100%. Používá rozostření 0.5 bodu a vzdálenost 4.72 bodu. Průhlednost klesá z 60% na 0.9% mezi pozicemi 0% a 60% podél odrazu:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

Výsledný text:

![The Reflection effect](reflection_effect.png)

### **Použijte efekty záře**

Záře přidává kolem textu měkký barevný obrys. Nastavte její barvu, průhlednost a poloměr, abyste efekt ovládali.

Tento příklad volá [EnableGlowEffect](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/enablegloweffect/) a aplikuje červenou záři s průhledností 54% a poloměrem 7 bodů:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Výsledný text:

![The Glow effect](glow_effect.png)

### **Použijte transformace WordArt**

Transformace WordArt ohýbají, roztahují nebo deformují blok textu.

Nastavte [Transform](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/transform/) na [ArchUpPour](https://reference.aspose.com/slides/cs/net/aspose.slides/textshapetype/), aby se celý rámeček textu zakřivil směrem nahoru:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Výsledný text:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides pro .NET poskytuje sadu předdefinovaných [transformation types](https://reference.aspose.com/slides/cs/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Použijte 3D efekty na tvary a text**

Můžete aplikovat 3D efekty na tvar nebo na jeho text. Šikmá řezání, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/) k přidání kulatých šikmých řezů, oranžové extruze a tmavě červeného konturu k obdélníku. Rozměry šikmého řezu, výška extruze, šířka konturu a hloubka jsou měřeny v bodech. Plastický materiál, vyvážené osvětlení natočené o 40° kolem osy Z a perspektivní kamera definují jeho vzhled:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Výsledný tvar:

![The shape 3D effect](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/threedformat/). Menší šikmé řezy tvarují okraje písmen, zatímco extruze a osvětlení dodávají textu hloubku:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Výsledný text:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Použití 3D efektů na text nebo na jejich tvary – a interakce mezi těmito efekty – je řízena specifickými pravidly. Uvažujte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je pro tvar i text nastavena scéna, má přednost scéna tvaru a scéna textu je ignorována.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se aplikuje jen na text.

Tyto chování se vztahují k vlastnostem [ThreeDFormat.LightRig](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/lightrig/) a [ThreeDFormat.Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Pro zachování plochého a čitelného textu při zachování 3D formátování tvaru, viz [Keep Text Flat on a 3D Shape](/slides/cs/net/3d-presentation/) pro srovnání obou nastavení a kompletní příklad v C#.

## **Často kladené otázky**

**Mohu používat efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides pro .NET podporuje Unicode a funguje se všemi hlavními písmy a skripty. Efekty WordArt, jako jsou stín, výplň a obrys, lze použít bez ohledu na jazyk, i když dostupnost písem a jejich vykreslování může záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky hlavního snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v hlavních snímcích, včetně zástupných symbolů titulů, zápatí nebo textu na pozadí. Změny provedené v hlavním rozvržení se projeví ve všech souvisejících snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientové výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu zobrazit náhled výsledku efektů WordArt, aniž bych uložil prezentaci?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [ISlide.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/), nebo vykreslit jednotlivé tvary pomocí [IShape.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getimage/). To vám umožní zobrazit náhled výsledku v paměti nebo na obrazovce před uložením či exportem celé prezentace.