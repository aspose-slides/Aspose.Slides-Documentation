---
title: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/nodejs-java/doughnut-chart/
---

## **Изменение центрального промежутка в кольцевой диаграмме**
{{% alert color="primary" %}} 
Aspose.Slides для Node.js через Java теперь поддерживает указание размера отверстия в кольцевой диаграмме. В этой теме мы на примере покажем, как указать размер отверстия в кольцевой диаграмме.
{{% /alert %}} 

Для указания размера отверстия в кольцевой диаграмме выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Добавьте кольцевую диаграмму на слайд.
1. Укажите размер отверстия в кольцевой диаграмме.
1. Запишите презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Записать презентацию на диск
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли создать многоуровневую кольцевую диаграмму с несколькими кольцами?**

Да. Добавьте несколько сериалов к одной кольцевой диаграмме — каждый сериал становится отдельным кольцом. Порядок колец определяется порядком сериалов в коллекции.

**Поддерживается ли «взрывная» кольцевая диаграмма (разделённые срезы)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) и свойство взрыва у точек данных; вы можете отделять отдельные срезы.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма является фигурой; её можно отрисовать в [растровое изображение](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) или экспортировать диаграмму в [SVG‑изображение](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).