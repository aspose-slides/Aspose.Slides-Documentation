---
title: Exportovat grafy prezentace v .NET
linktitle: Exportovat graf
type: docs
weight: 90
url: /cs/net/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak exportovat grafy prezentace pomocí Aspose.Slides pro .NET, podporující formáty PPT a PPTX, a zefektivněte reportování v jakémkoli pracovním postupu."
---
## **Přehled**

Aspose.Slides umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, když potřebujete znovu použít vizuály grafu mimo prezentaci PowerPoint.

Kromě základního postupu exportu obrázku článek také řeší běžné otázky související s exportem, včetně ukládání obsahu grafu do SVG, řízení velikosti výstupu pomocí možností vykreslování, načítání písem pro zachování vzhledu popisků a legendy a zachování původního formátování prezentace, jako jsou motivy, styly, výplně a efekty během vykreslování.

## **Získání obrázku grafu**
Aspose.Slides pro .NET poskytuje podporu pro extrakci obrázku konkrétního grafu. Níže je uveden ukázkový příklad.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **Často kladené otázky**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**

Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí metody [uložení tvaru do SVG](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/writeassvg/).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížení pro vykreslování obrázků, která umožňují zadat velikost nebo měřítko – knihovna podporuje vykreslování objektů s danými rozměry/měřítkem.

**Co mám dělat, pokud písma v popiscích a legendě po exportu vypadají špatně?**

[Načtěte potřebná písma](/slides/cs/net/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/), aby vykreslování grafu zachovalo metriky a vzhled textu.

**Respektuje export téma, styly a efekty PowerPointu?**

Ano. Vykreslovač Aspose.Slides dodržuje formátování prezentace (motivy, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde mohu najít dostupné možnosti vykreslování/exportu nad rámec obrázků grafů?**

Podívejte se na sekci exportu v [API](https://reference.aspose.com/slides/cs/net/aspose.slides.export/)/[dokumentaci](/slides/cs/net/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/net/convert-powerpoint-to-pdf/), [SVG](/slides/cs/net/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/net/convert-powerpoint-to-xps/), [HTML](/slides/cs/net/convert-powerpoint-to-html/), atd.) a související možnosti vykreslování.