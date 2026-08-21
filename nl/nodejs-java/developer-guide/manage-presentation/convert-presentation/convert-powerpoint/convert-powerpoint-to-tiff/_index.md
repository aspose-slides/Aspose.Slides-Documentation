---
title: PowerPoint‑presentaties omzetten naar TIFF in JavaScript
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint omzetten
- OpenDocument omzetten
- presentatie omzetten
- dia omzetten
- PPT omzetten
- PPTX omzetten
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
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt omzetten naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor Node.js, inclusief JavaScript‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische afbeeldingen. Ontwerpers, fotografen en desktopuitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) direct omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat je presentaties de maximale visuele getrouwheid behouden.

## **Een presentatie omzetten naar TIFF**

Met de [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)-klasse kun je snel een volledige PowerPoint‑presentatie omzetten naar TIFF. De resulterende TIFF‑afbeeldingen hebben de standaard dia‑grootte.

Deze JavaScript‑code laat zien hoe je een PowerPoint‑presentatie omzet naar TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Een presentatie omzetten naar Zwart‑wit TIFF**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/)-klasse stelt je in staat om het algoritme op te geven dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-)‑methode is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Opmerking" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te bepalen hoe een individueel vormobject eruitziet wanneer de zwart‑wit weergavemodus actief is, gebruik je [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Zie [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.
{{% /alert %}}

Laten we zeggen dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze JavaScript‑code laat zien hoe je de gekleurde dia omzet naar een zwart‑wit TIFF:

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

Resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Een presentatie omzetten naar TIFF met aangepaste grootte**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen met behulp van de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setImageSize)-methode stelt je in staat om de grootte van de resulterende afbeelding te definiëren.

Deze JavaScript‑code laat zien hoe je een PowerPoint‑presentatie omzet naar TIFF‑afbeeldingen met een aangepaste grootte:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Compressietypen:
        Default - Geeft het standaardcompressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie is.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De kleurdiepte wordt bepaald door het pixel‑formaat (zie het voorbeeld hieronder); CCITT3 en CCITT4 produceren altijd 1 bit per pixel.

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

## **Een presentatie omzetten naar TIFF met aangepast pixel‑formaat**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat)-methode van de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/)-klasse kun je het gewenste pixel‑formaat voor de resulterende TIFF‑afbeelding opgeven.

Deze JavaScript‑code laat zien hoe je een PowerPoint‑presentatie omzet naar een TIFF‑afbeelding met een aangepast pixel‑formaat:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat bevat de volgende waarden (zoals vermeld in de documentatie):
        Format1bppIndexed - 1 bit per pixel, geïndexeerd.
        Format4bppIndexed - 4 bits per pixel, geïndexeerd.
        Format8bppIndexed - 8 bits per pixel, geïndexeerd.
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
Bekijk de [GRATIS PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.
{{% /alert %}}

## **FAQ**

**Kan ik een individuele dia in plaats van een volledige PowerPoint‑presentatie omzetten naar TIFF?**

Ja. Aspose.Slides stelt je in staat om individuele dia’s van PowerPoint‑ en OpenDocument‑presentaties afzonderlijk om te zetten naar TIFF‑afbeeldingen.

**Is er een limiet op het aantal dia’s bij het omzetten van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia’s. Je kunt presentaties van elke omvang naar TIFF‑formaat omzetten.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het omzetten van dia’s naar TIFF?**

Nee, TIFF is een statisch afbeeldingformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische momentopnamen van de dia’s worden geëxporteerd.