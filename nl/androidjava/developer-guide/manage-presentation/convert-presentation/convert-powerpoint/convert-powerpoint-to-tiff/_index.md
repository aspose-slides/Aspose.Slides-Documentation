---
title: PowerPoint-presentaties converteren naar TIFF op Android
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
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt converteren naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor Android, met Java‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, lossless rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktopuitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en originele instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint‑dia's (PPT, PPTX) en OpenDocument‑dia's (ODP) direct omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat uw presentaties de maximale visuele getrouwheid behouden. 

## **Een presentatie converteren naar TIFF**

Met behulp van de [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse kunt u snel een volledige PowerPoint‑presentatie naar TIFF converteren. De gegenereerde TIFF‑afbeeldingen komen overeen met de standaarddia‑grootte.

Deze code toont hoe u een PowerPoint‑presentatie naar TIFF converteert:

```java
import com.aspose.slides.*;

// Instantieer de Presentation‑klasse die een presentatiebestand vertegenwoordigt (PPT, PPTX, ODP, enz.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Een presentatie converteren naar zwart-wit TIFF**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/) klasse stelt u in staat het algoritme te bepalen dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart-wit TIFF. Let op: deze instelling geldt alleen wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) methode is ingesteld op `CCITT4` of `CCITT3`.

{{% alert color="info" title="Note" %}}

TiffOptions.setBwConversionMode is een export‑niveau instelling die een pixel‑conversie‑algoritme kiest voor de volledige TIFF‑afbeelding. Om te bepalen hoe een afzonderlijke vorm moet worden weergegeven wanneer de zwart‑wit weergavemodus actief is, gebruikt u [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Zie [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.

{{% /alert %}}

Laten we aannemen dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze code toont hoe u de gekleurde dia naar een zwart-wit TIFF converteert:

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

![Zwart-wit TIFF](TIFF_black_and_white.png)

## **Een presentatie converteren naar TIFF met aangepaste grootte**

Als u een TIFF‑afbeelding met specifieke afmetingen nodig heeft, kunt u de gewenste waarden instellen met behulp van de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) methode stelt u in staat de grootte van de gegenereerde afbeelding te definiëren.

Deze code toont hoe u een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte converteert:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Compressietypen:
        Default - Geeft het standaard compressieschema aan (LZW).
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

## **Een presentatie converteren naar TIFF met aangepast pixel‑formaat**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) methode van de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/) klasse kunt u het gewenste pixel‑formaat voor de gegenereerde TIFF‑afbeelding opgeven.

Deze code toont hoe u een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixel‑formaat converteert:

```java
import com.aspose.slides.*;

// Instantieer de Presentation‑klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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
    
    // Sla de presentatie op als TIFF met het opgegeven pixel‑formaat.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Bekijk de [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online) van Aspose.

{{% /alert %}}

## **FAQ**

**Kan ik een individuele dia in plaats van een volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides maakt het mogelijk individuele dia's uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides stelt geen beperkingen aan het aantal dia's. U kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch beeldformaat. Animaties en overgangseffecten worden dus niet behouden; alleen statische snapshots van de dia’s worden geëxporteerd.