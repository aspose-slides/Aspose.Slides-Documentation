---
title: Android Sunumlarında Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/androidjava/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri kesinliği
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint sunumlarına Aspose.Slides for Android via Java kullanarak grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, böylece daha etkileyici slaytlar oluşturabilirsiniz."
---
## **Giriş**

Grafikteki veri etiketleri, grafik veri serileri veya tek tek veri noktaları hakkında ayrıntılar gösterir. Okuyucuların veri serilerini hızla tanımlamasını sağlar ve grafiklerin daha kolay anlaşılmasını sağlar.

## **Grafik Veri Etiketlerinde Veri Kesinliğini Ayarlama**

Bu Java kodu, bir grafik veri etiketinde veri kesinliğini nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yüzdeleri Etiket Olarak Görüntüleme**

Aspose.Slides for Android Java aracılığıyla, görüntülenen grafiklerde yüzde etiketleri ayarlamanızı sağlar. Bu Java kodu işlemi gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Grafiği içeren sunumu kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarlama**

Bu Java kodu, bir grafik veri etiketi için yüzde işaretini nasıl ayarlayacağınızı gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // İndeks aracılığıyla slayt referansını alır
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Bir slaytta PercentsStackedColumn grafiğini oluşturur
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // NumberFormatLinkedToSource özelliğini false olarak ayarlar
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Grafik veri çalışma sayfasını alır
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Yeni seri ekler
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Serinin dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // LabelFormat özelliklerini ayarlar
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Yeni seri ekler
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Dolgu tipini ve rengini ayarlar
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Sunumu diske yazar
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Eksenden Etiket Mesafesini Ayarlama**

Bu Java kodu, eksenlerden çizilmiş bir grafik ile çalışırken kategori ekseninden etiket mesafesini nasıl ayarlayacağınızı gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // Bir slaytın referansını alır
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Slayta bir grafik oluşturur
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Bir eksenden etiket mesafesini ayarlar
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Sunumu diske yazar
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Etiket Konumunu Ayarlama**

Eksenlere dayanmayan bir grafik (örneğin bir pasta grafiği) oluşturduğunuzda, grafiğin veri etiketleri kenarına çok yakın olabilir. Bu gibi durumlarda, veri etiketinin konumunu ayarlamanız gerekir ki kılavuz çizgileri net bir şekilde görüntülensin.

Bu Java kodu, bir pasta grafiğinde etiket konumunu nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**

Otomatik etiket yerleştirme, kılavuz çizgileri ve küçültülmüş yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategoriyi) gizleyin veya yalnızca uç/ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için görüntülemeyi kapatın.

**PDF/görüntülere dışa aktarırken tutarlı bir etiket stilini nasıl garanti edebilirim?**

Yazı tiplerini (aile, boyut) açıkça ayarlayın ve geri dönüşü önlemek için render tarafında yazı tipinin mevcut olduğunu doğrulayın.