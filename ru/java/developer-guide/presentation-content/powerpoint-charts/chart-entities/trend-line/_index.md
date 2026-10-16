---
title: Добавление тренд‑линий к диаграммам презентаций в Java
linktitle: Тренд‑линия
type: docs
url: /ru/java/trend-line/
keywords:
- диаграмма
- тренд‑линия
- экспоненциальная тренд‑линия
- линейная тренд‑линия
- логарифмическая тренд‑линия
- тренд‑линия скользящего среднего
- полиномиальная тренд‑линия
- степенная тренд‑линия
- пользовательская тренд‑линия
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Быстро добавляйте и настраивайте тренд‑линии в диаграммах PowerPoint с помощью Aspose.Slides для Java — практическое руководство по увлечению вашей аудитории."
---
## **Обзор**

В этой статье объясняется, как добавить тренд‑линии к диаграммам презентации с помощью Aspose.Slides. Показано, как создать диаграмму, добавить тренд‑линии к сериям диаграммы и работать с различными типами тренд‑линий, включая экспоненциальные, линейные, логарифмические, скользящие средние, полиномиальные и степенные.

Также описывается, как добавить пользовательскую линию к диаграмме, вставив форму линии, и включён короткий FAQ о значениях проекции тренд‑линий вперёд и назад, а также сохраняются ли тренд‑линии при экспорте в PDF или SVG и при рендеринге диаграмм в виде изображений.

## **Добавление тренд‑линии**

Используйте [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) для добавления тренд‑линии к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). Пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию и добавляет по две тренд‑линии к каждой из трёх её серий.

Экспоненциальная тренд‑линия скрывает своё уравнение и значение R‑квадрат с помощью [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) и [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), тогда как линейная тренд‑линия окрашена в красный цвет. Логарифмическая тренд‑линия использует [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) для пользовательской подписи. Скользящее среднее использует [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) в три точки данных и пользовательское [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Полиномиальная тренд‑линия имеет [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) равный трём и расширяется на одну категорию вперёд через [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). Степенная тренд‑линия расширяется на одну категорию назад через [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка пересечения тренд‑линии**

Используйте [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) для фиксирования значения Y тренд‑линии при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных тренд‑линий.

Например, модель стоимости производства может потребовать начала со известных фиксированных затрат в 100, даже если измерения при ненулевых объёмах производства указывают иной базовый уровень. Для линейной тренд‑линии фиксирование пересечения ограничивает уравнение `y = ax + b` до `b = 100`; наклон подбирается под данные при этом ограничении. Это не просто перемещение уже подогнанной линии. Настройки пересечения осей управляют тем, где оси диаграммы встречаются, а не коэффициентами подгонки тренд‑линии.

В следующем примере создаётся точечная (XY) диаграмма с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Диаграмма сохраняется с автоматическим пересечением по умолчанию, затем пересечение устанавливается в 100 и сохраняется второй файл PPTX. Оба файла отличаются только настройкой пересечения. Тренд‑линия отображает своё уравнение и расширяется назад до X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка пересечения в 100 вместо этого даёт примерно `y = 43.33x + 100`: подогнанное значение при нуле совпадает с известным базовым уровнем, при этом линия уже не проходит через каждую точку данных.

| Автоматический пересчёт | Фиксированное пересечение 100 |
| --- | --- |
| ![Линейная тренд‑линия с автоматически рассчитанным пересечением 140](intercept-automatic.png) | ![Линейная тренд‑линия с фиксированным пересечением 100](intercept-fixed.png) |

Оба изображения используют одни и те же данные и масштабы осей. Тренд‑линии расширены назад до X = 0, чтобы показать их пересечения.

По умолчанию [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) возвращает `Double.NaN`, что представляет неопределённое пересечение, а не ноль. Затем пересечение вычисляется автоматически из данных.

## **Добавление пользовательской линии**

Пользовательская линия — это форма, нарисованная поверх диаграммы, а не тренд‑линия, вычисленная из данных серии. Этот пример использует [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) для добавления горизонтальной линии на слайд поверх диаграммы. Позиция линии задаётся в координатах слайда в пунктах, поэтому она начинается от левого края диаграммы и располагается на половине высоты диаграммы. Её ширина совпадает с шириной диаграммы. Метод [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) задаёт линии сплошной красный цвет.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Что означают параметры «forward» и «backward» для тренд‑линии?**

Это длина части тренд‑линии, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для недиаграммных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохраняется ли тренд‑линия при экспорте презентации в PDF или SVG, а также при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/java/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; тренд‑линии, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/java/create-shape-thumbnails/).