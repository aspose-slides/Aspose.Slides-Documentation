---
title: Линия тренда
type: docs
url: /ru/nodejs-java/trend-line/
---

## **Добавить линию тренда**

Aspose.Slides for Node.js via Java предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию и выбранным типом (в примере используется ChartType.ClusteredColumn).
1. Добавить экспоненциальную линию тренда для серии диаграммы 1.
1. Добавить линейную линию тренда для серии диаграммы 1.
1. Добавить логарифмическую линию тренда для серии диаграммы 2.
1. Добавить скользящее среднее как линию тренда для серии диаграммы 2.
1. Добавить полиномиальную линию тренда для серии диаграммы 3.
1. Добавить степенную линию тренда для серии диаграммы 3.
1. Записать изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Создание диаграммы с группированными столбцами
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Добавление экспоненциальной линии тренда для серии 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Добавление линейной линии тренда для серии 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Добавление логарифмической линии тренда для серии 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Добавление линии тренда скользящего среднего для серии 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Добавление полиномиальной линии тренда для серии 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Добавление степенной линии тренда для серии 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Сохранение презентации
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавить пользовательскую линию**

Aspose.Slides for Node.js via Java предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую сплошную линию на выбранный слайд презентации, выполните следующие действия:

- Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получить ссылку на слайд, используя его индекс.
- Создать новую диаграмму с помощью метода AddChart, доступного у объекта Shapes.
- Добавить AutoShape типа Line с помощью метода AddAutoShape, доступного у объекта Shapes.
- Установить цвет линий фигуры.
- Сохранить изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с пользовательскими линиями.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Что означают «forward» и «backward» у линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах оси; для недиаграммных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохраняется ли линия тренда при экспорте презентации в PDF или SVG, либо при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются при этих операциях. Также доступен метод для [экспорта изображения самой диаграммы](/slides/ru/nodejs-java/create-shape-thumbnails/).