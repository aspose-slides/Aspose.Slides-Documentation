---
title: Vytvořte prohlížeč prezentací v JavaScriptu
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/nodejs-java/presentation-viewer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací v JavaScriptu s Aspose.Slides pro Node.js. Jednoduše zobrazujte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides pro Node.js přes Java se používá k vytváření souborů prezentací se snímky. Tyto snímky lze zobrazit otevřením prezentací v Microsoft PowerPointu, například. Někdy však vývojáři potřebují zobrazit snímky jako obrázky ve svém preferovaném prohlížeči obrázků nebo vytvořit vlastní prohlížeč prezentací. V takových případech Aspose.Slides umožňuje exportovat individuální snímek jako obrázek. Tento článek popisuje, jak to provést.

## **Vytvoření SVG obrázku ze snímku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Otevřete souborový tok.
1. Uložte snímek jako SVG obrázek do souborového toku.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Vytvoření SVG s vlastním ID tvaru**

Aspose.Slides lze použít k vygenerování [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním ID tvaru. K tomu použijte metodu `setId` z [SvgShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` lze použít k nastavení ID tvaru.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Vytvoření miniatury snímku**

Aspose.Slides vám pomáhá generovat miniatury snímků. Pro vytvoření miniatury snímku pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu obrázku referencovaného snímku v definovaném měřítku.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Vytvoření miniatury snímku s uživatelem definovanými rozměry**

Pro vytvoření miniatury snímku s uživatelem definovanými rozměry postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu obrázku referencovaného snímku s definovanými rozměry.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Vytvoření miniatury snímku s poznámkami přednášejícího**

Pro vytvoření miniatury snímku s poznámkami přednášejícího pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/).
1. Použijte metodu `RenderingOptions.setSlidesLayoutOptions` k nastavení polohy poznámek přednášejícího.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu obrázku referencovaného snímku s renderovacími možnostmi.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Živý příklad**

Můžete vyzkoušet bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/), abyste viděli, co můžete implementovat pomocí Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace Node.js?**

Ano. Můžete použít Aspose.Slides na straně serveru k vykreslení snímků jako obrázky nebo HTML a zobrazit je v prohlížeči. Navigační a zoom funkce lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob, jak zobrazit snímky v rámci vlastního prohlížeče?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej převést na HTML pomocí Aspose.Slides a pak zobrazit výstup v picture boxu (pro desktop) nebo v HTML kontejneru (pro web).

**Jak zvládnu velké prezentace s mnoha snímky?**

U velkých prezentací zvažte lazy-loading nebo renderování snímků na vyžádání. To znamená generovat obsah snímku pouze v okamžiku, kdy se uživatel na něj přepne, čímž se snižuje spotřeba paměti a čas načítání.