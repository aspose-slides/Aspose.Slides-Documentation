---
title: Prezentációs diák renderelése SVG képeként .NET-ben
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- prezentáció SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képeként .NET-ben, és irányítsa a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájl-formátum, amely jól működik webes közzétételnél, diavetítőkben, akadálymentesítési munkafolyamatokban és automatizált utófeldolgozás esetén. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan kerülnek kiírásra a szöveg, betűkészletek, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) akkor, ha az exportált SVG-nek kompakt, a böngészők között kiszámítható vagy interaktív felhasználásra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-t, válasszon ki egy diát, és írja ki egy adatfolyamba. Az alábbi példa minden diát külön SVG fájlként exportál a prezentációból.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

A fájlnév a [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) értékét használja a ciklusindex helyett. Egyedi alakzatot is exportálhat a [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) segítségével, ha egy diavetítőnek vagy weboldalnak csak az adott alakzatra van szüksége.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) szabályozza az SVG renderelést. Szövegdobozok esetén a [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) belefoglalja a szövegdobozt a renderelési területbe, a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) pedig meghatározza, hogy a doboz forgatása alkalmazásra kerüljön-e. Állítsa a [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) értékét **true**‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Vonalvég-körbevágás vezérlése nyilfejeknél**

Az SVG 1.1 nem tartalmaz marker inset beállítást, amely meghatározná, hol álljon le egy vonal egy nyilfej alatt. Alapértelmezés szerint az Aspose.Slides lerövidíti az exportált vonalat, hogy a vonal ne lógjon ki a markerből. Állítsa a [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) értékét **true**‑ra, hogy a vonal a teljes eredeti végpontig legyen rajzolva. Ez a beállítás csak az SVG kimenetet érinti; a vonal pozíciója és hossza a dián változatlan marad.

A példa háromszög és rombusz nyilfejeket rajzol 2‑ és 10‑pont vastagságú vonalakon. Kétszer exportálja ugyanazt a diát, csak a körbevágás beállítást változtatva.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Az összehasonlítás a 10‑pontos vonalon lévő háromszög nyilfejet mutatja. Körbevágás engedélyezésekor a csúcs éles, kikapcsolt állapotban a vonal a nyíl oldalain keresztül lóg ki, és lapos véget képez.

![Nagyított 10‑pontos háromszög, amelynek csúcsa éles, ha a körbevágás engedélyezett, és lapos, ha a körbevágás kikapcsolt](line-end-cropping.png)

A példában szereplő többi vonalnál a kiemelkedő vonal kevésbé látható a 2‑pontos háromszögnél. A kitöltött rombusz mindkét szélességnél lefedi a vonal végét.

## **Szöveg és betűkészletek vezérlése**

SVG‑k exportálásakor szabályozhatja, hogy a szöveg szövegként maradjon-e vagy vektorgrafikává alakuljon, valamint hogy a külső betűkészletek hogyan legyenek beleágyazva vagy hivatkozva. A következő beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkiválaszthatóságot és a betűkészlet-függőségeket az exportált SVG‑ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) értékét **true**‑ra, ha az összes diaszöveget vektorgrafikaként szeretné írni. Ezzel megszűnik a betűkészlet-függőség, és a vizuális eredmény böngészők között egységesebb, de a szöveg már nem lesz kijelölhető vagy kereshető SVG‑szövegként.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Külső betűkészletek kezelési módjának kiválasztása**

A [SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles`‑t, ha külön betűfájlokra szeretne hivatkozni, a `Embed`‑et, ha a betűadatok be legyenek ágyazva az SVG‑be, vagy a `Vectorize`‑t, ha csak a külső betűkészletet használó szöveget szeretné grafikává konvertálni. Ellenőrizze a betűkészlet licencelését, mielőtt beágyazná.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) beállítást a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) beállítást a levágott forrásterületek kihagyásához, valamint a [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) beállítást a JPEG kódolás minőségének szabályozásához. Ezek a beállítások fájlméretcsökkenést eredményeznek a kép hűség vagy a megőrzött képadatok árán.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Metafájl rasterizációs felbontásának vezérlése**

A [SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) az alacsonyabb felbontási határt állítja be a metafájlok rasterizálásához SVG‑exportálás közben. Ezzel egyensúlyozhat a részletgazdagság és a fájlméret között, amikor egy EMF vagy WMF kép rasterizálódik. Nem határoz meg globális DPI‑t az SVG-re, és nem kényszeríti minden objektum rasterképpé alakítását a dián.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely EMF képet tartalmaz szorosan elhelyezkedő átlós vonalakkal. Az alábbi példa az első diát három rasterizációs felbontásban exportálja a [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) segítségével. Az összes többi exportálási beállítás változatlan marad, hogy az eredmények összehasonlíthatók legyenek.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

A kimenetben az EMF minden SVG‑ben egy beágyazott PNG‑vé alakult. Az alábbi mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI‑ból pixelméretre való átszámításhoz.

| Metafájl rasterizáció DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja azonos nagyított megjelenítési mérettel. A 72 DPI‑nál látható pixelesség és a magasabb felbontásoknál simább él pontosítja a vizuális különbséget, miközben az SVG‑fájl mérete nő. A felbontás növelése nem feltétlenül javít minden részletet, és nem változtat minden exportált képen.

![Nagyított átlós vonal részlet 72, 150 és 300 DPI‑nál](metafile-rasterization-comparison.png)

A [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl rasterizációs felbontás változtatásának hatását. A [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) a JPEG kódolás minőségét, nem pedig a metafájl rasterizációs felbontását szabályozza.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja az [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) interfészt az [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) beállításához minden SVG alakzatra. Ahhoz, hogy a szöveg `tspan` elemeire is [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) értékeket állítson be, valósítsa meg az [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) interfészt. Mindkét vezérlőt a [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) segítségével adhatja meg.

Az alábbi vezérlő a [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) értékét használja, amely stabil a forma élettartama alatt, valamint egy ismételhető számlálót a szöveges spannek. Ez a generált azonosítókat alkalmasá teszi egy változatlan prezentáció utófeldolgozásához.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **SVG eseménykezelők hozzáadása**

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)-ben hívja meg az [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. A vezérlőt a [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) segítségével rendelje hozzá, és definiálja a JavaScript függvényt a HTML‑oldalon vagy az SVG‑dokumentumban, amely a kimenetet tartalmazza.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

A hostoldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, a hozzáférhetőségi fejlesztéseket és más interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) használata a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) beállítást, ha minden szöveget függetlenül kell kezelni a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) beállítást, ha csak a külső betűkészletet használó szöveget kívánja grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, és a linkelt betűfájlok választásával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, az alacsonyabb JPEG‑minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatom az exportált SVG elemeket az exportálás után?**

Igen. Rendeljen azonosítókat egy formázási vezérlővel, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptben.