---
title: Export grafů z prezentace pomocí Pythonu
linktitle: Export grafu
type: docs
weight: 90
url: /cs/python-net/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak exportovat grafy z prezentace pomocí Aspose.Slides pro Python via .NET, s podporou formátů PPT, PPTX a ODP, a zefektivněte reporting v jakémkoli workflow."
---
## **Přehled**

Aspose.Slides vám umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, když potřebujete vizuály grafu použít mimo prezentaci PowerPoint.

## **Získání obrázku grafu**
Aspose.Slides for Python via .NET poskytuje podporu pro získání obrázku konkrétního grafu. Níže je uveden ukázkový příklad.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**  
Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí [shape-to-SVG saving method](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/write_as_svg/).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**  
Použijte přetížení pro vykreslování obrázku, která umožňují zadat velikost nebo měřítko – knihovna podporuje vykreslování objektů s danými rozměry/měřítkem.

**Co mám dělat, pokud vypadají po exportu špatně fonty v popiscích a legendě?**  
[Načtěte požadované fonty](/slides/cs/python-net/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/), aby vykreslování grafu zachovalo metriky a vzhled textu.

**Respektuje export téma PowerPointu, styly a efekty?**  
Ano. Vykreslovací engine Aspose.Slides respektuje formátování prezentace (témata, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde mohu najít dostupné možnosti vykreslování/exportu mimo obrázky grafů?**  
Podívejte se na část exportu v [API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/)/[dokumentaci](/slides/cs/python-net/convert-powerpoint/) pro cílové formáty výstupu ([PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/python-net/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-net/convert-powerpoint-to-html/), atd.) a související možnosti vykreslování.