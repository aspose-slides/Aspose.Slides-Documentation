---
title: Настройка областей построения диаграмм презентаций в PHP
linktitle: Область построения
type: docs
url: /ru/php-java/chart-plot-area/
keywords:
- диаграмма
- область построения
- ширина области построения
- высота области построения
- размер области построения
- режим компоновки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как настраивать области построения диаграмм в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Улучшайте визуальное оформление слайдов без усилий."
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для .  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) перед получением фактических значений.
1. Получите фактическую координату X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получите фактическую координату Y (верх) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получите фактическую ширину элемента диаграммы.
1. Получите фактическую высоту элемента диаграммы.
```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить режим компоновки области построения диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для установки режима компоновки области построения диаграммы. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) были добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) и интерфейс [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). Если компоновка области построения задаётся вручную, это свойство определяет, следует ли компоновать область построения по её внутренней части (без осей и подписей осей) или внешней части (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) — указывает, что размер области построения определяется самой областью построения, без учета отметок и подписей осей.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) — указывает, что размер области построения определяется областью построения, отметками и подписями осей.

Пример кода приведён ниже.
```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**В каких единицах измерения возвращаются фактические x, y, ширина и высота?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем область построения отличается от области диаграммы по содержимому?**

Область построения — это область отображения данных (серии, сетка, линии тренда и пр.); область диаграммы включает окружающие элементы (заголовок, легенду и пр.). В 3‑D диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются x, y, ширина и высота области построения при ручной компоновке?**

Это дробные значения (0–1) от общего размера диаграммы; в этом режиме авто‑позиционирование отключено, и используются установленные вами дроби.

**Почему координаты области построения изменились после добавления/перемещения легенды?**

Легенда располагается в области диаграммы вне области построения, но влияет на компоновку и доступное пространство, поэтому при включённом авто‑позиционировании область построения может сместиться. Это стандартное поведение диаграмм PowerPoint.