---
title: Настройка пузырьковых диаграмм в презентациях с использованием PHP
linktitle: Пузырьковая диаграмма
type: docs
url: /ru/php-java/bubble-chart/
keywords:
- пузырьковая диаграмма
- размер пузыря
- масштабирование размера
- представление размера
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте мощные пузырьковые диаграммы в PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы легко улучшать визуализацию ваших данных."
---

## **Масштабирование размеров пузырьковой диаграммы**
Aspose.Slides for PHP via Java предоставляет поддержку масштабирования размеров пузырьковой диаграммы. В Aspose.Slides for PHP via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) и [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) добавлены методы. Ниже приведён пример.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Представление данных как размеров пузырьковой диаграммы**
Методы [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) и [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) добавлены в интерфейсы [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) и связанные классы. **BubbleSizeRepresentation** определяет, как значения размеров пузырей представлены на пузырьковой диаграмме. Возможные значения: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) и [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Соответственно, перечисление [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) было добавлено для указания возможных способов представления данных как размеров пузырьковой диаграммы. Ниже приведён пример кода.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Поддерживается ли «пузырьковая диаграмма с 3-D эффектом», и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3-D стилизацию к пузырькам, но не добавляет дополнительную ось; данные остаются X-Y-S (размер). Тип доступен в классе [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

**Есть ли ограничение на количество серий и точек в пузырьковой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и целевой версией PowerPoint. Рекомендуется держать количество точек разумным для читаемости и скорости рендеринга.

**Как экспорт влияет на внешний вид пузырьковой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.