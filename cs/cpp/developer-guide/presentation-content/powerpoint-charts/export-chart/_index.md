---
title: Exportovat grafy prezentace v C++
linktitle: Export grafu
type: docs
weight: 90
url: /cs/cpp/export-chart/
keywords:
- graf
- graf na obrázek
- graf jako obrázek
- extrahovat obrázek grafu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak exportovat grafy z prezentace pomocí Aspose.Slides pro C++, podporující formáty PPT a PPTX, a zefektivněte reportování v jakémkoli pracovním postupu."
---
## **Přehled**

Aspose.Slides vám umožňuje exportovat graf z prezentace jako obrázek. Tento článek ukazuje, jak získat obrázek z grafu a uložit jej, což je užitečné, pokud potřebujete znovu použít vizuály grafu mimo prezentaci PowerPoint.

## **Získání obrázku grafu**
Aspose.Slides pro C++ poskytuje podporu pro extrahování obrázku konkrétního grafu. Níže je uveden ukázkový příklad.  

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Často kladené dotazy**

**Mohu exportovat graf jako vektor (SVG) místo rastrového obrázku?**

Ano. Graf je tvar a jeho obsah lze uložit do SVG pomocí [metody ukládání shape-to-SVG](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/).

**Jak mohu nastavit přesnou velikost exportovaného grafu v pixelech?**

Použijte přetížení pro vykreslování obrázku, která umožňují zadat velikost nebo měřítko – knihovna podporuje vykreslování objektů s danými rozměry/měřítkem.

**Co mám dělat, pokud písma v popiscích a legendě vypadají po exportu špatně?**

[Načtěte požadovaná písma](/slides/cs/cpp/custom-font/) pomocí [FontsLoader](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/), aby vykreslování grafu zachovalo metriky a vzhled textu.

**Respektuje export téma PowerPointu, styly a efekty?**

Ano. Vykreslovací engine Aspose.Slides dodržuje formátování prezentace (témata, styly, výplně, efekty), takže vzhled grafu je zachován.

**Kde mohu najít dostupné možnosti vykreslování/exportu mimo obrázky grafů?**

Viz sekce exportu v [API](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/)/[dokumentaci](/slides/cs/cpp/convert-powerpoint/) pro výstupní cíle ([PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/), [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), atd.) a související možnosti vykreslování.