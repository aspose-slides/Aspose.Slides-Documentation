---
title: Grafik
type: docs
weight: 60
url: /tr/nodejs-java/examples/elements/chart/
keywords:
- kod örneği
- grafik
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile grafiklerde uzmanlaşın: grafik oluşturun, biçimlendirin, veri bağlayın ve PPT, PPTX ve ODP formatlarında grafikleri JavaScript örnekleriyle dışa aktarın."
---
**Aspose.Slides for Node.js via Java** kullanarak farklı grafik türlerini ekleme, erişme, kaldırma ve güncelleme örnekleri. Aşağıdaki kod parçacıkları temel grafik işlemlerini gösterir.

## **Grafik Ekle**

Bu yöntem, ilk slayta basit bir alan grafiği ekler.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk slayta basit bir alan grafiği ekleyin.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiğe Erişme**

Bir grafik oluşturduktan sonra, şekil koleksiyonu üzerinden onu alabilirsiniz.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Slayttaki ilk grafiğe eriş.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Grafik Kaldırma**

Aşağıdaki kod, grafiği slayttan kaldırır.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Grafiği kaldır.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafik Verilerini Güncelleme**

Grafik özelliklerini, örneğin başlığı, değiştirebilirsiniz.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Grafik başlığını değiştir.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```