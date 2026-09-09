---  
title: PowerPoint-presentaties naar TIFF converteren in Python  
linktitle: PowerPoint naar TIFF  
type: docs  
weight: 90  
url: /nl/python-java/convert-powerpoint-to-tiff/  
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
- Python  
- Java  
- Aspose.Slides  
description: "Leer hoe u eenvoudig PowerPoint-presentaties (PPT, PPTX) kunt converteren naar hoogwaardige TIFF-afbeeldingen met Aspose.Slides voor Python via Java, met codevoorbeelden."  
---
## **Introductie**

TIFF (**Tagged Image File Format**) is een rasterafbeeldingsformaat dat meerdere pagina’s en verliesvrije compressie ondersteunt. Het is handig voor het opslaan van gerenderde dia’s in één enkel afbeeldingsbestand.

Met Aspose.Slides for Python via Java kun je PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP) naar TIFF converteren. Elk voorbeeld hieronder start de Java‑virtual machine indien nodig en geeft de presentatie vrij na gebruik.

## **Een presentatie naar TIFF converteren**

Met de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse kun je snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende multipage‑TIFF bevat een gerenderde afbeelding van elke dia in de standaardgrootte.

Deze code toont hoe je een PowerPoint‑presentatie naar TIFF converteert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Sla alle dia's op in een multipage TIFF-bestand.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Een presentatie naar zwart‑wit TIFF converteren**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setBwConversionMode) in de [TiffOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/)‑klasse stelt je in staat om het algoritme te specificeren dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setCompressionType)‑methode is ingesteld op [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) of [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Note" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setBwConversionMode) is een export‑niveau instelling die een pixel‑conversie‑algoritme selecteert voor de volledige TIFF‑afbeelding. Om te definiëren hoe een individuele vorm eruit moet zien wanneer de zwart‑wit weergavemodus actief is, gebruik je [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setBlackWhiteMode). Zie [Control Black-and-White Rendering for Shapes](/slides/nl/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) voor voorbeelden.

{{% /alert %}}

Stel dat we een bestand “sample.pptx” hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

Deze code toont hoe je de gekleurde dia naar een zwart‑wit TIFF converteert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Het resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Een presentatie naar TIFF met een aangepaste grootte converteren**

Als je een TIFF‑afbeelding met specifieke afmetingen nodig hebt, kun je je gewenste waarden instellen met de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setImageSize)‑methode laat je de grootte van de resulterende afbeelding definiëren.

Deze code toont hoe je een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte converteert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Stel de horizontale en verticale resolutie in.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Stel de uitvoerafmetingen in pixels in.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Neem de volledige presentatoropmerkingen op onder elke dia.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Een presentatie naar TIFF met een aangepast pixel‑formaat converteren**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setPixelFormat)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/)‑klasse kun je je voorkeurspixel‑formaat voor de resulterende TIFF‑afbeelding opgeven.

Deze code toont hoe je een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixel‑formaat converteert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}

Bekijk de GRATIS PowerPoint‑naar‑Poster converter van Aspose [hier](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Kan ik een afzonderlijke dia in plaats van een volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt je in staat om individuele dia’s uit PowerPoint‑ en OpenDocument‑presentaties apart naar TIFF‑afbeeldingen te converteren.

**Is er een limiet op het aantal dia’s bij het converteren van een presentatie naar TIFF?**

Er is geen vaste limiet op het aantal dia’s voor TIFF‑export. Beschikbaar geheugen, complexiteit van de dia’s en de uitvoergrootte bepalen hoeveel presentaties je kunt verwerken.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia’s naar TIFF?**

Nee, TIFF is een statisch afbeeldingsformaat. Animaties en overgangseffecten worden niet bewaard; alleen statische momentopnamen van de dia’s worden geëxporteerd.