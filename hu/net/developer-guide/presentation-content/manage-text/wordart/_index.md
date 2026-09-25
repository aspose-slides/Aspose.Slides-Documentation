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
- WordArt effektus
- árnyékhatás
- tükrözési hatás
- ragyogás hatás
- WordArt transzformáció
- 3D hatás
- külső árnyékhatás
- belső árnyékhatás
- .NET
- C#
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for .NET-ben. Ez a lépésről-lépésre útmutató segít a fejlesztőknek professzionális szöveggel kibővíteni a prezentációkat C#-ban."
---
## **Áttekintés**

WordArt hatások lehetővé teszik, hogy szöveget töltséggel, körvonallal, árnyékkal, tükrözéssel, ragyogással, transzformációkkal és 3D formázással stilizálj. Ez a cikk bemutatja, hogyan hozhatók létre és testreszabhatók ezek a hatások PowerPoint prezentációkban az Aspose.Slides for .NET használatával, Microsoft Office telepítése nélkül.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

Következő példák egyszerű WordArt stílust építenek a szöveg, betűtípus, minta kitöltés és körvonal beállításával.

Minden példa egy új prezentációt hoz létre, és egy téglalapot ad hozzá az első diájához; bemeneti fájl nem szükséges. Az első példa a szöveget "Aspose.Slides"-re állítja. A alakzat pozícióját és méreteit pontban mérik:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Állítsa a betűtípust Arial Black-ra 36 pontban, hogy a formázás jobban észrevehető legyen:

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

Alkalmazzon egy [SmallGrid](https://reference.aspose.com/slides/hu/net/aspose.slides/patternstyle/) mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy 1 pont széles fekete szöveg körvonalat:

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

Az eredményes szöveg:

![Az egyszerű WordArt sablon](WordArt_template.png)

## **Egyéb WordArt hatások alkalmazása**

Következő példák bemutatják, hogyan alkalmazhatók árnyékok, tükrözések, ragyogás, transzformációk és 3D hatások a szövegre.

### **Külső árnyék hatások alkalmazása**

Az külső árnyék mélységet ad a szöveg mögé helyezett árnyékkal. A szín, irány, távolság, elmosódási sugár, méretezés és torzítás testreszabható.

Ez a példa meghívja a [EnableOuterShadowEffect](https://reference.aspose.com/slides/hu/net/aspose.slides/effectformat/enableoutershadoweffect/) metódust, és egy fekete árnyékot állít be 4 pont elmosódási sugárral, 230 fokos iránnyal és 30 pont távolsággal. A 100-as méretezési érték megtartja az árnyék méretét, míg a 20 fokos vízszintes torzítás megbillenti azt. Az alfa transzformáció 32%-os áttetszőséget állít be:

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

Az eredményes szöveg:

![A külső árnyék hatás](outer_shadow_effect.png)

{{% alert color="info" title="Megjegyzés" %}}
- Ha a külső és előre beállított árnyékok együtt vannak használva, csak a külső árnyék kerül alkalmazásra.
- Ha a külső és belső árnyékok egyszerre vannak használva, az eredmény hatása a PowerPoint verziójától függ. Például a PowerPoint 2013-ban a hatás duplázódik, míg a PowerPoint 2007-ben csak a külső árnyék kerül alkalmazásra.
{{% /alert %}}

### **Tükrözés hatások alkalmazása**

Egy tükrözés tükrözött másolatot hoz létre a szövegből. Állítsa be a pozíciót, méretezést, elmosódást és áttetszőséget a megjelenés szabályozásához.

Ez a példa meghívja a [EnableReflectionEffect](https://reference.aspose.com/slides/hu/net/aspose.slides/effectformat/enablereflectioneffect/) metódust, és függőlegesen tükrözi a reflexiót -100%-os méretezéssel. 0,5 pont elmosódási sugárral és 4,72 pont távolsággal dolgozik. Az áttetszőség 60%-ról 0,9%-ra csökken a 0% és 60% közötti pozíciók között a reflexión:

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

Az eredményes szöveg:

![A tükrözés hatás](reflection_effect.png)

### **Ragyogás hatások alkalmazása**

A ragyogás lágy színes körvonalat ad a szöveg köré. Állítsa be a színét, áttetszőségét és sugárát a hatás szabályozásához.

Ez a példa meghívja a [EnableGlowEffect](https://reference.aspose.com/slides/hu/net/aspose.slides/effectformat/enablegloweffect/) metódust, és piros ragyogást alkalmaz 54%-os áttetszőséggel és 7 pont sugárral:

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

Az eredményes szöveg:

![A ragyogás hatás](glow_effect.png)

### **WordArt transzformációk alkalmazása**

WordArt transzformációk hajlítják, nyújtják vagy torzítják a szövegtömböt.

A [Transform](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/transform/) beállítása [ArchUpPour](https://reference.aspose.com/slides/hu/net/aspose.slides/textshapetype/) értékre azt eredményezi, hogy az egész szövegkeret felfelé ível:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Az eredményes szöveg:

![A WordArt transzformáció](transform_effect.png)

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose.Slides for .NET előre definiált [transzformáció típusok](https://reference.aspose.com/slides/hu/net/aspose.slides/textshapetype/) készletet biztosít.
{{% /alert %}}

### **3D hatások alkalmazása alakzatokra és szövegre**

3D hatásokat alkalmazhat egy alakzatra vagy annak szövegére. A lekerekítések, kitüremkedés, világítás és kamera beállítások határozzák meg a végeredményt.

A következő példa a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) használatával körkörös lekerekítéseket, narancssárga kitüremkedést és sötétvörös körvonalat ad a téglalaphoz. A lekerekítések méretei, a kitüremkedés magassága, a körvonal szélessége és mélysége pontban mérve. Egy műanyag anyag, 40 fokban Z tengely körül elforgatott kiegyensúlyozott világítás és perspektív kamera határozza meg a megjelenést:

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

Az alakzat 3D hatása:

![Az alakzat 3D hatása](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/threedformat/) segítségével. A kisebb lekerekítések az betűk széleit formálják, míg a kitüremkedés és a világítás mélységet adnak a szövegnek:

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

A szöveg 3D hatása:

![A szöveg 3D hatása](text_3D_effect.png)

{{% alert color="info" title="Megjegyzés" %}}
A 3D hatások szövegre vagy azok alakzataira való alkalmazását – valamint a hatások közötti kölcsönhatást – specifikus szabályok irányítják. Tekintsünk egy jelenetet, amely magában foglalja a szöveget és a azt tartalmazó alakzatot. Egy 3D hatás magában foglalja az objektum 3D ábrázolását és a benne elhelyezkedő jelenetet.
- Ha a jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete kap elsőbbséget, a szöveg jelenete figyelmen kívül marad.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete kerül felhasználásra.
- Ha az alakzatnak egyáltalán nincs 3D hatása, laposként kezelik, és a 3D hatás csak a szövegre kerül alkalmazásra.
Ezek a viselkedések a [ThreeDFormat.LightRig](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/lightrig/) és a [ThreeDFormat.Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/camera/) tulajdonságokra vonatkoznak.
{{% /alert %}}

A szöveg lapos és olvasható állapotának megtartása, miközben az alakzat 3D formázása megmarad, lásd a [Keep Text Flat on a 3D Shape](/slides/hu/net/3d-presentation/) oldalon, ahol összehasonlítást láthat a két beállításról és egy teljes C# példát.

## **GYIK**

**Használhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides for .NET támogatja az Unicode-ot, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt hatásokat, mint az árnyék, kitöltés és körvonal, a nyelvtől függetlenül alkalmazhatók, bár a betűtípusok elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt hatásokat a dia mester elemeire?**

Igen, WordArt hatásokat alkalmazhat a mester diák alakzataira, beleértve a címhelyettesítőket, láblécet vagy háttérszöveget. A mester elrendezésén végzett módosítások minden kapcsolódó diába átkerülnek.

**Növelik a WordArt hatások a prezentáció fájlméretét?**

Enyhén. A WordArt hatások, mint az árnyékok, ragyogás és színátmenetes kitöltések, kismértékben növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Megnézhetem a WordArt hatások eredményét mentés nélkül?**

Igen, a WordArt-ot tartalmazó diák képekké (pl. PNG, JPEG) renderelhetők a [ISlide.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) segítségével, vagy különálló alakzatok renderelhetők a [IShape.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getimage/) metódussal. Ez lehetővé teszi az eredmény előnézetét memóriában vagy a képernyőn, mielőtt mentené vagy exportálná a teljes prezentációt.