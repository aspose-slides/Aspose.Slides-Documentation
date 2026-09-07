---
title: Převod snímků PowerPoint do PNG v Pythonu
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /cs/python-java/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do PNG
- prezentaci do PNG
- snímek do PNG
- PPT do PNG
- PPTX do PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- Python
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint na PNG obrázky v Pythonu přes Java. Exportujte PPT, PPTX a ODP prezentace s vlastním měřítkem nebo přesnými rozměry obrázku."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint na obrázky PNG pomocí Aspose.Slides pro Python přes Java. Můžete načíst soubory PPT, PPTX a ODP, vykreslit každou snímek a uložit jej jako samostatný obrázek PNG.  
Příklady také ukazují, jak řídit výstupní rozměry pomocí faktorů měřítka nebo přesné šířky a výšky. Každý příklad spustí virtuální stroj Java, pokud je to potřeba, a po použití uvolní prostředky prezentace a obrázku.

## **Převod PowerPointu na PNG**

1. Načtěte vstupní soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte snímky pomocí [Presentation.getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides).
3. Vykreslete každý snímek pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage).
4. Uložte každý vykreslený obrázek pomocí [ImageFormat.Png](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/#Png) a poté uvolněte jeho prostředky.

Následující příklad v Pythonu exportuje všechny snímky v jejich výchozí velikosti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Převod PowerPointu na PNG s vlastním měřítkem**

Předejte horizontální a vertikální faktory měřítka metodě [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage), aby se zvýšily nebo snížily výstupní rozměry. Například snímek o velikosti 720 × 540 bodů vykreslený s faktorem měřítka 2 na obou osách vytvoří obrázek 1440 × 1080 pixelů.  
Použijte stejné faktory měřítka pro zachování poměru stran snímku. Různé faktory snímek roztaží horizontálně nebo vertikálně.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pro určení přesných rozměrů v pixelech předáte objekt Java `Dimension` s požadovanou šířkou a výškou metodě [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage). Zvolte rozměry se stejným poměrem stran jako má původní snímek, aby nedošlo k deformaci.  
Následující příklad ukládá každý snímek jako PNG obrázek o rozměrech 960 × 720 pixelů:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu exportovat jednotlivý tvar, například graf nebo obrázek, místo celého snímku?**

Ano. Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/python-java/create-shape-thumbnails/), které můžete uložit jako PNG obrázky.

**Mohu převádět prezentace paralelně na serveru?**

Používejte samostatnou instanci prezentace pro každý vlákný nebo proces a používejte jedinečné výstupní cesty, aby nedošlo k přepsání souborů. Nesdílejte instanci prezentace mezi vlákny. Viz [Multithreading](/slides/cs/python-java/multithreading/).

**Jaká jsou omezení zkušební verze při exportu do PNG?**

Režim hodnocení přidává vodoznak k výstupním obrázkům a uplatňuje [další omezení](/slides/cs/python-java/licensing/). Použijte licenci k odstranění těchto omezení.