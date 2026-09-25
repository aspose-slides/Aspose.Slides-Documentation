---
title: Vytváření 3D efektů v prezentacích pomocí .NET
linktitle: 3D prezentace
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
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v .NET s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro .NET může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek popisuje 3D efekty, jako je otáčení, extruze, zkosení, osvětlení, materiál, gradientové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
This article is about 3D formatting effects on PowerPoint shapes and text. It is not about inserting or editing standalone 3D model files. When you export a slide to an image, PDF, or HTML, Aspose.Slides renders those 3D effects into the exported 2D output.
{{% /alert %}}

## **Koncepty 3D formátování**

Pro aplikaci 3D formátování na tvar použijte vlastnost [IShape.ThreeDFormat]. Tato vlastnost poskytuje [IThreeDFormat], která řídí 3D scénu pro daný tvar.

Pro text použijte vlastnost [ITextFrameFormat.ThreeDFormat]. To použije 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější vlastnosti jsou:

| Property | Co řídí | Kdy použít |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/camera) | Pohled, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otáčení objektu ve 3D prostoru nebo shodování s přednastaveným 3D otáčením v PowerPointu. |
| [LightRig](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/lightrig) | Přednastavení světla, směr a rotace světla. | Změna vzhledu zvýraznění a stínů na 3D povrchu. |
| [Material](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/material) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobí, že stejná geometrie vypadá plochěji, měkčeji, leskleji nebo kovově. |
| [ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko se tvar rozšiřuje dozadu od přední plochy. | Přemění plochý tvar na viditelně tlustý 3D objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Barva extrudovaných stran. | Zviditelní hloubku nebo sladí barvu stran s výplní přední strany. |
| [Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/depth) | Další 3D hloubka používaná v PowerPoint 3D formátování. | Jemně doladí hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [BevelTop](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/bevelbottom) | Vytlačené nebo zaoblené hrany na přední a zadní straně. | Přidá změkčený nebo tvarovaný okraj místo ostré ploché plochy. |
| [ContourColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrys kolem 3D objektu. | Zvýrazní hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvary obvykle potřebují čtyři typy nastavení, než vypadají přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení zpřehledňuje plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku dvakrát ve výchozích rozměrech a uloží prezentaci jako PPTX.

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

Vykreslený snímek ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v panelu 3‑D Rotace. Hodnoty rotace X, Y a Z odpovídají rotaci nastavené přes API kamery.

![Panel 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujte ke kameře přes [IThreeDFormat.Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/camera). Tento příklad vytvoří obdélník, zvolí ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfigurace tvaru proběhne v paměti bez uložení souboru:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Používejte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint i Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že se tvar rozšiřuje dozadu od přední plochy. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a ovládání barvy určuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Nastavte [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) pro tloušťku a [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusioncolor) pro barvu stran. Tento příklad dává obdélníku 100‑bodovou extruzi s fialovými stranami a otáčí kameru tak, aby ukázala jeho tloušťku. Konfigurace proběhne v paměti bez uložení souboru:

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

Vlastnost [IThreeDFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/depth) nastavuje hloubku 3D tvaru. Vlastnost [ExtrusionHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/properties/extrusionheight) řídí výšku efektu extruze, jak ukazuje tento příklad.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále používat stejná nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradient od modré k oranžové na přední stranu a tmavě oranžovou barvu na 150‑bodovou extruzi. Zastavení gradientu na 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek se vykreslí do PNG obrázku dvakrát ve výchozích rozměrech:

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

Vykreslený výstup zachovává gradient na přední straně a vykresluje extruzi odděleně:

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor s názvem "image.jpg" v pracovním adresáři. Roztažení obrázku na celý obdélník, nastavení 150‑bodové extruze a rotace kamery ve stupních. Konfigurace proběhne v paměti bez uložení nebo vykreslení souboru:

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

Obrázek se vykreslí na přední stranu, zatímco extruze se vykreslí jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použití 3D formátování na text**

Formátování 3D tvaru ovlivňuje tělo tvaru. Formátování 3D textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, aplikuje křivku a nastaví 3D parametry přes [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/threedformat). Výška a hloubka extruze jsou v bodech a rotace světla ve stupních. Výplň a obrys tvaru jsou skryty, takže je viditelný jen text. Příklad vykreslí PNG obrázek dvakrát ve výchozích rozměrech snímku a uloží prezentaci jako PPTX:

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

![Vykreslený 3D text s zakřiveným WordArt transformací, oranžovou vzorovanou výplní a tmavou extruzí](img_02_05.png)

## **Udržení textu plochého na 3D tvaru**

Chcete‑li, aby byl text čitelný při zachování 3D vzhledu tvaru, nastavte [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/keeptextflat/) přes [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/textframeformat/). Když je hodnota `true`, text zůstává mimo 3D scénu. Když je `false`, text se podílí na scéně a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [IShape.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/threedformat/). Je to také odlišné od běžné rotace. [IShape.Rotation](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/rotation/) otáčí tvar v rovině snímku, zatímco [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/rotationangle/) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Udržení textu mimo 3D scénu neobnoví žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG dvakrát ve výchozích rozměrech.

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

Vedle sebe umístěné 3D obdélníky: KeepTextFlat je vlevo false a vpravo true:

![Side-by-side 3D rectangles: KeepTextFlat is false on the left and true on the right](keep_text_flat.png)

## **Chování exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou rozložením se 3D scéna rasterizuje nebo vykreslí do výstupu jako 2D výsledek. To platí při vykreslování snímků do [PNG](/slides/cs/net/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/net/convert-powerpoint-to-html/), nebo generování snímků pro [video conversion](/slides/cs/net/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, světelného rig, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete prozkoumat zděděné nebo motivové hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/net/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech se vizuální výsledek spíše vykreslí než uchová jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje PowerPoint 3D efekty pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje editaci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný PowerPoint tvar nebo text, jako je otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte světelný rig a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

**Mohu použít 3D efekty na tvary i text?**

Ano. Použijte [IShape.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/threedformat) pro tělo tvaru a [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/threedformat) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při vytváření obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po použití dědičnosti a nastavení motivu?**

Ano. Použijte API efektivního formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/net/shape-effective-properties/), abyste získali koneční hodnoty kamery, světelného rig, zkosení a souvisejících 3D parametrů.