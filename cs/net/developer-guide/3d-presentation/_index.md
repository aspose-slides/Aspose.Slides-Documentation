---
title: Vytvoření 3D efektů v prezentacích pomocí .NET
linktitle: 3D Prezentace
type: docs
weight: 232
url: /cs/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D rotace
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v .NET pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro .NET může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek pokrývá 3D efekty, jako je otáčení, extruze, sklonování, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá efekty 3D formátování na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte vlastnost [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) k aplikaci 3D formátování na tvar. Vlastnost poskytuje [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), která řídí 3D scénu pro tento tvar.

Pro text použijte vlastnost [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Tím se 3D formátování aplikuje na textový rámec místo těla tvaru.

| Vlastnost | Co řídí | Kdy ji použít |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Pohledový bod, přednastavený typ kamery, rotace, zoom a perspektiva. | Otáčejte objekt ve 3D prostoru nebo odpovídejte přednastavenému 3D otočení v PowerPointu. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Přednastavené osvětlení, směr a rotace světla. | Změňte, jak se zvýraznění a stíny zobrazují na 3D povrchu. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plochěji, měkčeji, leskleji nebo kovově. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko se tvar prodlužuje zpět od své přední plochy. | Proměňte plochý tvar v viditelně tlustý 3D objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Barva extrudovaných stran. | Zobrazte hloubku nebo sladěte barvu stran s přední výplní. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Další 3D hloubka používaná 3D formátováním v PowerPointu. | Doladíte hloubku pro tvary nebo text, zejména společně s nastavením sklonu a materiálu. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) a [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Vyvýšené nebo zaoblené hrany na přední a zadní ploše. | Přidejte změkčený nebo tvarovaný okraj místo ostré plochy. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) a [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrys kolem 3D objektu. | Zdůrazněte hranici objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu a aplikuje 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku dvakrát většího než výchozí rozměry a uloží prezentaci jako PPTX.

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

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v podokně 3‑D rotace. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte pomocí API kamery.

![Podokno PowerPoint 3‑D rotace se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujte ke kameře přes [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez uložení souboru:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Používejte kameru, když potřebujete změnit, jak pozorovatel objekt vidí. Nemění 2D geometrii tvaru na snímku. Mění 3D pohled použitého v PowerPointu i v Aspose.Slides při renderování.

### **Zkopírování orientace kamery ze šablonového tvaru**

Pro sladění tvaru v šabloně zkopírujte jeho přednastavení [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) a přečtěte úhly pomocí [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Příklad otevře `template.pptx`, načte kameru z prvního tvaru na první snímku a aplikuje jeho orientaci na druhý tvar. Oba tvary již mají 3D osvětlení a druhý tvar nemá explicitní rotaci kamery.

Úhly jsou ve stupních. Index `0` představuje zeměpisnou šířku, index `1` délku a index `2` otáčení. Předávejte je do [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) v tomto pořadí. Pokud zdroj vrátí `null`, nemá explicitní rotaci, takže ponechte úhly druhého tvaru nenastavené. Explicitní rotace `(0, 0, 0)` vrací tři nuly a měla by být zkopírována.

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

Po opětovném otevření `camera-copy.pptx` mají oba tvary stejné přednastavení kamery a rotaci. V PowerPointu šipka vpravo používá orientaci kamery zkopírovanou z levého obdélníku. Oba tvary používají stejné osvětlení a hloubku extruze.

![Modrý 3D obdélník a šipka vpravo se shodnou orientací kamery, pohled shora a zprava](camera-orientation.png)

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě, protože se prodlužuje za přední plochu. V PowerPointu ovládací prvek hloubky nastavuje tuto viditelnou tloušťku a ovládací prvek barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na vlastnosti barvy a výšky extruze](img_02_02.png)

Nastavte [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) pro tloušťku a [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) pro barvu stran. Tento příklad dává obdélníku 100‑bodovou extruzi s fialovými stranami a otáčí kameru, aby odhalila jeho tloušťku. Konfiguruje tvar v paměti bez uložení souboru:

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

Vlastnost [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) nastavuje hloubku 3D tvaru. Vlastnost [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete na přední plochu použít plnou barvu, gradient, vzor nebo obrázkovou výplň a přesto použít stejnou kameru, osvětlení, materiál a nastavení extruze.

Tento příklad aplikuje gradient od modré k oranžové na přední plochu a tmavozářovou barvu na 150‑bodovou extruzi. Zastavení gradientu při 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku dvakrát většího než výchozí rozměry:

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

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor s názvem "image.jpg" v pracovním adresáři. Roztažením obrázku vyplní obdélník, aplikuje 150‑bodovou extruzi a nastaví rotaci kamery ve stupních. Konfiguruje tvar v paměti bez uložení nebo renderování souboru:

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

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílem mřížkovým vzorem, použije zakřivený oblouk a nastaví 3D parametry přes [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Výška a hloubka extruze jsou v bodech a rotace světla ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný jen text. Příklad vykreslí PNG obrázek dvakrát větší než výchozí rozměry snímku a uloží prezentaci jako PPTX:

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

![Vykreslený 3D text s archivním WordArt transformací, oranžovým vzorem výplně a tmavou extruzí](img_02_05.png)

## **Udržení textu plochého na 3D tvaru**

Chcete‑li, aby byl text čitelný při zachování 3D vzhledu tvaru, nastavte [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) přes [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Když je hodnota `true`, text zůstává mimo 3D scénu. Když je `false`, text se podílí na scéně a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: kamera, osvětlení, materiál a extruze zůstávají nakonfigurovány přes [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). Navíc se liší od běžné rotace. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) otáčí tvar v rovině snímku, zatímco [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) řídí vlastní rotaci textu v jeho ohraničujícím rámce. Udržení textu mimo 3D scénu nerese žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se jen nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG dvakrát většího než výchozí rozměry.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Postranní zobrazení 3D obdélníků: KeepTextFlat je vlevo `false` a vpravo `true`](keep_text_flat.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou stránkou je 3D scéna rasterizována nebo nakreslena do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/net/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/net/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/net/convert-powerpoint-to-video/).

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu rotovat divákem.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete prohlédnout zděděné nebo na motivu založené hodnoty formátování, přečtěte [efektivní vlastnosti tvaru](/slides/cs/net/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Dokáže Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, kde formát podporuje tuto funkci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, sklon, osvětlení a materiál. Tento článek se věnuje právě 3D efektům.

**Která nastavení jsou potřebná pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby vykreslené plochy měly jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) pro tělo tvaru a [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF, HTML a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje pouze vykreslený vzhled, ne editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API pro efektivní formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/net/shape-effective-properties/) k načtení finálních hodnot kamery, osvětlení, sklonu a souvisejících 3D parametrů.