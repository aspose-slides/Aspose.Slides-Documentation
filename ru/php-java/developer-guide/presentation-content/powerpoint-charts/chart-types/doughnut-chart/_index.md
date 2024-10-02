---
title: Круговая диаграмма
type: docs
weight: 30
url: /ru/php-java/doughnut-chart/
---

## **Изменение центрального зазора в круговой диаграмме**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java теперь поддерживает указание размера отверстия в круговой диаграмме. В этой теме мы рассмотрим на примере, как указать размер отверстия в круговой диаграмме.

{{% /alert %}} 

Чтобы указать размер отверстия в круговой диаграмме, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Добавьте круговую диаграмму на слайд.
1. Укажите размер отверстия в круговой диаграмме.
1. Запишите презентацию на диск.

В приведенном ниже примере мы установили размер отверстия в круговой диаграмме.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Запишите презентацию на диск
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```