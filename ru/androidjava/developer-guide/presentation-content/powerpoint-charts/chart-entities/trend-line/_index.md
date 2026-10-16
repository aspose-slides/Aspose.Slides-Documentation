---
title: Добавление линий тренда к диаграммам презентаций на Android
linktitle: Линия тренда
type: docs
url: /ru/androidjava/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия скользящего среднего
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для Android на Java — практическое руководство для вовлечения вашей аудитории."
---
## **Обзор**

В этой статье объясняется, как добавить линии тренда к диаграммам презентаций с помощью Aspose.Slides. Показано, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальные, линейные, логарифмические, скользящее среднее, полиномиальные и степенные.

Также описывается, как добавить пользовательскую линию к диаграмме, вставив форму линии, и содержится небольшой FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в изображения.

## **Добавить линию тренда**

Используйте [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) для добавления линии тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). Пример создаёт столбчатую диаграмму с группировкой по умолчанию и добавляет две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R‑квадрат с помощью [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) и [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), в то время как линейная линия тренда окрашена в красный цвет. Логарифмическая линия тренда использует [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) для пользовательской подписи. Скользящее среднее использует [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) из трёх точек данных и пользовательское [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Полиномиальная линия тренда имеет [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) = 3 и расширяется вперёд на одну категорию с помощью [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). Степенная линия тренда расширяется назад на одну категорию через [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Установить перехват линии тренда**

Используйте [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) для фиксирования значения Y линии тренда при X = 0. Этот параметр поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начать с известных фиксированных затрат в 100, даже если измерения при ненулевых объёмах производства указывают иной базовый уровень. Для линейной линии тренда фиксирование перехвата ограничивает уравнение `y = ax + b` условием `b = 100`; наклон подгоняется под данные при этом ограничении. Это не просто перемещает уже подогнанную линию. Параметры пересечения осей управляют тем, где оси диаграммы встречаются, а не коэффициентами подгоняемой линии тренда.

Следующий пример создаёт точечную (XY) диаграмму с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Он сохраняет диаграмму с автоматически вычисляемым перехватом, затем устанавливает перехват = 100 и сохраняет второй PPTX. Оба файла отличаются только настройкой перехвата. Линия тренда отображает своё уравнение и расширяется обратно до X = 0.

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

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка перехвата в 100 вместо этого приводит к приблизительно `y = 43.33x + 100`: подогнанное значение при нуле совпадает с известным базовым уровнем, тогда как линия больше не проходит через каждую точку данных.

| Автоматический перехват | Фиксированный перехват 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически рассчитанным перехватом 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным перехватом 100](intercept-fixed.png) |

Оба изображения используют одни и те же данные и масштабы осей. Линии тренда расширены обратно до X = 0, чтобы показать их перехваты.

По умолчанию [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) возвращает `Double.NaN`, что представляет неустановленный перехват, а не ноль. Затем перехват рассчитывается автоматически из данных.

## **Добавить пользовательскую линию**

Пользовательская линия — это фигура, нарисованная поверх диаграммы, а не линия тренда, вычисленная из данных серии. В этом примере используется [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) для добавления горизонтальной линии на слайд над диаграммой. Позиция линии задаётся в координатах слайда в пунктах, поэтому она начинается у левого края диаграммы и находится посередине её высоты. Ширина линии совпадает с шириной диаграммы. [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) задаёт линии сплошной красный цвет.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

**Что означают параметры «forward» и «backward» для линии тренда?**

Это длины линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для остальных — в количестве категорий. Допустимы только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, а также при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/androidjava/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорта изображения самой диаграммы](/slides/ru/androidjava/create-shape-thumbnails/).