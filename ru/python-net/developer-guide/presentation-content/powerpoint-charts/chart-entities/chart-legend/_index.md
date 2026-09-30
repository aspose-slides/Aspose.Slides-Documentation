---
title: Настройка легенд диаграмм в презентациях с помощью Python
linktitle: Легенда диаграммы
type: docs
url: /ru/python-net/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for Python via .NET для оптимизации презентаций PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for Python via .NET предоставляет параметры для настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать позицию и размер легенды, установить размер шрифта для всей легенды, оформить отдельный элемент легенды и скрыть или восстановить выбранные элементы.

В FAQ рассматриваются связанные поведения, включая резервирование места для легенды, отображение многострочных подписей и наследование форматирования из темы презентации.

## **Расположение легенды**

Используйте свойства легенды [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) и [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) для указания её позиции и размеров в виде долей от размеров диаграммы.

В этом примере создаётся презентация и добавляется сгруппированная столбчатая диаграмма с данными по умолчанию на первый слайд. Деление желаемых смещений и размеров легенды на ширину и высоту диаграммы преобразует их в относительные значения: легенда смещается на 50 пунктов от верхнего левого угла диаграммы и имеет размер 100 × 100 пунктов.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Укажите положение и размер легенды относительно диаграммы.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка размера шрифта легенды**

Используйте [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) легенды для доступа к её форматированию текста и задайте [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) в пунктах.

Этот пример создаёт диаграмму с данными по умолчанию и устанавливает размер текста легенды 20 пунктов. Он также отключает автоматические границы вертикальной оси и задаёт её диапазон от -5 до 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка размера шрифта отдельного элемента легенды**

Используйте коллекцию [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) легенды для доступа к форматированию конкретного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` относится ко второму элементу.

В этом примере создаётся сгруппированная столбчатая диаграмма, у которой данные по умолчанию включают как минимум две серии. Он оформляет второй элемент легенды полужирным, курсивом и синим текстом размером 20 пунктов.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Скрытие отдельных элементов легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, установите [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) в `True` через [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Это скрывает только выбранный элемент легенды; серия и её данные не удаляются. Установка [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) в `False`, напротив, скрывает всю легенду.

Ниже пример, создающий сгруппированную столбчатую диаграмму с несколькими сериями, использующими данные по умолчанию. Он скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем восстанавливает элемент, установив [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) в `False`, и сохраняет вторую копию. Столбцы остаются видимыми в обоих файлах.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Восстановить тот же элемент без изменения данных диаграммы.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Сравнение ниже показывает одну и ту же диаграмму с видимыми всеми элементами и с скрытым вторым элементом. Столбцы второй серии остаются без изменений.

![Сравнение диаграммы со всеми видимыми элементами легенды и с скрытым элементом серии 2; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, линейных и гистограммах элементы легенды обозначают серии. В круговых диаграммах они обозначают отдельные точки данных (дольки), поэтому используйте [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) для выбранной дольки. API документирует это свойство точки данных для типов диаграмм `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` и `BAR_OF_PIE`. Не полагайтесь на его применение к кольцевым диаграммам, которые в список не входят.

## **FAQ**

**Могу ли я заставить диаграмму резервировать место для легенды вместо её накладывания?**

Да. Установите [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) в `False`, чтобы зарезервировать место для легенды вместо её перекрытия области построения.

**Могу ли я сделать подписи легенды многострочными?**

Да. Длинные подписи могут переноситься, если доступной ширины недостаточно. Вы также можете использовать символы перевода строки в названиях серий для принудительного разрыва строк.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**

Не задавайте цвета, заливки и шрифты легенды, чтобы она могла наследовать форматирование темы. Явное форматирование переопределяет соответствующие настройки темы.