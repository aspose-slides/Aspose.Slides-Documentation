---
title: Добавление линий тренда в диаграммы презентаций на Java
linktitle: Линия тренда
type: docs
url: /ru/java/trend-line/
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
- Java
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides for Java — практическое руководство для привлечения вашей аудитории."
---

## **Добавить линию тренда**
Aspose.Slides for Java предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и выбранным типом (в данном примере используется ChartType.ClusteredColumn).
4. Добавление экспоненциальной линии тренда для серии 1 диаграммы.
5. Добавление линейной линии тренда для серии 1 диаграммы.
6. Добавление логарифмической линии тренда для серии 2 диаграммы.
7. Добавление линии тренда скользящего среднего для серии 2 диаграммы.
8. Добавление полиномиальной линии тренда для серии 3 диаграммы.
9. Добавление степенной линии тренда для серии 3 диаграммы.
10. Запишите изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Создание диаграммы кластерных столбцов
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Добавление экспоненциальной линии тренда для серии 1 диаграммы
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Добавление линейной линии тренда для серии 1 диаграммы
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Добавление логарифмической линии тренда для серии 2 диаграммы
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Добавление линии тренда скользящего среднего для серии 2 диаграммы
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Добавление полиномиальной линии тренда для серии 3 диаграммы
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Добавление степенной линии тренда для серии 3 диаграммы
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Сохранение презентации
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавить пользовательскую линию**
Aspose.Slides for Java предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую сплошную линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- Получите ссылку на слайд, используя его индекс
- Создайте новую диаграмму с помощью метода AddChart, доступного у объекта Shapes
- Добавьте AutoShape типа Line с помощью метода AddAutoShape, доступного у объекта Shapes
- Установите цвет линий фигуры.
- Запишите изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы с пользовательскими линиями.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Что означают «forward» и «backward» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для остальных диаграмм — в количестве категорий. Допускаются только неотрицательные значения.

**Сохраняется ли линия тренда при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/java/render-a-slide-as-an-svg-image/) и отображает диаграммы в виде изображений; линии тренда, как часть диаграммы, сохраняются при этих операциях. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/java/create-shape-thumbnails/).