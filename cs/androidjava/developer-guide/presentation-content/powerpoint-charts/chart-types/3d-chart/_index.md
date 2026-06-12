---
title: Přizpůsobení 3D grafů v prezentacích na Androidu
linktitle: 3D graf
type: docs
url: /cs/androidjava/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak vytvářet a přizpůsobovat 3D grafy v Aspose.Slides pro Android pomocí Javy, s podporou souborů PPT a PPTX — vylepšete své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides konfigurací nastavení `Rotation3D`, jako jsou `RotationX`, `RotationY`, `DepthPercents` a `RightAngleAxes`. Popisuje vytvoření prezentace, přidání 3D grafu s výchozími daty, aplikaci požadovaných nastavení 3D zobrazení a uložení upravené prezentace jako soubor PPTX.

## **Nastavení vlastností RotationX, RotationY a DepthPercents 3D grafu**

Aspose.Slides for Android via Java poskytuje jednoduché API pro nastavení těchto vlastností. Následující článek vám pomůže nastavit různé vlastnosti, jako jsou **X, Y rotace, DepthPercents** a další. V ukázkovém kódu jsou nastaveny výše zmíněné vlastnosti.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte vlastnosti Rotation3D.
5. Uložte upravenou prezentaci do souboru PPTX.

```java
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidání grafu s výchozími daty
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Nastavení indexu listu s daty grafu
    int defaultWorksheetIndex = 0;
    
    // Získání listu s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Přidání řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Přidání kategorií
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Nastavení vlastností Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Získání druhé řady grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Nyní plníme data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Nastavení hodnoty Overlap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Uložení prezentace na disk
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s dalšími souvisejícími 3D typy dostupnými prostřednictvím třídy [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/) v referenční dokumentaci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf jako obrázek pomocí [chart API](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) nebo [render the entire slide](/slides/cs/androidjava/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete pixelově přesný náhled nebo chcete vložit graf do dokumentů, panelů nebo webových stránek bez potřeby PowerPointu.

**Jaký je výkon při vytváření a renderování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro dosažení nejlepších výsledků udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do výstupu s vhodnými rozměry (rozlišení a velikost), aby odpovídal cílovému displeji nebo tiskovým požadavkům.