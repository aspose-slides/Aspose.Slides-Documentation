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
description: "Узнайте, как настраивать области построения диаграмм в презентациях PowerPoint с Aspose.Slides для PHP через Java. Улучшайте визуализацию слайдов без усилий."
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides для PHP через Java предоставляет простой API для .  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите первый слайд.
3. Добавьте диаграмму с данными по умолчанию.
4. Вызовите метод [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) перед получением фактических значений.
5. Получает фактическое положение по оси X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
6. Получает фактическую позицию сверху элемента диаграммы относительно левого верхнего угла диаграммы.
7. Получает фактическую ширину элемента диаграммы.
8. Получает фактическую высоту элемента диаграммы.
```php
  # Создать экземпляр класса Presentation
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
Aspose.Slides для PHP через Java предоставляет простой API для установки режима компоновки области построения диаграммы. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea). Если компоновка области построения определена вручную, это свойство указывает, следует ли размещать область построения по её внутренней части (не включая оси и подписи осей) или по внешней части (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) — указывает, что размер области построения определяет размер области построения без учёта делений и подписей осей.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) — указывает, что размер области построения определяет размер области построения, включая деления и подписи осей.

Пример кода приведён ниже.
```php
  # Создать экземпляр класса Presentation
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

**В каких единицах возвращаются фактические x, фактические y, фактическая ширина и фактическая высота?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем область построения отличается от области диаграммы по содержимому?**

Область построения — это область отрисовки данных (серии, линии сетки, трендовые линии и т.п.); область диаграммы включает окружающие элементы (заголовок, легенду и т.п.). В 3‑D диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются x, y, ширина и высота области построения при ручной компоновке?**

Это дробные значения (0–1) от общего размера диаграммы; в этом режиме автоматическое позиционирование отключено, и используются заданные вами дроби.

**Почему положение области построения изменилось после добавления/перемещения легенды?**

Легенда размещается в области диаграммы за пределами области построения, но влияет на компоновку и доступное пространство, поэтому область построения может смещаться, когда включено автоматическое позиционирование. (Это стандартное поведение диаграмм PowerPoint.)