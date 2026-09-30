---
title: Настройка легенд диаграмм в презентациях с использованием Java
linktitle: Легенда диаграммы
type: docs
url: /ru/java/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides для Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for Java предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. Эта статья показывает, как установить позицию и размер легенды, задать размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

В разделе FAQ рассматриваются связанные особенности, включая резервирование места для легенды, отображение многострочных меток и наследование форматирования из темы презентации.

## **Позиционирование легенды**

Используйте методы легенды [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-) и [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) для указания её позиции и размеров в виде долей от размеров диаграммы.

В этом примере создаётся презентация и добавляется сгруппированная столбчатая диаграмма с данными по умолчанию на первый слайд. Деление желаемых смещений и размеров легенды на ширину и высоту диаграммы преобразует их в относительные значения: легенда смещена на 50 пунктов от левого верхнего угла диаграммы и имеет размер 100 × 100 пунктов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Задает позицию и размер легенды относительно диаграммы.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить размер шрифта легенды**

Используйте метод легенды [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) для доступа к её текстовому форматированию и [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) для задания размера шрифта в пунктах.

Этот пример создаёт диаграмму с данными по умолчанию и устанавливает размер текста легенды в 20 пунктов. Он также отключает автоматические границы вертикальной оси и задаёт её диапазон от -5 до 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить размер шрифта отдельного элемента легенды**

Используйте коллекцию, возвращаемую методом легенды [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) для доступа к форматированию конкретного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` относится ко второму элементу.

В этом примере создаётся сгруппированная столбчатая диаграмма, у которой данные по умолчанию включают как минимум две серии. Второй элемент легенды форматируется полужирным, курсивом и с синим текстом размером 20 пунктов.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Скрыть отдельные элементы легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, вызовите [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) с `true` через [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Это скрывает только выбранный элемент легенды; серия и её точки данных остаются. Вызов [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) с `false`, наоборот, скрывает всю легенду.

В примере ниже создаётся сгруппированная столбчатая диаграмма с несколькими сериями, использующая данные по умолчанию. Она скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем элемент восстанавливается вызовом [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) с `false` и сохраняется вторая копия. Столбцы остаются видимыми в обоих файлах.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Восстановить тот же элемент без изменения данных диаграммы.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже показывает одну и ту же диаграмму с видимыми всеми элементами легенды и со скрытым вторым элементом. Столбцы второй серии остаются без изменений.

![Сравнение диаграммы со всеми видимыми элементами легенды и с скрытым элементом Series 2 в легенде; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, линейных и гистограммных диаграммах элементы легенды идентифицируют серии. В круговых диаграммах они идентифицируют отдельные точки данных (дольки), поэтому используйте [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) для выбранной дольки. API документирует этот метод для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не следует предполагать, что он применим к кольцевым диаграммам, которые в этом списке не указаны.

## **Часто задаваемые вопросы**

**Можно ли заставить диаграмму резервировать место для легенды вместо её наложения?**

Да. Вызовите [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) с `false`, чтобы зарезервировать место для легенды вместо её наложения на область построения.

**Можно ли сделать многострочные подписи в легенде?**

Да. Длинные подписи могут переноситься, если доступной ширины недостаточно. Вы также можете использовать символы переноса строки в названиях серий для принудительного разрыва строк.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**

Не задавайте цвета, заливки и шрифты легенды, чтобы она могла наследовать форматирование темы. Явное форматирование переопределяет соответствующие параметры темы.