---
title: Převod snímků PowerPointu na PNG v Pythonu
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/python-net/convert-powerpoint-to-png/
keywords:
- převést PowerPoint na PNG
- převést prezentaci na PNG
- převést snímek na PNG
- převést PPT na PNG
- převést PPTX na PNG
- převést ODP na PNG
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- ODP na PNG
- Python
- Aspose.Slides
description: "Převádějte prezentace PowerPoint a OpenDocument na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro Python přes .NET, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro Python přes .NET. Můžete načíst prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný obrázek PNG.

Níže uvedené příklady ukazují vykreslování v výchozím měřítku, zvýšení měřítka, zadání výstupních rozměrů v pixelech a výběr stylu vykreslování gradientu.

## **Převod PowerPointu na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přistupujte k jejím snímkům prostřednictvím kolekce [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). Příklad vykreslí každý snímek pomocí [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) bez parametrů pro vytvoření náhledu. Poté zavolá [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) s [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) pro uložení každého vykresleného snímku jako obrázku PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Přetížení [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/), které nevyžaduje žádné parametry, vykresluje v měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří náhled o rozměrech 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení s faktory měřítka nebo s explicitní velikostí obrázku, jak je uvedeno níže.
{{% /alert %}}

## **Převod PowerPointu na PNG s vlastními rozměry**

Předejte horizontální a vertikální faktory měřítka metodě [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) k řízení vykreslených rozměrů. V tomto příkladu jsou oba faktory nastaveny na 2, takže snímek o rozměrech 720 × 540 bodů vytvoří obrázek o rozměrech 1440 × 1080 pixelů. Stejné faktory měřítka zachovají poměr stran snímku. Každý obrázek je uložen ve formátu PNG pomocí [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pro zadání výstupních rozměrů v pixelech předejte metodě [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) velikost místo faktorů měřítka. Tento příklad vykreslí každý snímek na 960 × 720 pixelů a výsledek uloží pomocí [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Zvolte rozměry, které odpovídají poměru stran snímku, aby nedošlo k roztažení obrázku.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Výběr stylu vykreslování gradientu**

Předpokládejme, že snímek obsahuje výplně gradientů, ale přechody v exportovaném PNG vypadají světlejší nebo jinak odlišně od toho, co vidíte v PowerPointu. Můžete použít vlastnost [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) třídy [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) k výběru, jak budou gradienty vykresleny.

Stáhněte [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurová k oranžové nahoře a modrá k žluté dole. Každý gradient má dva zastavení, při 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí stejný první snímek v obou režimech pomocí [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Obrázky níže ukazují výstup ze stejného snímku, s oběma gradienty v každém obrázku:

| Výchozí | PowerPointUI |
| --- | --- |
| ![Gradienty cyan‑to‑orange a blue‑to‑yellow vykreslené výchozím způsobem](gradient-Default.png) | ![Stejné gradienty vykreslené pomocí PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `DEFAULT` vytváří světlejší mezilehlé barvy, zatímco `POWER_POINT_UI` vytváří tmavší mezilehlé barvy. Rozdíl závisí na barvách a zastaveních v gradientu.

Zvolte `DEFAULT`, pokud vám vyhovuje standardní výstup Aspose.Slides. Vyzkoušejte `POWER_POINT_UI`, pokud je vaším cílem co největší shoda s vzhledem v PowerPointu. Porovnejte oba výstupy s požadovaným výsledkem; žádný režim není univerzálně lepší.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování náhledů pro jednotlivé tvary](/slides/cs/python-net/create-shape-thumbnails/), což vám umožní vykreslit tvar jako PNG obrázek.

**Je paralelní převod podporován na serveru?**

Ano. Použijte samostatnou instanci prezentace pro každé vlákno nebo proces; [nesdílejte jedinou instanci napříč vlákny](/slides/cs/python-net/multithreading/).

**Jaká jsou omezení evaluační verze při exportu do PNG?**

Evaluační režim přidává vodoznak k výstupním obrázkům a uplatňuje [další omezení](/slides/cs/python-net/licensing/), dokud není licence aplikována.