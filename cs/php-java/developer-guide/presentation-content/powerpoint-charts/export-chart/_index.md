---
title: Exportovat grafy prezentací v PHP
linktitle: Exportovat graf
type: docs
weight: 90
url: /cs/php-java/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak exportovat grafy prezentací pomocí Aspose.Slides pro PHP přes Java, podporující formáty PPT a PPTX, a zefektivněte vytváření zpráv v jakémkoli pracovním postupu."
---
## **Přehled**

Aspose.Slides vám umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, když potřebujete vizuály grafu použít mimo prezentaci PowerPoint.

## **Získání obrázku grafu**
Aspose.Slides pro PHP přes Java poskytuje podporu pro extrahování obrázku konkrétního grafu. Níže je uveden ukázkový příklad.  

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**

Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí [metody ukládání tvaru do SVG](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížení pro vykreslování obrázku, která umožňují zadat velikost nebo měřítko – knihovna podporuje vykreslování objektů s danými rozměry/měřítkem.

**Co mám dělat, pokud fonty v popiscích a legendě vypadají po exportu špatně?**

[Načtěte požadované fonty](/slides/cs/php-java/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/), aby vykreslování grafu zachovalo metriky a vzhled textu.

**Respektuje export téma, styly a efekty PowerPointu?**

Ano. Vykreslovač Aspose.Slides dodržuje formátování prezentace (témata, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde najdu dostupné možnosti vykreslování/exportu mimo obrázky grafů?**

Podívejte se na [API](https://reference.aspose.com/slides/cs/php-java/aspose.slides/)/[dokumentaci](/slides/cs/php-java/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/php-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/php-java/convert-powerpoint-to-html/), atd.) a související možnosti vykreslování.