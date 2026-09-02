---
title: PowerPoint‑presentaties converteren naar TIFF in JavaScript
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar TIFF
- presentatie naar TIFF
- dia naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- PPT opslaan als TIFF
- PPTX opslaan als TIFF
- PPT exporteren naar TIFF
- PPTX exporteren naar TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt converteren naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor Node.js, met JavaScript‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt lossless rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktop‑uitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint‑dia's (PPT, PPTX) en OpenDocument‑dia's (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat uw presentaties maximaal visueel getrouw blijven.

## **Converteer een presentatie naar TIFF**

Met de [opslaan](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) methode die wordt geleverd door de [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse, kunt u snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen komen overeen met de standaard dia‑grootte.

Deze JavaScript‑code laat zien hoe u een PowerPoint‑presentatie naar TIFF converteert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) representeert.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Converteer een presentatie naar zwart‑wit TIFF**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) klasse stelt u in staat het algoritme op te geven dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) methode is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Opmerking" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te definiëren hoe een individuele vorm moet worden weergegeven wanneer de zwart‑wit weergavemodus actief is, gebruikt u [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Zie [Controleer zwart‑wit rendering voor vormen](/slides/nl/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.
{{% /alert %}}

Stel, we hebben een bestand **sample.pptx** met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze JavaScript‑code laat zien hoe u de gekleurde dia naar een zwart‑wit TIFF converteert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Zwart-wit TIFF](TIFF_black_and_white.png)

## **Converteer een presentatie naar TIFF met aangepaste grootte**

Als u een TIFF‑afbeelding met specifieke afmetingen nodig heeft, kunt u uw gewenste waarden instellen via methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/). De methode [setImageSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setImageSize) stelt u bijvoorbeeld in staat de grootte van de resulterende afbeelding te definiëren.

Deze JavaScript‑code laat zien hoe u een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte converteert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation-klasse die een presentiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Compressietypen:
        Default - Geeft het standaardcompressieschema aan (LZW).
        None - Geeft aan dat er geen compressie wordt toegepast.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De kleurdiepte wordt geregeld door het pixelformaat (zie het voorbeeld hieronder); CCITT3 en CCITT4 geven altijd 1 bit per pixel.

    // Stel de DPI van de afbeelding in.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Stel de afbeeldingsgrootte in.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als TIFF met de opgegeven grootte.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Converteer een presentatie naar TIFF met aangepast beeldpixelformaat**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) methode van de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) klasse kunt u het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

Deze JavaScript‑code laat zien hoe u een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat converteert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation-klasse die een presentiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat bevat de volgende waarden (zoals vermeld in de documentatie):
        Format1bppIndexed - 1 bit per pixel, geïndiceerd.
        Format4bppIndexed - 4 bits per pixel, geïndiceerd.
        Format8bppIndexed - 8 bits per pixel, geïndiceerd.
        Format24bppRgb    - 24 bits per pixel, RGB.
        Format32bppArgb   - 32 bits per pixel, ARGB.
    */

    /// Sla de presentatie op als TIFF met de opgegeven afbeeldingsgrootte.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Bekijk Aspose’s [GRATIS PowerPoint‑naar‑poster converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik een individuele dia converteren in plaats van de volledige PowerPoint‑presentatie naar TIFF?**

Ja. Aspose.Slides stelt u in staat individuele dia's uit PowerPoint‑ en OpenDocument‑presentaties apart naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia's. U kunt presentaties van elke omvang naar het TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Animaties en overgangseffecten worden daarom niet behouden; alleen statische momentopnames van de dia’s worden geëxporteerd.