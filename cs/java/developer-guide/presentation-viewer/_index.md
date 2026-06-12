---
title: Vytvoření prohlížeče prezentací v Javě
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací v Javě pomocí Aspose.Slides. Jednoduše zobrazujte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides pro Java se používá k vytváření souborů prezentací se snímky. Tyto snímky lze zobrazit otevřením prezentací například v Microsoft PowerPointu. Někdy však vývojáři mohou potřebovat zobrazit snímky jako obrázky ve svém preferovaném prohlížeči obrázků nebo vytvořit vlastní prohlížeč prezentací. V takových případech Aspose.Slides umožňuje exportovat jednotlivý snímek jako obrázek. Tento článek popisuje, jak to provést.

## **Vygenerovat SVG obrázek ze snímku**

Pro vygenerování SVG obrázku ze snímku prezentace pomocí Aspose.Slides postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
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

## **Vygenerovat SVG s vlastním ID tvaru**

Aspose.Slides lze použít k vygenerování [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním ID tvaru. K tomu použijte metodu `setId` z [ISvgShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` lze použít k nastavení ID tvaru.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Vytvořit miniaturu snímku**

Aspose.Slides vám pomáhá generovat miniatury snímků. Pro vygenerování miniatury snímku pomocí Aspose.Slides postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu obrázku odkazovaného snímku v definovaném měřítku.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu obrázku.

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

## **Vytvořit miniaturu snímku s uživatelem určenými rozměry**

Pro vytvoření miniatury snímku s uživatelem určenými rozměry postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu obrázku odkazovaného snímku s definovanými rozměry.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu obrázku.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Vytvořit miniaturu snímku s poznámkami přednášejícího**

Pro vygenerování miniatury snímku s poznámkami přednášejícího pomocí Aspose.Slides postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/).
1. Použijte metodu `RenderingOptions.setSlidesLayoutOptions` k nastavení polohy poznámek přednášejícího.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte miniaturu obrázku odkazovaného snímku s nastavenými možnostmi renderování.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu obrázku.

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

Můžete vyzkoušet bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/), abyste viděli, co můžete implementovat pomocí API Aspose.Slides:

![Online prohlížeč PowerPoint](online-PowerPoint-viewer.png)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace?**

Ano. Můžete použít Aspose.Slides na straně serveru k vykreslení snímků jako obrázků nebo HTML a zobrazit je v prohlížeči. Navigační a zoomovací funkce lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob, jak zobrazit snímky v vlastním prohlížeči?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej převést na HTML pomocí Aspose.Slides, a poté zobrazit výstup v picture boxu (pro desktop) nebo v HTML kontejneru (pro web).

**Jak zacházet s velkými prezentacemi s mnoha snímky?**

U velkých prezentací zvažte lazy-loading nebo renderování snímků na vyžádání. To znamená generovat obsah snímku pouze při přechodu uživatele na něj, čímž se snižuje spotřeba paměti a doba načítání.