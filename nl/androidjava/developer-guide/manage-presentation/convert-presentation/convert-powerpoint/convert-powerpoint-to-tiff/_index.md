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
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) kunt converteren naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor Android, inclusief Java‑codevoorbeelden."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktopuitgevers kiezen vaak voor TIFF om lagen, kleurnauwkeurigheid en de oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat je presentaties de maximale visuele getrouwheid behouden.

## **Een presentatie omzetten naar TIFF**

Met behulp van de [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse kun je snel een volledige PowerPoint‑presentatie naar TIFF omzetten. De resulterende TIFF‑afbeeldingen hebben dezelfde afmeting als de standaarddia‑grootte.

Deze code laat zien hoe je een PowerPoint‑presentatie naar TIFF kunt omzetten:

```java
// Maak een instantie van de Presentation‑klasse die een presentatiedocument (PPT, PPTX, ODP, enz.) vertegenwoordigt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Een presentatie omzetten naar zwart-wit TIFF**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/)‑klasse stelt je in staat om het algoritme op te geven dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart-wit TIFF. Let op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)‑methode is ingesteld op `CCITT4` of `CCITT3`.

Stel dat we een bestand "sample.pptx" hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze code laat zien hoe je de gekleurde dia naar een zwart-wit TIFF kunt omzetten:

```java
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

## **Een presentatie omzetten naar TIFF met aangepaste grootte**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je de gewenste waarden instellen met behulp van methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-)‑methode stelt je in staat de grootte van de resulterende afbeelding te definiëren.

Deze code laat zien hoe je een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte kunt omzetten:

```java
// Maak een instantie van de Presentation‑klasse die een presentatiedocument (PPT, PPTX, ODP, enz.) vertegenwoordigt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Compressietypen:
        Default - Geeft het standaardcompressieschema op (LZW).
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

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als TIFF met de opgegeven grootte.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Een presentatie omzetten naar TIFF met aangepast pixel‑formaat**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/)‑klasse kun je het gewenste pixel‑formaat voor de resulterende TIFF‑afbeelding opgeven.

Deze code laat zien hoe je een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixel‑formaat kunt omzetten:

```java
// Maak een instantie van de Presentation‑klasse die een presentatiedocument (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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
    
    // Sla de presentatie op als TIFF met de opgegeven afbeeldingsgrootte.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Bekijk Aspose's [GRATIS PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan ik een individuele dia in plaats van een volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt je in staat om individuele dia’s van PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen beperking op aan het aantal dia's. Je kunt presentaties van elke omvang naar het TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia’s naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische snapshots van de dia’s worden geëxporteerd.