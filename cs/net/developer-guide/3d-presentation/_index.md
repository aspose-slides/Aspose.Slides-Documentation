---
title: Vytváření 3D efektů v prezentacích pomocí .NET
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

Aspose.Slides pro .NET může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako jsou otáčení, extruze, zkosení, osvětlení, materiál, gradientní nebo obrázkové výplně a 3D text.

{{% alert color="primary" %}}
Tento článek se věnuje 3D formátovacím efektům na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Pomocí vlastnosti [IShape.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/threedformat) aplikujete 3D formátování na tvar. Vlastnost poskytuje [IThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat), který řídí 3D scénu pro tento tvar.

Pro text použijte vlastnost [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/threedformat). Tím se 3D formátování použije na textový rámec místo těla tvaru.

Nejdůležitější vlastnosti jsou:

| Vlastnost | Co řídí | Kdy použít |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/camera) | Pohled, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otáčení objektu ve 3D prostoru nebo odpovídání přednastavenému otáčení PowerPointu. |
| [LightRig](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/lightrig) | Přednastavení světla, směr a otáčení světla. | Změna vzhledu světelných odlesků a stínů na 3D povrchu. |
| [Material](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/material) | Materiál povrchu, jako plochý, matný, plastový nebo kovový. | Udělat stejnou geometrii vzhledově plošší, měkčí, lesklejší nebo kovovější. |
| [ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko tvar vystupuje dozadu od své přední plochy. | Proměnit plochý tvar na viditelně tlustý 3D objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Barva extrudovaných stran. | Zviditelnit hloubku nebo sladit barvu stran s přední výplní. |
| [Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/depth) | Dodatečná 3D hloubka používaná formátováním 3D v PowerPointu. | Doladit hloubku tvarů nebo textu, zejména spolu s nastavením zkosení a materiálu. |
| [BevelTop](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/beveltop) a [BevelBottom](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/bevelbottom) | Vytýčené nebo zaoblené hrany na přední a zadní straně. | Přidat změkčený nebo formovaný okraj místo ostré ploché plochy. |
| [ContourColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/contourcolor) a [ContourWidth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrys kolem 3D objektu. | Zdůraznit hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal věrohodně 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení umožňuje rozpoznat plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu, aplikuje 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

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

Vykreslený snímek ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D otáčení nastavuje v panelu 3‑D Rotation. Hodnoty otáčení X, Y a Z odpovídají otáčení, které nastavíte pomocí rozhraní kamery.

![PowerPoint 3‑D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení pomocí [IThreeDFormat.Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Kameru použijte, když potřebujete změnit, jak divák vidí objekt. Nemění geometrii 2D tvaru na snímku. Mění 3D pohledový úhel, který používá PowerPoint i Aspose.Slides při renderování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se protáhne za přední stranu. V PowerPointu ovládací prvek hloubky určuje tuto viditelnou tloušťku a ovládací prvek barvy určuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Nastavte [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) pro tloušťku a [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusioncolor) pro barvu boků:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Použijte [IThreeDFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/depth), když potřebujete pracovat přímo s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha situacích je nastavení `ExtrusionHeight` přehlednější, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít jednolitou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále používat stejné nastavení kamery, osvětlení, materiálu a extruze.

Tento příklad použije gradientní výplň na tvar a tmavší barvu extruze na boky:

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

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Chcete‑li místo toho použít obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej výplni tvaru:

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

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použití 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. Toto je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s vzorovou výplní, aplikuje transformaci WordArt a nastaví 3D parametry na [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat):

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

![Vykreslený 3D text s zakřivenou WordArt transformací, oranžovou vzorovou výplní a tmavou extruzí](img_02_05.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou rozlohou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí při renderování snímků do [PNG](/slides/cs/net/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/net/convert-powerpoint-to-html/), nebo při generování snímků pro [video conversion](/slides/cs/net/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt není možné po exportu otáčet v prohlížeči.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a škálování snímku.
- Pokud potřebujete prozkoumat zděděné nebo tématem definované hodnoty formátování, přečtěte si [effective shape properties](/slides/cs/net/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit upravitelná 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl uložen jako upravitelná 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF ani HTML stránkách, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, kde je formát podporován.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá právě 3D efekty.

**Jaká nastavení jsou požadována pro viditelný 3D tvar?**

Minimálně nastavte otáčení kamery a buď extruzi, nebo hloubku. V praxi je také vhodné nastavit osvětlení a materiál, aby měly vykreslené plochy jasné odlesky a stíny.

**Mohu použít 3D efekty jak na tvary, tak na text?**

Ano. Použijte [IShape.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/threedformat) pro tělo tvaru a [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/threedformat) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu i snímků používaných pro převod do videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API pro efektivní formátování popsané v [Shape Effective Properties](/slides/cs/net/shape-effective-properties/), abyste získali konečné hodnoty kamery, osvětlení, zkosení a souvisejících 3D parametrů.