---
title: Vytvoření prohlížeče prezentací pro Android
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/androidjava/presentation-viewer/
keywords:
- zobrazit prezentaci
- prohlížeč prezentací
- vytvořit prohlížeč prezentací
- zobrazit PPT
- zobrazit PPTX
- zobrazit ODP
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací v jazyce Java pomocí Aspose.Slides pro Android. Jednoduše zobrazte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides pro Android přes Java se používá k vytváření souborů prezentací s snímky. Tyto snímky lze zobrazit otevřením prezentace v Microsoft PowerPointu, například. Někdy však vývojáři potřebují zobrazit snímky jako obrázky ve svém preferovaném prohlížeči obrázků nebo vytvořit vlastní prohlížeč prezentací. V takových případech umožňuje Aspose.Slides exportovat jednotlivý snímek jako obrázek. Tento článek popisuje, jak na to.

## **Vytvoření SVG obrázku ze snímku**

Chcete-li vygenerovat SVG obrázek ze snímku prezentace pomocí Aspose.Slides, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Otevřete souborový stream.
1. Uložte snímek jako SVG obrázek do souborového streamu.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Vytvoření SVG s vlastním ID tvaru**

Aspose.Slides lze použít k vygenerování [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním ID tvaru. K tomu použijte metodu `setId` z [ISvgShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` lze použít k nastavení ID tvaru.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Vytvoření miniatury snímku**

Aspose.Slides vám pomáhá generovat miniatury obrázků snímků. Chcete-li vygenerovat miniaturu snímku pomocí Aspose.Slides, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu obrázku odkazovaného snímku v definovaném měřítku.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Vytvoření miniatury snímku s uživatelem definovanými rozměry**

Chcete-li vytvořit miniaturu snímku s uživatelem definovanými rozměry, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu obrázku odkazovaného snímku s definovanými rozměry.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Vytvoření miniatury snímku s poznámkami řečníka**

Chcete-li vygenerovat miniaturu snímku s poznámkami řečníka pomocí Aspose.Slides, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/renderingoptions/) .
1. Použijte metodu `RenderingOptions.setSlidesLayoutOptions` k nastavení umístění poznámek řečníka.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu obrázku odkazovaného snímku s možnostmi vykreslování.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Ukázkový příklad**

Můžete vyzkoušet bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/) a zjistit, co můžete implementovat pomocí Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace?**

Ano. Můžete použít Aspose.Slides na straně serveru k vykreslování snímků jako obrázků nebo HTML a zobrazit je v prohlížeči. Navigaci a funkce přiblížení lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob, jak zobrazit snímky v vlastním prohlížeči?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej převést na HTML pomocí Aspose.Slides a poté výstup zobrazit v obrazovém rámečku (pro desktop) nebo v HTML kontejneru (pro web).

**Jak zacházet s velkými prezentacemi s mnoha snímky?**

U velkých prezentací zvažte lazy-loading nebo vykreslování snímků na požádání. To znamená generovat obsah snímku pouze tehdy, když do něj uživatel přejde, což snižuje paměťovou náročnost a dobu načítání.