---
title: Vytvořte prohlížeč prezentací v .NET
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/net/presentation-viewer/
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
- .NET
- C#
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací v .NET pomocí Aspose.Slides. Jednoduše zobrazujte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides pro .NET se používá k vytváření prezentačních souborů se snímky. Tyto snímky lze prohlížet například otevřením prezentace v Microsoft PowerPointu. Vývojáři však někdy potřebují zobrazit snímky jako obrázky ve svém oblíbeném prohlížeči obrázků nebo je použít v vlastním prezentačním prohlížeči. V takových případech Aspose.Slides umožňuje exportovat jednotlivé snímky jako obrázky. Tento článek vysvětluje, jak na to.

## **Vytvoření SVG obrázku ze snímku**

Pro vytvoření SVG obrázku ze snímku prezentace pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Otevřete souborový stream.
1. Uložte snímek jako SVG obrázek do souborového streamu.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Vytvoření SVG s vlastním ID tvaru**

Aspose.Slides lze použít k vytvoření [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním `ID` tvaru. Pro dosažení tohoto cíle použijte vlastnost Id z rozhraní [ISvgShape](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgshape). Třída `CustomSvgShapeFormattingController` může být použita k nastavení ID tvaru.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Vytvoření miniatury snímku**

Aspose.Slides vám pomáhá generovat miniatury snímků. Pro vytvoření miniatury snímku pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Vytvořte miniaturu snímku v požadovaném měřítku.
1. Uložte miniaturu v preferovaném formátu obrázku.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Vytvoření miniatury snímku s uživatelem definovanými rozměry**

Pro vytvoření miniatury snímku s uživatelem definovanými rozměry postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Vygenerujte miniaturu snímku se zadanými rozměry.
1. Uložte miniaturu v preferovaném formátu obrázku.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Vytvoření miniatury snímku s poznámkami přednášejícího**

Pro vytvoření miniatury snímku s poznámkami přednášejícího pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/).
1. Použijte vlastnost `RenderingOptions.SlidesLayoutOptions` k nastavení pozice poznámek přednášejícího.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Vygenerujte miniaturu snímku pomocí renderovacích možností.
1. Uložte miniaturu v preferovaném formátu obrázku.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Živý příklad**

Vyzkoušejte bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/), abyste viděli, co můžete implementovat pomocí Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/cs/viewer/)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace ASP.NET?**

Ano. Můžete použít Aspose.Slides na serverové straně k vykreslení snímků jako obrázků nebo HTML a zobrazit je v prohlížeči. Navigační a zoom funkce lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob zobrazování snímků v vlastním .NET prohlížeči?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej převést na HTML pomocí Aspose.Slides, a poté zobrazit výstup v picture boxu (pro desktop) nebo v HTML kontejneru (pro web).

**Jak zvládnout velké prezentace s mnoha snímky?**

U velkých prezentací zvažte lazy-loading nebo načítání na požádání. To znamená generovat obsah snímku pouze při přechodu uživatele na něj, čímž se sníží paměťové a načítací nároky.