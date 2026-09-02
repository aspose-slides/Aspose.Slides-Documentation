---
title: PowerPoint tintaobjektumok kezelése .NET-ben
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/net/manage-ink/
keywords:
- tinta
- tinta objektum
- tinta vonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- tinta exportálása
- tinta renderelése
- tinta elrejtése
- IInkOptions
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Kezelje a PowerPoint tintaobjektumokat, szerkessze a vonalakat és az ecset tulajdonságait, valamint szabályozza a tinta megjelenését PDF, HTML, SVG, TIFF és képexportálás során az Aspose.Slides for .NET segítségével."
---
## **Bevezetés**

A PowerPoint egy tintafunkciót kínál, amely lehetővé teszi a szabadkézi vonalak rajzolását. A tinta használható más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő egyes elemek felhívására.

A [Aspose.Slides.Ink](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/) névtér tartalmazza a tintaobjektumok kezeléséhez szükséges osztályokat és interfészeket. Például az [IInk](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iink/) interfész egy tintobjektumot képvisel egy dián.

## **A normál objektumok és a tintobjektumok közötti különbségek**

A PowerPoint dián szereplő objektumok általában alakzatobjektumokként jelennek meg. A legegyszerűbb formában egy alakzat egy tároló, amely meghatározza az objektum (a keret) területét, valamint olyan tulajdonságokat, mint a tároló mérete, alakja és háttérje. További információkért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/net/shape-manipulations/#access-layout-formats-for-shape) oldalt.

Azonban amikor a PowerPoint egy tintobjektummal dolgozik, figyelmen kívül hagyja az objektumkeret (tároló) összes tulajdonságát, kivéve a méretét. A tároló területének mérete a szabványos [IShape.Width](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/width/) és [IShape.Height](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/height/) tulajdonságok alapján kerül meghatározásra:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintavonalak**

A tintavonal egy alapvető elem, amely a toll mozgásának trajektóriáját rögzíti, amikor a felhasználó digitális tintát ír. Egy vonal összekapcsolt pontok sorozatát tárolja.

A legkézenfekvőbb kódolási forma minden mintapont X és Y koordinátáját adja meg. Ha az összekapcsolt pontok megjelennek, a következő képet eredményezik:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecsettulajdonságok a rajzoláshoz**

Az ecsetet a tintavonal pontjait összekötő vonalak rajzolásához használják. Az ecset színét és méretét a [IInkBrush.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iinkbrush/color/) és a [IInkBrush.Size](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iinkbrush/size/) tulajdonságok képviselik.

### **Tintaecset színének beállítása**

Ez a C# kód mutatja be, hogyan állítható be egy tintaecset színe:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Tintaecset méretének beállítása**

Ez a C# kód mutatja be, hogyan állítható be egy tintaecset mérete:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Általában az ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürkén jelenik meg). Amikor az ecset szélessége és magassága megegyezik, a PowerPoint a következőképpen mutatja a méretet:

![ink_powerpoint3](ink_powerpoint3.png)

A világosság kedvéért növeljük meg a tintobjektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig azt feltételezi, hogy a vonalvastagság nulla (lásd az előző képet).

Ezért a teljes tintobjektum látható területének meghatározásához a vonalak ecsetméretét is figyelembe kell venni. Itt a célobjektum (a kézírásos szövegvonal) a tároló (keret) méretéhez van skálázva. Amikor a tároló mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz a szövegobjektumokra is:

![ink_powerpoint6](ink_powerpoint6.png)

## **Tintajelenlét szabályozása exportálás és megjelenítés során**

Az Aspose.Slides a [IInkOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/) interfészt biztosítja a tintobjektumok megjelenésének szabályozásához exportált vagy renderelt kimenetben. A tulajdonságokkal elrejthető a tinta, vagy módosítható, hogyan értelmeződnek a tintaecset maszkműveletek.

A tinta beállításai elérhetők a különböző kimenettípusok export- vagy renderelési beállításain keresztül:

| Kimenet | Tintabeállítás tulajdonság |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Dia kép | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/inkoptions/) |

A következő két beállítás érhető el ezen tulajdonságokon keresztül:

- [`HideInk`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/hideink/) határozza meg, hogy a tintobjektumok szerepelnek-e a kimenetben. Alapértelmezett értéke `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) határozza meg, hogy egy maszkművelet opacitásként legyen-e értelmezve tintaecset renderelésekor. Alapértelmezett értéke `true`; állítsa `false`‑ra a ROP művelet használatához.

### **Tintobjektumok elrejtése PDF kimenetben**

Alapértelmezés szerint a tintobjektumok láthatóak maradnak exportáláskor. Állítsa az [IInkOptions.HideInk](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/hideink/) értékét `true`‑ra, ha tiszta kimenetet szeretne kézírásos megjegyzések vagy egyéb tinta tartalom nélkül.

Az alábbi C# példa PDF‑re exportál egy bemutatót, miközben elrejti az összes tintát:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Tintobjektumok elrejtése dia kép formátumban történő rendereléskor**

A tintobjektumok elrejtéséhez dia bitmap képként történő renderelésekor konfigurálja a [RenderingOptions.InkOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/inkoptions/) beállítást, majd adja át a renderelési beállításokat az [ISlide.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) metódusnak.

Az alábbi C# példa PNG képet renderel az első diáról tintával nélkül:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Tintamaskara renderelés szabályozása**

Az [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) tulajdonság szabályozza, hogyan értelmeződnek a maskaműveletek tintaecsetek renderelésekor. Alapértelmezett értéke `true`, ami opacitást használ. Állítsa `false`‑ra a ROP művelet használatához.

Az alábbi C# példa SVG‑re exportál egy diát, és ROP‑alapú renderelést alkalmaz a tintamaskra műveletekhez:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Ugyanez a beállítás alkalmazható a [TiffOptions.InkOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/inkoptions/) használatával is, amikor egy bemutatót exportál vagy egy diát TIFF‑ként renderel.

### **Válassza ki, hogy elrejtse vagy megőrizze a tintát**

Használja az [IInkOptions.HideInk](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/hideink/) értékét `true`‑ra, ha az exportált fájl egy megjegyzésekkel ellátott bemutató tiszta változatát kell, hogy legyen (például a végleges terjesztésre szánt másolat).

Hagyja az [IInkOptions.HideInk](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/hideink/) alapértelmezett `false` értékét, ha a tinta megjegyzések a szándékolt tartalom részei, például felülvizsgálati kommentek, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek láthatónak kell maradniuk az exportált eredményben. Ez lehetővé teszi az alkalmazások számára, hogy ugyanabból a bemutatóból külön felülvizsgálati és végleges kimeneteket generáljanak a forrás tintobjektumok módosítása nélkül.

## **GYIK**

**Megváltoztathatom egy meglévő tintavonal színét vagy méretét?**

Igen. Szerezze meg a vonalat az [IInk.Traces](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iink/traces/) segítségével, majd módosítsa annak [IInkTrace.Brush](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iinktrace/brush/) tulajdonságát. Beállíthatja a [IInkBrush.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iinkbrush/color/) és a [IInkBrush.Size](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/iinkbrush/size/) értékeket.

**Az tinta elrejtése módosítja a forrás bemutatót?**

Nem. Az [IInkOptions.HideInk](https://reference.aspose.com/slides/hu/net/aspose.slides.export/iinkoptions/hideink/) csak a renderelt vagy exportált eredményt befolyásolja; nem távolítja el vagy módosítja a tintobjektumokat a forrás bemutatóban.

**Mely exportformátumok támogatják a tinta beállításait?**

A tinta beállításait konfigurálhatja PDF, HTML, SVG, TIFF és bitmap dia képek esetén a fent bemutatott export‑ vagy renderelési beállításokon keresztül.

**További olvasnivaló**

* A formákról általában a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/net/powerpoint-shapes/) szakaszban olvashat.
* A hatékony értékekről a [Shape Effective Properties](https://docs.aspose.com/slides/hu/net/shape-effective-properties/#get-effective-font-height-value) oldal részletezi.
* A PDF export részletei: [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/net/convert-powerpoint-to-pdf/).
* A HTML export részletei: [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/net/convert-powerpoint-to-html/).
* Az SVG export részletei: [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/net/render-a-slide-as-an-svg-image/).
* A TIFF export részletei: [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/net/convert-powerpoint-to-tiff/).
* A dia‑kép renderelés részletei: [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/net/convert-slide/).