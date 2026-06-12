---
title: Správa značek dat grafu v prezentacích pomocí Javy
linktitle: Datová značka
type: docs
url: /cs/java/chart-data-marker/
keywords:
- graf
- datový bod
- značka
- možnosti značky
- velikost značky
- typ výplně
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak přizpůsobit datové značky grafu v Aspose.Slides pro Javu a zvýšit účinek prezentací v formátech PPT a PPTX pomocí přehledných ukázek kódu v Jave."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s datovými značkami grafu v Aspose.Slides. Ukazuje, jak vytvořit graf, získat přístup k sérii a jejím datovým bodům, aplikovat výplně obrázkem na značky na úrovni datového bodu, upravit velikost značky a uložit aktualizovanou prezentaci. Také uvádí, že standardní tvary značek jsou k dispozici prostřednictvím výčtu `MarkerStyleType` a že vzhled značky je zachován při exportu grafů do rastrových formátů nebo SVG.

## **Nastavení možností značek grafu**
Značky lze nastavit na datových bodech grafu v konkrétních sériích. Pro nastavení možností značek grafu postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Nastavte obrázek.
- Získejte první sérii grafu.
- Přidejte nový datový bod.
- Uložte prezentaci na disk.

V příkladu uvedeném níže jsme nastavili možnosti značek grafu na úrovni datových bodů.

```java
// Vytvoření prázdné prezentace
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Vytvoření výchozího grafu
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Získání indexu výchozího listu dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získání listu dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstranění demonstrační série
    chart.getChartData().getSeries().clear();
    
    // Přidání nové série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Načtení obrázku 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Načtení obrázku 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Získání první série grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Přidání nového bodu (1:3) tam.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Změna značky série grafu
    series.getMarker().setSize(15);
    
    // Uložení prezentace s grafem
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jaké tvary značek jsou k dispozici přímo z krabice?**

Standardní tvary jsou k dispozici (kružnice, čtverec, diamant, trojúhelník atd.); seznam je definován třídou [MarkerStyleType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte značku s výplní obrázkem k napodobení vlastních vizuálů.

**Zůstávají značky zachovány při exportu grafu do obrázku nebo SVG?**

Ano. Při vykreslování grafů do [rasterových formátů](/slides/cs/java/convert-powerpoint-to-png/) nebo ukládání [tvarů jako SVG](/slides/cs/java/render-a-slide-as-an-svg-image/), značky si zachovávají svůj vzhled a nastavení, včetně velikosti, výplně i obrysu.