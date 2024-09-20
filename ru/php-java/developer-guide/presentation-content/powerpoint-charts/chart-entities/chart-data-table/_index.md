---
title: Таблица данных диаграммы
type: docs
url: /php-java/chart-data-table/
---

## **Установка свойств шрифта для таблицы данных диаграммы**
Aspose.Slides для PHP через Java предоставляет поддержку изменения цвета категорий в цвете серии.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Установите таблицу диаграммы.
1. Установите высоту шрифта.
1. Сохраните изменённую презентацию.

 Ниже приведён пример.

```php
  # Создание пустой презентации
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```