---
title: Diák renderelése SVG képekként .NET-ben
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
description: "Exportálja a PowerPoint diákat SVG képekként .NET környezetben, és vezérelje a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájlformátum, amely jól működik webes kiadványokhoz, diamegjelenítőkhez, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan íródnak a szövegek, betűk, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) lehetőséget, ha az exportált SVG-nek kompakt, böngészők között kiszámítható, vagy interaktív felhasználásra készültnek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba. Az alábbi példa minden diát külön SVG fájlként exportál a prezentációból.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

A fájlnév a [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) értékét használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) használatával, ha egy diamegjelenítőnek vagy weboldalnak csak arra az alakzatra van szüksége.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) szabályozza az SVG renderelését. Szövegdobozok esetén a [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) belefoglalja a szövegdobozt a renderelési területbe, a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) pedig meghatározza, hogy a doboz forgása alkalmazásra kerül-e. Állítsa a [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) értékét `true`‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

## **Szöveg és betűtípusok kezelése**

SVG-be történő diaexportáláskor szabályozhatja, hogy a szöveg szövegként maradjon-e vagy vektoros grafikává konvertálódik, valamint hogy a külső betűtípusok hogyan legyenek belefoglalva vagy hivatkozva. Az alábbi beállítások segítenek egyensúlyt teremteni a vizuális konzisztencia, a szövegkiválasztás és a betűtípus-függőségek között az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) értékét `true`‑ra, hogy a diák minden szövege vektoros grafikaként kerüljön kiírásra. Ez megszünteti a betűtípus‑függőségeket, és a vizuális eredményt egységesebbé teszi a böngészők között, de a szöveg már nem lesz kiválasztható vagy kereshető SVG‑szövegként.

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

### **Külső betűtípusok kezelési módjának kiválasztása**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza a `AddLinksToFontFiles` lehetőséget, ha különálló betűtárfájlokra szeretne hivatkozni, a `Embed` opciót, ha a betűtípus‑adatokat be szeretné ágyazni az SVG‑be, vagy a `Vectorize` lehetőséget, ha csak a külső betűtípust használó szöveget szeretné grafikává konvertálni. Betűtípus‑licencelést ellenőrizze a beágyazás előtt.

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

Használja a [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) beállítást a beágyazott képek felbontásának csökkentésére, a [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) beállítással a levágott forrásterületek elhagyására, és a [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) értékkel a JPEG kódolás minőségének szabályozására. Ezek a beállítások a fájlméretet csökkentik a kép‑hűség vagy a megmaradt képadatok kárára.

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

## **Metafájl raszterezési felbontásának vezérlése**

A [SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) az SVG exportálása során a metafájlok raszterezésének alsó felbontási határát állítja be. Ennek segítségével egyensúlyozhat a részletesség és a fájlméret között, ha egy EMF vagy WMF képet raszterez. Nem definiál globális DPI‑t az SVG‑hez, és nem kényszeríti minden objektumot raszteres képpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezett átlóvonalakkal. Az alábbi példa a prezentáció első diáját három raszterezési felbontásban exportálja a [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) használatával. A többi exportbeállítás változatlan marad, hogy az eredményeket össze lehessen hasonlítani.

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

A kimenetben az EMF minden SVG‑ben egy beágyazott PNG‑re vált. Az alábbi mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI‑ból pixelméret számításához.

| Metafájl raszterezési DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alább látható összehasonlítás ugyanazt a beágyazott rasztert mutatja azonos nagyított megjelenítési méreten. A átlóvonalak 72 DPI‑n látható pixelesedést, magasabb felbontásoknál pedig simább éleket mutatnak, miközben az SVG fájl mérete nő. A felbontás növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képen.

![Nagyított átlóvonal részlet 72, 150 és 300 DPI-n](metafile-rasterization-comparison.png)

A [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl raszterezési felbontásának változtatásának hatását. A [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) a JPEG kódolás minőségét szabályozza, nem a metafájl raszterezési felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja az [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) segítségével a [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) beállítását minden SVG alakzathoz. A szöveg `tspan` elemeinek [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) értékének beállításához implementálja az [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)-t. Bármelyik vezérlőt a [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) segítségével adja meg.

Az alábbi vezérlő az [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) értékét használja, amely stabil a forma életciklusa alatt, valamint egy ismételhető számlálót a szöveg‑spannekhez. Ez a generált azonosítók alkalmasá teszi a változatlan prezentáció utófeldolgozását.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)‑ben hívja meg a [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon hozzá egy exportált alakzathoz. Adja meg a vezérlőt a [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) segítségével, és definiálja a JavaScript függvényt az oldalon vagy az SVG dokumentumban, amely a kimenetet tartalmazza.

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

A host oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diamegjelenítők, akadálymentesítési bővítmények és más interaktív SVG munkafolyamatok használatát.

## **GYIK**

**Mikor kell használni a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) helyett a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)‑t?**

Használja a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) lehetőséget, ha minden szöveget függetleníteni kell a betűtípusoktól. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) beállítást, ha csak a külső betűtípust használó szövegeket szeretné grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, valamint a linkelt betűtárfájlok választásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, az alacsonyabb JPEG‑minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatom az exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázó vezérlő segítségével, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptjében.