---
title: PowerPoint-presentaties omzetten naar TIFF in JavaScript
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
description: "Leer hoe u eenvoudig PowerPoint (PPT, PPTX)-presentaties kunt omzetten naar hoogwaardige TIFF-afbeeldingen met Aspose.Slides voor Node.js, met JavaScript‑codevoorbeelden."
---
## **Introductie**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesloos rasterafbeeldingsformaat dat bekend staat om zijn uitstekende kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktoppublishers kiezen vaak TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) direct omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat uw presentaties hun maximale visuele getrouwheid behouden.

## **Presentatie omzetten naar TIFF**

Met behulp van de [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)‑methode die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse, kunt u snel een volledige PowerPoint‑presentatie omzetten naar TIFF. De resulterende TIFF‑afbeeldingen komen overeen met de standaard dia‑grootte.

Deze JavaScript‑code toont hoe u een PowerPoint‑presentatie naar TIFF kunt converteren:

```js
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Presentatie omzetten naar zwart‑wit TIFF**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/)‑klasse stelt u in staat om het algoritme op te geven dat wordt gebruikt bij het converteren van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-)‑methode is ingesteld op `CCITT4` of `CCITT3`.

Stel dat we een bestand “sample.pptx” hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze JavaScript‑code toont hoe u de gekleurde dia naar een zwart‑wit TIFF kunt converteren:

```js
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

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Presentatie omzetten naar TIFF met aangepaste grootte**

Als u een TIFF‑afbeelding met specifieke afmetingen nodig heeft, kunt u uw gewenste waarden instellen met behulp van de methoden die beschikbaar zijn in de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setImageSize)‑methode stelt u in staat de grootte van de resulterende afbeelding te definiëren.

Deze JavaScript‑code toont hoe u een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte kunt converteren:

```js
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Compressietypes:
        Default - Geeft het standaardcompressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie wordt toegepast.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De diepte is afhankelijk van het compressietype en kan niet handmatig worden ingesteld.

    // Stel de afbeelding DPI in.
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

## **Presentatie omzetten naar TIFF met aangepaste beeldpixelindeling**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/)‑klasse kunt u de gewenste pixelindeling voor de resulterende TIFF‑afbeelding opgeven.

Deze JavaScript‑code toont hoe u een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepaste pixelindeling kunt converteren:

```js
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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

{{% alert title="Tip" color="primary" %}}
Bekijk de [GRATIS PowerPoint‑naar‑poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.
{{% /alert %}}

## **FAQ**

**Kan ik een individuele dia omzetten in plaats van een volledige PowerPoint‑presentatie naar TIFF?**

Ja. Aspose.Slides stelt u in staat om individuele dia’s uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk om te zetten naar TIFF‑afbeeldingen.

**Is er een limiet aan het aantal dia’s bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia’s. U kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia’s naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische momentopnames van de dia’s worden geëxporteerd.