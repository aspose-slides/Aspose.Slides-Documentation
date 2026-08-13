---
title: Vytvoření 3D efektů v prezentacích pomocí .NET
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
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

Aspose.Slides pro .NET může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty jako otáčení, extruzi, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" %}}
Tento článek se týká 3D formátovacích efektů na tvary a text v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte vlastnost [IShape.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/threedformat) k aplikaci 3D formátování na tvar. Vlastnost poskytuje rozhraní [IThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat), které řídí 3D scénu pro daný tvar.

Pro text použijte vlastnost [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/threedformat). Tím se aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější vlastnosti jsou:

| Vlastnost | Co řídí | Kdy použít |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/camera) | Pohled, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otáčet objekt ve 3D prostoru nebo odpovídat přednastavenému 3D otáčení v PowerPointu. |
| [LightRig](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/lightrig) | Přednastavení světla, směr a otáčení světla. | Změnit, jak se na 3D povrchu zobrazují zvýraznění a stíny. |
| [Material](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/material) | Materiál povrchu, například plochý, matný, plastový nebo kovový. | Způsobit, aby stejná geometrie vypadala plochěji, měkčeji, leskleji nebo kovově. |
| [ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko se tvar rozšiřuje dozadu od své přední plochy. | Proměnit plochý tvar na viditelně tlustý 3D objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Barva extrudovaných stran. | Zobrazit hloubku nebo sladit barvu stran s přední výplní. |
| [Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/depth) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Jemně doladit hloubku pro tvary nebo text, zejména spolu s nastaveními zkosení a materiálu. |
| [BevelTop](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/bevelbottom) | Zvýšené nebo zakulacené hrany na přední a zadní ploše. | Přidat změkčený nebo formovaný okraj místo ostré ploché strany. |
| [ContourColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrys kolem 3D objektu. | Zdůraznit hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, než bude vypadat přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu, aplikujte 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D otáčení nastavuje v podokně 3‑D Rotation. Hodnoty otáčení X, Y a Z odpovídají otáčení nastavenému přes API kamery.

![Podokno PowerPoint 3‑D Rotation se zvýrazněnými hodnotami otáčení X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení přes [IThreeDFormat.Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění geometrii 2D tvaru na snímku. Mění 3D pohled, který používá PowerPoint a Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlouží za přední plochu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a kontrola barvy nastavuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Nastavte [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) pro tloušťku a [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusioncolor) pro barvu stran:

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

Použijte [IThreeDFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/depth), když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvarů je `ExtrusionHeight` srozumitelnější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete na přední plochu použít plnou barvu, gradient, vzor nebo obrázkovou výplň a stále používat stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradientovou výplň na tvar a tmavší barvu extruze na strany:

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

Vykreslený výstup zachová gradient na přední ploše a extruzi vykreslí odděleně:

![Vykreslený 3D obdélník s modro‑oranžovým gradientem výplně a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej jako výplň tvaru:

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

Obrázek je vykreslen na přední ploše, zatímco extruze je vykreslena jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzoru, aplikuje transformaci WordArt a nakonfiguruje 3D nastavení na [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat):

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s obloukovou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování při exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou úpravou je 3D scéna rasterizována nebo vložena do výstupu jako 2D výsledek. To platí, když vykreslujete snímky do [PNG](/slides/cs/net/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/net/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/net/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nemůže být po exportu otáčen divákem.
- Konečný vzhled závisí na kombinaci kamery, světelného zařízení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete prozkoumat zděděné nebo tématem podmíněné hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/net/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit upravitelná 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen, místo aby byl zachován jako upravitelná 3D nastavení.

## **Často kladené otázky**

### Může Aspose.Slides vytvářet interaktivní 3D prezentace?

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří z exportovaných obrázků, PDF ani HTML stránek interaktivní 3D scény, které by mohl divák otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

### Jaký je rozdíl mezi 3D modelem a 3D efektem?

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

### Jaká nastavení jsou potřebná pro viditelný 3D tvar?

Minimálně nastavte otáčení kamery a buď extruzi, nebo hloubku. V praxi také nastavte světelné zařízení a materiál, aby vykreslené plochy měly jasné zvýraznění a stíny.

### Mohu aplikovat 3D efekty na tvary i text?

Ano. Použijte [IShape.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/threedformat) pro tělo tvaru a [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/threedformat) pro text.

### Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF, HTML a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

### Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení tématu?

Ano. Použijte API pro efektivní formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/net/shape-effective-properties/), abyste získali konečné hodnoty kamery, světelného zařízení, zkosení a souvisejících 3D hodnot.