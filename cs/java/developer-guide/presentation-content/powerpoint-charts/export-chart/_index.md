---
title: Exportovat grafy prezentace v Java
linktitle: Export grafu
type: docs
weight: 90
url: /cs/java/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak exportovat grafy z prezentací pomocí Aspose.Slides pro Java, podporující formáty PPT a PPTX, a zefektivněte vytváření zpráv v jakémkoli pracovním postupu."
---
## **Přehled**

Aspose.Slides vám umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, když potřebujete znovu použít vizuály grafu mimo prezentaci PowerPoint.

Kromě základního postupu exportu obrázku se článek také věnuje běžným otázkám souvisejícím s exportem, včetně ukládání obsahu grafu do SVG, řízení velikosti výstupu pomocí možností renderování, načítání fontů pro zachování vzhledu popisků a legendy a zachování původního formátování prezentace, jako jsou motivy, styly, výplně a efekty během renderování.

## **Získání obrázku grafu**
Aspose.Slides pro Java poskytuje podporu pro extrakci obrázku konkrétního grafu. Níže je uveden ukázkový příklad.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**

Ano. Graf je tvar a jeho obsah lze uložit do formátu SVG pomocí [metody ukládání shape-to-SVG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížení pro renderování obrázku, která umožňují zadat velikost nebo měřítko — knihovna podporuje renderování objektů s danými rozměry/měřítkem.

**Co mám dělat, pokud fonty v popiscích a legendě vypadají po exportu špatně?**

[Načtěte požadované fonty](/slides/cs/java/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/) tak, aby renderování grafu zachovalo metriky a vzhled textu.

**Respektuje export motiv PowerPointu, styly a efekty?**

Ano. Renderér Aspose.Slides dodržuje formátování prezentace (motivy, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde mohu najít dostupné možnosti renderování/exportu mimo obrázky grafů?**

Podívejte se na [API](https://reference.aspose.com/slides/cs/java/com.aspose.slides/)/[dokumentaci](/slides/cs/java/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/java/convert-powerpoint-to-pdf/), [SVG](/slides/cs/java/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/java/convert-powerpoint-to-xps/), [HTML](/slides/cs/java/convert-powerpoint-to-html/), atd.) a související možnosti renderování.