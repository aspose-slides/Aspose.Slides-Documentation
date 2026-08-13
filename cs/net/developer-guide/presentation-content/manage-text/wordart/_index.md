---
title: Vytvoření a aplikace WordArt efektů v .NET
linktitle: WordArt
type: docs
weight: 110
url: /cs/net/wordart/
keywords:
- WordArt
- vytvořit WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt zobrazení
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- .NET
- C#
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro .NET. Tento krok za krokem průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v C#."
---
## **Přehled**

WordArt efekty vám umožňují přidávat vizuálně přitažlivý, stylizovaný text do prezentací PowerPoint. S Aspose.Slides pro .NET mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint – bez nutnosti instalace Office. Tento článek poskytuje přehled práce s WordArt v .NET, včetně toho, jak aplikovat textové transformace, výplně, obrysy, stíny a další možnosti formátování, aby byl obsah vaší prezentace výraznější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo nápadnější.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

V této části prozkoumáme, jak vytvořit jednoduchou šablonu WordArt a aplikovat ji na text pomocí Aspose.Slides pro .NET. WordArt nabízí snadný způsob, jak vylepšit vzhled textu údernými vizuálními efekty a styly. Naučením základních kroků tvorby a používání WordArt můžete tyto techniky snadno přizpůsobit libovolnému projektu, čímž učiníte své prezentace živějšími a zapamatovatelnějšími.

Nejprve vytvoříme jednoduchý text pomocí následujícího kódu C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Nyní nastavíme výšku písma textu na větší hodnotu, aby byl efekt výraznější, pomocí následujícího kódu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Zde aplikujeme výplň vzoru SmallGrid na text a přidáme černý obrys textu šířky 1 pomocí následujícího kódu:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

Výsledný text:

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použijte další efekty WordArt**

Kromě základních transformací vám Aspose.Slides pro .NET umožňuje aplikovat řadu pokročilých efektů WordArt pro vylepšení vzhledu vašeho textu. Patří sem obrysy, výplně, stíny, odrazy a efekty záře. Kombinací těchto funkcí můžete vytvořit poutavé styly textu, které ve vašich prezentacích vyniknou. Tato část demonstruje, jak tyto efekty aplikovat programově pomocí jednoduchých, přehledných příkladů kódu.

### **Aplikujte efekty vnějšího stínu**

Efekty vnějšího stínu pomáhají textu vyniknout přidáním stínu za jeho obrys, čímž vytvářejí pocit hloubky a oddělení od pozadí. Aspose.Slides pro .NET vám umožňuje snadno aplikovat a přizpůsobovat vnější stíny na text WordArt. V této části se naučíte nastavit barvu stínu, směr, vzdálenost, poloměr rozostření a další parametry pro dosažení požadovaného vizuálního dojmu.

Následující úryvek kódu C# aplikuje efekt stínu na výše vytvořený text.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

Výsledný text:

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" %}} 

- Když jsou použity OuterShadow a PresetShadow společně, použije se pouze efekt OuterShadow.
- Pokud jsou použity OuterShadow a InnerShadow současně, výsledný efekt závisí na verzi PowerPointu. Například v PowerPoint 2013 je efekt zdvojený, zatímco v PowerPoint 2007 se použije pouze efekt OuterShadow.

{{% /alert %}}

### **Aplikujte efekty odrazu**

V této části prozkoumáme, jak aplikovat efekty odrazu ve vašich snímcích pomocí Aspose.Slides pro .NET. Efekty odrazu mohou být účinným způsobem, jak dodat vašemu textu nebo tvarům stylový a moderní vzhled, pomoci klíčovým prvkům vyniknout a přidat hloubku vaší prezentaci. Porozuměním procesu aplikace a přizpůsobení těchto efektů můžete snadno upravit jejich vzhled podle designových potřeb a požadavků na značku.

Přidejte efekt odrazu k textu pomocí tohoto příkladu kódu C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

Výsledný text:

![Efekt odrazu](reflection_effect.png)

### **Aplikujte efekty záře**

V této části prozkoumáme, jak aplikovat efekt záře na text pomocí Aspose.Slides pro .NET. Efekt záře může váš text zvýraznit zářivým obrysem, čímž zlepší vizuální přitažlivost vašich snímků. Úpravou nastavení, jako je barva a intenzita, můžete snadno přizpůsobit záři tak, aby odpovídala vašemu designu a požadavkům na značku, a zajistit, aby klíčové body vaší prezentace upoutaly pozornost publika.

Aplikujte efekt záře na text, aby zazářil nebo vynikl, pomocí následujícího kódu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

Výsledný text:

![Efekt záře](glow_effect.png)

### **Aplikujte transformace WordArt**

V této části prozkoumáme, jak používat transformace v WordArt s Aspose.Slides pro .NET. Transformace vám umožňují ohýbat, roztahovat nebo deformovat text, čímž vytvářejí jedinečné a vizuálně působivé efekty. Ovládnutím těchto technik můžete snadno přizpůsobit tvary a styly textu podle vašeho brandingu nebo kreativní vize, což zajistí poutavou a profesionální prezentaci.

Použijte vlastnost `Transform` (která se vztahuje na celý blok textu) pomocí následujícího kódu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

Výsledný text:

![Transformace WordArt](transform_effect.png)

{{% alert color="info" %}} 

Aspose.Slides pro .NET poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/net/aspose.slides/textshapetype/).

{{% /alert %}} 

### **Aplikujte 3D efekty na tvary a text**

Vytváření realistických, poutavých vizuálů může výrazně zvýšit dopad vašich prezentací. V této části prozkoumáme, jak aplikovat trojrozměrné (3D) efekty na tvary pomocí Aspose.Slides pro .NET. Manipulací parametrů, jako je hloubka, úhel a osvětlení, můžete vytvořit působivé 3D transformace, které okamžitě zaujmou vaše publikum. Ať už cílíte na jemné zvýraznění nebo dramatické iluze, tyto funkce nabízejí flexibilní způsoby, jak pozvednout váš design a předat myšlenky poutavějším způsobem.

Použijte následující ukázkový kód k nastavení 3D efektu na tvar:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
}
```

Výsledný tvar:

![3D efekt tvaru](shape_3D_effect.png)

Použijte následující ukázkový kód k nastavení 3D efektu na text:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
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
}
```

Výsledný text:

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" %}} 

Aplikace 3D efektů na text nebo jejich tvary – a interakce mezi těmito efekty – je řízena konkrétními pravidly. Uvažujte scénář zahrnující jak text, tak tvar obsahující tento text. 3D efekt zahrnuje 3D reprezentaci objektu i scénu, na které je umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, má prioritu scéna tvaru a scéna textu se ignoruje.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá vůbec 3D efekt, je považován za plochý a 3D efekt se použije jen na text.

Tyto chování souvisí s vlastnostmi [ThreeDFormat.LightRig](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/lightrig/) a [ThreeDFormat.Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **Často kladené otázky**

### Mohu použít efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?

Ano, Aspose.Slides pro .NET podporuje Unicode a pracuje se všemi hlavními písmy a skripty. Efekty WordArt jako stín, výplň a obrys lze aplikovat bez ohledu na jazyk, i když dostupnost písma a vykreslování mohou záviset na systémových fontech.

### Mohu aplikovat efekty WordArt na prvky masteru snímků?

Ano, můžete aplikovat efekty WordArt na tvary na hlavních snímcích, včetně zástupných znaků titulku, patiček nebo textu na pozadí. Změny provedené v rozložení masteru se projeví ve všech souvisejících snímcích.

### Ovlivňují efekty WordArt velikost souboru prezentace?

Mírně. Efekty WordArt jako stíny, záře a gradientové výplně mohou velikost souboru mírně zvýšit kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

### Mohu zobrazit náhled výsledku efektů WordArt bez uložení prezentace?

Ano, můžete renderovat snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí metody `GetImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) nebo [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/). To vám umožní zobrazit náhled v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.