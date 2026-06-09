---
title: Grafik
type: docs
weight: 60
url: /tr/androidjava/examples/elements/chart/
keywords:
- kod örneği
- grafik
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile grafiklerde uzmanlaşın: grafik oluşturma, biçimlendirme, veri bağlama ve PPT, PPTX ve ODP formatlarında grafikleri dışa aktarma, Java örnekleriyle."
---
**Aspose.Slides for Android via Java** ile farklı grafik türlerini ekleme, erişme, kaldırma ve güncelleme örnekleri. Aşağıdaki kod parçacıkları temel grafik işlemlerini gösterir.

## **Grafik Ekle**

Bu yöntem, ilk slayta basit bir alan grafiği ekler.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // İlk slayta basit bir alan grafiği ekleyin.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiğe Eriş**

Bir grafik oluşturduktan sonra, şekil koleksiyonu aracılığıyla onu alabilirsiniz.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Slayttaki ilk grafiğe erişin.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiği Kaldır**

Aşağıdaki kod, bir slayttan grafiği kaldırır.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Grafiği kaldır.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafik Verilerini Güncelle**

Grafik başlığı gibi özelliklerini değiştirebilirsiniz.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Grafik başlığını değiştir.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```