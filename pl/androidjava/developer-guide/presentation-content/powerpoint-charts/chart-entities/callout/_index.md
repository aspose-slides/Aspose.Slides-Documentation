---
title: Zarządzanie odwołaniami w wykresach prezentacji na Androidzie
linktitle: Odwołanie
type: docs
url: /pl/androidjava/callout/
keywords:
- odwołanie wykresu
- użycie odwołania
- etykieta danych
- format etykiety
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz i stylizuj odwołania w Aspose.Slides dla Androida przy użyciu zwięzłych przykładów kodu w języku Java, kompatybilnych z formatami PPT i PPTX, aby zautomatyzować przepływy pracy prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z odwołaniami dla etykiet danych wykresu w Aspose.Slides. Pokazuje, jak używać metody `setShowLabelAsDataCallout`, aby wyświetlać etykiety jako odwołania, jak konfigurować ustawienia etykiet związane z odwołaniami dla wykresu pierścieniowego oraz zauważa, że odwołania i ich wygląd są zachowywane przy eksportowaniu prezentacji do formatów PDF, HTML5, SVG i obrazów rastrowych.

## **Używanie odwołań**
Do klasy [DataLabelFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/datalabelformat) i interfejsu [IDataLabelFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idatalabelformat) dodano nowe metody [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) oraz [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-). Metody te określają, czy etykieta danych określonego wykresu będzie wyświetlana jako odwołanie danych, czy jako etykieta danych.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw odwołanie dla wykresu pierścieniowego**
Aspose.Slides dla Androida przy użyciu Javy zapewnia obsługę ustawiania kształtu odwołania etykiety danych serii dla wykresu pierścieniowego. Poniżej podano przykładowy kod.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy odwołania są zachowywane przy konwertowaniu prezentacji do formatu PDF, HTML5, SVG lub obrazów?**

Tak. Odwołania są częścią renderowania wykresu, więc przy eksporcie do [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/pl/androidjava/export-to-html5/), [SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/) lub [obrazów rastrowych](/slides/pl/androidjava/convert-powerpoint-to-png/) są zachowywane razem z formatowaniem slajdu.

**Czy niestandardowe czcionki działają w odwołaniach i czy ich wygląd może być zachowany przy eksporcie?**

Tak. Aspose.Slides obsługuje [osadzanie czcionek](/slides/pl/androidjava/embedded-font/) w prezentacji i kontroluje osadzanie czcionek podczas eksportu, takiego jak [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), zapewniając, że odwołania wyglądają tak samo na różnych systemach.