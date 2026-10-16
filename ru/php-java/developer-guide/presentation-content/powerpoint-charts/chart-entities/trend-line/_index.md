---
title: Добавление линий тренда к диаграммам презентаций в PHP
linktitle: Линия тренда
type: docs
url: /ru/php-java/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- скользящее среднее линия тренда
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для PHP через Java — практическое руководство для вовлечения вашей аудитории."
---
## **Обзор**

Эта статья объясняет, как добавить линии тренда к диаграммам в презентациях с помощью Aspose.Slides. В ней показано, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальную, линейную, логарифмическую, скользящее среднее, полиномиальную и степенную.

Также описывается, как добавить пользовательскую линию к диаграмме, вставив форму линии, и включён краткий FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в виде изображений.

## **Добавить линию тренда**

Используйте [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) для добавления линии тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию и добавляет по две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R-квадрат с помощью [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) и [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), тогда как линейная линия тренда отображается красным цветом. Логарифмическая линия тренда использует [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) для пользовательской подписи. Скользящее среднее использует [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) из трёх точек данных и пользовательское [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

Полиномиальная линия тренда имеет порядок три, задаётся через [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), и расширяется на одну категорию вперёд через [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Степенная линия тренда расширяется на одну категорию назад через [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить пересечение линии тренда**

Используйте [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) для фиксации значения Y линии тренда при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начала с известных фиксированных затрат в 100, даже если измерения при ненулевых объёмах производства указывают иную базовую линию. Для линейной линии тренда фиксация пересечения ограничивает уравнение `y = ax + b` значением `b = 100`; наклон подгоняется к данным при этом ограничении. Это не просто перемещение уже построенной линии. Настройки пересечения осей управляют точкой соприкосновения осей диаграммы, а не коэффициентами подгоняемой линии тренда.

Следующий пример создаёт точечную (XY) диаграмму с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Он сохраняет диаграмму с автоматическим пересечением по умолчанию, задаёт пересечение = 100 и сохраняет второй PPTX. Оба файла различаются только настройкой пересечения. Линия тренда отображает своё уравнение и расширяется назад до X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

При автоматическом вычислении эти данные дают `y = 30x + 140`. Установка пересечения в 100 вместо этого даёт примерно `y = 43.33x + 100`: значение при нуле совпадает с известной базой, однако линия больше не проходит через каждую точку данных.

| Автоматическое пересечение | Фиксированное пересечение 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически вычисленным пересечением 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным пересечением 100](intercept-fixed.png) |

Оба изображения используют одни и те же данные и шкалы осей. Линии тренда расширены назад до X = 0, чтобы показать их пересечения.

По умолчанию [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) возвращает `NaN`, что обозначает неопределённое пересечение, а не ноль. Затем пересечение вычисляется автоматически из данных.

## **Добавить пользовательскую линию**

Пользовательская линия — это форма, нарисованная поверх диаграммы, а не линия тренда, вычисленная из данных серии. Этот пример использует [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) для добавления горизонтальной линии на слайд над диаграммой. Позиция линии задаётся в координатах слайда, измеряемых в пунктах, поэтому она начинается у левого края диаграммы и находится на полпути вниз по диаграмме. Её ширина совпадает с шириной диаграммы. Метод [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) задаёт линии сплошной красный цвет.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**Что означают ‘forward’ и ‘backward’ для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для остальных диаграмм — в количестве категорий. Допускаются только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, а также при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/php-java/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются при этих операциях. Также доступен метод для [export an image of the chart](/slides/ru/php-java/create-shape-thumbnails/) itself.