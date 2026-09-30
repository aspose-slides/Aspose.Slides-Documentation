---
title: Настройка легенд диаграмм в презентациях на Android
linktitle: Легенда диаграммы
type: docs
url: /ru/androidjava/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for Android via Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for Android via Java предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать положение и размер легенды, установить размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

В разделе FAQ рассматриваются связанные возможности, включая резервирование места для легенды, отображение многострочных подписей и наследование форматирования из темы презентации.

## **Расположение легенды**

Используйте методы легенды [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-) и [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) для указания её положения и размера в виде долей от размеров диаграммы.

В этом примере создаётся презентация и добавляется сгруппированная столбчатая диаграмма с данными по умолчанию на первый слайд. Деление желаемых смещений и размеров легенды на ширину и высоту диаграммы переводит их в относительные значения: легенда смещена на 50 пунктов от левого верхнего угла диаграммы и имеет размер 100 × 100 пунктов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Задайте позицию и размер легенды относительно диаграммы.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка размера шрифта легенды**

Получите объект форматирования текста легенды через [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) и используйте [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для задания размера шрифта в пунктах.

В этом примере создаётся диаграмма с данными по умолчанию и устанавливается размер шрифта легенды 20 пунктов. Также отключаются автоматические границы вертикальной оси и задаётся диапазон от ‑5 до 10.

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

## **Установка размера шрифта отдельного элемента легенды**

Получите коллекцию элементов легенды через метод [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) и измените форматирование нужного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` соответствует второму элементу.

В этом примере создаётся сгруппированная столбчатая диаграмма, у которой в данных по умолчанию присутствует как минимум две серии. Второй элемент легенды форматируется полужирным, курсивом и синим текстом размером 20 пунктов.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Скрытие отдельных элементов легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, вызовите [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) со значением `true` через [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Это скрывает только выбранный элемент легенды; серия и её точки данных остаются. Вызов [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) со значением `false`, напротив, скрывает всю легенду.

Пример ниже создаёт сгруппированную столбчатую диаграмму с несколькими сериями, используя данные по умолчанию. Он скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем элемент восстанавливается вызовом [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) со значением `false` и сохраняется вторичная копия. Столбцы остаются видимыми в обоих файлах.

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

Сравнение ниже показывает одну и ту же диаграмму с видимыми всеми элементами легенды и с скрытым вторым элементом. Столбцы второй серии остаются без изменений.

![Сравнение диаграммы с видимыми всеми элементами легенды и с скрытым элементом Series 2; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, гистограммных и линейных диаграммах элементы легенды идентифицируют серии. Для круговых диаграмм они идентифицируют отдельные точки данных (дольки), поэтому используйте [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) для выбранной дольки. API документирует этот метод для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не предполагайте, что он работает и для кольцевых диаграмм, которые в список не входят.

## **Вопросы и ответы**

**Могу ли я заставить диаграмму резервировать место для легенды вместо наложения её?**  
Да. Вызовите [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) со значением `false`, чтобы зарезервировать место для легенды, а не позволять ей перекрывать область построения.

**Могу ли я создавать многострочные подписи в легенде?**  
Да. Длинные подписи могут переноситься, если доступной ширины недостаточно. Вы также можете использовать символы новой строки в названиях серий для принудительного разбиения на строки.

**Как заставить легенду использовать схему цветов темы презентации?**  
Не задавайте цвета, заливки и шрифты легенды, чтобы она могла наследовать форматирование темы. Явное форматирование переопределяет соответствующие настройки темы.