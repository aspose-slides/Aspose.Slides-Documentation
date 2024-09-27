---
title: Doughnut Chart
type: docs
weight: 30
url: /ru/androidjava/doughnut-chart/
---

## **Изменение размера центра в Doughnut Chart**
{{% alert color="primary" %}} 

Aspose.Slides для Android через Java теперь поддерживает указание размера отверстия в круговой диаграмме. В этой теме мы рассмотрим на примере, как указать размер отверстия в круговой диаграмме.

{{% /alert %}} 

Чтобы указать размер отверстия в круговой диаграмме, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Добавьте круговую диаграмму на слайд.
1. Укажите размер отверстия в круговой диаграмме.
1. Запишите презентацию на диск.

В приведенном ниже примере мы задали размер отверстия в круговой диаграмме.

```java
// Создаем экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Записываем презентацию на диск
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```