---
title: Přizpůsobení 3D grafů v prezentacích pomocí JavaScriptu
linktitle: 3D graf
type: docs
url: /cs/nodejs-java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak vytvářet a přizpůsobovat 3D grafy v Aspose.Slides pro Node.js prostřednictvím Javy, s podporou souborů PPT a PPTX - vylepšete své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides nastavením parametrů `Rotation3D`, jako jsou `RotationX`, `RotationY`, `DepthPercents` a `RightAngleAxes`. Popisuje vytvoření prezentace, přidání 3D grafu s výchozími daty, aplikaci požadovaných nastavení 3D zobrazení a uložení upravené prezentace jako soubor PPTX.

## **Nastavení vlastností RotationX, RotationY a DepthPercents 3D grafu**

Aspose.Slides pro Node.js prostřednictvím Javy poskytuje jednoduché API pro nastavení těchto vlastností. Tento následující článek vám pomůže, jak nastavit různé vlastnosti, jako **X, Y Rotation, DepthPercents** atd. Vzorek kódu aplikuje nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) .
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte vlastnosti Rotation3D.
5. Uložte upravenou prezentaci do souboru PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přístup k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Přidání grafu s výchozími daty
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Nastavení indexu listu s daty grafu
    var defaultWorksheetIndex = 0;
    // Získání listu s daty grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Přidání řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Přidání kategorií
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Nastavení vlastností Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Získání druhé řady grafu
    var series = chart.getChartData().getSeries().get_Item(1);
    // Nyní se naplňují data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Nastavení hodnoty OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // Uložení prezentace na disk
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s příslušnými 3D typy zpřístupněnými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/). Pro aktuální úplný seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/) v referenční dokumentaci API verze, kterou máte nainstalovanou.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf do obrázku pomocí [chart API](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage) nebo [vyrenderovat celý snímek](/slides/cs/nodejs-java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete pixelově přesný náhled nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do výstupu odpovídající velikosti (rozlišení a rozměry), aby vyhovoval cílovému zobrazovacímu zařízení nebo tisku.