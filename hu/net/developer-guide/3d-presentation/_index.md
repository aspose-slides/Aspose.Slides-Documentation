---
title: 3D hatások létrehozása prezentációkban .NET használatával
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
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre .NET környezetben az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrudálást, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes létrehozni, szerkeszteni, megőrizni és megjeleníteni PowerPoint‑stílusú 3D formázást alakzatokra és szövegre. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrudálás, levágások, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről van szó. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat a kiexportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D Formázási Fogalmak**

Használja az [IShape.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/threedformat) tulajdonságot a 3D formázás alkalmazásához egy alakzatra. A tulajdonság exponálja az [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat) felületet, amely az adott alakzat 3D jelenetét szabályozza.

Szöveghez használja az [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/threedformat) tulajdonságot. Ez a 3D formázást a szövegkeretre alkalmazza az alakzat testének helyett.

A legfontosabb tulajdonságok:

| Tulajdonság | Mit szabályoz | Mikor használja |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/camera) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Forgassa az objektumot 3D térben, vagy illessze a PowerPoint 3D forgatás előre beállított értékéhez. |
| [LightRig](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/lightrig) | Fény előre beállítás, irány, és fény forgatás. | Módosítsa a kiemelések és árnyékok megjelenését a 3D felületen. |
| [Material](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/material) | Felületi anyag, például sima, matt, műanyag vagy fém. | Tegye ugyanezen geometriai alakot laposabbá, lágyabbá, fényesebbé vagy fémesebbé. |
| [ExtrusionHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusionheight) | Milyen messzire nyúlik az alakzat hátrafelé az első felületétől. | Alakítson egy sík alakzatot láthatóan vastag 3D objektummá. |
| [ExtrusionColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Az extrudált oldalak színe. | Tegye a mélységet láthatóvá, vagy egyeztesse az oldal színét az első kitöltéssel. |
| [Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/depth) | A PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a levágás és anyag beállításokkal együtt. |
| [BevelTop](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/beveltop) és [BevelBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/bevelbottom) | Emelt vagy lekerekített élek az első és hátsó felületeken. | Adjon hozzá lágyabb vagy formázott élt a hegyes sík felület helyett. |
| [ContourColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/contourcolor) és [ContourWidth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/contourwidth) | Körvonal a 3D objektum körül. | Emelje ki az objektum határát a renderelt kimenetben. |

## **3D Alakzat Létrehozása**

Egy alakzathoz általában négyféle beállítás szükséges, hogy meggyőzően 3D‑snek tűnjön:

- Kamera beállítások, mert az alapértelmezett elülső nézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás olvashatóvá teszi a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mert egy sík alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az első felületéhez, alkalmaz 3D formázást, PPTX formátumban menti a prezentációt, és a diát PNG képre rendereli.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Az renderelt dia kép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat Forgatása Kamerával**

PowerPoint‑ban a 3D forgatás a 3‑D Forgatás panelen állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D Forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ban a kamera típust és forgatást a [IThreeDFormat.Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/camera) segítségével állíthatja be:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Használja a kamerát, amikor meg kell változtatni, hogyan látja a néző az objektumot. Nem módosítja a 2D alakzat geometriáját a dián. Megváltoztatja a PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot.

## **Extrudálás és Mélység Hozzáadása**

Az extrudálás az alakzatot vastagnak mutatja azáltal, hogy a front felület mögé nyúlik. PowerPoint‑ban a mélység vezérlés beállítja ezt a látható vastagságot, a szín vezérlés pedig az oldalfelületek színét állítja be.

![PowerPoint mélység vezérlések leképezve az extrudálás színre és magasság tulajdonságokra](img_02_02.png)

Állítsa be a [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusionheight) a vastagsághoz, és a [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusioncolor) az oldalak színéhez:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Használja a [IThreeDFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/depth) beállítást, amikor közvetlenül a PowerPoint mélység értékével kell dolgozni, vagy a mélységet össze kell kombinálni a bevel, anyag és szövegeffektusokkal. Sok alakzati esetben az `ExtrusionHeight` egyértelműbb, mert közvetlenül kifejezi a látható extrudálást.

## **Színátmenetes vagy Képes Kitöltés 3D Hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egyszínű, színátmenetes, mintás vagy képes kitöltést az első felületre, miközben ugyanazokat a kamera, fény, anyag és extrudálás beállításokat használja.

Ez a példa színátmenetes kitöltést alkalmaz az alakzatra, és egy sötétebb extrudálás színt az oldalakon:

```csharp
using System.Drawing;
using Aspose.Slides;

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

Az renderelt kimenet megőrzi a színátmenetet az első felületen, és külön rendereli az extrudálást:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Hogy képes kitöltést használjon, adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Renderelt 3D téglalap fénykép kitöltéssel az első felületen és narancssárga extrudálással](img_02_04.png)

## **3D Formázás Alkalmazása Szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos a WordArt‑szerű hatásoknál, ahol a betűknek maguknak kell extrudálás, anyag, megvilágítás és kamera beállítások.

A következő példa szöveget hoz létre mintás kitöltéssel, WordArt átalakítást alkalmaz, és 3D beállításokat konfigurál az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat) felületen:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

A szöveg ívelt, extrudált 3D betűként kerül renderelésre:

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Exportálás és Renderelés Viselkedése**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumokba, például PPTX‑be történő mentéskor. Renderelés vagy fix elrendezésű formátumokba exportáláskor a 3D jelenet raszterizálódik vagy a kimenetbe 2D eredményként kerül be. Ez akkor érvényes, amikor a diákat [PNG](/slides/hu/net/convert-powerpoint-to-png/), [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), [HTML](/slides/hu/net/convert-powerpoint-to-html/) formátumba rendereli, vagy a [video konverzió](/slides/hu/net/convert-powerpoint-to-video/) kereteit generálja.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot az export után a néző nem tudja forgatni.
- A végső megjelenés a kamera, fény rig, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy témára alapozott formázási értékeket, olvassa el a [effective shape properties](/slides/hu/net/shape-effective-properties/).
- Néhány kimeneti formátum nem tud szerkeszthető PowerPoint 3D formázást tárolni. Ezekben a formátumokban a vizuális eredmény renderelve kerül a szerkeszthető 3D beállítások helyett.

## **GYIK**

### Készíthet az Aspose.Slides interaktív 3D prezentációkat?

Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatokra és szövegre. Nem teszi az exportált képeket, PDF‑eket vagy HTML oldalak interaktív 3D jelenetekké, amelyet a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

### Mi a különbség egy 3D modell és egy 3D hatás között?

A 3D modell egy különálló 3D objektum a prezentációba beszúrva. A 3D hatás egy formázás, amelyet egy szabályos PowerPoint alakzatra vagy szövegre alkalmaznak, például forgatás, extrudálás, levágás, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

### Mely beállítások szükségesek egy látható 3D alakzathoz?

Legalább egy kamera forgatás és vagy extrudálás vagy mélység beállítása szükséges. Gyakorlati szinten érdemes fény riget és anyagot is beállítani, hogy a renderelt felületeknek legyenek egyértelmű kiemelések és árnyékok.

### Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?

Igen. Használja az [IShape.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/threedformat) a alakzat testhez, és az [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/threedformat) a szöveghez.

### Megjelennek a 3D hatások képek, PDF, HTML vagy videó keretek exportálásakor?

Igen. Az Aspose.Slides rendereli a 3D hatásokat amikor a diaszeme képek, PDF, HTML vagy videó konverzióhoz használt kereteket állítja elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

### Olvashatok a végleges 3D értékeket az öröklődés és a téma beállítások alkalmazása után?

Igen. Használja a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/net/shape-effective-properties/) leírásában részleteznek, a végső kamera, fény rig, bevel és kapcsolódó 3D értékek olvasásához.