---
title: Настройка таблиц данных диаграмм в презентациях с использованием PHP
linktitle: Таблица данных
type: docs
url: /ru/php-java/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Настройте таблицы данных диаграмм для PPT и PPTX с помощью Aspose.Slides для PHP через Java, чтобы повысить эффективность и привлекательность презентаций."
---

## **Установить свойства шрифта для таблицы данных диаграммы**
Aspose.Slides для PHP через Java предоставляет поддержку изменения цвета категорий в серии.  

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
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


## **Часто задаваемые вопросы**

**Могу ли я отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [ключи легенды](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/), и их можно включать или отключать.

**Будет ли таблица данных сохранена при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides выводит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/php-java/convert-powerpoint-to-html/)/[image](/slides/ru/php-java/convert-powerpoint-to-png/) содержит диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из файла шаблона?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, [отображается ли таблица данных](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/), используя свойства диаграммы.

**Как быстро найти, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, которое указывает, [отображается ли таблица данных](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/), и пройдитесь по слайдам, чтобы определить диаграммы, у которых она включена.