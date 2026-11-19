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
description: "Alkalmazzon és rendereljen 3D hatásokat a PowerPoint alakzatokra és szövegre .NET környezetben az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint-szerű 3D formázást alakzatokra és szövegre. Ez a cikk a 3D hatásokat, például a forgatást, extrudálást, rézsút, megvilágítást, anyagot, színátmenetes vagy képes kitöltéseket és a 3D szöveget tárgyalja.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem az önálló 3D modellfájlok beillesztéséről vagy szerkesztéséről van szó. Ha egy diát képre, PDF-re vagy HTML-re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja az [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) tulajdonságot a 3D formázás alkalmazásához egy alakzatra. A tulajdonság elérhetővé teszi az [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), amely a 3D jelenetet szabályozza az adott alakzatra.

Szövegnél használja az [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) tulajdonságot. Ez a 3D formázást a szövegkerethez alkalmazza ahelyett, hogy a alakzat testehez.

A legfontosabb tulajdonságok a következők:

| Tulajdonság | Mi irányítja | Mikor használjuk |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Nézőpont, előre definiált kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy PowerPoint 3D forgatási előre beállításának egyezése. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Fény beállítás, irány és fény forgatás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabb, puhább, fényesebb vagy fémesebb megjelenésben. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Mennyi távolságra nyúlik ki az alakzat hátsó felületéről. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldal színének a front kitöltéssel való összehangolása. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Kiegészítő 3D mélység, amelyet a PowerPoint 3D formázás használ. | A mélység finomhangolása alakzatok vagy szöveg esetén, különösen a rézsú és anyag beállításokkal együtt. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) és [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Emelkedő vagy lekerekített él a front és hát oldalon. | Lágyabb vagy formázott él hozzáadása éles, lapos felület helyett. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) és [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Körvonal a 3D objektum körül. | Az objektum határok kiemelése a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt hitelesen 3D-nek tűnik:
- Kamera beállítások, mert az alapértelmezett frontál nézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá az oldalakat és felületeket.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad a front felülethez, és alkalmaz 3D formázást. A kamera forgatási értékek fokban vannak, az extrudálás magassága 100 pont. A példa a diát PNG képre rendereli a nyers méret kétszeresére, és a prezentációt PPTX formátumban menti.

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

A renderelt dia kép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel a front felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3-D forgatás panelen konfigurálható. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3-D forgatás panel kiemelt X, Y és Z forgatási értékekkel](img_02_01.png)

Az Aspose.Slides-ban a kamerához a [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) segítségével férhet hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai front nézetet választ, és az X, Y és Z forgatásait 20, 30 illetve 40 fokra állítja. A alakzatot memóriában konfigurálja anélkül, hogy fájlt mentene:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Használja a kamerát, amikor meg akarja változtatni, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

### **Kameraorientáció másolása sablon alakzatról**

A sablonban lévő alakzat egyezéséhez másolja annak [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) előre beállítását, és olvassa be szögeit a [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) segítségével. A példa megnyitja a `template.pptx` fájlt, beolvassa az első dia első alakzatának kameráját, és a második alakzatra alkalmazza az orientációt. Mindkét alakzat már rendelkezik 3D megvilágítással, és a második alakzatnak nincs explicit kamera forgatása.

A szögek fokban vannak. A `0` index a szélesség, az `1` index a hosszúság, a `2` index a fordulat. Ezeket ebben a sorrendben adja át a [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) metódusnak. Ha a forrás `null`‑t ad vissza, nincs explicit forgatás, ezért a második alakzat szögeit hagyja beállítatlanul. A `(0, 0, 0)` explicit forgatás három nullát ad vissza, és másolandó.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

Amikor újra megnyitja a `camera-copy.pptx` fájlt, a két alakzat ugyanazt a kamera előre beállítást és forgatást használja. PowerPointban a jobb oldali nyíl a bal oldali téglalapról másolt kameraorientációt használja. Mindkét alakzat ugyanazt a megvilágítást és extrudálási mélységet használja.

![Egy kék 3D téglalap és egy jobb nyíl egyező kameraorientációval, felülről és jobbról nézve](camera-orientation.png)

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat azáltal, hogy meghosszabbítja azt a front felület mögött. PowerPointban a mélység vezérlés állítja be ezt a látható vastagságot, a szín vezérlés pedig az oldalfelületek színét.

![PowerPoint mélység szabályozók leképezve az extrudálás színére és magasság tulajdonságaira](img_02_02.png)

Állítsa be az [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) értékét a vastagsághoz és az [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) értékét az oldalfelület színéhez. Ez a példa egy 100 pontos extrudálást ad a téglalapnak lila oldalakkal, és a kamerát forgatja, hogy felfedje a vastagságát. A alakzatot memóriában konfigurálja anélkül, hogy fájlt mentene:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Az [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) tulajdonság beállítja egy 3D alakzat mélységét. Az [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) tulajdonság szabályozza az extrudálási hatás magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltések használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egyszínű, színátmenetes, mintás vagy képes kitöltést a front felületre, miközben ugyanazokat a kamera-, fény-, anyag- és extrudálás beállításokat használja.

Ez a példa kékre‑narancssárga színátmenetet alkalmaz a front felületre, és sötét narancssárga színt a 150 pontos extrudálásra. A színátmenet állomásai a 0‑nál és 100‑nál jelölik a színátmenet kezdetét és végét. A kamera forgatási értékek fokban vannak. A dia PNG képre renderelődik a nyers méret kétszeresére:

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

A renderelt kimenet megtartja a színátmenetet a front felületen, és külön rendereli az extrudálást:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához adja a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy meglévő, a munkakönyvtárban lévő „image.jpg” nevű fájlt igényli. A képet kinyújtja, hogy kitöltse a téglalapot, 150 pontos extrudálást alkalmaz, és a kamera forgatását fokban állítja be. A alakzatot memóriában konfigurálja anélkül, hogy fájlt mentene vagy renderelne:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

A kép a front felületre kerül renderelésre, míg az extrudálás a 3D oldalfelületként jelenik meg:

![Renderelt 3D téglalap fotós kitöltéssel a front felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása a alakzat testét befolyásolja. A szöveg 3D formázása a szövegkeretet érinti. Ez hasznos a WordArt-szerű hatásokhoz, ahol maguk a betűknek is szükségük van extrudálásra, anyagra, megvilágításra és kamera beállításokra.

A következő példa egy narancssárga‑fehér rácsmintával rendelkező szöveget hoz létre, felfelé ívelt görbét alkalmaz, és 3D beállításokat konfigurál az [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) segítségével. Az extrudálás magassága és mélysége pontban, a fény forgatása fokban van. Az alakzat kitöltése és körvonala rejtve van, így csak a szöveg látható. A példa PNG képet renderel a dia alapméretének kétszeresén, és a prezentációt PPTX‑ként menti:

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

A szöveg görbe, extrudált 3D betűként renderelődik:

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának fenntartásához, miközben az alakzat 3D megjelenését megőrzi, állítsa be az [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) értékét az [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jelenetből. Ha `false`, a szöveg részt vesz a jelenetben és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, a megvilágítás, az anyag és az extrudálás továbbra is az [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) segítségével van beállítva. Emellett különbözik a szokásos forgatástól. Az [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) a alakzatot a dia síkjában forgatja, míg az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) a szöveg egyéni forgatását szabályozza a határoló keretén belül. A szöveg 3D jelenetből való kivétel sem állítja vissza ezeket a szögeket.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és az eredeti mellett klónozza. Mindkét alakzat ugyanazt a 3D formázást használja; csak a szöveg beállítása különbözik: a bal oldalon `false`, a jobb oldalon `true`. A kamera szögek fokban vannak, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli a nyers méret kétszeresén.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

A bal oldalon a szöveg a 3D orientációt követi. A jobb oldalon sík marad és könnyebben olvasható. Mindkét téglalap ugyanazt a látható extrudálást és 3D orientációt tartja meg.

![Egymás mellett lévő 3D téglalapok: KeepTextFlat bal oldalon false, jobb oldalon true](keep_text_flat.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumokba, például PPTX‑be mentéskor. Renderelés vagy exportálás fix elrendezésű formátumokba esetén a 3D jelenet rasterizálódik vagy 2D eredményként kerül a kimenetbe. Ez akkor is érvényes, amikor diákot renderel a [PNG](/slides/hu/net/convert-powerpoint-to-png/), exportál a [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), exportál a [HTML](/slides/hu/net/convert-powerpoint-to-html/), vagy kereteket generál a [video conversion](/slides/hu/net/convert-powerpoint-to-video/) számára.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot az export után a néző nem tudja forgatni.
- A végső megjelenés a kamera, a fényrendszer, az anyag, az extrudálás, a kitöltés és a dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia örökölt vagy téma‑alapú formázási értékeket, olvassa el a [hatékony alakzat tulajdonságok](/slides/hu/net/shape-effective-properties/) oldalt.
- Néhány kimeneti formátum nem tárolhat szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve jelenik meg, nem szerkeszthető 3D beállításként tárolva.

## **GYIK**

**Készíthet-e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásokat alakzatokra és szövegre. Nem tesz az exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetekké, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló 3D objektum, amely a prezentációba van beszúrva. A 3D hatás egy formázás, amelyet egy szabályos PowerPoint alakzatra vagy szövegre alkalmaznak, mint például forgatás, extrudálás, rézsú, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Mely beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és vagy extrudálást vagy mélységet kell beállítani. Gyakorlatban ajánlott a fényrendszert és az anyagot is beállítani, hogy a renderelt felületeknek világos kiemelései és árnyékai legyenek.

**Alkalmazhatok-e 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használja az [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) a alakzat testére, és az [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) a szövegre.

**Megjelennek-e a 3D hatások képek, PDF, HTML vagy videokeretek exportálásakor?**

Igen. Az Aspose.Slides rendereli a 3D hatásokat diaképek, PDF kimenet, HTML kimenet és a videókonverzióhoz használt keretek előállításakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom-e a végső 3D értékeket öröklődés és téma beállítások alkalmazása után?**

Igen. Használja a hatékony formázási API‑kat, amelyeket a [Alakzat hatékony tulajdonságai](/slides/hu/net/shape-effective-properties/) leír, a végső kamera, fényrendszer, rézsú és kapcsolódó 3D értékek kiolvasásához.