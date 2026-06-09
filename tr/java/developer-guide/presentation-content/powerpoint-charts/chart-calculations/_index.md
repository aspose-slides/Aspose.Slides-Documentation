---
title: Java'da Sunumlar İçin Grafik Hesaplamalarını Optimize Et
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/java/chart-calculations/
keywords:
- grafik hesaplamaları
- grafik öğeleri
- öğe konumu
- gerçek konum
- alt öğe
- üst öğe
- grafik değerleri
- gerçek değer
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da PPT ve PPTX için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü, pratik Java kod örnekleriyle anlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve düzen verileriyle çalışmak için API'ler sağlar. Bu makale, `IActualLayout` uygulayan öğelerin gerçek konum ve boyutları ile grafik eksenlerinin gerçek değerleri dahil olmak üzere grafik öğelerinin gerçek değerlerini nasıl alacağınızı gösterir. Ayrıca bu değerlerin grafik düzeni doğrulamasından sonra doldurulduğunu açıklar.

Ayrıca, makale ebeveyn grafik öğelerinin gerçek konumunu nasıl alacağınızı ve başlık, eksenler, gösterge ve ızgara çizgileri gibi grafik bileşenlerini nasıl gizleyeceğinizi gösterir. Bu örnekler birlikte, grafik düzen bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesaplama**

Aspose.Slides for Java, bu özellikleri almak için basit bir API sağlar. [IAxis](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis) arabiriminin özellikleri, eksen grafik öğesinin gerçek konumu hakkında bilgi verir ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis#getActualMaxValue--),[IAxis.getActualMinValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis#getActualMinValue--),[IAxis.getActualMajorUnit](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis#getActualMajorUnit--),[IAxis.getActualMinorUnit](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis#getActualMinorUnit--),[IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis#getActualMajorUnitScale--),[IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Gerçek değerlerle özellikleri doldurmak için önce [IChart.validateChartLayout()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChart#validateChartLayout--) yönteminin çağrılması gerekir.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ebeveyn Grafik Öğelerinin Gerçek Konumunu Hesaplama**

Aspose.Slides for Java, bu özellikleri almak için basit bir API sağlar. [IActualLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IActualLayout) arabiriminin özellikleri, ebeveyn grafik öğesinin gerçek konumu hakkında bilgi verir ([IActualLayout.getActualX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IActualLayout#getActualX--),[IActualLayout.getActualY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IActualLayout#getActualY--),[IActualLayout.getActualWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IActualLayout#getActualWidth--),[IActualLayout.getActualHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IActualLayout#getActualHeight--)). Gerçek değerlerle özellikleri doldurmak için önce [IChart.validateChartLayout()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChart#validateChartLayout--) yönteminin çağrılması gerekir.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafik Öğelerini Gizle**

Bu konu, grafikten bilgiyi nasıl gizleyeceğinizi anlamanıza yardımcı olur. Aspose.Slides for Java kullanarak grafikten **Başlık, Dikey Eksen, Yatay Eksen** ve **Izgara Çizgileri** gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Grafik Başlığını Gizleme
    chart.setTitle(false);

    ///Değer eksenini gizleme
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Kategori Eksen Görünürlüğü
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Göstergeyi Gizleme
    chart.setLegend(false);

    //Ana Izgara Çizgilerini Gizleme
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Seri satır rengini ayarlama
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Harici Excel çalışma kitapları veri kaynağı olarak çalışır mı ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik harici bir çalışma kitabına referans verebilir: harici kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açma/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, [harici çalışma kitabını belirt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) yolunu ve bağlantılı verileri yönetmenizi sağlar.

**Regresyonu kendim uygulamadan eğri çizgilerini (trendline) hesaplayıp görüntüleyebilir miyim?**

Evet. [Trendlines](/slides/tr/java/trend-line/) (lineer, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri seri verilerinden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı uygulamanıza gerek yoktur.

**Bir sunumda birden fazla harici bağlantılı grafik varsa, her grafiğin hesaplanan değerler için hangi çalışma kitabını kullandığını kontrol edebilir miyim?**

Evet. Her grafik kendi [harici çalışma kitabına](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) işaret edebilir veya diğerlerinden bağımsız olarak grafik başına bir harici çalışma kitabı oluşturup/yerine koyabilirsiniz.