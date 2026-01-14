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
description: "Создавайте и настраивайте мощные пузырьковые диаграммы в PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы легко улучшить визуализацию данных."
---

## **Масштабирование размеров пузырьковой диаграммы**
Aspose.Slides for PHP via Java предоставляет поддержку масштабирования размеров пузырьковой диаграммы. В Aspose.Slides for PHP via Java добавлены методы [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) и [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) . Ниже приведён пример. 
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


## **Представление данных в виде размеров пузырьковой диаграммы**
В классы [**ChartSeries**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/), [**ChartSeriesGroup**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) и связанные классы добавлены методы [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) и [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) . **BubbleSizeRepresentation** указывает, как значения размеров пузырей представлены в пузырьковой диаграмме. Возможные значения: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) и [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width) . Соответственно, добавлен перечисление [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) для указания возможных способов представления данных в виде размеров пузырьковой диаграммы. Ниже приведён пример кода. 
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

**Поддерживается ли «пузырьковая диаграмма с 3‑D‑эффектом» и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3‑D‑оформление к пузырям, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Этот тип доступен в классе [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) .  

**Есть ли ограничение на количество рядов и точек в пузырьковой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и версией целевого PowerPoint. Рекомендуется держать количество точек в разумных пределах для читаемости и скорости отрисовки.  

**Как экспорт влияет на внешний вид пузырьковой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.