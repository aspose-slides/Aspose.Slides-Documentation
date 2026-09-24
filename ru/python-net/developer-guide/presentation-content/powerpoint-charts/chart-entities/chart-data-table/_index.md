---
title: Настройка таблиц данных диаграмм в презентациях на Python
linktitle: Таблица данных
type: docs
url: /ru/python-net/chart-data-table/
keywords:
  - данные диаграммы
  - таблица данных
  - свойства шрифта
  - PowerPoint
  - презентация
  - Python
  - Aspose.Slides
description: "Настройте шрифты, границы и ключи легенды таблицы данных диаграммы в презентациях PowerPoint с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET позволяет отображать таблицу данных диаграммы и настраивать форматирование её текста, границы и ключи легенды. В этой статье объясняется, как включить таблицу, форматировать её текст, управлять каждым типом границы и показывать или скрывать ключи легенды. Примеры сохраняют настроенные диаграммы в файлах PPTX.

## **Установка свойств шрифта**

Чтобы отобразить таблицу данных диаграммы, установите [has_data_table](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/has_data_table/) в `True`. Используйте [chart_data_table](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/chart_data_table/) для доступа к таблице и настройки её форматирования текста.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Добавьте сгруппированную столбчатую диаграмму на первый слайд.
1. Включите таблицу данных диаграммы.
1. Включите полужирный шрифт с помощью [font_bold](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/font_bold/) и установите [font_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/font_height/) в `20` для текста размером 20 пунктов.
1. Сохраните изменённую презентацию.

Следующий пример требует файл `test.pptx` в рабочем каталоге, содержащий хотя бы один слайд. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) с шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включённой таблицей данных и применёнными указанными настройками шрифта.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Настройка границ таблицы данных**

Включите таблицу с помощью [Chart.has_data_table](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/has_data_table/) и получите к ней доступ через [Chart.chart_data_table](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/chart_data_table/). Вы можете управлять тремя типами границ независимо:

- [has_border_horizontal](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datatable/has_border_horizontal/) управляет горизонтальными границами ячеек.
- [has_border_vertical](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datatable/has_border_vertical/) управляет вертикальными границами ячеек.
- [has_border_outline](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datatable/has_border_outline/) управляет внешней границей таблицы.

Установите каждое свойство в `True`, чтобы отобразить соответствующие границы, или в `False`, чтобы скрыть их. Следующий пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, скрывая вертикальные границы. Входной файл не требуется. Позиция и размер диаграммы задаются в пунктах.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Сравнение ниже использует одни и те же данные диаграммы и настройку ключей легенды во всех четырёх случаях. Начиная со всех включённых границ, каждый последующий вариант отключает только одно свойство границы. Нижний‑левый вариант соответствует настройкам границ в примере.

![Таблицы данных диаграмм со всеми включёнными границами, без горизонтальных границ, без вертикальных границ и без внешней границы](data-table-borders.png)

## **Показ или скрытие ключей легенды**

Ключи легенды — небольшие цветные маркеры рядом с названиями рядов в таблице данных. Они помогают читателям сопоставлять каждую строку таблицы с рядом диаграммы. Установите [show_legend_key](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datatable/show_legend_key/) в `True`, чтобы показывать эти маркеры, или в `False`, чтобы скрыть их.

Отдельная легенда диаграммы управляется свойством [Chart.has_legend](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/has_legend/). Эти настройки независимы: скрытие отдельной легенды не скрывает ключи внутри таблицы данных, и скрытие ключей таблицы не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и показывает ключи легенды внутри неё, одновременно скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только ключи таблицы, измените `data_table.show_legend_key` на `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Сравнение ниже показывает одну и ту же таблицу с включёнными и отключёнными ключами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Таблицы данных диаграмм с показанными слева и скрытыми справа ключами легенды](data-table-legend-keys.png)

## **FAQ**

**Могу ли я показывать ключи легенды в таблице данных диаграммы?**

Да. Установите [show_legend_key](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datatable/show_legend_key/) в `True`, чтобы отобразить ключи легенды, или в `False`, чтобы скрыть их.

**Сохраняется ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму и её отображаемую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) или [изображения](/slides/ru/python-net/convert-powerpoint-to-png/).

**Можно ли работать с таблицами данных в диаграммах, загруженных из шаблона?**

Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [has_data_table](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/has_data_table/) для проверки или изменения того, отображается ли её таблица данных.

**Как найти диаграммы, у которых включена таблица данных?**

Итерируйте формы на каждом слайде, определяйте диаграммы и проверяйте их свойство [has_data_table](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/has_data_table/). Значение `True` указывает, что таблица данных включена.