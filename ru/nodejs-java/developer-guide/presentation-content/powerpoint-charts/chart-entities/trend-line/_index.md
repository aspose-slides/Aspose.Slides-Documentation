---
title: Добавление линий тренда к диаграммам презентаций на JavaScript
linktitle: Линия тренда
type: docs
url: /ru/nodejs-java/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия тренда скользящего среднего
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью JavaScript и Aspose.Slides для Node.js через Java — практическое руководство для привлечения вашей аудитории."
---
## **Обзор**

В этой статье объясняется, как добавлять линии тренда в диаграммы презентаций с помощью Aspose.Slides. Показано, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальную, линейную, логарифмическую, скользящую среднюю, полиномиальную и степенную.

Она также описывает, как добавить пользовательскую линию к диаграмме, вставив форму линии, и включает короткий FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм как изображений.

## **Добавление линии тренда**

Используйте [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add), чтобы добавить линию тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Пример создаёт группированную столбчатую диаграмму с данными по умолчанию и добавляет две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R‑квадрата с помощью [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) и [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), в то время как линейная линия тренда красная. Логарифмическая линия тренда использует [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) для пользовательской метки. Скользящая средняя использует [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) в три точки данных и пользовательский [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName).

Полиномиальная линия тренда имеет [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) равный трем и расширяется на одну категорию вперёд с помощью [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Степенная линия тренда расширяется на одну категорию назад с помощью [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка пересечения линии тренда**

Используйте [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept), чтобы зафиксировать значение Y линии тренда при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начала с известных фиксированных затрат в размере 100, даже если измерения при ненулевых объёмах производства предполагают иной базовый уровень. Для линейной линии тренда фиксирование пересечения ограничивает уравнение `y = ax + b` до `b = 100`; наклон подгоняется к данным при этом ограничении. Это не просто перемещает уже подогнанную линию. Настройки пересечения осей управляют тем, где оси диаграммы встречаются, а не коэффициентами подогнанной линии тренда.

В следующем примере создаётся точечная (XY) диаграмма с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Диаграмма сохраняется с автоматическим пересечением по умолчанию, затем пересечение устанавливается в 100 и сохраняется второй PPTX. Два файла отличаются только настройкой пересечения. Линия тренда отображает своё уравнение и протягивается назад до X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка пересечения в 100 вместо этого дает приблизительно `y = 43.33x + 100`: подгоняемое значение при нуле соответствует известному базовому уровню, тогда как линия больше не проходит через каждую точку данных.

| Автоматическое пересечение | Фиксированное пересечение 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически рассчитанным пересечением 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным пересечением 100](intercept-fixed.png) |

Оба изображения используют одни и те же данные и масштабы осей. Линии тренда протянуты назад до X = 0, чтобы показать их пересечения.

По умолчанию [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) возвращает `NaN`, что представляет собой неуказанное пересечение, а не ноль. Затем пересечение рассчитывается автоматически из данных.

## **Добавление пользовательской линии**

Пользовательская линия — это форма, нарисованная поверх диаграммы, а не линия тренда, вычисленная из данных серии. В этом примере используется [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) для добавления горизонтальной линии на слайд над диаграммой. Позиция линии задаётся в координатах слайда, измеряемых в пунктах, поэтому линия начинается от левой границы диаграммы и располагается на полпути вниз по диаграмме. Её ширина совпадает с шириной диаграммы. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) задаёт линии сплошной красный цвет.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Что означают ‘forward’ и ‘backward’ для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для не точечных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорта изображения самой диаграммы](/slides/ru/nodejs-java/create-shape-thumbnails/).