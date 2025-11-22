---
title: Пузырчатая диаграмма
type: docs
url: /ru/nodejs-java/bubble-chart/
---

## **Масштабирование размеров пузырчатой диаграммы**
Aspose.Slides for Node.js via Java предоставляет поддержку масштабирования размеров пузырчатой диаграммы. В Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) и [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) добавлены новые методы. Ниже приведён пример.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Представление данных в виде размеров пузырчатой диаграммы**
В классы [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) и связанные с ними классы добавлены методы [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) и [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--). **BubbleSizeRepresentation** определяет, как значения размеров пузырей отображаются в пузырчатой диаграмме. Возможные значения: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) и [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Соответственно, в перечисление [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) добавлен для указания возможных способов представления данных в виде размеров пузырчатой диаграммы. Пример кода приведён ниже.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Поддерживается ли «пузырчатая диаграмма с 3‑D‑эффектом», и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3‑D‑оформление к пузырям, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Тип доступен в перечислении [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

**Есть ли ограничение на количество рядов и точек в пузырчатой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и целевой версией PowerPoint. Рекомендуется сохранять количество точек разумным для читаемости и скорости рендеринга.

**Как экспорт влияет на внешний вид пузырчатой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.