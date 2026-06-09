---
title: JavaScript'te Sunumlar İçin Grafik Hesaplamalarını Optimize Edin
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/nodejs-java/chart-calculations/
keywords:
- grafik hesaplamaları
- grafik öğeleri
- öğe konumu
- gerçek konum
- çocuk öğe
- üst öğe
- grafik değerleri
- gerçek değer
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te PPT ve PPTX için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü, pratik JavaScript kod örnekleriyle anlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve yerleşim verileriyle çalışmak için API'ler sağlar. Bu makale, öğelerin gerçek konum ve boyutları ile grafik eksenlerinin gerçek değerleri dahil olmak üzere, grafik öğelerinin gerçek değerlerini nasıl alacağınızı gösterir. Ayrıca bu değerlerin grafik yerleşimi doğrulamasından sonra doldurulduğunu açıklar.

Ayrıca, makale üst grafik öğelerinin gerçek konumunu almayı ve başlık, eksenler, açıklama ve ızgara çizgileri gibi grafik bileşenlerini nasıl gizleyeceğinizi gösterir. Birlikte, bu örnekler grafik yerleşim bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesaplama**

Aspose.Slides for Node.js via Java, bu özellikleri almak için basit bir API sağlar. [Axis](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis) sınıfının özellikleri, eksen grafik öğesinin gerçek konumu hakkında bilgi verir ([Axis.getActualMaxValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Özelliklerin gerçek değerlerle doldurulması için daha önce [Chart.validateChartLayout()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#validateChartLayout--) yönteminin çağrılması gerekir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Üst Grafik Öğelerinin Gerçek Konumunu Hesaplama**

Aspose.Slides for Node.js via Java, bu özellikleri almak için basit bir API sağlar. `ActualLayout` sınıfının özellikleri, üst grafik öğesinin gerçek konumu hakkında bilgi verir `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Özelliklerin gerçek değerlerle doldurulması için daha önce [Chart.validateChartLayout()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#validateChartLayout--) yönteminin çağrılması gerekir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafikten Bilgi Gizleme**

Bu konu, grafik üzerindeki bilgileri nasıl gizleyeceğinizi anlamanıza yardımcı olur. Aspose.Slides for Node.js via Java kullanarak grafikten **Başlık, Dikey Eksen, Yatay Eksen** ve **Izgara Çizgileri** gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Grafik Başlığını Gizleme
    chart.setTitle(false);
    // /Değer eksenini gizleme
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Kategori ekseninin görünürlüğü
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Legendi gizleme
    chart.setLegend(false);
    // Ana ızgara çizgilerini gizleme
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Seri çizgi rengini ayarlama
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Harici Excel çalışma kitapları veri kaynağı olarak çalışıyor mu ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik harici bir çalışma kitabına referans verebilir: harici kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açma/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, harici çalışma kitabının yolunu [harici çalışma kitabını belirleyin](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) belirtmenize ve bağlanan verileri yönetmenize olanak tanır.

**Regresyonu kendim uygulamadan eğri çizgileri hesaplayıp görüntüleyebilir miyim?**

Evet. [Trendlines](/slides/tr/nodejs-java/trend-line/) (doğrusal, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri seriler verisinden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı uygulamanıza gerek kalmaz.

**Bir sunumda birden fazla grafik harici bağlantılara sahipse, her bir grafiğin hangi çalışma kitabını kullandığını kontrol edebilir miyim?**

Evet. Her bir grafik, kendi [harici çalışma kitabına](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) işaret edebilir veya her grafik için diğerlerinden bağımsız olarak bir harici çalışma kitabı oluşturabilir/değiştirebilirsiniz.