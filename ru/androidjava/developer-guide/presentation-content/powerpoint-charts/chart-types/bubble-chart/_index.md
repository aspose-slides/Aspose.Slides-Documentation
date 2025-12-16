---
title: Настройка пузырчатых диаграмм в презентациях на Android
linktitle: Пузырчатая диаграмма
type: docs
url: /ru/androidjava/bubble-chart/
keywords:
- пузырчатая диаграмма
- размер пузыря
- масштабирование размеров
- представление размеров
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте и настраивайте мощные пузырчатые диаграммы в PowerPoint с помощью Aspose.Slides for Android via Java, чтобы легко улучшить визуализацию данных."
---

## **Масштабирование размеров пузырчатой диаграммы**
Aspose.Slides for Android via Java предоставляет поддержку масштабирования размеров пузырчатой диаграммы. В Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) и [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) добавлены. Ниже приведён пример.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Представление данных в виде размеров пузырчатой диаграммы**
Методы [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) и [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) добавлены в интерфейсы [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) и связанные классы. **BubbleSizeRepresentation** определяет, как значения размеров пузырей представлены в пузырчатой диаграмме. Возможные значения: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) и [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Соответственно, добавлен перечисляемый тип [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType), который задаёт возможные способы представления данных как размеров пузырчатой диаграммы. Пример кода приведён ниже.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Поддерживается ли "пузырчатая диаграмма с 3‑D эффектом", и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3‑D стилизацию к пузырям, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Этот тип доступен в классе [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

**Есть ли ограничение на количество рядов и точек в пузырчатой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и целевой версией PowerPoint. Рекомендуется держать количество точек разумным для читабельности и скорости рендеринга.

**Как экспорт влияет на внешний вид пузырчатой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.