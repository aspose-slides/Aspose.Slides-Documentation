---
title: .NET használatával 3D hatások létrehozása prezentációkban
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D effektusokat PowerPoint alakzatokra és szövegre .NET környezetben az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrudálást, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint‑szerű 3D formázást alakzatokhoz és szöveghez. Ez a cikk a 3D effektusokat, például a forgatást, extrudálást, peremeket, megvilágítást, anyagot, színátmenetes vagy képes kitöltést, valamint a 3D szöveget tárgyalja.

{{% alert color="primary" %}}
Ez a cikk a PowerPoint‑alakzatok és szöveg 3D formázási effektusairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D effektusokat a exportált 2D kimenetbe rendeli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja a [IShape.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/threedformat) tulajdonságot a 3D formázás alkalmazásához egy alakzatra. A tulajdonság elérhetővé teszi az [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat) objektumot, amely a 3D jelenetet szabályozza az adott alakzatra.

Szöveghez használja a [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/threedformat) tulajdonságot. Ez a 3D formázást a szövegkeretre alkalmazza az alakzattörzs helyett.

A legfontosabb tulajdonságok:

| Tulajdonság | Mit szabályoz | Mikor használja |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/camera) | Nézetpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Forgassa az objektumot 3D térben, vagy egyeztesse a PowerPoint 3D forgatás előbeállított értékével. |
| [LightRig](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/lightrig) | Fény előbeállítás, irány és fényforgás. | Módosítsa, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [Material](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/material) | Felületi anyag, például sík, matt, műanyag vagy fém. | Tegye ugyanazt a geometriát laposabbá, puhábbá, fényesebbé vagy fémesebbé. |
| [ExtrusionHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusionheight) | Milyen messzire nyúlik vissza az alakzat az első felületétől. | Alakítson egy sík alakzatot láthatóan vastag 3D objektummá. |
| [ExtrusionColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Az extrudált oldalak színe. | Tegye a mélységet láthatóvá vagy igazítsa az oldalsó színt az első kitöltéshez. |
| [Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/depth) | További 3D mélység, amelyet a PowerPoint 3D formázása használ. | Finomhangolja a mélységet alakzatok vagy szöveg számára, különösen a bevel és anyag beállításokkal együtt. |
| [BevelTop](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/beveltop) és [BevelBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/bevelbottom) | Emelt vagy lekerekített élek az első és hátsó felületeken. | Adj hozzá lágy vagy formázott élt a hegyes sík felület helyett. |
| [ContourColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/contourcolor) és [ContourWidth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/contourwidth) | Körvonal a 3D objektum körül. | Emelje ki az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt hiteles 3D‑ként jelenik meg:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrudálást.
- Világítás beállítások, mivel a fény megkülönbözteti a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja a fény megjelenítését.
- Extrudálás vagy mélység beállítások, mivel egy sík alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az előoldalához, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, majd a diát PNG képre rendereli.

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

A renderelt dia kép mutatja a téglalapot vastag 3D blokként:

![Megjelenített kék 3D téglalap fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPoint‑ban a 3D forgatást a **3‑D Rotation** ablaktáblán állítják be. Az X, Y és Z forgatási értékek felelnek meg annak a forgatásnak, amelyet a kamera API‑val ad meg.

![PowerPoint 3‑D Rotation ablaktábla X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑nél a kamera típusát és forgatását a [IThreeDFormat.Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/camera) segítségével állíthatja be:

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Használja a kamerát, ha meg szeretné változtatni, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzatgeometriát a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat azzal, hogy kinyújtja azt az első felület mögé. PowerPoint‑ban a mélység vezérlő határozza meg ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység vezérlők leképezve az extrudálás színre és extrudálás magasság tulajdonságokra](img_02_02.png)

Állítsa be a [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusionheight) értékét a vastagságra és a [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusioncolor) értékét az oldal színére:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Használja az [IThreeDFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/depth) tulajdonságot, ha közvetlenül a PowerPoint mélységértékével akar dolgozni, vagy a mélységet kombinálná a bevel, anyag és szövegeffektusokkal. Sok alakzatszituációban az `ExtrusionHeight` egyértelműbb beállítás, mert közvetlenül a látható extrudálást fejezi ki.

## **Színátmenetes vagy képes kitöltés használata 3D effektusokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy egyszínű, színátmenetes, mintás vagy képes kitöltést az előoldalon, miközben ugyanazt a kamera, világítás, anyag és extrudálás beállításokat használja.

Ez a példa színátmenetes kitöltést ad az alakzatra és sötétebb extrudálási színt az oldalakra:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához adja hozzá a képet a prezentációhoz, majd rendelje hozzá az alakzat kitöltéséhez:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Renderelt 3D téglalap fotó kitöltéssel az előoldalon és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása a forma testére hat. A szöveg 3D formázása a szövegkeretre. Ez hasznos WordArt‑szerű effektusoknál, ahol a betűknek maguknak is szükségük van extrudálásra, anyagra, megvilágításra és kamera beállításokra.

A következő példa mintás kitöltéssel hoz létre szöveget, WordArt átalakítást alkalmaz, és konfigurálja a 3D beállításokat az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat)‑nél:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás során fix elrendezésű formátumokba a 3D jelenet rasterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/net/convert-powerpoint-to-png/)-re rendereli, [PDF](/slides/hu/net/convert-powerpoint-to-pdf/)-re exportál, [HTML](/slides/hu/net/convert-powerpoint-to-html/)-re exportál, vagy [videó konverzió](/slides/hu/net/convert-powerpoint-to-video/) kereteket generál.

Tartsa szem előtt a következőket:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja forgatni az export után.
- A végső megjelenés a kamera, fényrig, anyag, extrudálás, kitöltés és a dia skálázás kombinációjától függ.
- Ha meg szeretné tekinteni az örökölt vagy sablon alapú formázási értékeket, olvassa el a [hatásos alakzat tulajdonságok](/slides/hu/net/shape-effective-properties/) oldalt.
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként marad meg.

## **GYIK**

**Képes-e az Aspose.Slides interaktív 3D prezentációk létrehozására?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D effektusokat alakzatokra és szövegre. Nem tesz exportált képeket, PDF‑eket vagy HTML oldalakat interaktív 3D jelenetekké, amelyet a felhasználó forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ha a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D effektus egy formázás, amelyet egy szabványos PowerPoint alakzatra vagy szövegre alkalmaznak, például forgatás, extrudálás, perem, megvilágítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és vagy extrudálást vagy mélységet kell beállítani. Gyakorlatban ajánlott a fényrig és az anyag beállítása is, hogy a renderelt felületeknek egyértelmű kiemelései és árnyékai legyenek.

**Alkalmazhatok‑e 3D effektusokat alakzatokra és szövegre egyaránt?**

Igen. Használja a [IShape.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/threedformat)‑t az alakzat testére, és a [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/threedformat)‑t a szövegre.

**Megjelennek‑e a 3D effektusok exportáláskor képekre, PDF‑re, HTML‑re vagy videó keretekre?**

Igen. Az Aspose.Slides rendereli a 3D effektusokat diaképek, PDF‑kimenet, HTML‑kimenet és a videókonverzióhoz használt keretek előállítása során. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom‑e a végső 3D értékeket az öröklődés és a sablon beállítások alkalmazása után?**

Igen. Használja a hatásos formázási API‑kat, amelyek a [Shape Effective Properties](/slides/hu/net/shape-effective-properties/) leírásában szerepelnek, a végső kamera, fényrig, bevel és egyéb 3D értékek kiolvasásához.