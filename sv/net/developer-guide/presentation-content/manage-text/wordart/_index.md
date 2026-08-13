---
title: Skapa och tillämpa WordArt‑effekter i .NET
linktitle: WordArt
type: docs
weight: 110
url: /sv/net/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- visningseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för .NET. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i C#."
---
## **Översikt**

WordArt‑effekter gör att du kan lägga till visuellt tilltalande, styliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides för .NET kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva ha Office installerat. Denna artikel ger en översikt över hur du arbetar med WordArt i .NET, inklusive hur du tillämpar text‑omvandlingar, fyllnadsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt låter dig behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

I det här avsnittet utforskar vi hur du skapar en enkel WordArt‑mall och tillämpar den på text med Aspose.Slides för .NET. WordArt erbjuder ett enkelt sätt att förbättra textens utseende med slående visuella effekter och stilar. Genom att lära dig de grundläggande stegen för att skapa och använda WordArt kan du snabbt anpassa dessa tekniker till vilket projekt som helst, vilket gör dina presentationer mer livfulla och minnesvärda.

Först skapar vi enkel text med följande C#‑kod:

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

Nu sätter vi textens teckenhöjd till ett större värde för att göra effekten mer märkbar med följande kod:

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

Här applicerar vi SmallGrid‑mönsterfyllnad på texten och lägger till en svart textkant med bredden 1 med följande kod:

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

Den resulterande texten:

![Den enkla WordArt‑mallen](WordArt_template.png)

## **Applicera andra WordArt‑effekter**

Förutom grundläggande transformationer låter Aspose.Slides för .NET dig använda en mängd avancerade WordArt‑effekter för att förbättra textens utseende. Dessa inkluderar konturer, fyllningar, skuggor, reflektioner och glödeffekter. Genom att kombinera dessa funktioner kan du skapa iögonfallande textstilar som sticker ut i dina presentationer. Detta avsnitt demonstrerar hur du programatiskt applicerar dessa effekter med enkla, rena kodexempel.

### **Applicera yttre skuggeffekter**

Yttre skuggeffekter får texten att sticka ut genom att lägga till en skugga bakom dess kontur, vilket skapar en känsla av djup och separation från bakgrunden. Aspose.Slides för .NET låter dig enkelt applicera och anpassa yttre skuggor på WordArt‑text. I detta avsnitt lär du dig hur du ställer in skuggans färg, riktning, avstånd, oskärpa med mera för att uppnå önskad visuell effekt.

Följande C#‑kodsnutt applicerar en skuggeffekt på texten som skapades ovan.

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

Den resulterande texten:

![Yttre skuggeffekt](outer_shadow_effect.png)

{{% alert color="info" %}} 
- När OuterShadow och PresetShadow används tillsammans appliceras endast OuterShadow‑effekten.
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 dubblas effekten, medan i PowerPoint 2007 appliceras endast OuterShadow‑effekten.
{{% /alert %}}

### **Applicera reflektionseffekter**

I detta avsnitt utforskar vi hur du applicerar reflektionseffekter i dina bilder med Aspose.Slides för .NET. Reflektionseffekter kan vara ett effektivt sätt att ge din text eller dina former en stilren och modern look, vilket hjälper nyckelelement att sticka ut och ger djup åt presentationen. Genom att förstå processen för att applicera och anpassa dessa effekter kan du enkelt skräddarsy dem efter dina design‑ och varumärkesbehov.

Lägg till en reflektionseffekt på texten med följande C#‑kodexempel:

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

Den resulterande texten:

![Reflektionseffekt](reflection_effect.png)

### **Applicera glödeffekter**

I detta avsnitt utforskar vi hur du applicerar en glödeffekt på text med Aspose.Slides för .NET. Glödeffekten kan få din text att sticka ut med en lysande kontur, vilket förbättrar de visuella intrycken i dina bilder. Genom att justera inställningar som färg och intensitet kan du enkelt anpassa glödet så att det passar din design och ditt varumärke, vilket säkerställer att viktiga punkter i presentationen fångar publikens uppmärksamhet.

Applicera en glödeffekt på texten för att få den att skina eller stå ut med följande kod:

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

Den resulterande texten:

![Glödeffekt](glow_effect.png)

### **Applicera WordArt‑transformeringar**

I detta avsnitt utforskar vi hur du använder transformationer i WordArt med Aspose.Slides för .NET. Transformationer låter dig böja, sträcka eller vrida text, vilket skapar unika och visuellt iögonfallande effekter. Genom att bemästra dessa tekniker kan du enkelt anpassa textformer och stilar efter ditt varumärke eller kreativa vision, vilket säkerställer en övertygande och polerad presentation.

Använd egenskapen `Transform` (som gäller för hela textblocket) med följande kod:

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

Den resulterande texten:

![WordArt‑transformation](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides för .NET tillhandahåller en uppsättning fördefinierade [transformeringstyper](https://reference.aspose.com/slides/sv/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **Applicera 3D‑effekter på former och text**

Att skapa realistiska, iögonfallande visuella element kan avsevärt förbättra intrycket av dina presentationer. I detta avsnitt utforskar vi hur du applicerar tredimensionella (3D)‑effekter på former med Aspose.Slides för .NET. Genom att manipulera parametrar som djup, vinkel och belysning kan du producera imponerande 3D‑transformationer som omedelbart fångar publikens uppmärksamhet. Oavsett om du siktar på subtila höjdpunkter eller dramatiska illusioner erbjuder dessa funktioner flexibla sätt att lyfta din design och förmedla idéer på ett mer fängslande sätt.

Använd följande exempel­kod för att sätta en 3D‑effekt på formen:

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

Den resulterande formen:

![Formens 3D‑effekt](shape_3D_effect.png)

Använd följande exempel­kod för att sätta en 3D‑effekt på texten:

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

Den resulterande texten:

![Textens 3D‑effekt](text_3D_effect.png)

{{% alert color="info" %}} 
Appliceringen av 3D‑effekter på text eller deras former—och interaktionen mellan dessa effekter—styrs av specifika regler. Tänk på en scen som innehåller både en text och formen som innehåller texten. En 3D‑effekt omfattar objektets 3D‑representation och scenen den placeras i.

- Om en scen är angiven både för formen och för texten har formen prioritet och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation används textens scen.
- Om formen inte har någon 3D‑effekt alls behandlas den som platt, och 3D‑effekten appliceras endast på texten.

Dessa beteenden relaterar till egenskaperna [ThreeDFormat.LightRig](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/lightrig/) och [ThreeDFormat.Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

### Kan jag använda WordArt‑effekter med olika typsnitt eller skript (t.ex. arabiska, kinesiska)?

Ja, Aspose.Slides för .NET stöder Unicode och fungerar med alla större typsnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om tillgänglighet och rendering av typsnitt kan bero på systemets fonter.

### Kan jag applicera WordArt‑effekter på element i bildmaster?

Ja, du kan applicera WordArt‑effekter på former i masterbilder, inklusive titel‑platshållare, sidfot eller bakgrundstext. Ändringar som görs i masterlayouten kommer att återspeglas i alla associerade bilder.

### Påverkar WordArt‑effekter presentationens filstorlek?

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av ytterligare formateringsmetadata, men skillnaden är vanligtvis försumbar.

### Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?

Ja, du kan rendera bilder som innehåller WordArt till bildformat (t.ex. PNG, JPEG) med hjälp av `GetImage`‑metoden från [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/) eller [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.