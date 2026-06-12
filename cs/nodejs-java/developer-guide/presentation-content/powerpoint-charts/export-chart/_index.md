---
title: Export grafů z prezentací v JavaScriptu
linktitle: Exportovat graf
type: docs
weight: 90
url: /cs/nodejs-java/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak exportovat grafy z prezentací pomocí Aspose.Slides pro Node.js prostřednictvím Javy, podporující formáty PPT a PPTX, a zjednodušte vytváření zpráv v jakémkoli pracovním postupu."
---
## **Přehled**

Aspose.Slides umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, když potřebujete vizuály grafu znovu použít mimo prezentaci PowerPoint.

## **Získání obrázku grafu**
Aspose.Slides pro Node.js via Java poskytuje podporu pro extrahování obrázku konkrétního grafu. Níže je uveden ukázkový příklad.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**

Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí [shape-to-SVG saving method](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížení pro vykreslování obrázku, která umožňují zadat velikost nebo měřítko – knihovna podporuje vykreslování objektů s určenými rozměry/měřítkem.

**Co mám dělat, pokud vypadají po exportu písma v popiscích a legendě špatně?**

[Načtěte požadovaná písma](/slides/cs/nodejs-java/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/).

**Respektuje export téma, styly a efekty PowerPointu?**

Ano. Vykreslovací engine Aspose.Slides dodržuje formátování prezentace (témata, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde mohu najít dostupné možnosti vykreslování/exportu mimo obrázky grafů?**

Viz [API](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/)/[documentation](/slides/cs/nodejs-java/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/), atd.) a související možnosti vykreslování.