---
title: PowerPoint-presentaties naar TIFF converteren op Android
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
description: "Leer hoe je gemakkelijk PowerPoint (PPT, PPTX) presentaties naar hoogwaardige TIFF-afbeeldingen kunt converteren met Aspose.Slides voor Android, met Java-codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktopuitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia's (PPT, PPTX) en OpenDocument‑dia's (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, waardoor je presentaties maximaal visueel getrouw blijven.

## **Een presentatie naar TIFF converteren**

Met de [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int‑)‑methode die wordt geleverd door de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse, kun je snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen hebben de standaard dia‑grootte.

Deze code laat zien hoe je een PowerPoint‑presentatie naar TIFF kunt converteren:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatie-bestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Een presentatie naar zwart‑wit TIFF converteren**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int‑) in de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/)‑klasse stelt je in staat het algoritme op te geven dat wordt gebruikt bij het converteren van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Let op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int‑)‑methode is ingesteld op `CCITT4` of `CCITT3`.

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

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen met behulp van methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size‑)‑methode stelt je in staat de grootte van de resulterende afbeelding te definiëren.

Deze code laat zien hoe je een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte kunt converteren:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Compressietypen:
        Default - Geeft het standaard compressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie wordt toegepast.
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

## **Een presentatie naar TIFF met aangepast pixelformaat voor afbeelding converteren**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int‑)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/)‑klasse kun je het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

Deze code laat zien hoe je een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat kunt converteren:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatie-bestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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
Bekijk de [GRATIS PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.
{{% /alert %}}

## **FAQ**

### Kan ik een enkele dia in plaats van een volledige PowerPoint‑presentatie naar TIFF converteren?

Ja. Aspose.Slides stelt je in staat om individuele dia's uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

### Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?

Nee, Aspose.Slides legt geen beperkingen op aan het aantal dia's. Je kunt presentaties van elke omvang naar TIFF‑formaat converteren.

### Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia's naar TIFF?

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische snapshots van dia's worden geëxporteerd.