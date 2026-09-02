---
title: PowerPoint-presentaties omzetten naar TIFF op Android
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt omzetten naar TIFF‑afbeeldingen van hoge kwaliteit met Aspose.Slides voor Android, met Java‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitstekende kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktop-uitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) rechtstreeks omzetten naar TIFF‑afbeeldingen van hoge kwaliteit, waardoor je presentaties de maximale visuele getrouwheid behouden.

## **Een presentatie naar TIFF converteren**

Met behulp van de [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode die door de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse wordt aangeboden, kun je snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen komen overeen met de standaard dia‑grootte.

This code demonstrates how to convert a PowerPoint presentation to TIFF:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) weergeeft.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Een presentatie naar zwart‑wit TIFF converteren**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/)‑klasse stelt je in staat het algoritme te specificeren dat wordt gebruikt bij het converteren van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)‑methode is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Opmerking" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te bepalen hoe een individuele vorm moet verschijnen wanneer de zwart‑wit weergavemodus actief is, gebruik je [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Zie [Control zwart‑wit weergave voor vormen](/slides/nl/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.
{{% /alert %}}

Stel dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze code laat zien hoe je de gekleurde dia naar een zwart‑wit TIFF kunt converteren:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Een presentatie naar TIFF met aangepaste grootte converteren**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen met behulp van de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-)‑methode stelt je in staat de grootte van de resulterende afbeelding te definiëren.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, etc.) weergeeft.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Compressietypen:
        Default - Geeft het standaard compressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie is.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De diepte hangt af van het compressietype en kan niet handmatig worden ingesteld.

    // Stel de DPI van de afbeelding in.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Stel de afbeeldingsgrootte in.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als TIFF met de opgegeven grootte.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Een presentatie naar TIFF met aangepast pixelformaat converteren**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/)‑klasse kun je het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, etc.) weergeeft.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat bevat de volgende waarden (zoals vermeld in de documentatie):
        Format1bppIndexed - 1 bit per pixel, geïndexeerd.
        Format4bppIndexed - 4 bits per pixel, geïndexeerd.
        Format8bppIndexed - 8 bits per pixel, geïndexeerd.
        Format24bppRgb    - 24 bits per pixel, RGB.
        Format32bppArgb   - 32 bits per pixel, ARGB.
    */
    
    // Sla de presentatie op als TIFF met het opgegeven pixelformaat.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Bekijk de gratis PowerPoint‑naar‑poster converter van Aspose: [GRATIS PowerPoint‑naar‑poster converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan ik een individuele dia in plaats van een hele PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt je in staat om individuele dia’s van PowerPoint‑ en OpenDocument‑presentaties apart te converteren naar TIFF‑afbeeldingen.

**Is er een limiet aan het aantal dia’s bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia’s. Je kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia’s naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische momentopnamen van dia’s worden geëxporteerd.