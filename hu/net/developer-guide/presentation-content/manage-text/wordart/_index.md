---
title: WordArt hatások létrehozása és alkalmazása .NET-ben
linktitle: WordArt
type: docs
weight: 110
url: /hu/net/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyék hatás
- megjelenítési hatás
- ragyogás hatás
- WordArt transzformáció
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET-ben WordArt hatásokat hozhat létre és testreszabhat. Ez a lépésről‑lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat C#‑ban."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adj hozzá a PowerPoint előadásaidhoz. Az Aspose.Slides for .NET segítségével a fejlesztők programozottan létrehozhatják, testreszabhatják és kezelhetik a WordArt-ot úgy, mint a Microsoft PowerPointben – anélkül, hogy az Office telepítve lenne. Ez a cikk átfogó képet nyújt a WordArt .NET-ben történő kezeléséről, beleértve a szövegtranszformációk, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy a prezentáció tartalma kifejezőbb és vonzóbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeld. Olyan hatásokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy vonzóbbá vagy feltűnőbbé tegyék.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

Ebben a szakaszban megvizsgáljuk, hogyan hozhatsz létre egyszerű WordArt sablont és alkalmazhatod azt szövegre az Aspose.Slides for .NET segítségével. A WordArt egyszerű módot kínál a szöveg megjelenésének javítására feltűnő vizuális hatások és stílusok alkalmazásával. A WordArt létrehozásának és használatának alaplépéseinek megtanulásával ezeket a technikákat könnyedén alkalmazhatod bármely projektben, élénkebbé és emlékezetesebbé téve az előadásokat.

First, we create simple text using the following C# code:

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

Now, we set the text’s font height to a larger value to make the effect more noticeable using the following code:

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

Here, we apply the SmallGrid pattern fill to the text and add a black text border with a width of 1 using the following code:

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

The resulting text:

![Az egyszerű WordArt sablon](WordArt_template.png)

## **Egyéb WordArt hatások alkalmazása**

Az alapvető transzformációkon túl az Aspose.Slides for .NET lehetővé teszi, hogy különféle fejlett WordArt hatásokat alkalmazz a szöveg megjelenésének javítására. Ezek közé tartoznak a körvonalak, kitöltések, árnyékok, tükrözések és ragyogási hatások. Ezeket a funkciókat kombinálva szemrevaló szövegstílusokat hozhatsz létre, amelyek kiemelkednek az előadásaidban. Ez a szakasz bemutatja, hogyan alkalmazhatod ezeket a hatásokat programozottan egyszerű, tiszta kódrészletekkel.

### **Külső árnyék hatások alkalmazása**

A külső árnyék hatások a szöveg körvonalá mögé árnyékot helyeznek, így mélységet és elkülönülést biztosítanak a háttértől. Az Aspose.Slides for .NET egyszerűen lehetővé teszi a külső árnyékok alkalmazását és testreszabását a WordArt szövegnél. Ebben a szakaszban megtanulod beállítani az árnyék színét, irányát, távolságát, elmosódási sugárát és egyebeket a kívánt vizuális hatás eléréséhez.

The following C# code snippet applies a shadow effect to the text created above.

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

The resulting text:

![A külső árnyék hatás](outer_shadow_effect.png)

{{% alert color="info" %}} 
- Amikor az OuterShadow és a PresetShadow együtt van használva, csak az OuterShadow hatás kerül alkalmazásra.
- Ha az OuterShadow és az InnerShadow egyszerre van használva, a kapott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013-ban a hatás duplázódik, míg a PowerPoint 2007-ben csak az OuterShadow hatás kerül alkalmazásra.
{{% /alert %}}

### **Tükrözés hatások alkalmazása**

Ebben a szakaszban megvizsgáljuk, hogyan alkalmazzunk tükrözés hatásokat a diákon az Aspose.Slides for .NET segítségével. A tükrözés hatásai hatékony módot nyújtanak arra, hogy a szöveg vagy alakzatok stílusos, modern megjelenést kapjanak, segítve a kulcsfontosságú elemek kiemelését és mélységet adva az előadásodnak. A hatások alkalmazásának és testreszabásának folyamatának megértésével könnyedén a tervezési igényeidhez és márkád követelményeihez igazíthatod őket.

Add a reflection effect to the text using this C# code example:

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

The resulting text:

![A tükrözés hatás](reflection_effect.png)

### **Ragyogás hatások alkalmazása**

Ebben a szakaszban megvizsgáljuk, hogyan alkalmazz ragyogás hatást a szövegre az Aspose.Slides for .NET segítségével. A ragyogás hatás kiemelheti a szöveget egy fénylő körvonallal, javítva a diák vizuális vonzerejét. A szín és intenzitás beállításával könnyedén a tervezésedhez és márkád igényeihez igazíthatod a ragyogást, biztosítva, hogy a kulcsfontosságú pontok felkeltsék a közönség figyelmét.

Apply a glow effect to the text to make it shine or stand out using the following code:

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

The resulting text:

![A ragyogás hatás](glow_effect.png)

### **WordArt transzformációk alkalmazása**

Ebben a szakaszban megvizsgáljuk, hogyan használhatók a transzformációk a WordArt-ban az Aspose.Slides for .NET segítségével. A transzformációk lehetővé teszik a szöveg hajlítását, nyújtását vagy torzítását, egyedi és látványos hatások létrehozását. E technikák elsajátításával könnyedén a szöveg alakját és stílusát a márka vagy kreatív elképzelésedhez igazíthatod, meggyőző és kifinomult előadást biztosítva.

Use the `Transform` property (which applies to the entire block of text) using the following code:

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

The resulting text:

![A WordArt transzformáció](transform_effect.png)

{{% alert color="info" %}} 
Az Aspose.Slides for .NET előre definiált [transzformáció típusok](https://reference.aspose.com/slides/hu/net/aspose.slides/textshapetype/)-et biztosít.
{{% /alert %}} 

### **3D hatások alkalmazása alakzatokra és szövegre**

A valósághű, szemkáprázó vizuális elemek jelentősen fokozhatják az előadások hatását. Ebben a szakaszban azt vizsgáljuk, hogyan alkalmazhatunk háromdimenziós (3D) hatásokat alakzatokra az Aspose.Slides for .NET segítségével. A mélység, szög és megvilágítás paramétereinek manipulálásával lenyűgöző 3D transzformációkat hozhatsz létre, amelyek azonnal felkeltik a közönség figyelmét. Legyen szó finom kiemelésekről vagy drámai illúziókról, ezek a funkciók rugalmas módot kínálnak a tervezésed emelésére és az ötletek hatásosabb közvetítésére.

Use the following sample code to set a 3D effect to the shape:

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

The resulting shape:

![Az alakzat 3D hatása](shape_3D_effect.png)

Use the following sample code to set a 3D effect to the text:

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

The resulting text:

![A szöveg 3D hatása](text_3D_effect.png)

{{% alert color="info" %}} 
A 3D hatások szövegre vagy alakzatra való alkalmazása—és ezen hatások kölcsönhatása—speciális szabályok szerint működik. Tekintsünk egy olyan jelenetet, amely egy szöveget és a szöveget tartalmazó alakzatot is magában foglalja. Egy 3D hatás tartalmazza az objektum 3D ábrázolását és a rá helyezett jelenetet.

- Ha egy jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete kap elsőbbséget és a szöveg jelenete figyelmen kívül marad.
- Ha az alakzat nem rendelkezik saját jelenettel, de 3D reprezentációja van, a szöveg jelenete lesz használva.
- Ha az alakzatnak egyáltalán nincs 3D hatása, laposként kezelik, és a 3D hatás csak a szövegre lesz alkalmazva.

Ezek a viselkedések a [ThreeDFormat.LightRig](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/lightrig/) és a [ThreeDFormat.Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/camera/) tulajdonságokra vonatkoznak.
{{% /alert %}} 

## **GYIK**

### Alkalmazhatok-e WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?

Igen, az Aspose.Slides for .NET támogatja az Unicode-ot, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt hatások, például az árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatók, bár a betűtípusok elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

### Alkalmazhatok-e WordArt hatásokat a dia mester elemeire?

Igen, WordArt hatásokat alkalmazhatsz a mester diákon található alakzatokra, beleértve a címhelyőrzőket, láblécet vagy háttérszöveget. A mester elrendezésben végzett módosítások minden kapcsolódó diára kiterjednek.

### Befolyásolják-e a WordArt hatások a prezentáció fájlméretét?

Enyhén. Az olyan WordArt hatások, mint az árnyékok, ragyogások és gradient kitöltések kissé növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

### Előnézhetem a WordArt hatások eredményét a prezentáció mentése nélkül?

Igen, a WordArt-ot tartalmazó diákat képekként (például PNG, JPEG) renderelheted a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) vagy [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) interfészek `GetImage` metódusával. Ez lehetővé teszi, hogy a memóriában vagy a képernyőn előnézetet készíts a mentés vagy a teljes prezentáció exportálása előtt.