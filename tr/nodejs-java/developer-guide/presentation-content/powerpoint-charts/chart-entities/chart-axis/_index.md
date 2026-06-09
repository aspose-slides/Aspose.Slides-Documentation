---
title: JavaScript Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/nodejs-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Node.js via Java ile JavaScript kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale Aspose.Slides’da grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini alma, eksenler arasındaki veriyi değiştirme, çizgi grafikleri için dikey veya yatay ekseni gizleme, kategori ekseni tipini değiştirme, kategori ekseni değerleri için tarih biçimini ayarlama, eksen başlığını döndürme, eksen konumunu belirleme ve değer ekseninde bir birim etiketi gösterme konularını gösterir.

## **Grafiklerde Dikey Eksenin Maksimum Değerlerini Alma**

Aspose.Slides for Node.js via Java, dikey eksende minimum ve maksimum değerleri elde etmenizi sağlar. Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Eksen üzerindeki gerçek maksimum değeri alın.
1. Eksen üzerindeki gerçek minimum değeri alın.
1. Eksenin gerçek ana birimini alın.
1. Eksenin gerçek yan birimini alın.
1. Eksenin gerçek ana birim ölçeğini alın.
1. Eksenin gerçek yan birim ölçeğini alın.

Bu örnek kod — yukarıdaki adımların bir uygulaması — gerekli değerleri JavaScript’te nasıl alacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Sunumu kaydeder
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eksenler Arasında Veriyi Değiştirme**

Aspose.Slides, eksenler arasındaki veriyi hızlıca değiştirmenizi sağlar — dikey eksende (y-ekseninde) temsil edilen veri yatay eksene (x-eksenine) ve tersine taşınır. 

Bu JavaScript kodu, bir grafikte eksenler arasındaki veri değişimini nasıl yapacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Satır ve sütunları değiştirir
    chart.getChartData().switchRowColumn();
    // Sunumu kaydeder
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Çizgi Grafiklerinde Dikey Eksenin Devre Dışı Bırakılması**

Bu JavaScript kodu, bir çizgi grafiği için dikey ekseni nasıl gizleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Çizgi Grafiklerinde Yatay Eksenin Devre Dışı Bırakılması**

Bu kod, bir çizgi grafiği için yatay ekseni nasıl gizleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kategori Eksenini Değiştirme**

**CategoryAxisType** özelliğini kullanarak tercih ettiğiniz kategori ekseni tipini (**date** veya **text**) belirtebilirsiniz. Bu JavaScript kodu işlemi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kategori Eksen Değeri İçin Tarih Biçimini Ayarlama**

Aspose.Slides for Node.js via Java, bir kategori ekseni değeri için tarih biçimini ayarlamanıza olanak tanır. İşlem bu JavaScript kodunda gösterilmektedir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Grafik Eksen Başlığı İçin Döndürme Açısını Ayarlama**

Aspose.Slides for Node.js via Java, bir grafik eksen başlığı için döndürme açısını ayarlamanızı sağlar. Bu JavaScript kodu işlemi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kategori veya Değer Ekseni İçinde Pozisyon Eksenini Ayarlama**

Aspose.Slides for Node.js via Java, bir kategori veya değer ekseninde pozisyon eksenini ayarlamanıza izin verir. Bu JavaScript kodu görevi nasıl yapacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafik Değer Ekseninde Görüntü Birimi Etiketini Etkinleştirme**

Aspose.Slides for Node.js via Java, bir grafiğin değer ekseninde bir birim etiketi göstermesini yapılandırmanızı sağlar. Bu JavaScript kodu işlemi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bir eksenin diğerini kestiği değeri (eks kesişimi) nasıl ayarlarım?**

Eksenler bir [crossing setting](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/axis/setcrosstype/) sunar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X-eksenini yukarı ya da aşağı kaydırmak veya bir temel çizgiyi vurgulamak için kullanışlıdır.

**Kiriç etiketlerini eksene göre (yanında, dışarıda, içinde) nasıl konumlandırabilirim?**

[Label position](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/axis/setmajortickmark/) değerini "cross", "outside" veya "inside" olarak ayarlayın. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.