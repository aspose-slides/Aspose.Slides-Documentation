---
title: 3D effektusok létrehozása prezentációkban .NET segítségével
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokhoz és szöveghez .NET környezetben az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatokhoz és szöveghez. Ez a cikk a 3D effekteket, például a forgatást, extrúziót, rézkörülméteket, megvilágítást, anyagot, színátmenetes vagy képtöltéseket, valamint a 3D szöveget tárgyalja.

{{% alert color="info" title="Megjegyzés" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szólt. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat az exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja az [IShape.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/threedformat) tulajdonságot 3D formázás alkalmazásához egy alakzatra. A tulajdonság [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat) objektumot biztosít, amely vezérli az alakzat 3D jelenetét.

Szöveghez használja az [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/threedformat) tulajdonságot. Ez a szövegkeretre alkalmaz 3D formázást, nem az alakzat testére.

A legfontosabb tulajdonságok:

| Property | Mit szabályoz | Mikor használja |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/camera) | Nézőpont, előre beállított kamera típusa, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatás előre beállított érének illesztése. |
| [LightRig](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/lightrig) | Fény előre beállított, irány és fényforgatás. | Megváltoztatja, hogy a kiemelések és árnyékok hogyan jelennek meg a 3D felületen. |
| [Material](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/material) | Felületi anyag, például sima, matt, műanyag vagy fém. | Azonos geometria laposabbá, lágyabbá, fényesebbé vagy fémesebbé tétele. |
| [ExtrusionHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusionheight) | Milyen távolságra nyúlik az alakzat hátrafelé az elülső felületétől. | Egy lapos alakzat átalakítása láthatóan vastag 3D objektummá. |
| [ExtrusionColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldal színének összehangolása az elülső kitöltéssel. |
| [Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/depth) | A PowerPoint 3D formázás által használt további 3D mélység. | A mélység finomhangolása alakzatok vagy szöveg esetén, különösen a rézkörülmény és anyag beállításokkal együtt. |
| [BevelTop](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/beveltop) és [BevelBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/bevelbottom) | Emelt vagy lekerekített szélek az elülső és hátul lévő felületeken. | Puhább vagy formázott él hozzáadása ahelyett, hogy egy éles lapos felület lenne. |
| [ContourColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/contourcolor) és [ContourWidth](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/contourwidth) | Körvonal a 3D objektum körül. | Az objektum határának hangsúlyozása a renderelt kimenetben. |

## **3D alakzat létrehozása**

Az alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D‑nak tűnik:

- Kamera beállítások, mivel az alapértelmezett elülső nézet elrejtheti az extrúziót.
- Fény beállítások, mivel a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad az elülső felületéhez, és 3D formázást alkalmaz. A kamera forgatási értékek fokban vannak megadva, az extrúzió magassága 100 pont. A példa a diát PNG képpé rendereli az alapértelmezett méret kétszeresére, és a prezentációt PPTX‑ként menti.

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

![Megjelenített kék 3D téglalap fehér 3D szöveggel az elülső felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPoint‑ban a 3D forgatást a 3‑D forgatás panelen állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ben a kamerához a [IThreeDFormat.Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/properties/camera) segítségével férhet hozzá. Ez a példa egy téglalapot hoz létre, ortografikus elülső nézetet választ, és X, Y, Z forgatását rendre 20, 30 és 40 fokra állítja. A shape‑ot memóriában konfigurálja fájl mentése nélkül:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

A kamerát akkor kell használni, amikor meg kell változtatni, hogy a néző hogyan látja az objektumot. Nem módosítja a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot változtatja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak látszóvá tesz azzal, hogy kinyújtja a frontális felület mögé. PowerPoint‑ban a mélység szabályozó állítja be ezt a látható vastagságot, a szín szabályozó pedig az oldalfelületek színét.

![PowerPoint mélység beállítások összekapcsolva az extrúzió színével és magasságával](img_02_02.png)

[IThreeDFormat.ExtrusionHeight] beállítása adja a vastagságot, [IThreeDFormat.ExtrusionColor] a oldalszínt. Ez a példa egy téglalapnak 100 pont extrúziót ad lila oldalakkal, és elforgatja a kamerát, hogy látható legyen a vastagsága. A shape‑ot memóriában konfigurálja fájl mentése nélkül:

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

Az [IThreeDFormat.Depth] tulajdonság a 3D alakzat mélységét állítja be. Az [ExtrusionHeight] tulajdonság szabályozza az extrúziós hatás magasságát, ahogyan ez a példában látható.

## **Gradiensek vagy képtöltések használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat szilárd színt, színátmenetet, mintát vagy képtöltést az elülső felületre, és továbbra is használhatja ugyanazt a kamera, fény, anyag és extrúzió beállítást.

Ez a példa egy kék‑narancs színátmenetet alkalmaz az elülső felületre, és sötét narancssárga színt a 150 pont magasságú extrúzióra. A színátmenet leáll 0‑nál és 100‑nál, amely a kezdő és végpontot jelöli. A kamera forgatási értékek fokokban vannak. A diát PNG képpé rendereli az alapértelmezett méret kétszeresére:

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

![Megjelenített 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képtöltés használatához adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy „image.jpg” nevű meglévő fájlt igényel a munkakönyvtárban. A képet a téglalap kitöltésére nyújtja, 150 pont extrúziót alkalmaz, és fokokban állítja be a kamera forgatását. A shape‑ot memóriában konfigurálja mentés vagy renderelés nélkül:

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

![Megjelenített 3D téglalap fotótöltéssel az elülső felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegkeretre vonatkozik. Ez hasznos WordArt‑szerű hatásokhoz, ahol maguk a betűk is extrúzióra, anyagra, megvilágításra és kamera beállításokra szorulnak.

A következő példa egy narancssárga‑fehér rácsmintával rendelkező szöveget hoz létre, felfelé ívelt ívet alkalmaz, és a 3D beállításokat az [ITextFrameFormat.ThreeDFormat] segítségével konfigurálja. Az extrúzió magassága és mélysége pontban van megadva, a fény forgatása fokokban. Az alakzat kitöltése és körvonala el van rejtve, így csak a szöveg látható. A példa PNG képet renderel a diák alapértelmezett méretének kétszeresére, és a prezentációt PPTX‑ként menti:

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

![Megjelenített 3D szöveg ívelt WordArt transzformációval, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának megőrzéséhez a 3D megjelenés miatt, állítsa be az [ITextFrameFormat.KeepTextFlat] értékét az [ITextFrame.TextFrameFormat] segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jelenetből. Ha `false`, a szöveg részt vesz a jelenetben és követi a 3D orientációt.

Ez a beállítás nem távolítja el az alakzat 3D formázását: kamera, megvilágítás, anyag és extrúzió továbbra is a [IShape.ThreeDFormat] segítségével van beállítva. Emellett különbözik a szokásos forgatástól. Az [IShape.Rotation] az alakzatot a diapadon forgatja, míg az [ITextFrameFormat.RotationAngle] a szöveg egyedi forgatását szabályozza a saját keretén belül. A szöveg 3D jelenetből való eltávolítása nem állítja vissza ezeket a szögeket.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és az eredeti mellett klónozza. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítása különbözik: baloldalon `false`, jobboldalon `true`. A kamera szögek fokokban vannak, az extrúzió magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli az alapértelmezett méret kétszeresére.

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

![Egymás mellé helyezett 3D téglalapok: KeepTextFlat baloldalon false, jobboldalon true](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás fix elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetbe. Ez akkor is érvényes, amikor diákot [PNG](/slides/hu/net/convert-powerpoint-to-png/) formátumba renderel, [PDF](/slides/hu/net/convert-powerpoint-to-pdf/) formátumba exportál, [HTML](/slides/hu/net/convert-powerpoint-to-html/) formátumba exportál, vagy kereteket generál [videó konverzióhoz](/slides/hu/net/convert-powerpoint-to-video/).

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja elforgatni az export után.
- A végső megjelenés a kamera, fény rig, anyag, extrúzió, kitöltés és diák méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy téma alapú formázási értékeket, olvassa el a [hatékony alakzat tulajdonságok](/slides/hu/net/shape-effective-properties/) dokumentációt.
- Egyes kimeneti formátumok nem képesek tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve van, nem szerkeszthető 3D beállításként.

## **GYIK**

**Képes az Aspose.Slides interaktív 3D prezentációkat létrehozni?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatokra és szövegre. Nem teszi interaktívvá az exportált képeket, PDF‑eket vagy HTML‑oldalakat, amelyeket a néző forogtatni tudna. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrúzió, rézkörülmény, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Mely beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatás és extrúzió vagy mélység beállítás szükséges. Gyakorlati felhasználás esetén érdemes beállítani a fény riget és az anyagot is, hogy a renderelt felületeknek legyenek egyértelmű kiemelések és árnyékok.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre is?**

Igen. Használja az [IShape.ThreeDFormat] a alakzat testhez és az [ITextFrameFormat.ThreeDFormat] a szöveghez.

**Megjelennek a 3D hatások, amikor képekre, PDF‑re, HTML‑re vagy videó keretekre exportálunk?**

Igen. Az Aspose.Slides a 3D hatásokat rendereli a diaképek, PDF‑kimenet, HTML‑kimenet és a videó konverzióhoz használt keretek létrehozása során. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Ki tudom olvasni a végső 3D értékeket az öröklődés és téma beállítások alkalmazása után?**

Igen. Használja a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/net/shape-effective-properties/) leírás tartalmaz, hogy elolvassa a végső kamera, fény rig, rézkörülmény és kapcsolódó 3D értékeket.