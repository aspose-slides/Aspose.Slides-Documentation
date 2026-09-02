---
title: Dia bemutatók SVG képekké konvertálása .NET-ben
linktitle: Dia SVG-be
type: docs
weight: 50
url: /hu/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-be
- prezentáció SVG-be
- dia SVG-be
- PPT SVG-be
- PPTX SVG-be
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "PowerPoint diákat SVG képekként exportál .NET-ben, és a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket vezérelheti az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájlformátum, amely jól működik webes kiadványokhoz, diavetítők számára, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűtípusok, képek és SVG elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/)‑t, ha az exportált SVG‑nek kompakt, böngészők között kiszámítható vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG‑ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolamba. Az alábbi példa a bemutató minden diáit külön SVG fájlba exportálja.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

A fájlnév a [ISlide.SlideNumber](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/slidenumber/) értékét használja a ciklusindex helyett. Egyedi alakzatot is exportálhat a [IShape.WriteAsSvg](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/writeassvg/) segítségével, ha a diavetítő vagy a weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/) szabályozza az SVG renderelését. Szövegdobozok esetén a [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/useframesize/) a szövegdobozt a renderelési területbe foglalja, a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/useframerotation/) pedig meghatározza, hogy a doboz forgatása alkalmazásra kerül‑e. Állítsa a [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/disablefontligatures/) értékét `true`‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

## **Szöveg és betűtípusok vezérlése**

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/vectorizetext/) értékét `true`‑ra, hogy a dia összes szövegét vektorgrafikaként írja. Ez eltávolítja a betűtípus‑függőségeket, és a vizuális eredményt konzisztenssé teszi a böngészők között, de a szöveg már nem választható vagy kereshető SVG szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

A [SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/externalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgexternalfontshandling/) értéket használ azokhoz a betűtípusokhoz, amelyek külső forrásból töltődnek be. Válassza a `AddLinksToFontFiles` lehetőséget a különálló betűtípusfájlokra való hivatkozáshoz, az `Embed` opciót a betűtípusadatok SVG‑be történő beágyazásához, vagy a `Vectorize` lehetőséget, hogy a külső betűtípusokat használó szöveget grafikaként renderelje. Ellenőrizze a betűtípus licencelését a beágyazás előtt.

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

Használja a [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/picturescompression/) beállítást a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) opciót a levágott forrásterületek kihagyásához, valamint a [SVGOptions.JpegQuality](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/jpegquality/) beállítást a JPEG kódolás minőségének szabályozásához. Ezek a beállítások csökkentik a fájlméretet a kép hűség vagy a megtartott képadatok rovására.

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

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja a [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgshapeformattingcontroller/) osztályt, hogy minden SVG alakzatra beállítsa a [ISvgShape.Id](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgshape/id/) értéket. A szöveg `tspan` elemeire is szeretne [ISvgTSpan.Id](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgtspan/id/) értékeket beállítani, akkor valósítsa meg a [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) interfészt. Bármelyik vezérlőt a [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) segítségével rendelje hozzá.

Az alábbi vezérlő a [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/officeinteropshapeid/) értékét használja, amely az alakzat életciklusa során stabil, valamint egy ismételhető számlálót a szövegtartományokhoz. Ez a generált azonosítókat megfelelővé teszi egy változatlan bemutató utófeldolgozásához.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgshapeformattingcontroller/) esetén hívja meg az [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. A vezérlőt a [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) segítségével rendelje hozzá, és definiálja a JavaScript függvényt az oldalon vagy az SVG dokumentumban, amely a kimenetet tartalmazza.

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

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, az akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell használni a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/vectorizetext/)‑t a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgexternalfontshandling/)‑helyett?**

Használja a [SVGOptions.VectorizeText](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgoptions/vectorizetext/) beállítást, ha az összes szöveget betűtípusoktól függetlenül kell kezelni. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/net/aspose.slides.export/svgexternalfontshandling/) opciót, ha csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a linkelt betűtípusfájlok választásával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje a végeredményt, mivel az alacsonyabb képfelbontás, a gyengébb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méreth trade‑off‑okat eredményeznek.

**Módosíthatom‑e az exportált SVG elemeket az exportálás után?**

Igen. Azonosítókat rendelhet egy formázási vezérlőn keresztül, majd kiválaszthatja a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptjében.