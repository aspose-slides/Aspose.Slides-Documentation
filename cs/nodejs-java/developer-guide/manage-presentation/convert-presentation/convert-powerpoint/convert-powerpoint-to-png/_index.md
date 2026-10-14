---
title: Převod snímků PowerPoint na PNG v JavaScriptu
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky v JavaScriptu rychle s Aspose.Slides pro Node.js a zajistěte přesné, automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro Node.js přes Java. Můžete načíst prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný obrázek PNG.

Níže uvedené příklady ukazují vykreslování ve výchozím měřítku, zvýšení měřítka, určení výstupních rozměrů v pixelech a výběr stylu vykreslování gradientu.

## **Převod PowerPointu na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a přistupte k jejím snímkům prostřednictvím kolekce [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). Příklad vykresluje každý snímek pomocí [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) bez parametrů pro vytvoření miniatury. Poté volá [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) s [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) pro uložení každého vykresleného snímku jako obrázku PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Přetížení [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) bez parametrů vykresluje v měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří miniaturu 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení s faktory měřítka nebo s explicitní velikostí obrázku, jak je ukázáno níže.
{{% /alert %}}

## **Převod PowerPointu na PNG s vlastními rozměry**

Předávejte vodorovné a svislé faktory měřítka metodě [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) pro ovládání vykreslených rozměrů. V tomto příkladu jsou oba faktory 2, takže snímek o rozměrech 720 × 540 bodů vytvoří obrázek 1440 × 1080 pixelů. Stejné faktory měřítka zachovají poměr stran snímku. Každý obrázek je uložen ve formátu PNG pomocí [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pro určení výstupních rozměrů v pixelech předávejte metodě [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) místo faktorů měřítka velikost. Tento příklad vykresluje každý snímek v rozměrech 960 × 720 pixelů a výsledek uloží pomocí [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Zvolte rozměry, které odpovídají poměru stran snímku, aby nedocházelo k roztažení obrázku.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Vyberte styl vykreslování gradientu**

Předpokládejme, že snímek obsahuje výplně gradientem, ale přechody v exportovaném PNG vypadají světleji nebo jinak odlišně od toho, co vidíte v PowerPointu. Můžete použít metodu [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) zděděnou od [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) pro výběr způsobu vykreslení gradientů.

Stáhněte soubor [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurovou k oranžové nahoře a modrou k žluté dole. Každý gradient má dva zastavení na 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí stejný první snímek v obou režimech pomocí [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty od azurové po oranžovou a od modré po žlutou vykreslené pomocí Default](gradient-Default.png) | ![Stejné gradienty vykreslené pomocí PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Default` vytváří světlejší mezilehlé barvy, zatímco `PowerPointUI` vytváří tmavší mezilehlé barvy. Rozdíl závisí na barvách a zastaveních v gradientu.

Zvolte `Default`, když standardní výstup Aspose.Slides vyhovuje vašim potřebám. Vyzkoušejte `PowerPointUI`, když je vaším prioritou shoda vzhledu s PowerPointem. Porovnejte oba výstupy s požadovaným výsledkem; žádný režim není obecně výhodnější.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/nodejs-java/create-shape-thumbnails/), což vám umožní vykreslit tvar jako PNG obrázek.

**Je paralelní konverze podporována na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každý vlákno nebo proces; [nesdílejte jednu instanci napříč vlákny](/slides/cs/nodejs-java/multithreading/).

**Jaká jsou omezení evaluační verze při exportu do PNG?**

Evaluační režim přidává vodoznak k výstupním obrázkům a uplatňuje [další omezení](/slides/cs/nodejs-java/licensing/), dokud není licence použita.