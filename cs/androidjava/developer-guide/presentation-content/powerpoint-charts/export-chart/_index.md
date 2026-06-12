---
title: Export grafů prezentace na Androidu
linktitle: Export grafu
type: docs
weight: 90
url: /cs/androidjava/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak exportovat grafy prezentací pomocí Aspose.Slides pro Android prostřednictvím Javy, podporující formáty PPT a PPTX, a zefektivněte reportování v jakémkoli pracovním postupu."
---
## **Přehled**

Aspose.Slides vám umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, když potřebujete vizualizaci grafu použít mimo prezentaci PowerPoint.

Kromě základního postupu exportu obrázku článek také řeší časté otázky související s exportem, včetně ukládání obsahu grafu do SVG, řízení velikosti výstupu pomocí možností vykreslování, načítání písem pro zachování vzhledu popisků a legendy a zachování původního formátování prezentace, jako jsou motivy, styly, výplně a efekty během vykreslování.

## **Získat obrázek grafu**
Aspose.Slides for Android via Java poskytuje podporu pro extrakci obrázku konkrétního grafu. Níže je uveden ukázkový příklad.

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

Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí [metody ukládání tvaru do SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížené metody pro vykreslování obrázku, které umožňují zadat velikost nebo měřítko – knihovna podporuje vykreslování objektů s danými rozměry/měřítkem.

**Co mám dělat, když písma v popiscích a legendě vypadají po exportu špatně?**

[Načtěte požadovaná písma](/slides/cs/androidjava/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/), aby vykreslování grafu zachovalo metriky a vzhled textu.

**Respektuje export motiv PowerPointu, styly a efekty?**

Ano. Vykreslovací modul Aspose.Slides dodržuje formátování prezentace (motiv, styly, výplně, efekty), takže vzhled grafu zůstane zachován.

**Kde najdu dostupné možnosti vykreslování/exportu nad rámec obrázků grafů?**

Viz [API](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/)/[dokumentace](/slides/cs/androidjava/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), atd.) a související možnosti vykreslování.