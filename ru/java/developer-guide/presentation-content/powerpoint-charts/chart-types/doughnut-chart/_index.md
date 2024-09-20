---
title: Донатный график
type: docs
weight: 30
url: /java/doughnut-chart/
---

## **Изменение размера центра в донатном графике**
{{% alert color="primary" %}} 

Aspose.Slides для Java теперь поддерживает указание размера отверстия в донатном графике. В этой теме мы рассмотрим на примере, как указать размер отверстия в донатном графике.

{{% /alert %}} 

Чтобы указать размер отверстия в донатном графике, пожалуйста, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Добавьте донатный график на слайд.
1. Укажите размер отверстия в донатном графике.
1. Сохраните презентацию на диск.

В приведенном ниже примере мы установили размер отверстия в донатном графике.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Сохраните презентацию на диск
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```