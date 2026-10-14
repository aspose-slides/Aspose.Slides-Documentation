---
title: Převod snímků PowerPointu na PNG v Javě
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Rychle převádějte prezentace PowerPointu na vysoce kvalitní PNG obrázky pomocí Aspose.Slides pro Java, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na PNG obrázky pomocí Aspose.Slides pro Java. Můžete načíst prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný PNG obrázek.

Níže uvedené příklady ukazují vykreslování ve výchozím měřítku, zvětšení měřítka, určení výstupních rozměrů v pixelech a výběr stylu vykreslování gradientu.

## **Převod PowerPointu na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a přistupujte k jejím snímkům pomocí kolekce [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--). Příklad vykresluje každý snímek pomocí [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) bez parametrů pro vytvoření miniatury. Poté volá [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) s [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) pro uložení každého vykresleného snímku jako PNG obrázku.

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
Přetížení [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) bez parametrů vykresluje ve měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří miniaturu o rozměrech 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení s faktory měřítka nebo explicitní velikostí obrázku, jak je ukázáno níže.
{{% /alert %}}

## **Převod PowerPointu na PNG s vlastními rozměry**

Předávejte horizontální a vertikální faktory měřítka metodě [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) , abyste řídili vykreslené rozměry. V tomto příkladu jsou oba faktory 2, takže snímek o rozměrech 720 × 540 bodů vytvoří obrázek o rozměrech 1440 × 1080 pixelů. Stejné faktory měřítka zachovávají poměr stran snímku. Každý obrázek je uložen ve formátu PNG pomocí [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

Pro určení výstupních rozměrů v pixelech předávejte velikost metodě [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) místo faktorů měřítka. Tento příklad vykresluje každý snímek na 960 × 720 pixelů a výsledek uloží pomocí [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Vyberte rozměry, které odpovídají poměru stran snímku, aby nedošlo k roztažení obrázku.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

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

## **Výběr stylu vykreslování gradientu**

Předpokládejme, že snímek obsahuje gradientové výplně, ale přechody v exportovaném PNG vypadají světleji nebo jinak odlišně od toho, co vidíte v PowerPointu. Můžete použít metodu [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) , která je zděděna v [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) , a zvolit, jak budou gradienty vykreslovány.

Stáhněte [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurovou k oranžové nahoře a modrou k žluté dole. Každý gradient má dva zastavení, při 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí první snímek v obou režimech pomocí [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

Obrázky níže zobrazují výstup ze stejných snímků, s oběma gradienty v každém obrázku:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Default` produkuje světlejší mezilehlé barvy, zatímco `PowerPointUI` produkuje tmavší mezilehlé barvy. Rozdíl závisí na barvách a zastavení v gradientu.

Zvolte `Default`, když vám vyhovuje standardní výstup Aspose.Slides. Vyzkoušejte `PowerPointUI`, pokud je vaším cílem co nejpřesněji odpovídat vzhledu v PowerPointu. Porovnejte oba výstupy s požadovaným výsledkem; žádný režim není univerzálně lepší.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/java/create-shape-thumbnails/), což vám umožní vykreslit tvar jako PNG obrázek.

**Je paralelní konverze podporována na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každý vlákno nebo proces; [nesdílejte jednu instanci mezi vlákny](/slides/cs/java/multithreading/).

**Jaká jsou omezení hodnocení při exportu do PNG?**

Režim hodnocení přidává vodoznak do výstupních obrázků a uplatňuje [další omezení](/slides/cs/java/licensing/), dokud není licence aplikována.