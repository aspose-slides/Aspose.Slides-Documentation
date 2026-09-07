---
title: Převod prezentací PowerPoint do TIFF v Pythonu
linktitle: PowerPoint do TIFF
type: docs
weight: 90
url: /cs/python-java/convert-powerpoint-to-tiff/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do TIFF
- prezentace do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak jednoduše převést prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF snímků pomocí Aspose.Slides pro Python prostřednictvím Javy, s ukázkovými kódy."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je rastrový formát obrázku, který podporuje více stránek a bezztrátovou kompresi. Je užitečný pro uložení vykreslených snímků v jednom souboru obrázku.

Pomocí Aspose.Slides pro Python prostřednictvím Javy můžete převést prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) do TIFF. Každý následující příklad spustí virtuální stroj Javy, pokud je to potřeba, a po použití uvolní prezentaci. 

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) můžete rychle převést celou prezentaci PowerPoint do TIFF. Výsledný vícestránkový TIFF obsahuje vykreslený obrázek každého snímku ve výchozí velikosti.

Tento kód ukazuje, jak převést prezentaci PowerPoint do TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Uložit všechny snímky do vícestránkového TIFF souboru.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#setBwConversionMode) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/) vám umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#setCompressionType) nastavena na [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) nebo [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Poznámka" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#setBwConversionMode) je nastavení na úrovni exportu, které vybírá algoritmus převodu pixelů pro kompletní TIFF obrázek. Pro určení, jak má vypadat jednotlivý tvar při aktivním černobílém režimu zobrazení, použijte [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setBlackWhiteMode). Příklady najdete v [Control Black-and-White Rendering for Shapes](/slides/cs/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes).
{{% /alert %}}

Řekněme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód ukazuje, jak převést barevný snímek na černobílý TIFF:

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

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#setImageSize) vám umožňuje definovat velikost výsledného obrázku.

Tento kód ukazuje, jak převést prezentaci PowerPoint na TIFF obrázky s vlastní velikostí:

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

    # Nastavit horizontální a vertikální rozlišení.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Nastavit výstupní rozměry v pixelech.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Zahrnout úplné poznámky přednášejícího pod každý snímek.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrázku**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#setPixelFormat) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/) můžete určit požadovaný formát pixelů pro výsledný TIFF obrázek.

Tento kód ukazuje, jak převést prezentaci PowerPoint na TIFF obrázek s vlastním formátem pixelů:

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
Vyzkoušejte Aspose [BEZPLATNÝ konvertor PowerPoint na poster](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé prezentace PowerPoint do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z prezentací PowerPoint a OpenDocument do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Neexistuje pevný limit počtu snímků pro export do TIFF. Dostupná paměť, složitost snímků a výstupní rozměry ovlivňují velikost prezentací, které můžete zpracovat.

**Zůstávají při převodu snímků do TIFF zachovány animace a přechodové efekty PowerPointu?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; exportovány jsou pouze statické snímky snímků.