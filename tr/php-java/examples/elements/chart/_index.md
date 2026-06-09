---
title: Grafik
type: docs
weight: 60
url: /tr/php-java/examples/elements/chart/
keywords:
- grafik
- grafik ekle
- grafiğe eriş
- grafik kaldır
- grafik güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile grafik oluşturun ve özelleştirin: veri ekleyin, serileri, eksenleri ve etiketleri biçimlendirin, türleri değiştirin ve dışa aktarın—PPT, PPTX ve ODP ile çalışır."
---
Farklı grafik türlerini ekleme, erişme, kaldırma ve güncelleme örnekleri **Aspose.Slides for PHP via Java** ile. Aşağıdaki kod parçacıkları temel grafik işlemlerini gösterir.

## **Grafik Ekle**

Bu yöntem, ilk slayta basit bir alan grafiği ekler.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayta basit bir sütun grafiği ekleyin.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Grafiğe Erişim**

Grafiği şekil koleksiyonundan alın.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk grafiğe eriş.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Grafiği Kaldır**

Aşağıdaki kod bir slayttan grafiği kaldırır.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin grafik olduğu varsayılıyor.
        $chart = $slide->getShapes()->get_Item(0);

        // Grafiği kaldır.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Grafik Verilerini Güncelle**

Başlık gibi grafik özelliklerini değiştirebilirsiniz.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin grafik olduğu varsayılıyor.
        $chart = $slide->getShapes()->get_Item(0);

        // Grafik başlığını değiştir.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```