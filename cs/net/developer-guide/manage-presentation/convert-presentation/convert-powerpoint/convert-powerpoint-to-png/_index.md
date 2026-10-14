---
title: Převést snímky PowerPoint na PNG v .NET
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro .NET a zajistěte přesné, automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro .NET. Můžete načíst prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný obrázek PNG.

Níže uvedené příklady demonstrují vykreslování miniatur, nastavení měřítkových faktorů, určení výstupních rozměrů v pixelech a výběr stylu vykreslování gradientu.

## **Převést PowerPoint na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přistupujte k jejím snímkům přes kolekci [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Příklad vykresluje každý snímek pomocí [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) bez parametrů k vytvoření miniatury. Poté volá [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) s [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) pro uložení každého vykresleného snímku jako PNG obrázek.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Přetížení [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) bez parametrů vykresluje v měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří miniaturu 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení s měřítkovými faktory nebo explicitní velikost obrázku uvedenou níže.
{{% /alert %}}

## **Převést PowerPoint na PNG s vlastními rozměry**

Předávejte horizontální a vertikální měřítkové faktory metodě [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pro řízení vykreslených rozměrů. V tomto příkladu jsou oba faktory 2, takže snímek o rozměrech 720 × 540 bodů vytvoří obrázek 1440 × 1080 pixelů. Stejné faktory zachovávají poměr stran snímku. Každý obrázek je uložen ve formátu PNG pomocí [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Převést PowerPoint na PNG s vlastní velikostí**

Pro zadání výstupních rozměrů v pixelech předávejte metodě [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) velikost místo měřítkových faktorů. Tento příklad vykresluje každý snímek na 960 × 720 pixelů a výsledek uloží pomocí [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Zvolte rozměry, které odpovídají poměru stran snímku, aby nedošlo k natažení obrázku.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Vyberte styl vykreslování gradientu**

Předpokládejme, že snímek obsahuje gradientové výplně, ale přechody v exportovaném PNG vypadají světlejší nebo jinak odlišně od toho, co vidíte v PowerPointu. Můžete použít vlastnost [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) třídy [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) k volbě způsobu vykreslování gradientů.

Stáhněte soubor [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: cyan na oranžovou v horní části a modrou na žlutou ve spodní části. Každý gradient má dva zastavení, při 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí ten samý první snímek v obou režimech pomocí [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Obrázky níže ukazují výstup ze stejného snímku, s oběma gradienty v každém obrázku:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty od cyan až po oranžovou a od modré po žlutou vykreslené pomocí Default](gradient-Default.png) | ![Stejné gradienty vykreslené pomocí PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Default` vytváří světlejší přechodové barvy, zatímco `PowerPointUI` vytváří tmavší přechodové barvy. Rozdíl závisí na barvách a zastaveních v gradientu.

Zvolte `Default`, pokud vám vyhovuje standardní výstup Aspose.Slides. Vyzkoušejte `PowerPointUI`, pokud je vaším cílem co nejvíce odpovídat vzhledu v PowerPointu. Porovnejte oba výstupy s požadovaným výsledkem; žádný režim není obecně lepší.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/net/create-shape-thumbnails/), což vám umožní vykreslit tvar jako PNG obrázek.

**Je paralelní konverze podporována na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každý vláknový či procesní kontext; [nesdílejte jednu instanci napříč vlákny](/slides/cs/net/multithreading/).

**Jaká jsou omezení evaluační verze při exportu do PNG?**

Evaluační režim přidává vodoznak do výstupních obrázků a uplatňuje [další omezení](/slides/cs/net/licensing/), dokud není licence použita.