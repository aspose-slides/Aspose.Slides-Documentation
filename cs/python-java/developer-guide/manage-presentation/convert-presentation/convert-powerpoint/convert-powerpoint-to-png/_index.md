---
title: Převod snímků PowerPoint na PNG v Pythonu
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/python-java/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- Python
- Java
- Aspose.Slides
description: "Převést snímky PowerPointu na PNG obrázky v Pythonu přes Java. Exportovat prezentace PPT, PPTX a ODP s vlastními měřítky nebo přesnými rozměry obrázku."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro Python přes Java. Můžete načíst prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný PNG obrázek.

## **Převod PowerPointu na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a přistupujte k jejím snímkům přes kolekci [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). Příklad vykreslí každý snímek pomocí [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) bez parametrů pro vytvoření miniatury. Poté zavolá [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) s [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) pro uložení každého vykresleného snímku jako PNG obrázku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Parametrický přetížený [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) vykresluje ve měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří miniaturu o rozměrech 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení s měřítkovými faktory nebo explicitní velikostí obrázku, jak je uvedeno níže.
{{% /alert %}}

## **Převod PowerPointu na PNG s vlastním rozměrem**

Předávejte horizontální a vertikální měřítkové faktory metodě [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) pro ovládání vykreslených rozměrů. V tomto příkladu jsou oba faktory rovny 2, takže snímek o rozměrech 720 × 540 bodů vytvoří obrázek o rozměrech 1440 × 1080 pixelů. Stejné měřítkové faktory zachovávají poměr stran snímku. Každý vykreslený obrázek je uložen ve formátu PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pro určení výstupních rozměrů v pixelech předávejte metodě [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) velikost místo měřítkových faktorů. Tento příklad vykreslí všechny snímky na 960 × 720 pixelů a uloží výsledek ve formátu PNG. Zvolte rozměry, které odpovídají poměru stran snímku, aby nedošlo k natažení obrázku.

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Zvolte styl renderování gradientu**

Předpokládejme, že snímek obsahuje gradientní výplně, ale přechody v exportovaném PNG vypadají světleji nebo jinak než v PowerPointu. Můžete použít metodu [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) zděděnou třídou [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) pro výběr způsobu renderování gradientů.

Stáhněte [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurově‑oranžový v horní části a modro‑žlutý ve spodní části. Každý gradient má dva zastavení, na 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí první snímek v obou režimech pomocí [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Obrázky níže ukazují výstup ze stejného snímku, s oběma gradienty v každém obrázku:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty cyan‑to‑orange a blue‑to‑yellow vykreslené pomocí Default](gradient-Default.png) | ![Stejné gradienty vykreslené pomocí PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Default` vytváří světlejší mezibarevné tóny, zatímco `PowerPointUI` vytváří tmavší mezibarevné tóny. Rozdíl závisí na barvách a zastaveních v gradientu.

Zvolte `Default`, pokud vám vyhovuje standartní výstup Aspose.Slides. Vyzkoušejte `PowerPointUI`, pokud je vaším hlavním cílem shoda vzhledu s PowerPointem. Porovnejte oba výstupy s očekávaným výsledkem; žádný režim není univerzálně lepší.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/python-java/create-shape-thumbnails/), což vám umožní vykreslit tvar jako PNG obrázek.

**Je paralelní převod podporován na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každé vlákno nebo proces; [nesdílet jedinou instanci mezi vlákny](/slides/cs/python-java/multithreading/).

**Jaká jsou omezení evaluační verze při exportu do PNG?**

Evaluační režim přidává vodoznak do výstupních obrázků a použije [další omezení](/slides/cs/python-java/licensing/), dokud není licence aplikována.