---
title: Správa značek dat grafu v prezentacích pomocí JavaScriptu
linktitle: Značka dat
type: docs
url: /cs/nodejs-java/chart-data-marker/
keywords:
- graf
- datový bod
- značka
- možnosti značky
- velikost značky
- typ výplně
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se přizpůsobit značky dat grafu v Aspose.Slides pro Node.js a zvýšit účinek prezentací v formátech PPT a PPTX pomocí srozumitelných příkladů kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s datovými značkami v grafech v Aspose.Slides. Ukazuje, jak vytvořit graf, získat přístup k sérii a jejím datovým bodům, aplikovat obrázkové výplně na značky na úrovni datových bodů, upravit velikost značky a uložit aktualizovanou prezentaci. Také uvádí, že standardní tvary značek jsou k dispozici prostřednictvím výčtu `MarkerStyleType` a že vzhled značky je zachován při exportu grafů do rastrových formátů nebo SVG.

## **Nastavení možností značek grafu**

Značky lze nastavit na datových bodech grafu v konkrétní sérii. Pro nastavení možností značek grafu postupujte podle následujících kroků:

- Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Nastavte obrázek.
- Získejte první sérii grafu.
- Přidejte nový datový bod.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili možnosti značek grafu na úrovni datových bodů.

```javascript
// Vytvoření prázdné prezentace
var pres = new aspose.slides.Presentation();
try {
    // Přístup k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Vytvoření výchozího grafu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Získání indexu výchozího listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získání listu dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstranění ukázkové série
    chart.getChartData().getSeries().clear();
    // Přidání nové série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Načtení obrázku 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Načtení obrázku 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Získání první série grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Přidání nového bodu (1:3) tam.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Změna značky série grafu
    series.getMarker().setSize(15);
    // Uložení prezentace s grafem
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jaké tvary značek jsou k dispozici přímo?**

Standardní tvary jsou k dispozici (kroužek, čtverec, diamant, trojúhelník atd.); seznam je definován výčtem [MarkerStyleType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte značku s obrázkovou výplní k napodobení vlastního vzhledu.

**Zůstávají značky zachovány při exportu grafu do obrázku nebo SVG?**

Ano. Při vykreslování grafů do [rasterových formátů](/slides/cs/nodejs-java/convert-powerpoint-to-png/) nebo ukládání [tvarů jako SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/) značky zachovávají svůj vzhled a nastavení, včetně velikosti, výplně a obrysu.