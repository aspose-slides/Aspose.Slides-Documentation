---
title: Exportovat grafy prezentace v Pythonu přes Java
linktitle: Exportovat graf
type: docs
weight: 90
url: /cs/python-java/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak exportovat grafy prezentací pomocí Aspose.Slides pro Python přes Java, s podporou formátů PPT a PPTX, a zjednodušte reportování v jakémkoli workflow."
---
## **Přehled**

Aspose.Slides vám umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit ho, což je užitečné, když potřebujete znovu použít vizuály grafu mimo prezentaci PowerPoint.

Kromě základního postupu exportu obrázku se článek také věnuje běžným otázkám souvisejícím s exportem, včetně uložení obsahu grafu do SVG, řízení velikosti výstupu pomocí možností renderování, načítání písem pro zachování vzhledu popisků a legendy a zachování původního formátování prezentace, jako jsou motivy, styly, výplně a efekty během renderování.

## **Získání obrázku grafu**

Aspose.Slides for Python via Java podporuje extrakci obrázku konkrétního grafu. Následující příklad ukazuje, jak to provést.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**

Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí [metody ukládání tvaru do SVG](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížení pro renderování obrázku, které umožňují zadat velikost nebo měřítko – knihovna podporuje renderování objektů s určenými rozměry/měřítkem.

**Co mám dělat, pokud fonty v popiscích a legendě vypadají po exportu špatně?**

[Načtěte požadovaná písma](/slides/cs/python-java/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/), aby renderování grafu zachovalo metriky a vzhled textu.

**Respektuje export téma, styly a efekty PowerPointu?**

Ano. Renderér Aspose.Slides dodržuje formátování prezentace (motivy, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde mohu najít další dostupné možnosti renderování/exportu mimo obrázky grafů?**

Podívejte se na [API](https://reference.aspose.com/slides/cs/python-java/aspose.slides/)/[dokumentaci](/slides/cs/python-java/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/python-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-java/convert-powerpoint-to-html/), atd.) a související možnosti renderování.