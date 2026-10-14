---
title: Převod snímků PowerPoint na PNG na Androidu
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/androidjava/convert-powerpoint-to-png/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- Android
- Java
- Aspose.Slides
description: "Rychle převádějte prezentace PowerPoint na vysoce kvalitní obrázky PNG pomocí Aspose.Slides pro Android přes Javu, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro Android prostřednictvím Javy. Můžete načíst prezentace ve formátech, jako jsou PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný obrázek PNG.

Níže uvedené příklady ukazují vykreslení v výchozím měřítku, zvýšení měřítka, určení výstupních rozměrů v pixelech a výběr stylu gradientového vykreslení.

## **Převod PowerPointu na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a přistupte k jejím snímkům přes kolekci [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--). Příklad vykresluje každý snímek pomocí [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) bez parametrů pro vytvoření miniatury. Poté volá [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) s [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) pro uložení každého vykresleného snímku jako obrázek PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Přetížení [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) bez parametrů vykresluje v měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří miniaturu o rozměrech 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení s faktory měřítka nebo s explicitní velikostí obrázku, jak je ukázáno níže.
{{% /alert %}}

## **Převod PowerPointu na PNG s vlastními rozměry**

Předávejte horizontální a vertikální faktory měřítka metodě [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) pro řízení vykreslených rozměrů. V tomto příkladu jsou oba faktory 2, takže snímek o velikosti 720 × 540 bodů vytvoří obrázek o rozměrech 1440 × 1080 pixelů. Stejné faktory měřítka zachovávají poměr stran snímku. Každý obrázek se uloží ve formátu PNG pomocí [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Chcete-li určit výstupní rozměry v pixelech, předávejte metodě [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) velikost místo faktorů měřítka. Tento příklad vykresluje každý snímek na 960 × 720 pixelů a výsledek uloží pomocí [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Zvolte rozměry odpovídající poměru stran snímku, aby nedošlo k roztažení obrázku.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Výběr stylu gradientového vykreslení**

Předpokládejme, že snímek obsahuje gradientové výplně, ale přechody v exportovaném PNG vypadají světleji nebo jinak odlišně od toho, co vidíte v PowerPointu. Můžete použít metodu [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) zděděnou třídou [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) , aby jste vybrali, jak se gradienty vykreslují.

Stáhněte [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurový k oranžové nahoře a modrý k žluté dole. Každý gradient má dva zastavení, na 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí první snímek v obou režimech pomocí [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Obrázky níže ukazují výstup ze stejného snímku, s oběma gradienty v každém obrázku:

| Výchozí | PowerPointUI |
| --- | --- |
| ![Gradienty cyan‑k‑oranžové a modré‑k‑žluté vykreslené ve výchozím režimu](gradient-Default.png) | ![Stejné gradienty vykreslené s PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Výchozí` produkuje světlejší střední barvy, zatímco `PowerPointUI` produkuje tmavší střední barvy. Rozdíl závisí na barvách a zastaveních v gradientu.

Zvolte `Výchozí`, když vám vyhovuje standardní výstup Aspose.Slides. Vyzkoušejte `PowerPointUI`, pokud je vaším prioritním cílem shoda vzhledu s PowerPointem. Porovnejte oba výstupy s očekávaným výsledkem; žádný režim není univerzálně výhodnější.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/androidjava/create-shape-thumbnails/), což vám umožní vykreslit tvar jako obrázek PNG.

**Je paralelní konverze podporována na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každý vlákno nebo proces; [nesdílejte jednu instanci mezi vlákny](/slides/cs/androidjava/multithreading/).

**Jaká jsou omezení evaluační verze při exportu do PNG?**

Evaluační režim přidává vodoznak do výstupních obrázků a uplatňuje [další omezení](/slides/cs/androidjava/licensing/), dokud není licence použita.